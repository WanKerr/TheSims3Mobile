// Decompiled with JetBrains decompiler
// Type: XNAMenu
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using midp;

public class XNAMenu
{
  public int FRAME_X;
  public int FRAME_Y;
  public int FRAME_WIDTH;
  public int FRAME_HEIGHT;
  public int HEADER_TXT_X;
  public int HEADER_TXT_Y;
  public int LEADERBOARD_HEADER_X;
  public int LEADERBOARD_HEADER_Y;
  public int LEADERBOARD_HEADER_WIDTH;
  public int LEADERBOARD_HEADER_HEIGHT;
  public int TEXT_AREA_X;
  public int TEXT_AREA_Y;
  public int TEXT_AREA_WIDTH;
  public int TEXT_AREA_HEIGHT;
  public int SCROLLBAR_X;
  public int SCROLLBAR_Y;
  public int SCROLLBAR_WIDTH;
  public int SCROLLBAR_HEIGHT;
  public int BTN_BACK_X;
  public int BTN_BACK_Y;
  public int BTN_BACK_WIDTH;
  public int BTN_BACK_HEIGHT;
  protected AppEngine ae;
  protected XNAMenuRes res;
  protected Scene m_scene;
  protected XNAConnect conn;
  protected TextManager tm;
  protected ScrollText scrollText;
  protected Rectangle textAreaRect;
  protected XNAButton btnBack;

  public XNAButton[] buttons { get; protected set; }

  public XNAMenu(AppEngine engine, XNAMenuRes resources, Scene scene, XNAConnect connect)
  {
    this.ae = engine;
    this.res = resources;
    this.m_scene = scene;
    this.conn = connect;
  }

  public virtual void init()
  {
    this.FRAME_WIDTH = this.res.Frame.getWidth();
    this.FRAME_HEIGHT = this.res.Frame.getHeight();
    this.FRAME_X = this.ae.getWidth() - this.FRAME_WIDTH >> 1;
    this.FRAME_Y = this.ae.getHeight() - this.FRAME_HEIGHT >> 1;
    this.HEADER_TXT_X = this.FRAME_X + (this.FRAME_WIDTH >> 1);
    this.HEADER_TXT_Y = this.FRAME_Y + 37;
    this.LEADERBOARD_HEADER_X = this.FRAME_X + 57;
    this.LEADERBOARD_HEADER_Y = this.FRAME_Y + 56;
    if (this is LeaderboardsMenu)
    {
      this.LEADERBOARD_HEADER_WIDTH = this.res.LeaderboardHeader.getWidth();
      this.LEADERBOARD_HEADER_HEIGHT = this.res.LeaderboardHeader.getHeight();
    }
    this.TEXT_AREA_X = this.FRAME_X + 57;
    this.TEXT_AREA_Y = this.LEADERBOARD_HEADER_Y + this.LEADERBOARD_HEADER_HEIGHT;
    if (this is LeaderboardsMenu)
    {
      this.TEXT_AREA_WIDTH = this.res.ScrollFieldSM.getWidth();
      this.TEXT_AREA_HEIGHT = this.res.ScrollFieldSM.getHeight();
    }
    else
    {
      this.TEXT_AREA_WIDTH = this.res.ScrollFieldLG.getWidth();
      this.TEXT_AREA_HEIGHT = this.res.ScrollFieldLG.getHeight();
    }
    this.textAreaRect = new Rectangle(this.TEXT_AREA_X, this.TEXT_AREA_Y, this.TEXT_AREA_WIDTH, this.TEXT_AREA_HEIGHT);
    if (this is LeaderboardsMenu)
    {
      this.SCROLLBAR_Y = this.TEXT_AREA_Y + 6;
      this.SCROLLBAR_HEIGHT = 93;
    }
    else
    {
      this.SCROLLBAR_Y = this.TEXT_AREA_Y + 9;
      this.SCROLLBAR_HEIGHT = 142;
    }
    this.SCROLLBAR_X = this.TEXT_AREA_X + 282;
    this.SCROLLBAR_WIDTH = 7;
    this.BTN_BACK_X = this.FRAME_X + 6;
    this.BTN_BACK_Y = this.FRAME_Y + 6;
    this.BTN_BACK_WIDTH = 38;
    this.BTN_BACK_HEIGHT = 38;
    this.tm = this.ae.getTextManager();
    this.btnBack = new XNAButton(this.BTN_BACK_X, this.BTN_BACK_Y, this.BTN_BACK_WIDTH, this.BTN_BACK_HEIGHT, XNAButton.Type.BACK_BTN);
  }

  public virtual void update(int timeStep)
  {
    this.btnBack.update(timeStep);
  }

  public virtual void render(Graphics g)
  {
  }

  protected void drawButtons(Graphics g)
  {
    this.drawButtons(g, 0);
  }

  protected void drawButtons(Graphics g, int top_offset)
  {
    g.Begin();
    this.btnBack.render(g);
    if (this.buttons != null)
    {
      foreach (XNAButton button in this.buttons)
        button.render(g, top_offset);
    }
    g.End();
  }

  public virtual void processInput(int _event, int[] args)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || this.btnBack.handleInput(_event, args) == XNAButton.State.RELEASED)
    {
      if (this.isIngame())
        this.ae.getSceneGame().stateTransitionPauseMenu(0);
      else
        this.ae.getSceneMenu().stateTransition(4);
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed)
        this.m_scene.playSound(20);
    }
    foreach (XNAButton button1 in this.buttons)
    {
      if (button1.handleInput(_event, args) == XNAButton.State.PRESSED)
      {
        foreach (XNAButton button2 in this.buttons)
        {
          if (button2.Equals((object) button1))
          {
            if (!button2.Highlight && (!(this is AchievementsMenu) || _event != 1))
              this.m_scene.playSound(21);
            button2.Highlight = true;
          }
          else
          {
            button2.Highlight = false;
            button2.setState(XNAButton.State.IDLE);
          }
        }
      }
    }
  }

  public bool isIngame()
  {
    return this.ae.getSceneGame() != null && this.ae.getSceneGame().gamePaused();
  }
}
