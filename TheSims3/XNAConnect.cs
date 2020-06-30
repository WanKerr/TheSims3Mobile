// Decompiled with JetBrains decompiler
// Type: XNAConnect
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

//using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using midp;
using sims3;
using System;
using System.Collections.Generic;
using System.Linq;

public class XNAConnect
{
    private static bool guideVisible = false;
    private static SignedInGamer gamer;

    public XNAConnect()
    {
        SignedInGamer.SignedIn += new EventHandler<SignedInEventArgs>(this.GamerSignedInCallback);
    }

    public void writeToLeaderboard(
      int leaderboardID,
      int score,
      TimeSpan time,
      bool win,
      LeaderboardKey key)
    {
        SignedInGamer gamer = XNAConnect.getGamer();
        if (gamer == null)
            return;
        if (TheSims3.IsTrialMode)
            return;
        try
        {
            //LeaderboardIdentity leaderboardId = LeaderboardIdentity.Create(key, leaderboardID);
            //LeaderboardEntry leaderboard = gamer.LeaderboardWriter.GetLeaderboard(leaderboardId);
            //leaderboard.Rating = !Scene.IsScoreLeaderboard(leaderboardID) ? (long) time.TotalMinutes : (long) score;
            //leaderboard.Columns.SetValue("Outcome", win ? LeaderboardOutcome.Win : LeaderboardOutcome.Loss);
        }
        //catch (GameUpdateRequiredException ex)
        //{
        //    XNAConnect.PromptForUpdate();
        //}
        catch (Exception ex)
        {
        }
    }

    public XNAConnect.LeaderboardResult LeaderboardsRead { get; set; }

    private void LeaderboardCallback(IAsyncResult result)
    {
        SignedInGamer asyncState = result.AsyncState as SignedInGamer;
        try
        {
            if (asyncState == null)
                return;
            //this.LeaderboardsRead.Read(LeaderboardReader.EndRead(result));
        }
        //catch (GameUpdateRequiredException ex)
        //{
        //    XNAConnect.PromptForUpdate();
        //}
        catch (Exception ex)
        {
            XNAConnect.NotifyConnectionLost();
            this.LeaderboardsRead = (XNAConnect.LeaderboardResult)null;
        }
    }

    public void readLeaderboard(int leaderboardID, LeaderboardKey key)
    {
        this.LeaderboardsRead = (XNAConnect.LeaderboardResult)null;
        if (TheSims3.IsTrialMode)
            return;
        SignedInGamer gamer = XNAConnect.getGamer();
        if (gamer == null)
            return;
        LeaderboardIdentity leaderboardIdentity = LeaderboardIdentity.Create(key, leaderboardID);
        this.LeaderboardsRead = new XNAConnect.LeaderboardResult(leaderboardIdentity);
        try
        {
            //LeaderboardReader.BeginRead(leaderboardIdentity, (Gamer)gamer, 20, new AsyncCallback(this.LeaderboardCallback), (object)gamer);
        }
        //catch (GameUpdateRequiredException ex)
        //{
        //    XNAConnect.PromptForUpdate();
        //}
        catch (Exception ex)
        {
            XNAConnect.NotifyConnectionLost();
        }
    }

    public static AchievementCollection getAchievements()
    {
        SignedInGamer gamer = XNAConnect.getGamer();
        if (gamer == null)
            return (AchievementCollection)null;
        AchievementCollection achievementCollection = (AchievementCollection)null;
        try
        {
            achievementCollection = gamer.GetAchievements();
        }
        //catch (GameUpdateRequiredException ex)
        //{
        //    XNAConnect.PromptForUpdate();
        //}
        catch (Exception ex)
        {
        }
        return achievementCollection;
    }

    public void awardAchievement(string achievementKey)
    {
        if (TheSims3.IsTrialMode)
            return;
        SignedInGamer gamer = XNAConnect.getGamer();
        if (gamer == null)
            return;
        try
        {
            gamer.AwardAchievement(achievementKey);
        }
        //catch (GameUpdateRequiredException ex)
        //{
        //    XNAConnect.PromptForUpdate();
        //}
        catch (Exception ex)
        {
        }
    }

    protected void GamerSignedInCallback(object sender, SignedInEventArgs args)
    {
        //if (args.Gamer.IsSignedInToLive)
        //  XNAConnect.gamer = args.Gamer;
        TheSims3.IsTrialMode = Guide.IsTrialMode;
    }

    public static SignedInGamer getGamer()
    {
        return XNAConnect.gamer;
    }

    public static void PromptForUpdate()
    {
        JavaLibGame.GSC.Enabled = false;
        if (XNAConnect.guideVisible || Guide.IsVisible)
            return;
        XNAConnect.guideVisible = true;
        Guide.BeginShowMessageBox(LocaleManager.getInstance().getString(1881), LocaleManager.getInstance().getString(1882), (IEnumerable<string>)new List<string>()
    {
      LocaleManager.getInstance().getString(32),
      LocaleManager.getInstance().getString(31)
    }, 1, MessageBoxIcon.Alert, new AsyncCallback(XNAConnect.MessageBoxFinished), (object)null);
    }

    protected static void MessageBoxFinished(IAsyncResult result)
    {
        int? nullable = Guide.EndShowMessageBox(result);
        ref int? local = ref nullable;
        int valueOrDefault = local.GetValueOrDefault();
        if (local.HasValue)
        {
            switch (valueOrDefault)
            {
                case 1:
                    do
                        ;
                    while (Guide.IsVisible);
                    TheSims3.IsTrialMode = Guide.IsTrialMode;
                    if (TheSims3.IsTrialMode)
                    {
                        Guide.ShowMarketplace(PlayerIndex.One);
                        break;
                    }
                    //MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();
                    //marketplaceDetailTask.set_ContentType((MarketplaceContentType) 1);
                    //marketplaceDetailTask.Show();
                    break;
            }
        }
        XNAConnect.guideVisible = false;
    }

    public static void NotifyConnectionLost()
    {
        if (XNAConnect.guideVisible || Guide.IsVisible)
            return;
        XNAConnect.guideVisible = true;
        Guide.BeginShowMessageBox(LocaleManager.getInstance().getString(1884), LocaleManager.getInstance().getString(1884), (IEnumerable<string>)new List<string>()
    {
      LocaleManager.getInstance().getString(27)
    }, 0, MessageBoxIcon.Error, new AsyncCallback(XNAConnect.MessageBoxFinished), (object)null);
    }

    public class LeaderboardResult
    {
        public LeaderboardIdentity Identity { get; private set; }

        public LeaderboardEntry[] Entries { get; private set; }

        public LeaderboardResult(LeaderboardIdentity identity)
        {
            this.Identity = identity;
        }

        public bool Read(LeaderboardReader reader)
        {
            //if (reader.LeaderboardIdentity.GameMode != this.Identity.GameMode)
            //  return false;
            //this.Entries = reader.Entries.ToArray<LeaderboardEntry>();
            //return true;

            return false;
        }
    }
}
