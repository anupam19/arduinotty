using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Xml.Serialization;

namespace libarduinotty
{
	public static class ArduinoSerial
	{
		#region Privates
		private static SerialPort p_SerialPort;
		private static string p_Port;
		private static int p_BaudRate;
		private static Thread p_CheckInputDataThread;
		private static Stream p_BaseStream;
		private static List<List<byte>> p_ReceivedBytesBuffers = new List<List<byte>>();
		private static List<List<byte>> p_TransmittedBytesBuffers = new List<List<byte>>();
		#endregion
		
		#region Publics
		public static EventHandler BytesReceived;
		public static EventHandler BytesTransmitted;
		public static EventHandler Connection;
		public static EventHandler Disconnection;
		public static string Port
		{
			get { return p_Port; }
		}
		public static int BaudRate
		{
			get { return p_BaudRate; }
		}
		public static bool Connected
		{
			get 
			{
				if(p_SerialPort != null)
				{
					return p_SerialPort.IsOpen;
				}
				else
				{
					return false;
				}
			}
		}
		public static string[] AvailablePorts
		{
			get { return SerialPort.GetPortNames(); }
		}
		public static bool FreezeReceivedBytes = false;
		public static bool FreezeTransmittedBytes = false;
		#endregion

		#region Public methods
		public static bool Connect(string portName, int baudrate)
		{
			if(Connected) return false;
			string os = Environment.OSVersion.Platform.ToString();
			try
			{
				p_Port = portName;
				p_BaudRate = baudrate;
				p_SerialPort = new SerialPort( portName, p_BaudRate, Parity.None, 8,StopBits.One );
				p_SerialPort.Handshake = Handshake.None;
				p_SerialPort.Open();
				if ( os == "Unix" )
				{
					p_SerialPort.RtsEnable = false;
					for (int i = 0; i < 8; i++)
					{
						//Thread.Sleep( 250 );
					}
				}
				if(p_SerialPort.IsOpen)
				{
					p_BaseStream = p_SerialPort.BaseStream;
					p_SerialPort.DiscardInBuffer();
					p_CheckInputDataThread = new Thread(new ThreadStart(CheckInputData));
					p_CheckInputDataThread.Start();
					if(Connection != null) Gtk.Application.Invoke(Connection);
					return true;
				}
				else
				{
					DisconnectSafely();
					return false;
				}
			}
			catch
			{
				DisconnectSafely();
				return false;
			}
		}
		public static bool Disconnect()
		{
			if(!Connected )
			{
				return false;
			}
			if(p_CheckInputDataThread != null)
			{
				p_CheckInputDataThread.Abort();
				p_CheckInputDataThread.Join();
				p_CheckInputDataThread = null;
			}
			return true;
		}
		public static void AddReceivedBytesBuffer(List<byte> buffer)
		{
			if(buffer != null) p_ReceivedBytesBuffers.Add(buffer);
		}
		public static void AddTransmittedBytesBuffer(List<byte> buffer)
		{
			if(buffer != null) p_TransmittedBytesBuffers.Add(buffer);
		}
		public static void TransmitBytes(byte[] writeBuffer)
		{
			if ( !Connected )
			{
				return;
			}
			p_SerialPort.Write(writeBuffer, 0, writeBuffer.Length);
			if(!FreezeTransmittedBytes)
			{
				for(int i = 0; i < writeBuffer.Length; i++)
				{
					for(int g = 0; g < p_TransmittedBytesBuffers.Count; g++)
					{
						if(p_TransmittedBytesBuffers[g] != null)
						{
							p_TransmittedBytesBuffers[g].Add(writeBuffer[i]);
						}
					}
				}
			}
			if(BytesTransmitted != null) Gtk.Application.Invoke(BytesTransmitted);
		}
		public static void TransmitBytes(List<byte> writeBuffer)
		{
			TransmitBytes(writeBuffer.ToArray());
		}
		public static void SaveBufferAXML(string filename, List<byte> buffer)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<byte>));
				FileStream fs = new FileStream(filename, FileMode.Create);
				serializer.Serialize(fs, buffer);
				fs.Close();
			}
			catch
			{}
		}
		
		public static List<byte> LoadBufferAXML(string filename)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<byte>));
				FileStream fs = new FileStream(filename, FileMode.Open);
				List<byte> l = (List<byte>)serializer.Deserialize(fs);
				fs.Close();
				return l;
			}
			catch
			{
				return new List<byte>();
			}
		}
		
		public static void SaveBufferTXT(string filename, List<byte> buffer)
		{
			try
			{
				TextWriter tw = new StreamWriter(filename);
				System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
				tw.Write(enc.GetString(buffer.ToArray()));
				tw.Close();
			}
			catch
			{}
		}
		
		public static List<byte> LoadBufferTXT(string filename)
		{
			try
			{
				TextReader tr = new StreamReader(filename);
				string text = tr.ReadToEnd();
				tr.Close();
				System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
				List<byte> bytes = new List<byte>(enc.GetBytes(text));
    			return bytes;
			}
			catch
			{
				return new List<byte>();
			}
		}
		
		public static void SaveBufferBIN(string filename, List<byte> buffer)
		{
			try
			{
				FileStream fs = new FileStream(filename, FileMode.Create);
				BinaryWriter bw = new BinaryWriter(fs);
				bw.Write(buffer.ToArray());
				bw.Close();
			}
			catch
			{}
		}
		
		public static List<byte> LoadBufferBIN(string filename)
		{
			try
			{
				FileStream fs = new FileStream(filename, FileMode.Open);
				BinaryReader br = new BinaryReader(fs);
				List<byte> bytes = new List<byte>(br.ReadBytes(Convert.ToInt32(br.BaseStream.Length)));
				br.Close();
    			return bytes;
			}
			catch
			{
				return new List<byte>();
			}
		}
		
		#endregion
		
		#region Private methods
		private static void CheckInputData()
		{
			try
			{
				while(true)
				{
					if(p_SerialPort.BytesToRead > 0)
					{
						byte[] readBuffer = new byte[p_SerialPort.BytesToRead];
						p_SerialPort.Read(readBuffer, 0, readBuffer.Length);
						if(!FreezeReceivedBytes)
						{
							for(int i = 0; i < readBuffer.Length; i++)
							{
								Console.Out.WriteLine(readBuffer[i]);
								for(int g = 0; g < p_ReceivedBytesBuffers.Count; g++)
								{
									if(p_ReceivedBytesBuffers[g] != null)
									{
										p_ReceivedBytesBuffers[g].Add(readBuffer[i]);
									}
								}
							}
							if(BytesReceived != null) Gtk.Application.Invoke(BytesReceived);
						}
					}
				}
			}
			catch(Exception)
			{
				DisconnectSafely();
			}
		}
		
		private static void DisconnectSafely()
		{
			if(p_SerialPort != null)
			{
				if(p_SerialPort.IsOpen)
				{
					try
					{
						p_BaseStream.Close();
					}
					catch
					{}
					p_SerialPort.Close();
				}
				p_SerialPort = null;
			}
			if(Disconnection != null) Gtk.Application.Invoke(Disconnection);
		}
		#endregion
	}
}

