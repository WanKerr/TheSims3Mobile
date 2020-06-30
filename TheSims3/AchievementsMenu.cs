// Decompiled with JetBrains decompiler
// Type: AchievementsMenu
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using midp;

public class AchievementsMenu : XNAMenu
{
  private int y_offset;
  private int prev_y;
  private Rectangle buttonArea;
  private int acceleration;

  public AchievementsMenu(AppEngine ae, XNAMenuRes res, Scene menu, XNAConnect c)
    : base(ae, res, menu, c)
  {
    this.buttons = new XNAButton[18];
  }

  public override void init()
  {
    base.init();
    this.y_offset = 0;
    this.prev_y = 0;
    XNAButton.AC = XNAConnect.getAchievements();
    int h = 40;
    for (int index = 0; index < this.buttons.Length; ++index)
      this.buttons[index] = new XNAButton(this.TEXT_AREA_X, this.TEXT_AREA_Y + h * index, this.TEXT_AREA_WIDTH, h, (XNAButton.Type) (10 + index));
    this.buttonArea = new Rectangle(this.TEXT_AREA_X, this.TEXT_AREA_Y, this.TEXT_AREA_WIDTH, this.TEXT_AREA_HEIGHT);
  }

  public override void update(int timeStep)
  {
    base.update(timeStep);
    foreach (XNAButton button in this.buttons)
      button.update(timeStep);
  }

  public override void render(Graphics g)
  {
    base.render(g);
    g.Begin();
    g.drawImage(this.res.Frame, (float) this.FRAME_X, (float) this.FRAME_Y, 9);
    g.drawImage(this.res.ScrollFieldLG, (float) this.TEXT_AREA_X, (float) this.TEXT_AREA_Y, 9);
    this.tm.drawString(g, 1814, 6, this.HEADER_TXT_X, this.HEADER_TXT_Y, 18);
    g.End();
    float num1 = (float) this.y_offset / (float) (this.buttons[this.buttons.Length - 1].pos.Y + this.buttons[this.buttons.Length - 1].pos.Height - this.TEXT_AREA_HEIGHT - this.buttons[0].pos.Y);
    if ((double) num1 >= 0.0)
    {
      int height = this.res.Scroll.getHeight();
      int num2 = this.SCROLLBAR_Y + (height >> 1);
      int num3 = this.SCROLLBAR_Y + this.SCROLLBAR_HEIGHT - (height >> 1) - num2;
      int num4 = num2 + (int) ((double) num1 * (double) num3);
      g.Begin();
      g.drawImage(this.res.Scroll, new Vector2((float) this.SCROLLBAR_X, (float) num4), 10);
      g.End();
    }
    Rectangle clip = g.getClip();
    g.setClip(320 - this.buttonArea.Height - this.buttonArea.Y, this.buttonArea.X, this.buttonArea.Height, this.buttonArea.Width);
    this.drawButtons(g, this.y_offset);
    g.setClip(clip);
  }

  public override void processInput(int _event, int[] args)
  {
    base.processInput(_event, args);
    int x = args[1];
    int y = args[2];
    foreach (XNAButton button in this.buttons)
    {
      if (button.handleInput(_event, args) == XNAButton.State.RELEASED)
      {
        if (this.isIngame())
          this.ae.getSceneGame().stateTransitionPauseMenu(6);
        else
          this.ae.getSceneMenu().stateTransition(41);
      }
    }
    if (this.buttonArea.Contains(x, y))
    {
      int num = this.prev_y - y;
      if (_event == 1)
      {
        this.y_offset += num;
        this.acceleration = num;
      }
      this.y_offset = System.Math.Max(0, this.y_offset);
      this.y_offset = System.Math.Min(this.y_offset, (this.buttons[1].pos.Y - this.buttons[0].pos.Y) * this.buttons.Length - this.TEXT_AREA_HEIGHT);
      this.prev_y = args[2];
    }
    else
    {
      if (System.Math.Abs(this.acceleration) <= 0)
        return;
      this.acceleration -= this.acceleration / 6;
      if (System.Math.Abs(this.acceleration) < 7)
        this.acceleration = 0;
      this.y_offset += this.acceleration;
      this.y_offset = System.Math.Max(0, this.y_offset);
      this.y_offset = System.Math.Min(this.y_offset, (this.buttons[1].pos.Y - this.buttons[0].pos.Y) * this.buttons.Length - this.TEXT_AREA_HEIGHT);
    }
  }
}
