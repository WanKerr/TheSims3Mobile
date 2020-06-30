// Decompiled with JetBrains decompiler
// Type: m3g.TriangleStripArray
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;
using System.Collections.Generic;

namespace m3g
{
  internal class TriangleStripArray : IndexBuffer
  {
    public new const int M3G_UNIQUE_CLASS_ID = 11;

    public TriangleStripArray()
    {
      this.setPrimitiveType(8);
    }

    public TriangleStripArray(int[] indices, int[] stripLengths)
      : base(8, stripLengths, indices)
    {
    }

    public TriangleStripArray(int firstIndex, int[] stripLengths)
      : base(8, stripLengths, firstIndex)
    {
    }

    public override int getM3GUniqueClassID()
    {
      return 11;
    }

    public static TriangleStripArray m3g_cast(Object3D obj)
    {
      return obj.getM3GUniqueClassID() == 11 ? (TriangleStripArray) obj : (TriangleStripArray) null;
    }

    public override IndexBuffer commitDuplicate()
    {
      ushort[] stripLengths = this.getStripLengths();
      int length1 = stripLengths.Length;
      List<int> intList = new List<int>();
      short[] explicitIndices = this.getExplicitIndices();
      int firstIndex = this.getFirstIndex();
      if (firstIndex == -1)
      {
        int src_position = 0;
        for (int index1 = 0; index1 < length1; ++index1)
        {
          int length2 = (int) stripLengths[index1];
          short[] numArray = new short[length2];
          midp.JSystem.arraycopy((Array) explicitIndices, src_position, (Array) numArray, 0, length2);
          for (int index2 = 2; index2 < length2; ++index2)
          {
            int num1 = (int) numArray[index2 - 2];
            int num2 = (int) numArray[index2 - 1];
            int num3 = (int) numArray[index2];
            if (num1 != num2 && num2 != num3 && num1 != num3)
            {
              intList.Add(num1);
              if ((index2 & 1) == 0)
              {
                intList.Add(num2);
                intList.Add(num3);
              }
              else
              {
                intList.Add(num3);
                intList.Add(num2);
              }
            }
          }
          src_position += length2;
        }
      }
      else
      {
        for (int index1 = 0; index1 < length1; ++index1)
        {
          int num1 = (int) stripLengths[index1];
          for (int index2 = 2; index2 < num1; ++index2)
          {
            int num2 = firstIndex + index2 - 2;
            int num3 = firstIndex + index2 - 1;
            int num4 = firstIndex + index2;
            intList.Add(num2);
            if ((index2 & 1) == 0)
            {
              intList.Add(num3);
              intList.Add(num4);
            }
            else
            {
              intList.Add(num4);
              intList.Add(num3);
            }
          }
          firstIndex += num1;
        }
      }
      int[] indices = new int[intList.Count];
      for (int index = 0; index < indices.Length; ++index)
        indices[index] = intList[index];
      return new IndexBuffer(8, indices.Length / 3, indices);
    }
  }
}
