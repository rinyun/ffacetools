﻿namespace FFACETools
{
	#region Status

	/// <summary>
	/// Player Statuses
	/// </summary>
	public enum Status : byte
	{
		Standing = 0,
		Fighting = 1,
		Dead1 = 2,
		Dead2 = 3,
		Event = 4,
		Chocobo = 5,
		Healing = 33,
		FishBite = 38,
		Obtained = 39,
		RodBreak = 40,
		LineBreak = 41,
		LostCatch = 43,
		CatchMonster = 42,
		Synthing = 44,
		Sitting = 47,
		Fishing = 50

	} // @ public enum Status : byte

	#endregion

	#region Job

	/// <summary>
	/// Player Jobs
	/// </summary>
	public enum Job : byte
	{
		NONE = 0,
		WAR = 1,
		MNK = 2,
		WHM = 3,
		BLM = 4,
		RDM = 5,
		THF = 6,
		PLD = 7,
		DRK = 8,
		BST = 9,
		BRD = 10,
		RNG = 11,
		SAM = 12,
		NIN = 13,
		DRG = 14,
		SMN = 15,
		BLU = 16,
		COR = 17,
		PUP = 18,
		DNC = 19,
		SCH = 20

	} // @ public enum Job : byte

	#endregion

	#region StatusEffect

	/// <summary>
	/// Status effects
	/// </summary>
	public enum StatusEffect : ushort
	{
		KO = 0,
		Weakness = 1,
		Sleep = 2,
		Poison = 3,
		Paralysis = 4,
		Blindness = 5,
		Silence = 6,
		Petrification = 7,
		Disease = 8,
		Curse = 9,
		Stun = 10,
		Bind = 11,
		Weight = 12,
		Slow = 13,
		Charm1 = 14,
		Doom = 15,
		Amnesia = 16,
		Charm2 = 17,
		Petrification = 18,
		Sleep2 = 19,
		Terror = 28,
		Mute = 29,
		Bane = 30,
		Plague = 31,
		Flee = 32,
		Haste = 33,
		Blaze_Spikes = 34,
		Ice_Spikes = 35,
		Blink = 36,
		Stoneskin = 37,
		Shock_Spikes = 38,
		Aquaveil = 39,
		Protect = 40,
		Shell = 41,
		Regen = 42,
		Refresh = 43,
		Mighty_Strikes = 44,
		Boost = 45,
		Hundred_Fists = 46,
		Manafont = 47,
		Chainspell = 48,
		Perfect_Dodge = 49,
		Invincible = 50,
		Blood_Weapon = 51,
		Soul_Voice = 52,
		Eagle_Eye_Shot = 53,
		Meikyo_Shisui = 54,
		Astral_Flow = 55,
		Berserk = 56,
		Defender = 57,
		Aggressor = 58,
		Focus = 59,
		Dodge = 60,
		Counterstance = 61,
		Sentinel = 62,
		Souleater = 63,
		Last_Resort = 64,
		Sneak_Attack = 65,
		Copy_Image = 66,
		Third_Eye = 67,
		Warcry = 68,
		Invisible = 69,
		Deodorize = 70,
		Sneak = 71,
		Sharpshot = 72,
		Barrage = 73,
		Holy_Circle = 74,
		Arcane_Circle = 75,
		Hide = 76,
		Camouflage = 77,
		Divine_Seal = 78,
		Elemental_Seal = 79,
		STR_Boost1 = 80,
		DEX_Boost1 = 81,
		VIT_Boost1 = 82,
		AGI_Boost1 = 83,
		INT_Boost1 = 84,
		MND_Boost1 = 85,
		CHR_Boost1 = 86,
		Trick_Attack = 87,
		Max_HP_Boost = 88,
		Max_MP_Boost = 89,
		Accuracy_Boost = 90,
		Attack_Boost = 91,
		Evasion_Boost = 92,
		Defense_Boost = 93,
		Enfire = 94,
		Enblizzard = 95,
		Enaero = 96,
		Enstone = 97,
		Enthunder = 98,
		Enwater = 99,
		Barfire = 100,
		Barblizzard = 101,
		Baraero = 102,
		Barstone = 103,
		Barthunder = 104,
		Barwater = 105,
		Barsleep = 106,
		Barpoison = 107,
		Barparalyze = 108,
		Barblind = 109,
		Barsilence = 110,
		Barpetrify = 111,
		Barvirus = 112,
		Reraise = 113,
		Cover = 114,
		Unlimited_Shot = 115,
		Phalanx = 116,
		Warding_Circle = 117,
		Ancient_Circle = 118,
		STR_Boost2 = 119,
		DEX_Boost2 = 120,
		VIT_Boost2 = 121,
		AGI_Boost2 = 122,
		INT_Boost2 = 123,
		MND_Boost2 = 124,
		CHR_Boost2 = 125,
		Spirit_Surge = 126,
		Costume = 127,
		Burn = 128,
		Frost = 129,
		Choke = 130,
		Rasp = 131,
		Shock = 132,
		Drown = 133,
		Dia = 134,
		Bio = 135,
		STR_Down = 136,
		DEX_Down = 137,
		VIT_Down = 138,
		AGI_Down = 139,
		INT_Down = 140,
		MND_Down = 141,
		CHR_Down = 142,
		Level_Restriction = 143,
		Max_HP_Down = 144,
		Max_MP_Down = 145,
		Accuracy_Down = 146,
		Attack_Down = 147,
		Evasion_Down = 148,
		Defense_Down = 149,
		Physical_Shield = 150,
		Arrow_Shield = 151,
		Magic_Shield1 = 152,
		Damage_Spikes = 153,
		Shining_Ruby = 154,
		Medicine = 155,
		Flash = 156,
		Subjob_Restriction = 157,
		Provoke = 158,
		Penalty = 159,
		Preparations = 160,
		Sprint = 161,
		Enchantment = 162,
		Azure_Lore = 163,
		Chain_Affinity = 164,
		Burst_Affinity = 165,
		Overdrive = 166,
		Magic_Def_Down = 167,
		Inhibit_TP = 168,
		Potency = 169,
		Regain = 170,
		Pax = 171,
		Intension = 172,
		Dread_Spikes = 173,
		Magic_Acc_Down = 174,
		Magic_Atk_Down = 175,
		Quickening = 176,
		Firestorm = 178,
		Hailstorm = 179,
		Windstorm = 180,
		Sandstorm = 181,
		Thunderstorm = 182,
		Rainstorm = 183,
		Aurorastorm = 184,
		Voidstorm = 185,
		Helix = 186,
		Sublimation_Activated = 187,
		Sublimation_Complete = 188,
		Magic_Shield2 = 189,
		Magic_Atk_Boost = 190,
		Magic_Def_Boost = 191,
		Requiem = 192,
		Lullaby = 193,
		Elegy = 194,
		Paeon = 195,
		Ballad = 196,
		Minne = 197,
		Minuet = 198,
		Madrigal = 199,
		Prelude = 200,
		Mambo = 201,
		Aubade = 202,
		Pastoral = 203,
		Hum = 204,
		Fantasia = 205,
		Operetta = 206,
		Capriccio = 207,
		Serenade = 208,
		Round = 209,
		Gavotte = 210,
		Fugue = 211,
		Rhapsody = 212,
		Aria = 213,
		March = 214,
		Etude = 215,
		Carol = 216,
		Threnody = 217,
		Hymnus = 218,
		Mazurka = 219,
		Sirvente = 220,
		Dirge = 221,
		Auto_Regen = 233,
		Auto_Refresh = 234,
		Fishing_Imagery = 235,
		Woodworking_Imagery = 236,
		Smithing_Imagery = 237,
		Goldsmithing_Imagery = 238,
		Clothcraft_Imagery = 239,
		Leathercraft_Imagery = 240,
		Bonecraft_Imagery = 241,
		Alchemy_Imagery = 242,
		Cooking_Imagery = 243,
		Dedication = 249,
		Ef_Badge = 250,
		Food = 251,
		Chocobo = 252,
		Signet = 253,
		Battlefield = 254,
		Sanction = 256,
		Besieged = 257,
		Illusion = 258,
		No_Weapons_Armor = 259,
		No_Support_Job = 260,
		No_Job_Abilities = 261,
		No_Magic_Casting = 262,
		Penalty_to_Attribute_s_ = 263,
		Allied_Tags = 267,
		Sigil = 268,
		Level_Sync = 269,
		Aftermath_lvl1 = 270,
		Aftermath_lvl2 = 271,
		Aftermath_lvl3 = 272,
		Aftermath = 273,
		Enlight = 274,
		Auspice = 275,
		Confrontation = 276,
		Enfire_2 = 277,
		Enblizzard_2 = 278,
		Enaero_2 = 279,
		Enstone_2 = 280,
		Enthunder_2 = 281,
		Enwater_2 = 282,
		Overload = 299,
		Fire_Maneuver = 300,
		Ice_Maneuver = 301,
		Wind_Maneuver = 302,
		Earth_Maneuver = 303,
		Thunder_Maneuver = 304,
		Water_Maneuver = 305,
		Light_Maneuver = 306,
		Dark_Maneuver = 307,
		Doubleup_Chance = 308,
		Bust = 309,
		Fighters_Roll = 310,
		Monks_Roll = 311,
		Healers_Roll = 312,
		Wizards_Roll = 313,
		Warlocks_Roll = 314,
		Rogues_Roll = 315,
		Gallants_Roll = 316,
		Chaos_Roll = 317,
		Beast_Roll = 318,
		Choral_Roll = 319,
		Hunters_Roll = 320,
		Samurai_Roll = 321,
		Ninja_Roll = 322,
		Drachen_Roll = 323,
		Evokers_Roll = 324,
		Maguss_Roll = 325,
		Corsairs_Roll = 326,
		Puppet_Roll = 327,
		Dancers_Roll = 328,
		Scholars_Roll = 329,
		Warriors_Charge = 340,
		Formless_Strikes = 341,
		Assassins_Charge = 342,
		Feint = 343,
		Fealty = 344,
		Dark_Seal = 345,
		Diabolic_Eye = 346,
		Nightingale = 347,
		Troubadour = 348,
		Killer_Instinct = 349,
		Stealth_Shot = 350,
		Flashy_Shot = 351,
		Sange = 352,
		Hasso = 353,
		Seigan = 354,
		Convergence = 355,
		Diffusion = 356,
		Snake_Eye = 357,
		Light_Arts = 358,
		Dark_Arts = 359,
		Penury = 360,
		Parsimony = 361,
		Celerity = 362,
		Alacrity = 363,
		Rapture = 364,
		Ebullience = 365,
		Accession = 366,
		Manifestation = 367,
		Drain_Samba = 368,
		Aspir_Samba = 369,
		Haste_Samba = 370,
		Velocity_Shot = 371,
		Building_Flourish = 375,
		Trance = 376,
		Tabula_Rasa = 377,
		Drain_Daze = 378,
		Aspir_Daze = 379,
		Haste_Daze = 380,
		Finishing_Move1 = 381,
		Finishing_Move2 = 382,
		Finishing_Move3 = 383,
		Finishing_Move4 = 384,
		Finishing_Move5 = 385,
		Lethargic_Daze1 = 386,
		Lethargic_Daze2 = 387,
		Lethargic_Daze3 = 388,
		Lethargic_Daze4 = 389,
		Lethargic_Daze5 = 390,
		Sluggish_Daze1 = 391,
		Sluggish_Daze2 = 392,
		Sluggish_Daze3 = 393,
		Sluggish_Daze4 = 394,
		Sluggish_Daze5 = 395,
		Weakened_Daze1 = 396,
		Weakened_Daze2 = 397,
		Weakened_Daze3 = 398,
		Weakened_Daze4 = 399,
		Weakened_Daze5 = 400,
		Addendum_White = 401,
		Addendum_Black = 402,
		Reprisal = 403,
		Magic_Evasion_Down = 404,
		Retaliation = 405,
		Footwork = 406,
		Klimaform = 407,
		Sekkanoki = 408,
		Pianissimo = 409,
		Saber_Dance = 410,
		Fan_Dance = 411,
		Altruism = 412,
		Focalization = 413,
		Tranquility = 414,
		Equanimity = 415,
		Enlightenment = 416,
		Afflatus_Solace = 417,
		Afflatus_Misery = 418,
		Composure = 419,
		Yonin = 420,
		Innin = 421

	} // @ public enum StatusEffect : short

	#endregion

	#region ChatMode

	/// <summary>
	/// Chat Modes
	/// </summary>
	public enum ChatMode : short
	{
		//------------------------------------------------------------------------------------------'
		//--------------------------------------Tekz eChatModes-------------------------------------'
		//------------------------------------------------------------------------------------------'

		Unknown = 0,			 // Catch all.

		//--------------------------------------------------------------'
		//-Text That's Been Sent To The ChatLog By You aKa (The Player-)'
		//--------------------------------------------------------------'
		SentSay = 1,			 // = A Say Msg That The Used Sends 
		SentShout = 2,		   // = A Shout Msg That The Used Sends
		SentTell = 4,			// = my Tell to someone else
		SentParty = 5,		   // = my msg to Party
		SentLinkShell = 6,	   // = my msg to my linkshell

		//--------------------------------------------------------------'
		//----Text That's Been Recieved In ChatLog By Other Players-----'
		//--------------------------------------------------------------'
		RcvdSay = 9,			 // = A Say Msg That The Used Will See From Someone Else
		RcvdShout = 10,		  // = A Shout Msg That The Used Will See From Someone Else
		RcvdTell = 12,		   // = received a Tell
		RcvdParty = 13,		  // = received party text -- Thanks to AcidFang for this value (v1.5.4)
		RcvdLinkShell = 14,	  // = incoming linkshell text

		//--------------------------------------------------------------'
		//-----------You aKa (The Player's) Fight Log Stuff-------------'
		//--------------------------------------------------------------'
		PlayerzFightLog = 20,	// eg. Teknical hits the Thread Leech for 63 points of damage.
		PlayerDefeats = 36,	  // eg. Teknical Defeats the River Crab. or whatever
		PlayerStartCasting = 52, // eg. Teknical starts casting Dia on the Thread Leech.
		PlayerUsesJobAbility = 101, // eg. Teknical uses Divine Seal.
		PlayerReadiesMove = 110, // eg. The Thread Leech readies Brain Drain.
		PlayersBadCast = 122,	// eg. Inturrupted or Unable to Cast. eg: Unable To Cast That Spell

		//--------------------------------------------------------------'
		//-----The Other Player aKa (The Target's) Fight Log Stuff------'
		//--------------------------------------------------------------'
		TargetUsesJobAbility = 22, // eg. The Thread Leech uses TP Drainkiss.
		TargetFightLog = 28,	 // eg. The Thread Leech hits Teknical for 4 points of damage.
		TargetReadiesMove = 100, // eg. Teknical readies Rock Crusher.
		TargetMisses = 29,	   // eg. The Thread Leech misses Teknical.

		Emote1 = 7,			  // = Emote1
		Emote2 = 15,			 // = Emote2

		Echo = 206,			  // = echo

		EffectWearOff = 191,	 // eg. Teknical's Protect effect wears off

		SomeoneDefeats = 44,	 // = somebody "defeats the" river crab or whatever
		SynthResult = 121,	   // = you throw away a rusty subligar or whatever
		TellNotRcvd = 123,	   // = your tell was not received
		SkillBoost = 129,		// = you fishing skill rises 0.1 points
		ItemSold = 138,		  // = item sold

		FishObtained = 146,	  // "player caught ....!"
		FishResult = 148,		// = fishing result including: 
								 //-You didn't catch anything=,
								 //-You lost your catch, 
								 //-Whatever caught the hook was too small to catch, 
								 //-Your line broke

		CaughtOnHook = 152,	  //// = something caught on hook
		DropRipCap = 159,		//// = you release the ripped cap regretfully

		CommandError = 157,	  //// = A command error occurred

		RegConquest = 161,	   //// = regional conquest update message
		ServerNotice = 200	   //// = notice of upcoming server maintenance

	} // @ public enum ChatMode : short

	#endregion

	#region Zone

	/// <summary>
	/// Zones
	/// </summary>
	public enum Zone : short
	{
		Unknown = 0x0,
		Phanauet_Channel = 0x1,
		Carpenters_Landing = 0x2,
		Manaclipper = 0x3,
		Bibiki_Bay = 0x4,
		Uleguerand_Range = 0x5,
		Bearclaw_Pinnacle = 0x6,
		Attohwa_Chasm = 0x7,
		Valley_Of_Sorrows = 0x8,
		PsoXja = 0x9,
		The_Shrouded_Maw = 0xA,
		Oldton_Movalpolos = 0xB,
		Newton_Movalpolos = 0xC,
		Mineshaft_2716 = 0xD,
		Hall_of_Transference = 0xE,
		Promyvion__Holla = 0x10,
		Spire_of_Holla = 0x11,
		Promyvion__Dem = 0x12,
		Spire_of_Dem = 0x13,
		Promyvion__Mea = 0x14,
		Spire_of_Mea = 0x15,
		Promyvion__Vahzl = 0x16,
		Spire_of_Vahzl = 0x17,
		Lufaise_Meadows = 0x18,
		Misareaux_Coast = 0x19,
		Tavnazian_Safehold = 0x1A,
		Phomiuna_Aqueducts = 0x1B,
		Sacrarium = 0x1C,
		Riverne__Site_B01 = 0x1D,
		Riverne__Site_A01 = 0x1E,
		Monarch_Linn = 0x1F,
		Sealions_Den = 0x20,
		AlTaieu = 0x21,
		Grand_Palace_of_HuXzoi = 0x22,
		The_Garden_of_RuHmet = 0x23,
		Stellar_Fulcrum = 0x24,
		Heavens_Tower = 0x25,
		Dynamis_Valkurm = 0x27,
		Dynamis_Buberimu = 0x28,
		Dynamis_Qufim = 0x29,
		Dynamis_Tavnazia = 0x2A,
		Bibiki_Bay__Purgonorgo_Isle = 0x2B,
		Al_Zahbi = 0x30,
		Aht_Urgan_Whitegate = 0x32,
		Wajaom_Woodlands = 0x33,
		Bhaflau_Thickets = 0x34,
		Nashmau = 0x35,
		Arrapago_Reef = 0x36,
		Ilrusi_Atoll = 0x37,
		Periqia = 0x38,
		Talacca_Cove = 0x39,
		Silver_Sea_Route_to_Nashmau = 0x3A,
		Silver_Sea_Route_to_Al_Zahbi = 0x3B,
		Mount_Zhayolm = 0x3D,
		Halvung = 0x3E,
		Lebros_Cavern = 0x3F,
		Mamook = 0x41,
		Mamool_Ja_Training_Grounds = 0x42,
		Aydeewa_Subterrane = 0x44,
		Leujaoam_Sanctum = 0x45,
		Caedarva_Mire = 0x4F,
		Ronfaure_West = 0x64,
		Ronfaure_East = 0x65,
		La_Theine_Plateau = 0x66,
		Valkurm_Dunes = 0x67,
		Jugner_Forest = 0x68,
		Batallia_Downs = 0x69,
		Gustaberg_North = 0x6A,
		Gustaberg_South = 0x6B,
		Konschtat_Highlands = 0x6C,
		Pashhow_Marshlands = 0x6D,
		Rolanberry_Fields = 0x6E,
		Beaucedine_Glacier = 0x6F,
		Xarcabard = 0x70,
		Cape_Terriggan = 0x71,
		Altepa_Eastern_Desert = 0x72,
		Sarutabaruta_West = 0x73,
		Sarutabaruta_East = 0x74,
		Tahrongi_Canyon = 0x75,
		Buburimu_Peninsula = 0x76,
		Meriphataud_Mountains = 0x77,
		Sauromugue_Champaign = 0x78,
		Sanctuary_of_ZiTah = 0x79,
		RoMaeve = 0x7A,
		Yuhtunga_Jungle = 0x7B,
		Yhoator_Jungle = 0x7C,
		Altepa_Western_Desert = 0x7D,
		Qufim_Island = 0x7E,
		Behemoths_Dominion = 0x7F,
		Valley_of_Sorrows = 0x80,
		RuAun_Gardens = 0x82,
		Mordion_Gaol = 0x83,
		Dynamis_Beaucedine = 0x86,
		Dynamis_Xarcabard = 0x87,
		Horlais_Peak = 0x8B,
		Ghelsba_Outpost = 0x8C,
		Fort_Ghelsba = 0x8D,
		Yughott_Grotto = 0x8E,
		Palborough_Mines = 0x8F,
		Waughroon_Shrine = 0x90,
		Giddeus = 0x91,
		Balgas_Dais = 0x92,
		Beadeaux = 0x93,
		Qulun_Dome = 0x94,
		Davoi = 0x95,
		Monastic_Cavern = 0x96,
		Castle_Oztroja = 0x97,
		Altar_Room = 0x98,
		Boyahda_Tree = 0x99,
		Dragons_Aery = 0x9A,
		Delkfutts_Middle_Tower = 0x9D,
		Delkfutts_Upper_Tower = 0x9E,
		Temple_of_Uggalepih = 0x9F,
		Den_of_Rancor = 0xA0,
		Castle_Zvahl_Baileys = 0xA1,
		Castle_Zvahl_Keep = 0xA2,
		Throne_Room = 0xA5,
		Ranguemont_Pass = 0xA6,
		Bostaunieux_Oubliette = 0xA7,
		Toraimarai_Canal = 0xA9,
		Full_Moon_Fountain = 0xAA,
		Zeruhn_Mines = 0xAC,
		Korroloka_Tunnel = 0xAD,
		Kuftal_Tunnel = 0xAE,
		Sea_Serpent_Grotto = 0xB0,
		VeLugannon_Palace = 0xB1,
		Shrine_of_RuAvitau = 0xB2,
		Empyreal_Paradox = 0xB3,
		LaLoff_Amphitheatre = 0xB4,
		Ground_of_Decisive_Battle = 0xB7,
		Delkfutts_Lower_Tower = 0xB8,
		Bastok_Mines = 0xBA,
		Windurst_Walls = 0xBB,
		RuLude_Gardens = 0xBC,
		King_Ranperres_Tomb = 0xBE,
		Dangruf_Wadi = 0xBF,
		Horutoto_Ruins = 0xC0,
		Ordelles_Caves = 0xC1,
		Eldieme_Necropolis = 0xC3,
		Gusgen_Mines = 0xC4,
		Crawlers_Nest = 0xC5,
		Maze_of_Shakhrami = 0xC6,
		Garlaige_Citadel = 0xC8,
		Cloister_of_Gales = 0xC9,
		Cloister_of_Thunder = 0xCA,
		Cloister_of_Frost = 0xCB,
		FeiYin = 0xCC,
		Ifrits_Cauldron = 0xCD,
		QuBia_Arena = 0xCE,
		Cloister_of_Flames = 0xCF,
		Quicksand_Caves = 0xD0,
		Cloister_of_Tremors = 0xD1,
		Cloister_of_Storms = 0xD3,
		Gustav_Tunnel = 0xD4,
		Labyrinth_of_Onzozo = 0xD5,
		Jeuno_Residential_Area = 0xD7,
		San_DOria_Residential_Area = 0xD8,
		Bastok_Residential_Area = 0xD9,
		Windurst_Residential_Area = 0xDA,
		Ferry_between_Mhaura__Selbina = 0xDC,
		Ferry_between_Selbina__Mhaura = 0xDD,
		Airship_from_Jeuno_to_Bastok = 0xE0,
		Southern_San_DOria = 0xE6,
		Northern_San_DOria = 0xE7,
		Port_San_DOria = 0xE8,
		Chateau_DOraguille = 0xE9,
		Bastok_Markets = 0xEB,
		Port_Bastok = 0xEC,
		Metalworks = 0xED,
		Windurst_Woods = 0xEE,
		Windurst_Waters = 0xEF,
		Port_Windurst = 0xF0,
		Upper_Jeuno = 0xF4,
		Lower_Jeuno = 0xF5,
		Port_Jeuno = 0xF6,
		Rabao = 0xF7,
		Selbina = 0xF8,
		Mhaura = 0xF9,
		Kazham = 0xFA,
		Hall_of_the_Gods = 0xFB,
		Norg = 0xFC

	} // @ public enum Zone : short 

	#endregion

	#region SpellList

	/// <summary>
	/// Spell List
	/// </summary>
	public enum SpellList : short
	{
		Cure			= 2,
		Cure_II		 = 4,
		Cure_III		= 6,
		Cure_IV		 = 8,
		Cure_V		  = 10,
		Cure_VI		 = 12,
		Curaga		  = 14,
		Curaga_II	   = 16,
		Curaga_III	  = 18,
		Curaga_IV	   = 20,
		Curaga_V		= 22,
		Raise		   = 24,
		Raise_II		= 26,
		Poisona		 = 28,
		Paralyna		= 30,
		Blindna		 = 32,
		Silena		  = 34,
		Stona		   = 36,
		Viruna		  = 38,
		Cursna		  = 40,
		Holy			= 42,
		Holy_II		 = 44,
		Dia			 = 46,
		Dia_II		  = 48,
		Dia_III		 = 50,
		Dia_IV		  = 52,
		Dia_V		   = 54,
		Banish		  = 56,
		Banish_II	   = 58,
		Banish_III	  = 60,
		Banish_IV	   = 62,
		Banish_V		= 64,
		Diaga		   = 66,
		Diaga_II		= 68,
		Diaga_III	   = 70,
		Diaga_IV		= 72,
		Diaga_V		 = 74,
		Banshiga		= 76,
		Banishga_II	 = 78,
		Banishga_III	= 80,
		Banishga_IV	 = 82,
		Banishga_V	  = 84,
		Protect		 = 86,
		Protect_II	  = 88,
		Protect_III	 = 90,
		Protect_IV	  = 92,
		Protect_V	   = 94,
		Shell		   = 96,
		Shell_II		= 98,
		Shell_III	   = 100,
		Shell_IV		= 102,
		Shell_V		 = 104,
		Blink		   = 106,
		Stoneskin	   = 108,
		Aquaveil		= 110,
		Slow			= 112,
		Haste		   = 114,
		Paralyze		= 116,
		Silence		 = 118,
		Barfire		 = 120,
		Barblizzard	 = 122,
		Baraero		 = 124,
		Barstone		= 126,
		Barthunder	  = 128,
		Barwater		= 130,
		Barfira		 = 132,
		Barblizzara	 = 134,
		Baraera		 = 136,
		Barstonra	   = 138,
		Barthundra	  = 140,
		Barwatera	   = 142,
		Barsleep		= 144,
		Barpoison	   = 146,
		Barparalyze	 = 148,
		Barblind		= 150,
		Barsilence	  = 152,
		Barpetrify	  = 154,
		Barvirus		= 156,
		Barsleep_II	 = 158,
		Barpoison_II	= 160,
		Barparalyze_II  = 162,
		Barblind_II	 = 164,
		Barsilence_II   = 166,
		Barpetrify_II   = 168,
		Barvirus_II	 = 170,
		Barsleepra	  = 172,
		Barpoisonra	 = 174,
		Barparalyzra	= 176,
		Barblindra	  = 178,
		Barsilencera	= 180,
		Barpetra		= 182,
		Barvira		 = 184,
		Barsleepra_II   = 186,
		Barpoisonra_II  = 188,
		Barparalyzra_II = 190,
		Barblindra_II   = 192,
		Barsilencera_II = 194,
		Barpetra_II	 = 196,
		Barvira_II	  = 198,
		Enfire		  = 200,
		Enblizzard	  = 202,
		Enaero		  = 204,
		Enstone		 = 206,
		Enthunder	   = 208,
		Enwater		 = 210,
		Phalanx		 = 212,
		Phalanx_II	  = 214,
		Regen		   = 216,
		Refresh		 = 218,
		Regen_II		= 220,
		Regen_III	   = 222,
		Flash		   = 224,

		Teleport_Yhoat  = 240,
		Teleport_Altep  = 242,
		Teleport_Holla  = 244,
		Teleport_Dem	= 246,
		Teleport_Mea	= 248,
		Protectra	   = 250,
		Protectra_II	= 252,
		Protectra_III   = 254,
		Protectra_IV	= 256,
		Protectra_V	 = 258,
		Shellra		 = 260,
		Shellra_II	  = 262,
		Shellra_III	 = 264,
		Shellra_IV	  = 266,
		Shellra_V	   = 268,
		Reraise		 = 270,
		Invisible	   = 272,
		Sneak		   = 274,
		Deodorize	   = 276,
		Teleport_Vahzl  = 278,
		Raise_III	   = 280,
		Reraise_II	  = 282,
		Reraise_III	 = 284,
		Erase		   = 286,
		Fire			= 288,
		Fire_II		 = 290,
		Fire_III		= 292,
		Fire_IV		 = 294,
		Fire_V		  = 296,
		Blizzard		= 298,
		Blizzard_II	 = 300,
		Blizzard_III	= 302,
		Blizzard_IV	 = 304,
		Blizzard_V	  = 306,
		Aero			= 308,
		Aero_II		 = 310,
		Aero_III		= 312,
		Aero_IV		 = 314,
		Aero_V		  = 316,
		Stone		   = 318,
		Stone_II		= 320,
		Stone_III	   = 322,
		Stone_IV		= 324,
		Stone_V		 = 326,
		Thunder		 = 328,
		Thunder_II	  = 330,
		Thunder_III	 = 332,
		Thunder_IV	  = 334,
		Thunder_V	   = 336,
		Water		   = 338,
		Water_II		= 340,
		Water_III	   = 342,
		Water_IV		= 344,
		Water_V		 = 346,
		Firaga		  = 348,
		Firaga_II	   = 350,
		Firaga_III	  = 352,
		Firaga_IV	   = 354,
		Firaga_V		= 356,
		Blizzaga		= 358,
		Blizzaga_II	 = 360,
		Blizzaga_III	= 362,
		Blizzaga_IV	 = 364,
		Blizzaga_V	  = 366,
		Aeroga		  = 368,
		Aeroga_II	   = 370,
		Aeroga_III	  = 372,
		Aeroga_IV	   = 374,
		Aeroga_V		= 376,
		Stonega		 = 378,
		Stonega_II	  = 380,
		Stonega_III	 = 382,
		Stonega_IV	  = 384,
		Stonega_V	   = 386,
		Thundaga		= 388,
		Thundaga_II	 = 390,
		Thundaga_III	= 392,
		Thundaga_IV	 = 394,
		Thundaga_V	  = 396,
		Waterga		 = 398,
		Waterga_II	  = 400,
		Waterga_III	 = 402,
		Waterga_IV	  = 404,
		Waterga_V	   = 406,
		Flare		   = 408,
		Flare_II		= 410,
		Freeze		  = 412,
		Freeze_II	   = 414,
		Tornado		 = 416,
		Tornado_II	  = 418,
		Quake		   = 420,
		Quake_II		= 422,
		Burst		   = 424,
		Burst_II		= 426,
		Flood		   = 428,
		Flood_II		= 430,
		Gravity		 = 432,
		Gravity_II	  = 434,
		Meteo		   = 436,
		Meteo_II		= 438,
		Poison		  = 440,
		Poison_II	   = 442,
		Poison_III	  = 444,
		Poison_IV	   = 446,
		Poison_V		= 448,
		Poisonga		= 450,
		Poisonga_II	 = 452,
		Poisonga_III	= 454,
		Poisonga_IV	 = 456,
		Poisonga_V	  = 458,
		Bio			 = 460,
		Bio_II		  = 462,
		Bio_III		 = 464,
		Bio_IV		  = 466,
		Bio_V		   = 468,
		Burn			= 470,
		Frost		   = 472,
		Choke		   = 474,
		Rasp			= 476,
		Shock		   = 478,
		Drown		   = 480,
		
		Drain		   = 490,
		Drain_II		= 492,
		Aspir		   = 494,
		Aspir_II		= 496,
		Blaze_Spikes	= 498,
		Ice_Spikes	  = 500,
		Shock_Spikes	= 502,
		Stun			= 504,
		Sleep		   = 506,
		Blind		   = 508,
		Break		   = 510,
		Virus		   = 512,
		Curse		   = 514,
		Bind			= 516,
		Sleep_II		= 518,
		Dispel		  = 520,
		Warp			= 522,
		Warp_II		 = 524,
		Escape		  = 526,
		Tractor		 = 528,
		Tractor_II	  = 530,
		Absorb_STR	  = 532,
		Absorb_DEX	  = 534,
		Absorb_VIT	  = 536,
		Absorb_AGI	  = 538,
		Absorb_INT	  = 540,
		Absorb_MND	  = 542,
		Absorb_CHR	  = 544,
		Sleepga_DRK	 = 546,
		Sleepga_II_DRK  = 548,
		
		Fire_Spirit	 = 576,
		Ice_Spirit	  = 578,
		Air_Spirit	  = 580,
		Earth_Spirit	= 582,
		Thunder_Spirit  = 584,
		Water_Spirit	= 586,
		Light_Spirit	= 588,
		Dark_Spirit	 = 590,
		Carbuncle	   = 592,
		Fenrir		  = 594,
		Ifrit		   = 596,
		Titan		   = 598,
		Leviathan	  = 600,
		Garuda		 = 602,
		Shiva		  = 604,
		Ramuh		  = 606,
		Diabolos	   = 608,
		
		Katon_Ichi	 = 640,
		Katon_Ni	   = 642,
		Katon_San	  = 644,
		Hyoton_Ichi	= 646,
		Hyoton_Ni	  = 648,
		Hyoton_San	 = 650,
		Huton_Ichi	 = 652,
		Huton_Ni	   = 654,
		Huton_San	  = 656,
		Doton_Ichi	 = 658,
		Doton_Ni	   = 660,
		Doton_San	  = 662,
		Raiton_Ichi	= 664,
		Raiton_Ni	  = 666,
		Raiton_San	 = 668,
		Suiton_Ichi	= 670,
		Suiton_Ni	  = 672,
		Suiton_San	 = 674,
		UtsusemiIchi   = 676,
		UtsusemiNi	 = 678,
		Utsusemi_San   = 680,
		Jubaku_Ichi	= 682,
		Jubaku_Ni	  = 684,
		Jubaku_San	 = 686,
		Hojo_Ichi	  = 688,
		Hojo_Ni		= 690,
		Hojo_San	   = 692,
		Kurayami_Ichi  = 694,
		Kurayami_Ni	= 696,
		Kurayami_San   = 698,
		Dokumori_Ichi   = 700,
		Dokumori_Ni	 = 702,
		Dokumori_San	= 704,
		Tonko_Ichi	  = 706,
		Tonko_Ni		= 708,
		Tonko_San	   = 710,
		Paralyga		= 712,
		Slowga		  = 714,
		Hastega		 = 716,
		Silencega	   = 718,
		Dispelga		= 720,
		Blindga		 = 722,
		Bindga		  = 724,
		Sleepga		 = 726,
		SleepgaII	   = 728,
		Breakga		 = 730,
		Graviga		 = 732,
		Death		   = 734,
		
		Foe_Requiem		 = 736,
		Foe_Requiem_II	  = 738,
		Foe_Requiem_III	 = 740,
		Foe_Requiem_IV	  = 742,
		Foe_Requiem_V	   = 744,
		Foe_Requiem_VI	  = 746,
		Foe_Requiem_VII	 = 748,
		Foe_Requiem_VIII	= 750,
		Horde_Lullaby	   = 752,
		Horde_Lullaby_II	= 754,
		Armys_Paeon		 = 756,
		Armys_Paeon_II	  = 758,
		Armys_Paeon_III	 = 760,
		Armys_Paeon_IV	  = 762,
		Armys_Paeon_V	   = 764,
		Armys_Paeon_VI	  = 766,
		Armys_Paeon_VII	 = 768,
		Armys_Paeon_VIII	= 770,
		Mages_Ballad		= 772,
		Mages_Ballad_II	 = 774,
		Mages_Ballad_III	= 776,
		Knights_Minne	   = 778,
		Knights_Minne_II	= 780,
		Knights_Minne_III   = 782,
		Knights_Minne_IV	= 784,
		Knights_Minne_V	 = 786,
		Valor_Minuet		= 788,
		Valor_Minuet_II	 = 790,
		Valor_Minuet_III	= 792,
		Valor_Minuet_IV	 = 794,
		Valor_Minuet_V	  = 796,
		Sword_Madrigal	  = 798,
		Blade_Madrigal	   = 800,
		Hunters_Prelude	  = 802,
		Archers_Prelude	  = 804,
		Sheepfoe_Mambo	   = 806,
		Dragonfoe_Mambo	  = 808,
		Fowl_Aubade		  = 810,
		Herb_Pastoral		= 812,
		Chocobo_Hum		  = 814,
		Shining_Fantasia	 = 816,
		Scops_Operetta	   = 818,
		Puppets_Operetta	 = 820,
		Travelers_Operetta   = 822,
		Gold_Cappricio	   = 824,
		Gift_Serenade		= 826,
		Warding_Round		= 828,
		Goblin_Gavotte	   = 830,
		Sabotender_Fugue	 = 832,
		Mogs_Rhapsody		= 834,
		Passionate_Aria	  = 836,
		Advancing_March	  = 838,
		Victory_March		= 840,
		Battlefield_Elegy	= 842,
		Carnage_Elegy		= 844,
		Massacre_Elegy	   = 846,
		Sinewy_Etude		 = 848,
		Dextrous_Etude	   = 850,
		Vivacious_Etude	  = 852,
		Quick_Etude		  = 854,
		Learned_Etude		= 856,
		Spirited_Etude	   = 858,
		Enchanting_Etude	 = 860,
		Herculean_Etude	  = 862,
		Uncanny_Etude		= 864,
		Vital_Etude		  = 866,
		Swift_Etude		  = 868,
		Sage_Etude		   = 870,
		Logical_Etude		= 872,
		Bewitching_Etude	 = 874,
		Fire_Carol		   = 876,
		Ice_Carol			= 878,
		Wind_Carol		   = 880,
		Earth_Carol		  = 882,
		Lightning_Carol	  = 884,
		Water_Carol		  = 886,
		Light_Carol		  = 888,
		Dark_Carol		   = 890,
		Fire_Carol_II		= 892,
		Ice_Carol_II		 = 894,
		Wind_Carol_II		= 896,
		Earth_Carol_II	   = 898,
		Lightning_Carol_II   = 900,
		Water_Carol_II	   = 902,
		Light_Carol_II	   = 904,
		Dark_Carol_II		= 906,
		Fire_Threnody		= 908,
		Ice_Threnody		 = 910,
		Wind_Threnody		= 912,
		Earth_Threnody	   = 914,
		Lightning_Threnody   = 916,
		Water_Threnody	   = 918,
		Light_Threnody	   = 920,
		Dark_Threnody		= 922,
		Magic_Finale		 = 924,
		Foe_Lullaby		  = 926,
		Goddesss_Hymnus	  = 928,
		Chocobo_Mazurka	  = 930,
		Maidens_Virelai	  = 932,
		Awful_Eye			= 934,
		Battle_Dance		 = 936,
		Blastbomb			= 938,
		Blitzstrahl		  = 940,
		Blood_Drain		  = 942,
		Bludgeon			 = 944,
		Bomb_Toss			= 946,
		Chaotic_Eye		  = 948,
		Claw_Cyclone		 = 950,
		Cocoon			   = 952,
		Cold_Wave			= 954,
		Cursed_Sphere		= 956,
		Death_Ray			= 958,
		Death_Scissors	   = 960,
		Feather_Storm		= 962,
		Foot_Kick			= 964,
		Frenetic_Rip		 = 966,
		Frightful_Roar	   = 968,
		Frost_Breath		 = 970,
		Frypan			   = 972,
		Grand_Slam		   = 974,
		Head_Butt			= 976,
		Healing_Breeze	   = 978,
		Helldive			 = 980,
		Hydro_Shot		   = 982,
		Hysteric_Barrage	 = 984,
		Ice_Break			= 986,
		Jet_Stream		   = 988,
		Magic_Fruit		  = 990,
		Mandibular_Bite	  = 992,
		Metalic_Body		 = 994,
		MP_Drainkiss		 = 996,
		Pinecone_Bomb		= 998,
		Poison_Breath	 = 1000,
		Pollen			= 1002,
		Power_Attack	  = 1004,
		Queasyshroom	  = 1006,
		Refueling		 = 1008,
		Sandspin		  = 1010,
		Screwdriver	   = 1012,
		Sickle_Slash	  = 1014,
		Smite_of_Rage	 = 1016,
		Soporific		 = 1018,
		Sound_Blast	   = 1020,
		Spinal_Cleave	 = 1022,
		Sprout_Smack	  = 1024,
		Stinking_Gas	  = 1026,
		Tail_Slap		 = 1028,
		Uppercut		  = 1030,
		Venom_Shell	   = 1032,
		Voracious_Trunk   = 1034,
		Warm_Up		   = 1036,
		Wild_Oats		 = 1038,
		Magic_Hammer	  = 1040,
		Exuviation		= 1042

	} // @ public enum SpellList : short

	#endregion

	#region AbilityList

	/// <summary>
	/// Ability List
	/// </summary>
	public enum AbilityList : byte
	{
		Two_Hour = 0,
		Berserk = 1,
		Warcry = 2,
		Defender = 3,
		Aggressor = 4,
		Provoke = 5,
		Warriors_Charge = 6,
		Tomahawk = 7,
		Retaliation = 8,
		Focus = 13,
		Dodge = 14,
		Chakra = 15,
		Boost = 16,
		Counterstance = 17,
		Chi_Blast = 18,
		Mantra = 19,
		Formless = 20,
		Divine_Seal = 26,
		Martyr = 27,
		Devotion = 28,
		Afflatus_Solace = 29,
		Afflatus_Misery = 30,
		Elemental_Seal = 38,
		Convert = 49,
		Composure = 50,
		Steal = 61,
		Flee = 62,
		Hide = 63,
		Sneak_Attack = 64,
		Mug = 65,
		Trick_Attack = 66,
		Assassins_Charge = 67,
		Feint = 68,
		Accomplice = 69,
		Shield_Bash = 73,
		Holy_Circle = 74,
		Sentinel = 75,
		Cover = 76,
		Rampart = 77,
		Fealty = 78,
		Chivalry = 79,
		Souleater = 85,
		Arcane_Circle = 86,
		Last_Resort = 87,
		Weapon_Bash = 88,
		Dark_Seal = 89,
		Diabolic_Eye = 90,
		Charm = 97,
		Gauge = 98,
		Tame = 99,
		Fight = 100,
		Stay_Heel_Leave = 101,
		Sic = 102,
		Reward = 103,
		Call_Beast = 104,
		Feral_Howl = 105,
		Snarl = 107,
		Killer_Instinct = 108,
		Nightingale = 109,
		Troubadour = 110,
		Scavenge = 121,
		Shadowbind = 122,
		Camouflage = 123,
		Sharpshot = 124,
		Barrage = 125,
		Unlimited_Shot = 126,
		Stealth_Shot = 127,
		Flashy_Shot = 128,
		Velocity_Shot = 129,
		Third_Eye_3 = 133,
		Meditate = 134,
		Warding_Circle = 135,
		Shikikoyo = 136,
		Blade_Bash = 137,
		Hasso = 138,
		Seigan = 139,
		Sekkanoki = 140,
		Sange = 145,
		Ancient_Circle = 157,
		Jump = 158,
		High_Jump = 159,
		Super_Jump = 160,
		Dismiss = 161,
		Spirit_Link = 162,
		Call_Wyvern = 163,
		Deep_Breathing = 164,
		Angon = 165,
		Assault = 170,
		Retreat = 171,
		Release = 172,
		Blood_Pact_Rage = 173,
		Blood_Pact_Ward = 174,
		Elemental_Siphon = 175,
		Chain_Affinity = 181,
		Burst_Affinity = 182,
		Convergence = 183,
		Diffusion  = 184,
		Roll = 193,
		Double_Up = 194,
		Shot = 195,
		Random_Deal = 196,
		Snake_Eye = 197,
		Fold_Passen = 198,
		Activate = 205,
		Repair = 206,
		Deploy = 207,
		Deactivate = 208,
		Retrieve = 209,
		Maneuver = 210,
		Role_Reversal = 211,
		Ventriloquy = 212,
		Sambas = 216,
		Waltzes = 217,
		Jigs = 218,
		Steps = 220,
		Flourishes_I = 221,
		Flourishes_II = 222,
		Light_Arts = 228,
		Modus = 230,
		Stratagems = 231,
		Dark_Arts = 232,
		Sublimation = 234,
		Weaponskill = 900

	} // @ public enum AbilityList : byte

	#endregion

	#region Treasure

	/// <summary>
	/// Status of the item in the treasure pool
	/// </summary>
	public enum TreasureStatus : byte
	{
		NoAction = 0,
		Pass = 1,
		Lot = 2

	} // @ public enum TreasureStatus

	#endregion

	#region Player related

	/// <summary>
	/// Craft types
	/// </summary>
	public enum Craft : byte
	{
		Alchemy,
		Bonecrafting,
		Clothcraft,
		Cooking,
		Fishing,
		Goldsmithing,
		Leathercraft,
		Smithing,
		Woodworking

	} // @ public enum Craft : byte

	/// <summary>
	/// Magic skill types
	/// </summary>
	public enum MagicSkill : byte
	{
		BlueMagic,
		Dark,
		Divine,
		Enfeebling,
		Enhancing,
		Elemental,
		Healing,
		Ninjitsu,
		Singing,
		String,
		Summoning,
		Wind

	} // @ public enum MagicSkill : byte

	/// <summary>
	/// Combat skill types
	/// </summary>
	public enum CombatSkill : byte
	{
		HandToHand,
		Dagger,
		Sword,
		GreatSword,
		Axe,
		GreatAxe,
		Scythe,
		Polearm,
		Katana,
		GreatKatana,
		Club,
		Staff,
		Archery,
		Marksmanship,
		Throwing,
		Guarding,
		Evasion,
		Shield,
		Parrying

	} // @ public enum CombatSkill : byte

	/// <summary>
	/// Equipment Slot
	/// </summary>
	public enum EquipSlot : short
	{
		Main = 0,
		Shield = 1,
		Range = 2,
		Ammo = 3,
		Head = 4,
		Body = 5,
		Hands = 6,
		Legs = 7,
		Feet = 8,
		Neck = 9,
		Waist = 10,
		EarLeft = 11,
		EarRight = 12,
		RingLeft = 13,
		RingRight = 14,
		Back = 15

	} // @ public enum EquipSlot : short

	/// <summary>
	/// Alignment in which the fishing rod can be in
	/// </summary>
	public enum RodAlign : byte
	{
		Err = 0,
		Center = 1,
		Left = 2,
		Right = 3

	} // @ public enum RodAlign : byte

	/// <summary>
	/// View mode the player is in
	/// </summary>
	public enum ViewMode : byte
	{
		ThirdPerson,
		FirstPerson

	} // @ public enum ViewMode : byte

	/// <summary>
	/// Nation person is in
	/// </summary>
	public enum Nation : byte
	{
		SandOria,
		Bastok,
		Windurst

	} // @ public enum Nation : byte

	#endregion

	#region Timer Related

	/// <summary>
	/// The different moon phases
	/// </summary>
	public enum MoonPhase : byte
	{
		New,
		WaxingCrescent,
		WaxingCrescent2,
		FirstQuarter,
		WaxingGibbous,
		WaxingGibbous2,
		Full,
		WaningGibbous,
		WaningGibbous2,
		LastQuarter,
		WaningCrescent,
		WaningCrescent2

	} // @ public enum MoonPhase

	/// <summary>
	/// Names of the days of the week
	/// </summary>
	public enum Weekday
	{
		Firesday,
		Earthsday,
		Watersday,
		Windsday,
		Iceday,
		Lightningday,
		Lightsday,
		Darksday

	} // @ public enum Weekday

	#endregion

	#region KeyCodes

	/// <summary>
	/// Key Code sent to windower
	/// </summary>
	public enum KeyCode
	{
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		//~~~~~~~~~These Here Are The Most Important FFXI Keys~~~~~~~~~
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		EscapeKey = 1,

		EnterKey = 28,
		TabKey = 15,

		UpArrow = 200,
		LeftArrow = 203,
		RightArrow = 205,
		DownArrow = 208,
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		//~~~~~~~These Here Are The NumPad Keys On Your Keyboard~~~~~~~
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		MainNumlockKey = 69,

		NP_Number0 = 82,
		NP_Number1 = 79,
		NP_Number2 = 80,
		NP_Number3 = 81,
		NP_Number4 = 75,
		NP_Number5 = 76,
		NP_Number6 = 77,
		NP_Number7 = 71,
		NP_Number8 = 72,
		NP_Number9 = 73,

		NP_Forwardslash = 181,
		NP_MultiplyKey = 55,
		NP_MinusKey = 74,
		NP_AdditionKey = 78,
		NP_EnterKey = 156,
		NP_PeriodKey = 83,
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		//~~~These Here Are The Letters From A to Z On Your Keyboard~~~
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		LetterA = 30,
		LetterB = 48,
		LetterC = 46,
		LetterD = 32,
		LetterE = 18,
		LetterF = 33,
		LetterG = 34,
		LetterH = 35,
		LetterI = 23,
		LetterJ = 36,
		LetterK = 37,
		LetterL = 38,
		LetterM = 50,
		LetterN = 49,
		LetterO = 24,
		LetterP = 25,
		LetterQ = 16,
		LetterR = 19,
		LetterS = 31,
		LetterT = 20,
		LetterU = 22,
		LetterV = 47,
		LetterW = 17,
		LetterX = 45,
		LetterY = 21,
		LetterZ = 44,
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		//~~~These Here Are The Numbers From 0 to 9 On Your Keyboard~~~
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		Number1 = 2,
		Number2 = 3,
		Number3 = 4,
		Number4 = 5,
		Number5 = 6,
		Number6 = 7,
		Number7 = 8,
		Number8 = 9,
		Number9 = 10,
		Number0 = 11,
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		//~~These Here Are The F Keys From F1 to F12 On Your Keyboard~~
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		F1Key = 59,
		F2Key = 60,
		F3Key = 61,
		F4Key = 62,
		F5Key = 63,
		F6Key = 64,
		F7Key = 65,
		F8Key = 66,
		F9Key = 67,
		F10Key = 68,
		F11Key = 87,
		F12Key = 88,

		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		//~~~~These Here Are Ones That You Should Not Need But Here~~~~
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		MinusKey = 12,
		EqualsKey = 13,
		BackspaceKey = 14,
		LeftBracket = 26,
		RightBracket = 27,
		LeftCtrlKey = 29,
		Semicolon = 39,
		Apostrophe = 40,
		Accentgrave = 41,
		LeftShift = 42,
		Backslash = 43,
		CommaKey = 51,
		PeriodKey = 52,
		ForwardslashKEy = 53,
		RightShift = 54,
		ScrollLock = 70,
		LeftAltKey = 56,
		Spacebar = 57,
		CapsLock = 58,
		RightControlKey = 157,
		RightAltKey = 184,
		InsertKey = 210,
		DeleteKey = 211,
		LeftWindowKey = 219,
		RightWindowKey = 220
		
		//Calculator = &HA1
		//MuteKey = &HA0
		//PlayNPauseKey = &HA2
		//StopMedia = &HA
		//VolumeDown = &HAE
		//VolumeUp = &HB0
		//NextMediaTrack = &HED
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	}

	#endregion

	#region NPC

	/// <summary>
	/// Type of NPC returned from GetNPCType
	/// </summary>
	public enum NPCType : byte
	{
		Player,
		NPC,
		Mob,
		InadamentObject

	} // @ public enum NPCType

	#endregion
}
