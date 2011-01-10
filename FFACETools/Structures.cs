using System;
using System.Runtime.InteropServices;

namespace FFACETools
{
	public partial class FFACE
	{
		/*
		 * Structures passed to/from FFACE
		 */
		#region PC/NPC

		#region Player Information

		/// <summary>
		/// Stats of the player
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct PlayerStats
		{
			public short Str;
			public short Dex;
			public short Vit;
			public short Agi;
			public short Int;
			public short Mnd;
			public short Chr;

		} // @ public struct PlayerStats

		/// <summary>
		/// Element reistances of the player
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct PlayerElements
		{
			public ushort Fire;
			public ushort Ice;
			public ushort Wind;
			public ushort Earth;
			public ushort Lightning;
			public ushort Water;
			public ushort Light;
			public ushort Dark;

		} // @ public struct PlayerElements

		/// <summary>
		/// Players Combat Skills
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		private struct PlayerCombatSkills
		{
			public ushort HandToHand;
			public ushort Dagger;
			public ushort Sword;
			public ushort GreatSword;
			public ushort Axe;
			public ushort GreatAxe;
			public ushort Scythe;
			public ushort Polearm;
			public ushort Katana;
			public ushort GreatKatana;
			public ushort Club;
			public ushort Staff;
			private ushort unkweap0;
			private ushort unkweap1;
			private ushort unkweap2;
			private ushort unkweap3;
			private ushort unkweap4;
			private ushort unkweap5;
			private ushort unkweap6;
			private ushort unkweap7;
			private ushort unkweap8;
			private ushort unkweap9;
			private ushort unkweap10;
			private ushort unkweap11;
			public ushort Archery;
			public ushort Marksmanship;
			public ushort Throwing;
			public ushort Guarding;
			public ushort Evasion;
			public ushort Shield;
			public ushort Parrying;

		} // @ public struct PlayerCombatSkills

		/// <summary>
		/// Players magic skills
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		private struct PlayerMagicSkills
		{
			public ushort Divine;
			public ushort Healing;
			public ushort Enhancing;
			public ushort Enfeebling;
			public ushort Elemental;
			public ushort Dark;
			public ushort Summon;
			public ushort Ninjitsu;
			public ushort Singing;
			public ushort String;
			public ushort Wind;
			public ushort BlueMagic;
			private ushort unkmagic0;
			private ushort unkmagic1;
			private ushort unkmagic2;
			private ushort unkmagic3;

		} // @ public struct PlayerMagicSkills

		/// <summary>
		/// Players craft skills
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		private struct PlayerCraftLevels
		{
			public ushort Fishing;
			public ushort Woodworking;
			public ushort Smithing;
			public ushort Goldsmithing;
			public ushort Clothcraft;
			public ushort Leathercraft;
			public ushort Bonecraft;
			public ushort Alchemy;
			public ushort Cooking;

		} // @ public struct PlayerCraftLevels

		/// <summary>
		/// Structure passed back from FFACE.GetPlayerInfo()
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		private struct PLAYERINFO
		{
			public int HPMax;
			public int MPMax;
			public Job MainJob;
			public byte MainJobLVL;
			public Job SubJob;
			public byte SubJobLVL;
			public ushort EXPIntoLVL;
			public ushort EXPForLVL;
			public PlayerStats Stats;
			public PlayerStats StatModifiers;
			public short Attack;
			public short Defense;
			public PlayerElements Elements;
			public short Title;
			public short Rank;
			public short RankPts;
			public byte Nation;
			public byte Residence;
			public int HomePoint;
			public PlayerCombatSkills CombatSkills;
			public PlayerMagicSkills MagicSkills;
			public PlayerCraftLevels CraftLevels;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 146)]
			private byte[] null0;
			public ushort LimitPoints;
			public byte MeritPoints;
			public byte LimitMode;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 78)]
			private byte[] null1;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			public StatusEffect[] Buffs;

		} // @ private struct PLAYERINFO

		#endregion

		/// <summary>
		/// FFACE structure for a party member
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		private struct PARTYMEMBER
		{
			public int pad0;
			public byte Index;
			public byte MemberNumber;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
			public string Name;
			public int SvrID;
			public int ID;
			private int unknown0;
			public int CurrentHP;
			public int CurrentMP;
			public int CurrentTP;
			public byte CurrentHPP;
			public byte CurrentMPP;
			public short Zone;
			private int pad1;
			public uint FlagMask;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
			private byte[] pad2;
			public int SvrIDDupe;
			public byte CurrentHPPDupe;
			public byte CurrentMPPDupe;
			public byte Active;
			private byte pad3;

		} // @ private struct PARTYMEMBER

		/// <summary>
		/// FFACE Structure for target information
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		private struct TARGETINFO
		{
			public int CurrentID;
			public int SubID;
			public int CurrentSvrID;
			public int SubSrvID;
			public ushort CurrentMask;
			public ushort SubMask;
			public byte IsLocked;
			public byte IsSub;
			public byte HPP;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
			public string Name;

		} // @ public struct TARGETINFO

		/// <summary>
		/// FFACE structure for alliance information
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		private struct ALLIANCEINFO
		{
			public int AllianceLeaderID;
			public int Party0LeaderID;
			public int Party1LeaderID;
			public int Party2LeaderID;
			public byte Party0Visible;
			public byte Party1Visible;
			public byte Party2Visible;
			public byte Party0Count;
			public byte Party1Count;
			public byte Party2Count;
			public byte Invited;
			private byte unknown;

		} // @ private struct ALLIANCEINFO

		#endregion

		#region Items

		/// <summary>
		/// FFACE structure for an inventory item
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		private struct INVENTORYITEM
		{
			public ushort ID;
			public byte Index;
			public uint Count;
			public uint Flag;
			public uint Price;
			public ushort Extra;

		} // @ public struct INVENTORYITEM

		/// <summary>
		/// Structure to hold information about an item in the treasure pool
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct TREASUREITEM
		{
			public byte Flag; //3=no item, 2=item	
			public short ItemID;
			public byte Count;
			public TreasureStatus Status;
			public short MyLot;
			public short WinLot;
			public int WinPlayerSrvID;
			public int WinPlayerID;
			public int TimeStamp; //utc timestamp

		} // @ private struct TREASUREITEM

        /// <summary>
        /// Structure to hold information about a specific item in the trade window
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct TRADEITEM
        { 
            public ushort ItemID;
            public byte Index;
            public byte Count;

        } // @ private struct TRADEITEM

        /// <summary>
        /// Structure containing information about the trade window
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct TRADEINFO
        { 
            public uint Gil;
            public int TargetID;
            public byte SelectedBox;		
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] 
            public TRADEITEM[] items;

        } // @ private struct TRADEINFO
		
		///<summary>
        ///FFACETools Structure for setTradeItems
        ///</summary>
        public struct NPCTRADEINFO
        {
            public UInt32 Gil;
            public TRADEITEM[] items;
        }


		#endregion

		#region Chat

		/// <summary>
		/// Chat extra info structure
		/// </summary>
		//private struct CHATEXTRAINFO
		//{
		//	public ChatMode MessageType;

		//} // @ private struct CHATEXTRAINFO

		#endregion

    } // @ public partial class FFACE
}
