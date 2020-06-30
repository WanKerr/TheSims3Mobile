// Decompiled with JetBrains decompiler
// Type: TextureManager
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using midp;
using sims3;
using System;

public class TextureManager : GlobalConstants
{
    internal static string CACHE_FOLDER = "tc";
    internal static string CACHE_INDEX = "index";
    internal static string CACHE_PREFIX = "pvrtc";
    internal static string CACHE_PLAYER_TAG = "p";
    internal static string CACHE_SEP = "-";
    private static TextureManager instance = new TextureManager();
    private string[][] m_playerTextureFilenames;
    private string[][] m_npcTextureFilenames;

    internal static void DEBUG_CACHESIMTEXTURES(string str)
    {
    }

    private TextureManager()
    {
        this.m_playerTextureFilenames = (string[][])null;
        this.m_npcTextureFilenames = (string[][])null;
        int simCount = AppEngine.getCanvas().getSimData().getSimCount();
        this.m_playerTextureFilenames = new string[7][];
        for (int index1 = 0; index1 < 7; ++index1)
        {
            this.m_playerTextureFilenames[index1] = new string[11];
            for (int index2 = 0; index2 < 11; ++index2)
                this.m_playerTextureFilenames[index1][index2] = "";
        }
        this.m_npcTextureFilenames = new string[simCount][];
        for (int index1 = 0; index1 < simCount; ++index1)
        {
            this.m_npcTextureFilenames[index1] = new string[11];
            for (int index2 = 0; index2 < 11; ++index2)
                this.m_npcTextureFilenames[index1][index2] = "";
        }
    }

    public new virtual void Dispose()
    {
        this.unload();
    }

    private void unload()
    {
        TextureManager.DEBUG_CACHESIMTEXTURES("unload\n");
        for (int index1 = 0; index1 < this.m_playerTextureFilenames.Length; ++index1)
        {
            for (int index2 = 0; index2 < this.m_playerTextureFilenames[index1].Length; ++index2)
                this.m_playerTextureFilenames[index1][index2] = (string)null;
        }
        for (int index1 = 0; index1 < this.m_npcTextureFilenames.Length; ++index1)
        {
            for (int index2 = 0; index2 < this.m_npcTextureFilenames[index1].Length; ++index2)
                this.m_npcTextureFilenames[index1][index2] = (string)null;
        }
    }

    private void loadIndex()
    {
        throw new NotImplementedException();
    }

    private void saveIndex()
    {
        throw new NotImplementedException();
    }

    public static TextureManager getInstance()
    {
        return TextureManager.instance;
    }

    public m3g.Texture2D getSimTexture(
      int simId,
      int textureId,
      string textureFilename,
      int textureIdOver,
      string textureFilenameOver,
      bool compressTextures)
    {
        AppEngine.getCanvas();
        AppEngine.getResourceManager();
        Image2D image1 = (Image2D)null;
        if (image1 == null)
        {
            TextureManager.DEBUG_CACHESIMTEXTURES("constructing texture\n");
            AppEngine.timerBegin();
            Image image2 = ResourceManager.loadImage(textureFilename.Substring(0, textureFilename.Length - 4));
            Image image3 = textureFilenameOver == null ? (Image)null : ResourceManager.loadImage(textureFilenameOver.Substring(0, textureFilenameOver.Length - 4));
            AppEngine.timerEnd("loading images");
            int width = image2.getWidth();
            int height = image2.getHeight();
            Image image4 = (Image)null;
            if (image3 != null)
            {
                AppEngine.timerBegin();
                GraphicsDevice graphicsDevice = JavaLib.GraphicsDevice;
                RenderTarget2D renderTarget = new RenderTarget2D(graphicsDevice, width, height);
                SpriteBatch spriteBatch = Display.getDisplay(JavaLib.MIDlet).getSpriteBatch();
                lock (spriteBatch)
                {
                    image4 = Image.createImage(width, height);
                    graphicsDevice.SetRenderTarget(renderTarget);
                    spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                    spriteBatch.Draw(image2.texture2D, new Rectangle(0, 0, width, height), new Rectangle?(new Rectangle(0, 0, width, height)), Color.White, 0.0f, Vector2.Zero, SpriteEffects.FlipVertically, 0.0f);
                    spriteBatch.Draw(image3.texture2D, new Rectangle(0, 0, width, height), new Rectangle?(new Rectangle(0, 0, width, height)), Color.White, 0.0f, Vector2.Zero, SpriteEffects.FlipVertically, 0.0f);
                    spriteBatch.End();
                    graphicsDevice.SetRenderTarget(TheSims3.currentTarget);
                }
                image4.texture2D = (Microsoft.Xna.Framework.Graphics.Texture2D)renderTarget;
                AppEngine.timerEnd("layer images");
            }
            else
            {
                AppEngine.timerBegin();
                GraphicsDevice graphicsDevice = JavaLib.GraphicsDevice;
                RenderTarget2D renderTarget = new RenderTarget2D(graphicsDevice, width, height);
                SpriteBatch spriteBatch = Display.getDisplay(JavaLib.MIDlet).getSpriteBatch();
                lock (spriteBatch)
                {
                    image4 = Image.createImage(width, height);
                    graphicsDevice.SetRenderTarget(renderTarget);
                    spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                    spriteBatch.Draw(image2.texture2D, new Rectangle(0, 0, width, height), new Rectangle?(new Rectangle(0, 0, width, height)), Color.White, 0.0f, Vector2.Zero, SpriteEffects.FlipVertically, 0.0f);
                    spriteBatch.End();
                    graphicsDevice.SetRenderTarget(TheSims3.currentTarget);
                }
                image4.texture2D = (Microsoft.Xna.Framework.Graphics.Texture2D)renderTarget;
            }
            image1 = new Image2D(100, image4);
        }
        m3g.Texture2D texture2D = new m3g.Texture2D(image1);
        texture2D.setFiltering(210, 209);
        return texture2D;
    }

    private string getCacheFilename(int simId, int textureId, int textureIdOver)
    {
        int rmsGameSlotIndex = AppEngine.getCanvas().getRMSGameSlotIndex();
        StringBuffer stringBuffer = new StringBuffer();
        stringBuffer.append(TextureManager.CACHE_PREFIX);
        if (simId == 0)
        {
            stringBuffer.append(TextureManager.CACHE_PLAYER_TAG);
            stringBuffer.append(rmsGameSlotIndex);
        }
        else
            stringBuffer.append(simId);
        stringBuffer.append(TextureManager.CACHE_SEP).append(textureId).append(TextureManager.CACHE_SEP).append(textureIdOver);
        return stringBuffer.toString();
    }

    private Image2D loadCached(
      int simId,
      int textureId,
      int textureIdOver,
      string textureFilename,
      string textureFilenameOver)
    {
        throw new NotImplementedException();
    }

    private void saveCached(
      int simId,
      int textureId,
      int textureIdOver,
      string textureFilename,
      string textureFilenameOver,
      int width,
      int height,
      ref sbyte[] pvrData)
    {
        throw new NotImplementedException();
    }
}
