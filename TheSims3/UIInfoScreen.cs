// Decompiled with JetBrains decompiler
// Type: UIInfoScreen
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class UIInfoScreen : UIScrollable
{
  private const int STATE_IDLE = 0;
  public const int TYPE_NONE = -1;
  public const int TYPE_RELATIONSHIPS = 0;
  public const int TYPE_CAREER = 1;
  public const int TYPE_SKILLS = 2;
  public const int TYPE_DREAMS = 3;
  public const int TYPE_STATUS = 4;
  public const int TYPE_PERSONA = 5;
  public const int TYPE_INVENTORY = 6;
  public const int TYPE_RELATIONSHIPS_NPC = 10;
  public const int TYPE_INVENTORY_RECIPE = 11;
  private const int NUM_TYPES = 7;
  private const int CONTENT_WIDTH = 330;
  private int[] m_tempInt10;
  private int m_state;
  private int m_type;
  private int m_screenLeft;
  private int m_screenRight;
  private int m_subType;
  private int m_focusItem;
  private int m_titleId;
  private int m_dotIndex;
  private int m_longestStringNPCName;
  private int m_longestStringSkill;
  private int m_longestStringMotive;

  public static int getLongestStringNPCName()
  {
    AppEngine canvas = AppEngine.getCanvas();
    UIInfoScreen infoScreen = canvas.getSceneGame().getInfoScreen();
    SimData simData = canvas.getSimData();
    if (infoScreen.m_longestStringNPCName == 0)
    {
      int num = 0;
      int simCount = simData.getSimCount();
      for (int sim = 1; sim < simCount; ++sim)
      {
        int simName = simData.getSimName(sim);
        int stringWidth = canvas.getTextManager().getStringWidth(simName, 3);
        if (stringWidth > num)
          num = stringWidth;
      }
      infoScreen.m_longestStringNPCName = num;
    }
    return infoScreen.m_longestStringNPCName;
  }

  public UIInfoScreen()
  {
    this.m_tempInt10 = new int[10];
    this.m_state = 0;
    this.m_type = -1;
    this.m_screenLeft = -1;
    this.m_screenRight = -1;
    this.m_subType = -1;
    this.m_focusItem = -1;
    this.m_titleId = -1;
    this.m_dotIndex = -1;
    this.m_longestStringNPCName = 0;
    this.m_longestStringSkill = 0;
    this.m_longestStringMotive = 0;
  }

  public new void Dispose()
  {
    base.Dispose();
  }

  public void init(int type)
  {
    SceneGame sceneGame = AppEngine.getCanvas().getSceneGame();
    sceneGame.getUIList(4).initList();
    sceneGame.getUIList(6).initList();
    sceneGame.getUIList(5).initList();
    this.setScrollOffset(0.0f);
    this.resetScrolling(false);
    this.resetSwiping(true);
    this.setType(type);
    this.setSwipeRange(-1980f, 0.0f, 330f);
    this.setSwipeOffset((float) (-type * 330));
  }

  private void setType(int type)
  {
    this.m_type = type;
    this.setSubType(-1, -1);
    this.m_screenLeft = -1;
    this.m_screenRight = -1;
    if (type > 0)
      this.m_screenLeft = type - 1;
    if (type < 6)
      this.m_screenRight = type + 1;
    switch (type)
    {
      case -1:
        this.m_dotIndex = -1;
        this.m_titleId = -1;
        break;
      case 0:
        this.m_dotIndex = 0;
        this.m_titleId = 129;
        break;
      case 1:
        this.m_dotIndex = 1;
        this.m_titleId = 128;
        break;
      case 2:
        this.m_dotIndex = 2;
        this.m_titleId = 130;
        break;
      case 3:
        this.m_dotIndex = 3;
        this.m_titleId = 131;
        break;
      case 4:
        this.m_dotIndex = 4;
        this.m_titleId = 132;
        break;
      case 5:
        this.m_dotIndex = 5;
        this.m_titleId = 133;
        break;
      case 6:
        this.m_dotIndex = 6;
        this.m_titleId = 135;
        break;
    }
  }

  public void setSubType(int subType, int focusItem)
  {
    AppEngine canvas = AppEngine.getCanvas();
    SimData simData = canvas.getSimData();
    SimWorld simWorld = canvas.getSimWorld();
    int subType1 = this.m_subType;
    this.m_subType = subType;
    this.m_focusItem = focusItem;
    switch (subType)
    {
      case -1:
        if (subType1 != -1)
          this.resetSwiping(true);
        this.m_focusItem = -1;
        break;
      case 10:
        this.m_titleId = simData.getSimName(focusItem);
        this.resetSwiping(false);
        break;
      case 11:
        this.m_titleId = simWorld.getItemDescString(focusItem);
        this.resetSwiping(false);
        break;
    }
  }

  private void stateTransition(int newState)
  {
    this.m_state = newState;
    if (newState != 0)
      return;
    this.getScene().deactivateUIElement((UIElement) this);
  }

  public void render(Graphics g)
  {
    this.setup();
    AppEngine canvas = AppEngine.getCanvas();
    AnimationManager2D animationManager2D = canvas.getAnimationManager2D();
    float halfWidth = (float) canvas.getHalfWidth();
    float halfHeight = (float) canvas.getHalfHeight();
    animationManager2D.submitAnim(175, halfWidth, halfHeight);
    if (this.m_dotIndex >= 0 && this.m_dotIndex < 7)
    {
      float num = 32f;
      float x = (float) ((double) halfWidth - 108.0 + (double) num * (double) this.m_dotIndex);
      float y = halfHeight + 128f;
      animationManager2D.submitAnim(177, x, y);
    }
    int x1 = (int) ((double) halfWidth - 202.0);
    int y1 = (int) ((double) halfHeight - 95.0);
    this.getScene().getUIButton(128).submit(ref animationManager2D, x1, y1);
    bool enabled1 = canvas.getSimData().isTimeForWork((MapObject) null, 0);
    int x2 = (int) ((double) halfWidth + 197.0);
    int y2 = (int) ((double) halfHeight - 48.0);
    this.getScene().getUIButton(256).submit(ref animationManager2D, x2, y2, enabled1);
    bool enabled2 = !canvas.getSceneGame().isMapMode();
    int x3 = (int) ((double) halfWidth + 192.0);
    int y3 = (int) ((double) halfHeight + 32.0);
    this.getScene().getUIButton(512).submit(ref animationManager2D, x3, y3, enabled2);
    SceneGame sceneGame = canvas.getSceneGame();
    bool enabled3 = sceneGame.isMapMode() || sceneGame.isZoomMapMode();
    int x4 = (int) ((double) halfWidth + 186.0);
    int y4 = (int) ((double) halfHeight + 78.0);
    this.getScene().getUIButton(1024).submit(ref animationManager2D, x4, y4, enabled3);
    if (this.m_subType == -1)
    {
      if (this.itemsLeft())
      {
        float x5 = halfWidth - 185f;
        float y5 = halfHeight;
        animationManager2D.submitAnim(178, x5, y5);
      }
      if (this.itemsRight())
      {
        float x5 = halfWidth + 163f;
        float y5 = halfHeight;
        animationManager2D.submitAnim(179, x5, y5);
      }
    }
    if (this.m_subType != -1)
    {
      float x5 = halfWidth - 188f;
      float y5 = halfHeight + 17f;
      animationManager2D.submitAnim(176, x5, y5);
      float num1 = x5;
      float num2 = y5 - 16f;
      this.getScene().getUIButton(1048576).submit(ref animationManager2D, (int) num1, (int) num2);
    }
    animationManager2D.flushAnims(g);
    g.Begin();
    int x6 = (int) ((double) halfWidth - 15.0);
    int y6 = (int) ((double) halfHeight - 118.0);
    canvas.getTextManager().drawString(g, this.m_titleId, 6, x6, y6, 18);
    g.End();
    int num3 = (int) ((double) halfWidth - 165.0 - 11.0);
    int y7 = (int) ((double) halfHeight - 95.0 + 14.0);
    if (this.m_subType != -1)
    {
      int x5 = num3 + 15;
      this.renderContents(g, this.m_subType, x5, y7, 315, 190);
    }
    else
    {
      this.setDragArea(num3, y7, 330, 190);
      int clipX = g.getClipX();
      int clipY = g.getClipY();
      int clipWidth = g.getClipWidth();
      int clipHeight = g.getClipHeight();
      g.setClip(320 - y7 - 190, num3, 190, 330);
      int swipeOffset = (int) this.getSwipeOffset();
      int num1 = swipeOffset + this.m_type * 330;
      int x5 = num3 + num1;
      this.renderContents(g, this.m_type, x5, y7, 330, 190);
      float swipeNotchOffset = this.getSwipeNotchOffset(this.getSwipeOffset());
      if ((double) swipeOffset != (double) swipeNotchOffset)
      {
        int type = this.m_screenLeft;
        int num2 = -330;
        if ((double) swipeOffset < (double) swipeNotchOffset)
        {
          type = this.m_screenRight;
          num2 = 330;
        }
        if (type != -1)
        {
          int x7 = num3 + num2 + num1;
          this.renderContents(g, type, x7, y7, 330, 190);
        }
      }
      g.setClip(clipX, clipY, clipWidth, clipHeight);
    }
  }

  public override void update(int timeStep)
  {
    base.update(timeStep);
    int state = this.m_state;
  }

  public override void onMidSwipe()
  {
    this.setType(-this.getSwipeNotch(this.getSwipeOffset()));
  }

  private void renderContents(Graphics g, int type, int x, int y, int width, int height)
  {
    switch (type)
    {
      case 0:
        this.renderRelationships(g, x, y, width, height);
        break;
      case 1:
        this.renderCareer(g, x, y, width, height);
        break;
      case 2:
        this.renderSkills(g, x, y, width, height);
        break;
      case 3:
        this.renderDreams(g, x, y, width, height);
        break;
      case 4:
        this.renderStatus(g, x, y, width, height);
        break;
      case 5:
        this.renderPersona(g, x, y, width, height);
        break;
      case 6:
        this.renderInventory(g, x, y, width, height);
        break;
      case 10:
        this.renderRelationshipsNPC(g, x, y, width, height);
        break;
      case 11:
        this.renderInventoryRecipe(g, x, y, width, height);
        break;
    }
  }

  private void renderRelationships(Graphics g, int x, int y, int width, int height)
  {
    UIList uiList = this.getScene().getUIList(6);
    uiList.setup(x, y, width, height);
    uiList.render(g, true);
    if (uiList.getItemCount() != 0)
      return;
    AppEngine canvas = AppEngine.getCanvas();
    int x1 = x + (width >> 1);
    int y1 = y + (height >> 1);
    int lineWidth = width * 3 / 4;
    g.Begin();
    canvas.getTextManager().drawWrappedStringChunk(g, 0, 965, 3, lineWidth, x1, y1, 18);
    g.End();
  }

  private void renderCareer(Graphics g, int x, int y, int width, int height)
  {
    AppEngine canvas = AppEngine.getCanvas();
    TextManager textManager = canvas.getTextManager();
    SimData simData = canvas.getSimData();
    SimWorld simWorld = canvas.getSimWorld();
    AnimationManager2D animationManager2D = canvas.getAnimationManager2D();
    int simCareer = simData.getSimCareer(0);
    if (simCareer == -1)
    {
      int x1 = x + (width >> 1);
      int num = y + 68;
      float scaleX = 200f / animationManager2D.getAnimWidth(126);
      int y1 = y + 34;
      int y2 = y + 68 + (height - 68 >> 1);
      animationManager2D.submitAnim(126, (float) x1, (float) num, 1f, scaleX, 1f);
      animationManager2D.flushAnims(g);
      g.Begin();
      textManager.drawString(g, 997, 3, x1, y1, 18);
      textManager.drawWrappedStringChunk(g, 0, 998, 3, 200, x1, y2, 18);
      g.End();
    }
    else
    {
      int simCareerLevel = simData.getSimCareerLevel(0);
      int careerLevelFlags = simData.getCareerLevelFlags(simCareer, simCareerLevel);
      int careerLevelIncome = simData.getCareerLevelIncome(simCareer, simCareerLevel);
      int careerIcon = simData.getCareerIcon(simCareer);
      int careerDescString = simData.getCareerDescString(simCareer);
      int careerLevelDescString = simData.getCareerLevelDescString(simCareer, simCareerLevel);
      int careerRabbitHole = simData.getCareerRabbitHole(simCareer);
      int objectStringId = simWorld.getObjectStringId(careerRabbitHole);
      int careerBoss = simData.getCareerBoss(simCareer);
      int simName = simData.getSimName(careerBoss);
      int num1 = x + (width >> 1);
      int num2 = x + 251;
      int num3 = y + 27;
      int x1 = x + num2 >> 1;
      int y1 = y + 27;
      int num4 = x + (width >> 1);
      int num5 = y + 55;
      float animWidth = animationManager2D.getAnimWidth(188);
      int num6 = num4;
      int num7 = (int) ((double) (y + height - 25) + (double) animationManager2D.getAnimHeight((int) sbyte.MaxValue));
      float scaleX = animWidth / animationManager2D.getAnimWidth((int) sbyte.MaxValue);
      int num8 = (width >> 1) - 10;
      int num9 = height - 55 - 25;
      int num10 = y + 55;
      int num11 = x;
      int num12 = num1 + 5;
      int x2 = num11 + (num8 >> 1);
      int x3 = num12;
      int x4 = num12 + num8;
      animationManager2D.submitAnimGrid(233, 234, 235, 236, 237, 238, 239, 240, 241, (float) num11, (float) num10, (float) num8, (float) num9);
      animationManager2D.submitAnim(188, (float) num4, (float) num5);
      animationManager2D.submitAnim(careerIcon, (float) num2, (float) num3);
      animationManager2D.submitAnim((int) sbyte.MaxValue, (float) num6, (float) num7, 1f, scaleX, -1f);
      animationManager2D.flushAnims(g);
      g.Begin();
      textManager.drawString(g, careerLevelDescString, 3, x1, y1, 18);
      int font = 3;
      int lineHeight = textManager.getLineHeight(font);
      int num13 = 4 * lineHeight + 4;
      int y2 = num10 + (num9 - num13 >> 1);
      textManager.drawString(g, 981, font, x2, y2, 18);
      int y3 = y2 + lineHeight;
      StringBuffer strBuffer1 = textManager.clearStringBuffer();
      int num14 = 0;
      for (int index = 0; index < SimData.DAY_FLAGS.Length; ++index)
      {
        if ((careerLevelFlags & SimData.DAY_FLAGS[index]) != 0)
        {
          if (num14 > 0)
            textManager.appendStringIdToBuffer(11);
          textManager.appendStringIdToBuffer(SimData.DAY_STRINGS[index]);
          ++num14;
        }
      }
      textManager.drawString(g, strBuffer1, font, x2, y3, 18);
      int y4 = y3 + (lineHeight + 4);
      textManager.drawString(g, 990, font, x2, y4, 18);
      int y5 = y4 + lineHeight;
      StringBuffer strBuffer2 = textManager.clearStringBuffer();
      int careerLevelHoursStart = simData.getCareerLevelHoursStart(simCareer, simCareerLevel);
      textManager.appendTimeToBuffer24Hour(careerLevelHoursStart);
      textManager.appendStringIdToBuffer(991);
      int careerLevelHoursEnd = simData.getCareerLevelHoursEnd(simCareer, simCareerLevel);
      textManager.appendTimeToBuffer24Hour(careerLevelHoursEnd);
      textManager.drawString(g, strBuffer2, font, x2, y5, 18);
      int num15 = 4 * lineHeight + 12;
      int y6 = num10 + (num9 - num15 >> 1);
      textManager.drawString(g, 975, font, x3, y6, 10);
      textManager.drawString(g, careerDescString, font, x4, y6, 34);
      int y7 = y6 + (lineHeight + 4);
      textManager.drawString(g, 977, font, x3, y7, 10);
      StringBuffer strBuffer3 = textManager.clearStringBuffer();
      textManager.appendMoneyToBuffer(careerLevelIncome);
      textManager.drawString(g, strBuffer3, font, x4, y7, 34);
      int y8 = y7 + (lineHeight + 4);
      textManager.drawString(g, 979, font, x3, y8, 10);
      textManager.drawString(g, objectStringId, font, x4, y8, 34);
      int y9 = y8 + (lineHeight + 4);
      textManager.drawString(g, 980, font, x3, y9, 10);
      textManager.drawString(g, simName, font, x4, y9, 34);
      int num16 = y9 + lineHeight;
      g.End();
    }
  }

  private void renderSkills(Graphics g, int x, int y, int width, int height)
  {
    UIList uiList = this.getScene().getUIList(4);
    uiList.setup(x, y, width, height);
    uiList.render(g, true);
  }

  private void renderDreams(Graphics g, int x, int y, int width, int height)
  {
    AppEngine canvas = AppEngine.getCanvas();
    TextManager textManager = canvas.getTextManager();
    AnimationManager2D animationManager2D = canvas.getAnimationManager2D();
    SimData simData = canvas.getSimData();
    int dream = simData.getDream();
    int num1 = x + (width >> 1);
    int x1 = num1;
    int y1 = y + 4;
    int num2 = x + 50;
    int x2 = num2 + 28;
    int lineWidth = x + width - x2 - 50;
    int num3 = y1 + 13;
    float x3 = (float) num1;
    float scaleX1 = (float) lineWidth / animationManager2D.getAnimWidth((int) sbyte.MaxValue);
    float scaleX2 = (float) lineWidth / animationManager2D.getAnimWidth(126);
    int num4 = num3;
    int num5 = num1;
    int num6 = y + height + (num4 + 112) >> 1;
    int num7 = width - 20;
    int y2 = num6 - 16;
    int num8 = y2 + 8;
    int num9 = num5 + 25;
    int y3 = num8 + 3;
    int x4 = num5 - 125;
    int y4 = num6;
    animationManager2D.submitAnim((int) sbyte.MaxValue, x3, (float) num3, 1f, scaleX1, 1f);
    int num10 = num4;
    for (int index = 0; index < 4; ++index)
    {
      animationManager2D.submitAnim(135, (float) num2, (float) (num10 + 14), 1f, 1.8f, 1.8f);
      if (simData.getPromise(index) != -1)
        animationManager2D.submitAnim(40, (float) num2, (float) (num10 + 14));
      num10 += 28;
      animationManager2D.submitAnim(126, x3, (float) num10, 1f, scaleX2, 1f);
    }
    animationManager2D.submitAnimHBar(189, 190, 191, (float) num5, (float) num6, (float) num7);
    animationManager2D.submitAnim(126, (float) num9, (float) num8, 1f, scaleX2, 1f);
    if (dream != -1)
      this.getScene().getUIButton(16384).submit(ref animationManager2D, x4, y4);
    animationManager2D.flushAnims(g);
    g.Begin();
    textManager.drawString(g, 799, 3, x1, y1, 18);
    int chunk = 0;
    int num11 = num4;
    for (int index = 0; index < 4; ++index)
    {
      int promise = simData.getPromise(index);
      int stringId = 805;
      if (promise != -1)
        stringId = simData.getDreamDescString(promise);
      textManager.drawWrappedStringChunk(g, chunk, stringId, 3, lineWidth, x2, num11 + 14, 10);
      ++chunk;
      num11 += 28;
    }
    textManager.drawString(g, 800, 3, x2, y2, 10);
    int stringId1 = 806;
    if (dream != -1)
      stringId1 = simData.getDreamDescString(dream);
    textManager.drawWrappedStringChunk(g, chunk, stringId1, 3, lineWidth, x2, y3, 9);
    g.End();
  }

  private void renderStatus(Graphics g, int x, int y, int width, int height)
  {
    AppEngine canvas = AppEngine.getCanvas();
    TextManager textManager = canvas.getTextManager();
    AnimationManager2D animationManager2D = canvas.getAnimationManager2D();
    SimData simData = canvas.getSimData();
    int motiveCount = simData.getMotiveCount();
    if (this.m_longestStringMotive == 0)
    {
      int num = 0;
      for (int motive = 0; motive < motiveCount; ++motive)
      {
        int motiveDescString = (int) simData.getMotiveDescString(motive);
        int stringWidth = textManager.getStringWidth(motiveDescString, 3);
        if (stringWidth > num)
          num = stringWidth;
      }
      this.m_longestStringMotive = num;
    }
    int num1 = y + height - 32;
    int num2 = x + 10;
    int num3 = width - 20;
    int x1 = num2 + (num3 >> 1);
    int y1 = num1 + 16;
    int num4 = (height - 32 - 5 - 5) / motiveCount;
    float num5 = (float) (y + 5);
    float num6 = (float) num4;
    int x2 = x + 10 + this.m_longestStringMotive;
    int num7 = num4 >> 1;
    int num8 = x2 + 12;
    int num9 = x + width - 40 - num8;
    int num10 = num8 + (num9 >> 1);
    int num11 = num7;
    int num12 = num8 + num9 + 20;
    int num13 = num7;
    float num14 = num5;
    for (int motive = 0; motive < motiveCount; ++motive)
    {
      int motiveLevel = simData.getMotiveLevel(motive);
      float num15 = (float) MathExt.Fdiv(motiveLevel, 6553600) * 1.525879E-05f;
      float y2 = num14 + (float) num11;
      animationManager2D.submitAnimHBar(46, 47, 48, (float) num10, y2, (float) num9);
      int num16 = 49;
      int animMid = 50;
      int num17 = 51;
      int animId = (int) simData.getMotiveHighAnim(motive);
      if (motiveLevel < 2293760)
      {
        num16 = 52;
        animMid = 53;
        num17 = 54;
        animId = (int) simData.getMotiveLowAnim(motive);
      }
      else if (motiveLevel < 4259840)
        animId = (int) simData.getMotiveMidAnim(motive);
      int num18 = (int) ((double) animationManager2D.getAnimWidth(num16) + (double) animationManager2D.getAnimWidth(num17) - 8.0);
      float w = (float) num18 + num15 * (float) (num9 - num18);
      float x3 = (float) num8 + w * 0.5f;
      animationManager2D.submitAnimHBar(num16, animMid, num17, x3, y2, w);
      float y3 = num14 + (float) num13;
      animationManager2D.submitAnim(animId, (float) num12, y3);
      num14 += num6;
    }
    animationManager2D.submitAnimGrid(233, 234, 235, 236, 237, 238, 239, 240, 241, (float) num2, (float) num1, (float) num3, 32f);
    animationManager2D.flushAnims(g);
    g.Begin();
    int num19 = (int) num5;
    for (int motive = 0; motive < motiveCount; ++motive)
    {
      int motiveDescString = (int) simData.getMotiveDescString(motive);
      int y2 = num19 + num7;
      textManager.drawString(g, motiveDescString, 3, x2, y2, 34);
      num19 += (int) num6;
    }
    StringBuffer strBuffer = textManager.clearStringBuffer();
    textManager.appendStringIdToBuffer(767);
    textManager.appendStringIdToBuffer(simData.getMoodDescStringId());
    textManager.drawString(g, strBuffer, 3, x1, y1, 18);
    g.End();
  }

  private void renderPersona(Graphics g, int x, int y, int width, int height)
  {
    AppEngine canvas = AppEngine.getCanvas();
    TextManager textManager = canvas.getTextManager();
    AnimationManager2D animationManager2D = canvas.getAnimationManager2D();
    SimData simData = canvas.getSimData();
    int sim = 0;
    int persona = simData.getPersona();
    int personaDescString = (int) simData.getPersonaDescString(persona);
    int personaNthGoalCount = simData.getPersonaNthGoalCount();
    int num1 = x + (width >> 1);
    int num2 = num1;
    int num3 = y;
    int num4 = width >> 1;
    int num5 = num1 - (width >> 2);
    int num6 = y + 25;
    int x1 = num5;
    int y1 = num6 + 35;
    int x2 = x1;
    int y2 = y1 + 16;
    int x3 = x1;
    int y3 = y2 + 15;
    int x4 = num2 + 10;
    int x5 = num2 + (num4 >> 1);
    int num7 = num3 + 8;
    int lineHeight = textManager.getLineHeight(3);
    int x6 = num1;
    int y4 = num3 + 100 + 11;
    int x7 = x + 60;
    int num8 = x7 - 16;
    int num9 = y4 + 20;
    int num10 = 16;
    int num11 = x6;
    float scaleX = (float) width * 0.9f / animationManager2D.getAnimWidth(126);
    int num12 = -(num10 >> 1);
    animationManager2D.submitAnim(181, (float) num5, (float) num6);
    animationManager2D.submitAnimGrid(233, 234, 235, 236, 237, 238, 239, 240, 241, (float) num2, (float) num3, (float) num4, 100f, 1f);
    int num13 = num9;
    for (int index = 0; index < personaNthGoalCount; ++index)
    {
      bool flag = simData.isPersonaGoalsCompleted(index);
      animationManager2D.submitAnim(135, (float) num8, (float) num13);
      if (flag)
        animationManager2D.submitAnim(134, (float) num8, (float) num13);
      animationManager2D.submitAnim(126, (float) num11, (float) (num13 + num12), 1f, scaleX, 1f);
      num13 += num10;
    }
    animationManager2D.flushAnims(g);
    g.Begin();
    string simName = canvas.getSimName();
    textManager.drawString(g, simName, 6, x1, y1, 18);
    textManager.drawString(g, 969, 3, x2, y2, 18);
    textManager.drawString(g, personaDescString, 3, x3, y3, 18);
    int numPlayerTraits = simData.getNumPlayerTraits();
    int y5 = num7;
    textManager.drawString(g, 967, 3, x5, y5, 17);
    int y6 = y5 + lineHeight;
    for (int index = 0; index < numPlayerTraits; ++index)
    {
      int simTrait = simData.getSimTrait(sim, index);
      int traitDescString = (int) simData.getTraitDescString(simTrait);
      textManager.drawString(g, traitDescString, 3, x4, y6, 9);
      y6 += lineHeight;
    }
    textManager.drawString(g, 970, 3, x6, y4, 18);
    int y7 = num9;
    for (int index = 0; index < personaNthGoalCount; ++index)
    {
      int personaNthGoalItem = simData.getPersonaNthGoalItem(index);
      int dreamDescString = simData.getDreamDescString(personaNthGoalItem);
      textManager.drawString(g, dreamDescString, 3, x7, y7, 10);
      y7 += num10;
    }
    g.End();
  }

  private void renderInventory(Graphics g, int x, int y, int width, int height)
  {
    UIList uiList = this.getScene().getUIList(5);
    uiList.setup(x, y, width, height);
    uiList.render(g, true);
    if (uiList.getItemCount() != 0)
      return;
    AppEngine canvas = AppEngine.getCanvas();
    int x1 = x + (width >> 1);
    int y1 = y + (height >> 1);
    int lineWidth = width * 3 / 4;
    g.Begin();
    canvas.getTextManager().drawWrappedStringChunk(g, 0, 966, 3, lineWidth, x1, y1, 18);
    g.End();
  }

  private void renderRelationshipsNPC(Graphics g, int x, int y, int width, int height)
  {
    AppEngine canvas = AppEngine.getCanvas();
    TextManager textManager = canvas.getTextManager();
    AnimationManager2D animationManager2D = canvas.getAnimationManager2D();
    SimData simData = canvas.getSimData();
    int simCareer1 = simData.getSimCareer(0);
    int num1 = simCareer1 != -1 ? simData.getCareerBoss(simCareer1) : -1;
    int focusItem = this.m_focusItem;
    int simPortraitAnim = simData.getSimPortraitAnim(focusItem);
    int simPartner = simData.getSimPartner(focusItem);
    int strId = simPartner >= 0 ? simData.getSimName(simPartner) : -1;
    int simCareer2 = simData.getSimCareer(focusItem);
    int careerDescString = simData.getCareerDescString(simCareer2);
    int relState1 = simData.getRelState(focusItem);
    int[] tempInt10 = this.m_tempInt10;
    simData.getRelationshipLevels(focusItem, tempInt10);
    bool flag1 = simCareer1 != -1 && simCareer2 == simCareer1;
    bool flag2 = num1 == focusItem;
    int num2 = x + (width >> 1);
    int num3 = y + (height >> 1);
    int num4 = x + num2 >> 1;
    int num5 = y + 18;
    int num6 = 30;
    int x1 = num4;
    int width1 = width >> 1;
    int width2 = width * 3 >> 2;
    int x2 = x1 + (width2 - width1 >> 1);
    int num7 = num2 + 42;
    int num8 = y - 42;
    int num9 = width >> 1;
    int num10 = height >> 1;
    int num11 = num7 + (num9 >> 1);
    int num12 = num8 + (num10 >> 1);
    int num13 = num2 + 5;
    int num14 = y + 5 + 50;
    int num15 = (width >> 1) - 10;
    int num16 = (int) (0.75 * (double) height);
    int x3 = num13 + (num15 >> 1);
    int num17 = num14 + 8;
    int num18 = 2 * textManager.getLineHeight(3);
    int num19 = width >> 1;
    int x4 = x + 4;
    int x5 = num2 - 4;
    int num20 = num3 + 5;
    int num21 = 2 * textManager.getLineHeight(3) + 4;
    int num22 = x4 + x5 >> 1;
    int num23 = num20 + 47;
    int num24 = (int) ((double) num19 / (double) animationManager2D.getAnimWidth(126));
    int x6 = num22 + 22;
    int num25 = num22 - 44;
    int y1 = num23 + (y + height - num23 >> 1);
    int lineWidth = num19 >> 1;
    animationManager2D.submitAnim(simPortraitAnim, (float) num11, (float) num12);
    animationManager2D.submitAnimGrid(233, 234, 235, 236, 237, 238, 239, 240, 241, (float) num13, (float) num14, (float) num15, (float) num16, 1f);
    animationManager2D.submitAnim(126, (float) num22, (float) num23, 1f, (float) num24, 1f);
    if (flag1)
      animationManager2D.submitAnim(182, (float) num25, (float) y1);
    int y2 = num5;
    UIInfoScreen.drawRelBar(g, animationManager2D, x2, y2, width2, relState1, 65536, true);
    int y3 = y2 + num6;
    for (int index = 0; index < 4; index += 2)
    {
      int relState2 = tempInt10[index];
      if (relState2 != -1)
      {
        int levelF = tempInt10[index + 1];
        UIInfoScreen.drawRelBar(g, animationManager2D, x1, y3, width1, relState2, levelF, false);
        y3 += 24;
      }
      else
        break;
    }
    animationManager2D.flushAnims(g);
    int y4 = num5;
    UIInfoScreen.drawRelBar(g, (AnimationManager2D) null, x2, y4, width1, relState1, 65536, true);
    int y5 = y4 + num6;
    for (int index = 0; index < 4; index += 2)
    {
      int relState2 = tempInt10[index];
      if (relState2 != -1)
      {
        int levelF = tempInt10[index + 1];
        UIInfoScreen.drawRelBar(g, (AnimationManager2D) null, x1, y5, width1, relState2, levelF, false);
        y5 += 24;
      }
      else
        break;
    }
    g.Begin();
    int simTraitCount = simData.getSimTraitCount(focusItem);
    int y6 = num17;
    textManager.drawString(g, 967, 3, x3, y6, 17);
    int y7 = y6 + num18;
    for (int index = 0; index < simTraitCount; ++index)
    {
      int simTrait = simData.getSimTrait(focusItem, index);
      int stringId = (int) simData.getTraitDescString(simTrait);
      if (!simData.isTraitDiscovered(focusItem, simTrait))
        stringId = 968;
      textManager.drawWrappedStringChunk(g, 0, stringId, 3, num15 - 10, x3, y7, 18);
      y7 += num18;
    }
    int y8 = num20;
    textManager.drawString(g, 975, 3, x4, y8, 10);
    textManager.drawWrappedStringChunk(g, 1, careerDescString, 3, num19 >> 1, x5, y8, 34);
    int y9 = y8 + num21;
    if (simPartner != -1)
    {
      textManager.drawString(g, 971, 3, x4, y9, 9);
      textManager.drawString(g, strId, 3, x5, y9, 33);
    }
    int num26 = y9 + num21;
    if (flag1)
    {
      int stringId = 973;
      if (flag2)
        stringId = 972;
      textManager.drawWrappedStringChunk(g, 2, stringId, 3, lineWidth, x6, y1, 18);
    }
    g.End();
  }

  public static void drawRelBar(
    Graphics g,
    AnimationManager2D am2d,
    int x,
    int y,
    int width,
    int relState,
    int levelF,
    bool big)
  {
    AppEngine canvas = AppEngine.getCanvas();
    TextManager textManager = canvas.getTextManager();
    SimData simData = canvas.getSimData();
    if (am2d == null)
    {
      int relStateDescString = simData.getRelStateDescString(relState);
      int font = big ? 3 : 3;
      g.Begin();
      textManager.drawString(g, relStateDescString, font, x, y - 3, 18);
      g.End();
    }
    else
    {
      int animLeft = 208;
      int animMid = 209;
      int animRight = 210;
      if ((simData.getRelStateFlags(relState) & 1) != 0)
      {
        animLeft = 211;
        animMid = 212;
        animRight = 213;
      }
      else if ((simData.getRelStateFlags(relState) & 2) != 0)
      {
        animLeft = 214;
        animMid = 215;
        animRight = 216;
      }
      float w = (float) (width - 25);
      float scaleY1 = big ? 1.33333f : 1f;
      float scaleY2 = big ? 1f : 0.75f;
      am2d.submitAnimHBar(217, 218, 219, (float) x, (float) y, (float) width, 1f, scaleY1);
      if (levelF != 65536)
      {
        am2d.flushAnims(g);
        int clipX = g.getClipX();
        int clipY = g.getClipY();
        int clipWidth = g.getClipWidth();
        int clipHeight = g.getClipHeight();
        int y1 = x - (width >> 1);
        int h = MathExt.Fmul(width, levelF);
        g.setClip(clipY, y1, clipHeight, h);
        am2d.submitAnimHBar(animLeft, animMid, animRight, (float) x, (float) y, (float) width, 1f, scaleY1);
        am2d.flushAnims(g);
        g.setClip(clipX, clipY, clipWidth, clipHeight);
      }
      else
        am2d.submitAnimHBar(animLeft, animMid, animRight, (float) x, (float) y, (float) width, 1f, scaleY1);
      am2d.submitAnimHBar(220, 221, 222, (float) x, (float) y, w, 1f, scaleY2);
    }
  }

  private void renderInventoryRecipe(Graphics g, int x, int y, int width, int height)
  {
    AppEngine canvas = AppEngine.getCanvas();
    TextManager textManager = canvas.getTextManager();
    AnimationManager2D animationManager2D = canvas.getAnimationManager2D();
    SimData simData = canvas.getSimData();
    SimWorld simWorld = canvas.getSimWorld();
    int focusItem = this.m_focusItem;
    int recipeForItem = simWorld.getRecipeForItem(focusItem);
    int recipeIngredientCount1 = simWorld.getRecipeIngredientCount(recipeForItem);
    int num1 = x + 25;
    int num2 = y + 10;
    int x1 = x + 45;
    int y1 = num2;
    int num3 = x + 25;
    int x2 = num3 + 15;
    int num4 = 200;
    int num5 = x + (num4 >> 1);
    float scaleX1 = (float) num4 / animationManager2D.getAnimWidth(126);
    float scaleX2 = (float) num4 / animationManager2D.getAnimWidth((int) sbyte.MaxValue);
    int num6 = y + 25;
    int num7 = num5 + (num4 >> 1) + 10;
    int num8 = num6;
    int num9 = x + width - num7 - 10;
    int num10 = y + height - num8 - 10;
    animationManager2D.submitAnim(180, (float) num1, (float) num2);
    animationManager2D.submitAnim((int) sbyte.MaxValue, (float) num5, (float) num6, 1f, scaleX2, 1f);
    animationManager2D.submitAnimGrid(233, 234, 235, 236, 237, 238, 239, 240, 241, (float) num7, (float) num8, (float) num9, (float) num10);
    int recipe = recipeForItem;
    int recipeIngredientCount2 = simWorld.getRecipeIngredientCount(recipe);
    int animHeight = (int) animationManager2D.getAnimHeight(simWorld.getItemIcon(simWorld.getRecipeIngredient(recipe, 0)));
    int animWidth = (int) animationManager2D.getAnimWidth(simWorld.getItemIcon(simWorld.getRecipeIngredient(recipe, 0)));
    int num11 = num7 + (num9 >> 1) - (recipeIngredientCount2 > 4 ? animWidth >> 1 : 0);
    int num12 = JMath.min(4, recipeIngredientCount2);
    int num13 = num8 + (num10 >> 1) - (num12 * animHeight >> 1) + (animHeight >> 1);
    int num14 = num11;
    int num15 = num13;
    for (int index = 0; index < recipeIngredientCount2; ++index)
    {
      int recipeIngredient = simWorld.getRecipeIngredient(recipe, index);
      int itemIcon = simWorld.getItemIcon(recipeIngredient);
      float alpha = simData.getInventoryCount(recipeIngredient) > 0 ? 1f : 0.4f;
      animationManager2D.submitAnim(itemIcon, (float) num14, (float) num15, alpha);
      if (index == 3)
      {
        num15 = num13;
        num14 += animWidth;
      }
      else
        num15 += animHeight;
    }
    int num16 = num6;
    for (int index = 0; index < recipeIngredientCount1; ++index)
    {
      if (index > 0)
        animationManager2D.submitAnim(126, (float) num5, (float) num16, 1f, scaleX1, 1f);
      animationManager2D.submitAnim(135, (float) num3, (float) (num16 + 10));
      int recipeIngredient = simWorld.getRecipeIngredient(recipeForItem, index);
      if (simData.getInventoryCount(recipeIngredient) > 0)
        animationManager2D.submitAnim(134, (float) num3, (float) (num16 + 10));
      num16 += 20;
    }
    animationManager2D.flushAnims(g);
    g.Begin();
    textManager.drawString(g, 393, 4, x1, y1, 10);
    int num17 = num6;
    for (int index = 0; index < recipeIngredientCount1; ++index)
    {
      int recipeIngredient = simWorld.getRecipeIngredient(recipeForItem, index);
      int itemDescString = simWorld.getItemDescString(recipeIngredient);
      textManager.drawString(g, itemDescString, 3, x2, num17 + 10, 10);
      num17 += 20;
    }
    g.End();
  }

  public override void processInput(int _event, int[] args)
  {
    SimData simData = AppEngine.getCanvas().getSimData();
    if (this.m_state != 0)
      return;
    base.processInput(_event, args);
    switch (this.m_type)
    {
      case 0:
        if (this.m_subType == -1)
        {
          if (!Scene.checkCommand(_event, args, int.MinValue))
            break;
          int index = args[2];
          this.setSubType(10, simData.getRelationshipNthItem(index));
          break;
        }
        if (!Scene.checkCommand(_event, args, 1048576))
          break;
        this.setType(this.m_type);
        break;
      case 3:
        if (!Scene.checkCommand(_event, args, 16384))
          break;
        simData.dreamToPromise();
        break;
      case 6:
        if (this.m_subType == -1)
        {
          if (!Scene.checkCommand(_event, args, int.MinValue))
            break;
          int index = args[2];
          this.setSubType(11, simData.getInventoryNthItem(index));
          break;
        }
        if (!Scene.checkCommand(_event, args, 1048576))
          break;
        this.setType(this.m_type);
        break;
    }
  }
}
