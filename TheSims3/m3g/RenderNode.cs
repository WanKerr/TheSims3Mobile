// Decompiled with JetBrains decompiler
// Type: m3g.RenderNode
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

namespace m3g
{
  public struct RenderNode : IComparable<RenderNode>
  {
    public Node renderNode;
    public Transform compositeTransform;
    public int m_layer;
    public int m_blending;
    public AppearanceBase m_appearance;
    public IndexBuffer m_indexBuffer;
    public VertexBuffer m_vertexBuffer;
    public bool m_isSkinning;

    public RenderNode(RenderNode r)
    {
      this.renderNode = r.renderNode;
      this.compositeTransform = r.compositeTransform;
      this.m_layer = r.m_layer;
      this.m_blending = r.m_blending;
      this.m_appearance = r.m_appearance;
      this.m_indexBuffer = r.m_indexBuffer;
      this.m_vertexBuffer = r.m_vertexBuffer;
      this.m_isSkinning = r.m_isSkinning;
    }

    public RenderNode(Node n, int submeshIndex, ref Transform t, bool skinning)
    {
      this.renderNode = (Node) null;
      this.compositeTransform = (Transform) null;
      this.m_layer = 0;
      this.m_blending = 68;
      this.m_appearance = (AppearanceBase) null;
      this.m_indexBuffer = (IndexBuffer) null;
      this.m_vertexBuffer = (VertexBuffer) null;
      this.m_isSkinning = skinning;
      if (n == null)
        return;
      Mesh mesh = (Mesh) n;
      if (mesh == null)
        return;
      AppearanceBase appearance = (AppearanceBase) mesh.getAppearance(submeshIndex);
      IndexBuffer indexBuffer = mesh.getIndexBuffer(submeshIndex);
      if (appearance == null || indexBuffer == null)
        return;
      this.renderNode = n;
      this.compositeTransform = t;
      this.m_layer = appearance.getLayer();
      this.m_appearance = appearance;
      this.m_indexBuffer = indexBuffer;
      this.m_vertexBuffer = mesh.getVertexBuffer();
      CompositingMode compositingMode = appearance.getCompositingMode();
      if (compositingMode == null)
        return;
      this.m_blending = compositingMode.getBlending();
    }

    public RenderNode CopyFrom(RenderNode rhs)
    {
      this.renderNode = rhs.renderNode;
      this.compositeTransform = rhs.compositeTransform;
      this.m_layer = rhs.m_layer;
      this.m_appearance = rhs.m_appearance;
      this.m_indexBuffer = rhs.m_indexBuffer;
      this.m_vertexBuffer = rhs.m_vertexBuffer;
      this.m_blending = rhs.m_blending;
      return this;
    }

    public int CompareTo(RenderNode other)
    {
      int layer1 = this.m_layer;
      int layer2 = other.m_layer;
      if (layer1 == layer2)
        return 0;
      if (layer1 < layer2)
        return -1;
      return layer1 == layer2 ? 0 : 1;
    }
  }
}
