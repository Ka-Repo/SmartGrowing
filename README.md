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

- Raspberry pi, breadboard and dht11 sensor
- Python > 3.5
- Azure Account
- Azure Event Hub

<br>

## Getting started I - Raspberry Pi

Follow these steps to setup a Raspberry Pi which reads DHT11 sensor data and sends them to an Azure Event Hub.

<br>

On your Raspberry Pi run the following commands:

<br>

1. Install Python and DHT11-Toolkit.

   ```
   sudo apt-get update

   sudo apt-get install build-essential python3-dev

   git clone https://github.com/coding-world/Python_DHT.git

   cd Python_DHT

   sudo python3 setup.py install

   ```

2. Install Azure Event Hub package for python.

   ```
   pip3 install azure-eventhub

   pip3 install azure-eventhub-checkpointstoreblob-aio
   ```

3. Add the following lines to your /home/pi/.profile (right click -> show hidden files, if bash is your login shell as per default on raspbian) to establish os variables containing your Event Hub auth information. Replace `<your-connection-string>` and `<your-event-hub-name>` with your Azure Event Hub connection string and name under SAS (Shared Access Signature) in your azure account.

   ```
   EVENT_HUB_CONN_STR=Endpoint='<your-connection-string>'

   export EVENT_HUB_CONN_STR

   EVENT_HUB_NAME='<your-event-hub-name>'

   export EVENT_HUB_NAME
   ```

4. Connect DHT11 sensor.

   ```
   Plugin DHT11 sensor into breadboard.

   Connect 4.7 Ω resistor (yellow, purple, black, brown, gold) to pin 1 and 2 on the DHT11.

   Connect 3.3 V power supply (pin 1 on Raspberry Pi 3) to pin 1 on DHT11.

   Connect gpio 4 on Raspberry Pi (pin 7) to DHT11 pin 2.

   Connect ground (pin 9 on Raspberry Pi 3) to DHT11 pin 4.

   ```

   The setup should look like this.

   <br>
   <img src="raspberrypi_setup.png" alt="raspberry pi connected to dht11 sensor" height="300">

<br>

5. Create cron-job to execute smart_growing.py every minute.

   ```
   crontab -e

   Add * * * * * . $HOME/.profile; python3 /home/pi/<path-to-script>/smart_growing.py >> /home/pi/log.txt to end of file.

   Check out https://crontab.guru/ for examples on how to use cron.
   ```

<br>
Now you should be able to run the SmartGrowing/python_scripts/smart_growing.py script from this repository.

To set up an Event Hub continue to section II.

<br>

## Getting started II - Azure

<br>

## Getting started III - Xamarin.Forms
