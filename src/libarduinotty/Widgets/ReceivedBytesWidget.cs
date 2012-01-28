using System;
using System.Collections.Generic;
using Gtk;
using libarduinotty;

namespace libarduinotty.Widgets
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ReceivedBytesWidget : Gtk.Bin
	{
		private bool p_HideNewButton = false;
		private bool p_HideOpenButton = false;
		private bool p_HideSaveButton = false;
		private bool p_HideTransmitButton = false;
		private NodeStore p_NodeStore;
		private List<byte> p_AllReceivedBytes;
		private List<byte> p_ReceivedBytes;
		private List<ByteTreeNode> p_ByteTreeNodes;
		
		public bool HideNewButton
		{
			get 
			{
				return p_HideNewButton;
			}
			set
			{
				p_HideNewButton = value;
				if(p_HideNewButton)
				{
					if(NewButton != null) NewButton.Show();
				}
				else
				{
					if(NewButton != null) NewButton.Hide();
				}
			}
		}
		public bool HideOpenButton
		{
			get 
			{
				return p_HideOpenButton;
			}
			set
			{
				p_HideOpenButton = value;
				if(p_HideOpenButton)
				{
					if(OpenButton != null) OpenButton.Show();
				}
				else
				{
					if(OpenButton != null) OpenButton.Hide();
				}
			}
		}
		public bool HideSaveButton
		{
			get 
			{
				return p_HideSaveButton;
			}
			set
			{
				p_HideSaveButton = value;
				if(p_HideSaveButton)
				{
					if(SaveButton != null) SaveButton.Show();
				}
				else
				{
					if(SaveButton != null) SaveButton.Hide();
				}
			}
		}
		public bool HideTransmitButton
		{
			get 
			{
				return p_HideTransmitButton;
			}
			set
			{
				p_HideTransmitButton = value;
				if(p_HideTransmitButton)
				{
					if(TransmitButton != null) TransmitButton.Show();
				}
				else
				{
					if(TransmitButton != null) TransmitButton.Hide();
				}
			}
		}
		
		public ReceivedBytesWidget()
		{
			this.Build();
			NewButton.TooltipMarkup = Mono.Unix.Catalog.GetString("Create new byte-list.");
			OpenButton.TooltipMarkup = Mono.Unix.Catalog.GetString("Open byte-list.");
			SaveButton.TooltipMarkup = Mono.Unix.Catalog.GetString("Save byte-list.");
			RecordToggleButton.TooltipMarkup = Mono.Unix.Catalog.GetString("Record incoming bytes.");
			TransmitButton.TooltipMarkup = Mono.Unix.Catalog.GetString("Transmit selected bytes.");
			NodeView.AppendColumn (Mono.Unix.Catalog.GetString("Bin"), new Gtk.CellRendererText (), "text", 0);
			NodeView.AppendColumn (Mono.Unix.Catalog.GetString("Oct"), new Gtk.CellRendererText (), "text", 1);
			NodeView.AppendColumn (Mono.Unix.Catalog.GetString("Dec"), new Gtk.CellRendererText (), "text", 2);
			NodeView.AppendColumn (Mono.Unix.Catalog.GetString("Hex"), new Gtk.CellRendererText (), "text", 3);
			NodeView.AppendColumn (Mono.Unix.Catalog.GetString("ASCII"), new Gtk.CellRendererText (), "text", 4);
			NodeView.Selection.Mode = SelectionMode.Multiple;
			p_NodeStore = new NodeStore(typeof(ByteTreeNode));
			NodeView.NodeStore = p_NodeStore;
			NodeView.ShowAll();
			p_ReceivedBytes = new List<byte>();
			p_AllReceivedBytes = new List<byte>();
			p_ByteTreeNodes = new List<ByteTreeNode>();
			NodeView.NodeSelection.Changed += new EventHandler(OnNodeSelectionChanged);
			ArduinoSerial.AddReceivedBytesBuffer(p_ReceivedBytes);
			ArduinoSerial.BytesReceived += new EventHandler(BytesReceived);
			ArduinoSerial.Connection += new EventHandler(OnConnection);
			ArduinoSerial.Disconnection += new EventHandler(OnDisconnection);
		}
		
		public void SetFont(Pango.FontDescription font)
		{
			TextView.ModifyFont(font);
		}
		
		protected override void OnShown()
		{
			base.OnShown();
			if(p_HideNewButton) if(NewButton != null) NewButton.Hide();
			if(p_HideOpenButton) if(NewButton != null) OpenButton.Hide();
			if(p_HideSaveButton) if(NewButton != null) SaveButton.Hide();
			if(p_HideTransmitButton) if(NewButton != null) TransmitButton.Hide();
		}
		
		private void BytesReceived(object sender, EventArgs e)
		{
			ByteTreeNode btn;
			for(int i = 0; i < p_ReceivedBytes.Count; i++)
			{
				btn = new ByteTreeNode(p_ReceivedBytes[i]);
				p_AllReceivedBytes.Add(btn.Byte);
				p_ByteTreeNodes.Add(btn);
				p_NodeStore.AddNode(btn);
				TextView.Buffer.Text = TextView.Buffer.Text + ((char)btn.Byte).ToString();
			}
			p_ReceivedBytes.Clear();
		}

		protected void OnNewButtonClicked(object sender, System.EventArgs e)
		{
			p_AllReceivedBytes.Clear();
			p_ByteTreeNodes.Clear();
			p_NodeStore.Clear();
			TextView.Buffer.Text = "";
		}
		
		protected void OnOpenButtonClicked(object sender, System.EventArgs e)
		{
			FileChooserDialog fd = new FileChooserDialog(Mono.Unix.Catalog.GetString("Open bytes ..."), null, FileChooserAction.Save, Mono.Unix.Catalog.GetString("Cancel"), ResponseType.Cancel, Mono.Unix.Catalog.GetString("Open"), ResponseType.Accept);
			FileFilter allfilter = new FileFilter();
			allfilter.Name = Mono.Unix.Catalog.GetString("Compatible formats");
			allfilter.AddMimeType("application/xml");
			allfilter.AddPattern("*.axml");
			allfilter.AddMimeType("text/plain");
			allfilter.AddPattern("*.txt");
			allfilter.AddMimeType("application/octet-stream");
			allfilter.AddPattern("*.bin");
			FileFilter axmlFilter = new FileFilter();
			axmlFilter.Name = Mono.Unix.Catalog.GetString("AXML");
			axmlFilter.AddMimeType("application/xml");
			axmlFilter.AddPattern("*.axml");
			FileFilter txtFilter = new FileFilter();
			txtFilter.Name = Mono.Unix.Catalog.GetString("Textfile");
			txtFilter.AddMimeType("text/plain");
			txtFilter.AddPattern("*.txt");
			FileFilter binFilter = new FileFilter();
			binFilter.Name = Mono.Unix.Catalog.GetString("Binary file");
			binFilter.AddMimeType("application/octet-stream");
			binFilter.AddPattern("*.bin");
			fd.AddFilter(allfilter);
			fd.AddFilter(axmlFilter);
			fd.AddFilter(txtFilter);
			fd.AddFilter(binFilter);
			fd.SetCurrentFolder(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
			if(fd.Run() == (int)ResponseType.Accept)
			{
				List<byte> bytes = new List<byte>();
				if(fd.Filename.EndsWith(".axml"))
				{
					bytes = ArduinoSerial.LoadBufferAXML(fd.Filename);
				}
				if(fd.Filename.EndsWith(".txt"))
				{
					bytes = ArduinoSerial.LoadBufferTXT(fd.Filename);
					
				}
				if(fd.Filename.EndsWith(".bin"))
				{
					bytes = ArduinoSerial.LoadBufferBIN(fd.Filename);
				}
				p_AllReceivedBytes.Clear();
				p_NodeStore.Clear();
				TextView.Buffer.Text = "";
				ByteTreeNode btn;
				for(int i = 0; i < bytes.Count; i++)
				{
					btn = new ByteTreeNode(bytes[i]);
					p_AllReceivedBytes.Add(btn.Byte);
					p_ByteTreeNodes.Add(btn);
					p_NodeStore.AddNode(btn);
					TextView.Buffer.Text = TextView.Buffer.Text + ((char)btn.Byte).ToString();
				}
			}
			fd.Destroy();
		}
		
		protected void OnSaveButtonClicked(object sender, System.EventArgs e)
		{
			FileChooserDialog fd = new FileChooserDialog(Mono.Unix.Catalog.GetString("Save bytes ..."), null, FileChooserAction.Save, Mono.Unix.Catalog.GetString("Cancel"), ResponseType.Cancel, Mono.Unix.Catalog.GetString("Save"), ResponseType.Accept);
			FileFilter axmlFilter = new FileFilter();
			axmlFilter.Name = Mono.Unix.Catalog.GetString("AXML");
			axmlFilter.AddMimeType("application/xml");
			axmlFilter.AddPattern("*.axml");
			FileFilter txtFilter = new FileFilter();
			txtFilter.Name = Mono.Unix.Catalog.GetString("Textfile");
			txtFilter.AddMimeType("text/plain");
			txtFilter.AddPattern("*.txt");
			FileFilter binFilter = new FileFilter();
			binFilter.Name = Mono.Unix.Catalog.GetString("Binary file");
			binFilter.AddMimeType("application/octet-stream");
			binFilter.AddPattern("*.bin");
			fd.AddFilter(axmlFilter);
			fd.AddFilter(txtFilter);
			fd.AddFilter(binFilter);
			fd.SetCurrentFolder(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
			fd.CurrentName = "bytes";
			if(fd.Run() == (int)ResponseType.Accept)
			{
				if(fd.Filter == axmlFilter)
				{
					if(fd.Filename.EndsWith(".axml"))
					{
						ArduinoSerial.SaveBufferAXML(fd.Filename, p_AllReceivedBytes);
					}
					else
					{
						ArduinoSerial.SaveBufferAXML(fd.Filename + ".axml", p_AllReceivedBytes);
					}
				}
				if(fd.Filter == txtFilter)
				{
					if(fd.Filename.EndsWith(".txt"))
					{
						ArduinoSerial.SaveBufferTXT(fd.Filename, p_AllReceivedBytes);
					}
					else
					{
						ArduinoSerial.SaveBufferTXT(fd.Filename + ".txt", p_AllReceivedBytes);
					}
				}
				if(fd.Filter == binFilter)
				{
					if(fd.Filename.EndsWith(".bin"))
					{
						ArduinoSerial.SaveBufferBIN(fd.Filename, p_AllReceivedBytes);
					}
					else
					{
						ArduinoSerial.SaveBufferBIN(fd.Filename + ".bin", p_AllReceivedBytes);
					}
				}
			}
			fd.Destroy();
		}

		protected void OnTransmitButtonClicked(object sender, System.EventArgs e)
		{
			List<byte> bytes = new List<byte>();
			for(int i = 0; i < p_ByteTreeNodes.Count; i++)
			{
				if(NodeView.NodeSelection.NodeIsSelected(p_ByteTreeNodes[i]))
				{
					bytes.Add(p_ByteTreeNodes[i].Byte);
				}
			}
			ArduinoSerial.TransmitBytes(bytes);
		}

		protected void OnNotebookSwitchPage(object o, Gtk.SwitchPageArgs args)
		{
			RefreshUI();
		}
	
		private void OnConnection(object sender, EventArgs e)
		{
			RefreshUI();
		}
		
		private void OnDisconnection(object sender, EventArgs e)
		{
			RefreshUI();
		}
		
		private void OnNodeSelectionChanged(object sender, EventArgs e)
		{
			RefreshUI();
		}
		
		private void RefreshUI()
		{
			if(ArduinoSerial.Connected)
			{
				if(Notebook.Page == 0)
				{
					TransmitButton.Sensitive = false;
				}
				if(Notebook.Page == 1)
				{
					if(NodeView.NodeSelection.SelectedNodes.Length == 0)
					{
						TransmitButton.Sensitive = false;
					}
					else
					{
						TransmitButton.Sensitive = true;
					}
				}
			}
			else
			{
				TransmitButton.Sensitive = false;
			}
		}

		protected void OnRecordToggleButtonClicked (object sender, System.EventArgs e)
		{
			ArduinoSerial.FreezeReceivedBytes = !RecordToggleButton.Active;
		}
	}
}

