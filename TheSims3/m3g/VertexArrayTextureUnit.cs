// Decompiled with JetBrains decompiler
// Type: m3g.VertexArrayTextureUnit
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class VertexArrayTextureUnit
  {
    public readonly VertexArray texcoords;
    public float texcoordScale;
    public float texcoordBiasU;
    public float texcoordBiasV;

    public VertexArrayTextureUnit(VertexArray arr, float scale, float[] bias)
    {
      this.texcoords = arr;
      this.texcoordScale = 1f;
      this.texcoordBiasU = 0.0f;
      this.texcoordBiasV = 0.0f;
      this.texcoordScale = scale;
      if (bias != null)
      {
        this.texcoordBiasU = bias[0];
        this.texcoordBiasV = bias[1];
      }
      else
      {
        this.texcoordBiasU = 0.0f;
        this.texcoordBiasV = 0.0f;
      }
    }

    public int getVertexCount()
    {
      return this.texcoords.getVertexCount();
    }
  }
}
