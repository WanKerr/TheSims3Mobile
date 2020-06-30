// Decompiled with JetBrains decompiler
// Type: sims3.Game1
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Babaroga.Framework.Profiling;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using midp;
using System;
using System.Threading;

namespace sims3
{
    public class TheSims3 : JavaLibGame
    {
        private static bool _isTrialMode = true;
        private bool firstFrame = true;
        private float savedMediaPlayerVolume = MediaPlayer.Volume;
        private float savedGameVolume = MediaPlayer.Volume;
        private MonkeyApp midlet;
        private Texture2D splash;
        private SpriteBatch spriteBatch;
        public static bool exitGame;
        public static RenderTarget2D currentTarget;
        public static RenderTarget2D target;
        private FpsComponent benchmark;

        public static bool IsTrialMode
        {
            get
            {
                return TheSims3._isTrialMode;
            }
            set
            {
                TheSims3._isTrialMode = value;
            }
        }

        public TheSims3()
          : base(533, 320)
        {
            this.Content.RootDirectory = "Content";
            JavaLibGame.GraphicsDeviceManager.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(this.OnPreparingDeviceSettings);
            //this.TargetElapsedTime = new TimeSpan(333333L);
            JavaLib.ServiceProvider = (IServiceProvider)this.Services;
            JavaLib.contentManager = new ContentManager(JavaLib.ServiceProvider, "Content");
        }

        private void OnPreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.RenderTargetUsage = RenderTargetUsage.PreserveContents;
        }

        protected override void Initialize()
        {
            target = new RenderTarget2D(this.GraphicsDevice, 320, 533,false, SurfaceFormat.Bgra32SRgb, DepthFormat.Depth24Stencil8);
            benchmark = new Babaroga.Framework.Profiling.FpsComponent(this, "HelveticaPlain12");
            this.splash = this.Content.Load<Texture2D>("Default");
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            benchmark.LoadContent();
        }

        protected override MIDlet loadMIDlet()
        {
            if (this.midlet == null)
                this.midlet = new MonkeyApp();
            return (MIDlet)this.midlet;
        }

        protected override void Update(GameTime gameTime)
        {
            if (!this.IsActive)
            {
                if (this.midlet == null || this.midlet.m_engine == null || (this.midlet.m_engine.getSceneGame() == null || this.midlet.m_engine.getSceneGame().gamePaused()))
                    return;
                this.midlet.m_engine.getSceneGame().pause();
            }
            else
            {
                if (TheSims3.exitGame || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    this.Exit();

                benchmark.Update(gameTime);
                base.Update(gameTime);

                if (!JavaLibGame.isLoaded)
                {
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed)
                        return;
                    this.Exit();
                }
                else if (this.midlet == null || this.midlet.m_engine == null)
                {
                    this.Exit();
                }
                else
                {
                    AppEngine engine = this.midlet.m_engine;
                    long num = midp.JSystem.currentTimeMillis();
                    int frameTime = midp.JMath.max(1, (int)(num - engine.m_gameThread.timeStartFrame));
                    engine.m_gameThread.timeStartFrame = num;
                    if (engine.m_gameRunning && !engine.m_paused)
                    {
                        engine.m_updateScheduled = true;
                        engine.runLoop(frameTime);
                        engine.m_updateScheduled = false;
                        if ((!engine.m_gameRunning || this.firstFrame) && this.firstFrame)
                            this.midlet.Display.current.orientationChanged(2);
                        this.firstFrame = false;
                    }
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            currentTarget = target;
            this.GraphicsDevice.SetRenderTarget(target);
            this.GraphicsDevice.Clear(Color.Black);

            //if (!this.IsActive)
            //    return;
            if (!JavaLibGame.isLoaded)
            {
                this.spriteBatch.Begin();
                this.spriteBatch.Draw(this.splash, new Rectangle(0, 0, 320, 533), Color.White);
                this.spriteBatch.End();
                base.Draw(gameTime);
            }
            else
            {
                if (this.splash != null)
                    this.splash = (Texture2D)null;
                AppEngine engine = this.midlet.m_engine;
                if (engine.m_gameRunning && !engine.m_paused && (engine.m_gameRunning && !this.firstFrame))
                {
                    engine.m_paintScheduled = true;
                    engine.repaint();
                    engine.serviceRepaints();
                    engine.m_paintScheduled = false;
                }
                base.Draw(gameTime);
            }

            currentTarget = null;
            this.GraphicsDevice.SetRenderTarget(null);
            this.spriteBatch.Begin(SpriteSortMode.Deferred);
            this.spriteBatch.Draw(target, new Rectangle(0, 320, 320, 533), null, Color.White, MathHelper.ToRadians(-90f), new Vector2(), SpriteEffects.None, 0);
            this.spriteBatch.End();

            benchmark.Draw(gameTime);
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            base.OnExiting(sender, args);
        }

        protected override void OnActivated(object sender, EventArgs args)
        {
            base.OnActivated(sender, args);
            this.savedMediaPlayerVolume = MediaPlayer.Volume;
            MediaPlayer.Volume = this.savedGameVolume;
            TheSims3.IsTrialMode = Guide.IsTrialMode;
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            base.OnDeactivated(sender, args);
            this.savedGameVolume = MediaPlayer.Volume;
            MediaPlayer.Volume = this.savedMediaPlayerVolume;
        }
    }
}
