using System;
using Gtk;

namespace arduinotty
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			Mono.Unix.Catalog.Init("arduinotty", "./locale");
			MainWindow win = new MainWindow();
			win.Show ();
			Application.Run ();
		}
	}
}
