// Decompiled with JetBrains decompiler
// Type: m3g.Sprite3D
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class Sprite3D : Node
  {
    public new const int M3G_UNIQUE_CLASS_ID = 18;
    private Appearance m_appearance;
    private Image2D m_image;
    private int m_cropX;
    private int m_cropY;
    private int m_cropW;
    private int m_cropH;

    public Sprite3D(bool scaled, Image2D image, Appearance app)
    {
      this.m_appearance = app;
      this.m_image = image;
      this.m_cropX = 0;
      this.m_cropY = 0;
      this.m_cropW = 0;
      this.m_cropH = 0;
      this.m_cropW = this.m_image.getWidth();
      this.m_cropH = this.m_image.getHeight();
    }

    protected override void updateAnimationProperty(int property, float[] value)
    {
      base.updateAnimationProperty(property, value);
      if (property != 259)
        return;
      this.setCrop((int) value[0], (int) value[1], (int) value[2], (int) value[3]);
    }

    public Appearance getAppearance()
    {
      return this.m_appearance;
    }

    public Image2D getImage2D()
    {
      return this.m_image;
    }

    public void setCrop(int x, int y, int width, int height)
    {
      this.m_cropX = x;
      this.m_cropY = y;
      this.m_cropW = width;
      this.m_cropH = height;
    }

    public override int getM3GUniqueClassID()
    {
      return 18;
    }
  }
}
