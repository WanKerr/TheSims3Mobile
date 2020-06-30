// Decompiled with JetBrains decompiler
// Type: m3g.Texture2D
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class Texture2D : Transformable
  {
    public const int FILTER_BASE_LEVEL = 208;
    public const int FILTER_LINEAR = 209;
    public const int FILTER_NEAREST = 210;
    public const int FUNC_ADD = 224;
    public const int FUNC_BLEND = 225;
    public const int FUNC_DECAL = 226;
    public const int FUNC_MODULATE = 227;
    public const int FUNC_REPLACE = 228;
    public const int WRAP_CLAMP = 240;
    public const int WRAP_REPEAT = 241;
    public new const int M3G_UNIQUE_CLASS_ID = 17;
    private Image2D m_image;
    private int m_blendColor;
    private int m_blending;
    private int m_imageFilter;
    private int m_levelFilter;
    private int m_wrappingS;
    private int m_wrappingT;

    public Texture2D()
    {
      this.m_image = (Image2D) null;
      this.m_blendColor = -1;
      this.m_blending = 227;
      this.m_imageFilter = 210;
      this.m_levelFilter = 208;
      this.m_wrappingS = 241;
      this.m_wrappingT = 241;
    }

    public Texture2D(Image2D image)
    {
      this.m_image = (Image2D) null;
      this.m_blendColor = -1;
      this.m_blending = 227;
      this.m_imageFilter = 210;
      this.m_levelFilter = 208;
      this.m_wrappingS = 241;
      this.m_wrappingT = 241;
      this.setImage(image);
    }

    protected override void duplicateTo(ref Object3D ret)
    {
      base.duplicateTo(ref ret);
      Texture2D texture2D = (Texture2D) ret;
      texture2D.setImage(this.getImage());
      texture2D.setBlending(this.getBlending());
      texture2D.setFiltering(this.getLevelFilter(), this.getImageFilter());
      texture2D.setWrapping(this.getWrappingS(), this.getWrappingT());
    }

    public int getBlending()
    {
      return this.m_blending;
    }

    public Image2D getImage()
    {
      return this.m_image;
    }

    public int getImageFilter()
    {
      return this.m_imageFilter;
    }

    public int getLevelFilter()
    {
      return this.m_levelFilter;
    }

    public int getWrappingS()
    {
      return this.m_wrappingS;
    }

    public int getWrappingT()
    {
      return this.m_wrappingT;
    }

    public void setBlendColor(int ARGB)
    {
      this.m_blendColor = ARGB;
    }

    public void setBlending(int blending)
    {
      this.m_blending = blending;
    }

    public void setFiltering(int levelFilter, int imageFilter)
    {
      this.m_levelFilter = levelFilter;
      this.m_imageFilter = imageFilter;
    }

    public void setImage(Image2D image)
    {
      this.m_image = image;
    }

    public void setWrapping(int wrapS, int wrapT)
    {
      this.m_wrappingS = wrapS;
      this.m_wrappingT = wrapT;
    }

    public override int getM3GUniqueClassID()
    {
      return 17;
    }

    public static Texture2D m3g_cast(Object3D obj)
    {
      return obj.getM3GUniqueClassID() == 17 ? (Texture2D) obj : (Texture2D) null;
    }
  }
}
