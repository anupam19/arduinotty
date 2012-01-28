
// This file has been generated by the GUI designer. Do not modify.
namespace arduinotty
{
	public partial class PreferencesDialog
	{
		private global::Gtk.Frame frame1;
		private global::Gtk.Alignment GtkAlignment2;
		private global::Gtk.VBox vbox2;
		private global::Gtk.Alignment alignment2;
		private global::Gtk.CheckButton UseLastValuesCheckButton;
		private global::Gtk.Table table2;
		private global::Gtk.ComboBox ComboBox;
		private global::Gtk.Label LabelBaudrate;
		private global::Gtk.SpinButton SpinButton;
		private global::Gtk.Label StandartViewLabel;
		private global::Gtk.Label GtkLabel5;
		private global::Gtk.Frame frame3;
		private global::Gtk.Alignment GtkAlignment4;
		private global::Gtk.VBox vbox4;
		private global::Gtk.Alignment alignment4;
		private global::Gtk.FontButton FontButton;
		private global::Gtk.Label GtkLabel8;
		private global::Gtk.Frame frame2;
		private global::Gtk.Alignment GtkAlignment3;
		private global::Gtk.VBox vbox3;
		private global::Gtk.Alignment alignment6;
		private global::Gtk.CheckButton CheckButton;
		private global::Gtk.Label GtkLabel7;
		private global::Gtk.Button buttonCancel;
		private global::Gtk.Button buttonOk;
        
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget arduinotty.PreferencesDialog
			this.Name = "arduinotty.PreferencesDialog";
			this.Title = global::Mono.Unix.Catalog.GetString ("Preferences");
			this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-preferences", global::Gtk.IconSize.Menu);
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Resizable = false;
			this.AllowGrow = false;
			// Internal child arduinotty.PreferencesDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child VBox.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment2 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment2.Name = "GtkAlignment2";
			this.GtkAlignment2.LeftPadding = ((uint)(12));
			// Container child GtkAlignment2.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment2 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment2.Name = "alignment2";
			this.alignment2.TopPadding = ((uint)(5));
			this.vbox2.Add (this.alignment2);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment2]));
			w2.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.UseLastValuesCheckButton = new global::Gtk.CheckButton ();
			this.UseLastValuesCheckButton.CanFocus = true;
			this.UseLastValuesCheckButton.Name = "UseLastValuesCheckButton";
			this.UseLastValuesCheckButton.Label = global::Mono.Unix.Catalog.GetString ("Use settings from last session.");
			this.UseLastValuesCheckButton.DrawIndicator = true;
			this.UseLastValuesCheckButton.UseUnderline = true;
			this.vbox2.Add (this.UseLastValuesCheckButton);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.UseLastValuesCheckButton]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.table2 = new global::Gtk.Table (((uint)(2)), ((uint)(2)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(6));
			this.table2.ColumnSpacing = ((uint)(6));
			// Container child table2.Gtk.Table+TableChild
			this.ComboBox = global::Gtk.ComboBox.NewText ();
			this.ComboBox.AppendText (global::Mono.Unix.Catalog.GetString ("Received"));
			this.ComboBox.AppendText (global::Mono.Unix.Catalog.GetString ("Transmitted"));
			this.ComboBox.AppendText (global::Mono.Unix.Catalog.GetString ("Both"));
			this.ComboBox.Name = "ComboBox";
			this.ComboBox.Active = 0;
			this.table2.Add (this.ComboBox);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table2 [this.ComboBox]));
			w4.TopAttach = ((uint)(1));
			w4.BottomAttach = ((uint)(2));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.LabelBaudrate = new global::Gtk.Label ();
			this.LabelBaudrate.Name = "LabelBaudrate";
			this.LabelBaudrate.Xalign = 0F;
			this.LabelBaudrate.LabelProp = global::Mono.Unix.Catalog.GetString ("Baudrate:");
			this.table2.Add (this.LabelBaudrate);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table2 [this.LabelBaudrate]));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.SpinButton = new global::Gtk.SpinButton (300, 500000, 100);
			this.SpinButton.CanFocus = true;
			this.SpinButton.Name = "SpinButton";
			this.SpinButton.Adjustment.PageIncrement = 10;
			this.SpinButton.ClimbRate = 1;
			this.SpinButton.Numeric = true;
			this.SpinButton.Value = 9600;
			this.table2.Add (this.SpinButton);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table2 [this.SpinButton]));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.StandartViewLabel = new global::Gtk.Label ();
			this.StandartViewLabel.Name = "StandartViewLabel";
			this.StandartViewLabel.Xalign = 0F;
			this.StandartViewLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("View:");
			this.table2.Add (this.StandartViewLabel);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table2 [this.StandartViewLabel]));
			w7.TopAttach = ((uint)(1));
			w7.BottomAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add (this.table2);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.table2]));
			w8.Position = 2;
			w8.Expand = false;
			w8.Fill = false;
			this.GtkAlignment2.Add (this.vbox2);
			this.frame1.Add (this.GtkAlignment2);
			this.GtkLabel5 = new global::Gtk.Label ();
			this.GtkLabel5.Name = "GtkLabel5";
			this.GtkLabel5.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Settings on startup</b>");
			this.GtkLabel5.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel5;
			w1.Add (this.frame1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(w1 [this.frame1]));
			w11.Position = 0;
			// Container child VBox.Gtk.Box+BoxChild
			this.frame3 = new global::Gtk.Frame ();
			this.frame3.Name = "frame3";
			this.frame3.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame3.Gtk.Container+ContainerChild
			this.GtkAlignment4 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment4.Name = "GtkAlignment4";
			this.GtkAlignment4.LeftPadding = ((uint)(12));
			// Container child GtkAlignment4.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.alignment4 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment4.Name = "alignment4";
			this.alignment4.TopPadding = ((uint)(5));
			this.vbox4.Add (this.alignment4);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.alignment4]));
			w12.Position = 0;
			// Container child vbox4.Gtk.Box+BoxChild
			this.FontButton = new global::Gtk.FontButton ();
			this.FontButton.CanFocus = true;
			this.FontButton.Name = "FontButton";
			this.vbox4.Add (this.FontButton);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.FontButton]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			this.GtkAlignment4.Add (this.vbox4);
			this.frame3.Add (this.GtkAlignment4);
			this.GtkLabel8 = new global::Gtk.Label ();
			this.GtkLabel8.Name = "GtkLabel8";
			this.GtkLabel8.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Font</b>");
			this.GtkLabel8.UseMarkup = true;
			this.frame3.LabelWidget = this.GtkLabel8;
			w1.Add (this.frame3);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(w1 [this.frame3]));
			w16.Position = 1;
			// Container child VBox.Gtk.Box+BoxChild
			this.frame2 = new global::Gtk.Frame ();
			this.frame2.Name = "frame2";
			this.frame2.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment3 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment3.Name = "GtkAlignment3";
			this.GtkAlignment3.LeftPadding = ((uint)(12));
			// Container child GtkAlignment3.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.alignment6 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment6.Name = "alignment6";
			this.alignment6.TopPadding = ((uint)(5));
			this.vbox3.Add (this.alignment6);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.alignment6]));
			w17.Position = 0;
			// Container child vbox3.Gtk.Box+BoxChild
			this.CheckButton = new global::Gtk.CheckButton ();
			this.CheckButton.CanFocus = true;
			this.CheckButton.Name = "CheckButton";
			this.CheckButton.Label = global::Mono.Unix.Catalog.GetString ("Show \"Arduino TTY\" symbol");
			this.CheckButton.DrawIndicator = true;
			this.CheckButton.UseUnderline = true;
			this.vbox3.Add (this.CheckButton);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.CheckButton]));
			w18.Position = 1;
			w18.Expand = false;
			w18.Fill = false;
			this.GtkAlignment3.Add (this.vbox3);
			this.frame2.Add (this.GtkAlignment3);
			this.GtkLabel7 = new global::Gtk.Label ();
			this.GtkLabel7.Name = "GtkLabel7";
			this.GtkLabel7.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Symbol</b>");
			this.GtkLabel7.UseMarkup = true;
			this.frame2.LabelWidget = this.GtkLabel7;
			w1.Add (this.frame2);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(w1 [this.frame2]));
			w21.Position = 2;
			// Internal child arduinotty.PreferencesDialog.ActionArea
			global::Gtk.HButtonBox w22 = this.ActionArea;
			w22.Name = "dialog1_ActionArea";
			w22.Spacing = 10;
			w22.BorderWidth = ((uint)(5));
			w22.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w23 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w22 [this.buttonCancel]));
			w23.Expand = false;
			w23.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w24 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w22 [this.buttonOk]));
			w24.Position = 1;
			w24.Expand = false;
			w24.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 253;
			this.DefaultHeight = 327;
			this.Show ();
			this.UseLastValuesCheckButton.Clicked += new global::System.EventHandler (this.OnUseLastValuesCheckButtonClicked);
		}
	}
}
