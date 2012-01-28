using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using Gtk;
using libarduinotty;

namespace libarduinotty.Widgets
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ConnectionWidget : Gtk.Bin
	{
		
		private bool p_BaudrateVisible = false;
		private string[] p_SerialPorts;
		private EventHandler p_RefreshUIEvent;
		private bool p_Refreshing = false;
		private List<string> p_NewSerialPorts = new List<string>();
		private List<string> p_RemovedSerialPorts = new List<string>();
		private Thread p_CheckPorts;
		private string p_CurrentSelectedPort = "";
		
		public int Baudrate
		{
			get 
			{ return Convert.ToInt32(BaudrateSpinButton.Value); }
			set
			{ BaudrateSpinButton.Value = Convert.ToDouble(value); }
		}
		public bool HideBaudrate
		{
			get { return !p_BaudrateVisible; }
			set
			{
				p_BaudrateVisible = !value;
				if(BaudrateLabel != null)
				{
					if(p_BaudrateVisible)
					{
						BaudrateLabel.Show();
					}
					else
					{
						BaudrateLabel.Hide();
					}
				}
				if(BaudrateSpinButton != null)
				{
					if(p_BaudrateVisible)
					{
						BaudrateSpinButton.Show();
					}
					else
					{
						BaudrateSpinButton.Hide();
					}
				}
			}
		}
		
		public ConnectionWidget()
		{
			this.Build();
			ConnectToggleButton.TooltipMarkup = Mono.Unix.Catalog.GetString("Connect.");
			PortComboBox.TooltipMarkup = Mono.Unix.Catalog.GetString("Available ports.");
			BaudrateSpinButton.TooltipMarkup = Mono.Unix.Catalog.GetString("Baudrate.");
			p_SerialPorts = ArduinoSerial.AvailablePorts;
			ArduinoSerial.Connection += new EventHandler(OnConnection);
			ArduinoSerial.Disconnection += new EventHandler(OnDisconnection);
			RefreshUI(new object(), new EventArgs());
			p_RefreshUIEvent += new EventHandler(RefreshUI);
			p_CheckPorts = new Thread(new ThreadStart(CheckPorts));
			p_CheckPorts.Start();
		}
		
		
		private void RefreshUI(object sender, EventArgs e)
		{
			if(p_SerialPorts.Length > 0)
			{
				int index = 0;
				ListStore store = new ListStore(typeof(string));
				PortComboBox.Model = store;
				for(int i = 0; i < p_SerialPorts.Length; i++)
				{
					store.AppendValues(p_SerialPorts[i]);
				}
				if(p_NewSerialPorts.Count > 0)
				{
					for(int i = 0; i < p_SerialPorts.Length; i++)
					{
						if(p_SerialPorts[i] == p_NewSerialPorts[0])
						{
							index = i;
						}
					}
				}
				else
				{
					
					if(p_RemovedSerialPorts.Count > 0)
					{
						bool exists = false;
						for(int i = 0; i < p_RemovedSerialPorts.Count; i++)
						{
							if(p_RemovedSerialPorts[i] == p_CurrentSelectedPort) exists = true;
						}
						if(!exists)
						{
							for(int i = 0; i < p_SerialPorts.Length; i++)
							{
								if(p_SerialPorts[i] == p_CurrentSelectedPort) index = i;
							}
						}
					}					
				}
				PortComboBox.Active = index;
				p_CurrentSelectedPort = p_SerialPorts[index];
				PortComboBox.Sensitive = true;
			}
			else
			{
				ListStore store = new ListStore(typeof(string));
				PortComboBox.Model = store;
				PortComboBox.Sensitive = false;
			}
			p_Refreshing = false;
		}

		protected void OnConnectToggleButtonClicked(object sender, System.EventArgs e)
		{
			if(ConnectToggleButton.Active)
			{
				if((PortComboBox.ActiveText != "") && (ArduinoSerial.AvailablePorts.Length > 0))
				{
					bool connected = ArduinoSerial.Connect(PortComboBox.ActiveText, Convert.ToInt32(BaudrateSpinButton.Value));
				}
			}
			else
			{
				if(ArduinoSerial.Connected)
				{
					ArduinoSerial.Disconnect();
				}
			}
		}
		
		protected override void OnShown()
		{
			base.OnShown();
			if(p_BaudrateVisible == false) 
			{
				if(BaudrateLabel != null) BaudrateLabel.Hide();
				if(BaudrateSpinButton != null) BaudrateSpinButton.Hide();
			}
		}
			
		private void OnConnection(object sender, EventArgs e)
		{
			ConnectToggleButton.Active = true;
			PortComboBox.Sensitive = false;
			BaudrateSpinButton.Sensitive = false;
			ConnectToggleButton.TooltipText = Mono.Unix.Catalog.GetString("Disconnect.");
			for(int i = 0; i < p_SerialPorts.Length; i++)
			{
				if(p_SerialPorts[i] == ArduinoSerial.Port) PortComboBox.Active = i;
			}
		}
		
		private void OnDisconnection(object sender, EventArgs e)
		{
			ConnectToggleButton.Active = false;
			PortComboBox.Sensitive = true;
			BaudrateSpinButton.Sensitive = true;
			ConnectToggleButton.TooltipText = Mono.Unix.Catalog.GetString("Connect.");
		}
	
		public void StopCheckPortsThread()
		{
			if(p_CheckPorts != null)
			{
				p_CheckPorts.Abort();
				p_CheckPorts.Join();
				p_CheckPorts = null;
			}
		}
		
		private void CheckPorts()
		{
			try
			{
				bool exists;
				string[] serialPorts;
				List<string> newPorts = new List<string>();
				List<string> removedPorts = new List<string>();
				while(true)
				{
					try
					{
						if(!ArduinoSerial.Connected && !p_Refreshing)
						{
							newPorts.Clear();
							removedPorts.Clear();
							serialPorts = ArduinoSerial.AvailablePorts;
							for(int i = 0; i < serialPorts.Length; i++)
							{
								exists = false;
								for(int g = 0; g < p_SerialPorts.Length; g++)
								{
									if(serialPorts[i] == p_SerialPorts[g])
									{
										exists = true;
										break;
									}
								}
								if(!exists) newPorts.Add(serialPorts[i]);
							}
							for(int i = 0; i < p_SerialPorts.Length; i++)
							{
								exists = false;
								for(int g = 0; g < serialPorts.Length; g++)
								{
									if(p_SerialPorts[i] == serialPorts[g])
									{
										exists = true;
										break;
									}
								}
								if(!exists) removedPorts.Add(p_SerialPorts[i]);
							}
							p_SerialPorts = serialPorts;
							if((newPorts.Count > 0) || (removedPorts.Count > 0))
							{
								p_Refreshing = true;
								p_NewSerialPorts.Clear();
								for(int i = 0; i < newPorts.Count; i++)
								{
									p_NewSerialPorts.Add(newPorts[i]);
								}
								for(int i = 0; i < removedPorts.Count; i++)
								{
									p_RemovedSerialPorts.Add(removedPorts[i]);
								}
								if(p_RefreshUIEvent != null) Gtk.Application.Invoke(p_RefreshUIEvent);
							}
						}
					}
					catch(System.IO.IOException)
					{}
				}
			
			
			}
			catch(ThreadAbortException)
			{
			}
		}

		protected void OnPortComboBoxChanged (object sender, System.EventArgs e)
		{
			p_CurrentSelectedPort = PortComboBox.ActiveText;
		}
	}
}

