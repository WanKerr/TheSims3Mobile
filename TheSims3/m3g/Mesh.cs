// Decompiled with JetBrains decompiler
// Type: m3g.Mesh
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace m3g
{
  public class Mesh : Node
  {
    private List<object> m_indexBuffers = new List<object>();
    private List<object> m_appearances = new List<object>();
    public new const int M3G_UNIQUE_CLASS_ID = 14;
    protected VertexBuffer m_vertexBuffer;
    private bool m_mutable;

    public Mesh(VertexBuffer vertices, ref IndexBuffer[] submeshes, ref Appearance[] appearances)
    {
      this.m_vertexBuffer = (VertexBuffer) null;
      this.m_indexBuffers = new List<object>();
      this.m_appearances = new List<object>();
      this.m_mutable = true;
      this.setVertexBuffer(vertices);
      this.setSubmeshCount(submeshes.Length);
      for (int index = 0; index < submeshes.Length; ++index)
        this.setIndexBuffer(index, submeshes[index]);
      for (int index = 0; index < appearances.Length; ++index)
        this.setAppearance(index, appearances[index]);
    }

    public Mesh(int submeshCount, int morphCount)
    {
      this.m_vertexBuffer = (VertexBuffer) null;
      this.m_indexBuffers = new List<object>();
      this.m_appearances = new List<object>();
      this.m_mutable = true;
      this.setSubmeshCount(submeshCount);
    }

    public Mesh(VertexBuffer vertices, IndexBuffer submesh, Appearance appearance)
    {
      this.m_vertexBuffer = (VertexBuffer) null;
      this.m_indexBuffers = new List<object>();
      this.m_appearances = new List<object>();
      this.m_mutable = true;
      this.setVertexBuffer(vertices);
      this.setSubmeshCount(1);
      this.setIndexBuffer(0, submesh);
      this.setAppearance(0, appearance);
    }

    public void commit()
    {
      if (!this.m_mutable)
        return;
      VertexBuffer vertexBuffer = (VertexBuffer) this.getVertexBuffer().duplicate();
      vertexBuffer.commit();
      this.setVertexBuffer(vertexBuffer);
      for (int index = 0; index < this.getSubmeshCount(); ++index)
      {
        IndexBuffer indexBuffer = this.getIndexBuffer(index).commitDuplicate();
        this.setIndexBuffer(index, indexBuffer);
      }
      this.m_mutable = false;
    }

    public Appearance getAppearance(int index)
    {
      return !this.verifyIndex(index) ? (Appearance) null : (Appearance) this.m_appearances.ElementAt<object>(index);
    }

    public IndexBuffer getIndexBuffer(int index)
    {
      return !this.verifyIndex(index) ? (IndexBuffer) null : (IndexBuffer) this.m_indexBuffers.ElementAt<object>(index);
    }

    public int getSubmeshCount()
    {
      return this.m_indexBuffers.Count;
    }

    public VertexBuffer getVertexBuffer()
    {
      return this.m_vertexBuffer;
    }

    public void setIndexBuffer(int index, IndexBuffer indexBuffer)
    {
      if (!this.verifyMutable() || !this.verifyIndex(index))
        return;
      this.m_indexBuffers[index] = (object) indexBuffer;
    }

    public void setAppearanceBase(int index, AppearanceBase appearance)
    {
      if (!this.verifyMutable() || !this.verifyIndex(index))
        return;
      this.m_appearances[index] = (object) appearance;
    }

    public void setAppearance(int index, Appearance appearance)
    {
      this.setAppearanceBase(index, (AppearanceBase) appearance);
    }

    public bool isMutable()
    {
      return this.m_mutable;
    }

    public void setVertexBuffer(VertexBuffer vertexBuffer)
    {
      if (!this.verifyMutable())
        return;
      this.m_vertexBuffer = vertexBuffer;
    }

    public void setSubmeshCount(int count)
    {
      if (!this.verifyMutable())
        return;
      this.m_indexBuffers.Clear();
      this.m_indexBuffers.Capacity = count;
      for (int index = 0; index < count; ++index)
        this.m_indexBuffers.Add((object) null);
      this.m_appearances.Clear();
      this.m_appearances.Capacity = count;
      for (int index = 0; index < count; ++index)
        this.m_appearances.Add((object) null);
    }

    public Mesh()
    {
      this.m_vertexBuffer = (VertexBuffer) null;
      this.m_indexBuffers = new List<object>();
      this.m_appearances = new List<object>();
      this.m_mutable = true;
    }

    protected override void duplicateTo(ref Object3D ret)
    {
      base.duplicateTo(ref ret);
      Mesh mesh = (Mesh) ret;
      mesh.setSubmeshCount(this.getSubmeshCount());
      VertexBuffer vertexBuffer = this.getVertexBuffer();
      if (vertexBuffer != null)
        mesh.setVertexBuffer(vertexBuffer);
      for (int index = 0; index < this.getSubmeshCount(); ++index)
      {
        mesh.setAppearance(index, this.getAppearance(index));
        mesh.setIndexBuffer(index, this.getIndexBuffer(index));
      }
      mesh.m_mutable = this.isMutable();
    }

    public override int getReferences(ref Object3D[] references)
    {
      int references1 = base.getReferences(ref references);
      int num1 = references1;
      for (int index = 0; index < this.getSubmeshCount(); ++index)
      {
        if (this.getAppearance(index) != null)
          ++references1;
        if (this.getIndexBuffer(index) != null)
          ++references1;
      }
      int num2 = references1 + 1;
      if (references != null)
      {
        for (int index = 0; index < this.getSubmeshCount(); ++index)
        {
          Appearance appearance = this.getAppearance(index);
          if (appearance != null)
            references[num1++] = (Object3D) appearance;
          IndexBuffer indexBuffer = this.getIndexBuffer(index);
          if (indexBuffer != null)
            references[num1++] = (Object3D) indexBuffer;
        }
        Object3D[] object3DArray = references;
        int index1 = num1;
        int num3 = index1 + 1;
        VertexBuffer vertexBuffer = this.getVertexBuffer();
        object3DArray[index1] = (Object3D) vertexBuffer;
      }
      return num2;
    }

    protected override void findReferences(ref Object3DFinder finder)
    {
      base.findReferences(ref finder);
      finder.find((Object3D) this.getVertexBuffer());
      int submeshCount = this.getSubmeshCount();
      for (int index = 0; index < submeshCount; ++index)
        finder.find((Object3D) this.getAppearance(index));
      for (int index = 0; index < submeshCount; ++index)
        finder.find((Object3D) this.getIndexBuffer(index));
    }

    public override int animateReferences(int time)
    {
      if (!this.isRenderingEnabled())
        return 0;
      int val2 = this.animateReferencesObject3D(time);
      return Math.Min(this.getVertexBuffer().animate(time), val2);
    }

    private bool verifyIndex(int index)
    {
      return index >= 0 && index < this.getSubmeshCount();
    }

    private bool verifyMutable()
    {
      return this.m_mutable;
    }

    public void preparePositionsForSkinning()
    {
      float[] scaleBias = new float[4];
      VertexArray positions = this.getVertexBuffer().getPositions(ref scaleBias);
      if (positions.getComponentCount() != 3 || positions.getComponentType() == 4 && (double) scaleBias[0] == 1.0 && ((double) scaleBias[1] == 0.0 && (double) scaleBias[2] == 0.0) && (double) scaleBias[3] == 0.0)
        return;
      float[] values = new float[positions.getVertexCount() * positions.getComponentCount()];
      VertexArray arr = new VertexArray(positions.getVertexCount(), positions.getComponentCount(), 4);
      positions.get(0, positions.getVertexCount(), ref values);
      float[] bias = new float[scaleBias.Length - 1];
      Array.Copy((Array) scaleBias, 1, (Array) bias, 0, scaleBias.Length - 1);
      this.getVertexBuffer().setPositions(arr, scaleBias[0], bias);
    }

    public override int getM3GUniqueClassID()
    {
      return 14;
    }

    public static Mesh m3g_cast(Object3D obj)
    {
      switch (obj.getM3GUniqueClassID())
      {
        case 14:
        case 16:
          return (Mesh) obj;
        default:
          return (Mesh) null;
      }
    }
  }
}
