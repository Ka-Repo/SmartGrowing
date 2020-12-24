# SmartGrowing
Serverless application monitoring plant growth affecting data using a Raspberry Pi and the Azure cloud

<br>

## Preprequisites
- Raspberry pi with dht11 sensor
- Python > 3.5
- Azure Account
- Azure Event Hub


<br>

## Getting started

<br>

1. Install Azure Eventhub package for python

    ``` 
    pip3 install azure-eventhub

2. Replace connection string `CONNECTION_STR` and Azure Event Hub Name `EVENTHUB_NAME` with your Azure Event Hub connection string and name under SAS (Shared Access Signature)

    ```
    CONNECTION_STR = '<your-connection-string>'
    EVENTHUB_NAME = '<your-event-hub-name>'
    ```

