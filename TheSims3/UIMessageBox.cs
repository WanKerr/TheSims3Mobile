// Decompiled with JetBrains decompiler
// Type: UIMessageBox
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using midp;
using System;
using System.IO;

public class UIMessageBox : UIScrollable
{
  private AnimTimer m_animTimer = new AnimTimer();
  internal const int MESSAGE_WIDTH = 200;
  internal const int TEXT_HEIGHT_MAX = 200;
  internal const int OPTIONS_POPUP_WIDTH = 500;
  internal const int OPTIONS_WIDTH = 410;
  private const int STATE_POPUP = 0;
  private const int STATE_IDLE = 1;
  public const int TYPE_NULL = 0;
  public const int TYPE_MESSAGE_SINGLE = 1;
  public const int TYPE_MESSAGE_DOUBLE = 2;
  public const int TYPE_OPTIONS_SINGLE = 3;
  public const int TYPE_BOX = 4;
  private int m_state;
  private int m_type;
  private int m_messageStringId;
  private int m_titleStringId;
  private int m_messagePanelId;
  private int m_commandTop;
  private int m_commandLeft;
  private int m_commandRight;
  private int m_popupWidth;
  private int m_contentWidth;
  private int m_contentHeight;
  private int m_contentHeightVisible;

  public override void processInput(int _event, int[] args)
  {
    switch (this.m_state)
    {
      case 1:
        base.processInput(_event, args);
        break;
    }
  }

  public UIMessageBox()
  {
    this.m_state = 1;
    this.m_type = 0;
    this.m_animTimer = new AnimTimer();
    this.m_messageStringId = -1;
    this.m_titleStringId = -1;
    this.m_messagePanelId = -1;
    this.m_commandTop = -1;
    this.m_commandLeft = -1;
    this.m_commandRight = -1;
    this.m_popupWidth = 0;
    this.m_contentWidth = 0;
    this.m_contentHeight = 0;
    this.m_contentHeightVisible = 0;
  }

  public new void Dispose()
  {
    base.Dispose();
  }

  public void stateTransition(int newState)
  {
    this.m_state = newState;
    switch (newState)
    {
      case 0:
        this.m_animTimer.startTimer(2, 16);
        break;
    }
  }

  public void setMessage(int messageStringId, int titleStringId, int commandTop)
  {
    AnimationManager2D animationManager2D = AppEngine.getCanvas().getAnimationManager2D();
    this.m_type = 1;
    this.m_titleStringId = titleStringId;
    this.m_messagePanelId = -1;
    this.m_commandTop = commandTop;
    this.m_commandLeft = -1;
    this.m_commandRight = -1;
    this.m_popupWidth = (int) animationManager2D.getAnimWidth(96);
    this.m_contentWidth = 200;
    this.setWrappedString(messageStringId, false);
    this.stateTransition(0);
  }

  public void setMessage(
    int messageStringId,
    int titleStringId,
    int commandLeft,
    int commandRight)
  {
    AnimationManager2D animationManager2D = AppEngine.getCanvas().getAnimationManager2D();
    this.m_type = 2;
    this.m_titleStringId = titleStringId;
    this.m_messagePanelId = -1;
    this.m_commandTop = -1;
    this.m_commandLeft = commandLeft;
    this.m_commandRight = commandRight;
    this.m_popupWidth = (int) animationManager2D.getAnimWidth(96);
    this.m_contentWidth = 200;
    this.setWrappedString(messageStringId, false);
    this.stateTransition(0);
  }

  public void setMessageScrollable(int messageStringId, int titleStringId, int commandTop)
  {
    AnimationManager2D animationManager2D = AppEngine.getCanvas().getAnimationManager2D();
    this.m_type = 1;
    this.m_titleStringId = titleStringId;
    this.m_messagePanelId = -1;
    this.m_commandTop = commandTop;
    this.m_commandLeft = -1;
    this.m_commandRight = -1;
    this.m_popupWidth = (int) animationManager2D.getAnimWidth(96);
    this.m_contentWidth = 200;
    this.setWrappedString(messageStringId, true);
    this.stateTransition(0);
  }

  public void setMessageCustom(
    int messageStringId,
    int titleStringId,
    int commandTop,
    int commandLeft,
    int commandRight,
    int type)
  {
    AnimationManager2D animationManager2D = AppEngine.getCanvas().getAnimationManager2D();
    this.m_type = type;
    this.m_titleStringId = titleStringId;
    this.m_messagePanelId = -1;
    this.m_commandTop = commandTop;
    this.m_commandLeft = commandLeft;
    this.m_commandRight = commandRight;
    if (type == 3)
    {
      this.m_popupWidth = 500;
      this.m_contentWidth = 410;
    }
    else
    {
      this.m_popupWidth = (int) animationManager2D.getAnimWidth(96);
      this.m_contentWidth = 200;
    }
    this.setWrappedString(messageStringId, false);
    this.stateTransition(0);
  }

  public void renderCustom(Graphics g, int panelId)
  {
    if (panelId != this.m_messagePanelId)
    {
      this.m_messagePanelId = panelId;
      this.m_contentHeight = this.getScene().getUIPanelHeight(panelId, this.m_contentWidth, 200);
      this.m_contentHeightVisible = this.m_contentHeight;
    }
    this.render(g);
  }

  public void render(Graphics g)
  {
    this.setup();
    AppEngine canvas = AppEngine.getCanvas();
    TextManager textManager = canvas.getTextManager();
    AnimationManager2D animationManager2D = canvas.getAnimationManager2D();
    bool enabled = this.m_state == 1;
    int num1 = 0;
    int num2 = 0;
    switch (this.m_type)
    {
      case 1:
        num1 = 70;
        num2 = 30;
        break;
      case 2:
        num1 = 60;
        num2 = 75;
        break;
      case 3:
        num1 = 70;
        num2 = 19;
        break;
      case 4:
        num1 = 20;
        num2 = 20;
        break;
    }
    float popupWidth = (float) this.m_popupWidth;
    float h = (float) (this.m_contentHeightVisible + num1 + num2);
    float halfWidth = (float) canvas.getHalfWidth();
    float x1 = halfWidth - (float) (((double) popupWidth - 8.0) * 0.5);
    float y1 = (float) canvas.getHalfHeight() - h * 0.5f;
    if (this.m_state == 0)
    {
      float valueLinear = this.m_animTimer.getValueLinear();
      float valuePopup = this.m_animTimer.getValuePopup();
      animationManager2D.setGlobalAlpha(valueLinear);
      animationManager2D.setGlobalScale(x1 + popupWidth * 0.5f, y1 + h * 0.5f, valuePopup, valuePopup);
    }
    switch (this.m_type)
    {
      case 1:
        animationManager2D.submitAnimGrid(87, 88, 89, 90, 91, 92, 93, 94, 95, x1, y1, popupWidth, h, 1f);
        float x2 = x1 + 10f;
        float y2 = y1 + 26f;
        animationManager2D.submitAnim(99, x2, y2);
        float num3 = x2 - 3f;
        float num4 = y2 - 3f;
        this.getScene().getUIButton(this.m_commandTop).submit(ref animationManager2D, (int) num3, (int) num4, enabled);
        break;
      case 2:
        float x3 = x1 + popupWidth * 0.5f;
        float y3 = y1 + h * 0.5f;
        animationManager2D.submitAnimVBar(96, 97, 98, x3, y3, h);
        int x4 = (int) ((double) x1 + (double) popupWidth * 0.5 - 52.0);
        int y4 = (int) ((double) y1 + (double) h - 36.0);
        this.getScene().getUIButton(this.m_commandLeft).submit(ref animationManager2D, x4, y4, enabled);
        int x5 = (int) ((double) x1 + (double) popupWidth * 0.5 + 44.0);
        int y5 = (int) ((double) y1 + (double) h - 36.0);
        this.getScene().getUIButton(this.m_commandRight).submit(ref animationManager2D, x5, y5, enabled);
        float x6 = x1 + 7f;
        float y6 = y1 + 11f;
        float w1 = popupWidth - 22f;
        float animHeight1 = animationManager2D.getAnimHeight(113);
        animationManager2D.submitAnimStretched(113, x6, y6, w1, animHeight1);
        break;
      case 3:
        UIOptionMenu.renderOptionsBG(g, (int) x1, (int) y1, (int) popupWidth, (int) h, this.m_commandTop);
        break;
    }
    if (this.m_contentHeight > this.m_contentHeightVisible)
    {
      float barHeight = (float) this.m_contentHeightVisible - 10f;
      float barX = (float) ((double) x1 + (double) popupWidth - 32.0);
      float barY = (float) ((double) y1 + (double) num1 + (double) barHeight * 0.5);
      float contentHeightVisible = (float) this.m_contentHeightVisible;
      float contentHeight = (float) this.m_contentHeight;
      float num5 = -this.getScrollOffset();
      this.submitScrollbar(ref animationManager2D, (int) num5, (int) contentHeightVisible, (int) contentHeight, barX, barY, barHeight);
    }
    animationManager2D.flushAnims(g);
    animationManager2D.resetGlobal();
    if (this.m_state != 1)
      return;
    g.Begin();
    if (this.m_type == 1 || this.m_type == 2)
    {
      int x7 = (int) halfWidth;
      int y7 = (int) ((double) y1 + (double) num1 * 0.5);
      textManager.drawString(g, this.m_titleStringId, 6, x7, y7, 18);
    }
    int x8 = (int) ((double) halfWidth - (double) (this.m_contentWidth >> 1));
    int y8 = (int) ((double) y1 + (double) num1);
    int num6 = 0;
    int num7 = 0;
    if (this.m_type == 3)
    {
      x8 = (int) ((double) x1 + 55.0);
      y8 = (int) ((double) y1 + 59.0);
      num6 = 0;
      num7 = 8;
    }
    else if (this.m_type == 1 || this.m_type == 2)
    {
      num6 = 11;
      num7 = 18;
    }
    int num8 = this.m_contentHeightVisible + num6 + num7;
    int y9 = y8 - num6;
    g.End();
    if (this.m_messagePanelId == -1)
    {
      int clipX = g.getClipX();
      int clipY = g.getClipY();
      int clipWidth = g.getClipWidth();
      int clipHeight = g.getClipHeight();
      int x7 = x8 + (this.m_contentWidth >> 1);
      int y7 = (int) ((double) y8 + (double) this.getScrollOffset());
      g.setClip(320 - y9 - num8, clipY, num8, clipHeight);
      g.Begin();
      textManager.drawWrappedString(g, 3, x7, y7, 17);
      g.End();
      g.setClip(clipX, clipY, clipWidth, clipHeight);
    }
    else
      this.getScene().drawUIPanel(g, this.m_messagePanelId, x8, y8, this.m_contentWidth, this.m_contentHeightVisible);
    this.setDragArea(x8, y9, this.m_contentWidth, num8);
    switch (this.m_type)
    {
      case 1:
        float w2 = popupWidth * 0.8f;
        float animHeight2 = animationManager2D.getAnimHeight((int) sbyte.MaxValue);
        float x9 = halfWidth - w2 * 0.5f;
        float y10 = (float) ((double) y1 + (double) num1 - (double) animHeight2 - 5.0);
        animationManager2D.submitAnimStretched((int) sbyte.MaxValue, x9, y10, w2, animHeight2);
        if (this.m_contentHeight != this.m_contentHeightVisible)
        {
          float w3 = popupWidth - 35f;
          float animHeight3 = animationManager2D.getAnimHeight(101);
          float x7 = (float) ((double) x1 + (double) popupWidth * 0.5 - (double) w3 * 0.5 - 8.0);
          float y7 = (float) ((double) y1 + (double) h - (double) animHeight3 * 0.5 - 20.0);
          animationManager2D.submitAnimStretched(101, x7, y7, w3, animHeight3);
        }
        animationManager2D.flushAnims(g);
        break;
      case 3:
        int titleStringId = this.m_state == 1 ? this.m_titleStringId : -1;
        UIOptionMenu.renderOptionsFG(g, (int) x1, (int) y1, (int) popupWidth, (int) h, titleStringId);
        break;
    }
  }

  public int getTitleStringId()
  {
    return this.m_titleStringId;
  }

  public override void update(int timeStep)
  {
    switch (this.m_state)
    {
      case 0:
        this.m_animTimer.updateTimer(timeStep);
        if (this.m_animTimer.isAnimating())
          break;
        this.stateTransition(1);
        break;
      case 1:
        base.update(timeStep);
        break;
    }
  }

  public void setWrappedString(int messageStringId, bool scrollable)
  {
    this.m_messageStringId = messageStringId;
    TextManager textManager = AppEngine.getCanvas().getTextManager();
    if (messageStringId == 79)
    {
      string string1 = GlobalConstants.VERSION_STRING;
      try
      {
        using (Stream stream = TitleContainer.OpenStream("version.txt"))
        {
          using (StreamReader streamReader = new StreamReader(stream))
          {
            string1 = streamReader.ReadLine();
            streamReader.Close();
          }
          stream.Close();
        }
      }
      catch (Exception ex)
      {
      }
      textManager.dynamicString(-11, messageStringId, string1);
      textManager.wrapString(-11, 3, this.m_contentWidth);
    }
    else
      textManager.wrapString(messageStringId, 3, this.m_contentWidth);
    int num1 = textManager.getNumWrappedLines() * textManager.getLineHeight(3);
    this.m_contentHeight = num1;
    this.m_contentHeightVisible = MathExt.clip(num1, 50, 200);
    if (scrollable && this.m_contentHeight > this.m_contentHeightVisible)
    {
      this.resetScrolling(true);
      this.setScrollRange((float) -(this.m_contentHeight - this.m_contentHeightVisible), 0.0f);
      this.setScrollOffset(0.0f);
    }
    else
    {
      this.resetScrolling(false);
      float num2 = (float) (this.m_contentHeightVisible - this.m_contentHeight >> 1);
      this.setScrollRange(num2, num2);
      this.setScrollOffset(num2);
    }
  }
}
