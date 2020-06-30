// Decompiled with JetBrains decompiler
// Type: MapObjectSim
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;
using System;

public class MapObjectSim : MapObject
{
  private readonly int[,,] ANGRY_SOUNDS = new int[2, 1, 2];
  private readonly int[] GENERIC_NEEDS = new int[5]
  {
    8,
    4,
    16,
    32,
    128
  };
  private const int GET_ATTENTION_TIMEOUT = 4000;
  private const int GET_OCCUPIED_TIMEOUT = 4000;
  private const int TALK_TEXT_TIME = 2000;
  private const int MAX_STATE_TIME = 3000000;
  private const int NEED_CHECK_RATE = 2500;
  private const int MAX_CONVERSATION_TIMER = 20000;
  private const int MAX_LAST_CONVERSATION_TIMER = 20000;
  private const int SIM_STATE_NONE = 0;
  private const int SIM_STATE_IDLE = 1;
  private const int SIM_STATE_CHANGEPOSTURE = 2;
  private const int SIM_STATE_WALKING = 3;
  private const int SIM_STATE_FEEDBACK = 4;
  private const int SIM_STATE_GETATTENTION = 5;
  private const int SIM_STATE_GETOCCUPIED = 6;
  private const int SIM_STATE_LISTEN = 7;
  private const int SIM_STATE_HIDE = 8;
  private const int SIM_STATE_REMOVE = 9;
  public const int POSTURE_STANDING = 0;
  public const int POSTURE_SITTING_CHAIR = 1;
  public const int POSTURE_SITTING_TOILET = 2;
  public const int POSTURE_SITTING_BED = 3;
  public const int POSTURE_SITTING_READING = 4;
  public const int POSTURE_LYING_COUCH = 5;
  public const int POSTURE_LYING_BED = 6;
  public const int POSTURE_RELAXING = 7;
  public const int POSTURE_CROUCHING = 8;
  public const int POSTURE_PHONE = 9;
  public const int POSTURE_DANCING = 10;
  public const int POSTURE_FRIDGE = 11;
  public const int POSTURE_NAKED = 12;
  public const int POSTURE_BATH = 13;
  public const int POSTURE_SHOWER = 14;
  private const int NUM_VOICES = 2;
  private const int NUM_VARIATIONS = 1;
  private const int GENERIC_NEED_FLAGS = 188;
  private int m_appearance;
  private int m_subAppearance;
  private int m_simState;
  private int m_simStateTime;
  private int m_facingAngle;
  private int m_posture;
  private int m_targetPosture;
  private MapObject m_postureObject;
  private int m_simAction;
  private int m_simActionPhaseIndex;
  private int m_simPhase;
  private MapObject m_simActionArg1;
  private int m_simActionArg2;
  private int m_simActionArg3;
  private int m_queuedSimAction;
  private MapObject m_queuedSimActionArg1;
  private int m_queuedSimActionArg2;
  private int m_queuedSimActionArg3;
  private int m_needFlags;
  private int m_needCheckTimer;
  private MapObject m_occupiedObject;
  private int m_occupiedIndex;
  private int m_walkDestXF;
  private int m_walkDestZF;
  private int[] m_walkPath;
  private int m_walkPathPoint;
  private bool m_walkStopShort;
  private int m_checkPosXF;
  private int m_checkPosZF;
  private int m_conversationSim;
  private int m_conversationTimer;
  private int m_lastConversationTimer;
  private int m_feedbackSubAppearance;
  private int lastAction;
  private bool m_feedbackLoop;
  private bool m_feedbackRealTime;
  private int m_feedbackTime;
  private int m_feedbackFloaterAnimId;
  private bool m_feedbackAnimateFloater;
  private int m_feedbackSpeechBubbleAnimId;

  public MapObjectSim(SceneGame scene)
    : base(scene)
  {
    this.m_appearance = 0;
    this.m_subAppearance = 0;
    this.m_simState = 0;
    this.m_simStateTime = 0;
    this.m_facingAngle = 0;
    this.m_posture = 0;
    this.m_targetPosture = 0;
    this.m_postureObject = (MapObject) null;
    this.m_simAction = 0;
    this.m_simActionPhaseIndex = 0;
    this.m_simPhase = 0;
    this.m_simActionArg1 = (MapObject) null;
    this.m_simActionArg2 = 0;
    this.m_simActionArg3 = 0;
    this.m_queuedSimAction = 0;
    this.m_queuedSimActionArg1 = (MapObject) null;
    this.m_queuedSimActionArg2 = 0;
    this.m_queuedSimActionArg3 = 0;
    this.m_needFlags = 0;
    this.m_needCheckTimer = 0;
    this.m_occupiedObject = (MapObject) null;
    this.m_occupiedIndex = 0;
    this.m_walkDestXF = 0;
    this.m_walkDestZF = 0;
    this.m_walkPath = (int[]) null;
    this.m_walkPathPoint = 0;
    this.m_walkStopShort = false;
    this.m_checkPosXF = 0;
    this.m_checkPosZF = 0;
    this.m_conversationSim = 0;
    this.m_conversationTimer = 0;
    this.m_lastConversationTimer = 0;
    this.m_feedbackSubAppearance = 0;
    this.m_feedbackLoop = false;
    this.m_feedbackRealTime = false;
    this.m_feedbackTime = 0;
    this.m_feedbackFloaterAnimId = 0;
    this.m_feedbackAnimateFloater = false;
    this.m_feedbackSpeechBubbleAnimId = -1;
  }

  public new void Dispose()
  {
    base.Dispose();
  }

  public override void init(int type, int xF, int yF, int zF, int facingDir, int id)
  {
    base.init(type, xF, yF, zF, facingDir, id);
    this.m_simState = 0;
    this.m_simStateTime = 0;
    this.m_facingAngle = MapObject.getFacingAngle(facingDir);
    this.m_posture = 0;
    this.m_targetPosture = 0;
    this.m_postureObject = (MapObject) null;
    this.m_simAction = 0;
    this.m_simActionPhaseIndex = 0;
    this.m_simPhase = 0;
    this.m_simActionArg1 = (MapObject) null;
    this.m_simActionArg2 = 0;
    this.m_simActionArg3 = 0;
    this.m_queuedSimAction = -1;
    this.m_queuedSimActionArg1 = (MapObject) null;
    this.m_queuedSimActionArg2 = 0;
    this.m_queuedSimActionArg3 = 0;
    this.m_needFlags = 0;
    this.m_needCheckTimer = 0;
    this.m_occupiedObject = (MapObject) null;
    this.m_occupiedIndex = -1;
    this.m_walkDestXF = this.getPosX();
    this.m_walkDestZF = this.getPosZ();
    this.m_walkPath = (int[]) null;
    this.m_walkPathPoint = 0;
    this.m_walkStopShort = false;
    this.m_checkPosXF = 0;
    this.m_checkPosZF = 0;
    this.m_conversationSim = -1;
    this.m_conversationTimer = 0;
    this.m_lastConversationTimer = -1;
    this.m_feedbackSubAppearance = -1;
    this.m_feedbackLoop = true;
    this.m_feedbackTime = 0;
    this.m_feedbackAnimateFloater = false;
    this.m_feedbackSpeechBubbleAnimId = -1;
    this.getAnimPlayerCreate(this.ANIMPLAYER_PRIMARY);
    this.m_appearance = -1;
    this.m_subAppearance = 1;
    SimData simData = this.getSimData();
    if (this.m_scene.isMapMode())
    {
      this.getModelCreate(0).assembleMacromapSim(id);
      this.setAppearance(2);
    }
    else
    {
      this.getModelCreate(0).assembleSimForGame(id);
      if (simData.isSimMale(id))
        this.setAppearance(0);
      else
        this.setAppearance(1);
    }
    if (id == 0)
    {
      this.getModelCreate(2).assembleObject(169);
      for (int index = 0; index < 6; ++index)
      {
        int buff = simData.getBuff(index);
        if (buff != -1)
          this.startBuff(buff);
      }
      if (this.m_scene.isHouseMode() && this.getSimWorld().getHouseId() == 0)
        this.setFlag(2);
    }
    this.changeRoom(-1, this.getRoomId());
    this.simStateTransition(1);
  }

  public override void update(int timeStep)
  {
    if (this.m_simStateTime < 3000000)
      this.m_simStateTime += timeStep;
    if (this.m_conversationSim != -1)
    {
      this.m_conversationTimer += timeStep;
      if (this.m_conversationTimer > 20000)
        this.clearConversation();
    }
    else if (this.m_lastConversationTimer >= 0)
    {
      this.m_lastConversationTimer += timeStep;
      if (this.m_lastConversationTimer > 20000)
        this.m_lastConversationTimer = -1;
    }
    this.updateFacing(timeStep);
    this.getAnimPlayer().updateAnim(timeStep);
    switch (this.m_simState)
    {
      case 1:
        this.simUpdateIdle(timeStep);
        break;
      case 2:
        this.simUpdateChangePosture(timeStep);
        break;
      case 3:
        this.simUpdateWalking(timeStep);
        break;
      case 4:
        this.simUpdateFeedback(timeStep);
        break;
      case 5:
        this.simUpdateGetAttention(timeStep);
        break;
      case 6:
        this.simUpdateGetOccupied(timeStep);
        break;
      case 7:
        this.simUpdateListen(timeStep);
        break;
      case 8:
        this.simUpdateHide(timeStep);
        break;
    }
    this.lastAction = this.m_simAction;
  }

  public override void render2D(Graphics g)
  {
    AnimPlayer animPlayer = this.getAnimPlayer();
    int animId1 = animPlayer.getAnimID();
    if (!animPlayer.isAnimating() || animId1 == 9)
      return;
    SimWorld simWorld = this.getSimWorld();
    int[] tempInt10 = this.s_tempInt10;
    AnimationManager2D animationManager2D = this.m_engine.getAnimationManager2D();
    float num1 = (float) (1.0 / (double) simWorld.getCameraDolly() * 400.0);
    switch (animId1)
    {
      case 0:
        this.getModel().getLocatorPos(tempInt10, 1051, true);
        int worldX1 = tempInt10[0];
        int worldY1 = tempInt10[1];
        int worldZ1 = tempInt10[2];
        simWorld.coordWorldToScreen(tempInt10, worldX1, worldY1, worldZ1);
        int num2 = tempInt10[0];
        int num3 = tempInt10[1];
        int animId2 = -1;
        animPlayer.getFirePointCurrFrame(ref tempInt10, 0);
        switch (tempInt10[0])
        {
          case 0:
            animId2 = 29;
            break;
          case 1:
            animId2 = 30;
            break;
          case 2:
            animId2 = 31;
            break;
          case 3:
            animId2 = 32;
            break;
        }
        animationManager2D.submitAnim(animId2, (float) num2, (float) num3, 1f, num1, num1);
        animationManager2D.flushAnims(g);
        break;
      case 9:
        break;
      default:
        int num4 = 1638400;
        if (this.m_feedbackAnimateFloater)
        {
          int a = 65536 - MathExt.smoothstepF(1000, 2000, this.m_feedbackTime);
          num4 += MathExt.Fmul(a, 655360);
        }
        Model model = this.getModel();
        if (this.m_scene.isMapMode())
          model.getHotspot(tempInt10, 0, true);
        else
          model.getLocatorPos(tempInt10, 702, true);
        int worldX2 = tempInt10[0];
        int worldY2 = tempInt10[1] + num4;
        int worldZ2 = tempInt10[2];
        simWorld.coordWorldToScreen(tempInt10, worldX2, worldY2, worldZ2);
        int num5 = tempInt10[0];
        int num6 = tempInt10[1];
        int animId3 = -1;
        int num7 = 1;
        bool flag = false;
        switch (animId1)
        {
          case 1:
            animId3 = 242;
            flag = true;
            break;
          case 2:
            ++num7;
            animId3 = 242;
            flag = true;
            break;
          case 3:
            num7 = num7 + 1 + 1;
            animId3 = 242;
            flag = true;
            break;
          case 4:
            animId3 = 243;
            flag = true;
            break;
          case 5:
            ++num7;
            animId3 = 243;
            flag = true;
            break;
          case 6:
            num7 = num7 + 1 + 1;
            animId3 = 243;
            flag = true;
            break;
          case 12:
          case 13:
            num7 = 4;
            animId3 = 243;
            flag = true;
            break;
          case 14:
            num7 = 4;
            animId3 = 242;
            flag = true;
            break;
          case 15:
            num6 -= 15;
            animId3 = 377;
            break;
        }
        if (!flag || (animPlayer.getCurrAnimFrame() & 1) == 0)
        {
          float num8 = animationManager2D.getAnimWidth(animId3) * num1;
          float num9 = (float) num5 - (float) ((double) num8 * (double) (num7 - 1) * 0.5);
          for (int index = 0; index < num7; ++index)
          {
            float x = num9 + (float) index * num8;
            animationManager2D.submitAnim(animId3, x, (float) num6, 1f, num1, num1);
          }
        }
        if (this.m_simPhase == 6 && animId1 == 15 && this.m_feedbackSpeechBubbleAnimId != -1)
        {
          float num8 = -8f * num1;
          animationManager2D.submitAnim(this.m_feedbackSpeechBubbleAnimId, (float) num5, (float) num6 + num8, 1f, num1, num1);
        }
        animationManager2D.flushAnims(g);
        break;
    }
  }

  public new void reposition(int posXF, int posYF, int posZF, int facing)
  {
    int roomId1 = this.getRoomId();
    base.reposition(posXF, posYF, posZF, facing);
    int roomId2 = this.getRoomId();
    this.changeRoom(roomId1, roomId2);
  }

  public override int getFacingAngle()
  {
    return this.m_facingAngle;
  }

  private void snapFacingAngle()
  {
    this.m_facingAngle = MapObject.getFacingAngle(this.getFacingDir());
  }

  private void updateFacing(int timeStep)
  {
    int angle1 = this.m_facingAngle;
    int facingAngle = MapObject.getFacingAngle(this.getFacingDir());
    int a = this.getRuntimeFlag(16777216) ? 2293760 : 983040;
    int b1 = 42598;
    int b2 = timeStep << 6;
    int betweenAnglesDegF1 = MathExt.getDiffBetweenAnglesDegF(angle1, facingAngle);
    int b3 = MathExt.Fmul(midp.JMath.abs(betweenAnglesDegF1), b1);
    int num = MathExt.Fmul(MathExt.Fmul(a, b3), b2);
    if (facingAngle < -5898240 && angle1 > 5898240)
      angle1 = MathExt.normaliseAngleDegreesF(angle1 + num);
    else if (facingAngle > 5898240 && angle1 < -5898240)
      angle1 = MathExt.normaliseAngleDegreesF(angle1 - num);
    else if (betweenAnglesDegF1 > 0)
      angle1 = MathExt.normaliseAngleDegreesF(angle1 + num);
    else if (betweenAnglesDegF1 < 0)
      angle1 = MathExt.normaliseAngleDegreesF(angle1 - num);
    int betweenAnglesDegF2 = MathExt.getDiffBetweenAnglesDegF(angle1, facingAngle);
    if (MathExt.sign(betweenAnglesDegF1) != MathExt.sign(betweenAnglesDegF2))
      angle1 = facingAngle;
    this.m_facingAngle = angle1;
  }

  protected override void updateAnim3D(int timeStep)
  {
    base.updateAnim3D(timeStep);
    if (this.getId() != 0)
      return;
    this.getModel(2).updatePlumbBob(timeStep, true);
  }

  public override void updateModel()
  {
    base.updateModel();
    if (this.getId() != 0)
      return;
    Model model = this.getModel(0);
    if (this.m_scene.isMapMode())
      model.getHotspot(this.s_tempInt10, 0, false);
    else
      model.getLocatorPos(this.s_tempInt10, 702, false);
    this.getModel(2).updatePlumbBob(0, false, this.s_tempInt10[0], this.s_tempInt10[1] + 1638400, this.s_tempInt10[2], (float) this.m_facingAngle * 1.525879E-05f, this.getSimWorld().getCameraYaw(), this.getSimWorld().getCameraPitch());
  }

  public override void updateTint()
  {
    base.updateTint();
    if (!this.m_scene.isMapMode())
      return;
    bool dayNightLighting = this.getSimWorld().getDayNightLighting();
    Model model = this.getModel();
    model.getLocator(5050).setRenderingEnable(dayNightLighting);
    model.getLocator(5051).setRenderingEnable(dayNightLighting);
  }

  private void setAppearance(int appearance)
  {
    if (this.m_appearance == appearance)
      return;
    this.m_appearance = appearance;
    Model model = this.getModel();
    if (appearance == 2 || appearance == 3)
    {
      model.getLocator(1110).setRenderingEnable(appearance == 3);
      model.getLocator(1109).setRenderingEnable(appearance == 2);
    }
    int subAppearance = this.m_subAppearance;
    this.m_subAppearance = -1;
    this.setSubAppearance(subAppearance);
  }

  public void setSubAppearance(int type)
  {
    type = this.getSimWorld().mapSubAppearance(type);
    if (this.m_subAppearance == type)
      return;
    this.m_subAppearance = type;
    if (type == -1)
      return;
    this.setAnim3D(this.getSimWorld().getSubAppearanceAnim3D(this.m_appearance, type));
    int modelId = -1;
    int anim3D = 0;
    bool flag = false;
    switch (type)
    {
      case 34:
        modelId = 171;
        anim3D = 0;
        break;
      case 36:
        modelId = 174;
        anim3D = 217;
        break;
      case 37:
        modelId = 174;
        anim3D = 218;
        break;
      case 38:
        modelId = 174;
        anim3D = 219;
        break;
      case 45:
      case 90:
      case 91:
      case 92:
        flag = true;
        break;
      case 57:
        modelId = 172;
        anim3D = 221;
        break;
      case 65:
        modelId = 175;
        anim3D = 247;
        break;
      case 76:
        modelId = 174;
        anim3D = 220;
        break;
      case 84:
        modelId = 170;
        anim3D = 222;
        break;
    }
    this.setSupportModel(modelId);
    this.setSupportAnim3D(anim3D);
    if (flag)
    {
      this.getAnimPlayer().startAnim(0, 4);
    }
    else
    {
      if (this.getAnimPlayer().getAnimID() != 0)
        return;
      this.getAnimPlayer().setAnimating(false);
    }
  }

  public int getSubAppearance()
  {
    return this.m_subAppearance;
  }

  private void simStateTransition(int newState)
  {
    SceneGame scene = this.m_scene;
    switch (this.m_simState)
    {
      case 2:
        if (this.m_postureObject != null && this.m_posture == 0)
        {
          this.m_postureObject = (MapObject) null;
          break;
        }
        break;
      case 3:
        if (newState != 3 && scene.isMapMode())
        {
          this.setAppearance(2);
          if (scene.getCameraTarget() == this)
          {
            scene.setCameraFollow((MapObject) null);
            break;
          }
          break;
        }
        break;
      case 8:
        this.unsetRuntimeFlag(8192);
        break;
    }
    this.setRuntimeFlag(128);
    int simState = this.m_simState;
    this.m_simState = newState;
    this.m_simStateTime = 0;
    switch (newState)
    {
      case 1:
        this.setSubAppearance(this.m_posture == 6 ? (this.getRuntimeFlag(524288) ? 25 : 26) : (this.m_posture == 5 ? 81 : (this.m_posture == 7 ? 40 : (this.m_posture == 3 ? 22 : (this.m_posture == 1 ? 31 : (this.m_posture == 2 ? 91 : (this.m_posture == 4 ? 37 : (this.m_posture == 8 ? 43 : (this.m_posture == 9 ? 48 : (this.m_posture == 10 ? 52 : (this.m_posture == 11 ? 1 : (this.m_posture == 13 ? 70 : (this.m_posture == 14 ? 97 : (this.m_posture == 12 ? 1 : 1))))))))))))));
        break;
      case 2:
        this.simStateTransitionChangePosture();
        break;
      case 3:
        AppEngine.ASSERT(this.m_posture == 0, "not standing but trying to walk!");
        this.setSubAppearance(0);
        if (this.getId() != 0 || !scene.isMapMode() || (this.isInView() || simState == 3))
          break;
        scene.setCameraFollow((MapObject) this);
        break;
      case 4:
        SimData simData = this.getSimData();
        if (this.m_feedbackFloaterAnimId != -1)
        {
          this.getAnimPlayer().startAnim(this.m_feedbackFloaterAnimId, 16);
          if (this.m_simPhase == 6)
            this.m_feedbackSpeechBubbleAnimId = simData.getActionTalkIcon(this.m_simAction);
        }
        else
          this.getAnimPlayer().setAnimating(false);
        if (this.m_feedbackSubAppearance == -1)
          this.m_feedbackSubAppearance = simData.getActionWorldArg(this.m_simAction);
        MapObjectSim simActionArg1Sim1 = this.getSimActionArg1Sim();
        if (this.m_simAction == 86 || this.m_simAction == 87 || this.m_simAction == 88)
        {
          if (simData.actionAccept(this.getId(), simActionArg1Sim1.getId(), this.m_simAction))
          {
            simActionArg1Sim1.unsetRuntimeFlag(128);
            if (this.m_simAction == 86)
            {
              simActionArg1Sim1.setSubAppearance(17);
              this.m_feedbackSubAppearance = 20;
            }
            else
            {
              simActionArg1Sim1.setSubAppearance(68);
              this.m_feedbackSubAppearance = 68;
            }
            if (this.m_simAction == 88)
              scene.triggerEvent(3);
          }
          else
          {
            simActionArg1Sim1.unsetRuntimeFlag(128);
            simActionArg1Sim1.setSubAppearance(19);
            this.m_feedbackSubAppearance = 18;
          }
        }
        else if (this.m_simAction == 97)
        {
          simActionArg1Sim1.unsetRuntimeFlag(128);
          simActionArg1Sim1.setSubAppearance(16);
        }
        else if (this.m_simAction == 98)
        {
          simActionArg1Sim1.unsetRuntimeFlag(128);
          simActionArg1Sim1.setSubAppearance(102);
        }
        else if (this.m_simAction == 82)
        {
          simActionArg1Sim1.unsetRuntimeFlag(128);
          simActionArg1Sim1.setSubAppearance(103);
        }
        if (!this.m_feedbackLoop)
          this.unsetRuntimeFlag(128);
        this.setSubAppearance(this.m_feedbackSubAppearance);
        break;
      case 5:
      case 6:
        this.setSubAppearance(1);
        break;
      case 7:
        this.setFacingObject(this.m_simActionArg1);
        int type = -5;
        MapObjectSim simActionArg1Sim2 = this.getSimActionArg1Sim();
        if (simActionArg1Sim2 != null)
        {
          switch (simActionArg1Sim2.getSimAction())
          {
            case 86:
            case 87:
              type = 1;
              break;
          }
        }
        this.setSubAppearance(type);
        break;
      case 8:
        this.setRuntimeFlag(8192);
        break;
      case 9:
        this.destroy();
        break;
    }
  }

  private void simStateTransitionChangePosture()
  {
    SimWorld simWorld = this.getSimWorld();
    int type = -1;
    int num1 = this.m_posture;
    MapObject simActionArg1 = this.m_simActionArg1;
    switch (this.m_posture)
    {
      case 0:
        if (this.m_targetPosture == 10)
        {
          type = 51;
          num1 = 10;
          break;
        }
        if (this.m_targetPosture == 9)
        {
          type = 46;
          num1 = 9;
          this.m_postureObject = simActionArg1;
          simActionArg1.phonePickup();
          break;
        }
        if (this.m_targetPosture == 11)
        {
          type = 77;
          num1 = 11;
          this.m_postureObject = simActionArg1;
          simActionArg1.fridgeOpen();
          break;
        }
        if (this.m_targetPosture == 13 || this.m_targetPosture == 14)
        {
          type = 93;
          num1 = 12;
          break;
        }
        if (this.m_targetPosture == 2)
        {
          type = 90;
          num1 = 2;
          break;
        }
        if (this.m_targetPosture == 3 || this.m_targetPosture == 6)
        {
          this.m_postureObject = simActionArg1;
          type = 21;
          num1 = 3;
          break;
        }
        if (this.m_targetPosture == 8)
        {
          type = 42;
          num1 = 8;
          break;
        }
        if (this.m_targetPosture == 1 || this.m_targetPosture == 7 || (this.m_targetPosture == 5 || this.m_targetPosture == 4))
        {
          AppEngine.ASSERT(simActionArg1 != null, "sitting without a chair");
          this.m_postureObject = simActionArg1;
          type = 30;
          num1 = 1;
          if (simActionArg1.getParentType() == 13)
          {
            this.setFacingDir(simActionArg1.getFacingDir());
            type = 30;
            break;
          }
          switch (simActionArg1.getFacingDir() + 4 - this.getFacingDir() & 3)
          {
            case 0:
              type = 30;
              break;
            case 1:
              type = 86;
              break;
            case 2:
              this.setFacingDir(this.getFacingDir() + 2 & 3);
              type = 30;
              break;
            case 3:
              type = 85;
              break;
          }
        }
        else
          break;
        break;
      case 1:
        if (this.m_targetPosture == 4)
        {
          type = 36;
          num1 = 4;
          break;
        }
        if (this.m_targetPosture == 7 || this.m_targetPosture == 5)
        {
          type = 39;
          num1 = 7;
          break;
        }
        if (this.m_targetPosture == 0)
        {
          int num2 = num1;
          num1 = 0;
          MapObject postureObject = this.m_postureObject;
          if (postureObject.getParentType() == 13)
          {
            type = 35;
          }
          else
          {
            int facingDir = postureObject.getFacingDir();
            int facingOffsetX1 = MapObject.getFacingOffsetX(0, 2097152, facingDir);
            int facingOffsetZ1 = MapObject.getFacingOffsetZ(0, 2097152, facingDir);
            int facingOffsetX2 = MapObject.getFacingOffsetX(0, -2097152, facingDir);
            int facingOffsetZ2 = MapObject.getFacingOffsetZ(0, -2097152, facingDir);
            int facingOffsetX3 = MapObject.getFacingOffsetX(2097152, 0, facingDir);
            int facingOffsetZ3 = MapObject.getFacingOffsetZ(2097152, 0, facingDir);
            int posX = postureObject.getPosX();
            int posZ = postureObject.getPosZ();
            if (postureObject.getParentType() == 12)
            {
              switch (facingDir)
              {
                case 0:
                  posX -= 2097152;
                  break;
                case 1:
                  posZ -= 2097152;
                  break;
              }
            }
            type = -1;
            if (postureObject.getParentType() != 12)
            {
              int xF = posX + facingOffsetX3;
              int zF = posZ + facingOffsetZ3;
              if (simWorld.isWorldPointWalkableFrom(xF, zF, posX, posZ))
                type = 35;
            }
            if (type == -1)
            {
              int num3 = posX + facingOffsetX1;
              int num4 = posZ + facingOffsetZ1;
              if (simWorld.isWorldPointWalkableFrom(num3, num4, posX, posZ))
              {
                type = 87;
                this.reposition(num3, this.getPosY(), num4, facingDir + 3 & 3);
                this.snapFacingAngle();
              }
            }
            if (type == -1)
            {
              int num3 = posX + facingOffsetX2;
              int num4 = posZ + facingOffsetZ2;
              if (simWorld.isWorldPointWalkableFrom(num3, num4, posX, posZ))
              {
                type = 88;
                this.reposition(num3, this.getPosY(), num4, facingDir + 1 & 3);
                this.snapFacingAngle();
              }
            }
          }
          if (type == -1)
          {
            this.m_simAction = this.lastAction;
            this.m_simState = 0;
            this.m_posture = num2;
            this.m_queuedSimAction = -1;
            this.m_queuedSimActionArg1 = (MapObject) null;
            this.m_queuedSimActionArg2 = 0;
            this.m_queuedSimActionArg3 = 0;
            break;
          }
          break;
        }
        break;
      case 2:
        type = 92;
        num1 = 0;
        break;
      case 3:
        if (this.m_targetPosture == 0)
        {
          type = 29;
          num1 = 0;
          break;
        }
        if (this.m_targetPosture == 6)
        {
          this.setRuntimeFlag(524288, (this.getFacingDir() + 4 - simActionArg1.getFacingDir() & 3) == 3);
          type = this.getRuntimeFlag(524288) ? 23 : 24;
          num1 = 6;
          Room room = this.getRoom();
          if (room != null)
          {
            room.removeSim();
            break;
          }
          break;
        }
        break;
      case 4:
        type = 38;
        num1 = 1;
        break;
      case 5:
        type = 82;
        num1 = 7;
        break;
      case 6:
        type = this.getRuntimeFlag(524288) ? 27 : 28;
        num1 = 3;
        Room room1 = this.getRoom();
        if (room1 != null)
        {
          room1.addSim();
          break;
        }
        break;
      case 7:
        if (this.m_targetPosture == 5)
        {
          type = 80;
          num1 = 5;
          break;
        }
        type = 41;
        num1 = 1;
        break;
      case 8:
        type = 44;
        num1 = 0;
        break;
      case 9:
        type = 47;
        num1 = 0;
        this.m_postureObject.phoneHangup();
        break;
      case 10:
        type = 53;
        num1 = 0;
        break;
      case 11:
        type = 78;
        num1 = 0;
        this.m_postureObject.fridgeClose();
        break;
      case 12:
        if (this.m_targetPosture == 13)
        {
          type = 69;
          num1 = 13;
          this.m_postureObject = simActionArg1;
          simActionArg1.bathToFill();
          break;
        }
        if (this.m_targetPosture == 14)
        {
          type = 94;
          num1 = 14;
          this.m_postureObject = simActionArg1;
          simActionArg1.showerOpen();
          this.setRuntimeFlag(8388608);
          break;
        }
        type = 93;
        num1 = 0;
        break;
      case 13:
        type = 71;
        num1 = 12;
        this.m_postureObject.bathToEmpty();
        break;
      case 14:
        type = 97;
        this.setRuntimeFlag(8388608);
        this.m_postureObject.showerOpen();
        num1 = 12;
        break;
      default:
        AppEngine.ASSERT(false, "invalid current posture");
        if (this.m_targetPosture == 10)
        {
          type = 51;
          num1 = 10;
          break;
        }
        if (this.m_targetPosture == 9)
        {
          type = 46;
          num1 = 9;
          this.m_postureObject = simActionArg1;
          simActionArg1.phonePickup();
          break;
        }
        if (this.m_targetPosture == 11)
        {
          type = 77;
          num1 = 11;
          this.m_postureObject = simActionArg1;
          simActionArg1.fridgeOpen();
          break;
        }
        if (this.m_targetPosture == 13 || this.m_targetPosture == 14)
        {
          type = 93;
          num1 = 12;
          break;
        }
        if (this.m_targetPosture == 2)
        {
          type = 90;
          num1 = 2;
          break;
        }
        if (this.m_targetPosture == 3 || this.m_targetPosture == 6)
        {
          this.m_postureObject = simActionArg1;
          type = 21;
          num1 = 3;
          break;
        }
        if (this.m_targetPosture == 8)
        {
          type = 42;
          num1 = 8;
          break;
        }
        if (this.m_targetPosture == 1 || this.m_targetPosture == 7 || (this.m_targetPosture == 5 || this.m_targetPosture == 4))
        {
          AppEngine.ASSERT(simActionArg1 != null, "sitting without a chair");
          this.m_postureObject = simActionArg1;
          type = 30;
          num1 = 1;
          if (simActionArg1.getParentType() == 13)
          {
            this.setFacingDir(simActionArg1.getFacingDir());
            type = 30;
            break;
          }
          switch (simActionArg1.getFacingDir() + 4 - this.getFacingDir() & 3)
          {
            case 0:
              type = 30;
              break;
            case 1:
              type = 86;
              break;
            case 2:
              this.setFacingDir(this.getFacingDir() + 2 & 3);
              type = 30;
              break;
            case 3:
              type = 85;
              break;
          }
        }
        else
          break;
        break;
    }
    AppEngine.ASSERT(num1 != this.m_posture, "invalid posture change");
    AppEngine.ASSERT(type != -1, "invalid posture transition appearance type");
    this.m_posture = num1;
    this.unsetRuntimeFlag(128);
    this.setSubAppearance(type);
  }

  private void simFeedback(
    int subAppearance,
    int timer,
    int floatAnim,
    bool animateFloater,
    bool gameTime)
  {
    this.m_feedbackSubAppearance = subAppearance;
    this.m_feedbackLoop = timer >= 0;
    this.m_feedbackTime = timer;
    this.m_feedbackFloaterAnimId = floatAnim;
    this.m_feedbackAnimateFloater = animateFloater;
    this.m_feedbackRealTime = gameTime;
    this.simStateTransition(4);
  }

  private void endFeedback()
  {
    this.m_feedbackSubAppearance = -1;
    this.m_feedbackLoop = false;
    this.m_feedbackTime = -1;
    this.m_feedbackFloaterAnimId = -1;
    this.m_feedbackAnimateFloater = false;
    this.m_feedbackRealTime = true;
    this.getAnimPlayer().setAnimating(false);
  }

  private void simHide(int timer, bool gameTime)
  {
    this.m_feedbackTime = timer;
    this.m_feedbackRealTime = gameTime;
    this.simStateTransition(8);
  }

  private void simUpdateIdle(int timeStep)
  {
    this.updateAnim3D(timeStep);
    this.m_needCheckTimer += timeStep;
    if (this.m_queuedSimAction != -1)
    {
      this.beginSimAction(this.m_queuedSimAction, this.m_queuedSimActionArg1, this.m_queuedSimActionArg2, this.m_queuedSimActionArg3);
      this.m_queuedSimAction = -1;
      this.m_queuedSimActionArg1 = (MapObject) null;
    }
    else
    {
      if (this.getType() == 0)
      {
        if (this.m_simStateTime > 3000 && this.getSimData().buffGetActiveSlot(10) != -1)
        {
          this.beginSimAction(3, (MapObject) null);
          return;
        }
        if (this.m_simStateTime > 3500 && this.m_posture == 0)
        {
          int action = -1;
          int moodLevel = this.getSimData().getMoodLevel();
          int num = this.m_engine.randPercent();
          if (this.getSimData().buffGetActiveSlot(1) != -1 && num < 30 || this.getSimData().buffGetActiveSlot(2) != -1 && num < 60)
            action = 7;
          else if (moodLevel > 4915200)
            action = 5;
          else if (moodLevel < -3276800)
            action = 6;
          if (action != -1)
          {
            this.beginSimAction(action, (MapObject) null);
            return;
          }
        }
      }
      if (this.m_simStateTime > 1000)
      {
        bool flag1 = this.m_posture == 1;
        MapObject postureObject = this.m_postureObject;
        bool flag2 = this.m_posture == 0;
        MapObject objectByParentType = this.m_scene.findRandomObjectByParentType(31);
        if (objectByParentType != null && objectByParentType.getRuntimeFlag(64) && objectByParentType.getRoomId() == this.getRoomId() && (flag1 && postureObject != null && objectByParentType.tvViewable(postureObject) || flag2 && objectByParentType.tvViewable((MapObject) this)))
        {
          if (this.getId() == 0)
          {
            this.getSimData().dreamCompleteEvent(35);
            if (!this.isIdle())
              return;
          }
          int action = 18;
          if (flag1)
          {
            action = 20;
            if (objectByParentType.getRuntimeFlag(32768))
              action = 19;
          }
          this.beginSimAction(action, objectByParentType);
          return;
        }
      }
      if (this.m_posture == 0 && this.m_simStateTime > 5000)
      {
        MapObject objectByParentType = this.m_scene.findRandomObjectByParentType(26);
        if (objectByParentType != null && objectByParentType.getRuntimeFlag(64))
        {
          SimWorld simWorld = this.getSimWorld();
          int worldTileX1 = simWorld.coordWorldToWorldTileX(objectByParentType.getPosX());
          int worldTileZ1 = simWorld.coordWorldToWorldTileZ(objectByParentType.getPosZ());
          int roomAt1 = simWorld.getRoomAt(worldTileX1, worldTileZ1);
          int worldTileX2 = simWorld.coordWorldToWorldTileX(this.getPosX());
          int worldTileZ2 = simWorld.coordWorldToWorldTileZ(this.getPosZ());
          int roomAt2 = simWorld.getRoomAt(worldTileX2, worldTileZ2);
          if (roomAt1 == roomAt2 && midp.JMath.abs(worldTileX2 - worldTileX1) + midp.JMath.abs(worldTileZ2 - worldTileZ1) < 5)
          {
            this.beginSimAction(21, (MapObject) null);
            return;
          }
        }
      }
      if (this.m_needCheckTimer <= 2500 || !this.occupiedIsEmpty())
        return;
      this.m_needCheckTimer = 0;
      this.checkNeeds();
    }
  }

  public int getPosture()
  {
    return this.m_posture;
  }

  public MapObject getPostureObject()
  {
    return this.m_postureObject;
  }

  private void simUpdateChangePosture(int timeStep)
  {
    this.updateAnim3D(timeStep);
    Model model = this.getModel();
    int animTime = model.getAnimPlayer3D().getAnimTime();
    if (this.m_subAppearance == 93 && !this.getRuntimeFlag(4194304) && animTime >= 1000)
    {
      this.setRuntimeFlag(4194304);
      int animId = model.getAnimPlayer3D().getAnimID();
      if (this.m_posture == 12)
        model.assembleSimForGameNaked(this.getId());
      else
        model.assembleSimForGame(this.getId());
      model.getAnimPlayer3D().startAnim(animId, 16);
      model.getAnimPlayer3D().setAnimTime(animTime);
      this.updateTint();
    }
    if (this.m_subAppearance == 97 && this.getRuntimeFlag(8388608) && !this.m_postureObject.isAnimating3D())
    {
      this.m_postureObject.showerEnd();
      this.unsetRuntimeFlag(128);
      this.setSubAppearance(98);
      this.m_posture = 12;
    }
    else
    {
      if (this.isAnimating3D())
        return;
      if (this.m_posture == 1)
      {
        int facingDir1 = this.m_postureObject.getFacingDir();
        int facingDir2 = this.getFacingDir();
        int num = facingDir1 + 4 - facingDir2 & 3;
        int x = 0;
        int z = 0;
        switch (num)
        {
          case 1:
            x = 1;
            z = -1;
            break;
          case 3:
            x = 1;
            z = 1;
            break;
        }
        this.reposition(this.getPosX() + MapObject.getFacingOffsetX(x, z, facingDir1) * 2097152, this.getPosY(), this.getPosZ() + MapObject.getFacingOffsetZ(x, z, facingDir1) * 2097152, facingDir1);
        this.snapFacingAngle();
      }
      if (this.getRuntimeFlag(8388608))
      {
        if (this.m_posture == 14)
        {
          this.unsetRuntimeFlag(8388736);
          this.m_simActionArg1.showerStart();
          this.setSubAppearance(96);
          return;
        }
        if (this.m_posture == 12)
        {
          this.unsetRuntimeFlag(8388736);
          this.setSubAppearance(95);
          this.m_postureObject.showerClose();
          return;
        }
      }
      if (this.m_posture == this.m_targetPosture)
        this.endSimPhase();
      else
        this.simStateTransition(2);
    }
  }

  private void simUpdateWalking(int timeStep)
  {
    SimWorld simWorld = this.getSimWorld();
    int posX = this.getPosX();
    int posZ = this.getPosZ();
    int walkDestXf = this.m_walkDestXF;
    int walkDestZf = this.m_walkDestZF;
    int worldTileX1 = simWorld.coordWorldToWorldTileX(posX);
    int worldTileZ1 = simWorld.coordWorldToWorldTileZ(posZ);
    int attribute1 = simWorld.getAttribute(worldTileX1, worldTileZ1);
    int dx = MathExt.sign(walkDestXf - posX);
    int dz = MathExt.sign(walkDestZf - posZ);
    int a1 = dx << 16;
    int a2 = dz << 16;
    if (dx != 0 && dz != 0)
    {
      a1 = MathExt.Fmul(a1, 46341);
      a2 = MathExt.Fmul(a2, 46341);
    }
    int num1 = 4170;
    int num2 = 8340;
    if (this.getRuntimeFlag(2048))
    {
      num1 = 5560;
      num2 = 11120;
    }
    else if (this.getRuntimeFlag(4096))
    {
      num1 = 2780;
      num2 = 5560;
    }
    if (this.m_scene.isMapMode())
    {
      num1 = num2;
      bool flag = this.getRuntimeFlag(16777216);
      if (flag)
      {
        flag = (simWorld.getAttribute(worldTileX1, worldTileZ1) & 64) != 0;
        if (flag)
        {
          int num3;
          if (dz == 0)
          {
            int worldCenterX = simWorld.coordWorldTileToWorldCenterX(worldTileX1);
            num3 = dx < 0 && posX <= worldCenterX || dx > 0 && posX >= worldCenterX ? simWorld.getAttribute(worldTileX1 + dx, worldTileZ1) : simWorld.getAttribute(worldTileX1 - dx, worldTileZ1);
          }
          else
          {
            int worldCenterZ = simWorld.coordWorldTileToWorldCenterZ(worldTileZ1);
            num3 = dz < 0 && posZ <= worldCenterZ || dz > 0 && posZ >= worldCenterZ ? simWorld.getAttribute(worldTileX1, worldTileZ1 + dz) : simWorld.getAttribute(worldTileX1, worldTileZ1 - dz);
          }
          flag = (num3 & 64) != 0;
        }
      }
      if (flag)
      {
        num1 = 14826;
        this.setAppearance(3);
      }
      else
        this.setAppearance(2);
    }
    int b = num1 * timeStep;
    int num4 = posX + MathExt.Fmul(a1, b);
    int num5 = posZ + MathExt.Fmul(a2, b);
    if (dx > 0 && num4 > walkDestXf || dx < 0 && num4 < walkDestXf)
      num4 = walkDestXf;
    if (dz > 0 && num5 > walkDestZf || dz < 0 && num5 < walkDestZf)
      num5 = walkDestZf;
    int facingDirFull = MapObject.getFacingDirFull(dx, dz);
    this.reposition(num4, this.getPosY(), num5, facingDirFull);
    if (!this.m_scene.isMapMode())
    {
      int worldTileX2 = simWorld.coordWorldToWorldTileX(num4);
      int worldTileZ2 = simWorld.coordWorldToWorldTileZ(num5);
      int attribute2 = simWorld.getAttribute(worldTileX2, worldTileZ2);
      if ((attribute1 & 32) != (attribute2 & 32))
      {
        bool flag1 = false;
        bool flag2 = false;
        if ((attribute1 & 32) != 0)
          flag2 = true;
        else if ((attribute2 & 16) != 0)
          flag1 = true;
        MapObject parentTypeNearest = this.m_scene.findObjectByParentTypeNearest(15, this.getPosX(), this.getPosZ());
        if (parentTypeNearest != null)
        {
          if (flag1 && !parentTypeNearest.getRuntimeFlag(64))
            parentTypeNearest.doorOpen(this);
          if (flag2 && parentTypeNearest.getRuntimeFlag(64))
            parentTypeNearest.doorClose();
        }
      }
    }
    this.updateAnim3D(timeStep);
    if (num4 != walkDestXf || num5 != walkDestZf)
      return;
    if (this.getRuntimeFlag(2))
      this.endSimAction();
    else if (!this.occupiedIsEmpty() && this.getType() != 0)
      this.failSimPhase(true);
    else if (this.m_simActionArg1 != null && (this.m_simActionArg1.getPosX() != this.m_checkPosXF || this.m_simActionArg1.getPosZ() != this.m_checkPosZF))
    {
      this.simWalkTo(this.m_simActionArg1, 0, 0);
    }
    else
    {
      bool flag1 = !this.setOccupied(this.m_simActionArg1);
      bool flag2 = this.m_walkStopShort || flag1;
      int[] walkPath = this.m_walkPath;
      int num3 = walkPath != null ? (walkPath.Length >> 1) - this.m_walkPathPoint : -1;
      if (num3 > (flag2 ? 2 : 1))
      {
        if (!this.getRuntimeFlag(50331648) && this.m_simActionArg1 != null && ((num3 & 3) == 0 || num3 < 4))
        {
          if (!flag1)
          {
            this.setOccupied((MapObject) null);
            this.setOccupied(this.m_simActionArg1);
          }
          this.simWalkTo(this.m_simActionArg1, 0, 0);
        }
        else
        {
          ++this.m_walkPathPoint;
          this.m_walkDestXF = walkPath[this.m_walkPathPoint << 1];
          this.m_walkDestZF = walkPath[(this.m_walkPathPoint << 1) + 1];
          this.checkDoorOpen();
        }
      }
      else if (flag1)
        this.beginSimPhase(10);
      else if (this.getRuntimeFlag(33554432))
        this.simWalkTo(this.m_simActionArg1, this.m_simActionArg2, this.m_simActionArg3);
      else
        this.endSimPhase();
    }
  }

  private void changeRoom(int oldRoomId, int newRoomId)
  {
    if (oldRoomId == newRoomId)
      return;
    SimWorld simWorld = this.getSimWorld();
    if (oldRoomId != -1)
      simWorld.getRoom(oldRoomId).removeSim();
    if (newRoomId != -1)
      simWorld.getRoom(newRoomId).addSim();
    this.updateTint();
  }

  public bool simCanWalkTo(MapObject @object, int xF, int zF)
  {
    SimWorld simWorld = this.getSimWorld();
    int posX = this.getPosX();
    int posZ = this.getPosZ();
    int num1 = xF;
    int num2 = zF;
    if (@object != null)
    {
      int closestInterestPoint = @object.getClosestInterestPoint(this.getPosX(), this.getPosZ(), false, this);
      if (closestInterestPoint == -1)
        return false;
      int[] tempInt10 = this.s_tempInt10;
      @object.getInterestPoint(tempInt10, closestInterestPoint);
      num1 = tempInt10[0];
      num2 = tempInt10[1];
    }
    if (simWorld.pathFind(posX, posZ, num1, num2, 0).Length > 0)
      return true;
    int num3 = midp.JMath.abs(posX - num1) + midp.JMath.abs(posZ - num2);
    return simWorld.isWorldPointWalkable(num1, num2) && num3 <= 2097152;
  }

  private void simWalkTo(MapObject @object, int xF, int zF)
  {
    SimWorld simWorld = this.getSimWorld();
    int posX = this.getPosX();
    int posZ = this.getPosZ();
    int x = xF;
    int z = zF;
    bool flag1 = false;
    bool flag2 = false;
    if (@object != null)
    {
      flag1 = false;
      flag2 = !this.setOccupied(@object);
      int index = this.m_occupiedIndex;
      if (index == -1)
      {
        index = @object.getClosestInterestPoint(this.getPosX(), this.getPosZ(), false, (MapObjectSim) null);
        if (index == -1)
        {
          this.failSimPhase(this.getId() != 0);
          return;
        }
      }
      int[] tempInt10 = this.s_tempInt10;
      @object.getInterestPoint(tempInt10, index);
      x = tempInt10[0];
      z = tempInt10[1];
      this.m_checkPosXF = @object.getPosX();
      this.m_checkPosZF = @object.getPosZ();
    }
    else if (this.getId() == 0)
    {
      MapObject walkTo = this.m_scene.getWalkTo();
      int worldTileX = simWorld.coordWorldToWorldTileX(x);
      int worldTileZ = simWorld.coordWorldToWorldTileZ(z);
      int worldCenterX = simWorld.coordWorldTileToWorldCenterX(worldTileX);
      int worldCenterZ = simWorld.coordWorldTileToWorldCenterZ(worldTileZ);
      walkTo.setPos(worldCenterX, 0, worldCenterZ);
      walkTo.unhide();
    }
    int worldCenterX1 = simWorld.coordWorldTileToWorldCenterX(simWorld.coordWorldToWorldTileX(x));
    int worldCenterZ1 = simWorld.coordWorldTileToWorldCenterZ(simWorld.coordWorldToWorldTileZ(z));
    if ((worldCenterX1 != this.getPosX() || worldCenterZ1 != this.getPosZ()) && this.m_posture != 0)
    {
      --this.m_simActionPhaseIndex;
      this.beginSimPhase(31);
    }
    else
    {
      if (this.m_scene.isHouseMode() && simWorld.getHouseId() != 0 && (this.getId() == 0 && this.m_simAction != 163) && (!this.getRuntimeFlag(32) && !this.getSimData().getSimCurRelStateFlags(0, 1)))
      {
        int worldTileX1 = simWorld.coordWorldToWorldTileX(this.getPosX());
        int worldTileZ1 = simWorld.coordWorldToWorldTileZ(this.getPosZ());
        int worldTileX2 = simWorld.coordWorldToWorldTileX(worldCenterX1);
        int worldTileZ2 = simWorld.coordWorldToWorldTileZ(worldCenterZ1);
        if ((simWorld.getAttribute(worldTileX1, worldTileZ1) & 16) == 0 && (simWorld.getAttribute(worldTileX2, worldTileZ2) & 16) != 0)
        {
          bool flag3 = this.m_simAction == 111 && this.m_simActionArg1 == null;
          this.m_queuedSimAction = this.m_simAction;
          this.m_queuedSimActionArg1 = this.m_simActionArg1;
          this.m_queuedSimActionArg2 = this.m_simActionArg2;
          this.m_queuedSimActionArg3 = this.m_simActionArg3;
          this.setRuntimeFlag(16);
          this.beginSimAction(163, this.m_scene.findFrontDoor());
          if (this.m_simAction != 163 || !flag3)
            return;
          this.m_scene.getWalkTo().unhide();
          return;
        }
      }
      this.unsetRuntimeFlag(32);
      int num1 = 0;
      bool flag4 = false;
      int flags;
      if (this.m_scene.isMapMode())
      {
        if (this.getRuntimeFlag(33554432))
        {
          flags = num1 | 6;
        }
        else
        {
          flag4 = this.hasCar() && midp.JMath.abs(posX - worldCenterX1) + midp.JMath.abs(posZ - worldCenterZ1) > 16777216;
          flags = !flag4 ? num1 | 8 : num1 | 2;
        }
      }
      else
      {
        flags = num1 | 16;
        MapObjectSim[] simObjects = this.m_scene.getSimObjects();
        if (simObjects.Length > 1)
        {
          simWorld.pathClearAvoidTiles();
          for (int index = 0; index < simObjects.Length; ++index)
          {
            MapObjectSim mapObjectSim = simObjects[index];
            if (mapObjectSim != this)
            {
              int worldTileX = simWorld.coordWorldToWorldTileX(mapObjectSim.getPosX());
              int worldTileZ = simWorld.coordWorldToWorldTileZ(mapObjectSim.getPosZ());
              simWorld.pathAddAvoidTile(worldTileX, worldTileZ);
            }
          }
          flags |= 1;
        }
      }
      bool runtimeFlag = this.getRuntimeFlag(33554432);
      this.unsetRuntimeFlag(50331648);
      int[] numArray1;
      if (flag4 && !runtimeFlag)
      {
        numArray1 = simWorld.pathFind(posX, posZ, worldCenterX1, worldCenterZ1, flags);
        int num2 = numArray1.Length >> 1;
        int num3 = -1;
        for (int index = 0; index < num2; ++index)
        {
          int worldTileX = simWorld.coordWorldToWorldTileX(numArray1[index << 1]);
          int worldTileZ = simWorld.coordWorldToWorldTileZ(numArray1[(index << 1) + 1]);
          if ((simWorld.getAttribute(worldTileX, worldTileZ) & 64) != 0)
          {
            num3 = index;
            break;
          }
        }
        if (num3 != -1)
        {
          int[] numArray2 = new int[num3 + 1 << 1];
          midp.JSystem.arraycopy((Array) numArray1, 0, (Array) numArray2, 0, numArray2.Length);
          numArray1 = numArray2;
          this.setRuntimeFlag(33554432);
        }
      }
      else
        numArray1 = simWorld.pathFind(posX, posZ, worldCenterX1, worldCenterZ1, flags);
      if (!flag1 && flag2 && numArray1.Length == 2)
        this.beginSimPhase(10);
      else if (flag1 && numArray1.Length == 2)
        this.endSimPhase();
      else if (numArray1.Length >= 2)
      {
        this.m_walkPath = numArray1;
        this.m_walkPathPoint = 0;
        this.m_walkStopShort = flag1;
        this.m_walkDestXF = numArray1[this.m_walkPathPoint << 1];
        this.m_walkDestZF = numArray1[(this.m_walkPathPoint << 1) + 1];
        this.checkDoorOpen();
        if (runtimeFlag)
          this.setRuntimeFlag(16777216);
        this.simStateTransition(3);
      }
      else
      {
        int num2 = midp.JMath.abs(posX - worldCenterX1) + midp.JMath.abs(posZ - worldCenterZ1);
        if (simWorld.isWorldPointWalkable(worldCenterX1, worldCenterZ1) && num2 <= 2097152)
        {
          if (num2 != 0)
          {
            this.m_walkPath = numArray1;
            this.m_walkPathPoint = 0;
            this.m_walkStopShort = flag1;
            this.m_walkDestXF = worldCenterX1;
            this.m_walkDestZF = worldCenterZ1;
            this.simStateTransition(3);
          }
          else
            this.endSimPhase();
        }
        else
          this.failSimPhase(false);
      }
    }
  }

  private void checkDoorOpen()
  {
    SimWorld simWorld = this.getSimWorld();
    int worldTileX1 = simWorld.coordWorldToWorldTileX(this.getPosX());
    int worldTileZ1 = simWorld.coordWorldToWorldTileZ(this.getPosZ());
    int attribute1 = simWorld.getAttribute(worldTileX1, worldTileZ1);
    int worldTileX2 = simWorld.coordWorldToWorldTileX(this.m_walkDestXF);
    int worldTileZ2 = simWorld.coordWorldToWorldTileZ(this.m_walkDestZF);
    int attribute2 = simWorld.getAttribute(worldTileX2, worldTileZ2);
    if ((attribute1 & 32) == 0 || (attribute1 & 16) != 0 || (attribute2 & 16) == 0)
      return;
    MapObject parentTypeNearest = this.m_scene.findObjectByParentTypeNearest(15, this.getPosX(), this.getPosZ());
    if (parentTypeNearest == null || parentTypeNearest.getRuntimeFlag(64))
      return;
    parentTypeNearest.doorOpen(this);
  }

  public int getFeedbackTime()
  {
    return this.m_feedbackTime;
  }

  private void simUpdateFeedback(int timeStep)
  {
    bool flag1 = this.isAnimating3D();
    this.updateAnim3D(timeStep);
    AnimPlayer3D animPlayer3D = this.getModel(0).getAnimPlayer3D();
    this.checkOneShotFeedback();
    bool flag2;
    if (this.m_feedbackLoop)
    {
      if (this.m_feedbackRealTime)
      {
        flag2 = this.m_feedbackTime <= this.getSimData().getGameTimeAbs();
      }
      else
      {
        if (!this.m_scene.inMiniGame())
          this.m_feedbackTime -= timeStep;
        flag2 = this.m_feedbackTime <= 0;
      }
    }
    else
      flag2 = !animPlayer3D.isAnimating();
    if (this.m_simPhase == 53 && this.getSimActionArg1().coffeeMachineIsReady())
      this.endSimPhase();
    if (this.m_simAction == 9)
    {
      if (flag2 && flag1)
        this.m_scene.startCurtainIn();
      flag2 = false;
    }
    else if (this.m_simAction == 10)
    {
      if (flag2 && flag1 && !this.getRuntimeFlag(4194304))
      {
        this.setRuntimeFlag(4194304);
        SpywareManager.getInstance().trackEndGameDeath("bladder");
        this.m_scene.killPlayer(1212);
      }
      flag2 = false;
    }
    if (flag2)
    {
      this.m_feedbackSubAppearance = -1;
      this.m_feedbackTime = -1;
      this.m_feedbackLoop = true;
      this.endSimPhase();
    }
    else
    {
      if (this.getId() != 0 || this.m_simPhase != 21 || (this.m_simStateTime <= 4000 || !this.m_feedbackRealTime) || (this.m_feedbackTime - this.getSimData().getGameTimeAbs() <= 60 || !this.occupiedIsEmpty() || this.m_scene.isCurtainActive()))
        return;
      this.m_scene.startCurtainIn();
    }
  }

  private void checkOneShotFeedback()
  {
    AnimPlayer3D animPlayer3D = this.getModel(0).getAnimPlayer3D();
    switch (this.m_simAction)
    {
      case 82:
        if (this.m_subAppearance != 104 || animPlayer3D.getAnimTime() < 1450 || this.getRuntimeFlag(4194304))
          break;
        this.setRuntimeFlag(4194304);
        this.playSound(86);
        break;
      case 87:
        if (this.m_subAppearance != 68 || animPlayer3D.getAnimTime() < 1500 || (this.getRuntimeFlag(4194304) || this.getSimActionArg1Sim() == null) || this.getSimData().getSimCurRelStateFlags(this.getSimActionArg1Sim().getId(), 32768))
          break;
        this.setRuntimeFlag(4194304);
        this.getSimData().setSimCurRelStateFlags(this.getSimActionArg1Sim().getId(), 32768);
        this.m_scene.triggerEvent(2);
        break;
      case 97:
        if (this.m_subAppearance != 15 || animPlayer3D.getAnimTime() < 800 || this.getRuntimeFlag(4194304))
          break;
        this.setRuntimeFlag(4194304);
        this.playSound(66);
        break;
      case 98:
        if (this.m_subAppearance != 101 || animPlayer3D.getAnimTime() < 800 || this.getRuntimeFlag(4194304))
          break;
        this.setRuntimeFlag(4194304);
        int soundId = 84;
        if (this.getId() == 0 && this.m_engine.randPercent() < 25)
        {
          soundId = 85;
          this.getSimData().adjustMotiveLevel(3, -6553600);
        }
        this.playSound(soundId);
        break;
      case 158:
        if (this.m_subAppearance != 55 || animPlayer3D.getAnimTime() < 900 || this.getRuntimeFlag(4194304))
          break;
        this.setRuntimeFlag(4194304);
        this.playSound(71);
        break;
      case 162:
        if (this.m_subAppearance != 58 || animPlayer3D.getAnimTime() < 500 || this.getRuntimeFlag(4194304))
          break;
        this.setRuntimeFlag(4194304);
        this.playSound(69);
        break;
    }
  }

  private void simUpdateGetAttention(int timeStep)
  {
    this.updateAnim3D(timeStep);
    MapObjectSim simActionArg1Sim = this.getSimActionArg1Sim();
    if (this.m_simAction != 99 && midp.JMath.abs(simActionArg1Sim.getPosX() - this.getPosX()) + midp.JMath.abs(simActionArg1Sim.getPosZ() - this.getPosZ()) > 2097152)
      this.failSimPhase(false);
    else if (this.m_simStateTime > 4000)
    {
      this.failSimPhase(false);
    }
    else
    {
      if (simActionArg1Sim.isIdle())
        simActionArg1Sim.beginSimAction(2, (MapObject) this);
      if (!simActionArg1Sim.isListeningTo(this))
        return;
      this.endSimPhase();
    }
  }

  private void simUpdateGetOccupied(int timeStep)
  {
    this.updateAnim3D(timeStep);
    if (this.m_simStateTime > 4000)
    {
      this.failSimPhase(false);
    }
    else
    {
      if (!this.setOccupied(this.m_simActionArg1))
        return;
      this.beginSimPhase(1);
    }
  }

  private void simUpdateListen(int timeStep)
  {
    this.updateAnim3D(timeStep);
    MapObjectSim simActionArg1Sim = this.getSimActionArg1Sim();
    if (simActionArg1Sim == null || simActionArg1Sim.isIdle())
    {
      this.endSimPhase();
    }
    else
    {
      if (simActionArg1Sim == null || !simActionArg1Sim.getRuntimeFlag(1024))
        return;
      SimData simData = this.getSimData();
      if (simData.hasSimGotTrait(this.getId(), 12) != -1)
      {
        if (this.getRuntimeFlag(262144))
          return;
        simData.tryDiscoverTrait(this.getId(), 12);
        this.setRuntimeFlag(262144);
      }
      else
      {
        simActionArg1Sim.interrupt();
        this.clearConversation();
        int num = 0;
        if (simData.hasSimGotTrait(this.getId(), 13) != -1)
        {
          num = 34;
          simData.tryDiscoverTrait(this.getId(), 13);
          simData.adjustRelLevels(this.getId(), -1, -1);
        }
        this.beginSimAction(17, (MapObject) simActionArg1Sim, num, 0);
      }
    }
  }

  private void simUpdateHide(int timeStep)
  {
    if (this.m_simAction == 170)
      return;
    if (this.m_feedbackRealTime)
    {
      if (this.m_feedbackTime > this.getSimData().getGameTimeAbs())
        return;
      this.endSimPhase();
    }
    else
    {
      if (this.m_feedbackTime <= 0)
        return;
      this.m_feedbackTime -= timeStep;
      if (this.m_feedbackTime > 0)
        return;
      this.endSimPhase();
    }
  }

  public int getSimAction()
  {
    return this.m_simAction;
  }

  public int getSimPhase()
  {
    return this.m_simPhase;
  }

  public MapObject getSimActionArg1()
  {
    return this.m_simActionArg1;
  }

  public MapObjectSim getSimActionArg1Sim()
  {
    if (this.m_simActionArg1 == null)
      return (MapObjectSim) null;
    return !this.m_simActionArg1.getFlag(8192) ? (MapObjectSim) null : (MapObjectSim) this.m_simActionArg1;
  }

  public override bool isIdle()
  {
    return (this.getSimData().getActionFlags(this.m_simAction) & 4) != 0;
  }

  public bool isListeningTo(MapObjectSim sim)
  {
    return this.m_simState == 7 && this.getSimActionArg1Sim() == sim;
  }

  public bool isReady()
  {
    return this.isIdle() || this.m_simPhase == 9 || this.m_simPhase == 10 || this.m_simPhase == 1;
  }

  public bool isWorking()
  {
    return this.m_simPhase == 27;
  }

  public bool isSleeping()
  {
    if (this.m_simAction != 128 && this.m_simAction != (int) sbyte.MaxValue && this.m_simAction != 126)
      return false;
    return this.m_posture == 6 || this.m_posture == 5;
  }

  public void queueSimAction(int action, MapObject arg1, int arg2, int arg3)
  {
    if (this.isReady())
      this.beginSimAction(action, arg1, arg2, arg3);
    else
      this.setQueueAction(action, arg1, arg2, arg3);
  }

  public void setQueueAction(int action, MapObject arg1, int arg2, int arg3)
  {
    this.m_queuedSimAction = action;
    this.m_queuedSimActionArg1 = arg1;
    this.m_queuedSimActionArg2 = arg2;
    this.m_queuedSimActionArg3 = arg3;
  }

  public int getQueuedAction()
  {
    return this.m_queuedSimAction;
  }

  public MapObject getQueuedActionArg1()
  {
    return this.m_queuedSimActionArg1;
  }

  public void beginSimAction(int action, MapObject arg1)
  {
    this.beginSimAction(action, arg1, 0, 0);
  }

  public void beginSimAction(int action, MapObject arg1, int arg2, int arg3)
  {
    SimData simData = this.getSimData();
    if (this.getId() == 0 && (simData.getActionFlags(action) & 1) != 0)
      SpywareManager.getInstance().trackAction(action);
    if (this.m_simPhase != 0)
      this.endSimPhase(true);
    this.unsetRuntimeFlag(262146);
    if (action == 124 && this.m_appearance == 0 && this.m_engine.randPercent() < 50)
      action = 125;
    this.m_simAction = action;
    this.m_simActionArg1 = arg1;
    this.m_simActionArg2 = arg2;
    this.m_simActionArg3 = arg3;
    if (arg1 != null || action == 111)
      this.setOccupied(arg1);
    MapObjectSim simActionArg1Sim = this.getSimActionArg1Sim();
    if (simActionArg1Sim != null && (simData.getActionFlags(action) & 2) != 0)
      this.setConversation(simActionArg1Sim);
    int actionPhase = simData.getActionPhase(action, 0);
    this.m_simActionPhaseIndex = 0;
    this.beginSimPhase(actionPhase);
  }

  public void playerAction(MapObject arg1)
  {
    if (arg1 == this || (this.m_needFlags & 64) == 0)
      return;
    MapObjectSim simActionArg1Sim = this.m_scene.getPlayerSim().getSimActionArg1Sim();
    if (this.m_conversationSim != 0 && (simActionArg1Sim == null || this.m_conversationSim != simActionArg1Sim.getId()))
      return;
    this.clearConversation();
  }

  public bool setOccupied(MapObject target)
  {
    AppEngine.ASSERT(target != this, "attempting to get occupied flag on self");
    if (target == this.m_occupiedObject)
      return true;
    if (this.m_occupiedObject != null)
    {
      this.m_occupiedObject.occupiedRelease(this.m_occupiedIndex);
      this.m_occupiedObject = (MapObject) null;
      this.m_occupiedIndex = -1;
    }
    if (target == null)
      return true;
    if (target.occupiedIsAnyAvailable())
    {
      int index;
      if (target.getParentType() == 15 && target.getRuntimeFlag(1048576))
      {
        SimWorld simWorld = this.getSimWorld();
        int worldTileX = simWorld.coordWorldToWorldTileX(this.getPosX());
        int worldTileZ = simWorld.coordWorldToWorldTileZ(this.getPosZ());
        index = (simWorld.getAttribute(worldTileX, worldTileZ) & 16) == 0 ? 1 : 0;
      }
      else
        index = target.getClosestInterestPoint(this.getPosX(), this.getPosZ(), true, this);
      if (index != -1 && target.occupiedCapture(index, this))
      {
        this.m_occupiedObject = target;
        this.m_occupiedIndex = index;
        return true;
      }
    }
    return false;
  }

  public MapObject getOccupiedObject()
  {
    return this.m_occupiedObject;
  }

  private void endSimAction()
  {
    bool runtimeFlag = this.getRuntimeFlag(4);
    SimData simData = this.getSimData();
    this.unsetRuntimeFlag(12);
    int simAction = this.m_simAction;
    MapObject simActionArg1 = this.m_simActionArg1;
    MapObjectSim simActionArg1Sim = this.getSimActionArg1Sim();
    bool flag = this.getId() == 0;
    this.beginSimAction(0, (MapObject) null);
    int actionFlags = simData.getActionFlags(simAction);
    if (!runtimeFlag && simActionArg1Sim != null && (actionFlags & 2) != 0)
    {
      this.setOccupied((MapObject) null);
      simActionArg1Sim.setOccupied((MapObject) null);
      if (simActionArg1Sim.respondToAction(simAction, this))
        this.clearConversation();
      if (flag)
      {
        int id = simActionArg1Sim.getId();
        if (simAction == 97)
        {
          simData.dreamCompleteEvent(18);
          if (simData.getAchievements(64))
            this.m_engine.getScene().awardAchievment(7);
          simData.setSimCurRelStateFlags(id, 32);
          simData.setSimCurRelStateFlags(id, 2048);
        }
        else if (simAction == 110)
          simData.setSimCurRelStateFlags(id, 256);
      }
    }
    else if (!runtimeFlag)
    {
      switch (simAction)
      {
        case 4:
          if (this.m_engine.randPercent() < 5)
          {
            this.beginSimAction(10, (MapObject) null);
            return;
          }
          break;
        case 112:
          this.m_scene.gotoMap(true);
          break;
        case 116:
        case 118:
          this.m_scene.increaseSkill(3);
          break;
        case 126:
        case (int) sbyte.MaxValue:
        case 128:
          this.m_needFlags &= -9;
          break;
        case 153:
          this.m_scene.showQuitJob();
          break;
        case 162:
          if (!flag)
          {
            this.m_simStateTime = 0;
            this.m_scene.showDoorKnock(this.getId());
            break;
          }
          break;
        case 165:
        case 166:
        case 171:
          this.m_scene.gotoMapForObject(simActionArg1);
          break;
        case 169:
          simData.dreamCompleteEvent(20);
          simData.adjustMotiveLevel(0, 2621440);
          break;
      }
    }
    if (simAction == 163)
    {
      this.unsetRuntimeFlag(16);
      if (runtimeFlag)
      {
        this.m_queuedSimAction = -1;
        this.m_queuedSimActionArg1 = (MapObject) null;
      }
      else
        this.setRuntimeFlag(32);
    }
    if (simActionArg1 != null && simActionArg1Sim == null && !runtimeFlag)
    {
      simActionArg1.respondToAction(simAction, this);
      if (flag)
        simData.setQuickLinkVisited(simActionArg1.getType());
    }
    if (this.m_queuedSimAction == -1 || !this.isIdle())
      return;
    int queuedSimAction = this.m_queuedSimAction;
    MapObject queuedSimActionArg1 = this.m_queuedSimActionArg1;
    int queuedSimActionArg2 = this.m_queuedSimActionArg2;
    int queuedSimActionArg3 = this.m_queuedSimActionArg3;
    this.m_queuedSimAction = -1;
    this.m_queuedSimActionArg1 = (MapObject) null;
    this.beginSimAction(queuedSimAction, queuedSimActionArg1, queuedSimActionArg2, queuedSimActionArg3);
  }

  public override bool respondToAction(int action, MapObjectSim fromSim)
  {
    SimData simData = this.getSimData();
    int id1 = fromSim.getId();
    int id2 = this.getId();
    int[] tempInt10 = this.s_tempInt10;
    simData.relationshipAction(tempInt10, id1, id2, action);
    int num = tempInt10[0];
    int action1 = tempInt10[1];
    int animId = tempInt10[2];
    if ((num & 64) != 0)
      this.m_scene.advertiseEvent(29, fromSim, (MapObject) this);
    if (action == 108 || action == 103)
    {
      this.beginSimAction(0, (MapObject) null);
      this.setNeedFlag(512);
    }
    else if (action1 != -1)
    {
      if ((simData.getActionFlags(action1) & 2) == 0 && action1 != 111)
        fromSim = (MapObjectSim) null;
      if (id1 == 0)
      {
        switch (action1)
        {
          case 16:
            simData.dreamCompleteEvent(14);
            simData.setSimCurRelStateFlags(id2, 8192);
            break;
          case 86:
            simData.setSimCurRelStateFlags(id2, 65536);
            break;
        }
      }
      this.beginSimAction(action1, (MapObject) fromSim, num, 0);
      if (animId != -1)
        this.m_scene.createEffectAnim(this.getPosX(), 4587520, this.getPosZ(), animId);
    }
    return (num & 32) != 0;
  }

  private void beginSimPhase(int phase)
  {
    SceneGame scene = this.m_scene;
    SimData simData = this.getSimData();
    this.m_simPhase = phase;
    int simAction = this.m_simAction;
    MapObject simActionArg1 = this.m_simActionArg1;
    MapObjectSim simActionArg1Sim = this.getSimActionArg1Sim();
    int simActionArg2 = this.m_simActionArg2;
    int simActionArg3 = this.m_simActionArg3;
    bool condition = this.getId() == 0;
    if (condition && simActionArg1Sim != null)
      simData.setLastNPC(simActionArg1Sim.getId());
    if (simActionArg1 != null && simActionArg1Sim == null && phase != 1)
    {
      simActionArg1.setRuntimeFlag(2048, this.getRuntimeFlag(2048));
      simActionArg1.setRuntimeFlag(4096, this.getRuntimeFlag(4096));
    }
    bool flag = false;
    switch (phase)
    {
      case 0:
        if (this.m_posture == 9 || this.m_posture == 11 || (this.m_posture == 13 || this.m_posture == 12) || (this.m_posture == 14 || this.m_posture == 8))
        {
          --this.m_simActionPhaseIndex;
          this.beginSimPhase(31);
          break;
        }
        if (this.m_posture == 4)
        {
          --this.m_simActionPhaseIndex;
          this.beginSimPhase(34);
          break;
        }
        this.simStateTransition(1);
        break;
      case 1:
        this.simWalkTo(simActionArg1, simActionArg2, simActionArg3);
        break;
      case 2:
      case 3:
        if (simActionArg1 != null)
          this.setFacingObject(simActionArg1);
        else
          this.setFacingDir(simActionArg2 - this.getPosX(), simActionArg3 - this.getPosZ());
        if (phase == 3)
          this.setFacingDir(this.getFacingDir() + 2 & 3);
        this.endSimPhase();
        break;
      case 4:
      case 5:
        this.setFacingDir(simActionArg1.getFacingDir());
        if (phase == 5)
          this.setFacingDir(this.getFacingDir() + 2 & 3);
        this.endSimPhase();
        break;
      case 6:
      case 7:
      case 8:
        this.performPhaseFeedback(simAction, phase);
        flag = true;
        break;
      case 9:
        this.simStateTransition(5);
        break;
      case 10:
        this.simStateTransition(6);
        break;
      case 11:
        this.getSimActionArg1Sim().interrupt();
        this.endSimPhase();
        break;
      case 12:
        this.simStateTransition(7);
        break;
      case 13:
        AppEngine.ASSERT(condition, "NPC cooking!");
        if (simData.startRecipe(simActionArg2))
        {
          scene.beginMiniGame(0, simActionArg1);
          AppEngine.ASSERT(simActionArg1.getParentType() == 27, "cooking at non-stove!");
          simActionArg1.stoveStart();
          this.simFeedback(54, 1000, -1, false, false);
          break;
        }
        this.failSimPhase(false);
        break;
      case 14:
        AppEngine.ASSERT(condition, "NPC fishing!");
        if (simData.startFishing())
        {
          if (simActionArg1.getType() == 8)
            this.setFacingDir(0);
          else if (simActionArg1.getType() == 9)
            this.setFacingDir(1);
          else if (simActionArg1.getType() == 7)
            this.setFacingDir(2);
          else if (simActionArg1.getType() == 6)
            this.setFacingDir(3);
          scene.beginMiniGame(1, simActionArg1);
          this.simFeedback(62, 1000, -1, false, false);
          break;
        }
        this.failSimPhase(false);
        break;
      case 15:
        AppEngine.ASSERT(condition, "NPC repairing!");
        if (simData.startRepairing())
        {
          scene.beginMiniGame(2, simActionArg1);
          this.simFeedback(54, 1000, -1, false, false);
          break;
        }
        this.failSimPhase(false);
        break;
      case 17:
        int timer = 5000;
        if (condition)
        {
          int adjust = 458752;
          if (simAction == 132)
            adjust = this.getSimWorld().getRecipeReplenishes(simActionArg2);
          simData.setMotiveAdjust(0, adjust);
        }
        if (simActionArg1.getParentType() == 17)
          timer = 3500;
        int subAppearance = 54;
        if (this.m_posture == 1)
          subAppearance = 34;
        this.simFeedback(subAppearance, timer, -1, false, false);
        flag = true;
        this.playSound(70);
        break;
      case 18:
        switch (simActionArg1.getParentType())
        {
          case 4:
            if (condition && !this.getRuntimeFlag(1024))
              simData.setMotiveAdjust(3, 458752);
            simActionArg1.basinStart();
            this.simFeedback(99, 2400, -1, false, false);
            break;
          case 5:
            simActionArg1.bathToFill();
            if (condition)
              this.getSimData().setMotiveAdjust(3, 655360);
            this.simFeedback(70, 8000, -1, false, false);
            flag = true;
            break;
          case 25:
            if (condition)
              simData.setMotiveAdjust(3, 655360);
            simActionArg1.showerClose();
            this.simFeedback(97, 5000, -1, false, false);
            flag = true;
            break;
          default:
            AppEngine.ASSERT(false, "what are we washing at?!");
            break;
        }
        break;
      case 19:
        if (condition)
          simData.setMotiveAdjust(2, 3276800);
        this.simFeedback(simAction == 124 ? 91 : 45, 2000, -1, false, false);
        break;
      case 20:
      case 21:
        this.performPhaseSleep(phase);
        flag = true;
        break;
      case 22:
        simActionArg1.turnOn();
        this.endSimPhase();
        flag = true;
        break;
      case 23:
        simActionArg1.turnOff();
        this.endSimPhase();
        flag = true;
        break;
      case 24:
        if (this.m_simAction == 137)
          simActionArg1.tvSwitchToAction();
        else if (this.m_simAction == 136)
          simActionArg1.tvSwitchToComedy();
        MapObject sitObjectTv = scene.findSitObjectTV(this, simActionArg1);
        if (sitObjectTv != null)
        {
          int action = 155;
          if (sitObjectTv.getParentType() == 10)
            action = 156;
          this.beginSimAction(action, sitObjectTv, 0, 0);
        }
        else
          this.beginSimAction(111, simActionArg1, 0, 0);
        flag = true;
        break;
      case 25:
        MapObject sitObject = scene.findSitObject(this, simAction);
        if (sitObject != null)
        {
          this.m_simActionArg1 = sitObject;
          this.endSimPhase();
          break;
        }
        this.failSimPhase(false);
        break;
      case 26:
        if (condition)
          simData.setMotiveAdjust(5, 196608);
        this.simFeedback(37, 10000, -1, false, false);
        break;
      case 27:
        if (condition)
        {
          this.simStateTransition(8);
          scene.startCurtainIn();
          break;
        }
        if (scene.getSimObjects().Length == 2 && !simData.isWelcome())
          scene.kickPlayer(1166, simData.getSimName(this.getId()));
        this.simStateTransition(9);
        break;
      case 28:
        scene.finishCallAction(simAction, simActionArg2);
        this.endSimPhase();
        break;
      case 29:
        AppEngine.ASSERT(condition, "NPC looking for work!");
        int careerFromObject = simData.getJobSearchCareerFromObject(simActionArg1);
        int jobSearchLevel = simData.getJobSearchLevel(careerFromObject);
        scene.showJobOffer(careerFromObject, jobSearchLevel, true);
        this.endSimPhase();
        break;
      case 30:
        scene.kickPlayer(1165, 1164);
        this.endSimPhase();
        break;
      case 31:
      case 32:
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
        this.performPhasePosture(phase);
        break;
      case 45:
        if (condition)
        {
          this.performPhaseCheckMoney();
          break;
        }
        this.endSimPhase();
        break;
      case 46:
        if (condition)
        {
          this.performPhaseCheckLock();
          break;
        }
        this.endSimPhase();
        break;
      case 47:
        if (condition)
        {
          this.performPhaseCheckHappy();
          break;
        }
        this.endSimPhase();
        break;
      case 48:
        scene.openShop(simActionArg1);
        this.endSimPhase();
        break;
      case 49:
        this.performPhasePlant();
        break;
      case 50:
        this.performPhaseTend();
        break;
      case 51:
        simActionArg1.plantHarvest();
        this.endSimPhase();
        break;
      case 52:
        simActionArg1.plantUproot();
        this.endSimPhase();
        break;
      case 53:
        AppEngine.ASSERT(simActionArg1.getParentType() == 11, "drinking at non-coffee machine");
        simActionArg1.coffeeMachineActivate();
        this.simFeedback(1, 60000, -1, false, false);
        flag = true;
        break;
      case 54:
        if (condition)
        {
          simData.setMotiveAdjust(2, -327680);
          simData.setMotiveAdjust(1, 655360);
        }
        this.simFeedback(84, -1, -1, false, false);
        break;
      case 55:
        if (condition)
          simData.setMotiveAdjust(5, 393216);
        this.m_simActionArg1.turnOn();
        this.simFeedback(89, 15000, -1, false, false);
        break;
    }
    if (this.getSimWorld().getHouseId() == 0)
      flag = false;
    if (condition && flag && (simData.getActionFlags(simAction) & 2097152) != 0)
      scene.advertiseEvent(26, this, this.m_simActionArg1);
    if (!this.getRuntimeFlag(2))
      return;
    this.failSimPhase(true);
  }

  private void performPhaseFeedback(int action, int phase)
  {
    SimData simData = this.getSimData();
    if (action == 162 && this.m_simActionArg1.getRuntimeFlag(64))
    {
      this.endSimPhase();
    }
    else
    {
      int subAppearance = -1;
      int floatAnim = -1;
      if (phase == 6)
        floatAnim = 15;
      if (phase == 6 || phase == 7 || phase == 8)
      {
        float x = (float) this.getPosX() / 65536f;
        float y = (float) this.getPosY() / 65536f;
        float z = (float) this.getPosZ() / 65536f;
        this.playSimlishSound(action, x, y, z);
      }
      bool animateFloater = false;
      if (action != 147 && action != 148 && (action != 116 && this.m_simActionArg2 != 0))
      {
        floatAnim = SimData.responseToFeedbackAnim(this.m_simActionArg2);
        animateFloater = true;
      }
      int timer = phase == 8 || phase == 6 ? -1 : 2000;
      if (action == 21)
        timer = 5000;
      this.simFeedback(subAppearance, timer, floatAnim, animateFloater, false);
      if (this.getId() == 0)
      {
        if (action == 159)
          simData.setMotiveAdjust(3, -1310720);
        else if (action == 18 || action == 19 || action == 20)
          simData.setMotiveAdjust(5, 196608);
        else if (action == 21)
          simData.setMotiveAdjust(5, 196608);
      }
      if (action == 158)
      {
        this.m_simActionArg1.trashCanKick(this);
        if (this.getId() != 0)
          return;
        simData.dreamCompleteEvent(36);
        simData.setHouseCurRelStateFlags(this.getSimWorld().getHouseId(), 16);
        simData.setHouseCurRelStateFlags(this.getSimWorld().getHouseId(), 4096);
      }
      else
      {
        if (action != 4)
          return;
        if (this.getId() == 0)
          simData.adjustMotiveLevel(3, -6553600);
        if (this.m_scene.isObjectAt(3, this.getPosX(), this.getPosZ()))
          return;
        int id = -1;
        if (this.getSimWorld().getHouseId() == 0)
          id = this.getSimWorld().objectBuy(12, this.getPosX(), this.getPosZ(), this.getFacingDir());
        this.m_scene.createObject(12, this.getPosX(), this.getPosY(), this.getPosZ(), this.getFacingDir(), id);
      }
    }
  }

  private void playSimlishSound(int action, float x, float y, float z)
  {
    AppEngine canvas = AppEngine.getCanvas();
    bool flag = this.getSimData().isSimMale(this.getId());
    int simMacromapColor = this.getSimData().getSimMacromapColor(this.getId());
    int theme = -1;
    switch (action)
    {
      case 13:
        theme = canvas.rand(0, 99) >= 60 ? canvas.rand(0, 6) : 1;
        break;
      case 16:
      case 22:
        theme = 5;
        break;
      case 23:
      case 62:
      case 63:
      case 94:
      case 95:
      case 103:
      case 107:
        theme = 0;
        break;
      case 24:
      case 96:
      case 100:
      case 101:
        theme = 6;
        break;
      case 30:
      case 31:
      case 74:
      case 75:
      case 76:
      case 77:
      case 80:
      case 86:
      case 89:
      case 92:
      case 113:
        theme = 3;
        break;
      case 64:
      case 65:
      case 66:
      case 69:
      case 70:
      case 71:
      case 72:
      case 73:
      case 99:
      case 104:
      case 106:
      case 108:
      case 147:
      case 148:
        theme = 1;
        break;
      case 67:
      case 79:
      case 83:
      case 84:
      case 91:
      case 93:
      case 102:
        theme = 2;
        break;
      case 78:
        theme = 4;
        break;
    }
    if (theme == -1)
      return;
    int voice = simMacromapColor % 2;
    int sex = flag ? 0 : 1;
    int simlish = canvas.getSceneGame().getSimlish(theme, voice, sex);
    if (simlish == -1)
      return;
    canvas.getSoundManager().playEventAt(simlish, x, y, z);
  }

  private void performPhaseSleep(int phase)
  {
    SimData simData = this.getSimData();
    int gameTimeAbs = simData.getGameTimeAbs();
    bool longSleep = this.m_simAction == (int) sbyte.MaxValue;
    int a = simData.getWakeupTime(this.getId(), longSleep);
    if (phase == 20)
      a = midp.JMath.min(a, gameTimeAbs + 120);
    int num = a - gameTimeAbs;
    if (this.getId() == 0)
    {
      simData.setFastforward(true);
      simData.setMotiveAdjust(1, 65536);
    }
    int timer = gameTimeAbs + num;
    this.simFeedback(this.m_postureObject == null || this.m_postureObject.getParentType() != 13 ? (this.getRuntimeFlag(524288) ? 25 : 26) : 81, timer, -1, false, true);
  }

  private void performPhasePosture(int phase)
  {
    int num1 = this.m_simActionArg1 == null ? -1 : this.m_simActionArg1.getParentType();
    if (phase == 32)
    {
      AppEngine.ASSERT(this.m_simActionArg1 != null, "can't auto-sit without a chair");
      phase = 34;
      switch (num1)
      {
        case 6:
          phase = 33;
          break;
        case 13:
          this.setFacingDir(this.getFacingDir() + 2 & 3);
          break;
      }
    }
    int num2 = phase == 31 ? 0 : (phase == 33 ? 3 : (phase == 34 ? 1 : (phase == 35 ? 2 : (phase == 36 ? 4 : (phase == 39 ? 8 : (phase == 37 ? (num1 == 13 ? 5 : 6) : (phase == 38 ? 7 : (phase == 40 ? 9 : (phase == 42 ? 11 : (phase == 43 ? 13 : (phase == 44 ? 14 : 10)))))))))));
    if (this.m_posture == num2)
    {
      this.endSimPhase();
    }
    else
    {
      this.m_targetPosture = num2;
      this.simStateTransition(2);
    }
  }

  private void performPhaseCheckMoney()
  {
    if (this.m_scene.isHouseMode() && this.getSimWorld().getHouseId() != 0 && this.m_simAction == 131)
    {
      this.endSimPhase();
    }
    else
    {
      SimData simData = this.getSimData();
      int costForAction = simData.getCostForAction(this.m_simAction);
      if (simData.getMoney() >= costForAction)
      {
        simData.adjustMoney(-costForAction);
        this.m_scene.createEffectMoney(this.getPosX(), this.getPosZ(), -costForAction);
        this.endSimPhase();
      }
      else
        this.failSimPhase(false);
    }
  }

  private void performPhaseCheckLock()
  {
    SimData simData = this.getSimData();
    bool flag = true;
    if (this.m_scene.getSimObjects().Length > 1)
      flag = false;
    else if (simData.getSimCareer(0) == 4)
      flag = false;
    else if (simData.isWelcome())
      flag = false;
    if (flag)
      this.failSimPhase(false);
    else
      this.endSimPhase();
  }

  private void performPhaseCheckHappy()
  {
    SimData simData = this.getSimData();
    if (simData.buffGetActiveSlot(12) != -1 || simData.buffGetActiveSlot(11) != -1)
      this.failSimPhase(false);
    else
      this.endSimPhase();
  }

  private void performPhasePlant()
  {
    SimData simData = this.getSimData();
    int simActionArg2 = this.m_simActionArg2;
    if (simData.getInventoryCount(simActionArg2) > 0)
    {
      simData.adjustInventory(simActionArg2, -1);
      this.m_simActionArg1.plantSeed(simActionArg2);
      this.endSimPhase();
    }
    else
      this.failSimPhase(false);
  }

  private void performPhaseTend()
  {
    SimData simData = this.getSimData();
    if (simData.getInventoryCount(2) > 0 && simData.getInventoryCount(3) > 0)
    {
      simData.adjustInventory(3, -1);
      this.m_simActionArg1.plantGrow();
      this.endSimPhase();
    }
    else
      this.failSimPhase(false);
  }

  public void endSimPhase()
  {
    this.endSimPhase(false);
  }

  private void endSimPhase(bool cleanupOnly)
  {
    SimData simData = this.getSimData();
    int houseId = this.getSimWorld().getHouseId();
    int actionPhaseCount = simData.getActionPhaseCount(this.m_simAction);
    bool flag = this.getId() == 0;
    MapObject simActionArg1 = this.m_simActionArg1;
    switch (this.m_simPhase)
    {
      case 1:
        if (flag && this.m_scene.getWalkTo() != null)
        {
          this.m_scene.getWalkTo().hide();
          break;
        }
        break;
      case 6:
      case 7:
      case 8:
        this.endFeedback();
        if (flag)
        {
          if (this.m_simAction == 159)
          {
            simData.setMotiveAdjust(3, 0);
            break;
          }
          if (this.m_simAction == 18 || this.m_simAction == 19 || (this.m_simAction == 20 || this.m_simAction == 21))
          {
            simData.setMotiveAdjust(5, 0);
            break;
          }
          break;
        }
        break;
      case 13:
        AppEngine.ASSERT(simActionArg1.getParentType() == 27, "cooking at non-stove!");
        simActionArg1.stoveEnd();
        break;
      case 17:
        if (flag)
        {
          simData.setMotiveAdjust(0, 0);
          break;
        }
        break;
      case 18:
        if (flag)
          simData.setMotiveAdjust(3, 0);
        if (simActionArg1 != null)
        {
          switch (simActionArg1.getParentType())
          {
            case 4:
              simActionArg1.basinEnd();
              break;
            case 5:
              simActionArg1.bathToEmpty();
              break;
            case 25:
              if (flag && houseId != 0)
              {
                simData.dreamCompleteEvent(38);
                simData.setHouseCurRelStateFlags(houseId, 8);
                break;
              }
              break;
          }
        }
        else
          break;
        break;
      case 19:
        if (flag)
        {
          simData.setMotiveAdjust(2, 0);
          if (houseId != 0)
          {
            simData.dreamCompleteEvent(39);
            simData.setHouseCurRelStateFlags(houseId, 4);
            break;
          }
          break;
        }
        break;
      case 20:
      case 21:
        if (flag)
        {
          simData.setMotiveAdjust(1, 0);
          simData.setFastforward(false);
          if (this.m_simPhase == 21 && houseId != 0)
          {
            simData.dreamCompleteEvent(37);
            int relStateFlags = simActionArg1.bedGetRelStateFlags();
            simData.setHouseCurRelStateFlags(houseId, relStateFlags);
          }
        }
        this.recheckBuffEffects();
        break;
      case 26:
        if (flag)
        {
          simData.setMotiveAdjust(5, 0);
          break;
        }
        break;
      case 53:
        if (simActionArg1 != null)
        {
          simActionArg1.coffeeMachineDeactivate();
          break;
        }
        break;
      case 54:
        if (flag)
        {
          simData.setMotiveAdjust(2, 0);
          simData.setMotiveAdjust(1, 0);
          break;
        }
        break;
      case 55:
        if (flag)
          simData.setMotiveAdjust(5, 0);
        simActionArg1.turnOff();
        break;
    }
    this.m_simPhase = 0;
    if (cleanupOnly)
      return;
    if (this.m_simActionPhaseIndex < actionPhaseCount - 1)
    {
      ++this.m_simActionPhaseIndex;
      this.beginSimPhase(simData.getActionPhase(this.m_simAction, this.m_simActionPhaseIndex));
    }
    else
      this.endSimAction();
  }

  public void interrupt()
  {
    this.setRuntimeFlag(2);
    int actionFlags = this.getSimData().getActionFlags(this.m_simAction);
    if ((actionFlags & 2) != 0 && (actionFlags & 1048576) == 0 && (this.getSimActionArg1Sim() != null && !this.getSimActionArg1Sim().getRuntimeFlag(2)))
      this.getSimActionArg1Sim().interrupt();
    this.failSimPhase(true);
  }

  private void failSimPhase(bool friendly)
  {
    this.setRuntimeFlag(4);
    int action = -1;
    int messageStringId = -1;
    int titleStringId = 428;
    switch (this.m_simPhase)
    {
      case 1:
        if (!friendly || this.getId() != 0)
        {
          messageStringId = 434;
          break;
        }
        break;
      case 6:
      case 7:
      case 8:
      case 9:
      case 10:
      case 12:
      case 17:
      case 22:
      case 23:
      case 24:
      case 26:
      case 29:
      case 53:
      case 54:
        this.endSimPhase(true);
        this.endSimAction();
        break;
      case 13:
        messageStringId = 1178;
        titleStringId = this.getSimWorld().getRecipeDesc(this.m_simActionArg2);
        break;
      case 14:
        messageStringId = 505;
        break;
      case 15:
        messageStringId = 439;
        break;
      case 16:
        messageStringId = 437;
        break;
      case 18:
      case 19:
      case 20:
      case 21:
      case 55:
        this.endSimPhase();
        break;
      case 25:
        messageStringId = this.m_simAction != 157 ? 458 : 474;
        break;
      case 45:
        messageStringId = 456;
        break;
      case 46:
        messageStringId = 482;
        break;
      case 47:
        messageStringId = 429;
        action = 8;
        if (this.m_engine.randPercent() < 50)
        {
          action = 17;
          break;
        }
        break;
      case 49:
        messageStringId = 441;
        break;
      case 50:
        messageStringId = 444;
        break;
    }
    if (this.getId() == 0 && this.m_scene.getWalkTo() != null)
      this.m_scene.getWalkTo().hide();
    if (messageStringId == -1)
      return;
    if (!friendly && this.getId() == 0)
      this.m_scene.showMessageBox(messageStringId, titleStringId);
    if (action != -1)
      this.beginSimAction(action, (MapObject) null);
    else
      this.endSimAction();
  }

  private void checkNeeds()
  {
    AppEngine engine = this.m_engine;
    int needFlags1 = this.m_needFlags;
    if ((needFlags1 & 514) != 0)
    {
      this.beginSimAction(170, this.m_scene.findRandomObjectByType(4));
    }
    else
    {
      if (this.m_scene.getContextMenuObject() == this || this.getType() == 0 && this.m_scene.getContextMenuObject() != null || this.m_lastConversationTimer == -1 && (this.m_needFlags & 64) != 0 && (this.getId() != 0 || engine.getAutonomityEnabled() && this.m_scene.isPlayerInactive()) && ((this.getId() == 0 || (this.m_needFlags & 8) == 0) && this.checkNeedChat()) || (needFlags1 & 188) == 0)
        return;
      int length = this.GENERIC_NEEDS.Length;
      int index1 = engine.rand(0, length - 1);
      if ((needFlags1 & 8) != 0)
      {
        int[] anArray = new int[length];
        for (int index2 = 0; index2 < length; ++index2)
          anArray[index2] = this.GENERIC_NEEDS[index2];
        index1 = AppEngine.indexOf(8, anArray);
      }
      for (int index2 = 0; index2 < length; ++index2)
      {
        int needFlags2 = this.GENERIC_NEEDS[index1];
        if (needFlags2 != 4 || this.getId() != 0 || this.getSimData().getMoney() >= 10)
        {
          if ((needFlags1 & needFlags2) != 0)
          {
            MapObject randomNeedObject = this.m_scene.findRandomNeedObject(needFlags2);
            if (randomNeedObject != null)
            {
              SimWorld simWorld = this.getSimWorld();
              int type = randomNeedObject.getType();
              this.beginSimAction((int) simWorld.getObjectActions(type)[0], randomNeedObject);
              this.m_needFlags &= ~simWorld.getObjectNeed(type);
              break;
            }
          }
          index1 = (index1 + 1) % length;
        }
      }
    }
  }

  private bool checkNeedChat()
  {
    AppEngine engine = this.m_engine;
    SimData simData = this.getSimData();
    MapObjectSim newSim1 = (MapObjectSim) null;
    if (this.m_conversationSim != -1)
    {
      newSim1 = this.m_scene.findSim(this.m_conversationSim);
      if (this.m_conversationSim == 0 && newSim1 != null && (newSim1.getSimActionArg1() == this || newSim1.getQueuedActionArg1() == this || this.m_scene.isObjectInQueue((MapObject) this)))
        return true;
      if (!this.checkNeedChatSim(newSim1))
        newSim1 = (MapObjectSim) null;
    }
    int id = this.getId();
    int houseId = this.getSimWorld().getHouseId();
    if (simData.getSimHome(id) != houseId && !simData.getSimCurRelStateFlags(id, 1) && (id != 0 || engine.getAutonomityEnabled()))
    {
      if ((this.m_needFlags & 1024) == 0)
      {
        MapObject frontDoor = this.m_scene.findFrontDoor();
        if (frontDoor != null)
        {
          this.beginSimAction(162, frontDoor);
          this.m_needFlags |= 1024;
          return true;
        }
      }
      else
      {
        if (id != 0)
        {
          if (this.m_simStateTime > 30000)
            this.m_needFlags |= 512;
        }
        else
          this.m_needFlags &= -1025;
        return true;
      }
    }
    else
      this.m_needFlags &= -1025;
    if (newSim1 == null)
    {
      MapObjectSim[] simObjects = this.m_scene.getSimObjects();
      int length = simObjects.Length;
      int index1 = engine.rand(0, length - 1);
      for (int index2 = 0; index2 < length; ++index2)
      {
        MapObjectSim newSim2 = simObjects[index1];
        index1 = (index1 + 1) % simObjects.Length;
        if (this.checkNeedChatSim(newSim2))
        {
          newSim1 = newSim2;
          break;
        }
      }
    }
    if (newSim1 == null)
      return false;
    int num = engine.randPercent();
    this.beginSimAction(num < 30 ? 66 : (num < 70 ? 94 : 78), (MapObject) newSim1);
    return true;
  }

  private bool checkNeedChatSim(MapObjectSim newSim)
  {
    if (newSim == this || newSim == null)
      return false;
    MapObject contextMenuObject = this.m_scene.getContextMenuObject();
    return newSim != contextMenuObject && (newSim.getId() != 0 || contextMenuObject == null) && (!newSim.isSleeping() && (newSim.m_conversationSim == -1 || newSim.m_conversationSim == this.getId())) && (!newSim.getRuntimeFlag(8) && (!newSim.getRuntimeFlag(1024) || this.getSimData().hasSimGotTrait(this.getId(), 12) != -1));
  }

  public void clearNeedFlags()
  {
    this.m_needFlags = 0;
  }

  public void setNeedFlag(int flag)
  {
    this.m_needFlags |= flag;
  }

  public void startBuff(int buff)
  {
    switch (buff)
    {
      case 4:
      case 5:
      case 7:
        this.setRuntimeFlag(4096);
        break;
      case 6:
        this.setRuntimeFlag(2048);
        break;
      case 9:
        this.setRuntimeFlag(1024);
        if (this.m_scene.isMapMode())
          break;
        Model modelCreate = this.getModelCreate(1);
        modelCreate.assembleObject(11);
        modelCreate.getAnimPlayer3D().startAnim(250, 20);
        break;
    }
  }

  public void endBuff(int buff)
  {
    switch (buff)
    {
      case 4:
      case 5:
      case 7:
        this.unsetRuntimeFlag(4096);
        break;
      case 6:
        this.unsetRuntimeFlag(2048);
        break;
      case 9:
        this.unsetRuntimeFlag(1024);
        if (this.m_scene.isMapMode())
          break;
        this.getModel(1)?.unload();
        break;
    }
  }

  private void recheckBuffEffects()
  {
    if (!this.getRuntimeFlag(1024))
      return;
    this.startBuff(9);
  }

  public void setConversation(MapObjectSim sim)
  {
    this.m_conversationSim = sim.getId();
    this.m_lastConversationTimer = -1;
    this.setNeedFlag(64);
    sim.m_conversationSim = this.getId();
    sim.m_lastConversationTimer = -1;
    sim.setNeedFlag(64);
  }

  private void clearConversation()
  {
    MapObjectSim sim = this.m_scene.findSim(this.m_conversationSim);
    if (sim != null)
    {
      sim.m_needFlags &= -65;
      sim.m_conversationSim = -1;
      sim.m_conversationTimer = 0;
      sim.m_lastConversationTimer = 0;
    }
    this.m_needFlags &= -65;
    this.m_conversationSim = -1;
    this.m_conversationTimer = 0;
    this.m_lastConversationTimer = 0;
  }

  private bool hasCar()
  {
    SimData simData = this.getSimData();
    SimWorld simWorld = this.getSimWorld();
    int simCareer = simData.getSimCareer(this.getId());
    if (simCareer != -1)
    {
      int simCareerLevel = simData.getSimCareerLevel(this.getId());
      if ((simData.getCareerLevelFlags(simCareer, simCareerLevel) & 1) != 0)
        return true;
    }
    if (this.getType() == 0)
    {
      int itemCount = simWorld.getItemCount();
      for (int index = 0; index < itemCount; ++index)
      {
        if ((simWorld.getItemFlags(index) & 2) != 0 && simData.getInventoryCount(index) != 0)
          return true;
      }
    }
    return simData.hasSimGotFlag(this.getId(), 1);
  }

  public void reloadCar()
  {
    if (!this.m_scene.isMapMode())
      return;
    this.getModelCreate(0).assembleMacromapSim(this.getId());
    int appearance = this.m_appearance;
    this.m_appearance = -1;
    this.setAppearance(appearance);
  }

  public void gotoSleep(MapObject bed)
  {
    AppEngine.ASSERT(bed != null, "can't sleep on null");
    AppEngine.ASSERT(this.setOccupied(bed), "couldn't get occupied flag for bed");
    int[] tempInt10 = this.s_tempInt10;
    bed.getInterestPoint(tempInt10, this.m_occupiedIndex);
    this.reposition(tempInt10[0], bed.getPosY(), tempInt10[1], this.getFacingDir());
    this.setFacingObject(bed);
    this.setFacingDir((this.getFacingDir() + 2) % 4);
    this.m_postureObject = bed;
    this.m_posture = 6;
    this.m_targetPosture = 6;
    if (bed.getParentType() == 13)
    {
      this.m_posture = 5;
      this.m_targetPosture = 5;
    }
    else
    {
      this.setRuntimeFlag(524288, (this.getFacingDir() + 4 - bed.getFacingDir() & 3) == 3);
      this.getRoom()?.removeSim();
    }
    if (this.getId() == 0)
      this.m_scene.snapCameraAndCursor(bed);
    this.beginSimAction(128, bed);
  }

  public bool isWithinTiles(int tileX, int tileZ, int width, int height)
  {
    SimWorld simWorld = this.getSimWorld();
    int worldTileX1 = simWorld.coordWorldToWorldTileX(this.getPosX());
    int worldTileZ1 = simWorld.coordWorldToWorldTileZ(this.getPosZ());
    if (worldTileX1 > tileX - width && worldTileX1 <= tileX && (worldTileZ1 > tileZ - height && worldTileZ1 <= tileZ))
      return true;
    if (this.m_simState == 3)
    {
      int worldTileX2 = simWorld.coordWorldToWorldTileX(this.m_walkDestXF);
      int worldTileZ2 = simWorld.coordWorldToWorldTileZ(this.m_walkDestZF);
      if (worldTileX2 > tileX - width && worldTileX2 <= tileX && (worldTileZ2 > tileZ - height && worldTileZ2 <= tileZ))
        return true;
    }
    return false;
  }

  public bool respondToEvent(int _event, MapObjectSim source, MapObject target)
  {
    SimData simData = this.getSimData();
    if (this.isSleeping() && _event != 27)
      return false;
    if (_event == 29)
    {
      AppEngine.ASSERT(target.getFlag(8192), "wtf: romancing a non-sim!");
      if (simData.getSimPartner(this.getId()) != target.getId())
        return false;
    }
    int[] tempInt10 = this.s_tempInt10;
    simData.relationshipAction(tempInt10, source.getId(), this.getId(), _event);
    int action = tempInt10[1];
    switch (action)
    {
      case -1:
        return false;
      case 24:
        if (!this.m_scene.isHouseMode())
        {
          action = 23;
          break;
        }
        break;
    }
    MapObject mapObject = (tempInt10[0] & 65536) != 0 ? target : (MapObject) source;
    this.interrupt();
    this.queueSimAction(action, mapObject, 0, 0);
    if (_event == 29 && source.getId() == 0)
      simData.dreamCompleteEvent(50);
    this.setRuntimeFlag(8);
    return true;
  }
}
