// Decompiled with JetBrains decompiler
// Type: m3g.VertexArray
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

namespace m3g
{
  public class VertexArray : Object3D
  {
    public const int BYTE = 1;
    public const int FIXED = 3;
    public const int FLOAT = 4;
    public const int HALF = 5;
    public const int SHORT = 2;
    public new const int M3G_UNIQUE_CLASS_ID = 20;
    public float[] vData;
    private int m_numVertices;
    private int m_numComponents;
    public int m_componentType;
    private IntPtr m_data;
    private readonly bool m_dataIsShared;
    private readonly int m_dataOffset;
    private int m_dataStride;
    private int m_componentStride;
    public bool converted;

    public static int componentSize(int componentType)
    {
      switch (componentType)
      {
        case 1:
          return 1;
        case 2:
          return 2;
        case 3:
          return 4;
        case 4:
          return 4;
        case 5:
          return 2;
        default:
          return 0;
      }
    }

    public VertexArray()
    {
      this.m_numVertices = 0;
      this.m_numComponents = 0;
      this.m_componentType = 0;
      this.m_dataIsShared = false;
      this.m_dataOffset = 0;
      this.m_dataStride = 0;
      this.m_componentStride = 0;
    }

    public void setFormat(int vertexCount, int componentCount, int componentType)
    {
      this.m_numVertices = vertexCount;
      this.m_numComponents = componentCount;
      this.m_componentType = componentType;
      this.vData = new float[vertexCount * this.getComponentCount()];
    }

    public VertexArray(
      int vertexCount,
      int componentCount,
      int componentType,
      IntPtr sharedData,
      int dataOffset,
      int dataStride)
    {
      this.m_numVertices = 0;
      this.m_numComponents = 0;
      this.m_componentType = 0;
      this.m_data = sharedData;
      this.m_dataIsShared = true;
      this.m_dataOffset = dataOffset;
      this.m_dataStride = dataStride;
      this.m_componentStride = 0;
      this.setFormat(vertexCount, componentCount, componentType);
    }

    public VertexArray(int vertexCount, int componentCount, int componentType)
    {
      this.m_numVertices = 0;
      this.m_numComponents = 0;
      this.m_componentType = 0;
      this.m_dataIsShared = false;
      this.m_dataOffset = 0;
      this.m_dataStride = 0;
      this.m_componentStride = 0;
      this.setFormat(vertexCount, componentCount, componentType);
    }

    public void get(int firstVertex, int numVertices, ref sbyte[] values)
    {
      int num1 = 0;
      int componentCount = this.getComponentCount();
      int num2 = firstVertex * componentCount;
      for (int index1 = 0; index1 < numVertices; ++index1)
      {
        sbyte[] numArray1 = values;
        int index2 = num1;
        int num3 = index2 + 1;
        float[] vData1 = this.vData;
        int index3 = num2;
        int num4 = index3 + 1;
        int num5 = (int) (sbyte) vData1[index3];
        numArray1[index2] = (sbyte) num5;
        sbyte[] numArray2 = values;
        int index4 = num3;
        num1 = index4 + 1;
        float[] vData2 = this.vData;
        int index5 = num4;
        num2 = index5 + 1;
        int num6 = (int) (sbyte) vData2[index5];
        numArray2[index4] = (sbyte) num6;
        if (componentCount > 2)
          values[num1++] = (sbyte) this.vData[num2++];
        if (componentCount > 3)
          values[num1++] = (sbyte) this.vData[num2++];
      }
    }

    public void get(int firstVertex, int numVertices, sbyte[] values)
    {
      int num1 = 0;
      int componentCount = this.getComponentCount();
      int num2 = firstVertex * componentCount;
      for (int index1 = 0; index1 < numVertices; ++index1)
      {
        sbyte[] numArray1 = values;
        int index2 = num1;
        int num3 = index2 + 1;
        float[] vData1 = this.vData;
        int index3 = num2;
        int num4 = index3 + 1;
        int num5 = (int) (sbyte) vData1[index3];
        numArray1[index2] = (sbyte) num5;
        sbyte[] numArray2 = values;
        int index4 = num3;
        num1 = index4 + 1;
        float[] vData2 = this.vData;
        int index5 = num4;
        num2 = index5 + 1;
        int num6 = (int) (sbyte) vData2[index5];
        numArray2[index4] = (sbyte) num6;
        if (componentCount > 2)
          values[num1++] = (sbyte) this.vData[num2++];
        if (componentCount > 3)
          values[num1++] = (sbyte) this.vData[num2++];
      }
    }

    public float[] getvData()
    {
      return this.vData;
    }

    public void get(int firstVertex, int numVertices, ref float[] values)
    {
      int num1 = 0;
      int componentCount = this.getComponentCount();
      int num2 = firstVertex * componentCount;
      for (int index1 = 0; index1 < numVertices; ++index1)
      {
        float[] numArray1 = values;
        int index2 = num1;
        int num3 = index2 + 1;
        float[] vData1 = this.vData;
        int index3 = num2;
        int num4 = index3 + 1;
        double num5 = (double) vData1[index3];
        numArray1[index2] = (float) num5;
        float[] numArray2 = values;
        int index4 = num3;
        num1 = index4 + 1;
        float[] vData2 = this.vData;
        int index5 = num4;
        num2 = index5 + 1;
        double num6 = (double) vData2[index5];
        numArray2[index4] = (float) num6;
        if (componentCount > 2)
          values[num1++] = this.vData[num2++];
        if (componentCount > 3)
          values[num1++] = this.vData[num2++];
      }
    }

    public void get(int firstVertex, int numVertices, ref int[] values, int type)
    {
      throw new NotImplementedException();
    }

    public void get(int firstVertex, int numVertices, ref short[] values)
    {
      int num1 = firstVertex * this.m_numComponents;
      int num2 = 0;
      for (int index1 = 0; index1 < numVertices; ++index1)
      {
        short[] numArray1 = values;
        int index2 = num2;
        int num3 = index2 + 1;
        float[] vData1 = this.vData;
        int index3 = num1;
        int num4 = index3 + 1;
        int num5 = (int) (short) vData1[index3];
        numArray1[index2] = (short) num5;
        short[] numArray2 = values;
        int index4 = num3;
        num2 = index4 + 1;
        float[] vData2 = this.vData;
        int index5 = num4;
        num1 = index5 + 1;
        int num6 = (int) (short) vData2[index5];
        numArray2[index4] = (short) num6;
      }
    }

    public int getComponentCount()
    {
      return this.m_numComponents;
    }

    public int getComponentType()
    {
      return this.m_componentType;
    }

    public int getVertexCount()
    {
      return this.m_numVertices;
    }

    public void convert(int componentType)
    {
      throw new NotImplementedException();
    }

    public void set(int firstVertex, int numVertices, sbyte[] src)
    {
      int num1 = 0;
      int componentCount = this.getComponentCount();
      int num2 = firstVertex * componentCount;
      for (int index1 = 0; index1 < numVertices; ++index1)
      {
        float[] vData1 = this.vData;
        int index2 = num2;
        int num3 = index2 + 1;
        sbyte[] numArray1 = src;
        int index3 = num1;
        int num4 = index3 + 1;
        double num5 = (double) (byte) numArray1[index3];
        vData1[index2] = (float) num5;
        float[] vData2 = this.vData;
        int index4 = num3;
        num2 = index4 + 1;
        sbyte[] numArray2 = src;
        int index5 = num4;
        num1 = index5 + 1;
        double num6 = (double) (byte) numArray2[index5];
        vData2[index4] = (float) num6;
        if (componentCount > 2)
          this.vData[num2++] = (float) (byte) src[num1++];
        if (componentCount > 3)
          this.vData[num2++] = (float) (byte) src[num1++];
      }
    }

    public void set(int firstVertex, int numVertices, float[] src)
    {
      int num1 = 0;
      int componentCount = this.getComponentCount();
      int num2 = firstVertex * componentCount;
      for (int index1 = 0; index1 < numVertices; ++index1)
      {
        float[] vData1 = this.vData;
        int index2 = num2;
        int num3 = index2 + 1;
        float[] numArray1 = src;
        int index3 = num1;
        int num4 = index3 + 1;
        double num5 = (double) numArray1[index3];
        vData1[index2] = (float) num5;
        float[] vData2 = this.vData;
        int index4 = num3;
        num2 = index4 + 1;
        float[] numArray2 = src;
        int index5 = num4;
        num1 = index5 + 1;
        double num6 = (double) numArray2[index5];
        vData2[index4] = (float) num6;
        if (componentCount > 2)
          this.vData[num2++] = src[num1++];
        if (componentCount > 3)
          this.vData[num2++] = src[num1++];
      }
    }

    public void set(int firstVertex, int numVertices, int[] src)
    {
      int num1 = 0;
      int componentCount = this.getComponentCount();
      int num2 = firstVertex * componentCount;
      for (int index1 = 0; index1 < numVertices; ++index1)
      {
        float[] vData1 = this.vData;
        int index2 = num2;
        int num3 = index2 + 1;
        int[] numArray1 = src;
        int index3 = num1;
        int num4 = index3 + 1;
        double num5 = (double) ((float) numArray1[index3] / 65536f);
        vData1[index2] = (float) num5;
        float[] vData2 = this.vData;
        int index4 = num3;
        num2 = index4 + 1;
        int[] numArray2 = src;
        int index5 = num4;
        num1 = index5 + 1;
        double num6 = (double) ((float) numArray2[index5] / 65536f);
        vData2[index4] = (float) num6;
        if (componentCount > 2)
          this.vData[num2++] = (float) src[num1++] / 65536f;
        if (componentCount > 3)
          this.vData[num2++] = (float) src[num1++] / 65536f;
      }
    }

    public void set(int firstVertex, int numVertices, short[] src)
    {
      int num1 = 0;
      int componentCount = this.getComponentCount();
      int num2 = firstVertex * componentCount;
      for (int index1 = 0; index1 < numVertices; ++index1)
      {
        if (this.m_componentType == 2)
        {
          float[] vData1 = this.vData;
          int index2 = num2;
          int num3 = index2 + 1;
          short[] numArray1 = src;
          int index3 = num1;
          int num4 = index3 + 1;
          double num5 = (double) numArray1[index3];
          vData1[index2] = (float) num5;
          float[] vData2 = this.vData;
          int index4 = num3;
          num2 = index4 + 1;
          short[] numArray2 = src;
          int index5 = num4;
          num1 = index5 + 1;
          double num6 = (double) numArray2[index5];
          vData2[index4] = (float) num6;
          if (componentCount > 2)
            this.vData[num2++] = (float) src[num1++];
          if (componentCount > 3)
            this.vData[num2++] = (float) src[num1++];
        }
        else if (this.m_componentType == 5)
        {
          float[] vData1 = this.vData;
          int index2 = num2;
          int num3 = index2 + 1;
          short[] numArray1 = src;
          int index3 = num1;
          int num4 = index3 + 1;
          double num5 = (double) VertexArray.halfToFloat(numArray1[index3]);
          vData1[index2] = (float) num5;
          float[] vData2 = this.vData;
          int index4 = num3;
          num2 = index4 + 1;
          short[] numArray2 = src;
          int index5 = num4;
          num1 = index5 + 1;
          double num6 = (double) VertexArray.halfToFloat(numArray2[index5]);
          vData2[index4] = (float) num6;
          if (componentCount > 2)
            this.vData[num2++] = VertexArray.halfToFloat(src[num1++]);
          if (componentCount > 3)
            this.vData[num2++] = VertexArray.halfToFloat(src[num1++]);
        }
      }
    }

    private static float halfToFloat(short v)
    {
      int num1 = v > (short) 0 ? -1 : 1;
      int num2 = ((int) v >> 10 & 31) - 15;
      float num3 = (float) ((int) v & 1023) / 1024f;
      if (num2 != -15)
        ++num3;
      return (float) ((double) num1 * (double) num3 * (double) (1 << num2 + 15) / 32768.0);
    }

    public override int getM3GUniqueClassID()
    {
      return 20;
    }
  }
}
