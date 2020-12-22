import Python_DHT

sensor = Python_DHT.DHT11
pin = 4

humidity, temperature = Python_DHT.read_retry(sensor, pin)

print('Temperatur: {0:0.1f} C'.format(temperature))
print('Luftfeuchtigkeit:    {0:0.1f} %'.format(humidity))