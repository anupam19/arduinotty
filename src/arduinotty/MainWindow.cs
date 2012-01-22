using System;
using Gtk;
using libarduinotty;

namespace arduinotty
{
	public partial class MainWindow : Gtk.Window
	{	
		
		public MainWindow(): base (Gtk.WindowType.Toplevel)
		{
			Build();
		}
	
		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			ArduinoSerial.Disconnect();
			ConnectionWidget.StopCheckPortsThread();
			Application.Quit();
			a.RetVal = true;
		}
	
		protected void OnFilterComboBoxChanged(object sender, System.EventArgs e)
		{
			if(FilterComboBox.Active == 0)
			{
				ReceivedBytesWidget.Show();
				TransmittedBytesWidget.Hide();
			}
			if(FilterComboBox.Active == 1)
			{
				ReceivedBytesWidget.Hide();
				TransmittedBytesWidget.Show();
			}
			if(FilterComboBox.Active == 2)
			{
				ReceivedBytesWidget.Show();
				TransmittedBytesWidget.Show();
			}
		}
	}
}