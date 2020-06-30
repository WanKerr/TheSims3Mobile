// Decompiled with JetBrains decompiler
// Type: XNAButton
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using midp;

public class XNAButton
{
    private const int ANIM_STATE_TIME = 100;
    private static TextManager tm;
    private XNAButton.Type type;
    private XNAButton.State state;
    private Texture2D texture;
    private Texture2D texture_high;
    private int stateTimer;
    private string label;
    private int top_offset;

    public static AchievementCollection AC { get; set; }

    public static Image AchievementLocked { get; private set; }

    public static Image AchievementUnlocked { get; private set; }

    public bool Highlight { get; set; }

    public Rectangle pos { get; private set; }

    public XNAButton(int x, int y, int w, int h, XNAButton.Type t)
    {
        this.pos = new Rectangle(x, y, w, h);
        this.type = t;
        this.state = XNAButton.State.IDLE;
        this.stateTimer = 0;
        this.Highlight = false;
        this.top_offset = 0;
        if (XNAButton.tm == null)
            XNAButton.tm = AppEngine.getCanvas().getTextManager();
        switch (this.type)
        {
            case XNAButton.Type.BACK_BTN:
                this.texture = JavaLib.contentManager.Load<Texture2D>("XNAMenu//back_press");
                break;
            case XNAButton.Type.LEADERBOARD_BTN_1:
            case XNAButton.Type.LEADERBOARD_BTN_2:
            case XNAButton.Type.LEADERBOARD_BTN_3:
            case XNAButton.Type.LEADERBOARD_BTN_4:
            case XNAButton.Type.LEADERBOARD_BTN_5:
            case XNAButton.Type.LEADERBOARD_BTN_6:
            case XNAButton.Type.LEADERBOARD_BTN_7:
            case XNAButton.Type.LEADERBOARD_BTN_8:
            case XNAButton.Type.LEADERBOARD_BTN_9:
                this.texture = JavaLib.contentManager.Load<Texture2D>("XNAMenu//leaderboard_icon_" + (object)(int)this.type);
                this.texture_high = JavaLib.contentManager.Load<Texture2D>("XNAMenu//leaderboard_icon_" + (object)(int)this.type + "_high");
                break;
            case XNAButton.Type.ACHIEVEMENT_BTN_1:
            case XNAButton.Type.ACHIEVEMENT_BTN_2:
            case XNAButton.Type.ACHIEVEMENT_BTN_3:
            case XNAButton.Type.ACHIEVEMENT_BTN_4:
            case XNAButton.Type.ACHIEVEMENT_BTN_5:
            case XNAButton.Type.ACHIEVEMENT_BTN_6:
            case XNAButton.Type.ACHIEVEMENT_BTN_7:
            case XNAButton.Type.ACHIEVEMENT_BTN_8:
            case XNAButton.Type.ACHIEVEMENT_BTN_9:
            case XNAButton.Type.ACHIEVEMENT_BTN_10:
            case XNAButton.Type.ACHIEVEMENT_BTN_11:
            case XNAButton.Type.ACHIEVEMENT_BTN_12:
            case XNAButton.Type.ACHIEVEMENT_BTN_13:
            case XNAButton.Type.ACHIEVEMENT_BTN_14:
            case XNAButton.Type.ACHIEVEMENT_BTN_15:
            case XNAButton.Type.ACHIEVEMENT_BTN_16:
            case XNAButton.Type.ACHIEVEMENT_BTN_17:
            case XNAButton.Type.ACHIEVEMENT_BTN_18:
                this.texture = new Texture2D(JavaLib.GraphicsDevice, w, h);
                Color[] data = new Color[w * h];
                Color color = new Color(100, 100, 100, 30);
                for (int index = 0; index < data.Length; ++index)
                    data[index] = color;
                this.texture.SetData<Color>(data);
                this.label = XNAButton.AC == null ? "Achievment " + (object)(int)(this.type - 10) : XNAButton.AC.ElementAt<Achievement>((int)(this.type - 10)).Name;
                break;
            case XNAButton.Type.UNLOCK_GAME:
                this.texture = JavaLib.contentManager.Load<Texture2D>("XNAMenu//menu_unlock");
                break;
            case XNAButton.Type.UNLOCKFULL_STORE:
            case XNAButton.Type.UNLOCKFULL_BACK:
                this.texture = new Texture2D(JavaLib.GraphicsDevice, w, h);
                this.label = this.type == XNAButton.Type.UNLOCKFULL_BACK ? XNAButton.tm.getString(1880) : XNAButton.tm.getString(1879);
                break;
        }
        if (XNAButton.AchievementLocked != null)
            return;
        XNAButton.AchievementLocked = new Image(JavaLib.contentManager.Load<Texture2D>("XNAMenu//achievement_locked"));
        XNAButton.AchievementUnlocked = new Image(JavaLib.contentManager.Load<Texture2D>("XNAMenu//achievement_unlocked"));
    }

    public void update(int timeStep)
    {
        if (this.isAnimating())
        {
            this.stateTimer += timeStep;
            switch (this.state)
            {
                case XNAButton.State.ANIM_COLOR:
                    if (this.stateTimer <= 100)
                        break;
                    this.state = XNAButton.State.ANIM_GRAY;
                    this.stateTimer = 0;
                    break;
                case XNAButton.State.ANIM_GRAY:
                    if (this.stateTimer <= 100)
                        break;
                    this.state = XNAButton.State.ANIM_DONE;
                    this.stateTimer = 0;
                    break;
                case XNAButton.State.ANIM_DONE:
                    this.state = XNAButton.State.RELEASED;
                    break;
            }
        }
        else
        {
            this.state = XNAButton.State.IDLE;
            this.stateTimer = 0;
        }
    }

    public bool contains(int x, int y)
    {
        return new Rectangle(this.pos.X, this.pos.Y - this.top_offset, this.pos.Width, this.pos.Height).Contains(x, y);
    }

    public XNAButton.State handleInput(int _event, int[] args)
    {
        int x = args[1];
        int y = args[2];
        if (this.contains(x, y) || this.isAnimating())
        {
            switch (_event)
            {
                case 0:
                case 1:
                    this.state = XNAButton.State.PRESSED;
                    break;
                case 2:
                    if (this.type < XNAButton.Type.ACHIEVEMENT_BTN_1 || this.type > XNAButton.Type.ACHIEVEMENT_BTN_18)
                    {
                        this.state = XNAButton.State.ANIM_COLOR;
                        this.stateTimer = 0;
                        break;
                    }
                    break;
                case 3:
                    if (this.type >= XNAButton.Type.ACHIEVEMENT_BTN_1 && this.type <= XNAButton.Type.ACHIEVEMENT_BTN_18)
                    {
                        this.state = XNAButton.State.ANIM_COLOR;
                        this.stateTimer = 0;
                        break;
                    }
                    break;
            }
        }
        else if (_event == 1 && !this.contains(x, y) && !this.isAnimating())
            this.state = XNAButton.State.IDLE;
        return this.state;
    }

    public bool isAnimating()
    {
        return this.state == XNAButton.State.ANIM_COLOR || this.state == XNAButton.State.ANIM_GRAY || this.state == XNAButton.State.ANIM_DONE;
    }

    public void setState(XNAButton.State newState)
    {
        this.state = newState;
    }

    public void render(midp.Graphics g)
    {
        this.render(g, 0);
    }

    public void render(midp.Graphics g, int top_offset)
    {
        this.top_offset = top_offset;
        switch (this.type)
        {
            case XNAButton.Type.BACK_BTN:
            case XNAButton.Type.UNLOCK_GAME:
                Color color1 = Color.White;
                if (this.state == XNAButton.State.PRESSED || this.state == XNAButton.State.ANIM_GRAY)
                    color1 = Color.Gray;
                g.spriteBatch.Draw(this.texture, new Rectangle(this.pos.X, this.pos.Y - top_offset, this.pos.Width, this.pos.Height), color1);
                break;
            case XNAButton.Type.LEADERBOARD_BTN_1:
            case XNAButton.Type.LEADERBOARD_BTN_2:
            case XNAButton.Type.LEADERBOARD_BTN_3:
            case XNAButton.Type.LEADERBOARD_BTN_4:
            case XNAButton.Type.LEADERBOARD_BTN_5:
            case XNAButton.Type.LEADERBOARD_BTN_6:
            case XNAButton.Type.LEADERBOARD_BTN_7:
            case XNAButton.Type.LEADERBOARD_BTN_8:
            case XNAButton.Type.LEADERBOARD_BTN_9:
                Color color2 = Color.White;
                if (this.state == XNAButton.State.PRESSED || this.state == XNAButton.State.ANIM_GRAY)
                    color2 = Color.Gray;
                if (this.Highlight)
                {
                    g.spriteBatch.Draw(this.texture_high, new Rectangle(this.pos.X, this.pos.Y - top_offset, this.pos.Width, this.pos.Height), color2);
                    break;
                }
                g.spriteBatch.Draw(this.texture, new Rectangle(this.pos.X, this.pos.Y - top_offset, this.pos.Width, this.pos.Height), color2);
                break;
            case XNAButton.Type.ACHIEVEMENT_BTN_1:
            case XNAButton.Type.ACHIEVEMENT_BTN_2:
            case XNAButton.Type.ACHIEVEMENT_BTN_3:
            case XNAButton.Type.ACHIEVEMENT_BTN_4:
            case XNAButton.Type.ACHIEVEMENT_BTN_5:
            case XNAButton.Type.ACHIEVEMENT_BTN_6:
            case XNAButton.Type.ACHIEVEMENT_BTN_7:
            case XNAButton.Type.ACHIEVEMENT_BTN_8:
            case XNAButton.Type.ACHIEVEMENT_BTN_9:
            case XNAButton.Type.ACHIEVEMENT_BTN_10:
            case XNAButton.Type.ACHIEVEMENT_BTN_11:
            case XNAButton.Type.ACHIEVEMENT_BTN_12:
            case XNAButton.Type.ACHIEVEMENT_BTN_13:
            case XNAButton.Type.ACHIEVEMENT_BTN_14:
            case XNAButton.Type.ACHIEVEMENT_BTN_15:
            case XNAButton.Type.ACHIEVEMENT_BTN_16:
            case XNAButton.Type.ACHIEVEMENT_BTN_17:
            case XNAButton.Type.ACHIEVEMENT_BTN_18:
                Color color3 = Color.Black;
                if (this.state == XNAButton.State.PRESSED || this.state == XNAButton.State.ANIM_GRAY)
                    color3 = Color.Gray;
                g.spriteBatch.Draw(this.texture, new Rectangle(this.pos.X, this.pos.Y - top_offset, this.pos.Width, this.pos.Height), color3);
                XNAButton.tm.drawString(g, this.label, 6, this.pos.X + 5, this.pos.Y + (this.pos.Height >> 1) - top_offset, 10);
                if (XNAButton.AC == null)
                    break;
                Achievement achievement = XNAButton.AC.ElementAt<Achievement>((int)(this.type - 10));
                g.drawImage(achievement.IsEarned ? XNAButton.AchievementUnlocked : XNAButton.AchievementLocked, (float)(this.pos.X + this.pos.Width - 70), (float)(this.pos.Y + (this.pos.Height >> 1) - top_offset), 10);
                break;
            case XNAButton.Type.UNLOCKFULL_STORE:
            case XNAButton.Type.UNLOCKFULL_BACK:
                Color color4 = Color.White;
                if (this.state == XNAButton.State.PRESSED || this.state == XNAButton.State.ANIM_GRAY)
                    color4 = Color.Gray;
                g.spriteBatch.Draw(this.texture, new Rectangle(this.pos.X, this.pos.Y, this.pos.Width, this.pos.Height), color4);
                XNAButton.tm.drawString(g, this.label, 6, this.pos.X + (this.pos.Width >> 1), this.pos.Y + (this.pos.Height >> 1), 18);
                break;
        }
    }

    public enum State
    {
        PRESSED,
        ANIM_COLOR,
        ANIM_GRAY,
        ANIM_DONE,
        RELEASED,
        IDLE,
    }

    public enum Type
    {
        BACK_BTN,
        LEADERBOARD_BTN_1,
        LEADERBOARD_BTN_2,
        LEADERBOARD_BTN_3,
        LEADERBOARD_BTN_4,
        LEADERBOARD_BTN_5,
        LEADERBOARD_BTN_6,
        LEADERBOARD_BTN_7,
        LEADERBOARD_BTN_8,
        LEADERBOARD_BTN_9,
        ACHIEVEMENT_BTN_1,
        ACHIEVEMENT_BTN_2,
        ACHIEVEMENT_BTN_3,
        ACHIEVEMENT_BTN_4,
        ACHIEVEMENT_BTN_5,
        ACHIEVEMENT_BTN_6,
        ACHIEVEMENT_BTN_7,
        ACHIEVEMENT_BTN_8,
        ACHIEVEMENT_BTN_9,
        ACHIEVEMENT_BTN_10,
        ACHIEVEMENT_BTN_11,
        ACHIEVEMENT_BTN_12,
        ACHIEVEMENT_BTN_13,
        ACHIEVEMENT_BTN_14,
        ACHIEVEMENT_BTN_15,
        ACHIEVEMENT_BTN_16,
        ACHIEVEMENT_BTN_17,
        ACHIEVEMENT_BTN_18,
        UNLOCK_GAME,
        UNLOCKFULL_STORE,
        UNLOCKFULL_BACK,
    }
}
