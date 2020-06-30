// Decompiled with JetBrains decompiler
// Type: m3g.Image2DPlatformData
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class Image2DPlatformData
  {
    public Image2DPlatformData.Data data = new Image2DPlatformData.Data();
    public Image2DPlatformData.glesDestructorDelegate glesDestructor;

    public Image2DPlatformData()
    {
      this.data.gl = new Image2DPlatformData.Data.GL();
      this.data.gles = new Image2DPlatformData.Data.GLES();
      this.glesDestructor = (Image2DPlatformData.glesDestructorDelegate) null;
      this.data.gles.texName = 0U;
    }

    public struct Data
    {
      public Image2DPlatformData.Data.GLES gles;
      public Image2DPlatformData.Data.GL gl;

      public struct GLES
      {
        public uint texName;
        public int magFilter;
        public int minFilter;
        public int wrapS;
        public int wrapT;
      }

      public struct GL
      {
        public uint texName;
        public int magFilter;
        public int minFilter;
        public int wrapS;
        public int wrapT;
      }
    }

    public delegate void glesDestructorDelegate(Image2DPlatformData temp);
  }
}
