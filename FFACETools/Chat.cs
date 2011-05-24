using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace FFACETools
{
	public partial class FFACE
	{
		/// <summary>
		/// Class container to impliment Pyrolol's chat system
		/// </summary>
		public class ChatTools
		{
			#region Classes

			/// <summary>
			/// Class container for a chat line returned from GetNextLine()
			/// </summary>
			public struct ChatLine
			{
				/// <summary>
				/// The time the message was parsed in
				/// "January 01, 2009 HH:mm:ss AM/PM" format.
				/// </summary>
				public DateTime NowDate { get; set; }
				
				/// <summary>
				/// The time the message was parsed in "[HH:mm:ss]" format.
				/// </summary>
				public string Now { get; set; }

				/// <summary>
				/// The color code of the message
				/// </summary>
				public Color Color { get; set; }

				/// <summary>
				/// The chat line text
				/// </summary>
				public string Text { get; set; }

				/// <summary>
				/// The type of message
				/// </summary>
				public ChatMode Type { get; set; }

				public static bool operator ==(ChatLine item1, ChatLine item2)
				{
					if ((object)item1 == null && (object)item2 == null)
						return true;
					else if ((object)item1 == null || (object)item2 == null)
						return false;
					else
						return item1.Equals(item2);
				}

				public static bool operator !=(ChatLine item1, ChatLine item2)
				{
					if ((object)item1 == null && (object)item2 == null)
						return false;
					else if ((object)item1 == null || (object)item2 == null)
						return true;
					else
						return !item1.Equals(item2);
				}

				/// <summary>
				/// Returns a value indicating whether this instance is is equal to a specified instance
				/// </summary>
				/// <param name="o"></param>
				/// <returns></returns>
				public override bool Equals(object o)
				{
					bool bEquals = false;

					if (o is ChatLine)
					{
						if (this.Text.Equals(((ChatLine)o).Text)
						  && this.Type.Equals(((ChatLine)o).Type))
							bEquals = true;
					}

					return bEquals;

				} // @ public override bool Equals(object o)

				/// <summary>
				/// Returns the hash code for the ChatLogEntry
				/// </summary>
				public override int GetHashCode()
				{
					return (Text.GetHashCode()) & (~(short)Type);

				} // @ public override int GetHashCode()
			}

			/// <summary>
			/// Structure to hold a Chat log message and it's type
			/// </summary>
			[Serializable]
			public class ChatLogEntry : ICloneable
			{
				#region Members

				public DateTime LineTime { get; set; }
				public string LineTimeString { get; set; }
				public string LineColor { get; set; }
				public string LineText { get; set; }
				public ChatMode LineType { get; set; }
				public int Index { get; set; }

				#endregion

				#region Methods

				public static bool operator ==(ChatLogEntry item1, ChatLogEntry item2)
				{
					if ((object)item1 == null && (object)item2 == null)
						return true;
					else if ((object)item1 == null || (object)item2 == null)
						return false;
					else
						return item1.Equals(item2);
				}

				public static bool operator !=(ChatLogEntry item1, ChatLogEntry item2)
				{
					if ((object)item1 == null && (object)item2 == null)
						return false;
					else if ((object)item1 == null || (object)item2 == null)
						return true;
					else
						return !item1.Equals(item2);
				}

				/// <summary>
				/// Returns a value indicating whether this instance is is equal to a specified instance
				/// </summary>
				/// <param name="o"></param>
				/// <returns></returns>
				public override bool Equals(object o)
				{
					bool bEquals = false;

					if (o is ChatLogEntry)
					{
						if(this.LineText.Equals(((ChatLogEntry)o).LineText)
						  && this.LineType.Equals(((ChatLogEntry)o).LineType)
						  && this.Index.Equals(((ChatLogEntry)o).Index))
							bEquals = true;
					}

					return bEquals;

				} // @ public override bool Equals(object o)

				/// <summary>
				/// Returns the hash code for the ChatLogEntry
				/// </summary>
				public override int GetHashCode()
				{
					return (LineText.GetHashCode()) & (~(short)LineType);

				} // @ public override int GetHashCode()

				public object Clone()
				{
					System.IO.MemoryStream ms = new System.IO.MemoryStream();
					System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
						new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
					bf.Serialize(ms, this);
					ms.Position = 0;
					object obj = bf.Deserialize(ms);
					ms.Close();

					return obj;
				}

				#endregion

			} // @ private struct ChatLogEntry

			#endregion

			#region Constructor

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="instanceID">Instance ID generated by FFACE</param>
			public ChatTools(int instanceID)
			{
				_InstanceID = instanceID;
				Update();
				Clear();

			} // @ public ChatWrapper(int instanceID)

			#endregion

			#region Members

			/// <summary>
			/// Instance ID generated by FFACE
			/// </summary>
			private int _InstanceID { get; set; }

			/// <summary>
			/// Queue of Chat Log entries
			/// </summary>
			private Queue<ChatLogEntry> _ChatLog = new Queue<ChatLogEntry>(50);

			/// <summary>
			/// Last seen chat entry
			/// </summary>
			private ChatLogEntry _LastSeenEntry;

			/// <summary>
			/// Number of lines FFACE sees in the chat log
			/// 
			/// NOTE: Draws directly from FFACE
			/// </summary>
			public int GetLineCount
			{
				get { return FFACE.GetChatLineCount(_InstanceID); }

			} // @ public int GetLineCount

			/// <summary>
			/// Returns if there is a new line, directly from FFACE
			/// </summary>
			public bool IsNewLine
			{
				get { return FFACE.IsNewLine(_InstanceID); }

			} // @ public bool IsNewLine

			#endregion

			#region Methods

			/// <summary>
			/// Will strip abnormal characters (colors, etc) from the string
			/// </summary>
			/// <param name="line">line to clean (left intact)</param>
			/// <returns>string containing the cleaned line</returns>
			internal string CleanLine(string line)
			{
			  string cleanedString = line;
			  byte[] bytearray1252 = System.Text.Encoding.GetEncoding(1252).GetBytes(cleanedString);
			  int i = 0, len = bytearray1252.Length;
			  string sEF = "\xFF\x1F\x20\x21\x22\x23\x24\x25\x26\x27\x28\xFF";
				// 1f 20 21 22 23 24 25 26 27 28
			  string rep = "<FIAETWLD{}>";
			  string s1E = "\x01\x02\x03\xFC\xFD";
			  string s1F = "\x0E\x0F\x2F\x7F\x79\x7B\x7C\x8D\x88\x8A\xA1\xD0\r\n\x07";
			  string sExtra = "\r\n\x07\x7F\x81\x87";
			  List<Byte> cleaned = new List<byte>();
			  int ndx = -1;

			  for (int c = 0; c < len; ++c) {

			    if ((bytearray1252[c] == '\xEF') && (((c + 1) < len) && ((ndx = sEF.IndexOf((char) bytearray1252[c + 1])) >= 0))) {
			      // 3C <  3E >
			      // 7B {  7D }
			      if (sEF[ndx] != '\x28') // Not closing brace? Needs starter char
				cleaned.Add((byte) rep[0]);
			      cleaned.Add((byte) rep[ndx]); // add rep.char based on Index
			      if (sEF[ndx] != '\x27') // Not opening brace? Needs closer char
				cleaned.Add((byte) rep[rep.Length - 1]); // >  Final: <{ and }> for Auto-translate braces
			      ++c;
			    }
			    else if ((bytearray1252[c] == '\x1F') && (((c + 1) < len) && s1F.IndexOf((char) bytearray1252[c + 1]) >= 0)) {
			      ++c;
			    }
			    else if ((bytearray1252[c] == '\x1E') && (((c + 1) < len) && s1E.IndexOf((char) bytearray1252[c + 1]) >= 0)) {
			      ++c;
			    }
			    else {
			      i = sExtra.IndexOf((char) bytearray1252[c]);
			      if (i >= 3) // \r\n\07 are singles, others are doubles
				{
				if (((bytearray1252[c] == '\x7F') && (((c + 1) < len) && bytearray1252[c + 1] == '\x31')) ||
				    ((bytearray1252[c] == '\x81') && (((c + 1) < len) && bytearray1252[c + 1] == '\xA1')) ||
				    ((bytearray1252[c] == '\x87') && (((c + 1) < len) && bytearray1252[c + 1] == '\xB2')) ||
				    ((bytearray1252[c] == '\x87') && (((c + 1) < len) && bytearray1252[c + 1] == '\xB3'))) {
				  ++c;
				}
				else {
				  i = -1; // not a target, so "wasn't found"
				}
			      }
			      /*else if (i >= 0) {
				++c; // using an auto-incrementing for loop this becomes { }
			      }*/
			      if (i < 0) {
				cleaned.Add(bytearray1252[c]);
			      }
			    }
			  }
			  cleaned.Add(0);
			  #region The above code done with all line.Replace() instead.
			  /*
				if (cleanedString.IndexOf('\xEF') >= 0)
				{
				  cleanedString = cleanedString.Replace("\xEF\x1F", "");  // Fire
				  cleanedString = cleanedString.Replace("\xEF\x20", "");  // Ice
				  cleanedString = cleanedString.Replace("\xEF\x21", "");  // Wind (Air)
				  cleanedString = cleanedString.Replace("\xEF\x22", "");  // Earth
				  cleanedString = cleanedString.Replace("\xEF\x23", "");  // Lightning (Thunder)
				  cleanedString = cleanedString.Replace("\xEF\x24", "");  // Water
				  cleanedString = cleanedString.Replace("\xEF\x25", "");  // Light
				  cleanedString = cleanedString.Replace("\xEF\x26", "");  // Darkness
				  cleanedString = cleanedString.Replace("\xEF\x27", "");  // Opening Brace
				  cleanedString = cleanedString.Replace("\xEF\x28", "");  // Closing Brace
				}
				if (cleanedString.IndexOf('\x1E') >= 0)
				{
				  cleanedString = cleanedString.Replace("\x1E\x01", "");
				  cleanedString = cleanedString.Replace("\x1E\x02", "");
				  cleanedString = cleanedString.Replace("\x1E\x03", "");
				  cleanedString = cleanedString.Replace("\x1E\xFC", "");
				  cleanedString = cleanedString.Replace("\x1E\xFD", "");
				}
				if (cleanedString.IndexOf('\x1F') >= 0)
				{
				  cleanedString = cleanedString.Replace("\x1F\x0E", "");
				  cleanedString = cleanedString.Replace("\x1F\x0F", "");
				  cleanedString = cleanedString.Replace("\x1F\x2F", "");
				  cleanedString = cleanedString.Replace("\x1F\x7F", "");
				  cleanedString = cleanedString.Replace("\x1F\x79", "");
				  cleanedString = cleanedString.Replace("\x1F\x7B", "");
				  cleanedString = cleanedString.Replace("\x1F\x7C", "");
				  cleanedString = cleanedString.Replace("\x1F\x8D", "");
				  cleanedString = cleanedString.Replace("\x1F\x88", "");
				  cleanedString = cleanedString.Replace("\x1F\x8A", "");
				  cleanedString = cleanedString.Replace("\x1F\xA1", "");
				  cleanedString = cleanedString.Replace("\x1F\xD0", "");
				  cleanedString = cleanedString.Replace("\x1F\r", "");
				  cleanedString = cleanedString.Replace("\x1F\n", "");
				  cleanedString = cleanedString.Replace("\x1F\x07", "");
				}
				if (cleanedString.IndexOfAny(new char[] { '\r', '\n', '\x7F', '\x81', '\x87', '\x07' }) >= 0) {
				  cleanedString = cleanedString.Replace("\r", "");
				  cleanedString = cleanedString.Replace("\n", "");
				  cleanedString = cleanedString.Replace("\x7F\x31", "");
				  cleanedString = cleanedString.Replace("\x81\xA1", "");
				  cleanedString = cleanedString.Replace("\x87\xB2", "");
				  cleanedString = cleanedString.Replace("\x87\xB3", "");
				  cleanedString = cleanedString.Replace("\x07", "");
				}
			  */
			  #endregion
			  #region Original code (fail)
			  /*
				// change the dot to a [ for start of string
				string startingChars = System.Text.Encoding.GetEncoding(1252).GetString(new byte[2] { 0x1e, 0xfc });
				if (cleanedString.StartsWith(startingChars))
					cleanedString = "[" + cleanedString.Substring(2);

				cleanedString = cleanedString.Replace("y", String.Empty);

				if (cleanedString.Contains(" "))
				{
					cleanedString = cleanedString.Replace(" ", "**&*&!!@#$@$#$");
					cleanedString = cleanedString.Replace("**&*&!!@#$@$#$", " ");
				}

				cleanedString = cleanedString.Replace("1", "");
				cleanedString = cleanedString.Replace(" ", " "); // green start
				cleanedString = cleanedString.Replace("", "");   // green end
				cleanedString = cleanedString.Replace("Ð", "");
				cleanedString = cleanedString.Replace("{", "");
				cleanedString = cleanedString.Replace("ﾐ", "");
				cleanedString = cleanedString.Replace("", "");
				cleanedString = cleanedString.Replace("・", "E");
				cleanedString = cleanedString.Replace("・", "[");
				cleanedString = cleanedString.Replace("・", "");
				cleanedString = cleanedString.Replace("巧", "I"); // Yellow colored lines, JP
				cleanedString = cleanedString.Replace("｡", ""); // Super Kupowers, JP
				cleanedString = cleanedString.Replace("垢", "C"); // Change job text.

				// trim the 1 that occasionally shows up at the end
				if (cleanedString.EndsWith("1"))
					cleanedString = cleanedString.TrimEnd('1');
				
				cleanedString = cleanedString.TrimStart('');
				*/
			  #endregion

			  if (cleaned[0] != 0)
			  {
				  byte[] arr = cleaned.ToArray();
				  cleanedString = System.Text.Encoding.GetEncoding(932).GetString(arr, 0, arr.Length);
			  }
			  else
				  cleanedString = String.Empty;
			  if (cleanedString.StartsWith("["))  // Detect and remove Windower Timestamp plugin text.
			  {
				  string text = cleanedString.Substring(1, 8);
				  string re1 = ".*?";	// Non-greedy match on filler
				  string re2 = "((?:(?:[0-1][0-9])|(?:[2][0-3])|(?:[0-9])):(?:[0-5][0-9])(?::[0-5][0-9])?(?:\\s?(?:am|AM|pm|PM))?)";

				  Regex r = new Regex(re1+re2,RegexOptions.IgnoreCase|RegexOptions.Singleline);
				  Match m = r.Match(text);
				  if (m.Success)
				  {
				    cleanedString = cleanedString.Remove(0, 11); // this assumes timestamp found is only 10+1 space in length
				    // Better way? : line = line.Remove(0,m.Length+1);
				  }
			  } // Detect and remove Windower Timestamp plugin text.

			  return cleanedString.TrimEnd('\0');

			} // private CleanLine(string line)

			/// <summary>
			/// Will get a chat line directly from FFACE
			/// </summary>
			/// <param name="index">Index of the line to get (0 being most recent)</param>
			internal ChatLogEntry GetLine(short index)
			{
				// 210 to make sure it reads to end of string
				// for some reason 200 isn't big enough and it will strip some of the line off if it's long
				int size = 255;
				byte[] buffer = new byte[255];
				GetChatLine(_InstanceID, index, buffer, ref size);
				if (size == 0)
					return new ChatLogEntry() { LineText = String.Empty, LineType = ChatMode.Unknown, Index = 0 };

				string tempLine = System.Text.Encoding.GetEncoding(1252).GetString(buffer, 0, size - 1);

				return new ChatLogEntry()
				{
					LineText = tempLine,
					Index = index
				};

			} // @ internal ChatLogEntry GetLine(short index)

			/// <summary>
			/// Will get a chat line and type directly from FFACE
			/// </summary>
			/// <param name="index">Index of the line to get (0 being most recent)</param>
			internal ChatLogEntry GetLineExtra(short index)
			{
				// 210 to make sure it reads to end of string
				// for some reason 200 isn't big enough and it will strip some of the line off if it's long
				int size = 255;
				byte[] buffer = new byte[255];
				ChatMode mode = new ChatMode();
				GetChatLineEx(_InstanceID, index, buffer, ref size, ref mode);
				if (size == 0)
					return new ChatLogEntry() { LineText = String.Empty, LineType = ChatMode.Unknown, Index = 0 };

				string tempLine = System.Text.Encoding.GetEncoding(1252).GetString(buffer, 0, size - 1);

				return new ChatLogEntry()
				{
					LineText = tempLine,
					LineType = mode,
					Index	= index
				};

			} // @ internal ChatLogEntry GetLineExtra(short index)

			/// <summary>
			/// Will get the raw data of a chat line from FFACE
			/// </summary>
			/// <param name="index">Index of the line to get (0 being most recent)</param>
			public ChatLogEntry GetLineRaw(short index)
			{
				// 210 to make sure it reads to end of string
				// for some reason 200 isn't big enough and it will strip some of the line off if it's long
				int size = 255;
				byte[] buffer = new byte[255];
				GetChatLineR(_InstanceID, index, buffer, ref size);
				if (size == 0)
					return new ChatLogEntry() { LineTime = DateTime.Now, LineTimeString = "[" + DateTime.Now.ToString("HH:mm:ss") + "] ", LineColor = string.Empty, LineText = String.Empty, LineType = ChatMode.Unknown, Index = 0 };

				// System.Text.Encoding.GetEncoding(932)
				string tempLine = System.Text.Encoding.GetEncoding(1252).GetString(buffer, 0, size - 1);
				
				string[] sArray = tempLine.Split(new char[1] {','}, 12);

				/*
				 * [0] Chat Type
				 * [1] UNKNOWN 
				 * [2] UNKNOWN
				 * [3] UNKNOWN
				 * [4] Index merging wrapping
				 * [5] Index not merging wrapping (a line wrap gets its own index)
				 * [6] UNKNOWN
				 * [7] UNKNOWN (always zero?)
				 * [8] UNKNOWN
				 * [9] UNKNOWN
				 * [10] UNKNOWN
				 * [11] Actual line text
				 */
				try {  // Temporary fix for index out of bounds error.
					return new ChatLogEntry()
					{
						LineTime = DateTime.Now,
						LineTimeString = "[" + DateTime.Now.ToString("HH:mm:ss") + "] ",
						// Original Line:  LineColor = ColorTranslator.FromHtml("#" + sArray[3]),
                        LineColor = sArray[3],
						LineText = sArray[11].Remove(0, 4),
						LineType = (ChatMode)short.Parse(sArray[0], System.Globalization.NumberStyles.AllowHexSpecifier),
						Index = int.Parse(sArray[5], System.Globalization.NumberStyles.AllowHexSpecifier)
					};
				} catch (Exception e) {
					return new ChatLogEntry()
					{
						LineTime = DateTime.Now,
						LineTimeString = "[" + DateTime.Now.ToString("HH:mm:ss") + "] ",
						LineColor = "#FF0000",
						LineText = "Error: " + e.Message,
						LineType = ChatMode.Unknown,
						Index = 0
					};
				}

			} // @ private ChatLogEntry GetLineRaw(short index)

			/// <summary>
			/// Updates the internal ChatTools queue
			/// </summary>
			internal void Update()
			{
				// create a stack to hold current unparsed messages
				Stack<ChatLogEntry> currentLines = new Stack<ChatLogEntry>();

				// if we don't know our most recent chat line
				// NOTE: This should only happen when the first update is called
				if (null == _LastSeenEntry)
				{
					// iterate over the last 50 chat lines
					for (short index = 0; index <= 49; index++)
					{
						ChatLogEntry currentEntry = GetLineRaw(index);

						// only add the first 3 most recent lines
						if (index.Equals(0))
							_LastSeenEntry = (ChatLogEntry)currentEntry.Clone();

						// add the line to the unparsed line list
						currentLines.Push(currentEntry);

					} // @ for (short j = 0; j <= 49; j++)
				} // @ if (_LastAdded.Count.Equals(0))

				// we know our most recent chat line
				// (every other time but the first call to this function)
				else 
				{
					// for tracking our most recent chat line
					ChatLogEntry mostCurrentEntry = null;

					// check for new unparsed lines from fface
					for (short index = 0; index <= 49; index++)
					{
						ChatLogEntry currentEntry = GetLineRaw(index);

						// add the indexed line to the current line stack
						currentLines.Push(currentEntry);

						// get the 3 most current lines
						if (index.Equals(0))
							mostCurrentEntry = (ChatLogEntry)currentEntry.Clone();

						// check if the current line (most recent so far)
						// is equal to the most recent last added line
						if (currentLines.Peek().Equals(_LastSeenEntry))
						{
							_LastSeenEntry = (ChatLogEntry)mostCurrentEntry.Clone();
							currentLines.Pop();

							break;

						} // @ if (stack.Peek() == _LastAdded.Peek())
					} // @ for (index = 0; index <= 49; index++)
				} // @ else

				// update our chatlog
				while (0 < currentLines.Count)
					_ChatLog.Enqueue(currentLines.Pop());

			} // @ public void Update()

			/// <summary>
			/// Returns the number of unparsed lines in the internal ChatTools queue
			/// </summary>
			internal int NumberOfUnparsedLines()
			{
				return _ChatLog.Count;

			} // @ public int NumberOfUnparsedLines()

			/// <summary>
			/// Marks a line as parsed in the internal ChatTools queue
			/// </summary>
			internal void LineParsed()
			{
				if (!_ChatLog.Count.Equals(0))
					_ChatLog.Dequeue();

			} // @ public void LineParsed()

			/// <summary>
			/// Clears the internal ChatTools queue
			/// </summary>
			public void Clear()
			{
				_ChatLog.Clear();

			} // @ public void Clear()

			/// <summary>
			/// Will get the next chat line
			/// </summary>
			/// <param name="cleanLine">Whether to return a clean text line</param>
			/// <param name="addcolor">Whether to return a color coded line</param>
			/// <returns>Empty string if no new line available, otherwise the new line</returns>
			public ChatLine GetNextLine(bool cleanLine, bool addcolor)
			{
				ChatLine line = new ChatLine();

				// update our local cache of chat lines
				Update();

				// if we have a new line
				if (!NumberOfUnparsedLines().Equals(0))
				{
					// get the next chat line
					line.Now = _ChatLog.Peek().LineTimeString;
					line.NowDate = _ChatLog.Peek().LineTime;
					if (addcolor == true)
                    {
                        line.Color = ColorTranslator.FromHtml("#" + _ChatLog.Peek().LineColor);
                    }
                    else
                    {
                        line.Color = Color.Empty;
                    }
                    
					line.Type = _ChatLog.Peek().LineType;
					line.Text = _ChatLog.Peek().LineText;

					// if user wanted to strip off color characters, do so
					if (cleanLine)
						line.Text = CleanLine(line.Text);

					LineParsed();

				} // @ if (!NumberOfUnparsedLines().Equals(0))

				return line;

			} // @ public string GetNextLine(bool cleanLine)

			/// <summary>
			/// Will get the next chat line
			/// </summary>
			/// <param name="cleanLine">Whether to return a clean text line</param>
			/// <returns>Empty string if no new line available, otherwise the new line</returns>
			internal ChatLine GetCurrentLine(bool cleanLine)
			{
				ChatLine line = new ChatLine();

				// update our local cache of chat lines
				Update();

				// if we have a new line
				if (!NumberOfUnparsedLines().Equals(0))
				{
					// get the next chat line
					line.Type = _ChatLog.Peek().LineType;
					line.Text = _ChatLog.Peek().LineText;

					// if user wanted to strip off color characters, do so
					if (cleanLine)
						line.Text = CleanLine(line.Text);

				} // @ if (!NumberOfUnparsedLines().Equals(0))

				return line;

			} // @ public string GetCurrentLine(bool cleanLine)

			#endregion

		} // @ public class ChatWrapper
	} // @ public partial FFACE
}
