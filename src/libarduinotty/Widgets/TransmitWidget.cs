using System;
using System.Collections.Generic;

namespace libarduinotty.Widgets
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class TransmitWidget : Gtk.Bin
	{
		
		private bool p_ReturnPressed = false;
		private List<string> p_Lines;
		private List<int> p_LineTypes;
		private int p_Index = 0;
		public bool Error
		{
			get
			{
				if(ArduinoSerial.Connected)
				{
					bool error = false;
					List<byte> list = new List<byte>();
					if(ComboBox.Active == 4)
					{
						try
						{
							for(int i = 0; i < ComboBoxEntry.ActiveText.Length; i++)
							{
								list.Add(Convert.ToByte(ComboBoxEntry.ActiveText[i]));
							}
							if(ComboBoxEntry.ActiveText.Length == 0) error = true;
						}
						catch(System.Exception)
						{
							error = true;
						}
					}
					else
					{
						char[] seperator = { ':' };
						string[] splitted = ComboBoxEntry.ActiveText.Split(seperator);
						try
						{
							for(int i = 0; i < splitted.Length; i++)
							{
								switch(ComboBox.Active)
								{
									case 0:
										list.Add(Convert.ToByte(splitted[i], 2));
										break;
									case 1:
										list.Add(Convert.ToByte(splitted[i], 8));
										break;
									case 2:
										list.Add(Convert.ToByte(splitted[i], 10));
										break;
									case 3:
										list.Add(Convert.ToByte(splitted[i], 16));
										break;
								}
							}
						}
						catch(System.Exception)
						{
							error = true;
						}
					}
					return error;
				}
				else
				{
					return true;
				}
			}
		}
		
		public List<byte> Bytes
		{
			get
			{
				List<byte> list = new List<byte>();
				if(ComboBox.Active == 4)
				{
					try
					{
						for(int i = 0; i < ComboBoxEntry.ActiveText.Length; i++)
						{
							list.Add(Convert.ToByte(ComboBoxEntry.ActiveText[i]));
						}
					}
					catch(System.Exception)
					{
						list.Clear();
					}
				}
				else
				{
					char[] seperator = { ':' };
					string[] splitted = ComboBoxEntry.ActiveText.Split(seperator);
					try
					{
						for(int i = 0; i < splitted.Length; i++)
						{
							switch(ComboBox.Active)
							{
								case 0:
									list.Add(Convert.ToByte(splitted[i], 2));
									break;
								case 1:
									list.Add(Convert.ToByte(splitted[i], 8));
									break;
								case 2:
									list.Add(Convert.ToByte(splitted[i], 10));
									break;
								case 3:
									list.Add(Convert.ToByte(splitted[i], 16));
									break;
							}
						}
					}
					catch(System.Exception)
					{
						list.Clear();
					}
				}
				return list;
			}
		}
		
		public TransmitWidget()
		{
			this.Build();
			p_Lines = new List<string>();
			p_LineTypes = new List<int>();
			ArduinoSerial.Connection += new EventHandler(OnConnection);
			ArduinoSerial.Disconnection += new EventHandler(OnDisconnection);
		}

		protected void OnComboBoxChanged(object sender, System.EventArgs e)
		{
			if(Error)
			{
				Button.Sensitive = false;
			}
			else
			{
				Button.Sensitive = true;
			}
		}

		protected void OnButtonClicked(object sender, System.EventArgs e)
		{
			TransmitBytes();
		}
		
		private void TransmitBytes()
		{
			if(!Error)
			{
				ArduinoSerial.TransmitBytes(Bytes);
				bool exists = false;
				for(int i = 0; i < p_Lines.Count; i++)
				{
					if((ComboBoxEntry.ActiveText == p_Lines[i]) && (ComboBox.Active == p_LineTypes[i])) exists = true;
				}
				if(!exists)
				{
					string text = "";
					switch(ComboBox.Active)
					{
						case 0:
							text = text + "Bin: ";
							break;
						case 1:
							text = text + "Oct: ";
							break;
						case 2:
							text = text + "Dec: ";
							break;
						case 3:
							text = text + "Hex: ";
							break;
					}
					text = text + ComboBoxEntry.ActiveText;
					p_Lines.Add(ComboBoxEntry.ActiveText);
					p_LineTypes.Add(ComboBox.Active);
					ComboBoxEntry.AppendText(text);
				}
				ComboBoxEntry.Entry.Text = "";
			}
		}

		protected void OnComboBoxEntryChanged(object sender, System.EventArgs e)
		{
			if(ComboBoxEntry.Active == -1)
			{
				if(Error)
				{
					Button.Sensitive = false;
				}
				else
				{
					Button.Sensitive = true;
				}
			}
			else
			{
				Console.Out.WriteLine(p_LineTypes.Count);
				Console.Out.WriteLine(ComboBoxEntry.Active);
				Console.Out.WriteLine();
				ComboBox.Active = p_LineTypes[ComboBoxEntry.Active];
				ComboBoxEntry.Entry.Text = p_Lines[ComboBoxEntry.Active];

				if(Error)
				{
					Button.Sensitive = false;
				}
				else
				{
					Button.Sensitive = true;
				}
			}
		}
		
		private void OnConnection(object sender, EventArgs e)
		{
			if(Error)
			{
				Button.Sensitive = false;
			}
			else
			{
				Button.Sensitive = true;
			}		
		}
		
		private void OnDisconnection(object sender, EventArgs e)
		{
			Button.Sensitive = false;
		}

		protected void OnComboBoxEntryKeyPressEvent(object o, Gtk.KeyPressEventArgs args)
		{
			if(args.Event.Key == Gdk.Key.Return) p_ReturnPressed = true;
		}

		protected void OnComboBoxEntryKeyReleaseEvent(object o, Gtk.KeyReleaseEventArgs args)
		{
			if(args.Event.Key == Gdk.Key.Return)
			{
				TransmitBytes();
				p_ReturnPressed = false;
			}
		}
	}
}

