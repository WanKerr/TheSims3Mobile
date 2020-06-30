// Decompiled with JetBrains decompiler
// Type: SimData
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;
using System;

public class SimData
{
    public static readonly int[] DAY_FLAGS = new int[7]
    {
    4,
    8,
    16,
    32,
    64,
    128,
    256
    };
    public static readonly int[] DAY_STRINGS = new int[7]
    {
    982,
    983,
    984,
    985,
    986,
    987,
    988
    };
    public static readonly int[] PERK_FLAGS = new int[2]
    {
    1,
    2
    };
    public static readonly int[] PERK_STRINGS = new int[2]
    {
    994,
    995
    };
    public static readonly short[] MOODDESC_STRINGS = new short[12]
    {
    (short) 564,
    (short) 565,
    (short) 566,
    (short) 567,
    (short) 568,
    (short) 569,
    (short) 570,
    (short) 571,
    (short) 572,
    (short) 573,
    (short) 574,
    (short) 575
    };
    public static readonly short[] RESPONSE_ANIMS = new short[7]
    {
    (short) 3,
    (short) 2,
    (short) 1,
    (short) 9,
    (short) 4,
    (short) 5,
    (short) 6
    };
    public static readonly short[] SPEECHICONS = new short[114]
    {
    (short) 460,
    (short) -1,
    (short) 461,
    (short) -1,
    (short) 462,
    (short) -1,
    (short) 463,
    (short) -1,
    (short) 464,
    (short) -1,
    (short) 465,
    (short) -1,
    (short) 466,
    (short) -1,
    (short) 468,
    (short) -1,
    (short) 469,
    (short) -1,
    (short) 470,
    (short) -1,
    (short) 471,
    (short) -1,
    (short) 472,
    (short) -1,
    (short) 473,
    (short) -1,
    (short) 474,
    (short) -1,
    (short) 476,
    (short) -1,
    (short) 477,
    (short) -1,
    (short) 478,
    (short) -1,
    (short) 479,
    (short) -1,
    (short) 480,
    (short) -1,
    (short) 481,
    (short) -1,
    (short) 482,
    (short) -1,
    (short) 484,
    (short) -1,
    (short) 485,
    (short) -1,
    (short) 486,
    (short) -1,
    (short) 487,
    (short) -1,
    (short) 488,
    (short) -1,
    (short) 489,
    (short) -1,
    (short) 490,
    (short) -1,
    (short) 492,
    (short) -1,
    (short) 493,
    (short) -1,
    (short) 494,
    (short) -1,
    (short) 495,
    (short) -1,
    (short) 496,
    (short) -1,
    (short) 497,
    (short) -1,
    (short) 498,
    (short) -1,
    (short) 501,
    (short) -1,
    (short) 502,
    (short) -1,
    (short) 503,
    (short) -1,
    (short) 504,
    (short) -1,
    (short) 505,
    (short) -1,
    (short) 506,
    (short) -1,
    (short) 507,
    (short) -1,
    (short) 509,
    (short) -1,
    (short) 510,
    (short) -1,
    (short) 511,
    (short) -1,
    (short) 512,
    (short) -1,
    (short) 513,
    (short) -1,
    (short) 514,
    (short) -1,
    (short) 515,
    (short) -1,
    (short) 516,
    (short) -1,
    (short) 517,
    (short) -1,
    (short) 518,
    (short) -1,
    (short) 519,
    (short) -1,
    (short) 520,
    (short) -1,
    (short) 521,
    (short) -1,
    (short) 522,
    (short) -1,
    (short) 523,
    (short) -1
    };
    public const int NONE = -1;
    public const int GAME_TIME_RATIO = 1000;
    public const int GAME_TIME_START = 480;
    public const int GAME_TIME_1HOUR = 60;
    public const int GAME_TIME_1DAY = 1440;
    public const int GAME_TIME_1WEEK = 10080;
    public const int TIME_FAST_SHIFT = 4;
    public const int TIME_FAST_FACTOR = 16;
    public const int TIME_OBJECTS_FAST_SHIFT = 2;
    public const int TIME_OBJECTS_FAST_FACTOR = 4;
    private const int GAME_TIME_LONGSLEEPSTART = 1320;
    private const int GAME_TIME_LONGSLEEPEND = 360;
    public const int FULL_SLEEP_TIME = 600;
    public const int NAP_TIME = 120;
    public const int SLEEPCURTAIN_MIN_TIME = 60;
    public const int SLEEPCURTAIN_MARGIN_TIME = 15;
    public const int SKILLLEVEL_LOWEST = 0;
    public const int SKILLLEVEL_HIGHEST = 327680;
    public const int SKILLLEVEL_RANKSIZE = 65536;
    public const int SKILLRANK_MAX = 5;
    public const int SKILLRANKNAME_MAX = 6;
    private const int SKILLLEVEL_CHECK_LOW = 65536;
    private const int SKILLLEVEL_CHECK_HIGH = 196608;
    private const int CAREER_PRESTART_WARNING_TIME = 30;
    private const int CAREER_PRESTART_WAKE_TIME = 60;
    private const int CAREER_PRESTART_SLEEP_TIME = 660;
    private const int CAREER_START_TIME_MARGIN = 60;
    private const int CAREER_PHONE_CHANGE = 1440000;
    private const int DAYS_MISSED_FIRED = 3;
    private const int DAYS_WORKED_MAKEUP = 3;
    private const int DAYS_WORKED_AUTOPROMOTION = 10;
    public const int TIMEFLAG_JOB_NEARSTART = 1;
    public const int TIMEFLAG_JOB_START = 2;
    public const int TIMEFLAG_JOB_WORK = 4;
    public const int TIMEFLAG_JOB_OFF = 8;
    public const int TIMEFLAG_SLEEP = 16;
    private const int ALL_PERSONA_ACTIONFLAGS = 33554432;
    public const int PROMISE_SLOTS = 4;
    public const int DREAM_RANDOM_TIME = 120000;
    public const int DREAM_START_TIME = 5000;
    public const int DREAM_EXPIRE_TIME = 240000;
    private const int DREAM_ACCUMULATESIMOLEANS_CASH = 1000;
    private const int DREAM_MATERIALISTIC_SIMOLEANS_CASH = 5000;
    public const int ACHIEVEMENT_PERSONACOMPLETE = 1;
    public const int ACHIEVEMENT_PERSONACOMPLETE_SHOWN = 2;
    public const int ACHIEVEMENT_FISHING = 4;
    public const int ACHIEVEMENT_COOKING = 8;
    public const int ACHIEVEMENT_HOUSEUPGRADE1_MSG = 16;
    public const int ACHIEVEMENT_HOUSEUPGRADE2_MSG = 32;
    public const int ACHIEVEMENT_INSULTED = 64;
    public const int ACHIEVEMENT_ANNOYED = 128;
    public const int ACHIEVEMENT_SLAPPED = 256;
    private const int FATAL_WOOHOOS = 10;
    public const int MOTIVELEVEL_HIGHEST = 6553600;
    public const int MOTIVELEVEL_LOW_RANGE = 2293760;
    public const int MOTIVELEVEL_HIGH_RANGE = 4259840;
    public const int BUFF_MAX_ACTIVE = 6;
    public const int MOODLEVEL_NEG_HIGH = -3276800;
    public const int MOODLEVEL_NEUTRAL_SIZE = 655360;
    public const int MOODLEVEL_POS_MEDIUM = 2621440;
    public const int MOODLEVEL_POS_HIGH = 4915200;
    public const int MOODLEVEL_BEGIN = 1638400;
    public const int MOODLEVEL_LOWEST = -6553600;
    public const int MOODLEVEL_HIGHEST = 6553600;
    public const int MOODDESC_ELATED = 0;
    public const int MOODDESC_VERYHAPPY = 1;
    public const int MOODDESC_HAPPY = 2;
    public const int MOODDESC_FAIR = 3;
    public const int MOODDESC_SAD = 4;
    public const int MOODDESC_DEPRESSED = 5;
    public const int MOODDESC_TENSE = 6;
    public const int MOODDESC_STRESSED = 7;
    public const int MOODDESC_UNCOMFORTABLE = 8;
    public const int MOODDESC_MISERABLE = 9;
    public const int MOODDESC_ANGRY = 10;
    public const int MOODDESC_FURIOUS = 11;
    private const int MAX_COMMODITY_LEVEL = 13107200;
    public const int RELLEVEL_FRIENDSHIP_LOWEST = -1966080;
    public const int RELLEVEL_ROMANCE_LOWEST = -327680;
    public const int RELLEVEL_HIGHEST = 1966080;
    public const int CURRELFLAG_GREETED = 1;
    public const int CURRELFLAG_HOUSEMATE = 2;
    public const int CURRELFLAG_TOILETED = 4;
    public const int CURRELFLAG_SHOWERED = 8;
    public const int CURRELFLAG_TRASHED = 16;
    public const int CURRELFLAG_SLAPPED = 32;
    public const int CURRELFLAG_INSULTED = 64;
    public const int CURRELFLAG_CREEPED = 128;
    public const int CURRELFLAG_WATCHEDSLEEP = 256;
    public const int CURRELFLAG_BEDSLEPT_1 = 512;
    public const int CURRELFLAG_BEDSLEPT_2 = 1024;
    public const int CURRELFLAG_QUEST_SLAP = 2048;
    public const int CURRELFLAG_QUEST_TRASHED = 4096;
    public const int CURRELFLAG_QUEST_LAUGH = 8192;
    public const int CURRELFLAG_QUEST_ANNOY = 16384;
    public const int CURRELFLAG_KISSED = 32768;
    public const int CURRELFLAG_QUEST_HUG = 65536;
    private const int COMMODITY_DECAY_RATE = 3000;
    private const int COMMODITY_DECAY_AMOUNT = 327680;
    private const int COMMODITY_DECAY_OTHERS = 655360;
    private const int MAX_ACTION_HISTORY = 10;
    private const int DISCOVER_TRAIT_COUNT = 3;
    private const int MAX_LAST_NPC_TIMER = 10000;
    public const int RESPONSEFLAG_NEG3 = 0;
    public const int RESPONSEFLAG_NEG2 = 1;
    public const int RESPONSEFLAG_NEG1 = 2;
    public const int RESPONSEFLAG_NEUTRAL = 3;
    public const int RESPONSEFLAG_POS1 = 4;
    public const int RESPONSEFLAG_POS2 = 5;
    public const int RESPONSEFLAG_POS3 = 6;
    public const int RESPONSE_CODE_MASK = 15;
    public const int RESPONSEFLAG_POSITIVE = 16;
    public const int RESPONSEFLAG_NEGATIVE = 32;
    public const int RESPONSEFLAG_ROMANTIC = 64;
    public const int RESPONSE_FLAGS = 0;
    public const int RESPONSE_ACTION = 1;
    public const int RESPONSE_EFFECTANIM = 2;
    public const int RESPONSE_SIZE = 3;
    private const int EFFECT_NONE = -1;
    private const int SPEECH_GENERIC = 1;
    private const int SPEECH_NULL = 2;
    private const int SPEECH_FOOD = 4;
    private const int SPEECH_MOVE = 8;
    private const int SPEECH_INSULT = 16;
    private const int SPEECH_FUNNY = 32;
    private const int SPEECH_BED = 64;
    private const int SPEECH_FISH = 128;
    private const int SPEECH_FURNITURE = 256;
    private const int SPEECH_PLANT = 512;
    private const int SPEECH_TRASHCAN = 1024;
    private const int SPEECH_ALL = -1;
    public const int CCOUTCOME_YES1 = 0;
    public const int CCOUTCOME_YES2 = 1;
    public const int CCOUTCOME_NO1 = 2;
    public const int CCOUTCOME_NO2 = 3;
    public const int PLAYER_TRAITS = 5;
    private const int MAX_OBJECT_RECORDS = 100;
    public const int IMPORT_SUCCESS = 0;
    public const int IMPORT_INVALID_DATA = 1;
    public const int IMPORT_INVALID_DEVICE = 2;
    public const int IMPORT_DLC_NEEDED = 3;
    private AppEngine m_engine;
    private short[] d_skillDescStrings;
    private int[][] d_skillRates;
    private short[][] d_skillLevelDescStrings;
    private short[] d_careerDescStrings;
    private short[] d_careerIcons;
    private short[] d_careerRabbitHoles;
    private sbyte[] d_careerBosses;
    private short[] d_careerFreakDeath1s;
    private short[] d_careerFreakDeath2s;
    private short[] d_careerRaiseFail;
    private short[][] d_careerLevelDescStrings;
    private short[][] d_careerLevelIncomes;
    private short[][] d_careerLevelFlags;
    private short[][] d_careerLevelHoursStarts;
    private short[][] d_careerLevelHoursEnds;
    private sbyte[][][] d_careerLevelRequirements;
    private short[] d_personaDescStrings;
    private short[] d_personaLongDescStrings;
    private short[] d_personaFlags;
    private short[] d_dreamDescStrings;
    private short[] d_dreamFlags;
    private int d_motiveCount;
    private short[] d_motiveDescStrings;
    private int[] d_motiveStartLevel;
    private int[] d_motiveDecayRate;
    private short[] d_motiveTriggersNeeds;
    private int[] d_motiveTriggersNeedLevels;
    private short[] d_motiveAnimHighs;
    private short[] d_motiveAnimMids;
    private short[] d_motiveAnimLows;
    private sbyte[] d_timeRangeDreams;
    private int d_buffCount;
    private short[] d_buffDescStringIds;
    private int[] d_buffTimeouts;
    private sbyte[] d_buffTimeoutChains;
    private sbyte[] d_buffTimes;
    private sbyte[] d_buffFlags;
    private sbyte[][] d_buffTriggerMotives;
    private int[][] d_buffTriggerMotiveLevels;
    private sbyte[][] d_buffEffectMood;
    private sbyte[][] d_buffEffectMoodAmount;
    private sbyte[][] d_buffEffectMotive;
    private int[][] d_buffEffectMotiveFactors;
    private short[] d_traitDescStrings;
    private short[] d_traitExcludes;
    private int d_numRelLevels;
    private short[] d_relStateDescStrings;
    private sbyte[] d_relStateFlags;
    private short[] d_relStateEffectAnims;
    private short[] d_relStateToStrings;
    private sbyte[][] d_relStateTriggerToStates;
    private sbyte[][] d_relStateTriggerLevels;
    private short[][] d_relStateTriggerLevelValues;
    private int d_numSims;
    private short[] d_simNameStrings;
    private short[] d_simPortraitAnims;
    private sbyte[] d_simMacromapColors;
    private int[][] d_simAttributes;
    private short[] d_simHomes;
    private sbyte[] d_simFlags;
    private sbyte[] d_simPartners;
    private sbyte[] d_simCareers;
    private sbyte[] d_simCareerLevels;
    private sbyte[][] d_simTraits;
    private sbyte[][] d_simQuests;
    private short[] d_commodityStringIds;
    private int d_numActions;
    private short[] d_actionStringIds;
    private short[] d_actionGroupStringIds;
    private int[] d_actionFlags;
    private short[] d_actionWorldArgs;
    private sbyte[][] d_actionConditionCommodities;
    private sbyte[][] d_actionConditionTraits;
    private int[][] d_actionConditionRelStates;
    private int[][] d_actionEffectFlags;
    private sbyte[][] d_actionAffectFriendships;
    private sbyte[][] d_actionAffectRomances;
    private sbyte[][] d_actionAffectCommodities;
    private sbyte[][] d_actionAffectCommodityAmounts;
    private short[][] d_actionResponseActions;
    private sbyte[][] d_actionPhases;
    private short[] d_chanceCardPrompts;
    private sbyte[] d_chanceCardYesPercents;
    private sbyte[] d_chanceCardNoPercents;
    private sbyte[] d_chanceCardResultYes1s;
    private short[] d_chanceCardResultYes1Strings;
    private sbyte[] d_chanceCardResultYes2s;
    private short[] d_chanceCardResultYes2Strings;
    private sbyte[] d_chanceCardResultNo1s;
    private short[] d_chanceCardResultNo1Strings;
    private sbyte[] d_chanceCardResultNo2s;
    private short[] d_chanceCardResultNo2Strings;
    private sbyte[] d_questFlags;
    private short[] d_questPrompts;
    private short[] d_questMessages;
    private short[] d_questFinishActions;
    private short[] d_questGiveItem;
    private short[] d_questRewardCash;
    private short[][] d_questTriggerActions;
    private byte m_soldSomething;
    private byte m_fishCaughtToday;
    private int[] m_woohooSimsToday;
    private int m_timeTimer;
    private int m_timeTotal;
    private int m_money;
    private int m_moneySpent;
    private bool m_fastForward;
    private sbyte m_furnitureStage;
    private short m_houseUpgradeDay;
    private int m_activeRecipe;
    private int[] m_skillLevelsF;
    private sbyte m_careerAcceptDay;
    private short m_careerDaysWorked;
    private short m_careerDaysMissed;
    private sbyte[] m_careerLevelsAttained;
    private sbyte m_phoneCareer;
    private int m_phoneCareerTimer;
    private sbyte m_persona;
    private sbyte m_dream;
    private short m_dreamLGCSeed;
    private int m_dreamTimer;
    private sbyte[] m_promises;
    private int m_personaGoalsCompleted;
    private int m_achievements;
    private int[] m_timeRanges;
    private short m_dreamFishCount;
    private short m_dreamHarvestCount;
    private int[] m_woohooTimes;
    private int m_quickLinkFlags;
    private int m_motiveTimer;
    private int[] m_motiveLevelsF;
    private int[] m_motiveDecaysF;
    private int[] m_motiveDecayFactorsF;
    private int[] m_motiveDecayAdjustsF;
    private short[] m_buffsActive;
    private int[] m_buffTimers;
    private int[] m_moodLevelsF;
    private int m_moodDesc;
    private int m_moodLevel;
    private sbyte[] m_currentRelStates;
    private short[] m_currentRelStateFlags;
    private int[][] m_currentRelLevelsF;
    private int[][] m_commodityLevelsF;
    private short[][] m_actionHistories;
    private sbyte[][] m_knownTraits;
    private int m_commodityTimer;
    private int m_lastNPC;
    private int m_lastNPCTimer;
    private short[] m_unlockedActionPackIds;
    private sbyte[] m_questSims;
    private int[] m_questTimes;
    private int m_timeoutDelay;
    private short[] m_objectStateIds;
    private int[] m_objectStateValues;
    private int[] m_objectStateTimes;

    public int DemoTime { get; set; }

    public bool[] LiveAchievementAwarded { get; set; }

    public TimeSpan totalAppRunTime { get; set; }

    public int mostMoneyEarned { get; set; }

    public int numPurchases { get; set; }

    public int numFriendships { get; set; }

    public int numJobsWorked { get; set; }

    public TimeSpan totalTimeMaintained { get; set; }

    public SimData(AppEngine ae)
    {
        this.m_engine = ae;
        this.d_skillDescStrings = (short[])null;
        this.d_skillRates = (int[][])null;
        this.d_skillLevelDescStrings = (short[][])null;
        this.d_careerDescStrings = (short[])null;
        this.d_careerIcons = (short[])null;
        this.d_careerRabbitHoles = (short[])null;
        this.d_careerBosses = (sbyte[])null;
        this.d_careerFreakDeath1s = (short[])null;
        this.d_careerFreakDeath2s = (short[])null;
        this.d_careerRaiseFail = (short[])null;
        this.d_careerLevelDescStrings = (short[][])null;
        this.d_careerLevelIncomes = (short[][])null;
        this.d_careerLevelFlags = (short[][])null;
        this.d_careerLevelHoursStarts = (short[][])null;
        this.d_careerLevelHoursEnds = (short[][])null;
        this.d_careerLevelRequirements = (sbyte[][][])null;
        this.d_personaDescStrings = (short[])null;
        this.d_personaLongDescStrings = (short[])null;
        this.d_personaFlags = (short[])null;
        this.d_dreamDescStrings = (short[])null;
        this.d_dreamFlags = (short[])null;
        this.d_motiveCount = 0;
        this.d_motiveDescStrings = (short[])null;
        this.d_motiveStartLevel = (int[])null;
        this.d_motiveDecayRate = (int[])null;
        this.d_motiveTriggersNeeds = (short[])null;
        this.d_motiveTriggersNeedLevels = (int[])null;
        this.d_motiveAnimHighs = (short[])null;
        this.d_motiveAnimMids = (short[])null;
        this.d_motiveAnimLows = (short[])null;
        this.d_timeRangeDreams = (sbyte[])null;
        this.d_buffCount = 0;
        this.d_buffDescStringIds = (short[])null;
        this.d_buffTimeouts = (int[])null;
        this.d_buffTimeoutChains = (sbyte[])null;
        this.d_buffTimes = (sbyte[])null;
        this.d_buffFlags = (sbyte[])null;
        this.d_buffTriggerMotives = (sbyte[][])null;
        this.d_buffTriggerMotiveLevels = (int[][])null;
        this.d_buffEffectMood = (sbyte[][])null;
        this.d_buffEffectMoodAmount = (sbyte[][])null;
        this.d_buffEffectMotive = (sbyte[][])null;
        this.d_buffEffectMotiveFactors = (int[][])null;
        this.d_traitDescStrings = (short[])null;
        this.d_traitExcludes = (short[])null;
        this.d_numRelLevels = 0;
        this.d_relStateDescStrings = (short[])null;
        this.d_relStateFlags = (sbyte[])null;
        this.d_relStateEffectAnims = (short[])null;
        this.d_relStateToStrings = (short[])null;
        this.d_relStateTriggerToStates = (sbyte[][])null;
        this.d_relStateTriggerLevels = (sbyte[][])null;
        this.d_relStateTriggerLevelValues = (short[][])null;
        this.d_numSims = 0;
        this.d_simNameStrings = (short[])null;
        this.d_simPortraitAnims = (short[])null;
        this.d_simMacromapColors = (sbyte[])null;
        this.d_simAttributes = (int[][])null;
        this.d_simHomes = (short[])null;
        this.d_simFlags = (sbyte[])null;
        this.d_simPartners = (sbyte[])null;
        this.d_simCareers = (sbyte[])null;
        this.d_simCareerLevels = (sbyte[])null;
        this.d_simTraits = (sbyte[][])null;
        this.d_simQuests = (sbyte[][])null;
        this.d_commodityStringIds = (short[])null;
        this.d_numActions = 0;
        this.d_actionStringIds = (short[])null;
        this.d_actionGroupStringIds = (short[])null;
        this.d_actionFlags = (int[])null;
        this.d_actionWorldArgs = (short[])null;
        this.d_actionConditionCommodities = (sbyte[][])null;
        this.d_actionConditionTraits = (sbyte[][])null;
        this.d_actionConditionRelStates = (int[][])null;
        this.d_actionEffectFlags = (int[][])null;
        this.d_actionAffectFriendships = (sbyte[][])null;
        this.d_actionAffectRomances = (sbyte[][])null;
        this.d_actionAffectCommodities = (sbyte[][])null;
        this.d_actionAffectCommodityAmounts = (sbyte[][])null;
        this.d_actionResponseActions = (short[][])null;
        this.d_actionPhases = (sbyte[][])null;
        this.d_chanceCardPrompts = (short[])null;
        this.d_chanceCardYesPercents = (sbyte[])null;
        this.d_chanceCardNoPercents = (sbyte[])null;
        this.d_chanceCardResultYes1s = (sbyte[])null;
        this.d_chanceCardResultYes1Strings = (short[])null;
        this.d_chanceCardResultYes2s = (sbyte[])null;
        this.d_chanceCardResultYes2Strings = (short[])null;
        this.d_chanceCardResultNo1s = (sbyte[])null;
        this.d_chanceCardResultNo1Strings = (short[])null;
        this.d_chanceCardResultNo2s = (sbyte[])null;
        this.d_chanceCardResultNo2Strings = (short[])null;
        this.d_questFlags = (sbyte[])null;
        this.d_questPrompts = (short[])null;
        this.d_questMessages = (short[])null;
        this.d_questFinishActions = (short[])null;
        this.d_questGiveItem = (short[])null;
        this.d_questRewardCash = (short[])null;
        this.d_questTriggerActions = (short[][])null;
        this.m_timeTimer = 0;
        this.m_timeTotal = 0;
        this.m_money = 0;
        this.m_moneySpent = 0;
        this.m_fastForward = false;
        this.m_furnitureStage = (sbyte)0;
        this.m_houseUpgradeDay = (short)0;
        this.m_activeRecipe = 0;
        this.m_skillLevelsF = (int[])null;
        this.m_careerAcceptDay = (sbyte)0;
        this.m_careerDaysWorked = (short)0;
        this.m_careerDaysMissed = (short)0;
        this.m_careerLevelsAttained = (sbyte[])null;
        this.m_phoneCareer = (sbyte)0;
        this.m_phoneCareerTimer = 0;
        this.m_persona = (sbyte)0;
        this.m_dream = (sbyte)0;
        this.m_dreamLGCSeed = (short)0;
        this.m_dreamTimer = 0;
        this.m_promises = (sbyte[])null;
        this.m_personaGoalsCompleted = 0;
        this.m_achievements = 0;
        this.m_timeRanges = (int[])null;
        this.m_dreamFishCount = (short)0;
        this.m_dreamHarvestCount = (short)0;
        this.m_woohooTimes = (int[])null;
        this.m_quickLinkFlags = 0;
        this.m_motiveTimer = 0;
        this.m_motiveLevelsF = (int[])null;
        this.m_motiveDecaysF = (int[])null;
        this.m_motiveDecayFactorsF = (int[])null;
        this.m_motiveDecayAdjustsF = (int[])null;
        this.m_buffsActive = (short[])null;
        this.m_buffTimers = (int[])null;
        this.m_moodLevelsF = (int[])null;
        this.m_moodDesc = 0;
        this.m_moodLevel = 0;
        this.m_currentRelStates = (sbyte[])null;
        this.m_currentRelStateFlags = (short[])null;
        this.m_currentRelLevelsF = (int[][])null;
        this.m_commodityLevelsF = (int[][])null;
        this.m_actionHistories = (short[][])null;
        this.m_knownTraits = (sbyte[][])null;
        this.m_commodityTimer = 0;
        this.m_lastNPC = 0;
        this.m_lastNPCTimer = 0;
        this.m_unlockedActionPackIds = (short[])null;
        this.m_questSims = (sbyte[])null;
        this.m_questTimes = (int[])null;
        this.m_timeoutDelay = 0;
        this.m_objectStateIds = (short[])null;
        this.m_objectStateValues = (int[])null;
        this.m_objectStateTimes = (int[])null;
        this.m_soldSomething = (byte)0;
        this.m_fishCaughtToday = (byte)0;
        this.LiveAchievementAwarded = new bool[18];
        this.m_woohooSimsToday = new int[10];
        this.DemoTime = 0;
        this.totalAppRunTime = new TimeSpan();
        this.mostMoneyEarned = 0;
        this.numPurchases = 0;
        this.numFriendships = 0;
        this.numJobsWorked = 0;
        this.totalTimeMaintained = new TimeSpan();
        this.initData();
        this.resetRMSGameData();
        this.getSimWorld().resetRMSGameData();
    }

    public void Dispose()
    {
    }

    public SimWorld getSimWorld()
    {
        return this.m_engine.getSimWorld();
    }

    private static short lookupSimsData(DataInputStream dis)
    {
        return GlobalConstants.SIMSDATA_SYMBOL_LOOKUPS[(int)dis.readShort()];
    }

    private void initData()
    {
        AppEngine.getResourceManager();
        DataInputStream dis = new DataInputStream(ResourceManager.loadBinaryFile(180));
        int length1 = (int)dis.readByte();
        short[] numArray1 = new short[length1];
        int[][] numArray2 = new int[length1][];
        short[][] numArray3 = new short[length1][];
        for (int index1 = 0; index1 < length1; ++index1)
        {
            numArray1[index1] = SimData.lookupSimsData(dis);
            AppEngine.ASSERT(true, "invalid SKILL_NUM_RANKS");
            int[] numArray4 = new int[5];
            for (int index2 = 0; index2 < 5; ++index2)
                numArray4[index2] = dis.readInt();
            numArray2[index1] = numArray4;
            short[] numArray5 = new short[6];
            for (int index2 = 0; index2 < 6; ++index2)
                numArray5[index2] = SimData.lookupSimsData(dis);
            numArray3[index1] = numArray5;
        }
        int length2 = (int)dis.readByte();
        short[] numArray6 = new short[length2];
        short[] numArray7 = new short[length2];
        short[] numArray8 = new short[length2];
        sbyte[] numArray9 = new sbyte[length2];
        short[] numArray10 = new short[length2];
        short[] numArray11 = new short[length2];
        short[] numArray12 = new short[length2];
        short[][] numArray13 = new short[length2][];
        short[][] numArray14 = new short[length2][];
        short[][] numArray15 = new short[length2][];
        short[][] numArray16 = new short[length2][];
        short[][] numArray17 = new short[length2][];
        sbyte[][][] numArray18 = new sbyte[length2][][];
        for (int index1 = 0; index1 < length2; ++index1)
        {
            numArray6[index1] = SimData.lookupSimsData(dis);
            numArray7[index1] = SimData.lookupSimsData(dis);
            numArray8[index1] = SimData.lookupSimsData(dis);
            numArray9[index1] = dis.readByte();
            numArray10[index1] = SimData.lookupSimsData(dis);
            numArray11[index1] = SimData.lookupSimsData(dis);
            numArray12[index1] = SimData.lookupSimsData(dis);
            int length3 = (int)dis.readByte();
            short[] numArray4 = new short[length3];
            short[] numArray5 = new short[length3];
            short[] numArray19 = new short[length3];
            short[] numArray20 = new short[length3];
            short[] numArray21 = new short[length3];
            sbyte[][] numArray22 = new sbyte[length3][];
            for (int index2 = 0; index2 < length3; ++index2)
            {
                numArray4[index2] = SimData.lookupSimsData(dis);
                numArray5[index2] = dis.readShort();
                numArray19[index2] = dis.readShort();
                int num1 = (int)dis.readShort();
                int num2 = (int)dis.readShort();
                int num3 = num1 % 100 + num1 / 100 * 60;
                int num4 = num2 % 100 + num2 / 100 * 60;
                numArray20[index2] = (short)num3;
                numArray21[index2] = (short)num4;
                sbyte[] numArray23 = new sbyte[4]
                {
          dis.readByte(),
          dis.readByte(),
          dis.readByte(),
          dis.readByte()
                };
                numArray22[index2] = numArray23;
            }
            numArray13[index1] = numArray4;
            numArray14[index1] = numArray5;
            numArray15[index1] = numArray19;
            numArray16[index1] = numArray20;
            numArray17[index1] = numArray21;
            numArray18[index1] = numArray22;
        }
        int length4 = (int)dis.readByte();
        short[] numArray24 = new short[length4];
        short[] numArray25 = new short[length4];
        short[] numArray26 = new short[length4];
        for (int index = 0; index < length4; ++index)
        {
            numArray24[index] = SimData.lookupSimsData(dis);
            numArray25[index] = SimData.lookupSimsData(dis);
            numArray26[index] = dis.readShort();
        }
        int length5 = (int)dis.readByte();
        short[] numArray27 = new short[length5];
        short[] numArray28 = new short[length5];
        for (int index = 0; index < length5; ++index)
        {
            numArray27[index] = SimData.lookupSimsData(dis);
            numArray28[index] = dis.readShort();
        }
        int length6 = (int)dis.readByte();
        short[] numArray29 = new short[length6];
        int[] numArray30 = new int[length6];
        int[] numArray31 = new int[length6];
        short[] numArray32 = new short[length6];
        int[] numArray33 = new int[length6];
        short[] numArray34 = new short[length6];
        short[] numArray35 = new short[length6];
        short[] numArray36 = new short[length6];
        for (int index = 0; index < length6; ++index)
        {
            numArray29[index] = SimData.lookupSimsData(dis);
            numArray30[index] = dis.readInt();
            numArray31[index] = dis.readInt();
            numArray32[index] = dis.readShort();
            numArray33[index] = dis.readInt();
            numArray34[index] = SimData.lookupSimsData(dis);
            numArray35[index] = SimData.lookupSimsData(dis);
            numArray36[index] = SimData.lookupSimsData(dis);
        }
        sbyte[] b1 = new sbyte[(int)dis.readByte()];
        dis.readFully(b1);
        int length7 = (int)dis.readByte();
        short[] numArray37 = new short[length7];
        int[] numArray38 = new int[length7];
        sbyte[] numArray39 = new sbyte[length7];
        sbyte[] numArray40 = new sbyte[length7];
        sbyte[] numArray41 = new sbyte[length7];
        sbyte[][] numArray42 = new sbyte[length7][];
        int[][] numArray43 = new int[length7][];
        sbyte[][] numArray44 = new sbyte[length7][];
        sbyte[][] numArray45 = new sbyte[length7][];
        sbyte[][] numArray46 = new sbyte[length7][];
        int[][] numArray47 = new int[length7][];
        for (int index1 = 0; index1 < length7; ++index1)
        {
            numArray37[index1] = SimData.lookupSimsData(dis);
            numArray38[index1] = dis.readInt();
            numArray39[index1] = dis.readByte();
            numArray40[index1] = dis.readByte();
            numArray41[index1] = dis.readByte();
            int length3 = (int)dis.readByte();
            sbyte[] numArray4 = new sbyte[length3];
            int[] numArray5 = new int[length3];
            for (int index2 = 0; index2 < length3; ++index2)
            {
                numArray4[index2] = dis.readByte();
                numArray5[index2] = dis.readInt();
            }
            numArray42[index1] = numArray4;
            numArray43[index1] = numArray5;
            int length8 = (int)dis.readByte();
            sbyte[] numArray19 = new sbyte[length8];
            sbyte[] numArray20 = new sbyte[length8];
            for (int index2 = 0; index2 < length8; ++index2)
            {
                numArray19[index2] = (sbyte)SimData.lookupSimsData(dis);
                numArray20[index2] = dis.readByte();
            }
            numArray44[index1] = numArray19;
            numArray45[index1] = numArray20;
            int length9 = (int)dis.readByte();
            sbyte[] numArray21 = new sbyte[length9];
            int[] numArray22 = new int[length9];
            for (int index2 = 0; index2 < length9; ++index2)
            {
                numArray21[index2] = dis.readByte();
                numArray22[index2] = dis.readInt();
            }
            numArray46[index1] = numArray21;
            numArray47[index1] = numArray22;
        }
        int length10 = (int)dis.readByte();
        short[] numArray48 = new short[length10];
        short[] numArray49 = new short[length10];
        for (int index = 0; index < length10; ++index)
        {
            numArray48[index] = SimData.lookupSimsData(dis);
            numArray49[index] = (short)dis.readByte();
        }
        int num5 = (int)dis.readByte();
        int length11 = (int)dis.readByte();
        short[] numArray50 = new short[length11];
        sbyte[] numArray51 = new sbyte[length11];
        short[] numArray52 = new short[length11];
        short[] numArray53 = new short[length11];
        sbyte[][] numArray54 = new sbyte[length11][];
        sbyte[][] numArray55 = new sbyte[length11][];
        short[][] numArray56 = new short[length11][];
        for (int index1 = 0; index1 < length11; ++index1)
        {
            numArray50[index1] = SimData.lookupSimsData(dis);
            numArray51[index1] = dis.readByte();
            numArray52[index1] = SimData.lookupSimsData(dis);
            numArray53[index1] = SimData.lookupSimsData(dis);
            int length3 = dis.readUnsignedByte();
            sbyte[] numArray4 = new sbyte[length3];
            sbyte[] numArray5 = new sbyte[length3];
            short[] numArray19 = new short[length3];
            for (int index2 = 0; index2 < length3; ++index2)
            {
                numArray4[index2] = dis.readByte();
                numArray5[index2] = dis.readByte();
                numArray19[index2] = dis.readShort();
            }
            numArray54[index1] = numArray4;
            numArray55[index1] = numArray5;
            numArray56[index1] = numArray19;
        }
        int length12 = (int)dis.readByte();
        short[] numArray57 = new short[length12];
        short[] numArray58 = new short[length12];
        sbyte[] numArray59 = new sbyte[length12];
        int[][] numArray60 = new int[length12][];
        short[] numArray61 = new short[length12];
        sbyte[] numArray62 = new sbyte[length12];
        sbyte[] numArray63 = new sbyte[length12];
        sbyte[] numArray64 = new sbyte[length12];
        sbyte[] numArray65 = new sbyte[length12];
        sbyte[][] numArray66 = new sbyte[length12][];
        sbyte[][] numArray67 = new sbyte[length12][];
        for (int index1 = 0; index1 < length12; ++index1)
        {
            numArray57[index1] = SimData.lookupSimsData(dis);
            numArray58[index1] = SimData.lookupSimsData(dis);
            numArray59[index1] = dis.readByte();
            int[] numArray4 = new int[13];
            for (int index2 = 0; index2 < 13; ++index2)
            {
                int num1 = 0;
                if (index2 < 11)
                    num1 = (int)dis.readByte();
                numArray4[index2] = num1;
            }
            numArray60[index1] = numArray4;
            numArray61[index1] = SimData.lookupSimsData(dis);
            numArray62[index1] = dis.readByte();
            numArray63[index1] = dis.readByte();
            numArray64[index1] = dis.readByte();
            numArray65[index1] = dis.readByte();
            sbyte[] b2 = new sbyte[(int)dis.readByte()];
            dis.readFully(b2);
            numArray66[index1] = b2;
            sbyte[] b3 = new sbyte[(int)dis.readByte()];
            dis.readFully(b3);
            numArray67[index1] = b3;
        }
        int length13 = (int)dis.readByte();
        short[] numArray68 = new short[length13];
        for (int index = 0; index < length13; ++index)
            numArray68[index] = SimData.lookupSimsData(dis);
        int length14 = (int)dis.readShort();
        this.m_unlockedActionPackIds = new short[length14];
        short[] numArray69 = new short[length14];
        short[] numArray70 = new short[length14];
        int[] numArray71 = new int[length14];
        short[] numArray72 = new short[length14];
        sbyte[][] numArray73 = new sbyte[length14][];
        sbyte[][] numArray74 = new sbyte[length14][];
        sbyte[][] numArray75 = new sbyte[length14][];
        int[][] numArray76 = new int[length14][];
        int[][] numArray77 = new int[length14][];
        sbyte[][] numArray78 = new sbyte[length14][];
        sbyte[][] numArray79 = new sbyte[length14][];
        sbyte[][] numArray80 = new sbyte[length14][];
        sbyte[][] numArray81 = new sbyte[length14][];
        short[][] numArray82 = new short[length14][];
        for (int index1 = 0; index1 < length14; ++index1)
        {
            this.m_unlockedActionPackIds[index1] = (short)-1;
            numArray69[index1] = SimData.lookupSimsData(dis);
            numArray70[index1] = SimData.lookupSimsData(dis);
            int num1 = dis.readInt();
            numArray71[index1] = num1;
            numArray72[index1] = SimData.lookupSimsData(dis);
            int length3 = (int)dis.readByte();
            sbyte[] numArray4 = new sbyte[length3];
            sbyte[] numArray5 = new sbyte[length3];
            int[] numArray19 = new int[length3];
            int[] numArray20 = new int[length3];
            sbyte[] numArray21 = new sbyte[length3];
            sbyte[] numArray22 = new sbyte[length3];
            sbyte[] numArray23 = new sbyte[length3];
            sbyte[] numArray83 = new sbyte[length3];
            short[] numArray84 = new short[length3];
            for (int index2 = 0; index2 < length3; ++index2)
            {
                numArray4[index2] = dis.readByte();
                numArray5[index2] = dis.readByte();
                int num2 = dis.readInt();
                numArray20[index2] = dis.readInt();
                numArray21[index2] = dis.readByte();
                numArray22[index2] = dis.readByte();
                numArray23[index2] = dis.readByte();
                numArray83[index2] = dis.readByte();
                numArray84[index2] = dis.readShort();
                numArray19[index2] = (num2 & 1) != 0 ? ~num2 : num2;
            }
            int length8 = (int)dis.readByte();
            sbyte[] b2;
            if ((num1 & 67108864) != 0)
            {
                AppEngine.ASSERT(numArray73[30] != null && length8 == 0, "invalid generic talk");
                b2 = numArray73[30];
            }
            else
            {
                b2 = new sbyte[length8];
                dis.readFully(b2);
            }
            numArray74[index1] = numArray4;
            numArray75[index1] = numArray5;
            numArray76[index1] = numArray19;
            numArray77[index1] = numArray20;
            numArray78[index1] = numArray21;
            numArray79[index1] = numArray22;
            numArray80[index1] = numArray23;
            numArray81[index1] = numArray83;
            numArray82[index1] = numArray84;
            numArray73[index1] = b2;
        }
        int length15 = (int)dis.readByte();
        short[] numArray85 = new short[length15];
        sbyte[] numArray86 = new sbyte[length15];
        sbyte[] numArray87 = new sbyte[length15];
        sbyte[] numArray88 = new sbyte[length15];
        short[] numArray89 = new short[length15];
        sbyte[] numArray90 = new sbyte[length15];
        short[] numArray91 = new short[length15];
        sbyte[] numArray92 = new sbyte[length15];
        short[] numArray93 = new short[length15];
        sbyte[] numArray94 = new sbyte[length15];
        short[] numArray95 = new short[length15];
        for (int index = 0; index < length15; ++index)
        {
            numArray85[index] = SimData.lookupSimsData(dis);
            numArray86[index] = dis.readByte();
            numArray87[index] = dis.readByte();
            numArray88[index] = dis.readByte();
            numArray89[index] = SimData.lookupSimsData(dis);
            numArray90[index] = dis.readByte();
            numArray91[index] = SimData.lookupSimsData(dis);
            numArray92[index] = dis.readByte();
            numArray93[index] = SimData.lookupSimsData(dis);
            numArray94[index] = dis.readByte();
            numArray95[index] = SimData.lookupSimsData(dis);
        }
        int length16 = (int)dis.readByte();
        sbyte[] numArray96 = new sbyte[length16];
        short[] numArray97 = new short[length16];
        short[] numArray98 = new short[length16];
        short[] numArray99 = new short[length16];
        short[] numArray100 = new short[length16];
        short[] numArray101 = new short[length16];
        short[][] numArray102 = new short[length16][];
        for (int index1 = 0; index1 < length16; ++index1)
        {
            numArray96[index1] = dis.readByte();
            numArray97[index1] = SimData.lookupSimsData(dis);
            numArray98[index1] = SimData.lookupSimsData(dis);
            numArray99[index1] = dis.readShort();
            numArray100[index1] = SimData.lookupSimsData(dis);
            numArray101[index1] = dis.readShort();
            int length3 = (int)dis.readByte();
            short[] numArray4 = new short[length3];
            for (int index2 = 0; index2 < length3; ++index2)
                numArray4[index2] = dis.readShort();
            numArray102[index1] = numArray4;
        }
        this.getSimWorld().initWorld(dis);
        this.getSimWorld().initHouses(dis);
        dis.close();
        this.d_skillDescStrings = numArray1;
        this.d_skillRates = numArray2;
        this.d_skillLevelDescStrings = numArray3;
        this.d_careerDescStrings = numArray6;
        this.d_careerIcons = numArray7;
        this.d_careerRabbitHoles = numArray8;
        this.d_careerBosses = numArray9;
        this.d_careerFreakDeath1s = numArray10;
        this.d_careerFreakDeath2s = numArray11;
        this.d_careerRaiseFail = numArray12;
        this.d_careerLevelDescStrings = numArray13;
        this.d_careerLevelIncomes = numArray14;
        this.d_careerLevelFlags = numArray15;
        this.d_careerLevelHoursStarts = numArray16;
        this.d_careerLevelHoursEnds = numArray17;
        this.d_careerLevelRequirements = numArray18;
        this.d_personaDescStrings = numArray24;
        this.d_personaLongDescStrings = numArray25;
        this.d_personaFlags = numArray26;
        this.d_dreamDescStrings = numArray27;
        this.d_dreamFlags = numArray28;
        this.d_motiveCount = length6;
        this.d_motiveDescStrings = numArray29;
        this.d_motiveStartLevel = numArray30;
        this.d_motiveDecayRate = numArray31;
        this.d_motiveTriggersNeeds = numArray32;
        this.d_motiveTriggersNeedLevels = numArray33;
        this.d_motiveAnimHighs = numArray34;
        this.d_motiveAnimMids = numArray35;
        this.d_motiveAnimLows = numArray36;
        this.d_timeRangeDreams = b1;
        this.d_buffCount = length7;
        this.d_buffDescStringIds = numArray37;
        this.d_buffTimeouts = numArray38;
        this.d_buffTimeoutChains = numArray39;
        this.d_buffTimes = numArray40;
        this.d_buffFlags = numArray41;
        this.d_buffTriggerMotives = numArray42;
        this.d_buffTriggerMotiveLevels = numArray43;
        this.d_buffEffectMood = numArray44;
        this.d_buffEffectMoodAmount = numArray45;
        this.d_buffEffectMotive = numArray46;
        this.d_buffEffectMotiveFactors = numArray47;
        this.d_traitDescStrings = numArray48;
        this.d_traitExcludes = numArray49;
        this.d_numRelLevels = num5;
        this.d_relStateDescStrings = numArray50;
        this.d_relStateFlags = numArray51;
        this.d_relStateEffectAnims = numArray52;
        this.d_relStateToStrings = numArray53;
        this.d_relStateTriggerToStates = numArray54;
        this.d_relStateTriggerLevels = numArray55;
        this.d_relStateTriggerLevelValues = numArray56;
        this.d_numSims = length12;
        this.d_simNameStrings = numArray57;
        this.d_simPortraitAnims = numArray58;
        this.d_simMacromapColors = numArray59;
        this.d_simAttributes = numArray60;
        this.d_simHomes = numArray61;
        this.d_simFlags = numArray62;
        this.d_simPartners = numArray63;
        this.d_simCareers = numArray64;
        this.d_simCareerLevels = numArray65;
        this.d_simTraits = numArray66;
        this.d_simQuests = numArray67;
        this.d_commodityStringIds = numArray68;
        this.d_numActions = length14;
        this.d_actionStringIds = numArray69;
        this.d_actionGroupStringIds = numArray70;
        this.d_actionFlags = numArray71;
        this.d_actionWorldArgs = numArray72;
        this.d_actionConditionCommodities = numArray74;
        this.d_actionConditionTraits = numArray75;
        this.d_actionConditionRelStates = numArray76;
        this.d_actionEffectFlags = numArray77;
        this.d_actionAffectFriendships = numArray78;
        this.d_actionAffectRomances = numArray79;
        this.d_actionAffectCommodities = numArray80;
        this.d_actionAffectCommodityAmounts = numArray81;
        this.d_actionResponseActions = numArray82;
        this.d_actionPhases = numArray73;
        this.d_chanceCardPrompts = numArray85;
        this.d_chanceCardYesPercents = numArray86;
        this.d_chanceCardNoPercents = numArray87;
        this.d_chanceCardResultYes1s = numArray88;
        this.d_chanceCardResultYes1Strings = numArray89;
        this.d_chanceCardResultYes2s = numArray90;
        this.d_chanceCardResultYes2Strings = numArray91;
        this.d_chanceCardResultNo1s = numArray92;
        this.d_chanceCardResultNo1Strings = numArray93;
        this.d_chanceCardResultNo2s = numArray94;
        this.d_chanceCardResultNo2Strings = numArray95;
        this.d_questFlags = numArray96;
        this.d_questPrompts = numArray97;
        this.d_questMessages = numArray98;
        this.d_questFinishActions = numArray99;
        this.d_questGiveItem = numArray100;
        this.d_questRewardCash = numArray101;
        this.d_questTriggerActions = numArray102;
    }

    public int getGameTimeAbs()
    {
        return this.m_timeTotal;
    }

    public int getGameTime()
    {
        return SimData.getGameTime(this.m_timeTotal);
    }

    public static int getGameTime(int absTime)
    {
        return absTime % 1440;
    }

    public int getGameDay()
    {
        return SimData.getGameDay(this.m_timeTotal);
    }

    public static int getGameDay(int absTime)
    {
        return absTime / 1440 % 7;
    }

    public static int getGameMidnight(int absTime)
    {
        return absTime / 1440 * 1440;
    }

    public int getTotalDays()
    {
        return (this.getGameTimeAbs() - 480) / 1440;
    }

    public int getMoney()
    {
        return this.m_money;
    }

    public int getMoneySpent()
    {
        return this.m_moneySpent;
    }

    public void adjustMoney(int amount)
    {
        this.m_money = midp.JMath.min(this.m_money + amount, 999999);
        if (this.m_money > this.mostMoneyEarned)
            this.mostMoneyEarned = this.m_money;
        if (amount < 0)
        {
            this.m_moneySpent -= amount;
        }
        else
        {
            if (this.m_money >= 1000)
                this.dreamCompleteEvent(42);
            if (this.m_money >= 5000)
                this.dreamCompleteEvent(61);
        }
        if (this.m_money <= 10000 || !this.getAchievements(62))
            return;
        this.m_engine.getScene().awardAchievment(13);
    }

    private void initGameTimeMoney()
    {
        this.m_timeTotal = 480;
        this.m_money = 700;
        this.m_moneySpent = 0;
        this.m_fastForward = false;
        this.m_furnitureStage = (sbyte)0;
        this.m_houseUpgradeDay = (short)-1;
    }

    public void setFastforward(bool enable)
    {
        this.m_fastForward = enable;
    }

    public bool getFastforward()
    {
        return this.m_fastForward;
    }

    private void updateGameTime(int timeStep)
    {
        if (SimData.getGameDay(this.m_timeTimer) != SimData.getGameDay(this.m_timeTimer + timeStep))
        {
            this.m_fishCaughtToday = (byte)0;
            this.m_woohooSimsToday = new int[10];
        }
        this.m_timeTimer += timeStep;
        if (this.m_timeTimer <= 1000)
            return;
        int num = this.m_timeTimer / 1000;
        this.m_timeTimer -= num * 1000;
        int timeTotal = this.m_timeTotal;
        this.m_timeTotal += num;
        this.m_engine.getSceneGame().checkGameTimeTriggers(timeTotal, this.m_timeTotal);
    }

    public int getCostForAction(int action)
    {
        switch (action)
        {
            case 131:
                return 10;
            case 169:
                int simCareer = this.getSimCareer(0);
                if (simCareer != -1)
                {
                    int simCareerLevel = this.getSimCareerLevel(0);
                    if ((this.getCareerLevelFlags(simCareer, simCareerLevel) & 2) != 0)
                        return 15;
                }
                return 30;
            default:
                AppEngine.ASSERT(false, "unknown cost for action");
                return 0;
        }
    }

    public int getFurnitureStage()
    {
        int totalDays = this.getTotalDays();
        for (int skill = 0; skill < this.getSkillCount(); ++skill)
            totalDays += this.getSkillRank(skill);
        if (totalDays >= 15)
            return 2;
        return totalDays >= 5 ? 1 : 0;
    }

    public bool isFurnitureStageChange()
    {
        int furnitureStage = this.getFurnitureStage();
        if (furnitureStage <= (int)this.m_furnitureStage)
            return false;
        this.m_furnitureStage = (sbyte)furnitureStage;
        return true;
    }

    public void upgradePlayerHouse()
    {
        this.m_houseUpgradeDay = (short)this.getTotalDays();
    }

    public int getHouseUpgradeMessage()
    {
        int totalDays = this.getTotalDays();
        switch (this.getSimWorld().getHouseUpgradeLevel())
        {
            case 0:
                if (totalDays >= 3 && !this.getAchievements(16))
                {
                    this.setAchievements(16);
                    return 1176;
                }
                break;
            case 1:
                if (totalDays - (int)this.m_houseUpgradeDay >= 5 && !this.getAchievements(32))
                {
                    this.setAchievements(32);
                    return 1177;
                }
                break;
        }
        return -1;
    }

    public int getDesiredWakeupTime(int simId)
    {
        int num = 480;
        if (this.hasSimGotTrait(simId, 10) != -1)
            num = 540;
        else if (this.hasSimGotTrait(simId, 11) != -1)
            num = 420;
        return num;
    }

    public int getWakeupTime(int simId, bool longSleep)
    {
        int gameTimeAbs = this.getGameTimeAbs();
        int b;
        if (simId == 0 && !longSleep)
        {
            int a = 65536 - MathExt.Fdiv(this.m_motiveLevelsF[1], 6553600);
            b = gameTimeAbs + MathExt.Fmul(a, 600);
        }
        else
            b = gameTimeAbs + 600;
        if (this.getSimCareer(simId) != -1)
        {
            int a = this.getNextJobStartTime(simId, gameTimeAbs) - 60;
            if (a > gameTimeAbs && a - gameTimeAbs < 1440)
                b = midp.JMath.min(a, b);
        }
        AppEngine.ASSERT(b >= gameTimeAbs, "can't wake up in the past!");
        return b;
    }

    public void updateSkipWorking()
    {
        int careerLevelHoursEnd = this.getCareerLevelHoursEnd(this.getSimCareer(0), this.getSimCareerLevel(0));
        int gameTime = this.getGameTime();
        int num = careerLevelHoursEnd - gameTime;
        if (num < 0)
            num += 1440;
        AppEngine.ASSERT(careerLevelHoursEnd >= gameTime, "Can't knock-off *before* we go to work!");
        this.updateGameTime(num * 1000);
        this.adjustMotiveLevelWithBuffCheck(1, -2621440, 3);
        this.adjustMotiveLevelWithBuffCheck(3, -1310720, 8);
        this.adjustMotiveLevel(5, -1638400);
        this.adjustMotiveLevel(2, this.getMotiveLevel(2) < 2293760 ? 3276800 : -983040);
        if (this.getSimCareer(0) != 0)
            this.adjustMotiveLevelWithBuffCheck(0, -1310720, 0);
        this.delayAlerts();
        this.getSimWorld().forceTint();
    }

    public void updateSkipSleeping(int wakeTime)
    {
        int gameTimeAbs = this.getGameTimeAbs();
        AppEngine.ASSERT(wakeTime >= gameTimeAbs, "Can't wake up *before* we go to sleep!");
        this.updateGameTime((wakeTime - gameTimeAbs) * 1000);
        this.adjustMotiveLevel(1, 6553600);
        this.adjustMotiveLevel(2, -655360);
        this.adjustMotiveLevelWithBuffCheck(0, -1310720, 0);
        this.adjustMotiveLevelWithBuffCheck(3, -983040, 8);
        this.delayAlerts();
        this.getSimWorld().forceTint();
    }

    private void initInventory()
    {
        int itemCount = this.getSimWorld().getItemCount();
        for (int index = 0; index < itemCount; ++index)
            this.setInventoryCount(index, 0);
    }

    public int getInventoryCount(int item)
    {
        return (int)this.getSimWorld().getItemRecord(item).m_inventoryCount;
    }

    private void setInventoryCount(int item, int amount)
    {
        this.getSimWorld().getItemRecord(item).m_inventoryCount = (short)amount;
    }

    public int getInventoryNthCount()
    {
        int num = 0;
        int itemCount = this.getSimWorld().getItemCount();
        for (int index = 0; index < itemCount; ++index)
        {
            if (this.getInventoryCount(index) != 0)
                ++num;
        }
        return num;
    }

    public int getInventoryNthItem(int index)
    {
        int num = 0;
        int itemCount = this.getSimWorld().getItemCount();
        for (int index1 = 0; index1 < itemCount; ++index1)
        {
            if (this.getInventoryCount(index1) != 0)
            {
                if (num == index)
                    return index1;
                ++num;
            }
        }
        return -1;
    }

    public void adjustInventory(int item, int amount)
    {
        int amount1 = (int)(sbyte)midp.JMath.min(this.getSimWorld().getItemMaxInventory(item), this.getInventoryCount(item) + amount);
        this.setInventoryCount(item, amount1);
        if (amount <= 0 || (this.getSimWorld().getItemFlags(item) & 4) == 0)
            return;
        this.dreamCompleteEvent(26);
    }

    public void createPlantContextMenu(int[] menu, int[] actions, int action)
    {
        int dActionStringId = (int)this.d_actionStringIds[action];
        AppEngine.menuClear(menu, dActionStringId);
        AppEngine.menuClear(actions, dActionStringId);
        SimWorld simWorld = this.getSimWorld();
        int itemCount = simWorld.getItemCount();
        for (int index = 0; index < itemCount; ++index)
        {
            if (this.getInventoryCount(index) > 0 && (simWorld.getItemFlags(index) & 1) != 0)
            {
                AppEngine.menuAppendItem(menu, simWorld.getItemDescString(index));
                AppEngine.menuAppendItem(actions, action);
            }
        }
    }

    public void createCookContextMenu(int[] menu, int[] actions, int action)
    {
        int dActionStringId = (int)this.d_actionStringIds[action];
        AppEngine.menuClear(menu, dActionStringId);
        AppEngine.menuClear(actions, dActionStringId);
        SimWorld simWorld = this.getSimWorld();
        int itemCount = simWorld.getItemCount();
        for (int index = 0; index < itemCount; ++index)
        {
            if (this.getInventoryCount(index) > 0 && (simWorld.getItemFlags(index) & 4) != 0)
            {
                AppEngine.menuAppendItem(menu, simWorld.getItemDescString(index));
                AppEngine.menuAppendItem(actions, action);
            }
        }
    }

    public bool startRecipe(int recipe)
    {
        SimWorld simWorld = this.getSimWorld();
        int recipeIngredientCount = simWorld.getRecipeIngredientCount(recipe);
        for (int index = 0; index < recipeIngredientCount; ++index)
        {
            if (this.getInventoryCount(simWorld.getRecipeIngredient(recipe, index)) < 1)
                return false;
        }
        for (int index = 0; index < recipeIngredientCount; ++index)
            this.adjustInventory(simWorld.getRecipeIngredient(recipe, index), -1);
        this.m_activeRecipe = recipe;
        return true;
    }

    public int getActiveRecipe()
    {
        return this.m_activeRecipe;
    }

    public bool startFishing()
    {
        return this.getInventoryCount(1) > 0;
    }

    public bool startRepairing()
    {
        return this.getInventoryCount(0) > 0;
    }

    private void initSkills()
    {
        int skillCount = this.getSkillCount();
        if (this.m_skillLevelsF == null)
            this.m_skillLevelsF = new int[skillCount];
        AppEngine.fillArray(this.m_skillLevelsF, 0);
    }

    public int getSkillLevel(int skill)
    {
        return this.m_skillLevelsF[skill];
    }

    public int getSkillCount()
    {
        return this.d_skillDescStrings.Length;
    }

    public int getSkillDesc(int skill)
    {
        return (int)this.d_skillDescStrings[skill];
    }

    public int getSkillLevelDesc(int skill)
    {
        return (int)this.d_skillLevelDescStrings[skill][this.getSkillRank(skill)];
    }

    public int getSkillRank(int skill)
    {
        return this.m_skillLevelsF[skill] / 65536;
    }

    public void increaseSkill(int skill)
    {
        int[] skillLevelsF = this.m_skillLevelsF;
        int skillRank = this.getSkillRank(skill);
        if (skillRank >= 5)
            return;
        int a = this.d_skillRates[skill][skillRank];
        if (this.hasSimGotTrait(0, 14) != -1)
            a = MathExt.Fmul(a, 81920);
        else if (this.hasSimGotTrait(0, 15) != -1)
            a = MathExt.Fmul(a, 49152);
        skillLevelsF[skill] += a;
        skillLevelsF[skill] = midp.JMath.min(skillLevelsF[skill], 65536 * (skillRank + 1));
    }

    private void initCareer()
    {
        this.d_simCareers[0] = (sbyte)-1;
        this.d_simCareerLevels[0] = (sbyte)0;
        this.m_careerAcceptDay = (sbyte)-1;
        this.m_careerDaysWorked = (short)0;
        this.m_careerDaysMissed = (short)0;
        if (this.m_careerLevelsAttained == null)
            this.m_careerLevelsAttained = new sbyte[this.d_careerDescStrings.Length];
        AppEngine.fillArray(this.m_careerLevelsAttained, (sbyte)0);
        this.m_phoneCareer = (sbyte)-1;
        this.m_phoneCareerTimer = 1440000;
    }

    private void updateCareer(int timeStep)
    {
        this.m_phoneCareerTimer += timeStep;
        if (this.m_phoneCareerTimer <= 1440000)
            return;
        this.m_phoneCareerTimer = 0;
        int length = this.d_careerDescStrings.Length;
        if (!this.m_engine.isBonusUnlocked())
            --length;
        this.m_phoneCareer = (sbyte)(this.m_engine.rand(0, length) - 1);
    }

    public void careerAcceptJob(int career, int level)
    {
        int dSimCareer = (int)this.d_simCareers[0];
        int dSimCareerLevel = (int)this.d_simCareerLevels[0];
        this.d_simCareers[0] = (sbyte)career;
        this.d_simCareerLevels[0] = (sbyte)level;
        if (career != -1)
            this.m_careerLevelsAttained[career] = (sbyte)level;
        this.m_careerDaysWorked = (short)0;
        this.m_careerDaysMissed = (short)0;
        if (career != -1)
        {
            if (dSimCareer != career)
                this.m_careerAcceptDay = (sbyte)this.getGameDay();
            AppEngine engine = this.m_engine;
            SceneGame sceneGame = engine.getSceneGame();
            int baseString = dSimCareer == career ? (level > dSimCareerLevel ? 955 : 957) : 953;
            int gameDay = SimData.getGameDay(this.getNextJobStartTime(0, this.getGameTimeAbs()));
            int stringid = SimData.getGameDay(this.getGameTimeAbs() + 1440) != gameDay ? SimData.DAY_STRINGS[gameDay] : 989;
            TextManager textManager = engine.getTextManager();
            string string0 = textManager.getString(stringid);
            StringBuffer stringBuffer = textManager.clearStringBuffer();
            textManager.appendTimeToBuffer24Hour((int)this.d_careerLevelHoursStarts[career][level]);
            string string2 = textManager.getString(this.getSimWorld().getObjectStringId((int)this.d_careerRabbitHoles[career]));
            textManager.dynamicString(-11, baseString, string0, stringBuffer.toString(), string2);
            int postMessage = 0;
            if (dSimCareer == career && level > dSimCareerLevel)
                postMessage = 4;
            else if (career != -1)
                postMessage = 3;
            int careerLevelDescString = this.getCareerLevelDescString(career, level);
            sceneGame.showMessageBox(-11, careerLevelDescString, postMessage);
        }
        this.m_engine.setRMSHasSeenTutorial(23);
        SpywareManager.getInstance().trackJobChange();
    }

    public int careerDayWorked()
    {
        int careerLevelIncome = this.getCareerLevelIncome(this.getSimCareer(0), this.getSimCareerLevel(0));
        this.adjustMoney(careerLevelIncome);
        ++this.m_careerDaysWorked;
        if ((int)this.m_careerDaysWorked % 3 == 2 && this.m_careerDaysMissed > (short)0)
            --this.m_careerDaysMissed;
        return careerLevelIncome;
    }

    public void careerDayMissed()
    {
        ++this.m_careerDaysMissed;
        if (this.m_careerDaysMissed < (short)3)
            return;
        this.careerAcceptJob(-1, 0);
    }

    public int getRequirementValue(int requirement)
    {
        switch (requirement)
        {
            case 0:
                return this.getSkillRank(0);
            case 1:
                return this.getSkillRank(1);
            case 2:
                return (int)this.m_careerDaysWorked;
            case 3:
                int num = 0;
                for (int index = 1; index < this.d_numSims; ++index)
                {
                    if ((this.getRelStateFlags((int)this.m_currentRelStates[index]) & 16) != 0)
                        ++num;
                }
                return num;
            case 4:
                return this.getSkillRank(3);
            case 5:
                return this.getSkillRank(2);
            default:
                AppEngine.ASSERT(false, "invalid requirement");
                return this.getSkillRank(0);
        }
    }

    public int getRequimentName(int requirement)
    {
        switch (requirement)
        {
            case 0:
                return 691;
            case 1:
                return 705;
            case 2:
                return 1074;
            case 3:
                return 1073;
            case 4:
                return 719;
            case 5:
                return 712;
            default:
                AppEngine.ASSERT(false, "invalid requirement");
                return 691;
        }
    }

    public bool careerRequirementsMet(int career, int level)
    {
        sbyte[] numArray = this.d_careerLevelRequirements[career][level];
        int requirement1 = (int)numArray[0];
        int num1 = (int)numArray[1];
        if (requirement1 != -1 && this.getRequirementValue(requirement1) < num1)
            return false;
        int requirement2 = (int)numArray[2];
        int num2 = (int)numArray[3];
        return (requirement2 == -1 || this.getRequirementValue(requirement2) >= num2) && (this.getRelStateFlags((int)this.m_currentRelStates[this.getCareerBoss(career)]) & 2) == 0;
    }

    public bool careerAutoPromotionDue()
    {
        int simCareer = this.getSimCareer(0);
        int simCareerLevel = this.getSimCareerLevel(0);
        return simCareerLevel < this.getCareerLevelCount(simCareer) - 1 && this.careerRequirementsMet(simCareer, simCareerLevel + 1) && this.m_careerDaysWorked >= (short)10;
    }

    public int getJobSearchCareerFromObject(MapObject @object)
    {
        int dSimCareer = (int)this.d_simCareers[0];
        int num = -1;
        if (@object == null || @object.getType() == 132)
        {
            int gameTime = this.getGameTime();
            if (gameTime >= 450 && gameTime <= 1110 && (int)this.m_phoneCareer != dSimCareer)
                num = (int)this.m_phoneCareer;
        }
        else
            num = AppEngine.indexOf((short)@object.getType(), this.d_careerRabbitHoles);
        return num;
    }

    public int getJobSearchLevel(int career)
    {
        return career == -1 ? 0 : midp.JMath.max((int)this.m_careerLevelsAttained[career] - 1, 0);
    }

    public bool isTimeInRange(int time, int startTime, int endTime)
    {
        startTime = (startTime + 1440) % 1440;
        endTime = (endTime + 1440) % 1440;
        return startTime < endTime ? time >= startTime && time <= endTime : time >= startTime || time <= endTime;
    }

    public int getTimeFlags(int sim)
    {
        return this.getTimeFlags(sim, this.getGameTimeAbs());
    }

    public int getTimeFlags(int sim, int gameTime)
    {
        int num1 = 0;
        int gameDay = SimData.getGameDay(gameTime);
        int gameTime1 = SimData.getGameTime(gameTime);
        int endTime = this.getDesiredWakeupTime(sim);
        int startTime = endTime - 600;
        int dSimCareer = (int)this.d_simCareers[sim];
        int num2;
        if (dSimCareer == -1)
        {
            num2 = num1 | 8;
        }
        else
        {
            int dSimCareerLevel = (int)this.d_simCareerLevels[sim];
            int num3 = (int)this.d_careerLevelHoursStarts[dSimCareer][dSimCareerLevel];
            if (sim == 0 && gameDay == (int)this.m_careerAcceptDay)
            {
                num2 = num1 | 8;
            }
            else
            {
                if (sim == 0)
                    this.m_careerAcceptDay = (sbyte)-1;
                int num4 = SimData.DAY_FLAGS[gameDay];
                if (((int)this.d_careerLevelFlags[dSimCareer][dSimCareerLevel] & num4) != 0)
                {
                    int num5 = (int)this.d_careerLevelHoursEnds[dSimCareer][dSimCareerLevel];
                    num2 = gameTime1 >= num3 - 30 ? (gameTime1 >= num3 ? (gameTime1 >= num3 + 60 ? (gameTime1 >= num5 ? num1 | 8 : num1 | 4) : num1 | 2) : num1 | 1) : num1 | 8;
                }
                else
                    num2 = num1 | 8;
            }
            startTime = num3 - 660;
            endTime = num3 - 60;
        }
        if (this.isTimeInRange(gameTime1, startTime, endTime))
            num2 |= 16;
        return num2;
    }

    public int getNextJobStartTime(int sim, int now)
    {
        int simCareer = this.getSimCareer(sim);
        AppEngine.ASSERT(simCareer != -1, "Can't get the start time for a slacker");
        int simCareerLevel = this.getSimCareerLevel(sim);
        int careerLevelFlags = this.getCareerLevelFlags(simCareer, simCareerLevel);
        int careerLevelHoursStart = this.getCareerLevelHoursStart(simCareer, simCareerLevel);
        int gameTime = SimData.getGameTime(now);
        int gameDay = SimData.getGameDay(now);
        int index1 = gameDay;
        for (int index2 = 0; index2 < 7; ++index2)
        {
            index1 = (gameDay + index2) % 7;
            if ((careerLevelFlags & SimData.DAY_FLAGS[index1]) != 0 && (sim != 0 || index1 != (int)this.m_careerAcceptDay) && (index1 != gameDay || gameTime < careerLevelHoursStart))
                break;
        }
        int num = SimData.getGameMidnight(this.getGameTimeAbs()) + careerLevelHoursStart;
        if (index1 != gameDay)
            num += (index1 - gameDay + 7) % 7 * 1440;
        return num;
    }

    private bool isPlaceForWork(MapObject target, int sim)
    {
        int dSimCareer = (int)this.d_simCareers[sim];
        if (dSimCareer == -1 || target == null)
            return false;
        int careerRabbitHole = this.getCareerRabbitHole(dSimCareer);
        return target.getType() == careerRabbitHole;
    }

    public bool isTimeForWork(MapObject target, int sim)
    {
        return (target == null || this.isPlaceForWork(target, sim)) && (this.getTimeFlags(sim) & 3) != 0;
    }

    public int getCareerLevelCount(int career)
    {
        return this.d_careerLevelDescStrings[career].Length;
    }

    public int getCareerDescString(int career)
    {
        return career == -1 ? 996 : (int)this.d_careerDescStrings[career];
    }

    public int getCareerIcon(int career)
    {
        return (int)this.d_careerIcons[career];
    }

    public int getCareerRabbitHole(int career)
    {
        return (int)this.d_careerRabbitHoles[career];
    }

    public int getCareerBoss(int career)
    {
        return (int)this.d_careerBosses[career];
    }

    public int getCareerDeathString()
    {
        int dSimCareer = (int)this.d_simCareers[0];
        return this.m_engine.randPercent() < 50 ? (int)this.d_careerFreakDeath1s[dSimCareer] : (int)this.d_careerFreakDeath2s[dSimCareer];
    }

    public int getCareerFailString(int career)
    {
        return (int)this.d_careerRaiseFail[career];
    }

    public int getCareerLevelDescString(int career, int level)
    {
        return (int)this.d_careerLevelDescStrings[career][level];
    }

    public int getCareerLevelIncome(int career, int level)
    {
        return (int)this.d_careerLevelIncomes[career][level];
    }

    public int getCareerLevelFlags(int career, int level)
    {
        return (int)this.d_careerLevelFlags[career][level];
    }

    public int getCareerLevelHoursStart(int career, int level)
    {
        return (int)this.d_careerLevelHoursStarts[career][level];
    }

    public int getCareerLevelHoursEnd(int career, int level)
    {
        return (int)this.d_careerLevelHoursEnds[career][level];
    }

    public sbyte[] getCareerLevelRequirements(int career, int level)
    {
        return this.d_careerLevelRequirements[career][level];
    }

    public int getPersona()
    {
        return (int)this.m_persona;
    }

    public void setPersona(int persona)
    {
        this.m_persona = (sbyte)persona;
    }

    public int getPersonaCount()
    {
        return this.d_personaDescStrings.Length;
    }

    public short getPersonaDescString(int persona)
    {
        return persona == 1 && !this.isSimMale(0) ? (short)782 : this.d_personaDescStrings[persona];
    }

    public short getPersonaLongDescString(int persona)
    {
        return this.d_personaLongDescStrings[persona];
    }

    public int getPersonaFlags()
    {
        return (int)this.d_personaFlags[(int)this.m_persona];
    }

    public int getPersonaNthGoalCount()
    {
        return AppEngine.countOfFlags(this.getPersonaFlags(), this.d_dreamFlags);
    }

    public int getPersonaNthGoalItem(int index)
    {
        return AppEngine.indexOfNthElementFlags(index, this.d_dreamFlags, this.getPersonaFlags());
    }

    private int getPersonaActionFlags()
    {
        return this.m_persona != (sbyte)5 ? 0 : 33554432;
    }

    public bool showPersonaComplete()
    {
        if (!this.getAchievements(1) || this.getAchievements(2))
            return false;
        this.setAchievements(2);
        return true;
    }

    private void initDreams()
    {
        this.m_dream = (sbyte)-1;
        this.m_dreamLGCSeed = (short)this.m_engine.rand(0, this.d_dreamFlags.Length - 1);
        this.m_dreamTimer = 115000;
        if (this.m_promises == null)
        {
            this.m_promises = new sbyte[4];
            this.m_timeRanges = new int[this.d_timeRangeDreams.Length];
            this.m_woohooTimes = new int[10];
        }
        AppEngine.fillArray(this.m_promises, (sbyte)-1);
        this.m_personaGoalsCompleted = 0;
        this.m_achievements = 0;
        AppEngine.fillArray(this.m_timeRanges, this.getGameTimeAbs());
        this.m_dreamFishCount = (short)0;
        this.m_dreamHarvestCount = (short)0;
        AppEngine.fillArray(this.m_woohooTimes, -1);
        this.m_quickLinkFlags = 0;
    }

    public bool getAchievements(int flags)
    {
        return (this.m_achievements & flags) != 0;
    }

    public bool getAchievementsAll(int flags)
    {
        return (this.m_achievements & flags) == flags;
    }

    public void setAchievements(int flags)
    {
        this.m_achievements |= flags;
    }

    public void unsetAchievements(int flags)
    {
        this.m_achievements &= ~flags;
    }

    private void updateDreams(int timeStep)
    {
        this.m_dreamTimer += timeStep;
        if (this.m_dream != (sbyte)-1)
        {
            if (this.m_dreamTimer > 240000)
            {
                this.m_engine.getSceneGame().showExpiredDream((int)this.m_dream);
                this.m_dream = (sbyte)-1;
                this.m_dreamTimer = 0;
            }
        }
        else if (this.m_dreamTimer > 120000)
        {
            this.m_dream = (sbyte)this.dreamNew();
            this.m_dreamTimer = 0;
            this.m_engine.getSceneGame().showNewDream();
        }
        int gameTimeAbs = this.getGameTimeAbs();
        for (int index = 0; index < this.m_timeRanges.Length; ++index)
        {
            int timeRange = this.m_timeRanges[index];
            if (timeRange != -1 && gameTimeAbs - timeRange > 4320)
            {
                this.m_timeRanges[index] = gameTimeAbs;
                this.dreamCompleteEvent((int)this.d_timeRangeDreams[index]);
            }
        }
    }

    public void getNewDream()
    {
        this.m_dream = (sbyte)this.dreamNew();
        this.m_dreamTimer = 0;
        this.m_engine.getSceneGame().showNewDreamMessage();
    }

    private int dreamNew()
    {
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        for (int index = 0; index < 4; ++index)
        {
            int promise = (int)this.m_promises[index];
            if (promise != -1)
            {
                int dDreamFlag = (int)this.d_dreamFlags[promise];
                if ((dDreamFlag & 1) != 0)
                    ++num1;
                if ((dDreamFlag & 2) != 0)
                    ++num2;
                if ((dDreamFlag & 4) != 0)
                    ++num3;
            }
        }
        int length = this.d_dreamFlags.Length;
        AppEngine.ASSERT(length <= 257, "LGC isn't big enough for dreams list");
        int dream1 = -1;
        int num4 = (int)this.m_dreamLGCSeed;
        for (int index = 0; index < length; ++index)
        {
            do
            {
                num4 = (1543 * num4 + 3571) % 257;
            }
            while (num4 >= length);
            int dream2 = num4;
            if (this.getDreamSlot(dream2) == -1 && ((int)this.d_dreamFlags[dream2] & 8) == 0 && this.dreamSuitable(dream2) && (!this.m_engine.isGoalCompleted(dream2) || this.m_engine.randPercent() >= 70))
            {
                dream1 = dream2;
                this.m_dreamLGCSeed = (short)dream2;
                break;
            }
        }
        switch (dream1)
        {
            case 43:
                this.m_dreamFishCount = (short)0;
                break;
            case 44:
                this.m_dreamHarvestCount = (short)0;
                break;
            case 51:
                this.clearAllRelStateFlags(1536);
                break;
        }
        int index1 = AppEngine.indexOf((sbyte)dream1, this.d_timeRangeDreams);
        if (index1 != -1 && this.m_timeRanges[index1] != -1)
            this.m_timeRanges[index1] = this.getGameTimeAbs();
        AppEngine.ASSERT(dream1 != -1, "couldn't find a new dream");
        this.m_engine.setGoalDiscovered(dream1);
        return dream1;
    }

    public void dreamToPromise()
    {
        int dreamSlot = this.getDreamSlot(-1);
        if (dreamSlot == -1 || this.m_dream == (sbyte)-1)
            return;
        this.m_engine.setGoalDiscovered((int)this.m_dream);
        this.m_promises[dreamSlot] = this.m_dream;
        this.m_dream = (sbyte)-1;
        this.m_dreamTimer = 0;
        this.m_engine.getSceneGame().showNewPromise(dreamSlot);
    }

    public bool isDreamToPromisePossible()
    {
        return AppEngine.indexOf((sbyte)-1, this.m_promises) != -1;
    }

    private bool dreamSuitable(int dream)
    {
        SimWorld simWorld = this.getSimWorld();
        switch (dream)
        {
            case 2:
                return this.getInventoryCount(1) == 0;
            case 3:
                return this.getInventoryCount(2) == 0;
            case 4:
                return this.getInventoryCount(0) == 0;
            case 5:
                return !simWorld.playerOwnsParentType(27);
            case 6:
                return !simWorld.playerOwnsParentType(5);
            case 7:
                return this.getSkillRank(0) < 5;
            case 8:
                return this.getSkillRank(1) < 5;
            case 9:
                return this.getSkillRank(2) < 5;
            case 10:
            case 49:
                AppEngine.ASSERT(true, "stranger should be 0");
                AppEngine.ASSERT(this.m_currentRelStates[0] == (sbyte)0, "player rel state should be stranger");
                return AppEngine.countOf(0, this.m_currentRelStates) > 1;
            case 11:
            case 12:
            case 13:
                int num1;
                switch (dream)
                {
                    case 11:
                        num1 = 16;
                        break;
                    case 12:
                        num1 = 4;
                        break;
                    default:
                        num1 = 8;
                        break;
                }
                int num2 = num1;
                for (int index = 1; index < this.d_numSims; ++index)
                {
                    if ((this.getRelStateFlags((int)this.m_currentRelStates[index]) & num2) == 0)
                        return true;
                }
                return false;
            case 19:
                return this.getSimCareer(0) == -1;
            case 26:
                int itemCount = simWorld.getItemCount();
                for (int index = 0; index < itemCount; ++index)
                {
                    if (this.getInventoryCount(index) == 0 && (simWorld.getItemFlags(index) & 4) != 0)
                        return true;
                }
                return false;
            case 40:
                return simWorld.playerOwnsParentType(13) && !simWorld.playerOwnsObject(111) && (!simWorld.playerOwnsObject(110) && !simWorld.playerOwnsObject(112)) && !simWorld.playerOwnsObject(109);
            case 41:
                return simWorld.playerOwnsParentType(31) && !simWorld.playerOwnsObject(130) && !simWorld.playerOwnsObject(131);
            case 42:
                return this.m_money < 500;
            case 53:
            case 54:
                return this.getSimCareer(0) != -1 && this.getSimCareerLevel(0) < this.getCareerLevelCount(this.getSimCareer(0));
            default:
                return true;
        }
    }

    public int getDreamSlot(int dream)
    {
        return AppEngine.indexOf((sbyte)dream, this.m_promises);
    }

    public int getDream()
    {
        return (int)this.m_dream;
    }

    public int getPromise(int index)
    {
        return (int)this.m_promises[index];
    }

    public int getDreamDescString(int dream)
    {
        return dream < 0 || dream >= this.d_dreamDescStrings.Length ? 806 : (int)this.d_dreamDescStrings[dream];
    }

    public int getTaskCount()
    {
        return this.d_dreamDescStrings.Length;
    }

    public int getTaskFlags(int dream)
    {
        return (int)this.d_dreamFlags[dream];
    }

    public void dreamCompleteEvent(int dream)
    {
        AppEngine engine = this.m_engine;
        SceneGame sceneGame = engine.getSceneGame();
        bool flag = false;
        int dreamSlot = this.getDreamSlot(dream);
        if (dreamSlot != -1)
        {
            flag = true;
            this.m_promises[dreamSlot] = (sbyte)-1;
            sceneGame.awardAchievment(1);
        }
        else if ((int)this.m_dream == dream)
        {
            flag = true;
            dreamSlot = 4;
            this.m_dream = (sbyte)-1;
            this.m_dreamTimer = 0;
        }
        int flags = 0;
        switch (dream)
        {
            case 0:
                flags |= 4;
                break;
            case 1:
                flags |= 8;
                break;
            case 15:
                flags |= 128;
                break;
            case 16:
                flags |= 64;
                break;
            case 18:
                flags |= 256;
                break;
        }
        this.setAchievements(flags);
        int num1 = 0;
        int num2 = 0;
        int taskCount = this.getTaskCount();
        int personaFlags = this.getPersonaFlags();
        for (int dream1 = 0; dream1 < taskCount; ++dream1)
        {
            if ((this.getTaskFlags(dream1) & personaFlags) != 0)
            {
                int num3 = 1 << num1;
                if (dream == dream1 && (this.m_personaGoalsCompleted & num3) == 0)
                {
                    this.m_personaGoalsCompleted |= num3;
                    flag = true;
                }
                if ((this.m_personaGoalsCompleted & num3) != 0)
                    ++num2;
                ++num1;
            }
        }
        if (flag)
        {
            engine.setGoalCompleted(dream);
            sceneGame.showGoalCompleted(dream, dreamSlot);
            SpywareManager.getInstance().trackGoalComplete(dream);
        }
        if (num2 == num1)
        {
            this.setAchievements(1);
            switch (this.m_persona)
            {
                case 0:
                    sceneGame.awardAchievment(16);
                    break;
                case 1:
                    if (this.getSimCareer(0) == 2)
                    {
                        sceneGame.awardAchievment(15);
                        break;
                    }
                    break;
                case 2:
                    sceneGame.awardAchievment(14);
                    break;
            }
        }
        if (!engine.isBonusUnlocked())
        {
            int length = this.d_dreamDescStrings.Length;
            if (engine.getNumGoalsComplete() == length)
            {
                sceneGame.unlockBonus();
                sceneGame.awardAchievment(17);
            }
        }
        if (dream != 21)
            return;
        ++this.m_dreamFishCount;
        if (this.m_dreamFishCount > (short)15)
            this.dreamCompleteEvent(43);
        ++this.m_fishCaughtToday;
        if (this.m_fishCaughtToday < (byte)5)
            return;
        sceneGame.awardAchievment(8);
    }

    public void registerBuyFurninture(int type)
    {
        SimWorld simWorld = this.getSimWorld();
        switch (simWorld.getObjectParent(type))
        {
            case 5:
                this.dreamCompleteEvent(6);
                break;
            case 13:
                if (type != 108)
                {
                    this.dreamCompleteEvent(40);
                    if (simWorld.gotBetterTV())
                    {
                        this.m_engine.getScene().awardAchievment(6);
                        break;
                    }
                    break;
                }
                break;
            case 27:
                this.dreamCompleteEvent(5);
                break;
            case 31:
                if (type != 129)
                {
                    this.dreamCompleteEvent(41);
                    if (simWorld.gotBetterCouch())
                    {
                        this.m_engine.getScene().awardAchievment(6);
                        break;
                    }
                    break;
                }
                break;
        }
        if (simWorld.gotBestFurniture())
            this.dreamCompleteEvent(63);
        this.dreamCompleteEvent(20);
        if (this.m_soldSomething == (byte)0)
            return;
        this.m_engine.getScene().awardAchievment(4);
    }

    public void registerBuyItem(int type)
    {
        this.dreamCompleteEvent(20);
        if (type == 1)
            this.dreamCompleteEvent(2);
        if (type == 2)
            this.dreamCompleteEvent(3);
        if (type != 0)
            return;
        this.dreamCompleteEvent(4);
    }

    public void registerHarvest(int amount)
    {
        this.m_dreamHarvestCount += (short)amount;
        if (this.m_dreamHarvestCount <= (short)30)
            return;
        this.dreamCompleteEvent(44);
    }

    public bool registerWooHoo()
    {
        int[] woohooTimes = this.m_woohooTimes;
        int gameTimeAbs = this.getGameTimeAbs();
        int num1 = 0;
        int num2 = -1;
        for (int index = 0; index < 10; ++index)
        {
            int num3 = woohooTimes[index];
            if (gameTimeAbs - num3 > 1440)
            {
                woohooTimes[index] = -1;
                num3 = -1;
            }
            if (num3 == -1 && num2 == -1)
            {
                num2 = index;
                woohooTimes[index] = gameTimeAbs;
                num3 = gameTimeAbs;
            }
            if (num3 != -1)
                ++num1;
        }
        if (num2 == -1 || num1 >= 10)
            return true;
        if (num1 >= 8)
            this.dreamCompleteEvent(60);
        this.dreamCompleteEvent(52);
        return false;
    }

    public bool isPersonaGoalsCompleted(int index)
    {
        return (this.m_personaGoalsCompleted & 1 << index) != 0;
    }

    public bool isQuickLinkVisited(int type)
    {
        int objectQuickLinkIndex = this.getSimWorld().getObjectQuickLinkIndex(type);
        return objectQuickLinkIndex != -1 && (this.m_quickLinkFlags & 1 << objectQuickLinkIndex) != 0;
    }

    public void setQuickLinkVisited(int type)
    {
        int objectQuickLinkIndex = this.getSimWorld().getObjectQuickLinkIndex(type);
        if (objectQuickLinkIndex == -1)
            return;
        this.m_quickLinkFlags |= 1 << objectQuickLinkIndex;
    }

    public int getMotiveCount()
    {
        return this.d_motiveCount;
    }

    public short getMotiveDescString(int motive)
    {
        return this.d_motiveDescStrings[motive];
    }

    public short getMotiveHighAnim(int motive)
    {
        return this.d_motiveAnimHighs[motive];
    }

    public short getMotiveMidAnim(int motive)
    {
        return this.d_motiveAnimMids[motive];
    }

    public short getMotiveLowAnim(int motive)
    {
        return this.d_motiveAnimLows[motive];
    }

    public int getMotiveLevel(int motive)
    {
        return this.m_motiveLevelsF[motive];
    }

    public void setMotiveLevel(int motive, int level)
    {
        this.m_motiveLevelsF[motive] = level;
    }

    private void initMotives()
    {
        if (this.m_motiveLevelsF == null)
        {
            this.m_motiveLevelsF = new int[this.d_motiveCount];
            this.m_motiveDecaysF = new int[this.d_motiveCount];
            this.m_motiveDecayAdjustsF = new int[this.d_motiveCount];
            this.m_motiveDecayFactorsF = new int[this.d_motiveCount];
        }
        midp.JSystem.arraycopy((Array)this.d_motiveStartLevel, 0, (Array)this.m_motiveLevelsF, 0, this.d_motiveCount);
        midp.JSystem.arraycopy((Array)this.d_motiveDecayRate, 0, (Array)this.m_motiveDecaysF, 0, this.d_motiveCount);
        AppEngine.fillArray(this.m_motiveDecayAdjustsF, 0);
        AppEngine.fillArray(this.m_motiveDecayFactorsF, 65536);
        this.m_motiveTimer = 0;
    }

    private void updateMotives(int timeStep)
    {
        this.m_motiveTimer += timeStep;
        if (this.m_motiveTimer <= 500)
            return;
        this.m_motiveTimer -= 500;
        int[] motiveDecaysF = this.m_motiveDecaysF;
        int[] motiveDecayFactorsF = this.m_motiveDecayFactorsF;
        int[] motiveDecayAdjustsF = this.m_motiveDecayAdjustsF;
        for (int motive = 0; motive < this.d_motiveCount; ++motive)
        {
            int num = MathExt.Fmul(motiveDecayFactorsF[motive], motiveDecaysF[motive]);
            this.adjustMotiveLevel(motive, num + motiveDecayAdjustsF[motive] >> 1);
        }
    }

    public void adjustMotiveLevel(int motive, int change)
    {
        int a = change;
        if (this.hasSimGotTrait(0, 0) != -1 && motive == 4 && a > 0)
            a = MathExt.Fmul(a, 81920);
        else if (this.hasSimGotTrait(0, 1) != -1 && motive == 4 && a > 0)
            a = MathExt.Fmul(a, 49152);
        if (this.hasSimGotTrait(0, 4) != -1 && motive == 5 && a > 0)
            a = MathExt.Fmul(a, 81920);
        else if (this.hasSimGotTrait(0, 5) != -1 && motive == 5 && a > 0)
            a = MathExt.Fmul(a, 49152);
        if (this.hasSimGotTrait(0, 10) != -1 && motive == 0 && a > 0)
            a = MathExt.Fmul(a, 49152);
        else if (this.hasSimGotTrait(0, 11) != -1 && motive == 0 && a > 0)
            a = MathExt.Fmul(a, 81920);
        if (this.hasSimGotTrait(0, 10) != -1 && motive == 2 && a < 0)
            a = MathExt.Fmul(a, 49152);
        else if (this.hasSimGotTrait(0, 11) != -1 && motive == 2 && a < 0)
            a = MathExt.Fmul(a, 81920);
        if (this.hasSimGotTrait(0, 13) != -1 && motive == 3 && a > 0)
            a = MathExt.Fmul(a, 49152);
        else if (this.hasSimGotTrait(0, 12) != -1 && motive == 3 && a > 0)
            a = MathExt.Fmul(a, 81920);
        if (this.hasSimGotTrait(0, 7) != -1 && motive == 3 && a > 0)
            a = MathExt.Fmul(a, 49152);
        else if (this.hasSimGotTrait(0, 6) != -1 && motive == 3 && a > 0)
            a = MathExt.Fmul(a, 81920);
        if (this.hasSimGotTrait(0, 15) != -1 && motive == 5 && a > 0)
            a = MathExt.Fmul(a, 81920);
        else if (this.hasSimGotTrait(0, 14) != -1 && motive == 5 && a > 0)
            a = MathExt.Fmul(a, 49152);
        if (this.hasSimGotTrait(0, 2) != -1 && motive == 4 && a < 0)
            a = MathExt.Fmul(a, 81920);
        else if (this.hasSimGotTrait(0, 3) != -1 && motive == 4 && a < 0)
            a = MathExt.Fmul(a, 49152);
        int num;
        if (this.hasSimGotTrait(0, 9) != -1 && motive == 4 && a < 0)
            num = MathExt.Fmul(a, 81920);
        else if (this.hasSimGotTrait(0, 8) != -1 && motive == 4 && a < 0)
            num = MathExt.Fmul(a, 49152);
        int[] motiveLevelsF = this.m_motiveLevelsF;
        motiveLevelsF[motive] += change;
        motiveLevelsF[motive] = MathExt.clip(motiveLevelsF[motive], 0, 6553600);
    }

    private void adjustMotiveLevelWithBuffCheck(int motive, int change, int excludingBuff)
    {
        if (this.buffGetActiveSlot(excludingBuff) != -1)
            return;
        this.adjustMotiveLevel(motive, change);
    }

    public void setMotiveAdjust(int motive, int adjust)
    {
        this.m_motiveDecayAdjustsF[motive] = adjust;
    }

    public int getPlayerNeedFlags()
    {
        int num = 0;
        int[] motiveLevelsF = this.m_motiveLevelsF;
        short[] motiveTriggersNeeds = this.d_motiveTriggersNeeds;
        int[] triggersNeedLevels = this.d_motiveTriggersNeedLevels;
        for (int index = 0; index < motiveLevelsF.Length; ++index)
        {
            if (motiveLevelsF[index] < triggersNeedLevels[index])
                num |= (int)motiveTriggersNeeds[index];
        }
        return num;
    }

    private void initBuffs()
    {
        if (this.m_buffsActive == null)
        {
            this.m_buffsActive = new short[6];
            this.m_buffTimers = new int[6];
        }
        AppEngine.fillArray(this.m_buffsActive, (short)-1);
        AppEngine.fillArray(this.m_buffTimers, 0);
    }

    private void updateBuffs(int timeStep)
    {
        AppEngine engine = this.m_engine;
        short[] buffsActive = this.m_buffsActive;
        int[] buffTimers = this.m_buffTimers;
        sbyte[] dBuffFlags = this.d_buffFlags;
        int[] dBuffTimeouts = this.d_buffTimeouts;
        sbyte[] buffTimeoutChains = this.d_buffTimeoutChains;
        for (int slot = 0; slot < 6; ++slot)
        {
            int buff = (int)buffsActive[slot];
            if (buff != -1)
            {
                if (((int)dBuffFlags[buff] & 2) == 0 && !this.buffTriggerConditionsExist(buff))
                {
                    this.removeActiveBuff(buff);
                }
                else
                {
                    int num = dBuffTimeouts[buff] * 1000;
                    buffTimers[slot] += timeStep;
                    if (buffTimers[slot] > num)
                    {
                        buffTimers[slot] = num;
                        if (buffTimeoutChains[buff] != (sbyte)-1)
                            this.setBuff(slot, (int)buffTimeoutChains[buff]);
                        else if (!this.buffTriggerConditionsExist(buff))
                        {
                            this.removeActiveBuff(buff);
                        }
                        else
                        {
                            switch (buff)
                            {
                                case 2:
                                    SpywareManager.getInstance().trackEndGameDeath("starvation");
                                    engine.getSceneGame().killPlayer(1211);
                                    this.delayAlerts();
                                    return;
                                case 5:
                                    engine.getSceneGame().passOut();
                                    this.delayAlerts();
                                    this.setBuff(slot, 4);
                                    return;
                                case 10:
                                    this.adjustMotiveLevel(2, 3276800);
                                    this.removeActiveBuff(buff);
                                    SceneGame sceneGame = engine.getSceneGame();
                                    if (!sceneGame.isMapMode())
                                    {
                                        MapObjectSim playerSim = sceneGame.getPlayerSim();
                                        if (!playerSim.isReady())
                                            playerSim.interrupt();
                                        playerSim.queueSimAction(4, (MapObject)null, 0, 0);
                                    }
                                    this.delayAlerts();
                                    return;
                                default:
                                    continue;
                            }
                        }
                    }
                }
            }
        }
        int dBuffCount = this.d_buffCount;
        for (int index = 0; index < dBuffCount; ++index)
        {
            int buff = index;
            if (((int)dBuffFlags[buff] & 8) == 0 && this.buffTriggerConditionsExist(buff))
            {
                if (buff == 3 && (this.m_engine.getSceneGame().getPlayerSim().getSimPhase() == 54 || this.buffGetActiveSlot(6) != -1))
                    buff = 6;
                int activeSlot = this.buffGetActiveSlot(buff);
                if (activeSlot == -1)
                {
                    this.addActiveBuff(buff);
                    this.delayAlerts();
                    break;
                }
                if (buff == 6)
                    this.m_buffTimers[activeSlot] = 0;
            }
        }
    }

    private void applyBuffsToMood()
    {
        int[] moodLevelsF = this.m_moodLevelsF;
        AppEngine.fillArray(moodLevelsF, 0);
        for (int index1 = 0; index1 < 6; ++index1)
        {
            int index2 = (int)this.m_buffsActive[index1];
            if (index2 != -1)
            {
                sbyte[] numArray1 = this.d_buffEffectMood[index2];
                sbyte[] numArray2 = this.d_buffEffectMoodAmount[index2];
                int length = numArray1.Length;
                for (int index3 = 0; index3 < length; ++index3)
                    moodLevelsF[(int)numArray1[index3]] += (int)numArray2[index3] << 16;
            }
        }
        for (int index = 0; index < 2; ++index)
            moodLevelsF[index] = MathExt.clip(moodLevelsF[index], -6553600, 6553600);
        this.updateMood();
    }

    private void setBuff(int slot, int buff)
    {
        int buff1 = (int)this.m_buffsActive[slot];
        this.m_buffsActive[slot] = (short)buff;
        this.m_buffTimers[slot] = 0;
        MapObjectSim playerSim = this.m_engine.getSceneGame().getPlayerSim();
        playerSim.endBuff(buff1);
        playerSim.startBuff(buff);
        sbyte[][] buffEffectMotive = this.d_buffEffectMotive;
        int[][] effectMotiveFactors = this.d_buffEffectMotiveFactors;
        int[] motiveDecayFactorsF = this.m_motiveDecayFactorsF;
        if (buff1 != -1)
        {
            for (int index = 0; index < buffEffectMotive[buff1].Length; ++index)
                motiveDecayFactorsF[(int)buffEffectMotive[buff1][index]] += effectMotiveFactors[buff1][index];
        }
        if (buff != -1)
        {
            for (int index = 0; index < buffEffectMotive[buff].Length; ++index)
                motiveDecayFactorsF[(int)buffEffectMotive[buff][index]] -= effectMotiveFactors[buff][index];
            switch (buff)
            {
                case 3:
                    this.removeActiveBuff(6);
                    this.removeActiveBuff(7);
                    break;
                case 6:
                    this.removeActiveBuff(3);
                    this.removeActiveBuff(7);
                    break;
                case 9:
                    this.removeActiveBuff(8);
                    break;
            }
            SceneGame sceneGame = this.m_engine.getSceneGame();
            if (buff == 2)
                sceneGame.showMessageBox(1210, 579);
            else if (buff == 1)
                sceneGame.showTutorialMessage(14);
            else if (buff == 4)
                sceneGame.showTutorialMessage(15);
            else if (buff == 5)
                sceneGame.showTutorialMessage(16);
            else if (buff == 10)
                sceneGame.showTutorialMessage(17);
            else if (buff == 9)
                sceneGame.showTutorialMessage(18);
            else if (buff == 11)
                sceneGame.showTutorialMessage(19);
            else if (buff == 12)
                sceneGame.showTutorialMessage(20);
        }
        this.applyBuffsToMood();
    }

    private void addActiveBuff(int buff)
    {
        int dBuffTime = (int)this.d_buffTimes[buff];
        if (dBuffTime != -1)
            this.m_timeRanges[dBuffTime] = -1;
        int slot = AppEngine.indexOf((short)-1, this.m_buffsActive);
        AppEngine.ASSERT(slot != -1, "no free buff slots");
        this.setBuff(slot, buff);
    }

    private void removeActiveBuff(int buff)
    {
        int dBuffTime = (int)this.d_buffTimes[buff];
        if (dBuffTime != -1)
            this.m_timeRanges[dBuffTime] = this.getGameTimeAbs();
        int slot = AppEngine.indexOf((short)buff, this.m_buffsActive);
        if (slot == -1)
            return;
        this.setBuff(slot, -1);
    }

    private bool buffTriggerConditionsExist(int buff)
    {
        int buffTimeoutChain = (int)this.d_buffTimeoutChains[buff];
        if (buffTimeoutChain != -1 && this.buffGetActiveSlot(buffTimeoutChain) != -1)
            return false;
        int[] motiveLevelsF = this.m_motiveLevelsF;
        sbyte[] buffTriggerMotive = this.d_buffTriggerMotives[buff];
        int[] triggerMotiveLevel = this.d_buffTriggerMotiveLevels[buff];
        int length = buffTriggerMotive.Length;
        if (length == 0)
            return true;
        for (int index1 = 0; index1 < length; ++index1)
        {
            int index2 = (int)buffTriggerMotive[index1];
            int num1 = triggerMotiveLevel[index1];
            int num2 = motiveLevelsF[index2];
            if (num1 > 0 && num2 > num1 || num1 < 0 && num2 < -num1)
                return true;
        }
        return false;
    }

    public int buffGetActiveSlot(int buff)
    {
        short[] buffsActive = this.m_buffsActive;
        for (int index = 0; index < 6; ++index)
        {
            if ((int)buffsActive[index] == buff)
                return index;
        }
        return -1;
    }

    public int getBuffsNumActive()
    {
        return this.m_buffsActive.Length - AppEngine.countOf(-1, this.m_buffsActive);
    }

    public int getBuff(int index)
    {
        return (int)this.m_buffsActive[index];
    }

    public int getBuffTimer(int index)
    {
        return this.m_buffTimers[index];
    }

    public int getBuffDescString(int buff)
    {
        return (int)this.d_buffDescStringIds[buff];
    }

    public int getBuffFlags(int buff)
    {
        return (int)this.d_buffFlags[buff];
    }

    public int getTraitCount()
    {
        return 17;
    }

    public short getTraitDescString(int trait)
    {
        return this.d_traitDescStrings[trait];
    }

    public int getTraitExclude(int trait)
    {
        return (int)this.d_traitExcludes[trait];
    }

    private void initMoods()
    {
        if (this.m_moodLevelsF == null)
            this.m_moodLevelsF = new int[4];
        AppEngine.fillArray(this.m_moodLevelsF, 1638400);
    }

    private void updateMood()
    {
        int[] moodLevelsF = this.m_moodLevelsF;
        int minValue = int.MinValue;
        int num1 = -1;
        int maxValue = int.MaxValue;
        for (int index = 0; index < 4; ++index)
        {
            if (moodLevelsF[index] > minValue)
                minValue = moodLevelsF[index];
            if (moodLevelsF[index] < maxValue)
            {
                num1 = index;
                maxValue = moodLevelsF[index];
            }
        }
        int num2 = 3;
        int num3 = minValue;
        if (maxValue < -655360)
        {
            if (maxValue < -3276800)
            {
                switch (num1)
                {
                    case 0:
                        num2 = 5;
                        break;
                    case 1:
                        num2 = 7;
                        break;
                    case 2:
                        num2 = 9;
                        break;
                    case 3:
                        num2 = 11;
                        break;
                    default:
                        AppEngine.ASSERT(false, "invalid mood");
                        num2 = 5;
                        break;
                }
            }
            else
            {
                switch (num1)
                {
                    case 0:
                        num2 = 4;
                        break;
                    case 1:
                        num2 = 6;
                        break;
                    case 2:
                        num2 = 8;
                        break;
                    case 3:
                        num2 = 10;
                        break;
                    default:
                        AppEngine.ASSERT(false, "invalid mood");
                        num2 = 4;
                        break;
                }
            }
            num3 = maxValue;
        }
        else if (minValue > 655360)
        {
            num2 = minValue <= 4915200 ? (minValue <= 2621440 ? 2 : 1) : 0;
            num3 = minValue;
        }
        this.m_moodDesc = num2;
        this.m_moodLevel = num3;
    }

    public int getMoodDesc()
    {
        return this.m_moodDesc;
    }

    public int getMoodDescStringId()
    {
        return (int)SimData.MOODDESC_STRINGS[this.m_moodDesc];
    }

    public int getMoodLevel()
    {
        return this.m_moodLevel;
    }

    public int getMoodFaceFrame()
    {
        return 4 - (this.m_moodLevel - -6553600) / 2621440;
    }

    private void initRelationships()
    {
        int dNumSims = this.d_numSims;
        if (this.m_currentRelStates == null)
        {
            sbyte[] numArray1 = new sbyte[dNumSims];
            short[] numArray2 = new short[dNumSims];
            int[][] numArray3 = new int[dNumSims][];
            int[][] numArray4 = new int[dNumSims][];
            short[][] numArray5 = new short[dNumSims][];
            sbyte[][] numArray6 = new sbyte[dNumSims][];
            for (int index = 1; index < dNumSims; ++index)
            {
                numArray3[index] = new int[this.d_numRelLevels];
                numArray4[index] = new int[this.d_commodityStringIds.Length];
                numArray5[index] = new short[10];
                numArray6[index] = new sbyte[this.d_simTraits[index].Length];
            }
            this.m_currentRelStates = numArray1;
            this.m_currentRelStateFlags = numArray2;
            this.m_currentRelLevelsF = numArray3;
            this.m_commodityLevelsF = numArray4;
            this.m_actionHistories = numArray5;
            this.m_knownTraits = numArray6;
        }
        for (int index = 1; index < dNumSims; ++index)
        {
            this.m_currentRelStates[index] = (sbyte)0;
            this.m_currentRelStateFlags[index] = (short)0;
            AppEngine.fillArray(this.m_currentRelLevelsF[index], 0);
            AppEngine.fillArray(this.m_actionHistories[index], (short)-1);
            AppEngine.fillArray(this.m_knownTraits[index], (sbyte)0);
        }
        this.m_commodityTimer = 0;
        this.m_lastNPC = -1;
        this.m_lastNPCTimer = 0;
    }

    private void updateRelationships(int timeStep)
    {
        if (this.m_lastNPCTimer < 10000)
        {
            this.m_lastNPCTimer += this.m_engine.getSceneGame().getNormalTimeStep();
            if (this.m_lastNPCTimer >= 10000)
                this.m_lastNPC = -1;
        }
        this.m_commodityTimer += timeStep;
        if (this.m_commodityTimer > 3000)
            this.m_commodityTimer = 0;
        int dNumSims = this.d_numSims;
        for (int index = 1; index < dNumSims; ++index)
        {
            this.checkRelationshipTriggers(index);
            if (this.m_commodityTimer == 0)
            {
                int dominantCommodity1 = this.getDominantCommodity(index);
                this.decayCommodities(index, 327680);
                int dominantCommodity2 = this.getDominantCommodity(index);
                if (this.m_lastNPC == index && this.m_lastNPCTimer < 10000 && dominantCommodity1 != dominantCommodity2)
                {
                    this.m_engine.getTextManager().dynamicString(-12, (int)this.d_commodityStringIds[dominantCommodity2], this.getSimName(index));
                    this.m_engine.getSceneGame().showTickerMessage(-12, -1);
                }
            }
        }
    }

    public void setLastNPC(int simId)
    {
        this.m_lastNPC = simId;
        this.m_lastNPCTimer = 0;
    }

    public int getLastNPC()
    {
        return this.m_lastNPC;
    }

    public bool isLastNPCStillRelevant()
    {
        return this.m_lastNPCTimer < 10000;
    }

    private void decayCommodities(int sim, int amount)
    {
        int[] numArray = this.m_commodityLevelsF[sim];
        for (int index = 0; index < numArray.Length; ++index)
        {
            numArray[index] -= amount;
            if (numArray[index] < 0)
                numArray[index] = 0;
        }
    }

    private bool checkRelationshipStranger(int toSim)
    {
        if (this.m_currentRelStates[toSim] != (sbyte)0)
            return false;
        int toState = 1;
        if (this.m_currentRelLevelsF[toSim][0] < 0)
            toState = 2;
        this.relationshipStateTransition(toSim, toState);
        return true;
    }

    public void adjustRelLevels(int sim, int friendship, int romance)
    {
        int a1 = friendship << 16;
        int a2 = romance << 16;
        if (this.hasSimGotTrait(0, 0) != -1 && a1 > 0)
            a1 = MathExt.Fmul(a1, 49152);
        else if (this.hasSimGotTrait(0, 1) != -1 && a1 > 0)
            a1 = MathExt.Fmul(a1, 81920);
        if (this.hasSimGotTrait(0, 13) != -1 && a2 > 0)
            a2 = MathExt.Fmul(a2, 81920);
        else if (this.hasSimGotTrait(0, 12) != -1 && a2 > 0)
            a2 = MathExt.Fmul(a2, 49152);
        int[] numArray = this.m_currentRelLevelsF[sim];
        int num1 = numArray[0] + a1;
        int num2 = numArray[1] + a2;
        numArray[0] = MathExt.clip(num1, -1966080, 1966080);
        numArray[1] = MathExt.clip(num2, -327680, 1966080);
    }

    private bool checkRelationshipTriggers(int sim)
    {
        int currentRelState = (int)this.m_currentRelStates[sim];
        int[] numArray = this.m_currentRelLevelsF[sim];
        sbyte[] stateTriggerToState = this.d_relStateTriggerToStates[currentRelState];
        sbyte[] stateTriggerLevel = this.d_relStateTriggerLevels[currentRelState];
        short[] triggerLevelValue = this.d_relStateTriggerLevelValues[currentRelState];
        int length = stateTriggerToState.Length;
        for (int index1 = 0; index1 < length; ++index1)
        {
            bool flag1 = true;
            int index2 = (int)stateTriggerLevel[index1];
            int num1 = (int)triggerLevelValue[index1];
            int num2 = numArray[index2];
            bool flag2 = num1 < 0;
            int num3 = num1 << 16;
            if (flag2 && num2 > num3 || !flag2 && num2 < num3)
                flag1 = false;
            if (flag1)
            {
                int toState = (int)stateTriggerToState[index1];
                if (toState == 1 && numArray[0] < 0)
                    toState = 2;
                this.relationshipStateTransition(sim, toState);
                return true;
            }
        }
        return false;
    }

    private void relationshipStateTransition(int sim, int toState)
    {
        sbyte[] currentRelStates = this.m_currentRelStates;
        int state = (int)currentRelStates[sim];
        currentRelStates[sim] = (sbyte)toState;
        AppEngine.fillArray(this.m_currentRelLevelsF[sim], 0);
        if (state == 0)
            this.dreamCompleteEvent(10);
        if (toState == 12)
            this.dreamCompleteEvent(64);
        if ((this.getRelStateFlags(state) & 16) == 0 && (this.getRelStateFlags(toState) & 16) != 0)
        {
            this.dreamCompleteEvent(11);
            if (this.getRequirementValue(3) >= 3)
                this.m_engine.getScene().awardAchievment(5);
            ++this.numFriendships;
        }
        if ((this.getRelStateFlags(state) & 8) == 0 && (this.getRelStateFlags(toState) & 8) != 0)
            this.dreamCompleteEvent(13);
        if ((this.getRelStateFlags(state) & 4) == 0 && (this.getRelStateFlags(toState) & 4) != 0)
            this.dreamCompleteEvent(12);
        if (AppEngine.indexOf((sbyte)0, currentRelStates, 1) == -1)
            this.dreamCompleteEvent(49);
        int num = 0;
        bool flag1 = true;
        bool flag2 = true;
        for (int index1 = 1; index1 < currentRelStates.Length; ++index1)
        {
            int index2 = (int)currentRelStates[index1];
            flag1 = flag1 && ((int)this.d_relStateFlags[index2] & 1) != 0;
            flag2 = flag2 && ((int)this.d_relStateFlags[index2] & 2) != 0;
            if (((int)this.d_relStateFlags[index2] & 4) != 0)
                ++num;
        }
        if (flag1)
            this.dreamCompleteEvent(65);
        if (flag2)
            this.dreamCompleteEvent(66);
        if (num >= 3)
            this.dreamCompleteEvent(59);
        if (toState == 12)
        {
            this.m_engine.getTextManager().dynamicString(-11, 643, (int)this.d_simNameStrings[sim]);
            this.m_engine.getSceneGame().showMessageBox(-11, this.getRelStateDescString(toState), 9);
        }
        else
        {
            this.m_engine.getTextManager().dynamicString(-11, (int)this.d_relStateToStrings[toState], (int)this.d_simNameStrings[sim]);
            this.m_engine.getSceneGame().showMessageBox(-11, this.getRelStateDescString(toState));
        }
    }

    private bool actionEffectEvent(int toSim, int action, int effectFlags)
    {
        SceneGame sceneGame = this.m_engine.getSceneGame();
        int currentRelState = (int)this.m_currentRelStates[toSim];
        int toState = -1;
        switch (action)
        {
            case 89:
                AppEngine.ASSERT(currentRelState == 10, "non-partners becoming fiancees");
                toState = 11;
                break;
            case 90:
                AppEngine.ASSERT(currentRelState == 11, "non-fiancees getting married");
                toState = 12;
                break;
            case 100:
                AppEngine.ASSERT(currentRelState == 9 || currentRelState == 10 || currentRelState == 11, "non-date/partner/fiancee breakup");
                toState = 14;
                break;
            case 101:
                AppEngine.ASSERT(currentRelState == 12, "non-spouse getting divorced");
                toState = 13;
                break;
            case 102:
                this.setSimCurRelStateFlags(toSim, 2);
                sceneGame.showMessageBox(1168, 1167);
                break;
            case 103:
                this.unsetSimCurRelStateFlags(toSim, 2);
                sceneGame.showMessageBox(1169, 1164);
                break;
            case 104:
                if ((effectFlags & 16384) != 0)
                {
                    sceneGame.showMessageBox(956, this.getSimName(toSim));
                    break;
                }
                int dSimCareer = (int)this.d_simCareers[0];
                int dSimCareerLevel = (int)this.d_simCareerLevels[0];
                if (dSimCareerLevel < this.d_careerLevelFlags[dSimCareer].Length - 1)
                {
                    sceneGame.showJobOffer(dSimCareer, dSimCareerLevel + 1, false);
                    break;
                }
                break;
            case 105:
                sceneGame.showQuitJob();
                break;
        }
        if (toState == -1)
            return false;
        this.relationshipStateTransition(toSim, toState);
        return true;
    }

    public static int responseToFeedbackAnim(int response)
    {
        return (int)SimData.RESPONSE_ANIMS[response & 15];
    }

    public void relationshipAction(int[] result, int fromSim, int toSim, int action)
    {
        SceneGame sceneGame = this.m_engine.getSceneGame();
        int num1 = 0;
        int num2 = -1;
        int num3 = -1;
        int effectFlags = 0;
        bool flag1 = false;
        int dActionFlag = this.d_actionFlags[action];
        if (toSim == 0)
        {
            if ((dActionFlag & 1048576) == 0)
            {
                if (action == 23)
                {
                    num1 = 35;
                    num2 = 14;
                }
                else
                {
                    num1 = 19;
                    num2 = 13;
                }
            }
            this.setSimCurRelStateFlags(fromSim, 1);
            this.setSimCurRelStateFlags(0, 1);
            if (this.checkRelationshipStranger(fromSim))
                flag1 = true;
        }
        else if (fromSim != 0)
        {
            if ((dActionFlag & 1048576) == 0)
            {
                num1 = 20;
                num2 = 13;
            }
        }
        else
        {
            int index1 = this.calcActionEffect(toSim, action);
            if (index1 == -1)
            {
                num2 = (dActionFlag & 4194304) == 0 ? -1 : -1;
            }
            else
            {
                bool flag2 = false;
                int trait = (int)this.d_actionConditionTraits[action][index1];
                if (trait != -1)
                    flag2 = this.tryDiscoverTrait(toSim, trait);
                short[] actionHistory = this.m_actionHistories[toSim];
                for (int index2 = 9; index2 > 0; --index2)
                    actionHistory[index2] = actionHistory[index2 - 1];
                actionHistory[0] = (short)action;
                if ((dActionFlag & 32) != 0)
                {
                    this.unsetSimCurRelStateFlags(toSim, 1);
                }
                else
                {
                    this.setSimCurRelStateFlags(toSim, 1);
                    this.setSimCurRelStateFlags(0, 1);
                }
                num2 = (int)this.d_actionResponseActions[action][index1];
                bool flag3 = true;
                MapObjectSim sim = sceneGame.findSim(toSim);
                if (num2 == -1 && sim != null && sim.isSleeping())
                    flag3 = false;
                int num4 = 0;
                if (flag3)
                {
                    int friendship = (int)this.d_actionAffectFriendships[action][index1];
                    int romance = (int)this.d_actionAffectRomances[action][index1];
                    this.adjustRelLevels(toSim, friendship, romance);
                    num4 = friendship + romance;
                    if (romance > 0)
                        num1 |= 64;
                    int dominantCommodity1 = this.getDominantCommodity(toSim);
                    int index2 = (int)this.d_actionAffectCommodities[action][index1];
                    int num5 = (int)this.d_actionAffectCommodityAmounts[action][index1];
                    int[] numArray = this.m_commodityLevelsF[toSim];
                    for (int index3 = 0; index3 < numArray.Length; ++index3)
                    {
                        if (index3 == index2)
                        {
                            int num6 = num5 << 16;
                            numArray[index2] += num6;
                            if (numArray[index2] > 13107200)
                                numArray[index2] = 13107200;
                        }
                        else
                        {
                            numArray[index3] -= 655360;
                            if (numArray[index3] < 0)
                                numArray[index3] = 0;
                        }
                    }
                    int dominantCommodity2 = this.getDominantCommodity(toSim);
                    if (dominantCommodity2 != dominantCommodity1 && !flag2)
                    {
                        this.m_engine.getTextManager().dynamicString(-12, (int)this.d_commodityStringIds[dominantCommodity2], this.getSimName(toSim));
                        sceneGame.showTickerMessage(-12, -1);
                        if (dominantCommodity2 == 1 || dominantCommodity2 == 2 || dominantCommodity2 == 8)
                        {
                            this.dreamCompleteEvent(15);
                            this.setSimCurRelStateFlags(toSim, 16384);
                        }
                        if (dominantCommodity2 == 2)
                        {
                            this.dreamCompleteEvent(16);
                            if (this.getAchievements(256))
                                this.m_engine.getScene().awardAchievment(7);
                            this.setSimCurRelStateFlags(toSim, 64);
                        }
                        if (dominantCommodity2 == 1)
                        {
                            this.dreamCompleteEvent(17);
                            this.setSimCurRelStateFlags(toSim, 128);
                            bool flag4 = true;
                            for (int simId = 1; simId <= 13; ++simId)
                                flag4 = flag4 && this.getSimCurRelStateFlags(simId, 128);
                            if (flag4)
                                this.m_engine.getScene().awardAchievment(11);
                        }
                    }
                }
                effectFlags = this.d_actionEffectFlags[action][index1];
                if ((effectFlags & 8) != 0)
                {
                    if (this.actionEffectEvent(toSim, action, effectFlags))
                        flag1 = true;
                }
                else if (action == 104)
                {
                    int dSimCareer = (int)this.d_simCareers[0];
                    int dSimCareerLevel = (int)this.d_simCareerLevels[0];
                    if (dSimCareerLevel < this.d_careerLevelFlags[dSimCareer].Length - 1)
                        sceneGame.showJobRaiseFail(dSimCareer, dSimCareerLevel + 1);
                }
                if (this.checkRelationshipTriggers(toSim))
                    flag1 = true;
                else if ((dActionFlag & 4194304) == 0 && action != 110 && this.checkRelationshipStranger(toSim))
                    flag1 = true;
                if (flag1)
                    num3 = (int)this.d_relStateEffectAnims[(int)this.m_currentRelStates[toSim]];
                int num7;
                if (num3 != -1)
                {
                    num7 = num1 | 3;
                }
                else
                {
                    int num5 = MathExt.clip(3 + num4, 0, 6);
                    num7 = num1 | num5;
                }
                num1 = num7 >= 3 ? num7 | 16 : num7 | 32;
            }
        }
        if (num2 != -1)
        {
            int simId = -1;
            if (fromSim == 0)
                simId = toSim;
            else if (toSim == 0)
                simId = fromSim;
            if (simId != -1)
            {
                this.adjustMotiveLevel(4, 1310720);
                this.setLastNPC(simId);
            }
        }
        if (fromSim == 0 && (effectFlags & 32768) != 0)
            this.questCheckTriggers(toSim, action, !flag1);
        result[0] = num1;
        result[1] = num2;
        result[2] = num3;
    }

    public int getRelStateDescString(int state)
    {
        return (int)this.d_relStateDescStrings[state];
    }

    public int getRelStateFlags(int state)
    {
        return (int)this.d_relStateFlags[state];
    }

    public int getRelState(int sim)
    {
        return (int)this.m_currentRelStates[sim];
    }

    public void getRelationshipLevels(int sim, int[] result)
    {
        int relState = this.getRelState(sim);
        int[] numArray = this.m_currentRelLevelsF[sim];
        sbyte[] stateTriggerToState = this.d_relStateTriggerToStates[relState];
        sbyte[] stateTriggerLevel = this.d_relStateTriggerLevels[relState];
        short[] triggerLevelValue = this.d_relStateTriggerLevelValues[relState];
        int index1 = 0;
        int length = stateTriggerToState.Length;
        for (int index2 = 0; index2 < length; ++index2)
        {
            int index3 = (int)stateTriggerLevel[index2];
            int num1 = (int)triggerLevelValue[index2];
            int num2 = numArray[index3] >> 16;
            if (num1 > 0 && num2 > 0 || num1 < 0 && num2 < 0)
            {
                result[index1] = (int)stateTriggerToState[index2];
                result[index1 + 1] = MathExt.Fdiv(num2 << 16, num1 << 16);
                index1 += 2;
            }
        }
        result[index1] = -1;
    }

    public bool isWelcome()
    {
        if (!this.m_engine.getSceneGame().isHouseMode())
            return true;
        int houseId = this.getSimWorld().getHouseId();
        int simCount = this.getSimCount();
        for (int sim = 1; sim < simCount; ++sim)
        {
            if (this.getSimHome(sim) == houseId && (this.getRelStateFlags(this.getRelState(sim)) & 32) != 0)
                return true;
        }
        return houseId == 0;
    }

    private void clearAllRelStateFlags(int flags)
    {
        for (int index = 1; index < this.d_numSims; ++index)
            this.m_currentRelStateFlags[index] &= (short)~flags;
    }

    private int countHouseRelStateFlags(int flags)
    {
        bool flag1 = true;
        int num = 0;
        for (int sim = this.d_numSims - 1; sim >= 1; --sim)
        {
            int simHome = this.getSimHome(sim);
            if (simHome != 0)
            {
                bool flag2 = ((int)this.m_currentRelStateFlags[sim] & flags) != 0;
                flag1 = flag1 && flag2;
                if (flag2 && AppEngine.indexOf((short)simHome, this.d_simHomes, sim + 1) == -1)
                    ++num;
            }
        }
        return flag1 ? -1 : num;
    }

    public void setHouseCurRelStateFlags(int house, int flags)
    {
        for (int index = 1; index < this.d_numSims; ++index)
        {
            if ((int)this.d_simHomes[index] == house)
                this.m_currentRelStateFlags[index] |= (short)flags;
        }
        int num = this.countHouseRelStateFlags(flags);
        if (num == -1)
        {
            switch (flags)
            {
                case 4:
                    this.dreamCompleteEvent(55);
                    break;
                case 8:
                    this.dreamCompleteEvent(56);
                    break;
                case 16:
                    this.dreamCompleteEvent(69);
                    break;
            }
        }
        if (flags != 512 && flags != 1024)
            return;
        if (num == -1)
        {
            this.dreamCompleteEvent(51);
        }
        else
        {
            int flags1 = flags == 512 ? 1024 : 512;
            if (num + this.countHouseRelStateFlags(flags1) < 3)
                return;
            this.dreamCompleteEvent(51);
        }
    }

    public void setSimCurRelStateFlags(int simId, int flags)
    {
        this.m_currentRelStateFlags[simId] |= (short)flags;
        int num = AppEngine.countOfFlags(flags, this.m_currentRelStateFlags, 0);
        switch (flags)
        {
            case 32:
                AppEngine.ASSERT(((int)this.m_currentRelStateFlags[0] & flags) == 0, "player shouldn't have slap flag");
                if (num < 4)
                    break;
                this.dreamCompleteEvent(67);
                break;
            case 64:
                AppEngine.ASSERT(((int)this.m_currentRelStateFlags[0] & flags) == 0, "player shouldn't have insulted flag");
                if (num < 5)
                    break;
                this.dreamCompleteEvent(68);
                break;
            case 128:
                AppEngine.ASSERT(((int)this.m_currentRelStateFlags[0] & flags) == 0, "player shouldn't have creeped flag");
                if (num < 5)
                    break;
                this.dreamCompleteEvent(57);
                break;
            case 256:
                AppEngine.ASSERT(((int)this.m_currentRelStateFlags[0] & flags) == 0, "player shouldn't have watch flag");
                if (num < 3)
                    break;
                this.dreamCompleteEvent(58);
                break;
        }
    }

    private void unsetSimCurRelStateFlags(int simId, int flags)
    {
        this.m_currentRelStateFlags[simId] &= (short)~flags;
    }

    public bool getSimCurRelStateFlags(int simId, int flags)
    {
        return ((int)this.m_currentRelStateFlags[simId] & flags) != 0;
    }

    public int getRelationshipNthCount()
    {
        AppEngine.ASSERT(true, "stranger should be 0");
        AppEngine.ASSERT(this.m_currentRelStates[0] == (sbyte)0, "player rel state should be stranger");
        return this.m_currentRelStates.Length - AppEngine.countOf(0, this.m_currentRelStates);
    }

    public int getRelationshipNthItem(int index)
    {
        return AppEngine.indexOfNthElement(index, this.m_currentRelStates, 0);
    }

    public int getActionCount()
    {
        return this.d_numActions;
    }

    public void unlockAction(int action, int packId)
    {
        this.d_actionFlags[action] &= -134217729;
        this.m_unlockedActionPackIds[action] = (short)packId;
    }

    public int getActionPackId(int action)
    {
        return action >= 0 && action < this.m_unlockedActionPackIds.Length ? (int)this.m_unlockedActionPackIds[action] : -1;
    }

    public int getActionWorldArg(int action)
    {
        return (int)this.d_actionWorldArgs[action];
    }

    public int getActionString(int action)
    {
        return (int)this.d_actionStringIds[action];
    }

    public int getActionFlags(int action)
    {
        return this.d_actionFlags[action];
    }

    public int getActionPhaseCount(int action)
    {
        return this.d_actionPhases[action].Length;
    }

    public int getActionPhase(int action, int phaseIndex)
    {
        return (int)this.d_actionPhases[action][phaseIndex];
    }

    public void createContextMenu(MapObject target, int[] menu, int[] actions)
    {
        if (target.getFlag(8192) && target.getType() != 0)
            this.createSimContextMenu((MapObjectSim)target, menu, actions);
        else
            this.createObjectContextMenu(target, menu, actions);
    }

    private void createSimContextMenu(MapObjectSim target, int[] menu, int[] actions)
    {
        int dNumActions = this.d_numActions;
        short[] dActionStringIds = this.d_actionStringIds;
        int[] dActionFlags = this.d_actionFlags;
        int id = target.getId();
        bool flag1 = target.isSleeping();
        this.setLastNPC(id);
        int dSimNameString = (int)this.d_simNameStrings[id];
        AppEngine.menuClear(menu, dSimNameString);
        AppEngine.menuClear(actions, dSimNameString);
        if (this.m_engine.getSceneGame().isMapMode())
        {
            int index = 165;
            AppEngine.menuAppendItem(menu, (int)dActionStringIds[index]);
            AppEngine.menuAppendItem(actions, index);
        }
        else
        {
            for (int action = 0; action < dNumActions; ++action)
            {
                if ((dActionFlags[action] & 2) != 0 && ((dActionFlags[action] & 8) != 0 || !flag1) && (((dActionFlags[action] & 8) == 0 || flag1) && dActionStringIds[action] != (short)8))
                {
                    bool flag2 = true;
                    int num = dActionFlags[action];
                    if (flag2)
                    {
                        if ((num & 16) != 0)
                            flag2 = !this.getSimCurRelStateFlags(id, 1);
                        else if ((num & 32) != 0)
                            flag2 = this.getSimCurRelStateFlags(id, 1);
                    }
                    if ((num & 33554432) != 0)
                    {
                        int personaActionFlags = this.getPersonaActionFlags();
                        flag2 = (num & personaActionFlags) != 0;
                    }
                    if (flag2)
                        flag2 = this.calcActionEffect(id, action) != -1;
                    if (flag2)
                    {
                        int simCareer = this.getSimCareer(0);
                        if ((num & 32768) != 0)
                            flag2 = simCareer != -1 && this.getCareerBoss(simCareer) == id;
                        if (flag2 && (num & 65536) != 0)
                            flag2 = simCareer != -1 && this.getSimCareer(id) == simCareer;
                    }
                    if (flag2)
                    {
                        int houseId = this.getSimWorld().getHouseId();
                        int simHome = this.getSimHome(id);
                        if ((num & 393216) == 393216)
                            flag2 = this.getSimCurRelStateFlags(id, 2);
                        else if ((num & 131072) != 0)
                            flag2 = houseId == 0 && simHome != 0;
                        else if ((num & 262144) != 0)
                            flag2 = houseId != 0 && simHome == houseId;
                    }
                    if (flag2 && (num & 16777216) != 0)
                    {
                        int questForActionFinish = this.getQuestForActionFinish(action);
                        flag2 = (int)this.m_questSims[questForActionFinish] == id && this.questConditionsSatisfied(questForActionFinish);
                    }
                    if (flag2)
                    {
                        if ((num & 268435456) != 0)
                            flag2 = this.isSimMale(0);
                        else if ((num & 536870912) != 0)
                            flag2 = !this.isSimMale(0);
                    }
                    if (flag2)
                        flag2 = (num & 134217728) == 0;
                    if (flag2)
                    {
                        switch (action)
                        {
                            case 89:
                                flag2 = AppEngine.indexOf((sbyte)12, this.m_currentRelStates) == -1;
                                break;
                            case 99:
                                MapObjectSim playerSim = this.m_engine.getSceneGame().getPlayerSim();
                                flag2 = midp.JMath.abs(target.getPosX() - playerSim.getPosX()) + midp.JMath.abs(target.getPosZ() - playerSim.getPosZ()) > 8388608;
                                break;
                            case 102:
                                flag2 = AppEngine.indexOfFlags(2, this.m_currentRelStateFlags) == -1;
                                break;
                            case 103:
                                flag2 = this.m_currentRelStates[id] != (sbyte)12;
                                break;
                        }
                    }
                    if (flag2)
                    {
                        AppEngine.menuAppendItem(menu, (int)dActionStringIds[action]);
                        AppEngine.menuAppendItem(actions, action);
                    }
                }
            }
        }
    }

    private void createObjectContextMenu(MapObject target, int[] menu, int[] actions)
    {
        MapObjectSim playerSim = this.m_engine.getSceneGame().getPlayerSim();
        short[] dActionStringIds = this.d_actionStringIds;
        int[] dActionFlags = this.d_actionFlags;
        int typeString = target.getTypeString();
        AppEngine.menuClear(menu, typeString);
        AppEngine.menuClear(actions, typeString);
        int type = target.getType();
        SimWorld simWorld = this.getSimWorld();
        short[] objectActions = simWorld.getObjectActions(type);
        int objectFlags = simWorld.getObjectFlags(type);
        int length = objectActions.Length;
        if ((objectFlags & 33554432) != 0 && target.getRuntimeFlag(256))
        {
            AppEngine.menuAppendItem(menu, (int)dActionStringIds[115]);
            AppEngine.menuAppendItem(actions, 115);
        }
        for (int index1 = 0; index1 < length; ++index1)
        {
            int index2 = (int)objectActions[index1];
            AppEngine.ASSERT(dActionStringIds[index2] != (short)8, "invalid action");
            int num = dActionFlags[index2];
            if ((num & 2) == 0 && ((num & 64) == 0 || target.getRuntimeFlag(64)) && (((num & 128) == 0 || !target.getRuntimeFlag(64)) && ((num & 256) == 0 || target.isIdle())) && (((num & 512) == 0 || target.isActive()) && ((num & 1024) == 0 || !target.getRuntimeFlag(256)) && (((num & 2048) == 0 || !target.getRuntimeFlag(512)) && ((num & 8192) == 0 || this.isPlaceForWork(target, 0)))) && (((num & 16384) == 0 || this.isTimeForWork(target, 0)) && ((num & 4096) == 0 || !this.isPlaceForWork(target, 0)) && (((num & 262144) == 0 || simWorld.getHouseId() == 0) && ((num & 131072) == 0 || simWorld.getHouseId() != 0)) && ((index2 != 152 || type != 155 || this.m_engine.isBonusUnlocked()) && (index2 != 139 || MediaPicker.isAvailable()))))
            {
                if ((num & 33554432) != 0)
                {
                    int personaActionFlags = this.getPersonaActionFlags();
                    if ((num & personaActionFlags) == 0)
                        continue;
                }
                if ((index2 != 136 || !target.getRuntimeFlag(16384)) && (index2 != 137 || !target.getRuntimeFlag(32768)) && (index2 != 144 || !target.getRuntimeFlag(2097152)) && ((index2 != (int)sbyte.MaxValue || this.getGameTime() >= 1320 || this.getGameTime() <= 360) && (((num & 268435456) == 0 || this.isSimMale(0)) && ((num & 536870912) == 0 || !this.isSimMale(0)))) && ((!target.getFlag(2097152) || target.isAgainstWall() || index2 == 111) && (index2 != 135 || playerSim.getPosture() != 1 || playerSim.getPostureObject().getParentType() != 13) && ((index2 != 161 || this.getSimCurRelStateFlags(0, 1) || simWorld.getHouseId() == 0) && (index2 != 163 || !this.getSimCurRelStateFlags(0, 1) && simWorld.getHouseId() != 0))))
                {
                    if (index2 == 162)
                    {
                        int worldTileX = simWorld.coordWorldToWorldTileX(playerSim.getPosX());
                        int worldTileZ = simWorld.coordWorldToWorldTileZ(playerSim.getPosZ());
                        if ((simWorld.getAttribute(worldTileX, worldTileZ) & 16) != 0)
                            continue;
                    }
                    AppEngine.menuAppendItem(menu, (int)dActionStringIds[index2]);
                    AppEngine.menuAppendItem(actions, index2);
                }
            }
        }
        if ((objectFlags & 2048) != 0)
        {
            int index = 111;
            AppEngine.menuAppendItem(menu, (int)dActionStringIds[index]);
            AppEngine.menuAppendItem(actions, index);
        }
        if (menu[0] != 0)
            return;
        AppEngine.menuAppendItem(menu, 430);
        AppEngine.menuAppendItem(actions, -4);
    }

    public void compactContextMenu(int[] menu, int[] actions, int[] fullActions)
    {
        AppEngine.menuClear(menu, fullActions[1]);
        AppEngine.menuClear(actions, 8);
        short[] dActionStringIds = this.d_actionStringIds;
        short[] actionGroupStringIds = this.d_actionGroupStringIds;
        int fullAction1 = fullActions[0];
        for (int index = 0; index < fullAction1; ++index)
        {
            int fullAction2 = fullActions[5 + index];
            int submenuGroupString = (int)actionGroupStringIds[fullAction2];
            if (submenuGroupString != 8 && this.countContextMenuGroup(fullActions, submenuGroupString) >= 2)
            {
                if (!AppEngine.menuContains(menu, submenuGroupString))
                {
                    AppEngine.menuAppendItem(menu, submenuGroupString);
                    AppEngine.menuAppendItem(actions, -2);
                }
            }
            else
            {
                AppEngine.menuAppendItem(menu, (int)dActionStringIds[fullAction2]);
                AppEngine.menuAppendItem(actions, fullAction2);
            }
        }
    }

    private int countContextMenuGroup(int[] menu, int submenuGroupString)
    {
        short[] actionGroupStringIds = this.d_actionGroupStringIds;
        int num1 = 0;
        int num2 = menu[0];
        for (int index1 = 0; index1 < num2; ++index1)
        {
            int index2 = menu[index1 + 5];
            if ((int)actionGroupStringIds[index2] == submenuGroupString)
                ++num1;
        }
        return num1;
    }

    public void filterContextMenu(
      int[] menu,
      int[] actions,
      int[] fullActions,
      int submenuGroupString)
    {
        AppEngine.menuClear(menu, submenuGroupString);
        AppEngine.menuClear(actions, submenuGroupString);
        short[] dActionStringIds = this.d_actionStringIds;
        short[] actionGroupStringIds = this.d_actionGroupStringIds;
        int fullAction1 = fullActions[0];
        for (int index = 0; index < fullAction1; ++index)
        {
            int fullAction2 = fullActions[5 + index];
            if ((int)actionGroupStringIds[fullAction2] == submenuGroupString)
            {
                AppEngine.menuAppendItem(menu, (int)dActionStringIds[fullAction2]);
                AppEngine.menuAppendItem(actions, fullAction2);
            }
        }
    }

    public void createCallContextMenu(int[] menu, int[] actions, int action)
    {
        int dActionStringId = (int)this.d_actionStringIds[action];
        AppEngine.menuClear(menu, dActionStringId);
        AppEngine.menuClear(actions, dActionStringId);
        int houseId = this.getSimWorld().getHouseId();
        for (int sim = 1; sim < this.d_numSims; ++sim)
        {
            if (this.m_currentRelStates[sim] != (sbyte)0 && this.getSimHome(sim) != houseId)
            {
                AppEngine.menuAppendItem(menu, (int)this.d_simNameStrings[sim]);
                AppEngine.menuAppendItem(actions, action);
            }
        }
    }

    public int getDominantCommodity(int npc)
    {
        int[] numArray = this.m_commodityLevelsF[npc];
        int length = numArray.Length;
        int num1 = 3;
        int num2 = 0;
        for (int index = 0; index < length; ++index)
        {
            if (numArray[index] > num2)
            {
                num2 = numArray[index];
                num1 = index;
            }
        }
        return num1;
    }

    private int relStateToRelStateBit(int relState)
    {
        switch (relState)
        {
            case 0:
                return 2;
            case 1:
                return 4;
            case 2:
                return 32;
            case 3:
                return 1024;
            case 4:
                return 2048;
            case 5:
                return 8;
            case 6:
                return 64;
            case 7:
                return 128;
            case 8:
                return 16;
            case 9:
                return 256;
            case 10:
                return 512;
            case 11:
                return 4096;
            case 12:
                return 8192;
            case 13:
                return 16384;
            case 14:
                return 32768;
            default:
                AppEngine.ASSERT(false, "invalid state");
                return 2;
        }
    }

    private bool checkActionHistory(int npc, int action, int repeat, int overLast)
    {
        short[] actionHistory = this.m_actionHistories[npc];
        int num = 0;
        for (int index = 0; index < overLast; ++index)
        {
            if ((int)actionHistory[index] == action && ++num >= repeat)
                return true;
        }
        return false;
    }

    private int calcActionEffect(int npc, int action)
    {
        int dominantCommodity = this.getDominantCommodity(npc);
        int relStateBit = this.relStateToRelStateBit((int)this.m_currentRelStates[npc]);
        sbyte[] conditionCommodity = this.d_actionConditionCommodities[action];
        sbyte[] actionConditionTrait = this.d_actionConditionTraits[action];
        int[] conditionRelState = this.d_actionConditionRelStates[action];
        int[] actionEffectFlag = this.d_actionEffectFlags[action];
        for (int index1 = conditionCommodity.Length - 1; index1 >= 0; --index1)
        {
            int num1 = actionEffectFlag[index1];
            int num2 = (int)conditionCommodity[index1];
            if (num2 == -1 || num2 == dominantCommodity)
            {
                int trait = (int)actionConditionTrait[index1];
                if (trait == -1 || ((num1 & 4096) == 0 || this.hasSimGotTrait(0, trait) != -1) && ((num1 & 4096) != 0 && (num1 & 8192) == 0 || this.hasSimGotTrait(npc, trait) != -1))
                {
                    int num3 = conditionRelState[index1];
                    if (num3 == 0 || (num3 & relStateBit) != 0)
                    {
                        if ((num1 & 7) != 0)
                        {
                            int repeat = 3;
                            int overLast = 6;
                            if ((num1 & 1) != 0)
                            {
                                repeat = 2;
                                overLast = 4;
                            }
                            else if ((num1 & 4) != 0)
                            {
                                repeat = 6;
                                overLast = 10;
                            }
                            if (!this.checkActionHistory(npc, action, repeat, overLast))
                                continue;
                        }
                        if ((num1 & 464) != 0)
                        {
                            int index2 = 0;
                            if ((num1 & 16) != 0)
                                index2 = 0;
                            else if ((num1 & 64) != 0)
                                index2 = 1;
                            else if ((num1 & 128) != 0)
                                index2 = 2;
                            else if ((num1 & 256) != 0)
                                index2 = 3;
                            if (this.m_skillLevelsF[index2] < ((num1 & 512) != 0 ? 196608 : 65536))
                                continue;
                        }
                        if ((num1 & 3072) != 0)
                        {
                            if ((num1 & 2048) != 0)
                            {
                                if (!this.buffTriggerConditionsExist(4))
                                    continue;
                            }
                            else if (!this.buffTriggerConditionsExist(1))
                                continue;
                        }
                        if (action == 104 && (num1 & 8) != 0 && (num1 & 16384) == 0)
                        {
                            int dSimCareer = (int)this.d_simCareers[0];
                            if (dSimCareer != -1)
                            {
                                int dSimCareerLevel = (int)this.d_simCareerLevels[0];
                                if (dSimCareerLevel >= this.d_careerLevelDescStrings[dSimCareer].Length - 1 || !this.careerRequirementsMet(dSimCareer, dSimCareerLevel + 1))
                                    continue;
                            }
                            else
                                continue;
                        }
                        return index1;
                    }
                }
            }
        }
        return -1;
    }

    public bool actionAccept(int fromSim, int toSim, int action)
    {
        if (fromSim != 0)
            return true;
        if (action == 88 && !this.LiveAchievementAwarded[12])
        {
            for (int index = 0; index < this.m_woohooSimsToday.Length && this.m_woohooSimsToday[index] != toSim; ++index)
            {
                if (this.m_woohooSimsToday[index] == 0)
                {
                    this.m_woohooSimsToday[index] = toSim;
                    if (index > 1)
                    {
                        this.m_engine.getScene().awardAchievment(12);
                        break;
                    }
                    break;
                }
            }
        }
        int index1 = this.calcActionEffect(toSim, action);
        return (this.d_actionEffectFlags[action][index1] & 16384) == 0;
    }

    public int getActionTalkIcon(int action)
    {
        int num1;
        switch (action)
        {
            case 23:
                num1 = 16;
                break;
            case 24:
                num1 = 16;
                break;
            case 30:
                num1 = 1;
                break;
            case 31:
                num1 = 1;
                break;
            case 32:
                num1 = 16;
                break;
            case 33:
            case 34:
            case 35:
            case 36:
            case 37:
            case 38:
            case 39:
            case 40:
            case 41:
            case 42:
            case 43:
            case 44:
            case 45:
            case 46:
            case 47:
            case 48:
            case 49:
            case 50:
            case 51:
            case 52:
            case 53:
            case 54:
            case 55:
            case 56:
            case 57:
            case 58:
            case 59:
            case 60:
            case 61:
                num1 = 1;
                break;
            case 62:
                num1 = 4;
                break;
            case 63:
                num1 = 64;
                break;
            case 64:
                num1 = 1;
                break;
            case 65:
                num1 = 1;
                break;
            case 66:
                num1 = 1;
                break;
            case 67:
                num1 = 1;
                break;
            case 68:
                num1 = 1;
                break;
            case 69:
                num1 = 1;
                break;
            case 70:
                num1 = 4;
                break;
            case 71:
                num1 = 128;
                break;
            case 72:
                num1 = 512;
                break;
            case 74:
                num1 = 4;
                break;
            case 75:
                num1 = 128;
                break;
            case 76:
                num1 = 512;
                break;
            case 77:
                num1 = 256;
                break;
            case 78:
                num1 = 32;
                break;
            case 79:
                num1 = 32;
                break;
            case 80:
                num1 = 32;
                break;
            case 83:
                num1 = 1;
                break;
            case 84:
                num1 = 1;
                break;
            case 89:
                num1 = 1;
                break;
            case 90:
                num1 = 1;
                break;
            case 91:
                num1 = 1;
                break;
            case 92:
                num1 = 1;
                break;
            case 93:
                num1 = 1;
                break;
            case 94:
                num1 = 16;
                break;
            case 95:
                num1 = 16;
                break;
            case 96:
                num1 = 16;
                break;
            case 99:
                num1 = 8;
                break;
            case 100:
                num1 = 1;
                break;
            case 101:
                num1 = 1;
                break;
            case 102:
                num1 = 1;
                break;
            case 103:
                num1 = 1;
                break;
            case 104:
                num1 = 1;
                break;
            case 105:
                num1 = 1;
                break;
            case 106:
                num1 = 1;
                break;
            case 107:
                num1 = 1;
                break;
            case 108:
                num1 = 1;
                break;
            case 117:
                num1 = -1;
                break;
            case 147:
                num1 = 1;
                break;
            case 148:
                num1 = 1;
                break;
            case 149:
                num1 = 256;
                break;
            case 150:
                num1 = 1;
                break;
            default:
                AppEngine.ASSERT(false, "unknown action with talk phase");
                num1 = 16;
                break;
        }
        int num2 = 0;
        for (int index = 0; index < SimData.SPEECHICONS.Length; index += 2)
        {
            if ((num1 & (int)SimData.SPEECHICONS[index + 1]) != 0)
                ++num2;
        }
        int num3 = this.m_engine.rand(0, num2 - 1);
        int num4 = 0;
        for (int index = 0; index < SimData.SPEECHICONS.Length; index += 2)
        {
            if ((num1 & (int)SimData.SPEECHICONS[index + 1]) != 0)
            {
                if (num4 == num3)
                    return (int)SimData.SPEECHICONS[index];
                ++num4;
            }
        }
        return 9;
    }

    private bool chanceCardAppropriate(int card)
    {
        int chanceCardResultNo1 = (int)this.d_chanceCardResultNo1s[card];
        int chanceCardResultNo2 = (int)this.d_chanceCardResultNo2s[card];
        int chanceCardResultYes1 = (int)this.d_chanceCardResultYes1s[card];
        int chanceCardResultYes2 = (int)this.d_chanceCardResultYes2s[card];
        int simCareer = this.getSimCareer(0);
        int simCareerLevel = this.getSimCareerLevel(0);
        if ((chanceCardResultNo1 == 2 || chanceCardResultNo2 == 2 || (chanceCardResultYes1 == 2 || chanceCardResultYes2 == 2)) && (simCareer != -1 && simCareerLevel == 0))
            return false;
        if (simCareer != -1)
        {
            int num = this.d_careerLevelDescStrings[simCareer].Length - 1;
            if ((chanceCardResultNo1 == 1 || chanceCardResultNo2 == 1 || (chanceCardResultYes1 == 1 || chanceCardResultYes2 == 1)) && simCareerLevel == num)
                return false;
        }
        return true;
    }

    public int getChanceCardForWork()
    {
        int card;
        do
        {
            card = this.m_engine.rand(0, this.d_chanceCardPrompts.Length - 1);
        }
        while (!this.chanceCardAppropriate(card));
        return card;
    }

    public int getChanceCardOutcome(int card, bool yes)
    {
        int num = this.m_engine.randPercent();
        return yes ? (num >= (int)this.d_chanceCardYesPercents[card] ? 1 : 0) : (num >= (int)this.d_chanceCardNoPercents[card] ? 3 : 2);
    }

    public int getChanceCardPromptString(int card)
    {
        return (int)this.d_chanceCardPrompts[card];
    }

    public int getChanceCardOutcomeString(int card, int outcome)
    {
        switch (outcome)
        {
            case 0:
                return (int)this.d_chanceCardResultYes1Strings[card];
            case 1:
                return (int)this.d_chanceCardResultYes2Strings[card];
            case 2:
                return (int)this.d_chanceCardResultNo1Strings[card];
            case 3:
                return (int)this.d_chanceCardResultNo2Strings[card];
            default:
                AppEngine.ASSERT(false, "invalid outcome");
                return (int)this.d_chanceCardResultYes1Strings[card];
        }
    }

    public void performChanceCardOutcome(int card, int outcome)
    {
        SceneGame sceneGame = this.m_engine.getSceneGame();
        int num1;
        switch (outcome)
        {
            case 0:
                num1 = (int)this.d_chanceCardResultYes1s[card];
                break;
            case 1:
                num1 = (int)this.d_chanceCardResultYes2s[card];
                break;
            case 2:
                num1 = (int)this.d_chanceCardResultNo1s[card];
                break;
            case 3:
                num1 = (int)this.d_chanceCardResultNo2s[card];
                break;
            default:
                AppEngine.ASSERT(false, "invalid outcome");
                num1 = (int)this.d_chanceCardResultYes1s[card];
                break;
        }
        int dSimCareer = (int)this.d_simCareers[0];
        int dSimCareerLevel = (int)this.d_simCareerLevels[0];
        switch (num1)
        {
            case 1:
                this.dreamCompleteEvent(53);
                this.careerAcceptJob(dSimCareer, dSimCareerLevel + 1);
                break;
            case 2:
                this.careerAcceptJob(dSimCareer, dSimCareerLevel - 1);
                break;
            case 3:
                this.careerAcceptJob(-1, 0);
                break;
            case 4:
                int num2 = -1;
                int amount = 1;
                switch (dSimCareer)
                {
                    case 0:
                        num2 = 20;
                        break;
                    case 1:
                        num2 = 9;
                        break;
                    case 2:
                        num2 = 21;
                        break;
                    case 3:
                        num2 = 31;
                        break;
                    case 4:
                        num2 = 16;
                        break;
                }
                this.adjustInventory(num2, amount);
                break;
            case 5:
                this.adjustMoney(1000);
                sceneGame.playSound(83);
                break;
        }
    }

    private void initQuests()
    {
        if (this.m_questSims == null)
        {
            this.m_questSims = new sbyte[this.d_questPrompts.Length];
            this.m_questTimes = new int[this.d_questPrompts.Length];
        }
        AppEngine.fillArray(this.m_questSims, (sbyte)-1);
        AppEngine.fillArray(this.m_questTimes, -1);
    }

    public int getQuestPromptString(int id)
    {
        return (int)this.d_questPrompts[id];
    }

    public int getQuestMessageString(int id)
    {
        return (int)this.d_questMessages[id];
    }

    public int getQuestFlags(int id)
    {
        return (int)this.d_questFlags[id];
    }

    private int getQuestForActionFinish(int action)
    {
        return AppEngine.indexOf((short)action, this.d_questFinishActions);
    }

    private void questCheckTriggers(int toSim, int action, bool allowStarts)
    {
        int gameTimeAbs = this.getGameTimeAbs();
        foreach (int id in this.d_simQuests[toSim])
        {
            int questTime = this.m_questTimes[id];
            bool flag = false;
            if ((int)this.m_questSims[id] == toSim)
            {
                if ((int)this.d_questFinishActions[id] == action)
                {
                    this.m_engine.getSceneGame().triggerFetchQuestEnd(id, toSim);
                    break;
                }
                if (gameTimeAbs - questTime >= 1440)
                    flag = true;
                else
                    continue;
            }
            else if (this.m_questSims[id] != (sbyte)-1)
                continue;
            if (allowStarts && AppEngine.indexOf((short)action, this.d_questTriggerActions[id]) != -1 && (flag || AppEngine.indexOf((sbyte)toSim, this.m_questSims) == -1 && (questTime == -1 || gameTimeAbs - questTime >= 1440) && this.m_engine.randPercent() <= 30))
            {
                this.m_questTimes[id] = this.getGameTimeAbs();
                this.questStart(id, toSim);
                break;
            }
        }
    }

    private void questStart(int id, int simId)
    {
        AppEngine.ASSERT(this.m_questSims[id] == (sbyte)-1 || (int)this.m_questSims[id] == simId, "quest already in progress");
        this.m_questSims[id] = (sbyte)simId;
        this.m_engine.getSceneGame().triggerFetchQuest(id, simId);
        switch (id)
        {
            case 0:
                this.unsetSimCurRelStateFlags(1, 4096);
                break;
            case 1:
                this.unsetSimCurRelStateFlags(1, 2048);
                break;
            case 4:
                this.unsetSimCurRelStateFlags(2, 8192);
                break;
            case 8:
                this.unsetSimCurRelStateFlags(13, 4096);
                break;
            case 15:
                this.unsetSimCurRelStateFlags(4, 4096);
                break;
            case 16:
                this.unsetSimCurRelStateFlags(4, 16384);
                break;
            case 17:
                this.unsetSimCurRelStateFlags(4, 2048);
                break;
            case 18:
                this.unsetSimCurRelStateFlags(2, 4096);
                break;
            case 19:
                this.unsetSimCurRelStateFlags(2, 16384);
                break;
            case 20:
                this.unsetSimCurRelStateFlags(2, 2048);
                break;
            case 28:
                this.unsetSimCurRelStateFlags(7, 4096);
                break;
        }
    }

    public void questCompleted(int id)
    {
        int amount = (int)this.d_questRewardCash[id];
        if (amount != 0)
        {
            this.adjustMoney(amount);
            this.m_engine.getSceneGame().playSound(83);
        }
        int num1 = (int)this.d_questGiveItem[id];
        if (num1 != -1)
        {
            AppEngine.ASSERT(this.getInventoryCount(num1) > 0, "invalid giving");
            this.adjustInventory(num1, -1);
            this.m_engine.getScene().awardAchievment(3);
        }
        sbyte num2 = -1;
        if (((int)this.d_questFlags[id] & 1) != 0)
            num2 = (sbyte)-2;
        this.m_questSims[id] = num2;
        this.m_questTimes[id] = this.getGameTimeAbs();
        if (id != 21)
            return;
        this.adjustInventory(51, 1);
    }

    private bool questConditionsSatisfied(int id)
    {
        short[] currentRelStateFlags = this.m_currentRelStateFlags;
        switch (id)
        {
            case 0:
                return ((int)currentRelStateFlags[1] & 4096) != 0;
            case 1:
                return ((int)currentRelStateFlags[1] & 2048) != 0;
            case 4:
                return ((int)currentRelStateFlags[2] & 8192) != 0;
            case 8:
                return ((int)currentRelStateFlags[13] & 4096) != 0;
            case 15:
                return ((int)currentRelStateFlags[4] & 4096) != 0;
            case 16:
                return ((int)currentRelStateFlags[4] & 16384) != 0;
            case 17:
                return ((int)currentRelStateFlags[4] & 2048) != 0;
            case 18:
                return ((int)currentRelStateFlags[2] & 4096) != 0;
            case 19:
                return ((int)currentRelStateFlags[2] & 16384) != 0;
            case 20:
                return ((int)currentRelStateFlags[2] & 2048) != 0;
            case 28:
                return ((int)currentRelStateFlags[7] & 4096) != 0;
            default:
                AppEngine.ASSERT(this.d_questGiveItem[id] != (short)-1, "invalid quest items");
                return this.getInventoryCount((int)this.d_questGiveItem[id]) > 0;
        }
    }

    private void initSims()
    {
        if (this.d_simTraits[0].Length == 5)
            return;
        this.d_simTraits[0] = new sbyte[5];
        AppEngine.fillArray(this.d_simTraits[0], (sbyte)-1);
    }

    public int getSimCount()
    {
        return this.d_numSims;
    }

    public int getSimName(int sim)
    {
        return (int)this.d_simNameStrings[sim];
    }

    public int getSimPortraitAnim(int sim)
    {
        return (int)this.d_simPortraitAnims[sim];
    }

    public int getSimPartner(int sim)
    {
        return (int)this.d_simPartners[sim];
    }

    public int getSimMacromapColor(int sim)
    {
        return (int)this.d_simMacromapColors[sim];
    }

    public static int getAttributeColorForType(int attrib)
    {
        switch (attrib)
        {
            case 2:
                return 3;
            case 5:
                return 6;
            case 7:
                return 8;
            case 9:
                return 10;
            case 11:
                return 12;
            default:
                return -1;
        }
    }

    public static int getAttributeTypeForColor(int attrib)
    {
        switch (attrib)
        {
            case 3:
                return 2;
            case 6:
                return 5;
            case 8:
                return 7;
            case 10:
                return 9;
            case 12:
                return 11;
            default:
                return -1;
        }
    }

    public int mapAttributeToMeshAttrib(int sim, int attribute)
    {
        return this.mapAttributeToMeshAttrib(this.isSimMale(sim), attribute);
    }

    public int mapAttributeToMeshAttrib(bool male, int attribute)
    {
        switch (attribute)
        {
            case 1:
                return !male ? 8 : 1;
            case 2:
                return !male ? 9 : 2;
            case 4:
                return 0;
            case 5:
                return !male ? 12 : 5;
            case 7:
                return !male ? 13 : 6;
            case 9:
                return !male ? 14 : 7;
            case 11:
                return !male ? 10 : 3;
            case 14:
                return !male ? 11 : 4;
            default:
                return -1;
        }
    }

    public int mapSimAttributeToUnique(bool male, int attribute, int optIndex)
    {
        switch (attribute)
        {
            case 0:
            case 3:
            case 6:
            case 8:
            case 10:
            case 12:
                return optIndex;
            case 1:
            case 2:
            case 4:
            case 5:
            case 7:
            case 9:
            case 11:
                return this.getSimWorld().getSimMeshUniqueId(this.mapAttributeToMeshAttrib(male, attribute), optIndex);
            default:
                return 0;
        }
    }

    public int mapSimAttributeToIndex(bool male, int attribute, int optIndex)
    {
        switch (attribute)
        {
            case 0:
            case 3:
            case 6:
            case 8:
            case 10:
            case 12:
                return optIndex;
            case 1:
            case 2:
            case 4:
            case 5:
            case 7:
            case 9:
            case 11:
                int simMeshLocalId = this.getSimWorld().getSimMeshLocalId(this.mapAttributeToMeshAttrib(0, attribute), optIndex);
                return simMeshLocalId == -1 ? -1 : simMeshLocalId;
            default:
                return -1;
        }
    }

    public bool isSimMale(int sim)
    {
        return this.getSimAttributeUnique(sim, 0) == 0;
    }

    public int getSimAttributeByIndex(int sim, int attribute)
    {
        bool male = this.isSimMale(0);
        int simAttributeUnique = this.getSimAttributeUnique(sim, attribute);
        return this.mapSimAttributeToIndex(male, attribute, simAttributeUnique);
    }

    public int getSimAttributeUnique(int sim, int attribute)
    {
        return this.d_simAttributes[sim][attribute];
    }

    public void setPlayerSimAttributeUnique(int attribute, int value)
    {
        this.d_simAttributes[0][attribute] = value;
    }

    public void setPlayerSimAttributeByIndex(int attribute, int value)
    {
        int unique = this.mapSimAttributeToUnique(this.isSimMale(0), attribute, value);
        this.d_simAttributes[0][attribute] = unique;
    }

    public int getSimHome(int sim)
    {
        return this.getSimCurRelStateFlags(sim, 2) ? 0 : (int)this.d_simHomes[sim];
    }

    public int getSimCareer(int sim)
    {
        return sim == 10 && this.m_engine.isBonusUnlocked() ? 4 : (int)this.d_simCareers[sim];
    }

    public int getSimCareerLevel(int sim)
    {
        return sim == 10 && this.m_engine.isBonusUnlocked() ? this.d_careerLevelDescStrings[4].Length - 1 : (int)this.d_simCareerLevels[sim];
    }

    public bool hasSimGotFlag(int sim, int flag)
    {
        return ((int)this.d_simFlags[sim] & flag) != 0;
    }

    public int hasSimGotTrait(int sim, int trait)
    {
        return AppEngine.indexOf((sbyte)trait, this.d_simTraits[sim]);
    }

    public bool isTraitDiscovered(int sim, int trait)
    {
        int index = this.hasSimGotTrait(sim, trait);
        return index != -1 && this.m_knownTraits[sim][index] >= (sbyte)3;
    }

    public bool tryDiscoverTrait(int sim, int trait)
    {
        sbyte[] knownTrait = this.m_knownTraits[sim];
        int index = this.hasSimGotTrait(sim, trait);
        if (index < 0 || knownTrait[index] >= (sbyte)3)
            return false;
        ++knownTrait[index];
        if (knownTrait[index] != (sbyte)3)
            return false;
        this.m_engine.getTextManager().dynamicString(-12, 595, this.getSimName(sim), (int)this.d_traitDescStrings[trait]);
        this.m_engine.getSceneGame().showTickerMessage(-12, -1);
        return true;
    }

    public int getSimTraitCount(int sim)
    {
        return this.d_simTraits[sim].Length;
    }

    public int getSimTrait(int sim, int index)
    {
        return (int)this.d_simTraits[sim][index];
    }

    public int getNumPlayerTraits()
    {
        sbyte[] dSimTrait = this.d_simTraits[0];
        return dSimTrait.Length - AppEngine.countOf(-1, dSimTrait);
    }

    public void traitPlayerAdd(int trait)
    {
        if (this.hasSimGotTrait(0, trait) != -1)
            return;
        int dTraitExclude = (int)this.d_traitExcludes[trait];
        if (dTraitExclude != -1)
            this.traitPlayerRemove(dTraitExclude);
        int index = this.hasSimGotTrait(0, -1);
        if (index == -1)
            return;
        this.d_simTraits[0][index] = (sbyte)trait;
    }

    public void traitPlayerRemove(int trait)
    {
        int index = this.hasSimGotTrait(0, trait);
        if (index == -1)
            return;
        this.d_simTraits[0][index] = (sbyte)-1;
    }

    public int getSimByName(int nameString)
    {
        return AppEngine.indexOf((short)nameString, this.d_simNameStrings, 1);
    }

    public bool acceptInvitation(int sim)
    {
        switch (this.m_currentRelStates[sim])
        {
            case 2:
            case 3:
            case 4:
                return false;
            default:
                if ((this.getTimeFlags(sim) & 16) == 0 && (this.getTimeFlags(sim) & 8) != 0)
                    return true;
                goto case 2;
        }
    }

    public int getSimCarItem(int sim)
    {
        if (sim != 0)
            return 35;
        int num = -1;
        int itemCount = this.getSimWorld().getItemCount();
        for (int index = 0; index < itemCount; ++index)
        {
            if (this.getInventoryCount(index) > 0 && (this.getSimWorld().getItemFlags(index) & 2) != 0)
                num = index;
        }
        return num;
    }

    public string getSimCarModel(int sim)
    {
        ResourceManager resourceManager = AppEngine.getResourceManager();
        SimWorld simWorld = this.getSimWorld();
        if (sim != 0)
            return resourceManager.idToFilename(293);
        int simCarItem = this.getSimCarItem(sim);
        if (simCarItem != -1)
            return simWorld.getItemCarModel(simCarItem);
        int simCareer = this.getSimCareer(sim);
        if (simCareer != -1)
        {
            int simCareerLevel = this.getSimCareerLevel(sim);
            if ((this.getCareerLevelFlags(simCareer, simCareerLevel) & 1) != 0)
                return resourceManager.idToFilename(294);
        }
        return resourceManager.idToFilename(295);
    }

    public string getSimCarTexture()
    {
        ResourceManager resourceManager = AppEngine.getResourceManager();
        SimWorld simWorld = this.getSimWorld();
        int simCarItem = this.getSimCarItem(0);
        return simCarItem == -1 ? resourceManager.idToFilename(253) : simWorld.getItemCarTexture(simCarItem);
    }

    public int getSimCarObject(int sim)
    {
        int simCarItem = this.getSimCarItem(sim);
        return simCarItem != -1 ? this.getSimWorld().getItemCarObject(simCarItem) : -1;
    }

    public void update(int timeStep)
    {
        this.updateGameTime(timeStep);
        this.updateCareer(timeStep);
        if (!this.m_engine.getSceneGame().isTutorialMode())
        {
            if (!this.isDelayed())
                this.updateMotives(timeStep);
            if (!this.isDelayed())
                this.updateBuffs(timeStep);
            if (!this.isDelayed())
                this.updateRelationships(timeStep);
            if (!this.isDelayed())
                this.updateDreams(timeStep);
        }
        if (this.isDelayed())
            this.m_timeoutDelay = midp.JMath.max(this.m_timeoutDelay - timeStep, 0);
        if (AppEngine.indexOf((short)8, this.m_buffsActive) == -1 || AppEngine.indexOf((short)0, this.m_buffsActive) == -1 || AppEngine.indexOf((short)3, this.m_buffsActive) == -1)
            return;
        this.totalTimeMaintained = this.totalTimeMaintained.Add(new TimeSpan(0, 0, 0, 0, timeStep));
    }

    public void newScene()
    {
        this.setFastforward(false);
        this.setLastNPC(-1);
        AppEngine.fillArray(this.m_motiveDecayAdjustsF, 0);
        for (int simId = 1; simId < this.d_numSims; ++simId)
        {
            this.unsetSimCurRelStateFlags(simId, 1);
            AppEngine.fillArray(this.m_commodityLevelsF[simId], 0);
            AppEngine.fillArray(this.m_actionHistories[simId], (short)-1);
        }
        this.unsetSimCurRelStateFlags(0, 1);
        this.delayAlerts();
    }

    public void delayAlerts()
    {
        this.m_timeoutDelay = 2500;
    }

    public bool isDelayed()
    {
        return this.m_timeoutDelay != 0;
    }

    public void newGame()
    {
        int taskCount = this.getTaskCount();
        int personaFlags = this.getPersonaFlags();
        for (int dream = 0; dream < taskCount; ++dream)
        {
            if ((this.getTaskFlags(dream) & personaFlags) != 0)
                this.m_engine.setGoalDiscovered(dream);
        }
        this.setQuickLinkVisited(140);
    }

    private void initObjectValues()
    {
        if (this.m_objectStateIds == null)
        {
            this.m_objectStateIds = new short[100];
            this.m_objectStateValues = new int[100];
            this.m_objectStateTimes = new int[100];
        }
        AppEngine.fillArray(this.m_objectStateIds, (short)-1);
        AppEngine.fillArray(this.m_objectStateValues, 0);
        AppEngine.fillArray(this.m_objectStateTimes, 0);
    }

    public void saveObjectValue(int houseId, int id, int value)
    {
        AppEngine.ASSERT(id >= 0, "invalid id");
        int num = houseId << 8 | id;
        int index = AppEngine.indexOf((short)num, this.m_objectStateIds);
        if (value == 0 && index != -1)
        {
            this.removeObjectValue(houseId, id);
        }
        else
        {
            if (index == -1)
            {
                index = AppEngine.indexOf((short)-1, this.m_objectStateIds);
                AppEngine.ASSERT(index != -1, "no room in persistant object data");
            }
            this.m_objectStateIds[index] = (short)num;
            this.m_objectStateValues[index] = value;
            this.m_objectStateTimes[index] = this.getGameTimeAbs();
        }
    }

    public int getObjectValue(int houseId, int id)
    {
        AppEngine.ASSERT(id >= 0, "invalid id");
        int index = AppEngine.indexOf((short)(houseId << 8 | id), this.m_objectStateIds);
        return index == -1 ? 0 : this.m_objectStateValues[index];
    }

    public int getObjectValueTime(int houseId, int id)
    {
        AppEngine.ASSERT(id >= 0, "invalid id");
        int index = AppEngine.indexOf((short)(houseId << 8 | id), this.m_objectStateIds);
        return index == -1 ? -1 : this.m_objectStateTimes[index];
    }

    public void removeObjectValue(int houseId, int id)
    {
        int index = AppEngine.indexOf((short)(houseId << 8 | id), this.m_objectStateIds);
        if (index == -1)
            return;
        this.m_objectStateIds[index] = (short)-1;
        this.m_objectStateValues[index] = 0;
        this.m_objectStateTimes[index] = 0;
    }

    public void moveObject(int oldIdx, int newIdx)
    {
        int index = AppEngine.indexOf((short)oldIdx, this.m_objectStateIds);
        if (index == -1)
            return;
        int num = (int)this.m_objectStateIds[index] & 65280;
        this.m_objectStateIds[index] = (short)(num | newIdx);
    }

    public void resetRMSGameData()
    {
        this.initGameTimeMoney();
        this.initInventory();
        this.initSkills();
        this.initCareer();
        this.m_persona = (sbyte)0;
        AppEngine.fillArray(this.d_simTraits[0], (sbyte)-1);
        this.initDreams();
        this.initMotives();
        this.initBuffs();
        this.initMoods();
        this.initQuests();
        this.initSims();
        this.initRelationships();
        this.initObjectValues();
        this.m_soldSomething = (byte)0;
        this.m_fishCaughtToday = (byte)0;
        this.LiveAchievementAwarded = new bool[18];
        for (int index = 0; index < this.LiveAchievementAwarded.Length; ++index)
            this.LiveAchievementAwarded[index] = false;
        this.m_woohooSimsToday = new int[10];
        for (int index = 0; index < this.m_woohooSimsToday.Length; ++index)
            this.m_woohooSimsToday[index] = 0;
        this.DemoTime = 0;
        AppEngine.fillArray(this.d_simAttributes[0], 0);
    }

    public void loadRMSGameDataLegacy(DataInputStream @in)
    {
        SimWorld simWorld = this.getSimWorld();
        for (int index = 0; index < 11; ++index)
            this.setPlayerSimAttributeByIndex(0, (int)@in.readByte());
        this.d_simAttributes[0][11] = 0;
        this.d_simAttributes[0][12] = 0;
        sbyte[] dSimTrait = this.d_simTraits[0];
        for (int index = 0; index < 5; ++index)
            dSimTrait[index] = @in.readByte();
        this.m_timeTimer = @in.readInt();
        this.m_timeTotal = @in.readInt();
        this.m_money = @in.readInt();
        this.m_moneySpent = @in.readInt();
        this.m_furnitureStage = @in.readByte();
        this.m_houseUpgradeDay = @in.readShort();
        int itemCount = simWorld.getItemCount();
        for (int index = 0; index < itemCount; ++index)
            this.setInventoryCount(index, 0);
        int itemCountLegacy = simWorld.getItemCountLegacy();
        for (int itemId = 0; itemId < itemCountLegacy; ++itemId)
            this.setInventoryCount(simWorld.getItemIdLegacy(itemId), (int)@in.readByte());
        for (int index = 0; index < this.m_skillLevelsF.Length; ++index)
            this.m_skillLevelsF[index] = @in.readInt();
        this.d_simCareers[0] = @in.readByte();
        this.d_simCareerLevels[0] = @in.readByte();
        this.m_careerAcceptDay = @in.readByte();
        this.m_careerDaysWorked = @in.readShort();
        this.m_careerDaysMissed = @in.readShort();
        for (int index = 0; index < this.m_careerLevelsAttained.Length; ++index)
            this.m_careerLevelsAttained[index] = @in.readByte();
        this.m_phoneCareer = @in.readByte();
        this.m_phoneCareerTimer = @in.readInt();
        this.m_persona = @in.readByte();
        this.m_dream = @in.readByte();
        this.m_dreamLGCSeed = @in.readShort();
        this.m_dreamTimer = @in.readInt();
        for (int index = 0; index < this.m_promises.Length; ++index)
            this.m_promises[index] = @in.readByte();
        this.m_personaGoalsCompleted = @in.readInt();
        this.m_achievements = @in.readInt();
        for (int index = 0; index < this.m_timeRanges.Length; ++index)
            this.m_timeRanges[index] = @in.readInt();
        this.m_dreamFishCount = @in.readShort();
        this.m_dreamHarvestCount = @in.readShort();
        for (int index = 0; index < this.m_woohooTimes.Length; ++index)
            this.m_woohooTimes[index] = @in.readInt();
        this.m_quickLinkFlags = @in.readInt();
        for (int index = 0; index < this.m_motiveLevelsF.Length; ++index)
            this.m_motiveLevelsF[index] = @in.readInt();
        for (int index = 0; index < 6; ++index)
        {
            this.m_buffsActive[index] = @in.readShort();
            this.m_buffTimers[index] = @in.readInt();
        }
        this.applyBuffsToMood();
        int dNumSims = this.d_numSims;
        for (int index = 1; index < dNumSims; ++index)
        {
            this.m_currentRelStates[index] = @in.readByte();
            this.m_currentRelStateFlags[index] = @in.readShort();
            for (var i = 0; i < m_currentRelLevelsF[index].Length; i++)
            {
                var num = this.m_currentRelLevelsF[index][i] = @in.readInt();
            }

            for (var i1 = 0; i1 < m_knownTraits[index].Length; i1++)
            {
                var num = this.m_knownTraits[index][i1]  = @in.readByte();
            }
        }
        for (int index = 0; index < 100; ++index)
        {
            this.m_objectStateIds[index] = @in.readShort();
            this.m_objectStateValues[index] = @in.readInt();
            this.m_objectStateTimes[index] = @in.readInt();
        }
        for (int index = 0; index < this.m_questSims.Length; ++index)
        {
            this.m_questSims[index] = @in.readByte();
            this.m_questTimes[index] = @in.readInt();
        }
        int activeSlot = this.buffGetActiveSlot(2);
        if (activeSlot == -1)
            return;
        this.m_buffTimers[activeSlot] = 0;
    }

    public void loadRMSGameData(DataInputStream @in, int version)
    {
        for (int attribute = 0; attribute < 13; ++attribute)
        {
            if (version == 138)
            {
                int num = (int)@in.readByte();
                this.setPlayerSimAttributeByIndex(attribute, num);
            }
            else
            {
                int num = @in.readInt();
                this.setPlayerSimAttributeUnique(attribute, num);
            }
        }
        sbyte[] dSimTrait = this.d_simTraits[0];
        for (int index = 0; index < 5; ++index)
            dSimTrait[index] = @in.readByte();
        this.m_timeTimer = @in.readInt();
        this.m_timeTotal = @in.readInt();
        this.m_money = @in.readInt();
        this.m_moneySpent = @in.readInt();
        this.m_furnitureStage = @in.readByte();
        this.m_houseUpgradeDay = @in.readShort();
        int itemCount = this.getSimWorld().getItemCount();
        for (int index = 0; index < itemCount; ++index)
            this.setInventoryCount(index, 0);
        int num1 = (int)@in.readShort();
        for (int index = 0; index < num1; ++index)
            this.setInventoryCount((int)@in.readShort(), (int)@in.readByte());
        for (int index = 0; index < this.m_skillLevelsF.Length; ++index)
            this.m_skillLevelsF[index] = @in.readInt();
        this.d_simCareers[0] = @in.readByte();
        this.d_simCareerLevels[0] = @in.readByte();
        this.m_careerAcceptDay = @in.readByte();
        this.m_careerDaysWorked = @in.readShort();
        this.m_careerDaysMissed = @in.readShort();
        for (int index = 0; index < this.m_careerLevelsAttained.Length; ++index)
            this.m_careerLevelsAttained[index] = @in.readByte();
        this.m_phoneCareer = @in.readByte();
        this.m_phoneCareerTimer = @in.readInt();
        this.m_persona = @in.readByte();
        this.m_dream = @in.readByte();
        this.m_dreamLGCSeed = @in.readShort();
        this.m_dreamTimer = @in.readInt();
        for (int index = 0; index < this.m_promises.Length; ++index)
            this.m_promises[index] = @in.readByte();
        this.m_personaGoalsCompleted = @in.readInt();
        this.m_achievements = @in.readInt();
        for (int index = 0; index < this.m_timeRanges.Length; ++index)
            this.m_timeRanges[index] = @in.readInt();
        this.m_dreamFishCount = @in.readShort();
        this.m_dreamHarvestCount = @in.readShort();
        for (int index = 0; index < this.m_woohooTimes.Length; ++index)
            this.m_woohooTimes[index] = @in.readInt();
        this.m_quickLinkFlags = @in.readInt();
        for (int index = 0; index < this.m_motiveLevelsF.Length; ++index)
            this.m_motiveLevelsF[index] = @in.readInt();
        for (int index = 0; index < 6; ++index)
        {
            this.m_buffsActive[index] = @in.readShort();
            this.m_buffTimers[index] = @in.readInt();
        }
        this.applyBuffsToMood();
        int dNumSims = this.d_numSims;
        for (int index = 1; index < dNumSims; ++index)
        {
            this.m_currentRelStates[index] = @in.readByte();
            this.m_currentRelStateFlags[index] = @in.readShort();
            for (var i = 0; i < m_currentRelLevelsF[index].Length; i++)
            {
                var num2 = this.m_currentRelLevelsF[index][i] = @in.readInt();
            }

            for (var i1 = 0; i1 < m_knownTraits[index].Length; i1++)
            {
                var num2 = this.m_knownTraits[index][i1] = @in.readByte();
            }
        }
        for (int index = 0; index < 100; ++index)
        {
            this.m_objectStateIds[index] = @in.readShort();
            this.m_objectStateValues[index] = @in.readInt();
            this.m_objectStateTimes[index] = @in.readInt();
        }
        for (int index = 0; index < this.m_questSims.Length; ++index)
        {
            this.m_questSims[index] = @in.readByte();
            this.m_questTimes[index] = @in.readInt();
        }
        int activeSlot = this.buffGetActiveSlot(2);
        if (activeSlot != -1)
            this.m_buffTimers[activeSlot] = 0;
        this.m_soldSomething = (byte)@in.readByte();
        this.m_fishCaughtToday = (byte)@in.readByte();
        for (int index = 0; index < this.LiveAchievementAwarded.Length; ++index)
            this.LiveAchievementAwarded[index] = @in.readBoolean();
        for (int index = 0; index < this.m_woohooSimsToday.Length; ++index)
            this.m_woohooSimsToday[index] = @in.readInt();
        this.DemoTime = @in.readInt();
        @in.readLong();
        this.mostMoneyEarned = @in.readInt();
        this.numPurchases = @in.readInt();
        this.numFriendships = @in.readInt();
        this.numJobsWorked = @in.readInt();
        this.totalTimeMaintained = new TimeSpan(@in.readLong() * 60L * 1000L * 1000L * 10L);
    }

    public void saveRMSGameData(DataOutputStream @out)
    {
        for (int attribute = 0; attribute < 13; ++attribute)
        {
            int simAttributeUnique = this.getSimAttributeUnique(0, attribute);
            @out.writeInt(simAttributeUnique);
        }
        sbyte[] dSimTrait = this.d_simTraits[0];
        for (int index = 0; index < 5; ++index)
            @out.writeByte((int)dSimTrait[index]);
        @out.writeInt(this.m_timeTimer);
        @out.writeInt(this.m_timeTotal);
        @out.writeInt(this.m_money);
        @out.writeInt(this.m_moneySpent);
        @out.writeByte((int)this.m_furnitureStage);
        @out.writeShort((int)this.m_houseUpgradeDay);
        int itemCount = this.getSimWorld().getItemCount();
        @out.writeShort(itemCount);
        for (int v = 0; v < itemCount; ++v)
        {
            @out.writeShort(v);
            @out.writeByte(this.getInventoryCount(v));
        }
        for (int index = 0; index < this.m_skillLevelsF.Length; ++index)
            @out.writeInt(this.m_skillLevelsF[index]);
        @out.writeByte((int)this.d_simCareers[0]);
        @out.writeByte((int)this.d_simCareerLevels[0]);
        @out.writeByte((int)this.m_careerAcceptDay);
        @out.writeShort((int)this.m_careerDaysWorked);
        @out.writeShort((int)this.m_careerDaysMissed);
        for (int index = 0; index < this.m_careerLevelsAttained.Length; ++index)
            @out.writeByte((int)this.m_careerLevelsAttained[index]);
        @out.writeByte((int)this.m_phoneCareer);
        @out.writeInt(this.m_phoneCareerTimer);
        @out.writeByte((int)this.m_persona);
        @out.writeByte((int)this.m_dream);
        @out.writeShort((int)this.m_dreamLGCSeed);
        @out.writeInt(this.m_dreamTimer);
        for (int index = 0; index < this.m_promises.Length; ++index)
            @out.writeByte((int)this.m_promises[index]);
        @out.writeInt(this.m_personaGoalsCompleted);
        @out.writeInt(this.m_achievements);
        for (int index = 0; index < this.m_timeRanges.Length; ++index)
            @out.writeInt(this.m_timeRanges[index]);
        @out.writeShort((int)this.m_dreamFishCount);
        @out.writeShort((int)this.m_dreamHarvestCount);
        for (int index = 0; index < this.m_woohooTimes.Length; ++index)
            @out.writeInt(this.m_woohooTimes[index]);
        @out.writeInt(this.m_quickLinkFlags);
        for (int index = 0; index < this.m_motiveLevelsF.Length; ++index)
            @out.writeInt(this.m_motiveLevelsF[index]);
        for (int index = 0; index < 6; ++index)
        {
            @out.writeShort((int)this.m_buffsActive[index]);
            @out.writeInt(this.m_buffTimers[index]);
        }
        int dNumSims = this.d_numSims;
        for (int index = 1; index < dNumSims; ++index)
        {
            @out.writeByte((int)this.m_currentRelStates[index]);
            @out.writeShort((int)this.m_currentRelStateFlags[index]);
            foreach (int v in this.m_currentRelLevelsF[index])
                @out.writeInt(v);
            foreach (int v in this.m_knownTraits[index])
                @out.writeByte(v);
        }
        for (int index = 0; index < 100; ++index)
        {
            @out.writeShort((int)this.m_objectStateIds[index]);
            @out.writeInt(this.m_objectStateValues[index]);
            @out.writeInt(this.m_objectStateTimes[index]);
        }
        for (int index = 0; index < this.m_questSims.Length; ++index)
        {
            @out.writeByte((int)this.m_questSims[index]);
            @out.writeInt(this.m_questTimes[index]);
        }
        @out.writeByte((int)this.m_soldSomething);
        @out.writeByte((int)this.m_fishCaughtToday);
        for (int index = 0; index < this.LiveAchievementAwarded.Length; ++index)
            @out.writeBoolean(this.LiveAchievementAwarded[index]);
        for (int index = 0; index < this.m_woohooSimsToday.Length; ++index)
            @out.writeInt(this.m_woohooSimsToday[index]);
        @out.writeInt(this.DemoTime);
        @out.writeLong((long)this.totalAppRunTime.TotalMinutes);
        @out.writeInt(this.mostMoneyEarned);
        @out.writeInt(this.numPurchases);
        @out.writeInt(this.numFriendships);
        @out.writeInt(this.numJobsWorked);
        @out.writeLong((long)this.totalTimeMaintained.TotalMinutes);
    }

    public byte[] getExportData()
    {
        BitOutputStream bitOutputStream = new BitOutputStream();
        bitOutputStream.writeInt(5, 4);
        string str = "temp";
        bitOutputStream.writeString(str);
        bitOutputStream.writeInt(this.getSimAttributeUnique(0, 0), 1);
        bitOutputStream.writeInt(this.getSimAttributeUnique(0, 1), 16);
        bitOutputStream.writeInt(this.getSimAttributeUnique(0, 2), 16);
        bitOutputStream.writeInt(this.getSimAttributeUnique(0, 3), 3);
        bitOutputStream.writeInt(this.getSimAttributeUnique(0, 11), 16);
        bitOutputStream.writeInt(this.getSimAttributeUnique(0, 12), 3);
        bitOutputStream.writeInt(this.getSimAttributeUnique(0, 4), 16);
        bitOutputStream.writeInt(this.getSimAttributeUnique(0, 5), 16);
        bitOutputStream.writeInt(this.getSimAttributeUnique(0, 6), 3);
        bitOutputStream.writeInt(this.getSimAttributeUnique(0, 7), 16);
        bitOutputStream.writeInt(this.getSimAttributeUnique(0, 8), 3);
        bitOutputStream.writeInt(this.getSimAttributeUnique(0, 9), 16);
        bitOutputStream.writeInt(this.getSimAttributeUnique(0, 10), 3);
        string simName = this.m_engine.getSimName();
        bitOutputStream.writeString(simName);
        return bitOutputStream.toArray();
    }

    public int loadExportData(byte[] data)
    {
        BitInputStream bitInputStream = new BitInputStream(data);
        if (bitInputStream.readInt(4) != 5)
            return 1;
        bitInputStream.readString();
        int num1 = bitInputStream.readInt(1);
        int num2 = bitInputStream.readInt(16);
        int num3 = bitInputStream.readInt(16);
        int num4 = bitInputStream.readInt(3);
        int num5 = bitInputStream.readInt(16);
        int num6 = bitInputStream.readInt(3);
        int num7 = bitInputStream.readInt(16);
        int num8 = bitInputStream.readInt(16);
        int num9 = bitInputStream.readInt(3);
        int num10 = bitInputStream.readInt(16);
        int num11 = bitInputStream.readInt(3);
        int num12 = bitInputStream.readInt(16);
        int num13 = bitInputStream.readInt(3);
        this.setPlayerSimAttributeUnique(0, num1);
        this.setPlayerSimAttributeUnique(1, num2);
        this.setPlayerSimAttributeUnique(2, num3);
        this.setPlayerSimAttributeUnique(3, num4);
        this.setPlayerSimAttributeUnique(11, num5);
        this.setPlayerSimAttributeUnique(12, num6);
        this.setPlayerSimAttributeUnique(4, num7);
        this.setPlayerSimAttributeUnique(5, num8);
        this.setPlayerSimAttributeUnique(6, num9);
        this.setPlayerSimAttributeUnique(7, num10);
        this.setPlayerSimAttributeUnique(8, num11);
        this.setPlayerSimAttributeUnique(9, num12);
        this.setPlayerSimAttributeUnique(10, num13);
        for (int attribute = 0; attribute < 13; ++attribute)
        {
            switch (attribute)
            {
                case 0:
                    if (num1 != 0 && num1 != 1)
                        return 3;
                    break;
                case 1:
                case 2:
                case 4:
                case 5:
                case 7:
                case 9:
                case 11:
                    int uniquePackId = SimWorld.getUniquePackId(this.getSimAttributeUnique(0, attribute));
                    if (uniquePackId != 0 && DLCManager.getInstance().getDLCPackByUniqueId(uniquePackId) == null)
                        return 3;
                    break;
            }
        }
        this.m_engine.setSimName(bitInputStream.readString());
        return 0;
    }

    public void triggerSoldSomething()
    {
        this.m_soldSomething = (byte)1;
        if (!this.getAchievements(20))
            return;
        this.m_engine.getScene().awardAchievment(4);
    }

    public void clearMotives()
    {
        int num = 3276800;
        for (int index = 0; index < this.m_motiveLevelsF.Length; ++index)
            this.m_motiveLevelsF[index] = num;
    }
}
