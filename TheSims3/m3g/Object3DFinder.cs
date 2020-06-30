// Decompiled with JetBrains decompiler
// Type: m3g.Object3DFinder
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class Object3DFinder
  {
    private int m_userID;
    private Object3D m_found;

    public Object3DFinder(int userID)
    {
      this.m_userID = userID;
      this.m_found = (Object3D) null;
    }

    public void resetTo(int userID)
    {
      this.m_userID = userID;
      this.m_found = (Object3D) null;
    }

    public void Dispose()
    {
    }

    public void find(Object3D obj)
    {
      if (obj == null || this.m_found != null)
        return;
      this.m_found = obj.find(this.m_userID);
    }

    public Object3D getFound()
    {
      return this.m_found;
    }
  }
}
