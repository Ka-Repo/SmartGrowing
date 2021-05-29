using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace xamarin_app.Models
{
	public class Plant : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		string _id;
		[JsonProperty("id")]
		public string Id
		{
			get => _id;
			set
			{
				if (_id == value)
					return;

				_id = value;

				HandlePropertyChanged();
			}
		}

		string _name;
		[JsonProperty("name")]
		public string Name
		{
			get => _name;
			set
			{
				if (_name == value)
					return;

				_name = value;

				HandlePropertyChanged();
			}
		}

		string _description;
		[JsonProperty("Description")]
		public string Description
		{
			get => _description;
			set
			{
				if (_description == value)
					return;

				_description = value;

				HandlePropertyChanged();
			}
		}

		string _temperature;
		[JsonProperty("Temperature")]
		public string Temperature
		{
			get => _temperature;
			set
			{
				if (_temperature == value)
					return;

				_temperature = value;

				HandlePropertyChanged();
			}
		}

		string _humidity;
		[JsonProperty("Humidity")]
		public string Humidity
		{
			get => _humidity;
			set
			{
				if (_humidity == value)
					return;

				_humidity = value;

				HandlePropertyChanged();
			}
		}

		void HandlePropertyChanged([CallerMemberName] string propertyName = "")
		{
			var eventArgs = new PropertyChangedEventArgs(propertyName);

			PropertyChanged?.Invoke(this, eventArgs);
		}
	}
}