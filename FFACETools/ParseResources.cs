using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;

using System.IO;

namespace FFACETools
{
	public partial class FFACE
	{
		/// <summary>
		/// This class will parse the resources.xml file to
		/// translate ID <-> Names of spells/abilities/items
		/// </summary>
		public class ParseResources
		{
			#region Constants

			/// <summary>
			/// Name of the resources.xml file
			/// </summary>
			private const string RESOURCES_FILE_NAME = "resources.xml";

			private const string RESOURCES_ITEMS_GENERAL_FILE_NAME = "items_general.xml";
			private const string RESOURCES_ITEM_ARMOR_FILE_NAME = "items_armor.xml";
			private const string RESOURCES_ITEM_WEAPONS_FILE_NAME = "items_weapons.xml";
			private const string RESOURCES_AREAS_FILE_NAME = "areas.xml";
			private const string RESOURCES_STATUS_FILE_NAME = "status.xml";
			private const string RESOURCES_SPELLS_FILE_NAME = "spells.xml";
			private const string RESOURCES_ABILS_FILE_NAME = "abils.xml";

			#endregion

			/// <summary>
			/// Will get the name of the passed area ID
			/// </summary>
			/// <param name="id">ID of the area to get the name for</param>
			public static string GetAreaName(int id)
			{
				string sResult = String.Empty;

				XPathDocument document = new XPathDocument(FFACE.WindowerPath.Trim(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar + RESOURCES_AREAS_FILE_NAME);

				XPathNavigator node = document.CreateNavigator().SelectSingleNode("//areas/a[@id='" + id + "']");
				//XPathDocument document = new XPathDocument(/*FFACE.WindowerPath + */RESOURCES_FILE_NAME);

				//XPathNavigator node = document.CreateNavigator().SelectSingleNode("//resources/areas/entry[@id='" + id + "']");

				if (null != node && !String.IsNullOrEmpty(node.Value))
					sResult = node.Value;

				return sResult;

			} // @ public static string GetAreaName(int id)

			/// <summary>
			/// Will get the name of the passed item ID
			/// </summary>
			/// <param name="id">ID of the item to get the name for</param>
			public static string GetItemName(int id)
			{
				string sResult = String.Empty;

				//XPathDocument document = new XPathDocument(/*FFACE.WindowerPath + */RESOURCES_FILE_NAME);

				//XPathNavigator node = document.CreateNavigator().SelectSingleNode("//resources/items/entry[@id='" + id + "']");

				//if (null != node && !String.IsNullOrEmpty(node.Value))
				//        sResult = node.Value;

				XPathDocument document = new XPathDocument(FFACE.WindowerPath.Trim(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar + RESOURCES_ITEMS_GENERAL_FILE_NAME);
				XPathNavigator node = document.CreateNavigator().SelectSingleNode("//items/i[@id='" + id + "']");  // Items Armor items_armor.xml
				if (null != node && !String.IsNullOrEmpty(node.Value))
				  return (node.Value);

				XPathDocument doc2 = new XPathDocument(FFACE.WindowerPath.Trim(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar + RESOURCES_ITEM_ARMOR_FILE_NAME);
				XPathNavigator node2 = doc2.CreateNavigator().SelectSingleNode("//items/i[@id='" + id + "']");  // Items Weapons item_weapons.xml
				if (null != node2 && !String.IsNullOrEmpty(node2.Value))
				  return (node2.Value);

				XPathDocument doc1 = new XPathDocument(FFACE.WindowerPath.Trim(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar + RESOURCES_ITEM_WEAPONS_FILE_NAME);
				XPathNavigator node1 = doc1.CreateNavigator().SelectSingleNode("//items/i[@id='" + id + "']");  // Items General items_general.xml

				if (null != node1 && !String.IsNullOrEmpty(node1.Value))
				  sResult = node1.Value;
				return sResult;

			} // @ public static string GetItemName(int id)

			/// <summary>
			/// Will get the ID of of the passed item name (case senstitive)
			/// </summary>
			/// <param name="name">Name of the item</param>
			/// <returns>-1 if no ID was found for passed name</returns>
			public static int GetItemID(string name)
			{
			  int iResult = -1;

			  //XPathDocument document = new XPathDocument(/*FFACE.WindowerPath + */RESOURCES_FILE_NAME);
			  //XPathNavigator node = document.CreateNavigator().SelectSingleNode("//resources/items/entry[translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"" + name.ToLower() + "\"]");

			  XPathDocument document = new XPathDocument(FFACE.WindowerPath.Trim(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar + RESOURCES_ITEMS_GENERAL_FILE_NAME);
			  XPathNavigator node = document.CreateNavigator().SelectSingleNode("//items/i[translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"" + name.ToLower() + "\"]");

			  if (null != node && !String.IsNullOrEmpty(node.Value))
			    return (Convert.ToInt32(node.GetAttribute("id", String.Empty)));

			  XPathDocument doc2 = new XPathDocument(FFACE.WindowerPath.Trim(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar + RESOURCES_ITEM_ARMOR_FILE_NAME);
			  XPathNavigator node2 = doc2.CreateNavigator().SelectSingleNode("//items/i[translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"" + name.ToLower() + "\"]");
			  //XPathNavigator node = document.CreateNavigator().SelectSingleNode("//resources/items/entry[translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"" + name.ToLower() + "\"]");

			  if (null != node2 && !String.IsNullOrEmpty(node2.Value))
			    return (Convert.ToInt32(node2.GetAttribute("id", String.Empty)));

			  XPathDocument doc1 = new XPathDocument(FFACE.WindowerPath.Trim(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar + RESOURCES_ITEM_WEAPONS_FILE_NAME);
			  XPathNavigator node1 = doc1.CreateNavigator().SelectSingleNode("//items/i[translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"" + name.ToLower() + "\"]");

			  if (null != node1 && !String.IsNullOrEmpty(node1.Value))
			    iResult = Convert.ToInt32(node1.GetAttribute("id", String.Empty));

			  return iResult;

			} // @ public static string GetItemID(string name)

			/// <summary>
			/// Will get the name of the passed status effect
			/// </summary>
			/// <param name="id">ID of the area to get the name for</param>
			public static string GetStatusEffectName(StatusEffect statusEffect)
			{
				string sResult = String.Empty;

				//XPathDocument document = new XPathDocument(/*FFACE.WindowerPath + */RESOURCES_FILE_NAME);
				//XPathNavigator node = document.CreateNavigator().SelectSingleNode("//resources/status/entry[@id='" + statusEffect + "']");

				XPathDocument document = new XPathDocument(FFACE.WindowerPath.Trim(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar + RESOURCES_STATUS_FILE_NAME);
				XPathNavigator node = document.CreateNavigator().SelectSingleNode("//status/b[@id='" + statusEffect + "']");

				if (null != node && !String.IsNullOrEmpty(node.Value))
					sResult = node.Value;

				return sResult;

			} // @ public static string GetAreaName(int id)

			/// <summary>
			/// Current array of exact file numbers that contain the information for each file type.
			/// </summary>
			private static int[] _fileNumberArray = { -1,							   // Nil, ignore
				// To access, do (NUM_LANG_MAX * file_type) + Pref.Language
				// Items													= 0
				4,	73,	55815,  56235,
				// Objs													 = 1
				5,	74,	55816,	56236,
				// Weapons												  = 2
				6,	75,	55817,	56237,
				// Armor													= 3
				7,	76,	55818,	56238,
				// Puppet												   = 4
				8,	77,	55819,	56239,
				// Gil													  = 5
				9,	91,	55820,	56240
			};

			public static string[] _FileNumberArrayList = null;
			public static void GetItemList(int processID)
			{
				string datpath = String.Empty;

				System.Diagnostics.Process proc = System.Diagnostics.Process.GetProcessById(processID);
				foreach (System.Diagnostics.ProcessModule module in proc.Modules)
				{
					if (module.ModuleName.ToLower().Equals("ffxi.dll"))
						datpath = module.FileName.Substring(0, module.FileName.Length - 8);
				}

				String filenameToCheck = String.Empty;

				BinaryReader vtable = new BinaryReader(File.Open(datpath + "VTABLE.DAT", FileMode.Open));
				BinaryReader ftable = new BinaryReader(File.Open(datpath + "FTABLE.DAT", FileMode.Open));

				foreach (int num in _fileNumberArray)
				{
					if (null == _FileNumberArrayList)
						_FileNumberArrayList = new string[1];
					else
						Array.Resize(ref _FileNumberArrayList, _FileNumberArrayList.Length + 1);

					if (num > 0)
					{
						vtable.BaseStream.Position = num;
						if (vtable.ReadByte() == 0x00)
						{
							_FileNumberArrayList[_FileNumberArrayList.Length - 1] = "INVALID FILE - num less than 0";
							continue;
						}

						ftable.BaseStream.Position = num * 2;

						filenameToCheck = datpath + InterpretPath(ftable.ReadUInt16());
						if (!File.Exists(filenameToCheck))
							throw new FileNotFoundException("File does not exist!", filenameToCheck);

						_FileNumberArrayList[_FileNumberArrayList.Length - 1] = filenameToCheck;
					}
					else 
						_FileNumberArrayList[_FileNumberArrayList.Length - 1] = "INVALID_FILE - num less than 0";

				}

				vtable.Close();
				ftable.Close();
			}

			/// <summary>
			/// Returns a string in the format ROM\dir\file.DAT given a UInt16 fileID.
			/// </summary>
			/// <param name="fileID">The file ID found in FTABLE.DAT and VTABLE.DAT</param>
			/// <returns>String location of the file that fileID references.</returns>
			private static string InterpretPath(UInt16 fileID)
			{
				// all files for the FINAL FANTASY XI\FTABLE & VTABLE.DAT files are in ROM\
				// further files in the ROM2, ROM3, ROM4 folders have a separate FTABLE/VTABLE file
				// in their subdirectory.
				return String.Format("ROM\\{0}\\{1}.DAT", fileID >> 7, fileID & 0x007F);
			}

			private static class ffxiFileTypes
			{
				public static readonly int ITEMS = 0;
				public static readonly int OBJS = 1;
				public static readonly int WPNS = 2;
				public static readonly int ARMR = 3;
				public static readonly int PUPP = 4;
				public static readonly int GIL = 5;
			}

			private int GetFileNumber(int filetype)
			{
				if ((filetype < 0) || (filetype >= _FileNumberArrayList.Length))
					return 0;
				return (int)((filetype * 4) + 2);
			}

			/*
			/// <summary>
			/// Generic loader for loading Item names into a permanent array for use by GetPhrases().
			/// </summary>
			/// <param name="file_num">File number to load (OBJ, ITEMS, PUPP, ARMR, WEPN, GIL)</param>
			private void LoadItemFile(int file_num)
			{
				if (_FileNumberArrayList == null)
					return;
				else if ((file_num < 0) || (file_num >= _FileNumberArrayList.Length))
					return;

				FileInfo fi = new FileInfo(_FileNumberArrayList[file_num]);
				Boolean file_error = false;

				if (!fi.Exists) return;
				if ((fi.Length % 0xC00) != 0) return;

				int items_in_file = (int)(fi.Length / 0xC00);
				BinaryReader iteminfo = null;
				try
				{
					iteminfo = new BinaryReader(File.Open(_FileNumberArrayList[file_num], FileMode.Open));
				}
				catch (IOException e)
				{
					//System.Windows.Forms.MessageBox.Show(e.Message + "\r\nSome Auto-Translate phrases may not be available.");
					file_error = true;
				}

				if (file_error == true) 
					return;  // Attempt a Sanity Check

				for (int item_counter = 0; item_counter < items_in_file; item_counter++)
				{
					iteminfo.BaseStream.Position = 0xC00 * item_counter;
					byte[] readbytes = DecodeBlock(iteminfo.ReadBytes(0x200), 5);
					BinaryReader data = new BinaryReader(new MemoryStream(readbytes, false));
					itemFormat itemObjects = new itemFormat(data, FFXIConvert);
					// INSERT ITEM CHECK DATA HERE
					data.Close();
					//if ((itemObjects.itemHeader.ID < 0xFFFF) && (itemObjects.itemHeader.ID > 0x6FFF))
					//	continue;
					//else if (itemObjects.text == String.Empty)
					//	continue;
					//else 
					if ((itemObjects.itemHeader.Flags & (ushort)ItemFlags.Nothing) == (ushort)ItemFlags.Nothing)
						continue;
					else if (itemObjects.itemHeader.ID == 0x00)
						continue;

					// 0x0100 0x0040 0x1000
					/* UINT32 ID
					 * UINT16 Flags
					 * UINT16 Stack Size
					 * UINT16 Type
					 * UINT16 ResourceID
					 * UINT16 ValidTargets 
					 * 14 Bytes - Common Header Size
					 *
					int atp = 0;

					if (_ATKeys_Items == null)
						_ATKeys_Items = new FFXIATPhrase[1];
					else Array.Resize(ref _ATKeys_Items, (int)(_ATKeys_Items.Length + 1));

					atp = _ATKeys_Items.Length - 1;

					_ATKeys_Items[atp] = new FFXIATPhrase();
					_ATKeys_Items[atp].StringResource = 0x07;
					_ATKeys_Items[atp].Language = (byte)2;
					_ATKeys_Items[atp].GroupID = (byte)((itemObjects.itemHeader.ID & 0xFF00) >> 8);
					_ATKeys_Items[atp].MessageID = (byte)(itemObjects.itemHeader.ID & 0x00FF);
					_ATKeys_Items[atp].Flags = itemObjects.itemHeader.Flags;
					if (itemObjects.itemHeader.Type != 0)  // if it's nothing, categorize at as something else
						_ATKeys_Items[atp].Type = itemObjects.itemHeader.Type;
					else
					{
						if ((itemObjects.itemHeader.ID <= 0x2FFF) && (itemObjects.itemHeader.ID >= 0x2000))
							_ATKeys_Items[atp].Type = 13; // Puppet Items
						else if ((itemObjects.itemHeader.ID <= 0x3FFF) && (itemObjects.itemHeader.ID >= 0x3000))
							_ATKeys_Items[atp].Type = 5; // Armor Items
						else if ((itemObjects.itemHeader.ID <= 0x6FFF) && (itemObjects.itemHeader.ID >= 0x4000))
							_ATKeys_Items[atp].Type = 4; // Weapon Items
					}
					_ATKeys_Items[atp].value = itemObjects.text;
					_ATKeys_Items[atp].shortvalue = itemObjects.logtext; // misleading i know
				}
				iteminfo.Close();
			}

			/// <summary>
			/// Decodes a data/text block by reversing the set bit rotation.
			/// </summary>
			/// <param name="bytes">Array of bytes to decode.</param>
			/// <param name="shiftcount">The number of bits to shift right by.</param>
			/// <returns>The modified bytes array.</returns>
			private static byte[] DecodeBlock(byte[] bytes, int shiftcount)
			{
				for (int i = 0; i < bytes.Length; i++)
					bytes[i] = RotateRight(bytes[i], shiftcount);
				return bytes;
			}

			/// <summary>Rotates the bits to the right by a set number of places.</summary>
			/// <param name="b">The byte whose bits we want to shift with rotation (preserving all set bits).</param>
			/// <param name="count">The number of places we want to shift the byte by.</param>
			/// <returns>The newly rotated byte.</returns>
			private static byte RotateRight(byte b, int count)
			{
				for (; count > 0; count--)
				{
					if ((b & 0x01) == 0x01)
					{
						b >>= 1; // if the last bit is 1 (ex. 00000001, it needs to be dropped
						b |= 0x80; // and then set as the first bit (ex. 10000000)
					}
					else b >>= 1; // if the last bit is not 1 (set), just rotate as normal.
				}
				return b;
			}

			private class itemHeaderFormat : Object
			{
				#region itemHeaderFormat Variables
				public UInt32 ID;
				public UInt16 Flags;
				public UInt16 StackSize;
				public UInt16 Type;
				public UInt16 ResourceID;
				public UInt16 ValidTargets;
				public UInt16 HeaderSize;
				#endregion

				#region itemHeaderFormat Constructor
				public itemHeaderFormat(BinaryReader br)
				{
					ID = br.ReadUInt32();
					Flags = br.ReadUInt16();
					StackSize = br.ReadUInt16();
					Type = br.ReadUInt16();
					ResourceID = br.ReadUInt16();
					ValidTargets = br.ReadUInt16();
					HeaderSize = 0x0E;  // 14 bytes, Common
				}
				#endregion
			}
			
			private class itemFormat : Object
			{
				#region itemFormat Variables
				public itemHeaderFormat itemHeader;
				public String text;
				public String logtext;
				#endregion

				#region itemFormat Constructor
				public itemFormat(BinaryReader br, FFXIEncoding FFXIConvert)
				{
					String[] ItemTexts = new String[9];

					itemHeader = new itemHeaderFormat(br);
					long data_pos = 0;
					UInt32 num_strings = 0, offset = 0, flags = 0;
					// Objects (General Items)  skip 6 bytes
					if ((itemHeader.ID <= 0x0FFF) && (itemHeader.ID >= 0x0000))
						br.BaseStream.Position = itemHeader.HeaderSize + 6;
					// Usable items skip 2 bytes
					// Usable Items skip 6 bytes as of March 10, 2008 Update (new UINT32)
					else if ((itemHeader.ID <= 0x1FFF) && (itemHeader.ID >= 0x1000))
						br.BaseStream.Position = itemHeader.HeaderSize + 6;
					// Gil skip just 2 bytes
					else if (itemHeader.ID == 0xFFFF)
						br.BaseStream.Position = itemHeader.HeaderSize + 2;
					// Puppet Items, skip 8 bytes
					else if ((itemHeader.ID <= 0x2FFF) && (itemHeader.ID >= 0x2000))
						br.BaseStream.Position = itemHeader.HeaderSize + 10;  // Unknown is 0x04 bytes not 0x02
					// Armor Specific Info, 22 bytes to skip to get to text
					// 26 in March 10, 2008 Update (new UINT32)
					else if ((itemHeader.ID <= 0x3FFF) && (itemHeader.ID >= 0x3000))
						br.BaseStream.Position = itemHeader.HeaderSize + 26;
					// Weapon Specific Info, 30 bytes to skip
					// 34 bytes in March 10, 2008 Update (new UINT32)
					else if ((itemHeader.ID <= 0x6FFF) && (itemHeader.ID >= 0x4000))
						br.BaseStream.Position = itemHeader.HeaderSize + 34;
					// Unknown, should not have anything in the way...
					else br.BaseStream.Position = itemHeader.HeaderSize + 2;
					data_pos = br.BaseStream.Position;
					num_strings = br.ReadUInt32();
					long fallback_pos = 0;
					for (int i = 0; i < num_strings; i++)
					{
						//					if (num_strings >= 5)
						//{ int x = i; }

						offset = br.ReadUInt32();
						flags = br.ReadUInt32();
						fallback_pos = br.BaseStream.Position;
						// Indicator (UInt32) + UInt32 x 6 Padding before text
						br.BaseStream.Position = data_pos + offset + 28;
						byte[] b = new byte[4];
						int counter = 0;
						do
						{
							if (br.BaseStream.Position >= br.BaseStream.Length) break;
							if (b == null)
								b = new byte[4];
							else if ((counter + 4) > b.Length)
								Array.Resize(ref b, (int)(counter + 4));
							b[counter++] = br.ReadByte();
							b[counter++] = br.ReadByte();
							b[counter++] = br.ReadByte();
							b[counter++] = br.ReadByte();
							if (b[counter - 1] == 0x00)
								break;
						} while (true);
						ItemTexts[i] = FFXIConvert.GetString(b).Trim().Trim("\0\u0001.".ToCharArray());
						br.BaseStream.Position = fallback_pos;
					}
					text = ItemTexts[0];
					if (num_strings <= 4) // Japanese (no log name, same as shortname)
						logtext = text;
					else if (num_strings <= 5) // English (shortname, logname is position 3)
						logtext = ItemTexts[2];
					else if (num_strings <= 6) // French (shortname, logname is position 4)
						logtext = ItemTexts[3];
					else if (num_strings <= 9)
						logtext = ItemTexts[4];
					else logtext = text;
				}
				#endregion
			}

			*/
		} // @ public class ParseResources
	} // @ public partial class FFACE
}
