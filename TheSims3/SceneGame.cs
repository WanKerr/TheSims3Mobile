// Decompiled with JetBrains decompiler
// Type: SceneGame
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using midp;
using sims3;
using System;
using System.Collections.Generic;

public class SceneGame : Scene
{
    public static readonly short[] AMBIENT_MM_SOUNDS = new short[4]
    {
    (short) 62,
    (short) 63,
    (short) 60,
    (short) 61
    };
    public static readonly short[] AMBIENT_LAKESIDE_SOUNDS = new short[2]
    {
    (short) 62,
    (short) 63
    };
    private Stack<MapObject> m_objectStack = new Stack<MapObject>();
    private Stack<MapObject> m_objectStackToRemove = new Stack<MapObject>();
    private string m_miniGameTypeString = "";
    private AnimPlayer3D[] m_pots = new AnimPlayer3D[4];
    private float[] m_potHeats = new float[4];
    private float[] m_potHeatSpeeds = new float[4];
    public const int FILTER_TIME = 1500;
    public const int COOKING_LEVEL_MAX = 6553600;
    public const int COOKING_LEVEL_WARN_UPPER = 4915200;
    public const int COOKING_LEVEL_WARN_LOWER = 1638400;
    public const int COOKING_LEVEL_FAIL_LOWER = 65536;
    public const float HEAT_SPEED_LOW = 2f;
    public const float HEAT_SPEED_HIGH = 7f;
    public const float HEAT_MAX = 100f;
    public const float HEAT_REDUCE = 50f;
    public const float FISHING_LEVEL_MAX = 1f;
    public const float FISHING_LEVEL_FAIL = -0.5f;
    public const float FISHING_LEVEL_CATCH = 0.9f;
    public const float FISHING_LEVEL_DOWN_SPEED = -0.2f;
    public const float FISHING_LEVEL_UP_SPEED = 0.3f;
    public const float FISHING_CURSOR_MAX = 2f;
    public const float FISHING_CATCH_RANGE = 0.18f;
    public const float FISH_FLASHER_STEP = 3f;
    public const float TUTORIAL_PULSE_SPEED = 0.3f;
    public const float TUTORIAL_PULSE_MAX = 1.1f;
    public const float TUTORIAL_PULSE_MIN = 0.9f;
    public const int STATE_NONE = 0;
    public const int STATE_LOADING = 1;
    public const int STATE_CHANGESCENE = 2;
    public const int STATE_CHANGESCENE_SAVEPROMPT = 3;
    public const int STATE_CHANGESCENE_PROMPT = 4;
    public const int STATE_EXITGAME = 5;
    public const int STATE_MAIN = 6;
    public const int STATE_BUILDMODE = 7;
    public const int STATE_INFOSCREEN = 8;
    public const int STATE_SHOW_MESSAGEBOX = 9;
    public const int STATE_SHOW_JOBOFFER = 10;
    public const int STATE_SHOW_PAY = 11;
    public const int STATE_SHOW_RAISEFAILURE = 12;
    public const int STATE_SHOW_QUITJOB = 13;
    public const int STATE_SHOW_NEWDREAM = 14;
    public const int STATE_SHOW_GETITEM = 15;
    public const int STATE_MINIGAME = 16;
    public const int STATE_SHOPPING = 17;
    public const int STATE_QUEST = 18;
    public const int STATE_EVENTCUTSCENE = 19;
    public const int STATE_CONFIRM_TUTORIAL = 20;
    public const int STATE_TUTORIAL = 21;
    public const int STATE_CONFIRM_EDITSIM = 22;
    public const int STATE_PURCHASE_FULL_VERSION = 23;
    public const int STATE_PASSEDOUT = 96;
    public const int STATE_GOHOME = 97;
    public const int STATE_MAPMODE = 98;
    public const int STATE_MAPMODE_WORK = 99;
    public const int STATE_ZOOMMAP = 100;
    public const int MAPMODE_HOUSE = 0;
    public const int MAPMODE_ZOOM = 1;
    public const int MAPMODE_MAP = 2;
    public const int TUTORIAL_CONFIRM_WRAPWIDTH = 300;
    private const int LOADING_INIT = 0;
    private const int LOADING_INITMAP = 1;
    private const int LOADING_IMAGES = 2;
    private const int LOADING_3D = 3;
    private const int LOADING_SOUND = 4;
    private const int LOADING_FINISHED = 5;
    private const int LOADINGTHREAD_STATE_IDLE = 0;
    private const int LOADINGTHREAD_STATE_WAIT = 1;
    private const int LOADINGTHREAD_STATE_QUIT = 2;
    public const int SIMLISH_ANGRY = 0;
    public const int SIMLISH_CONVO = 1;
    public const int SIMLISH_FLIRT = 2;
    public const int SIMLISH_HAPPY = 3;
    public const int SIMLISH_JOKE = 4;
    public const int SIMLISH_LAUGH = 5;
    public const int SIMLISH_SAD = 6;
    public const int SIMLISH_NUM_THEMES = 7;
    public const int SIMLISH_SEX_MALE = 0;
    public const int SIMLISH_SEX_FEMALE = 1;
    public const int SIMLISH_NUM_SEXES = 2;
    public const int SIMLISH_VOICES = 2;
    public const int TUTORIAL_INTRO = 0;
    public const int TUTORIAL_MACROMAP = 1;
    public const int TUTORIAL_LAKE = 2;
    public const int TUTORIAL_COOKING_HOWTO = 5;
    public const int TUTORIAL_FISHING_HOWTO = 6;
    public const int TUTORIAL_REPAIRING_HOWTO = 7;
    public const int TUTORIAL_CLEANING_HOWTO = 8;
    public const int TUTORIAL_FISHING_TIP = 9;
    public const int TUTORIAL_GARDENING_TIP = 10;
    public const int TUTORIAL_REPAIRING_TIP = 11;
    public const int TUTORIAL_CLEANING_TIP = 12;
    public const int TUTORIAL_PASSOUT_TIP = 13;
    public const int TUTORIAL_HUNGRY = 14;
    public const int TUTORIAL_SLEEPY = 15;
    public const int TUTORIAL_EXHAUSTED = 16;
    public const int TUTORIAL_NEEDSTOPEE = 17;
    public const int TUTORIAL_SMELLY = 18;
    public const int TUTORIAL_BORED = 19;
    public const int TUTORIAL_SOCIAL = 20;
    public const int TUTORIAL_GOOD_MOOD = 21;
    public const int TUTORIAL_BAD_MOOD = 22;
    public const int TUTORIAL_GET_JOB = 23;
    public const int TUTORIAL_VISIT_TOWN = 24;
    public const int TUTORIAL_BUILD_MODE1 = 25;
    public const int TUTORIAL_BUILD_MODE2 = 26;
    public const int TUTORIAL_BUILD_MODE3 = 27;
    public const int TUTORIAL_BUILD_MODE4 = 28;
    public const int TUTORIAL_SIMOLEAN = 29;
    public const int TUTORIAL_RECIPE = 30;
    public const int TUTORIAL_BUILD_MODE5 = 32;
    public const int TUTORIAL_CARYARD1 = 33;
    public const int TUTORIAL_CARYARD2 = 34;
    public const int TUTORIAL_EDITSIM = 35;
    private const int TUTORIAL_HOME_TIMER_MAX = 300000;
    private const int TUTORIAL_JOB_TIME = 1980;
    private const int HUD_ZOOMBAR_HANDLE_BUFFER = 5;
    public const int POSTMSG_STATE_MAIN = 0;
    public const int POSTMSG_KICKOUT = 1;
    public const int POSTMSG_CANCELWORK = 2;
    public const int POSTMSG_EVENT_HIRED = 3;
    public const int POSTMSG_EVENT_PROMOTION = 4;
    public const int POSTMSG_SHOPPING = 5;
    public const int POSTMSG_TUTORIAL = 6;
    public const int POSTMSG_SIMDEATH = 7;
    public const int POSTMSG_PERSONA = 8;
    public const int POSTMSG_SPOUSE = 9;
    public const int POSTMSG_SKILLMAX = 10;
    public const int CURTAINSTATE_NONE = 0;
    public const int CURTAINSTATE_IN = 1;
    public const int CURTAINSTATE_HOLD = 2;
    public const int CURTAINSTATE_OUT = 3;
    private const int CURTAIN_SLIDE_TIME = 1000;
    private const int CURTAIN_HOLD_TIME = 500;
    private const int TICKER_FLASH_TIME = 1000;
    private const int TICKER_FLASH_SPEED = 511;
    private const int TICKER_STILL_TIME = 1000;
    private const int TICKER_MARGIN = 327680;
    protected const int CAMERA_STATE_IDLE = 0;
    protected const int CAMERA_STATE_FOLLOW = 1;
    protected const int CAMERA_STATE_SNAPPING = 2;
    protected const int CAMERA_STATE_SNAPPING_TO_SIM = 3;
    protected const int CAMERA_STATE_SNAPPING_TO_POINT = 4;
    protected const int CAMERA_STATE_UNSNAPPING = 5;
    protected const int CAMERA_STATE_MINIGAME_PRE = 6;
    protected const int CAMERA_STATE_MINIGAME_MAIN = 7;
    protected const int CAMERA_STATE_MINIGAME_POST = 8;
    protected const int CAMERA_STATE_ZOOM_OUT = 9;
    private const int DRAG_STATE_NONE = 0;
    private const int MAX_CONTEXTMENU_SIZE = 55;
    private const int MAX_PAUSEMENU_SIZE = 15;
    public const int PAUSEMENU_MAIN = 0;
    public const int PAUSEMENU_SAVECONFIRM = 1;
    public const int PAUSEMENU_SAVEQUITCONFIRM = 2;
    public const int PAUSEMENU_MEDIAPICKER = 3;
    public const int PAUSEMENU_LEADERBOARDS = 4;
    public const int PAUSEMENU_ACHIEVEMENTS = 5;
    public const int PAUSEMENU_ACHIEVEMENTS_DETAIL = 6;
    private const int BUILDMODE_STATE_NONE = 0;
    private const int BUILDMODE_STATE_EDIT = 1;
    private const int BUILDMODE_STATE_BUY_SELECT = 2;
    private const int BUILDMODE_STATE_BUY_NO_BPS = 3;
    private const int BUILDMODE_STATE_BUY_PLACE = 4;
    private const int BUILDMODE_STATE_BUY_CONFIRM = 5;
    private const int BUILDMODE_STATE_BUY_WAIT = 6;
    private const int BUILDMODE_STATE_BUY_NO_CASH = 7;
    private const int BUILDMODE_STATE_BUY_UNAVAILABLE = 8;
    private const int BUILDMODE_STATE_SELL_CONFIRM = 9;
    private const int BUILDMODE_STATE_UPGRADE_CONFIRM = 10;
    private const int BUILDMODE_STATE_UPGRADE_FAIL = 11;
    private const int BUILDMODE_STATE_MOVE_PLACE = 12;
    private const int BUILDMODE_STATE_CHOOSEACTION = 13;
    private const int BUILDMODE_STATE_CHOOSECAT = 14;
    private const int BUILDMODE_STATE_CHANGE = 15;
    private const int BUILDMODE_STATE_CHANGEFLOOR = 16;
    private const int BUILDMODE_STATE_CHANGEWALL = 17;
    private const int BUILDMODE_STATE_CHANGEDOOR = 18;
    private const int BUILDMODE_STATE_CHANGEFLOOR_CONFIRM = 19;
    private const int BUILDMODE_STATE_CHANGEWALL_CONFIRM = 20;
    private const int BUILDMODE_STATE_CHANGEFLOOR_NO_CASH = 21;
    private const int BUILDMODE_STATE_CHANGEWALL_NO_CASH = 22;
    private const int BUILDMODE_WAIT_TIME = 1500;
    private const int NUM_BUILD_CATS = 6;
    private const int BUILD_MODE_CAT_CHOOSE_TIMER_MAX = 1000;
    private const int BUILD_MODE_CAT_CHOOSE_CYCLE = 300;
    private const int EVENTRATE_HOUSE = 3000;
    private const int EVENTRATE_ZOOMMAP = 5000;
    private const int EVENTRATE_MAPMODE = 5000;
    private const int AMBIENTRATE_MAPMODE = 3000;
    private const int AMBIENTRATE_LAKESIDE = 8000;
    private const int AMBIENTRATE_STREETSIDE = 10000;
    private const int INACTIVITY_TIME = 20000;
    private const int MAX_ACTIONS = 3;
    private const int QUEST_STATE_CC_PROMPT = 0;
    private const int QUEST_STATE_CC_OUTCOME = 1;
    private const int QUEST_STATE_FQ_PROMPT = 2;
    private const int QUEST_STATE_FQ_SUCCESS = 3;
    private const int QUEST_STATE_FINISHED = 4;
    private const int EVENT_STATE_NONE = 0;
    private const int EVENT_STATE_ZOOMCAMERA = 1;
    private const int EVENT_STATE_FLASH = 2;
    private const int EVENT_STATE_WAITING = 3;
    private const int EVENT_STATE_FADEOUT = 4;
    private const int EVENT_STATE_FINISHED = 5;
    private const int EVENT_FLASH_TIME = 500;
    private const int EVENT_FADEOUT_TIME = 1000;
    private const int MINIGAME_FISHING_SOUND_TIME_MIN = 4000;
    private const int MINIGAME_FISHING_SOUND_TIME_MAX = 7000;
    private const int MINIGAME_COOKING_SOUND_TIME_MIN = 3000;
    private const int MINIGAME_COOKING_SOUND_TIME_MAX = 4000;
    private const int MINIGAME_WINDUP_TIME = 3200;
    private const int MINIGAME_STATE_ZOOMCAMERA = 0;
    private const int MINIGAME_STATE_MAIN = 1;
    private const int MINIGAME_STATE_SUCCESS = 2;
    private const int MINIGAME_STATE_FAIL = 3;
    private const int MINIGAME_STATE_CANCEL = 4;
    private const int MINIGAME_STATE_COOKING_TIMEUP = 5;
    private const int MINIGAME_STATE_COOKING_OUTRO = 6;
    private const int MINIGAME_STATE_FISHING_INTRO = 7;
    private const int MINIGAME_STATE_FISHING_OUTRO = 8;
    private const int MINIGAME_STATE_REPAIR_MAIN = 10;
    private const int MINIGAME_STATE_REPAIR_COMPLETED = 11;
    private const int MINIGAME_STATE_REPAIR_TIMEUP = 12;
    public const int MINIGAME_TYPE_COOKING = 0;
    public const int MINIGAME_TYPE_FISHING = 1;
    public const int MINIGAME_TYPE_REPAIRING = 2;
    public const int MINIGAME_TYPE_CLEANING = 3;
    private const int POT_TOP_LEFT = 1;
    private const int POT_TOP_RIGHT = 0;
    private const int POT_BOTTOM_LEFT = 2;
    private const int POT_BOTTOM_RIGHT = 3;
    private const int POT_STATE_IDLE = 0;
    private const int POT_STATE_RAISING = 1;
    private const int POT_STATE_SHAKING = 2;
    private const int COOKING_MAX_POTS = 4;
    private const int REPAIR_COMPONENT_STATE_NONE = 0;
    private const int REPAIR_COMPONENT_STATE_NEW = 1;
    private const int REPAIR_COMPONENT_STATE_BROKEN = 2;
    private const int REPAIR_COMPONENT_STATE_LOCKED = 3;
    private const int REPAIR_OUTRO_TIME = 3000;
    private const int REPAIR_BACKGROUND_COLOR = 9222898;
    private const int SHOPPING_STATE_NONE = -1;
    private const int SHOPPING_STATE_BROWSEMENU = 0;
    private const int SHOPPING_STATE_NO_MONEY = 1;
    private const int SHOPPING_STATE_TOO_MANY_CARS = 2;
    private const int SHOPPING_STATE_CONFIRM_BUY = 3;
    private const int TUTORIAL_STATE_INITIAL = 0;
    private const int TUTORIAL_STATE_CAMERAZOOMOUT = 1;
    private const int TUTORIAL_STATE_CAMERACONTROLS = 2;
    private const int TUTORIAL_STATE_MOVEMENT = 3;
    private const int TUTORIAL_STATE_INTERACT = 4;
    private const int TUTORIAL_STATE_WAIT_INTERACT = 5;
    private const int TUTORIAL_STATE_NEEDS = 6;
    private const int TUTORIAL_STATE_HUNGRY = 7;
    private const int TUTORIAL_STATE_AUTONOMOUS = 8;
    private const int TUTORIAL_STATE_WISHES = 9;
    private const int TUTORIAL_STATE_GOALS = 10;
    private const int TUTORIAL_STATE_MENU = 11;
    private const int HUD_MASK_NONE = 0;
    private const int HUD_MASK_ACTION_QUEUE = 1;
    private const int HUD_MASK_TIME = 2;
    private const int HUD_MASK_NEEDS = 4;
    private const int HUD_MASK_WISHES = 8;
    private const int HUD_MASK_ZOOM_SLIDER = 16;
    private const int HUD_MASK_BUFFS = 32;
    private const int HUD_MASK_RIGHT_BUTTON = 64;
    private const int HUD_MASK_LEFT_BUTTON = 128;
    private const int HUD_MASK_BUILD_BUTTON = 256;
    private const int HUD_MASK_BUFF_BAR = 512;
    private const int HUD_MASK_FIND_SIM = 1024;
    private const int HUD_MASK_MONEY = 2048;
    private const int HUD_MASK_ALL = -1;
    private const int CAM_TUTE_PAN = 1;
    private const int CAM_TUTE_ORBIT = 2;
    private const int CAM_TUTE_ZOOM = 4;
    private const int TUTORIAL_TIMER_NEEDS_DURATION = 3000;
    private const int TUTORIAL_TIMER_WISHES_DURATION = 5000;
    private XNAUnlockFullVersion xnaUnlockFullVersion;
    private bool backPressed;
    protected int[] m_tempInt10;
    private int m_state;
    private int m_stateTime;
    private int m_afterFadeState;
    private int m_nextScene;
    private int m_nextSceneState;
    private int m_initialState;
    private int m_mapMode;
    private bool m_suppressMenus;
    private int m_viewportX;
    private int m_viewportY;
    private int m_viewportWidth;
    private int m_viewportHeight;
    private short m_maxContextMenuItems;
    private int m_loadingState;
    private int m_loadingProgress;
    private JThread m_loadingThread;
    private int m_loadingThreadState;
    private int[][][][] m_simlish;
    private bool m_tutorialMessageActive;
    private int m_tuteHomeTimer;
    private int m_normalTimeStep;
    private bool m_isBuffPanelVisible;
    private float m_buffPanelSlideFactor;
    private int m_displayedMoney;
    private UIObjectPreview m_hudPlumbBob;
    private int HUD_ZOOMBAR_X;
    private int HUD_ZOOMBAR_Y;
    private int HUD_ZOOMBAR_W;
    private int HUD_ZOOMBAR_H;
    private int HUD_ZOOMBAR_TOP;
    private int HUD_ZOOMBAR_LENGTH;
    private bool m_zoomBarActive;
    private int m_postMessageBox;
    private int m_curtainState;
    private int m_curtainPlayerAction;
    private int m_curtainTime;
    private int m_tickerString1;
    private int m_tickerString2;
    private int m_tickerTimer;
    private int m_tickerOffsetF;
    private int m_tickerLengthF;
    private MapObject m_cursorObject;
    private int m_cursorSelectFlags;
    private int m_cameraState;
    private float m_cameraDestX;
    private float m_cameraDestY;
    private float m_cameraDestZ;
    private float m_cameraDestPitch;
    private float m_cameraDestYaw;
    private float m_cameraDestDolly;
    private bool m_cameraAtDest;
    private float m_cameraPreSnapX;
    private float m_cameraPreSnapY;
    private float m_cameraPreSnapZ;
    private float m_cameraPreSnapPitch;
    private float m_cameraPreSnapYaw;
    private float m_cameraPreSnapDolly;
    private MapObject m_cameraTarget;
    private float m_cameraDragVelX;
    private float m_cameraDragVelZ;
    private float m_cameraDragVelPitch;
    private float m_cameraDragVelYaw;
    private float m_cameraDragVelDolly;
    private int m_cameraDragReleaseTime;
    private int m_dragState;
    private bool m_snappingToBroken;
    private SignalFilter m_cameraFilterX;
    private SignalFilter m_cameraFilterY;
    private SignalFilter m_cameraFilterZ;
    private SignalFilter m_cameraFilterDolly;
    private SignalFilter m_cameraFilterPitch;
    private SignalFilter m_cameraFilterYaw;
    private MapObject[] m_objects;
    private MapObjectSim[] m_objectsSims;
    private MapObjectSim m_playerSim;
    private MapObject m_walkToMarker;
    private bool m_refreshObjects;
    private bool m_refreshObjectsSims;
    private int m_camTutesComplete;
    private bool m_contextMenuActive;
    private bool m_contextMenuOnSubMenu;
    private short m_contextMenuBackCursor;
    private int[] m_contextMenuItems;
    private int[] m_contextMenuActions;
    private int[] m_contextMenuFullActions;
    private MapObject m_contextMenuObject;
    private UIContextMenu m_contextMenu;
    private bool m_pauseMenuActive;
    private bool m_pauseMenuMediaPickerInGame;
    private int[] m_pauseMenuItems;
    private int m_pauseMenuState;
    private UIPauseMenu m_pauseMenu;
    private int m_buildModeState;
    private int m_buildModeNewType;
    private MapObject m_buildModeObject;
    private int m_buildModeRoomId;
    private int m_buildModeOldSetting;
    private int m_buildModeEffectX;
    private int m_buildModeEffectZ;
    private UIObjectPreview m_buildModePreview;
    private int BUILD_CAT_BUTTON_WIDTH;
    private int BUILD_CAT_BUTTON_HEIGHT;
    private int BUILD_CAT_BUTTONS_X;
    private int BUILD_CAT_BUTTONS_Y;
    private int BUILD_CAT_BUTTON_SPACING_X;
    private int BUILD_CAT_BUTTON_SPACING_Y;
    private int m_buildModeChosenCat;
    private int m_buildModeCatChooseTimer;
    private UIInfoScreen m_infoScreen;
    private int m_infoLoadedNPC;
    private int m_jobOfferCareer;
    private int m_jobOfferLevel;
    private int m_payIncome;
    private bool m_quitJobConfirmed;
    private bool m_showBonusUnlocked;
    private bool m_showNewDream;
    private bool m_showTutorial;
    private int m_showTutorialTitle;
    private int m_showTutorialBody;
    private AnimTimer[] m_dreamAnimTimers;
    private AnimTimer[] m_motiveAnimTimers;
    private int[] m_motiveHUDIndexes;
    private int m_showGetItem;
    private int m_showGetItemQty;
    private int m_showGetItemTitle;
    private int m_showGetItemMessage;
    private int m_simAIEventTimer;
    private int m_ambientEventTimer;
    private short[] m_ambientSounds;
    private int m_ambientSoundRate;
    private int m_simInactivityTimer;
    private int m_actionQueueSize;
    private int[] m_actionQueueActions;
    private MapObject[] m_actionQueueArg1s;
    private int[] m_actionQueueArg2s;
    private int[] m_actionQueueArg3s;
    private int m_displayedMoodLevel;
    private int m_timeHit;
    private int m_questId;
    private int m_questSimId;
    private int m_questState;
    private int m_chanceCardOutcome;
    private bool m_showFetchQuestEnd;
    private int m_eventState;
    private int m_eventId;
    private int m_eventSoundId;
    private int m_eventTimer;
    private int m_miniGameState;
    private MapObject m_miniGameTargetObject;
    private int m_miniGameType;
    private int m_minigameTipId;
    private int m_minigameSoundTimer;
    private int m_minigameSoundTimeMin;
    private int m_minigameSoundTimeMax;
    private int m_minigameAmbSound;
    private int m_curSelectedPot;
    private int m_prevSelectedPot;
    private int m_selectedPotState;
    private int m_miniGameTimer;
    private int m_miniGameOutroTimer;
    private int m_miniGameTimerMax;
    private int m_cookingPotCount;
    private int m_cookingPotActive;
    private int[] m_cookingLevelsF;
    private int[] m_displayedCookingLevelsF;
    private sbyte[] m_cookingPotContents;
    private int m_cookingDeadPotAnim;
    private float m_fishingFishPos;
    private float m_fishFlasherAlpha;
    private float m_fishFlasherAlphaStep;
    private float m_fishingFishPosFrom;
    private float m_fishingFishPosTo;
    private float m_fishingLevel;
    private float m_fishingFishSpeed;
    private float m_fishingMinFishMove;
    private int m_fishingFishType;
    private AnimPlayer3D m_miniGameFish;
    private AnimPlayer3D m_miniGameFishingRod;
    private float m_miniGameFishingTilt;
    private int m_preRepairColor;
    private int[] m_repairDataSkills;
    private int[][] m_repairDataJoints;
    private int[][] m_repairDataComponents;
    private int[][] m_repairDataConnections;
    private int[][] m_repairDataSkillIndices;
    private Model m_repairBoard;
    private AnimPlayer3D[] m_repairBoardCircuits;
    private AnimPlayer3D[] m_repairBoardSparks;
    private AnimPlayer3D m_repairBoardAnimPlayer;
    private int m_repairOutroTimer;
    private int[] m_repairComponentTypes;
    private int[] m_repairComponentStates;
    private int[][] m_repairComponentLocations;
    private m3g.Node[] m_repairComponents;
    private int[] m_repairComponentJoints;
    private m3g.Node[] m_repairComponentJointNodes;
    private int m_repairNumComponentsSlots;
    private int m_repairNumBrokenComponents;
    private int m_repairNumReplacedComponents;
    private int m_repairDragTarget;
    private bool m_repairIronActive;
    private int m_repairSolderingTimer;
    private int SLIDE_BAR_X;
    private int SLIDE_BAR_Y;
    private int SLIDE_BAR_WIDTH;
    private int m_shoppingState;
    private int m_shoppingTimeSinceLastPlusPress;
    private int m_shoppingTimeSinceLastMinusPress;
    private int[] m_shoppingBasketQtys;
    private int[] m_shoppingBasketItemIds;
    private int m_shoppingTally;
    private int[][] m_shoppingList;
    private int m_shoppingObjectType;
    private int m_tutorialState;
    private int m_HUDRenderMask;
    private bool m_pointerPressed;
    private int m_tutorialTimer;
    private bool m_tutorialGoalReached;
    private float m_tutorialPulseScale;
    private float m_tutorialPulseSpeed;
    private bool m_prevNotGoodMood;
    private Image imgTrashCan;
    private int m_numStereosPlaying;

    public SceneGame(AppEngine ae)
      : base(ae)
    {
        this.m_tempInt10 = new int[10];
        this.m_state = 0;
        this.m_stateTime = 0;
        this.m_afterFadeState = 0;
        this.m_nextScene = 0;
        this.m_nextSceneState = -1;
        this.m_initialState = 0;
        this.m_mapMode = 0;
        this.m_suppressMenus = false;
        this.m_viewportX = 0;
        this.m_viewportY = 0;
        this.m_viewportWidth = 0;
        this.m_viewportHeight = 0;
        this.m_maxContextMenuItems = (short)0;
        this.m_loadingState = 0;
        this.m_loadingThread = (JThread)null;
        this.m_loadingThreadState = 0;
        this.m_tutorialMessageActive = false;
        this.m_normalTimeStep = 0;
        this.m_isBuffPanelVisible = false;
        this.m_buffPanelSlideFactor = 0.0f;
        this.m_hudPlumbBob = (UIObjectPreview)null;
        this.m_displayedMoney = 0;
        this.m_postMessageBox = 0;
        this.m_curtainState = 0;
        this.m_curtainPlayerAction = 0;
        this.m_curtainTime = 0;
        this.m_tickerString1 = 0;
        this.m_tickerString2 = 0;
        this.m_tickerTimer = 0;
        this.m_tickerOffsetF = 0;
        this.m_tickerLengthF = 0;
        this.m_cursorObject = (MapObject)null;
        this.m_cursorSelectFlags = 0;
        this.m_cameraState = 0;
        this.m_cameraDestX = 0.0f;
        this.m_cameraDestY = 32f;
        this.m_cameraDestZ = 0.0f;
        this.m_cameraDestPitch = 45f;
        this.m_cameraDestYaw = 45f;
        this.m_cameraDestDolly = 300f;
        this.m_cameraAtDest = false;
        this.m_cameraPreSnapX = 0.0f;
        this.m_cameraPreSnapY = 32f;
        this.m_cameraPreSnapZ = 0.0f;
        this.m_cameraPreSnapPitch = 45f;
        this.m_cameraPreSnapYaw = 45f;
        this.m_cameraPreSnapDolly = 300f;
        this.m_cameraTarget = (MapObject)null;
        this.m_cameraDragVelX = 0.0f;
        this.m_cameraDragVelZ = 0.0f;
        this.m_cameraDragVelPitch = 0.0f;
        this.m_cameraDragVelYaw = 0.0f;
        this.m_cameraDragVelDolly = 0.0f;
        this.m_cameraDragReleaseTime = 0;
        this.m_dragState = 0;
        this.m_cameraFilterX = new SignalFilter(0, 1500f, 0.0f);
        this.m_cameraFilterY = new SignalFilter(0, 1500f, 0.0f);
        this.m_cameraFilterZ = new SignalFilter(0, 1500f, 0.0f);
        this.m_cameraFilterDolly = new SignalFilter(0, 1500f, 0.0f);
        this.m_cameraFilterPitch = new SignalFilter(0, 1500f, 0.0f);
        this.m_cameraFilterYaw = new SignalFilter(0, 1500f, 0.0f);
        this.m_objects = (MapObject[])null;
        this.m_objectsSims = (MapObjectSim[])null;
        this.m_playerSim = (MapObjectSim)null;
        this.m_walkToMarker = (MapObject)null;
        this.m_objectStack = new Stack<MapObject>();
        this.m_objectStackToRemove = new Stack<MapObject>();
        this.m_refreshObjects = false;
        this.m_refreshObjectsSims = false;
        this.m_contextMenuActive = false;
        this.m_contextMenuOnSubMenu = false;
        this.m_contextMenuBackCursor = (short)0;
        this.m_contextMenuItems = (int[])null;
        this.m_contextMenuActions = (int[])null;
        this.m_contextMenuFullActions = (int[])null;
        this.m_contextMenuObject = (MapObject)null;
        this.m_contextMenu = (UIContextMenu)null;
        this.m_pauseMenuActive = false;
        this.m_pauseMenuMediaPickerInGame = false;
        this.m_pauseMenuItems = (int[])null;
        this.m_pauseMenuState = 0;
        this.m_pauseMenu = (UIPauseMenu)null;
        this.m_buildModeState = 0;
        this.m_buildModeNewType = 0;
        this.m_buildModeObject = (MapObject)null;
        this.m_buildModeRoomId = -1;
        this.m_buildModeOldSetting = -1;
        this.m_buildModeEffectX = 0;
        this.m_buildModeEffectZ = 0;
        this.m_buildModePreview = (UIObjectPreview)null;
        this.m_infoScreen = (UIInfoScreen)null;
        this.m_infoLoadedNPC = 0;
        this.m_jobOfferCareer = 0;
        this.m_jobOfferLevel = 0;
        this.m_payIncome = 0;
        this.m_quitJobConfirmed = false;
        this.m_showBonusUnlocked = false;
        this.m_showNewDream = false;
        this.m_showTutorial = false;
        this.m_showTutorialTitle = 8;
        this.m_showTutorialBody = 8;
        this.m_dreamAnimTimers = (AnimTimer[])null;
        this.m_motiveAnimTimers = (AnimTimer[])null;
        this.m_motiveHUDIndexes = (int[])null;
        this.m_showGetItem = 0;
        this.m_showGetItemQty = 0;
        this.m_showGetItemTitle = 0;
        this.m_showGetItemMessage = 0;
        this.m_simAIEventTimer = 0;
        this.m_ambientEventTimer = 0;
        this.m_ambientSounds = (short[])null;
        this.m_ambientSoundRate = 0;
        this.m_simInactivityTimer = 0;
        this.m_actionQueueSize = 0;
        this.m_actionQueueActions = (int[])null;
        this.m_actionQueueArg1s = (MapObject[])null;
        this.m_actionQueueArg2s = (int[])null;
        this.m_actionQueueArg3s = (int[])null;
        this.m_displayedMoodLevel = 0;
        this.m_timeHit = 0;
        this.m_questId = 0;
        this.m_questSimId = 0;
        this.m_questState = 0;
        this.m_chanceCardOutcome = 0;
        this.m_showFetchQuestEnd = false;
        this.m_eventState = 0;
        this.m_eventId = 0;
        this.m_eventSoundId = -1;
        this.m_eventTimer = 0;
        this.m_miniGameState = 0;
        this.m_miniGameTargetObject = (MapObject)null;
        this.m_miniGameType = 0;
        this.m_miniGameTypeString = (string)null;
        this.m_miniGameTimer = 0;
        this.m_miniGameTimerMax = 0;
        this.m_cookingPotCount = 0;
        this.m_cookingPotActive = 0;
        this.m_cookingLevelsF = new int[4];
        this.m_displayedCookingLevelsF = new int[4];
        this.m_cookingPotContents = new sbyte[4];
        this.m_cookingDeadPotAnim = 0;
        this.m_fishingFishPos = 0.0f;
        this.m_fishingFishPosFrom = 0.0f;
        this.m_fishingFishPosTo = 0.0f;
        this.m_fishingLevel = 0.0f;
        this.m_fishingFishSpeed = 0.0f;
        this.m_fishingMinFishMove = 0.0f;
        this.m_fishingFishType = 0;
        this.m_shoppingState = -1;
        this.m_shoppingObjectType = 0;
        this.m_loadingProgress = 0;
        this.m_curSelectedPot = -1;
        this.m_prevSelectedPot = -1;
        this.m_selectedPotState = 0;
        this.m_miniGameFish = (AnimPlayer3D)null;
        this.m_miniGameFishingTilt = 0.0f;
        this.m_miniGameFishingRod = (AnimPlayer3D)null;
        this.m_repairBoard = (Model)null;
        this.m_repairBoardAnimPlayer = (AnimPlayer3D)null;
        this.m_repairBoardCircuits = (AnimPlayer3D[])null;
        this.m_repairOutroTimer = 0;
        this.m_repairComponents = (m3g.Node[])null;
        this.m_repairComponentJoints = (int[])null;
        this.m_repairComponentTypes = (int[])null;
        this.m_repairComponentStates = (int[])null;
        this.m_repairComponentLocations = (int[][])null;
        this.m_repairNumComponentsSlots = 0;
        this.m_repairNumBrokenComponents = 0;
        this.m_repairNumReplacedComponents = 0;
        this.m_repairDragTarget = -1;
        this.m_repairIronActive = false;
        this.m_repairSolderingTimer = 0;
        this.m_repairBoardSparks = (AnimPlayer3D[])null;
        this.HUD_ZOOMBAR_X = 0;
        this.HUD_ZOOMBAR_Y = 0;
        this.HUD_ZOOMBAR_W = 0;
        this.HUD_ZOOMBAR_H = 0;
        this.HUD_ZOOMBAR_TOP = 0;
        this.HUD_ZOOMBAR_LENGTH = 0;
        this.m_zoomBarActive = false;
        this.m_shoppingTimeSinceLastMinusPress = 0;
        this.m_shoppingTimeSinceLastPlusPress = 0;
        this.SLIDE_BAR_X = 0;
        this.SLIDE_BAR_Y = 0;
        this.SLIDE_BAR_WIDTH = 0;
        this.m_shoppingBasketQtys = (int[])null;
        this.m_shoppingBasketItemIds = (int[])null;
        this.m_shoppingList = (int[][])null;
        this.m_shoppingTally = 0;
        this.m_buildModeCatChooseTimer = -1;
        this.BUILD_CAT_BUTTON_WIDTH = 0;
        this.BUILD_CAT_BUTTON_HEIGHT = 0;
        this.BUILD_CAT_BUTTONS_X = 0;
        this.BUILD_CAT_BUTTONS_Y = 0;
        this.BUILD_CAT_BUTTON_SPACING_X = 0;
        this.BUILD_CAT_BUTTON_SPACING_Y = 0;
        this.m_buildModeChosenCat = 0;
        this.m_minigameTipId = -1;
        this.m_miniGameOutroTimer = 0;
        this.m_tuteHomeTimer = 300000;
        this.m_repairDataSkills = (int[])null;
        this.m_repairDataJoints = (int[][])null;
        this.m_repairDataComponents = (int[][])null;
        this.m_repairDataConnections = (int[][])null;
        this.m_repairDataSkillIndices = (int[][])null;
        this.m_repairComponentJointNodes = (m3g.Node[])null;
        this.m_fishFlasherAlphaStep = 3f;
        this.m_fishFlasherAlpha = 0.0f;
        this.m_HUDRenderMask = -1;
        this.m_camTutesComplete = 0;
        this.m_tutorialState = 0;
        this.m_pointerPressed = false;
        this.m_tutorialTimer = 0;
        this.m_tutorialGoalReached = false;
        this.m_tutorialPulseSpeed = 0.3f;
        this.m_tutorialPulseScale = 1f;
        this.m_numStereosPlaying = 0;
        this.m_snappingToBroken = false;
        this.m_prevNotGoodMood = false;
        this.m_preRepairColor = 0;
        this.m_simlish = (int[][][][])null;
        this.m_minigameSoundTimer = 0;
        this.m_minigameSoundTimeMin = 0;
        this.m_minigameSoundTimeMax = 0;
        this.m_minigameAmbSound = -1;
        AnimationManager3D animationManager3D = this.m_engine.getAnimationManager3D();
        this.m_pots[0] = new AnimPlayer3D(animationManager3D);
        this.m_pots[1] = new AnimPlayer3D(animationManager3D);
        this.m_pots[2] = new AnimPlayer3D(animationManager3D);
        this.m_pots[3] = new AnimPlayer3D(animationManager3D);
        this.m_miniGameFish = new AnimPlayer3D(animationManager3D);
        this.m_miniGameFishingRod = new AnimPlayer3D(animationManager3D);
        this.m_hudPlumbBob = new UIObjectPreview();
        this.m_xnaConnect = new XNAConnect();
    }

    public override void processInput(int _event, int[] args)
    {
        base.processInput(_event, args);
        if (this.m_state == 1 || this.isCurtainActive() && this.m_curtainState != 2 && !this.m_pauseMenuActive)
            return;
        AppEngine engine = this.m_engine;
        if (engine.fadeColorReached() && this.m_afterFadeState != 0)
        {
            this.stateTransition(this.m_afterFadeState);
            engine.startFadeIn();
            this.m_afterFadeState = 0;
        }
        else
        {
            if (engine.isFading())
                return;
            if (this.m_pauseMenuActive)
                this.processInputPauseMenu(_event, args);
            else if (!this.m_suppressMenus && this.m_contextMenuActive)
                this.processInputContextMenu(_event, args);
            else if (this.m_tutorialMessageActive)
            {
                this.processInputTutorialMessage(_event, args);
            }
            else
            {
                switch (this.m_state)
                {
                    case 3:
                        this.processInputSavePrompt(_event, args);
                        break;
                    case 4:
                        this.processInputChangePrompt(_event, args);
                        break;
                    case 6:
                        this.processInputMain(_event, args);
                        break;
                    case 7:
                        this.processInputBuildMode(_event, args);
                        break;
                    case 8:
                        this.processInputInfoScreen(_event, args);
                        break;
                    case 9:
                        this.processInputMessageBox(_event, args);
                        break;
                    case 10:
                        this.processInputJobOffer(_event, args);
                        break;
                    case 11:
                        this.processInputPay(_event, args);
                        break;
                    case 12:
                        this.processInputRaiseFailure(_event, args);
                        break;
                    case 13:
                        this.processInputQuitJob(_event, args);
                        break;
                    case 14:
                        this.processInputNewDream(_event, args);
                        break;
                    case 15:
                        this.processInputShowGetItem(_event, args);
                        break;
                    case 16:
                        this.processInputMiniGame(_event, args);
                        break;
                    case 17:
                        this.processInputShopping(_event, args);
                        break;
                    case 18:
                        this.processInputQuest(_event, args);
                        break;
                    case 19:
                        this.processInputEvent(_event, args);
                        break;
                    case 20:
                        if (Scene.checkCommand(_event, args, 32))
                        {
                            this.stateTransition(21);
                            break;
                        }
                        if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && !Scene.checkCommand(_event, args, 66))
                            break;
                        this.backPressed = true;
                        this.m_engine.setTutorialBeenPlayed();
                        this.m_simData.setMotiveLevel(0, 4915200);
                        this.m_simData.setMotiveLevel(2, 4915200);
                        this.m_simData.setMotiveLevel(1, 6553600);
                        this.m_simData.setMotiveLevel(5, 4915200);
                        this.m_simData.setMotiveLevel(3, 4915200);
                        this.m_simData.setMotiveLevel(4, 4915200);
                        this.stateTransition(6);
                        this.showTutorialMessage(35);
                        break;
                    case 21:
                        if (this.m_tutorialState == 10)
                        {
                            if (_event != 3)
                                break;
                            this.processPointerTapHUD(args[1], args[2]);
                            break;
                        }
                        if (this.m_tutorialState < 2)
                            break;
                        this.processInputMain(_event, args);
                        break;
                    case 22:
                        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 64))
                        {
                            this.stateTransition(6);
                            break;
                        }
                        if (!Scene.checkCommand(_event, args, 32))
                            break;
                        this.changeSceneWithFade(1, 33);
                        break;
                    case 23:
                        bool flag = GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed;
                        XNAButton.State state = this.xnaUnlockFullVersion.btnMenu.handleInput(_event, args);
                        if (flag || state == XNAButton.State.RELEASED)
                        {
                            this.changeScene(1, -1);
                            break;
                        }
                        if (this.xnaUnlockFullVersion.btnStore.handleInput(_event, args) != XNAButton.State.RELEASED)
                            break;
                        Guide.ShowMarketplace(PlayerIndex.One);
                        this.stateTransition(6);
                        break;
                }
            }
        }
    }

    private void processInputTutorialMessage(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && !Scene.checkCommand(_event, args, 2) && !Scene.checkCommand(_event, args, 4))
            return;
        this.hideTutorialMessage();
        this.backPressed = true;
    }

    private void processInputMain(int _event, int[] args)
    {
        if (_event == 3)
        {
            if (this.m_state == 21 && this.m_tutorialState < 3)
                return;
            this.processPointerTap(args);
        }
        else
            this.processInputCameraNavigation(_event, args);
    }

    private void processInputSavePrompt(int _event, int[] args)
    {
        if (Scene.checkCommand(_event, args, 32))
        {
            this.m_engine.saveRMSAppSettings();
            this.m_engine.saveRMSGameData();
            this.fadeStateTransition(2);
        }
        else
        {
            if (!Scene.checkCommand(_event, args, 64))
                return;
            this.fadeStateTransition(2);
        }
    }

    private void processInputChangePrompt(int _event, int[] args)
    {
        if (Scene.checkCommand(_event, args, 32))
        {
            this.fadeStateTransition(2);
        }
        else
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && !Scene.checkCommand(_event, args, 64))
                return;
            this.stateTransition(6);
            this.backPressed = true;
        }
    }

    private void processInputMessageBox(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && !Scene.checkCommand(_event, args, 6))
            return;
        this.backPressed = true;
        switch (this.m_postMessageBox)
        {
            case 0:
                this.stateTransition(6);
                break;
            case 1:
                this.gotoMap(false);
                break;
            case 2:
                if (this.getPlayerSim().getSimAction() == 170)
                    this.getPlayerSim().interrupt();
                this.stateTransition(6);
                break;
            case 3:
                this.triggerEvent(6);
                break;
            case 4:
                this.triggerEvent(7);
                break;
            case 6:
                this.stateTransition(21);
                this.stateTransitionTutorial(this.m_tutorialState + 1);
                break;
            case 7:
                this.triggerEvent(0);
                break;
            case 8:
                this.triggerEvent(8);
                break;
            case 9:
                this.triggerEvent(1);
                break;
            case 10:
                this.triggerEvent(4);
                break;
        }
    }

    public void processInputCameraNavigation(int _event, int[] args)
    {
        if (this.m_cameraState == 2 || this.m_cameraState == 3 || this.m_cameraState == 4)
            return;
        switch (_event)
        {
            case 0:
                this.m_zoomBarActive = this.inHUDZoomBarRange(args);
                this.m_pointerPressed = true;
                break;
            case 2:
                this.m_pointerPressed = false;
                break;
            case 3:
            case 7:
                this.clearCameraFollow();
                break;
            case 4:
                this.clearCameraFollow();
                break;
            case 5:
                this.clearCameraFollow();
                this.resetCameraVelocity();
                int num1 = args[9];
                int num2 = args[1];
                int num3 = args[2];
                int num4 = args[5];
                int num5 = args[6];
                int num6 = num4 - num2;
                int num7 = num5 - num3;
                float cameraDolly1 = this.m_simWorld.getCameraDolly();
                float num8 = this.isMapMode() ? 1.5f : 0.5f;
                float num9 = this.isMapMode() ? 1f / 1000f : 1f / 1000f;
                int num10 = this.isMapMode() ? 800 : 150;
                float num11 = num8 + num9 * (cameraDolly1 - (float)num10);
                float num12 = (float)-num6 * num11;
                float num13 = (float)-num7 * num11;
                float radians = MathExt.degreesToRadians(this.m_simWorld.getCameraYaw());
                float num14 = midp.JMath.Cos(radians);
                float num15 = midp.JMath.Sin(radians);
                float num16 = (float)((double)num14 * (double)num12 + (double)num15 * (double)num13);
                float num17 = (float)(-(double)num15 * (double)num12 + (double)num14 * (double)num13);
                float vecX = num16;
                float vecZ = num17;
                this.m_cameraDragVelYaw = 0.0f;
                this.m_cameraDragVelPitch = 0.0f;
                this.m_cameraDragVelDolly = 0.0f;
                float[] rangeSlowdownFactor = this.m_simWorld.getCamRangeSlowdownFactor(vecX, vecZ);
                float num18 = rangeSlowdownFactor[0];
                float num19 = rangeSlowdownFactor[1];
                this.m_cameraDragVelX = num18 / (float)num1;
                this.m_cameraDragVelZ = num19 / (float)num1;
                this.m_cameraDragReleaseTime = 700;
                float cameraPosX = this.m_simWorld.getCameraPosX();
                float cameraPosZ = this.m_simWorld.getCameraPosZ();
                this.m_simWorld.setCameraPosX(cameraPosX + num18);
                this.m_simWorld.setCameraPosZ(cameraPosZ + num19);
                this.completeCamTute(1);
                break;
            case 8:
                this.clearCameraFollow();
                this.resetCameraVelocity();
                this.stateTransitionDragging(0);
                break;
            case 9:
                this.clearCameraFollow();
                int a = args[9];
                int num20 = args[1];
                int num21 = args[2];
                int num22 = args[5];
                int num23 = args[6];
                int num24 = args[3];
                int num25 = args[4];
                int num26 = args[7];
                int num27 = args[8];
                bool flag = false;
                if (num20 == num22 && num21 == num23 || num24 == num26 && num25 == num27)
                {
                    flag = num20 != num22 || num21 != num23 || (num24 != num26 || num25 != num27);
                }
                else
                {
                    float num28 = (float)((num24 - num20) * (num27 - num21) - (num26 - num20) * (num25 - num21));
                    float num29 = (float)((num24 - num20) * (num23 - num21) - (num22 - num20) * (num25 - num21));
                    if ((double)num28 > 0.0 && (double)num29 < 0.0 || (double)num28 < 0.0 && (double)num29 > 0.0)
                        flag = true;
                }
                if (flag)
                {
                    float[] numArray1 = new float[2];
                    float[] numArray2 = new float[2];
                    numArray1[0] = (float)(num24 - num20);
                    numArray1[1] = (float)(num25 - num21);
                    numArray2[0] = (float)(num26 - num22);
                    numArray2[1] = (float)(num27 - num23);
                    float num28 = (float)(System.Math.Atan2((double)numArray2[1], (double)numArray2[0]) - System.Math.Atan2((double)numArray1[1], (double)numArray1[0])) * 57.29578f;
                    this.m_simWorld.setCameraYaw(this.m_simWorld.getCameraYaw() + num28);
                    this.m_cameraDragVelYaw = num28 / (float)a;
                    this.m_cameraDragVelYaw = MathExt.clip(this.m_cameraDragVelYaw, -0.5f, 0.5f);
                    this.completeCamTute(2);
                }
                else
                    this.m_cameraDragVelYaw = 0.0f;
                float num30 = (float)(num21 + num25) / 2f;
                float num31 = (float)(num23 + num27) / 2f - num30;
                float cameraPitch = this.m_simWorld.getCameraPitch();
                float pitch = midp.JMath.min(75f, midp.JMath.max(15f, cameraPitch + num31 * 0.7f));
                this.m_simWorld.setCameraPitch(pitch);
                this.m_cameraDragVelPitch = (float)(((double)pitch - (double)cameraPitch) / 2.0) / (float)a;
                float num32 = MathExt.mag2((float)(num24 - num20), (float)(num25 - num21)) - MathExt.mag2((float)(num26 - num22), (float)(num27 - num23));
                float cameraDolly2 = this.m_simWorld.getCameraDolly();
                float b = cameraDolly2 - (float)((double)num32 * (double)a * 0.00499999988824129);
                float dolly = midp.JMath.min(this.isMapMode() ? 1800f : 750f, midp.JMath.max(this.isMapMode() ? 800f : 150f, b));
                this.m_simWorld.setCameraDolly(dolly);
                this.completeCamTute(4);
                this.m_cameraDragVelDolly = (dolly - cameraDolly2) / (float)midp.JMath.max(a, 1);
                this.m_cameraDragReleaseTime = 700;
                break;
            case 10:
                this.stateTransitionDragging(0);
                this.pointerReset();
                break;
        }
    }

    private void processInputContextMenu(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 2))
        {
            this.processContextMenuBack();
            this.backPressed = true;
        }
        else if (Scene.checkCommand(_event, args, 16))
        {
            this.hideMenus();
            this.setCameraUnsnap();
        }
        else
        {
            if (!Scene.checkCommand(_event, args, 8))
                return;
            this.processContextMenuSelect();
        }
    }

    private void processInputPauseMenu(int _event, int[] args)
    {
        AppEngine engine = this.m_engine;
        if (this.getSharedMenuState() != -1)
        {
            this.processInputSharedMenu(_event, args);
        }
        else
        {
            switch (this.m_pauseMenuState)
            {
                case 0:
                    if (Scene.checkCommand(_event, args, 2) || GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    {
                        this.hidePauseMenu();
                        this.backPressed = true;
                        break;
                    }
                    if (!Scene.checkCommand(_event, args, int.MinValue))
                        break;
                    this.processBasicAction(args[2]);
                    break;
                case 1:
                case 2:
                    if (Scene.checkCommand(_event, args, 32))
                    {
                        engine.saveRMSAppSettings();
                        engine.saveRMSGameData();
                        if (this.m_pauseMenuState == 2)
                        {
                            SpywareManager.getInstance().trackEndGame();
                            this.changeSceneWithFade(1, -1);
                            break;
                        }
                        this.hidePauseMenu();
                        break;
                    }
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && !Scene.checkCommand(_event, args, 66))
                        break;
                    this.stateTransitionPauseMenu(0);
                    break;
                case 3:
                    break;
                case 4:
                    this.m_leaderboardsMenu.processInput(_event, args);
                    break;
                case 5:
                    this.m_achievementsMenu.processInput(_event, args);
                    break;
                case 6:
                    this.m_achievementDetailMenu.processInput(_event, args);
                    break;
                default:
                    AppEngine.ASSERT(false, "invalid state");
                    break;
            }
        }
    }

    private void processInputBuildMode(int _event, int[] args)
    {
        switch (this.m_buildModeState)
        {
            case 1:
            case 15:
                this.processInputBuildModeEdit(_event, args);
                break;
            case 2:
                this.processInputBuildModeSelect(_event, args);
                break;
            case 3:
            case 7:
            case 8:
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && !Scene.checkCommand(_event, args, 6))
                    break;
                this.stateTransitionBuildMode(2);
                break;
            case 4:
            case 12:
                this.processInputBuildModePlace(_event, args);
                break;
            case 5:
                this.processInputBuildModeBuyConfirm(_event, args);
                break;
            case 9:
                this.processInputBuildModeSellConfirm(_event, args);
                break;
            case 10:
            case 11:
                this.processInputBuildModeUpgradeConfirm(_event, args);
                break;
            case 13:
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 4))
                {
                    this.stateTransitionBuildMode(0);
                    this.backPressed = true;
                    break;
                }
                if (Scene.checkCommand(_event, args, 65536))
                {
                    this.stateTransitionBuildMode(1);
                    this.showTutorialMessage(26);
                    break;
                }
                if (Scene.checkCommand(_event, args, 32768))
                {
                    this.stateTransitionBuildMode(15);
                    this.showTutorialMessage(32);
                    break;
                }
                if (Scene.checkCommand(_event, args, 131072))
                {
                    this.stateTransitionBuildMode(14);
                    break;
                }
                if (!Scene.checkCommand(_event, args, 262144))
                    break;
                this.upgradeHouse();
                break;
            case 14:
                this.processInputBuildModeChooseCat(_event, args);
                break;
            case 16:
            case 17:
            case 18:
                this.processInputBuildModeChangeFloor(_event, args);
                break;
            case 19:
            case 20:
            case 21:
            case 22:
                this.processInputBuildModeChangeFloorConfirm(_event, args);
                break;
        }
    }

    private void processInputBuildModeChooseCat(int _event, int[] args)
    {
        if (_event == 3)
        {
            int x = args[1];
            int y = args[2];
            int buildCatButtonsX = this.BUILD_CAT_BUTTONS_X;
            int rectY = this.BUILD_CAT_BUTTONS_Y;
            for (int index = 0; index < 6; ++index)
            {
                if (UIElement.isInBox(x, y, buildCatButtonsX, rectY, this.BUILD_CAT_BUTTON_WIDTH, this.BUILD_CAT_BUTTON_HEIGHT))
                {
                    this.m_buildModeChosenCat = index;
                    this.m_buildModeCatChooseTimer = 1000;
                    this.playSound(21);
                    break;
                }
                if (index == 2)
                {
                    buildCatButtonsX = this.BUILD_CAT_BUTTONS_X;
                    rectY = this.BUILD_CAT_BUTTONS_Y + this.BUILD_CAT_BUTTON_HEIGHT + this.BUILD_CAT_BUTTON_SPACING_Y;
                }
                else
                    buildCatButtonsX += this.BUILD_CAT_BUTTON_WIDTH + this.BUILD_CAT_BUTTON_SPACING_X;
            }
        }
        else
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && !Scene.checkCommand(_event, args, 2))
                return;
            this.stateTransitionBuildMode(13);
        }
    }

    private void processInputBuildModeEdit(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 524288))
        {
            this.stateTransitionBuildMode(13);
            this.backPressed = true;
        }
        else
        {
            if (this.getActiveUIElement() != null)
                return;
            if (_event == 3)
                this.processPointerTap(args);
            else
                this.processInputCameraNavigation(_event, args);
        }
    }

    private void processInputBuildModeSelect(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 2))
        {
            this.stateTransitionBuildMode(14);
        }
        else
        {
            if (_event != 3)
                return;
            int num1 = args[1];
            int num2 = args[2];
            UIList uiList = this.getUIList(8);
            if (!uiList.isInDragArea(num1, num2))
                return;
            int itemAt = uiList.getItemAt(num1, num2);
            if (itemAt < 0 || itemAt >= uiList.getItemCount())
                return;
            int nthItemOfCategory = this.m_simWorld.getFurnitureNthItemOfCategory(itemAt, this.m_buildModeChosenCat);
            this.m_buildModeNewType = nthItemOfCategory;
            if (!this.m_simWorld.isFurnitureAvailable(nthItemOfCategory))
            {
                this.playSound(20);
                this.stateTransitionBuildMode(8);
            }
            else if (this.m_simData.getMoney() >= this.m_simWorld.getObjectBuyPrice(this.m_buildModeNewType))
            {
                if (this.m_simWorld.createBuildPoints(this.m_buildModeNewType) > 0)
                {
                    this.playSound(21);
                    this.stateTransitionBuildMode(4);
                }
                else
                {
                    this.playSound(20);
                    this.stateTransitionBuildMode(3);
                }
            }
            else
            {
                this.playSound(20);
                this.stateTransitionBuildMode(7);
                this.showTutorialMessage(29);
            }
        }
    }

    private void processInputBuildModePlace(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 524288))
        {
            this.removeBuildPoints();
            if (this.m_buildModeState == 12)
            {
                MapObject buildModeObject = this.m_buildModeObject;
                buildModeObject.applyFootprint(true);
                buildModeObject.unhide();
                this.m_buildModeObject = (MapObject)null;
                this.stateTransitionBuildMode(1);
            }
            else
                this.stateTransitionBuildMode(2);
            this.backPressed = true;
        }
        else
        {
            if (this.getActiveUIElement() != null)
                return;
            if (_event == 3)
            {
                int screenX = args[1];
                int screenY = args[2];
                int wallDepthAt = this.m_simWorld.getWallDepthAt(screenX, screenY);
                MapObject @object = this.findObjectAtScreen(screenX, screenY, wallDepthAt);
                if (@object == null)
                    return;
                int facingDir = @object.getFacingDir();
                if (@object.getType() == 15)
                {
                    facingDir = @object.getFacingDir();
                    @object = @object.getBuildPointSelector();
                }
                if (this.m_buildModeState == 12)
                {
                    this.showTutorialMessage(28);
                    this.m_buildModeObject.unhide();
                    this.m_buildModeObject.reposition(@object.getPosX(), @object.getPosY(), @object.getPosZ(), facingDir);
                    this.m_buildModeObject.applyFootprint(true);
                    this.m_simWorld.objectChange(this.m_buildModeObject.getId(), @object.getPosX(), @object.getPosZ(), facingDir);
                    this.m_buildModeObject = (MapObject)null;
                    this.removeBuildPoints();
                    this.stateTransitionBuildMode(1);
                    this.playSound(64);
                }
                else
                {
                    this.setCursorObject(@object);
                    this.stateTransitionBuildMode(5);
                }
            }
            else
                this.processInputCameraNavigation(_event, args);
        }
    }

    private void processInputBuildModeBuyConfirm(int _event, int[] args)
    {
        if (Scene.checkCommand(_event, args, 32))
        {
            this.processInputBuildModePlaceObject(false);
        }
        else
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && !Scene.checkCommand(_event, args, 66))
                return;
            this.stateTransitionBuildMode(4);
        }
    }

    private void processInputBuildModeSellConfirm(int _event, int[] args)
    {
        if (Scene.checkCommand(_event, args, 32))
        {
            MapObject buildModeObject = this.m_buildModeObject;
            AppEngine.ASSERT(buildModeObject != null, "Can't sell null object");
            int type = buildModeObject.getType();
            this.m_simWorld.objectSell(buildModeObject.getId());
            this.processCancelAction(buildModeObject);
            int objectSellPrice = this.m_simWorld.getObjectSellPrice(type);
            this.m_simData.adjustMoney(objectSellPrice);
            int num1 = (buildModeObject.getFootprintX() - 1) * 2097152 >> 1;
            int num2 = (buildModeObject.getFootprintZ() - 1) * 2097152 >> 1;
            this.createEffectMoney(buildModeObject.getPosX() - num1, buildModeObject.getPosZ() - num2, objectSellPrice);
            buildModeObject.destroy();
            this.stateTransitionBuildMode(1);
            this.playSound(83);
            this.getSimData().triggerSoldSomething();
        }
        else
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && !Scene.checkCommand(_event, args, 66))
                return;
            this.stateTransitionBuildMode(1);
        }
    }

    private void processInputBuildModeUpgradeConfirm(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 70))
        {
            this.stateTransitionBuildMode(0);
        }
        else
        {
            if (!Scene.checkCommand(_event, args, 32))
                return;
            this.m_simData.adjustMoney(-this.m_simWorld.getHouseUpgradeCost());
            this.m_simWorld.upgradePlayerHouse();
            this.playSound(72);
            this.stateTransitionBuildMode(0);
            this.startCurtainIn();
            this.m_curtainPlayerAction = 149;
        }
    }

    private void processInputBuildModeChangeFloor(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 32))
        {
            int listId = -1;
            int num1 = 0;
            int num2 = -1;
            int state1 = -1;
            int state2 = -1;
            switch (this.m_buildModeState)
            {
                case 16:
                    listId = 10;
                    num1 = 50;
                    num2 = this.m_simWorld.getUnlockedFloorIndex(this.m_buildModeOldSetting);
                    state1 = 21;
                    state2 = 19;
                    break;
                case 17:
                    listId = 11;
                    num1 = 50;
                    num2 = this.m_simWorld.getUnlockedWallIndex(this.m_buildModeOldSetting);
                    state1 = 22;
                    state2 = 20;
                    break;
            }
            if (this.getUIList(listId).getSelectedIdx() != num2)
            {
                if (num1 <= this.m_simData.getMoney())
                    this.stateTransitionBuildMode(state2);
                else
                    this.stateTransitionBuildMode(state1);
            }
            else
                this.stateTransitionBuildMode(15);
            this.backPressed = true;
        }
        else
        {
            if (!Scene.checkCommand(_event, args, int.MinValue))
                return;
            int index = args[2];
            switch (this.m_buildModeState)
            {
                case 16:
                    this.m_simWorld.changeFloor(this.m_buildModeRoomId, this.m_simWorld.getUnlockedFloorNthId(index), false);
                    break;
                case 17:
                    this.m_simWorld.changeWall(this.m_buildModeRoomId, this.m_simWorld.getUnlockedWallNthId(index), false);
                    break;
            }
        }
    }

    private void processInputBuildModeChangeFloorConfirm(int _event, int[] args)
    {
        if (Scene.checkCommand(_event, args, 32))
        {
            int num = 0;
            switch (this.m_buildModeState)
            {
                case 19:
                    this.m_simWorld.changeFloor(this.m_buildModeRoomId, this.m_simWorld.getUnlockedFloorNthId(this.getUIList(10).getSelectedIdx()), true);
                    num = 50;
                    break;
                case 20:
                    this.m_simWorld.changeWall(this.m_buildModeRoomId, this.m_simWorld.getUnlockedWallNthId(this.getUIList(11).getSelectedIdx()), true);
                    num = 50;
                    break;
            }
            this.m_simData.adjustMoney(-num);
            this.createEffectMoney(this.m_buildModeEffectX, this.m_buildModeEffectZ, -num);
            this.stateTransitionBuildMode(15);
        }
        else
        {
            if (!Scene.checkCommand(_event, args, 68))
                return;
            switch (this.m_buildModeState)
            {
                case 19:
                case 21:
                    this.m_simWorld.changeFloor(this.m_buildModeRoomId, this.m_buildModeOldSetting, false);
                    break;
                case 20:
                case 22:
                    this.m_simWorld.changeWall(this.m_buildModeRoomId, this.m_buildModeOldSetting, false);
                    break;
            }
            this.stateTransitionBuildMode(15);
        }
    }

    private void processInputInfoScreen(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 128))
        {
            this.backPressed = true;
            this.hideInfoScreen();
        }
        else if (Scene.checkCommand(_event, args, 1024))
        {
            this.hideInfoScreen();
            this.goHome();
        }
        else if (Scene.checkCommand(_event, args, 256))
        {
            this.hideInfoScreen();
            this.gotoWork();
            if ((this.m_simData.getTimeFlags(0) & 1) == 0)
                return;
            this.awardAchievment(2);
        }
        else
        {
            if (!Scene.checkCommand(_event, args, 512))
                return;
            this.hideInfoScreen();
            this.gotoMap(true);
        }
    }

    private void processInputJobOffer(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 68))
        {
            this.stateTransition(6);
            this.backPressed = true;
        }
        else
        {
            if (!Scene.checkCommand(_event, args, 32))
                return;
            SimData simData = this.m_simData;
            int simCareer = simData.getSimCareer(0);
            int simCareerLevel = simData.getSimCareerLevel(0);
            int jobOfferCareer = this.m_jobOfferCareer;
            int jobOfferLevel = this.m_jobOfferLevel;
            simData.careerAcceptJob(jobOfferCareer, jobOfferLevel);
            if (simCareer != jobOfferCareer && jobOfferCareer != -1)
                simData.dreamCompleteEvent(19);
            if (simCareer == jobOfferCareer && simCareerLevel < jobOfferLevel)
                simData.dreamCompleteEvent(53);
            if (jobOfferLevel == simData.getCareerLevelCount(jobOfferCareer) - 1)
                simData.dreamCompleteEvent(54);
            if (jobOfferCareer == 2 && this.m_simData.getAchievements(1))
                this.awardAchievment(15);
            this.reloadPlayerCar();
        }
    }

    private void processInputPay(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && !Scene.checkCommand(_event, args, 6))
            return;
        this.backPressed = true;
        SimData simData = this.m_simData;
        if (simData.careerAutoPromotionDue())
            this.showJobOffer(simData.getSimCareer(0), simData.getSimCareerLevel(0) + 1, false);
        else if (this.m_engine.randPercent() < 15)
            this.triggerChanceCard(this.m_simData.getChanceCardForWork());
        else
            this.stateTransition(6);
    }

    private void processInputRaiseFailure(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && !Scene.checkCommand(_event, args, 4))
            return;
        this.stateTransition(6);
        this.backPressed = true;
    }

    private void processInputQuitJob(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 70))
        {
            this.stateTransition(6);
            this.backPressed = true;
        }
        else
        {
            if (!Scene.checkCommand(_event, args, 32))
                return;
            this.m_simData.careerAcceptJob(-1, 0);
            this.m_quitJobConfirmed = true;
            this.prepareMessageBox(1072, 535);
            this.reloadPlayerCar();
        }
    }

    private void processInputNewDream(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 70))
        {
            if (this.m_tutorialState == 9)
                this.stateTransition(21);
            else
                this.stateTransition(6);
            this.backPressed = true;
        }
        else
        {
            if (!Scene.checkCommand(_event, args, 32))
                return;
            if (this.m_simData.isDreamToPromisePossible())
                this.m_simData.dreamToPromise();
            if (this.m_tutorialState == 9)
                this.stateTransition(21);
            else
                this.stateTransition(6);
        }
    }

    private void processInputShowGetItem(int _event, int[] args)
    {
        if (!Scene.checkCommand(_event, args, 4))
            return;
        this.m_showGetItem = -1;
        this.stateTransition(6);
    }

    private void processInputQuest(int _event, int[] args)
    {
        SimData simData = this.m_simData;
        switch (this.m_questState)
        {
            case 0:
                if (Scene.checkCommand(_event, args, 32))
                {
                    this.m_chanceCardOutcome = simData.getChanceCardOutcome(this.m_questId, true);
                    this.stateTransitionQuest(1);
                    break;
                }
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && !Scene.checkCommand(_event, args, 66))
                    break;
                this.m_chanceCardOutcome = simData.getChanceCardOutcome(this.m_questId, false);
                this.stateTransitionQuest(1);
                break;
            case 1:
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && !Scene.checkCommand(_event, args, 6))
                    break;
                this.stateTransitionQuest(4);
                simData.performChanceCardOutcome(this.m_questId, this.m_chanceCardOutcome);
                break;
            case 2:
                if (!Scene.checkCommand(_event, args, 4))
                    break;
                int questFlags = simData.getQuestFlags(this.m_questId);
                if ((questFlags & 2) != 0)
                    this.showTutorialMessage(9);
                else if ((questFlags & 4) != 0)
                    this.showTutorialMessage(10);
                this.stateTransitionQuest(4);
                break;
            case 3:
                if (!Scene.checkCommand(_event, args, 4))
                    break;
                simData.questCompleted(this.m_questId);
                this.stateTransitionQuest(4);
                break;
        }
    }

    public void triggerEvent(int _event)
    {
        this.m_simData.delayAlerts();
        this.m_engine.vibrate();
        this.m_eventId = _event;
        this.stateTransition(19);
        this.stateTransitionEvent(1);
        int mask = 0;
        switch (_event)
        {
            case 0:
                mask = 2048;
                this.m_eventSoundId = 12;
                break;
            case 1:
                mask = 4096;
                this.m_eventSoundId = 14;
                break;
            case 2:
                mask = 8192;
                this.m_eventSoundId = 13;
                break;
            case 3:
                mask = 16384;
                this.m_eventSoundId = 13;
                break;
            case 4:
                mask = 32768;
                this.m_eventSoundId = 17;
                break;
            case 5:
                mask = 65536;
                this.m_eventSoundId = 16;
                break;
            case 6:
                mask = 131072;
                this.m_eventSoundId = 15;
                break;
            case 7:
                mask = 262144;
                this.m_eventSoundId = 15;
                break;
            case 8:
                mask = 524288;
                this.m_eventSoundId = 17;
                break;
        }
        this.m_engine.loadAllImages(mask);
    }

    private void processInputEvent(int _event, int[] args)
    {
        if (this.m_eventState != 3 || GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && _event != 3)
            return;
        this.triggerTapper(args[1], args[2]);
        this.stateTransitionEvent(4);
    }

    private void processInputMiniGame(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 3))
            this.showPauseMenu();
        else if (Scene.checkCommand(_event, args, 524288))
        {
            this.stateTransitionMiniGame(4);
        }
        else
        {
            if (this.m_miniGameState != 1)
                return;
            switch (this.m_miniGameType)
            {
                case 0:
                    this.processInputMiniGameCooking(_event, args);
                    break;
                case 2:
                    this.processInputMiniGameRepairing(_event, args);
                    break;
            }
        }
    }

    private void processInputMiniGameCooking(int _event, int[] args)
    {
        if (_event != 3)
            return;
        int[] result1 = new int[3];
        int[] result2 = new int[3];
        int x = args[1];
        int y = args[2];
        for (int pot = 0; pot < this.m_cookingPotCount; ++pot)
        {
            m3g.Node node = m3g.Node.m3g_cast(this.m_pots[pot].getNode().find(3100));
            this.m_miniGameTargetObject.getModel().getLocatorPos(result1, node);
            this.m_simWorld.coordWorldToScreen(result2, result1[0], result1[1], result1[2]);
            if (UIElement.isInRadius(x, y, result2[0], result2[1], 20))
            {
                this.selectPot(pot);
                break;
            }
        }
    }

    private void processInputMiniGameRepairing(int _event, int[] args)
    {
        if (this.m_miniGameState != 1)
            return;
        switch (_event)
        {
            case 0:
                this.repairPickObject(args[1], args[2]);
                break;
            case 1:
                int pointerEndX = args[1];
                int pointerEndY = args[2];
                if (this.m_repairDragTarget == -1)
                    break;
                this.setRepairTargetPosition(pointerEndX, pointerEndY);
                break;
            case 2:
                int pointerX = args[1];
                int pointerY = args[2];
                if (this.m_repairDragTarget == -1)
                    break;
                if (this.m_repairComponentStates[this.m_repairDragTarget] == 2)
                {
                    if (this.isOverBin(pointerX, pointerY))
                        this.destroyBrokenComponent();
                    else
                        this.resetRepairTarget();
                }
                else if (this.m_repairComponentStates[this.m_repairDragTarget] == 1)
                {
                    if (this.getComponentGapType(pointerX, pointerY) == this.m_repairComponentTypes[this.m_repairDragTarget])
                        this.replaceComponent(pointerX, pointerY);
                    else
                        this.resetRepairTarget();
                }
                this.clearRepairTarget();
                break;
        }
    }

    private void processInputShopping(int _event, int[] args)
    {
        switch (this.m_shoppingState)
        {
            case 0:
                this.processInputShoppingBrowse(_event, args);
                break;
            case 1:
            case 2:
                if (!Scene.checkCommand(_event, args, 4))
                    break;
                this.stateTransitionShopping(0);
                break;
            case 3:
                this.processInputShoppingConfirm(_event, args);
                break;
        }
    }

    private void processInputShoppingBrowse(int _event, int[] args)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
        {
            this.stateTransitionShopping(-1);
            this.backPressed = true;
        }
        else
        {
            switch (_event)
            {
                case 0:
                    int x = args[1];
                    int y = args[2];
                    int selectedIdx = this.getUIList(7).getSelectedIdx();
                    int itemNthItem1 = this.m_simWorld.getItemNthItem(this.m_shoppingObjectType, selectedIdx);
                    int itemMaxInventory = this.m_simWorld.getItemMaxInventory(itemNthItem1);
                    if (UIElement.isInRadius(x, y, 258, 285, 20))
                    {
                        this.m_shoppingTimeSinceLastMinusPress = 0;
                        if (this.m_shoppingBasketQtys[selectedIdx] == 0)
                            this.playSound(20);
                        else if (this.m_simWorld.getItemSellPrice(itemNthItem1) > 0 || this.m_simData.getInventoryCount(itemNthItem1) < this.m_shoppingBasketQtys[selectedIdx])
                        {
                            this.playSound(21);
                            int num = midp.JMath.max(0, this.m_shoppingBasketQtys[selectedIdx] - 1);
                            this.m_shoppingBasketQtys[selectedIdx] = num;
                        }
                        else
                            this.playSound(20);
                    }
                    else if (UIElement.isInRadius(x, y, 333, 285, 20))
                    {
                        this.m_shoppingTimeSinceLastPlusPress = 0;
                        if (this.m_shoppingBasketQtys[selectedIdx] == itemMaxInventory)
                        {
                            this.playSound(20);
                        }
                        else
                        {
                            this.playSound(21);
                            int num = midp.JMath.min(this.m_shoppingBasketQtys[selectedIdx] + 1, itemMaxInventory);
                            this.m_shoppingBasketQtys[selectedIdx] = num;
                            this.excludeShopping(2, selectedIdx);
                        }
                    }
                    this.tallyShopping();
                    break;
                case 11:
                    if (Scene.checkCommand(_event, args, 524288))
                    {
                        this.stateTransitionShopping(-1);
                        break;
                    }
                    if (!Scene.checkCommand(_event, args, 32))
                        break;
                    if (this.m_shoppingTally > this.m_simData.getMoney())
                    {
                        this.stateTransitionShopping(1);
                        break;
                    }
                    bool flag = false;
                    for (int index = 0; index < this.m_shoppingBasketQtys.Length; ++index)
                    {
                        int itemNthItem2 = this.m_simWorld.getItemNthItem(this.m_shoppingObjectType, index);
                        if (this.m_shoppingBasketQtys[index] != this.m_simData.getInventoryCount(itemNthItem2))
                        {
                            flag = true;
                            break;
                        }
                    }
                    int num1 = 0;
                    int num2 = 0;
                    int itemCount = this.m_simWorld.getItemCount();
                    for (int index1 = 0; index1 < itemCount; ++index1)
                    {
                        if ((this.m_simWorld.getItemFlags(index1) & 2) != 0)
                        {
                            int index2 = AppEngine.indexOf(index1, this.m_shoppingBasketItemIds);
                            if (index2 != -1)
                            {
                                if (this.m_shoppingBasketQtys[index2] > 0 && this.m_simData.getInventoryCount(index1) <= 0)
                                    ++num2;
                            }
                            else if (this.m_simData.getInventoryCount(index1) > 0)
                                ++num1;
                        }
                    }
                    if (num2 + num1 > 1)
                    {
                        this.stateTransitionShopping(2);
                        break;
                    }
                    if (!flag)
                        break;
                    this.stateTransitionShopping(3);
                    break;
            }
        }
    }

    private void processInputShoppingConfirm(int _event, int[] args)
    {
        if (Scene.checkCommand(_event, args, 32))
        {
            this.m_simData.adjustMoney(-this.m_shoppingTally);
            for (int index = 0; index < this.m_shoppingBasketQtys.Length; ++index)
            {
                int itemNthItem = this.m_simWorld.getItemNthItem(this.m_shoppingObjectType, index);
                int inventoryCount = this.m_simData.getInventoryCount(itemNthItem);
                int num = this.m_shoppingBasketQtys[index] - inventoryCount;
                this.m_simData.adjustInventory(itemNthItem, num);
                if (num > 0)
                {
                    this.m_simData.registerBuyItem(itemNthItem);
                    SpywareManager.getInstance().trackBuyItem(itemNthItem, num);
                    this.m_simData.numPurchases += num;
                }
            }
            this.playSound(72);
            this.stateTransitionShopping(-1);
            this.reloadPlayerCar();
        }
        else
        {
            if (!Scene.checkCommand(_event, args, 64) && GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed)
                return;
            this.stateTransitionShopping(0);
            this.backPressed = true;
        }
    }

    public new void Dispose()
    {
        for (int index = this.m_dreamAnimTimers.Length - 1; index >= 0; --index)
            this.m_dreamAnimTimers[index] = (AnimTimer)null;
        for (int index = this.m_motiveAnimTimers.Length - 1; index >= 0; --index)
            this.m_motiveAnimTimers[index] = (AnimTimer)null;
        if (this.m_contextMenu != null)
        {
            this.removeUIElement((UIElement)this.m_contextMenu);
            this.m_contextMenu = (UIContextMenu)null;
        }
        if (this.m_pauseMenu != null)
        {
            this.removeUIElement((UIElement)this.m_pauseMenu);
            this.m_pauseMenu = (UIPauseMenu)null;
        }
        if (this.m_infoScreen != null)
        {
            this.removeUIElement((UIElement)this.m_infoScreen);
            this.m_infoScreen = (UIInfoScreen)null;
        }
        if (this.m_hudPlumbBob != null)
            this.m_hudPlumbBob = (UIObjectPreview)null;
        this.m_pots[0].Dispose();
        this.m_pots[1].Dispose();
        this.m_pots[2].Dispose();
        this.m_pots[3].Dispose();
        this.m_miniGameFish.Dispose();
        this.m_miniGameFishingRod.Dispose();
    }

    public bool isHouseMode()
    {
        return this.m_mapMode == 0;
    }

    public bool isMapMode()
    {
        return this.m_mapMode == 2;
    }

    public bool isZoomMapMode()
    {
        return this.m_mapMode == 1;
    }

    private void updateLoading(int timeStep)
    {
        this.updateLoading(timeStep, this.m_loadingProgress);
        if (this.m_loadingThread == null)
        {
            if (!this.m_engine.isFading())
            {
                this.m_loadingThread = new JThread(this);
                this.m_loadingThread.getSystemThread().IsBackground = true;
                this.m_loadingThreadState = 0;
                this.m_loadingThread.start();
            }
        }
        else
            JThread.sleep(1);
        if (this.m_loadingState != 5 || !this.isLoadbarFull())
            return;
        int eventId = 5;
        if (this.isHouseMode())
            eventId = 4;
        else if (this.isZoomMapMode())
            eventId = 3;
        this.m_engine.getBgMusic().playMusic(eventId, 0);
        if (!this.m_engine.hasTutorialBeenPlayed())
            this.stateTransition(20);
        else
            this.stateTransition(this.m_initialState);
        if (this.isMapMode())
        {
            this.m_engine.setRMSHasSeenTutorial(24);
            this.showTutorialMessage(1);
        }
        else if (this.isZoomMapMode() && this.m_engine.getNextZoomMapId() == 4)
            this.showTutorialMessage(2);
        else if (this.isHouseMode() && this.m_state != 20)
            this.showTutorialMessage(35);
        this.checkTriggers();
        this.m_engine.setFadeStep(197379);
        this.m_engine.startFadeIn();
    }

    public override void run()
    {
        while (this.m_loadingThreadState != 2)
        {
            if (this.m_loadingThreadState != 0)
                JThread.sleep(1000);
            else
                this.updateLoadingState();
        }
    }

    private void updateLoadingState()
    {
        AppEngine.timerBegin();
        AppEngine engine = this.m_engine;
        switch (this.m_loadingState)
        {
            case 0:
                this.m_loadingProgress = 10;
                ++this.m_loadingState;
                break;
            case 1:
                this.m_simWorld.setViewport(this.m_viewportX, this.m_viewportY, this.m_viewportWidth, this.m_viewportHeight);
                this.m_refreshObjects = true;
                this.m_refreshObjectsSims = true;
                bool flag = true;
                if (this.m_mapMode == 2)
                {
                    this.m_loadingProgress = 50;
                    this.initMacroMap();
                }
                else if (this.m_mapMode == 1)
                {
                    this.m_loadingProgress = 50;
                    this.initZoomMap();
                    if (this.getSimObjects().Length > 1)
                        flag = false;
                }
                else
                {
                    this.m_loadingProgress = 50;
                    if (this.m_initialState == 96)
                        flag = false;
                    this.initHouseMap();
                }
                if (flag)
                {
                    this.setCameraLookAt((MapObject)this.getPlayerSim());
                    this.snapCameraPosition();
                    this.setCameraLookAt((MapObject)null);
                }
                this.m_simWorld.setCameraPosY(32f);
                this.m_simWorld.setCameraYaw(45f);
                this.m_simWorld.setCameraPitch(45f);
                this.m_simWorld.setCameraDolly(this.isMapMode() ? 1000f : 300f);
                this.m_simWorld.updateCameraPos(0);
                this.stateTransitionCamera(0);
                this.clearCameraFollow();
                this.snapCameraPosition();
                this.cameraStorePreSnap();
                ++this.m_loadingState;
                this.m_loadingProgress = 60;
                engine.loadImagesBegin();
                break;
            case 2:
                int mask = 16;
                switch (this.m_mapMode)
                {
                    case 0:
                        mask |= 32;
                        break;
                    case 1:
                        if (engine.getNextZoomMapId() == 4)
                        {
                            mask |= 512;
                            break;
                        }
                        if (engine.getNextZoomMapId() == 183)
                        {
                            mask |= 1024;
                            break;
                        }
                        break;
                    case 2:
                        mask |= 64;
                        break;
                    default:
                        AppEngine.ASSERT(false, "invalid map mode");
                        break;
                }
                this.initXNAMenus();
                if (engine.loadImagesNext(mask))
                {
                    ++this.m_loadingState;
                    this.m_loadingProgress = 80;
                    break;
                }
                this.m_loadingProgress += 10;
                break;
            case 3:
                int status = 2;
                if (this.isMapMode())
                    status = 4;
                else if (this.isZoomMapMode())
                    status = 5;
                else if (this.getSimWorld().getHouseId() == 0)
                    status = 3;
                this.m_hudPlumbBob.loadPlumbBobObject(false);
                ModelManager.getInstance().setLoadStatus(status);
                ++this.m_loadingState;
                this.m_loadingProgress = 90;
                break;
            case 4:
                SoundManager soundManager = engine.getSoundManager();
                short[] numArray1 = new short[0];
                short[] numArray2;
                int num;
                if (this.isMapMode())
                {
                    numArray2 = new short[SceneGame.AMBIENT_MM_SOUNDS.Length];
                    midp.JSystem.arraycopy((Array)SceneGame.AMBIENT_MM_SOUNDS, 0, (Array)numArray2, 0, SceneGame.AMBIENT_MM_SOUNDS.Length);
                    num = 3000;
                }
                else
                {
                    if (engine.getNextZoomMapId() == 4)
                    {
                        numArray2 = new short[SceneGame.AMBIENT_LAKESIDE_SOUNDS.Length];
                        midp.JSystem.arraycopy((Array)SceneGame.AMBIENT_LAKESIDE_SOUNDS, 0, (Array)numArray2, 0, SceneGame.AMBIENT_LAKESIDE_SOUNDS.Length);
                        num = 8000;
                    }
                    else if (engine.getNextZoomMapId() == 183)
                    {
                        numArray2 = new short[SceneGame.AMBIENT_MM_SOUNDS.Length];
                        midp.JSystem.arraycopy((Array)SceneGame.AMBIENT_MM_SOUNDS, 0, (Array)numArray2, 0, SceneGame.AMBIENT_MM_SOUNDS.Length);
                        num = 10000;
                    }
                    else
                    {
                        numArray2 = new short[SceneGame.AMBIENT_LAKESIDE_SOUNDS.Length];
                        midp.JSystem.arraycopy((Array)SceneGame.AMBIENT_LAKESIDE_SOUNDS, 0, (Array)numArray2, 0, SceneGame.AMBIENT_LAKESIDE_SOUNDS.Length);
                        num = 8000;
                    }
                    this.loadSimlish();
                }
                this.loadSFX();
                for (int index = 0; index < numArray2.Length; ++index)
                    soundManager.loadEvent((int)numArray2[index]);
                this.m_ambientSounds = numArray2;
                this.m_ambientSoundRate = num;
                this.m_loadingThreadState = 2;
                ++this.m_loadingState;
                this.m_loadingProgress = 100;
                this.m_simWorld.initCamera();
                this.initHUDZoomBar();
                this.readRepairData();
                break;
        }
        AppEngine.timerEnd("SceneGame::updateLoadingState");
    }

    private void loadSimlish()
    {
        SoundManager soundManager = this.m_engine.getSoundManager();
        soundManager.loadEvent(42);
        soundManager.loadEvent(43);
        soundManager.loadEvent(44);
        soundManager.loadEvent(45);
        soundManager.loadEvent(47);
        soundManager.loadEvent(49);
        soundManager.loadEvent(46);
        soundManager.loadEvent(50);
        soundManager.loadEvent(48);
        soundManager.loadEvent(51);
        soundManager.loadEvent(52);
        soundManager.loadEvent(53);
        soundManager.loadEvent(54);
        soundManager.loadEvent(56);
        soundManager.loadEvent(58);
        soundManager.loadEvent(55);
        soundManager.loadEvent(59);
        soundManager.loadEvent(57);
        soundManager.loadEvent(24);
        soundManager.loadEvent(25);
        soundManager.loadEvent(26);
        soundManager.loadEvent(27);
        soundManager.loadEvent(29);
        soundManager.loadEvent(31);
        soundManager.loadEvent(28);
        soundManager.loadEvent(32);
        soundManager.loadEvent(30);
        soundManager.loadEvent(33);
        soundManager.loadEvent(34);
        soundManager.loadEvent(35);
        soundManager.loadEvent(36);
        soundManager.loadEvent(38);
        soundManager.loadEvent(40);
        soundManager.loadEvent(37);
        soundManager.loadEvent(41);
        soundManager.loadEvent(39);
        int[] numArray = new int[7] { 1, 3, 1, 1, 1, 1, 1 };
        this.m_simlish = new int[7][][][];
        for (int index1 = 0; index1 < 7; ++index1)
        {
            int length = numArray[index1];
            this.m_simlish[index1] = new int[2][][];
            for (int index2 = 0; index2 < 2; ++index2)
            {
                this.m_simlish[index1][index2] = new int[2][];
                for (int index3 = 0; index3 < 2; ++index3)
                    this.m_simlish[index1][index2][index3] = new int[length];
            }
        }
        int index4 = 0;
        int index5 = 0;
        this.m_simlish[0][index5][0][index4] = 42;
        this.m_simlish[0][index5][1][index4] = 24;
        int index6 = 1;
        this.m_simlish[0][index6][0][index4] = 51;
        this.m_simlish[0][index6][1][index4] = 33;
        int index7 = 0;
        this.m_simlish[1][index7][0][index4] = 43;
        this.m_simlish[1][index7][0][index4 + 1] = 44;
        this.m_simlish[1][index7][0][index4 + 2] = 45;
        this.m_simlish[1][index7][1][index4] = 25;
        this.m_simlish[1][index7][1][index4 + 1] = 26;
        this.m_simlish[1][index7][1][index4 + 2] = 26;
        int index8 = 1;
        this.m_simlish[1][index8][0][index4] = 52;
        this.m_simlish[1][index8][0][index4 + 1] = 53;
        this.m_simlish[1][index8][0][index4 + 2] = 54;
        this.m_simlish[1][index8][1][index4] = 34;
        this.m_simlish[1][index8][1][index4 + 1] = 35;
        this.m_simlish[1][index8][1][index4 + 2] = 36;
        int index9 = 0;
        this.m_simlish[2][index9][0][index4] = 46;
        this.m_simlish[2][index9][1][index4] = 28;
        int index10 = 1;
        this.m_simlish[2][index10][0][index4] = 55;
        this.m_simlish[2][index10][1][index4] = 37;
        int index11 = 0;
        this.m_simlish[3][index11][0][index4] = 47;
        this.m_simlish[3][index11][1][index4] = 29;
        int index12 = 1;
        this.m_simlish[3][index12][0][index4] = 56;
        this.m_simlish[3][index12][1][index4] = 38;
        int index13 = 0;
        this.m_simlish[4][index13][0][index4] = 48;
        this.m_simlish[4][index13][1][index4] = 30;
        int index14 = 1;
        this.m_simlish[4][index14][0][index4] = 57;
        this.m_simlish[4][index14][1][index4] = 39;
        int index15 = 0;
        this.m_simlish[5][index15][0][index4] = 49;
        this.m_simlish[5][index15][1][index4] = 31;
        int index16 = 1;
        this.m_simlish[5][index16][0][index4] = 58;
        this.m_simlish[5][index16][1][index4] = 40;
        int index17 = 0;
        this.m_simlish[6][index17][0][index4] = 50;
        this.m_simlish[6][index17][1][index4] = 32;
        int index18 = 1;
        this.m_simlish[6][index18][0][index4] = 59;
        this.m_simlish[6][index18][1][index4] = 41;
    }

    private void unloadSimlish()
    {
        SoundManager soundManager = this.m_engine.getSoundManager();
        soundManager.unloadEvent(42);
        soundManager.unloadEvent(43);
        soundManager.unloadEvent(47);
        soundManager.unloadEvent(49);
        soundManager.unloadEvent(46);
        soundManager.unloadEvent(50);
        soundManager.unloadEvent(48);
        soundManager.unloadEvent(51);
        soundManager.unloadEvent(52);
        soundManager.unloadEvent(56);
        soundManager.unloadEvent(58);
        soundManager.unloadEvent(55);
        soundManager.unloadEvent(59);
        soundManager.unloadEvent(57);
        soundManager.unloadEvent(24);
        soundManager.unloadEvent(25);
        soundManager.unloadEvent(29);
        soundManager.unloadEvent(31);
        soundManager.unloadEvent(28);
        soundManager.unloadEvent(32);
        soundManager.unloadEvent(30);
        soundManager.unloadEvent(33);
        soundManager.unloadEvent(34);
        soundManager.unloadEvent(38);
        soundManager.unloadEvent(40);
        soundManager.unloadEvent(37);
        soundManager.unloadEvent(41);
        soundManager.unloadEvent(39);
    }

    public int getSimlish(int theme, int voice, int sex)
    {
        int index = this.m_engine.rand(0, this.m_simlish[theme][voice][sex].Length - 1);
        return this.m_simlish[theme][voice][sex][index];
    }

    private void loadSFX()
    {
        SoundManager soundManager = this.m_engine.getSoundManager();
        if (this.isMapMode())
        {
            soundManager.loadEvent(72);
            soundManager.loadEvent(65);
            soundManager.loadEvent(83);
        }
        if (this.isZoomMapMode())
        {
            soundManager.loadEvent(73);
            soundManager.loadEvent(75);
            soundManager.loadEvent(76);
            soundManager.loadEvent(66);
            soundManager.loadEvent(84);
            soundManager.loadEvent(85);
            soundManager.loadEvent(86);
        }
        else
        {
            soundManager.loadEvent(64);
            soundManager.loadEvent(65);
            soundManager.loadEvent(16);
            soundManager.loadEvent(66);
            soundManager.loadEvent(71);
            soundManager.loadEvent(70);
            soundManager.loadEvent(69);
            soundManager.loadEvent(67);
            soundManager.loadEvent(68);
            soundManager.loadEvent(76);
            soundManager.loadEvent(74);
            soundManager.loadEvent(77);
            soundManager.loadEvent(79);
            soundManager.loadEvent(80);
            soundManager.loadEvent(81);
            soundManager.loadEvent(82);
            soundManager.loadEvent(78);
            soundManager.loadEvent(83);
            soundManager.loadEvent(84);
            soundManager.loadEvent(85);
            soundManager.loadEvent(86);
        }
        soundManager.loadEvent(12);
        soundManager.loadEvent(14);
        soundManager.loadEvent(13);
        soundManager.loadEvent(17);
        soundManager.loadEvent(15);
        soundManager.loadEvent(23);
    }

    private void unloadSFX()
    {
        SoundManager soundManager = this.m_engine.getSoundManager();
        if (this.isMapMode())
        {
            soundManager.unloadEvent(72);
            soundManager.unloadEvent(65);
            soundManager.unloadEvent(83);
        }
        if (this.isZoomMapMode())
        {
            soundManager.unloadEvent(73);
            soundManager.unloadEvent(75);
            soundManager.unloadEvent(76);
            soundManager.unloadEvent(66);
        }
        else
        {
            soundManager.unloadEvent(64);
            soundManager.unloadEvent(65);
            soundManager.unloadEvent(16);
            soundManager.unloadEvent(66);
            soundManager.unloadEvent(71);
            soundManager.unloadEvent(70);
            soundManager.unloadEvent(69);
            soundManager.unloadEvent(67);
            soundManager.unloadEvent(68);
            soundManager.unloadEvent(76);
            soundManager.unloadEvent(74);
            soundManager.unloadEvent(77);
            soundManager.unloadEvent(79);
            soundManager.unloadEvent(80);
            soundManager.unloadEvent(81);
            soundManager.unloadEvent(82);
            soundManager.unloadEvent(78);
            soundManager.unloadEvent(83);
        }
        soundManager.unloadEvent(12);
        soundManager.unloadEvent(14);
        soundManager.unloadEvent(13);
        soundManager.unloadEvent(17);
        soundManager.unloadEvent(15);
        soundManager.unloadEvent(23);
    }

    public bool simSpaceAvailable()
    {
        return !this.isMapMode() && this.getSimObjects().Length < 4;
    }

    public override int getSceneID()
    {
        return 2;
    }

    public override void start(int initialState)
    {
        AppEngine engine = this.m_engine;
        SimData simData = engine.getSimData();
        this.initUI();
        simData.newScene();
        this.m_state = 0;
        this.m_stateTime = 0;
        this.m_afterFadeState = 0;
        this.m_nextScene = 0;
        this.m_nextSceneState = -1;
        this.m_suppressMenus = false;
        this.m_viewportX = 0;
        this.m_viewportY = 0;
        this.m_viewportWidth = engine.getWidth();
        this.m_viewportHeight = engine.getHeight();
        this.m_maxContextMenuItems = (short)(this.m_viewportHeight / 26);
        this.m_loadingThread = (JThread)null;
        this.m_loadingThreadState = 0;
        this.m_tutorialMessageActive = false;
        this.m_normalTimeStep = 0;
        this.m_displayedMoney = simData.getMoney();
        this.m_postMessageBox = 0;
        this.m_curtainState = 0;
        this.m_tickerString1 = -1;
        this.m_tickerString2 = -1;
        this.m_cursorObject = (MapObject)null;
        this.m_cursorSelectFlags = 0;
        this.m_cameraState = 0;
        this.m_cameraDestX = 0.0f;
        this.m_cameraDestY = 32f;
        this.m_cameraDestZ = 0.0f;
        this.m_cameraDestPitch = 45f;
        this.m_cameraDestYaw = 45f;
        this.m_cameraDestDolly = 300f;
        this.m_cameraAtDest = false;
        this.m_cameraPreSnapX = 0.0f;
        this.m_cameraPreSnapY = 32f;
        this.m_cameraPreSnapZ = 0.0f;
        this.m_cameraPreSnapPitch = 45f;
        this.m_cameraPreSnapYaw = 45f;
        this.m_cameraPreSnapDolly = 300f;
        this.m_cameraTarget = (MapObject)null;
        this.m_cameraDragVelX = 0.0f;
        this.m_cameraDragVelZ = 0.0f;
        this.m_cameraDragVelPitch = 0.0f;
        this.m_cameraDragVelYaw = 0.0f;
        this.m_cameraDragVelDolly = 0.0f;
        this.m_cameraDragReleaseTime = 0;
        this.m_dragState = 0;
        if (!this.m_simWorld.isLoaded())
        {
            this.m_objects = new MapObject[0];
            this.m_objectsSims = new MapObjectSim[0];
            this.m_playerSim = (MapObjectSim)null;
            this.m_walkToMarker = (MapObject)null;
            this.m_objectStack.Clear();
            this.m_objectStackToRemove.Clear();
        }
        this.m_refreshObjects = true;
        this.m_refreshObjectsSims = true;
        this.m_contextMenuActive = false;
        this.m_contextMenuOnSubMenu = false;
        this.m_contextMenuBackCursor = (short)0;
        if (this.m_contextMenuItems == null)
        {
            this.m_contextMenuItems = new int[55];
            this.m_contextMenuActions = new int[55];
            this.m_contextMenuFullActions = new int[55];
        }
        this.m_contextMenuObject = (MapObject)null;
        if (this.m_contextMenu == null)
        {
            this.m_contextMenu = new UIContextMenu();
            this.addUIElement((UIElement)this.m_contextMenu);
        }
        this.m_pauseMenuActive = false;
        this.m_pauseMenuMediaPickerInGame = false;
        this.initPauseMenu();
        this.m_buildModeState = 0;
        this.m_buildModeObject = (MapObject)null;
        this.m_buildModePreview = new UIObjectPreview();
        if (this.m_infoScreen == null)
        {
            this.m_infoScreen = new UIInfoScreen();
            this.addUIElement((UIElement)this.m_infoScreen);
        }
        this.m_infoLoadedNPC = 0;
        this.m_jobOfferCareer = 0;
        this.m_jobOfferLevel = 0;
        this.m_payIncome = 0;
        this.m_quitJobConfirmed = false;
        this.m_showBonusUnlocked = false;
        this.m_showNewDream = false;
        this.m_showTutorial = false;
        this.m_showGetItem = -1;
        this.m_showGetItemQty = 0;
        this.m_showGetItemTitle = 0;
        this.m_showGetItemMessage = 0;
        this.m_simAIEventTimer = 0;
        this.m_ambientEventTimer = 0;
        this.m_ambientSounds = new short[0];
        this.m_simInactivityTimer = 0;
        this.initActionQueue();
        this.m_displayedMoodLevel = simData.getMoodLevel();
        this.m_timeHit = 0;
        this.m_showFetchQuestEnd = false;
        this.m_eventState = 0;
        this.m_miniGameState = 0;
        this.m_miniGameTargetObject = (MapObject)null;
        this.m_miniGameTypeString = (string)null;
        if (this.m_cookingLevelsF == null)
        {
            this.m_cookingLevelsF = new int[4];
            this.m_displayedCookingLevelsF = new int[4];
            this.m_cookingPotContents = new sbyte[4];
        }
        this.m_shoppingState = -1;
        if (this.m_dreamAnimTimers == null)
        {
            this.m_dreamAnimTimers = new AnimTimer[5];
            for (int index = 0; index < this.m_dreamAnimTimers.Length; ++index)
                this.m_dreamAnimTimers[index] = new AnimTimer();
            this.m_motiveAnimTimers = new AnimTimer[simData.getMotiveCount()];
            for (int index = 0; index < this.m_motiveAnimTimers.Length; ++index)
                this.m_motiveAnimTimers[index] = new AnimTimer();
            this.m_motiveHUDIndexes = new int[this.m_motiveAnimTimers.Length];
        }
        AppEngine.fillArray(this.m_motiveHUDIndexes, 0);
        this.m_mapMode = 0;
        switch (initialState)
        {
            case -1:
                initialState = 6;
                break;
            case 97:
                this.m_timeHit = 30;
                initialState = 6;
                break;
            case 98:
                this.m_mapMode = 2;
                initialState = 6;
                break;
            case 99:
                this.m_mapMode = 2;
                break;
            case 100:
                this.m_mapMode = 1;
                initialState = 6;
                break;
        }
        this.m_initialState = initialState;
        if (this.isZoomMapMode())
            this.m_engine.getBgMusic().playMusic(3, 0);
        SpywareManager.getInstance().trackArrive();
        this.stateTransition(1);
    }

    private void initPauseMenu()
    {
        int[] menu = new int[15];
        AppEngine.menuClear(menu, 57);
        if (MediaPicker.isAvailable())
            AppEngine.menuAppendItem(menu, 1731);
        AppEngine.menuAppendItem(menu, 49);
        AppEngine.menuAppendItem(menu, 50);
        if (!TheSims3.IsTrialMode && XNAConnect.getGamer() != null)
        {
            AppEngine.menuAppendItem(menu, 1814);
            AppEngine.menuAppendItem(menu, 1815);
        }
        AppEngine.menuAppendItem(menu, 60);
        AppEngine.menuAppendItem(menu, 62);
        this.m_pauseMenuItems = menu;
        this.m_pauseMenuState = 0;
        this.m_pauseMenu = new UIPauseMenu();
        this.addUIElement((UIElement)this.m_pauseMenu);
    }

    public override void pause()
    {
        if (this.m_state == 1 && this.m_loadingThreadState != 2)
            this.m_loadingThreadState = 1;
        if (this.m_state != 6 || this.m_pauseMenuActive || this.m_tutorialMessageActive)
            return;
        this.showPauseMenu();
    }

    public override void resume()
    {
        if (this.m_state != 1 || this.m_loadingThreadState != 1)
            return;
        this.m_loadingThreadState = 0;
    }

    public override void end()
    {
        this.writeLeaderboard(3, this.getSimData().numFriendships, TimeSpan.Zero);
        this.writeLeaderboard(4, this.getSimData().numJobsWorked, TimeSpan.Zero);
        this.writeLeaderboard(1, this.getSimData().mostMoneyEarned, TimeSpan.Zero);
        this.writeLeaderboard(0, 0, this.getSimData().totalAppRunTime);
        this.writeLeaderboard(2, this.getSimData().numPurchases, TimeSpan.Zero);
        this.writeLeaderboard(5, 0, this.getSimData().totalTimeMaintained);
        this.m_loadingThreadState = 2;
        this.m_loadingThread.join();
        this.m_loadingThread = (JThread)null;
        foreach (MapObject @object in this.getObjects())
            this.removeObject(@object);
        this.getObjects();
        this.getSimObjects();
        this.m_buildModePreview = (UIObjectPreview)null;
        for (int index = 0; index < this.m_objects.Length; ++index)
            this.m_objects[index] = (MapObject)null;
        for (int index = 0; index < this.m_objectsSims.Length; ++index)
            this.m_objectsSims[index] = (MapObjectSim)null;
        this.m_objectStack.Clear();
        this.m_objectStackToRemove.Clear();
        this.m_refreshObjects = true;
        if (this.m_simWorld != null)
            this.m_simWorld.unload();
        int mask = 2032;
        if (this.m_engine.getNextSceneId() == 2)
            mask &= -17;
        this.m_engine.unloadAllImages(mask, -1);
        this.m_engine.saveRMSGameData();
        SoundManager soundManager = this.m_engine.getSoundManager();
        this.unloadSimlish();
        this.unloadSFX();
        for (int index = 0; index < this.m_ambientSounds.Length; ++index)
            soundManager.unloadEvent((int)this.m_ambientSounds[index]);
        SpywareManager.getInstance().trackLeave();
    }

    public override void render(Graphics g)
    {
        this.startUI();
        AppEngine engine = this.m_engine;
        switch (this.m_state)
        {
            case 1:
                this.renderLoading(g);
                break;
            case 3:
            case 4:
            case 9:
            case 20:
            case 22:
                this.renderMain(g);
                if (this.m_messageBox.getTitleStringId() == 1708)
                    this.renderInfoScreen(g);
                engine.renderBackgroundDim(g);
                this.drawGenericMessageBox(g);
                break;
            case 6:
            case 21:
                this.renderMain(g);
                break;
            case 7:
                this.renderBuildMode(g);
                break;
            case 8:
                this.renderInfoScreen(g);
                break;
            case 10:
                this.renderJobOffer(g);
                break;
            case 11:
                this.renderPay(g);
                break;
            case 12:
                this.renderRaiseFailure(g);
                break;
            case 13:
                this.renderQuitJob(g);
                break;
            case 14:
                this.renderNewDream(g);
                break;
            case 15:
                this.renderShowGetItem(g);
                break;
            case 16:
                this.renderMiniGame(g);
                break;
            case 17:
                this.renderShopping(g);
                break;
            case 18:
                this.renderQuest(g);
                break;
            case 19:
                this.renderEvent(g);
                break;
            case 23:
                this.xnaUnlockFullVersion.Render(g);
                break;
            default:
                this.renderLoading(g);
                break;
        }
        if (this.m_tutorialMessageActive)
            this.drawGenericMessageBox(g);
        this.endUI();
        this.renderTapper(g);
    }

    public override void update(int timeStep)
    {
        if (Guide.IsVisible)
            return;
        base.update(timeStep);
        this.m_stateTime += timeStep;
        if (TheSims3.IsTrialMode)
        {
            if (this.m_state == 6)
                this.m_simData.DemoTime += timeStep;
            if ((this.m_simData.DemoTime > 300000 || this.m_engine.getNumGoalsComplete() >= 3) && this.m_state == 6)
                this.stateTransition(23);
        }
        if (this.m_state == 1)
        {
            this.updateLoading(timeStep);
        }
        else
        {
            this.updateHUD(timeStep);
            if (this.m_pauseMenuActive)
            {
                this.updatePauseMenu(timeStep);
            }
            else
            {
                switch (this.m_state)
                {
                    case 6:
                        this.updateMain(timeStep);
                        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                        {
                            this.showPauseMenu();
                            break;
                        }
                        break;
                    case 7:
                        this.updateBuildMode(timeStep);
                        break;
                    case 8:
                        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                        {
                            this.hideInfoScreen();
                            break;
                        }
                        break;
                    case 16:
                        this.updateMiniGame(timeStep);
                        this.updateCamera(timeStep);
                        break;
                    case 17:
                        this.m_shoppingTimeSinceLastMinusPress += timeStep;
                        this.m_shoppingTimeSinceLastPlusPress += timeStep;
                        if (this.m_showTutorial)
                        {
                            this.checkTriggers();
                            break;
                        }
                        break;
                    case 19:
                        this.updateEvent(timeStep);
                        break;
                    case 21:
                        this.updateMain(timeStep);
                        this.updateTutorial(timeStep);
                        break;
                    case 23:
                        this.xnaUnlockFullVersion.Update(timeStep);
                        break;
                }
                this.backPressed = false;
            }
        }
    }

    public void stateTransition(int newState)
    {
        AppEngine engine = this.m_engine;
        int state = this.m_state;
        this.m_state = newState;
        this.m_stateTime = 0;
        this.m_suppressMenus = true;
        switch (newState)
        {
            case 1:
                this.m_loadingState = 0;
                this.m_contextMenuActive = false;
                this.m_pauseMenuActive = false;
                this.m_engine.getBgMusic().playMusic(1, 2);
                break;
            case 2:
                if (this.m_nextSceneState == 97)
                    this.m_engine.setNextHouseId(0);
                engine.changeScene(this.m_nextScene, this.m_nextSceneState);
                break;
            case 3:
                this.hideMenus();
                this.prepareConfirmBox(73, 59);
                break;
            case 4:
                this.hideMenus();
                int stringId = -1;
                if (this.m_nextScene == 2)
                {
                    switch (this.m_nextSceneState)
                    {
                        case 97:
                            stringId = 1589;
                            break;
                        case 98:
                            stringId = 1588;
                            break;
                        case 100:
                            stringId = this.m_engine.getNextZoomMapId() != 4 ? 1592 : 1591;
                            break;
                        default:
                            stringId = this.m_engine.getNextHouseId() == 0 ? 1589 : 1590;
                            break;
                    }
                }
                this.prepareConfirmBox(stringId, 1601);
                break;
            case 5:
                engine.endGame();
                break;
            case 6:
                this.setCursorSelectFlags(2);
                this.m_suppressMenus = false;
                break;
            case 7:
                this.m_suppressMenus = false;
                break;
            case 11:
                this.m_payIncome = this.m_simData.careerDayWorked();
                this.prepareCustomMessageBox(1070, 1069);
                break;
            case 15:
                this.prepareCustomMessageBox(this.m_showGetItemMessage, this.m_showGetItemTitle);
                break;
            case 20:
                this.prepareConfirmBox(1714, 70);
                break;
            case 21:
                this.m_suppressMenus = false;
                if (state == 9 || state == 14)
                    break;
                this.stateTransitionTutorial(0);
                break;
            case 22:
                this.prepareConfirmBox(1728, 506);
                break;
            case 23:
                if (this.xnaUnlockFullVersion != null)
                    break;
                this.xnaUnlockFullVersion = new XNAUnlockFullVersion(engine);
                this.xnaUnlockFullVersion.Initialize();
                break;
        }
    }

    private void fadeStateTransition(int newState)
    {
        this.m_afterFadeState = newState;
        if (this.m_engine.isFadingOut())
            return;
        this.m_engine.startFadeOut();
    }

    private void changeSceneWithSavePrompt(int nextScene, int nextSceneState)
    {
        if (this.m_engine.getSavePromptsEnabled())
        {
            this.m_nextScene = nextScene;
            this.m_nextSceneState = nextSceneState;
            this.stateTransition(3);
        }
        else
            this.changeSceneWithFade(nextScene, nextSceneState);
    }

    private void changeSceneWithPrompt(int nextScene, int nextSceneState)
    {
        this.m_nextScene = nextScene;
        this.m_nextSceneState = nextSceneState;
        this.stateTransition(4);
    }

    private void changeScene(int nextScene, int nextSceneState)
    {
        this.m_nextScene = nextScene;
        this.m_nextSceneState = nextSceneState;
        this.stateTransition(2);
    }

    private void hideMenus()
    {
        if (!this.m_contextMenuActive)
            return;
        this.hideContextMenu();
    }

    public void kickPlayer(int stringId, int titleId)
    {
        this.showMessageBox(stringId, titleId, 1);
    }

    public void killPlayer(int msg)
    {
        this.showMessageBox(msg, 1209, 7);
    }

    public void passOut()
    {
        this.getPlayerSim().beginSimAction(9, (MapObject)null);
        if (!this.isMapMode())
            return;
        this.startCurtainIn();
    }

    public void goHome()
    {
        this.changeSceneWithPrompt(2, 97);
    }

    public void gotoWork()
    {
        if (this.isMapMode())
        {
            this.hideMenus();
            this.startPlayerAction(170, this.findRandomObjectByType(this.m_simData.getCareerRabbitHole(this.m_simData.getSimCareer(0))), 0, 0);
        }
        else
            this.changeSceneWithFade(2, 99);
        ++this.m_simData.numJobsWorked;
    }

    public void gotoMap(bool confirm)
    {
        if (confirm)
            this.changeSceneWithPrompt(2, 98);
        else
            this.changeSceneWithFade(2, 98);
    }

    public void gotoMapForObject(MapObject @object)
    {
        int type = @object.getType();
        switch (type)
        {
            case 1:
                this.m_engine.setupEncounter((MapObjectSim)@object);
                this.m_engine.setNextZoomMapId(183);
                this.changeSceneWithPrompt(2, 100);
                break;
            case 157:
                this.m_engine.setupEncounter((MapObjectSim)null);
                this.m_engine.setNextZoomMapId(4);
                this.changeSceneWithPrompt(2, 100);
                break;
            default:
                this.m_engine.setNextHouseId(this.m_simWorld.getHouseForObject(type));
                this.changeSceneWithPrompt(2, -1);
                break;
        }
    }

    public void showTutorialMessage(int messageId)
    {
        AppEngine engine = this.m_engine;
        if (engine.getRMSHasSeenTutorial(messageId))
            return;
        engine.setRMSHasSeenTutorial(messageId);
        if (!engine.getTutorialsEnabled())
            return;
        switch (messageId)
        {
            case 0:
                this.m_showTutorialTitle = 91;
                this.m_showTutorialBody = 92;
                break;
            case 1:
                this.m_showTutorialTitle = 96;
                this.m_showTutorialBody = 97;
                break;
            case 2:
                this.m_showTutorialTitle = 1700;
                this.m_showTutorialBody = 1701;
                break;
            case 5:
                this.m_showTutorialTitle = 98;
                this.m_showTutorialBody = 99;
                break;
            case 6:
                this.m_showTutorialTitle = 100;
                this.m_showTutorialBody = 101;
                break;
            case 7:
                this.m_showTutorialTitle = 102;
                this.m_showTutorialBody = 103;
                break;
            case 8:
                this.m_showTutorialTitle = 106;
                this.m_showTutorialBody = 107;
                break;
            case 9:
                this.m_showTutorialTitle = 705;
                this.m_showTutorialBody = 108;
                break;
            case 10:
                this.m_showTutorialTitle = 719;
                this.m_showTutorialBody = 112;
                break;
            case 11:
                this.m_showTutorialTitle = 712;
                this.m_showTutorialBody = 109;
                break;
            case 13:
                this.m_showTutorialTitle = 582;
                this.m_showTutorialBody = 116;
                break;
            case 14:
                this.m_showTutorialTitle = 578;
                this.m_showTutorialBody = 113;
                break;
            case 15:
                this.m_showTutorialTitle = 581;
                this.m_showTutorialBody = 114;
                break;
            case 16:
                this.m_showTutorialTitle = 582;
                this.m_showTutorialBody = 115;
                break;
            case 17:
                this.m_showTutorialTitle = 587;
                this.m_showTutorialBody = 117;
                break;
            case 18:
                this.m_showTutorialTitle = 586;
                this.m_showTutorialBody = 118;
                break;
            case 19:
                this.m_showTutorialTitle = 588;
                this.m_showTutorialBody = 119;
                break;
            case 20:
                this.m_showTutorialTitle = 589;
                this.m_showTutorialBody = 1583;
                break;
            case 21:
                this.m_showTutorialTitle = 1596;
                this.m_showTutorialBody = 1585;
                break;
            case 22:
                this.m_showTutorialTitle = 1597;
                this.m_showTutorialBody = 1584;
                break;
            case 23:
                this.m_showTutorialTitle = 1598;
                this.m_showTutorialBody = 1587;
                break;
            case 24:
                this.m_showTutorialTitle = 1599;
                this.m_showTutorialBody = 1586;
                break;
            case 25:
                this.m_showTutorialTitle = 1702;
                this.m_showTutorialBody = 1703;
                break;
            case 26:
                this.m_showTutorialTitle = 1702;
                this.m_showTutorialBody = 1704;
                break;
            case 27:
                this.m_showTutorialTitle = 1702;
                this.m_showTutorialBody = 1705;
                break;
            case 28:
                this.m_showTutorialTitle = 1702;
                this.m_showTutorialBody = 1706;
                break;
            case 29:
                this.m_showTutorialTitle = 1710;
                this.m_showTutorialBody = 1711;
                break;
            case 30:
                this.m_showTutorialTitle = 1712;
                this.m_showTutorialBody = 1713;
                break;
            case 32:
                this.m_showTutorialTitle = 1702;
                this.m_showTutorialBody = 1707;
                break;
            case 33:
                this.m_showTutorialTitle = 120;
                this.m_showTutorialBody = 121;
                break;
            case 34:
                this.m_showTutorialTitle = 120;
                this.m_showTutorialBody = 122;
                break;
            case 35:
                this.m_showTutorialTitle = 93;
                this.m_showTutorialBody = 94;
                break;
            default:
                AppEngine.ASSERT(false, "Invalid message ID");
                break;
        }
        this.m_showTutorial = true;
    }

    private void hideTutorialMessage()
    {
        this.m_tutorialMessageActive = false;
        if (this.m_messageBox.getTitleStringId() != 1710)
            return;
        if (this.m_state == 7)
        {
            this.stateTransitionBuildMode(this.m_buildModeState);
        }
        else
        {
            if (this.m_state != 17)
                return;
            this.stateTransitionShopping(this.m_shoppingState);
        }
    }

    public int getNormalTimeStep()
    {
        return this.m_normalTimeStep;
    }

    public bool gamePaused()
    {
        if (this.m_pauseMenuActive || this.m_tutorialMessageActive)
            return true;
        return this.m_state != 6 && this.m_state != 21;
    }

    private void renderMain(Graphics g)
    {
        this.m_simWorld.renderWorld(g);
        this.renderHUD(g);
    }

    private void renderHUD(Graphics g)
    {
        if (this.m_HUDRenderMask == 0 || this.m_state == 20)
            return;
        if (!this.m_tutorialMessageActive)
            this.renderTooltips(g);
        this.renderHUDTop(g);
        if (this.isCurtainActive())
            this.renderCurtain(g);
        if (this.m_pauseMenuActive)
        {
            this.renderHUDBottom(g);
            this.renderPauseMenu(g);
        }
        else if (!this.m_suppressMenus && this.m_contextMenuActive)
        {
            this.renderHUDBottom(g);
            this.renderContextMenu(g);
        }
        else if (this.m_tutorialMessageActive)
        {
            this.renderHUDBottom(g);
            this.m_engine.renderBackgroundDim(g);
        }
        else
            this.renderHUDBottom(g);
    }

    private void updateMain(int timeStep)
    {
        if (this.gamePaused())
            return;
        SimData simData = this.m_simData;
        if (this.isCurtainActive())
            this.updateCurtain(timeStep);
        if (!this.m_tutorialMessageActive && !simData.isDelayed() && this.checkTriggers())
            return;
        if (this.isHouseMode() && this.m_tuteHomeTimer > 0 && this.m_state != 21)
            this.m_tuteHomeTimer -= timeStep;
        this.updateTicker(timeStep);
        this.m_normalTimeStep = timeStep;
        this.updateObjects(simData.getFastforward() ? timeStep << 2 : timeStep);
        this.updateCamera(timeStep);
        this.m_hudPlumbBob.update(timeStep);
        if (this.isCurtainActive() || this.m_engine.isFading())
            return;
        this.updateSimData(timeStep);
        if (this.m_mapMode == 2)
            this.updateEventsMapMode(timeStep);
        else if (this.m_mapMode == 0)
            this.updateEventsHouse(timeStep);
        else
            this.updateEventsZoomMode(timeStep);
        if (this.m_ambientSounds != null)
            this.updateAmbientSounds(timeStep, this.m_ambientSoundRate, this.m_ambientSounds);
        this.updateSimAction();
    }

    private bool checkTriggers()
    {
        SimData simData = this.m_simData;
        if (this.m_showTutorial)
        {
            this.m_showTutorial = false;
            this.hideMenus();
            this.prepareTextBox(this.m_showTutorialBody, this.m_showTutorialTitle);
            this.m_tutorialMessageActive = true;
            this.m_simData.delayAlerts();
            return true;
        }
        if (this.m_showFetchQuestEnd)
        {
            this.m_showFetchQuestEnd = false;
            this.stateTransition(18);
            this.stateTransitionQuest(3);
            return true;
        }
        if (this.m_showGetItem != -1)
        {
            this.stateTransition(15);
            return true;
        }
        if (simData.showPersonaComplete())
        {
            this.showMessageBox(1201, 1193, 8);
            return true;
        }
        if (this.m_showBonusUnlocked)
        {
            this.m_showBonusUnlocked = false;
            this.m_engine.unlockBonus();
            this.showMessageBox(1186, 1130);
            return true;
        }
        if (simData.isFurnitureStageChange())
        {
            this.showMessageBox(1187, 1188);
            return true;
        }
        int houseUpgradeMessage = simData.getHouseUpgradeMessage();
        if (houseUpgradeMessage != -1)
        {
            this.showMessageBox(houseUpgradeMessage, 1170);
            return true;
        }
        if (this.m_showNewDream)
        {
            this.m_showNewDream = false;
            switch (simData.getDream())
            {
                case -1:
                    goto label_18;
                case 1:
                case 7:
                case 26:
                case 27:
                case 29:
                case 30:
                    this.showTutorialMessage(30);
                    break;
            }
            this.showNewDreamMessage();
            return true;
        }
    label_18:
        if (this.m_tuteHomeTimer < 0 && !this.m_engine.getRMSHasSeenTutorial(24))
        {
            this.showTutorialMessage(24);
            return true;
        }
        if (this.m_simData.getSimCareer(0) != -1 || this.m_engine.getRMSHasSeenTutorial(23) || this.m_simData.getGameTimeAbs() <= 1980)
            return false;
        this.showTutorialMessage(23);
        return true;
    }

    private void updateHUD(int timeStep)
    {
        this.m_displayedMoney = this.interpolateValue(this.m_displayedMoney, this.m_simData.getMoney(), timeStep, 9);
        if (this.m_state == 6 && !this.m_pauseMenuActive)
        {
            for (int index = 0; index < this.m_dreamAnimTimers.Length; ++index)
                this.m_dreamAnimTimers[index].updateTimer(timeStep);
            for (int index = 0; index < this.m_motiveAnimTimers.Length; ++index)
                this.m_motiveAnimTimers[index].updateTimer(timeStep);
        }
        if (this.getNumActiveBuffs() == 0)
            this.m_isBuffPanelVisible = false;
        if (this.m_isBuffPanelVisible)
            this.m_buffPanelSlideFactor = midp.JMath.min(this.m_buffPanelSlideFactor + 0.007f * (float)timeStep, 1f);
        else
            this.m_buffPanelSlideFactor = midp.JMath.max(this.m_buffPanelSlideFactor - 0.007f * (float)timeStep, 0.0f);
    }

    private void renderHUDTop(Graphics g)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        SimData simData = this.m_simData;
        if (this.m_state == 7)
        {
            if (this.m_contextMenuActive || this.m_buildModeState != 1 && this.m_buildModeState != 15 && (this.m_buildModeState != 4 && this.m_buildModeState != 12) && (this.m_buildModeState != 16 && this.m_buildModeState != 17 && this.m_buildModeState != 18))
                return;
            int commandId = 524288;
            int num1 = (int)sbyte.MaxValue;
            if (this.m_buildModeState == 16 || this.m_buildModeState == 17 || this.m_buildModeState == 18)
            {
                commandId = 32;
                num1 = 28;
            }
            else if (this.m_buildModeState == 12)
                num1 = 485;
            else if (this.m_buildModeState == 4)
                num1 = 1145;
            int font = 4;
            int num2 = textManager.getStringWidth(num1, font) + 60;
            int num3 = 32 + (num2 >> 1);
            int x = num3 + 5;
            animationManager2D.submitAnimHBar(359, 360, 361, (float)num3, 35f, (float)num2);
            animationManager2D.submitAnim(330, 32f, 32f);
            this.getUIButton(commandId).submit(ref animationManager2D, 32, 32, !this.m_tutorialMessageActive);
            animationManager2D.flushAnims(g);
            g.Begin();
            textManager.drawString(g, num1, font, x, 35, 18);
            g.End();
        }
        else
        {
            if ((this.m_HUDRenderMask & 1) != 0)
            {
                int num = 27;
                int actionQueueSize = this.m_actionQueueSize;
                MapObject[] actionQueueArg1s = this.m_actionQueueArg1s;
                for (int index = 0; index < actionQueueSize; ++index)
                {
                    MapObject mapObject = actionQueueArg1s[index];
                    int animId1 = 174;
                    if (index == 0)
                        animId1 = 174;
                    int animId2 = 508;
                    if (mapObject != null)
                    {
                        if (mapObject.getFlag(8192) && !this.isMapMode())
                        {
                            animId2 = 509;
                        }
                        else
                        {
                            int objectActionIcon = this.m_simWorld.getObjectActionIcon(mapObject.getType());
                            if (objectActionIcon != -1)
                                animId2 = objectActionIcon;
                        }
                    }
                    animationManager2D.submitAnim(animId1, (float)num, 27f);
                    animationManager2D.submitAnim(animId2, (float)num, 27f);
                    num += 48;
                }
                animationManager2D.flushAnims(g);
            }
            if ((this.m_HUDRenderMask & 2) != 0)
            {
                float x1 = (float)(engine.getWidth() - 48);
                animationManager2D.submitAnim(39, x1, 16f);
                animationManager2D.flushAnims(g);
                int gameDay = simData.getGameDay();
                int gameTime = simData.getGameTime();
                StringBuffer strBuffer = textManager.clearStringBuffer();
                g.Begin();
                textManager.appendStringIdToBuffer(SimData.DAY_STRINGS[gameDay]);
                textManager.appendStringToBuffer(".  ");
                textManager.appendTimeToBuffer24Hour(gameTime);
                int x2 = (int)x1;
                textManager.drawString(g, strBuffer, 3, x2, 17, 18);
                g.End();
            }
            if (this.getPlayerSim().isInView() || this.m_contextMenuActive || (this.m_HUDRenderMask & 1024) == 0)
                return;
            int num1 = engine.getWidth() >> 1;
            int y = (int)animationManager2D.getAnimHeight(287) >> 1;
            int num2 = 20 + textManager.getStringWidth(1582, 3) + 20;
            int num3 = num2 + 30;
            int x = num1 - (num3 >> 1) + (num2 >> 1);
            int num4 = x + (num2 >> 1) + 15 - 4;
            int num5 = y;
            animationManager2D.submitAnimHBar(287, 288, 289, (float)num1, (float)y, (float)num3);
            animationManager2D.submitAnimHBar(290, 291, 292, (float)x, (float)y, (float)num2);
            animationManager2D.flushAnims(g);
            g.Begin();
            textManager.drawString(g, 1582, 3, x, y, 18);
            g.End();
            this.m_hudPlumbBob.render(g, num4 - 50, num5 - 35, 100, 70);
        }
    }

    protected void initHUDZoomBar()
    {
        AnimationManager2D animationManager2D = this.m_engine.getAnimationManager2D();
        this.HUD_ZOOMBAR_W = (int)((double)animationManager2D.getAnimWidth(379) * 2.0);
        this.HUD_ZOOMBAR_H = (int)animationManager2D.getAnimHeight(379);
        this.HUD_ZOOMBAR_X = this.m_engine.getWidth() - this.HUD_ZOOMBAR_W;
        this.HUD_ZOOMBAR_Y = 45;
        this.HUD_ZOOMBAR_TOP = this.HUD_ZOOMBAR_Y + 5;
        this.HUD_ZOOMBAR_LENGTH = this.HUD_ZOOMBAR_H - 10;
        this.m_zoomBarActive = false;
    }

    private bool inHUDZoomBarRange(int[] args)
    {
        return UIElement.isInBox(args[1], args[2], this.HUD_ZOOMBAR_X + 10, this.HUD_ZOOMBAR_Y - 10, this.HUD_ZOOMBAR_W - 10, this.HUD_ZOOMBAR_H + 20);
    }

    private void processInputZoomBar(int[] args)
    {
        float num1 = midp.JMath.max(0.0f, midp.JMath.min(1f, (float)(args[6] - this.HUD_ZOOMBAR_Y - 5) / (float)this.HUD_ZOOMBAR_LENGTH));
        int num2 = this.isMapMode() ? 800 : 150;
        int num3 = this.isMapMode() ? 1800 : 750;
        this.m_simWorld.setCameraDolly((float)num2 + (float)(num3 - num2) * num1);
        this.completeCamTute(4);
    }

    private void renderHUDZoomBar(Graphics g)
    {
        if ((this.m_HUDRenderMask & 16) == 0)
            return;
        AnimationManager2D animationManager2D = this.m_engine.getAnimationManager2D();
        animationManager2D.submitAnim(379, (float)(this.HUD_ZOOMBAR_X + (this.HUD_ZOOMBAR_W >> 2)), (float)(this.HUD_ZOOMBAR_Y + (this.HUD_ZOOMBAR_H >> 1)));
        animationManager2D.submitAnim(379, (float)(this.HUD_ZOOMBAR_X + (this.HUD_ZOOMBAR_W >> 1) + (this.HUD_ZOOMBAR_W >> 2)), (float)(this.HUD_ZOOMBAR_Y + (this.HUD_ZOOMBAR_H >> 1)), 1f, -1f);
        float cameraDolly = this.m_simWorld.getCameraDolly();
        float num1 = this.isMapMode() ? 800f : 150f;
        float num2 = this.isMapMode() ? 1800f : 750f;
        float num3 = (float)(((double)cameraDolly - (double)num1) / ((double)num2 - (double)num1));
        int num4 = this.HUD_ZOOMBAR_X + (this.HUD_ZOOMBAR_W >> 1);
        int num5 = (int)((double)this.HUD_ZOOMBAR_TOP + (double)this.HUD_ZOOMBAR_LENGTH * (double)num3);
        animationManager2D.submitAnim(380, (float)num4, (float)num5);
        animationManager2D.flushAnims(g);
    }

    private void renderHUDBottom(Graphics g)
    {
        if ((this.m_HUDRenderMask & 12) == 0 || this.m_state == 7)
            return;
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        SimData simData = this.m_simData;
        int sim = this.getSimContext();
        if (sim == 0)
            sim = -1;
        if (this.m_state != 16 && this.m_state != 7)
            this.renderHUDBuffs(g);
        int num1 = 240;
        int num2 = engine.getHeight() - 33;
        if (this.m_tickerString1 != -1)
        {
            float y1 = (float)(num2 - 22);
            animationManager2D.submitAnim(55, 68f, y1);
            float x1 = (float)((double)engine.getWidth() - 24.0 - 32.0);
            animationManager2D.submitAnim(57, x1, y1);
            float num3 = (float)((double)engine.getWidth() - 88.0 - 64.0 - 48.0);
            float x2 = (float)(112.0 + (double)num3 * 0.5);
            float scaleX = num3 / 4f;
            animationManager2D.submitAnim(56, x2, y1, 1f, scaleX);
            animationManager2D.flushAnims(g);
            int y2 = (int)((double)x2 - (double)num3 * 0.5);
            int h = (int)num3;
            int y3 = (int)((double)y1 - 16.0);
            int clipX = g.getClipX();
            int clipY = g.getClipY();
            int clipWidth = g.getClipWidth();
            int clipHeight = g.getClipHeight();
            g.setClip(320 - clipHeight - clipY, y2, clipHeight, h);
            int x3 = y2 - (this.m_tickerOffsetF >> 16);
            g.Begin();
            textManager.drawString(g, this.m_tickerString1, 4, x3, y3, 9);
            if (this.m_tickerString2 != -1)
            {
                int stringWidth = textManager.getStringWidth(this.m_tickerString1, 4);
                int x4 = x3 + stringWidth + 5;
                textManager.drawString(g, this.m_tickerString2, 4, x4, y3, 9);
            }
            g.setClip(clipX, clipY, clipWidth, clipHeight);
            g.End();
        }
        if (this.isHouseMode() && this.m_simWorld.getHouseId() == 0 && (this.m_HUDRenderMask & 256) != 0)
        {
            int num3 = num1 - 208;
            int num4 = num2 - 50;
            animationManager2D.submitAnim(41, (float)num3, (float)num4);
        }
        int x5 = num1 + 57;
        int y4 = num2 - 9;
        int y5 = y4 + 21;
        int width = 220;
        int relState1 = -1;
        int relState2 = -1;
        int levelF = 0;
        if (sim == -1)
        {
            if ((this.m_HUDRenderMask & 4) != 0)
            {
                int num3 = (int)animationManager2D.getAnimWidth(36) >> 1;
                animationManager2D.submitAnim(36, (float)num3, (float)num2);
            }
            if ((this.m_HUDRenderMask & 8) != 0)
            {
                int num3 = engine.getWidth() - ((int)animationManager2D.getAnimWidth(37) >> 1);
                animationManager2D.submitAnim(37, (float)num3, (float)num2);
            }
            int num4 = engine.getWidth() - 33;
            int num5 = engine.getHeight() - 33;
            if ((this.m_HUDRenderMask & 64) != 0)
            {
                float num3 = 1f;
                if (this.m_state == 21 && this.m_tutorialState == 10)
                    num3 = this.m_tutorialPulseScale;
                animationManager2D.submitAnim(374, (float)num4, (float)num5, 1f, num3, num3);
            }
            else if ((this.m_HUDRenderMask & 8) != 0)
                animationManager2D.submitAnim(374, (float)num4, (float)num5, 0.5f);
        }
        else
        {
            relState1 = simData.getRelState(sim);
            int[] tempInt10 = this.m_tempInt10;
            simData.getRelationshipLevels(sim, tempInt10);
            relState2 = tempInt10[0];
            levelF = tempInt10[1];
            int num3 = num1 - 162;
            int num4 = num2;
            animationManager2D.submitAnim(38, (float)num3, (float)num4);
            int num5 = num1 - 84;
            int num6 = num2 + 1;
            int num7 = num5 + 161;
            animationManager2D.submitAnimHBar(278, 279, 280, (float)num7, (float)num6, 322f);
            UIInfoScreen.drawRelBar(g, animationManager2D, x5, y4, width, relState1, 65536, false);
            if (relState2 != -1)
                UIInfoScreen.drawRelBar(g, animationManager2D, x5, y5, width, relState2, levelF, false);
        }
        if ((this.m_HUDRenderMask & 2048) != 0)
        {
            float x1 = (float)num1 - 114f;
            float y1 = (float)num2 - 11f;
            animationManager2D.submitAnim(277, x1, y1);
        }
        int num8 = engine.getHeight() - 33;
        if ((this.m_HUDRenderMask & 128) != 0)
            animationManager2D.submitAnim(381, 33f, (float)num8, 1f, 1.2f, 1.2f);
        else if ((this.m_HUDRenderMask & 4) != 0)
            animationManager2D.submitAnim(381, 33f, (float)num8, 0.5f, 1.2f, 1.2f);
        if (this.m_tickerString1 != -1)
        {
            float x1 = (float)(num1 - 162);
            float y1 = (float)(num2 - 24);
            animationManager2D.submitAnim(58, x1, y1);
        }
        float x6 = (float)(num1 - 120);
        float y6 = (float)(num2 + 13);
        bool flag = this.m_displayedMoodLevel < 0;
        int w = 84 * midp.JMath.abs(this.m_displayedMoodLevel >> 16) / 100;
        int x7 = (int)((double)x6 - 42.0);
        animationManager2D.submitAnimHBar(46, 47, 48, x6, y6, 84f);
        animationManager2D.flushAnims(g);
        int clipX1 = g.getClipX();
        int clipY1 = g.getClipY();
        int clipWidth1 = g.getClipWidth();
        int clipHeight1 = g.getClipHeight();
        g.setClip(x7, clipY1, w, clipHeight1);
        int animLeft = 49;
        int animMid = 50;
        int animRight = 51;
        if (flag)
        {
            animLeft = 52;
            animMid = 53;
            animRight = 54;
        }
        animationManager2D.submitAnimHBar(animLeft, animMid, animRight, x6, y6, 84f);
        animationManager2D.flushAnims(g);
        g.setClip(clipX1, clipY1, clipWidth1, clipHeight1);
        if (sim == -1)
        {
            float num3 = (float)((double)num1 + 145.0 + 53.0);
            float num4 = (float)num2 + 8f;
            float num5 = (float)((double)num1 + 53.0 + 53.0);
            float num6 = (float)num2 + 8f;
            for (int index1 = 0; index1 < 2; ++index1)
            {
                float x1 = num5;
                for (int index2 = 0; index2 < 5; ++index2)
                {
                    int num7;
                    float num9;
                    float y1;
                    if (index2 == 4)
                    {
                        num7 = simData.getDream();
                        num9 = 1f;
                        y1 = num4;
                        x1 = num3;
                    }
                    else
                    {
                        num7 = simData.getPromise(index2);
                        num9 = 0.6f;
                        y1 = num6;
                    }
                    AnimTimer dreamAnimTimer = this.m_dreamAnimTimers[index2];
                    if (num7 != -1 && index1 == 0 || dreamAnimTimer.isAnimating() && index1 == 1)
                    {
                        float alpha = 1f;
                        if (dreamAnimTimer.isAnimating())
                        {
                            num9 *= dreamAnimTimer.getValue();
                            if (dreamAnimTimer.getTimerID() == 4)
                                alpha = dreamAnimTimer.getValueLinearInv();
                        }
                        animationManager2D.submitAnim(40, x1, y1, alpha, num9, num9);
                    }
                    x1 += 20f;
                }
            }
        }
        if (sim == -1)
        {
            float num3 = (float)num1 - 64f;
            float y1 = (float)num2 + 12f;
            int motiveCount = simData.getMotiveCount();
            float x1 = num3;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            for (int motive = 0; motive < motiveCount && num4 < 4; ++motive)
            {
                if (simData.getMotiveLevel(motive) < 2293760)
                {
                    int motiveLowAnim = (int)simData.getMotiveLowAnim(motive);
                    animationManager2D.submitAnim(motiveLowAnim, x1, y1);
                    if (this.m_motiveHUDIndexes[motive] != 0 && (this.m_motiveHUDIndexes[motive] == -1 || this.m_motiveHUDIndexes[motive] < motiveCount + 1))
                        this.m_motiveAnimTimers[motive].startTimer(6, 16);
                    this.m_motiveHUDIndexes[motive] = num4 + motiveCount + 1;
                    if (this.m_motiveAnimTimers[motive].isAnimating())
                    {
                        float alpha = this.m_motiveAnimTimers[motive].getValue();
                        int motiveMidAnim = (int)simData.getMotiveMidAnim(motive);
                        animationManager2D.submitAnim(motiveMidAnim, x1, y1, alpha);
                    }
                    x1 += 22f;
                    ++num4;
                    ++num5;
                }
            }
            for (int motive = 0; motive < motiveCount && num4 < 4; ++motive)
            {
                if (simData.getMotiveLevel(motive) > 4259840)
                {
                    int motiveHighAnim = (int)simData.getMotiveHighAnim(motive);
                    animationManager2D.submitAnim(motiveHighAnim, x1, y1);
                    if (this.m_motiveHUDIndexes[motive] != 0 && (this.m_motiveHUDIndexes[motive] == -1 || this.m_motiveHUDIndexes[motive] >= motiveCount + 1))
                        this.m_motiveAnimTimers[motive].startTimer(6, 16);
                    this.m_motiveHUDIndexes[motive] = num4 + 1;
                    if (this.m_motiveAnimTimers[motive].isAnimating())
                    {
                        float alpha = this.m_motiveAnimTimers[motive].getValue();
                        int motiveMidAnim = (int)simData.getMotiveMidAnim(motive);
                        animationManager2D.submitAnim(motiveMidAnim, x1, y1, alpha);
                    }
                    x1 += 22f;
                    ++num4;
                    ++num6;
                }
                else if (simData.getMotiveLevel(motive) >= 2293760)
                    this.m_motiveHUDIndexes[motive] = -1;
            }
            int moodLevel = this.m_simData.getMoodLevel();
            if (num5 >= 3 && moodLevel < -327680)
                this.showTutorialMessage(22);
            else if (num6 >= 3 && this.m_prevNotGoodMood && moodLevel > 327680)
                this.showTutorialMessage(21);
            else if (num6 < 3)
                this.m_prevNotGoodMood = true;
        }
        animationManager2D.flushAnims(g);
        if ((this.m_HUDRenderMask & 2048) != 0)
        {
            float num3 = (float)num1 - 114f;
            float num4 = (float)num2 - 13f;
            StringBuffer strBuffer = textManager.clearStringBuffer();
            textManager.appendMoneyToBuffer(this.m_displayedMoney);
            g.Begin();
            textManager.drawString(g, strBuffer, 3, (int)num3, (int)num4, 18);
            g.End();
        }
        if (sim == -1)
            return;
        UIInfoScreen.drawRelBar(g, (AnimationManager2D)null, x5, y4, width, relState1, 65536, false);
        if (relState2 == -1)
            return;
        UIInfoScreen.drawRelBar(g, (AnimationManager2D)null, x5, y5, width, relState2, levelF, false);
    }

    public void showMessageBox(int messageStringId, int titleStringId)
    {
        this.showMessageBox(messageStringId, titleStringId, 0);
    }

    public void showMessageBox(int messageStringId, int titleStringId, int postMessage)
    {
        this.m_postMessageBox = postMessage;
        this.prepareMessageBox(messageStringId, titleStringId);
        this.stateTransition(9);
    }

    public bool isCurtainActive()
    {
        return this.m_curtainState != 0;
    }

    public void startCurtainIn()
    {
        this.hideMenus();
        this.m_curtainPlayerAction = this.getPlayerSim().getSimAction();
        this.stateTransitionCurtain(1);
    }

    public void startCurtainOut()
    {
        this.hideMenus();
        this.stateTransitionCurtain(2);
    }

    private void stateTransitionCurtain(int newState)
    {
        this.m_curtainState = newState;
        switch (newState)
        {
            case 0:
                this.m_curtainTime = 0;
                break;
            case 1:
                this.m_simData.delayAlerts();
                this.m_curtainTime = 0;
                break;
            case 2:
                this.m_curtainTime = 1000;
                break;
            case 3:
                this.m_curtainTime = 1000;
                break;
        }
    }

    private void updateCurtain(int timeStep)
    {
        if (!this.m_cameraAtDest)
            return;
        switch (this.m_curtainState)
        {
            case 1:
                this.m_simData.delayAlerts();
                if (this.m_curtainTime == 1000)
                {
                    this.stateTransitionCurtain(2);
                    this.doCurtainInUpdate();
                    break;
                }
                this.m_curtainTime += timeStep;
                this.m_curtainTime = midp.JMath.min(this.m_curtainTime + timeStep, 1000);
                break;
            case 2:
                this.m_simData.delayAlerts();
                this.m_curtainTime += timeStep;
                if (this.m_curtainTime < 1500)
                    break;
                this.m_simWorld.forceTint();
                this.stateTransitionCurtain(3);
                break;
            case 3:
                this.m_simData.delayAlerts();
                if (this.m_curtainTime == 0)
                {
                    this.stateTransitionCurtain(0);
                    this.doCurtainOutUpdate();
                    break;
                }
                this.m_curtainTime = midp.JMath.max(this.m_curtainTime - timeStep, 0);
                break;
        }
    }

    private void doCurtainInUpdate()
    {
        switch (this.m_curtainPlayerAction)
        {
            case 9:
                if (this.isHouseMode() && this.m_simWorld.getHouseId() == 0)
                {
                    this.putSimInBed(this.getPlayerSim());
                    this.m_timeHit = 120;
                    this.m_simData.delayAlerts();
                    foreach (MapObjectSim simObject in this.getSimObjects())
                    {
                        if (simObject != this.getPlayerSim())
                        {
                            if (this.m_simData.getSimHome(simObject.getId()) != 0)
                                simObject.destroy();
                            else
                                simObject.beginSimAction(0, (MapObject)null);
                        }
                    }
                    break;
                }
                this.m_engine.setNextHouseId(0);
                this.changeScene(2, 96);
                break;
            case 126:
            case (int)sbyte.MaxValue:
                this.m_simData.updateSkipSleeping(this.getPlayerSim().getFeedbackTime() - 15);
                break;
            case 149:
                this.clearActionQueue();
                foreach (MapObject mapObject in this.getObjects())
                    mapObject.destroy();
                this.m_simWorld.unload();
                this.m_simWorld.prepareWorldHouse(0);
                break;
            case 170:
                AppEngine.ASSERT(this.getPlayerSim().isWorking(), "sim not working!");
                if ((this.m_simData.getTimeFlags(0) & 1) != 0)
                    this.awardAchievment(2);
                this.m_simData.updateSkipWorking();
                this.cancelWorkMessages();
                this.getPlayerSim().endSimPhase();
                break;
        }
    }

    private void doCurtainOutUpdate()
    {
        switch (this.m_curtainPlayerAction)
        {
            case 9:
                this.showTutorialMessage(13);
                this.m_simData.delayAlerts();
                break;
            case 149:
                this.triggerEvent(5);
                break;
            case 170:
                this.finishWork();
                break;
            default:
                this.m_simData.delayAlerts();
                break;
        }
    }

    private void renderCurtain(Graphics g)
    {
        if (!this.m_cameraAtDest)
            return;
        int h = (midp.JMath.min(this.m_curtainTime, 1000) * this.m_viewportHeight / 1000 >> 1) + 1;
        g.Begin();
        g.setColor(0);
        g.fillRect(this.m_viewportX, this.m_viewportY, this.m_viewportWidth, h);
        g.fillRect(this.m_viewportX, this.m_viewportY + this.m_viewportHeight - h, this.m_viewportWidth, h);
        g.End();
    }

    public void showTickerMessage(int string1, int string2)
    {
        TextManager textManager = this.m_engine.getTextManager();
        this.m_tickerString1 = string1;
        this.m_tickerString2 = string2;
        this.m_tickerTimer = 0;
        this.m_tickerOffsetF = 0;
        this.m_tickerLengthF = (textManager.getStringWidth(string1, 4) << 16) + 327680;
        if (string2 == -1)
            return;
        this.m_tickerLengthF += 5 + textManager.getStringWidth(string2, 4) << 16;
    }

    public void cancelTickerMessage(int string1)
    {
        if (this.m_tickerString1 != string1)
            return;
        this.m_tickerString1 = -1;
    }

    public bool isShowingTickerMessage()
    {
        return this.m_tickerString1 != -1;
    }

    private void updateTicker(int timeStep)
    {
        if (this.m_tickerString1 == -1)
            return;
        this.m_tickerTimer += timeStep;
        if (this.m_tickerTimer <= 2000)
            return;
        if (this.m_tickerOffsetF > this.m_tickerLengthF)
        {
            this.m_tickerString1 = -1;
            this.m_tickerString2 = -1;
        }
        else
            this.m_tickerOffsetF += timeStep * 3276;
    }

    private void processPointerTap(int[] args)
    {
        int num1 = args[1];
        int num2 = args[2];
        if ((this.m_state != 21 || this.m_tutorialState >= 5) && this.processPointerTapHUD(num1, num2))
            return;
        int wallDepthAt = this.m_simWorld.getWallDepthAt(num1, num2);
        MapObject objectAtScreen = this.findObjectAtScreen(num1, num2, wallDepthAt);
        if (objectAtScreen != null && this.m_tutorialState != 10 && (this.m_state != 21 || objectAtScreen.getType() != 4 && objectAtScreen.getType() != 132))
        {
            int[] tempInt10 = this.m_tempInt10;
            objectAtScreen.getHotspot(tempInt10, 0);
            this.triggerTapperInWorldSpace(tempInt10[0], tempInt10[1], tempInt10[2]);
            this.setCursorObject(objectAtScreen);
            this.processInputFire();
        }
        else
        {
            if (objectAtScreen == null && this.m_state == 7 && this.m_buildModeState == 15)
            {
                int[] tempInt10 = this.m_tempInt10;
                this.m_simWorld.coordScreenToWorldY0(tempInt10, num1, num2);
                int x = tempInt10[0];
                int z = tempInt10[2];
                int num3 = tempInt10[3];
                this.m_buildModeEffectX = x;
                this.m_buildModeEffectZ = z;
                if (wallDepthAt == 0 || num3 < wallDepthAt)
                {
                    int worldTileX = this.m_simWorld.coordWorldToWorldTileX(x);
                    int worldTileZ = this.m_simWorld.coordWorldToWorldTileZ(z);
                    int roomAt = this.m_simWorld.getRoomAt(worldTileX, worldTileZ);
                    if (roomAt != -1)
                    {
                        this.triggerTapperInWorldSpace(this.m_simWorld.coordWorldTileToWorldCenterX(worldTileX), 0, this.m_simWorld.coordWorldTileToWorldCenterZ(worldTileZ));
                        this.playSound(22);
                        this.m_buildModeRoomId = roomAt;
                        this.m_buildModeOldSetting = this.m_simWorld.getRoom(roomAt).getFloorType();
                        this.stateTransitionBuildMode(16);
                    }
                }
                else
                {
                    int wallDepthRoomIdAt = this.m_simWorld.getWallDepthRoomIdAt(num1, num2);
                    if (wallDepthRoomIdAt != -1)
                    {
                        this.triggerTapper(num1, num2);
                        this.playSound(22);
                        this.m_buildModeRoomId = wallDepthRoomIdAt;
                        this.m_buildModeOldSetting = this.m_simWorld.getRoom(wallDepthRoomIdAt).getWallType();
                        this.stateTransitionBuildMode(17);
                    }
                }
            }
            if (this.m_state != 6 && this.m_state != 21)
                return;
            int[] tempInt10_1 = this.m_tempInt10;
            this.m_simWorld.coordScreenToWorldY0(tempInt10_1, num1, num2);
            int num4 = tempInt10_1[0];
            int num5 = tempInt10_1[2];
            int num6 = tempInt10_1[3];
            if (wallDepthAt != 0 && num6 >= wallDepthAt || (!this.m_simWorld.isWorldPointWalkable(num4, num5) || this.isSimAt(num4, num5)))
                return;
            this.triggerTapperInWorldSpace(this.m_simWorld.coordWorldTileToWorldCenterX(this.m_simWorld.coordWorldToWorldTileX(num4)), 0, this.m_simWorld.coordWorldTileToWorldCenterZ(this.m_simWorld.coordWorldToWorldTileZ(num5)));
            this.playSound(21);
            this.processSimAction(111, (MapObject)null, num4, num5);
        }
    }

    private bool processPointerTapHUD(int x, int y)
    {
        int num = 3 + 48 * this.m_actionQueueSize;
        if (x < num && y < 51)
        {
            this.playSound(20);
            this.cancelSimAction(midp.JMath.max(0, (x - 3) / 48));
            return true;
        }
        if (this.m_state == 6 && UIElement.isInRadius(x, y, 34, 286, 48) && (this.m_HUDRenderMask & 128) != 0)
        {
            this.playSound(21);
            this.triggerTapper(34, 286);
            this.showPauseMenu();
            return true;
        }
        if (this.isHouseMode() && this.m_simWorld.getHouseId() == 0 && ((this.m_HUDRenderMask & 256) != 0 && this.m_state == 6) && UIElement.isInRadius(x, y, 33, 232, 48))
        {
            this.playSound(21);
            this.triggerTapper(33, 232);
            this.stateTransition(7);
            this.stateTransitionBuildMode(13);
            this.showTutorialMessage(25);
            return true;
        }
        if ((this.m_state == 6 || this.m_state == 21) && (UIElement.isInRadius(x, y, 498, 286, 48) && (this.m_HUDRenderMask & 64) != 0))
        {
            this.playSound(21);
            this.triggerTapper(498, 286);
            if (this.m_state == 21)
            {
                this.m_infoScreen.init(3);
                this.showTutorialMessage(1709, 1708);
            }
            else if (this.getSimContext() != -1)
                this.showInfoScreen(0);
            else
                this.showInfoScreen(3);
            return true;
        }
        int rectY = this.m_engine.getHeight() - 64;
        if (this.m_state == 6 && UIElement.isInBox(x, y, 0, rectY, 533, 64))
        {
            this.playSound(21);
            this.triggerTapper(498, 286);
            if (x > 260)
                this.showInfoScreen(3);
            else
                this.showInfoScreen(4);
            return true;
        }
        if (this.m_state == 6 && UIElement.isInBox(x, y, 0, 50, this.getBuffPanelWidth(), this.getBuffPanelHeight()) && this.getNumActiveBuffs() > 0)
        {
            this.m_isBuffPanelVisible = !this.m_isBuffPanelVisible;
            return true;
        }
        if (this.m_state != 6 && this.m_state != 21 || (!UIElement.isInBox(x, y, (this.m_engine.getWidth() >> 1) - 101, 0, 203, 50) || this.getPlayerSim().isInView()) || (this.m_contextMenuActive || this.m_cameraTarget == this.getPlayerSim()))
            return false;
        this.setFindMySimCameraLookat();
        return true;
    }

    private void processInputFire()
    {
        this.clearCameraFollow();
        MapObject cursorObject = this.getCursorObject();
        if (cursorObject == null)
            return;
        this.playSound(22);
        this.showContextMenu(cursorObject);
    }

    private void renderTooltips(Graphics g)
    {
        if (!this.isMapMode())
            return;
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        SimWorld simWorld = this.m_simWorld;
        SimData simData = this.m_simData;
        foreach (MapObject mapObject in this.getObjects())
        {
            int type = mapObject.getType();
            if (mapObject.getFlag(128) && simData.isQuickLinkVisited(type))
            {
                int[] tempInt10 = this.m_tempInt10;
                mapObject.getHotspot(tempInt10, 0);
                int worldX = tempInt10[0];
                int worldY = tempInt10[1];
                int worldZ = tempInt10[2];
                simWorld.coordWorldToScreen(tempInt10, worldX, worldY, worldZ);
                int num1 = tempInt10[0];
                int num2 = tempInt10[1];
                int font = 3;
                int typeString = mapObject.getTypeString();
                textManager.wrapStringChunk(19, typeString, font, 100);
                int num3 = 5 + textManager.getNumWrappedLinesChunk(19) * textManager.getLineHeight(font) + 5;
                int num4 = num1 - 110;
                int num5 = num2 - num3;
                int x1 = num4 + 55;
                int y1 = num5 + (num3 >> 1);
                float num6 = (float)num4;
                float num7 = (float)num5;
                float num8 = 110f;
                float num9 = (float)num3;
                float animWidth1 = animationManager2D.getAnimWidth(137);
                float animWidth2 = animationManager2D.getAnimWidth(140);
                float animWidth3 = animationManager2D.getAnimWidth(143);
                float animWidth4 = animationManager2D.getAnimWidth(146);
                float animWidth5 = animationManager2D.getAnimWidth(149);
                float animHeight1 = animationManager2D.getAnimHeight(137);
                float animHeight2 = animationManager2D.getAnimHeight(138);
                float animHeight3 = animationManager2D.getAnimHeight(139);
                float x2 = num6 + animWidth1 * 0.5f;
                float num10 = (float)(((double)num8 - (double)animWidth1 - (double)animWidth5 - (double)animWidth3) * 0.5);
                float x3 = (float)((double)num6 + (double)animWidth1 + (double)num10 + (double)animWidth3 * 0.5);
                float x4 = (float)((double)num6 + (double)num8 - (double)animWidth5 * 0.5);
                float scaleX1 = num10 / animWidth2;
                float x5 = (float)((double)num6 + (double)animWidth1 + (double)num10 * 0.5);
                float scaleX2 = num10 / animWidth4;
                float x6 = (float)((double)num6 + (double)num8 - (double)animWidth5 - (double)num10 * 0.5);
                float y2 = num7 + animHeight1 * 0.5f;
                float num11 = num9 - animHeight1 - animHeight3;
                float y3 = (float)((double)num7 + (double)animHeight1 + (double)num11 * 0.5);
                float scaleY = num11 / animHeight2;
                float y4 = (float)((double)num7 + (double)num9 - (double)animHeight3 * 0.5);
                float y5 = (float)(0.375 + (double)y4 + ((double)animationManager2D.getAnimHeight(145) - (double)animHeight3) * 0.5);
                animationManager2D.submitAnim(137, x2, y2, 1f);
                animationManager2D.submitAnim(140, x5, y2, 1f, scaleX1, 1f);
                animationManager2D.submitAnim(143, x3, y2, 1f);
                animationManager2D.submitAnim(146, x6, y2, 1f, scaleX2, 1f);
                animationManager2D.submitAnim(149, x4, y2, 1f);
                animationManager2D.submitAnim(138, x2, y3, 1f, 1f, scaleY);
                animationManager2D.submitAnim(141, x5, y3, 1f, scaleX1, scaleY);
                animationManager2D.submitAnim(144, x3, y3, 1f, 1f, scaleY);
                animationManager2D.submitAnim(147, x6, y3, 1f, scaleX2, scaleY);
                animationManager2D.submitAnim(150, x4, y3, 1f, 1f, scaleY);
                animationManager2D.submitAnim(139, x2, y4, 1f);
                animationManager2D.submitAnim(142, x5, y4, 1f, scaleX1, 1f);
                animationManager2D.submitAnim(145, x3, y5, 1f);
                animationManager2D.submitAnim(148, x6, y4, 1f, scaleX2, 1f);
                animationManager2D.submitAnim(151, x4, y4, 1f);
                animationManager2D.flushAnims(g);
                g.Begin();
                textManager.drawWrappedStringChunk(g, 19, font, x1, y1, 18);
                g.End();
            }
        }
    }

    public MapObject getCursorObject()
    {
        return this.m_cursorObject;
    }

    public void setCursorObject(MapObject @object)
    {
        this.m_cursorObject = @object;
        this.setCameraLookAt(@object);
    }

    protected void setCursorSelectFlags(int flags)
    {
        this.m_cursorSelectFlags = flags;
        if (this.getCursorObject() != null && this.getCursorObject().getFlag(flags))
            return;
        this.setCursorObject((MapObject)null);
    }

    protected void stateTransitionCamera(int newState)
    {
        int cameraState = this.m_cameraState;
        this.m_cameraState = newState;
        switch (newState)
        {
            case 0:
                this.resetCameraVelocity();
                break;
            case 1:
                this.m_cameraAtDest = false;
                this.calcCameraDest();
                break;
            case 5:
                this.m_cameraDestX = this.m_cameraPreSnapX;
                this.m_cameraDestY = this.m_cameraPreSnapY;
                this.m_cameraDestZ = this.m_cameraPreSnapZ;
                this.m_cameraDestDolly = this.m_cameraPreSnapDolly;
                this.m_cameraDestPitch = this.m_cameraPreSnapPitch;
                this.m_cameraDestYaw = this.m_cameraPreSnapYaw;
                break;
            case 6:
                this.m_cameraAtDest = false;
                this.cameraStorePreSnap();
                this.m_cameraTarget = this.m_miniGameTargetObject;
                this.calcMiniGameCameraDest();
                if (this.m_miniGameType == 2)
                {
                    this.m_simWorld.setCameraPosX(this.m_cameraDestX);
                    this.m_simWorld.setCameraPosY(this.m_cameraDestY);
                    this.m_simWorld.setCameraPosZ(this.m_cameraDestZ);
                    this.m_simWorld.setCameraPitch(this.m_cameraDestPitch);
                    this.m_simWorld.setCameraYaw(this.m_cameraDestYaw);
                    this.m_simWorld.setCameraDolly(this.m_cameraDestDolly);
                    this.m_simWorld.setupCameraTransform();
                    this.m_cameraAtDest = true;
                    break;
                }
                break;
            case 8:
                this.m_cameraTarget = (MapObject)null;
                this.m_cameraDestX = this.m_cameraPreSnapX;
                this.m_cameraDestY = this.m_cameraPreSnapY;
                this.m_cameraDestZ = this.m_cameraPreSnapZ;
                this.m_cameraDestDolly = this.m_cameraPreSnapDolly;
                this.m_cameraDestPitch = this.m_cameraPreSnapPitch;
                this.m_cameraDestYaw = this.m_cameraPreSnapYaw;
                if (this.m_miniGameType == 2)
                {
                    this.m_simWorld.setCameraPosX(this.m_cameraDestX);
                    this.m_simWorld.setCameraPosY(this.m_cameraDestY);
                    this.m_simWorld.setCameraPosZ(this.m_cameraDestZ);
                    this.m_simWorld.setCameraPitch(this.m_cameraDestPitch);
                    this.m_simWorld.setCameraYaw(this.m_cameraDestYaw);
                    this.m_simWorld.setCameraDolly(this.m_cameraDestDolly);
                    this.m_cameraFilterX.setSteadyState(this.m_simWorld.getCameraPosX());
                    this.m_cameraFilterY.setSteadyState(this.m_simWorld.getCameraPosY());
                    this.m_cameraFilterZ.setSteadyState(this.m_simWorld.getCameraPosZ());
                    this.m_cameraFilterDolly.setSteadyState(this.m_simWorld.getCameraDolly());
                    this.m_cameraFilterPitch.setSteadyState(this.m_simWorld.getCameraPitch());
                    this.m_cameraFilterYaw.setSteadyState(this.m_simWorld.getCameraYaw());
                    break;
                }
                break;
        }
        if (cameraState != 0 || newState == 0)
            return;
        this.m_cameraFilterX.setSteadyState(this.m_simWorld.getCameraPosX());
        this.m_cameraFilterY.setSteadyState(this.m_simWorld.getCameraPosY());
        this.m_cameraFilterZ.setSteadyState(this.m_simWorld.getCameraPosZ());
        this.m_cameraFilterDolly.setSteadyState(this.m_simWorld.getCameraDolly());
        this.m_cameraFilterPitch.setSteadyState(this.m_simWorld.getCameraPitch());
        this.m_cameraFilterYaw.setSteadyState(this.m_simWorld.getCameraYaw());
    }

    private void cameraStorePreSnap()
    {
        this.m_cameraPreSnapX = this.m_simWorld.getCameraPosX();
        this.m_cameraPreSnapY = this.m_simWorld.getCameraPosY();
        this.m_cameraPreSnapZ = this.m_simWorld.getCameraPosZ();
        this.m_cameraPreSnapDolly = this.m_simWorld.getCameraDolly();
        this.m_cameraPreSnapPitch = this.m_simWorld.getCameraPitch();
        this.m_cameraPreSnapYaw = this.m_simWorld.getCameraYaw();
    }

    public MapObject getCameraTarget()
    {
        return this.m_cameraTarget;
    }

    private void setFindMySimCameraLookat()
    {
        this.m_cameraTarget = (MapObject)this.getPlayerSim();
        this.cameraStorePreSnap();
        this.stateTransitionCamera(3);
    }

    public void setCameraLookAtBrokenObject(MapObject target)
    {
        this.setCameraLookAt(target);
        this.m_snappingToBroken = true;
    }

    public void setCameraLookAt(MapObject target)
    {
        this.m_cameraTarget = target;
        if (target == null)
        {
            if (this.m_cameraState == 8)
                return;
            this.stateTransitionCamera(0);
        }
        else
        {
            this.cameraStorePreSnap();
            this.stateTransitionCamera(2);
        }
    }

    public void setCameraLookAtPoint(float x, float z, float dolly)
    {
        this.m_cameraDestX = x;
        this.m_cameraDestY = this.m_simWorld.getCameraPosY();
        this.m_cameraDestZ = z;
        this.m_cameraDestDolly = dolly;
        this.m_cameraDestPitch = this.m_simWorld.getCameraPitch();
        this.m_cameraDestYaw = this.m_simWorld.getCameraYaw();
        this.m_cameraTarget = (MapObject)null;
        this.cameraStorePreSnap();
        this.stateTransitionCamera(4);
    }

    public void setCameraFollow(MapObject target)
    {
        if (this.m_contextMenuActive)
            return;
        this.setCursorObject((MapObject)null);
        this.m_cameraTarget = target;
        if (target == null)
            this.stateTransitionCamera(0);
        else
            this.stateTransitionCamera(1);
    }

    private void setCameraUnsnap()
    {
        this.stateTransitionCamera(5);
    }

    private void resetCameraVelocity()
    {
        this.m_cameraAtDest = true;
        this.m_cameraDragVelX = 0.0f;
        this.m_cameraDragVelZ = 0.0f;
        this.m_cameraDragVelYaw = 0.0f;
        this.m_cameraDragVelPitch = 0.0f;
        this.m_cameraDragVelDolly = 0.0f;
        this.m_cameraDragReleaseTime = 0;
    }

    public void clearCameraFollow()
    {
        if (this.m_cameraState == 1)
        {
            this.m_cameraTarget = (MapObject)null;
            this.stateTransitionCamera(0);
        }
        else
        {
            if (this.m_cameraState != 5)
                return;
            this.stateTransitionCamera(0);
        }
    }

    protected void snapCameraPosition()
    {
        this.calcCameraDest();
        this.m_simWorld.setCameraPosX(this.m_cameraDestX);
        this.m_simWorld.setCameraPosY(this.m_cameraDestY);
        this.m_simWorld.setCameraPosZ(this.m_cameraDestZ);
        this.m_cameraAtDest = true;
    }

    public void snapCameraAndCursor(MapObject obj)
    {
        this.setCursorObject(obj);
        this.snapCameraPosition();
        this.setCursorObject((MapObject)null);
    }

    protected void updateCamera(int timeStep)
    {
        switch (this.m_cameraState)
        {
            case 0:
                this.updateCameraNavigation(timeStep);
                break;
            case 1:
                this.calcCameraDest();
                if (this.m_cameraAtDest)
                    this.snapCameraPosition();
                else
                    this.updateCameraSnapping(timeStep);
                this.updateCameraNavigation(timeStep);
                break;
            case 2:
            case 3:
                this.calcCameraDest();
                this.updateCameraSnapping(timeStep);
                break;
            case 4:
            case 5:
                this.updateCameraSnapping(timeStep);
                break;
            case 6:
                if (this.m_miniGameType != 2)
                {
                    this.updateCameraSnapping(timeStep);
                    break;
                }
                break;
            case 7:
                if (this.m_miniGameType == 1 && this.m_miniGameState == 8)
                {
                    this.calcMiniGameCameraDest();
                    this.updateCameraSnapping(timeStep);
                    break;
                }
                break;
            case 8:
                this.updateCameraSnapping(timeStep);
                if (this.m_cameraAtDest)
                {
                    this.stateTransitionCamera(0);
                    break;
                }
                break;
            case 9:
                this.m_cameraDestX = this.m_simWorld.getCameraPosX();
                this.m_cameraDestY = this.m_simWorld.getCameraPosY();
                this.m_cameraDestZ = this.m_simWorld.getCameraPosZ();
                this.m_cameraDestDolly = 750f;
                this.m_cameraDestPitch = this.m_simWorld.getCameraPitch();
                this.m_cameraDestYaw = this.m_simWorld.getCameraYaw();
                this.updateCameraSnapping(timeStep);
                break;
        }
        this.m_simWorld.updateCameraPos(timeStep);
    }

    private void calcCameraDest()
    {
        float num1 = this.m_simWorld.getCameraPosX();
        float num2 = this.m_simWorld.getCameraPosY();
        float num3 = this.m_simWorld.getCameraPosZ();
        float num4 = this.m_simWorld.getCameraDolly();
        float cameraPitch = this.m_simWorld.getCameraPitch();
        float cameraYaw = this.m_simWorld.getCameraYaw();
        if (this.m_cameraTarget != null)
        {
            int[] tempInt4 = this.m_tempInt4;
            this.m_cameraTarget.getHotspot(tempInt4, 0);
            num1 = (float)tempInt4[0] * 1.525879E-05f;
            num2 = 16f;
            num3 = (float)tempInt4[2] * 1.525879E-05f;
            if (this.m_contextMenuActive)
            {
                num4 = this.isMapMode() ? 1000f : 300f;
                int num5 = this.isMapMode() ? 90 : 33;
                float radians = MathExt.degreesToRadians(cameraYaw + 90f);
                int num6 = (int)((double)midp.JMath.Sin(radians) * (double)num5);
                int num7 = (int)((double)midp.JMath.Cos(radians) * (double)num5);
                num1 += (float)num6;
                num3 += (float)num7;
            }
        }
        this.m_cameraDestX = num1;
        this.m_cameraDestY = num2;
        this.m_cameraDestZ = num3;
        this.m_cameraDestDolly = num4;
        this.m_cameraDestPitch = cameraPitch;
        this.m_cameraDestYaw = cameraYaw;
    }

    private void calcMiniGameCameraDest()
    {
        float num1 = this.m_simWorld.getCameraPosX();
        float num2 = this.m_simWorld.getCameraPosY();
        float num3 = this.m_simWorld.getCameraPosZ();
        float num4 = this.m_simWorld.getCameraDolly();
        float num5 = this.m_simWorld.getCameraPitch();
        float num6 = this.m_simWorld.getCameraYaw();
        if (this.m_cameraTarget != null)
        {
            int[] tempInt4 = this.m_tempInt4;
            this.m_cameraTarget.getHotspot(tempInt4, 0);
            num1 = (float)tempInt4[0] * 1.525879E-05f;
            num2 = 16f;
            num3 = (float)tempInt4[2] * 1.525879E-05f;
        }
        this.m_miniGameTypeString = (string)null;
        switch (this.m_miniGameType)
        {
            case 0:
                this.m_miniGameTypeString = "cooking";
                num4 = 100f;
                num5 = 47f;
                num2 = 30f;
                num6 = (float)((this.m_cameraTarget.getFacingAngle() >> 16) - 10);
                break;
            case 1:
                this.m_miniGameTypeString = "fishing";
                if (this.m_miniGameState != 8)
                {
                    num4 = 180f;
                    num5 = 50f;
                    num2 = 55f;
                    num6 = (float)((this.m_cameraTarget.getFacingAngle() >> 16) + 200);
                    if (this.getPlayerSim().getFacingDir() == 3 || this.getPlayerSim().getFacingDir() == 2)
                        num6 -= 90f;
                    float radians = MathExt.degreesToRadians(num6 + 90f);
                    int num7 = (int)((double)midp.JMath.Sin(radians) * 30.0);
                    int num8 = (int)((double)midp.JMath.Cos(radians) * 30.0);
                    num1 += (float)num7;
                    num3 += (float)num8;
                    break;
                }
                num4 = 200f;
                num5 = 20f;
                num2 = 35f;
                num6 = (float)((this.m_cameraTarget.getFacingAngle() >> 16) - 45);
                if (this.getPlayerSim().getFacingDir() == 3 || this.getPlayerSim().getFacingDir() == 2)
                {
                    num6 -= 90f;
                    break;
                }
                break;
            case 2:
                this.m_miniGameTypeString = "repairing";
                num1 = 10000f;
                num2 = 0.0f;
                num3 = 10000f;
                num5 = 70f;
                num6 = 0.0f;
                num4 = 350f;
                break;
        }
        SpywareManager.getInstance().trackMiniGameStart(this.m_miniGameTypeString);
        this.m_cameraDestX = num1;
        this.m_cameraDestY = num2;
        this.m_cameraDestZ = num3;
        this.m_cameraDestDolly = num4;
        this.m_cameraDestPitch = num5;
        this.m_cameraDestYaw = num6;
    }

    private void updateCameraSnapping(int timeStep)
    {
        this.m_cameraFilterX.setTargetValue(this.m_cameraDestX);
        this.m_cameraFilterY.setTargetValue(this.m_cameraDestY);
        this.m_cameraFilterZ.setTargetValue(this.m_cameraDestZ);
        this.m_cameraFilterDolly.setTargetValue(this.m_cameraDestDolly);
        this.m_cameraFilterPitch.setTargetValue(this.m_cameraDestPitch);
        this.m_cameraFilterYaw.setTargetValue(this.m_cameraDestYaw);
        this.m_cameraFilterX.update(timeStep);
        this.m_cameraFilterY.update(timeStep);
        this.m_cameraFilterZ.update(timeStep);
        this.m_cameraFilterDolly.update(timeStep);
        this.m_cameraFilterPitch.update(timeStep);
        this.m_cameraFilterYaw.update(timeStep);
        this.m_simWorld.setCameraPosX(this.m_cameraFilterX.getFilteredValue());
        this.m_simWorld.setCameraPosY(this.m_cameraFilterY.getFilteredValue());
        this.m_simWorld.setCameraPosZ(this.m_cameraFilterZ.getFilteredValue());
        this.m_simWorld.setCameraDolly(this.m_cameraFilterDolly.getFilteredValue());
        this.m_simWorld.setCameraPitch(this.m_cameraFilterPitch.getFilteredValue());
        this.m_simWorld.setCameraYaw(this.m_cameraFilterYaw.getFilteredValue());
        this.m_cameraAtDest = (double)midp.JMath.abs(this.m_cameraFilterX.getTargetValue() - this.m_simWorld.getCameraPosX()) + (double)midp.JMath.abs(this.m_cameraFilterY.getTargetValue() - this.m_simWorld.getCameraPosY()) + (double)midp.JMath.abs(this.m_cameraFilterZ.getTargetValue() - this.m_simWorld.getCameraPosZ()) + (double)midp.JMath.abs(this.m_cameraFilterYaw.getTargetValue() - this.m_simWorld.getCameraYaw()) + (double)midp.JMath.abs(this.m_cameraFilterPitch.getTargetValue() - this.m_simWorld.getCameraPitch()) + (double)midp.JMath.abs(this.m_cameraFilterDolly.getTargetValue() - this.m_simWorld.getCameraDolly()) < 1.0;
        if (!this.m_cameraAtDest)
            return;
        if (this.m_cameraState == 3 || this.m_cameraState == 9 || this.m_snappingToBroken)
        {
            this.setCameraFollow((MapObject)null);
            this.m_snappingToBroken = false;
        }
        else
        {
            if (this.m_cameraState != 4)
                return;
            this.setCameraLookAt((MapObject)null);
        }
    }

    private void stateTransitionDragging(int newState)
    {
        this.m_dragState = newState;
    }

    private void updateCameraNavigation(int timeStep)
    {
        if (this.getPointerState() != 0 || this.m_cameraDragReleaseTime <= 0)
            return;
        float num1 = (float)((double)this.m_cameraDragVelX * (double)this.m_cameraDragReleaseTime / 700.0);
        float num2 = (float)((double)this.m_cameraDragVelZ * (double)this.m_cameraDragReleaseTime / 700.0);
        float num3 = (float)((double)this.m_cameraDragVelYaw * (double)this.m_cameraDragReleaseTime / 700.0);
        float num4 = (float)((double)this.m_cameraDragVelPitch * (double)this.m_cameraDragReleaseTime / 700.0);
        float num5 = (float)((double)this.m_cameraDragVelDolly * (double)this.m_cameraDragReleaseTime / 700.0);
        this.m_cameraDragReleaseTime -= timeStep;
        int cameraPosX = (int)this.m_simWorld.getCameraPosX();
        int cameraPosZ = (int)this.m_simWorld.getCameraPosZ();
        float[] rangeSlowdownFactor = this.m_simWorld.getCamRangeSlowdownFactor(num1 * (float)timeStep, num2 * (float)timeStep);
        float num6 = rangeSlowdownFactor[0];
        float num7 = rangeSlowdownFactor[1];
        this.m_simWorld.setCameraPosX((float)cameraPosX + num6);
        this.m_simWorld.setCameraPosZ((float)cameraPosZ + num7);
        this.m_simWorld.setCameraYaw((float)MathExt.normaliseAngleDegreesF((int)((double)this.m_simWorld.getCameraYaw() + (double)num3 * (double)timeStep)));
        this.m_simWorld.setCameraPitch((float)midp.JMath.min(75, midp.JMath.max(15, (int)((double)this.m_simWorld.getCameraPitch() + (double)num4 * (double)timeStep))));
        int b = (int)((double)this.m_simWorld.getCameraDolly() + (double)num5 * (double)timeStep);
        this.m_simWorld.setCameraDolly((float)midp.JMath.min(this.isMapMode() ? 1800 : 750, midp.JMath.max(this.isMapMode() ? 800 : 150, b)));
    }

    protected void initHouseMap()
    {
        AppEngine.timerBegin();
        this.m_simWorld.prepareWorldHouse(this.m_engine.getNextHouseId());
        if (this.m_initialState == 96)
        {
            this.m_initialState = 6;
            this.putSimInBed(this.getPlayerSim());
            this.m_timeHit = 120;
            this.m_simData.delayAlerts();
            this.startCurtainOut();
            this.m_curtainPlayerAction = 9;
        }
        AppEngine.timerEnd(nameof(initHouseMap));
    }

    private void initZoomMap()
    {
        AppEngine.timerBegin();
        this.m_simWorld.prepareWorldZoomMap(this.m_engine.getNextZoomMapId());
        foreach (MapObjectSim simObject in this.getSimObjects())
        {
            if (simObject.getId() != 0)
                simObject.setNeedFlag(64);
        }
        AppEngine.timerEnd(nameof(initZoomMap));
    }

    private void initMacroMap()
    {
        AppEngine.timerBegin();
        bool atWork = false;
        if (this.m_initialState == 99)
        {
            this.m_initialState = 6;
            atWork = true;
        }
        bool atAirport = false;
        this.m_simWorld.prepareWorldMacromap(atWork, atAirport);
        AppEngine.timerEnd(nameof(initMacroMap));
    }

    public MapObject[] getObjects()
    {
        if (this.m_refreshObjects)
        {
            this.m_refreshObjects = false;
            if (this.m_objects == null || this.m_objects.Length != this.m_objectStack.Count)
                this.m_objects = new MapObject[this.m_objectStack.Count];
            this.m_objectStack.CopyTo(this.m_objects, 0);
        }
        return this.m_objects;
    }

    public MapObjectSim[] getSimObjects()
    {
        if (this.m_refreshObjectsSims)
        {
            this.m_refreshObjectsSims = false;
            MapObject[] objects = this.getObjects();
            int length = 0;
            for (int index = 0; index < objects.Length; ++index)
            {
                if (objects[index].getFlag(8192))
                    ++length;
            }
            MapObjectSim[] mapObjectSimArray1 = this.m_objectsSims;
            if (mapObjectSimArray1 == null || mapObjectSimArray1.Length != length)
            {
                this.m_objectsSims = new MapObjectSim[0];
                MapObjectSim[] mapObjectSimArray2 = new MapObjectSim[0];
                mapObjectSimArray1 = new MapObjectSim[length];
                this.m_objectsSims = mapObjectSimArray1;
            }
            int index1 = 0;
            for (int index2 = 0; index2 < objects.Length; ++index2)
            {
                if (objects[index2].getFlag(8192))
                {
                    mapObjectSimArray1[index1] = (MapObjectSim)objects[index2];
                    ++index1;
                }
            }
        }
        return this.m_objectsSims;
    }

    public MapObjectSim getPlayerSim()
    {
        return this.m_playerSim;
    }

    public MapObject getWalkTo()
    {
        return this.m_walkToMarker;
    }

    public MapObject findRandomObjectByType(int type)
    {
        MapObject[] objects = this.getObjects();
        int num = this.m_engine.rand(0, objects.Length - 1);
        for (int index1 = 0; index1 < objects.Length; ++index1)
        {
            int index2 = (num + index1) % objects.Length;
            MapObject mapObject = objects[index2];
            if (mapObject.getType() == type)
                return mapObject;
        }
        return (MapObject)null;
    }

    public MapObject findRandomObjectByParentType(int parentType)
    {
        MapObject[] objects = this.getObjects();
        int num = this.m_engine.rand(0, objects.Length - 1);
        for (int index1 = 0; index1 < objects.Length; ++index1)
        {
            int index2 = (num + index1) % objects.Length;
            MapObject mapObject = objects[index2];
            if (mapObject.getParentType() == parentType)
                return mapObject;
        }
        return (MapObject)null;
    }

    public MapObject findObjectByTypeNearest(int type, int posXF, int posZF)
    {
        MapObject mapObject1 = (MapObject)null;
        int num1 = int.MaxValue;
        foreach (MapObject mapObject2 in this.getObjects())
        {
            if (mapObject2.getType() == type)
            {
                int num2 = midp.JMath.abs(posXF - mapObject2.getPosX()) + midp.JMath.abs(posZF - mapObject2.getPosZ());
                if (num2 < num1)
                {
                    num1 = num2;
                    mapObject1 = mapObject2;
                }
            }
        }
        return mapObject1;
    }

    public MapObject findObjectByParentTypeNearest(int parentType, int posXF, int posZF)
    {
        MapObject mapObject1 = (MapObject)null;
        int num1 = int.MaxValue;
        foreach (MapObject mapObject2 in this.getObjects())
        {
            if (mapObject2.getParentType() == parentType)
            {
                int num2 = midp.JMath.abs(posXF - mapObject2.getPosX()) + midp.JMath.abs(posZF - mapObject2.getPosZ());
                if (num2 < num1)
                {
                    num1 = num2;
                    mapObject1 = mapObject2;
                }
            }
        }
        return mapObject1;
    }

    public MapObject findWallFadableObjectAt(int posXF, int posZF)
    {
        MapObject mapObject1 = (MapObject)null;
        int num1 = 2097153;
        foreach (MapObject mapObject2 in this.getObjects())
        {
            if (mapObject2.getFlag(512))
            {
                int num2 = midp.JMath.abs(posXF - mapObject2.getPosX()) + midp.JMath.abs(posZF - mapObject2.getPosZ());
                if (num2 < num1)
                {
                    num1 = num2;
                    mapObject1 = mapObject2;
                }
            }
        }
        return mapObject1;
    }

    public MapObject findObjectAtScreen(int screenX, int screenY, int maxDepthF)
    {
        int num1 = this.isMapMode() ? 90 : 50;
        MapObject mapObject1 = (MapObject)null;
        int num2 = int.MaxValue;
        MapObject[] objects = this.getObjects();
        int[] tempInt4 = this.m_tempInt4;
        int[] tempInt10 = this.m_tempInt10;
        for (int index1 = 0; index1 < objects.Length; ++index1)
        {
            MapObject mapObject2 = objects[index1];
            if (mapObject2.getFlag(this.m_cursorSelectFlags) && mapObject2.isInView())
            {
                int hotspotCount = mapObject2.getHotspotCount();
                for (int index2 = 0; index2 < hotspotCount; ++index2)
                {
                    mapObject2.getHotspot(tempInt4, index2);
                    this.m_simWorld.coordWorldToScreen(tempInt10, tempInt4[0], tempInt4[1], tempInt4[2]);
                    int num3 = tempInt10[2];
                    if (num3 >= 0 && (maxDepthF == 0 || num3 <= maxDepthF))
                    {
                        int num4 = midp.JMath.abs(tempInt10[0] - screenX) + midp.JMath.abs(tempInt10[1] - screenY);
                        if (num4 < num1 && num4 < num2)
                        {
                            mapObject1 = mapObject2;
                            num2 = num4;
                        }
                    }
                }
            }
        }
        return mapObject1;
    }

    public bool isObjectAt(int parentType, int posXF, int posZF)
    {
        SimWorld simWorld = this.m_simWorld;
        int worldTileX1 = simWorld.coordWorldToWorldTileX(posXF);
        int worldTileZ1 = simWorld.coordWorldToWorldTileZ(posZF);
        foreach (MapObject mapObject in this.getObjects())
        {
            if (mapObject.getParentType() == parentType)
            {
                int worldTileX2 = simWorld.coordWorldToWorldTileX(mapObject.getPosX());
                int worldTileZ2 = simWorld.coordWorldToWorldTileZ(mapObject.getPosZ());
                if (worldTileX2 == worldTileX1 && worldTileZ2 == worldTileZ1)
                    return true;
            }
        }
        return false;
    }

    public bool isSimAt(int posXF, int posZF)
    {
        SimWorld simWorld = this.m_simWorld;
        int worldTileX1 = simWorld.coordWorldToWorldTileX(posXF);
        int worldTileZ1 = simWorld.coordWorldToWorldTileZ(posZF);
        foreach (MapObject mapObject in this.getObjects())
        {
            if (mapObject.getFlag(8192))
            {
                int worldTileX2 = simWorld.coordWorldToWorldTileX(mapObject.getPosX());
                int worldTileZ2 = simWorld.coordWorldToWorldTileZ(mapObject.getPosZ());
                if (worldTileX2 == worldTileX1 && worldTileZ2 == worldTileZ1)
                    return true;
            }
        }
        return false;
    }

    public MapObject findBenchtopSupplyObjectAt(int tileX, int tileZ)
    {
        SimWorld simWorld = this.m_simWorld;
        foreach (MapObject mapObject in this.getObjects())
        {
            if (mapObject.getFlag(524288))
            {
                int worldTileX = simWorld.coordWorldToWorldTileX(mapObject.getPosX());
                int worldTileZ = simWorld.coordWorldToWorldTileZ(mapObject.getPosZ());
                int footprintX = mapObject.getFootprintX();
                int footprintZ = mapObject.getFootprintZ();
                if (tileX <= worldTileX && tileZ <= worldTileZ && (tileX > worldTileX - footprintX && tileZ > worldTileZ - footprintZ))
                    return mapObject;
            }
        }
        return (MapObject)null;
    }

    public MapObject findFrontDoor()
    {
        foreach (MapObject mapObject in this.getObjects())
        {
            if (mapObject.getParentType() == 15 && mapObject.getRuntimeFlag(1048576))
                return mapObject;
        }
        return (MapObject)null;
    }

    public MapObject findSitObject(MapObjectSim sim, int action)
    {
        SimWorld simWorld = this.m_simWorld;
        MapObject[] objects = this.getObjects();
        int num = this.m_engine.rand(0, objects.Length - 1);
        for (int index1 = 0; index1 < objects.Length; ++index1)
        {
            int index2 = (num + index1) % objects.Length;
            MapObject @object = objects[index2];
            int type = @object.getType();
            if ((simWorld.getObjectNeed(type) & 256) != 0 && @object.occupiedIsAnyAvailable())
            {
                if (action == 132)
                {
                    if (@object.getParentType() != 13)
                    {
                        int posX = @object.getPosX();
                        int posZ = @object.getPosZ();
                        int worldTileX = simWorld.coordWorldToWorldTileX(posX);
                        int worldTileZ = simWorld.coordWorldToWorldTileZ(posZ);
                        int facingDir = @object.getFacingDir();
                        int tileX = worldTileX + MapObject.getFacingOffsetX(1, 0, facingDir);
                        int tileZ = worldTileZ + MapObject.getFacingOffsetZ(1, 0, facingDir);
                        if (this.findBenchtopSupplyObjectAt(tileX, tileZ) == null || simWorld.isBenchTopObjectAt(tileX, tileZ))
                            continue;
                    }
                    else
                        continue;
                }
                if (sim.simCanWalkTo(@object, 0, 0))
                    return @object;
            }
        }
        return (MapObject)null;
    }

    public MapObject findSitObjectTV(MapObjectSim sim, MapObject tv)
    {
        int roomId = sim.getRoomId();
        int num1 = 0;
        MapObject mapObject = (MapObject)null;
        SimWorld simWorld = this.m_simWorld;
        MapObject[] objects = this.getObjects();
        int num2 = this.m_engine.rand(0, objects.Length - 1);
        for (int index1 = 0; index1 < objects.Length; ++index1)
        {
            int index2 = (num2 + index1) % objects.Length;
            MapObject from = objects[index2];
            int type = from.getType();
            if ((simWorld.getObjectNeed(type) & 256) != 0 && from.occupiedIsAnyAvailable() && (from.getRoomId() == roomId && tv.tvViewable(from)))
            {
                int num3 = midp.JMath.abs(sim.getPosX() - from.getPosX()) + midp.JMath.abs(sim.getPosZ() - from.getPosZ());
                if (num3 < num1 || num1 == 0)
                {
                    num1 = num3;
                    mapObject = from;
                }
            }
        }
        return mapObject;
    }

    public MapObject findRandomNeedObject(int needFlags)
    {
        SimWorld simWorld = this.m_simWorld;
        MapObject[] objects = this.getObjects();
        int num = this.m_engine.rand(0, objects.Length - 1);
        for (int index1 = 0; index1 < objects.Length; ++index1)
        {
            int index2 = (num + index1) % objects.Length;
            MapObject mapObject = objects[index2];
            int type = mapObject.getType();
            if ((simWorld.getObjectNeed(type) & needFlags) != 0 && mapObject.occupiedIsAnyAvailable() && !mapObject.getRuntimeFlag(768))
                return mapObject;
        }
        return (MapObject)null;
    }

    public MapObjectSim findSim(int simId)
    {
        MapObjectSim[] simObjects = this.getSimObjects();
        int length = simObjects.Length;
        for (int index = 0; index < length; ++index)
        {
            MapObjectSim mapObjectSim = simObjects[index];
            if (mapObjectSim.getId() == simId)
                return mapObjectSim;
        }
        return (MapObjectSim)null;
    }

    public MapObject createObject(int type, int xF, int yF, int zF, int facing, int id)
    {
        int objectFlags = this.m_simWorld.getObjectFlags(type);
        if (this.isZoomMapMode() && (type == 2 || type == 3))
            objectFlags |= 4096;
        MapObject @object = (MapObject)null;
        if ((objectFlags & 8192) != 0)
        {
            @object = (MapObject)new MapObjectSim(this);
            if (type == 0)
            {
                this.m_playerSim = (MapObjectSim)@object;
                this.m_walkToMarker = this.createObjectOnWorldTile(5, 0, 0, 0, 0, -1);
                this.m_walkToMarker.hide();
            }
        }
        else if ((objectFlags & 4096) != 0)
            @object = new MapObject(this);
        if (@object != null)
        {
            @object.init(type, xF, yF, zF, facing, id);
            this.addObject(@object);
            @object.updateModel();
        }
        return @object;
    }

    public MapObject createObjectOnObjectInterestPoint(int type, MapObject target, int id)
    {
        int[] tempInt10 = this.m_tempInt10;
        int interestPointCount = target.getInterestPointCount();
        int index = 0;
        do
        {
            target.getInterestPoint(tempInt10, index);
            ++index;
        }
        while (index < interestPointCount && !this.m_simWorld.isWorldPointWalkable(tempInt10[0], tempInt10[1]) && (interestPointCount <= 1 || this.isSimAt(tempInt10[0], tempInt10[1])));
        return this.createObject(type, tempInt10[0], 0, tempInt10[1], 0, id);
    }

    public MapObject createObjectOnWorldTile(
      int type,
      int roomTileX,
      int yF,
      int roomTileZ,
      int facingDir,
      int id)
    {
        SimWorld simWorld = this.m_simWorld;
        int worldCenterX = simWorld.coordWorldTileToWorldCenterX(roomTileX);
        int worldCenterZ = simWorld.coordWorldTileToWorldCenterZ(roomTileZ);
        return this.createObject(type, worldCenterX, yF, worldCenterZ, facingDir, id);
    }

    public void createEffectAnim(int wxF, int wyF, int wzF, int animId)
    {
        this.createObject(10, wxF, wyF, wzF, 3, -1)?.effectPlayAnim(animId);
    }

    public void createEffectModel(int wxF, int wyF, int wzF, int modelId, int animId)
    {
        this.createObject(13, wxF, wyF, wzF, 3, -1)?.effectPlayModel(modelId, animId);
    }

    public void createEffectMoney(int wxF, int wzF, int value)
    {
        this.createObject(11, wxF, 0, wzF, 3, -1)?.effectShowMoney(value);
    }

    private void addObject(MapObject @object)
    {
        @object.applyFootprint(true);
        this.m_objectStack.Push(@object);
        this.m_refreshObjects = true;
        if (!@object.getFlag(8192))
            return;
        this.m_refreshObjectsSims = true;
    }

    public void removeObject(MapObject @object)
    {
        if (this.getCursorObject() == @object)
            this.setCursorObject((MapObject)null);
        if (this.m_contextMenuActive && this.m_contextMenuObject == @object)
            this.hideContextMenu();
        int num = -1;
        if (@object.getFlag(8192))
            num = @object.getId();
        @object.applyFootprint(false);
        this.m_objectStackToRemove.Push(@object);
        AppEngine.removeObjectFromStack<MapObject>(ref this.m_objectStack, @object);
        this.m_refreshObjects = true;
        if (num == -1)
            return;
        this.m_refreshObjectsSims = true;
    }

    private void updateObjects(int timeStep)
    {
        ModelManager.getInstance().clearTVFrame();
        MapObject[] objects = this.getObjects();
        if (objects != null)
        {
            for (int index = 0; index < objects.Length; ++index)
                objects[index].update(timeStep);
        }
        this.m_objectStackToRemove.Clear();
    }

    private void updateObjectTypes(int timeStep, int type)
    {
        MapObject[] objects = this.getObjects();
        if (objects == null)
            return;
        for (int index = 0; index < objects.Length; ++index)
        {
            MapObject mapObject = objects[index];
            if (mapObject.getType() == type)
                mapObject.update(timeStep);
        }
    }

    public void removeBuildPoints()
    {
        foreach (MapObject mapObject in this.getObjects())
        {
            if (mapObject.getFlag(8))
                mapObject.destroy();
        }
    }

    public MapObject getContextMenuObject()
    {
        return this.m_contextMenuObject;
    }

    public void showContextMenu(MapObject @object)
    {
        SimData simData = this.m_simData;
        int[] contextMenuItems = this.m_contextMenuItems;
        int[] contextMenuActions = this.m_contextMenuActions;
        simData.setLastNPC(-1);
        this.m_contextMenuActive = true;
        this.m_contextMenuOnSubMenu = false;
        this.m_contextMenuBackCursor = (short)-1;
        this.m_contextMenuObject = @object;
        if (this.m_state == 7)
        {
            @object.createBuildContextMenu(contextMenuItems);
            AppEngine.menuCopy(contextMenuActions, contextMenuItems);
        }
        else
        {
            int index = Array.IndexOf<MapObject>(this.m_actionQueueArg1s, this.m_contextMenuObject);
            if (index != -1 && this.m_actionQueueActions[index] != 2)
            {
                int title = !this.m_contextMenuObject.getFlag(8192) ? this.m_contextMenuObject.getTypeString() : this.m_simData.getSimName(this.m_contextMenuObject.getId());
                AppEngine.menuClear(contextMenuItems, title);
                AppEngine.menuClear(contextMenuActions, title);
                AppEngine.menuAppendItem(contextMenuItems, 126);
                AppEngine.menuAppendItem(contextMenuActions, -3);
            }
            else
                simData.createContextMenu(this.m_contextMenuObject, contextMenuItems, contextMenuActions);
            AppEngine.menuCopy(this.m_contextMenuFullActions, contextMenuActions);
            if (contextMenuItems[0] > (int)this.m_maxContextMenuItems)
                simData.compactContextMenu(contextMenuItems, contextMenuActions, this.m_contextMenuFullActions);
        }
        contextMenuItems[4] = (int)this.m_maxContextMenuItems;
        this.refreshContextMenu();
    }

    private void refreshContextMenu()
    {
        this.m_contextMenu.setItems(ref this.m_contextMenuItems, ref this.m_contextMenuActions, this.m_contextMenuOnSubMenu ? 2 : 16);
    }

    private void hideContextMenu()
    {
        this.m_contextMenuActive = false;
        this.m_contextMenuOnSubMenu = false;
        this.m_contextMenuBackCursor = (short)-1;
        this.m_contextMenuObject = (MapObject)null;
        this.setCursorObject((MapObject)null);
    }

    private void renderContextMenu(Graphics g)
    {
        this.m_contextMenu.render(g);
    }

    private void processContextMenuBack()
    {
        this.resetPlayerInactivity();
        if (this.m_contextMenuOnSubMenu)
        {
            this.m_simData.compactContextMenu(this.m_contextMenuItems, this.m_contextMenuActions, this.m_contextMenuFullActions);
            this.m_contextMenuItems[4] = (int)this.m_maxContextMenuItems;
            this.m_contextMenuOnSubMenu = false;
            this.m_contextMenuItems[2] = (int)this.m_contextMenuBackCursor;
            AppEngine.menuVisible(this.m_contextMenuItems);
            this.refreshContextMenu();
        }
        else
        {
            this.hideContextMenu();
            this.setCameraUnsnap();
        }
    }

    private void processContextMenuSelect()
    {
        int index = 5 + this.m_contextMenuItems[2];
        if (this.m_state == 7)
        {
            this.processBasicAction(this.m_contextMenuItems[index]);
        }
        else
        {
            int contextMenuAction = this.m_contextMenuActions[index];
            switch (contextMenuAction)
            {
                case -6:
                case -5:
                    this.processContextMenuBack();
                    break;
                case -4:
                    this.hideContextMenu();
                    this.setCameraUnsnap();
                    break;
                case -3:
                    this.processCancelAction(this.m_contextMenuObject);
                    this.hideContextMenu();
                    this.setCameraUnsnap();
                    break;
                case -2:
                    this.m_contextMenuBackCursor = (short)this.m_contextMenuItems[2];
                    this.m_contextMenuOnSubMenu = true;
                    this.m_simData.filterContextMenu(this.m_contextMenuItems, this.m_contextMenuActions, this.m_contextMenuFullActions, this.m_contextMenuItems[index]);
                    this.m_contextMenuItems[4] = (int)this.m_maxContextMenuItems;
                    this.refreshContextMenu();
                    break;
                case 116:
                    this.processPlantAction();
                    break;
                case 132:
                    this.processCookAction();
                    break;
                case 147:
                case 148:
                    this.processCallAction();
                    break;
                case 172:
                    this.hideMenus();
                    this.stateTransition(22);
                    break;
                default:
                    MapObject cursorObject = this.getCursorObject();
                    this.hideMenus();
                    this.setCameraUnsnap();
                    this.processSimAction(contextMenuAction, cursorObject, 0, 0);
                    if (this.m_state != 21 || this.m_tutorialState != 4)
                        break;
                    this.showTutorialMessage(1692, 1691);
                    break;
            }
        }
    }

    private int getSimContext()
    {
        SimData simData = this.m_simData;
        if (!this.m_suppressMenus && this.m_contextMenuActive)
        {
            if (this.m_contextMenuObject != null && this.m_contextMenuObject.getFlag(8192))
                return this.m_contextMenuObject.getId();
        }
        else if (simData.isLastNPCStillRelevant())
            return simData.getLastNPC();
        return -1;
    }

    public void stateTransitionPauseMenu(int state)
    {
        this.m_pauseMenuState = state;
        switch (state)
        {
            case 0:
                this.m_pauseMenu.setItems(ref this.m_pauseMenuItems);
                break;
            case 1:
                this.prepareConfirmBox(61, 59);
                break;
            case 2:
                this.prepareConfirmBox(63, 59);
                break;
            case 3:
                Display display = Display.getDisplay((MIDlet)AppEngine.getMIDlet());
                this.m_engine.getBgMusic().suspend();
                this.m_engine.getMediaPicker().activate(display);
                break;
            case 4:
                this.m_leaderboardsMenu.init();
                break;
            case 5:
                this.m_achievementsMenu.init();
                break;
            case 6:
                this.m_achievementDetailMenu.init();
                break;
        }
    }

    private void showPauseMenu()
    {
        if (this.backPressed)
            return;
        if (this.m_contextMenuActive)
            this.hideContextMenu();
        this.m_pauseMenuActive = true;
        this.stateTransitionPauseMenu(0);
    }

    private void hidePauseMenu()
    {
        this.m_pauseMenuActive = false;
        this.m_engine.setSoftKeys(0, 0);
    }

    private void updatePauseMenu(int timeStep)
    {
        if (this.getSharedMenuState() != -1)
            this.updateSharedMenu(timeStep);
        else if (this.m_pauseMenuState == 3)
        {
            if (Display.getDisplay((MIDlet)AppEngine.getMIDlet()).getCurrent() == this.m_engine.getMediaPicker())
                return;
            this.m_engine.getBgMusic().resume();
            this.stateTransitionPauseMenu(0);
            if (!this.m_pauseMenuMediaPickerInGame)
                return;
            this.hidePauseMenu();
        }
        else if (this.m_pauseMenuState == 4)
            this.m_leaderboardsMenu.update(timeStep);
        else if (this.m_pauseMenuState == 5)
        {
            this.m_achievementsMenu.update(timeStep);
        }
        else
        {
            if (this.m_pauseMenuState != 6)
                return;
            this.m_achievementDetailMenu.update(timeStep);
        }
    }

    private void renderPauseMenu(Graphics g)
    {
        this.m_engine.renderBackgroundDim(g);
        if (this.getSharedMenuState() != -1)
        {
            this.renderSharedMenu(g);
        }
        else
        {
            switch (this.m_pauseMenuState)
            {
                case 0:
                    this.m_pauseMenu.render(g);
                    break;
                case 1:
                case 2:
                    this.drawGenericMessageBox(g);
                    break;
                case 4:
                    this.m_leaderboardsMenu.render(g);
                    break;
                case 5:
                    this.m_achievementsMenu.render(g);
                    break;
                case 6:
                    this.m_achievementDetailMenu.render(g);
                    break;
            }
        }
    }

    private void stateTransitionBuildMode(int state)
    {
        if (this.m_buildModeState == 14 && state == 13)
            SpywareManager.getInstance().trackStoreClose();
        this.m_stateTime = 0;
        SimWorld simWorld = this.m_simWorld;
        switch (state)
        {
            case 0:
                this.stateTransition(6);
                this.setCursorObject((MapObject)null);
                break;
            case 1:
                this.setCursorSelectFlags(4);
                this.setCursorObject((MapObject)null);
                break;
            case 2:
                if (this.m_buildModeState != 7 && this.m_buildModeState != 3 && (this.m_buildModeState != 8 && this.m_buildModeState != 4) && this.m_buildModeState != 6)
                {
                    this.getUIList(8).initList();
                    break;
                }
                break;
            case 3:
                this.prepareMessageBox(1147, 1146);
                break;
            case 4:
                this.setCursorObject((MapObject)null);
                this.setCursorSelectFlags(8);
                break;
            case 5:
                this.prepareCustomConfirmBox(1151, simWorld.getObjectStringId(this.m_buildModeNewType));
                break;
            case 7:
                this.prepareMessageBox(1148, simWorld.getObjectStringId(this.m_buildModeNewType));
                break;
            case 8:
                this.prepareMessageBox(1149, simWorld.getObjectStringId(this.m_buildModeNewType));
                break;
            case 9:
                this.prepareCustomConfirmBox(1152, this.m_buildModeObject.getTypeString());
                break;
            case 10:
                this.prepareCustomConfirmBox(1171, 1170);
                break;
            case 11:
                this.prepareCustomMessageBox(1172, 1170);
                break;
            case 12:
                this.m_buildModeNewType = this.m_buildModeObject.getType();
                this.m_buildModeObject.applyFootprint(false);
                this.m_buildModeObject.hide();
                simWorld.createBuildPoints(this.m_buildModeNewType);
                this.setCursorSelectFlags(8);
                break;
            case 14:
                if (this.m_buildModeState != 2)
                {
                    SpywareManager.getInstance().trackStoreOpen("build mode");
                    break;
                }
                break;
            case 15:
                this.setCursorObject((MapObject)null);
                this.setCursorSelectFlags(0);
                break;
            case 16:
            case 17:
                Room room = simWorld.getRoom(this.m_buildModeRoomId);
                int x = room.getPosX() + (room.getSizeX() >> 1);
                int z = room.getPosZ() + (room.getSizeZ() >> 1);
                this.setCameraLookAtPoint((float)simWorld.coordWorldTileToWorldCenterX(x) * 1.525879E-05f, (float)simWorld.coordWorldTileToWorldCenterZ(z) * 1.525879E-05f, MathExt.clip((float)(300.0 + (double)midp.JMath.max(room.getSizeX(), room.getSizeZ()) * 30.0), 150f, 750f));
                this.getUIList(state == 16 ? 10 : 11).initList(state == 16 ? this.m_simWorld.getUnlockedFloorIndex(this.m_buildModeOldSetting) : this.m_simWorld.getUnlockedWallIndex(this.m_buildModeOldSetting));
                break;
            case 18:
                this.setCameraLookAt(this.m_buildModeObject);
                break;
            case 19:
                this.prepareCustomConfirmBox(1602, 1603);
                break;
            case 20:
                this.prepareCustomConfirmBox(1643, 1644);
                break;
            case 21:
            case 22:
                this.prepareMessageBox(1148, this.m_buildModeState == 21 ? 1603 : 1644);
                break;
        }
        this.m_buildModeState = state;
    }

    private void updateBuildMode(int timeStep)
    {
        if (this.m_showTutorial)
            this.checkTriggers();
        switch (this.m_buildModeState)
        {
            case 1:
            case 4:
            case 12:
            case 15:
                this.updateCamera(timeStep);
                goto case 6;
            case 6:
                this.updateTicker(timeStep);
                this.updateObjectTypes(timeStep, 11);
                if (this.m_buildModeState != 6 || this.m_stateTime <= 1500)
                    break;
                this.stateTransitionBuildMode(2);
                break;
            case 14:
                if (this.m_buildModeCatChooseTimer <= 0)
                    break;
                this.m_buildModeCatChooseTimer -= timeStep;
                if (this.m_buildModeCatChooseTimer >= 0)
                    break;
                this.stateTransitionBuildMode(2);
                break;
            case 16:
            case 17:
            case 18:
                this.updateCamera(timeStep);
                break;
        }
    }

    private void renderBuildMode(Graphics g)
    {
        AppEngine engine = this.m_engine;
        switch (this.m_buildModeState)
        {
            case 1:
            case 4:
            case 6:
            case 12:
            case 15:
                this.renderMain(g);
                break;
            case 2:
                this.renderBuildModeSelect(g);
                this.renderShoppingMoney(g);
                break;
            case 3:
            case 7:
            case 8:
                this.renderBuildModeSelect(g);
                engine.renderBackgroundDim(g);
                this.drawGenericMessageBox(g);
                break;
            case 5:
            case 9:
                this.renderBuildModeTradeConfirm(g);
                this.renderShoppingMoney(g);
                break;
            case 10:
            case 11:
                this.renderBuildModeUpgradeConfirm(g);
                break;
            case 13:
                this.renderBuildModeChooseAction(g);
                break;
            case 14:
                this.renderBuildModeChooseCat(g);
                break;
            case 16:
            case 17:
            case 18:
                this.renderBuildModeChangeFloor(g);
                break;
            case 19:
            case 20:
                this.renderBuildModeTradeConfirm(g);
                break;
            case 21:
            case 22:
                this.renderMain(g);
                engine.renderBackgroundDim(g);
                this.drawGenericMessageBox(g);
                break;
        }
    }

    private void renderBuildModeChooseAction(Graphics g)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        this.renderMain(g);
        engine.renderBackgroundDim(g);
        if (this.m_tutorialMessageActive)
            return;
        bool flag = this.m_simWorld.getHouseUpgradeCost() > 0;
        int num1 = 320 + (flag ? 70 : 0);
        int num2 = engine.getWidth() - num1 >> 1;
        int num3 = engine.getHeight() - 240 >> 1;
        animationManager2D.submitAnimGrid(87, 88, 89, 90, 91, 92, 93, 94, 95, (float)num2, (float)num3, (float)num1, 240f);
        int x1 = num2 + 9;
        int y1 = num3 + 22;
        UIButton uiButton = this.getUIButton(4);
        animationManager2D.submitAnim(330, (float)x1, (float)y1);
        uiButton.submit(ref animationManager2D, x1, y1);
        int num4 = num2 + (num1 >> 1);
        int num5 = num3 + 70;
        int num6 = (int)((double)(int)((double)num1 * 0.899999976158142) / (double)animationManager2D.getAnimWidth((int)sbyte.MaxValue));
        animationManager2D.submitAnim((int)sbyte.MaxValue, (float)num4, (float)num5, 1f, (float)num6);
        int num7 = num2 + (num1 >> 1) + 45;
        int num8 = num7 - 90;
        int x2 = num7 + 90;
        int num9 = num7 + num8 >> 1;
        int num10 = num7 + x2 >> 1;
        int y2 = num3 + 120;
        int x3 = flag ? num8 : num9;
        int x4 = flag ? num7 : num10;
        int x5 = x3 - 90;
        this.getUIButton(65536).submit(ref animationManager2D, x5, y2);
        this.getUIButton(131072).submit(ref animationManager2D, x3, y2);
        this.getUIButton(32768).submit(ref animationManager2D, x4, y2);
        if (flag)
            this.getUIButton(262144).submit(ref animationManager2D, x2, y2);
        animationManager2D.flushAnims(g);
        int x6 = num4;
        int y3 = num3 + 40;
        g.Begin();
        textManager.drawString(g, 1131, 6, x6, y3, 18);
        int y4 = y2 + 70;
        int lineWidth = 81;
        textManager.drawWrappedStringChunk(g, 0, 1132, 3, lineWidth, x5, y4, 18);
        textManager.drawWrappedStringChunk(g, 1, 1134, 3, lineWidth, x3, y4, 18);
        textManager.drawWrappedStringChunk(g, 2, 1133, 3, lineWidth, x4, y4, 18);
        if (flag)
            textManager.drawWrappedStringChunk(g, 3, 1135, 3, lineWidth, x2, y4, 18);
        g.End();
    }

    public int getCurFurnitureCategory()
    {
        return this.m_buildModeChosenCat;
    }

    private void renderBuildModeChooseCat(Graphics g)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        int width = engine.getWidth();
        int height = engine.getHeight();
        this.renderMain(g);
        engine.renderBackgroundDim(g);
        int num1 = width - 10;
        int num2 = height - 10;
        animationManager2D.submitAnimGrid(321, 322, 323, 324, 325, 326, 327, 328, 329, 5f, 5f, (float)num1, (float)num2);
        int num3 = num1 - 144;
        int animHeight = (int)animationManager2D.getAnimHeight(363);
        animationManager2D.submitAnimHBar(362, 363, 364, (float)(77 + (num3 >> 1)), (float)(25 + (animHeight >> 1)), (float)num3);
        UIButton uiButton = this.getUIButton(2);
        animationManager2D.submitAnim(330, 32f, 34f);
        uiButton.submit(ref animationManager2D, 32, 34);
        int num4 = 25 + animHeight;
        int num5 = num1 - 144;
        int num6 = height - num4 - 5 - 22;
        animationManager2D.submitAnimGrid(331, 332, 333, 334, 335, 336, 337, 338, 339, 77f, (float)num4, (float)num5, (float)num6);
        int font = 3;
        int lineHeight = textManager.getLineHeight(font);
        int num7 = (int)((double)animationManager2D.getAnimWidth(309) + 15.0);
        int animWidth = (int)animationManager2D.getAnimWidth(309);
        this.BUILD_CAT_BUTTON_WIDTH = num7 + 22;
        this.BUILD_CAT_BUTTON_HEIGHT = animWidth + lineHeight + 20;
        this.BUILD_CAT_BUTTON_SPACING_X = 2;
        this.BUILD_CAT_BUTTON_SPACING_Y = 5;
        this.BUILD_CAT_BUTTONS_X = 86;
        this.BUILD_CAT_BUTTONS_Y = num4 + 9;
        int buildCatButtonsX1 = this.BUILD_CAT_BUTTONS_X;
        int num8 = this.BUILD_CAT_BUTTONS_Y;
        for (int category = 0; category < 6; ++category)
        {
            if (this.m_buildModeChosenCat == category && this.m_buildModeCatChooseTimer % 300 > 150)
                animationManager2D.submitAnimGrid(349, 350, 351, 352, 353, 354, 355, 356, 357, (float)buildCatButtonsX1, (float)num8, (float)this.BUILD_CAT_BUTTON_WIDTH, (float)this.BUILD_CAT_BUTTON_HEIGHT);
            else
                animationManager2D.submitAnimGrid(340, 341, 342, 343, 344, 345, 346, 347, 348, (float)buildCatButtonsX1, (float)num8, (float)this.BUILD_CAT_BUTTON_WIDTH, (float)this.BUILD_CAT_BUTTON_HEIGHT);
            int categoryIcon = this.m_simWorld.getCategoryIcon(category);
            animationManager2D.submitAnim(categoryIcon, (float)(buildCatButtonsX1 + 11 + (num7 >> 1)), (float)(num8 + 10 + (animWidth >> 1)));
            if (category == 2)
            {
                buildCatButtonsX1 = this.BUILD_CAT_BUTTONS_X;
                num8 = this.BUILD_CAT_BUTTONS_Y + this.BUILD_CAT_BUTTON_HEIGHT + this.BUILD_CAT_BUTTON_SPACING_Y;
            }
            else
                buildCatButtonsX1 += this.BUILD_CAT_BUTTON_WIDTH + this.BUILD_CAT_BUTTON_SPACING_X;
        }
        animationManager2D.flushAnims(g);
        int buildCatButtonsX2 = this.BUILD_CAT_BUTTONS_X;
        int num9 = this.BUILD_CAT_BUTTONS_Y;
        g.Begin();
        for (int category = 0; category < 6; ++category)
        {
            int x = buildCatButtonsX2 + (this.BUILD_CAT_BUTTON_WIDTH >> 1);
            int y = num9 + this.BUILD_CAT_BUTTON_HEIGHT - 5;
            int categoryString = this.m_simWorld.getCategoryString(category);
            if (textManager.getStringWidth(categoryString, font) > this.BUILD_CAT_BUTTON_WIDTH)
            {
                textManager.wrapString(categoryString, font, this.BUILD_CAT_BUTTON_WIDTH);
                textManager.drawWrappedString(g, font, x, y, 20);
            }
            else
                textManager.drawString(g, categoryString, font, x, y, 20);
            if (category == 2)
            {
                buildCatButtonsX2 = this.BUILD_CAT_BUTTONS_X;
                num9 = this.BUILD_CAT_BUTTONS_Y + this.BUILD_CAT_BUTTON_HEIGHT + this.BUILD_CAT_BUTTON_SPACING_Y;
            }
            else
                buildCatButtonsX2 += this.BUILD_CAT_BUTTON_WIDTH + this.BUILD_CAT_BUTTON_SPACING_X;
        }
        int x1 = 77 + (num3 >> 1);
        int y1 = 25 + (animHeight >> 1) - 4;
        textManager.drawString(g, 1145, 6, x1, y1, 18);
        g.End();
    }

    private void renderBuildModeSelect(Graphics g)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        this.renderMain(g);
        engine.renderBackgroundDim(g);
        int num1 = engine.getWidth() - 20;
        int num2 = engine.getHeight() - 20;
        int num3 = engine.getWidth() - num1 >> 1;
        int num4 = engine.getHeight() - num2 >> 1;
        animationManager2D.submitAnimGrid(321, 322, 323, 324, 325, 326, 327, 328, 329, (float)num3, (float)num4, (float)num1, (float)num2);
        int x1 = num3 + 32;
        int y1 = num4 + 32;
        UIButton uiButton = this.getUIButton(2);
        animationManager2D.submitAnim(330, (float)x1, (float)y1);
        uiButton.submit(ref animationManager2D, x1, y1);
        int x2 = num3 + (num1 >> 1);
        int num5 = num4 + 40;
        int num6 = num1 - 120;
        animationManager2D.submitAnimHBar(362, 363, 364, (float)x2, (float)num5, (float)num6);
        int num7 = num6 - 10;
        int num8 = num2 - 85;
        int num9 = x2 - (num7 >> 1);
        int num10 = num5 + 18;
        animationManager2D.submitAnimGrid(331, 332, 333, 334, 335, 336, 337, 338, 339, (float)num9, (float)num10, (float)num7, (float)num8);
        int w = num7 - 20;
        int h = num8 - 20;
        int x3 = num9 + 10;
        int y2 = num10 + 10;
        UIList uiList = this.getUIList(8);
        if (uiList.itemsLeft())
            animationManager2D.submitAnim(178, (float)(x3 - 20), (float)(y2 + (h >> 1)));
        if (uiList.itemsRight())
            animationManager2D.submitAnim(179, (float)(x3 + w + 20), (float)(y2 + (h >> 1)));
        animationManager2D.flushAnims(g);
        uiList.setup(x3, y2, w, h);
        uiList.render(g);
        g.Begin();
        if (this.m_buildModeState == 2)
        {
            int y3 = num5 - 5;
            int categoryString = this.m_simWorld.getCategoryString(this.m_buildModeChosenCat);
            textManager.drawString(g, categoryString, 6, x2, y3, 18);
        }
        g.End();
    }

    private void processInputBuildModePlaceObject(bool isExotic)
    {
        MapObject mapObject = this.getCursorObject();
        if (mapObject == null)
            return;
        SimData simData = this.m_simData;
        SimWorld simWorld = this.m_simWorld;
        int facingDir = mapObject.getFacingDir();
        if (mapObject.getType() == 15)
            mapObject = mapObject.getBuildPointSelector();
        int id = simWorld.objectBuy(this.m_buildModeNewType, mapObject.getPosX(), mapObject.getPosZ(), facingDir);
        this.playSound(64);
        MapObject @object = this.createObject(this.m_buildModeNewType, mapObject.getPosX(), mapObject.getPosY(), mapObject.getPosZ(), facingDir, id);
        this.removeBuildPoints();
        this.setCursorObject(@object);
        simData.registerBuyFurninture(this.m_buildModeNewType);
        if (isExotic)
            return;
        int objectBuyPrice = this.m_simWorld.getObjectBuyPrice(this.m_buildModeNewType);
        simData.adjustMoney(-objectBuyPrice);
        int num1 = (@object.getFootprintX() - 1) * 2097152 >> 1;
        int num2 = (@object.getFootprintZ() - 1) * 2097152 >> 1;
        this.createEffectMoney(@object.getPosX() - num1, @object.getPosZ() - num2, -objectBuyPrice);
        this.stateTransitionBuildMode(6);
    }

    private void renderBuildModeTradeConfirm(Graphics g)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        int num1 = -1;
        int num2 = -1;
        int num3 = 0;
        switch (this.m_buildModeState)
        {
            case 5:
                int buildModeNewType = this.m_buildModeNewType;
                num2 = 1076;
                num3 = this.m_simWorld.getObjectBuyPrice(buildModeNewType);
                num1 = this.m_simWorld.getObjectStringId(buildModeNewType);
                break;
            case 9:
                int type = this.m_buildModeObject.getType();
                num2 = 1077;
                num3 = this.m_simWorld.getObjectSellPrice(type);
                num1 = this.m_simWorld.getObjectStringId(type);
                break;
            case 19:
                num2 = 1076;
                num3 = 50;
                num1 = 1603;
                break;
            case 20:
                num2 = 1076;
                num3 = 50;
                num1 = 1644;
                break;
        }
        this.setUIPlaceholderString(1, num1);
        this.setUIPlaceholderString(2, num2);
        StringBuffer str = textManager.clearStringBuffer();
        textManager.appendMoneyToBuffer(num3);
        textManager.dynamicString(-9, str);
        this.setUIPlaceholderString(3, -9);
        this.renderMain(g);
        engine.renderBackgroundDim(g);
        this.drawCustomMessageBox(g, 2);
    }

    private void renderBuildModeUpgradeConfirm(Graphics g)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        this.setUIPlaceholderString(1, 1170);
        this.setUIPlaceholderString(2, 1175);
        StringBuffer str = textManager.clearStringBuffer();
        textManager.appendMoneyToBuffer(this.m_simWorld.getHouseUpgradeCost());
        textManager.dynamicString(-9, str);
        this.setUIPlaceholderString(3, -9);
        this.renderMain(g);
        engine.renderBackgroundDim(g);
        this.drawCustomMessageBox(g, 2);
    }

    private void renderBuildModeChangeFloor(Graphics g)
    {
        AppEngine engine = this.m_engine;
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        this.renderMain(g);
        float num1 = (float)((double)animationManager2D.getAnimHeight(399) * 2.0 * 1.5);
        float num2 = (float)((double)engine.getHeight() - (double)num1 * 0.5 - 5.0);
        float y1 = num2 - num1 * 0.25f;
        float y2 = num2 + num1 * 0.25f;
        float num3 = (float)engine.getWidth() - 40f;
        float x1 = (float)(20.0 + (double)num3 * 0.25);
        float x2 = (float)(20.0 + (double)num3 * 0.75);
        int x3 = engine.getWidth() - 356 >> 1;
        int y3 = (int)num2 - 27;
        int num4 = 48;
        int num5 = num4;
        int num6 = engine.getWidth() - num4;
        int num7 = (int)num2;
        animationManager2D.submitAnimHBar(397, 398, 399, x1, y1, num3 * 0.5f, 1f, 1.5f);
        animationManager2D.submitAnimHBar(397, 398, 399, x1, y2, num3 * 0.5f, 1f, -1.5f);
        animationManager2D.submitAnimHBarXFlipped(399, 398, 397, x2, y1, num3 * 0.5f, 1f, 1.5f);
        animationManager2D.submitAnimHBarXFlipped(399, 398, 397, x2, y2, num3 * 0.5f, 1f, -1.5f);
        animationManager2D.submitAnim(178, (float)num5, (float)num7);
        animationManager2D.submitAnim(179, (float)num6, (float)num7);
        animationManager2D.flushAnims(g);
        int listId = -1;
        switch (this.m_buildModeState)
        {
            case 16:
                listId = 10;
                break;
            case 17:
                listId = 11;
                break;
        }
        UIList uiList = this.getUIList(listId);
        uiList.setup(x3, y3, 356, 55);
        uiList.render(g);
    }

    public int getBuildModeOldSetting()
    {
        return this.m_buildModeOldSetting;
    }

    public UIInfoScreen getInfoScreen()
    {
        return this.m_infoScreen;
    }

    public void showInfoScreen(int screen)
    {
        this.stateTransition(8);
        this.m_infoScreen.init(screen);
        if (screen != 0)
            return;
        this.m_infoScreen.setSubType(10, this.getSimContext());
    }

    public void hideInfoScreen()
    {
        this.stateTransition(6);
    }

    private void renderInfoScreen(Graphics g)
    {
        this.renderMain(g);
        this.m_engine.renderBackgroundDim(g);
        this.m_infoScreen.render(g);
    }

    public int drawUICurrentDream(Graphics g, int x, int y, int w, int h)
    {
        if (g != null)
        {
            AnimationManager2D animationManager2D = this.m_engine.getAnimationManager2D();
            int num1 = x + 10;
            int num2 = 14;
            int lineWidth = w - 30;
            int x1 = x + w - lineWidth;
            int num3 = 14;
            SimData simData = this.m_simData;
            int dream = simData.getDream();
            int dreamDescString = simData.getDreamDescString(dream);
            int animId = 40;
            g.Begin();
            this.m_engine.getTextManager().drawWrappedStringChunk(g, 19, dreamDescString, 3, lineWidth, x1, y + num3, 10);
            g.End();
            animationManager2D.submitAnim(animId, (float)num1, (float)(y + num2));
            animationManager2D.flushAnims(g);
        }
        return 31;
    }

    public void reloadPlayerCar()
    {
        this.getPlayerSim().reloadCar();
    }

    public void showJobOffer(int career, int level, bool jobSearch)
    {
        this.hideContextMenu();
        this.m_jobOfferCareer = career;
        this.m_jobOfferLevel = level;
        if (career == -1)
        {
            this.prepareMessageBox(947, 948);
        }
        else
        {
            if (!jobSearch && !this.m_simData.careerRequirementsMet(career, level))
            {
                this.showJobRaiseFail(career, level);
                return;
            }
            int simCareer = this.m_simData.getSimCareer(0);
            this.prepareCustomConfirmBox(simCareer == -1 ? 951 : (simCareer == career ? 954 : 952), career == simCareer ? 950 : 949);
        }
        this.stateTransition(10);
    }

    private void renderJobOffer(Graphics g)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        int width = engine.getWidth();
        int height = engine.getHeight();
        this.m_simWorld.renderWorld(g);
        engine.renderBackgroundDim(g);
        int jobOfferCareer = this.m_jobOfferCareer;
        if (jobOfferCareer == -1)
        {
            this.drawGenericMessageBox(g);
        }
        else
        {
            int num1 = height - 290 >> 1;
            int num2 = (width - 384 >> 1) + 7;
            int num3 = engine.getHalfWidth() + 7;
            int halfHeight = engine.getHalfHeight();
            int num4 = num1 + 72;
            int num5 = num2 + 22;
            int lineHeight = textManager.getLineHeight(3);
            animationManager2D.submitAnimVBar(306, 307, 308, (float)num3, (float)halfHeight, 290f);
            int num6 = num5;
            int num7 = num4;
            int x1 = num6 + 55;
            int num8 = 5 * lineHeight;
            int num9 = num7 + (90 - num8 >> 1);
            animationManager2D.submitAnimGrid(233, 234, 235, 236, 237, 238, 239, 240, 241, (float)num6, (float)num7, 110f, 90f);
            int y1 = num1 + 290 - 32;
            int x2 = engine.getHalfWidth() - 48;
            int x3 = engine.getHalfWidth() + 48;
            UIButton uiButton1 = this.getUIButton(64);
            UIButton uiButton2 = this.getUIButton(32);
            uiButton1.submit(ref animationManager2D, x2, y1);
            uiButton2.submit(ref animationManager2D, x3, y1);
            int careerIcon = this.getSimData().getCareerIcon(jobOfferCareer);
            int num10 = num1 + 28;
            int num11 = num2 + 384 - 34;
            animationManager2D.submitAnim(careerIcon, (float)num11, (float)num10);
            animationManager2D.flushAnims(g);
            int jobOfferLevel = this.m_jobOfferLevel;
            int careerLevelFlags = this.m_simData.getCareerLevelFlags(jobOfferCareer, jobOfferLevel);
            int y2 = num9;
            StringBuffer str = textManager.clearStringBuffer();
            int num12 = 0;
            for (int index = 0; index < SimData.DAY_FLAGS.Length; ++index)
            {
                if ((careerLevelFlags & SimData.DAY_FLAGS[index]) != 0)
                {
                    if (num12 > 0)
                        textManager.appendStringToBuffer(" ");
                    textManager.appendStringIdToBuffer(SimData.DAY_STRINGS[index]);
                    ++num12;
                }
            }
            textManager.dynamicString(-11, str);
            g.Begin();
            textManager.drawString(g, 981, 3, x1, y2, 17);
            int y3 = y2 + lineHeight;
            textManager.drawWrappedStringChunk(g, 0, -11, 3, 100, x1, y3, 17);
            int y4 = y3 + 2 * lineHeight;
            StringBuffer strBuffer1 = textManager.clearStringBuffer();
            int careerLevelHoursStart = this.m_simData.getCareerLevelHoursStart(jobOfferCareer, jobOfferLevel);
            textManager.appendTimeToBuffer24Hour(careerLevelHoursStart);
            textManager.appendStringIdToBuffer(991);
            int careerLevelHoursEnd = this.m_simData.getCareerLevelHoursEnd(jobOfferCareer, jobOfferLevel);
            textManager.appendTimeToBuffer24Hour(careerLevelHoursEnd);
            textManager.drawString(g, 990, 3, x1, y4, 17);
            int y5 = y4 + lineHeight;
            textManager.drawString(g, strBuffer1, 3, x1, y5, 17);
            int y6 = num1 + 72 - 25;
            int x4 = num5 + 162;
            textManager.drawString(g, 949, 6, x4, y6, 20);
            int y7 = num4 + 90 + 42;
            int x5 = num5 + 162;
            textManager.drawString(g, 951, 4, x5, y7, 17);
            int num13 = 7 * lineHeight;
            int x6 = num6 + 110 + 15;
            int x7 = num5 + 325 - 10;
            int num14 = num4 + (90 - num13 >> 1);
            int num15 = lineHeight;
            int y8 = num14;
            textManager.drawString(g, 975, 3, x6, y8, 9);
            textManager.drawWrappedStringChunk(g, 0, this.m_simData.getCareerDescString(jobOfferCareer), 3, 130, x7, y8, 33);
            int y9 = y8 + num15 * 2;
            textManager.drawString(g, 976, 3, x6, y9, 9);
            textManager.drawWrappedStringChunk(g, 0, this.m_simData.getCareerLevelDescString(jobOfferCareer, jobOfferLevel), 3, 130, x7, y9, 33);
            int y10 = y9 + num15 * 2;
            int careerLevelIncome = this.m_simData.getCareerLevelIncome(jobOfferCareer, jobOfferLevel);
            StringBuffer strBuffer2 = textManager.clearStringBuffer();
            textManager.appendMoneyToBuffer(careerLevelIncome);
            textManager.drawString(g, 977, 3, x6, y10, 9);
            textManager.drawString(g, strBuffer2, 3, x7, y10, 33);
            int y11 = y10 + num15;
            int careerRabbitHole = this.m_simData.getCareerRabbitHole(jobOfferCareer);
            textManager.drawString(g, 979, 3, x6, y11, 9);
            textManager.drawString(g, this.m_simWorld.getObjectStringId(careerRabbitHole), 3, x7, y11, 33);
            int y12 = y11 + num15;
            int careerBoss = this.m_simData.getCareerBoss(jobOfferCareer);
            textManager.drawString(g, 980, 3, x6, y12, 9);
            textManager.drawString(g, this.m_simData.getSimName(careerBoss), 3, x7, y12, 33);
            g.End();
        }
    }

    public void finishWork()
    {
        if (this.m_engine.randPercent() < 5)
        {
            SpywareManager.getInstance().trackEndGameDeath("career");
            this.killPlayer(this.m_simData.getCareerDeathString());
        }
        else
        {
            this.playSound(83);
            this.stateTransition(11);
        }
    }

    private void renderPay(Graphics g)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        this.setUIPlaceholderString(1, 1069);
        this.setUIPlaceholderString(2, 977);
        StringBuffer str = textManager.clearStringBuffer();
        textManager.appendMoneyToBuffer(this.m_payIncome);
        textManager.dynamicString(-9, str);
        this.setUIPlaceholderString(3, -9);
        this.renderMain(g);
        engine.renderBackgroundDim(g);
        this.drawCustomMessageBox(g, 2);
    }

    public void showJobRaiseFail(int career, int level)
    {
        SimData simData = this.m_simData;
        this.m_jobOfferCareer = career;
        this.m_jobOfferLevel = level;
        int simName = simData.getSimName(simData.getCareerBoss(career));
        this.prepareCustomMessageBox(simData.getCareerFailString(career), simName);
        this.stateTransition(12);
    }

    private void renderRaiseFailure(Graphics g)
    {
        SimData simData = this.m_simData;
        TextManager textManager = this.m_engine.getTextManager();
        int jobOfferCareer = this.m_jobOfferCareer;
        int jobOfferLevel = this.m_jobOfferLevel;
        sbyte[] levelRequirements = simData.getCareerLevelRequirements(jobOfferCareer, jobOfferLevel);
        int requirement1 = (int)levelRequirements[0];
        int num1 = (int)levelRequirements[1];
        int requirement2 = (int)levelRequirements[2];
        int num2 = (int)levelRequirements[3];
        int panelId = 0;
        if (requirement1 != -1)
        {
            panelId = 2;
            this.setUIPlaceholderString(2, simData.getRequimentName(requirement1));
            StringBuffer str = textManager.clearStringBuffer();
            textManager.appendIntToBuffer(simData.getRequirementValue(requirement1));
            textManager.appendStringIdToBuffer(11);
            textManager.appendIntToBuffer(num1);
            textManager.dynamicString(-9, str);
            this.setUIPlaceholderString(3, -9);
        }
        if (requirement2 != -1)
        {
            panelId = 3;
            this.setUIPlaceholderString(4, simData.getRequimentName(requirement2));
            StringBuffer str = textManager.clearStringBuffer();
            textManager.appendIntToBuffer(simData.getRequirementValue(requirement2));
            textManager.appendStringIdToBuffer(11);
            textManager.appendIntToBuffer(num2);
            textManager.dynamicString(-8, str);
            this.setUIPlaceholderString(5, -8);
        }
        this.renderMain(g);
        this.m_engine.renderBackgroundDim(g);
        this.drawCustomMessageBox(g, panelId);
    }

    public void showQuitJob()
    {
        this.m_quitJobConfirmed = false;
        SimData simData = this.m_simData;
        this.prepareConfirmBox(1071, simData.getCareerLevelDescString(simData.getSimCareer(0), simData.getSimCareerLevel(0)));
        this.stateTransition(13);
    }

    private void renderQuitJob(Graphics g)
    {
        this.renderMain(g);
        this.m_engine.renderBackgroundDim(g);
        this.drawGenericMessageBox(g);
    }

    public void showNewDream()
    {
        this.m_showNewDream = true;
        this.m_dreamAnimTimers[4].startTimer(3, 16);
    }

    public void showExpiredDream(int dream)
    {
        this.showTickerMessage(797, this.m_simData.getDreamDescString(dream));
        this.m_dreamAnimTimers[4].startTimer(5, 16);
    }

    public void showNewDreamMessage()
    {
        this.m_engine.vibrate();
        if (this.m_simData.isDreamToPromisePossible())
            this.prepareCustomConfirmBox(801, 796);
        else
            this.prepareCustomMessageBox(802, 796);
        this.stateTransition(14);
    }

    private void renderNewDream(Graphics g)
    {
        this.renderMain(g);
        this.m_engine.renderBackgroundDim(g);
        this.drawCustomMessageBox(g, 4);
    }

    public void showNewPromise(int dreamSlot)
    {
        this.m_dreamAnimTimers[4].setAnimating(false);
        this.m_dreamAnimTimers[dreamSlot].startTimer(3, 16);
    }

    public void showGoalCompleted(int dream, int dreamSlot)
    {
        this.showTickerMessage(798, this.m_simData.getDreamDescString(dream));
        this.getPlayerSim().queueSimAction(12, (MapObject)null, 0, 0);
        if (dreamSlot != -1)
            this.m_dreamAnimTimers[dreamSlot].startTimer(4, 16);
        this.playSound(23);
    }

    public void unlockBonus()
    {
        this.m_showBonusUnlocked = true;
    }

    public void showDoorKnock(int simId)
    {
        this.showTickerMessage(this.m_simData.getSimName(simId), 794);
    }

    public void showGetItem(int item, int qty, int title, int message)
    {
        this.m_showGetItem = item;
        this.m_showGetItemQty = qty;
        this.m_showGetItemTitle = title;
        if (this.m_simData.getInventoryCount(item) == this.m_simWorld.getItemMaxInventory(item))
            message = 1084;
        this.m_showGetItemMessage = message;
    }

    private void renderShowGetItem(Graphics g)
    {
        this.renderMain(g);
        this.m_engine.renderBackgroundDim(g);
        this.drawCustomMessageBox(g, 5);
    }

    public int drawUIGetItem(Graphics g, int x, int y, int w, int h)
    {
        if (g != null)
        {
            SimWorld simWorld = this.m_simWorld;
            AppEngine engine = this.m_engine;
            TextManager textManager = engine.getTextManager();
            int showGetItem = this.m_showGetItem;
            int num1 = x + 3 + 8;
            int num2 = y + 20;
            int x1 = x + 3 + 16 + 3 + 3;
            int y1 = y + 20;
            int x2 = x + w - 3;
            int itemIcon = simWorld.getItemIcon(showGetItem);
            AnimationManager2D animationManager2D = engine.getAnimationManager2D();
            animationManager2D.submitAnim(itemIcon, (float)num1, (float)num2);
            animationManager2D.flushAnims(g);
            g.Begin();
            StringBuffer strBuffer1 = textManager.clearStringBuffer();
            if (this.m_showGetItemQty != 1)
            {
                textManager.appendIntToBuffer(this.m_showGetItemQty);
                textManager.appendStringIdToBuffer(1085);
            }
            textManager.appendStringIdToBuffer(simWorld.getItemDescString(showGetItem));
            textManager.drawString(g, strBuffer1, 3, x1, y1, 10);
            StringBuffer strBuffer2 = textManager.clearStringBuffer();
            textManager.appendIntToBuffer(this.m_simData.getInventoryCount(showGetItem));
            textManager.appendStringIdToBuffer(11);
            textManager.appendIntToBuffer(simWorld.getItemMaxInventory(showGetItem));
            textManager.drawString(g, strBuffer2, 3, x2, y1, 34);
            g.End();
        }
        return 40;
    }

    public bool isPlayerInactive()
    {
        return this.m_simInactivityTimer > 20000;
    }

    private void resetPlayerInactivity()
    {
        this.m_simInactivityTimer = 0;
        this.getPlayerSim().clearNeedFlags();
    }

    private void updateEventsHouse(int timeStep)
    {
        AppEngine engine = this.m_engine;
        SimData simData = this.m_simData;
        this.m_simAIEventTimer += timeStep;
        int num = 3000;
        if (simData.getFastforward())
            num >>= 1;
        if (this.m_simAIEventTimer > num)
        {
            this.m_simAIEventTimer = 0;
            int houseId = this.m_simWorld.getHouseId();
            int simCount = simData.getSimCount();
            for (int index = 1; index < simCount; ++index)
            {
                int timeFlags = simData.getTimeFlags(index);
                MapObjectSim sim = this.findSim(index);
                if (sim != null)
                {
                    if ((timeFlags & 7) != 0)
                        sim.setNeedFlag(2);
                    if ((timeFlags & 16) != 0)
                    {
                        if (houseId == simData.getSimHome(index))
                            sim.setNeedFlag(8);
                        else
                            sim.setNeedFlag(512);
                    }
                }
                else if ((timeFlags & 8) != 0 && houseId == simData.getSimHome(index) && this.simSpaceAvailable())
                {
                    MapObject randomObjectByType = this.findRandomObjectByType(4);
                    AppEngine.ASSERT(randomObjectByType != null, "no town object!");
                    ((MapObjectSim)this.createObjectOnObjectInterestPoint(1, randomObjectByType, index)).setNeedFlag((engine.randPercent() < 50 ? 4 : 0) | (engine.randPercent() < 50 ? 16 : 0) | (engine.randPercent() < 50 ? 128 : 0) | (engine.randPercent() < 50 ? 64 : 0) | (engine.randPercent() < 50 ? 32 : 0));
                }
            }
            MapObjectSim[] simObjects = this.getSimObjects();
            for (int index1 = 0; index1 < simObjects.Length; ++index1)
            {
                int index2 = engine.rand(0, simObjects.Length - 1);
                MapObjectSim mapObjectSim = simObjects[index2];
                if (mapObjectSim.isIdle() && mapObjectSim.occupiedIsEmpty() && mapObjectSim.getType() != 0)
                {
                    int flag = (engine.randPercent() < 50 ? 4 : 0) | (engine.randPercent() < 25 ? 16 : 0) | (engine.randPercent() < 50 ? 128 : 0) | (engine.randPercent() < 25 ? 32 : 0) | (engine.randPercent() < 60 ? 64 : 0);
                    if (houseId != simData.getSimHome(mapObjectSim.getId()))
                        flag &= -37;
                    mapObjectSim.setNeedFlag(flag);
                }
            }
        }
        MapObjectSim playerSim = this.getPlayerSim();
        if (engine.getAutonomityEnabled())
        {
            if (this.isPlayerInactive())
            {
                if (!playerSim.isIdle())
                    return;
                int playerNeedFlags = simData.getPlayerNeedFlags();
                if (this.m_simWorld.getHouseId() != 0 && !simData.getSimCurRelStateFlags(0, 1))
                    playerNeedFlags |= 64;
                playerSim.setNeedFlag(playerNeedFlags);
            }
            else
                this.m_simInactivityTimer += timeStep;
        }
        else
            playerSim.clearNeedFlags();
    }

    private void updateEventsZoomMode(int timeStep)
    {
        AppEngine engine = this.m_engine;
        SimData simData = this.m_simData;
        this.m_simAIEventTimer += timeStep;
        int num1 = 5000;
        if (simData.getFastforward())
            num1 >>= 1;
        if (this.m_simAIEventTimer <= num1)
            return;
        this.m_simAIEventTimer = 0;
        MapObjectSim[] simObjects = this.getSimObjects();
        int num2 = 50;
        if (simObjects.Length >= 2)
            num2 = 5;
        bool flag = false;
        int simCount = simData.getSimCount();
        int num3 = 4;
        for (int index = 0; index < num3; ++index)
        {
            int num4 = engine.rand(1, simCount - 1);
            MapObjectSim sim = this.findSim(num4);
            int timeFlags = simData.getTimeFlags(num4);
            if (sim != null)
            {
                if ((timeFlags & 7) != 0)
                    sim.setNeedFlag(2);
                if ((timeFlags & 16) != 0)
                    sim.setNeedFlag(512);
            }
            else if (engine.getNextZoomMapId() != 183 && (timeFlags & 8) != 0 && ((timeFlags & 16) == 0 && this.simSpaceAvailable()) && !flag)
            {
                flag = true;
                if (engine.randPercent() < num2)
                {
                    MapObject randomObjectByType = this.findRandomObjectByType(4);
                    AppEngine.ASSERT(randomObjectByType != null, "no town object!");
                    ((MapObjectSim)this.createObjectOnObjectInterestPoint(1, randomObjectByType, num4)).setNeedFlag(64);
                }
            }
        }
        for (int index = 0; index < simObjects.Length; ++index)
        {
            MapObjectSim mapObjectSim = simObjects[index];
            if (mapObjectSim.getId() != 0)
                mapObjectSim.setNeedFlag(64);
        }
    }

    private void updateEventsMapMode(int timeStep)
    {
        this.m_simAIEventTimer += timeStep;
        if (this.m_simAIEventTimer <= 5000)
            return;
        this.m_simAIEventTimer = 0;
        SimData simData = this.m_simData;
        SimWorld simWorld = this.m_simWorld;
        int num = this.m_engine.rand(1, simData.getSimCount() - 1);
        MapObjectSim mapObjectSim = this.findSim(num);
        if (mapObjectSim == null)
        {
            int simHome = simData.getSimHome(num);
            mapObjectSim = (MapObjectSim)this.createObjectOnObjectInterestPoint(1, this.findRandomObjectByType(simWorld.getHouseMacroObject(simHome)), num);
        }
        if (!mapObjectSim.isIdle())
            return;
        MapObject randomMapDestination = this.findRandomMapDestination();
        mapObjectSim.beginSimAction(111, randomMapDestination);
    }

    private void updateAmbientSounds(int timeStep, int rate, short[] soundList)
    {
        this.m_ambientEventTimer += timeStep;
        if (this.m_ambientEventTimer <= rate)
            return;
        this.m_ambientEventTimer = 0;
        int index = this.m_engine.rand(0, soundList.Length - 1);
        this.m_engine.getSoundManager().playEvent((int)soundList[index]);
    }

    private MapObject findRandomMapDestination()
    {
        MapObject[] objects = this.getObjects();
        AppEngine.ASSERT(objects.Length <= 257, "LGC isn't big enough for destination list");
        int index1 = this.m_engine.rand(0, objects.Length - 1);
        for (int index2 = 0; index2 < objects.Length; ++index2)
        {
            MapObject mapObject = objects[index1];
            if (mapObject.getFlag(1024))
                return mapObject;
            do
            {
                index1 = (1543 * index1 + 3571) % 257;
            }
            while (index1 >= objects.Length);
        }
        return (MapObject)null;
    }

    public void putSimInBed(MapObjectSim sim)
    {
        MapObject[] objects = this.getObjects();
        MapObject bed = (MapObject)null;
        MapObject mapObject = (MapObject)null;
        for (int index = 0; index < objects.Length; ++index)
        {
            MapObject target = objects[index];
            if (target.getParentType() == 6)
            {
                if (sim.setOccupied(target))
                {
                    bed = target;
                    break;
                }
            }
            else if (target.getParentType() == 13 && target.occupiedIsEmpty())
                mapObject = target;
        }
        if (bed == null)
            bed = mapObject;
        if (bed != null)
        {
            sim.gotoSleep(bed);
        }
        else
        {
            if (sim.getId() != 0)
                return;
            sim.beginSimAction(6, (MapObject)null);
        }
    }

    public void advertiseEvent(int actionEvent, MapObjectSim source, MapObject target)
    {
        SimData simData = this.m_simData;
        int houseId = this.m_simWorld.getHouseId();
        MapObjectSim[] simObjects = this.getSimObjects();
        int actionFlags = simData.getActionFlags(actionEvent);
        if (actionEvent == 27)
            simData.setSimCurRelStateFlags(0, 1);
        int length = simObjects.Length;
        for (int index = 0; index < length; ++index)
        {
            MapObjectSim mapObjectSim = simObjects[index];
            int id = mapObjectSim.getId();
            if (id != 0 && mapObjectSim != target && mapObjectSim != source && (((actionFlags & 262144) == 0 || simData.getSimHome(id) == houseId) && (mapObjectSim.respondToEvent(actionEvent, source, target) && (actionFlags & 8388608) != 0)))
                break;
        }
    }

    private void processBasicAction(int actionId)
    {
        switch (actionId)
        {
            case 30:
            case 430:
            case 431:
                this.hideMenus();
                this.setCameraUnsnap();
                break;
            case 49:
                this.stateTransitionSharedMenu(1);
                break;
            case 50:
                this.stateTransitionSharedMenu(3);
                break;
            case 58:
                this.hidePauseMenu();
                break;
            case 60:
                this.stateTransitionPauseMenu(1);
                break;
            case 62:
                this.stateTransitionPauseMenu(2);
                break;
            case 484:
                this.m_buildModeObject = this.getCursorObject();
                this.hideMenus();
                this.stateTransitionBuildMode(9);
                break;
            case 485:
                this.m_buildModeObject = this.getCursorObject();
                this.hideMenus();
                this.stateTransitionBuildMode(12);
                this.showTutorialMessage(27);
                break;
            case 486:
                MapObject cursorObject = this.getCursorObject();
                this.hideMenus();
                cursorObject.buildRotate();
                this.m_simWorld.objectRotate(cursorObject.getId(), cursorObject.getFacingDir());
                break;
            case 1731:
                this.stateTransitionPauseMenu(3);
                break;
            case 1814:
                this.stateTransitionPauseMenu(5);
                break;
            case 1815:
                this.stateTransitionPauseMenu(4);
                break;
            default:
                AppEngine.ASSERT(false, "action not implemented");
                break;
        }
    }

    private void initActionQueue()
    {
        this.m_actionQueueSize = 0;
        if (this.m_actionQueueActions == null)
        {
            this.m_actionQueueActions = new int[3];
            this.m_actionQueueArg1s = new MapObject[3];
            this.m_actionQueueArg2s = new int[3];
            this.m_actionQueueArg3s = new int[3];
        }
        this.clearActionQueue();
    }

    public void clearActionQueue()
    {
        this.m_actionQueueSize = 0;
        AppEngine.fillArray(this.m_actionQueueActions, -1);
        AppEngine.fillArray((object[])this.m_actionQueueArg1s, (object)null);
    }

    private void updateSimAction()
    {
        MapObjectSim playerSim = this.getPlayerSim();
        int[] actionQueueActions = this.m_actionQueueActions;
        MapObject[] actionQueueArg1s = this.m_actionQueueArg1s;
        if (this.m_actionQueueSize > 0)
        {
            if (playerSim.isIdle())
            {
                --this.m_actionQueueSize;
                for (int index = 0; index < 2; ++index)
                {
                    actionQueueActions[index] = actionQueueActions[index + 1];
                    actionQueueArg1s[index] = actionQueueArg1s[index + 1];
                    this.m_actionQueueArg2s[index] = this.m_actionQueueArg2s[index + 1];
                    this.m_actionQueueArg3s[index] = this.m_actionQueueArg3s[index + 1];
                }
                actionQueueArg1s[this.m_actionQueueSize] = (MapObject)null;
                if (this.m_actionQueueSize <= 0)
                    return;
                this.startPlayerAction(actionQueueActions[0], actionQueueArg1s[0], this.m_actionQueueArg2s[0], this.m_actionQueueArg3s[0]);
            }
            else
            {
                if (actionQueueActions[0] == playerSim.getSimAction())
                    return;
                int simAction = playerSim.getSimAction();
                if ((this.m_simData.getActionFlags(simAction) & 524288) != 0)
                    return;
                actionQueueActions[0] = simAction;
                actionQueueArg1s[0] = playerSim.getSimActionArg1();
            }
        }
        else
        {
            if ((this.m_simData.getActionFlags(playerSim.getSimAction()) & 524288) != 0)
                return;
            actionQueueActions[0] = playerSim.getSimAction();
            actionQueueArg1s[0] = playerSim.getSimActionArg1();
            this.m_actionQueueSize = 1;
        }
    }

    public bool isObjectInQueue(MapObject @object)
    {
        return AppEngine.indexOf<MapObject>(@object, this.m_actionQueueArg1s) != -1;
    }

    private void processSimAction(int action, MapObject arg1, int arg2, int arg3)
    {
        this.resetPlayerInactivity();
        switch (action)
        {
            case 138:
                this.m_engine.getBgMusic().playStereoNextTrack();
                break;
            case 139:
                this.showPauseMenu();
                this.m_pauseMenuMediaPickerInGame = true;
                this.stateTransitionPauseMenu(3);
                break;
            case 142:
                arg1.turnOn();
                break;
            case 143:
                arg1.turnOff();
                break;
            case 144:
                arg1.setRuntimeFlag(2097152);
                arg1.updateLightStatus();
                break;
            default:
                if (this.getPlayerSim().isIdle())
                {
                    this.startPlayerAction(action, arg1, arg2, arg3);
                    break;
                }
                if (action == 111)
                {
                    for (int actionIndex = this.m_actionQueueSize - 1; actionIndex >= 0 && (this.m_actionQueueActions[actionIndex] == 111 || actionIndex == 2); actionIndex = actionIndex - 1 - 1)
                        this.cancelSimAction(actionIndex);
                }
                this.addSimAction(action, arg1, arg2, arg3);
                break;
        }
    }

    private void addSimAction(int action, MapObject arg1, int arg2, int arg3)
    {
        int index = this.m_actionQueueSize != 3 ? this.m_actionQueueSize++ : 2;
        this.m_actionQueueActions[index] = action;
        this.m_actionQueueArg1s[index] = arg1;
        this.m_actionQueueArg2s[index] = arg2;
        this.m_actionQueueArg3s[index] = arg3;
    }

    public void startPlayerAction(int action, MapObject arg1, int arg2, int arg3)
    {
        MapObjectSim playerSim = this.getPlayerSim();
        playerSim.beginSimAction(action, arg1, arg2, arg3);
        foreach (MapObjectSim simObject in this.getSimObjects())
        {
            if (simObject != playerSim)
                simObject.playerAction(arg1);
        }
    }

    private void cancelSimAction(int actionIndex)
    {
        this.resetPlayerInactivity();
        if (actionIndex == 0)
        {
            if (this.m_actionQueueActions[0] != this.getPlayerSim().getSimAction())
                return;
            this.getPlayerSim().interrupt();
        }
        else
        {
            --this.m_actionQueueSize;
            for (int index = actionIndex; index < this.m_actionQueueSize; ++index)
            {
                this.m_actionQueueActions[index] = this.m_actionQueueActions[index + 1];
                this.m_actionQueueArg1s[index] = this.m_actionQueueArg1s[index + 1];
                this.m_actionQueueArg2s[index] = this.m_actionQueueArg2s[index + 1];
                this.m_actionQueueArg3s[index] = this.m_actionQueueArg3s[index + 1];
            }
            this.m_actionQueueArg1s[this.m_actionQueueSize] = (MapObject)null;
        }
    }

    private void processCancelAction(MapObject @object)
    {
        this.resetPlayerInactivity();
        if (@object == null || this.m_actionQueueSize <= 0)
            return;
        int actionIndex = AppEngine.indexOf<MapObject>(@object, this.m_actionQueueArg1s);
        if (actionIndex == -1)
            return;
        this.cancelSimAction(actionIndex);
    }

    private void processCallAction()
    {
        int index = this.m_contextMenuItems[2] + 5;
        int contextMenuAction = this.m_contextMenuActions[index];
        int contextMenuItem = this.m_contextMenuItems[index];
        switch (contextMenuItem)
        {
            case 467:
            case 468:
                this.m_contextMenuBackCursor = (short)this.m_contextMenuItems[2];
                this.m_contextMenuOnSubMenu = true;
                this.m_simData.createCallContextMenu(this.m_contextMenuItems, this.m_contextMenuActions, contextMenuAction);
                this.m_contextMenuItems[4] = (int)this.m_maxContextMenuItems;
                if (this.m_contextMenuItems[0] == 0)
                {
                    this.hideMenus();
                    this.setCameraUnsnap();
                    this.showMessageBox(1160, 1159);
                    break;
                }
                this.refreshContextMenu();
                break;
            default:
                MapObject cursorObject = this.getCursorObject();
                this.hideMenus();
                this.setCameraUnsnap();
                int simByName = this.m_simData.getSimByName(contextMenuItem);
                this.processSimAction(contextMenuAction, cursorObject, simByName, 0);
                break;
        }
    }

    public void finishCallAction(int action, int simId)
    {
        SimData simData = this.m_simData;
        switch (action)
        {
            case 147:
                if (this.findSim(simId) != null)
                {
                    this.showMessageBox(1161, 467);
                    break;
                }
                simData.adjustMotiveLevel(4, 983040);
                break;
            case 148:
                if (this.findSim(simId) != null)
                {
                    this.showMessageBox(1161, 468);
                    break;
                }
                if (this.simSpaceAvailable() && simData.acceptInvitation(simId))
                {
                    MapObject randomObjectByType = this.findRandomObjectByType(4);
                    AppEngine.ASSERT(randomObjectByType != null, "no town object!");
                    ((MapObjectSim)this.createObject(1, randomObjectByType.getPosX(), randomObjectByType.getPosY(), randomObjectByType.getPosZ(), randomObjectByType.getFacingDir(), simId)).setNeedFlag(64);
                    this.showMessageBox(1162, 468);
                    break;
                }
                this.showMessageBox(1163, 468);
                break;
        }
    }

    private void processPlantAction()
    {
        int index = this.m_contextMenuItems[2] + 5;
        int contextMenuAction = this.m_contextMenuActions[index];
        int contextMenuItem = this.m_contextMenuItems[index];
        if (contextMenuItem == 440)
        {
            this.m_contextMenuBackCursor = (short)this.m_contextMenuItems[2];
            this.m_contextMenuOnSubMenu = true;
            this.m_simData.createPlantContextMenu(this.m_contextMenuItems, this.m_contextMenuActions, contextMenuAction);
            this.m_contextMenuItems[4] = (int)this.m_maxContextMenuItems;
            if (this.m_contextMenuItems[0] == 0)
            {
                this.hideMenus();
                this.setCameraUnsnap();
                this.showMessageBox(1182, 1181);
            }
            else
                this.refreshContextMenu();
        }
        else
        {
            MapObject cursorObject = this.getCursorObject();
            this.hideMenus();
            this.setCameraUnsnap();
            int itemByName = this.m_simWorld.getItemByName(contextMenuItem);
            this.processSimAction(contextMenuAction, cursorObject, itemByName, 0);
        }
    }

    private void processCookAction()
    {
        int index = this.m_contextMenuItems[2] + 5;
        int contextMenuAction = this.m_contextMenuActions[index];
        int contextMenuItem = this.m_contextMenuItems[index];
        if (contextMenuItem == 457)
        {
            this.m_contextMenuBackCursor = (short)this.m_contextMenuItems[2];
            this.m_contextMenuOnSubMenu = true;
            this.m_simData.createCookContextMenu(this.m_contextMenuItems, this.m_contextMenuActions, contextMenuAction);
            this.m_contextMenuItems[4] = (int)this.m_maxContextMenuItems;
            if (this.m_contextMenuItems[0] == 0)
            {
                this.hideMenus();
                this.setCameraUnsnap();
                this.showMessageBox(1180, 1179);
            }
            else
                this.refreshContextMenu();
        }
        else
        {
            MapObject cursorObject = this.getCursorObject();
            this.hideMenus();
            this.setCameraUnsnap();
            int recipeByName = this.m_simWorld.getRecipeByName(contextMenuItem);
            this.processSimAction(contextMenuAction, cursorObject, recipeByName, 0);
        }
    }

    public void upgradeHouse()
    {
        this.hideMenus();
        switch (this.m_simWorld.getHouseUpgradeCost())
        {
            case -1:
                this.showMessageBox(1174, 470);
                break;
            case 0:
                this.showMessageBox(1173, 470);
                break;
            default:
                this.stateTransition(7);
                if (this.m_simWorld.getHouseUpgradeCost() <= this.m_simData.getMoney())
                {
                    this.stateTransitionBuildMode(10);
                    break;
                }
                this.stateTransitionBuildMode(11);
                break;
        }
    }

    public SimData getSimData()
    {
        return this.m_simData;
    }

    public SimWorld getSimWorld()
    {
        return this.m_simWorld;
    }

    private void updateSimData(int timeStep)
    {
        SimData simData = this.m_simData;
        if (this.m_timeHit != 0)
        {
            simData.update(this.m_timeHit * 1000);
            this.m_timeHit = 0;
            this.m_simWorld.forceTint();
        }
        else
        {
            int timeStep1 = timeStep;
            if (simData.getFastforward())
                timeStep1 <<= 4;
            simData.update(timeStep1);
        }
        this.m_displayedMoodLevel = this.interpolateValue(this.m_displayedMoodLevel, simData.getMoodLevel(), timeStep, 8);
        if (!this.getPlayerSim().isWorking())
        {
            int timeFlags = simData.getTimeFlags(0);
            if ((timeFlags & 1) != 0 && !this.isShowingTickerMessage())
            {
                this.showTickerMessage(958, -1);
            }
            else
            {
                if ((timeFlags & 2) == 0 || this.isShowingTickerMessage())
                    return;
                this.showTickerMessage(959, -1);
            }
        }
        else
            this.cancelWorkMessages();
    }

    private void cancelWorkMessages()
    {
        this.cancelTickerMessage(959);
        this.cancelTickerMessage(958);
    }

    public void setTimeHit(int time)
    {
        this.m_timeHit = time;
    }

    public void checkGameTimeTriggers(int oldTime, int newTime)
    {
        SimData simData = this.m_simData;
        if (this.getPlayerSim().isWorking() || simData.getSimCareer(0) == -1)
            return;
        for (int gameTime = oldTime; gameTime < newTime; ++gameTime)
        {
            int timeFlags1 = simData.getTimeFlags(0, gameTime);
            int timeFlags2 = simData.getTimeFlags(0, gameTime + 1);
            if ((timeFlags1 & 2) != 0 && (timeFlags2 & 4) != 0)
            {
                simData.careerDayMissed();
                this.cancelWorkMessages();
                int postMessage = 2;
                if (simData.getSimCareer(0) == -1)
                {
                    this.showMessageBox(964, 963, postMessage);
                    break;
                }
                this.showMessageBox(961, 960, postMessage);
                break;
            }
        }
    }

    private int getNumActiveBuffs()
    {
        int num = 0;
        for (int index = 0; index < 6; ++index)
        {
            if (this.m_simData.getBuff(index) != -1)
                ++num;
        }
        return num;
    }

    private int getBuffPanelWidth()
    {
        int num1 = 0;
        for (int index = 0; index < 6; ++index)
        {
            int buff = this.m_simData.getBuff(index);
            if (buff != -1)
            {
                int stringWidth = this.m_engine.getTextManager().getStringWidth(this.m_simData.getBuffDescString(buff), 3);
                if (stringWidth > num1)
                    num1 = stringWidth;
            }
        }
        AnimationManager2D animationManager2D = this.m_engine.getAnimationManager2D();
        float num2 = MathExt.smoothstep(0.0f, 1f, this.m_buffPanelSlideFactor);
        return (int)((double)animationManager2D.getAnimWidth(370) + (double)animationManager2D.getAnimWidth(371) + (double)num2 * (double)(num1 + 9) + (double)animationManager2D.getAnimWidth(372));
    }

    private int getBuffPanelHeight()
    {
        return (int)(2.0 * (double)this.m_engine.getAnimationManager2D().getAnimHeight(370));
    }

    private void renderHUDBuffs(Graphics g)
    {
        if ((this.m_HUDRenderMask & 32) == 0)
            return;
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        SimData simData = this.m_simData;
        bool flag = this.m_isBuffPanelVisible && (double)this.m_buffPanelSlideFactor > 0.990000009536743;
        int buffPanelWidth = this.getBuffPanelWidth();
        int num1 = (buffPanelWidth >> 1) - 6;
        int animHeight = (int)animationManager2D.getAnimHeight(369);
        int buffPanelHeight = this.getBuffPanelHeight();
        int y = 73;
        animationManager2D.submitAnimHBar(370, 371, 372, (float)num1, (float)(50 + (buffPanelHeight >> 2)), (float)buffPanelWidth);
        animationManager2D.submitAnimHBar(370, 371, 372, (float)num1, (float)(50 + (buffPanelHeight >> 2) + (buffPanelHeight >> 1)), (float)buffPanelWidth, 1f, -1f);
        if (this.getNumActiveBuffs() > 0)
        {
            int num2 = buffPanelWidth - 20;
            animationManager2D.submitAnim(flag ? 178 : 179, (float)num2, (float)(50 + (this.getBuffPanelHeight() >> 1)));
        }
        animationManager2D.flushAnims(g);
        for (int index = 0; index < 6; ++index)
        {
            int buff = simData.getBuff(index);
            if (buff != -1)
            {
                int buffDescString = simData.getBuffDescString(buff);
                int animId = (simData.getBuffFlags(buff) & 1) == 0 ? 369 : 368;
                animationManager2D.submitAnim(animId, 11f, (float)y);
                if (flag)
                {
                    g.Begin();
                    textManager.drawString(g, buffDescString, 3, 19, y, 10);
                    g.End();
                }
                y += animHeight - 4;
            }
        }
    }

    public void triggerChanceCard(int id)
    {
        this.m_questId = id;
        this.m_questSimId = -1;
        this.m_chanceCardOutcome = -1;
        this.stateTransition(18);
        this.stateTransitionQuest(0);
    }

    public void triggerFetchQuest(int id, int fromSimId)
    {
        this.m_questId = id;
        this.m_questSimId = fromSimId;
        this.stateTransition(18);
        this.stateTransitionQuest(2);
    }

    public void triggerFetchQuestEnd(int id, int fromSimId)
    {
        this.m_showFetchQuestEnd = true;
        this.m_questId = id;
        this.m_questSimId = fromSimId;
    }

    private void stateTransitionQuest(int state)
    {
        SimData simData = this.m_simData;
        this.m_questState = state;
        int questId = this.m_questId;
        int stringId = -1;
        bool flag = false;
        switch (state)
        {
            case 0:
                stringId = simData.getChanceCardPromptString(questId);
                flag = true;
                break;
            case 1:
                stringId = simData.getChanceCardOutcomeString(questId, this.m_chanceCardOutcome);
                break;
            case 2:
                stringId = simData.getQuestPromptString(questId);
                break;
            case 3:
                stringId = simData.getQuestMessageString(questId);
                break;
            case 4:
                this.stateTransition(6);
                break;
        }
        if (stringId == -1)
            return;
        int titleStringId = 1226;
        if (this.m_questSimId != -1)
            titleStringId = simData.getSimName(this.m_questSimId);
        if (flag)
            this.prepareConfirmBox(stringId, titleStringId);
        else
            this.prepareMessageBox(stringId, titleStringId);
    }

    private void renderQuest(Graphics g)
    {
        this.renderMain(g);
        this.m_engine.renderBackgroundDim(g);
        this.drawGenericMessageBox(g);
    }

    public bool isShowingEvent()
    {
        return this.m_eventState != 0 && this.m_eventState != 1 && this.m_eventState != 5;
    }

    private void finishEvent()
    {
        int mask = 1046528;
        if (this.isMapMode())
            mask &= -65537;
        this.m_engine.unloadAllImages(mask, -1);
        switch (this.m_eventId)
        {
            case 0:
                this.m_engine.changeScene(1, -1);
                break;
            case 2:
                this.stateTransition(6);
                break;
            case 3:
                this.m_timeHit = 30;
                if (this.m_simData.registerWooHoo())
                {
                    SpywareManager.getInstance().trackEndGameDeath("woohoo");
                    this.killPlayer(1213);
                    this.stateTransitionEvent(2);
                    break;
                }
                this.stateTransition(6);
                break;
            case 5:
                if (this.m_simWorld.isBestHouse())
                {
                    this.m_simData.dreamCompleteEvent(62);
                    if (this.m_simData.getMoney() > 10000)
                        this.awardAchievment(13);
                }
                this.stateTransition(6);
                break;
            default:
                this.stateTransition(6);
                break;
        }
    }

    private void stateTransitionEvent(int state)
    {
        this.m_eventState = state;
        this.m_stateTime = 0;
        switch (state)
        {
            case 1:
                this.setCursorObject((MapObject)this.getPlayerSim());
                break;
            case 3:
                this.playSound(this.m_eventSoundId);
                break;
            case 5:
                this.finishEvent();
                break;
        }
    }

    private void updateEvent(int timeStep)
    {
        this.m_eventTimer += timeStep;
        switch (this.m_eventState)
        {
            case 1:
                this.updateCamera(timeStep);
                if (!this.m_cameraAtDest)
                    break;
                this.setCursorObject((MapObject)null);
                this.stateTransitionEvent(2);
                break;
            case 2:
                if (this.m_stateTime <= 500)
                    break;
                this.stateTransitionEvent(3);
                break;
            case 4:
                if (this.m_stateTime <= 1000)
                    break;
                this.stateTransitionEvent(5);
                break;
        }
    }

    private void renderEvent(Graphics g)
    {
        AppEngine engine = this.m_engine;
        switch (this.m_eventState)
        {
            case 1:
                this.renderMain(g);
                break;
            case 2:
            case 3:
            case 4:
                this.renderEventMain(g);
                break;
        }
        if (this.m_eventState == 2)
        {
            int num = (int)byte.MaxValue - midp.JMath.min(this.m_stateTime * (int)byte.MaxValue / 500, (int)byte.MaxValue);
            int color = -16777216 | num << 16 | num << 8 | num;
            engine.renderFade(g, 65, color, 0, 0, engine.getWidth(), engine.getHeight());
        }
        else
        {
            if (this.m_eventState != 4)
                return;
            int num = (int)byte.MaxValue - midp.JMath.min(this.m_stateTime * (int)byte.MaxValue / 1000, (int)byte.MaxValue);
            int color = -16777216 | num << 16 | num << 8 | num;
            engine.renderFade(g, 66, color, 0, 0, engine.getWidth(), engine.getHeight());
        }
    }

    private void renderEventMain(Graphics g)
    {
        switch (this.m_eventId)
        {
            case 0:
                this.drawEventFrame(g, 1);
                break;
            case 1:
                this.drawEventFrame(g, 9);
                break;
            case 2:
                this.drawEventFrame(g, 7);
                break;
            case 3:
                this.drawEventFrame(g, 17);
                break;
            case 4:
                this.drawEventFrame(g, 15);
                break;
            case 5:
                this.drawEventFrame(g, 5);
                break;
            case 6:
                this.drawEventFrame(g, 3);
                break;
            case 7:
                this.drawEventFrame(g, 13);
                break;
            case 8:
                this.drawEventFrame(g, 11);
                break;
        }
    }

    private void drawEventFrame(Graphics g, int quadId)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        int stringWidth = textManager.getStringWidth(1190, 3);
        int lineHeight = textManager.getLineHeight(3);
        int num1 = stringWidth + 20;
        int num2 = lineHeight + 10;
        int num3 = this.m_engine.getHeight() - 5 - num2;
        animationManager2D.submitAnim(quadId, (float)engine.getHalfWidth(), (float)engine.getHalfHeight());
        animationManager2D.submitAnimGrid(340, 341, 342, 343, 344, 345, 346, 347, 348, 6f, (float)num3, (float)num1, (float)num2);
        animationManager2D.flushAnims(g);
        g.Begin();
        textManager.drawString(g, 1190, 3, 16, num3 + 5, 9);
        g.End();
    }

    public bool inMiniGame()
    {
        return this.m_state == 16;
    }

    public void beginMiniGame(int type, MapObject targetObject)
    {
        this.m_miniGameTimerMax = 0;
        this.m_minigameTipId = -1;
        this.hideMenus();
        this.m_simData.delayAlerts();
        this.m_miniGameTargetObject = targetObject;
        this.m_miniGameType = type;
        this.stateTransition(16);
        this.stateTransitionMiniGame(0);
        int num = 0;
        this.m_miniGameTimer = 0;
        switch (type)
        {
            case 0:
                num = 20;
                this.beginMiniGameCooking();
                break;
            case 1:
                num = 20;
                this.beginMiniGameFishing();
                break;
            case 2:
                num = 20;
                this.beginMiniGameRepairing();
                break;
        }
        this.m_timeHit = num;
        BGMusic bgMusic = this.m_engine.getBgMusic();
        if (this.m_miniGameType != 1)
            bgMusic.playMusic(2, 2);
        else if (!bgMusic.isPlaying())
            bgMusic.playMusic(3, 1);
        if (this.m_minigameAmbSound == -1)
            return;
        this.m_minigameSoundTimer = this.m_engine.rand(this.m_minigameSoundTimeMin, this.m_minigameSoundTimeMax);
    }

    private void stateTransitionMiniGame(int state)
    {
        SimData simData = this.m_simData;
        this.m_miniGameState = state;
        bool flag = false;
        switch (state)
        {
            case 0:
                this.setCursorObject((MapObject)null);
                this.stateTransitionCamera(6);
                break;
            case 1:
                switch (this.m_miniGameType)
                {
                    case 0:
                        this.showTutorialMessage(5);
                        break;
                    case 1:
                        this.showTutorialMessage(6);
                        break;
                    case 2:
                        this.showTutorialMessage(7);
                        break;
                    case 3:
                        this.showTutorialMessage(8);
                        break;
                }
                this.stateTransitionCamera(7);
                break;
            case 2:
                SpywareManager.getInstance().trackMiniGameFinish(this.m_miniGameTypeString, true, "success");
                this.playSound(76);
                this.stateTransition(6);
                if (this.m_miniGameType == 1)
                    this.m_engine.getBgMusic().setLooped(false);
                else if (this.m_numStereosPlaying > 0)
                {
                    this.m_engine.getBgMusic().playStereo();
                }
                else
                {
                    this.m_engine.getBgMusic().beQuiet();
                    this.m_engine.getBgMusic().playMusic(4, 2);
                }
                switch (this.m_miniGameType)
                {
                    case 0:
                        this.increaseSkill(0);
                        simData.dreamCompleteEvent(27);
                        switch (simData.getActiveRecipe())
                        {
                            case 0:
                                simData.dreamCompleteEvent(28);
                                break;
                            case 6:
                                simData.dreamCompleteEvent(29);
                                break;
                            case 9:
                                simData.dreamCompleteEvent(30);
                                break;
                        }
                        break;
                    case 1:
                        this.increaseSkill(1);
                        this.m_miniGameTargetObject.unhide();
                        simData.dreamCompleteEvent(21);
                        if (this.m_fishingFishType == 31)
                            simData.dreamCompleteEvent(22);
                        else if (this.m_fishingFishType == 32)
                            simData.dreamCompleteEvent(23);
                        else if (this.m_fishingFishType == 29)
                            simData.dreamCompleteEvent(24);
                        simData.adjustInventory(this.m_fishingFishType, 1);
                        this.showGetItem(this.m_fishingFishType, 1, 705, 1083);
                        break;
                    case 2:
                        this.increaseSkill(2);
                        simData.dreamCompleteEvent(25);
                        this.m_miniGameTargetObject.repairObject();
                        this.cleanupRepairingMiniGame();
                        break;
                }
                flag = true;
                this.m_playerSim.unhide();
                this.stateTransitionCamera(8);
                break;
            case 3:
                SpywareManager.getInstance().trackMiniGameFinish(this.m_miniGameTypeString, false, "fail");
                switch (this.m_miniGameType)
                {
                    case 1:
                        this.cleanupFishingMiniGame();
                        this.m_miniGameTargetObject.unhide();
                        break;
                    case 2:
                        this.cleanupRepairingMiniGame();
                        break;
                }
                if (this.m_miniGameType == 2 && this.m_engine.randPercent() < 5)
                {
                    SpywareManager.getInstance().trackEndGameDeath("repair");
                    this.killPlayer(1214);
                }
                else
                {
                    this.getPlayerSim().interrupt();
                    this.getPlayerSim().queueSimAction(11, (MapObject)null, 0, 0);
                    int titleStringId = -1;
                    switch (this.m_miniGameType)
                    {
                        case 0:
                            titleStringId = 691;
                            break;
                        case 1:
                            titleStringId = 705;
                            break;
                        case 2:
                            titleStringId = 712;
                            break;
                    }
                    this.showMessageBox(1154, titleStringId);
                    if (this.m_miniGameType == 1)
                        this.m_engine.getBgMusic().setLooped(false);
                    else if (this.m_numStereosPlaying > 0)
                    {
                        this.m_engine.getBgMusic().playStereo();
                    }
                    else
                    {
                        this.m_engine.getBgMusic().beQuiet();
                        this.m_engine.getBgMusic().playMusic(4, 2);
                    }
                    flag = true;
                }
                this.m_playerSim.unhide();
                this.stateTransitionCamera(8);
                break;
            case 4:
                SpywareManager.getInstance().trackMiniGameFinish(this.m_miniGameTypeString, false, "cancel");
                switch (this.m_miniGameType)
                {
                    case 0:
                        this.cleanupCookingMiniGame();
                        break;
                    case 1:
                        this.m_miniGameTargetObject.unhide();
                        this.cleanupFishingMiniGame();
                        break;
                    case 2:
                        this.cleanupRepairingMiniGame();
                        break;
                }
                this.m_timeHit = 0;
                this.getPlayerSim().interrupt();
                int titleStringId1 = -1;
                switch (this.m_miniGameType)
                {
                    case 0:
                        titleStringId1 = 691;
                        break;
                    case 1:
                        titleStringId1 = 705;
                        break;
                    case 2:
                        titleStringId1 = 712;
                        break;
                }
                this.showMessageBox(1155, titleStringId1);
                if (this.m_miniGameType == 1)
                    this.m_engine.getBgMusic().setLooped(false);
                else if (this.m_numStereosPlaying > 0)
                {
                    this.m_engine.getBgMusic().playStereo();
                }
                else
                {
                    this.m_engine.getBgMusic().beQuiet();
                    this.m_engine.getBgMusic().playMusic(4, 2);
                }
                flag = true;
                this.m_playerSim.unhide();
                this.stateTransitionCamera(8);
                break;
            case 5:
                AppEngine.ASSERT(this.m_miniGameType == 0, "only cooking uses timeup state");
                this.m_stateTime = 0;
                break;
            case 6:
                this.m_miniGameOutroTimer = 2000;
                AppEngine.ASSERT(this.m_miniGameType == 0, "only cooking uses outro state");
                break;
            case 7:
                AppEngine.ASSERT(this.m_miniGameType == 1, "only fishing uses intro state");
                MapObjectSim playerSim1 = this.getPlayerSim();
                playerSim1.unsetRuntimeFlag(128);
                playerSim1.setSubAppearance(60);
                this.m_simWorld.addObjectNode(this.m_miniGameFishingRod.getNode());
                break;
            case 8:
                AppEngine.ASSERT(this.m_miniGameType == 1, "only fishing uses outro state");
                MapObjectSim playerSim2 = this.getPlayerSim();
                playerSim2.unsetRuntimeFlag(128);
                int type = this.fishingSuccess() ? 64 : 61;
                playerSim2.setSubAppearance(type);
                this.m_miniGameFishingRod.startAnim(this.fishingSuccess() ? 231 : 230, 16);
                if (this.fishingSuccess())
                {
                    this.m_miniGameFish.startAnim(232, 16);
                    this.m_miniGameFish.getNode().setTranslation((float)this.m_playerSim.getPosX() / 65536f, (float)this.m_playerSim.getPosY() / 65536f, (float)this.m_playerSim.getPosZ() / 65536f);
                    this.playSound(73);
                    break;
                }
                this.m_simWorld.removeObjectNode(this.m_miniGameFish.getNode());
                break;
            case 11:
                this.m_repairBoardAnimPlayer.startAnim(235, 20);
                this.m_repairOutroTimer = 3000;
                for (int index = 0; index < this.m_repairBoardCircuits.Length; ++index)
                {
                    this.m_repairBoardCircuits[index].getNode().setRenderingEnable(true);
                    this.m_repairBoardCircuits[index].startAnim(236, 20);
                }
                this.playSound(79);
                break;
        }
        if (!flag)
            return;
        switch (this.m_miniGameType)
        {
            case 0:
                simData.dreamCompleteEvent(1);
                break;
            case 1:
                simData.dreamCompleteEvent(0);
                break;
        }
    }

    public void increaseSkill(int skill)
    {
        SimData simData = this.m_simData;
        int skillRank1 = simData.getSkillRank(skill);
        simData.increaseSkill(skill);
        int skillRank2 = simData.getSkillRank(skill);
        int messageStringId = 1156;
        if (skillRank1 != skillRank2)
        {
            messageStringId = skillRank2 == 5 ? 1158 : 1157;
            switch (skill)
            {
                case 0:
                    simData.dreamCompleteEvent(7);
                    if (skillRank2 == 5)
                    {
                        simData.dreamCompleteEvent(72);
                        break;
                    }
                    break;
                case 1:
                    simData.dreamCompleteEvent(8);
                    if (skillRank2 == 5)
                    {
                        simData.dreamCompleteEvent(70);
                        break;
                    }
                    break;
                case 2:
                    simData.dreamCompleteEvent(9);
                    if (skillRank2 == 5)
                    {
                        simData.dreamCompleteEvent(71);
                        break;
                    }
                    break;
                case 3:
                    if (skillRank2 == 5)
                    {
                        this.m_engine.getScene().awardAchievment(10);
                        break;
                    }
                    break;
            }
        }
        if (skillRank1 != skillRank2 && skillRank2 == 5)
        {
            int skillDesc = simData.getSkillDesc(skill);
            this.m_engine.getTextManager().dynamicString(-11, 1195, simData.getSkillDesc(skill));
            this.showMessageBox(-11, skillDesc, 10);
        }
        else if (skillRank1 != 5)
        {
            int skillDesc = simData.getSkillDesc(skill);
            this.showMessageBox(messageStringId, skillDesc);
        }
        if (skillRank1 == skillRank2 || simData.getSkillRank(0) <= 0 || (simData.getSkillRank(1) <= 0 || simData.getSkillRank(2) <= 0))
            return;
        this.awardAchievment(9);
    }

    private void renderMiniGame(Graphics g)
    {
        this.m_simWorld.renderWorld(g);
        if (this.m_miniGameState == 0)
            return;
        switch (this.m_miniGameType)
        {
            case 0:
                this.renderMiniGameBGTimer(g);
                this.renderMiniGameCooking(g);
                break;
            case 1:
                this.renderMiniGameBGTimer(g);
                this.renderMiniGameFishing(g);
                break;
            case 2:
                this.renderMiniGameBGTimer(g);
                this.renderMiniGameRepairing(g);
                break;
        }
        if (!this.m_pauseMenuActive)
            return;
        this.renderPauseMenu(g);
    }

    private int getMiniGameLeaveText(int minigame)
    {
        return 30;
    }

    private void renderMiniGameBGTimer(Graphics g)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        int miniGameLeaveText = this.getMiniGameLeaveText(this.m_miniGameType);
        int lineHeight = textManager.getLineHeight(6);
        int stringWidth = textManager.getStringWidth(miniGameLeaveText, 6);
        int num1 = lineHeight + 20;
        int num2 = stringWidth + 44 + 30;
        int num3 = 25 - (num1 >> 1);
        g.setColor(0);
        g.Begin();
        g.fillRect(0, 0, engine.getWidth(), 50);
        g.End();
        animationManager2D.submitAnimGrid(388, 391, 394, 389, 392, 395, 390, 393, 396, 30f, (float)num3, (float)num2, (float)num1);
        animationManager2D.submitAnim(330, 30f, 25f);
        this.getUIButton(524288).submit(ref animationManager2D, 30, 25, !this.m_pauseMenuActive);
        g.setColor(0);
        g.Begin();
        g.fillRect(0, engine.getHeight() - 40, engine.getWidth(), 40);
        g.End();
        int y = engine.getHeight() - 30;
        animationManager2D.submitAnim(376, 30f, (float)y);
        this.getUIButton(1).submit(ref animationManager2D, 30, y, !this.m_pauseMenuActive);
        if (this.m_miniGameType == 2)
        {
            if (this.imgTrashCan == null)
                this.imgTrashCan = JavaLib.createImage("trashcan");
            int num4 = 470;
            int num5 = 230;
            g.Begin();
            g.drawImage(this.imgTrashCan, (float)num4, (float)num5, 9);
            g.End();
        }
        int num6 = engine.getWidth() - 40;
        if (this.m_miniGameType == 0)
        {
            float angle = (float)(360.0 * ((double)(this.m_miniGameTimerMax - this.m_miniGameTimer) / (double)this.m_miniGameTimerMax));
            animationManager2D.submitAnim(382, (float)num6, 35f);
            animationManager2D.flushAnims(g);
            g.setColor(219, 29, 29, (int)sbyte.MaxValue);
            g.Begin();
            g.fillArc(num6 - 30, 5, 61, 61, 0, (int)angle);
            g.End();
            int num4 = (int)((double)num6 + 18.0 * (double)midp.JMath.cos((float)((360.0 - ((double)angle + 90.0)) * (System.Math.PI / 180.0))));
            int num5 = (int)(35.0 + 18.0 * (double)midp.JMath.sin((float)((360.0 - ((double)angle + 90.0)) * (System.Math.PI / 180.0))));
            animationManager2D.submitAnim(384, (float)num4, (float)num5, 1f, 1f, 1f, angle);
            animationManager2D.submitAnim(383, (float)num6, 35f);
        }
        else if (this.m_miniGameType == 2)
        {
            float num4 = (float)(360.0 * ((double)(this.m_miniGameTimerMax - this.m_miniGameTimer) / (double)this.m_miniGameTimerMax));
            animationManager2D.submitAnim(386, (float)num6, 35f);
            animationManager2D.flushAnims(g);
            g.setColor(14707588);
            g.Begin();
            g.fillArc(num6 - 30, 5, 61, 61, 0, (int)num4);
            g.End();
            animationManager2D.submitAnim(387, (float)num6, 35f);
        }
        int num7 = this.m_miniGameType == 2 ? 90 : 20;
        int animHeight = (int)animationManager2D.getAnimHeight(360);
        int num8 = -1;
        int num9 = engine.getHeight() - animHeight;
        if (this.m_minigameTipId != -1 && !this.m_tutorialMessageActive)
        {
            int num4 = textManager.getStringWidth(this.m_minigameTipId, 4) + 40;
            num8 = engine.getWidth() - num4 - num7;
            animationManager2D.submitAnimHBar(359, 360, 361, (float)(num8 + (num4 >> 1)), (float)(num9 + (animHeight >> 1)), (float)num4);
        }
        animationManager2D.flushAnims(g);
        g.Begin();
        textManager.drawString(g, miniGameLeaveText, 6, 74, num3 + 10, 9);
        if (this.m_minigameTipId != -1 && !this.m_tutorialMessageActive)
            textManager.drawString(g, this.m_minigameTipId, 4, num8 + 20, num9 + (animHeight >> 1), 10);
        g.End();
    }

    private void updateMiniGame(int timeStep)
    {
        if (this.m_pauseMenuActive || this.m_tutorialMessageActive)
            return;
        if (this.m_miniGameType != 1 || this.m_miniGameState == 7 || this.m_miniGameState == 8)
            this.getPlayerSim().update(timeStep);
        this.getPlayerSim().getModel(2).updatePlumbBob(timeStep, true);
        if (this.m_miniGameTargetObject != null)
            this.m_miniGameTargetObject.update(timeStep);
        this.updateObjectTypes(timeStep, 10);
        if (this.m_showTutorial && this.m_cameraAtDest)
            this.checkTriggers();
        if (this.m_miniGameState == 0)
        {
            if (this.m_cameraAtDest)
                this.stateTransitionMiniGame(this.m_miniGameType == 1 ? 7 : 1);
        }
        else
        {
            switch (this.m_miniGameType)
            {
                case 0:
                    this.updateMiniGameCooking(timeStep);
                    break;
                case 1:
                    this.updateMiniGameFishing(timeStep);
                    break;
                case 2:
                    this.updateMiniGameRepairing(timeStep);
                    break;
            }
        }
        if (this.m_miniGameState != 1 || this.m_minigameAmbSound == -1)
            return;
        this.m_minigameSoundTimer -= timeStep;
        if (this.m_minigameSoundTimer > 0)
            return;
        this.m_minigameSoundTimer = this.m_engine.rand(this.m_minigameSoundTimeMin, this.m_minigameSoundTimeMax);
        this.playSound(this.m_minigameAmbSound);
    }

    private void beginMiniGameCooking()
    {
        int skillRank = this.m_simData.getSkillRank(0);
        int num1 = 2;
        int num2 = -1;
        switch (skillRank)
        {
            case 0:
                num2 = 20000;
                break;
            case 1:
                num2 = 30000;
                break;
            case 2:
                num1 = 3;
                num2 = 30000;
                break;
            case 3:
                num1 = 3;
                num2 = 30000;
                break;
            case 4:
            case 5:
                num1 = 4;
                num2 = 40000;
                break;
            default:
                AppEngine.ASSERT(false, "invalid skill rank");
                break;
        }
        this.m_cookingPotCount = num1;
        this.m_miniGameTimerMax = num2;
        this.m_cookingPotActive = 0;
        this.m_miniGameTimer = 0;
        AppEngine engine = this.m_engine;
        engine.getBgMusic().playMusic(2, 2);
        for (int index = 0; index < this.m_cookingPotCount; ++index)
        {
            int num3 = engine.rand(1638400, 4915200);
            this.m_cookingLevelsF[index] = num3;
            this.m_displayedCookingLevelsF[index] = num3;
            this.m_cookingPotContents[index] = (sbyte)engine.rand(0, 3);
        }
        this.m_playerSim.hide();
        Model model1 = this.m_miniGameTargetObject.getModel();
        for (int index = 0; index < this.m_cookingPotCount; ++index)
        {
            m3g.Node model2 = ModelManager.getInstance().getModel(28);
            this.setCookingPotSurface((Group)model2);
            if (index < 2)
                model2.setOrientation(-60f, 0.0f, 1f, 0.0f);
            else
                model2.setOrientation(60f, 0.0f, 1f, 0.0f);
            this.m_pots[index].setNode(model2);
            this.m_pots[index].startAnim(223, 20);
            this.m_pots[index].updateAnim(this.m_engine.rand(0, 1000));
            Group.m3g_cast((Object3D)model1.getLocator(3000 + index)).addChild(model2);
            this.m_potHeatSpeeds[index] = (float)this.m_engine.rand(131072, 458752) / 65536f;
            this.m_potHeats[index] = 0.0f;
        }
        this.m_prevSelectedPot = -1;
        this.m_curSelectedPot = -1;
        this.m_selectedPotState = 0;
        this.m_minigameTipId = 1577;
        this.m_minigameSoundTimeMin = 3000;
        this.m_minigameSoundTimeMax = 4000;
        this.m_minigameAmbSound = 74;
    }

    private void cleanupCookingMiniGame()
    {
        Model model = this.m_miniGameTargetObject.getModel();
        for (int index = 0; index < this.m_cookingPotCount; ++index)
            Group.m3g_cast((Object3D)model.getLocator(3000 + index)).removeChild(this.m_pots[index].getNode());
        if (this.m_numStereosPlaying > 0)
            this.m_engine.getBgMusic().playStereo();
        this.m_minigameAmbSound = -1;
    }

    private void setCookingPotSurface(Group pot)
    {
        int num = this.m_engine.rand(0, 3);
        m3g.Node node1 = m3g.Node.m3g_cast(pot.find(3010));
        m3g.Node node2 = m3g.Node.m3g_cast(pot.find(3011));
        m3g.Node node3 = m3g.Node.m3g_cast(pot.find(3012));
        m3g.Node node4 = m3g.Node.m3g_cast(pot.find(3013));
        m3g.Node node5 = m3g.Node.m3g_cast(pot.find(3020));
        m3g.Node node6 = m3g.Node.m3g_cast(pot.find(3021));
        m3g.Node node7 = m3g.Node.m3g_cast(pot.find(3022));
        m3g.Node node8 = m3g.Node.m3g_cast(pot.find(3023));
        m3g.Node node9 = m3g.Node.m3g_cast(pot.find(3030));
        m3g.Node node10 = m3g.Node.m3g_cast(pot.find(3031));
        m3g.Node node11 = m3g.Node.m3g_cast(pot.find(3032));
        m3g.Node node12 = m3g.Node.m3g_cast(pot.find(3033));
        node1.setRenderingEnable(false);
        node2.setRenderingEnable(false);
        node3.setRenderingEnable(false);
        node4.setRenderingEnable(false);
        node5.setRenderingEnable(false);
        node6.setRenderingEnable(false);
        node7.setRenderingEnable(false);
        node8.setRenderingEnable(false);
        node9.setRenderingEnable(false);
        node10.setRenderingEnable(false);
        node11.setRenderingEnable(false);
        node12.setRenderingEnable(false);
        int userID1 = -1;
        int userID2 = -1;
        int userID3 = -1;
        switch (num)
        {
            case 0:
                userID1 = 3010;
                userID2 = 3020;
                userID3 = 3030;
                break;
            case 1:
                userID1 = 3011;
                userID2 = 3021;
                userID3 = 3031;
                break;
            case 2:
                userID1 = 3012;
                userID2 = 3022;
                userID3 = 3032;
                break;
            case 3:
                userID1 = 3013;
                userID2 = 3023;
                userID3 = 3033;
                break;
        }
        m3g.Node node13 = m3g.Node.m3g_cast(pot.find(userID1));
        m3g.Node node14 = m3g.Node.m3g_cast(pot.find(userID2));
        m3g.Node node15 = m3g.Node.m3g_cast(pot.find(userID3));
        node13.setRenderingEnable(true);
        node14.setRenderingEnable(true);
        node15.setRenderingEnable(true);
    }

    private void renderMiniGameCooking(Graphics g)
    {
        int[] result1 = new int[3];
        int[] result2 = new int[3];
        AnimationManager2D animationManager2D = this.m_engine.getAnimationManager2D();
        for (int index = 0; index < this.m_cookingPotCount; ++index)
        {
            if ((double)this.m_potHeats[index] > 50.0)
            {
                m3g.Node node = m3g.Node.m3g_cast(this.m_pots[index].getNode().find(3100));
                this.m_miniGameTargetObject.getModel().getLocatorPos(result1, node);
                this.m_simWorld.coordWorldToScreen(result2, result1[0], result1[1], result1[2]);
                float alpha = (float)(((double)this.m_potHeats[index] - 50.0) / 50.0);
                animationManager2D.submitAnim(385, (float)result2[0], (float)result2[1], alpha, 5f, 5f);
            }
        }
        animationManager2D.flushAnims(g);
    }

    private void updateMiniGameCooking(int timeStep)
    {
        if (this.m_miniGameState == 5)
        {
            this.stateTransitionMiniGame(2);
            this.cleanupCookingMiniGame();
        }
        else if (this.m_miniGameState == 6)
        {
            this.m_miniGameOutroTimer -= timeStep;
            if (this.m_miniGameOutroTimer > 0)
                return;
            this.stateTransitionMiniGame(3);
            this.cleanupCookingMiniGame();
        }
        else
        {
            this.m_miniGameTimer += timeStep;
            if (this.m_miniGameTimer > this.m_miniGameTimerMax)
            {
                this.m_engine.vibrate();
                this.stateTransitionMiniGame(5);
            }
            else
            {
                if (this.m_prevSelectedPot != -1 && !this.m_pots[this.m_prevSelectedPot].isAnimating())
                {
                    this.m_pots[this.m_prevSelectedPot].startAnim(223, 20);
                    if (this.m_curSelectedPot != -1)
                        this.m_pots[this.m_curSelectedPot].startAnim(224, 16);
                    this.m_prevSelectedPot = -1;
                    this.m_selectedPotState = 1;
                }
                if (this.m_curSelectedPot != -1)
                {
                    if (this.m_selectedPotState == 1 && !this.m_pots[this.m_curSelectedPot].isAnimating())
                    {
                        this.m_pots[this.m_curSelectedPot].startAnim(227, 20);
                        this.m_selectedPotState = 0;
                    }
                    else if (this.m_selectedPotState == 2)
                    {
                        this.m_potHeats[this.m_curSelectedPot] -= (float)(50.0 * ((double)timeStep / 1000.0));
                        this.m_potHeats[this.m_curSelectedPot] = midp.JMath.max(0.0f, this.m_potHeats[this.m_curSelectedPot]);
                        if (!this.m_pots[this.m_curSelectedPot].isAnimating())
                        {
                            this.m_selectedPotState = 0;
                            this.m_pots[this.m_curSelectedPot].startAnim(227, 20);
                        }
                    }
                    if (this.m_selectedPotState == 0)
                    {
                        Accelerometer staticAccelerometer = Accelerometer.getStaticAccelerometer();
                        float x = -1f;
                        float y = -1f;
                        float z = -1f;
                        staticAccelerometer.getRawXYZ(ref x, ref y, ref z);
                        if ((double)midp.JMath.sqrt((float)((double)x * (double)x + (double)y * (double)y + (double)z * (double)z)) > 1.39999997615814)
                        {
                            this.m_pots[this.m_curSelectedPot].startAnim(225, 16);
                            this.m_selectedPotState = 2;
                        }
                    }
                }
                for (int index = 0; index < this.m_cookingPotCount; ++index)
                {
                    this.m_pots[index].updateAnim(timeStep);
                    this.m_potHeats[index] += this.m_potHeatSpeeds[index] * ((float)timeStep / 1000f);
                    int num = midp.JMath.max(0, (int)(256.0 - (double)this.m_potHeats[index] / 100.0 * 256.0));
                    int defaultColor = -65536 | num << 8 | num;
                    ModelManager.applyDefaultColor(this.m_pots[index].getNode(), defaultColor);
                    if ((double)this.m_potHeats[index] >= 65.0)
                        this.m_minigameTipId = 1578;
                    if (num == 0)
                    {
                        this.m_minigameTipId = 1579;
                        this.stateTransitionMiniGame(6);
                        break;
                    }
                }
            }
        }
    }

    private void selectPot(int pot)
    {
        if (pot >= this.m_cookingPotCount || pot == this.m_curSelectedPot)
            pot = -1;
        if (this.m_curSelectedPot != -1)
        {
            this.m_prevSelectedPot = this.m_curSelectedPot;
            this.m_pots[this.m_prevSelectedPot].startAnim(226, 16);
            this.m_curSelectedPot = pot;
            this.m_selectedPotState = 0;
        }
        else
        {
            this.m_curSelectedPot = pot;
            if (this.m_curSelectedPot == -1)
                return;
            this.m_pots[this.m_curSelectedPot].startAnim(224, 16);
            this.m_selectedPotState = 1;
        }
    }

    private void beginMiniGameFishing()
    {
        AppEngine engine = this.m_engine;
        AppEngine.ASSERT(true, "fishy fish");
        AppEngine.ASSERT(true, "fishy fish");
        AppEngine.ASSERT(true, "fishy fish");
        AppEngine.ASSERT(true, "fishy fish");
        this.m_miniGameTargetObject.hide();
        int num1 = 29;
        int skillRank = this.m_simData.getSkillRank(1);
        switch (skillRank)
        {
            case 0:
                this.m_fishingFishType = num1;
                float num2 = 0.0f;
                float num3 = 0.0f;
                int modelId = 0;
                switch (this.m_fishingFishType)
                {
                    case 29:
                        num2 = 0.5f;
                        num3 = 0.5f;
                        modelId = 52;
                        break;
                    case 30:
                        num2 = 0.6f;
                        num3 = 0.4f;
                        modelId = 51;
                        break;
                    case 31:
                        num2 = 0.7f;
                        num3 = 0.3f;
                        modelId = 52;
                        break;
                    case 32:
                        num2 = 0.8f;
                        num3 = 0.2f;
                        modelId = 54;
                        break;
                    case 33:
                        num2 = 1f;
                        num3 = 0.2f;
                        modelId = 53;
                        break;
                    default:
                        AppEngine.ASSERT(false, "invalid fish type");
                        break;
                }
                this.m_fishingFishSpeed = num2;
                this.m_fishingMinFishMove = num3;
                this.m_fishingLevel = 0.0f;
                this.m_fishingFishPos = (float)this.m_engine.rand(0, 65536) / 65536f;
                this.fishPickNewDest();
                int facingAngle = MapObject.getFacingAngle(this.m_playerSim.getFacingDir());
                m3g.Node model1 = ModelManager.getInstance().getModel(modelId);
                model1.setTranslation((float)this.m_playerSim.getPosX() / 65536f, (float)this.m_playerSim.getPosY() / 65536f, (float)this.m_playerSim.getPosZ() / 65536f);
                model1.setOrientation((float)facingAngle / 65536f, 0.0f, 1f, 0.0f);
                ModelManager.applyTintColor(model1, this.m_simWorld.getDayNightTint());
                this.m_miniGameFish.setNode(model1);
                this.m_miniGameFish.startAnim(233, 20);
                m3g.Node model2 = ModelManager.getInstance().getModel(55);
                model2.setTranslation((float)this.m_playerSim.getPosX() / 65536f, (float)this.m_playerSim.getPosY() / 65536f, (float)this.m_playerSim.getPosZ() / 65536f);
                model2.setOrientation((float)facingAngle / 65536f, 0.0f, 1f, 0.0f);
                ModelManager.applyTintColor(model2, this.m_simWorld.getDayNightTint());
                this.m_miniGameFishingRod.setNode(model2);
                this.m_miniGameFishingRod.startAnim(228, 16);
                this.m_minigameTipId = 1574;
                this.m_minigameSoundTimeMin = 4000;
                this.m_minigameSoundTimeMax = 7000;
                this.m_minigameAmbSound = 75;
                break;
            case 1:
                num1 = engine.rand(29, 30);
                goto case 0;
            case 2:
                num1 = engine.rand(29, 31);
                goto case 0;
            case 3:
                num1 = engine.rand(29, 32);
                goto case 0;
            case 4:
            case 5:
                num1 = engine.rand(29, 33);
                if (skillRank == 5 && num1 < 30)
                {
                    num1 = engine.rand(29, 33);
                    goto case 0;
                }
                else
                    goto case 0;
            default:
                AppEngine.ASSERT(false, "invalid skill rank");
                goto case 0;
        }
    }

    private void renderMiniGameFishing(Graphics g)
    {
        if (this.m_miniGameState != 1 || (double)this.m_fishingLevel < 1.0)
            return;
        AnimationManager2D animationManager2D = this.m_engine.getAnimationManager2D();
        int num = (int)(400.0 + 100.0 * -(double)this.m_fishingFishPos);
        animationManager2D.submitAnim(34, (float)num, 120f, this.m_fishFlasherAlpha);
        animationManager2D.flushAnims(g);
    }

    private void updateMiniGameFishing(int timeStep)
    {
        switch (this.m_miniGameState)
        {
            case 1:
                this.m_playerSim.getModel(1)?.getAnimPlayer3D().updateAnim(timeStep);
                Accelerometer staticAccelerometer = Accelerometer.getStaticAccelerometer();
                float x1 = -1f;
                float y1 = -1f;
                float z1 = -1f;
                staticAccelerometer.getXYZ(ref x1, ref y1, ref z1);
                float num1 = midp.JMath.sqrt((float)((double)x1 * (double)x1 + (double)y1 * (double)y1 + (double)z1 * (double)z1));
                x1 /= num1;
                y1 /= num1;
                float num2 = z1 / num1;
                this.m_miniGameFishingTilt = midp.JMath.max(0.0f, midp.JMath.min(50f, (1.570796f - midp.JMath.acos(y1)) * 57.29578f / 2f + 25f)) / 25f - 1f;
                float t = (float)(((double)this.m_miniGameFishingTilt + 1.0) / 2.0);
                this.m_playerSim.setAnim3DTime(t);
                this.m_miniGameFishingRod.setAnimTime((int)((double)this.m_miniGameFishingRod.getAnimDuration() * (double)t));
                int num3 = (int)((double)this.m_miniGameFishingTilt * 15.0);
                if (this.m_playerSim.getFacingDir() == 3 || this.m_playerSim.getFacingDir() == 2)
                {
                    int num4 = num3 - 90;
                }
                float num5 = this.fishInZone() ? 0.3f : -0.2f;
                this.m_fishingLevel += num5 * ((float)timeStep / 1000f);
                this.m_minigameTipId = (double)num5 <= 0.0 ? 1574 : 1575;
                if ((double)this.m_fishingLevel >= 1.0)
                {
                    this.m_minigameTipId = 1576;
                    this.m_fishFlasherAlpha += this.m_fishFlasherAlphaStep * ((float)timeStep / 1000f);
                    if ((double)this.m_fishFlasherAlpha >= 1.0 || (double)this.m_fishFlasherAlpha <= 0.0)
                    {
                        this.m_fishFlasherAlpha = midp.JMath.max(0.0f, midp.JMath.min(1f, this.m_fishFlasherAlpha));
                        this.m_fishFlasherAlphaStep = -this.m_fishFlasherAlphaStep;
                    }
                }
                else
                {
                    if ((double)this.m_fishingLevel <= -0.5)
                    {
                        this.m_fishingLevel = -0.5f;
                        this.stateTransitionMiniGame(8);
                        return;
                    }
                    this.m_fishFlasherAlpha = 0.0f;
                    this.m_fishFlasherAlphaStep = 3f;
                }
                float x2 = -1f;
                float y2 = -1f;
                float z2 = -1f;
                staticAccelerometer.getRawXYZ(ref x2, ref y2, ref z2);
                if ((double)midp.JMath.sqrt((float)((double)x2 * (double)x2 + (double)y2 * (double)y2 + (double)z2 * (double)z2)) > 2.0)
                {
                    this.m_fishingLevel = (double)this.m_fishingLevel < 1.0 ? -0.5f : 1f;
                    this.stateTransitionMiniGame(8);
                    return;
                }
                if ((double)this.m_fishingLevel > -0.5 && (double)this.m_fishingLevel < 1.0)
                {
                    bool flag = (double)this.m_fishingFishPosTo < (double)this.m_fishingFishPosFrom;
                    this.m_fishingFishPos += this.m_fishingFishSpeed * ((flag ? (float)-timeStep : (float)timeStep) / 1000f);
                    if (flag && (double)this.m_fishingFishPos < (double)this.m_fishingFishPosTo || !flag && (double)this.m_fishingFishPos > (double)this.m_fishingFishPosTo)
                    {
                        this.m_fishingFishPos = this.m_fishingFishPosTo;
                        this.fishPickNewDest();
                    }
                    float num6 = (this.m_fishingFishPos - 1f) * 50f;
                    float num7 = 0.0f;
                    float num8 = 0.0f;
                    if (this.m_playerSim.getFacingDir() == 3 || this.m_playerSim.getFacingDir() == 2)
                        num8 = num6;
                    else
                        num7 = num6;
                    this.m_miniGameFish.getNode().setTranslation((float)this.m_playerSim.getPosX() / 65536f + num7, (float)this.m_playerSim.getPosY() / 65536f, (float)this.m_playerSim.getPosZ() / 65536f + num8);
                    break;
                }
                break;
            case 7:
                this.m_miniGameFishingRod.updateAnim(timeStep);
                if (this.m_playerSim.isAnimating3D())
                    return;
                this.stateTransitionMiniGame(1);
                this.m_playerSim.setSubAppearance(63);
                this.m_playerSim.setAnim3DTime(0.5f);
                this.m_miniGameFishingRod.startAnim(229, 20);
                this.m_miniGameFishingRod.setAnimTime(this.m_miniGameFishingRod.getAnimDuration() >> 1);
                this.m_simWorld.addObjectNode(this.m_miniGameFish.getNode());
                return;
            case 8:
                this.m_miniGameFishingRod.updateAnim(timeStep);
                if (!this.m_playerSim.isAnimating3D())
                {
                    this.stateTransitionMiniGame(this.fishingSuccess() ? 2 : 3);
                    this.cleanupFishingMiniGame();
                    break;
                }
                break;
        }
        this.m_miniGameFish.updateAnim(timeStep);
    }

    private bool fishingSuccess()
    {
        return (double)this.m_fishingLevel == 1.0;
    }

    private bool fishInZone()
    {
        return (double)midp.JMath.abs(this.m_fishingFishPos / 2f - (float)((1.0 + (double)this.m_miniGameFishingTilt) / 2.0)) < 0.180000007152557;
    }

    private void fishPickNewDest()
    {
        float fishingFishPos = this.m_fishingFishPos;
        float num = (float)this.m_engine.rand((int)this.m_fishingMinFishMove, (int)midp.JMath.max(fishingFishPos, 2f - fishingFishPos));
        bool flag = (double)fishingFishPos > 2.0 - (double)num || (double)fishingFishPos >= (double)num && this.m_engine.randPercent() < 50;
        this.m_fishingFishPosFrom = fishingFishPos;
        this.m_fishingFishPosTo = fishingFishPos + (flag ? -num : num);
    }

    private void cleanupFishingMiniGame()
    {
        this.m_simWorld.removeObjectNode(this.m_miniGameFish.getNode());
        this.m_simWorld.removeObjectNode(this.m_miniGameFishingRod.getNode());
        this.m_minigameAmbSound = -1;
    }

    private void processInputMiniGameFishing(int keyCode, int commandKey)
    {
    }

    public bool isRepairing()
    {
        return this.m_state == 16 && this.m_miniGameType == 2;
    }

    public bool isCooking()
    {
        return this.m_state == 16 && this.m_miniGameType == 0;
    }

    private void readRepairData()
    {
        AppEngine.getResourceManager();
        DataInputStream dataInputStream = new DataInputStream(ResourceManager.loadBinaryFile(56));
        int length1 = (int)dataInputStream.readByte();
        this.m_repairDataSkills = new int[length1];
        this.m_repairDataJoints = new int[length1][];
        this.m_repairDataComponents = new int[length1][];
        this.m_repairDataConnections = new int[length1][];
        int[] numArray = new int[6];
        for (int index1 = 0; index1 < length1; ++index1)
        {
            int index2 = dataInputStream.readInt();
            this.m_repairDataSkills[index1] = index2;
            ++numArray[index2];
            int length2 = (int)dataInputStream.readByte();
            this.m_repairDataJoints[index1] = new int[length2];
            this.m_repairDataComponents[index1] = new int[length2];
            for (int index3 = 0; index3 < length2; ++index3)
            {
                this.m_repairDataJoints[index1][index3] = (int)dataInputStream.readShort();
                this.m_repairDataComponents[index1][index3] = (int)dataInputStream.readShort();
            }
            int length3 = (int)dataInputStream.readByte();
            this.m_repairDataConnections[index1] = new int[length3];
            for (int index3 = 0; index3 < length3; ++index3)
                this.m_repairDataConnections[index1][index3] = (int)dataInputStream.readShort();
        }
        this.m_repairDataSkillIndices = new int[6][];
        int length4 = 0;
        for (int index1 = 0; index1 < 6; ++index1)
        {
            length4 += numArray[index1];
            this.m_repairDataSkillIndices[index1] = new int[length4];
            int index2 = 0;
            for (int index3 = 0; index3 < length1; ++index3)
            {
                if (this.m_repairDataSkills[index3] <= index1)
                {
                    this.m_repairDataSkillIndices[index1][index2] = index1;
                    ++index2;
                }
            }
        }
    }

    private void buildBoard(int idx)
    {
        m3g.Node model1 = ModelManager.getInstance().getModel(47);
        m3g.Node model2 = ModelManager.getInstance().getModel(46);
        m3g.Node model3 = ModelManager.getInstance().getModel(50);
        m3g.Node model4 = ModelManager.getInstance().getModel(49);
        m3g.Node model5 = ModelManager.getInstance().getModel(30);
        m3g.Node model6 = ModelManager.getInstance().getModel(29);
        m3g.Node model7 = ModelManager.getInstance().getModel(48);
        Group group1 = Group.m3g_cast((Object3D)this.m_repairBoard.getNode());
        m3g.Node.m3g_cast(group1.find(4100)).setRenderingEnable(false);
        m3g.Node.m3g_cast(group1.find(4101)).setRenderingEnable(false);
        m3g.Node.m3g_cast(group1.find(4102)).setRenderingEnable(false);
        m3g.Node.m3g_cast(group1.find(4103)).setRenderingEnable(false);
        m3g.Node.m3g_cast(group1.find(4104)).setRenderingEnable(false);
        m3g.Node.m3g_cast(group1.find(4105)).setRenderingEnable(false);
        m3g.Node.m3g_cast(group1.find(4106)).setRenderingEnable(false);
        m3g.Node.m3g_cast(group1.find(4107)).setRenderingEnable(false);
        m3g.Node.m3g_cast(group1.find(4108)).setRenderingEnable(false);
        m3g.Node.m3g_cast(group1.find(4109)).setRenderingEnable(false);
        m3g.Node.m3g_cast(group1.find(4110)).setRenderingEnable(false);
        m3g.Node.m3g_cast(group1.find(4111)).setRenderingEnable(false);
        m3g.Node.m3g_cast(group1.find(4112)).setRenderingEnable(false);
        m3g.Node.m3g_cast(group1.find(4113)).setRenderingEnable(false);
        int[] repairDataJoint = this.m_repairDataJoints[idx];
        int[] repairDataComponent = this.m_repairDataComponents[idx];
        int[] repairDataConnection = this.m_repairDataConnections[idx];
        int length1 = repairDataComponent.Length;
        this.m_repairNumComponentsSlots = length1 + 3;
        this.m_repairComponentTypes = new int[this.m_repairNumComponentsSlots];
        this.m_repairComponentStates = new int[this.m_repairNumComponentsSlots];
        for (int index = 0; index < length1; ++index)
        {
            this.m_repairComponentTypes[index] = GlobalConstants.REPAIR_SYMBOL_LOOKUPS[repairDataComponent[index]];
            this.m_repairComponentStates[index] = 2;
        }
        this.m_repairComponentTypes[length1] = 1;
        this.m_repairComponentStates[length1] = 1;
        this.m_repairComponentTypes[length1 + 1] = 2;
        this.m_repairComponentStates[length1 + 1] = 1;
        this.m_repairComponentTypes[length1 + 2] = 3;
        this.m_repairComponentStates[length1 + 2] = 1;
        this.m_repairNumBrokenComponents = length1;
        this.m_repairComponentLocations = new int[this.m_repairNumComponentsSlots][];
        this.m_repairComponents = new m3g.Node[this.m_repairNumComponentsSlots];
        this.m_repairComponentJoints = new int[this.m_repairNumComponentsSlots];
        this.m_repairComponentJointNodes = new m3g.Node[this.m_repairNumComponentsSlots];
        this.m_repairBoardSparks = new AnimPlayer3D[this.m_repairNumBrokenComponents];
        for (int index = 0; index < length1; ++index)
        {
            int num1 = GlobalConstants.REPAIR_SYMBOL_LOOKUPS[repairDataJoint[index]];
            int num2 = GlobalConstants.REPAIR_SYMBOL_LOOKUPS[repairDataComponent[index]];
            Group group2 = Group.m3g_cast(group1.find(num1));
            this.m_repairComponentJoints[index] = num1;
            this.m_repairComponentJointNodes[index] = (m3g.Node)group2;
            m3g.Node node = (m3g.Node)null;
            switch (num2)
            {
                case 1:
                    node = model3;
                    break;
                case 2:
                    node = model1;
                    break;
                case 3:
                    node = model5;
                    break;
            }
            this.m_repairComponents[index] = (m3g.Node)node.duplicate();
            group2.addChild(this.m_repairComponents[index]);
            this.m_repairComponentLocations[index] = new int[2];
            this.getScreenSpace(this.m_repairComponentLocations[index], num1);
            this.m_repairBoardSparks[index] = new AnimPlayer3D(this.m_engine.getAnimationManager3D());
            this.m_repairBoardSparks[index].setNode((m3g.Node)model7.duplicate());
            this.m_repairBoardSparks[index].startAnim(237, 20);
            group2.addChild(this.m_repairBoardSparks[index].getNode());
        }
        int index1 = length1;
        Group group3 = Group.m3g_cast(group1.find(4008));
        this.m_repairComponents[index1] = (m3g.Node)model4.duplicate();
        this.m_repairComponentJoints[index1] = 4008;
        this.m_repairComponentJointNodes[index1] = (m3g.Node)group3;
        group3.addChild(this.m_repairComponents[index1]);
        this.m_repairComponentLocations[index1] = new int[2];
        this.getScreenSpace(this.m_repairComponentLocations[index1], 4008);
        Group group4 = Group.m3g_cast(group1.find(4009));
        this.m_repairComponents[index1 + 1] = (m3g.Node)model2.duplicate();
        this.m_repairComponentJoints[index1 + 1] = 4009;
        this.m_repairComponentJointNodes[index1 + 1] = (m3g.Node)group4;
        group4.addChild(this.m_repairComponents[index1 + 1]);
        this.m_repairComponentLocations[index1 + 1] = new int[2];
        this.getScreenSpace(this.m_repairComponentLocations[index1 + 1], 4009);
        Group group5 = Group.m3g_cast(group1.find(4010));
        this.m_repairComponents[index1 + 2] = (m3g.Node)model6.duplicate();
        this.m_repairComponentJoints[index1 + 2] = 4010;
        this.m_repairComponentJointNodes[index1 + 2] = (m3g.Node)group5;
        group5.addChild(this.m_repairComponents[index1 + 2]);
        this.m_repairComponentLocations[index1 + 2] = new int[2];
        this.getScreenSpace(this.m_repairComponentLocations[index1 + 2], 4010);
        int length2 = repairDataConnection.Length;
        this.m_repairBoardCircuits = new AnimPlayer3D[length2];
        for (int index2 = 0; index2 < length2; ++index2)
        {
            int num = GlobalConstants.REPAIR_SYMBOL_LOOKUPS[repairDataConnection[index2]];
            m3g.Node.m3g_cast(group1.find(num)).setRenderingEnable(true);
            Group group2 = Group.m3g_cast((Object3D)this.getRepairCircuitAnimModel(num));
            group2.setTranslation(this.m_simWorld.getCameraPosX(), this.m_simWorld.getCameraPosY(), this.m_simWorld.getCameraPosZ());
            group2.setRenderingEnable(false);
            this.m_simWorld.addObjectNode((m3g.Node)group2);
            this.m_repairBoardCircuits[index2] = new AnimPlayer3D(this.m_engine.getAnimationManager3D());
            this.m_repairBoardCircuits[index2].setNode((m3g.Node)group2);
        }
    }

    private m3g.Node getRepairCircuitAnimModel(int connectionName)
    {
        int modelId = -1;
        switch (connectionName)
        {
            case 4100:
                modelId = 31;
                break;
            case 4101:
                modelId = 32;
                break;
            case 4102:
                modelId = 33;
                break;
            case 4103:
                modelId = 34;
                break;
            case 4104:
                modelId = 35;
                break;
            case 4105:
                modelId = 36;
                break;
            case 4106:
                modelId = 37;
                break;
            case 4107:
                modelId = 38;
                break;
            case 4108:
                modelId = 39;
                break;
            case 4109:
                modelId = 40;
                break;
            case 4110:
                modelId = 41;
                break;
            case 4111:
                modelId = 42;
                break;
            case 4112:
                modelId = 43;
                break;
            case 4113:
                modelId = 44;
                break;
        }
        return ModelManager.getInstance().getModel(modelId);
    }

    private void beginMiniGameRepairing()
    {
        int skillRank = this.m_simData.getSkillRank(2);
        this.m_repairBoard = new Model();
        this.m_repairBoard.assembleObject(45);
        this.m_repairBoard.getNode().setTranslation(this.m_simWorld.getCameraPosX(), this.m_simWorld.getCameraPosY(), this.m_simWorld.getCameraPosZ());
        this.m_simWorld.addObjectNode(this.m_repairBoard.getNode());
        this.buildBoard(this.m_engine.rand(0, this.m_repairDataSkillIndices[skillRank].Length - 1));
        this.m_miniGameTimerMax = 30000;
        this.m_repairNumReplacedComponents = 0;
        this.m_repairDragTarget = -1;
        this.m_repairBoardAnimPlayer = new AnimPlayer3D(this.m_engine.getAnimationManager3D());
        this.m_repairBoardAnimPlayer.setNode(this.m_repairBoard.getNode());
        this.m_repairBoardAnimPlayer.startAnim(234, 20);
        this.m_minigameTipId = 1580;
        this.m_preRepairColor = this.m_simWorld.getBackgroundColor();
        this.m_simWorld.setBackgroundColor(9222898);
    }

    private void cleanupRepairingMiniGame()
    {
        for (int index = 0; index < this.m_repairBoardCircuits.Length; ++index)
        {
            this.m_simWorld.removeObjectNode(this.m_repairBoardCircuits[index].getNode());
            this.m_repairBoardCircuits[index].Dispose();
        }
        this.m_repairBoardAnimPlayer.Dispose();
        for (int index = 0; index < this.m_repairBoardSparks.Length; ++index)
            this.m_repairBoardSparks[index].Dispose();
        this.m_repairBoard.unload();
        this.m_repairBoard.Dispose();
        this.m_simWorld.setBackgroundColor(this.m_preRepairColor);
    }

    private void renderMiniGameRepairing(Graphics g)
    {
    }

    private void updateMiniGameRepairing(int timeStep)
    {
        this.m_repairBoardAnimPlayer.updateAnim(timeStep);
        for (int index = 0; index < this.m_repairBoardSparks.Length; ++index)
            this.m_repairBoardSparks[index].updateAnim(timeStep);
        if (this.m_miniGameState == 11)
        {
            for (int index = 0; index < this.m_repairBoardCircuits.Length; ++index)
                this.m_repairBoardCircuits[index].updateAnim(timeStep);
            this.m_repairOutroTimer -= timeStep;
            if (this.m_repairOutroTimer > 0)
                return;
            this.stateTransitionMiniGame(2);
        }
        else if (this.m_miniGameState == 12)
        {
            this.stateTransitionMiniGame(3);
        }
        else
        {
            this.m_miniGameTimer += timeStep;
            if (this.m_miniGameTimer <= this.m_miniGameTimerMax)
                return;
            this.m_engine.vibrate();
            this.stateTransitionMiniGame(12);
        }
    }

    private void getScreenSpace(int[] outScreenCoords, int nodeId)
    {
        int[] result1 = new int[3];
        int[] result2 = new int[3];
        this.m_repairBoard.getLocatorPos(result1, nodeId);
        this.m_simWorld.coordWorldToScreen(result2, result1[0], result1[1], result1[2]);
        int num1 = result2[0];
        int num2 = result2[1];
        outScreenCoords[0] = num1;
        outScreenCoords[1] = num2;
    }

    private int repairPickComponentIdx(int pointerX, int pointerY)
    {
        for (int index = 0; index < this.m_repairNumComponentsSlots; ++index)
        {
            int centerX = this.m_repairComponentLocations[index][0];
            int centerY = this.m_repairComponentLocations[index][1];
            if (UIElement.isInRadius(pointerX, pointerY, centerX, centerY, 35))
                return index;
        }
        return -1;
    }

    private void repairPickObject(int pointerX, int pointerY)
    {
        int index = this.repairPickComponentIdx(pointerX, pointerY);
        if (index == -1 || this.m_repairComponentStates[index] == 0 || this.m_repairComponentStates[index] == 3)
            return;
        this.m_repairDragTarget = index;
    }

    private void setRepairTargetPosition(int pointerEndX, int pointerEndY)
    {
        int[] p0F = new int[3];
        int[] pnF = new int[3];
        int[] resultF = new int[4];
        p0F[0] = (int)((double)this.m_simWorld.getCameraPosX() * 65536.0);
        p0F[1] = (int)((double)this.m_simWorld.getCameraPosY() * 65536.0);
        p0F[2] = (int)((double)this.m_simWorld.getCameraPosZ() * 65536.0);
        pnF[0] = 0;
        pnF[1] = 1;
        pnF[2] = 0;
        this.m_simWorld.coordScreenToWorldPlane(resultF, p0F, pnF, pointerEndX, pointerEndY);
        m3g.Node componentJointNode = this.m_repairComponentJointNodes[this.m_repairDragTarget];
        int[] result = new int[3];
        this.m_repairBoard.getLocatorPos(result, componentJointNode);
        Transform transform = new Transform();
        this.m_simWorld.getWorldNode().getTransformTo(componentJointNode, ref transform);
        int[] vector = new int[4]
        {
      result[0] - resultF[0],
      result[1] - resultF[1],
      result[2] - resultF[2],
      0
        };
        transform.transformx(ref vector);
        this.m_repairComponents[this.m_repairDragTarget].setTranslationx(-vector[0], vector[1], -vector[2]);
    }

    private bool isOverBin(int pointerX, int pointerY)
    {
        int num1 = this.m_engine.getWidth() - 80;
        int num2 = this.m_engine.getHeight() - 120;
        return pointerX > num1 && pointerY > num2;
    }

    private void destroyBrokenComponent()
    {
        Group componentJointNode = (Group)this.m_repairComponentJointNodes[this.m_repairDragTarget];
        componentJointNode.removeChild(this.m_repairComponents[this.m_repairDragTarget]);
        componentJointNode.removeChild(this.m_repairBoardSparks[this.m_repairDragTarget].getNode());
        this.m_repairComponentStates[this.m_repairDragTarget] = 0;
        this.m_repairComponents[this.m_repairDragTarget] = (m3g.Node)null;
        this.m_repairBoardSparks[this.m_repairDragTarget].setAnimating(false);
        this.m_minigameTipId = 1581;
    }

    private int getComponentGapType(int pointerX, int pointerY)
    {
        int index = this.repairPickComponentIdx(pointerX, pointerY);
        return index != -1 && this.m_repairComponentStates[index] == 0 ? this.m_repairComponentTypes[index] : 0;
    }

    private void replaceComponent(int pointerX, int pointerY)
    {
        int index = this.repairPickComponentIdx(pointerX, pointerY);
        this.m_repairComponents[this.m_repairDragTarget].setTranslation(0.0f, 0.0f, 0.0f);
        ((Group)this.m_repairComponentJointNodes[index]).addChild((m3g.Node)this.m_repairComponents[this.m_repairDragTarget].duplicate());
        this.m_repairComponentStates[index] = 3;
        ++this.m_repairNumReplacedComponents;
        if (this.m_repairNumReplacedComponents != this.m_repairNumBrokenComponents)
            return;
        this.stateTransitionMiniGame(11);
    }

    public int shoppingListSize()
    {
        return this.m_shoppingList.Length;
    }

    public int shoppingListItem(int i)
    {
        return this.m_shoppingList[i][0];
    }

    public int shoppingListQty(int i)
    {
        return this.m_shoppingList[i][1];
    }

    public int getShoppingObjectType()
    {
        return this.m_shoppingObjectType;
    }

    public void openShop(MapObject shopObject)
    {
        int type = shopObject.getType();
        if (type == 155 && !this.m_engine.isBonusUnlocked())
        {
            this.showMessageBox(1185, 1184);
        }
        else
        {
            if (type == 158)
                this.showTutorialMessage(33);
            this.m_shoppingObjectType = type;
            this.stateTransition(17);
            this.stateTransitionShopping(0);
        }
    }

    private void stateTransitionShopping(int state)
    {
        int shoppingState = this.m_shoppingState;
        this.m_shoppingState = state;
        AppEngine engine = this.m_engine;
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        TextManager textManager = engine.getTextManager();
        switch (state)
        {
            case -1:
                if (shoppingState == 0)
                    SpywareManager.getInstance().trackStoreClose();
                this.stateTransition(6);
                break;
            case 0:
                if (shoppingState != -1)
                    break;
                SpywareManager.getInstance().trackStoreOpen(GlobalConstants.LOOKUP_OBJECT[this.m_shoppingObjectType]);
                this.initListShopping();
                break;
            case 1:
                this.prepareMessageBox(1562, 1561);
                this.showTutorialMessage(29);
                this.checkTriggers();
                break;
            case 2:
                this.prepareMessageBox(1564, 1563);
                break;
            case 3:
                int lineWidth = (int)animationManager2D.getAnimWidth(97) - 40;
                textManager.wrapString(1565, 3, lineWidth);
                int length = 0;
                for (int index = 0; index < this.m_shoppingBasketQtys.Length; ++index)
                {
                    int shoppingBasketItemId = this.m_shoppingBasketItemIds[index];
                    if (this.m_shoppingBasketQtys[index] != this.m_simData.getInventoryCount(shoppingBasketItemId))
                        ++length;
                }
                this.m_shoppingList = new int[length][];
                int index1 = 0;
                for (int index2 = 0; index2 < this.m_shoppingBasketQtys.Length; ++index2)
                {
                    int shoppingBasketItemId = this.m_shoppingBasketItemIds[index2];
                    int shoppingBasketQty = this.m_shoppingBasketQtys[index2];
                    int inventoryCount = this.m_simData.getInventoryCount(shoppingBasketItemId);
                    if (shoppingBasketQty != inventoryCount)
                    {
                        this.m_shoppingList[index1] = new int[2];
                        this.m_shoppingList[index1][0] = shoppingBasketItemId;
                        this.m_shoppingList[index1][1] = shoppingBasketQty - inventoryCount;
                        ++index1;
                    }
                }
                this.getUIList(9).initList();
                break;
        }
    }

    private void renderShopping(Graphics g)
    {
        switch (this.m_shoppingState)
        {
            case 0:
                this.m_simWorld.renderWorld(g);
                this.renderShoppingBrowseMenu(g);
                break;
            case 1:
            case 2:
                this.m_simWorld.renderWorld(g);
                this.renderShoppingBrowseMenu(g);
                this.m_engine.renderBackgroundDim(g);
                this.drawGenericMessageBox(g);
                break;
            case 3:
                this.m_simWorld.renderWorld(g);
                this.renderShoppingConfirm(g);
                break;
        }
    }

    private void renderShoppingBrowseMenu(Graphics g)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        bool enabled = this.m_shoppingState == 0 && !this.m_tutorialMessageActive;
        int width = engine.getWidth();
        int height = engine.getHeight();
        int num1 = width - 330 + 40;
        animationManager2D.submitAnimGrid(321, 322, 323, 324, 325, 326, 327, 328, 329, (float)num1, 0.0f, 330f, (float)height);
        int num2 = num1 + 45;
        int num3 = width - num2 - 8;
        int num4 = height - 14 - 100;
        animationManager2D.submitAnimGrid(331, 332, 333, 334, 335, 336, 337, 338, 339, (float)num2, 14f, (float)num3, (float)num4);
        int num5 = textManager.getLineHeight(3) + 30;
        int num6 = 14 + num4 + 3;
        int num7 = num2;
        int num8 = num3 - 60;
        int x1 = num7 + num8 - 20;
        animationManager2D.submitAnimGrid(331, 332, 333, 334, 335, 336, 337, 338, 339, (float)num7, (float)num6, (float)num8, (float)num5);
        int x2 = width - 40;
        int y1 = num6 + (num5 >> 1);
        UIButton uiButton1 = this.getUIButton(32);
        animationManager2D.submitAnim(330, (float)x2, (float)y1);
        uiButton1.submit(ref animationManager2D, x2, y1, enabled);
        int num9 = textManager.getLineHeight(3) + 20;
        int num10 = num6 + num5 + 3;
        int num11 = num2 + (num3 >> 1) - 30;
        int num12 = 30 + (num3 >> 1);
        this.SLIDE_BAR_X = num11 + 20;
        this.SLIDE_BAR_Y = num10 + (num9 >> 1);
        this.SLIDE_BAR_WIDTH = 100;
        animationManager2D.submitAnimGrid(331, 332, 333, 334, 335, 336, 337, 338, 339, (float)num11, (float)num10, (float)num12, (float)num9);
        g.setColor(1384261);
        g.Begin();
        g.fillRect(35, 5, 210, 55);
        g.End();
        animationManager2D.submitAnimHBar(365, 365, 366, 120f, 32f, 190f, 1f);
        UIButton uiButton2 = this.getUIButton(524288);
        animationManager2D.submitAnim(330, 32f, 32f);
        uiButton2.submit(ref animationManager2D, 32, 32, enabled);
        this.renderShoppingMoney(g);
        animationManager2D.flushAnims(g);
        int lineHeight = textManager.getLineHeight(3);
        int num13 = lineHeight * 3 + 6;
        int y2 = height - 100 - num13;
        int x3 = num2 + 30;
        int x4 = num2 + num3 - 30;
        UIList uiList = this.getUIList(7);
        uiList.setup(num2 + 2, 19, num3 - 4, num4 - 10 - num13);
        uiList.render(g);
        g.Begin();
        textManager.drawString(g, 1076, 3, x3, y2, 9);
        textManager.drawString(g, 1077, 3, x3, y2 + lineHeight, 9);
        textManager.drawString(g, 1080, 3, x3, y2 + (lineHeight << 1), 9);
        int itemNthItem = this.m_simWorld.getItemNthItem(this.m_shoppingObjectType, uiList.getSelectedIdx());
        int inventoryCount = this.m_simData.getInventoryCount(itemNthItem);
        int itemBuyPrice = this.m_simWorld.getItemBuyPrice(itemNthItem);
        int itemSellPrice = this.m_simWorld.getItemSellPrice(itemNthItem);
        StringBuffer strBuffer1 = textManager.clearStringBuffer();
        textManager.appendMoneyToBuffer(itemBuyPrice);
        textManager.drawString(g, strBuffer1, 3, x4, y2, 33);
        StringBuffer strBuffer2 = textManager.clearStringBuffer();
        textManager.appendMoneyToBuffer(itemSellPrice);
        textManager.drawString(g, strBuffer2, 3, x4, y2 + lineHeight, 33);
        StringBuffer strBuffer3 = textManager.clearStringBuffer();
        textManager.appendIntToBuffer(inventoryCount);
        textManager.drawString(g, strBuffer3, 3, x4, y2 + (lineHeight << 1), 33);
        textManager.drawString(g, 1079, 3, num7 + 20, num6 + 15, 9);
        StringBuffer strBuffer4 = textManager.clearStringBuffer();
        textManager.appendMoneyToBuffer(this.m_shoppingTally);
        textManager.drawString(g, strBuffer4, 3, x1, num6 + 15, 33);
        textManager.drawString(g, 1081, 3, num11 + num12 - 21, this.SLIDE_BAR_Y, 34);
        textManager.drawString(g, this.m_simWorld.getObjectStringId(this.m_shoppingObjectType), 3, 120, 32, 18);
        g.End();
        animationManager2D.submitAnim(378, 295f, (float)this.SLIDE_BAR_Y, 1f, 1f, 1f, 90f);
        animationManager2D.flushAnims(g);
        if (this.m_shoppingTimeSinceLastMinusPress < 200)
            animationManager2D.submitAnim(120, 258f, 285f, 0.5f, 0.7f, 0.7f);
        if (this.m_shoppingTimeSinceLastPlusPress < 200)
            animationManager2D.submitAnim(120, 333f, 285f, 0.5f, 0.7f, 0.7f);
        animationManager2D.flushAnims(g);
    }

    private void renderShoppingMoney(Graphics g)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        int num = engine.getHeight() - 20;
        animationManager2D.submitAnim(358, 60f, (float)num);
        animationManager2D.flushAnims(g);
        StringBuffer strBuffer = textManager.clearStringBuffer();
        textManager.appendMoneyToBuffer(this.m_simData.getMoney());
        g.Begin();
        textManager.drawString(g, strBuffer, 3, 50, num + 2, 18);
        g.End();
    }

    private void renderShoppingConfirm(Graphics g)
    {
        AppEngine engine = this.m_engine;
        SimWorld simWorld = this.m_simWorld;
        SimData simData = this.m_simData;
        TextManager textManager = engine.getTextManager();
        AnimationManager2D animationManager2D = engine.getAnimationManager2D();
        int height = engine.getHeight();
        int width = engine.getWidth();
        int num1 = 0;
        for (int index = 0; index < this.m_shoppingBasketQtys.Length; ++index)
        {
            int shoppingBasketItemId = this.m_shoppingBasketItemIds[index];
            int inventoryCount = simData.getInventoryCount(shoppingBasketItemId);
            int num2 = this.m_shoppingBasketQtys[index] - inventoryCount;
            if (num2 > 0)
                num1 += simWorld.getItemBuyPrice(shoppingBasketItemId) * num2;
            else if (num2 < 0)
                num1 -= simWorld.getItemSellPrice(shoppingBasketItemId) * -num2;
        }
        int lineHeight = textManager.getLineHeight(3);
        int num3 = textManager.getNumWrappedLines() * lineHeight;
        int num4 = lineHeight;
        int animHeight1 = (int)animationManager2D.getAnimHeight(96);
        int animHeight2 = (int)animationManager2D.getAnimHeight(98);
        int animWidth = (int)animationManager2D.getAnimWidth(97);
        int num5 = animHeight1 + num3 + 100 + 5 + num4 + 8 + animHeight2;
        int num6 = (height - num5 >> 1) + animHeight1;
        int x1 = (width - animWidth >> 1) + 20 + 4;
        int num7 = animWidth - 40;
        animationManager2D.submitAnimVBar(96, 97, 98, (float)(engine.getHalfWidth() + 4), (float)engine.getHalfHeight(), (float)num5);
        int y1 = num6 + num3 + 100 + 5 + num4 + 8 + 28;
        int x2 = engine.getHalfWidth() - 48;
        int x3 = engine.getHalfWidth() + 48;
        UIButton uiButton1 = this.getUIButton(32);
        UIButton uiButton2 = this.getUIButton(64);
        uiButton1.submit(ref animationManager2D, x3, y1);
        uiButton2.submit(ref animationManager2D, x2, y1);
        animationManager2D.flushAnims(g);
        int y2 = num6;
        g.Begin();
        textManager.drawWrappedString(g, 3, engine.getHalfWidth(), y2, 17);
        g.End();
        int x4 = x1 + 30;
        int y3 = num6 + num3 + 5;
        int w = num7 - 60;
        UIList uiList = this.getUIList(9);
        uiList.setup(x4, y3, w, 100);
        uiList.render(g);
        int y4 = y3 + 100 + 5;
        g.Begin();
        textManager.drawString(g, 1079, 3, x1, y4, 9);
        StringBuffer strBuffer = textManager.clearStringBuffer();
        textManager.appendMoneyToBuffer(num1);
        textManager.drawString(g, strBuffer, 3, x1 + num7, y4, 33);
        g.End();
    }

    private void initListShopping()
    {
        this.m_shoppingBasketQtys = new int[this.m_simWorld.getItemNthCount(this.m_shoppingObjectType)];
        this.m_shoppingBasketItemIds = new int[this.m_shoppingBasketQtys.Length];
        for (int index = 0; index < this.m_shoppingBasketQtys.Length; ++index)
        {
            int itemNthItem = this.m_simWorld.getItemNthItem(this.m_shoppingObjectType, index);
            int inventoryCount = this.m_simData.getInventoryCount(itemNthItem);
            this.m_shoppingBasketQtys[index] = inventoryCount;
            this.m_shoppingBasketItemIds[index] = itemNthItem;
        }
        this.m_shoppingTally = 0;
        UIList uiList = this.getUIList(7);
        uiList.initList();
        uiList.setSelectedIdx(0);
        this.m_shoppingTimeSinceLastMinusPress = 1000;
        this.m_shoppingTimeSinceLastPlusPress = 1000;
    }

    public int getShoppingItemCount()
    {
        return this.m_shoppingBasketQtys.Length;
    }

    public int getShoppingQty(int idx)
    {
        return this.m_shoppingBasketQtys[idx];
    }

    public int getShoppingItemId(int idx)
    {
        return this.m_shoppingBasketItemIds[idx];
    }

    private void excludeShopping(int flags, int itemIdx)
    {
        int itemNthItem = this.m_simWorld.getItemNthItem(this.m_shoppingObjectType, itemIdx);
        int itemCount = this.getUIList(7).getItemCount();
        if ((this.getSimWorld().getItemFlags(itemNthItem) & flags) == 0)
            return;
        for (int index = 0; index < itemCount; ++index)
        {
            if (index != itemIdx && (this.m_simWorld.getItemFlags(this.m_simWorld.getItemNthItem(this.m_shoppingObjectType, itemIdx)) & flags) != 0 && this.m_shoppingBasketQtys[index] > 0)
                this.m_shoppingBasketQtys[index] = 0;
        }
    }

    private void tallyShopping()
    {
        this.m_shoppingTally = 0;
        for (int index = 0; index < this.m_shoppingBasketQtys.Length; ++index)
        {
            int shoppingBasketItemId = this.m_shoppingBasketItemIds[index];
            int inventoryCount = this.m_simData.getInventoryCount(shoppingBasketItemId);
            int shoppingBasketQty = this.m_shoppingBasketQtys[index];
            this.m_shoppingTally += (shoppingBasketQty >= inventoryCount ? this.m_simWorld.getItemBuyPrice(shoppingBasketItemId) : this.m_simWorld.getItemSellPrice(shoppingBasketItemId)) * (shoppingBasketQty - inventoryCount);
        }
    }

    protected void initEditMode()
    {
        this.m_state = 7;
    }

    public bool isTutorialMode()
    {
        return this.m_state == 21;
    }

    private void initTutorial()
    {
        this.stateTransitionTutorial(0);
    }

    private void updateTutorial(int timeStep)
    {
        switch (this.m_tutorialState)
        {
            case 1:
                if (!this.m_cameraAtDest)
                    break;
                this.showTutorialMessage(1688, 1687);
                break;
            case 2:
                if (this.m_pointerPressed || ((this.m_camTutesComplete & 1) == 0 || (this.m_camTutesComplete & 2) == 0) && ((this.m_camTutesComplete & 1) == 0 || (this.m_camTutesComplete & 4) == 0) && ((this.m_camTutesComplete & 2) == 0 || (this.m_camTutesComplete & 4) == 0))
                    break;
                this.stateTransitionTutorial(3);
                break;
            case 5:
                if (!this.m_playerSim.isIdle())
                    break;
                this.showTutorialMessage(1694, 1693);
                break;
            case 6:
                this.m_tutorialTimer -= timeStep;
                if (this.m_tutorialTimer > 0)
                    break;
                this.showTutorialMessage(113, 1693);
                break;
            case 7:
                if (!this.m_tutorialGoalReached && this.m_actionQueueSize > 0)
                {
                    if (this.m_actionQueueActions[0] != 131)
                        break;
                    this.m_tutorialGoalReached = true;
                    break;
                }
                if (!this.m_tutorialGoalReached || !this.m_playerSim.isIdle())
                    break;
                this.m_simData.setMotiveLevel(0, 4259840);
                this.showTutorialMessage(1695, 71);
                break;
            case 9:
                if (this.m_tutorialGoalReached)
                {
                    this.showTutorialMessage(1699, 1698);
                    break;
                }
                this.m_tutorialTimer -= timeStep;
                if (this.m_tutorialTimer > 0)
                    break;
                this.m_simData.getNewDream();
                this.m_tutorialGoalReached = true;
                break;
            case 10:
                this.m_tutorialPulseScale += this.m_tutorialPulseSpeed * ((float)timeStep / 1000f);
                if ((double)this.m_tutorialPulseScale > 0.899999976158142 && (double)this.m_tutorialPulseScale < 1.10000002384186)
                    break;
                this.m_tutorialPulseScale = midp.JMath.min(1.1f, midp.JMath.max(0.9f, this.m_tutorialPulseScale));
                this.m_tutorialPulseSpeed = -this.m_tutorialPulseSpeed;
                break;
        }
    }

    private void stateTransitionTutorial(int state)
    {
        switch (state)
        {
            case 0:
                this.m_simData.clearMotives();
                this.m_HUDRenderMask = 0;
                this.showTutorialMessage(92, 91);
                break;
            case 1:
                this.stateTransitionCamera(9);
                break;
            case 2:
                this.m_HUDRenderMask ^= 16;
                break;
            case 3:
                this.showTutorialMessage(1690, 1689);
                break;
            case 4:
                this.setCursorSelectFlags(2);
                this.m_suppressMenus = false;
                break;
            case 5:
                this.m_HUDRenderMask ^= 1;
                break;
            case 6:
                this.m_HUDRenderMask ^= 4;
                this.m_simData.setMotiveLevel(0, 2293759);
                this.m_simData.setMotiveLevel(2, 4915200);
                this.m_simData.setMotiveLevel(1, 6553600);
                this.m_simData.setMotiveLevel(5, 4915200);
                this.m_simData.setMotiveLevel(3, 4915200);
                this.m_simData.setMotiveLevel(4, 4915200);
                this.m_tutorialTimer = 3000;
                break;
            case 7:
                this.m_tutorialGoalReached = false;
                break;
            case 8:
                this.showTutorialMessage(1697, 1696);
                break;
            case 9:
                this.m_HUDRenderMask ^= 8;
                this.m_tutorialTimer = 5000;
                this.m_tutorialGoalReached = false;
                break;
            case 10:
                this.m_HUDRenderMask ^= 64;
                break;
            case 11:
                this.showInfoScreen(3);
                this.m_HUDRenderMask = -1;
                this.m_engine.setTutorialBeenPlayed();
                break;
        }
        this.m_tutorialState = state;
    }

    private void showTutorialMessage(int messageId, int titleId)
    {
        this.showMessageBox(messageId, titleId, 6);
        this.m_simData.delayAlerts();
    }

    private void completeCamTute(int tuteId)
    {
        this.m_camTutesComplete |= tuteId;
    }

    public void playStereoMusic()
    {
        if (this.m_numStereosPlaying == 0)
            this.m_engine.getBgMusic().playStereo();
        ++this.m_numStereosPlaying;
    }

    public void stopStereoMusic()
    {
        --this.m_numStereosPlaying;
        if (this.m_numStereosPlaying != 0)
            return;
        this.m_engine.getBgMusic().beQuiet();
    }

    public void changeSceneWithFade(int nextScene, int nextSceneState)
    {
        this.m_nextScene = nextScene;
        this.m_nextSceneState = nextSceneState;
        this.fadeStateTransition(2);
    }

    public void resetRepairTarget()
    {
        this.m_repairComponents[this.m_repairDragTarget].setTranslationx(0, 0, 0);
        this.m_repairDragTarget = -1;
    }

    public void clearRepairTarget()
    {
        this.m_repairDragTarget = -1;
    }
}
