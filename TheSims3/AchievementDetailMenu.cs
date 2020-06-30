// Decompiled with JetBrains decompiler
// Type: AchievementDetailMenu
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using midp;
using System.Linq;

public class AchievementDetailMenu : XNAMenu
{
  private readonly string SPACE = " ";
  private int TEXT_AREA_COVER_X;
  private int TEXT_AREA_COVER_Y;
  private int TEXT_AREA_COVER_WIDTH;
  private int TEXT_AREA_COVER_HEIGHT;
  private int TEXT_X;
  private AchievementsMenu ach_menu;

  protected bool Visible { get; set; }

  public AchievementDetailMenu(
    AppEngine ae,
    XNAMenuRes res,
    AchievementsMenu ach_menu,
    Scene scene,
    XNAConnect c)
    : base(ae, res, scene, c)
  {
    this.ach_menu = ach_menu;
  }

  public override void init()
  {
    base.init();
    this.TEXT_AREA_COVER_X = this.TEXT_AREA_X;
    this.TEXT_AREA_COVER_Y = this.TEXT_AREA_Y;
    this.TEXT_AREA_COVER_WIDTH = this.res.AchievementDetailCover.getWidth();
    this.TEXT_AREA_COVER_HEIGHT = this.TEXT_AREA_HEIGHT;
    this.TEXT_X = this.TEXT_AREA_COVER_X + this.TEXT_AREA_COVER_WIDTH + 1;
    this.Visible = false;
  }

  public override void update(int timeStep)
  {
    base.update(timeStep);
  }

  public override void render(Graphics g)
  {
    base.render(g);
    g.Begin();
    g.drawImage(this.res.Frame, (float) this.FRAME_X, (float) this.FRAME_Y, 9);
    g.drawImage(this.res.ScrollFieldLG, (float) this.TEXT_AREA_X, (float) this.TEXT_AREA_Y, 9);
    g.drawImage(this.res.AchievementDetailCover, (float) this.TEXT_AREA_COVER_X, (float) this.TEXT_AREA_COVER_Y, 9);
    g.drawImage(this.res.AchievementLG, (float) (this.TEXT_AREA_COVER_X + (this.TEXT_AREA_COVER_WIDTH >> 1)), (float) (this.TEXT_AREA_COVER_Y + (this.TEXT_AREA_COVER_HEIGHT >> 1)), 18);
    int index1 = 0;
    for (int index2 = 0; index2 < this.ach_menu.buttons.Length; ++index2)
    {
      if (this.ach_menu.buttons[index2].Highlight)
        index1 = index2;
    }
    Achievement achievement = XNAButton.AC.ElementAt<Achievement>(index1);
    this.tm.drawString(g, 1816, 6, this.HEADER_TXT_X, this.HEADER_TXT_Y, 18);
    string str = this.tm.getString(1817) + this.SPACE + achievement.Name;
    int textAreaY = this.TEXT_AREA_Y;
    this.tm.wrapString(str, 6, this.SCROLLBAR_X - this.TEXT_X - 2);
    this.tm.drawWrappedString(g, 6, this.TEXT_X, textAreaY, 9);
    int y1 = textAreaY + (this.tm.getLineHeight(6) * this.tm.getNumWrappedLines() + 10);
    this.tm.wrapString(this.tm.getString(1818) + this.SPACE + achievement.HowToEarn, 6, this.SCROLLBAR_X - this.TEXT_X - 2);
    this.tm.drawWrappedString(g, 6, this.TEXT_X, y1, 9);
    int y2 = y1 + (this.tm.getLineHeight(6) * this.tm.getNumWrappedLines() + 10);
    this.tm.wrapString(this.tm.getString(1819) + this.SPACE + (object) achievement.GamerScore, 6, this.SCROLLBAR_X - this.TEXT_X - 2);
    this.tm.drawWrappedString(g, 6, this.TEXT_X, y2, 9);
    g.End();
    this.drawButtons(g);
  }

  public override void processInput(int _event, int[] args)
  {
    XNAButton.State state = this.btnBack.handleInput(_event, args);
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed && state != XNAButton.State.RELEASED)
      return;
    if (this.isIngame())
      this.ae.getSceneGame().stateTransitionPauseMenu(5);
    else
      this.ae.getSceneMenu().stateTransition(39);
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
      return;
    this.m_scene.playSound(20);
  }
}
