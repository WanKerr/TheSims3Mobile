// Decompiled with JetBrains decompiler
// Type: SpywareManager
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using ea_sdk;
using midp;
using sims3;

public class SpywareManager : GlobalConstants
{
  private static SpywareManager instance = new SpywareManager();
  private string m_lastStore = "";
  public const int EVT_SIMS3_SOUND = 221;
  public const int EVT_SIMS3_MUSIC = 222;
  public const int EVT_SIMS3_TUTORIALS = 223;
  public const int EVT_SIMS3_AUTONOMOUS = 224;
  public const int EVT_SIMS3_LANGUAGE = 225;
  public const int EVT_SIMS3_NEWGAME = 226;
  public const int EVT_SIMS3_DELETEGAME = 227;
  public const int EVT_SIMS3_RESETDATA = 228;
  public const int EVT_SIMS3_STARTGAME = 229;
  public const int EVT_SIMS3_ENDGAME = 231;
  public const int EVT_SIMS3_ENDGAME_DEATH = 255;
  public const int EVT_SIMS3_PLAYTIME = 230;
  public const int EVT_SIMS3_EXPORTGAME = 442;
  public const int EVT_SIMS3_IMPORTGAME = 443;
  public const int EVT_SIMS3_MOREGAMES_OPEN = 461;
  public const int EVT_SIMS3_MOREGAMES_CLOSE = 462;
  public const int EVT_SIMS3_MOREGAMES_LAUNCH = 532;
  public const int EVT_SIMS3_CAS_CREATED = 241;
  public const int EVT_SIMS3_CAS_GENDER = 235;
  public const int EVT_SIMS3_CAS_SKIN = 236;
  public const int EVT_SIMS3_CAS_HAIR = 232;
  public const int EVT_SIMS3_CAS_HEAD = 441;
  public const int EVT_SIMS3_CAS_EYES = 234;
  public const int EVT_SIMS3_CAS_TORSO = 233;
  public const int EVT_SIMS3_CAS_LEGS = 237;
  public const int EVT_SIMS3_CAS_FEET = 238;
  public const int EVT_SIMS3_CAS_PERSONA = 239;
  public const int EVT_SIMS3_CAS_TRAIT1 = 240;
  public const int EVT_SIMS3_CAS_TRAIT2 = 240;
  public const int EVT_SIMS3_CAS_TRAIT3 = 240;
  public const int EVT_SIMS3_CAS_TRAIT4 = 240;
  public const int EVT_SIMS3_CAS_TRAIT5 = 240;
  public const int EVT_SIMS3_CAS_EDITED = 242;
  public const int EVT_SIMS3_EDIT_HAIR = 232;
  public const int EVT_SIMS3_EDIT_HEAD = 441;
  public const int EVT_SIMS3_EDIT_TORSO = 233;
  public const int EVT_SIMS3_EDIT_LEGS = 237;
  public const int EVT_SIMS3_EDIT_FEET = 238;
  public const int EVT_SIMS3_ARRIVE = 253;
  public const int EVT_SIMS3_LEAVE = 254;
  public const int EVT_SIMS3_STORE_OPEN = 246;
  public const int EVT_SIMS3_STORE_CLOSE = 248;
  public const int EVT_SIMS3_MINIGAME_START = 249;
  public const int EVT_SIMS3_MINIGAME_SUCCESS = 250;
  public const int EVT_SIMS3_MINIGAME_FAIL = 251;
  public const int EVT_SIMS3_GOALCOMPLETE = 252;
  public const int EVT_SIMS3_ACTION = 257;
  public const int EVT_SIMS3_JOBCHANGE = 256;
  public const int EVT_SIMS3_BUY_WALL = 244;
  public const int EVT_SIMS3_BUY_FLOOR = 243;
  public const int EVT_SIMS3_BUY_ITEM = 247;
  public const int EVT_SIMS3_BUY_OBJECT = 247;
  private long m_gameStart;
  private int m_casHairType;
  private int m_casHairColor;
  private int m_casHeadType;
  private int m_casHeadColor;
  private int m_casTorsoType;
  private int m_casTorsoColor;
  private int m_casLegsType;
  private int m_casLegsColor;
  private int m_casFeetType;
  private int m_casFeetColor;
  private int m_location;
  private int m_locationMap;

  private SpywareManager()
  {
    this.m_gameStart = -1L;
    this.m_casHairType = -1;
    this.m_casHairColor = -1;
    this.m_casHeadType = -1;
    this.m_casHeadColor = -1;
    this.m_casTorsoType = -1;
    this.m_casTorsoColor = -1;
    this.m_casLegsType = -1;
    this.m_casLegsColor = -1;
    this.m_casFeetType = -1;
    this.m_casFeetColor = -1;
    this.m_location = -1;
    this.m_locationMap = -1;
    this.m_lastStore = (string) null;
  }

  public new void Dispose()
  {
  }

  public static SpywareManager getInstance()
  {
    return SpywareManager.instance;
  }

  public bool isEnabled()
  {
    return EASpywareManager.getInstance().isEnabled();
  }

  public void setEnabled(bool enabled)
  {
    EASpywareManager.getInstance().setEnabled(enabled);
  }

  public void trackOptionToggle(int stringId, bool enabled)
  {
    int eventId = -1;
    switch (stringId)
    {
      case 67:
        eventId = 221;
        break;
      case 68:
        eventId = 222;
        break;
      case 70:
        eventId = 223;
        break;
      case 71:
        eventId = 224;
        break;
    }
    if (eventId == -1)
      return;
    string str = enabled ? "on" : "off";
    EASpywareManager.getInstance().logEvent(eventId, str);
  }

  public void trackOptionLanguage()
  {
    EASpywareManager.getInstance().logEvent(225, LocaleManager.getInstance().getLocale());
  }

  public void trackNewGame(int slot, string simName)
  {
    string slotStr = string.Concat((object) slot);
    EASpywareManager.getInstance().logEvent(226, simName, slotStr);
  }

  public void trackDeleteGame(int slot, string simName)
  {
    string slotStr = string.Concat((object) slot);
    EASpywareManager.getInstance().logEvent(227, simName, slotStr);
  }

  public void trackResetData()
  {
    EASpywareManager.getInstance().logEvent(228);
  }

  public void trackStartGame()
  {
    this.m_gameStart = JSystem.currentTimeMillis();
    EASpywareManager.getInstance().logEvent(229, AppEngine.getCanvas().getSimName(), string.Concat((object) AppEngine.getCanvas().getRMSGameSlotIndex()));
  }

  public void trackEndGame()
  {
    EASpywareManager.getInstance().logEvent(231, AppEngine.getCanvas().getSimName());
    this.trackPlayTime();
  }

  public void trackEndGameDeath(string deathType)
  {
    EASpywareManager.getInstance().logEvent((int) byte.MaxValue, AppEngine.getCanvas().getSimName(), deathType);
    this.trackPlayTime();
  }

  private void trackPlayTime()
  {
    EASpywareManager.getInstance().logEventDuration(230, (int) ((JSystem.currentTimeMillis() - this.m_gameStart) / 1000L));
  }

  public void trackExport()
  {
    EASpywareManager.getInstance().logEvent(442, AppEngine.getCanvas().getSimName(), string.Concat((object) AppEngine.getCanvas().getRMSGameSlotIndex()));
  }

  public void trackImport()
  {
    EASpywareManager.getInstance().logEvent(443, AppEngine.getCanvas().getSimName(), string.Concat((object) AppEngine.getCanvas().getRMSGameSlotIndex()));
  }

  public void trackMoreGamesOpen()
  {
    EASpywareManager.getInstance().logEvent(461);
  }

  public void trackMoreGamesClose()
  {
    EASpywareManager.getInstance().logEvent(462);
  }

  public void trackMoreGamesAppLaunch()
  {
    EASpywareManager.getInstance().logEvent(532);
  }

  public void trackCASPreEdit()
  {
    SimData simData = AppEngine.getCanvas().getSimData();
    this.m_casHairType = simData.getSimAttributeUnique(0, 2);
    this.m_casHairColor = simData.getSimAttributeUnique(0, 3);
    this.m_casHeadType = simData.getSimAttributeUnique(0, 11);
    this.m_casHeadColor = simData.getSimAttributeUnique(0, 12);
    this.m_casTorsoType = simData.getSimAttributeUnique(0, 5);
    this.m_casTorsoColor = simData.getSimAttributeUnique(0, 6);
    this.m_casLegsType = simData.getSimAttributeUnique(0, 7);
    this.m_casLegsColor = simData.getSimAttributeUnique(0, 8);
    this.m_casFeetType = simData.getSimAttributeUnique(0, 9);
    this.m_casFeetColor = simData.getSimAttributeUnique(0, 10);
  }

  public void trackCAS(bool edited)
  {
    EASpywareManager instance = EASpywareManager.getInstance();
    SimData simData = AppEngine.getCanvas().getSimData();
    string simName = AppEngine.getCanvas().getSimName();
    string slotStr = string.Concat((object) AppEngine.getCanvas().getRMSGameSlotIndex());
    int simAttributeUnique1 = simData.getSimAttributeUnique(0, 0);
    int simAttributeUnique2 = simData.getSimAttributeUnique(0, 1);
    int simAttributeUnique3 = simData.getSimAttributeUnique(0, 2);
    int simAttributeUnique4 = simData.getSimAttributeUnique(0, 3);
    int simAttributeUnique5 = simData.getSimAttributeUnique(0, 4);
    int simAttributeUnique6 = simData.getSimAttributeUnique(0, 11);
    int simAttributeUnique7 = simData.getSimAttributeUnique(0, 12);
    int simAttributeUnique8 = simData.getSimAttributeUnique(0, 5);
    int simAttributeUnique9 = simData.getSimAttributeUnique(0, 6);
    int simAttributeUnique10 = simData.getSimAttributeUnique(0, 7);
    int simAttributeUnique11 = simData.getSimAttributeUnique(0, 8);
    int simAttributeUnique12 = simData.getSimAttributeUnique(0, 9);
    int simAttributeUnique13 = simData.getSimAttributeUnique(0, 10);
    if (!edited)
    {
      instance.logEvent(241, simName, slotStr);
      instance.logEvent(226, simName, slotStr);
      instance.logEvent(235, simAttributeUnique1 == 0 ? "male" : "female");
      instance.logEvent(236, simAttributeUnique2);
      instance.logEvent(232, simAttributeUnique3, simAttributeUnique4);
      instance.logEvent(441, simAttributeUnique6, simAttributeUnique7);
      instance.logEvent(234, simAttributeUnique5);
      instance.logEvent(233, simAttributeUnique8, simAttributeUnique9);
      instance.logEvent(237, simAttributeUnique10, simAttributeUnique11);
      instance.logEvent(238, simAttributeUnique12, simAttributeUnique13);
      int persona = simData.getPersona();
      string str1 = GlobalConstants.LOOKUP_PERSONA[persona];
      instance.logEvent(239, str1);
      int simTrait1 = simData.getSimTrait(0, 0);
      string str2 = GlobalConstants.LOOKUP_TRAIT[simTrait1];
      instance.logEvent(240, str2);
      int simTrait2 = simData.getSimTrait(0, 1);
      string str3 = GlobalConstants.LOOKUP_TRAIT[simTrait2];
      instance.logEvent(240, str3);
      int simTrait3 = simData.getSimTrait(0, 2);
      string str4 = GlobalConstants.LOOKUP_TRAIT[simTrait3];
      instance.logEvent(240, str4);
      int simTrait4 = simData.getSimTrait(0, 3);
      string str5 = GlobalConstants.LOOKUP_TRAIT[simTrait4];
      instance.logEvent(240, str5);
      int simTrait5 = simData.getSimTrait(0, 4);
      string str6 = GlobalConstants.LOOKUP_TRAIT[simTrait5];
      instance.logEvent(240, str6);
    }
    else
    {
      instance.logEvent(242, simName, slotStr);
      if (this.m_casHairType != simAttributeUnique3 || this.m_casHairColor != simAttributeUnique4)
        instance.logEvent(232, simAttributeUnique3, simAttributeUnique4);
      if (this.m_casHeadType != simAttributeUnique6 || this.m_casHeadColor != simAttributeUnique7)
        instance.logEvent(441, simAttributeUnique6, simAttributeUnique7);
      if (this.m_casTorsoType != simAttributeUnique8 || this.m_casTorsoColor != simAttributeUnique9)
        instance.logEvent(233, simAttributeUnique8, simAttributeUnique9);
      if (this.m_casLegsType != simAttributeUnique10 || this.m_casLegsColor != simAttributeUnique11)
        instance.logEvent(237, simAttributeUnique10, simAttributeUnique11);
      if (this.m_casFeetType == simAttributeUnique12 && this.m_casFeetColor == simAttributeUnique13)
        return;
      instance.logEvent(238, simAttributeUnique12, simAttributeUnique13);
    }
  }

  public void trackArrive()
  {
    AppEngine canvas = AppEngine.getCanvas();
    SceneGame sceneGame = canvas.getSceneGame();
    if (sceneGame.isMapMode())
    {
      this.m_location = 2;
      this.trackGotoTown();
    }
    else if (sceneGame.isZoomMapMode())
    {
      this.m_location = 1;
      this.m_locationMap = canvas.getNextZoomMapId();
      switch (this.m_locationMap)
      {
        case 4:
          SpywareManager.getInstance().trackGotoLakeside();
          break;
        case 183:
          SpywareManager.getInstance().trackGotoStreetside();
          break;
      }
    }
    else
    {
      if (!sceneGame.isHouseMode())
        return;
      this.m_location = 0;
      this.m_locationMap = canvas.getNextHouseId();
      this.trackGotoHouse(this.m_locationMap);
    }
  }

  public void trackLeave()
  {
    if (this.m_location == 2)
      this.trackGotoTown(false);
    else if (this.m_location == 1)
    {
      switch (this.m_locationMap)
      {
        case 4:
          SpywareManager.getInstance().trackGotoLakeside(false);
          break;
        case 183:
          SpywareManager.getInstance().trackGotoStreetside(false);
          break;
      }
    }
    else if (this.m_location == 0)
      this.trackGotoHouse(this.m_locationMap, false);
    this.m_location = -1;
    this.m_locationMap = -1;
  }

  private void trackGotoHouse(int houseId)
  {
    this.trackGotoHouse(houseId, true);
  }

  private void trackGotoHouse(int houseId, bool arrive)
  {
    string str = GlobalConstants.LOOKUP_HOUSE[houseId];
    EASpywareManager.getInstance().logEvent(arrive ? 253 : 254, str);
  }

  private void trackGotoTown()
  {
    this.trackGotoTown(true);
  }

  private void trackGotoTown(bool arrive)
  {
    string str = "TOWNMAP";
    EASpywareManager.getInstance().logEvent(arrive ? 253 : 254, str);
  }

  private void trackGotoLakeside()
  {
    this.trackGotoLakeside(true);
  }

  private void trackGotoLakeside(bool arrive)
  {
    string str = "LAKESIDE";
    EASpywareManager.getInstance().logEvent(arrive ? 253 : 254, str);
  }

  private void trackGotoStreetside()
  {
    this.trackGotoStreetside(true);
  }

  private void trackGotoStreetside(bool arrive)
  {
    string str = "STREETSIDE";
    EASpywareManager.getInstance().logEvent(arrive ? 253 : 254, str);
  }

  public void trackStoreOpen(string storeName)
  {
    this.m_lastStore = storeName;
    EASpywareManager.getInstance().logEvent(246, storeName);
  }

  public void trackStoreClose()
  {
    EASpywareManager.getInstance().logEvent(248, this.m_lastStore);
    this.m_lastStore = (string) null;
  }

  public void trackMiniGameStart(string type)
  {
    EASpywareManager.getInstance().logEvent(249, type);
  }

  public void trackMiniGameFinish(string type, bool success, string result)
  {
    EASpywareManager.getInstance().logEvent(success ? 250 : 251, type, result);
  }

  public void trackGoalComplete(int goalId)
  {
    EASpywareManager.getInstance().logEvent(252, GlobalConstants.LOOKUP_DREAM[goalId]);
  }

  public void trackAction(int actionId)
  {
    EASpywareManager.getInstance().logEvent(257, GlobalConstants.LOOKUP_ACTION[actionId]);
  }

  public void trackJobChange()
  {
    int simCareer = AppEngine.getCanvas().getSimData().getSimCareer(0);
    if (simCareer == -1)
      EASpywareManager.getInstance().logEvent(256, "unemployed");
    else
      EASpywareManager.getInstance().logEvent(256, GlobalConstants.LOOKUP_CAREER[simCareer], string.Concat((object) AppEngine.getCanvas().getSimData().getSimCareerLevel(0)));
  }

  public void trackBuyWall(int wallId)
  {
    EASpywareManager.getInstance().logEvent(244, GlobalConstants.LOOKUP_WALL[wallId]);
  }

  public void trackBuyFloor(int floorId)
  {
    EASpywareManager.getInstance().logEvent(243, GlobalConstants.LOOKUP_FLOOR[floorId]);
  }

  public void trackBuyItem(int itemId, int qty)
  {
    EASpywareManager.getInstance().logEvent(247, AppEngine.getCanvas().getSimWorld().getItemSpywareId(itemId), string.Concat((object) qty));
  }

  public void trackBuyObject(int objectId)
  {
    EASpywareManager.getInstance().logEvent(247, AppEngine.getCanvas().getSimWorld().getObjectSpywareId(objectId));
  }
}
