// Decompiled with JetBrains decompiler
// Type: SceneMenu
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using midp;
using sims3;
using System.Threading;

public class SceneMenu : Scene
{
  public static readonly int[] CAS_APPEARANCE_BUTTONS = new int[88]
  {
    35,
    133,
    48,
    405,
    406,
    0,
    -1,
    1,
    0,
    -1,
    -1,
    35,
    183,
    48,
    409,
    410,
    1,
    -1,
    2,
    0,
    1,
    1,
    35,
    233,
    48,
    413,
    414,
    4,
    -1,
    3,
    0,
    0,
    0,
    498,
    31,
    48,
    259,
    260,
    11,
    12,
    5,
    1,
    3,
    10,
    498,
    78,
    48,
    407,
    408,
    2,
    3,
    4,
    1,
    2,
    9,
    498,
    126,
    48,
    411,
    412,
    5,
    6,
    6,
    1,
    5,
    12,
    498,
    175,
    48,
    415,
    416,
    7,
    8,
    7,
    1,
    6,
    13,
    498,
    222,
    48,
    417,
    418,
    9,
    10,
    8,
    1,
    7,
    14
  };
  private UIObjectPreview m_exportSimPreview = new UIObjectPreview();
  private Image m_exportSimBackground = new Image();
  private Image m_bannerImage = new Image();
  private string m_bannerURL = "";
  private string m_tickerString = "";
  private string m_tickerURL = "";
  private Transform m_tempTransform = new Transform();
  private int[][] m_casBackup = new int[2][];
  private int[] m_casTempUnlocked = new int[13];
  private const int UNLOCK_BTN_X = 373;
  private const int UNLOCK_BTN_Y = 210;
  private const int UNLOCK_BTN_W = 160;
  private const int UNLOCK_BTN_H = 110;
  public const int CAS_REC_LEN = 11;
  public const int STATE_NONE = 0;
  public const int STATE_LOADING = 1;
  public const int STATE_CHANGESCENE = 2;
  public const int STATE_LANGUAGE = 3;
  public const int STATE_MAIN = 4;
  public const int STATE_GOALS = 5;
  public const int STATE_MOREGAMES = 6;
  public const int STATE_MEDIAPICKER = 7;
  public const int STATE_SELECT_GAME = 8;
  public const int STATE_DELETE_GAME = 9;
  public const int STATE_CONFIRM_DELETE = 10;
  public const int STATE_CAS_INTROTUTORIAL = 11;
  public const int STATE_CAS_APPEARANCE = 12;
  public const int STATE_CAS_PERSONA = 13;
  public const int STATE_CAS_TRAITS = 14;
  public const int STATE_CAS_NAME = 15;
  public const int STATE_CAS_SIMINFO = 16;
  public const int STATE_CONFIRM_ABANDON = 17;
  public const int STATE_CONFIRM_NEWGAME = 18;
  public const int STATE_EXPORT_GAME_SELECT = 19;
  public const int STATE_EXPORT_GAME_NOSIMS = 20;
  public const int STATE_EXPORT_GAME_BEGIN = 21;
  public const int STATE_EXPORT_GAME_HERESHOW = 22;
  public const int STATE_EXPORT_GAME_GETREADY = 23;
  public const int STATE_EXPORT_GAME_SNAPSHOT = 24;
  public const int STATE_EXPORT_GAME_DIDYAGETIT = 25;
  public const int STATE_EXPORT_GAME_FINISHED = 26;
  public const int STATE_IMPORT_GAME_NOSLOTS = 27;
  public const int STATE_IMPORT_GAME_HELP = 28;
  public const int STATE_IMPORT_GAME_PICKPHOTO = 29;
  public const int STATE_IMPORT_GAME_INVALIDPHOTO = 30;
  public const int STATE_IMPORT_GAME_MISSINGDLC = 31;
  public const int STATE_IMPORT_GAME_SUCCESS = 32;
  public const int STATE_EDITSIM = 33;
  public const int STATE_EDITSIM_CONFIRM_ABANDON = 34;
  public const int STATE_EDITSIM_CONFIRM_ACCEPT = 35;
  public const int STATE_EAMTXSTORE = 36;
  public const int STATE_EAMTXSTORE_FIRSTLAUNCH = 37;
  public const int STATE_EAMTXSTORE_UNAVAILABLE = 38;
  public const int STATE_ACHIEVEMENTS = 39;
  public const int STATE_LEADERBOARDS = 40;
  public const int STATE_ACHIEVEMENT_DETAIL = 41;
  public const int STATE_LOADING_CAS = 42;
  public const int SUBSTATE_CAS_NONE = -1;
  public const int SUBSTATE_CAS_APPEARANCE_START = 0;
  public const int SUBSTATE_CAS_APPEARANCE_SEX = 1;
  public const int SUBSTATE_CAS_APPEARANCE_SKIN = 2;
  public const int SUBSTATE_CAS_APPEARANCE_EYES = 3;
  public const int SUBSTATE_CAS_APPEARANCE_HAIR = 4;
  public const int SUBSTATE_CAS_APPEARANCE_HEAD = 5;
  public const int SUBSTATE_CAS_APPEARANCE_TORSO = 6;
  public const int SUBSTATE_CAS_APPEARANCE_LEGS = 7;
  public const int SUBSTATE_CAS_APPEARANCE_FEET = 8;
  public const int SUBSTATE_CAS_APPEARANCE_RANDOM = 9;
  public const int SUBSTATE_CAS_NAME_NONE = 10;
  public const int SUBSTATE_CAS_NAME_INVALID_INPUT = 11;
  private const int LOADING_INIT = 0;
  private const int LOADING_IMAGES = 1;
  private const int LOADING_BG = 2;
  private const int LOADING_MODELS = 3;
  private const int LOADING_TEXTURES = 4;
  private const int LOADING_FINISHED = 5;
  private const int LOADINGTHREAD_STATE_IDLE = 0;
  private const int LOADINGTHREAD_STATE_WAIT = 1;
  private const int LOADINGTHREAD_STATE_QUIT = 2;
  private const int BARCODE_START_X = 20;
  private const int BARCODE_MAX_X = 150;
  private const int BARCODE_START_Y = 210;
  private const int BARCODE_STEP_X = 4;
  private const int BARCODE_STEP_Y = 3;
  private const int ENCODE_COLOR_OFFSET = 16;
  private const int ENCODE_COLOR_THRESHOLD = 7;
  private const int NUM_TICKER_BITS = 2;
  private const int TICKER_DELAY = 5000;
  private const int INTERP_TIME_LOOKAT = 1100;
  private const int INTERP_TIME_LOOKFROM = 1100;
  private const int INTERP_TIME_ALPHA = 150;
  private const int CAS_DRAG_SLOW_TIME = 1000;
  private const int CAS_COLOR_BUTTON_X_OFFSET = -50;
  private const int CAS_COLOR_BUTTON_Y_OFFSET = 0;
  private const int CAS_COLOR_BUTTON_RADIUS = 30;
  private const int CAS_RANDOM_BUTTON_X = 48;
  private const int CAS_RANDOM_BUTTON_Y = 275;
  private const int CAS_RANDOM_BUTTON_RADIUS = 30;
  private XNAButton btnUnlock;
  private int m_state;
  private int m_casSubState;
  private int m_stateTime;
  private int m_previousState;
  private int m_afterFadeState;
  private int m_nextScene;
  private int m_nextSceneState;
  private int m_initialState;
  private int[] m_mainMenuItems;
  private UIPauseMenu m_mainMenu;
  private volatile int m_loadingState;
  private int m_loadingProgress;
  private int m_loadingProgressF;
  private midp.JThread m_loadingThread;
  private int m_loadingThreadState;
  public float[] m_tempFloat4_1;
  public float[] m_tempFloat4_2;
  private System.Threading.Thread loadingThread;
  private bool m_moreGamesFromStore;
  private World m_bgWorld;
  private Transform m_bgCameraTransform;
  private Camera m_bgCamera;
  private AnimPlayer3D m_bgAnimPlayer;
  private UIObjectPreview m_activeGamePlumbBob;
  private int[] m_exportSimTempRGB;
  private PhotoPicker m_photoPicker;
  private byte[] m_exportData;
  private SignalFilter m_bannerFilter;
  private string[] m_tickerStringBits;
  private SignalFilter m_tickerFilter;
  private int m_tickerTimer;
  private int m_tickerTimerMax;
  private int m_tickerWidth;
  private int m_tickerIndex;
  private World m_casWorld;
  private Group m_casRoomGroup;
  private Group m_casRoomGroupReflection;
  private Transform m_casCameraTransform;
  private Transform m_casMirrorTransform;
  private Camera m_casCamera;
  private bool m_casEditMode;
  private bool m_casImportMode;
  private bool m_casIntroTutorialShown;
  private SignalFilter m_casCameraLookatXFilter;
  private SignalFilter m_casCameraLookatYFilter;
  private SignalFilter m_casCameraLookatZFilter;
  private SignalFilter m_casCameraLookfromXFilter;
  private SignalFilter m_casCameraLookfromYFilter;
  private SignalFilter m_casCameraLookfromZFilter;
  private SignalFilter m_simLocatorXFilter;
  private SignalFilter m_simLocatorYFilter;
  private SignalFilter m_simLocatorZFilter;
  private SignalFilter m_simLocatorRotFilter;
  private SignalFilter m_UIBarAlphaFilterFeet;
  private SignalFilter m_UIBarAlphaFilterLegs;
  private SignalFilter m_UIBarAlphaFilterTorso;
  private SignalFilter m_UIBarAlphaFilterHairstyle;
  private SignalFilter m_UIBarAlphaFilterHead;
  private SignalFilter m_UIBarAlphaFilterEyes;
  private SignalFilter m_UIBarAlphaFilterSex;
  private SignalFilter m_UIBarAlphaFilterSkin;
  private SignalFilter m_randomiseNotifyAlphaFilter;
  private SignalFilter m_appearancePanelAlphaFilter;
  private Model m_casSimModel;
  private Model m_casSimModelReflection;
  private int m_simTestAnimIndex;
  private bool m_randomiseSimRequested;
  private bool m_randomiseMessageDrawn;
  private int[][] m_casUniqueOptions;
  private float m_casYaw;
  private float m_casDragVelYaw;
  private int m_casDragReleaseTime;

  public SceneMenu(AppEngine ae)
    : base(ae)
  {
    this.m_state = 0;
    this.m_casSubState = -1;
    this.m_stateTime = 0;
    this.m_previousState = 0;
    this.m_afterFadeState = 0;
    this.m_nextScene = 0;
    this.m_nextSceneState = -1;
    this.m_initialState = 0;
    this.m_mainMenuItems = (int[]) null;
    this.m_mainMenu = (UIPauseMenu) null;
    this.m_loadingState = 0;
    this.m_loadingProgress = 0;
    this.m_loadingProgressF = 0;
    this.m_tempFloat4_1 = new float[4];
    this.m_tempFloat4_2 = new float[4];
    this.m_loadingThread = (midp.JThread) null;
    this.m_loadingThreadState = 0;
    this.m_bgWorld = (World) null;
    this.m_bgCameraTransform = (Transform) null;
    this.m_bgCamera = (Camera) null;
    this.m_bgAnimPlayer = (AnimPlayer3D) null;
    this.m_bannerImage = (Image) null;
    this.m_bannerURL = (string) null;
    this.m_bannerFilter = new SignalFilter(0, 1000f, 0.0f);
    this.m_tickerString = (string) null;
    this.m_tickerStringBits = new string[2];
    this.m_tickerURL = (string) null;
    this.m_tickerFilter = new SignalFilter(0, 1000f, 0.0f);
    this.m_tickerTimer = 0;
    this.m_tickerTimerMax = 0;
    this.m_tickerWidth = 0;
    this.m_tickerIndex = 0;
    this.m_casWorld = (World) null;
    this.m_casRoomGroup = (Group) null;
    this.m_casRoomGroupReflection = (Group) null;
    this.m_casCameraTransform = (Transform) null;
    this.m_casMirrorTransform = (Transform) null;
    this.m_casCamera = (Camera) null;
    this.m_casEditMode = false;
    this.m_casImportMode = false;
    this.m_casIntroTutorialShown = false;
    this.m_casCameraLookatXFilter = new SignalFilter(0, 1100f, 0.0f);
    this.m_casCameraLookatYFilter = new SignalFilter(0, 1100f, 0.0f);
    this.m_casCameraLookatZFilter = new SignalFilter(0, 1100f, 0.0f);
    this.m_casCameraLookfromXFilter = new SignalFilter(0, 1100f, 0.0f);
    this.m_casCameraLookfromYFilter = new SignalFilter(0, 1100f, 0.0f);
    this.m_casCameraLookfromZFilter = new SignalFilter(0, 1100f, 0.0f);
    this.m_simLocatorXFilter = new SignalFilter(0, 1100f, 0.0f);
    this.m_simLocatorYFilter = new SignalFilter(0, 1100f, 0.0f);
    this.m_simLocatorZFilter = new SignalFilter(0, 1100f, 0.0f);
    this.m_simLocatorRotFilter = new SignalFilter(0, 1100f, 0.0f);
    this.m_UIBarAlphaFilterFeet = new SignalFilter(0, 150f, 0.0f);
    this.m_UIBarAlphaFilterLegs = new SignalFilter(0, 150f, 0.0f);
    this.m_UIBarAlphaFilterTorso = new SignalFilter(0, 150f, 0.0f);
    this.m_UIBarAlphaFilterHairstyle = new SignalFilter(0, 150f, 0.0f);
    this.m_UIBarAlphaFilterHead = new SignalFilter(0, 150f, 0.0f);
    this.m_UIBarAlphaFilterEyes = new SignalFilter(0, 150f, 0.0f);
    this.m_UIBarAlphaFilterSex = new SignalFilter(0, 150f, 0.0f);
    this.m_UIBarAlphaFilterSkin = new SignalFilter(0, 150f, 0.0f);
    this.m_randomiseNotifyAlphaFilter = new SignalFilter(0, 150f, 0.0f);
    this.m_appearancePanelAlphaFilter = new SignalFilter(0, 150f, 0.0f);
    this.m_activeGamePlumbBob = (UIObjectPreview) null;
    this.m_exportSimTempRGB = new int[1];
    this.m_exportSimPreview = (UIObjectPreview) null;
    this.m_exportSimBackground = (Image) null;
    this.m_photoPicker = (PhotoPicker) null;
    this.m_exportData = (byte[]) null;
    this.m_casSimModel = (Model) null;
    this.m_casSimModelReflection = (Model) null;
    this.m_simTestAnimIndex = 0;
    this.m_randomiseSimRequested = false;
    this.m_randomiseMessageDrawn = false;
    this.m_casUniqueOptions = (int[][]) null;
    this.m_casYaw = 0.0f;
    this.m_casDragVelYaw = 0.0f;
    this.m_casDragReleaseTime = 0;
    this.m_moreGamesFromStore = false;
    ae.setFadeStep(197379);
    this.m_mainMenu = new UIPauseMenu();
    this.addUIElement((UIElement) this.m_mainMenu);
    this.m_activeGamePlumbBob = new UIObjectPreview();
  }

  public override void processInput(int _event, int[] args)
  {
    if (this.processInputBanner(_event, args) || this.processInputTicker(_event, args))
      return;
    base.processInput(_event, args);
    if (this.m_state == 1)
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
      if (this.getSharedMenuState() != -1)
      {
        this.processInputSharedMenu(_event, args);
        if (this.getSharedMenuState() != -1)
          return;
        this.stateTransition(this.m_state);
      }
      else
      {
        bool flag = GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed;
        switch (this.m_state)
        {
          case 4:
            this.processInputMain(_event, args);
            break;
          case 5:
            if (!flag && !Scene.checkCommand(_event, args, 6))
              break;
            this.stateTransition(4);
            break;
          case 8:
            this.processInputSelectGame(_event, args);
            break;
          case 9:
            this.processInputDeleteGame(_event, args);
            break;
          case 10:
            if (Scene.checkCommand(_event, args, 32))
            {
              string simName = engine.getSimName();
              int rmsGameSlotIndex = engine.getRMSGameSlotIndex();
              engine.resetSimSaveData(rmsGameSlotIndex);
              engine.saveRMSAppSettings();
              SpywareManager.getInstance().trackDeleteGame(rmsGameSlotIndex, simName);
              this.stateTransition(8);
              break;
            }
            if (!flag && !Scene.checkCommand(_event, args, 64))
              break;
            this.stateTransition(9);
            break;
          case 11:
          case 32:
            if (!Scene.checkCommand(_event, args, 4) && !flag)
              break;
            this.stateTransition(42);
            break;
          case 12:
            this.processInputCASAppearance(_event, args);
            break;
          case 13:
            this.processInputCASPersona(_event, args);
            break;
          case 14:
            this.processInputCASTraits(_event, args);
            break;
          case 15:
            this.processInputCASName(_event, args);
            break;
          case 16:
            this.processInputCASSimInfo(_event, args);
            break;
          case 17:
            if (Scene.checkCommand(_event, args, 32))
            {
              this.m_engine.setSimName((string) null);
              this.fadeStateTransition(8);
              break;
            }
            if (!flag && !Scene.checkCommand(_event, args, 66))
              break;
            this.stateTransition(42);
            break;
          case 18:
            if (Scene.checkCommand(_event, args, 32))
            {
              SpywareManager.getInstance().trackCAS(false);
              engine.newGame();
              engine.beginGame();
              this.changeScene(2, -1);
              this.awardAchievment(0);
              break;
            }
            if (!flag && !Scene.checkCommand(_event, args, 66))
              break;
            this.stateTransition(15);
            break;
          case 19:
            this.processInputExportSelectGame(_event, args);
            break;
          case 20:
          case 27:
            if (!Scene.checkCommand(_event, args, 4))
              break;
            this.stateTransition(8);
            break;
          case 21:
            this.processInputExportBegin(_event, args);
            break;
          case 22:
            this.processInputExportHeresHow(_event, args);
            break;
          case 23:
            this.processInputExportGetReady(_event, args);
            break;
          case 24:
            this.processInputExportSnapshot(_event, args);
            break;
          case 25:
            this.processInputExportDidYaGetIt(_event, args);
            break;
          case 28:
            this.processInputImportHelp(_event, args);
            break;
          case 30:
          case 31:
            if (!Scene.checkCommand(_event, args, 4))
              break;
            this.stateTransition(8);
            break;
          case 34:
          case 35:
            if (flag || Scene.checkCommand(_event, args, 64))
            {
              this.stateTransition(42);
              break;
            }
            if (!Scene.checkCommand(_event, args, 32))
              break;
            if (this.m_state == 35)
              engine.saveRMSGameData();
            else
              engine.loadRMSGameData();
            SpywareManager.getInstance().trackCAS(true);
            engine.beginGame();
            this.changeScene(2, -1);
            break;
          case 37:
          case 38:
            if (!Scene.checkCommand(_event, args, 4))
              break;
            this.stateTransition(4);
            break;
          case 39:
            this.m_achievementsMenu.processInput(_event, args);
            break;
          case 40:
            this.m_leaderboardsMenu.processInput(_event, args);
            break;
          case 41:
            this.m_achievementDetailMenu.processInput(_event, args);
            break;
        }
      }
    }
  }

  private void processInputMain(int _event, int[] args)
  {
    if (Scene.checkCommand(_event, args, int.MinValue))
      this.processAction(args[2]);
    else if (Scene.checkCommand(_event, args, 2097152))
      this.processAction(39);
    else if (Scene.checkCommand(_event, args, 4194304))
      this.processAction(1725);
    else if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
    {
      this.m_engine.endGame();
      TheSims3.exitGame = true;
    }
    if (!TheSims3.IsTrialMode || this.btnUnlock.handleInput(_event, args) != XNAButton.State.RELEASED || Guide.IsVisible)
      return;
    Guide.ShowMarketplace(PlayerIndex.One);
    while (Guide.IsVisible)
      midp.JThread.sleep(500);
    TheSims3.IsTrialMode = Guide.IsTrialMode;
    this.initMainMenu();
  }

  private void processInputDeleteGame(int _event, int[] args)
  {
    AppEngine engine = this.m_engine;
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 2))
    {
      this.stateTransition(8);
    }
    else
    {
      if (!Scene.checkCommand(_event, args, int.MinValue))
        return;
      int index = args[2];
      if (index < 0)
        return;
      engine.setRMSGameSlotIndex(index);
      if (!engine.getRMSActiveGame())
        return;
      this.stateTransition(10);
    }
  }

  private void processInputSelectGame(int _event, int[] args)
  {
    AppEngine engine = this.m_engine;
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 2))
      this.stateTransition(4);
    else if (Scene.checkCommand(_event, args, 2048))
      this.stateTransition(9);
    else if (Scene.checkCommand(_event, args, 8388608))
    {
      if (engine.getRMSNumActiveGames() > 0)
        this.stateTransition(19);
      else
        this.stateTransition(20);
    }
    else if (Scene.checkCommand(_event, args, 268435456))
    {
      if (engine.getRMSNumActiveGames() < 7)
        this.fadeStateTransition(28);
      else
        this.stateTransition(27);
    }
    else
    {
      if (!Scene.checkCommand(_event, args, int.MinValue))
        return;
      int index = args[2];
      if (index < 0)
        return;
      engine.setRMSGameSlotIndex(index);
      if (engine.getRMSActiveGame())
      {
        engine.beginGame();
        this.changeScene(2, -1);
      }
      else
      {
        this.m_casImportMode = false;
        engine.resetRMSGameData();
        engine.clearSimName();
        this.fadeStateTransition(42);
      }
    }
  }

  private void processInputExportSelectGame(int _event, int[] args)
  {
    AppEngine engine = this.m_engine;
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 2))
    {
      this.stateTransition(8);
    }
    else
    {
      if (!Scene.checkCommand(_event, args, int.MinValue))
        return;
      int index = args[2];
      if (index < 0)
        return;
      engine.setRMSGameSlotIndex(index);
      if (!engine.getRMSActiveGame())
        return;
      this.fadeStateTransition(21);
    }
  }

  private void processInputExportBegin(int _event, int[] args)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 4096))
      this.fadeStateTransition(26);
    else if (Scene.checkCommand(_event, args, 16777216))
    {
      this.fadeStateTransition(23);
    }
    else
    {
      if (!Scene.checkCommand(_event, args, 67108864))
        return;
      this.fadeStateTransition(22);
    }
  }

  private void processInputExportHeresHow(int _event, int[] args)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 4096))
      this.fadeStateTransition(26);
    else if (Scene.checkCommand(_event, args, 16777216))
    {
      this.fadeStateTransition(23);
    }
    else
    {
      if (!Scene.checkCommand(_event, args, 67108864))
        return;
      this.fadeStateTransition(23);
    }
  }

  private void processInputExportGetReady(int _event, int[] args)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 4096))
      this.fadeStateTransition(26);
    else if (Scene.checkCommand(_event, args, 67108864))
    {
      this.fadeStateTransition(24);
    }
    else
    {
      if (!Scene.checkCommand(_event, args, 33554432))
        return;
      this.fadeStateTransition(22);
    }
  }

  private void processInputExportSnapshot(int _event, int[] args)
  {
    if (_event != 0)
      return;
    SpywareManager.getInstance().trackExport();
    this.fadeStateTransition(25);
  }

  private void processInputExportDidYaGetIt(int _event, int[] args)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 134217728))
      this.fadeStateTransition(24);
    else if (Scene.checkCommand(_event, args, 67108864))
    {
      this.fadeStateTransition(26);
    }
    else
    {
      if (!Scene.checkCommand(_event, args, 33554432))
        return;
      this.fadeStateTransition(22);
    }
  }

  private void processInputImportHelp(int _event, int[] args)
  {
    if (Scene.checkCommand(_event, args, 67108864))
    {
      this.fadeStateTransition(29);
    }
    else
    {
      if (!Scene.checkCommand(_event, args, 4096))
        return;
      this.fadeStateTransition(8);
    }
  }

  private bool processInputBanner(int _event, int[] args)
  {
    if (_event != 0 || this.m_state != 4 || ((double) this.m_bannerFilter.getFilteredValue() <= 0.999000012874603 || this.m_bannerImage == null) || (this.m_bannerURL == null || this.m_bannerImage != MTXStoreManager.getInstance().getBannerImage() || (args[1] >= this.m_bannerImage.getWidth() || args[2] <= this.m_engine.getHeight() - this.m_bannerImage.getHeight())))
      return false;
    WebView.launchBrowser(this.m_bannerURL);
    return true;
  }

  private bool processInputTicker(int _event, int[] args)
  {
    if (_event != 0 || this.m_state != 4 || ((double) this.m_tickerFilter.getFilteredValue() <= 0.999000012874603 || this.m_tickerString == null) || (this.m_tickerURL == null || !(this.m_tickerString == MTXStoreManager.getInstance().getTickerString(this.m_tickerIndex)) || args[2] >= 20))
      return false;
    WebView.launchBrowser(this.m_tickerURL);
    return true;
  }

  private void processInputCASAppearance(int _event, int[] args)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 4096))
    {
      if (this.m_casEditMode)
        this.stateTransition(34);
      else
        this.stateTransition(17);
    }
    else if (Scene.checkCommand(_event, args, 8192))
    {
      if (this.m_casEditMode)
        this.stateTransition(35);
      else
        this.stateTransition(13);
    }
    else
    {
      switch (_event)
      {
        case 3:
          int x = args[1];
          int y = args[2];
          if (!this.m_casEditMode && UIElement.isInRadius(x, y, 48, 275, 30))
          {
            this.setNewCasCameraTarget(10012, 10001);
            this.setNewCasSimLocatorTarget(10021);
            this.subStateTransitionCas(9);
            this.playSound(21);
            break;
          }
          bool flag = false;
          for (int index = 0; index < SceneMenu.CAS_APPEARANCE_BUTTONS.Length; index += 11)
          {
            if (!this.m_casEditMode || SceneMenu.CAS_APPEARANCE_BUTTONS[index + 8] != 0)
            {
              float num1 = (float) SceneMenu.CAS_APPEARANCE_BUTTONS[index];
              float num2 = (float) SceneMenu.CAS_APPEARANCE_BUTTONS[index + 1];
              float num3 = (float) (SceneMenu.CAS_APPEARANCE_BUTTONS[index + 2] >> 1);
              int attrib = SceneMenu.CAS_APPEARANCE_BUTTONS[index + 5];
              if (!this.isAttributeDisabled(attrib) && UIElement.isInRadius(x, y, (int) num1, (int) num2, (int) num3))
              {
                this.playSound(21);
                flag = true;
                int lookFromLocatorId = -1;
                int lookAtLocatorId = -1;
                int locatorId = 10021;
                int newSubState = -1;
                switch (attrib)
                {
                  case 0:
                    lookFromLocatorId = 10018;
                    lookAtLocatorId = 10007;
                    newSubState = 1;
                    break;
                  case 1:
                    lookFromLocatorId = 10019;
                    lookAtLocatorId = 10008;
                    newSubState = 2;
                    break;
                  case 2:
                    lookFromLocatorId = 10013;
                    lookAtLocatorId = 10002;
                    newSubState = 4;
                    locatorId = 10022;
                    break;
                  case 4:
                    lookFromLocatorId = 10010;
                    lookAtLocatorId = 9998;
                    newSubState = 3;
                    break;
                  case 5:
                    lookFromLocatorId = 10020;
                    lookAtLocatorId = 10009;
                    newSubState = 6;
                    break;
                  case 7:
                    lookFromLocatorId = 10016;
                    lookAtLocatorId = 10005;
                    newSubState = 7;
                    break;
                  case 9:
                    lookFromLocatorId = 10011;
                    lookAtLocatorId = 10000;
                    newSubState = 8;
                    break;
                  case 11:
                    lookFromLocatorId = 10013;
                    lookAtLocatorId = 10002;
                    newSubState = 5;
                    locatorId = 10022;
                    break;
                }
                if (this.m_casSubState == newSubState)
                {
                  this.subStateTransitionCas(0);
                  this.setNewCasCameraTarget(10012, 10001);
                  this.setNewCasSimLocatorTarget(10021);
                }
                else
                {
                  this.setNewCasCameraTarget(lookFromLocatorId, lookAtLocatorId);
                  this.setNewCasSimLocatorTarget(locatorId);
                  this.subStateTransitionCas(newSubState);
                }
              }
              if (flag)
                break;
            }
          }
          if (!this.isCameraInTargetPosition() || flag || (this.m_casSubState == 0 || this.m_casSubState == 9))
            break;
          int userId1 = -1;
          int userId2 = -1;
          int num4 = -1;
          int num5 = -1;
          switch (this.m_casSubState)
          {
            case 1:
              num4 = 0;
              userId1 = 10043;
              userId2 = 10044;
              break;
            case 2:
              num4 = 1;
              userId1 = 10046;
              userId2 = 10047;
              break;
            case 3:
              num4 = 4;
              userId1 = 10040;
              userId2 = 10041;
              break;
            case 4:
              num4 = 2;
              num5 = 3;
              userId1 = 10037;
              userId2 = 10038;
              break;
            case 5:
              num4 = 11;
              num5 = 12;
              userId1 = 10037;
              userId2 = 10038;
              break;
            case 6:
              num4 = 5;
              num5 = 6;
              userId1 = 10034;
              userId2 = 10035;
              break;
            case 7:
              num4 = 7;
              num5 = 8;
              userId1 = 10031;
              userId2 = 10032;
              break;
            case 8:
              num4 = 9;
              num5 = 10;
              userId1 = 10028;
              userId2 = 10029;
              break;
          }
          if (num5 != -1 && !this.isAttributeColorDisabled(num5))
          {
            int buttonX = 0;
            int buttonY = 0;
            this.getColorButtonScreenCoordsFromAttributeIndex(num4, ref buttonX, ref buttonY);
            if (UIElement.isInRadius(x, y, buttonX, buttonY, 30))
            {
              int simAttributeMax = this.m_simWorld.getSimAttributeMax(0, num5);
              int attributeByIndex = this.m_simData.getSimAttributeByIndex(0, num5);
              this.m_simData.setPlayerSimAttributeByIndex(num5, (attributeByIndex + 1) % simAttributeMax);
              this.playSound(21);
              this.loadSim();
              break;
            }
          }
          this.getCasRoomLocatorPosition(userId1, this.m_tempFloat4_1);
          ModelManager.coordWorldToScreen(this.m_tempFloat4_2, this.m_casCamera, this.m_casCameraTransform, this.m_engine.getWidth(), this.m_engine.getHeight(), this.m_tempFloat4_1[0], this.m_tempFloat4_1[1], this.m_tempFloat4_1[2]);
          float num6 = this.m_tempFloat4_2[0];
          float num7 = this.m_tempFloat4_2[1];
          this.getCasRoomLocatorPosition(userId2, this.m_tempFloat4_1);
          ModelManager.coordWorldToScreen(this.m_tempFloat4_2, this.m_casCamera, this.m_casCameraTransform, this.m_engine.getWidth(), this.m_engine.getHeight(), this.m_tempFloat4_1[0], this.m_tempFloat4_1[1], this.m_tempFloat4_1[2]);
          float num8 = this.m_tempFloat4_2[0];
          float num9 = this.m_tempFloat4_2[1];
          int changeDir = 0;
          if (UIElement.isInRadius(x, y, (int) num6, (int) num7, 30))
            changeDir = -1;
          else if (UIElement.isInRadius(x, y, (int) num8, (int) num9, 30))
            changeDir = 1;
          if (!this.casChange(num4, changeDir))
            break;
          this.playSound(21);
          this.loadSim();
          break;
        case 8:
          this.m_casDragReleaseTime = 0;
          this.m_casDragVelYaw = 0.0f;
          break;
        case 9:
          int num10 = args[9];
          int num11 = args[1];
          int num12 = args[2];
          int num13 = args[5];
          int num14 = args[6];
          int num15 = args[3];
          int num16 = args[4];
          int num17 = args[7];
          int num18 = args[8];
          if ((num11 != num13 || num12 != num14) && (num15 != num17 || num16 != num18) || (num11 != num13 || num12 != num14 || (num15 != num17 || num16 != num18)))
          {
            float[] numArray1 = new float[2];
            float[] numArray2 = new float[2];
            numArray1[0] = (float) (num15 - num11);
            numArray1[1] = (float) (num16 - num12);
            numArray2[0] = (float) (num17 - num13);
            numArray2[1] = (float) (num18 - num14);
            float num1 = (float) (System.Math.Atan2((double) numArray2[1], (double) numArray2[0]) - System.Math.Atan2((double) numArray1[1], (double) numArray1[0])) * 57.29578f;
            this.m_casYaw += num1;
            this.m_casDragVelYaw = num1 / (float) num10;
            this.m_casDragVelYaw = MathExt.clip(this.m_casDragVelYaw, -0.5f, 0.5f);
            this.m_casDragReleaseTime = 1000;
            break;
          }
          this.m_casDragReleaseTime = 0;
          this.m_casDragVelYaw = 0.0f;
          break;
      }
    }
  }

  private void processInputCASPersona(int _event, int[] args)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 2))
      this.stateTransition(12);
    else if (Scene.checkCommand(_event, args, 32))
    {
      this.stateTransition(14);
    }
    else
    {
      if (!Scene.checkCommand(_event, args, int.MinValue))
        return;
      this.m_simData.setPersona(args[2]);
    }
  }

  private void processInputCASTraits(int _event, int[] args)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 2))
      this.stateTransition(13);
    else if (Scene.checkCommand(_event, args, 32))
    {
      this.stateTransition(15);
    }
    else
    {
      if (_event != 3)
        return;
      int uiListItemAt = this.getUIListItemAt(2, args[1], args[2]);
      if (uiListItemAt < 0)
        return;
      bool flag = this.m_simData.hasSimGotTrait(0, uiListItemAt) != -1;
      if (this.m_simData.getNumPlayerTraits() == 5 && !flag)
      {
        this.getUIList(2).setSelectionResult(0);
        this.playSound(20);
      }
      else if (flag)
      {
        this.m_simData.traitPlayerRemove(uiListItemAt);
        this.getUIList(2).setSelectionResult(2);
        this.playSound(20);
      }
      else
      {
        this.m_simData.traitPlayerAdd(uiListItemAt);
        this.getUIList(2).setSelectionResult(1);
        this.playSound(21);
      }
    }
  }

  private void processInputCASName(int _event, int[] args)
  {
    bool flag1 = GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 2);
    if (this.m_casSubState == 11)
    {
      if (!flag1 && !Scene.checkCommand(_event, args, 4))
        return;
      this.subStateTransitionCas(10);
    }
    else if (flag1)
      this.stateTransition(14);
    else if (Scene.checkCommand(_event, args, 8192))
    {
      this.stateTransition(18);
    }
    else
    {
      if (!this.isCameraInTargetPosition() || _event != 3)
        return;
      int num1 = this.m_engine.getWidth() >> 1;
      int num2 = num1 - 80;
      int num3 = num1 + 80;
      if (args[1] <= num2 || args[1] >= num3 || args[2] <= 270)
        return;
      this.playSound(21);
      string inputString = AppEngine.getMIDlet().getInputString(" ", 50);
      if (inputString != null && inputString.Length > 0)
      {
        Font defaultFont = Font.getDefaultFont();
        bool flag2 = true;
        for (int index = 0; index < inputString.Length; ++index)
        {
          if (!defaultFont.spriteFont.Characters.Contains(inputString[index]))
          {
            flag2 = false;
            break;
          }
        }
        if (!flag2)
        {
          this.prepareMessageBox(1718, 1715);
          this.subStateTransitionCas(11);
        }
        else if (defaultFont.stringWidth(inputString) > 85)
        {
          this.prepareMessageBox(1717, 1715);
          this.subStateTransitionCas(11);
        }
        else
        {
          this.m_engine.setSimName(inputString);
          this.subStateTransitionCas(10);
        }
      }
      else
      {
        if (this.m_engine.getSimName() != null)
          return;
        this.prepareMessageBox(1716, 1715);
        this.subStateTransitionCas(11);
      }
    }
  }

  private void processInputCASSimInfo(int _event, int[] args)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 2))
    {
      this.stateTransition(15);
    }
    else
    {
      if (!Scene.checkCommand(_event, args, 8192))
        return;
      this.stateTransition(18);
    }
  }

  public override void Dispose()
  {
    if (this.m_casWorld != null)
      this.m_casWorld = (World) null;
    if (this.m_casCamera != null)
      this.m_casCamera = (Camera) null;
    if (this.m_casCameraTransform != null)
      this.m_casCameraTransform = (Transform) null;
    if (this.m_casSimModel != null)
      this.m_casSimModel = (Model) null;
    if (this.m_casSimModelReflection != null)
      this.m_casSimModelReflection = (Model) null;
    if (this.m_casRoomGroup != null)
      this.m_casRoomGroup = (Group) null;
    if (this.m_casRoomGroupReflection != null)
      this.m_casRoomGroupReflection = (Group) null;
    if (this.m_casMirrorTransform != null)
      this.m_casMirrorTransform = (Transform) null;
    if (this.m_activeGamePlumbBob != null)
      this.m_activeGamePlumbBob = (UIObjectPreview) null;
    this.m_bgWorld = (World) null;
    this.m_bgCamera = (Camera) null;
    this.m_bgCameraTransform = (Transform) null;
    this.m_bgAnimPlayer = (AnimPlayer3D) null;
    this.m_photoPicker = (PhotoPicker) null;
  }

  public override int getSceneID()
  {
    return 1;
  }

  public override void start(int initialState)
  {
    midp.JSystem.println("SceneMenu::starting");
    this.initUI();
    this.m_engine.resetGDGoals();
    if (initialState == -1)
      initialState = 4;
    this.m_initialState = initialState;
    this.stateTransition(1);
    this.m_engine.loadAllImages(4);
    this.m_loadingState = 0;
    this.m_loadingProgress = 0;
    this.m_loadingProgressF = 0;
    midp.JSystem.println("SceneMenu::started");
  }

  private void updateLoadingCAS(int timeStep)
  {
    this.updateLoadingCAS(timeStep, this.m_loadingProgress);
    if (!this.isLoadbarFull())
      return;
    this.stateTransition(12);
  }

  private void updateLoading(int timeStep)
  {
    this.updateLoading(timeStep, this.m_loadingProgress);
    if (this.m_loadingThread == null)
    {
      if (!this.m_engine.isFading() && this.m_loadingState != 5)
      {
        this.m_loadingThread = new midp.JThread(this);
        this.m_loadingThread.getSystemThread().IsBackground = true;
        this.m_loadingThreadState = 0;
        this.m_loadingThread.start();
      }
    }
    else
      midp.JThread.sleep(1);
    if (this.m_loadingState == 5 && this.m_loadingProgressF == 65536 && this.isLoadbarFull())
    {
      this.stateTransition(this.m_initialState);
      this.m_engine.getBgMusic().playMusic(0, 2);
    }
    else
      this.m_loadingProgressF = this.m_loadingProgress * 65536 / 100;
  }

  public override void run()
  {
    while (this.m_loadingThreadState != 2)
    {
      if (this.m_loadingThreadState != 0)
        midp.JThread.sleep(1000);
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
        this.m_loadingProgress = 0;
        this.m_mainMenuItems = new int[15];
        ++this.m_loadingState;
        this.m_loadingProgress = 20;
        engine.loadImagesBegin();
        break;
      case 1:
        if (engine.loadImagesNext(8))
        {
          this.m_loadingProgress = 50;
          ++this.m_loadingState;
          break;
        }
        break;
      case 2:
        this.initBG();
        this.initXNAMenus();
        this.m_loadingProgress = 60;
        ++this.m_loadingState;
        break;
      case 3:
        ModelManager instance = ModelManager.getInstance();
        instance.preloadSimAssets();
        instance.preloadAppearances();
        instance.initExtAppearances();
        this.m_activeGamePlumbBob.loadPlumbBobObject(true);
        this.m_loadingProgress = 80;
        ++this.m_loadingState;
        break;
      case 4:
        ModelManager.getInstance().setLoadStatus(1);
        this.m_loadingProgress = 100;
        ++this.m_loadingState;
        this.initMainMenu();
        this.m_loadingThreadState = 2;
        break;
    }
    AppEngine.timerEnd("SceneMenu::updateLoadingState");
  }

  public override void pause()
  {
    if (this.m_state != 1 || this.m_loadingThreadState == 2)
      return;
    this.m_loadingThreadState = 1;
  }

  public override void resume()
  {
    if (this.m_state != 1 || this.m_loadingThreadState != 1)
      return;
    this.m_loadingThreadState = 0;
  }

  public override void end()
  {
    midp.JSystem.println("SceneMenu::ending");
    ModelManager.getInstance().unloadSimTextures(0);
    this.m_loadingThreadState = 2;
    this.m_loadingThread.join();
    this.m_loadingThread = (midp.JThread) null;
    this.m_engine.unloadAllImages(8, -1);
    midp.JSystem.println("SceneMenu::ended");
  }

  public override void render(Graphics g)
  {
    this.startUI();
    AppEngine engine = this.m_engine;
    if (this.getSharedMenuState() != -1)
    {
      this.drawBG(g);
      this.renderSharedMenu(g);
      this.renderBanner(g);
    }
    else
    {
      switch (this.m_state)
      {
        case 1:
        case 42:
          this.renderLoading(g);
          break;
        case 2:
          this.renderLoading(g);
          break;
        case 4:
          this.renderMain(g);
          this.renderBanner(g);
          break;
        case 5:
          this.drawBG(g);
          this.renderGoalsScreen(g);
          this.renderBanner(g);
          break;
        case 8:
        case 9:
        case 19:
          this.renderSelectGame(g);
          this.renderBanner(g);
          break;
        case 10:
          this.renderSelectGame(g);
          this.drawGenericMessageBox(g);
          break;
        case 11:
        case 17:
        case 32:
        case 34:
        case 35:
          this.renderCAS(g);
          engine.renderBackgroundDim(g);
          this.drawGenericMessageBox(g);
          break;
        case 12:
        case 13:
        case 14:
        case 15:
        case 16:
          this.renderCAS(g);
          break;
        case 18:
          this.renderCAS(g);
          engine.renderBackgroundDim(g);
          this.drawGenericMessageBox(g);
          break;
        case 20:
        case 27:
          this.renderSelectGame(g);
          engine.renderBackgroundDim(g);
          this.drawGenericMessageBox(g);
          break;
        case 21:
          this.renderExportBegin(g);
          break;
        case 22:
          this.renderExportHeresHow(g);
          break;
        case 23:
          this.renderExportGetReady(g);
          break;
        case 24:
          this.renderExportSnapshot(g);
          break;
        case 25:
          this.renderExportDidYaGetIt(g);
          break;
        case 28:
          this.renderImportHelp(g);
          break;
        case 30:
        case 31:
          this.renderSelectGame(g);
          engine.renderBackgroundDim(g);
          this.drawGenericMessageBox(g);
          break;
        case 37:
        case 38:
          this.renderMain(g);
          this.renderBanner(g);
          engine.renderBackgroundDim(g);
          this.drawGenericMessageBox(g);
          break;
        case 39:
          this.drawBG(g);
          this.renderBanner(g);
          engine.renderBackgroundDim(g);
          this.m_achievementsMenu.render(g);
          break;
        case 40:
          this.drawBG(g);
          this.renderBanner(g);
          engine.renderBackgroundDim(g);
          this.m_leaderboardsMenu.render(g);
          break;
        case 41:
          this.drawBG(g);
          this.renderBanner(g);
          engine.renderBackgroundDim(g);
          this.m_achievementDetailMenu.render(g);
          break;
      }
      this.endUI();
      this.renderTapper(g);
    }
  }

  public override void update(int timeStep)
  {
    base.update(timeStep);
    this.m_stateTime += timeStep;
    if (this.m_state == 1)
      this.updateLoading(timeStep);
    else if (this.m_state == 42)
    {
      this.updateLoadingCAS(timeStep);
    }
    else
    {
      this.updateBG(timeStep);
      if (this.getSharedMenuState() != -1)
      {
        this.updateSharedMenu(timeStep);
        if (this.getSharedMenuState() != -1)
          return;
        this.stateTransition(this.m_state);
      }
      else
      {
        switch (this.m_state)
        {
          case 4:
            this.updateMain(timeStep);
            break;
          case 6:
            while (Guide.IsVisible)
              midp.JThread.sleep(500);
            this.stateTransition(4);
            break;
          case 7:
            this.updateMediaPicker(timeStep);
            break;
          case 8:
          case 9:
          case 19:
            this.updateSelectGame(timeStep);
            break;
          case 12:
          case 13:
          case 14:
          case 15:
          case 16:
            this.updateCAS(timeStep);
            break;
          case 29:
            this.updateImport(timeStep);
            break;
          case 39:
            this.m_achievementsMenu.update(timeStep);
            break;
          case 40:
            this.m_leaderboardsMenu.update(timeStep);
            break;
          case 41:
            this.m_achievementDetailMenu.update(timeStep);
            break;
        }
      }
    }
  }

  public void stateTransition(int newState)
  {
    AppEngine engine = this.m_engine;
    this.m_previousState = this.m_state;
    this.m_state = newState;
    this.m_stateTime = 0;
    engine.clearKeysPressedDown();
    engine.clearCommandKeys();
    if (this.m_previousState == 28)
      this.m_engine.getAnimationManager2D().unloadTexture(265);
    switch (newState)
    {
      case 1:
        this.m_loadingState = 0;
        engine.setSoftKeys(0, 0);
        engine.getBgMusic().playMusic(1, 2);
        break;
      case 2:
        engine.changeScene(this.m_nextScene, this.m_nextSceneState);
        break;
      case 4:
        engine.unloadAllImages(4, 0);
        break;
      case 5:
        this.initGoalsScreen();
        break;
      case 7:
        this.startMediaPicker();
        break;
      case 8:
        if (this.m_previousState == 9 || this.m_previousState == 19 || this.m_previousState == 17)
          break;
        this.getUIList(0).initList();
        break;
      case 10:
        this.prepareConfirmBox(44, 43);
        break;
      case 11:
        if (this.m_casEditMode)
        {
          this.prepareMessageBox(95, 93);
          break;
        }
        this.prepareMessageBox(124, 123);
        break;
      case 12:
        this.subStateTransitionCas(0);
        this.setNewCasCameraTarget(10012, 10001);
        this.setNewCasSimLocatorTarget(10021);
        break;
      case 13:
        this.setNewCasCameraTarget(10014, 10003);
        this.setNewCasSimLocatorTarget(10021);
        break;
      case 14:
        this.setNewCasCameraTarget(10015, 10004);
        this.setNewCasSimLocatorTarget(10021);
        break;
      case 15:
        this.subStateTransitionCas(10);
        this.setNewCasCameraTarget(10017, 10006);
        this.setNewCasSimLocatorTarget(10023);
        break;
      case 16:
        this.setNewCasCameraTarget(10012, 10001);
        this.setNewCasSimLocatorTarget(10021);
        break;
      case 17:
        this.prepareConfirmBox(46, 45);
        break;
      case 18:
        this.prepareConfirmBox(47, 40);
        break;
      case 20:
        this.prepareMessageBox(1748, 1746);
        break;
      case 21:
        this.initExport();
        TextManager textManager = engine.getTextManager();
        string simName = engine.getSimName();
        int stringid = this.m_simData.isSimMale(0) ? 1792 : 1793;
        string string1 = textManager.getString(stringid);
        textManager.dynamicString(-11, 1791, simName, string1);
        textManager.wrapString(-11, 1, 300);
        break;
      case 22:
        engine.getTextManager().wrapString(1795, 1, 180);
        break;
      case 23:
        engine.getTextManager().wrapString(1797, 1, 200);
        break;
      case 24:
        engine.getTextManager().wrapString(1801, 2, 100);
        break;
      case 25:
        engine.getTextManager().wrapString(1802, 1, 200);
        break;
      case 26:
        this.deinitExport();
        this.stateTransition(8);
        break;
      case 27:
        this.prepareMessageBox(1753, 1751);
        break;
      case 28:
        this.m_engine.getAnimationManager2D().loadTexture(265);
        engine.getTextManager().wrapString(1811, 1, 200);
        break;
      case 29:
        if (this.m_photoPicker == null)
          this.m_photoPicker = new PhotoPicker();
        this.m_photoPicker.activate(Display.getDisplay((MIDlet) AppEngine.getMIDlet()));
        break;
      case 30:
        this.prepareMessageBox(1754, 1751);
        break;
      case 31:
        this.prepareMessageBox(1755, 1751);
        break;
      case 32:
        engine.getTextManager().dynamicString(-11, 1752, engine.getSimName());
        this.prepareMessageBox(-11, 1751);
        break;
      case 33:
        this.m_casEditMode = true;
        this.stateTransition(42);
        SpywareManager.getInstance().trackCASPreEdit();
        break;
      case 34:
        this.prepareConfirmBox(1729, 506);
        break;
      case 35:
        this.prepareConfirmBox(1730, 506);
        break;
      case 36:
        this.m_engine.unloadAllImages(10, -1);
        break;
      case 37:
        this.m_engine.setRMSShownStorePrompt();
        this.stateTransition(4);
        break;
      case 38:
        this.prepareMessageBox(1726, 1725);
        break;
      case 39:
        this.m_achievementsMenu.init();
        break;
      case 40:
        this.m_leaderboardsMenu.init();
        break;
      case 41:
        this.m_achievementDetailMenu.init();
        break;
      case 42:
        if (this.m_casWorld == null)
        {
          this.m_loadingProgress = 0;
          this.loadingThread = new System.Threading.Thread(new ThreadStart(this.initCAS));
          this.loadingThread.Start();
          break;
        }
        this.initCAS();
        this.stateTransition(12);
        break;
    }
  }

  private void loadingCAS()
  {
    this.initCAS();
  }

  private void fadeStateTransition(int newState)
  {
    this.m_afterFadeState = newState;
    if (this.m_engine.isFadingOut())
      return;
    this.m_engine.startFadeOut();
  }

  private void changeScene(int nextScene, int state)
  {
    this.m_nextScene = nextScene;
    this.m_nextSceneState = state;
    this.fadeStateTransition(2);
  }

  private void initMainMenu()
  {
    int[] mainMenuItems = this.m_mainMenuItems;
    AppEngine.menuClear(mainMenuItems, 38);
    AppEngine.menuAppendItem(mainMenuItems, 48);
    if (MediaPicker.isAvailable())
      AppEngine.menuAppendItem(mainMenuItems, 1731);
    if (!TheSims3.IsTrialMode && XNAConnect.getGamer() != null)
    {
      AppEngine.menuAppendItem(mainMenuItems, 1814);
      AppEngine.menuAppendItem(mainMenuItems, 1815);
    }
    AppEngine.menuAppendItem(mainMenuItems, 49);
    AppEngine.menuAppendItem(mainMenuItems, 50);
    this.m_mainMenu.setItems(ref mainMenuItems, false);
    if (!TheSims3.IsTrialMode || this.btnUnlock != null)
      return;
    this.btnUnlock = new XNAButton(373, 210, 160, 110, XNAButton.Type.UNLOCK_GAME);
  }

  private void processAction(int action)
  {
    switch (action)
    {
      case 39:
        this.stateTransition(8);
        break;
      case 48:
        this.stateTransition(5);
        break;
      case 49:
        this.stateTransitionSharedMenu(0);
        break;
      case 50:
        this.stateTransitionSharedMenu(3);
        break;
      case 1725:
        this.stateTransition(38);
        break;
      case 1731:
        this.fadeStateTransition(7);
        break;
      case 1814:
        this.stateTransition(39);
        break;
      case 1815:
        this.stateTransition(40);
        break;
      default:
        AppEngine.ASSERT(false, "not implemented");
        break;
    }
  }

  private void startMoreGames(bool fromStore)
  {
    this.m_moreGamesFromStore = fromStore;
    if (fromStore)
      this.stateTransition(6);
    else
      this.fadeStateTransition(6);
  }

  private void startMediaPicker()
  {
    Display display = Display.getDisplay((MIDlet) AppEngine.getMIDlet());
    this.m_engine.getBgMusic().suspend();
    this.m_engine.getMediaPicker().activate(display);
  }

  private void updateMediaPicker(int timeStep)
  {
    if (Display.getDisplay((MIDlet) AppEngine.getMIDlet()).getCurrent() != this.m_engine)
      return;
    this.m_engine.getBgMusic().resume();
    this.stateTransition(4);
    this.m_engine.startFadeIn();
  }

  private void initBG()
  {
    World world = new World();
    this.m_bgWorld = world;
    Background background = new Background();
    background.setColorClearEnable(false);
    background.setDepthClearEnable(true);
    world.setBackground(background);
    this.m_bgCamera = new Camera();
    world.addChild((Node) this.m_bgCamera);
    world.setActiveCamera(this.m_bgCamera);
    this.m_bgCamera.setPerspective(80f, 0.6003752f, 5f, 2600f);
    this.m_bgCameraTransform = new Transform();
    this.m_bgCameraTransform.postRotate(90f, 0.0f, 0.0f, 1f);
    this.m_bgCamera.setTransform(this.m_bgCameraTransform);
    Node node = AppEngine.getResourceManager().loadM3GNode(292);
    ModelManager.getInstance().applyAppearances(node);
    ModelManager.applyCommit(node);
    world.addChild(node);
    this.m_bgAnimPlayer = new AnimPlayer3D(this.m_engine.getAnimationManager3D());
    this.m_bgAnimPlayer.setNode(node);
    this.m_bgAnimPlayer.startAnim(268, 20);
  }

  public void drawBG(Graphics g)
  {
    Graphics3D graphics3D = this.m_engine.getGraphics3D();
    graphics3D.bindTarget((object) g, JavaLib.GraphicsDevice);
    graphics3D.render(this.m_bgWorld);
    graphics3D.releaseTarget();
    this.renderTicker(g);
  }

  public void updateBG(int timeStep)
  {
    if (this.m_bgAnimPlayer == null)
      return;
    this.m_bgAnimPlayer.updateAnim(midp.JMath.max(1, timeStep / 3));
  }

  private void renderMain(Graphics g)
  {
    this.drawBG(g);
    this.m_mainMenu.render(g, true, this.m_state == 4);
    if (!TheSims3.IsTrialMode)
      return;
    g.Begin();
    this.btnUnlock.render(g);
    this.m_engine.getTextManager().wrapString(1879, 5, 140);
    this.m_engine.getTextManager().drawWrappedString(g, 5, 467, 306, 18);
    g.End();
  }

  private void updateMain(int timeStep)
  {
    if (this.m_stateTime > 1000 && !this.m_engine.getRMSShownStorePrompt())
      this.stateTransition(37);
    if (!TheSims3.IsTrialMode)
      return;
    this.btnUnlock.update(timeStep);
  }

  public bool isDeletingSaveGame()
  {
    return this.m_state == 9 || this.m_state == 10 || this.m_state == 19;
  }

  private void updateSelectGame(int timeStep)
  {
    this.m_activeGamePlumbBob.update(timeStep);
  }

  private void renderSelectGame(Graphics g)
  {
    AppEngine engine = this.m_engine;
    TextManager textManager = engine.getTextManager();
    AnimationManager2D animationManager2D = engine.getAnimationManager2D();
    bool enabled = this.m_state == 8 || this.m_state == 9 || this.m_state == 19;
    int rmsNumActiveGames = engine.getRMSNumActiveGames();
    int font = 6;
    this.drawBG(g);
    int num1 = engine.getWidth() - 72;
    int num2 = engine.getHeight() - 36 - 20;
    int num3 = num1 - 80;
    int x1 = 76 + (num3 >> 1) + 15;
    int num4 = x1 - (num3 >> 1);
    int num5 = num3 - 8;
    int num6 = num2 - 93;
    int x2 = x1 - (num3 >> 1) + 8;
    int w = num5 - 16;
    int num7 = num4 - 8;
    int num8 = num4 + num5 + 8 - 1;
    int num9 = num4 + (num5 >> 1);
    int num10 = 89 + num6 - 59;
    int num11 = (int) ((double) num5 / (double) animationManager2D.getAnimWidth((int) sbyte.MaxValue));
    animationManager2D.submitAnimGrid(321, 322, 323, 324, 325, 326, 327, 328, 329, 36f, 36f, (float) num1, (float) num2);
    animationManager2D.submitAnim(178, (float) num7, 156f);
    animationManager2D.submitAnim(179, (float) num8, 156f);
    animationManager2D.submitAnim(330, 61f, 68f);
    animationManager2D.submitAnimHBar(362, 363, 364, (float) x1, 79f, (float) num3);
    animationManager2D.flushAnims(g);
    g.Begin();
    textManager.drawString(g, this.m_state == 9 || this.m_state == 10 ? 55 : 54, font, x1, 74, 18);
    g.End();
    if (this.m_state == 9 || this.m_state == 10)
      engine.renderFade(g, 65, -11730944, 0, 0, engine.getWidth(), engine.getHeight());
    this.getUIButton(2).submit(ref animationManager2D, 61, 68, enabled);
    if (rmsNumActiveGames > 0 && this.m_state == 8)
    {
      animationManager2D.submitAnim(330, 61f, 265f);
      this.getUIButton(2048).submit(ref animationManager2D, 61, 265, enabled);
    }
    animationManager2D.submitAnimGrid(331, 332, 333, 334, 335, 336, 337, 338, 339, (float) num4, 89f, (float) num5, (float) num6);
    animationManager2D.submitAnim((int) sbyte.MaxValue, (float) num9, (float) num10, 1f, (float) num11, 1f);
    animationManager2D.flushAnims(g);
    int x3 = x1;
    int stringId;
    if (this.m_state == 19)
      stringId = 1747;
    else if (this.m_state == 9 || this.m_state == 10)
    {
      stringId = 1722;
    }
    else
    {
      switch (rmsNumActiveGames)
      {
        case 0:
          stringId = 1719;
          break;
        case 7:
          stringId = 1720;
          break;
        default:
          stringId = 1721;
          break;
      }
    }
    g.Begin();
    textManager.drawWrappedStringChunk(g, 0, stringId, 4, num3 >> 1, x3, 230, 18);
    g.End();
    UIList uiList = this.getUIList(0);
    uiList.setup(x2, 96, w, 120, enabled);
    uiList.render(g);
  }

  public UIObjectPreview getHudPlumbBob()
  {
    return this.m_activeGamePlumbBob;
  }

  private int encode1(int originalColor)
  {
    int num1 = (originalColor & 16711680) >> 16;
    int num2 = (originalColor & 65280) >> 8;
    int num3 = originalColor & (int) byte.MaxValue;
    int num4 = num2 + (num2 == (int) byte.MaxValue ? 16 : -16);
    return (num1 & (int) byte.MaxValue) << 16 | (num4 & (int) byte.MaxValue) << 8 | num3 & (int) byte.MaxValue;
  }

  private bool decode(int originalColor, int newColor)
  {
    return midp.JMath.abs(((originalColor & 65280) >> 8) - ((newColor & 65280) >> 8)) >= 7;
  }

  private void initExport()
  {
    this.m_engine.getAnimationManager2D().loadTexture(265);
    this.m_exportSimPreview.loadSim(0);
    if (this.m_exportSimBackground == null)
      this.m_exportSimBackground = ResourceManager.loadImage(297);
    this.m_exportData = this.m_simData.getExportData();
  }

  private void deinitExport()
  {
    this.m_exportSimPreview.unload();
    this.m_exportSimBackground = (Image) null;
    this.m_engine.getAnimationManager2D().unloadTexture(265);
  }

  private void submitExportBG()
  {
    AppEngine engine = this.m_engine;
    AnimationManager2D animationManager2D = engine.getAnimationManager2D();
    float width = (float) engine.getWidth();
    float height = (float) engine.getHeight();
    float animHeight = animationManager2D.getAnimHeight(20);
    float animWidth = animationManager2D.getAnimWidth(20);
    float scaleX = height / animWidth;
    float scaleY = width * 0.5f / animHeight;
    float x1 = width * 0.25f;
    float x2 = width * 0.75f;
    float y = height * 0.5f;
    animationManager2D.submitAnim(20, x1, y, 1f, -scaleX, scaleY, -90f);
    animationManager2D.submitAnim(20, x2, y, 1f, scaleX, scaleY, 90f);
  }

  private void submitExportHeader(float x, float y, float width, float height)
  {
    AnimationManager2D animationManager2D = this.m_engine.getAnimationManager2D();
    float animWidth = animationManager2D.getAnimWidth(19);
    float animHeight = animationManager2D.getAnimHeight(19);
    float scaleX = width * 0.5f / animWidth;
    float scaleY = height / animHeight;
    float x1 = x + width * 0.25f;
    float x2 = x + width * 0.75f;
    float y1 = y + height * 0.5f;
    animationManager2D.submitAnim(19, x1, y1, 1f, scaleX, scaleY);
    animationManager2D.submitAnim(19, x2, y1, 1f, -scaleX, scaleY);
  }

  private void renderExportBegin(Graphics g)
  {
    AppEngine engine = this.m_engine;
    AnimationManager2D animationManager2D = engine.getAnimationManager2D();
    TextManager textManager = engine.getTextManager();
    this.submitExportBG();
    float x1 = (float) (((double) engine.getWidth() - 380.0) * 0.5);
    this.submitExportHeader(x1, 16f, 380f, 55f);
    float num = (float) engine.getHeight() - 52f;
    float y1 = num;
    float y2 = num;
    float y3 = num;
    UIButton uiButton1 = this.getUIButton(4096);
    animationManager2D.submitAnim(330, 56f, y1);
    uiButton1.submit(ref animationManager2D, 56, (int) y1);
    UIButton uiButton2 = this.getUIButton(16777216);
    animationManager2D.submitAnim(330, 149f, y2);
    uiButton2.submit(ref animationManager2D, 149, (int) y2);
    UIButton uiButton3 = this.getUIButton(67108864);
    animationManager2D.submitAnim(330, 242f, y3);
    uiButton3.submit(ref animationManager2D, 242, (int) y3);
    animationManager2D.flushAnims(g);
    this.m_exportSimPreview.render(g, 353, 83, 160, 260);
    int x2 = (int) ((double) x1 + 190.0);
    int y4 = 43;
    textManager.drawString(g, 1790, 6, x2, y4, 18);
    int x3 = engine.getWidth() >> 1;
    textManager.drawWrappedString(g, 1, x3, 140, 18);
    int y5 = (int) ((double) num - 32.0);
    int chunk1 = 0;
    textManager.drawWrappedStringChunk(g, chunk1, 1803, 5, 85, 56, y5, 20);
    int chunk2 = chunk1 + 1;
    textManager.drawWrappedStringChunk(g, chunk2, 1804, 5, 85, 149, y5, 20);
    int chunk3 = chunk2 + 1;
    textManager.drawWrappedStringChunk(g, chunk3, 1805, 5, 85, 242, y5, 20);
  }

  private void renderExportHeresHow(Graphics g)
  {
    AppEngine engine = this.m_engine;
    AnimationManager2D animationManager2D = engine.getAnimationManager2D();
    TextManager textManager = engine.getTextManager();
    this.submitExportBG();
    float x1 = (float) ((double) engine.getWidth() - 180.0 - 10.0);
    this.submitExportHeader(x1, 16f, 180f, 45f);
    float num = (float) engine.getHeight() - 52f;
    float y1 = num;
    float y2 = num;
    float y3 = num;
    UIButton uiButton1 = this.getUIButton(4096);
    animationManager2D.submitAnim(330, 56f, y1);
    uiButton1.submit(ref animationManager2D, 56, (int) y1);
    UIButton uiButton2 = this.getUIButton(16777216);
    animationManager2D.submitAnim(330, 149f, y2);
    uiButton2.submit(ref animationManager2D, 149, (int) y2);
    UIButton uiButton3 = this.getUIButton(67108864);
    animationManager2D.submitAnim(330, 242f, y3);
    uiButton3.submit(ref animationManager2D, 242, (int) y3);
    animationManager2D.submitAnim(21, 151f, 113f, 1f, 1f, 1f, 10f);
    float alpha = midp.JMath.Cos((float) ((double) (this.m_stateTime % 1000) * 0.5 * 3.14159274101257 / 1000.0));
    animationManager2D.submitAnim(22, 37f, 96f, alpha, 1f, 1f, 10f);
    animationManager2D.submitAnim(23, 240f, 90f, alpha, 1f, 1f, 10f);
    animationManager2D.submitAnim(24, 21f, 96f);
    animationManager2D.submitAnim(24, 266f, 90f, 1f, -1f, 1f);
    animationManager2D.flushAnims(g);
    int x2 = (int) ((double) x1 + 90.0);
    int y4 = 38;
    textManager.drawString(g, 1794, 6, x2, y4, 18);
    int x3 = x2;
    int y5 = y4 + 25;
    textManager.drawWrappedString(g, 1, x3, y5, 17);
    int x4 = x3;
    textManager.drawWrappedStringChunk(g, 0, 1796, 0, 140, x4, 300, 20);
    int y6 = (int) num - 32;
    int chunk1 = 0;
    textManager.drawWrappedStringChunk(g, chunk1, 1803, 5, 80, 56, y6, 20);
    int chunk2 = chunk1 + 1;
    textManager.drawWrappedStringChunk(g, chunk2, 1804, 5, 80, 149, y6, 20);
    int chunk3 = chunk2 + 1;
    textManager.drawWrappedStringChunk(g, chunk3, 1805, 5, 80, 242, y6, 20);
  }

  private void renderExportGetReady(Graphics g)
  {
    AppEngine engine = this.m_engine;
    AnimationManager2D animationManager2D = engine.getAnimationManager2D();
    TextManager textManager = engine.getTextManager();
    this.submitExportBG();
    float num1 = (float) engine.getWidth() - 112f;
    float num2 = (float) engine.getHeight() - 52f;
    float y1 = num2;
    float x1 = (float) (56.0 + (double) num1 * 0.5);
    float y2 = num2;
    float x2 = 56f + num1;
    float y3 = num2;
    UIButton uiButton1 = this.getUIButton(4096);
    animationManager2D.submitAnim(330, 56f, y1);
    uiButton1.submit(ref animationManager2D, 56, (int) y1);
    UIButton uiButton2 = this.getUIButton(67108864);
    animationManager2D.submitAnim(330, x1, y2);
    uiButton2.submit(ref animationManager2D, (int) x1, (int) y2);
    UIButton uiButton3 = this.getUIButton(33554432);
    animationManager2D.submitAnim(330, x2, y3);
    uiButton3.submit(ref animationManager2D, (int) x2, (int) y3);
    animationManager2D.flushAnims(g);
    int x3 = engine.getWidth() >> 1;
    textManager.drawWrappedString(g, 1, x3, 110, 18);
    int y4 = (int) num2 - 32;
    int chunk1 = 0;
    textManager.drawWrappedStringChunk(g, chunk1, 1803, 5, 80, 56, y4, 20);
    int chunk2 = chunk1 + 1;
    textManager.drawWrappedStringChunk(g, chunk2, 1806, 5, 80, (int) x1, y4, 20);
    int chunk3 = chunk2 + 1;
    textManager.drawWrappedStringChunk(g, chunk3, 1807, 5, 80, (int) x2, y4, 20);
  }

  private void renderExportSnapshot(Graphics g)
  {
    AppEngine engine = this.m_engine;
    AnimationManager2D animationManager2D = engine.getAnimationManager2D();
    TextManager textManager = engine.getTextManager();
    g.drawImage(this.m_exportSimBackground, 0.0f, 0.0f, 9);
    int x1 = (engine.getWidth() - 250 >> 1) - 10;
    int y1 = engine.getHeight() - 300 >> 1;
    this.m_exportSimPreview.render(g, x1, y1, 250, 300);
    animationManager2D.submitAnim(530, 86f, 61f);
    int theTheTheTheAnim = this.getTheTheTheTheAnim();
    animationManager2D.submitAnim(theTheTheTheAnim, 46f, 61f, 1f, 0.4f, 0.4f);
    animationManager2D.flushAnims(g);
    textManager.drawWrappedStringChunk(g, 0, 1798, 2, 90, 89, 131, 18);
    textManager.drawString(g, engine.getSimName(), 7, 89, 161, 18);
    int num1 = textManager.getNumWrappedLines() * textManager.getLineHeight(3) + 40;
    int y2 = engine.getHalfHeight() - (num1 >> 1);
    int y3 = y2 + 18;
    int y4 = y3 + 30;
    int num2 = y3 + 20;
    float scaleX = 115f / animationManager2D.getAnimWidth(126);
    textManager.drawString(g, 1799, 7, 382, y2, 18);
    textManager.drawString(g, 1800, 3, 382, y3, 18);
    textManager.drawWrappedString(g, 2, 382, y4, 17);
    animationManager2D.submitAnim(126, 382f, (float) num2, 1f, scaleX);
    animationManager2D.flushAnims(g);
    int[] exportSimTempRgb = this.m_exportSimTempRGB;
    int x2 = 20;
    int y5 = 210;
    int length = this.m_exportData.Length;
    int num3 = length + 2;
    for (int index1 = 0; index1 < num3; ++index1)
    {
      int num4;
      switch (index1)
      {
        case 0:
          num4 = length & (int) byte.MaxValue;
          break;
        case 1:
          num4 = (length & 65280) >> 8;
          break;
        default:
          num4 = (int) this.m_exportData[index1 - 2];
          break;
      }
      int num5 = num4;
      for (int index2 = 0; index2 < 8; ++index2)
      {
        if ((num5 & 1 << index2) != 0)
        {
          int x3 = x2;
          int y6 = 319 - y5;
          this.m_exportSimBackground.getRGB(ref exportSimTempRgb, 0, 1, x3, y6, 1, 1);
          int colorRGB = this.encode1(exportSimTempRgb[0]);
          g.setColor(colorRGB);
          g.fillRect(x2, y5, 1, 1);
        }
        x2 += 4;
        if (x2 >= 150)
        {
          x2 = 20;
          y5 += 3;
        }
      }
    }
  }

  private void renderExportDidYaGetIt(Graphics g)
  {
    AppEngine engine = this.m_engine;
    AnimationManager2D animationManager2D = engine.getAnimationManager2D();
    TextManager textManager = engine.getTextManager();
    this.submitExportBG();
    float num1 = (float) engine.getWidth() - 112f;
    float num2 = (float) engine.getHeight() - 52f;
    float y1 = num2;
    float x1 = (float) (56.0 + (double) num1 * 0.5);
    float y2 = num2;
    float x2 = 56f + num1;
    float y3 = num2;
    UIButton uiButton1 = this.getUIButton(134217728);
    animationManager2D.submitAnim(330, 56f, y1);
    uiButton1.submit(ref animationManager2D, 56, (int) y1);
    UIButton uiButton2 = this.getUIButton(67108864);
    animationManager2D.submitAnim(330, x1, y2);
    uiButton2.submit(ref animationManager2D, (int) x1, (int) y2);
    UIButton uiButton3 = this.getUIButton(33554432);
    animationManager2D.submitAnim(330, x2, y3);
    uiButton3.submit(ref animationManager2D, (int) x2, (int) y3);
    animationManager2D.flushAnims(g);
    int x3 = engine.getWidth() >> 1;
    textManager.drawWrappedString(g, 1, x3, 110, 18);
    int y4 = (int) num2 - 32;
    int chunk1 = 0;
    textManager.drawWrappedStringChunk(g, chunk1, 1808, 5, 80, 56, y4, 20);
    int chunk2 = chunk1 + 1;
    textManager.drawWrappedStringChunk(g, chunk2, 1809, 5, 80, (int) x1, y4, 20);
    int chunk3 = chunk2 + 1;
    textManager.drawWrappedStringChunk(g, chunk3, 1810, 5, 80, (int) x2, y4, 20);
  }

  private bool decodeImportImage(Image image)
  {
    if (image == null || image.getWidth() != 320 || image.getHeight() != 480)
    {
      this.stateTransition(30);
      return false;
    }
    AppEngine engine = this.m_engine;
    Image image1 = ResourceManager.loadImage(297);
    int num1 = 20;
    int num2 = 210;
    int[] exportSimTempRgb = this.m_exportSimTempRGB;
    int length = 0;
    int num3 = 3;
    for (int index1 = 0; index1 < num3; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        int num4;
        switch (index1)
        {
          case 0:
            num4 = length & (int) byte.MaxValue;
            break;
          case 1:
            num4 = (length & 65280) >> 8;
            break;
          default:
            num4 = (int) this.m_exportData[index1 - 2];
            break;
        }
        int num5 = num4;
        int x1 = 319 - num2;
        int y1 = 479 - num1;
        image.getRGB(ref exportSimTempRgb, 0, 1, x1, y1, 1, 1);
        int newColor = exportSimTempRgb[0];
        int x2 = num1;
        int y2 = 319 - num2;
        image1.getRGB(ref exportSimTempRgb, 0, 1, x2, y2, 1, 1);
        if (this.decode(exportSimTempRgb[0], newColor))
          num5 |= 1 << index2;
        switch (index1)
        {
          case 0:
            length = num5;
            break;
          case 1:
            length |= 65280 & num5 << 8;
            if (index2 == 7)
            {
              num3 = length + 2;
              if (num3 < 8 || num3 > 512)
              {
                this.stateTransition(30);
                return false;
              }
              this.m_exportData = new byte[length];
              break;
            }
            break;
          default:
            this.m_exportData[index1 - 2] = (byte) num5;
            break;
        }
        num1 += 4;
        if (num1 >= 150)
        {
          num1 = 20;
          num2 += 3;
          if (num2 >= engine.getHeight())
          {
            this.stateTransition(30);
            return false;
          }
        }
      }
    }
    int index3 = -1;
    for (int index1 = 0; index1 < 7; ++index1)
    {
      if (!engine.getRMSActiveGame(index1))
      {
        index3 = index1;
        break;
      }
    }
    engine.setRMSGameSlotIndex(index3);
    engine.resetRMSGameData();
    switch (this.m_simData.loadExportData(this.m_exportData))
    {
      case 0:
        this.m_casImportMode = true;
        engine.startFadeIn();
        this.stateTransition(42);
        SpywareManager.getInstance().trackImport();
        return true;
      case 1:
      case 2:
        this.stateTransition(30);
        return false;
      case 3:
        this.stateTransition(31);
        return false;
      default:
        this.stateTransition(30);
        return false;
    }
  }

  private void updateImport(int timeStep)
  {
    if (Display.getDisplay((MIDlet) AppEngine.getMIDlet()).getCurrent() != this.m_engine)
      return;
    Image photo = this.m_photoPicker.getPhoto();
    this.m_photoPicker.releasePhoto();
    if (photo != null)
    {
      this.decodeImportImage(photo);
    }
    else
    {
      this.stateTransition(8);
      this.m_engine.startFadeIn();
    }
  }

  private void renderImportHelp(Graphics g)
  {
    AppEngine engine = this.m_engine;
    AnimationManager2D animationManager2D = engine.getAnimationManager2D();
    TextManager textManager = engine.getTextManager();
    this.submitExportBG();
    float num1 = (float) engine.getWidth() - 240f;
    float num2 = (float) engine.getHeight() - 52f;
    float y1 = num2;
    float x1 = 120f + num1;
    float y2 = num2;
    UIButton uiButton1 = this.getUIButton(4096);
    animationManager2D.submitAnim(330, 120f, y1);
    uiButton1.submit(ref animationManager2D, 120, (int) y1);
    UIButton uiButton2 = this.getUIButton(67108864);
    animationManager2D.submitAnim(330, x1, y2);
    uiButton2.submit(ref animationManager2D, (int) x1, (int) y2);
    animationManager2D.flushAnims(g);
    int x2 = engine.getWidth() >> 1;
    textManager.drawWrappedString(g, 1, x2, 110, 18);
    int y3 = (int) num2 - 32;
    int chunk1 = 0;
    textManager.drawWrappedStringChunk(g, chunk1, 1813, 5, 80, 120, y3, 20);
    int chunk2 = chunk1 + 1;
    textManager.drawWrappedStringChunk(g, chunk2, 1812, 5, 80, (int) x1, y3, 20);
  }

  private void updateBanner(int timeStep)
  {
    bool flag = (this.m_state == 4 || this.m_state == 37) && this.getSharedMenuState() == -1 && !this.m_engine.isFading();
    Image bannerImage = MTXStoreManager.getInstance().getBannerImage();
    if (flag && bannerImage != this.m_bannerImage && (double) this.m_bannerFilter.getFilteredValue() < 1.0 / 1000.0)
    {
      this.m_bannerImage = bannerImage;
      this.m_bannerURL = MTXStoreManager.getInstance().getBannerURL();
    }
    if (flag && bannerImage == this.m_bannerImage)
      this.m_bannerFilter.setTargetValue(1f);
    else
      this.m_bannerFilter.setTargetValue(0.0f);
    this.m_bannerFilter.update(timeStep);
  }

  public void renderBanner(Graphics g)
  {
    float filteredValue = this.m_bannerFilter.getFilteredValue();
    if ((double) filteredValue <= 1.0 / 1000.0 || this.m_bannerImage == null)
      return;
    float num1 = midp.JMath.min(filteredValue, 1f);
    float num2 = midp.JMath.max(1f - num1, 0.0f);
    int num3 = this.m_engine.getHeight() - this.m_bannerImage.getHeight();
    int num4 = this.m_engine.getHeight() + this.m_bannerImage.getHeight();
    int num5 = (int) ((double) num1 * 0.0 + (double) num2 * 0.0);
    int num6 = (int) ((double) num1 * (double) num3 + (double) num2 * (double) num4);
    g.drawImage(this.m_bannerImage, (float) num5, (float) num6, 9);
  }

  private void updateTicker(int timeStep)
  {
    bool flag = (this.m_state == 4 || this.m_state == 37) && this.getSharedMenuState() == -1 && !this.m_engine.isFading();
    string tickerString = MTXStoreManager.getInstance().getTickerString(this.m_tickerIndex);
    if (flag && tickerString != this.m_tickerString && (double) this.m_tickerFilter.getFilteredValue() < 0.00999999977648258)
    {
      this.m_tickerString = tickerString;
      this.m_tickerURL = MTXStoreManager.getInstance().getTickerURL(this.m_tickerIndex);
      if (tickerString != null)
      {
        for (int index = 0; index < this.m_tickerStringBits.Length; ++index)
        {
          int length1 = this.m_tickerString.Length;
          int num = length1 / 2;
          int startIndex = index * num;
          int length2 = startIndex + num;
          if (index == this.m_tickerStringBits.Length - 1)
            length2 = length1;
          this.m_tickerStringBits[index] = this.m_tickerString.Substring(startIndex, length2);
        }
        this.m_tickerWidth = this.m_engine.getTextManager().getStringWidth(tickerString, 2);
      }
      else
        this.m_tickerWidth = 0;
      this.m_tickerTimer = 0;
      this.m_tickerTimerMax = 5000 + this.m_tickerWidth * 10;
    }
    else if (!flag && (double) this.m_tickerFilter.getFilteredValue() < 0.00999999977648258)
    {
      this.m_tickerTimer = 0;
    }
    else
    {
      this.m_tickerTimer += timeStep;
      if (this.m_tickerTimer >= this.m_tickerTimerMax)
      {
        this.m_tickerFilter.setSteadyState(0.0f);
        int tickerCount = MTXStoreManager.getInstance().getTickerCount();
        if (tickerCount > 0)
          this.m_tickerIndex = (this.m_tickerIndex + 1) % tickerCount;
      }
    }
    if (flag && tickerString == this.m_tickerString)
      this.m_tickerFilter.setTargetValue(1f);
    else
      this.m_tickerFilter.setTargetValue(0.0f);
    this.m_tickerFilter.update(timeStep);
  }

  private void renderTicker(Graphics g)
  {
    float filteredValue = this.m_tickerFilter.getFilteredValue();
    if ((double) filteredValue <= 1.0 / 1000.0 || this.m_tickerString == null)
      return;
    TextManager textManager = this.m_engine.getTextManager();
    AnimationManager2D animationManager2D = this.m_engine.getAnimationManager2D();
    float num1 = MathExt.clip((float) (this.m_tickerTimer - 5000) / (float) (this.m_tickerTimerMax - 5000), 0.0f, 1f);
    float num2 = midp.JMath.max(1f - num1, 0.0f);
    float num3 = midp.JMath.min(filteredValue, 1f);
    float num4 = midp.JMath.max(1f - num3, 0.0f);
    int num5 = -this.m_tickerWidth - 10;
    int num6 = midp.JMath.max(10, this.m_engine.getWidth() - this.m_tickerWidth >> 1);
    int num7 = (int) ((double) num1 * (double) num5 + (double) num2 * (double) num6);
    int y1 = (int) ((double) num3 * 10.0 + (double) num4 * -10.0);
    float y2 = (float) (y1 - 10);
    int width = this.m_engine.getWidth();
    int animHeight = (int) animationManager2D.getAnimHeight(172);
    animationManager2D.submitAnimStretched(172, 0.0f, y2, (float) width, (float) animHeight);
    animationManager2D.flushAnims(g);
    int x = num7;
    for (int index = 0; index < this.m_tickerStringBits.Length; ++index)
    {
      textManager.drawString(g, this.m_tickerStringBits[index], 1, x, y1, 10);
      x += textManager.getStringWidth(this.m_tickerStringBits[index], 1);
    }
  }

  private void updateCASCamera(int timeStep)
  {
    if (this.getPointerState() == 0 && this.m_casDragReleaseTime > 0)
    {
      float num = (float) ((double) this.m_casDragVelYaw * (double) this.m_casDragReleaseTime / 1000.0);
      this.m_casDragReleaseTime -= timeStep;
      this.m_casYaw = (float) MathExt.normaliseAngleDegreesF((int) ((double) this.m_casYaw + (double) num * (double) timeStep));
    }
    this.m_casCameraLookatXFilter.update(timeStep);
    this.m_casCameraLookatYFilter.update(timeStep);
    this.m_casCameraLookatZFilter.update(timeStep);
    this.m_casCameraLookfromXFilter.update(timeStep);
    this.m_casCameraLookfromYFilter.update(timeStep);
    this.m_casCameraLookfromZFilter.update(timeStep);
    ModelManager.createLookAtTransform(this.m_casCameraTransform, this.m_casCameraLookfromXFilter.getFilteredValue(), this.m_casCameraLookfromYFilter.getFilteredValue(), this.m_casCameraLookfromZFilter.getFilteredValue(), this.m_casCameraLookatXFilter.getFilteredValue(), this.m_casCameraLookatYFilter.getFilteredValue(), this.m_casCameraLookatZFilter.getFilteredValue(), 0.0f, 1f, 0.0f);
    this.m_casCameraTransform.postRotate(90f, 0.0f, 0.0f, 1f);
    this.m_casCamera.setTransform(this.m_casCameraTransform);
  }

  private bool isCameraInTargetPosition()
  {
    float targetValue = this.m_casCameraLookatXFilter.getTargetValue();
    float filteredValue = this.m_casCameraLookatXFilter.getFilteredValue();
    return (double) midp.JMath.abs(this.m_casCameraLookfromXFilter.getTargetValue() - this.m_casCameraLookfromXFilter.getFilteredValue()) < 0.00999999977648258 && (double) midp.JMath.abs(targetValue - filteredValue) < 0.00999999977648258;
  }

  private void getCasRoomLocatorPosition(int userId, float[] result)
  {
    Node.m3g_cast(this.m_casRoomGroup.find(userId)).getTranslation(ref result);
  }

  private void getCasRoomLocatorOrientation(int userId, float[] result)
  {
    Node.m3g_cast(this.m_casRoomGroup.find(userId)).getOrientationQuat(ref result);
  }

  private void setNewCasSimLocatorTarget(int locatorId)
  {
    this.getCasRoomLocatorPosition(locatorId, this.m_tempFloat4_1);
    this.m_simLocatorXFilter.setTargetValue(this.m_tempFloat4_1[0]);
    this.m_simLocatorYFilter.setTargetValue(this.m_tempFloat4_1[1]);
    this.m_simLocatorZFilter.setTargetValue(this.m_tempFloat4_1[2]);
    this.getCasRoomLocatorOrientation(locatorId, this.m_tempFloat4_1);
    float targetValue = (float) (360.0 * (double) midp.JMath.acos(this.m_tempFloat4_1[3]) / 3.14159274101257);
    if ((double) targetValue <= -180.0)
      targetValue += 360f;
    else if ((double) targetValue >= 180.0)
      targetValue -= 360f;
    this.m_simLocatorRotFilter.setSteadyState(MathExt.normaliseAngleDegrees(this.m_simLocatorRotFilter.getFilteredValue() + this.m_casYaw));
    this.m_casYaw = 0.0f;
    this.m_casDragVelYaw = 0.0f;
    this.m_casDragReleaseTime = 0;
    this.m_simLocatorRotFilter.setTargetValue(targetValue);
  }

  private void setNewCasCameraTarget(int lookFromLocatorId, int lookAtLocatorId)
  {
    this.getCasRoomLocatorPosition(lookFromLocatorId, this.m_tempFloat4_1);
    this.m_casCameraLookfromXFilter.setTargetValue(this.m_tempFloat4_1[0]);
    this.m_casCameraLookfromYFilter.setTargetValue(this.m_tempFloat4_1[1]);
    this.m_casCameraLookfromZFilter.setTargetValue(this.m_tempFloat4_1[2]);
    this.getCasRoomLocatorPosition(lookAtLocatorId, this.m_tempFloat4_1);
    this.m_casCameraLookatXFilter.setTargetValue(this.m_tempFloat4_1[0]);
    this.m_casCameraLookatYFilter.setTargetValue(this.m_tempFloat4_1[1]);
    this.m_casCameraLookatZFilter.setTargetValue(this.m_tempFloat4_1[2]);
  }

  private bool casIsValid(int attrib, int uniqueId)
  {
    return (this.m_simWorld.getSimMeshFlags(this.m_simData.mapAttributeToMeshAttrib(0, attrib), uniqueId) & 4) == 0;
  }

  private void casInitOptions()
  {
    if (this.m_casUniqueOptions == null || this.m_casUniqueOptions.Length == 0)
      this.m_casUniqueOptions = new int[13][];
    bool male = this.m_simData.isSimMale(0);
    int simAttributeUnique = this.m_simData.getSimAttributeUnique(0, 0);
    for (int index1 = 0; index1 < 13; ++index1)
    {
      switch (index1)
      {
        case 0:
          this.m_casUniqueOptions[index1] = new int[2];
          this.m_casUniqueOptions[index1][0] = 0;
          this.m_casUniqueOptions[index1][1] = 1;
          break;
        case 1:
        case 2:
        case 4:
        case 5:
        case 7:
        case 9:
        case 11:
          int simAttributeMax1 = this.m_simWorld.getSimAttributeMax(0, index1);
          int length = 0;
          for (int optIndex = 0; optIndex < simAttributeMax1; ++optIndex)
          {
            int unique = this.m_simData.mapSimAttributeToUnique(male, index1, optIndex);
            if (this.casIsValid(index1, unique))
              ++length;
          }
          if (simAttributeUnique == this.m_casTempUnlocked[0] && this.m_casTempUnlocked[index1] != -1)
            ++length;
          if (this.m_casUniqueOptions[index1] == null || this.m_casUniqueOptions[index1].Length != length)
            this.m_casUniqueOptions[index1] = new int[length];
          int num1 = 0;
          for (int optIndex = 0; optIndex < simAttributeMax1; ++optIndex)
          {
            int unique = this.m_simData.mapSimAttributeToUnique(male, index1, optIndex);
            if (this.casIsValid(index1, unique))
              this.m_casUniqueOptions[index1][num1++] = unique;
          }
          if (simAttributeUnique == this.m_casTempUnlocked[0] && this.m_casTempUnlocked[index1] != -1)
          {
            int[] casUniqueOption = this.m_casUniqueOptions[index1];
            int index2 = num1;
            int num2 = index2 + 1;
            int num3 = this.m_casTempUnlocked[index1];
            casUniqueOption[index2] = num3;
            break;
          }
          break;
        case 3:
        case 6:
        case 8:
        case 10:
        case 12:
          int attributeTypeForColor = SimData.getAttributeTypeForColor(index1);
          if (simAttributeUnique == this.m_casTempUnlocked[0] && this.m_simData.getSimAttributeUnique(0, attributeTypeForColor) == this.m_casTempUnlocked[attributeTypeForColor])
          {
            this.m_casUniqueOptions[index1] = new int[1];
            this.m_casUniqueOptions[index1][0] = this.m_casTempUnlocked[index1];
            break;
          }
          int simAttributeMax2 = this.m_simWorld.getSimAttributeMax(0, index1);
          if (this.m_casUniqueOptions[index1] == null || this.m_casUniqueOptions[index1].Length != simAttributeMax2)
            this.m_casUniqueOptions[index1] = new int[simAttributeMax2];
          for (int index2 = 0; index2 < simAttributeMax2; ++index2)
            this.m_casUniqueOptions[index1][index2] = index2;
          break;
      }
    }
  }

  private bool casChange(int attrib, int changeDir)
  {
    int[] casUniqueOption = this.m_casUniqueOptions[attrib];
    int simAttributeUnique = this.m_simData.getSimAttributeUnique(0, attrib);
    int num = AppEngine.indexOf(simAttributeUnique, casUniqueOption);
    int length = casUniqueOption.Length;
    int index1 = (num + length + changeDir) % length;
    int index2 = casUniqueOption[index1];
    if (index2 == simAttributeUnique)
      return false;
    this.m_simData.setPlayerSimAttributeUnique(attrib, index2);
    if (attrib == 0)
    {
      for (int attribute = 0; attribute < 13; ++attribute)
      {
        this.m_casBackup[simAttributeUnique][attribute] = this.m_simData.getSimAttributeUnique(0, attribute);
        if (attribute != 0 && attribute != 1 && (attribute != 3 && attribute != 4))
          this.m_simData.setPlayerSimAttributeUnique(attribute, this.m_casBackup[index2][attribute]);
      }
    }
    else
    {
      int attributeColorForType = SimData.getAttributeColorForType(attrib);
      if (attributeColorForType != -1)
        this.m_simData.setPlayerSimAttributeUnique(attributeColorForType, 0);
    }
    this.casInitOptions();
    if (this.m_simData.getSimAttributeUnique(0, 3) >= this.m_casUniqueOptions[3].Length)
      this.m_simData.setPlayerSimAttributeUnique(3, 0);
    return true;
  }

  private bool isAttributeDisabled(int attrib)
  {
    AppEngine engine = this.m_engine;
    SimData simData = engine.getSimData();
    SimWorld simWorld = engine.getSimWorld();
    if (this.m_casUniqueOptions[attrib].Length <= 1)
      return true;
    int simAttributeUnique = simData.getSimAttributeUnique(0, 11);
    int meshAttrib = simData.mapAttributeToMeshAttrib(0, 11);
    int simMeshFlags = simWorld.getSimMeshFlags(meshAttrib, simAttributeUnique);
    switch (attrib)
    {
      case 1:
        if ((simMeshFlags & 8) != 0 || (simMeshFlags & 16) != 0)
          return true;
        break;
      case 2:
        if ((simMeshFlags & 1) != 0)
          return true;
        break;
    }
    return false;
  }

  private bool isAttributeColorDisabled(int attribColor)
  {
    return attribColor != -1 && this.m_simWorld.getSimAttributeMax(0, attribColor) <= 1;
  }

  private void subStateTransitionCas(int newSubState)
  {
    this.m_casSubState = newSubState;
  }

  private void initCAS()
  {
    if (this.m_casWorld == null)
    {
      this.m_loadingProgress = 0;
      World world = new World();
      this.m_casCamera = new Camera();
      world.addChild((Node) this.m_casCamera);
      world.setActiveCamera(this.m_casCamera);
      this.m_casCamera.setPerspective(50f, (float) this.m_engine.getHeight() / (float) this.m_engine.getWidth(), 5f, 2600f);
      this.m_casCameraTransform = new Transform();
      this.m_loadingProgress = 20;
      this.m_casSimModel = new Model();
      world.addChild(this.m_casSimModel.getNode());
      this.m_casSimModelReflection = new Model();
      world.addChild(this.m_casSimModelReflection.getNode());
      this.m_loadingProgress = 30;
      this.m_casRoomGroup = Group.m3g_cast((Object3D) ModelManager.getInstance().getModel(176, false));
      ModelManager instance = ModelManager.getInstance();
      this.m_casRoomGroupReflection = Group.m3g_cast(this.m_casRoomGroup.duplicate());
      instance.overrideAppearance((Node) this.m_casRoomGroupReflection, 81, instance.getAppearance(32));
      Appearance appearance = instance.getAppearance(36);
      instance.overrideAppearance((Node) this.m_casRoomGroupReflection, 80, appearance);
      Node.m3g_cast(this.m_casRoomGroupReflection.find(10049)).setRenderingEnable(false);
      Node.m3g_cast(this.m_casRoomGroupReflection.find(10048)).setRenderingEnable(false);
      Node.m3g_cast(this.m_casRoomGroupReflection.find(10050)).setRenderingEnable(false);
      world.addChild((Node) this.m_casRoomGroupReflection);
      ModelManager.applyCommit((Node) this.m_casRoomGroupReflection);
      world.addChild((Node) this.m_casRoomGroup);
      ModelManager.applyCommit((Node) this.m_casRoomGroup);
      this.m_loadingProgress = 50;
      this.m_casMirrorTransform = new Transform();
      float[] result1 = new float[3];
      float[] result2 = new float[3];
      float[] result3 = new float[3];
      this.getCasRoomLocatorPosition(10024, result1);
      this.getCasRoomLocatorPosition(10025, result2);
      this.getCasRoomLocatorPosition(10026, result3);
      float[] numArray1 = new float[3];
      float[] numArray2 = new float[3];
      numArray1[0] = result2[0] - result1[0];
      numArray1[1] = result2[1] - result1[1];
      numArray1[2] = result2[2] - result1[2];
      numArray2[0] = result3[0] - result1[0];
      numArray2[1] = result3[1] - result1[1];
      numArray2[2] = result3[2] - result1[2];
      float[] numArray3 = new float[3]
      {
        (float) ((double) numArray1[1] * (double) numArray2[2] - (double) numArray1[2] * (double) numArray2[1]),
        (float) ((double) numArray1[2] * (double) numArray2[0] - (double) numArray1[0] * (double) numArray2[2]),
        (float) ((double) numArray1[0] * (double) numArray2[1] - (double) numArray1[1] * (double) numArray2[0])
      };
      float num = 1f / midp.JMath.sqrt((float) ((double) numArray3[0] * (double) numArray3[0] + (double) numArray3[1] * (double) numArray3[1] + (double) numArray3[2] * (double) numArray3[2]));
      numArray3[0] *= num;
      numArray3[1] *= num;
      numArray3[2] *= num;
      ModelManager.createReflectionTransform(this.m_casMirrorTransform, numArray3[0], numArray3[1], numArray3[2], result1[0], result1[1], result1[2]);
      this.m_loadingProgress = 70;
      this.loadSim();
      this.m_casWorld = world;
      this.m_loadingProgress = 90;
    }
    if (this.m_previousState != 11 && this.m_previousState != 32 && (this.m_previousState != 17 && this.m_previousState != 34) && (this.m_previousState != 35 && this.m_previousState != 13))
    {
      this.m_casIntroTutorialShown = !this.m_engine.getTutorialsEnabled();
      for (int index = 0; index < this.m_casBackup.Length; ++index)
        this.m_casBackup[index] = new int[13];
      for (int index = 0; index < 13; ++index)
      {
        this.m_casBackup[0][index] = 0;
        this.m_casBackup[1][index] = 0;
      }
      this.m_casYaw = 0.0f;
      this.m_casDragVelYaw = 0.0f;
      this.m_casDragReleaseTime = 0;
      if (!this.m_casEditMode && !this.m_casImportMode)
      {
        this.m_engine.resetRMSGameData();
        this.m_engine.setSimName((string) null);
      }
      if (this.m_casImportMode)
      {
        int simMeshFlags = this.m_simWorld.getSimMeshFlags(this.m_simData.mapAttributeToMeshAttrib(0, 11), this.m_simData.getSimAttributeUnique(0, 11));
        if ((simMeshFlags & 1) != 0)
        {
          this.m_simData.setPlayerSimAttributeUnique(2, 0);
          this.m_simData.setPlayerSimAttributeUnique(3, 0);
        }
        if ((simMeshFlags & 8) != 0 || (simMeshFlags & 16) != 0)
          this.m_simData.setPlayerSimAttributeUnique(1, 0);
      }
      for (int index = 0; index < 13; ++index)
        this.m_casTempUnlocked[index] = -1;
      for (int index = 0; index < 13; ++index)
      {
        if (this.m_simData.getSimAttributeByIndex(0, index) == -1 || index == 0)
        {
          int simAttributeUnique = this.m_simData.getSimAttributeUnique(0, index);
          this.m_casTempUnlocked[index] = simAttributeUnique;
          int attributeColorForType = SimData.getAttributeColorForType(index);
          if (attributeColorForType != -1)
            this.m_casTempUnlocked[attributeColorForType] = this.m_simData.getSimAttributeUnique(0, attributeColorForType);
        }
      }
      this.casInitOptions();
      this.loadSim();
      this.getUIList(1).initList();
      this.getUIList(2).initList();
      this.getCasRoomLocatorPosition(10021, this.m_tempFloat4_1);
      this.m_simLocatorXFilter.setSteadyState(this.m_tempFloat4_1[0]);
      this.m_simLocatorYFilter.setSteadyState(this.m_tempFloat4_1[1]);
      this.m_simLocatorZFilter.setSteadyState(this.m_tempFloat4_1[2]);
      this.m_simLocatorRotFilter.setSteadyState(0.0f);
      if (this.m_casRoomGroupReflection != null)
        this.m_casRoomGroupReflection.setTransform(this.m_casMirrorTransform);
      this.getCasRoomLocatorPosition(10012, this.m_tempFloat4_1);
      this.m_casCameraLookfromXFilter.setSteadyState(this.m_tempFloat4_1[0]);
      this.m_casCameraLookfromYFilter.setSteadyState(this.m_tempFloat4_1[1]);
      this.m_casCameraLookfromZFilter.setSteadyState(this.m_tempFloat4_1[2]);
      this.getCasRoomLocatorPosition(10001, this.m_tempFloat4_1);
      this.m_casCameraLookatXFilter.setSteadyState(this.m_tempFloat4_1[0]);
      this.m_casCameraLookatYFilter.setSteadyState(this.m_tempFloat4_1[1]);
      this.m_casCameraLookatZFilter.setSteadyState(this.m_tempFloat4_1[2]);
      this.m_appearancePanelAlphaFilter.setSteadyState(0.0f);
      this.m_UIBarAlphaFilterFeet.setSteadyState(0.0f);
      this.m_UIBarAlphaFilterLegs.setSteadyState(0.0f);
      this.m_UIBarAlphaFilterTorso.setSteadyState(0.0f);
      this.m_UIBarAlphaFilterHairstyle.setSteadyState(0.0f);
      this.m_UIBarAlphaFilterHead.setSteadyState(0.0f);
      this.m_UIBarAlphaFilterEyes.setSteadyState(0.0f);
      this.m_UIBarAlphaFilterSex.setSteadyState(0.0f);
      this.m_UIBarAlphaFilterSkin.setSteadyState(0.0f);
      this.m_randomiseNotifyAlphaFilter.setSteadyState(0.0f);
      this.restartCASSim();
    }
    this.m_loadingProgress = 100;
  }

  private void loadSim()
  {
    this.m_casSimModel.assembleSimForCAS(this.m_casSimModelReflection);
  }

  private void restartCASSim()
  {
    int animID = !this.m_simData.isSimMale(0) ? 111 : 8;
    this.m_simTestAnimIndex = 0;
    this.m_casSimModel.getAnimPlayer3D().startAnim(animID, 16);
    this.m_casSimModelReflection.getAnimPlayer3D().startAnim(animID, 16);
  }

  private void updateCASSim(int timeStep)
  {
    this.m_simLocatorXFilter.update(timeStep);
    this.m_simLocatorYFilter.update(timeStep);
    this.m_simLocatorZFilter.update(timeStep);
    this.m_simLocatorRotFilter.update(timeStep);
    if (this.m_casSimModel == null)
      return;
    bool flag = this.m_state == 12 && (this.m_casSubState == 3 || this.m_casSubState == 4 || this.m_casSubState == 5) || this.m_state == 15;
    this.m_casSimModel.getAnimPlayer3D().updateAnim(timeStep);
    this.m_casSimModelReflection.getAnimPlayer3D().updateAnim(timeStep);
    if (!this.m_casSimModel.getAnimPlayer3D().isAnimating())
    {
      int[] numArray1 = new int[9]
      {
        8,
        6,
        5,
        8,
        6,
        8,
        8,
        5,
        8
      };
      int[] numArray2 = new int[1]{ 111 };
      int animID;
      if (this.m_simData.isSimMale(0))
      {
        animID = numArray1[this.m_simTestAnimIndex];
        this.m_simTestAnimIndex = flag ? 0 : (this.m_simTestAnimIndex + 1) % numArray1.Length;
      }
      else
      {
        if (this.m_simTestAnimIndex >= numArray2.Length)
          this.m_simTestAnimIndex = 0;
        animID = numArray2[this.m_simTestAnimIndex];
        this.m_simTestAnimIndex = flag ? 0 : (this.m_simTestAnimIndex + 1) % numArray2.Length;
      }
      this.m_casSimModel.getAnimPlayer3D().startAnim(animID, 16);
      this.m_casSimModelReflection.getAnimPlayer3D().startAnim(animID, 16);
    }
    this.m_casSimModel.getNode().setTranslation(this.m_simLocatorXFilter.getFilteredValue(), this.m_simLocatorYFilter.getFilteredValue(), this.m_simLocatorZFilter.getFilteredValue());
    this.m_casSimModel.getNode().setOrientation(this.m_simLocatorRotFilter.getFilteredValue() + this.m_casYaw, 0.0f, 1f, 0.0f);
    this.m_tempTransform.set(this.m_casMirrorTransform);
    this.m_tempTransform.postTranslate(this.m_simLocatorXFilter.getFilteredValue(), this.m_simLocatorYFilter.getFilteredValue(), this.m_simLocatorZFilter.getFilteredValue());
    this.m_tempTransform.postRotate(this.m_simLocatorRotFilter.getFilteredValue() + this.m_casYaw, 0.0f, 1f, 0.0f);
    this.m_casSimModelReflection.getNode().setTransform(this.m_tempTransform);
    if (this.m_casRoomGroupReflection == null)
      return;
    this.m_casRoomGroupReflection.setTransform(this.m_casMirrorTransform);
  }

  private void renderCAS(Graphics g)
  {
    Graphics3D graphics3D = this.m_engine.getGraphics3D();
    graphics3D.bindTarget((object) g, JavaLib.GraphicsDevice);
    graphics3D.render(this.m_casWorld);
    graphics3D.releaseTarget();
    if (this.m_state == 11 || this.m_state == 32 || (this.m_state == 12 || this.m_state == 17) || (this.m_state == 34 || this.m_state == 35))
      this.renderCASAppearance(g);
    else if (this.m_state == 13)
    {
      if ((double) this.m_appearancePanelAlphaFilter.getFilteredValue() > 0.01)
        this.renderCASAppearance(g);
      this.renderCASPersona(g);
    }
    else if (this.m_state == 14)
      this.renderCASTraits(g);
    else if (this.m_state == 15)
      this.renderCASName(g);
    else if (this.m_state == 16)
    {
      this.renderCASSimInfo(g);
    }
    else
    {
      if (this.m_state != 18)
        return;
      this.renderCASName(g);
    }
  }

  private void updateCAS(int timeStep)
  {
    if (this.m_casImportMode && this.m_stateTime > 500)
    {
      this.m_casImportMode = false;
      this.stateTransition(32);
    }
    else if (!this.m_casIntroTutorialShown && this.m_stateTime > 500)
    {
      this.m_casIntroTutorialShown = true;
      this.stateTransition(11);
    }
    else
    {
      this.updateCASCamera(timeStep);
      this.updateCASSim(timeStep);
      this.updateUIBarsVisibility(timeStep);
      if (this.m_state != 12 || this.m_casSubState != 9 || !this.isCameraInTargetPosition())
        return;
      this.m_randomiseSimRequested = (double) this.m_randomiseNotifyAlphaFilter.getFilteredValue() > 0.970000028610229;
      if (!this.m_randomiseMessageDrawn)
        return;
      this.setRandomSimAppearance();
      this.m_randomiseSimRequested = false;
      this.m_randomiseMessageDrawn = false;
      this.subStateTransitionCas(0);
    }
  }

  private void getColorButtonScreenCoordsFromAttributeIndex(
    int attribIdx,
    ref int buttonX,
    ref int buttonY)
  {
    for (int index = 0; index < SceneMenu.CAS_APPEARANCE_BUTTONS.Length; index += 11)
    {
      if (SceneMenu.CAS_APPEARANCE_BUTTONS[index + 5] == attribIdx)
      {
        buttonX = SceneMenu.CAS_APPEARANCE_BUTTONS[index] - 50;
        buttonY = SceneMenu.CAS_APPEARANCE_BUTTONS[index + 1];
        break;
      }
    }
  }

  private void setRandomSimAppearance()
  {
    int index1 = this.m_engine.rand(0, 1);
    this.m_simData.setPlayerSimAttributeUnique(0, index1);
    for (int attribute = 0; attribute < 13; ++attribute)
    {
      if (attribute != 0)
      {
        this.casInitOptions();
        int index2 = this.m_engine.rand(0, this.m_casUniqueOptions[attribute].Length - 1);
        int num = this.m_casUniqueOptions[attribute][index2];
        this.m_simData.setPlayerSimAttributeUnique(attribute, num);
      }
    }
    for (int attribute = 0; attribute < 13; ++attribute)
      this.m_casBackup[index1][attribute] = this.m_simData.getSimAttributeUnique(0, attribute);
    this.loadSim();
    this.restartCASSim();
  }

  private void renderCASAppearance(Graphics g)
  {
    AppEngine engine = this.m_engine;
    TextManager textManager = engine.getTextManager();
    AnimationManager2D animationManager2D = engine.getAnimationManager2D();
    DLCManager instance = DLCManager.getInstance();
    float filteredValue = this.m_appearancePanelAlphaFilter.getFilteredValue();
    int num1 = this.m_casEditMode ? 506 : 1087;
    int num2 = 47 + textManager.getStringWidth(num1, 4) + 20 + 16;
    animationManager2D.submitAnimHBar(168, 169, 170, (float) (5 + (num2 >> 1)), 32f, (float) num2, filteredValue, 1f);
    animationManager2D.flushAnims(g);
    this.getUIButton(4096).submit(ref animationManager2D, 32, 32);
    animationManager2D.flushAnims(g);
    g.Begin();
    textManager.drawString(g, num1, 4, 62, 32, 10);
    g.End();
    animationManager2D.submitAnim(424, 500f, 284f);
    this.getUIButton(8192).submit(ref animationManager2D, 500, 284);
    if (!this.m_casEditMode)
      animationManager2D.submitAnim(166, 45f, 205f, filteredValue, 1f);
    animationManager2D.submitAnim(167, 500f, 130f, filteredValue, 1f);
    if (!this.m_casEditMode)
      animationManager2D.submitAnim(422, 48f, 275f, filteredValue, 1f);
    for (int index = 0; index < SceneMenu.CAS_APPEARANCE_BUTTONS.Length; index += 11)
    {
      if (!this.m_casEditMode || SceneMenu.CAS_APPEARANCE_BUTTONS[index + 8] != 0)
      {
        float num3 = (float) SceneMenu.CAS_APPEARANCE_BUTTONS[index + 5];
        float num4 = (float) SceneMenu.CAS_APPEARANCE_BUTTONS[index + 6];
        bool flag1 = this.isAttributeDisabled((int) num3);
        bool flag2 = this.isAttributeColorDisabled((int) num4);
        float x = (float) SceneMenu.CAS_APPEARANCE_BUTTONS[index];
        float y = (float) SceneMenu.CAS_APPEARANCE_BUTTONS[index + 1];
        float num5 = (float) SceneMenu.CAS_APPEARANCE_BUTTONS[index + 3];
        float num6 = (float) SceneMenu.CAS_APPEARANCE_BUTTONS[index + 4];
        float num7 = (float) SceneMenu.CAS_APPEARANCE_BUTTONS[index + 7];
        bool flag3 = (double) num7 == (double) this.m_casSubState;
        float alpha1 = filteredValue;
        float alpha2 = filteredValue;
        if (flag1)
        {
          alpha1 *= 0.35f;
          alpha2 *= 0.3f;
        }
        float alpha3 = filteredValue;
        if (flag2)
          alpha3 *= 0.35f;
        if ((double) num4 != -1.0 && (double) num7 == (double) this.m_casSubState)
        {
          animationManager2D.submitAnim(420, x - 50f, y + 0.0f, alpha3, 1f, 1f);
          animationManager2D.flushAnims(g);
        }
        if (flag3)
        {
          animationManager2D.submitAnim(423, x, y, filteredValue, 1.42f, 1.42f);
          animationManager2D.flushAnims(g);
        }
        int num8 = flag3 ? 1 : 1;
        animationManager2D.submitAnim(419, x, y, alpha2, (float) num8, (float) num8);
        animationManager2D.submitAnim(flag3 ? (int) num6 : (int) num5, x, y, alpha1, 1f, 1f);
      }
    }
    animationManager2D.flushAnims(g);
    animationManager2D.submitAnim(261, (float) (this.m_engine.getWidth() >> 1), (float) (this.m_engine.getHeight() >> 1), this.m_randomiseNotifyAlphaFilter.getFilteredValue());
    animationManager2D.flushAnims(g);
    if (this.m_randomiseSimRequested)
      this.m_randomiseMessageDrawn = true;
    for (int index = 0; index < SceneMenu.CAS_APPEARANCE_BUTTONS.Length; index += 11)
    {
      if (!this.m_casEditMode || SceneMenu.CAS_APPEARANCE_BUTTONS[index + 8] != 0)
      {
        bool flag = this.m_simData.isSimMale(0);
        if (SceneMenu.CAS_APPEARANCE_BUTTONS[index + (flag ? 9 : 10)] != -1)
        {
          int num3 = SceneMenu.CAS_APPEARANCE_BUTTONS[index + 5];
          int uniquePackId = SimWorld.getUniquePackId(this.m_simData.getSimAttributeUnique(0, num3));
          if (!this.isAttributeDisabled(num3) && uniquePackId != 0)
          {
            Image tagByUniquePackId = instance.getPackTagByUniquePackId(uniquePackId);
            if (tagByUniquePackId != null)
            {
              int num4 = SceneMenu.CAS_APPEARANCE_BUTTONS[index];
              int num5 = SceneMenu.CAS_APPEARANCE_BUTTONS[index + 1];
              int num6 = num4 + (num4 < engine.getHalfWidth() ? -20 : 20);
              int num7 = num5 - 19;
              g.Begin();
              g.drawImage(tagByUniquePackId, (float) num6, (float) num7, 18);
              g.End();
            }
          }
        }
      }
    }
  }

  private void updateUIBarsVisibility(int timeStep)
  {
    bool flag1 = this.isCameraInTargetPosition();
    this.m_UIBarAlphaFilterFeet.update(timeStep);
    this.m_UIBarAlphaFilterLegs.update(timeStep);
    this.m_UIBarAlphaFilterTorso.update(timeStep);
    this.m_UIBarAlphaFilterHairstyle.update(timeStep);
    this.m_UIBarAlphaFilterHead.update(timeStep);
    this.m_UIBarAlphaFilterEyes.update(timeStep);
    this.m_UIBarAlphaFilterSex.update(timeStep);
    this.m_UIBarAlphaFilterSkin.update(timeStep);
    this.m_randomiseNotifyAlphaFilter.update(timeStep);
    this.m_appearancePanelAlphaFilter.update(timeStep);
    bool flag2 = flag1 && this.m_state == 12 && this.m_casSubState == 8;
    bool flag3 = flag1 && this.m_state == 12 && this.m_casSubState == 7;
    bool flag4 = flag1 && this.m_state == 12 && this.m_casSubState == 4;
    bool flag5 = flag1 && this.m_state == 12 && this.m_casSubState == 5;
    bool flag6 = flag1 && this.m_state == 12 && this.m_casSubState == 3;
    bool flag7 = flag1 && this.m_state == 12 && this.m_casSubState == 6;
    bool flag8 = flag1 && this.m_state == 12 && this.m_casSubState == 1;
    bool flag9 = flag1 && this.m_state == 12 && this.m_casSubState == 2;
    bool flag10 = flag1 && this.m_state == 12 && this.m_casSubState == 9;
    this.m_UIBarAlphaFilterFeet.setTargetValue(flag2 ? 1f : 0.0f);
    this.m_UIBarAlphaFilterLegs.setTargetValue(flag3 ? 1f : 0.0f);
    this.m_UIBarAlphaFilterTorso.setTargetValue(flag7 ? 1f : 0.0f);
    this.m_UIBarAlphaFilterHairstyle.setTargetValue(flag4 || flag5 ? 1f : 0.0f);
    this.m_UIBarAlphaFilterHead.setTargetValue(flag5 ? 1f : 0.0f);
    this.m_UIBarAlphaFilterEyes.setTargetValue(flag6 ? 1f : 0.0f);
    this.m_UIBarAlphaFilterSex.setTargetValue(flag8 ? 1f : 0.0f);
    this.m_UIBarAlphaFilterSkin.setTargetValue(flag9 ? 1f : 0.0f);
    this.m_randomiseNotifyAlphaFilter.setTargetValue(flag10 ? 1f : 0.0f);
    float targetValue = 0.0f;
    if (this.m_state == 12 && flag10)
      targetValue = 0.6f;
    else if (this.m_state == 12)
      targetValue = 1f;
    this.m_appearancePanelAlphaFilter.setTargetValue(targetValue);
    this.setUIBarAlphaFactor(10027, this.m_UIBarAlphaFilterFeet.getFilteredValue());
    this.setUIBarAlphaFactor(10030, this.m_UIBarAlphaFilterLegs.getFilteredValue());
    this.setUIBarAlphaFactor(10033, this.m_UIBarAlphaFilterTorso.getFilteredValue());
    this.setUIBarAlphaFactor(10036, this.m_UIBarAlphaFilterHairstyle.getFilteredValue());
    this.setUIBarAlphaFactor(10039, this.m_UIBarAlphaFilterEyes.getFilteredValue());
    this.setUIBarAlphaFactor(10042, this.m_UIBarAlphaFilterSex.getFilteredValue());
    this.setUIBarAlphaFactor(10045, this.m_UIBarAlphaFilterSkin.getFilteredValue());
    Node node1 = Node.m3g_cast(this.m_casRoomGroup.find(10027));
    Node node2 = Node.m3g_cast(this.m_casRoomGroup.find(10030));
    Node node3 = Node.m3g_cast(this.m_casRoomGroup.find(10033));
    Node node4 = Node.m3g_cast(this.m_casRoomGroup.find(10036));
    Node node5 = Node.m3g_cast(this.m_casRoomGroup.find(10039));
    Node node6 = Node.m3g_cast(this.m_casRoomGroup.find(10042));
    Node node7 = Node.m3g_cast(this.m_casRoomGroup.find(10045));
    node1.setRenderingEnable((double) this.m_UIBarAlphaFilterFeet.getFilteredValue() > 0.00999999977648258);
    node2.setRenderingEnable((double) this.m_UIBarAlphaFilterLegs.getFilteredValue() > 0.00999999977648258);
    node4.setRenderingEnable((double) this.m_UIBarAlphaFilterHairstyle.getFilteredValue() > 0.00999999977648258);
    node5.setRenderingEnable((double) this.m_UIBarAlphaFilterEyes.getFilteredValue() > 0.00999999977648258);
    node3.setRenderingEnable((double) this.m_UIBarAlphaFilterTorso.getFilteredValue() > 0.00999999977648258);
    node6.setRenderingEnable((double) this.m_UIBarAlphaFilterSex.getFilteredValue() > 0.00999999977648258);
    node7.setRenderingEnable((double) this.m_UIBarAlphaFilterSkin.getFilteredValue() > 0.00999999977648258);
  }

  private void setUIBarAlphaFactor(int userID, float alphaFactor)
  {
    Group group = Group.m3g_cast(this.m_casRoomGroup.find(userID));
    int childCount = group.getChildCount();
    for (int index = 0; index < childCount; ++index)
    {
      Mesh mesh = Mesh.m3g_cast((Object3D) group.getChild(index));
      if (mesh != null)
      {
        mesh.setAlphaFactor(alphaFactor);
        break;
      }
    }
  }

  private void renderCASPersona(Graphics g)
  {
    if (!this.isCameraInTargetPosition())
      return;
    AppEngine engine = this.m_engine;
    TextManager textManager = engine.getTextManager();
    AnimationManager2D animationManager2D = engine.getAnimationManager2D();
    animationManager2D.submitAnimGrid(321, 322, 323, 324, 325, 326, 327, 328, 329, 5f, 5f, 280f, 290f);
    animationManager2D.flushAnims(g);
    animationManager2D.submitAnimHBar(362, 363, 364, 158f, 47f, 200f);
    animationManager2D.submitAnimGrid(331, 332, 333, 334, 335, 336, 337, 338, 339, 50f, 70f, 200f, 194f);
    animationManager2D.submitAnim(178, 42f, 133f);
    animationManager2D.submitAnim(179, 257f, 133f);
    animationManager2D.flushAnims(g);
    g.Begin();
    textManager.drawString(g, 133, 6, 158, 44, 18);
    g.End();
    UIList uiList = this.getUIList(1);
    uiList.setup(54, 80, 192, 174);
    uiList.render(g);
    animationManager2D.submitAnim(424, 29f, 35f);
    this.getUIButton(2).submit(ref animationManager2D, 29, 35);
    animationManager2D.submitAnim(424, 240f, 288f);
    this.getUIButton(32).submit(ref animationManager2D, 240, 288);
    animationManager2D.flushAnims(g);
    animationManager2D.submitAnimHBar(359, 360, 361, 380f, 280f, 200f, 1f);
    animationManager2D.flushAnims(g);
    textManager.wrapString(1108, 4, 130);
    g.Begin();
    textManager.drawWrappedString(g, 4, 380, 278, 18);
    g.End();
  }

  private void updateCASPersona(int timeStep)
  {
    this.updateCASSim(timeStep);
  }

  private void renderCASTraits(Graphics g)
  {
    if (!this.isCameraInTargetPosition())
      return;
    AppEngine engine = this.m_engine;
    TextManager textManager = engine.getTextManager();
    AnimationManager2D animationManager2D = engine.getAnimationManager2D();
    animationManager2D.submitAnimGrid(321, 322, 323, 324, 325, 326, 327, 328, 329, 190f, 5f, 340f, 290f);
    animationManager2D.submitAnimHBar(362, 363, 364, 370f, 47f, 260f, 35f);
    animationManager2D.submitAnimGrid(331, 332, 333, 334, 335, 336, 337, 338, 339, 240f, 70f, 260f, 190f);
    animationManager2D.flushAnims(g);
    g.Begin();
    textManager.drawString(g, 1124, 6, 370, 44, 18);
    g.End();
    UIList uiList = this.getUIList(2);
    uiList.setup(250, 80, 240, 170);
    uiList.render(g);
    animationManager2D.submitAnim(424, 212f, 35f);
    this.getUIButton(2).submit(ref animationManager2D, 212, 35);
    int num = 260;
    int numPlayerTraits = this.m_simData.getNumPlayerTraits();
    for (int index = 0; index < 5; ++index)
    {
      animationManager2D.submitAnim(135, (float) num, 270f, 1f, 1.3f, 1.3f);
      animationManager2D.flushAnims(g);
      if (index < numPlayerTraits)
      {
        animationManager2D.submitAnim(114, (float) num, 270f, 1f, 0.6f, 0.6f);
        animationManager2D.flushAnims(g);
      }
      num += 40;
    }
    if (this.m_simData.getNumPlayerTraits() == 5)
    {
      animationManager2D.submitAnim(424, 480f, 288f);
      this.getUIButton(32).submit(ref animationManager2D, 480, 288);
      animationManager2D.flushAnims(g);
    }
    animationManager2D.submitAnimHBar(359, 360, 361, 103f, 280f, 200f, 1f);
    animationManager2D.flushAnims(g);
    g.Begin();
    textManager.drawWrappedStringChunk(g, 0, 1125, 4, 130, 103, 278, 18);
    g.End();
  }

  private void updateCASTraits(int timeStep)
  {
    this.updateCASSim(timeStep);
  }

  private void renderCASName(Graphics g)
  {
    if (!this.isCameraInTargetPosition())
      return;
    AppEngine engine = this.m_engine;
    TextManager textManager = engine.getTextManager();
    AnimationManager2D animationManager2D = engine.getAnimationManager2D();
    int num1 = engine.getWidth() >> 1;
    bool enabled = this.m_casSubState != 11 && this.m_state != 18;
    float num2 = (float) engine.getHeight() - 48f;
    this.getUIButton(2).submit(ref animationManager2D, 48, (int) num2, enabled);
    int x1 = num1;
    animationManager2D.submitAnimHBar(263, 264, 265, (float) x1, 30f, 300f, 1f, 0.75f);
    animationManager2D.submitAnimHBar(362, 363, 364, (float) x1, 34f, 250f);
    animationManager2D.flushAnims(g);
    g.Begin();
    textManager.drawString(g, 1127, 6, x1, 30, 18);
    g.End();
    animationManager2D.submitAnimGrid(266, 269, 272, 267, 270, 273, 268, 271, 274, 90f, 230f, 300f, 100f);
    int x2 = x1;
    animationManager2D.submitAnimHBar(287, 288, 289, (float) x2, 290f, 160f);
    animationManager2D.submitAnimHBar(290, 291, 292, (float) x2, 290f, 160f);
    animationManager2D.flushAnims(g);
    g.Begin();
    textManager.drawString(g, 1128, 4, x2, 290, 18);
    g.End();
    animationManager2D.submitAnim(275, (float) x1, 254f);
    animationManager2D.flushAnims(g);
    string simName = engine.getSimName();
    if (simName != null)
    {
      float num3 = (float) engine.getWidth() - 48f;
      float num4 = (float) engine.getHeight() - 48f;
      this.getUIButton(8192).submit(ref animationManager2D, (int) num3, (int) num4, enabled);
      animationManager2D.flushAnims(g);
      int x3 = x1;
      int y = 254 + ((int) animationManager2D.getAnimHeight(275) >> 1) - 15;
      g.Begin();
      textManager.drawString(g, simName, 4, x3, y, 18);
      g.End();
    }
    if (this.m_casSubState != 11)
      return;
    engine.renderBackgroundDim(g);
    this.drawGenericMessageBox(g);
  }

  private void updateCASName(int timeStep)
  {
    this.updateCASSim(timeStep);
  }

  private void renderCASSimInfo(Graphics g)
  {
    AppEngine engine = this.m_engine;
    AnimationManager2D animationManager2D = engine.getAnimationManager2D();
    bool enabled = this.m_state != 18;
    float num1 = (float) engine.getHeight() - 48f;
    this.getUIButton(2).submit(ref animationManager2D, 48, (int) num1, enabled);
    float num2 = (float) engine.getWidth() - 48f;
    float num3 = (float) engine.getHeight() - 48f;
    this.getUIButton(8192).submit(ref animationManager2D, (int) num2, (int) num3, enabled);
    animationManager2D.flushAnims(g);
  }
}
