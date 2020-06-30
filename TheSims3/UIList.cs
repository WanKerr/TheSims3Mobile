// Decompiled with JetBrains decompiler
// Type: UIList
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class UIList : UIScrollable
{
  private AnimTimer m_animTimer = new AnimTimer();
  internal const int BAR_MARGIN = 20;
  private const int STATE_IDLE = 0;
  private const int STATE_TRIGGERED = 1;
  private const int PREVIEW_CACHE_SIZE = 5;
  private const int CACHE_UNLOAD_DIST = 2;
  private const int CACHE_MAX_DIST = 4;
  public const int SELECTION_RESULT_FAIL = 0;
  public const int SELECTION_RESULT_SELECT = 1;
  public const int SELECTION_RESULT_DESELECT = 2;
  private int m_listId;
  private int m_state;
  private bool m_swipeList;
  private bool m_enabled;
  private int m_posX;
  private int m_posY;
  private int m_width;
  private int m_height;
  private int m_clipPosX;
  private int m_clipPosY;
  private int m_clipWidth;
  private int m_clipHeight;
  private int m_stringChunk;
  private int m_itemSelected;
  private int m_startSelection;
  private int m_itemNum;
  private int m_itemNumX;
  private int m_itemNumY;
  private int m_itemW;
  private int m_itemH;
  private int m_offsetCol;
  private UIObjectPreview[] m_objectPreviews;
  private int[] m_previewToIndexMap;
  private bool m_selectPreSend;
  private int m_selectAnim;
  private int m_lastMid;
  private int m_lastDir;
  private int m_selectionResult;
  private int m_soundId;

  public override void processInput(int _event, int[] args)
  {
    switch (this.m_state)
    {
      case 0:
        base.processInput(_event, args);
        if (_event != 3)
          break;
        int itemAt = this.getItemAt(args[1], args[2]);
        if (itemAt == -1 || !this.isItemSelectable(itemAt))
          break;
        if (this.m_soundId != -1)
          AppEngine.getCanvas().getScene().playSound(this.m_soundId);
        this.m_itemSelected = itemAt;
        this.stateTransition(1);
        break;
    }
  }

  public void setSelectionResult(int result)
  {
    this.m_selectionResult = result;
  }

  public UIList(int listId)
  {
    this.m_listId = listId;
    this.m_state = 0;
    this.m_swipeList = false;
    this.m_enabled = true;
    this.m_posX = 0;
    this.m_posY = 0;
    this.m_width = 0;
    this.m_height = 0;
    this.m_clipPosX = 0;
    this.m_clipPosY = 0;
    this.m_clipWidth = 0;
    this.m_clipHeight = 0;
    this.m_stringChunk = 0;
    this.m_itemSelected = 0;
    this.m_startSelection = -1;
    this.m_itemNum = 0;
    this.m_itemNumX = 0;
    this.m_itemNumY = 0;
    this.m_itemW = 0;
    this.m_itemH = 0;
    this.m_offsetCol = 0;
    this.m_selectPreSend = false;
    this.m_selectionResult = 0;
    this.m_selectAnim = 0;
    this.m_animTimer = new AnimTimer();
    this.m_objectPreviews = (UIObjectPreview[]) null;
    this.m_previewToIndexMap = (int[]) null;
    this.m_lastMid = -1;
    this.m_lastDir = 1;
    this.m_soundId = -1;
    switch (listId)
    {
      case 0:
        this.m_swipeList = true;
        this.m_soundId = 21;
        break;
      case 1:
        this.m_swipeList = true;
        break;
      case 8:
        this.m_swipeList = true;
        this.m_objectPreviews = new UIObjectPreview[5];
        this.m_previewToIndexMap = new int[5];
        break;
      case 10:
      case 11:
      case 12:
      case 13:
        this.m_swipeList = true;
        break;
    }
  }

  public new void Dispose()
  {
    if (this.m_listId != 8)
      return;
    for (int index = 0; index < 5; ++index)
      this.m_objectPreviews[index].Dispose();
  }

  public void setup(int x, int y, int w, int h)
  {
    this.setup(x, y, w, h, true);
  }

  public void setup(int x, int y, int w, int h, bool enabled)
  {
    this.setFlag(1);
    this.setDragArea(x, y, w, h);
    this.m_enabled = enabled;
    this.m_posX = this.getDragAreaX();
    this.m_posY = this.getDragAreaY();
    this.m_width = this.getDragAreaWidth();
    this.m_height = this.getDragAreaHeight();
    this.m_clipPosX = this.m_posX;
    this.m_clipPosY = this.m_posY;
    this.m_clipWidth = this.m_width;
    this.m_clipHeight = this.m_height;
    if (this.m_swipeList && this.getFlag(2))
    {
      this.m_width = this.m_itemW;
      this.m_posX = this.m_clipPosX + (this.m_clipWidth - this.m_width >> 1);
    }
    if (this.m_listId == 3)
    {
      this.m_posY += 10;
      this.m_height -= 10;
      this.m_clipHeight += 8;
    }
    if (this.getFlag(2))
      return;
    this.initList(this.m_startSelection);
  }

  public void initList()
  {
    this.initList(-1);
  }

  public void initList(int startSelection)
  {
    if (!this.getFlag(1))
    {
      this.m_startSelection = startSelection;
      this.unsetFlag(2);
    }
    else
    {
      AppEngine canvas = AppEngine.getCanvas();
      TextManager textManager = canvas.getTextManager();
      SimWorld simWorld = canvas.getSimWorld();
      SimData simData = canvas.getSimData();
      SceneGame sceneGame = canvas.getSceneGame();
      this.setFlag(2);
      this.m_itemNumX = 1;
      this.m_itemW = this.m_width - 20;
      this.m_itemSelected = startSelection;
      switch (this.m_listId)
      {
        case 0:
          this.m_selectPreSend = false;
          this.m_itemSelected = canvas.getRMSGameSlotIndex();
          this.m_itemNum = 7;
          this.m_itemNumX = this.m_itemNum;
          this.m_itemNumY = 1;
          this.m_itemW = 118;
          this.m_itemH = this.m_height;
          break;
        case 1:
          this.m_selectPreSend = true;
          this.m_itemNum = simData.getPersonaCount();
          this.m_itemSelected = simData.getPersona();
          this.m_itemNumX = this.m_itemNum;
          this.m_itemH = 40;
          this.m_itemNumY = 1;
          this.m_itemW = 160;
          this.m_itemH = this.m_height;
          break;
        case 2:
          this.m_itemNum = simData.getTraitCount();
          this.m_itemH = 40;
          break;
        case 3:
          this.m_itemNum = simData.getTaskCount();
          this.m_itemH = 28;
          break;
        case 4:
          this.m_itemNum = simData.getSkillCount();
          this.m_itemH = 45;
          int num1 = 0;
          for (int skill = simData.getSkillCount() - 1; skill >= 0; --skill)
          {
            int skillDesc = simData.getSkillDesc(skill);
            int stringWidth = textManager.getStringWidth(skillDesc, 3);
            if (stringWidth > num1)
              num1 = stringWidth;
          }
          this.m_offsetCol = num1;
          break;
        case 5:
          this.m_itemNum = simData.getInventoryNthCount();
          this.m_itemH = 40;
          break;
        case 6:
          this.m_itemNum = simData.getRelationshipNthCount();
          this.m_itemH = 40;
          break;
        case 7:
          this.m_itemSelected = 0;
          this.m_itemNum = sceneGame.getShoppingItemCount();
          this.m_itemH = 40;
          break;
        case 8:
          this.m_itemSelected = 0;
          this.m_itemNum = simWorld.getFurnitureCountOfCategory(sceneGame.getCurFurnitureCategory());
          this.m_itemH = 40;
          this.m_itemNumY = 1;
          this.m_itemW = 180;
          for (int index = 0; index < 5; ++index)
          {
            int nthItemOfCategory = simWorld.getFurnitureNthItemOfCategory(index, sceneGame.getCurFurnitureCategory());
            this.m_objectPreviews[index] = new UIObjectPreview();
            this.m_objectPreviews[index].loadObject(nthItemOfCategory);
            this.m_objectPreviews[index].getModel().disableFurnitureShadows();
            this.m_previewToIndexMap[index] = index;
          }
          break;
        case 9:
          this.m_itemSelected = 0;
          this.m_itemH = textManager.getLineHeight(3);
          this.m_itemNum = sceneGame.shoppingListSize();
          break;
        case 10:
          this.m_itemNum = simWorld.getUnlockedFloorNthCount();
          this.m_itemNumX = this.m_itemNum;
          this.m_itemNumY = 1;
          this.m_itemW = 160;
          this.m_itemH = this.m_height;
          break;
        case 11:
          this.m_itemNum = simWorld.getUnlockedWallNthCount();
          this.m_itemNumX = this.m_itemNum;
          this.m_itemNumY = 1;
          this.m_itemW = 160;
          this.m_itemH = this.m_height;
          break;
        case 12:
          int buildModeOldSetting = canvas.getSceneGame().getBuildModeOldSetting();
          int objectFootprintHeight = simWorld.getObjectFootprintHeight(buildModeOldSetting);
          this.m_itemNum = simWorld.getWindowNthTypeCount(objectFootprintHeight);
          this.m_itemNumX = this.m_itemNum;
          this.m_itemNumY = 1;
          this.m_itemW = 160;
          this.m_itemH = this.m_height;
          break;
        case 13:
          this.m_itemNum = simWorld.getDoorNthTypeCount();
          this.m_itemNumX = this.m_itemNum;
          this.m_itemNumY = 1;
          this.m_itemW = 160;
          this.m_itemH = this.m_height;
          break;
      }
      if (this.m_swipeList)
      {
        this.m_width = this.m_itemW;
        this.m_posX = this.m_clipPosX + (this.m_clipWidth - this.m_width >> 1);
        this.m_itemNumX = this.m_itemNum / this.m_itemNumY + (this.m_itemNum % this.m_itemNumY > 0 ? 1 : 0);
        int num2 = this.m_itemSelected >= 0 ? this.m_itemSelected : 0;
        int num3 = (this.m_itemNumX - 1) * this.m_itemW;
        float min = (float) JMath.min(0, -num3);
        float max = 0.0f;
        if (this.m_listId == 0)
        {
          min += (float) this.m_itemW;
          max -= (float) this.m_itemW;
          if (num2 == 0)
            num2 = 1;
          else if (num2 == this.m_itemNumX - 1)
            num2 = this.m_itemNumX - 2;
        }
        this.setSwipeRange(min, max, (float) this.m_itemW);
        this.resetSwiping(num3 >= this.m_width);
        this.setSwipeOffset((float) (-num2 * this.m_itemW));
      }
      else
      {
        this.m_itemNumY = this.m_itemNum / this.m_itemNumX + (this.m_itemNum % this.m_itemNumX > 0 ? 1 : 0);
        int num2 = this.m_itemNumY * this.m_itemH;
        this.setScrollRange((float) JMath.min(0, -num2 + this.m_height), 0.0f);
        this.resetScrolling(num2 > this.m_height);
        this.setScrollOffset(0.0f);
      }
    }
  }

  private void stateTransition(int newState)
  {
    this.m_state = newState;
    switch (newState)
    {
      case 0:
        this.getScene().deactivateUIElement((UIElement) this);
        break;
      case 1:
        this.getScene().activateUIElement((UIElement) this);
        if (this.m_selectAnim != -1)
          this.m_animTimer.startTimer(this.m_selectAnim, 16);
        else
          this.stateTransition(0);
        if (!this.m_selectPreSend)
          break;
        this.sendSelect();
        break;
    }
  }

  public void render(Graphics g)
  {
    this.render(g, false);
  }

  public void render(Graphics g, bool clipSet)
  {
    AnimationManager2D animationManager2D = AppEngine.getCanvas().getAnimationManager2D();
    int clipPosX = this.m_clipPosX;
    int clipPosY = this.m_clipPosY;
    int clipWidth1 = this.m_clipWidth;
    int clipHeight1 = this.m_clipHeight;
    int posX = this.m_posX;
    int num1 = this.m_width - 20;
    int num2 = this.m_posX + (int) this.getSwipeOffset();
    int num3 = this.m_posY + (int) this.getScrollOffset();
    int itemH = this.m_itemH;
    float num4 = (float) num1;
    float x1 = (float) posX + num4 * 0.5f;
    float scaleX = num4 / animationManager2D.getAnimWidth(126);
    int x2 = num2;
    int y1 = num3;
    for (int index = 0; index < this.m_itemNum; ++index)
    {
      if (!this.m_swipeList && y1 > clipPosY - this.m_itemH && y1 < clipPosY + clipHeight1 + this.m_itemH || this.m_swipeList && x2 + this.m_itemW > clipPosX && x2 < clipPosX + clipWidth1)
      {
        this.renderItem((Graphics) null, animationManager2D, index, x2, y1, this.m_itemW, this.m_itemH);
        if (this.m_itemNumX == 1 && index < this.m_itemNum - 1 && this.m_listId != 9)
          animationManager2D.submitAnim(126, x1, (float) (y1 + itemH), 1f, scaleX, 1f);
      }
      if (index % this.m_itemNumX == this.m_itemNumX - 1)
      {
        y1 += this.m_itemH;
        x2 = num2;
      }
      else
        x2 += this.m_itemW;
    }
    int clipX = g.getClipX();
    int clipY = g.getClipY();
    int clipWidth2 = g.getClipWidth();
    int clipHeight2 = g.getClipHeight();
    if (!clipSet)
      g.clipRect(320 - clipPosY - clipHeight1, clipPosX, clipHeight1, clipWidth1);
    animationManager2D.flushAnims(g);
    this.m_stringChunk = 0;
    int x3 = num2;
    int y2 = num3;
    for (int index = 0; index < this.m_itemNum; ++index)
    {
      if (!this.m_swipeList && y2 > clipPosY - this.m_itemH && y2 < clipPosY + clipHeight1 + this.m_itemH || this.m_swipeList && x3 + this.m_itemW > clipPosX && x3 < clipPosX + clipWidth1)
        this.renderItem(g, (AnimationManager2D) null, index, x3, y2, this.m_itemW, this.m_itemH);
      if (index % this.m_itemNumX == this.m_itemNumX - 1)
      {
        y2 += this.m_itemH;
        x3 = num2;
      }
      else
        x3 += this.m_itemW;
    }
    if (!clipSet)
      g.setClip(clipX, clipY, clipWidth2, clipHeight2);
    if (this.m_swipeList)
      return;
    float num5 = 10f;
    float height1 = (float) this.m_height;
    float barX = (float) (this.m_posX + this.m_width) - num5;
    float barY = (float) this.m_posY + height1 * 0.5f;
    float height2 = (float) this.m_height;
    float num6 = (float) (this.m_itemH * this.m_itemNumY);
    float num7 = -this.getScrollOffset();
    this.submitScrollbar(ref animationManager2D, (int) num7, (int) height2, (int) num6, barX, barY, height1);
    animationManager2D.flushAnims(g);
  }

  private void renderItem(
    Graphics g,
    AnimationManager2D am2d,
    int index,
    int x,
    int y,
    int width,
    int height)
  {
    AppEngine canvas = AppEngine.getCanvas();
    TextManager textManager = canvas.getTextManager();
    SimData simData = canvas.getSimData();
    SimWorld simWorld = canvas.getSimWorld();
    DLCManager instance = DLCManager.getInstance();
    SceneGame sceneGame = canvas.getSceneGame();
    switch (this.m_listId)
    {
      case 0:
        bool rmsActiveGame = canvas.getRMSActiveGame(index);
        bool flag1 = canvas.getSceneMenu().isDeletingSaveGame();
        int lineHeight = textManager.getLineHeight(4);
        int y1 = y + height - 10 - lineHeight;
        int x1 = x + (width >> 1);
        int num1 = x + (width >> 1);
        int num2 = y + (y1 - y >> 1);
        if (g != null)
        {
          if (rmsActiveGame)
          {
            SceneMenu sceneMenu = canvas.getSceneMenu();
            int clipX = g.getClipX();
            int clipY = g.getClipY();
            int clipWidth = g.getClipWidth();
            int clipHeight = g.getClipHeight();
            sceneMenu.getHudPlumbBob().render(g, num1 - 75, num2 - 75, 150, 150);
            g.setClip(clipX, clipY, clipWidth, clipHeight);
          }
          if (!rmsActiveGame && flag1)
            break;
          string simName = canvas.getSimName(index);
          if (simName != null && simName != "" && simName != " ")
          {
            g.Begin();
            textManager.drawString(g, simName, 4, x1, y1, 17);
            g.End();
            break;
          }
          g.Begin();
          textManager.drawString(g, 40, 4, x1, y1, 17);
          g.End();
          break;
        }
        int num3 = width;
        int num4 = height;
        int num5 = x + (width - num3 >> 1);
        int num6 = y + (height - num4 >> 1) + 1;
        float alpha1 = rmsActiveGame || !flag1 ? 1f : 0.2f;
        am2d.submitAnimGrid(340, 341, 342, 343, 344, 345, 346, 347, 348, (float) num5, (float) num6, (float) num3, (float) num4, alpha1);
        am2d.submitAnim(rmsActiveGame ? 403 : 402, (float) num1, (float) num2, alpha1);
        if (this.m_state != 1 || index != this.m_itemSelected || flag1 && !rmsActiveGame)
          break;
        float alpha2 = this.m_animTimer.getValue();
        am2d.submitAnimGrid(250, 253, 256, 251, 254, 257, 252, (int) byte.MaxValue, 258, (float) num5, (float) num6, (float) num3, (float) num4, alpha2);
        break;
      case 1:
        if (g != null)
        {
          g.Begin();
          int x2 = x + (width >> 1);
          int y2 = y + 96;
          int personaDescString = (int) simData.getPersonaDescString(index);
          textManager.drawString(g, personaDescString, 4, x2, y2, 18);
          int personaLongDescString = (int) simData.getPersonaLongDescString(index);
          int x3 = x2;
          int y3 = y + 143;
          textManager.drawWrappedStringChunk(g, 0, personaLongDescString, 4, width - 12, x3, y3, 18);
          g.End();
          break;
        }
        int num7 = width;
        int num8 = (int) (0.65 * (double) height);
        int num9 = x + (width - num7 >> 1);
        int num10 = y;
        int num11 = num9 + (width >> 1);
        am2d.submitAnimGrid(340, 341, 342, 343, 344, 345, 346, 347, 348, (float) num9, (float) num10, (float) num7, (float) num8);
        am2d.submitAnim(181, (float) num11, (float) (num10 + 50));
        int num12 = num9 + (num7 >> 1);
        int num13 = num10 + 115;
        float scaleX = (float) width / am2d.getAnimWidth((int) sbyte.MaxValue);
        am2d.submitAnim((int) sbyte.MaxValue, (float) num12, (float) num13, 1f, scaleX, 1f);
        break;
      case 2:
        if (g != null)
        {
          int x2 = x + 35;
          int num14 = height >> 1;
          int y2 = y + num14;
          int traitDescString = (int) simData.getTraitDescString(index);
          g.Begin();
          textManager.drawWrappedStringChunk(g, 0, traitDescString, 4, width - 35, x2, y2, 2);
          g.End();
          break;
        }
        int num15 = height >> 1;
        int num16 = (height >> 1) - 5;
        bool flag2 = simData.hasSimGotTrait(0, index) != -1;
        if (this.m_state == 1 && this.m_itemSelected == index)
        {
          float num14 = this.m_animTimer.getValue();
          if (this.m_selectionResult == 0)
            am2d.submitAnim(171, (float) (x + num16), (float) (y + num15), 1f, num14, num14);
          else if (this.m_selectionResult != 1)
          {
            int selectionResult = this.m_selectionResult;
          }
        }
        if (!flag2)
          break;
        am2d.submitAnim(114, (float) (x + num16), (float) (y + num15));
        break;
      case 3:
        int x4 = x + 55;
        int lineWidth1 = this.m_width - 110;
        int num17 = (height >> 1) + 1;
        int y4 = y + num17;
        int dream = this.remapGlobalGoalIndex(index);
        int num18 = -1;
        int stringId1;
        if (canvas.isDreamDiscovered(dream))
        {
          stringId1 = simData.getDreamDescString(dream);
          if (canvas.isGoalCompleted(dream))
            num18 = 134;
        }
        else
          stringId1 = 807;
        if (g != null)
        {
          g.Begin();
          textManager.drawWrappedStringChunk(g, this.m_stringChunk, stringId1, 3, lineWidth1, x4, y4, 10);
          g.End();
        }
        else
        {
          float x2 = (float) x + 30f;
          float y2 = (float) y + (float) height * 0.5f;
          am2d.submitAnim(135, x2, y2);
          if (num18 != -1)
            am2d.submitAnim(134, x2, y2);
        }
        ++this.m_stringChunk;
        break;
      case 4:
        int x5 = x + 32;
        int num19 = (height >> 1) + 1;
        int y5 = y + num19;
        int x6 = x + width - 12;
        int y6 = y5;
        int num20 = x5 + this.m_offsetCol + 12;
        int num21 = x6 - 12 - num20;
        int x7 = num20 + (num21 >> 1);
        int num22 = y5 - 9;
        int y7 = y5 + 9;
        if (g != null)
        {
          int skillDesc = simData.getSkillDesc(index);
          g.Begin();
          textManager.drawString(g, skillDesc, 3, x5, y5, 10);
          StringBuffer strBuffer = textManager.clearStringBuffer();
          textManager.appendIntToBuffer(simData.getSkillLevel(index) >> 16);
          textManager.drawString(g, strBuffer, 3, x6, y6, 10);
          textManager.drawString(g, simData.getSkillLevelDesc(index), 3, x7, y7, 18);
          g.End();
          break;
        }
        int num23 = (int) ((double) am2d.getAnimWidth(199) + (double) am2d.getAnimWidth(201));
        float num24 = (float) MathExt.Fdiv(simData.getSkillLevel(index), 327680) * 1.525879E-05f;
        am2d.submitAnimHBar(202, 203, 204, (float) x7, (float) num22, (float) num21);
        float w1 = (float) num23 + num24 * (float) (num21 - num23);
        float x8 = (float) num20 + w1 * 0.5f;
        am2d.submitAnimHBar(199, 200, 201, x8, (float) num22, w1);
        am2d.submitAnimHBar(205, 206, 207, (float) x7, (float) y7, (float) num21);
        break;
      case 5:
      case 7:
        bool flag3 = this.m_listId == 7;
        int num25 = this.m_listId == 5 ? simData.getInventoryNthItem(index) : sceneGame.getShoppingItemId(index);
        int num26 = height >> 1;
        if (g != null)
        {
          int num14 = x + 42;
          int y2 = y + num26;
          int num27 = width - 15;
          int x2 = x + num27;
          int y3 = y2;
          int itemDescString = simWorld.getItemDescString(num25);
          int lineWidth2 = flag3 ? width >> 1 : 120;
          g.Begin();
          textManager.drawWrappedStringChunk(g, 0, itemDescString, 3, lineWidth2, num14 + 4, y2, 10);
          if (this.m_listId == 5)
          {
            if ((simWorld.getItemFlags(num25) & 4) == 0)
            {
              int inventoryCount = simData.getInventoryCount(num25);
              int itemMaxInventory = simWorld.getItemMaxInventory(num25);
              StringBuffer strBuffer = textManager.clearStringBuffer();
              textManager.appendIntToBuffer(inventoryCount);
              textManager.appendStringIdToBuffer(11);
              textManager.appendIntToBuffer(itemMaxInventory);
              textManager.drawString(g, strBuffer, 3, x2, y3, 34);
            }
          }
          else
          {
            int shoppingQty = sceneGame.getShoppingQty(index);
            int itemMaxInventory = simWorld.getItemMaxInventory(num25);
            StringBuffer strBuffer = textManager.clearStringBuffer();
            textManager.appendIntToBuffer(shoppingQty);
            textManager.appendStringIdToBuffer(11);
            textManager.appendIntToBuffer(itemMaxInventory);
            textManager.drawString(g, strBuffer, 3, x2, y3, 34);
          }
          int itemPackId = simWorld.getItemPackId(num25);
          if (itemPackId != -1)
          {
            Image packTag = instance.getPackTag(itemPackId);
            if (packTag != null)
            {
              int num28 = x + width - 50;
              int num29 = y + 20;
              g.drawImage(packTag, (float) num28, (float) num29, 18);
            }
          }
          g.End();
          break;
        }
        if (this.m_listId == 7 && this.m_itemSelected == index)
        {
          int num14 = width;
          int num27 = height - 4;
          int num28 = (int) ((double) x + (double) (width - num14) * 0.5 + 4.0);
          int num29 = (int) ((double) y + (double) (height - num27) * 0.5);
          am2d.submitAnimGrid(224, 225, 226, 227, 228, 229, 230, 231, 232, (float) num28, (float) num29, (float) num14, (float) num27);
        }
        if ((simWorld.getItemFlags(num25) & 4) != 0 && !flag3)
        {
          if (this.m_state != 1 || this.m_itemSelected != index || (double) this.m_animTimer.getValue() > 0.5)
          {
            int num14 = width;
            int num27 = height - 4;
            int num28 = x + (width - num14 >> 1) + 4;
            int num29 = y + (height - num27 >> 1) + 1;
            am2d.submitAnimGrid(224, 225, 226, 227, 228, 229, 230, 231, 232, (float) num28, (float) num29, (float) num14, (float) num27);
            int recipeForItem = simWorld.getRecipeForItem(num25);
            int recipeIngredientCount = simWorld.getRecipeIngredientCount(recipeForItem);
            int num30 = (int) ((double) am2d.getAnimHeight(simWorld.getItemIcon(simWorld.getRecipeIngredient(recipeForItem, 0))) * 0.5 - 2.0);
            int num31 = (int) ((double) am2d.getAnimWidth(simWorld.getItemIcon(simWorld.getRecipeIngredient(recipeForItem, 0))) * 0.5);
            int num32 = -(num30 >> 1);
            int num33 = x + (width >> 1) + 20;
            int num34 = y + (height >> 1) + (recipeIngredientCount > 4 ? num32 : 0);
            int num35 = num33;
            int num36 = num34;
            for (int index1 = 0; index1 < recipeIngredientCount; ++index1)
            {
              int recipeIngredient = simWorld.getRecipeIngredient(recipeForItem, index1);
              int itemIcon = simWorld.getItemIcon(recipeIngredient);
              float alpha3 = simData.getInventoryCount(recipeIngredient) > 0 ? 1f : 0.4f;
              am2d.submitAnim(itemIcon, (float) num35, (float) num36, alpha3, 0.5f, 0.5f);
              if (index1 == 3)
              {
                num36 += num30;
                num35 = num33;
              }
              else
                num35 += num31;
            }
          }
          int num37 = width - 35;
          int num38 = x + num37;
          int num39 = (int) ((double) y + (double) height * 0.5);
          am2d.submitAnim(180, (float) num38, (float) num39);
        }
        int num40 = x + 21;
        int num41 = y + num26;
        int itemIcon1 = simWorld.getItemIcon(num25);
        am2d.submitAnim(itemIcon1, (float) num40, (float) num41);
        break;
      case 6:
        int x9 = x + 20;
        int num42 = height >> 1;
        int num43 = y + num42;
        int relationshipNthItem = simData.getRelationshipNthItem(index);
        int simName1 = simData.getSimName(relationshipNthItem);
        int relState = simData.getRelState(relationshipNthItem);
        int x10 = x + (width >> 1) + 20;
        int y8 = num43;
        if (g != null)
        {
          g.Begin();
          textManager.drawString(g, simName1, 4, x9, num43 - 3, 10);
          g.End();
        }
        else
        {
          if (this.m_state != 1 || this.m_itemSelected != index || (double) this.m_animTimer.getValue() > 0.5)
          {
            int num14 = height - 2;
            int num27 = (int) ((double) y + (double) (height - num14) * 0.5);
            int num28 = x10 - x - 75;
            int num29 = x;
            int num30 = x + width - (x10 + 75);
            int num31 = x10 + 75;
            int num32 = num31 - (num29 + num28);
            int num33 = height - 16;
            int num34 = num29 + num28;
            int num35 = y + (height - num33 >> 1);
            am2d.submitAnimGrid(224, 225, 226, 227, 228, 229, 230, 231, 232, (float) num29, (float) num27, (float) num28, (float) num14);
            am2d.submitAnimGrid(224, 225, 226, 227, 228, 229, 230, 231, 232, (float) num31, (float) num27, (float) num30, (float) num14);
            am2d.submitAnimStretched(228, (float) num34, (float) num35, (float) num32, (float) num33);
          }
          int num36 = width - 35;
          int num37 = x + num36;
          int num38 = (int) ((double) y + (double) height * 0.5);
          am2d.submitAnim(180, (float) num37, (float) num38);
        }
        UIInfoScreen.drawRelBar(g, am2d, x10, y8, 150, relState, 65536, false);
        break;
      case 8:
        int nthItemOfCategory = simWorld.getFurnitureNthItemOfCategory(index, sceneGame.getCurFurnitureCategory());
        int objectStringId = simWorld.getObjectStringId(nthItemOfCategory);
        int num44 = 173;
        int x11 = x + 5;
        int y9 = y + 5;
        int w2 = num44 - 10;
        if (g == null)
        {
          am2d.submitAnimGrid(340, 341, 342, 343, 344, 345, 346, 347, 348, (float) x, (float) y, (float) num44, 195f);
          if (!simWorld.isFurnitureAvailable(nthItemOfCategory))
            am2d.submitAnim(320, (float) (x11 + (w2 >> 1)), (float) (y9 + 65));
        }
        else
        {
          int clipX = g.getClipX();
          int clipY = g.getClipY();
          int clipWidth = g.getClipWidth();
          int clipHeight = g.getClipHeight();
          if (simWorld.isFurnitureAvailable(nthItemOfCategory))
          {
            int index1 = -1;
            for (int index2 = 0; index2 < 5; ++index2)
            {
              if (this.m_previewToIndexMap[index2] == index)
              {
                index1 = index2;
                break;
              }
            }
            if (index1 == -1)
            {
              int num14 = -this.getSwipeNotch(this.getSwipeOffset());
              int num27 = num14 == this.m_lastMid ? this.m_lastDir : JMath.min(1, JMath.max(-1, num14 - this.m_lastMid));
              this.m_lastMid = num14;
              this.m_lastDir = num27;
              int num28 = 0;
              for (int index2 = 0; index2 < 5; ++index2)
              {
                int a = this.m_previewToIndexMap[index2] - num14;
                int num29 = JMath.abs(a);
                if (a * num27 < 0 && num29 >= 2 || (num29 >= 4 || this.m_previewToIndexMap[index2] == -1))
                {
                  this.m_previewToIndexMap[index2] = -1;
                  ++num28;
                }
              }
              int index3 = index;
              int objectType = nthItemOfCategory;
              for (int index2 = 0; index2 < 5; ++index2)
              {
                if (this.m_previewToIndexMap[index2] == -1)
                {
                  this.m_objectPreviews[index2].loadObject(objectType);
                  this.m_objectPreviews[index2].getModel().disableFurnitureShadows();
                  this.m_previewToIndexMap[index2] = index3;
                  --num28;
                  if (index3 == index)
                    index1 = index2;
                  index3 += num27;
                  objectType = simWorld.getFurnitureNthItemOfCategory(index3, sceneGame.getCurFurnitureCategory());
                  if (index3 < 0 || index3 >= this.m_itemNum || num28 == 0)
                    break;
                }
              }
            }
            this.m_objectPreviews[index1].render(g, x11, y9, w2, 130);
            g.setClip(clipX, clipY, clipWidth, clipHeight);
          }
          int x2 = x + (num44 >> 1);
          int y2 = y9 + 130;
          g.Begin();
          textManager.drawWrappedStringChunk(g, this.m_stringChunk, objectStringId, 4, num44 - 10, x2, y2, 17);
          int y3 = y + 195 - 10;
          int x3 = x + (num44 >> 1);
          int objectBuyPrice = simWorld.getObjectBuyPrice(nthItemOfCategory);
          StringBuffer strBuffer = textManager.clearStringBuffer();
          textManager.appendMoneyToBuffer(objectBuyPrice);
          textManager.drawString(g, strBuffer, 4, x3, y3, 20);
          int objectPackId = simWorld.getObjectPackId(nthItemOfCategory);
          if (objectPackId != -1)
          {
            Image packTag = instance.getPackTag(objectPackId);
            if (packTag != null)
            {
              int num14 = x + width - 27;
              int num27 = y + 21;
              g.drawImage(packTag, (float) num14, (float) num27, 18);
            }
          }
          g.End();
        }
        ++this.m_stringChunk;
        break;
      case 9:
        if (g == null)
          break;
        int font1 = 3;
        int x12 = x;
        int x13 = x + width - 30;
        int num45 = sceneGame.shoppingListItem(index);
        int num46 = sceneGame.shoppingListQty(index);
        int itemDescString1 = simWorld.getItemDescString(num45);
        g.Begin();
        textManager.drawString(g, itemDescString1, font1, x12, y, 9);
        StringBuffer strBuffer1 = textManager.clearStringBuffer();
        textManager.appendStringIdToBuffer(1085);
        textManager.appendIntToBuffer(num46);
        textManager.drawString(g, strBuffer1, font1, x13, y, 9);
        g.End();
        break;
      case 10:
      case 11:
      case 12:
      case 13:
        if (g != null)
        {
          int font2 = 4;
          int font3 = 3;
          int x2 = x + (width >> 1);
          int y2 = y + (height - textManager.getLineHeight(font2) >> 1);
          int y3 = y + height - textManager.getLineHeight(font3);
          int lineWidth2 = width - 25;
          int buildModeOldSetting = canvas.getSceneGame().getBuildModeOldSetting();
          int stringId2 = -1;
          int packId = -1;
          int num14 = 0;
          bool flag4 = false;
          switch (this.m_listId)
          {
            case 10:
              int unlockedFloorNthId = simWorld.getUnlockedFloorNthId(index);
              stringId2 = simWorld.getFloorStringId(unlockedFloorNthId);
              packId = simWorld.getFloorPackId(unlockedFloorNthId);
              flag4 = unlockedFloorNthId == buildModeOldSetting;
              num14 = 50;
              break;
            case 11:
              int unlockedWallNthId = simWorld.getUnlockedWallNthId(index);
              stringId2 = simWorld.getWallStringId(unlockedWallNthId);
              packId = simWorld.getWallPackId(unlockedWallNthId);
              flag4 = unlockedWallNthId == buildModeOldSetting;
              num14 = 50;
              break;
            case 12:
              int objectFootprintHeight = simWorld.getObjectFootprintHeight(buildModeOldSetting);
              int windowNthType = simWorld.getWindowNthType(index, objectFootprintHeight);
              stringId2 = simWorld.getObjectStringId(windowNthType);
              flag4 = windowNthType == buildModeOldSetting;
              break;
            case 13:
              int doorNthType = simWorld.getDoorNthType(index);
              stringId2 = simWorld.getObjectStringId(doorNthType);
              flag4 = doorNthType == buildModeOldSetting;
              break;
          }
          g.Begin();
          textManager.drawWrappedStringChunk(g, this.m_stringChunk, stringId2, font2, lineWidth2, x2, y2, 18);
          ++this.m_stringChunk;
          if (flag4)
          {
            textManager.drawString(g, 1078, font3, x2, y3, 18);
          }
          else
          {
            StringBuffer strBuffer2 = textManager.clearStringBuffer();
            textManager.appendMoneyToBuffer(num14);
            textManager.drawString(g, strBuffer2, font3, x2, y3, 18);
          }
          if (packId != -1)
          {
            Image packTag = instance.getPackTag(packId);
            if (packTag != null)
            {
              int num27 = x + width - 12;
              int num28 = y + 42;
              g.drawImage(packTag, (float) num27, (float) num28, 18);
            }
          }
          g.End();
          break;
        }
        if (index == this.m_itemSelected)
        {
          am2d.submitAnimGrid(349, 350, 351, 352, 353, 354, 355, 356, 357, (float) x, (float) y, (float) width, (float) height);
          break;
        }
        am2d.submitAnimGrid(331, 332, 333, 334, 335, 336, 337, 338, 339, (float) x, (float) y, (float) width, (float) height);
        break;
    }
  }

  public int getItemCount()
  {
    return this.m_itemNum;
  }

  public int getItemAt(int xScreen, int yScreen)
  {
    if (!this.isInDragArea(xScreen, yScreen))
      return -1;
    if (this.m_swipeList)
    {
      int num = (int) (((double) (xScreen - this.m_posX) - (double) this.getSwipeOffset()) / (double) this.m_itemW);
      return num >= -1 && num < this.m_itemNum ? num : -1;
    }
    int num1 = (int) (((double) (yScreen - this.m_posY) - (double) this.getScrollOffset()) / (double) this.m_itemH);
    return num1 >= -1 && num1 < this.m_itemNum ? num1 : -1;
  }

  private bool isItemSelectable(int index)
  {
    if (!this.m_enabled)
      return false;
    AppEngine canvas = AppEngine.getCanvas();
    SimData simData = canvas.getSimData();
    SimWorld simWorld = canvas.getSimWorld();
    switch (this.m_listId)
    {
      case 0:
      case 2:
      case 7:
      case 10:
      case 11:
      case 12:
      case 13:
        return true;
      case 5:
        int inventoryNthItem = simData.getInventoryNthItem(index);
        return (simWorld.getItemFlags(inventoryNthItem) & 4) != 0;
      case 6:
        return true;
      default:
        return false;
    }
  }

  private void sendSelect()
  {
    this.getScene().processStringId(this.m_itemSelected);
  }

  public int getSelectedIdx()
  {
    return this.m_itemSelected;
  }

  public void setSelectedIdx(int idx)
  {
    this.m_itemSelected = idx;
    if (!this.m_swipeList || idx < 0)
      return;
    this.setSwipeOffset((float) (-this.m_itemSelected * this.m_itemW));
  }

  public override void update(int timeStep)
  {
    switch (this.m_state)
    {
      case 1:
        this.m_animTimer.updateTimer(timeStep);
        if (!this.m_animTimer.isAnimating())
        {
          this.stateTransition(0);
          if (!this.m_selectPreSend)
          {
            this.sendSelect();
            break;
          }
          break;
        }
        break;
    }
    base.update(timeStep);
  }

  public override void onBeginSwipe()
  {
  }

  public override void onMidSwipe()
  {
    switch (this.m_listId)
    {
      case 0:
        this.m_itemSelected = -this.getSwipeNotch(this.getSwipeOffset());
        break;
      case 1:
        this.m_itemSelected = -this.getSwipeNotch(this.getSwipeOffset());
        this.sendSelect();
        break;
    }
  }

  private int remapGlobalGoalIndex(int index)
  {
    AppEngine canvas = AppEngine.getCanvas();
    int taskCount = canvas.getSimData().getTaskCount();
    int numGoalsDiscovered = canvas.getNumGoalsDiscovered();
    int numGoalsComplete = canvas.getNumGoalsComplete();
    int num1 = 0;
    int num2 = 0;
    for (int dream = 0; dream < taskCount; ++dream)
    {
      if (!canvas.isDreamDiscovered(dream) && index >= numGoalsDiscovered)
        return dream;
      if (canvas.isDreamDiscovered(dream))
      {
        if (canvas.isGoalCompleted(dream))
        {
          if (num1 == index)
            return dream;
          ++num1;
        }
        else
        {
          if (num2 == index - numGoalsComplete && index >= numGoalsComplete)
            return dream;
          ++num2;
        }
      }
    }
    AppEngine.ASSERT(false, "no dreams! (shouldn't happen)");
    return -1;
  }
}
