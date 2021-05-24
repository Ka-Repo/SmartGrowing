using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace xamarin_app.Models
{
    public class User : INotifyPropertyChanged
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

		string _email;
		[JsonProperty("email")]
		public string Name
		{
			get => _email;
			set
			{
				if (_email == value)
					return;

				_email = value;

				HandlePropertyChanged();
			}
		}

		string _password;
		[JsonProperty("password")]
		public string Category
		{
			get => _password;
			set
			{
				if (_password == value)
					return;

				_password = value;

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
