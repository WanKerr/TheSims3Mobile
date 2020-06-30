// Decompiled with JetBrains decompiler
// Type: MapObject
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g;
using midp;
using System;

public class MapObject : GlobalConstants
{
  protected static Transform s_tempTransform = new Transform();
  internal readonly int[] FRUIT_LOCATORS = new int[9]
  {
    4200,
    4201,
    4202,
    4203,
    4204,
    4205,
    4206,
    4207,
    4208
  };
  public int[] s_tempInt10 = new int[10];
  private const int STATE_IDLE = 0;
  private const int STATE_ACTIVE = 1;
  private const int BASIN_STATE_IDLE = 0;
  private const int BASIN_STATE_ACTIVE = 1;
  private const int BATH_STATE_IDLE = 0;
  private const int BATH_STATE_FULL = 1;
  private const int BATH_STATE_FILLING = 2;
  private const int BATH_STATE_EMPTYING = 3;
  private const int CM_STATE_IDLE = 0;
  private const int CM_STATE_ACTIVE = 1;
  private const int CM_STATE_READY = 2;
  private const int COMPUTER_STATE_IDLE = 0;
  private const int COMPUTER_STATE_ACTIVE = 1;
  private const int COMPUTER_STATE_POWERUP = 2;
  private const int COMPUTER_STATE_POWERDN = 3;
  private const int DOOR_STATE_CLOSED = 0;
  private const int DOOR_STATE_OPEN = 1;
  private const int DOOR_STATE_OPENING = 2;
  private const int DOOR_STATE_CLOSING = 3;
  private const int FRIDGE_STATE_CLOSED = 0;
  private const int FRIDGE_STATE_OPEN = 1;
  private const int FRIDGE_STATE_OPENING = 2;
  private const int FRIDGE_STATE_CLOSING = 3;
  private const int PHONE_STATE_IDLE = 0;
  private const int PHONE_STATE_CHATTING = 1;
  private const int PHONE_STATE_PICKUP = 2;
  private const int PHONE_STATE_HANGUP = 3;
  private const int SHOWER_STATE_IDLE = 0;
  private const int SHOWER_STATE_ACTIVE = 1;
  private const int STOVE_STATE_IDLE = 0;
  private const int STOVE_STATE_ACTIVE = 1;
  private const int TC_STATE_IDLE = 0;
  private const int TC_STATE_TIPPED = 1;
  private const int TC_STATE_TIPPING = 2;
  private const int TV_STATE_OFF = 0;
  private const int TV_STATE_ON = 1;
  private const int PLANT_IDLE = 0;
  private const int PLANT_STAGE_FRUIT = 1;
  private const int PLANT_STAGE_01 = 2;
  private const int PLANT_STAGE_02 = 3;
  private const int PERSISTANT_VALUE = 16777215;
  private const int PERSISTANT_BROKEN = 16777216;
  private const int PERSISTANT_DIRTY = 33554432;
  private const int PERSISTANT_TV_COMEDY = 67108864;
  private const int PERSISTANT_TV_ACTION = 134217728;
  private const int PERSISTANT_PLANT_TALKEDTO = 268435456;
  private const int PERSISTANT_LIGHT_NOTAUTO = 536870912;
  private const int BREAKCLEAN_POINTS = 300;
  private const int BREAKCLEAN_START_POINTS = 100;
  private const int BREAKCLEAN_TIME_INTERVAL = 8000;
  private const int BREAKCLEAN_TIME_POINTS = 1;
  private const int BREAKCLEAN_USE_POINTS = 15;
  public const int EFFECT_MONEY_TIME = 1500;
  public const int FRUIT_PER_HARVEST = 6;
  public const int FRUIT_PER_HARVEST_GRND = 6;
  public const int MODEL_PRIMARY = 0;
  public const int MODEL_VFX_ALIGNED = 1;
  public const int MODEL_PLUMB_BOB = 2;
  protected readonly SceneGame m_scene;
  protected readonly AppEngine m_engine;
  private int m_type;
  private int m_id;
  private int m_typeString;
  private int m_flags;
  private int m_runtimeFlags;
  private int m_state;
  private int m_stateTime;
  private int m_posXF;
  private int m_posYF;
  private int m_posZF;
  private int m_facingDir;
  private sbyte m_footprintWidth;
  private sbyte m_footprintHeight;
  private bool m_inView;
  private short m_breakCleanPoints;
  private int m_breakCleanTimer;
  private MapObject m_buildPointSelector;
  private int m_occupiedFlags;
  private int m_tvSoundHandle;
  private int m_effectMoney;
  private Model[] m_fruit;
  public int ANIMPLAYER_PRIMARY;
  private AnimPlayer[] m_animPlayers;
  private Model[] m_models;
  private int m_modelOffsetXF;
  private int m_modelOffsetZF;

  public SimData getSimData()
  {
    return this.m_engine.getSimData();
  }

  public SimWorld getSimWorld()
  {
    return this.m_engine.getSimWorld();
  }

  public MapObject(SceneGame scene)
  {
    this.m_scene = scene;
    this.m_engine = AppEngine.getCanvas();
    this.m_type = 0;
    this.m_id = 0;
    this.m_typeString = 0;
    this.m_flags = 0;
    this.m_runtimeFlags = 0;
    this.m_state = 0;
    this.m_stateTime = 0;
    this.m_posXF = 0;
    this.m_posYF = 0;
    this.m_posZF = 0;
    this.m_facingDir = 0;
    this.m_footprintWidth = (sbyte) 0;
    this.m_footprintHeight = (sbyte) 0;
    this.m_inView = false;
    this.m_breakCleanPoints = (short) 0;
    this.m_breakCleanTimer = 0;
    this.m_buildPointSelector = (MapObject) null;
    this.m_occupiedFlags = 0;
    this.m_effectMoney = 0;
    this.m_fruit = new Model[0];
    this.m_animPlayers = new AnimPlayer[1];
    this.m_models = new Model[0];
    this.m_modelOffsetXF = 0;
    this.m_modelOffsetZF = 0;
    this.m_tvSoundHandle = -1;
    this.m_animPlayers[this.ANIMPLAYER_PRIMARY] = new AnimPlayer();
  }

  public new void Dispose()
  {
    this.destroyModels();
    for (int index = this.m_animPlayers.Length - 1; index >= 0; --index)
    {
      if (this.m_animPlayers[index] != null)
        this.m_animPlayers[index] = (AnimPlayer) null;
    }
    base.Dispose();
  }

  public virtual void init(int type, int xF, int yF, int zF, int facingDir, int id)
  {
    SimWorld simWorld = this.getSimWorld();
    SimData simData = this.getSimData();
    switch (type)
    {
      case 14:
      case 15:
        if (yF == 0)
        {
          yF = 39321;
          break;
        }
        break;
      case 30:
      case 31:
        yF = 39321;
        break;
    }
    this.m_type = type;
    this.m_id = id;
    int objectParent = simWorld.getObjectParent(type);
    this.setPos(xF, yF, zF);
    this.setFacingDir(facingDir);
    this.m_flags = simWorld.getObjectFlags(type);
    this.m_runtimeFlags = 0;
    this.m_typeString = simWorld.getObjectStringId(type);
    if (type == 1)
      this.m_typeString = simData.getSimName(this.getId());
    this.setRuntimeFlag(128);
    this.m_occupiedFlags = 0;
    int modelId = simWorld.getObjectModelId(type);
    if (type == 32 && simWorld.getHouseId() == 0)
      modelId = 23;
    if (type != 11 && type != 2 && (type != 3 && modelId != -1) && (this.m_flags & 8256) == 0)
      this.getModelCreate(0).assembleObject(modelId);
    int objectValue = this.getObjectValue();
    int newState = 0;
    if (type == 12)
    {
      newState = objectValue & 16777215;
    }
    else
    {
      switch (objectParent)
      {
        case 20:
        case 21:
          this.setRuntimeFlag(2097152, (objectValue & 536870912) == 0);
          break;
        case 23:
          newState = objectValue & 16777215;
          break;
        case 30:
          newState = objectValue & 16777215;
          if (newState != 0 && simWorld.getHouseId() != 0)
          {
            int gameTimeAbs = simData.getGameTimeAbs();
            int objectValueTime = this.getObjectValueTime();
            if (objectValueTime != -1 && gameTimeAbs - objectValueTime > 1440)
            {
              newState = 0;
              break;
            }
            break;
          }
          break;
      }
    }
    this.stateTransition(newState);
    if ((objectValue & 16777216) != 0)
      this.breakObject();
    if (this.getFlag(33554432) && !this.getRuntimeFlag(768))
    {
      this.m_breakCleanPoints = (short) (objectValue & 16777215);
      this.m_breakCleanTimer = 0;
      if (this.m_breakCleanPoints == (short) 0)
        this.m_breakCleanPoints = (short) this.m_engine.rand(0, 100);
    }
    switch (objectParent)
    {
      case 9:
        this.setRuntimeFlag(128);
        this.setAnim3D(269);
        break;
      case 19:
        this.setRuntimeFlag(128);
        this.setAnim3D(267);
        break;
      case 20:
      case 21:
        if (!this.getRuntimeFlag(2097152))
          break;
        this.updateLightStatus();
        break;
    }
  }

  public void initMacromapObject(Node node)
  {
    this.getModelCreate(0).assembleMacromap(node);
    this.updateModel();
  }

  public void destroy()
  {
    if (this.getRuntimeFlag(256))
      this.removeSparks();
    if (this.getParentType() == 20 && this.getRuntimeFlag(64))
      this.getRoom()?.removeLight();
    this.destroyModels();
    this.m_scene.removeObject(this);
  }

  private void destroyModels()
  {
    for (int index = 0; index < this.m_models.Length; ++index)
    {
      if (this.m_models[index] != null)
      {
        this.getSimWorld().removeObjectNode(this.m_models[index].getNode());
        this.m_models[index].unload();
        this.m_models[index] = (Model) null;
      }
    }
    this.m_models = (Model[]) null;
    this.plantClearFruit();
  }

  public void setInView(bool inView)
  {
    this.m_inView = this.getFlag(65536) || inView;
  }

  public bool isInView()
  {
    return this.m_inView;
  }

  public int getType()
  {
    return this.m_type;
  }

  public int getParentType()
  {
    return this.getSimWorld().getObjectParent(this.m_type);
  }

  public int getId()
  {
    return this.m_id;
  }

  public int getTypeString()
  {
    return this.getFlag(256) ? this.getHouseTypeString() : this.m_typeString;
  }

  public int getPosX()
  {
    return this.m_posXF;
  }

  public int getPosY()
  {
    return this.m_posYF;
  }

  public int getPosZ()
  {
    return this.m_posZF;
  }

  public void setPos(int xF, int yF, int zF)
  {
    this.m_posXF = xF;
    this.m_posYF = yF;
    this.m_posZF = zF;
  }

  public int getFootprintX()
  {
    return (int) this.m_footprintWidth;
  }

  public int getFootprintZ()
  {
    return (int) this.m_footprintHeight;
  }

  public bool getFlag(int flag)
  {
    return (this.m_flags & flag) != 0;
  }

  public void setFlag(int flag, bool value)
  {
    if (value)
      this.setFlag(flag);
    else
      this.unsetFlag(flag);
  }

  public void setFlag(int flag)
  {
    this.m_flags |= flag;
  }

  public void unsetFlag(int flag)
  {
    this.m_flags &= ~flag;
  }

  public bool getRuntimeFlag(int flag)
  {
    return (this.m_runtimeFlags & flag) != 0;
  }

  public void setRuntimeFlag(int flag, bool value)
  {
    if (value)
      this.setRuntimeFlag(flag);
    else
      this.unsetRuntimeFlag(flag);
  }

  public void setRuntimeFlag(int flag)
  {
    this.m_runtimeFlags |= flag;
  }

  public void unsetRuntimeFlag(int flag)
  {
    this.m_runtimeFlags &= ~flag;
  }

  public void hide()
  {
    if (this.getRuntimeFlag(256))
      this.removeSparks();
    this.setRuntimeFlag(8192);
  }

  public void unhide()
  {
    this.unsetRuntimeFlag(8192);
  }

  public void reposition(int posXF, int posYF, int posZF, int facing)
  {
    Room room = (Room) null;
    if (this.getParentType() == 20)
      room = this.getRoom();
    if (this.getRuntimeFlag(256))
      this.removeSparks();
    this.setPos(posXF, posYF, posZF);
    this.setFacingDir(facing);
    if (this.getParentType() != 20 || !this.getRuntimeFlag(64))
      return;
    room?.removeLight();
    this.getRoom()?.addLight();
  }

  public int getHotspotCount()
  {
    Model model = this.getModel();
    return model != null ? midp.JMath.max(1, model.getHotspotCount()) : 1;
  }

  public void getHotspot(int[] result, int index)
  {
    Model model = this.getModel();
    if (model != null)
    {
      model.getHotspot(result, index);
    }
    else
    {
      result[0] = this.getPosX();
      result[1] = this.getPosY();
      result[2] = this.getPosZ();
    }
  }

  public int getBenchtopCount()
  {
    Model model = this.getModel();
    return model != null ? model.getBenchtopCount() : 0;
  }

  public void getBenchtop(int[] result, int index)
  {
    this.getModel().getBenchtop(result, index);
  }

  public int getInterestPointCount()
  {
    return this.getSimWorld().getObjectInterestPointCount(this.getType());
  }

  public void getInterestPoint(int[] result, int index)
  {
    SimWorld simWorld = this.getSimWorld();
    simWorld.getObjectInterestPoint(ref result, this.getType(), index, this.getFacingDir());
    result[0] += simWorld.coordWorldToWorldTileX(this.getPosX());
    result[1] += simWorld.coordWorldToWorldTileZ(this.getPosZ());
    result[0] = simWorld.coordWorldTileToWorldCenterX(result[0]);
    result[1] = simWorld.coordWorldTileToWorldCenterZ(result[1]);
  }

  public int getClosestInterestPoint(
    int posXF,
    int posZF,
    bool occupiedCheck,
    MapObjectSim fromSim)
  {
    SimWorld simWorld = this.getSimWorld();
    int[] tempInt10 = this.s_tempInt10;
    int interestPointCount = simWorld.getObjectInterestPointCount(this.getType());
    if (interestPointCount <= 0)
      return -1;
    int num1 = -1;
    int num2 = int.MaxValue;
    for (int index1 = 0; index1 < interestPointCount; ++index1)
    {
      if (!occupiedCheck || this.occupiedIsAvailable(index1))
      {
        this.getInterestPoint(tempInt10, index1);
        int num3 = tempInt10[0];
        int num4 = tempInt10[1];
        if (simWorld.isWorldPointWalkableFrom(num3, num4, this.getPosX(), this.getPosZ()))
        {
          if (occupiedCheck && !this.getFlag(8388608))
          {
            int worldTileX1 = simWorld.coordWorldToWorldTileX(num3);
            int worldTileZ1 = simWorld.coordWorldToWorldTileZ(num4);
            bool flag = false;
            MapObjectSim[] simObjects = this.m_scene.getSimObjects();
            for (int index2 = 0; index2 < simObjects.Length && !flag; ++index2)
            {
              MapObjectSim mapObjectSim = simObjects[index2];
              if (mapObjectSim != fromSim)
              {
                int worldTileX2 = simWorld.coordWorldToWorldTileX(mapObjectSim.getPosX());
                int worldTileZ2 = simWorld.coordWorldToWorldTileZ(mapObjectSim.getPosZ());
                if (worldTileX2 == worldTileX1 && worldTileZ2 == worldTileZ1)
                  flag = true;
              }
            }
            if (flag)
              continue;
          }
          if (fromSim == null || fromSim.simCanWalkTo((MapObject) null, num3, num4))
          {
            int num5 = midp.JMath.abs(posXF - num3) + midp.JMath.abs(posZF - num4);
            if (num5 < num2)
            {
              num2 = num5;
              num1 = index1;
            }
          }
        }
      }
    }
    return num1;
  }

  public int getRoomId()
  {
    SimWorld simWorld = this.getSimWorld();
    int worldTileX = simWorld.coordWorldToWorldTileX(this.getPosX());
    int worldTileZ = simWorld.coordWorldToWorldTileZ(this.getPosZ());
    return simWorld.getRoomAt(worldTileX, worldTileZ);
  }

  public Room getRoom()
  {
    return this.getSimWorld().getRoom(this.getRoomId());
  }

  public bool occupiedCapture(int index, MapObjectSim sim)
  {
    if (this.getFlag(8388608))
      return true;
    if (this.getFlag(16777216))
    {
      if ((this.m_occupiedFlags & 1 << index) == 0)
      {
        this.m_occupiedFlags |= 1 << index;
        return true;
      }
    }
    else if (this.m_occupiedFlags == 0)
    {
      this.m_occupiedFlags = -1;
      return true;
    }
    return false;
  }

  public void occupiedRelease(int index)
  {
    if (this.getFlag(16777216))
    {
      AppEngine.ASSERT((this.m_occupiedFlags & 1 << index) != 0, "releasing already unoccupied flag");
      this.m_occupiedFlags &= ~(1 << index);
    }
    else
      this.m_occupiedFlags = 0;
  }

  public bool occupiedIsEmpty()
  {
    return this.getFlag(8388608) || this.m_occupiedFlags == 0;
  }

  public bool occupiedIsAnyAvailable()
  {
    return this.occupiedIsEmpty() || this.m_occupiedFlags < (1 << this.getSimWorld().getObjectInterestPointCount(this.getType())) - 1;
  }

  public bool occupiedIsAvailable(int index)
  {
    return (this.m_occupiedFlags & 1 << index) == 0;
  }

  private int getObjectValue()
  {
    return this.getId() == -1 || this.getFlag(8192) ? 0 : this.getSimData().getObjectValue(this.getSimWorld().getHouseId(), this.getId());
  }

  private int getObjectValueTime()
  {
    return this.getId() == -1 ? -1 : this.getSimData().getObjectValueTime(this.getSimWorld().getHouseId(), this.getId());
  }

  private void saveObjectValue()
  {
    if (this.getId() == -1)
      return;
    SimWorld simWorld = this.getSimWorld();
    SimData simData = this.getSimData();
    int num = 0;
    if (this.getType() == 128)
      num = this.m_state;
    else if (this.getType() == 12)
      num = this.m_state;
    else if (this.getParentType() == 23)
      num = this.m_state;
    else if ((this.getParentType() == 20 || this.getParentType() == 21) && !this.getRuntimeFlag(2097152))
      num |= 536870912;
    if (this.getFlag(33554432) && this.getRuntimeFlag(256))
      num |= 16777216;
    if (simWorld.getHouseId() == 0 && this.getFlag(33554432))
      num |= (int) this.m_breakCleanPoints;
    if (this.getRuntimeFlag(32768))
      num |= 134217728;
    if (this.getRuntimeFlag(16384))
      num |= 67108864;
    if (this.getRuntimeFlag(65536))
      num |= 268435456;
    simData.saveObjectValue(simWorld.getHouseId(), this.getId(), num);
  }

  public virtual bool isIdle()
  {
    if (this.getParentType() != 23)
      return this.m_state == 0;
    return !this.isAnimating() && !this.isSupportAnimating3D() && this.m_state != 1;
  }

  public bool isActive()
  {
    return (this.getParentType() != 23 || !this.isSupportAnimating3D() && !this.isAnimating()) && this.m_state == 1;
  }

  protected void stateTransition(int newState)
  {
    switch (this.getParentType())
    {
      case 3:
        this.peePuddleStateTransition(newState);
        break;
      case 4:
        this.basinStateTransition(newState);
        break;
      case 5:
        this.bathStateTransition(newState);
        break;
      case 11:
        this.coffeeMachineStateTransition(newState);
        break;
      case 12:
        this.computerStateTransition(newState);
        break;
      case 15:
        this.doorStateTransition(newState);
        break;
      case 17:
        this.fridgeStateTransition(newState);
        break;
      case 22:
        this.phoneStateTransition(newState);
        break;
      case 23:
        this.plantStateTransition(newState);
        break;
      case 25:
        this.showerStateTransition(newState);
        break;
      case 27:
        this.stoveStateTransition(newState);
        break;
      case 30:
        this.trashCanStateTransition(newState);
        break;
      case 31:
        this.tvStateTransition(newState);
        break;
    }
    this.m_state = newState;
    this.m_stateTime = 0;
    if (this.getParentType() != 30 && this.getType() != 12)
      return;
    this.saveObjectValue();
  }

  public virtual void update(int timeStep)
  {
    this.m_stateTime += timeStep;
    if (this.getModel() != null)
      this.getModel().updateHemisphereMap();
    if (this.getFlag(33554432) && !this.m_scene.isTutorialMode())
    {
      if (!this.getRuntimeFlag(768))
      {
        this.m_breakCleanTimer += timeStep;
        if (this.m_breakCleanTimer > 8000)
        {
          this.m_breakCleanTimer -= 8000;
          this.addBreakCleanPoints(1);
        }
      }
      else
        this.updateAnim(timeStep);
    }
    if (this.getRuntimeFlag(1))
      timeStep = this.m_scene.getNormalTimeStep();
    int type = this.getType();
    switch (this.getParentType())
    {
      case 2:
        this.updateAnim3D(timeStep);
        if (!this.isAnimating3D())
        {
          this.destroy();
          break;
        }
        break;
      case 3:
        this.updateAnim3D(timeStep);
        if (this.m_state != 1 && !this.isAnimating3D())
        {
          this.stateTransition(1);
          break;
        }
        break;
      case 4:
        this.basinUpdate(timeStep);
        break;
      case 5:
        this.bathUpdate(timeStep);
        break;
      case 9:
        this.updateAnim3D(timeStep);
        break;
      case 11:
        this.coffeeMachineUpdate(timeStep);
        break;
      case 12:
        this.computerUpdate(timeStep);
        break;
      case 15:
        this.doorUpdate(timeStep);
        break;
      case 17:
        this.fridgeUpdate(timeStep);
        break;
      case 19:
        this.updateAnim3D(timeStep);
        break;
      case 22:
        this.phoneUpdate(timeStep);
        break;
      case 23:
        this.plantUpdate(timeStep);
        break;
      case 25:
        this.showerUpdate(timeStep);
        break;
      case 26:
        if (this.getRuntimeFlag(64))
        {
          this.updateAnim3D(timeStep);
          break;
        }
        break;
      case 30:
        this.trashCanUpdate(timeStep);
        break;
      case 31:
        this.tvUpdate(timeStep);
        break;
      default:
        this.updateAnim(timeStep);
        break;
    }
    switch (type)
    {
      case 10:
        if (this.isAnimating())
          break;
        this.destroy();
        break;
      case 11:
        if (this.m_stateTime <= 1500)
          break;
        this.destroy();
        break;
    }
  }

  protected bool updateAnim(int timeStep)
  {
    if (this.getRuntimeFlag(2048))
      timeStep = MathExt.Fmul(timeStep << 16, 81920) >> 16;
    else if (this.getRuntimeFlag(4096))
      timeStep = MathExt.Fmul(timeStep << 16, 49152) >> 16;
    bool flag = this.updateAnimPlayer(timeStep, this.ANIMPLAYER_PRIMARY);
    if (flag)
      this.spawnEffects();
    return flag;
  }

  protected bool updateAnimPlayer(int timeStep, int animPlayerIndex)
  {
    AnimPlayer animPlayer = this.getAnimPlayer(animPlayerIndex);
    return animPlayer != null && animPlayer.updateAnim(timeStep);
  }

  protected virtual void updateAnim3D(int timeStep)
  {
    if (this.getRuntimeFlag(2048))
      timeStep = MathExt.Fmul(timeStep << 16, 81920) >> 16;
    else if (this.getRuntimeFlag(4096))
      timeStep = MathExt.Fmul(timeStep << 16, 49152) >> 16;
    for (int modelIndex = 0; modelIndex < this.m_models.Length; ++modelIndex)
      this.updateAnimPlayer3D(timeStep, modelIndex);
  }

  protected void updateAnimPlayer3D(int timeStep, int modelIndex)
  {
    Model model = this.getModel(modelIndex);
    if (model == null)
      return;
    model.getAnimPlayer3D().updateAnim(timeStep);
    model.getSupportAnimPlayer3D().updateAnim(timeStep);
  }

  protected void spawnEffects()
  {
    if (!this.getRuntimeFlag(256))
      return;
    int[] tempInt10 = this.s_tempInt10;
    this.getAnimPlayer(this.ANIMPLAYER_PRIMARY).getFirePointCurrFrame(ref tempInt10, 0);
    int userId = -1;
    switch (tempInt10[0])
    {
      case 0:
        userId = 1080;
        break;
      case 1:
        userId = 1081;
        break;
      case 2:
        userId = 1082;
        break;
      case 3:
        userId = 1083;
        break;
    }
    this.getModel().getLocatorPos(tempInt10, userId);
    this.m_scene.createEffectModel(tempInt10[0], tempInt10[1], tempInt10[2], 7, 238);
  }

  public virtual bool respondToAction(int action, MapObjectSim fromSim)
  {
    if (this.getParentType() == 30)
    {
      if (action == 159)
        this.stateTransition(0);
    }
    else if (this.getType() == 12)
    {
      if (action == 160)
      {
        if (this.getId() != -1)
          this.getSimWorld().objectSell(this.getId());
        this.destroy();
      }
    }
    else if (this.getParentType() == 15)
    {
      switch (action)
      {
        case 161:
        case 163:
          this.doorOpen(fromSim);
          break;
        case 162:
          if (fromSim.getId() == 0)
          {
            this.m_scene.advertiseEvent(28, fromSim, this);
            break;
          }
          break;
      }
    }
    else if (this.getParentType() == 23 && action == 117)
    {
      this.setRuntimeFlag(65536);
      this.saveObjectValue();
    }
    return false;
  }

  public void breakObject()
  {
    this.setRuntimeFlag(256);
    this.turnOff();
    this.saveObjectValue();
    AnimPlayer animPlayer = this.getAnimPlayer(this.ANIMPLAYER_PRIMARY);
    animPlayer.startAnim(11, 20);
    int numAnimFrames = animPlayer.getNumAnimFrames();
    animPlayer.setFrame(this.m_engine.rand(0, numAnimFrames - 1));
    this.m_scene.setCameraLookAtBrokenObject(this);
    this.m_scene.showTutorialMessage(11);
    this.playSound(77);
  }

  public void repairObject()
  {
    this.unsetRuntimeFlag(256);
    this.saveObjectValue();
  }

  public void addBreakCleanPoints(int amount)
  {
    if (this.getSimWorld().getHouseId() != 0)
      return;
    this.m_breakCleanPoints += (short) amount;
    if (this.m_breakCleanPoints > (short) 300)
    {
      this.m_breakCleanPoints = (short) 0;
      if (this.getFlag(33554432))
        this.breakObject();
    }
    this.saveObjectValue();
  }

  public void removeSparks()
  {
    int num1 = midp.JMath.max(1, this.getFootprintX()) - 1;
    int num2 = midp.JMath.max(1, this.getFootprintZ()) - 1;
    int num3 = this.getPosX() - num1 * 2097152 - 1048576 - 327680;
    int num4 = this.getPosZ() - num2 * 2097152 - 1048576 - 327680;
    int num5 = this.getPosX() + 1048576 + 327680;
    int num6 = this.getPosZ() + 1048576 + 327680;
    foreach (MapObject mapObject in this.m_scene.getObjects())
    {
      if (mapObject.getType() == 13)
      {
        Model model = mapObject.getModel();
        if (model != null && model.getModelId() == 7)
        {
          int posX = mapObject.getPosX();
          int posZ = mapObject.getPosZ();
          if (posX >= num3 && posZ >= num4 && (posX <= num5 && posZ <= num6))
            mapObject.destroy();
        }
      }
    }
  }

  private void turnOnOff(bool turnedOn)
  {
    Model model = this.getModel();
    int parentType = this.getParentType();
    switch (parentType)
    {
      case 12:
        this.stateTransition(turnedOn ? 2 : 3);
        break;
      case 20:
      case 21:
        if (turnedOn)
          model.switchRoot(1100);
        else
          model.switchRoot(1101);
        Room room = this.getRoom();
        if (room != null && parentType == 20)
        {
          if (turnedOn && !this.getRuntimeFlag(64))
          {
            room.addLight();
            break;
          }
          if (!turnedOn && this.getRuntimeFlag(64))
          {
            room.removeLight();
            break;
          }
          break;
        }
        break;
      case 26:
        if (turnedOn)
        {
          int modelId = -1;
          switch (this.getType())
          {
            case 113:
              modelId = 9;
              break;
            case 114:
              modelId = 10;
              break;
          }
          this.setRuntimeFlag(128);
          this.setSupportModel(modelId);
          this.setSupportAnim3D(266);
          break;
        }
        this.setSupportModel(-1);
        break;
      case 31:
        if (turnedOn && !this.getRuntimeFlag(49152))
          this.setRuntimeFlag(32768);
        this.stateTransition(turnedOn ? 1 : 0);
        break;
    }
    this.setRuntimeFlag(64, turnedOn);
    this.addBreakCleanPoints(15);
  }

  public void turnOn()
  {
    int parentType = this.getParentType();
    switch (parentType)
    {
      case 20:
      case 21:
        this.unsetRuntimeFlag(2097152);
        break;
    }
    if (!this.getRuntimeFlag(64) && parentType == 26)
      this.m_scene.playStereoMusic();
    this.turnOnOff(true);
  }

  public void turnOff()
  {
    int parentType = this.getParentType();
    switch (parentType)
    {
      case 20:
      case 21:
        this.unsetRuntimeFlag(2097152);
        break;
    }
    if (this.getRuntimeFlag(64) && parentType == 26)
      this.m_scene.stopStereoMusic();
    this.turnOnOff(false);
  }

  public void effectPlayAnim(int animId)
  {
    this.unsetRuntimeFlag(128);
    this.setAnim(animId);
  }

  public void effectPlayModel(int modelId, int animId)
  {
    this.unsetRuntimeFlag(128);
    this.getModelCreate(0).assembleObject(modelId);
    this.setAnim3D(animId);
  }

  public void effectShowMoney(int money)
  {
    this.m_effectMoney = money;
    this.setAnim(9);
  }

  private void renderEffectMoney(Graphics g, int objectX, int objectY)
  {
    TextManager textManager = this.m_engine.getTextManager();
    StringBuffer strBuffer = textManager.clearStringBuffer();
    textManager.appendMoneyToBuffer(this.m_effectMoney);
    textManager.drawString(g, strBuffer, 5, objectX, objectY, 17);
  }

  private void peePuddleStateTransition(int newState)
  {
    this.unsetRuntimeFlag(128);
    this.setAnim3D(248);
    switch (newState)
    {
      case 1:
        this.setAnim3DEnd();
        break;
    }
  }

  public void basinStart()
  {
    this.stateTransition(1);
    this.playSound(78);
  }

  public void basinEnd()
  {
    this.stateTransition(0);
  }

  private void basinStateTransition(int newState)
  {
    switch (newState)
    {
      case 0:
        this.getModel(1)?.unload();
        break;
      case 1:
        Model modelCreate = this.getModelCreate(1);
        modelCreate.assembleObject(8);
        modelCreate.getAnimPlayer3D().startAnim(249, 20);
        break;
      default:
        AppEngine.ASSERT(false, "invalid state for basin");
        this.getModel(1)?.unload();
        break;
    }
  }

  private void basinUpdate(int timeStep)
  {
    this.updateAnim3D(timeStep);
  }

  public void bathToFill()
  {
    if (this.m_state != 0 && this.m_state != 3)
      return;
    this.stateTransition(2);
  }

  public void bathToEmpty()
  {
    if (this.m_state != 1 && this.m_state != 2)
      return;
    this.stateTransition(3);
  }

  public bool bathIsFull()
  {
    return this.m_state == 1;
  }

  private void bathUpdate(int timeStep)
  {
    this.updateAnim3D(timeStep);
    if (this.isSupportAnimating3D())
      return;
    if (this.m_state == 2)
    {
      this.stateTransition(1);
    }
    else
    {
      if (this.m_state != 3)
        return;
      this.stateTransition(0);
    }
  }

  private void bathStateTransition(int newState)
  {
    switch (newState)
    {
      case 0:
        this.unsetRuntimeFlag(128);
        this.setSupportModel(-1);
        break;
      case 1:
        this.setRuntimeFlag(128);
        this.setSupportModel(6);
        this.setSupportAnim3D(257);
        break;
      case 2:
        this.unsetRuntimeFlag(128);
        this.setSupportModel(6);
        this.setSupportAnim3D(258);
        break;
      case 3:
        this.unsetRuntimeFlag(128);
        this.setSupportModel(6);
        this.setSupportAnim3D(259);
        break;
      default:
        AppEngine.ASSERT(false, "invalid state for bath");
        this.unsetRuntimeFlag(128);
        this.setSupportModel(-1);
        break;
    }
  }

  public int bedGetRelStateFlags()
  {
    MapObject[] objects = this.m_scene.getObjects();
    MapObject mapObject1 = (MapObject) null;
    for (int index = 0; index < objects.Length; ++index)
    {
      MapObject mapObject2 = objects[index];
      if (mapObject2 != this && mapObject2.getParentType() == 6)
      {
        mapObject1 = mapObject2;
        break;
      }
    }
    return mapObject1 != null && this.getId() >= mapObject1.getId() ? 1024 : 512;
  }

  public void createDummies(int width, int height, int rotFlags)
  {
    SimWorld simWorld = this.getSimWorld();
    int worldTileX = simWorld.coordWorldToWorldTileX(this.getPosX());
    int worldTileZ = simWorld.coordWorldToWorldTileZ(this.getPosZ());
    if ((rotFlags & 5) != 0)
    {
      int facingDir = 0;
      if ((rotFlags & 1) == 0)
        facingDir = 2;
      for (int index1 = 0; index1 < width; ++index1)
      {
        for (int index2 = 0; index2 < height; ++index2)
        {
          int num1 = worldTileX - index1;
          int num2 = worldTileZ - index2;
          if ((simWorld.getAttribute(num1, num2) & 8192) == 0)
            this.m_scene.createObjectOnWorldTile(15, num1, 0, num2, facingDir, -1).m_buildPointSelector = this;
        }
      }
    }
    if ((rotFlags & 10) == 0)
      return;
    int facingDir1 = 1;
    if ((rotFlags & 2) == 0)
      facingDir1 = 3;
    for (int index1 = 0; index1 < height; ++index1)
    {
      for (int index2 = 0; index2 < width; ++index2)
      {
        int num1 = worldTileX - index1;
        int num2 = worldTileZ - index2;
        if ((simWorld.getAttribute(num1, num2) & 8192) == 0)
          this.m_scene.createObjectOnWorldTile(15, num1, 0, num2, facingDir1, -1).m_buildPointSelector = this;
      }
    }
  }

  public MapObject getBuildPointSelector()
  {
    return this.m_buildPointSelector;
  }

  public void coffeeMachineActivate()
  {
    this.stateTransition(2);
  }

  public void coffeeMachineDeactivate()
  {
    this.stateTransition(0);
  }

  private void coffeeMachineStateTransition(int newState)
  {
  }

  private void coffeeMachineUpdate(int timeStep)
  {
  }

  public bool coffeeMachineIsReady()
  {
    return this.m_state == 2;
  }

  private void computerStateTransition(int newState)
  {
  }

  private void computerUpdate(int timeStep)
  {
  }

  public void doorOpen(MapObjectSim fromSim)
  {
    if (this.m_state != 1 && this.m_state != 2)
      this.stateTransition(2);
    if (fromSim.getId() != 0 || this.getSimWorld().getHouseId() == 0 || this.getSimData().getSimCurRelStateFlags(0, 1))
      return;
    this.m_scene.advertiseEvent(27, fromSim, this);
  }

  public void doorClose()
  {
    if (this.m_state == 0 || this.m_state == 3)
      return;
    this.stateTransition(3);
  }

  private void doorStateTransition(int newState)
  {
    this.unsetRuntimeFlag(128);
    switch (newState)
    {
      case 0:
        this.unsetRuntimeFlag(64);
        this.setAnim3D(265);
        this.setAnim3DEnd();
        break;
      case 1:
        this.setRuntimeFlag(64);
        this.setAnim3D(264);
        this.setAnim3DEnd();
        break;
      case 2:
        this.setAnim3D(264);
        if (!this.getRuntimeFlag(1048576))
          break;
        this.playSound(67);
        break;
      case 3:
        this.setAnim3D(265);
        if (!this.getRuntimeFlag(1048576))
          break;
        this.playSound(68);
        break;
    }
  }

  private void doorUpdate(int timeStep)
  {
    if (this.m_state == 2)
    {
      this.updateAnim3D(timeStep * 3);
      if (this.isAnimating3D())
        return;
      this.stateTransition(1);
    }
    else
    {
      if (this.m_state != 3)
        return;
      this.updateAnim3D(timeStep * 3);
      if (this.isAnimating3D())
        return;
      this.stateTransition(0);
    }
  }

  public void fridgeOpen()
  {
    if (this.m_state == 1)
      return;
    this.stateTransition(2);
  }

  public void fridgeClose()
  {
    if (this.m_state != 0)
      this.stateTransition(3);
    this.addBreakCleanPoints(15);
  }

  private void fridgeStateTransition(int newState)
  {
    this.unsetRuntimeFlag(128);
    bool enable = true;
    switch (newState)
    {
      case 0:
        enable = false;
        this.setAnim3D(261);
        this.setAnim3DEnd();
        break;
      case 1:
        this.setAnim3D(260);
        this.setAnim3DEnd();
        break;
      case 2:
        this.setAnim3D(260);
        break;
      case 3:
        this.setAnim3D(261);
        break;
    }
    Model model = this.getModel();
    Node locator1 = model.getLocator(1104);
    Node locator2 = model.getLocator(1105);
    locator1.setRenderingEnable(enable);
    locator2.setRenderingEnable(enable);
  }

  private void fridgeUpdate(int timeStep)
  {
    this.updateAnim3D(timeStep);
    if (this.isAnimating3D())
      return;
    if (this.m_state == 2)
    {
      this.stateTransition(1);
    }
    else
    {
      if (this.m_state != 3)
        return;
      this.stateTransition(0);
    }
  }

  private int getHouseTypeString()
  {
    int sim1 = -1;
    int sim2 = -1;
    int houseForObject = this.getSimWorld().getHouseForObject(this.getType());
    SimData simData = this.getSimData();
    int simCount = simData.getSimCount();
    for (int sim3 = 0; sim3 < simCount; ++sim3)
    {
      if (simData.getSimHome(sim3) == houseForObject)
      {
        if (sim1 == -1)
          sim1 = sim3;
        else if (sim2 == -1)
          sim2 = sim3;
        else
          AppEngine.ASSERT(false, "argh, three sims in the one house!");
      }
    }
    if (sim1 == -1 && sim2 == -1)
      return 290;
    TextManager textManager = this.m_engine.getTextManager();
    if (sim1 == 0)
      return 291;
    string str = textManager.getString(simData.getSimName(sim1));
    if (sim2 == -1)
    {
      textManager.dynamicString(-10, 292, str);
    }
    else
    {
      string string1 = textManager.getString(simData.getSimName(sim2));
      textManager.dynamicString(-10, 293, str, string1);
    }
    return -10;
  }

  public void updateLightStatus()
  {
    if (!this.getRuntimeFlag(2097152))
      return;
    Room room = this.getRoom();
    bool turnedOn = false;
    if (room != null)
      turnedOn = room.getLightStatus();
    this.turnOnOff(turnedOn);
  }

  private static int plantForSeed(int seedType)
  {
    switch (seedType)
    {
      case 4:
        return 25;
      case 5:
        return 28;
      case 6:
        return 26;
      case 7:
        return 29;
      case 8:
        return 27;
      default:
        AppEngine.ASSERT(false, "invalid seed type");
        return -1;
    }
  }

  private static int fruitModelForPlant(int plantType)
  {
    switch (plantType)
    {
      case 25:
        return 12;
      case 26:
        return 14;
      case 27:
        return 16;
      case 28:
        return 13;
      case 29:
        return 15;
      default:
        AppEngine.ASSERT(false, "invalid plant type");
        return -1;
    }
  }

  private static int fruitItemForPlant(int plantType)
  {
    switch (plantType)
    {
      case 25:
        return 10;
      case 26:
        return 12;
      case 27:
        return 18;
      case 28:
        return 11;
      case 29:
        return 14;
      default:
        AppEngine.ASSERT(false, "invalid plant type");
        return -1;
    }
  }

  private int fruitPerHarvest()
  {
    return this.isGroundPlant() ? 6 : 6;
  }

  private bool isGroundPlant()
  {
    return (this.getSimWorld().getObjectFlags(this.getType()) & 131072) != 0;
  }

  public void plantSeed(int seedType)
  {
    SimWorld simWorld = this.getSimWorld();
    int num = MapObject.plantForSeed(seedType);
    this.m_type = num;
    simWorld.objectChange(this.getId(), num);
    this.m_typeString = simWorld.getObjectStringId(num);
    this.m_state = 2;
    this.saveObjectValue();
    this.unsetRuntimeFlag(128);
    if (this.isGroundPlant())
    {
      this.unsetRuntimeFlag(128);
      this.setAnim(10);
      this.setSupportModel(17);
      this.setSupportAnim3D(241);
    }
    else
    {
      this.setSupportModel(18);
      this.setSupportAnim3D(239);
    }
  }

  public void plantGrow()
  {
    bool flag = false;
    switch (this.m_state)
    {
      case 2:
        if (this.isGroundPlant())
        {
          flag = true;
          this.m_state = 1;
          this.unsetRuntimeFlag(128);
          this.setAnim(10);
          this.setSupportModel(17);
          this.setSupportAnim3D(242);
          this.setSupportAnimEnd();
          break;
        }
        this.m_state = 3;
        this.unsetRuntimeFlag(128);
        this.setSupportModel(18);
        this.setSupportAnim3D(240);
        break;
      case 3:
        flag = true;
        this.m_state = 1;
        this.unsetRuntimeFlag(128);
        this.setAnim(10);
        this.setSupportModel(18);
        this.setSupportAnim3D(240);
        this.setSupportAnimEnd();
        break;
      default:
        AppEngine.ASSERT(false, "invalid state for plant growth");
        if (this.isGroundPlant())
        {
          flag = true;
          this.m_state = 1;
          this.unsetRuntimeFlag(128);
          this.setAnim(10);
          this.setSupportModel(17);
          this.setSupportAnim3D(242);
          this.setSupportAnimEnd();
          break;
        }
        this.m_state = 3;
        this.unsetRuntimeFlag(128);
        this.setSupportModel(18);
        this.setSupportAnim3D(240);
        break;
    }
    if (flag)
    {
      SimData simData = this.getSimData();
      simData.dreamCompleteEvent(31);
      if (this.getType() == 28)
        simData.dreamCompleteEvent(32);
      else if (this.getType() == 26)
        simData.dreamCompleteEvent(33);
      else if (this.getType() == 27)
        simData.dreamCompleteEvent(34);
    }
    this.saveObjectValue();
  }

  private void plantClearFruit()
  {
    for (int index = 0; index < this.m_fruit.Length; ++index)
    {
      if (this.m_fruit[index] != null)
      {
        ModelManager.orphanNode(this.m_fruit[index].getNode());
        this.m_fruit[index].unload();
        this.m_fruit[index] = (Model) null;
      }
    }
  }

  private void plantCreateFruit()
  {
    int num = this.fruitPerHarvest();
    for (int index = 0; index < num; ++index)
    {
      this.plantSpawnFruit(index);
      AnimPlayer3D animPlayer3D = this.m_fruit[index].getAnimPlayer3D();
      int endTime = animPlayer3D.getEndTime();
      animPlayer3D.setAnimWorldTime(endTime);
      animPlayer3D.setAnimating(false);
    }
  }

  private void plantSpawnFruit(int index)
  {
    if (this.m_fruit.Length == 0)
      this.m_fruit = new Model[this.fruitPerHarvest()];
    if (index >= this.m_fruit.Length)
      return;
    Model model = this.m_fruit[index];
    if (model == null)
    {
      model = new Model();
      this.m_fruit[index] = model;
      int modelId = MapObject.fruitModelForPlant(this.getType());
      model.assembleObject(modelId);
      model.setTint(this.getSimWorld().getDayNightTint());
      Group.m3g_cast((Object3D) this.getModel().getLocator(this.FRUIT_LOCATORS[index])).addChild(model.getNode());
    }
    int animID = 243;
    if (this.isGroundPlant())
      animID = this.m_state == 1 ? 246 : 245;
    model.getAnimPlayer3D().startAnim(animID, 16);
  }

  public void plantHarvest()
  {
    int num1 = MapObject.fruitItemForPlant(this.getType());
    int num2 = this.fruitPerHarvest();
    if (this.getRuntimeFlag(65536))
    {
      num2 += 2;
      this.unsetRuntimeFlag(65536);
    }
    this.getSimData().registerHarvest(num2);
    this.getSimData().adjustInventory(num1, num2);
    this.m_scene.showGetItem(num1, num2, 445, 1082);
    if (this.isGroundPlant())
      this.plantUproot();
    else
      this.stateTransition(3);
    this.plantClearFruit();
    this.saveObjectValue();
  }

  public void plantUproot()
  {
    this.m_type = 24;
    this.getSimWorld().objectChange(this.getId(), 24);
    this.m_typeString = this.getSimWorld().getObjectStringId(24);
    this.m_state = 0;
    this.plantClearFruit();
    this.unsetRuntimeFlag(128);
    this.setSupportModel(-1);
    this.saveObjectValue();
  }

  private void plantStateTransition(int newState)
  {
    this.m_state = newState;
    this.unsetRuntimeFlag(128);
    switch (newState)
    {
      case 0:
        this.setSupportModel(-1);
        break;
      case 1:
        if (this.isGroundPlant())
        {
          this.setSupportModel(17);
          this.setSupportAnim3D(242);
        }
        else
        {
          this.setSupportModel(18);
          this.setSupportAnim3D(240);
        }
        this.setSupportAnimEnd();
        this.plantCreateFruit();
        break;
      case 2:
        if (this.isGroundPlant())
        {
          this.setSupportModel(17);
          this.setSupportAnim3D(241);
          this.setSupportAnimEnd();
          this.plantCreateFruit();
          break;
        }
        this.setSupportModel(18);
        this.setSupportAnim3D(239);
        this.setSupportAnimEnd();
        break;
      case 3:
        this.setSupportModel(18);
        this.setSupportAnim3D(240);
        this.setSupportAnimEnd();
        break;
      default:
        AppEngine.ASSERT(false, "invalid state for plant");
        this.setSupportModel(-1);
        break;
    }
  }

  private void plantUpdate(int timeStep)
  {
    this.updateAnim3D(timeStep);
    if (this.isAnimating() && this.updateAnim(timeStep))
    {
      int currAnimFrame = this.getAnimPlayer(this.ANIMPLAYER_PRIMARY).getCurrAnimFrame();
      if (currAnimFrame >= 1)
        this.plantSpawnFruit(currAnimFrame - 1);
    }
    for (int index = 0; index < this.m_fruit.Length; ++index)
      this.m_fruit[index]?.getAnimPlayer3D().updateAnim(timeStep);
  }

  private void phoneStateTransition(int newState)
  {
    this.unsetRuntimeFlag(128);
    switch (newState)
    {
      case 0:
        this.setAnim3D((int) byte.MaxValue);
        this.setAnim3DEnd();
        break;
      case 1:
        this.setRuntimeFlag(128);
        this.setAnim3D(256);
        break;
      case 2:
        this.setAnim3D(254);
        break;
      case 3:
        this.setAnim3D((int) byte.MaxValue);
        break;
    }
  }

  private void phoneUpdate(int timeStep)
  {
    this.updateAnim3D(timeStep);
    if (this.isAnimating3D())
      return;
    if (this.m_state == 2)
    {
      this.stateTransition(1);
    }
    else
    {
      if (this.m_state != 3)
        return;
      this.stateTransition(0);
    }
  }

  public void phonePickup()
  {
    this.stateTransition(2);
  }

  public void phoneHangup()
  {
    this.stateTransition(3);
  }

  public void showerOpen()
  {
    this.unsetRuntimeFlag(128);
    this.setAnim3D(262);
  }

  public void showerStart()
  {
    this.stateTransition(1);
    SoundManager soundManager = AppEngine.getCanvas().getSoundManager();
    float posX = (float) this.getPosX() / 65536f;
    float posY = (float) this.getPosY() / 65536f;
    float posZ = (float) this.getPosZ() / 65536f;
    this.m_tvSoundHandle = soundManager.playEventAt(78, posX, posY, posZ);
    soundManager.setLoopCountEvent(this.m_tvSoundHandle, -1);
  }

  public void showerEnd()
  {
    this.addBreakCleanPoints(15);
    this.stateTransition(0);
    AppEngine.getCanvas().getSoundManager().stopEvent(this.m_tvSoundHandle);
  }

  public void showerClose()
  {
    this.unsetRuntimeFlag(128);
    this.setAnim3D(263);
  }

  private void showerStateTransition(int newState)
  {
    switch (newState)
    {
      case 0:
        this.getModel(1)?.unload();
        break;
      case 1:
        Model modelCreate = this.getModelCreate(1);
        modelCreate.assembleObject(8);
        modelCreate.getAnimPlayer3D().startAnim(249, 20);
        break;
      default:
        AppEngine.ASSERT(false, "invalid state for shower");
        this.getModel(1)?.unload();
        break;
    }
  }

  private void showerUpdate(int timeStep)
  {
    this.updateAnim3D(timeStep);
  }

  public void stoveStart()
  {
    this.stateTransition(1);
  }

  public void stoveEnd()
  {
    this.stateTransition(0);
  }

  private void stoveStateTransition(int newState)
  {
  }

  public void trashCanKick(MapObjectSim fromSim)
  {
    this.m_scene.advertiseEvent(25, fromSim, this);
    this.setFacingObject((MapObject) fromSim);
    this.setFacingDir(this.m_facingDir + 2 & 3);
    this.stateTransition(2);
  }

  private void trashCanStateTransition(int newState)
  {
    AppEngine.ASSERT(true, "idle state for trashcan must be 0 to match default persistant value");
    int facingOffsetX = MapObject.getFacingOffsetX(6291456, 0, this.getFacingDir());
    int facingOffsetZ = MapObject.getFacingOffsetZ(6291456, 0, this.getFacingDir());
    this.unsetRuntimeFlag(128);
    switch (newState)
    {
      case 0:
        this.setAnim3D(251);
        this.setAnim3DEnd();
        if (this.m_state != 1)
          break;
        this.applyFootprint(false);
        this.reposition(this.getPosX() - facingOffsetX, this.getPosY(), this.getPosZ() - facingOffsetZ, this.getFacingDir());
        this.applyFootprint(true);
        break;
      case 1:
        this.setAnim3D(253);
        this.setAnim3DEnd();
        this.applyFootprint(false);
        this.reposition(this.getPosX() + facingOffsetX, this.getPosY(), this.getPosZ() + facingOffsetZ, this.getFacingDir());
        this.applyFootprint(true);
        break;
      case 2:
        this.setAnim3D(252);
        break;
      default:
        AppEngine.ASSERT(false, "invalid state for trashcan");
        this.setAnim3D(251);
        this.setAnim3DEnd();
        if (this.m_state != 1)
          break;
        this.applyFootprint(false);
        this.reposition(this.getPosX() - facingOffsetX, this.getPosY(), this.getPosZ() - facingOffsetZ, this.getFacingDir());
        this.applyFootprint(true);
        break;
    }
  }

  private void trashCanUpdate(int timeStep)
  {
    this.updateAnim3D(timeStep);
    if (this.m_state != 2 || this.isAnimating3D())
      return;
    this.stateTransition(1);
  }

  public void tvSwitchToAction()
  {
    AppEngine.getCanvas().getSoundManager().stopEvent(this.m_tvSoundHandle);
    this.m_tvSoundHandle = -1;
    this.unsetRuntimeFlag(16384);
    this.setRuntimeFlag(32768);
    this.saveObjectValue();
    this.stateTransition(1);
  }

  public void tvSwitchToComedy()
  {
    AppEngine.getCanvas().getSoundManager().stopEvent(this.m_tvSoundHandle);
    this.m_tvSoundHandle = -1;
    this.setRuntimeFlag(16384);
    this.unsetRuntimeFlag(32768);
    this.saveObjectValue();
    this.stateTransition(1);
  }

  private void tvStateTransition(int newState)
  {
    Model model = this.getModel();
    Node locator1 = model.getLocator(1102);
    Node locator2 = model.getLocator(1103);
    Node locator3 = model.getLocator(1101);
    switch (newState)
    {
      case 0:
        locator3.setRenderingEnable(true);
        locator1.setRenderingEnable(false);
        locator2.setRenderingEnable(false);
        if (this.m_tvSoundHandle == -1)
          break;
        AppEngine.getCanvas().getSoundManager().stopEvent(this.m_tvSoundHandle);
        this.m_tvSoundHandle = -1;
        break;
      case 1:
        locator3.setRenderingEnable(false);
        locator1.setRenderingEnable(this.getRuntimeFlag(32768));
        locator2.setRenderingEnable(!this.getRuntimeFlag(32768));
        this.setRuntimeFlag(128);
        this.setAnim(this.getRuntimeFlag(32768) ? 16 : 17);
        this.m_tvSoundHandle = AppEngine.getCanvas().getSoundManager().playEventAt(this.getRuntimeFlag(32768) ? 81 : 82, (float) this.getPosX() / 65536f, (float) this.getPosY() / 65536f, (float) this.getPosZ() / 65536f);
        break;
    }
  }

  private void tvUpdate(int timeStep)
  {
    if (this.m_state != 1)
      return;
    this.updateAnim(timeStep);
    this.getAnimPlayer().getFirePointCurrFrame(ref this.s_tempInt10, 0);
    ModelManager.getInstance().setTVFrame(this.s_tempInt10[0], this.getRuntimeFlag(32768));
  }

  public bool tvViewable(MapObject from)
  {
    if (!from.getFlag(8192) && from.getFacingDir() == this.getFacingDir())
      return false;
    int num1 = this.getPosX() - from.getPosX();
    int num2 = this.getPosZ() - from.getPosZ();
    int facingOffsetX = MapObject.getFacingOffsetX(1, 0, this.getFacingDir());
    int facingOffsetZ = MapObject.getFacingOffsetZ(1, 0, this.getFacingDir());
    return num1 * facingOffsetX + num2 * facingOffsetZ <= 0;
  }

  public void wallFadableSetAlpha(int alphaF)
  {
    this.getModel().getLocator(2005)?.setRenderingEnable(alphaF > 0);
    if (this.getParentType() != 32)
      return;
    this.setRuntimeFlag(8192, alphaF == 0);
  }

  protected AnimPlayer getAnimPlayer()
  {
    return this.getAnimPlayer(this.ANIMPLAYER_PRIMARY);
  }

  protected AnimPlayer getAnimPlayer(int index)
  {
    return index < this.m_animPlayers.Length ? this.m_animPlayers[index] : (AnimPlayer) null;
  }

  protected AnimPlayer getAnimPlayerCreate(int index)
  {
    if (index >= this.m_animPlayers.Length)
    {
      AnimPlayer[] animPlayerArray = new AnimPlayer[index + 1];
      midp.JSystem.arraycopy((Array) this.m_animPlayers, 0, (Array) animPlayerArray, 0, this.m_animPlayers.Length);
      this.m_animPlayers = animPlayerArray;
    }
    if (this.m_animPlayers[index] == null)
    {
      AnimPlayer animPlayer = new AnimPlayer();
      this.m_animPlayers[index] = animPlayer;
      animPlayer.setAnimating(false);
    }
    return this.m_animPlayers[index];
  }

  public virtual void render2D(Graphics g)
  {
    if (this.getParentType() != 1)
      return;
    SimWorld simWorld = this.getSimWorld();
    int[] tempInt10 = this.s_tempInt10;
    int posX = this.getPosX();
    int posY = this.getPosY();
    int posZ = this.getPosZ();
    if (this.getType() == 11)
    {
      int num = 2621440 + MathExt.Fmul(MathExt.smoothstepF(0, 1500, this.m_stateTime), 1966080);
      posY += num;
    }
    simWorld.coordWorldToScreen(tempInt10, posX, posY, posZ);
    int num1 = tempInt10[0];
    int num2 = tempInt10[1];
    if (this.getType() == 11)
    {
      g.Begin();
      this.renderEffectMoney(g, num1, num2);
      g.End();
    }
    else
    {
      if (this.getType() != 10)
        return;
      this.getAnimPlayer(this.ANIMPLAYER_PRIMARY).drawAnim(g, num1, num2);
    }
  }

  public Model getModel()
  {
    return this.getModel(0);
  }

  public Model getModel(int index)
  {
    return this.m_models != null && index < this.m_models.Length ? this.m_models[index] : (Model) null;
  }

  protected Model getModelCreate(int index)
  {
    if (index >= this.m_models.Length)
    {
      Model[] modelArray = new Model[index + 1];
      midp.JSystem.arraycopy((Array) this.m_models, 0, (Array) modelArray, 0, this.m_models.Length);
      this.m_models = modelArray;
    }
    if (this.m_models[index] == null)
    {
      Model model = new Model();
      this.getSimWorld().addObjectNode(model.getNode());
      this.m_models[index] = model;
    }
    return this.m_models[index];
  }

  public virtual void updateModel()
  {
    int facingAngle = this.getFacingAngle();
    int x = this.getPosX() + this.m_modelOffsetXF;
    int posY = this.getPosY();
    int z = this.getPosZ() + this.m_modelOffsetZF;
    bool enable = !this.getRuntimeFlag(8192) && this.m_inView;
    for (int index = 0; index < this.m_models.Length; ++index)
    {
      Model model = this.m_models[index];
      if (model != null)
      {
        int degrees = facingAngle;
        if (index == 1)
          degrees = (int) ((double) this.getSimWorld().getCameraYaw() * 65536.0);
        Node node = model.getNode();
        node.setTranslationx(x, posY, z);
        node.setOrientationx(degrees, 0, 65536, 0);
        node.setRenderingEnable(enable);
      }
    }
  }

  public virtual void updateTint()
  {
    SimWorld simWorld = this.getSimWorld();
    int tint = simWorld.getDayNightTint();
    switch (this.getParentType())
    {
      case 15:
      case 32:
        int worldTileX = simWorld.coordWorldToWorldTileX(this.getPosX());
        int worldTileZ = simWorld.coordWorldToWorldTileZ(this.getPosZ());
        int roomAt1 = simWorld.getRoomAt(worldTileX, worldTileZ);
        Room room1 = simWorld.getRoom(roomAt1);
        int tintColor1 = room1 != null ? room1.getTintInside() : tint;
        int num1 = 0;
        int num2 = 0;
        switch (this.getFacingDir())
        {
          case 0:
          case 2:
            num1 = -1;
            break;
          case 1:
          case 3:
            num2 = -1;
            break;
        }
        int tileX = worldTileX + num1;
        int tileZ = worldTileZ + num2;
        int roomAt2 = simWorld.getRoomAt(tileX, tileZ);
        Room room2 = simWorld.getRoom(roomAt2);
        int tintColor2 = room2 != null ? room2.getTintInside() : tint;
        Model model = this.getModel();
        Node locator1 = model.getLocator(2007);
        Node locator2 = model.getLocator(2008);
        Node locator3 = model.getLocator(2006);
        Node locator4 = model.getLocator(2009);
        if (locator3 != null)
          ModelManager.applyTintColor(locator3, tintColor1);
        if (locator4 != null)
          ModelManager.applyTintColor(locator4, tintColor1);
        if (locator1 != null)
          ModelManager.applyTintColor(locator1, tintColor2);
        if (locator2 == null)
          break;
        ModelManager.applyTintColor(locator2, tintColor2);
        break;
      default:
        Room room3 = this.getRoom();
        if (room3 != null)
          tint = room3.getTintInside();
        this.setTint(tint);
        break;
    }
  }

  private void setTint(int tint)
  {
    for (int index = 0; index < this.m_models.Length; ++index)
      this.getModel(index)?.setTint(tint);
  }

  public void createBuildContextMenu(int[] menu)
  {
    AppEngine.menuClear(menu, this.m_typeString);
    if (!this.buildInUse())
    {
      if (this.buildCanRotate())
        AppEngine.menuAppendItem(menu, 486);
      if (this.buildCanMove())
        AppEngine.menuAppendItem(menu, 485);
      if (!this.buildCanSell())
        return;
      AppEngine.menuAppendItem(menu, 484);
    }
    else
      AppEngine.menuAppendItem(menu, 431);
  }

  public bool isAgainstWall()
  {
    SimWorld simWorld = this.getSimWorld();
    int objectFootprintWidth = simWorld.getObjectFootprintWidth(this.getType());
    int objectFootprintHeight = simWorld.getObjectFootprintHeight(this.getType());
    int worldTileX = simWorld.coordWorldToWorldTileX(this.getPosX());
    int worldTileZ = simWorld.coordWorldToWorldTileZ(this.getPosZ());
    return simWorld.isAgainstWall(worldTileX, worldTileZ, objectFootprintWidth, objectFootprintHeight, this.getFacingDir());
  }

  public void applyFootprint(bool set)
  {
    SimWorld simWorld = this.getSimWorld();
    int objectFootprintWidth = simWorld.getObjectFootprintWidth(this.getType());
    int objectFootprintHeight = simWorld.getObjectFootprintHeight(this.getType());
    int num1 = objectFootprintWidth;
    int num2 = objectFootprintHeight;
    if (this.getFacingDir() == 1 || this.getFacingDir() == 3)
    {
      int num3 = num1;
      num1 = num2;
      num2 = num3;
    }
    this.m_footprintWidth = (sbyte) num1;
    this.m_footprintHeight = (sbyte) num2;
    if (!this.getFlag(1048592))
    {
      int attribAnd;
      int attribOr;
      if (this.getFlag(8))
      {
        if (set)
        {
          attribAnd = (int) ushort.MaxValue;
          attribOr = 8192;
        }
        else
        {
          attribAnd = -8193;
          attribOr = 0;
        }
      }
      else if (this.getParentType() == 15)
      {
        if (set)
        {
          attribAnd = (int) ushort.MaxValue;
          attribOr = 32832;
        }
        else
        {
          attribAnd = -32833;
          attribOr = 0;
        }
      }
      else if (this.getFlag(32))
      {
        if (set)
        {
          attribAnd = (int) ushort.MaxValue;
          attribOr = 32768;
        }
        else
        {
          attribAnd = -32769;
          attribOr = 0;
        }
      }
      else if (set)
      {
        attribAnd = (int) ushort.MaxValue;
        attribOr = 4096;
      }
      else
      {
        attribAnd = -4097;
        attribOr = 0;
      }
      int worldTileX = simWorld.coordWorldToWorldTileX(this.getPosX());
      int worldTileZ = simWorld.coordWorldToWorldTileZ(this.getPosZ());
      simWorld.paintAttributes(worldTileX - num1 + 1, worldTileZ - num2 + 1, num1, num2, attribAnd, attribOr);
      bool[] outResult = new bool[4];
      simWorld.getWallStatus(worldTileX, worldTileZ, num1, num2, this.getFacingDir(), ref outResult);
      Model model = this.getModel();
      if (model != null)
      {
        model.setNodeRenderingEnable(2001, outResult[0]);
        model.setNodeRenderingEnable(2002, outResult[2]);
        model.setNodeRenderingEnable(2003, outResult[1]);
        model.setNodeRenderingEnable(2004, outResult[3]);
      }
    }
    if (this.getFlag(2097152))
    {
      Model model = this.getModel();
      if (model != null)
      {
        if (!this.isAgainstWall())
        {
          if (this.getParentType() == 20 || this.getParentType() == 21)
            this.turnOff();
          model.switchRoot(1107);
        }
        else if (this.getParentType() == 20 || this.getParentType() == 21)
          model.switchRoot(this.getRuntimeFlag(64) ? 1100 : 1101);
        else
          model.switchRoot(1108);
      }
    }
    if (set && (objectFootprintWidth > 1 || objectFootprintHeight > 1))
    {
      this.m_modelOffsetXF = -((num1 - 1) * 2097152 >> 1);
      this.m_modelOffsetZF = -((num2 - 1) * 2097152 >> 1);
    }
    if (!set)
      return;
    this.updateTint();
  }

  public int getFacingDir()
  {
    return this.m_facingDir;
  }

  public static int getFacingAngle(int dir)
  {
    switch (dir)
    {
      case 0:
        return 5898240;
      case 1:
        return 0;
      case 2:
        return -5898240;
      case 3:
        return 11796480;
      case 4:
        return 2949120;
      case 5:
        return -2949120;
      case 6:
        return -8847360;
      case 7:
        return 8847360;
      default:
        return 0;
    }
  }

  public static int getFacingOffsetX(int x, int z, int facingDir)
  {
    switch (facingDir)
    {
      case 0:
        return x;
      case 1:
        return -z;
      case 2:
        return -x;
      case 3:
        return z;
      default:
        return 0;
    }
  }

  public static int getFacingOffsetZ(int x, int z, int facingDir)
  {
    switch (facingDir)
    {
      case 0:
        return z;
      case 1:
        return x;
      case 2:
        return -z;
      case 3:
        return -x;
      default:
        return 0;
    }
  }

  public virtual int getFacingAngle()
  {
    return MapObject.getFacingAngle(this.m_facingDir);
  }

  public void setFacingDir(int dir)
  {
    if (this.m_facingDir == dir)
      return;
    this.m_facingDir = dir;
  }

  public static int getFacingDir(int dx, int dz)
  {
    return midp.JMath.abs(dx) <= midp.JMath.abs(dz) ? (dz >= 0 ? 1 : 3) : (dx >= 0 ? 0 : 2);
  }

  public static int getFacingDirFull(int dx, int dz)
  {
    if (dz == 0)
      return dx < 0 ? 2 : 0;
    if (dx == 0)
      return dz < 0 ? 3 : 1;
    if (dx < 0 && dz < 0)
    {
      if (dz << 1 > dx)
        return 2;
      return dx << 1 > dz ? 3 : 6;
    }
    if (dx > 0 && dz < 0)
    {
      if (-(dz << 1) < dx)
        return 0;
      return dx << 1 < -dz ? 3 : 7;
    }
    if (dx > 0 && dz > 0)
    {
      if (dz << 1 < dx)
        return 0;
      return dx << 1 < dz ? 1 : 4;
    }
    if (dx >= 0 || dz <= 0)
      return 0;
    if (dz << 1 < -dx)
      return 2;
    return -(dx << 1) < dz ? 1 : 5;
  }

  public void setFacingDir(int dx, int dz)
  {
    if (this.getFlag(8192))
      this.setFacingDir(MapObject.getFacingDirFull(dx, dz));
    else
      this.setFacingDir(MapObject.getFacingDir(dx, dz));
  }

  public void setFacingObject(MapObject @object)
  {
    int num1 = midp.JMath.max((int) @object.m_footprintWidth, 1);
    int num2 = midp.JMath.max((int) @object.m_footprintHeight, 1);
    int num3 = (num1 << 21) - 1048576;
    int num4 = (num2 << 21) - 1048576;
    int num5 = @object.getPosX() - num3;
    int num6 = @object.getPosZ() - num4;
    int num7 = @object.getPosX() + 1048576;
    int num8 = @object.getPosZ() + 1048576;
    int dx = this.getPosX() < num5 ? 1 : (this.getPosX() > num7 ? -1 : 0);
    int dz = this.getPosZ() < num6 ? 1 : (this.getPosZ() > num8 ? -1 : 0);
    if (dx == 0 && dz == 0)
    {
      int num9 = (num1 << 21) - 2097152 >> 1;
      int num10 = (num2 << 21) - 2097152 >> 1;
      int num11 = @object.getPosX() - num9;
      int num12 = @object.getPosZ() - num10;
      dx = num11 - this.getPosX();
      dz = num12 - this.getPosZ();
    }
    this.setFacingDir(MapObject.getFacingDir(dx, dz));
  }

  public void setAnim(int animId)
  {
    this.getAnimPlayer(this.ANIMPLAYER_PRIMARY).startAnim(animId, this.getRuntimeFlag(128) ? 20 : 16);
  }

  public bool isAnimating()
  {
    return this.m_animPlayers[this.ANIMPLAYER_PRIMARY].isAnimating();
  }

  public bool isAnimating(int animPlayerIndex)
  {
    AnimPlayer animPlayer = this.getAnimPlayer(animPlayerIndex);
    return animPlayer != null && animPlayer.isAnimating();
  }

  public void setAnim3D(int anim3D)
  {
    this.unsetRuntimeFlag(4194304);
    this.getModel().getAnimPlayer3D().startAnim(anim3D, this.getRuntimeFlag(128) ? 20 : 16);
  }

  public void setAnim3DEnd()
  {
    AnimPlayer3D animPlayer3D = this.getModel().getAnimPlayer3D();
    int endTime = animPlayer3D.getEndTime();
    animPlayer3D.setAnimWorldTime(endTime);
    animPlayer3D.setAnimating(false);
  }

  public void setSupportModel(int modelId)
  {
    this.getModel().setSupportNode(modelId);
    this.updateTint();
  }

  public void setSupportAnim3D(int anim3D)
  {
    this.getModel().getSupportAnimPlayer3D().startAnim(anim3D, this.getRuntimeFlag(128) ? 20 : 16);
  }

  public void setSupportAnimEnd()
  {
    AnimPlayer3D supportAnimPlayer3D = this.getModel().getSupportAnimPlayer3D();
    int endTime = supportAnimPlayer3D.getEndTime();
    supportAnimPlayer3D.setAnimWorldTime(endTime);
    supportAnimPlayer3D.setAnimating(false);
  }

  public bool isSupportAnimating3D()
  {
    return this.getModel().getSupportAnimPlayer3D().isAnimating();
  }

  public bool isAnimating3D()
  {
    return this.getModel().getAnimPlayer3D().isAnimating();
  }

  public bool isAnimating3D(int animPlayerIndex)
  {
    Model model = this.getModel(animPlayerIndex);
    return model != null && model.getAnimPlayer3D().isAnimating();
  }

  public void setAnim3DTime(float t)
  {
    Model model = this.getModel();
    int time = (int) ((double) model.getAnimPlayer3D().getAnimDuration() * (double) t);
    model.getAnimPlayer3D().setAnimTime(time);
  }

  private bool buildInUse()
  {
    if (this.m_occupiedFlags != 0)
      return true;
    if (this.getFlag(524288))
    {
      SimWorld simWorld = this.getSimWorld();
      int type = this.getType();
      int num1 = simWorld.getObjectFootprintWidth(type);
      int num2 = simWorld.getObjectFootprintHeight(type);
      if (this.getFacingDir() == 1 || this.getFacingDir() == 3)
      {
        int num3 = num1;
        num1 = num2;
        num2 = num3;
      }
      int worldTileX = simWorld.coordWorldToWorldTileX(this.getPosX());
      int worldTileZ = simWorld.coordWorldToWorldTileZ(this.getPosZ());
      for (int index1 = 0; index1 < num1; ++index1)
      {
        for (int index2 = 0; index2 < num2; ++index2)
        {
          if (simWorld.isBenchTopObjectAt(worldTileX - index1, worldTileZ - index2))
            return true;
        }
      }
    }
    foreach (MapObjectSim simObject in this.m_scene.getSimObjects())
    {
      if (simObject.getPostureObject() == this)
        return true;
    }
    return false;
  }

  public bool buildCanSell()
  {
    return this.getSimWorld().getObjectSellPrice(this.m_type) > 0;
  }

  public bool buildCanMove()
  {
    SimWorld simWorld = this.getSimWorld();
    this.applyFootprint(false);
    int buildPoints = simWorld.createBuildPoints(this.getType());
    this.m_scene.removeBuildPoints();
    this.applyFootprint(true);
    return buildPoints >= 1;
  }

  public bool buildCanRotate()
  {
    return this.getNextValidRotation() != this.getFacingDir();
  }

  private int getNextValidRotation()
  {
    SimWorld simWorld = this.getSimWorld();
    bool flag = this.getFlag(1048576);
    if (!flag)
      this.applyFootprint(false);
    int num1 = this.getFacingDir();
    int worldTileX = simWorld.coordWorldToWorldTileX(this.getPosX());
    int worldTileZ = simWorld.coordWorldToWorldTileZ(this.getPosZ());
    int objectValidRotations = simWorld.getObjectValidRotations(this.getType(), worldTileX, worldTileZ);
    for (int index1 = 1; index1 <= 4; ++index1)
    {
      int index2 = (num1 + index1) % 4;
      int num2 = SimWorld.ROTATION_FLAGS[index2];
      if ((objectValidRotations & num2) != 0)
      {
        num1 = index2;
        break;
      }
    }
    if (!flag)
      this.applyFootprint(true);
    return num1;
  }

  public void buildRotate()
  {
    int nextValidRotation = this.getNextValidRotation();
    this.applyFootprint(false);
    this.reposition(this.getPosX(), this.getPosY(), this.getPosZ(), nextValidRotation);
    this.applyFootprint(true);
  }

  public void buildChangeType(int newType)
  {
  }

  protected void playSound(int soundId)
  {
    SoundManager soundManager = AppEngine.getCanvas().getSoundManager();
    float posX = (float) this.getPosX() / 65536f;
    float posY = (float) this.getPosY() / 65536f;
    float posZ = (float) this.getPosZ() / 65536f;
    soundManager.playEventAt(soundId, posX, posY, posZ);
  }
}
