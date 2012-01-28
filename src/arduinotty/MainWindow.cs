using System;
using System.Collections.Generic;
using System.IO;
using Gtk;
using libarduinotty;

namespace arduinotty
{
	public partial class MainWindow : Gtk.Window
	{	
		private StatusIcon p_StatusIcon;
		private Gdk.Pixbuf p_Icon;
		private Gdk.Pixbuf p_Logo;
		private int p_OldWindowPositionX;
		private int p_OldWindowPositionY;
		private AboutDialog p_AboutDialog;
		private PreferencesDialog p_PreferencesDialog;
		Preferences p_Preferences;
		
		public MainWindow(): base (Gtk.WindowType.Toplevel)
		{
			Build();
			p_Preferences = new Preferences();
			FilterComboBox.TooltipMarkup = Mono.Unix.Catalog.GetString("View.");
			PreferencesButton.TooltipMarkup = Mono.Unix.Catalog.GetString("Preferences.");
			AboutButton.TooltipMarkup = Mono.Unix.Catalog.GetString("Info.");
			if(File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "/arduinotty.conf"))
			{
				p_Preferences = Preferences.LoadPreferences(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "/arduinotty.conf");
			}
			else
			{
				Preferences.SavePreferences(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "/arduinotty.conf", p_Preferences);
			}
			if(p_Preferences.UseLastUsedSettings)
			{
				ConnectionWidget.Baudrate = p_Preferences.LastUsedBaudrate;
				FilterComboBox.Active = p_Preferences.LastUsedBytesView;
			}
			else
			{
				ConnectionWidget.Baudrate = p_Preferences.Baudrate;
				FilterComboBox.Active = p_Preferences.BytesView;
			}
			Gdk.Pixbuf originalIcon = new Gdk.Pixbuf (System.IO.Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, "./arduinotty.png"));
			p_Icon = originalIcon.ScaleSimple(64, 64, Gdk.InterpType.Hyper);
			p_Logo = originalIcon.ScaleSimple(200, 200, Gdk.InterpType.Hyper);
			p_StatusIcon = new StatusIcon(p_Icon);
			p_StatusIcon.Tooltip = Mono.Unix.Catalog.GetString("Arduino TTY");
			p_StatusIcon.Visible = p_Preferences.ShowSymbol;
			p_StatusIcon.Activate += new EventHandler(OnStatusIconLeftMouseClicked);
			p_StatusIcon.PopupMenu += new PopupMenuHandler(OnStatusIconRightMouseClicked);
			RefreshUI();
		}
		
		public void RefreshUI()
		{
			p_StatusIcon.Visible = p_Preferences.ShowSymbol;
			ReceivedBytesWidget.SetFont(Pango.FontDescription.FromString(p_Preferences.Font));
			TransmittedBytesWidget.SetFont(Pango.FontDescription.FromString(p_Preferences.Font));
		}
		
		private void QuitArduinoTTY()
		{
			ArduinoSerial.Disconnect();
			ConnectionWidget.StopCheckPortsThread();
			p_Preferences.LastUsedBytesView = FilterComboBox.Active;
			p_Preferences.LastUsedBaudrate = ConnectionWidget.Baudrate;
			Preferences.SavePreferences(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "/arduinotty.conf", p_Preferences);
		}
	
		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			if(p_Preferences.ShowSymbol)
			{
				NewHide();
				a.RetVal = true;
			}
			else
			{
				QuitArduinoTTY();
				Application.Quit();
				a.RetVal = false;
			}
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
		
		protected void OnStatusIconLeftMouseClicked(object sender, EventArgs args)
		{
			if(this.Visible)
			{
				Hide();
			}
			else
			{
				Show();
			}
		}
		
		protected void OnStatusIconRightMouseClicked(object s, PopupMenuArgs args)
		{
			Menu menu = new Menu();
			MenuItem disconnectItem = new MenuItem(Mono.Unix.Catalog.GetString("Disconnect"));
			disconnectItem.Activated += new EventHandler(OnDisconnectItemClicked);
			MenuItem showItem = new MenuItem(Mono.Unix.Catalog.GetString("Show \"Arduino TTY\""));
			showItem.Activated += new EventHandler(OnShowItemClicked);
			MenuItem hideItem = new MenuItem(Mono.Unix.Catalog.GetString("Hide \"Arduino TTY\""));
			hideItem.Activated += new EventHandler(OnHideItemClicked);
			MenuItem quitItem = new MenuItem(Mono.Unix.Catalog.GetString("Quit"));
			quitItem.Activated += new EventHandler(OnQuitItemClicked);
			if(ArduinoSerial.Connected)
			{
				menu.Append(disconnectItem);
			}
			else
			{
				string[] ports = ArduinoSerial.AvailablePorts;
				if(ports.Length > 0)
				{
					MenuItem menuItemPorts = new MenuItem(Mono.Unix.Catalog.GetString("Connect with"));
					Menu menuPorts = new Menu();
					MenuItem tmpMenuItem;
					for(int i = 0; i < ports.Length; i++)
					{
						tmpMenuItem = new MenuItem(ports[i]);
						tmpMenuItem.Name = ports[i];
						tmpMenuItem.Activated += delegate(object sender, EventArgs e) {
							ArduinoSerial.Connect(((MenuItem) sender).Name, ConnectionWidget.Baudrate);
						};
						menuPorts.Append(tmpMenuItem);
					}
					menuItemPorts.Submenu = menuPorts;
					menu.Append(menuItemPorts);
				}
			}
			if(this.Visible)
			{
				menu.Append(hideItem);
			}
			else
			{
				menu.Append(showItem);
			}
			menu.Append(quitItem);
			menu.ShowAll();
			menu.Popup(null, null, new MenuPositionFunc(MenuPositionFunction), 3, Gtk.Global.CurrentEventTime);
		}
		
		protected void MenuPositionFunction(Menu menu, out int x, out int y, out bool push_in)
		{
			StatusIcon.PositionMenu(menu, out x, out y, out push_in, p_StatusIcon.Handle);
		}
		
		protected void OnDisconnectItemClicked(object sender, EventArgs args)
		{
			ArduinoSerial.Disconnect();
		}
		
		protected void OnShowItemClicked(object sender, EventArgs args)
		{
			Show();
		}
		
		protected void OnHideItemClicked(object sender, EventArgs args)
		{
			Hide();
		}
		
		protected void OnQuitItemClicked(object sender, EventArgs args)
		{
			QuitArduinoTTY();;
			Application.Quit();
		}
		
		protected void OnStatusIconRightMouseClicked(object sender, EventArgs args)
		{
			if(this.Visible)
			{
				NewHide();
			}
			else
			{
				NewShow();
			}
		}
		
		protected void NewShow()
		{
			Show();
			Move(p_OldWindowPositionX, p_OldWindowPositionY);
		}
		
		protected void NewHide()
		{
			GetPosition(out p_OldWindowPositionX, out p_OldWindowPositionY);
			Hide();
		}

		protected void OnPreferencesButtonClicked(object sender, System.EventArgs e)
		{
			p_PreferencesDialog = new PreferencesDialog();
			p_PreferencesDialog.SetPreferences(p_Preferences);
			p_PreferencesDialog.Response += new ResponseHandler(OnPreferencesDialogRespond);
			p_PreferencesDialog.Run();
		}

		protected void OnAboutButtonClicked(object sender, System.EventArgs e)
		{
			p_AboutDialog = new AboutDialog();
			p_AboutDialog.ProgramName = "Arduino TTY";
			p_AboutDialog.Version = "0.2";
			p_AboutDialog.Comments = Mono.Unix.Catalog.GetString("A serial terminal for the Arduino platform.");
			p_AboutDialog.License = Mono.Unix.Catalog.GetString("\"Arduino TTY\" is free software; you can redistribute it and/or\nmodify it under the terms of the GNU General Public\nLicense as published by the Free Software Foundation;\neither version 2 of the License, or (at your option) any\nlater version.\n\n\"Arduino TTY\" is distributed in the hope that it will be useful,\nbut WITHOUT ANY WARRANTY; without even the\nimplied warranty of MERCHANTABILITY or FITNESS\nFOR A PARTICULAR PURPOSE.  See the GNU General Public\nLicense for more details.\n\nYou should have received a copy of the GNU General\nPublic License along with \"Arduino TTY\"; if not, write to the\nFree Software Foundation, Inc., 59 Temple Place, Suite\n330, Boston, MA  02111-1307  USA");
			p_AboutDialog.Authors = new string[] { "arduinotty <arduinotty@gmail.de>" };
			p_AboutDialog.Website = "http://code.google.com/p/arduinotty/";
			p_AboutDialog.Icon = p_Icon;
			p_AboutDialog.Logo = p_Logo;
			p_AboutDialog.Response += new ResponseHandler(OnAboutDialogRespond);
			p_AboutDialog.Run();
		}
		
		protected void OnAboutDialogRespond(object sender, ResponseArgs e)
		{
			p_AboutDialog.Destroy();
		}
		
		protected void OnPreferencesDialogRespond(object sender, ResponseArgs e)
		{
			if(e.ResponseId == ResponseType.Ok)
			{
				p_Preferences = p_PreferencesDialog.GetPreferences();
				Preferences.SavePreferences(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "/arduinotty.conf", p_Preferences);
				RefreshUI();
			}
			p_PreferencesDialog.Destroy();
		}
	}
	
	
	

}