// Decompiled with JetBrains decompiler
// Type: m3g.renderer.Renderer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;

namespace m3g.renderer
{
  public abstract class Renderer
  {
    public abstract void restoreToClamp();

    public abstract void setProjectionAndViewTransform(Transform projection, Transform view);

    public abstract void pushModelTransform(Transform transform);

    public abstract void popModelTransform();

    public abstract void setViewport(int x, int y, int width, int height);

    public abstract void clear(Background background);

    public abstract void bind(int w, int h);

    public abstract void release();

    public abstract void render(
      VertexBuffer vertices,
      IndexBuffer primitives,
      AppearanceBase appearance,
      float alphaFactor);

    public abstract void render(
      VertexBuffer vertices,
      VertexArray skinIndices,
      VertexArray skinWeights,
      Matrix[] matrixPalette,
      IndexBuffer primitives,
      AppearanceBase appearance,
      float alphaFactor);

    public abstract void processApperance(Appearance appearance);
  }
}
