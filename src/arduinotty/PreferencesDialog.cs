using System;

namespace arduinotty
{
	public partial class PreferencesDialog : Gtk.Dialog
	{
		Preferences preferences = new Preferences();
		
		public PreferencesDialog()
		{
			this.Build();
			SpinButton.TooltipMarkup = Mono.Unix.Catalog.GetString("Adjust baudrate.");
			ComboBox.TooltipMarkup = Mono.Unix.Catalog.GetString("Adjust view.");
			FontButton.TooltipMarkup = Mono.Unix.Catalog.GetString("Adjust font.");
			buttonOk.TooltipMarkup = Mono.Unix.Catalog.GetString("Apply preferences.");
			buttonCancel.TooltipMarkup = Mono.Unix.Catalog.GetString("Cancel.");
		}
		
		public void SetPreferences(Preferences p)
		{
			if(p != null) 
			{
				UseLastValuesCheckButton.Active = p.UseLastUsedSettings;
				SpinButton.Value = Convert.ToDouble(p.Baudrate);
				ComboBox.Active = p.BytesView;
				FontButton.FontName = p.Font;
				CheckButton.Active = p.ShowSymbol;
				if(p.UseLastUsedSettings)
				{
					SpinButton.Sensitive = false;
					ComboBox.Sensitive = false;
				}
				else
				{
					SpinButton.Sensitive = true;
					ComboBox.Sensitive = true;
				}
			}
		}
		
		public Preferences GetPreferences()
		{
			Preferences preferences = new Preferences();
			preferences.Baudrate = Convert.ToInt32(SpinButton.Value);
			preferences.BytesView = ComboBox.Active;
			preferences.Font = FontButton.FontName;
			preferences.ShowSymbol = CheckButton.Active;
			preferences.UseLastUsedSettings = UseLastValuesCheckButton.Active;
			return preferences;
		}

		protected void OnUseLastValuesCheckButtonClicked (object sender, System.EventArgs e)
		{
			if(UseLastValuesCheckButton.Active)
			{
				SpinButton.Sensitive = false;
				ComboBox.Sensitive = false;
			}
			else
			{
				SpinButton.Sensitive = true;
				ComboBox.Sensitive = true;
			}
		}
	}
}

