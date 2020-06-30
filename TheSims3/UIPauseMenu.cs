// Decompiled with JetBrains decompiler
// Type: UIPauseMenu
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class UIPauseMenu : UIElement
{
  private AnimTimer m_animTimer = new AnimTimer();
  internal const float ITEM_WIDTH = 250f;
  internal const float ITEM_SPACING = 36.66667f;
  internal const float MAX_BG_TIMER = 8000f;
  private const int STATE_IDLE = 0;
  private const int STATE_TRIGGERED = 1;
  private int m_state;
  private bool m_enabled;
  private bool m_showBack;
  private int m_posX;
  private int m_posY;
  private int m_width;
  private int m_height;
  private int[] m_items;
  private int m_storeBGTimer;

  public override void processInput(int _event, int[] args)
  {
    if (!this.m_enabled)
      return;
    switch (this.m_state)
    {
      case 0:
        switch (_event)
        {
          case 0:
            int x1 = args[1];
            int y1 = args[2];
            if (!UIElement.isInBox(x1, y1, this.m_posX, this.m_posY, this.m_width, this.m_height))
              return;
            this.m_items[2] = (int) ((double) (y1 - this.m_posY) / 36.6666679382324);
            return;
          case 3:
            int x2 = args[1];
            int y2 = args[2];
            if (!UIElement.isInBox(x2, y2, this.m_posX, this.m_posY, this.m_width, this.m_height))
              return;
            this.m_items[2] = (int) ((double) (y2 - this.m_posY) / 36.6666679382324);
            this.getScene().playSound(21);
            this.stateTransition(1);
            return;
          case 4:
            this.m_items[2] = -1;
            return;
          default:
            return;
        }
    }
  }

  public UIPauseMenu()
  {
    this.m_state = 0;
    this.m_enabled = true;
    this.m_showBack = true;
    this.m_posX = 0;
    this.m_posY = 0;
    this.m_width = 0;
    this.m_height = 0;
    this.m_items = (int[]) null;
    this.m_animTimer = new AnimTimer();
    this.m_storeBGTimer = 0;
  }

  public new void Dispose()
  {
    base.Dispose();
  }

  public void setItems(ref int[] items, bool showBack)
  {
    this.m_showBack = showBack;
    this.m_items = items;
    items[2] = -1;
    this.stateTransition(0);
  }

  public void setItems(ref int[] items)
  {
    this.setItems(ref items, true);
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

  public void render(Graphics g, bool mainMenu)
  {
    this.render(g, mainMenu, true);
  }

  public void render(Graphics g)
  {
    this.render(g, false, true);
  }

  public void render(Graphics g, bool mainMenu, bool enabled)
  {
    this.setup();
    this.m_enabled = enabled;
    Scene scene = AppEngine.getCanvas().getScene();
    bool flag = scene.getSceneID() == 1;
    AppEngine canvas = AppEngine.getCanvas();
    TextManager textManager = canvas.getTextManager();
    AnimationManager2D animationManager2D = canvas.getAnimationManager2D();
    float w = (float) canvas.getWidth() - 80f;
    float h = (float) canvas.getHeight() - (mainMenu ? 10f : 30f);
    float x1 = (float) (((double) canvas.getWidth() - (double) w) * 0.5);
    float y1 = (float) (((double) canvas.getHeight() - (double) h) * 0.5 + 10.0);
    float alpha1 = flag ? 0.6f : 1f;
    animationManager2D.submitAnimGrid(71, 72, 73, 74, 75, 76, 77, 78, 79, x1, y1, w, h, alpha1);
    if (this.m_showBack)
    {
      float x2 = x1 + 23f;
      float y2 = y1 + 33f;
      animationManager2D.submitAnim(80, x2, y2);
      float num1 = x2 - 5f;
      float num2 = y2 - 5f;
      this.getScene().getUIButton(2).submit(ref animationManager2D, (int) num1, (int) num2);
    }
    float x3 = (float) ((double) x1 + (double) w + (mainMenu ? -23.0 : -18.0));
    float y3 = y1 + (mainMenu ? 50f : 28f);
    animationManager2D.submitAnim(530, x3, y3);
    int num3 = (int) ((double) x3 - 39.0);
    int num4 = (int) y3;
    int theTheTheTheAnim = scene.getTheTheTheTheAnim();
    animationManager2D.submitAnim(theTheTheTheAnim, (float) num3, (float) num4, 1f, 0.4f, 0.4f);
    int num5 = this.m_items[0];
    float x4 = (float) ((double) x1 + (double) w * 0.5 + (mainMenu ? -75.0 : 0.0));
    float num6 = (float) ((double) y1 - 4.0 + ((double) h - (double) (num5 - 1) * 36.6666679382324) * 0.5);
    for (int index = 0; index < num5; ++index)
    {
      float y2 = num6 + (float) index * 36.66667f;
      animationManager2D.submitAnimHBar(81, 82, 83, x4, y2, 200f, 1f);
      if (index == this.m_items[2])
      {
        float alpha2 = 0.5f;
        if (this.m_state == 1)
          alpha2 = this.m_animTimer.getValue();
        animationManager2D.submitAnimHBar(84, 85, 86, x4, y2, 200f, alpha2);
      }
    }
    if (mainMenu)
    {
      float num1 = (float) ((double) x1 + (double) w * 0.5 + 112.0);
      float num2 = y1 + 105f;
      scene.getUIButton(2097152).submit(ref animationManager2D, (int) num1, (int) num2, this.m_enabled);
      animationManager2D.flushAnims(g);
      g.Begin();
      int y2 = (int) ((double) num2 + 42.0);
      textManager.drawString(g, 39, 5, (int) num1, y2, 18);
      g.End();
    }
    else
      animationManager2D.flushAnims(g);
    for (int index = 0; index < num5; ++index)
    {
      int y2 = (int) ((double) num6 + (double) index * 36.6666679382324);
      int strId = this.m_items[5 + index];
      g.Begin();
      textManager.drawString(g, strId, 4, (int) x4, y2, 18);
      g.End();
      if (strId == 52)
      {
        animationManager2D.submitAnim(164, (float) ((double) x4 + 35.0 - 100.0), (float) (y2 - 2));
        animationManager2D.submitAnim(164, (float) ((double) x4 - 35.0 + 100.0), (float) (y2 - 2));
      }
    }
    this.m_posX = (int) ((double) x4 - 120.000007629395);
    this.m_posY = (int) ((double) num6 - 18.3333339691162);
    this.m_width = 240;
    this.m_height = (int) (36.6666679382324 * (double) num5);
    animationManager2D.flushAnims(g);
  }

  public override void update(int timeStep)
  {
    if (!this.m_enabled)
      return;
    this.m_storeBGTimer += timeStep;
    if ((double) this.m_storeBGTimer >= 8000.0)
      this.m_storeBGTimer -= 8000;
    switch (this.m_state)
    {
      case 1:
        this.m_animTimer.updateTimer(timeStep);
        if (this.m_animTimer.isAnimating())
          break;
        int stringId = this.m_items[5 + this.m_items[2]];
        this.m_items[2] = -1;
        this.stateTransition(0);
        this.getScene().processStringId(stringId);
        break;
    }
  }
}
