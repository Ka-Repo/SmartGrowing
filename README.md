<h1 align="center">SmartGrowing</h1>

<p align="center">
  <img src="xamarin_app\xamarin_app.Android\Resources\mipmap-xxxhdpi\icon.png" alt="SmartGrowing icon" height="245" >
  <br>
  <i>Serverless application monitoring plant growth affecting data using a Raspberry Pi and the Azure cloud.
  <br>
</p>

<br>
<hr>
<br>

## Preprequisites

- Raspberry pi with dht11 sensor
- Python > 3.5
- Azure Account
- Azure Event Hub

<br>

## Getting started I - Raspberry Pi

Follow these steps to setup a Raspberry Pi which reads DHT11 sensor data and sends them to Azure.

<br>

1. Install Azure Eventhub package for python

   ```
   pip3 install azure-eventhub

   ```

2. Replace connection string `CONNECTION_STR` and Azure Event Hub Name `EVENTHUB_NAME` with your Azure Event Hub connection string and name under SAS (Shared Access Signature)

   ```
   CONNECTION_STR = '<your-connection-string>'
   EVENTHUB_NAME = '<your-event-hub-name>'
   ```
