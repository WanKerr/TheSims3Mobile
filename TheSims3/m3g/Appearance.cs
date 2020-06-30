// Decompiled with JetBrains decompiler
// Type: m3g.Appearance
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class Appearance : AppearanceBase
  {
    private const int NUM_TEXTURES = 2;
    public new const int M3G_UNIQUE_CLASS_ID = 3;
    private PointSpriteMode m_pointSpriteMode;
    private Texture2D[] m_textures;
    private Material m_material;
    private Fog m_fog;

    protected override void duplicateTo(ref Object3D ret)
    {
      base.duplicateTo(ref ret);
      Appearance appearance = (Appearance) ret;
      appearance.setPointSpriteMode(this.getPointSpriteMode());
      for (int index = 0; index < 2; ++index)
        appearance.setTexture(index, this.getTexture(index));
      appearance.setMaterial(this.getMaterial());
      appearance.setFog(this.getFog());
    }

    public override int getReferences(ref Object3D[] references)
    {
      int references1 = base.getReferences(ref references);
      int num = references1;
      if (this.m_pointSpriteMode != null)
        ++references1;
      if (this.m_material != null)
        ++references1;
      if (this.m_fog != null)
        ++references1;
      for (int index = 0; index < 2; ++index)
      {
        if (this.getTexture(index) != null)
          ++references1;
      }
      if (references != null)
      {
        if (this.m_pointSpriteMode != null)
          references[num++] = (Object3D) this.m_pointSpriteMode;
        if (this.m_material != null)
          references[num++] = (Object3D) this.m_material;
        if (this.m_fog != null)
          references[num++] = (Object3D) this.m_fog;
        for (int index = 0; index < 2; ++index)
        {
          Texture2D texture = this.getTexture(index);
          if (texture != null)
            references[num++] = (Object3D) texture;
        }
      }
      return references1;
    }

    protected override void findReferences(ref Object3DFinder finder)
    {
      base.findReferences(ref finder);
      finder.find((Object3D) this.getPointSpriteMode());
      finder.find((Object3D) this.getMaterial());
      finder.find((Object3D) this.getFog());
      for (int index = 0; index < 2; ++index)
        finder.find((Object3D) this.getTexture(index));
    }

    public int minimum(int a, int b)
    {
      return a >= b ? b : a;
    }

    public override int animateReferences(int time)
    {
      int b = this.animateReferencesObject3D(time);
      if (this.getMaterial() != null)
        b = this.minimum(this.getMaterial().animate(time), b);
      if (this.getFog() != null)
        b = this.minimum(this.getFog().animate(time), b);
      for (int index = 0; index < 2; ++index)
      {
        if (this.getTexture(index) != null)
          b = this.minimum(this.getTexture(index).animate(time), b);
      }
      return b;
    }

    public Appearance()
    {
      this.m_pointSpriteMode = (PointSpriteMode) null;
      this.m_textures = new Texture2D[2];
      this.m_material = (Material) null;
      this.m_fog = (Fog) null;
      for (int index = 0; index < 2; ++index)
        this.m_textures[index] = (Texture2D) null;
    }

    public void setFog(Fog fog)
    {
      this.m_fog = fog;
    }

    public Fog getFog()
    {
      return this.m_fog;
    }

    public void setTexture(int index, Texture2D texture)
    {
      this.validateTextureUnit(index);
      Texture2D texture1 = this.m_textures[index];
      this.m_textures[index] = texture;
    }

    public Texture2D getTexture(int index)
    {
      this.validateTextureUnit(index);
      return this.m_textures[index];
    }

    public void setMaterial(Material material)
    {
      this.m_material = material;
    }

    public Material getMaterial()
    {
      return this.m_material;
    }

    public void setPointSpriteMode(PointSpriteMode pointSpriteMode)
    {
      this.m_pointSpriteMode = pointSpriteMode;
    }

    public PointSpriteMode getPointSpriteMode()
    {
      return this.m_pointSpriteMode;
    }

    private void validateTextureUnit(int index)
    {
    }

    public int getNumTextures()
    {
      return this.m_textures.Length;
    }

    public override int getM3GUniqueClassID()
    {
      return 3;
    }

    public static Appearance m3g_cast(Object3D obj)
    {
      return obj.getM3GUniqueClassID() == 3 ? (Appearance) obj : (Appearance) null;
    }
  }
}
