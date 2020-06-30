// Decompiled with JetBrains decompiler
// Type: LeaderboardsMenu
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using midp;

public class LeaderboardsMenu : XNAMenu
{
  private readonly string[] WINDOWS_LEADERBOARD = new string[16]
  {
    "Gamer 1",
    "Gamer 2",
    "Gamer 3",
    "Gamer 4",
    "Gamer 5",
    "Gamer 6",
    "Gamer 7",
    "Gamer 8",
    "Gamer 9",
    "Gamer 10",
    "Gamer 11",
    "Gamer 12",
    "Gamer 13",
    "Gamer 14",
    "Gamer 15",
    "Gamer 16"
  };
  private const int LEADERBOARD_BTN_1 = 0;
  private const int LEADERBOARD_BTN_2 = 1;
  private const int LEADERBOARD_BTN_3 = 2;
  private const int LEADERBOARD_BTN_4 = 3;
  private const int LEADERBOARD_BTN_5 = 4;
  private const int LEADERBOARD_BTN_6 = 5;
  private const int NUM_BUTTONS = 6;
  private const int LEADERBOARD_BTN_7 = 6;
  private const int LEADERBOARD_BTN_8 = 7;
  private const int NUM_SORT_BUTTONS = 2;
  public const int SORT_LIFETIME = 0;
  public const int SORT_RECENT = 1;
  public const int LEADERBOARD_NAME_Y = 134;
  private int currLeaderboardID;
  private int currSortID;
  private XNAButton[] sortButtons;

  public LeaderboardsMenu(AppEngine ae, XNAMenuRes res, Scene scene, XNAConnect c)
    : base(ae, res, scene, c)
  {
    this.buttons = new XNAButton[6];
    this.sortButtons = new XNAButton[2];
  }

  public override void init()
  {
    base.init();
    int num = this.LEADERBOARD_HEADER_X + 2;
    int y = this.LEADERBOARD_HEADER_Y + 7;
    for (int index = 0; index < 6; ++index)
      this.buttons[index] = new XNAButton(num + 32 * index, y, 30, 30, (XNAButton.Type) (1 + index));
    int x = this.LEADERBOARD_HEADER_X + this.LEADERBOARD_HEADER_WIDTH - 2 - 30;
    for (int index = 0; index < 2; ++index)
    {
      this.sortButtons[index] = new XNAButton(x, y, 30, 30, (XNAButton.Type) (7 + index));
      x -= 32;
    }
    this.currLeaderboardID = 0;
    this.buttons[this.currLeaderboardID].Highlight = true;
    this.sortButtons[this.currSortID].Highlight = true;
    this.setLeaderboardText(this.currLeaderboardID);
  }

  private void setLeaderboardText(int leaderboardID)
  {
    LeaderboardKey key = LeaderboardKey.BestScoreLifeTime;
    if (this.currSortID == 1)
      key = LeaderboardKey.BestScoreRecent;
    if (!Scene.IsScoreLeaderboard(leaderboardID))
    {
      key = LeaderboardKey.BestTimeLifeTime;
      if (this.currSortID == 1)
        key = LeaderboardKey.BestTimeRecent;
    }
    this.scrollText = (ScrollText) null;
    this.conn.readLeaderboard(leaderboardID, key);
  }

  public override void update(int timeStep)
  {
    base.update(timeStep);
    foreach (XNAButton button in this.buttons)
      button.update(timeStep);
    foreach (XNAButton sortButton in this.sortButtons)
      sortButton.update(timeStep);
    if (!this.buttons[this.currLeaderboardID].Highlight)
    {
      for (int index = 0; index < this.buttons.Length; ++index)
      {
        if (this.buttons[index].Highlight)
        {
          this.currLeaderboardID = index;
          this.setLeaderboardText(this.currLeaderboardID);
          break;
        }
      }
    }
    if (this.sortButtons[this.currSortID].Highlight)
      return;
    for (int index = 0; index < this.sortButtons.Length; ++index)
    {
      if (this.sortButtons[index].Highlight)
      {
        this.currSortID = index;
        this.setLeaderboardText(this.currLeaderboardID);
        break;
      }
    }
  }

  public override void render(Graphics g)
  {
    base.render(g);
    g.Begin();
    g.drawImage(this.res.Frame, (float) this.FRAME_X, (float) this.FRAME_Y, 9);
    g.drawImage(this.res.LeaderboardHeader, (float) this.LEADERBOARD_HEADER_X, (float) this.LEADERBOARD_HEADER_Y, 9);
    g.drawImage(this.res.ScrollFieldSM, (float) this.TEXT_AREA_X, (float) this.TEXT_AREA_Y, 9);
    this.tm.drawString(g, 1815, 6, this.HEADER_TXT_X, this.HEADER_TXT_Y, 18);
    g.End();
    LeaderboardEntry[] leaderboardEntryArray = this.conn.LeaderboardsRead != null ? this.conn.LeaderboardsRead.Entries : (LeaderboardEntry[]) null;
    if (leaderboardEntryArray != null && this.scrollText == null)
    {
      string[] text = new string[leaderboardEntryArray.Length];
      string[] scores = new string[leaderboardEntryArray.Length];
      for (int index = 0; index < leaderboardEntryArray.Length; ++index)
      {
        text[index] = leaderboardEntryArray[index].Gamer.Gamertag;
        if (Scene.IsScoreLeaderboard(this.currLeaderboardID))
        {
          scores[index] = leaderboardEntryArray[index].Columns.GetValueInt32("BestScore").ToString();
        }
        else
        {
          long valueInt64 = leaderboardEntryArray[index].Columns.GetValueInt32("CumulativeTime");
          int num = 0;
          string str = num.ToString();
          if (num < 10)
            str = "0" + str;
          scores[index] = valueInt64.ToString() + ":" + str;
        }
      }
      this.scrollText = new ScrollText(6, text, scores, this.TEXT_AREA_X + 10, this.TEXT_AREA_Y, this.SCROLLBAR_X - this.TEXT_AREA_X - 20, this.TEXT_AREA_HEIGHT, 8);
    }
    this.drawButtons(g);
    g.Begin();
    if (this.sortButtons != null)
    {
      foreach (XNAButton sortButton in this.sortButtons)
        sortButton.render(g);
    }
    this.tm.drawString(g, 1825 + this.currLeaderboardID, 5, this.TEXT_AREA_X + 10, 134, 9);
    this.tm.drawString(g, this.currSortID == 0 ? 1833 : 1831, 5, this.TEXT_AREA_X + this.TEXT_AREA_WIDTH - 3, 134, 33);
    g.End();
    if (this.scrollText == null)
      return;
    this.scrollText.draw(g);
    float cursorProgression = this.scrollText.getCursorProgression();
    if ((double) cursorProgression < 0.0)
      return;
    int height = this.res.Scroll.getHeight();
    int num1 = this.SCROLLBAR_Y + (height >> 1);
    int num2 = this.SCROLLBAR_Y + this.SCROLLBAR_HEIGHT - (height >> 1) - num1;
    int num3 = num1 + (int) ((double) cursorProgression * (double) num2);
    g.Begin();
    g.drawImage(this.res.Scroll, new Vector2((float) this.SCROLLBAR_X, (float) num3), 10);
    g.End();
  }

  public override void processInput(int _event, int[] args)
  {
    base.processInput(_event, args);
    int x = args[1];
    int y = args[2];
    if (this.scrollText != null && (this.textAreaRect.Contains(x, y) && _event == 1 || _event != 1))
      this.scrollText.handleInput(_event, args);
    foreach (XNAButton sortButton1 in this.sortButtons)
    {
      if (sortButton1.handleInput(_event, args) == XNAButton.State.PRESSED)
      {
        foreach (XNAButton sortButton2 in this.sortButtons)
        {
          if (sortButton2.Equals((object) sortButton1))
          {
            if (!sortButton2.Highlight)
              this.m_scene.playSound(21);
            sortButton2.Highlight = true;
          }
          else
          {
            sortButton2.Highlight = false;
            sortButton2.setState(XNAButton.State.IDLE);
          }
        }
      }
    }
  }
}
