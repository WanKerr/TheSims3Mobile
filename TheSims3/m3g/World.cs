// Decompiled with JetBrains decompiler
// Type: m3g.World
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class World : Group
  {
    public new const int M3G_UNIQUE_CLASS_ID = 22;
    private Background m_background;
    private Camera m_activeCamera;

    public World()
    {
      this.m_background = (Background) null;
      this.m_activeCamera = (Camera) null;
    }

    public void setActiveCamera(Camera camera)
    {
      this.m_activeCamera = camera;
    }

    public void setBackground(Background background)
    {
      this.m_background = background;
    }

    public Camera getActiveCamera()
    {
      return this.m_activeCamera;
    }

    public Background getBackground()
    {
      return this.m_background;
    }

    public override int getM3GUniqueClassID()
    {
      return 22;
    }

    public static World m3g_cast(Object3D obj)
    {
      return obj.getM3GUniqueClassID() == 22 ? (World) obj : (World) null;
    }
  }
}
