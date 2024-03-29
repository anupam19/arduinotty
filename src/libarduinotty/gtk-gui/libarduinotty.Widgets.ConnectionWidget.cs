
// This file has been generated by the GUI designer. Do not modify.
namespace libarduinotty.Widgets
{
	public partial class ConnectionWidget
	{
		private global::Gtk.VBox VBox;
		private global::Gtk.HBox HBox;
		private global::Gtk.ToggleButton ConnectToggleButton;
		private global::Gtk.VSeparator VSeparator;
		private global::Gtk.Label PortLabel;
		private global::Gtk.ComboBox PortComboBox;
		private global::Gtk.Label BaudrateLabel;
		private global::Gtk.SpinButton BaudrateSpinButton;
        
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget libarduinotty.Widgets.ConnectionWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "libarduinotty.Widgets.ConnectionWidget";
			// Container child libarduinotty.Widgets.ConnectionWidget.Gtk.Container+ContainerChild
			this.VBox = new global::Gtk.VBox ();
			this.VBox.Name = "VBox";
			this.VBox.Spacing = 6;
			// Container child VBox.Gtk.Box+BoxChild
			this.HBox = new global::Gtk.HBox ();
			this.HBox.Name = "HBox";
			this.HBox.Spacing = 6;
			// Container child HBox.Gtk.Box+BoxChild
			this.ConnectToggleButton = new global::Gtk.ToggleButton ();
			this.ConnectToggleButton.CanFocus = true;
			this.ConnectToggleButton.Name = "ConnectToggleButton";
			this.ConnectToggleButton.UseUnderline = true;
			// Container child ConnectToggleButton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w1 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w2 = new global::Gtk.HBox ();
			w2.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-connect", global::Gtk.IconSize.Menu);
			w2.Add (w3);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w5 = new global::Gtk.Label ();
			w2.Add (w5);
			w1.Add (w2);
			this.ConnectToggleButton.Add (w1);
			this.HBox.Add (this.ConnectToggleButton);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.HBox [this.ConnectToggleButton]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child HBox.Gtk.Box+BoxChild
			this.VSeparator = new global::Gtk.VSeparator ();
			this.VSeparator.Name = "VSeparator";
			this.HBox.Add (this.VSeparator);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.HBox [this.VSeparator]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			// Container child HBox.Gtk.Box+BoxChild
			this.PortLabel = new global::Gtk.Label ();
			this.PortLabel.Name = "PortLabel";
			this.PortLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Port:");
			this.HBox.Add (this.PortLabel);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.HBox [this.PortLabel]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			// Container child HBox.Gtk.Box+BoxChild
			this.PortComboBox = global::Gtk.ComboBox.NewText ();
			this.PortComboBox.Name = "PortComboBox";
			this.HBox.Add (this.PortComboBox);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.HBox [this.PortComboBox]));
			w12.Position = 3;
			w12.Expand = false;
			w12.Fill = false;
			// Container child HBox.Gtk.Box+BoxChild
			this.BaudrateLabel = new global::Gtk.Label ();
			this.BaudrateLabel.Name = "BaudrateLabel";
			this.BaudrateLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Baudrate:");
			this.HBox.Add (this.BaudrateLabel);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.HBox [this.BaudrateLabel]));
			w13.Position = 4;
			w13.Expand = false;
			w13.Fill = false;
			// Container child HBox.Gtk.Box+BoxChild
			this.BaudrateSpinButton = new global::Gtk.SpinButton (300, 500000, 100);
			this.BaudrateSpinButton.CanFocus = true;
			this.BaudrateSpinButton.Name = "BaudrateSpinButton";
			this.BaudrateSpinButton.Adjustment.PageIncrement = 10;
			this.BaudrateSpinButton.ClimbRate = 1;
			this.BaudrateSpinButton.Numeric = true;
			this.BaudrateSpinButton.Value = 9600;
			this.HBox.Add (this.BaudrateSpinButton);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.HBox [this.BaudrateSpinButton]));
			w14.Position = 5;
			w14.Expand = false;
			w14.Fill = false;
			this.VBox.Add (this.HBox);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.VBox [this.HBox]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			this.Add (this.VBox);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.ConnectToggleButton.Clicked += new global::System.EventHandler (this.OnConnectToggleButtonClicked);
			this.PortComboBox.Changed += new global::System.EventHandler (this.OnPortComboBoxChanged);
		}
	}
}
