using System;
using System.Collections.Generic;
using Gtk;
using libarduinotty;

namespace libarduinotty.Widgets
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class TransmittedBytesWidget : Gtk.Bin
	{
		private bool p_HideNewButton = false;
		private bool p_HideOpenButton = false;
		private bool p_HideSaveButton = false;
		private bool p_HideTransmitButton = false;
		private NodeStore p_NodeStore;
		private List<byte> p_AllTransmittedBytes;
		private List<byte> p_TransmittedBytes;
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
		
		public TransmittedBytesWidget()
		{
			this.Build();
			NodeView.AppendColumn ("Bin", new Gtk.CellRendererText (), "text", 0);
			NodeView.AppendColumn ("Oct", new Gtk.CellRendererText (), "text", 1);
			NodeView.AppendColumn ("Dec", new Gtk.CellRendererText (), "text", 2);
			NodeView.AppendColumn ("Hex", new Gtk.CellRendererText (), "text", 3);
			NodeView.AppendColumn ("ASCII", new Gtk.CellRendererText (), "text", 4);
			NodeView.Selection.Mode = SelectionMode.Multiple;
			p_NodeStore = new NodeStore(typeof(ByteTreeNode));
			NodeView.NodeStore = p_NodeStore;
			NodeView.ShowAll();
			p_TransmittedBytes = new List<byte>();
			p_AllTransmittedBytes = new List<byte>();
			p_ByteTreeNodes = new List<ByteTreeNode>();
			NodeView.NodeSelection.Changed += new EventHandler(OnNodeSelectionChanged);
			ArduinoSerial.AddTransmittedBytesBuffer(p_TransmittedBytes);
			ArduinoSerial.BytesTransmitted += new EventHandler(BytesTransmitted);
			ArduinoSerial.Connection += new EventHandler(OnConnection);
			ArduinoSerial.Disconnection += new EventHandler(OnDisconnection);
		}
		
		protected override void OnShown()
		{
			base.OnShown();
			if(p_HideNewButton) if(NewButton != null) NewButton.Hide();
			if(p_HideOpenButton) if(NewButton != null) OpenButton.Hide();
			if(p_HideSaveButton) if(NewButton != null) SaveButton.Hide();
			if(p_HideTransmitButton) if(NewButton != null) TransmitButton.Hide();
		}
		
		private void BytesTransmitted(object sender, EventArgs e)
		{
			ByteTreeNode btn;
			for(int i = 0; i < p_TransmittedBytes.Count; i++)
			{
				btn = new ByteTreeNode(p_TransmittedBytes[i]);
				p_AllTransmittedBytes.Add(btn.Byte);
				p_ByteTreeNodes.Add(btn);
				p_NodeStore.AddNode(btn);
				TextView.Buffer.Text = TextView.Buffer.Text + ((char)btn.Byte).ToString();
			}
			p_TransmittedBytes.Clear();
		}

		protected void OnNewButtonClicked(object sender, System.EventArgs e)
		{
			p_AllTransmittedBytes.Clear();
			p_ByteTreeNodes.Clear();
			p_NodeStore.Clear();
			TextView.Buffer.Text = "";
		}
		
		protected void OnOpenButtonClicked(object sender, System.EventArgs e)
		{
			FileChooserDialog fd = new FileChooserDialog("Open bytes ...", null, FileChooserAction.Save, "Cancel", ResponseType.Cancel, "Open", ResponseType.Accept);
			fd.SetCurrentFolder(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
			
			if(fd.Run() == (int)ResponseType.Accept)
			{
				if(fd.Filename.EndsWith(".axml"))
				{
					List<byte> bytes = ArduinoSerial.LoadBuffer(fd.Filename);
					p_AllTransmittedBytes.Clear();
					p_NodeStore.Clear();
					TextView.Buffer.Text = "";
					ByteTreeNode btn;
					for(int i = 0; i < bytes.Count; i++)
					{
						btn = new ByteTreeNode(bytes[i]);
						p_AllTransmittedBytes.Add(btn.Byte);
						p_ByteTreeNodes.Add(btn);
						p_NodeStore.AddNode(btn);
						TextView.Buffer.Text = TextView.Buffer.Text + ((char)btn.Byte).ToString();
					}
				}
			}
			fd.Destroy();
		}
		
		protected void OnSaveButtonClicked(object sender, System.EventArgs e)
		{
			FileChooserDialog fd = new FileChooserDialog("Save bytes ...", null, FileChooserAction.Save, "Cancel", ResponseType.Cancel, "Save", ResponseType.Accept);
			fd.SetCurrentFolder(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
			fd.CurrentName = "bytes.axml";
			if(fd.Run() == (int)ResponseType.Accept)
			{
				ArduinoSerial.SaveBuffer(fd.Filename, p_AllTransmittedBytes);
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

		protected void OnNotebookSwitchPage (object o, Gtk.SwitchPageArgs args)
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
	}
}

