// Decompiled with JetBrains decompiler
// Type: UIOptionMenu
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class UIOptionMenu : UIScrollable
{
  private AnimTimer m_animTimer = new AnimTimer();
  public const int STATE_IDLE = 0;
  public const int STATE_TRIGGERED = 1;
  public const int STATE_TRIGGERED_ON = 2;
  public const int STATE_TRIGGERED_OFF = 3;
  public const int STATE_TRIGGERED_SELECTED = 4;
  internal const float ITEM_WIDTH = 250f;
  internal const float ITEM_SPACING = 47f;
  private int m_state;
  private int[] m_items;
  private string[] m_itemStrings;
  private int m_cursor;
  private int m_itemsPosX;
  private int m_itemsPosY;

  public UIOptionMenu()
  {
    this.m_state = 0;
    this.m_items = (int[]) null;
    this.m_itemStrings = new string[0];
    this.m_cursor = -1;
    this.m_itemsPosX = 0;
    this.m_itemsPosY = 0;
    this.m_animTimer = new AnimTimer();
  }

  public new void Dispose()
  {
    base.Dispose();
  }

  public override void processInput(int _event, int[] args)
  {
    AppEngine canvas = AppEngine.getCanvas();
    switch (this.m_state)
    {
      case 0:
        base.processInput(_event, args);
        switch (_event)
        {
          case 0:
            int x1 = args[1];
            int y1 = args[2];
            if (!this.isInDragArea(x1, y1))
              return;
            this.m_cursor = this.getItemAt(x1, y1);
            return;
          case 3:
            int x2 = args[1];
            int y2 = args[2];
            int itemAt = this.getItemAt(x2, y2);
            if (itemAt == -1)
              return;
            this.m_cursor = itemAt;
            int num1 = this.m_items[5 + itemAt];
            int num2 = canvas.getRMSOptionState(num1);
            if (this.m_items[1] == 7)
              num2 = itemAt == canvas.getTextManager().getCurrentLanguage() ? 2 : 3;
            switch (num2)
            {
              case -1:
                this.getScene().playSound(21);
                this.stateTransition(1);
                return;
              case 2:
              case 3:
                this.getScene().playSound(19);
                this.stateTransition(4);
                this.getScene().processStringId(num1);
                return;
              default:
                int num3 = (int) ((double) this.m_itemsPosX + 125.0);
                if (x2 > num3)
                {
                  if (num2 != 1)
                    canvas.setRMSOptionState(num1, 1);
                  this.getScene().playSound(19);
                  this.stateTransition(2);
                  return;
                }
                if (x2 >= num3)
                  return;
                if (num1 == 88)
                {
                  if (num2 != 0)
                  {
                    this.getScene().processStringId(num1);
                    return;
                  }
                  this.getScene().playSound(19);
                  this.stateTransition(3);
                  return;
                }
                if (num2 != 0)
                  canvas.setRMSOptionState(num1, 0);
                this.getScene().playSound(19);
                this.stateTransition(3);
                return;
            }
          default:
            return;
        }
    }
  }

  public void setItems(ref int[] items)
  {
    string[] itemStrings = new string[0];
    this.setItems(ref items, ref itemStrings);
  }

  public void setItems(ref int[] items, ref string[] itemStrings)
  {
    this.m_items = items;
    this.m_itemStrings = itemStrings;
    this.m_cursor = -1;
    this.setScrollOffset(0.0f);
    this.resetScrolling(true);
    this.stateTransition(0);
  }

  public int getItemAt(int x, int y)
  {
    return this.isInDragArea(x, y) ? (int) (((double) (y - this.m_itemsPosY) - (double) this.getScrollOffset()) / 36.6666679382324) : -1;
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
        this.m_animTimer.startTimer(0, 16);
        break;
      case 2:
      case 3:
      case 4:
        this.getScene().activateUIElement((UIElement) this);
        this.m_animTimer.startTimer(1, 16);
        break;
    }
  }

  public static void renderOptionsBG(
    Graphics g,
    int x,
    int y,
    int width,
    int height,
    int buttonId)
  {
    AppEngine canvas = AppEngine.getCanvas();
    AnimationManager2D animationManager2D = canvas.getAnimationManager2D();
    animationManager2D.submitAnimGrid(71, 72, 73, 74, 75, 76, 77, 78, 79, (float) x, (float) y, (float) width, (float) height);
    if (buttonId != -1)
    {
      float x1 = (float) x + 23f;
      float y1 = (float) y + 33f;
      animationManager2D.submitAnim(80, x1, y1);
      float num1 = x1 - 5f;
      float num2 = y1 - 5f;
      canvas.getScene().getUIButton(buttonId).submit(ref animationManager2D, (int) num1, (int) num2);
    }
    float x2 = (float) x + 55f;
    float y2 = (float) y + 22f;
    float w = (float) width - 90f;
    float h = (float) height - 50f;
    animationManager2D.submitAnimGrid(102, 103, 104, 105, 106, 107, 108, 109, 110, x2, y2, w, h);
    animationManager2D.flushAnims(g);
  }

  public static void renderOptionsFG(
    Graphics g,
    int x,
    int y,
    int width,
    int height,
    int titleStringId)
  {
    AppEngine canvas = AppEngine.getCanvas();
    TextManager textManager = canvas.getTextManager();
    AnimationManager2D animationManager2D = canvas.getAnimationManager2D();
    float num1 = (float) x + 55f;
    float num2 = (float) y + 22f;
    float num3 = (float) width - 90f;
    float num4 = (float) height - 50f;
    float x1 = num1;
    float y1 = num2;
    float w1 = num3;
    float animHeight1 = animationManager2D.getAnimHeight(113);
    animationManager2D.submitAnimStretched(113, x1, y1, w1, animHeight1);
    float w2 = num3 - 20f;
    float animHeight2 = animationManager2D.getAnimHeight(112);
    float x2 = num1 + (float) (((double) num3 - (double) w2) * 0.5);
    float y2 = num2 + num4 - animHeight2;
    animationManager2D.submitAnimStretched(112, x2, y2, w2, animHeight2);
    animationManager2D.flushAnims(g);
    g.Begin();
    int num5 = 8;
    int x3 = (int) ((double) x1 + (double) w1 * 0.5);
    int y3 = (int) ((double) y1 + (double) animHeight1 * 0.5 - (double) (num5 >> 1));
    textManager.drawString(g, titleStringId, 6, x3, y3, 18);
    g.End();
  }

  public void render(Graphics g)
  {
    this.setup();
    AppEngine canvas = AppEngine.getCanvas();
    TextManager textManager = canvas.getTextManager();
    AnimationManager2D animationManager2D = canvas.getAnimationManager2D();
    float num1 = (float) canvas.getWidth() - 120f;
    float num2 = (float) canvas.getHeight() - 70f;
    float num3 = (float) (((double) canvas.getWidth() - (double) num1) * 0.5);
    float num4 = (float) (((double) canvas.getHeight() - (double) num2) * 0.5);
    UIOptionMenu.renderOptionsBG(g, (int) num3, (int) num4, (int) num1, (int) num2, 2);
    float num5 = num3 + 55f;
    float num6 = num4 + 22f;
    float num7 = num1 - 90f;
    float num8 = num2 - 50f;
    int num9 = this.m_items[0];
    float num10 = num5 + num7 * 0.5f;
    float num11 = 100f;
    float x1 = num10 + num11;
    float x2 = num10 - num11;
    float num12 = 37f;
    float num13 = num8 - num12;
    float num14 = num6 + num8 - num13;
    float w = num7 * 0.9f;
    float animHeight = animationManager2D.getAnimHeight(126);
    float x3 = num10 - w * 0.5f;
    for (int index = 0; index < num9; ++index)
    {
      int @string = this.m_items[5 + index];
      float y1 = (float) ((double) num14 + (double) this.getScrollOffset() + (double) index * 36.6666679382324 + 18.3333339691162);
      if ((double) y1 >= (double) num14 - 18.3333339691162 && (double) y1 <= (double) num14 + (double) num13 + 18.3333339691162)
      {
        int num15 = canvas.getRMSOptionState(@string);
        if (this.m_items[1] == 7)
          num15 = index != canvas.getTextManager().getCurrentLanguage() ? 3 : 2;
        if (num15 != -1)
        {
          int animId1 = 116;
          if (num15 == 1 || num15 == 2)
            animId1 = 114;
          int animId2 = -1;
          switch (num15)
          {
            case 0:
              animId2 = 115;
              break;
            case 1:
              animId2 = 117;
              break;
          }
          float num16 = 1f;
          float num17 = 1f;
          if (index == this.m_cursor)
          {
            if (this.m_state == 2 || this.m_state == 4)
              num16 = this.m_animTimer.getValue();
            else if (this.m_state == 3)
              num17 = this.m_animTimer.getValue();
          }
          animationManager2D.submitAnim(animId1, x1, y1, 1f, num16, num16);
          if (animId2 != -1)
            animationManager2D.submitAnim(animId2, x2, y1, 1f, num17, num17);
        }
        if (index == this.m_cursor && this.m_state == 1)
        {
          double num18 = (double) this.m_animTimer.getValue();
        }
        float y2 = (float) ((double) y1 + 18.3333339691162 - (double) animHeight * 0.5);
        animationManager2D.submitAnimStretched(126, x3, y2, w, animHeight);
      }
    }
    int clipX = g.getClipX();
    int clipY = g.getClipY();
    int clipWidth = g.getClipWidth();
    int clipHeight = g.getClipHeight();
    g.setClip(320 - (int) num14 - (int) num13, clipY, (int) num13, clipHeight);
    animationManager2D.flushAnims(g);
    for (int index = 0; index < num9; ++index)
    {
      float num15 = (float) ((double) num14 + (double) this.getScrollOffset() + (double) index * 36.6666679382324 + 18.3333339691162);
      if ((double) num15 >= (double) num14 - 18.3333339691162 && (double) num15 <= (double) num14 + (double) num13 + 18.3333339691162)
      {
        if (index == this.m_cursor)
        {
          float num16 = 0.5f;
          if (this.m_state == 1)
            num16 = this.m_animTimer.getValue();
          if ((double) num16 < 0.5)
            continue;
        }
        g.Begin();
        if (this.m_itemStrings.Length == 0)
        {
          int strId = this.m_items[5 + index];
          textManager.drawString(g, strId, 4, (int) num10, (int) num15, 18);
        }
        else
        {
          string itemString = this.m_itemStrings[index];
          textManager.drawString(g, itemString, 4, (int) num10, (int) num15, 18);
        }
        g.End();
      }
    }
    g.setClip(clipX, clipY, clipWidth, clipHeight);
    float barHeight = (float) ((double) num8 - (double) num12 - 10.0 - 20.0);
    float barX = (float) ((double) num5 + (double) num7 - 10.0);
    float barY = (float) ((double) num6 + (double) num12 + 10.0 + (double) barHeight * 0.5);
    float num19 = num13;
    float num20 = 36.66667f * (float) num9;
    float num21 = -this.getScrollOffset();
    this.submitScrollbar(ref animationManager2D, (int) num21, (int) num19, (int) num20, barX, barY, barHeight);
    animationManager2D.flushAnims(g);
    UIOptionMenu.renderOptionsFG(g, (int) num3, (int) num4, (int) num1, (int) num2, this.m_items[1]);
    this.setScrollRange((float) -this.m_items[0] * 36.66667f + num13, 0.0f);
    this.setDragArea((int) num5, (int) num14, (int) num7, (int) num13);
    this.m_itemsPosX = (int) num5;
    this.m_itemsPosY = (int) num14;
  }

  public override void update(int timeStep)
  {
    base.update(timeStep);
    switch (this.m_state)
    {
      case 1:
      case 2:
      case 3:
      case 4:
        this.m_animTimer.updateTimer(timeStep);
        if (this.m_animTimer.isAnimating())
          break;
        this.m_items[2] = this.m_cursor;
        int stringId = -1;
        if (this.m_state == 1)
          stringId = this.m_items[5 + this.m_cursor];
        this.m_cursor = -1;
        this.stateTransition(0);
        if (stringId == -1 || stringId == 88)
          break;
        this.getScene().processStringId(stringId);
        break;
    }
  }

  public override void onBeginScroll()
  {
    this.m_cursor = -1;
  }

  public override void onLostInput()
  {
    base.onLostInput();
    if (this.m_state == 0)
      return;
    this.stateTransition(0);
  }
}
