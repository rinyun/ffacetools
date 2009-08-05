﻿using System;

namespace FFACETools
{
	public partial class FFACE
	{
		/// <summary>
		/// Wrapper class for menu information from FFACE
		/// </summary>
		public class MenuTools
		{
			#region Constructor

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="instanceID">Instance ID generated by FFACE</param>
			public MenuTools(int instanceID)
			{
				_InstanceID = instanceID;

			} // @ public MenuTools(int instanceID)

			#endregion

			#region Members

			/// <summary>
			/// Instance ID Generated by FFACE
			/// </summary>
			private int _InstanceID { get; set; }

			/// <summary>
			/// Whether a menu is open or not
			/// </summary>
			public bool IsOpen
			{
				get { return MenuIsOpen(_InstanceID); }

			} // @ public bool IsOpen

			/// <summary>
			/// Name of the menu
			/// </summary>
			public string Name
			{
				get
				{
					int size = 9;
					byte[] buffer = new byte[size];
					MenuName(_InstanceID, buffer, ref size);

					return System.Text.Encoding.ASCII.GetString(buffer, 0, size - 1).Trim();
				}
			} // @ public bool Name

			/// <summary>
			/// Selection string of the menu
			/// </summary>
			public string Selection
			{
				get
				{
					int size = 12;
					byte[] buffer = new byte[size];
					MenuSelection(_InstanceID, buffer, ref size);

					return System.Text.Encoding.ASCII.GetString(buffer, 0, size - 1);
				}
			} // @ public string Selection

			/// <summary>
			/// Help message of the menu
			/// </summary>
			public string Help
			{
				get
				{
					int size = 100;
					byte[] buffer = new byte[size];
					MenuHelp(_InstanceID, buffer, ref size);

					return System.Text.Encoding.ASCII.GetString(buffer, 0, size - 1);
				}
			} // @ public string Help

			/// <summary>
			/// Maximum quantity of the selection
			/// </summary>
			public byte ShopQuantityMax
			{
				get { return FFACE.ShopQuantityMax(_InstanceID); }

			} // @ public string ShopQuantityMax

			/// <summary>
			/// Current quantity of the selection
			/// </summary>
			public byte ShopQuantity
			{
				get { return FFACE.ShopQuantity(_InstanceID); }

			} // @ public byte ShopQuantity

			#endregion

		} // @ public class Menu
	} // @ public partial class FFACE
}