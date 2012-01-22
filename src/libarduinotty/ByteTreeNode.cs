using System;
using Gtk;

namespace libarduinotty
{
	[TreeNode (ListOnly=true)]
	public class ByteTreeNode : TreeNode
	{
		private byte p_Byte;
		
		[Gtk.TreeNodeValue (Column=0)]
		public string Binary
		{
			get 
			{
				string s = Convert.ToString(Convert.ToInt32(p_Byte), 2);
				if(s.Length < 8)
				{
					string sadd = "";
					for(int i = s.Length; i < 8; i++) sadd = sadd + "0";
					s = sadd + s;
				}
				return s; 
			}
		}
		
		[Gtk.TreeNodeValue (Column=1)]
		public string Octal
		{
			get { return Convert.ToString(Convert.ToInt32(p_Byte), 8); }
		}
		
		[Gtk.TreeNodeValue (Column=2)]
		public string Decimal
		{
			get { return Convert.ToString(Convert.ToInt32(p_Byte), 10); }
		}
		
		[Gtk.TreeNodeValue (Column=3)]
		public string Hexadecimal
		{
			get { return Convert.ToString(Convert.ToInt32(p_Byte), 16); }
		}
		
		[Gtk.TreeNodeValue (Column=4)]
		public string ASCII
		{
			get
			{
				return Convert.ToChar(Convert.ToInt32(p_Byte)).ToString();
			}
		}
		
		public byte Byte
		{
			get 
			{
				return p_Byte;
			}
		}
		
		public ByteTreeNode(byte b)
		{
			p_Byte = b;
		}
	}
}