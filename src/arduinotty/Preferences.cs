using System;
using System.IO;
using System.Xml.Serialization;

namespace arduinotty
{
	[Serializable]
	public class Preferences
	{
		public bool UseLastUsedSettings = true;
		public int LastUsedBaudrate = 9600;
		public int LastUsedBytesView = 0;
		public int Baudrate = 9600;
		public int BytesView = 0;
		public string Font = "Sans 10";
		public bool ShowSymbol = true;
		
		public Preferences()
		{
		}
		
		public static void SavePreferences(string filename, Preferences p)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Preferences));
				FileStream fs = new FileStream(filename, FileMode.Create);
				serializer.Serialize(fs, p);
				fs.Close();
			}
			catch
			{}
		}
		
		public static Preferences LoadPreferences(string filename)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Preferences));
				FileStream fs = new FileStream(filename, FileMode.Open);
				Preferences p = (Preferences)serializer.Deserialize(fs);
				fs.Close();
				return p;
			}
			catch
			{
				return new Preferences();
			}
		}
	}
}

