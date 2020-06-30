// Decompiled with JetBrains decompiler
// Type: midp.JavaLibGame
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using System;
using System.Threading;

namespace midp
{
    public abstract class JavaLibGame : Game
    {
        private JavaLib javalib;
        private System.Threading.Thread loadThread;
        public static bool isLoaded;

        public static GraphicsDeviceManager GraphicsDeviceManager { get; private set; }

        public static GamerServicesComponent GSC { get; private set; }

        public JavaLibGame(int width, int height)
        {
            JavaLibGame.GraphicsDeviceManager = new GraphicsDeviceManager((Game)this);
            JavaLibGame.GraphicsDeviceManager.PreferredBackBufferWidth = width;
            JavaLibGame.GraphicsDeviceManager.PreferredBackBufferHeight = height;
            Guide.IsScreenSaverEnabled = false;
            //JavaLibGame.GraphicsDeviceManager.IsFullScreen = true;
        }

        public void MyCallbackFunction()
        {
            this.javalib = new JavaLib((Game)this, JavaLibGame.GraphicsDeviceManager.GraphicsDevice);
            this.javalib.LoadMIDlet(this.loadMIDlet());
            JavaLibGame.isLoaded = true;
        }

        protected override void Initialize()
        {
            JavaLibGame.GSC = new GamerServicesComponent((Game)this);
            this.Components.Add((IGameComponent)JavaLibGame.GSC);
            try
            {
                base.Initialize();
            }
            //catch (GameUpdateRequiredException ex)
            //{
            //    XNAConnect.PromptForUpdate();
            //}
            catch (Exception ex)
            {
            }
            this.loadThread = new System.Threading.Thread(new ThreadStart(this.MyCallbackFunction));
            this.loadThread.Start();
        }

        protected override void Dispose(bool disposing)
        {
            this.javalib = (JavaLib)null;
            base.Dispose(disposing);
        }

        protected override void Update(GameTime gameTime)
        {
            if (this.javalib != null)
                this.javalib.Update(gameTime);
            else
                System.Threading.Thread.Sleep(10);
            try
            {
                base.Update(gameTime);
            }
            //catch (GameUpdateRequiredException ex)
            //{
            //    XNAConnect.PromptForUpdate();
            //}
            catch (Exception ex)
            {
            }
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            JavaLib.MIDlet.destroyApp(true);
            base.OnExiting(sender, args);
        }

        protected abstract MIDlet loadMIDlet();
    }
}
