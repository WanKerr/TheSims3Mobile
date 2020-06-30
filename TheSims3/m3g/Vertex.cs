// Decompiled with JetBrains decompiler
// Type: m3g.Vertex
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace m3g
{
  public struct Vertex : IVertexType
  {
    public static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration(new VertexElement[7]
    {
      new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
      new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0),
      new VertexElement(24, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0),
      new VertexElement(32, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 1),
      new VertexElement(40, VertexElementFormat.Vector4, VertexElementUsage.BlendIndices, 0),
      new VertexElement(56, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
      new VertexElement(72, VertexElementFormat.Color, VertexElementUsage.Color, 0)
    });
    public Vector3 position;
    public Vector3 normal;
    public Vector2 textureCoordinate;
    public Vector2 textureCoordinate2;
    public Color color;
    public Vector4 skinIndex;
    public Vector4 skinWeight;

    VertexDeclaration IVertexType.VertexDeclaration
    {
      get
      {
        return Vertex.VertexDeclaration;
      }
    }
  }
}
