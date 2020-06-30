// Decompiled with JetBrains decompiler
// Type: m3g.VertexBuffer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using System;

namespace m3g
{
  public class VertexBuffer : Object3D
  {
    private Vector3 xnaDiffuse = Vector3.One;
    public new const int M3G_UNIQUE_CLASS_ID = 21;
    private int m_vertexCount;
    private int m_defaultColor;
    private VertexArray m_positions;
    private float m_positionScale;
    private float m_positionBiasX;
    private float m_positionBiasY;
    private float m_positionBiasZ;
    private VertexArray m_colors;
    private VertexArray m_normals;
    private VertexArray m_pointSizes;
    private VertexArrayTextureUnit[] m_textureUnits;
    private VertexArray m_skinIndices;
    private VertexArray m_skinWeights;
    public Vertex[] finalVertexData;
    public Vertex[] skinVertexDataTransformed;
    private bool m_mutable;

    public static bool verifyTextureUnit(int index)
    {
      return index >= 0 && index < 2;
    }

    protected override void duplicateTo(ref Object3D ret)
    {
      base.duplicateTo(ref ret);
      VertexBuffer vertexBuffer = (VertexBuffer) ret;
      vertexBuffer.setDefaultColor(this.getDefaultColor());
      float[] scaleBias1 = new float[4];
      VertexArray positions = this.getPositions(ref scaleBias1);
      float scale1 = scaleBias1[0];
      float[] bias1 = new float[scaleBias1.Length - 1];
      Array.Copy((Array) scaleBias1, 1, (Array) bias1, 0, scaleBias1.Length - 1);
      vertexBuffer.setPositions(positions, scale1, bias1);
      vertexBuffer.setColors(this.getColors());
      vertexBuffer.setNormals(this.getNormals());
      vertexBuffer.setPointSizes(this.getPointSizes());
      float[] scaleBias2 = new float[4];
      for (int index = 0; index < 2; ++index)
      {
        VertexArray texCoords = this.getTexCoords(index, ref scaleBias2);
        float[] bias2 = new float[scaleBias2.Length - 1];
        Array.Copy((Array) scaleBias2, 1, (Array) bias2, 0, scaleBias2.Length - 1);
        float scale2 = scaleBias2[0];
        vertexBuffer.setTexCoords(index, texCoords, scale2, bias2);
      }
    }

    public VertexBuffer()
    {
      this.m_vertexCount = 0;
      this.m_defaultColor = -1;
      this.m_positions = (VertexArray) null;
      this.m_positionScale = 1f;
      this.m_positionBiasX = 0.0f;
      this.m_positionBiasY = 0.0f;
      this.m_positionBiasZ = 0.0f;
      this.m_colors = (VertexArray) null;
      this.m_normals = (VertexArray) null;
      this.m_skinIndices = (VertexArray) null;
      this.m_skinWeights = (VertexArray) null;
      this.m_textureUnits = new VertexArrayTextureUnit[2];
      this.m_mutable = true;
      this.m_pointSizes = (VertexArray) null;
    }

    public VertexArray getColors()
    {
      return this.m_colors;
    }

    public int getDefaultColor()
    {
      return this.m_defaultColor;
    }

    public Vector3 getXnaDiffuse()
    {
      return this.xnaDiffuse;
    }

    public VertexArray getNormals()
    {
      return this.m_normals;
    }

    public VertexArray getPositions(ref float[] scaleBias)
    {
      if (scaleBias != null)
      {
        scaleBias[0] = this.m_positionScale;
        scaleBias[1] = this.m_positionBiasX;
        scaleBias[2] = this.m_positionBiasY;
        scaleBias[3] = this.m_positionBiasZ;
      }
      return this.m_positions;
    }

    public VertexArray getTexCoords(int index, ref float[] scaleBias)
    {
      if (!VertexBuffer.verifyTextureUnit(index))
        return (VertexArray) null;
      VertexArrayTextureUnit textureUnit = this.m_textureUnits[index];
      if (textureUnit == null)
        return (VertexArray) null;
      if (scaleBias != null)
      {
        scaleBias[0] = textureUnit.texcoordScale;
        scaleBias[1] = textureUnit.texcoordBiasU;
        scaleBias[2] = textureUnit.texcoordBiasV;
        scaleBias[3] = 0.0f;
      }
      return textureUnit.texcoords;
    }

    public int getVertexCount()
    {
      return this.m_vertexCount;
    }

    public void setColors(VertexArray arr)
    {
      if (!this.verifyMutable())
        return;
      this.m_colors = arr;
      this.updateVertexCount();
      this.processColors();
    }

    public void setDefaultColor(int ARGB)
    {
      this.xnaDiffuse = new Vector3((float) (ARGB >> 16 & (int) byte.MaxValue) / (float) byte.MaxValue, (float) (ARGB >> 8 & (int) byte.MaxValue) / (float) byte.MaxValue, (float) (ARGB & (int) byte.MaxValue) / (float) byte.MaxValue);
      this.m_defaultColor = ARGB;
    }

    public void setNormals(VertexArray arr)
    {
      if (!this.verifyMutable())
        return;
      this.m_normals = arr;
      this.updateVertexCount();
      this.processNormals();
    }

    public void setPointSizes(VertexArray pointSizes)
    {
      this.m_pointSizes = pointSizes;
      this.updateVertexCount();
    }

    public void setPositions(VertexArray arr, float scale, float[] bias)
    {
      if (!this.verifyMutable())
        return;
      this.m_positions = arr;
      this.m_positionScale = scale;
      if (bias != null)
      {
        this.m_positionBiasX = bias[0];
        this.m_positionBiasY = bias[1];
        this.m_positionBiasZ = bias[2];
      }
      else
      {
        this.m_positionBiasX = 0.0f;
        this.m_positionBiasY = 0.0f;
        this.m_positionBiasZ = 0.0f;
      }
      this.updateVertexCount();
      this.processPositions();
    }

    public void setTexCoords(int index, VertexArray arr, float scale, float[] bias)
    {
      if (!VertexBuffer.verifyTextureUnit(index) || !this.verifyMutable())
        return;
      VertexArrayTextureUnit textureUnit = this.m_textureUnits[index];
      this.m_textureUnits[index] = arr == null ? (VertexArrayTextureUnit) null : new VertexArrayTextureUnit(arr, scale, bias);
      if (textureUnit != null)
        ;
      this.updateVertexCount();
      this.processTextureCoords(index);
    }

    public VertexArray getSkinIndices()
    {
      return this.m_skinIndices;
    }

    public VertexArray getSkinWeights()
    {
      return this.m_skinWeights;
    }

    private bool verifyMutable()
    {
      return this.m_mutable;
    }

    private void updateVertexCount()
    {
      if (this.m_positions != null)
        this.m_vertexCount = this.m_positions.getVertexCount();
      else if (this.m_colors != null)
        this.m_vertexCount = this.m_colors.getVertexCount();
      else if (this.m_normals != null)
        this.m_vertexCount = this.m_normals.getVertexCount();
      else if (this.m_textureUnits[0] != null)
        this.m_vertexCount = this.m_textureUnits[0].getVertexCount();
      else if (this.m_textureUnits[1] != null)
        this.m_vertexCount = this.m_textureUnits[1].getVertexCount();
      else
        this.m_vertexCount = 0;
    }

    private VertexArray getPointSizes()
    {
      return this.m_pointSizes;
    }

    public void commit()
    {
    }

    private void processPositions()
    {
      int vertexCount = this.m_positions.getVertexCount();
      if (vertexCount <= 0)
        return;
      if (this.finalVertexData == null)
        this.finalVertexData = new Vertex[vertexCount];
      float[] values = new float[vertexCount * 3];
      this.m_positions.get(0, vertexCount, ref values);
      int num1 = 0;
      for (int index1 = 0; index1 < vertexCount; ++index1)
      {
        ref Vector3 local1 = ref this.finalVertexData[index1].position;
        float[] numArray1 = values;
        int index2 = num1;
        int num2 = index2 + 1;
        double num3 = (double) numArray1[index2] * (double) this.m_positionScale + (double) this.m_positionBiasX;
        local1.X = (float) num3;
        ref Vector3 local2 = ref this.finalVertexData[index1].position;
        float[] numArray2 = values;
        int index3 = num2;
        int num4 = index3 + 1;
        double num5 = (double) numArray2[index3] * (double) this.m_positionScale + (double) this.m_positionBiasY;
        local2.Y = (float) num5;
        ref Vector3 local3 = ref this.finalVertexData[index1].position;
        float[] numArray3 = values;
        int index4 = num4;
        num1 = index4 + 1;
        double num6 = (double) numArray3[index4] * (double) this.m_positionScale + (double) this.m_positionBiasZ;
        local3.Z = (float) num6;
      }
    }

    public void processTextureCoords(int index)
    {
      if (this.m_textureUnits == null || this.m_textureUnits[index] == null)
        return;
      int vertexCount = this.m_textureUnits[index].texcoords.getVertexCount();
      if (vertexCount <= 0)
        return;
      if (this.finalVertexData == null)
        this.finalVertexData = new Vertex[vertexCount];
      float[] values = new float[vertexCount * this.m_textureUnits[index].texcoords.getComponentCount()];
      this.m_textureUnits[index].texcoords.get(0, vertexCount, ref values);
      int num1 = 0;
      for (int index1 = 0; index1 < vertexCount; ++index1)
      {
        Vector2 zero = Vector2.Zero;
        ref Vector2 local1 = ref zero;
        float[] numArray1 = values;
        int index2 = num1;
        int num2 = index2 + 1;
        double num3 = (double) numArray1[index2] * (double) this.m_textureUnits[index].texcoordScale + (double) this.m_textureUnits[index].texcoordBiasU;
        local1.X = (float) num3;
        ref Vector2 local2 = ref zero;
        float[] numArray2 = values;
        int index3 = num2;
        num1 = index3 + 1;
        double num4 = (double) numArray2[index3] * (double) this.m_textureUnits[index].texcoordScale + (double) this.m_textureUnits[index].texcoordBiasV;
        local2.Y = (float) num4;
        if (this.m_textureUnits[index].texcoords.getComponentCount() > 2)
          ++num1;
        if (index == 0)
          this.finalVertexData[index1].textureCoordinate = zero;
        else
          this.finalVertexData[index1].textureCoordinate2 = zero;
      }
    }

    public void processColors()
    {
      if (this.m_colors == null)
        return;
      int vertexCount = this.m_colors.getVertexCount();
      if (vertexCount <= 0)
        return;
      if (this.finalVertexData == null)
        this.finalVertexData = new Vertex[vertexCount];
      float[] values = new float[vertexCount * this.m_colors.getComponentCount()];
      this.m_colors.get(0, vertexCount, ref values);
      int num1 = 0;
      for (int index1 = 0; index1 < vertexCount; ++index1)
      {
        float[] numArray1 = values;
        int index2 = num1;
        int num2 = index2 + 1;
        byte num3 = (byte) numArray1[index2];
        float[] numArray2 = values;
        int index3 = num2;
        int num4 = index3 + 1;
        byte num5 = (byte) numArray2[index3];
        float[] numArray3 = values;
        int index4 = num4;
        num1 = index4 + 1;
        byte num6 = (byte) numArray3[index4];
        this.finalVertexData[index1].color = this.m_colors.getComponentCount() != 4 ? new Color((int) num3, (int) num5, (int) num6, (int) byte.MaxValue) : new Color((int) num3, (int) num5, (int) num6, (int) (byte) values[num1++]);
      }
    }

    private void processNormals()
    {
      if (this.m_normals == null)
        return;
      int vertexCount = this.m_normals.getVertexCount();
      if (vertexCount <= 0)
        return;
      if (this.finalVertexData == null)
        this.finalVertexData = new Vertex[vertexCount];
      float[] values = new float[vertexCount * 3];
      this.m_normals.get(0, vertexCount, ref values);
      int num1 = 0;
      for (int index1 = 0; index1 < vertexCount; ++index1)
      {
        ref Vector3 local1 = ref this.finalVertexData[index1].normal;
        float[] numArray1 = values;
        int index2 = num1;
        int num2 = index2 + 1;
        double num3 = (double) numArray1[index2];
        local1.X = (float) num3;
        ref Vector3 local2 = ref this.finalVertexData[index1].normal;
        float[] numArray2 = values;
        int index3 = num2;
        int num4 = index3 + 1;
        double num5 = (double) numArray2[index3];
        local2.Y = (float) num5;
        ref Vector3 local3 = ref this.finalVertexData[index1].normal;
        float[] numArray3 = values;
        int index4 = num4;
        num1 = index4 + 1;
        double num6 = (double) numArray3[index4];
        local3.Z = (float) num6;
      }
    }

    public void setSkinTransformed()
    {
      this.skinVertexDataTransformed = new Vertex[this.finalVertexData.Length];
      for (int index = 0; index < this.finalVertexData.Length; ++index)
      {
        this.skinVertexDataTransformed[index].position.X = this.finalVertexData[index].position.X;
        this.skinVertexDataTransformed[index].position.Y = this.finalVertexData[index].position.Y;
        this.skinVertexDataTransformed[index].position.Z = this.finalVertexData[index].position.Z;
        this.skinVertexDataTransformed[index].normal.X = this.finalVertexData[index].normal.X;
        this.skinVertexDataTransformed[index].normal.Y = this.finalVertexData[index].normal.Y;
        this.skinVertexDataTransformed[index].normal.Z = this.finalVertexData[index].normal.Z;
        this.skinVertexDataTransformed[index].skinIndex.X = this.finalVertexData[index].skinIndex.X;
        this.skinVertexDataTransformed[index].skinIndex.Y = this.finalVertexData[index].skinIndex.Y;
        this.skinVertexDataTransformed[index].skinIndex.Z = this.finalVertexData[index].skinIndex.Z;
        this.skinVertexDataTransformed[index].skinIndex.W = this.finalVertexData[index].skinIndex.W;
        this.skinVertexDataTransformed[index].skinWeight.X = this.finalVertexData[index].skinWeight.X;
        this.skinVertexDataTransformed[index].skinWeight.Y = this.finalVertexData[index].skinWeight.Y;
        this.skinVertexDataTransformed[index].skinWeight.Z = this.finalVertexData[index].skinWeight.Z;
        this.skinVertexDataTransformed[index].skinWeight.W = this.finalVertexData[index].skinWeight.W;
        this.skinVertexDataTransformed[index].textureCoordinate.X = this.finalVertexData[index].textureCoordinate.X;
        this.skinVertexDataTransformed[index].textureCoordinate.Y = this.finalVertexData[index].textureCoordinate.Y;
        this.skinVertexDataTransformed[index].color.R = this.finalVertexData[index].color.R;
        this.skinVertexDataTransformed[index].color.G = this.finalVertexData[index].color.G;
        this.skinVertexDataTransformed[index].color.B = this.finalVertexData[index].color.B;
        this.skinVertexDataTransformed[index].color.A = this.finalVertexData[index].color.A;
      }
    }

    public Vertex[] getFinalVertices()
    {
      return this.finalVertexData;
    }

    public override int getM3GUniqueClassID()
    {
      return 21;
    }

    public static VertexBuffer m3g_cast(Object3D obj)
    {
      return obj.getM3GUniqueClassID() == 21 ? (VertexBuffer) obj : (VertexBuffer) null;
    }
  }
}
