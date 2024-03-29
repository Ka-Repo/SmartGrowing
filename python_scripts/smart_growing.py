import Python_DHT
import time
import asyncio
import os 

from azure.eventhub.aio import EventHubProducerClient
from azure.eventhub import EventData

CONNECTION_STR = os.environ['EVENT_HUB_CONN_STR']
EVENTHUB_NAME = os.environ['EVENT_HUB_NAME']

sensor = Python_DHT.DHT11
pin = 4


async def send_async(messages):
    # Create a producer client to send messages to the event hub.
    # Specify a connection string to your event hubs namespace and
    # the event hub name.
    producer = EventHubProducerClient.from_connection_string(
        conn_str=CONNECTION_STR,
        eventhub_name=EVENTHUB_NAME
    )
    async with producer:
        # Create a batch.
        event_data_batch = await producer.create_batch()

        # Add events to the batch.
        for message in messages:
            event_data_batch.add(EventData(message))

        # Send the batch of events to the event hub.
        await producer.send_batch(event_data_batch)

if __name__ == "__main__":
    humidity, temperature = Python_DHT.read_retry(sensor, pin)

    # Wait for async request to complete.
    loop = asyncio.get_event_loop()
    start_time = time.time()
    loop.run_until_complete(send_async([str(humidity) + " " + str(temperature)]))

    print("Sent messages in {} seconds.".format(time.time() - start_time))
    print('Sent temperature: {0:0.1f} C'.format(temperature) + ' to Azure.')
    print('Sent humidity:    {0:0.1f} %'.format(humidity) + ' to Azure.')
