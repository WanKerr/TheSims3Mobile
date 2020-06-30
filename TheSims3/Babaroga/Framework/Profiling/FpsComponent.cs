// Decompiled with JetBrains decompiler
// Type: Babaroga.Framework.Profiling.FpsComponent
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

//using Microsoft.Phone.Info;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Text;

namespace Babaroga.Framework.Profiling
{
    internal class FpsComponent
    {
        private StringBuilder sb = new StringBuilder();
        private ContentManager content;
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private Vector2 fpsScreenLocation;
        private int frameRate;
        private int frameCounter;
        private long elapsedTime;
        private int frameTens;
        private int frameOnes;
        private long totalMemory;
        private long currentMemory;
        private int memOnes;
        private int memTens;
        private object v;
        private string fpsString;
        private string font;
        private Game game;
        private System.Diagnostics.Process process;

        public FpsComponent(Game game, string font)
        {
            this.font = font;
            this.game = game;
            this.content = this.game.Content;
        }

        public void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.game.GraphicsDevice);
            this.spriteFont = this.content.Load<SpriteFont>(this.font);
            this.sb.Append("fps: 30");
            this.sb.Append(" CMem: 00");
            this.sb.Append(" TMem: 00");
            this.fpsScreenLocation = new Vector2(33f, 33f);
            this.process = System.Diagnostics.Process.GetCurrentProcess();
        }

        protected void UnloadContent()
        {
            this.content.Unload();
        }

        public void Update(GameTime gameTime)
        {
            if (process == null)
                return;


            this.elapsedTime += gameTime.ElapsedGameTime.Ticks;
            if (this.elapsedTime <= 10000000L)
                return;
            process.Refresh();

            this.elapsedTime -= 10000000L;
            this.frameRate = this.frameCounter;
            this.frameCounter = 0;
            this.currentMemory = process.WorkingSet64;
            this.totalMemory = process.PeakWorkingSet64;
            this.currentMemory /= 1048576L;
            this.totalMemory /= 1048576L;

            this.sb.Clear();
            this.sb.Append("fps: ")
                .Append(frameRate)
                .Append(" CMem: ")
                .Append(currentMemory)
                .Append(" TMem: ")
                .Append(totalMemory);
        }

        public void Draw(GameTime gameTime)
        {
            if (spriteFont == null)
                return;

            ++this.frameCounter;
            this.spriteBatch.Begin();
            this.spriteBatch.DrawString(this.spriteFont, this.sb, this.fpsScreenLocation, Color.White);
            this.spriteBatch.End();
        }
    }
}
