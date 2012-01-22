
// This file has been generated by the GUI designer. Do not modify.
namespace arduinotty
{
	public partial class MainWindow
	{
		private global::Gtk.VBox VBox;
		private global::Gtk.HBox HBox;
		private global::Gtk.Alignment AlignmentLeft;
		private global::libarduinotty.Widgets.ConnectionWidget ConnectionWidget;
		private global::Gtk.VSeparator VSeparator1;
		private global::Gtk.ComboBox FilterComboBox;
		private global::Gtk.Alignment AlignmentRight;
		private global::Gtk.HSeparator HSeparatorUp;
		private global::Gtk.HPaned HPaned;
		private global::libarduinotty.Widgets.ReceivedBytesWidget ReceivedBytesWidget;
		private global::libarduinotty.Widgets.TransmittedBytesWidget TransmittedBytesWidget;
		private global::Gtk.HSeparator HSeparatorDown;
		private global::libarduinotty.Widgets.TransmitWidget TransmitWidget;
        
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget arduinotty.MainWindow
			this.Name = "arduinotty.MainWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Arduino TTY");
			this.Icon = new global::Gdk.Pixbuf (global::System.IO.Path.Combine (global::System.AppDomain.CurrentDomain.BaseDirectory, "./arduinotty.png"));
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child arduinotty.MainWindow.Gtk.Container+ContainerChild
			this.VBox = new global::Gtk.VBox ();
			this.VBox.Name = "VBox";
			this.VBox.Spacing = 6;
			// Container child VBox.Gtk.Box+BoxChild
			this.HBox = new global::Gtk.HBox ();
			this.HBox.Name = "HBox";
			this.HBox.Spacing = 6;
			// Container child HBox.Gtk.Box+BoxChild
			this.AlignmentLeft = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.AlignmentLeft.Name = "AlignmentLeft";
			this.HBox.Add (this.AlignmentLeft);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.HBox [this.AlignmentLeft]));
			w1.Position = 0;
			// Container child HBox.Gtk.Box+BoxChild
			this.ConnectionWidget = new global::libarduinotty.Widgets.ConnectionWidget ();
			this.ConnectionWidget.Events = ((global::Gdk.EventMask)(256));
			this.ConnectionWidget.Name = "ConnectionWidget";
			this.ConnectionWidget.HideBaudrate = false;
			this.HBox.Add (this.ConnectionWidget);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.HBox [this.ConnectionWidget]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child HBox.Gtk.Box+BoxChild
			this.VSeparator1 = new global::Gtk.VSeparator ();
			this.VSeparator1.Name = "VSeparator1";
			this.HBox.Add (this.VSeparator1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.HBox [this.VSeparator1]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child HBox.Gtk.Box+BoxChild
			this.FilterComboBox = global::Gtk.ComboBox.NewText ();
			this.FilterComboBox.AppendText (global::Mono.Unix.Catalog.GetString ("Received"));
			this.FilterComboBox.AppendText (global::Mono.Unix.Catalog.GetString ("Transmitted"));
			this.FilterComboBox.AppendText (global::Mono.Unix.Catalog.GetString ("Both"));
			this.FilterComboBox.Name = "FilterComboBox";
			this.FilterComboBox.Active = 0;
			this.HBox.Add (this.FilterComboBox);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.HBox [this.FilterComboBox]));
			w4.Position = 3;
			w4.Expand = false;
			w4.Fill = false;
			// Container child HBox.Gtk.Box+BoxChild
			this.AlignmentRight = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.AlignmentRight.Name = "AlignmentRight";
			this.HBox.Add (this.AlignmentRight);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.HBox [this.AlignmentRight]));
			w5.Position = 4;
			this.VBox.Add (this.HBox);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.VBox [this.HBox]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child VBox.Gtk.Box+BoxChild
			this.HSeparatorUp = new global::Gtk.HSeparator ();
			this.HSeparatorUp.Name = "HSeparatorUp";
			this.VBox.Add (this.HSeparatorUp);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.VBox [this.HSeparatorUp]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child VBox.Gtk.Box+BoxChild
			this.HPaned = new global::Gtk.HPaned ();
			this.HPaned.WidthRequest = 600;
			this.HPaned.CanFocus = true;
			this.HPaned.Name = "HPaned";
			this.HPaned.Position = 300;
			// Container child HPaned.Gtk.Paned+PanedChild
			this.ReceivedBytesWidget = new global::libarduinotty.Widgets.ReceivedBytesWidget ();
			this.ReceivedBytesWidget.Events = ((global::Gdk.EventMask)(256));
			this.ReceivedBytesWidget.Name = "ReceivedBytesWidget";
			this.ReceivedBytesWidget.HideNewButton = false;
			this.ReceivedBytesWidget.HideOpenButton = false;
			this.ReceivedBytesWidget.HideSaveButton = false;
			this.ReceivedBytesWidget.HideTransmitButton = false;
			this.HPaned.Add (this.ReceivedBytesWidget);
			global::Gtk.Paned.PanedChild w8 = ((global::Gtk.Paned.PanedChild)(this.HPaned [this.ReceivedBytesWidget]));
			w8.Resize = false;
			// Container child HPaned.Gtk.Paned+PanedChild
			this.TransmittedBytesWidget = new global::libarduinotty.Widgets.TransmittedBytesWidget ();
			this.TransmittedBytesWidget.Events = ((global::Gdk.EventMask)(256));
			this.TransmittedBytesWidget.Name = "TransmittedBytesWidget";
			this.TransmittedBytesWidget.HideNewButton = false;
			this.TransmittedBytesWidget.HideOpenButton = false;
			this.TransmittedBytesWidget.HideSaveButton = false;
			this.TransmittedBytesWidget.HideTransmitButton = false;
			this.HPaned.Add (this.TransmittedBytesWidget);
			this.VBox.Add (this.HPaned);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.VBox [this.HPaned]));
			w10.Position = 2;
			// Container child VBox.Gtk.Box+BoxChild
			this.HSeparatorDown = new global::Gtk.HSeparator ();
			this.HSeparatorDown.Name = "HSeparatorDown";
			this.VBox.Add (this.HSeparatorDown);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.VBox [this.HSeparatorDown]));
			w11.Position = 3;
			w11.Expand = false;
			w11.Fill = false;
			// Container child VBox.Gtk.Box+BoxChild
			this.TransmitWidget = new global::libarduinotty.Widgets.TransmitWidget ();
			this.TransmitWidget.Events = ((global::Gdk.EventMask)(256));
			this.TransmitWidget.Name = "TransmitWidget";
			this.VBox.Add (this.TransmitWidget);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.VBox [this.TransmitWidget]));
			w12.Position = 4;
			w12.Expand = false;
			w12.Fill = false;
			this.Add (this.VBox);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 606;
			this.DefaultHeight = 428;
			this.TransmittedBytesWidget.Hide ();
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.FilterComboBox.Changed += new global::System.EventHandler (this.OnFilterComboBoxChanged);
		}
	}
}