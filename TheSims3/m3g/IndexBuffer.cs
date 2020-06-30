// Decompiled with JetBrains decompiler
// Type: m3g.IndexBuffer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

namespace m3g
{
  public class IndexBuffer : Object3D
  {
    public const int TRIANGLES = 8;
    public const int LINES = 9;
    public const int POINT_SPRITES = 10;
    public new const int M3G_UNIQUE_CLASS_ID = 39;
    private int m_firstIndex;
    private int m_primitiveCount;
    private short[] m_indices;
    private ushort[] m_stripLengths;
    private bool m_commited;
    private int m_type;

    public static void requireValidIndex(int index)
    {
    }

    public static void requireValidPrimitiveCount(int count)
    {
    }

    public static void requireValidType(int type)
    {
    }

    protected IndexBuffer()
    {
      this.m_firstIndex = -1;
      this.m_primitiveCount = -1;
      this.m_indices = (short[]) null;
      this.m_stripLengths = (ushort[]) null;
      this.m_commited = false;
      this.m_type = 0;
    }

    public IndexBuffer(int type, int[] stripLengths, int firstIndex)
    {
      this.m_firstIndex = -1;
      this.m_primitiveCount = -1;
      this.m_indices = (short[]) null;
      this.m_stripLengths = (ushort[]) null;
      this.m_commited = false;
      this.m_type = 0;
      int[] indices = this.collapseStripsImplicit(stripLengths, firstIndex);
      this.setPrimitiveType(8);
      this.setIndices(indices);
    }

    public IndexBuffer(int type, int[] stripLengths, int[] indices)
    {
      this.m_firstIndex = -1;
      this.m_primitiveCount = -1;
      this.m_indices = (short[]) null;
      this.m_stripLengths = (ushort[]) null;
      this.m_commited = false;
      this.m_type = 0;
      int[] indices1 = this.collapseStrips(stripLengths, indices);
      this.setPrimitiveType(8);
      this.setIndices(indices1);
    }

    public IndexBuffer(int type, int primitiveCount, int firstIndex)
    {
      this.m_firstIndex = -1;
      this.m_primitiveCount = -1;
      this.m_indices = (short[]) null;
      this.m_stripLengths = (ushort[]) null;
      this.m_commited = false;
      this.m_type = 0;
      this.setPrimitiveType(type);
      this.setPrimitiveCount(primitiveCount);
      this.setFirstIndex(firstIndex);
    }

    public IndexBuffer(int type, int primitiveCount, int[] indices)
    {
      this.m_firstIndex = -1;
      this.m_primitiveCount = -1;
      this.m_indices = (short[]) null;
      this.m_stripLengths = (ushort[]) null;
      this.m_commited = false;
      this.m_type = 0;
      this.setPrimitiveType(type);
      this.setPrimitiveCount(primitiveCount);
      this.setIndices(indices);
    }

    public int[] collapseStrips(int[] striplengths, int[] indices)
    {
      uint num1 = 0;
      for (int index = 0; index < striplengths.Length; ++index)
        num1 += (uint) (striplengths[index] - 2);
      this.m_primitiveCount = (int) num1;
      int[] numArray = new int[(num1 * 3U)];
      uint num2 = 0;
      uint num3 = 0;
      for (int index1 = 0; index1 < striplengths.Length; ++index1)
      {
        uint num4 = num3;
        for (int index2 = 0; index2 < striplengths[index1] - 2; ++index2)
        {
          if ((index2 & 1) != 0)
          {
            numArray[num2] = indices[(num4 + 1U)];
            numArray[(num2 + 1U)] = indices[num4];
            numArray[(num2 + 2U)] = indices[(num4 + 2U)];
          }
          else
          {
            numArray[num2] = indices[num4];
            numArray[(num2 + 1U)] = indices[(num4 + 1U)];
            numArray[(num2 + 2U)] = indices[(num4 + 2U)];
          }
          ++num4;
          num2 += 3U;
        }
        num3 += (uint) striplengths[index1];
      }
      return numArray;
    }

    private int[] collapseStripsImplicit(int[] striplengths, int firstindex)
    {
      uint num1 = 0;
      for (int index = 0; index < striplengths.Length; ++index)
        num1 += (uint) (striplengths[index] - 2);
      this.m_primitiveCount = (int) num1;
      int[] numArray = new int[(num1 * 3U)];
      uint num2 = 0;
      uint num3 = (uint) firstindex;
      for (int index1 = 0; index1 < striplengths.Length; ++index1)
      {
        uint num4 = num3;
        for (int index2 = 0; index2 < striplengths[index1] - 2; ++index2)
        {
          if ((index2 & 1) != 0)
          {
            numArray[num2] = (int) num4 + 1;
            numArray[(num2 + 1U)] = (int) num4;
            numArray[(num2 + 2U)] = (int) num4 + 2;
          }
          else
          {
            numArray[num2] = (int) num4;
            numArray[(num2 + 1U)] = (int) num4 + 1;
            numArray[(num2 + 2U)] = (int) num4 + 2;
          }
          ++num4;
          num2 += 3U;
        }
        num3 += (uint) striplengths[index1];
      }
      return numArray;
    }

    public virtual void commit()
    {
      this.m_commited = true;
    }

    public int getIndexCount()
    {
      return this.m_indices.Length;
    }

    public void getIndices(ref int[] indices)
    {
      int length = this.m_indices.Length;
      for (int index = 0; index < length; ++index)
        indices[index] = (int) this.m_indices[index];
    }

    public short[] getIndices()
    {
      return this.m_indices;
    }

    public int getPrimitiveType()
    {
      return this.m_type;
    }

    public bool isReadable()
    {
      return !this.m_commited;
    }

    public int getFirstIndex()
    {
      return this.m_firstIndex;
    }

    public int getPrimitiveCount()
    {
      return this.m_primitiveCount;
    }

    public short[] getExplicitIndices()
    {
      return this.m_indices;
    }

    public ushort[] getStripLengths()
    {
      return this.m_stripLengths;
    }

    public bool isStripped()
    {
      return this.m_stripLengths != null && this.m_stripLengths.Length > 0;
    }

    public bool isImplicit()
    {
      return this.m_firstIndex > -1;
    }

    public virtual IndexBuffer commitDuplicate()
    {
      return this;
    }

    public void setFirstIndex(int index)
    {
      IndexBuffer.requireValidIndex(index);
      this.m_firstIndex = index;
    }

    public void setStripLengths(int[] stripLengths)
    {
      int length = stripLengths.Length;
      this.m_stripLengths = new ushort[length];
      ushort[] stripLengths1 = this.m_stripLengths;
      int[] numArray = stripLengths;
      for (int index = 0; index < length; ++index)
        stripLengths1[index] = (ushort) numArray[index];
    }

    public void setPrimitiveCount(int count)
    {
      IndexBuffer.requireValidPrimitiveCount(count);
      this.m_primitiveCount = count;
    }

    public void setPrimitiveType(int type)
    {
      IndexBuffer.requireValidType(type);
      this.m_type = type;
    }

    public void setIndices(int[] indices)
    {
      int length = indices.Length;
      this.m_indices = new short[length];
      for (int index = 0; index < length; ++index)
        this.m_indices[index] = (short) indices[index];
    }

    public override int getM3GUniqueClassID()
    {
      return 39;
    }
  }
}
