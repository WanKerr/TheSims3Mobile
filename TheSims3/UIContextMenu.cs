// Decompiled with JetBrains decompiler
// Type: UIContextMenu
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class UIContextMenu : UIScrollable
{
  private AnimTimer m_animTimer = new AnimTimer();
  internal const float CONTEXT_X = 255f;
  internal const float CONTEXT_Y = 138f;
  internal const float ARC_CENTER_X = 115f;
  internal const float ARC_RADIUS = 155f;
  internal const float ITEMS_RANGE_Y_MAX = 220f;
  internal const int ITEMS_NUM_MAX = 7;
  internal const float ITEM_SPACING = 36.66667f;
  internal const float ITEM_WIDTH = 200f;
  private const int STATE_IDLE = 0;
  private const int STATE_TRIGGERED = 1;
  private int m_state;
  private int[] m_items;
  private int[] m_actions;
  private int m_commandId;

  public override void processInput(int _event, int[] args)
  {
    switch (this.m_state)
    {
      case 0:
        base.processInput(_event, args);
        switch (_event)
        {
          case 0:
            int x = args[1];
            int y = args[2];
            if (!this.isInDragArea(x, y))
              return;
            int num1 = (int) (((double) y - 138.0 - (double) this.getScrollOffset() + 18.3333339691162) / 36.6666679382324);
            if (num1 < 0 || num1 >= this.m_items[0])
              return;
            this.m_items[2] = num1;
            return;
          case 3:
            int num2 = this.m_items[2];
            if (num2 == -1)
              return;
            int action = this.m_actions[5 + num2];
            int eventId = 21;
            if (action == -2)
              eventId = 22;
            this.getScene().playSound(eventId);
            this.stateTransition(1);
            return;
          default:
            return;
        }
    }
  }

  public UIContextMenu()
  {
    this.m_state = 0;
    this.m_items = (int[]) null;
    this.m_actions = (int[]) null;
    this.m_commandId = -1;
    this.m_animTimer = new AnimTimer();
  }

  public new void Dispose()
  {
    base.Dispose();
  }

  public void setItems(ref int[] items, ref int[] actions, int commandId)
  {
    this.m_items = items;
    this.m_actions = actions;
    this.m_commandId = commandId;
    this.m_items[2] = -1;
    this.m_actions[2] = -1;
    float num1 = 36.66667f * (float) (this.m_items[0] - 1);
    float num2 = midp.JMath.max((float) (-(double) num1 * 0.5), -110f);
    float min = midp.JMath.min((float) (-(double) num1 + 110.0), num2);
    float max = midp.JMath.max(-110f, num2);
    this.setScrollOffset(num2);
    this.setScrollRange(min, max);
    this.resetScrolling(true);
    this.stateTransition(0);
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
    }
  }

  public void render(Graphics g)
  {
    this.setup();
    AppEngine canvas = AppEngine.getCanvas();
    TextManager textManager = canvas.getTextManager();
    AnimationManager2D animationManager2D = canvas.getAnimationManager2D();
    int num1 = this.m_items[0];
    float num2 = -132f;
    float num3 = -110f;
    float num4 = 110f;
    float num5 = 132f;
    for (int index = 0; index < num1; ++index)
    {
      float num6 = this.getScrollOffset() + (float) index * 36.66667f;
      if ((double) num6 >= (double) num2 && (double) num6 <= (double) num5)
      {
        float num7 = 1f;
        if ((double) num6 > (double) num4)
          num7 = (float) (1.0 - ((double) num6 - (double) num4) / ((double) num5 - (double) num4));
        else if ((double) num6 < (double) num3)
          num7 = (float) (1.0 - ((double) num6 - (double) num3) / ((double) num2 - (double) num3));
        float x = (float) (115.0 + (double) ((float) System.Math.Cos(System.Math.Asin((double) num6 / 155.0)) * 155f) + 100.0);
        float y = 138f + num6;
        animationManager2D.submitAnimHBar(287, 288, 289, x, y, 200f, num7, num7);
      }
    }
    float x1 = 77f;
    float y1 = 40f;
    animationManager2D.submitAnim(296, x1, y1);
    float x2 = x1 + 87f;
    float y2 = y1 - 11f;
    animationManager2D.submitAnim(297, x2, y2, 1f, 2f, 1f);
    float x3 = x1 + 145f;
    float y3 = y1 - 8f;
    animationManager2D.submitAnim(298, x3, y3);
    float x4 = x1 + 180f;
    float y4 = y1 + 88f;
    animationManager2D.submitAnim(299, x4, y4);
    float num8 = x1 - 1f;
    float num9 = y1 + 2f;
    this.getScene().getUIButton(this.m_commandId).submit(ref animationManager2D, (int) num8, (int) num9);
    float num10 = this.getScrollRangeMax() - this.getScrollRangeMin();
    float num11 = this.getScrollRangeMax() - this.getScrollOffset();
    float num12;
    float num13;
    if ((double) num10 != 0.0)
    {
      num12 = 0.6801548f;
      num13 = (float) ((1.36030960083008 - (double) num12 * 1.13329994678497) * (double) num11 / (double) num10 - 0.581194639205933);
    }
    else
    {
      num12 = 1.36031f;
      num13 = -37f * (float) System.Math.PI / 200f;
    }
    float num14 = 135f;
    float num15 = 136f;
    float num16 = 138f;
    float num17 = num12 / 7f;
    for (int index = 0; index < 7; ++index)
    {
      int num6 = index == 0 ? 0 : (index == 1 ? 6 : index - 1);
      float radians = num13 + num17 * (float) num6;
      float degrees = MathExt.radiansToDegrees(radians);
      float num7 = (float) System.Math.Cos((double) radians) * num16;
      float num18 = (float) System.Math.Sin((double) radians) * num16;
      float x5 = num14 + num7;
      float y5 = num15 + num18;
      int animId = 304;
      if (index == 0 || index == 1)
        animId = 302;
      animationManager2D.submitAnim(animId, x5, y5, 1f, 1f, 1f, -degrees);
    }
    int num19 = 253;
    int num20 = 137;
    int animHeight = (int) animationManager2D.getAnimHeight(300);
    int num21 = num20 - (animHeight >> 1);
    int num22 = num20 + (animHeight >> 1) - 1;
    animationManager2D.submitAnim(300, (float) num19, (float) num21, 1f, 1f, -1f);
    animationManager2D.submitAnim(301, (float) num19, (float) num22);
    for (int index = 0; index < num1; ++index)
    {
      float num6 = this.getScrollOffset() + (float) index * 36.66667f;
      if ((double) num6 >= (double) num2 && (double) num6 <= (double) num5)
      {
        float num7 = 1f;
        if ((double) num6 > (double) num4)
          num7 = (float) (1.0 - ((double) num6 - (double) num4) / ((double) num5 - (double) num4));
        else if ((double) num6 < (double) num3)
          num7 = (float) (1.0 - ((double) num6 - (double) num3) / ((double) num2 - (double) num3));
        float x5 = (float) (115.0 + (double) ((float) System.Math.Cos(System.Math.Asin((double) num6 / 155.0)) * 155f) + 100.0);
        float y5 = 138f + num6;
        animationManager2D.submitAnimHBar(290, 291, 292, x5, y5, 200f, num7, num7);
        if (index == this.m_items[2])
        {
          float num18 = 0.5f;
          if (this.m_animTimer.isAnimating())
            num18 = this.m_animTimer.getValue();
          animationManager2D.submitAnimHBar(293, 294, 295, x5, y5, 200f, num18 * num7, num7);
        }
      }
    }
    animationManager2D.flushAnims(g);
    g.Begin();
    int x6 = 160;
    int y6 = 30;
    int stringId = this.m_items[1];
    MapObject contextMenuObject = canvas.getSceneGame().getContextMenuObject();
    if (contextMenuObject != null)
    {
      stringId = contextMenuObject.getTypeString();
      if (contextMenuObject.getType() == 0)
      {
        string simName = canvas.getSimName();
        textManager.drawString(g, simName, 4, x6, y6, 18);
        stringId = -1;
      }
    }
    if (stringId != -1)
    {
      textManager.wrapStringChunk(0, stringId, 4, 116);
      textManager.drawWrappedStringChunk(g, 0, 4, x6, y6, 18);
    }
    g.End();
    for (int index1 = 0; index1 < num1; ++index1)
    {
      float num6 = this.getScrollOffset() + (float) index1 * 36.66667f;
      if ((double) num6 >= (double) num2 && (double) num6 <= (double) num5)
      {
        float num7 = 1f;
        if ((double) num6 > (double) num4)
          num7 = (float) (1.0 - ((double) num6 - (double) num4) / ((double) num5 - (double) num4));
        else if ((double) num6 < (double) num3)
          num7 = (float) (1.0 - ((double) num6 - (double) num3) / ((double) num2 - (double) num3));
        if ((double) num7 > 0.5)
        {
          float num18 = 115f + (float) System.Math.Cos(System.Math.Asin((double) num6 / 155.0)) * 155f;
          float num23 = 138f + num6;
          int index2 = 5 + index1;
          int x5 = (int) ((double) num18 + 100.0);
          int y5 = (int) num23;
          int strId = this.m_items[index2];
          g.Begin();
          textManager.drawString(g, strId, 4, x5, y5, 18);
          if (index2 < this.m_actions.Length)
          {
            int action = this.m_actions[index2];
            int actionPackId = canvas.getSimData().getActionPackId(action);
            if (actionPackId != -1)
            {
              Image packTag = DLCManager.getInstance().getPackTag(actionPackId);
              if (packTag != null)
              {
                int num24 = x5 + 90;
                int num25 = y5 - 10;
                g.drawImage(packTag, (float) num24, (float) num25, 18);
              }
            }
          }
          g.End();
        }
      }
    }
    animationManager2D.flushAnims(g);
    this.setDragArea((int) byte.MaxValue, 0, 200, 320);
  }

  public override void update(int timeStep)
  {
    base.update(timeStep);
    switch (this.m_state)
    {
      case 1:
        this.m_animTimer.updateTimer(timeStep);
        if (this.m_animTimer.isAnimating())
          break;
        this.stateTransition(0);
        this.getScene().processCommand(8);
        break;
    }
  }

  public override void onBeginScroll()
  {
    this.m_items[2] = -1;
  }

  public override void onLostInput()
  {
    base.onLostInput();
    if (this.m_state == 0)
      return;
    this.stateTransition(0);
  }
}
