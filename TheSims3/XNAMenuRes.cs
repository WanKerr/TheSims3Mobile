// Decompiled with JetBrains decompiler
// Type: XNAMenuRes
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework.Graphics;
using midp;

public class XNAMenuRes
{
  public Image LeaderboardHeader { get; private set; }

  public Image Frame { get; private set; }

  public Image Scroll { get; private set; }

  public Image ScrollFieldLG { get; private set; }

  public Image ScrollFieldSM { get; private set; }

  public Image AchievementLG { get; private set; }

  public Image AchievementDetailCover { get; private set; }

  public void load()
  {
    this.LeaderboardHeader = new Image(JavaLib.contentManager.Load<Texture2D>("XNAMenu//leaderboard_menu"));
    this.Frame = new Image(JavaLib.contentManager.Load<Texture2D>("XNAMenu//menu_cutout"));
    this.Scroll = new Image(JavaLib.contentManager.Load<Texture2D>("XNAMenu//scroll"));
    this.ScrollFieldLG = new Image(JavaLib.contentManager.Load<Texture2D>("XNAMenu//scrollfield_lg"));
    this.ScrollFieldSM = new Image(JavaLib.contentManager.Load<Texture2D>("XNAMenu//scrollfield_sm"));
    this.AchievementLG = new Image(JavaLib.contentManager.Load<Texture2D>("XNAMenu//achievement_lg"));
    this.AchievementDetailCover = new Image(JavaLib.contentManager.Load<Texture2D>("XNAMenu//menu_achievement"));
  }
}
