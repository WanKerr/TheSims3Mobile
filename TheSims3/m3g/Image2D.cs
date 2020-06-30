// Decompiled with JetBrains decompiler
// Type: m3g.Image2D
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using midp;
using System;

namespace m3g
{
  public class Image2D : Object3D
  {
    public const int ALPHA = 96;
    public const int LUMINANCE = 97;
    public const int LUMINANCE_ALPHA = 98;
    public const int RGB = 99;
    public const int RGBA = 100;
    public const int RGB565 = 101;
    public const int RGBA5551 = 102;
    public const int RGBA4444 = 103;
    public const int RGB_ATITC = 120;
    public const int RGBA_ATITC = 121;
    public const int RGB_PVRTC_2BPP = 122;
    public const int RGBA_PVRTC_2BPP = 123;
    public const int RGB_PVRTC_4BPP = 124;
    public const int RGBA_PVRTC_4BPP = 125;
    public new const int M3G_UNIQUE_CLASS_ID = 10;
    public Image2DPlatformData m_platformData;
    private int m_format;
    private int m_width;
    private int m_height;
    private bool m_mutable;
    private int m_bitsPerPixel;
    private int m_numMipMaps;
    private sbyte[][] m_mipMapData;
    private int m_mipMapDataLength;
    public Microsoft.Xna.Framework.Graphics.Texture2D texture2d;
    private int p;
    private int width;
    private int height;
    private sbyte[] pvrData;

    public Image2D()
    {
      this.m_platformData = new Image2DPlatformData();
      this.m_format = 0;
      this.m_width = 0;
      this.m_height = 0;
      this.m_mutable = true;
      this.m_bitsPerPixel = 0;
      this.m_numMipMaps = 0;
      this.m_mipMapData = (sbyte[][]) null;
      this.m_mipMapDataLength = 0;
      this.texture2d = (Microsoft.Xna.Framework.Graphics.Texture2D) null;
    }

    public Image2D(int format, int width, int height)
    {
      this.m_platformData = new Image2DPlatformData();
      this.m_format = 0;
      this.m_width = 0;
      this.m_height = 0;
      this.m_mutable = true;
      this.m_bitsPerPixel = 0;
      this.m_numMipMaps = 0;
      this.m_mipMapData = (sbyte[][]) null;
      this.m_mipMapDataLength = 0;
      this.set(format, width, height);
      this.texture2d = new Microsoft.Xna.Framework.Graphics.Texture2D(JavaLib.GraphicsDevice, width, height);
    }

    public Image2D(int format, Image image)
    {
      this.m_platformData = new Image2DPlatformData();
      this.m_format = 0;
      this.m_width = 0;
      this.m_height = 0;
      this.m_mutable = true;
      this.m_bitsPerPixel = 0;
      this.m_numMipMaps = 0;
      this.m_mipMapData = (sbyte[][]) null;
      this.m_mipMapDataLength = 0;
      this.set(format, image);
      this.texture2d = image.texture2D;
    }

    public Image2D(int p, int width, int height, sbyte[] pvrData)
    {
      this.p = p;
      this.width = width;
      this.height = height;
      this.pvrData = pvrData;
      throw new NotImplementedException();
    }

    public Image2D(Microsoft.Xna.Framework.Graphics.Texture2D texture)
    {
      this.m_mutable = false;
      this.m_format = 100;
      this.m_width = texture.Width;
      this.m_height = texture.Height;
      this.texture2d = texture;
      this.m_mipMapData = (sbyte[][]) null;
      this.m_mipMapDataLength = 0;
    }

    protected override void duplicateTo(ref Object3D ret)
    {
      base.duplicateTo(ref ret);
      Image2D image2D = (Image2D) ret;
      image2D.m_format = this.m_format;
      image2D.m_width = this.m_width;
      image2D.m_height = this.m_height;
      image2D.m_mutable = this.m_mutable;
      image2D.m_bitsPerPixel = this.m_bitsPerPixel;
      image2D.texture2d = this.texture2d;
    }

    public void set(int format, int width, int height)
    {
      Image2D.requirePowerOf2(width);
      Image2D.requirePowerOf2(height);
      this.m_format = format;
      this.m_width = width;
      this.m_height = height;
      this.m_bitsPerPixel = 0;
      switch (format)
      {
        case 96:
        case 97:
          this.m_bitsPerPixel = 8;
          break;
        case 98:
          this.m_bitsPerPixel = 16;
          break;
        case 99:
          this.m_bitsPerPixel = 24;
          break;
        case 100:
          this.m_bitsPerPixel = 32;
          break;
        case 101:
          this.m_bitsPerPixel = 16;
          break;
        case 102:
          this.m_bitsPerPixel = 16;
          break;
        case 103:
          this.m_bitsPerPixel = 16;
          break;
        case 120:
          this.m_bitsPerPixel = 4;
          break;
        case 121:
          this.m_bitsPerPixel = 8;
          break;
        case 122:
        case 123:
          this.m_bitsPerPixel = 2;
          break;
        case 124:
        case 125:
          this.m_bitsPerPixel = 4;
          break;
      }
      this.m_mutable = true;
    }

    public void set(int format, Image image)
    {
      int width = image.getWidth();
      int height = image.getHeight();
      this.set(format, width, height);
      this.texture2d = image.texture2D;
    }

    public void commit(sbyte[] palette, sbyte[] indices)
    {
      switch (this.m_format)
      {
        case 99:
          for (int level = 0; level < this.getNumMipMapLevels(); ++level)
          {
            sbyte[] mipMapData = this.getMipMapData(level);
            int mipMapWidth = this.getMipMapWidth(level);
            int mipMapHeight = this.getMipMapHeight(level);
            for (int index1 = 0; index1 < mipMapHeight; ++index1)
            {
              for (int index2 = 0; index2 < mipMapWidth; ++index2)
              {
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                for (int index3 = 0; index3 < 1 << level; ++index3)
                {
                  for (int index4 = 0; index4 < 1 << level; ++index4)
                  {
                    uint num4 = (uint) (((index1 << level) + index3) * this.m_width + (index2 << level) + index4);
                    uint num5 = (uint) (((int) indices[(int) num4] & (int) byte.MaxValue) * 3);
                    num1 += (int) palette[num5] & (int) byte.MaxValue;
                    num2 += (int) palette[(num5 + 1U)] & (int) byte.MaxValue;
                    num3 += (int) palette[(num5 + 2U)] & (int) byte.MaxValue;
                  }
                }
                int num6 = num1 >> level * 2;
                int num7 = num2 >> level * 2;
                int num8 = num3 >> level * 2;
                uint num9 = (uint) ((index1 * mipMapWidth + index2) * 3);
                mipMapData[num9] = (sbyte) num6;
                mipMapData[(num9 + 1U)] = (sbyte) num7;
                mipMapData[(num9 + 2U)] = (sbyte) num8;
                if (index2 == 0 && level == 0)
                {
                  Color[] data = new Color[mipMapData.Length / 3];
                  for (int index3 = 0; index3 < data.Length; ++index3)
                    data[index3] = new Color((int) mipMapData[index3 * 3], (int) mipMapData[index3 * 3 + 1], (int) mipMapData[index3 * 3 + 2]);
                  this.texture2d = new Microsoft.Xna.Framework.Graphics.Texture2D(JavaLib.GraphicsDevice, this.m_width, this.m_height, true, SurfaceFormat.Color);
                  this.texture2d.SetData<Color>(data);
                }
              }
            }
          }
          break;
        case 100:
          for (int level = 0; level < this.getNumMipMapLevels(); ++level)
          {
            sbyte[] mipMapData1 = this.getMipMapData(level);
            int mipMapWidth = this.getMipMapWidth(level);
            int mipMapHeight = this.getMipMapHeight(level);
            for (int index1 = 0; index1 < mipMapHeight; ++index1)
            {
              for (int index2 = 0; index2 < mipMapWidth; ++index2)
              {
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                for (int index3 = 0; index3 < 1 << level; ++index3)
                {
                  for (int index4 = 0; index4 < 1 << level; ++index4)
                  {
                    uint num5 = (uint) (((index1 << level) + index3) * this.m_width + (index2 << level) + index4);
                    uint num6 = (uint) (((int) indices[num5] & (int) byte.MaxValue) * 4);
                    num1 += (int) palette[num6] & (int) byte.MaxValue;
                    num2 += (int) palette[(num6 + 1U)] & (int) byte.MaxValue;
                    num3 += (int) palette[(num6 + 2U)] & (int) byte.MaxValue;
                    num4 += (int) palette[(num6 + 3U)] & (int) byte.MaxValue;
                  }
                }
                int num7 = num1 >> level * 2;
                int num8 = num2 >> level * 2;
                int num9 = num3 >> level * 2;
                int num10 = num4 >> level * 2;
                uint num11 = (uint) ((index1 * mipMapWidth + index2) * 4);
                mipMapData1[num11] = (sbyte) num7;
                mipMapData1[(num11 + 1U)] = (sbyte) num8;
                mipMapData1[(num11 + 2U)] = (sbyte) num9;
                mipMapData1[(num11 + 3U)] = (sbyte) num10;
                if (index2 == 0 && level == 0)
                {
                  sbyte[] mipMapData2 = this.getMipMapData(0);
                  Color[] data = new Color[this.getMipMapData(0).Length / 4];
                  for (int index3 = 0; index3 < data.Length; ++index3)
                    data[index3] = new Color((int) mipMapData2[index3 * 4], (int) mipMapData2[index3 * 4 + 1], (int) mipMapData2[index3 * 4 + 2], (int) mipMapData2[index3 * 4 + 3]);
                  this.texture2d = new Microsoft.Xna.Framework.Graphics.Texture2D(JavaLib.GraphicsDevice, this.m_width, this.m_height, false, SurfaceFormat.Color);
                  this.texture2d.SetData<Color>(data);
                }
              }
            }
          }
          break;
      }
      this.m_mutable = false;
    }

    public void commit(sbyte[] pixels)
    {
    }

    public void commit(byte[] pixels)
    {
      switch (this.m_format)
      {
        case 99:
          int num1 = 0;
          Color[] data1 = new Color[pixels.Length / 3];
          for (int index1 = 0; index1 < data1.Length; ++index1)
          {
            Color color = new Color();
            ref Color local1 = ref color;
            byte[] numArray1 = pixels;
            int index2 = num1;
            int num2 = index2 + 1;
            int num3 = (int) numArray1[index2];
            local1.R = (byte) num3;
            ref Color local2 = ref color;
            byte[] numArray2 = pixels;
            int index3 = num2;
            int num4 = index3 + 1;
            int num5 = (int) numArray2[index3];
            local2.G = (byte) num5;
            ref Color local3 = ref color;
            byte[] numArray3 = pixels;
            int index4 = num4;
            num1 = index4 + 1;
            int num6 = (int) numArray3[index4];
            local3.B = (byte) num6;
            color.A = byte.MaxValue;
            data1[index1] = color;
          }
          this.texture2d = new Microsoft.Xna.Framework.Graphics.Texture2D(JavaLib.GraphicsDevice, this.m_width, this.m_height, false, SurfaceFormat.Color);
          this.texture2d.SetData<Color>(data1);
          break;
        case 100:
          int num7 = 0;
          Color[] data2 = new Color[pixels.Length / 4];
          for (int index1 = 0; index1 < data2.Length; ++index1)
          {
            Color color = new Color();
            ref Color local1 = ref color;
            byte[] numArray1 = pixels;
            int index2 = num7;
            int num2 = index2 + 1;
            int num3 = (int) numArray1[index2];
            local1.R = (byte) num3;
            ref Color local2 = ref color;
            byte[] numArray2 = pixels;
            int index3 = num2;
            int num4 = index3 + 1;
            int num5 = (int) numArray2[index3];
            local2.G = (byte) num5;
            ref Color local3 = ref color;
            byte[] numArray3 = pixels;
            int index4 = num4;
            int num6 = index4 + 1;
            int num8 = (int) numArray3[index4];
            local3.B = (byte) num8;
            ref Color local4 = ref color;
            byte[] numArray4 = pixels;
            int index5 = num6;
            num7 = index5 + 1;
            int num9 = (int) numArray4[index5];
            local4.A = (byte) num9;
            data2[index1] = color;
          }
          this.texture2d = new Microsoft.Xna.Framework.Graphics.Texture2D(JavaLib.GraphicsDevice, this.m_width, this.m_height, false, SurfaceFormat.Color);
          this.texture2d.SetData<Color>(data2);
          break;
      }
    }

    protected int getNumMipMapLevels()
    {
      return this.m_numMipMaps;
    }

    protected sbyte[] getMipMapData(int level)
    {
      if (level >= this.m_mipMapDataLength)
        level = this.m_mipMapDataLength - 1;
      return this.m_mipMapData[level];
    }

    protected int getMipMapDataSize(int level)
    {
      if (level >= this.m_mipMapDataLength)
        level = this.m_mipMapDataLength - 1;
      int num = (this.getMipMapWidth(level) * this.getMipMapHeight(level) * this.m_bitsPerPixel + 7) / 8;
      switch (this.m_format)
      {
        case 120:
          if (num < 8)
          {
            num = 8;
            break;
          }
          break;
        case 121:
          if (num < 16)
          {
            num = 16;
            break;
          }
          break;
        case 122:
        case 123:
        case 124:
        case 125:
          if (num < 32)
          {
            num = 32;
            break;
          }
          break;
      }
      return num;
    }

    protected int getMipMapWidth(int level)
    {
      int num = this.m_width >> level;
      if (num == 0)
        num = 1;
      return num;
    }

    protected int getMipMapHeight(int level)
    {
      int num = this.m_height >> level;
      if (num == 0)
        num = 1;
      return num;
    }

    protected void discard()
    {
      for (int index = 0; index < this.m_mipMapDataLength; ++index)
      {
        sbyte[] numArray = this.m_mipMapData[index];
        this.m_mipMapData[index] = (sbyte[]) null;
      }
      if (this.m_mipMapData != null)
      {
        this.m_mipMapData = (sbyte[][]) null;
        this.m_mipMapData = (sbyte[][]) null;
      }
      this.m_mipMapDataLength = 0;
    }

    public int getFormat()
    {
      return this.m_format;
    }

    public int getWidth()
    {
      return this.m_width;
    }

    public int getHeight()
    {
      return this.m_height;
    }

    public bool isMutable()
    {
      return this.m_mutable;
    }

    internal static void requirePowerOf2(int dim)
    {
    }

    public override int getM3GUniqueClassID()
    {
      return 10;
    }

    public static Image2D m3g_cast(Object3D obj)
    {
      return obj.getM3GUniqueClassID() == 10 ? (Image2D) obj : (Image2D) null;
    }
  }
}
