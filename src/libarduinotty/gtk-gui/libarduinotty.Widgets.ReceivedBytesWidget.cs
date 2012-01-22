
// This file has been generated by the GUI designer. Do not modify.
namespace libarduinotty.Widgets
{
	public partial class ReceivedBytesWidget
	{
		private global::Gtk.VBox VBox;
		private global::Gtk.Label Label;
		private global::Gtk.Notebook Notebook;
		private global::Gtk.ScrolledWindow TextViewGtkScrolledWindow;
		private global::Gtk.TextView TextView;
		private global::Gtk.Label label1;
		private global::Gtk.ScrolledWindow NodeViewGtkScrolledWindow;
		private global::Gtk.NodeView NodeView;
		private global::Gtk.Label label2;
		private global::Gtk.HBox HBox;
		private global::Gtk.Alignment AlignmentLeft;
		private global::Gtk.Button NewButton;
		private global::Gtk.Button OpenButton;
		private global::Gtk.Button SaveButton;
		private global::Gtk.Button TransmitButton;
		private global::Gtk.Alignment AlignmentRight;
        
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget libarduinotty.Widgets.ReceivedBytesWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "libarduinotty.Widgets.ReceivedBytesWidget";
			// Container child libarduinotty.Widgets.ReceivedBytesWidget.Gtk.Container+ContainerChild
			this.VBox = new global::Gtk.VBox ();
			this.VBox.Name = "VBox";
			this.VBox.Spacing = 6;
			// Container child VBox.Gtk.Box+BoxChild
			this.Label = new global::Gtk.Label ();
			this.Label.Name = "Label";
			this.Label.LabelProp = global::Mono.Unix.Catalog.GetString ("Received:");
			this.VBox.Add (this.Label);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.VBox [this.Label]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child VBox.Gtk.Box+BoxChild
			this.Notebook = new global::Gtk.Notebook ();
			this.Notebook.CanFocus = true;
			this.Notebook.Name = "Notebook";
			this.Notebook.CurrentPage = 0;
			// Container child Notebook.Gtk.Notebook+NotebookChild
			this.TextViewGtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.TextViewGtkScrolledWindow.Name = "TextViewGtkScrolledWindow";
			this.TextViewGtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child TextViewGtkScrolledWindow.Gtk.Container+ContainerChild
			this.TextView = new global::Gtk.TextView ();
			this.TextView.CanFocus = true;
			this.TextView.Name = "TextView";
			this.TextView.Editable = false;
			this.TextViewGtkScrolledWindow.Add (this.TextView);
			this.Notebook.Add (this.TextViewGtkScrolledWindow);
			// Notebook tab
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Text");
			this.Notebook.SetTabLabel (this.TextViewGtkScrolledWindow, this.label1);
			this.label1.ShowAll ();
			// Container child Notebook.Gtk.Notebook+NotebookChild
			this.NodeViewGtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.NodeViewGtkScrolledWindow.Name = "NodeViewGtkScrolledWindow";
			this.NodeViewGtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child NodeViewGtkScrolledWindow.Gtk.Container+ContainerChild
			this.NodeView = new global::Gtk.NodeView ();
			this.NodeView.CanFocus = true;
			this.NodeView.Name = "NodeView";
			this.NodeViewGtkScrolledWindow.Add (this.NodeView);
			this.Notebook.Add (this.NodeViewGtkScrolledWindow);
			global::Gtk.Notebook.NotebookChild w5 = ((global::Gtk.Notebook.NotebookChild)(this.Notebook [this.NodeViewGtkScrolledWindow]));
			w5.Position = 1;
			// Notebook tab
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Table");
			this.Notebook.SetTabLabel (this.NodeViewGtkScrolledWindow, this.label2);
			this.label2.ShowAll ();
			this.VBox.Add (this.Notebook);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.VBox [this.Notebook]));
			w6.Position = 1;
			// Container child VBox.Gtk.Box+BoxChild
			this.HBox = new global::Gtk.HBox ();
			this.HBox.Name = "HBox";
			this.HBox.Spacing = 6;
			// Container child HBox.Gtk.Box+BoxChild
			this.AlignmentLeft = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.AlignmentLeft.Name = "AlignmentLeft";
			this.HBox.Add (this.AlignmentLeft);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.HBox [this.AlignmentLeft]));
			w7.Position = 0;
			// Container child HBox.Gtk.Box+BoxChild
			this.NewButton = new global::Gtk.Button ();
			this.NewButton.CanFocus = true;
			this.NewButton.Name = "NewButton";
			this.NewButton.UseUnderline = true;
			// Container child NewButton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w8 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w9 = new global::Gtk.HBox ();
			w9.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w10 = new global::Gtk.Image ();
			w10.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-new", global::Gtk.IconSize.Menu);
			w9.Add (w10);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w12 = new global::Gtk.Label ();
			w9.Add (w12);
			w8.Add (w9);
			this.NewButton.Add (w8);
			this.HBox.Add (this.NewButton);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.HBox [this.NewButton]));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			// Container child HBox.Gtk.Box+BoxChild
			this.OpenButton = new global::Gtk.Button ();
			this.OpenButton.CanFocus = true;
			this.OpenButton.Name = "OpenButton";
			this.OpenButton.UseUnderline = true;
			// Container child OpenButton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w17 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w18 = new global::Gtk.HBox ();
			w18.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w19 = new global::Gtk.Image ();
			w19.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-open", global::Gtk.IconSize.Menu);
			w18.Add (w19);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w21 = new global::Gtk.Label ();
			w18.Add (w21);
			w17.Add (w18);
			this.OpenButton.Add (w17);
			this.HBox.Add (this.OpenButton);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.HBox [this.OpenButton]));
			w25.Position = 2;
			w25.Expand = false;
			w25.Fill = false;
			// Container child HBox.Gtk.Box+BoxChild
			this.SaveButton = new global::Gtk.Button ();
			this.SaveButton.CanFocus = true;
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.UseUnderline = true;
			// Container child SaveButton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w26 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w27 = new global::Gtk.HBox ();
			w27.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w28 = new global::Gtk.Image ();
			w28.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			w27.Add (w28);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w30 = new global::Gtk.Label ();
			w27.Add (w30);
			w26.Add (w27);
			this.SaveButton.Add (w26);
			this.HBox.Add (this.SaveButton);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.HBox [this.SaveButton]));
			w34.Position = 3;
			w34.Expand = false;
			w34.Fill = false;
			// Container child HBox.Gtk.Box+BoxChild
			this.TransmitButton = new global::Gtk.Button ();
			this.TransmitButton.CanFocus = true;
			this.TransmitButton.Name = "TransmitButton";
			this.TransmitButton.UseUnderline = true;
			// Container child TransmitButton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w35 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w36 = new global::Gtk.HBox ();
			w36.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w37 = new global::Gtk.Image ();
			w37.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-apply", global::Gtk.IconSize.Menu);
			w36.Add (w37);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w39 = new global::Gtk.Label ();
			w36.Add (w39);
			w35.Add (w36);
			this.TransmitButton.Add (w35);
			this.HBox.Add (this.TransmitButton);
			global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.HBox [this.TransmitButton]));
			w43.Position = 4;
			w43.Expand = false;
			w43.Fill = false;
			// Container child HBox.Gtk.Box+BoxChild
			this.AlignmentRight = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.AlignmentRight.Name = "AlignmentRight";
			this.HBox.Add (this.AlignmentRight);
			global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.HBox [this.AlignmentRight]));
			w44.Position = 5;
			this.VBox.Add (this.HBox);
			global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.VBox [this.HBox]));
			w45.Position = 2;
			w45.Expand = false;
			w45.Fill = false;
			this.Add (this.VBox);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.Notebook.SwitchPage += new global::Gtk.SwitchPageHandler (this.OnNotebookSwitchPage);
			this.NewButton.Clicked += new global::System.EventHandler (this.OnNewButtonClicked);
			this.OpenButton.Clicked += new global::System.EventHandler (this.OnOpenButtonClicked);
			this.SaveButton.Clicked += new global::System.EventHandler (this.OnSaveButtonClicked);
			this.TransmitButton.Clicked += new global::System.EventHandler (this.OnTransmitButtonClicked);
		}
	}
}
