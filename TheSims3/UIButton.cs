// Decompiled with JetBrains decompiler
// Type: UIButton
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

public class UIButton : UIElement
{
  private AnimTimer m_animTimer = new AnimTimer();
  private const int STATE_IDLE = 0;
  private const int STATE_PRESSED = 1;
  private const int STATE_PRESSED_POINTEROFF = 2;
  private const int STATE_TRIGGERED = 3;
  private const int FLAG_SUPRESS_FORGROUND_ON_HIGHLIGHT = 1;
  private int m_state;
  private int m_pointerNum;
  private int m_posX;
  private int m_posY;
  private int m_radius;
  private int m_commandId;
  private int m_flags;
  private int m_animBackground;
  private int m_animForeground;
  private int m_animForegroundDisabled;
  private float m_foregroundScaleX;
  private float m_foregroundScaleY;
  private int m_animHighlight;
  private float m_highlightScale;
  private float m_highlightAlpha;
  private float m_highlightOffsetX;
  private float m_highlightOffsetY;
  private int m_soundId;

  public UIButton(int commandId)
  {
    this.m_state = 0;
    this.m_pointerNum = -1;
    this.m_posX = 0;
    this.m_posY = 0;
    this.m_radius = 35;
    this.m_animTimer = new AnimTimer();
    this.m_commandId = commandId;
    this.m_flags = 0;
    this.m_animBackground = -1;
    this.m_animForeground = -1;
    this.m_animForegroundDisabled = -1;
    this.m_foregroundScaleX = 1f;
    this.m_foregroundScaleY = 1f;
    this.m_animHighlight = -1;
    this.m_highlightScale = 1f;
    this.m_highlightAlpha = 0.5f;
    this.m_highlightOffsetX = 0.0f;
    this.m_highlightOffsetY = 0.0f;
    this.m_soundId = -1;
    switch (commandId)
    {
      case 1:
        this.m_animForeground = 381;
        this.m_animForegroundDisabled = 381;
        this.m_soundId = 18;
        break;
      case 2:
        this.m_animBackground = 119;
        this.m_animForeground = 123;
        this.m_animForegroundDisabled = 123;
        this.m_soundId = 20;
        break;
      case 4:
      case 524288:
        this.m_animBackground = 119;
        this.m_animForeground = 122;
        this.m_animForegroundDisabled = 122;
        this.m_soundId = 20;
        break;
      case 8:
      case 32:
        this.m_animBackground = 118;
        this.m_animForeground = 125;
        this.m_animForegroundDisabled = 125;
        this.m_soundId = 21;
        break;
      case 16:
        this.m_animBackground = 119;
        this.m_animForeground = 122;
        this.m_soundId = 20;
        break;
      case 64:
        this.m_animBackground = 121;
        this.m_animForeground = 124;
        this.m_animForegroundDisabled = 124;
        this.m_soundId = 20;
        break;
      case 128:
        this.m_soundId = 20;
        break;
      case 256:
        this.m_animForeground = 196;
        this.m_animForegroundDisabled = 197;
        this.m_soundId = 21;
        break;
      case 512:
        this.m_animForeground = 193;
        this.m_animForegroundDisabled = 195;
        this.m_soundId = 21;
        break;
      case 1024:
        this.m_animForeground = 192;
        this.m_animForegroundDisabled = 194;
        this.m_soundId = 21;
        break;
      case 2048:
        this.m_animForeground = 162;
        this.m_animForegroundDisabled = 162;
        this.m_soundId = 21;
        break;
      case 4096:
        this.m_animBackground = 121;
        this.m_animForeground = 122;
        this.m_animForegroundDisabled = 122;
        this.m_soundId = 20;
        break;
      case 8192:
        this.m_animBackground = 118;
        this.m_animForeground = 125;
        this.m_animForegroundDisabled = 125;
        this.m_soundId = 21;
        break;
      case 16384:
        this.m_animForeground = 198;
        this.m_soundId = 21;
        break;
      case 32768:
        this.m_highlightScale = 1.35f;
        this.m_animForeground = 441;
        this.m_soundId = 21;
        break;
      case 65536:
        this.m_highlightScale = 1.35f;
        this.m_animForeground = 317;
        this.m_soundId = 21;
        break;
      case 131072:
        this.m_highlightScale = 1.35f;
        this.m_animForeground = 318;
        this.m_soundId = 21;
        break;
      case 262144:
        this.m_highlightScale = 1.35f;
        this.m_animForeground = 319;
        this.m_soundId = 21;
        break;
      case 1048576:
        this.m_animForeground = 178;
        this.m_soundId = 18;
        break;
      case 2097152:
        this.m_animForeground = 163;
        this.m_animForegroundDisabled = 163;
        this.m_soundId = 21;
        this.m_highlightScale = 1.35f;
        this.m_highlightOffsetX = -2f;
        this.m_highlightOffsetY = -3f;
        this.m_radius = 50;
        break;
      case 4194304:
        this.m_flags |= 1;
        this.m_animForeground = 247;
        this.m_animForegroundDisabled = 247;
        this.m_animHighlight = 248;
        this.m_highlightAlpha = 1f;
        this.m_soundId = 21;
        this.m_radius = 50;
        break;
      case 8388608:
        this.m_animForeground = 246;
        this.m_soundId = 21;
        break;
      case 16777216:
        this.m_animForeground = 25;
        this.m_animBackground = 27;
        this.m_soundId = 21;
        break;
      case 33554432:
        this.m_animForeground = 26;
        this.m_animBackground = 27;
        this.m_soundId = 21;
        break;
      case 67108864:
        this.m_animBackground = 118;
        this.m_animForeground = 123;
        this.m_foregroundScaleX = -1f;
        this.m_soundId = 21;
        break;
      case 134217728:
        this.m_animBackground = 119;
        this.m_animForeground = 123;
        this.m_soundId = 21;
        break;
      case 268435456:
        this.m_animForeground = 245;
        this.m_soundId = 21;
        break;
    }
  }

  public new void Dispose()
  {
    base.Dispose();
  }

  public int getPosX()
  {
    return this.m_posX;
  }

  public int getPosY()
  {
    return this.m_posY;
  }

  public void submit(ref AnimationManager2D am2d, int x, int y)
  {
    this.submit(ref am2d, x, y, true);
  }

  public void submit(ref AnimationManager2D am2d, int x, int y, bool enabled)
  {
    if (enabled)
      this.setup();
    this.m_posX = x;
    this.m_posY = y;
    bool flag = this.m_state == 1 || this.m_state == 3 && (double) this.m_animTimer.getValue() > 0.5;
    if (this.m_animBackground != -1)
      am2d.submitAnim(this.m_animBackground, (float) x, (float) y);
    if (enabled)
    {
      if (this.m_animForeground != -1 && ((this.m_flags & 1) == 0 || !flag))
        am2d.submitAnim(this.m_animForeground, (float) x, (float) y, 1f, this.m_foregroundScaleX, this.m_foregroundScaleY);
    }
    else if (this.m_animForegroundDisabled != -1)
      am2d.submitAnim(this.m_animForegroundDisabled, (float) x, (float) y, 1f, this.m_foregroundScaleX, this.m_foregroundScaleY);
    if (!flag)
      return;
    int animId = this.m_animHighlight;
    if (animId == -1)
      animId = 120;
    am2d.submitAnim(animId, (float) x + this.m_highlightOffsetX, (float) y + this.m_highlightOffsetY, this.m_highlightAlpha, this.m_highlightScale, this.m_highlightScale);
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
      case 2:
        this.getScene().activateUIElement((UIElement) this);
        break;
      case 3:
        this.getScene().activateUIElement((UIElement) this);
        this.m_animTimer.startTimer(0, 16);
        break;
    }
  }

  public override void update(int timeStep)
  {
    if (this.m_state != 3)
      return;
    this.m_animTimer.updateTimer(timeStep);
    if (this.m_animTimer.isAnimating())
      return;
    this.stateTransition(0);
    this.getScene().processCommand(this.m_commandId);
  }

  public override void processInput(int _event, int[] args)
  {
    if (_event != 0 && _event != 1 && _event != 2)
      return;
    int num = args[0];
    int x = args[1];
    int y = args[2];
    switch (this.m_state)
    {
      case 0:
        if (_event != 0 || !UIElement.isInRadius(x, y, this.m_posX, this.m_posY, this.m_radius))
          break;
        this.m_pointerNum = num;
        this.stateTransition(1);
        break;
      case 1:
      case 2:
        if (_event != 1 && _event != 2 || num != this.m_pointerNum)
          break;
        switch (_event)
        {
          case 1:
            int newState = UIElement.isInRadius(x, y, this.m_posX, this.m_posY, this.m_radius) ? 1 : 2;
            if (this.m_state == newState)
              return;
            this.stateTransition(newState);
            return;
          case 2:
            if (this.m_state == 1)
            {
              if (this.m_soundId != -1)
                this.getScene().playSound(this.m_soundId);
              this.stateTransition(3);
              return;
            }
            if (this.m_state != 2)
              return;
            this.stateTransition(0);
            return;
          default:
            return;
        }
    }
  }
}
