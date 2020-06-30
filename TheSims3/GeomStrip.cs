// Decompiled with JetBrains decompiler
// Type: GeomStrip
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g;
using System;

public class GeomStrip
{
  internal static readonly int[] ADD_PANEL_EDGE_FLAGS = new int[9]
  {
    21,
    4,
    70,
    1,
    0,
    2,
    41,
    8,
    138
  };
  public const float TEXCOORDS_SCALE = 0.0001220703f;
  public const float COORDS_SCALE = 1f;
  public const int POS_COMPONENTS_NUM = 3;
  public const int POS_COMPONENTS_SIZE = 2;
  public const int TEX_COMPONENTS_NUM = 2;
  public const int TEX_COMPONENTS_SIZE = 2;
  public const int COL_COMPONENTS_NUM = 4;
  public const int COL_COMPONENTS_SIZE = 1;
  public const int TEXTURE_RANGE = 8192;
  public const int TEXTURE_SHIFT = 3;
  public const int TEX_BORDER_IN = 8;
  public const int VCOLOR_DIMMED = 160;
  public const int VCOLOR_BRIGHT = 255;
  public const int FLAG_DIM_A1_START = 1;
  public const int FLAG_DIM_A1_END = 2;
  public const int FLAG_DIM_A2_START = 4;
  public const int FLAG_DIM_A2_END = 8;
  public const int FLAG_DIM_C00 = 16;
  public const int FLAG_DIM_C01 = 32;
  public const int FLAG_DIM_C10 = 64;
  public const int FLAG_DIM_C11 = 128;
  private int[] m_indices;
  private short[] m_posCoords;
  private short[] m_texCoords;
  private sbyte[] m_colCoords;

  public GeomStrip()
  {
    this.m_indices = (int[]) null;
    this.m_posCoords = (short[]) null;
    this.m_texCoords = (short[]) null;
    this.m_colCoords = (sbyte[]) null;
  }

  public virtual void Dispose()
  {
  }

  private void addBasicPanel(
    int p11,
    int p12,
    int p21,
    int p22,
    int p3,
    GeomStrip.Axis a1,
    GeomStrip.Axis a2,
    int tileSizeA1,
    int tileSizeA2,
    int[] textureCoords)
  {
    this.addTrimmedPanel(p11, p12, p21, p22, p3, a1, a2, tileSizeA1, tileSizeA2, textureCoords, 0, 0, 0, 0);
  }

  private void addTrimmedPanel(
    int p11,
    int p12,
    int p21,
    int p22,
    int p3,
    GeomStrip.Axis a1,
    GeomStrip.Axis a2,
    int tileSizeA1,
    int tileSizeA2,
    int[] textureCoords,
    int trimStart1,
    int trimEnd1,
    int trimStart2,
    int trimEnd2)
  {
    this.addTrimmedPanel(p11, p12, p21, p22, p3, a1, a2, tileSizeA1, tileSizeA2, textureCoords, trimStart1, trimEnd1, trimStart2, trimEnd2, 0);
  }

  private void addTrimmedPanel(
    int p11,
    int p12,
    int p21,
    int p22,
    int p3,
    GeomStrip.Axis a1,
    GeomStrip.Axis a2,
    int tileSizeA1,
    int tileSizeA2,
    int[] textureCoords,
    int trimStart1,
    int trimEnd1,
    int trimStart2,
    int trimEnd2,
    int flags)
  {
    GeomStrip.Axis axis = (GeomStrip.Axis) (3 - a1 - a2);
    int num1 = (textureCoords[0] << 3) + 8;
    int num2 = (8192 - textureCoords[1] << 3) - 8;
    int num3 = (textureCoords[0] + textureCoords[2] << 3) - 8;
    int num4 = (8192 - textureCoords[1] - textureCoords[3] << 3) + 8;
    int num5 = p21 - p11;
    int num6 = p22 - p12;
    int num7 = midp.JMath.abs(num5 / tileSizeA1);
    int num8 = midp.JMath.abs(num6 / tileSizeA2);
    int num9 = num5 / num7;
    int num10 = num6 / num8;
    int num11 = num5 > 0 ? 1 : -1;
    int num12 = num6 > 0 ? 1 : -1;
    int num13 = num7 + 1;
    int num14 = num8 + 1;
    int num15 = num13 * num14;
    int indicesLength = num7 * num8 * 2 * 3;
    int[] indices = new int[indicesLength];
    short[] posCoords = new short[3 * num15];
    short[] texCoords = new short[2 * num15];
    sbyte[] colCoords = new sbyte[4 * num15];
    int num16 = 0;
    int index1 = 0;
    int index2 = 0;
    for (int index3 = 0; index3 < num14; ++index3)
    {
      int num17 = p12 + index3 * num10;
      int num18 = (index3 & 1) == 0 ? (int) (short) num2 : (int) (short) num4;
      if (trimStart2 != 0 && index3 == 0)
      {
        num17 += num12 * trimStart2;
        num18 += (num4 - num2) * trimStart2 / tileSizeA2;
      }
      if (trimEnd2 != 0 && index3 == num14 - 1)
      {
        num17 -= num12 * trimEnd2;
        num18 += ((index3 & 1) == 0 ? 1 : -1) * ((num4 - num2) * trimEnd2 / tileSizeA2);
      }
      for (int index4 = 0; index4 < num13; ++index4)
      {
        int num19 = p11 + index4 * num9;
        int num20 = (index4 & 1) == 0 ? (int) (short) num1 : (int) (short) num3;
        if (trimStart1 != 0 && index4 == 0)
        {
          num19 += num11 * trimStart1;
          num20 += (num3 - num1) * trimStart1 / tileSizeA1;
        }
        if (trimEnd1 != 0 && index4 == num13 - 1)
        {
          num19 -= num11 * trimEnd1;
          num20 += ((index4 & 1) == 0 ? 1 : -1) * ((num3 - num1) * trimEnd1 / tileSizeA1);
        }
        int num21 = (int) byte.MaxValue;
        int index5 = (index4 == 0 ? 0 : (index4 == num13 - 1 ? 2 : 1)) + (index3 == 0 ? 0 : (index3 == num14 - 1 ? 2 : 1)) * 3;
        if ((GeomStrip.ADD_PANEL_EDGE_FLAGS[index5] & flags) != 0)
          num21 = 160;
        posCoords[(int) (num16 + a1)] = (short) num19;
        posCoords[(int) (num16 + a2)] = (short) num17;
        posCoords[(int) (num16 + axis)] = (short) p3;
        texCoords[index1] = (short) num20;
        texCoords[index1 + 1] = (short) num18;
        colCoords[index2] = (sbyte) num21;
        colCoords[index2 + 1] = (sbyte) num21;
        colCoords[index2 + 2] = (sbyte) num21;
        colCoords[index2 + 3] = (sbyte) -1;
        num16 += 3;
        index1 += 2;
        index2 += 4;
      }
    }
    int index6 = 0;
    for (int index3 = 0; index3 < num7; ++index3)
    {
      for (int index4 = 0; index4 < num8; ++index4)
      {
        int num17 = index3 + index4 * num13;
        int num18 = index3 + 1 + index4 * num13;
        int num19 = index3 + (index4 + 1) * num13;
        int num20 = index3 + 1 + (index4 + 1) * num13;
        indices[index6] = num17;
        indices[index6 + 1] = num19;
        indices[index6 + 2] = num18;
        int index5 = index6 + 3;
        indices[index5] = num18;
        indices[index5 + 1] = num19;
        indices[index5 + 2] = num20;
        index6 = index5 + 3;
      }
    }
    this.addGeom(indices, indicesLength, posCoords, num15 * 3, texCoords, num15 * 2, colCoords, num15 * 4);
  }

  public void addFloor(
    int panelX,
    int panelZ,
    int panelW,
    int panelH,
    int[] texCoords,
    int trimStartX,
    int trimEndX,
    int trimStartZ,
    int trimEndZ)
  {
    this.addFloor(panelX, panelZ, panelW, panelH, texCoords, trimStartX, trimEndX, trimStartZ, trimEndZ, 0);
  }

  public void addFloor(
    int panelX,
    int panelZ,
    int panelW,
    int panelH,
    int[] texCoords,
    int trimStartX,
    int trimEndX,
    int trimStartZ,
    int trimEndZ,
    int flags)
  {
    this.addTrimmedPanel(panelX, panelZ, panelX + panelW, panelZ + panelH, 0, GeomStrip.Axis.AXIS_X, GeomStrip.Axis.AXIS_Z, 32, 32, texCoords, trimStartX, trimEndX, trimStartZ, trimEndZ, flags);
  }

  public void addTallWallTop(
    int panelX,
    int panelZ,
    int panelW,
    GeomStrip.Dir dir,
    int[] texCoords,
    int trimStart,
    int trimEnd)
  {
    this.addWallTop(96, panelX, panelZ, panelW, dir, texCoords, trimStart, trimEnd);
  }

  public void addShortWallTop(
    int panelX,
    int panelZ,
    int panelW,
    GeomStrip.Dir dir,
    int[] texCoords,
    int trimStart,
    int trimEnd)
  {
    this.addWallTop(12, panelX, panelZ, panelW, dir, texCoords, trimStart, trimEnd);
  }

  public void addDoorWall(
    int panelX,
    int panelZ,
    int panelW,
    GeomStrip.Dir dir,
    int[] texCoords,
    int trimStart,
    int trimEnd)
  {
    this.addDoorWall(panelX, panelZ, panelW, dir, texCoords, trimStart, trimEnd, 0);
  }

  public void addDoorWall(
    int panelX,
    int panelZ,
    int panelW,
    GeomStrip.Dir dir,
    int[] texCoords,
    int trimStart,
    int trimEnd,
    int flags)
  {
    int num = texCoords[3] * 16 / 96;
    int[] texCoords1 = new int[4]
    {
      texCoords[0],
      texCoords[1],
      texCoords[2],
      num
    };
    this.addWall(96, 80, 16, panelX, panelZ, panelW, dir, texCoords1, trimStart, trimEnd, flags);
  }

  public void addWindowWall(
    int panelX,
    int panelZ,
    int panelW,
    GeomStrip.Dir dir,
    int[] texCoords,
    int trimStart,
    int trimEnd)
  {
    this.addWindowWall(panelX, panelZ, panelW, dir, texCoords, trimStart, trimEnd, 0);
  }

  public void addWindowWall(
    int panelX,
    int panelZ,
    int panelW,
    GeomStrip.Dir dir,
    int[] texCoords,
    int trimStart,
    int trimEnd,
    int flags)
  {
    this.addDoorWall(panelX, panelZ, panelW, dir, texCoords, trimStart, trimEnd, flags);
    int num1 = texCoords[1] + texCoords[3] * 58 / 96;
    int num2 = texCoords[3] * 26 / 96;
    int[] texCoords1 = new int[4]
    {
      texCoords[0],
      num1,
      texCoords[2],
      num2
    };
    this.addWall(38, 12, 26, panelX, panelZ, panelW, dir, texCoords1, trimStart, trimEnd, flags);
  }

  public void addShortWall(
    int panelX,
    int panelZ,
    int panelW,
    GeomStrip.Dir dir,
    int[] texCoords,
    int trimStart,
    int trimEnd)
  {
    this.addShortWall(panelX, panelZ, panelW, dir, texCoords, trimStart, trimEnd, 0);
  }

  public void addShortWall(
    int panelX,
    int panelZ,
    int panelW,
    GeomStrip.Dir dir,
    int[] texCoords,
    int trimStart,
    int trimEnd,
    int flags)
  {
    flags |= 8;
    int num = texCoords[3] * 12 / 96;
    int[] texCoords1 = new int[4]
    {
      texCoords[0],
      texCoords[1] + texCoords[3] - num,
      texCoords[2],
      num
    };
    this.addWall(12, 0, 12, panelX, panelZ, panelW, dir, texCoords1, trimStart, trimEnd, flags);
  }

  public void addCap(
    int p12,
    int p22,
    int panelX,
    int panelZ,
    GeomStrip.Dir dir,
    int[] texCoords)
  {
    this.addCap(p12, p22, panelX, panelZ, dir, texCoords, 0);
  }

  public void addCap(
    int p12,
    int p22,
    int panelX,
    int panelZ,
    GeomStrip.Dir dir,
    int[] texCoords,
    int flags)
  {
    GeomStrip.Axis a1 = GeomStrip.Axis.AXIS_X;
    int p11 = 0;
    int p21 = 0;
    int p3 = 0;
    int tileSizeA2 = p12 - p22;
    switch (dir)
    {
      case GeomStrip.Dir.DIR_X_POS:
        a1 = GeomStrip.Axis.AXIS_Z;
        p11 = panelZ - 2;
        p21 = panelZ;
        p3 = panelX;
        break;
      case GeomStrip.Dir.DIR_Z_POS:
        a1 = GeomStrip.Axis.AXIS_X;
        p11 = panelX + 2;
        p21 = panelX;
        p3 = panelZ;
        break;
      case GeomStrip.Dir.DIR_X_NEG:
        a1 = GeomStrip.Axis.AXIS_Z;
        p11 = panelZ + 2;
        p21 = panelZ;
        p3 = panelX;
        break;
      case GeomStrip.Dir.DIR_Z_NEG:
        a1 = GeomStrip.Axis.AXIS_X;
        p11 = panelX - 2;
        p21 = panelX;
        p3 = panelZ;
        break;
    }
    this.addTrimmedPanel(p11, p12, p21, p22, p3, a1, GeomStrip.Axis.AXIS_Y, 2, tileSizeA2, texCoords, 0, 0, 0, 0, flags);
  }

  public void addTallCap(int panelX, int panelZ, GeomStrip.Dir dir, int[] texCoords)
  {
    this.addCap(96, 12, panelX, panelZ, dir, texCoords);
  }

  public void addShortCap(int panelX, int panelZ, GeomStrip.Dir dir, int[] texCoords)
  {
    this.addCap(12, 0, panelX, panelZ, dir, texCoords, 8);
  }

  private void addGeom(
    int[] indices,
    int indicesLength,
    short[] posCoords,
    int posLength,
    short[] texCoords,
    int texLength,
    sbyte[] colCoords,
    int colLength)
  {
    if (this.m_indices == null)
    {
      this.m_indices = new int[indicesLength];
      midp.JSystem.arraycopy((Array) indices, 0, (Array) this.m_indices, 0, indicesLength);
      this.m_posCoords = new short[posLength];
      midp.JSystem.arraycopy((Array) posCoords, 0, (Array) this.m_posCoords, 0, posLength);
      this.m_texCoords = new short[texLength];
      midp.JSystem.arraycopy((Array) texCoords, 0, (Array) this.m_texCoords, 0, texLength);
      this.m_colCoords = new sbyte[colLength];
      midp.JSystem.arraycopy((Array) colCoords, 0, (Array) this.m_colCoords, 0, colLength);
    }
    else
    {
      int num = this.m_posCoords.Length / 3;
      int length = this.m_indices.Length;
      int[] numArray1 = new int[this.m_indices.Length + indicesLength];
      midp.JSystem.arraycopy((Array) this.m_indices, 0, (Array) numArray1, 0, this.m_indices.Length);
      midp.JSystem.arraycopy((Array) indices, 0, (Array) numArray1, length, indicesLength);
      for (int index = 0; index < indicesLength; ++index)
        numArray1[length + index] += num;
      this.m_indices = numArray1;
      short[] numArray2 = new short[this.m_posCoords.Length + posLength];
      midp.JSystem.arraycopy((Array) this.m_posCoords, 0, (Array) numArray2, 0, this.m_posCoords.Length);
      midp.JSystem.arraycopy((Array) posCoords, 0, (Array) numArray2, this.m_posCoords.Length, posLength);
      this.m_posCoords = numArray2;
      short[] numArray3 = new short[this.m_texCoords.Length + texLength];
      midp.JSystem.arraycopy((Array) this.m_texCoords, 0, (Array) numArray3, 0, this.m_texCoords.Length);
      midp.JSystem.arraycopy((Array) texCoords, 0, (Array) numArray3, this.m_texCoords.Length, texLength);
      this.m_texCoords = numArray3;
      sbyte[] numArray4 = new sbyte[this.m_colCoords.Length + colLength];
      midp.JSystem.arraycopy((Array) this.m_colCoords, 0, (Array) numArray4, 0, this.m_colCoords.Length);
      midp.JSystem.arraycopy((Array) colCoords, 0, (Array) numArray4, this.m_colCoords.Length, colLength);
      this.m_colCoords = numArray4;
    }
  }

  public int getQuadCount()
  {
    return this.m_indices != null ? (this.m_indices.Length >> 1) + 1 : 0;
  }

  public Mesh createMesh()
  {
    int num = this.m_posCoords.Length / 3;
    VertexArray arr1 = new VertexArray(num, 3, 2);
    arr1.set(0, num, this.m_posCoords);
    VertexArray arr2 = new VertexArray(num, 2, 2);
    arr2.set(0, num, this.m_texCoords);
    VertexArray arr3 = new VertexArray(num, 4, 1);
    arr3.set(0, num, this.m_colCoords);
    VertexBuffer vertices = new VertexBuffer();
    float[] bias = (float[]) null;
    vertices.setPositions(arr1, 1f, bias);
    vertices.setTexCoords(0, arr2, 0.0001220703f, (float[]) null);
    vertices.setColors(arr3);
    IndexBuffer submesh = new IndexBuffer(8, this.m_indices.Length / 3, this.m_indices);
    this.m_indices = new int[0];
    this.m_posCoords = new short[0];
    this.m_texCoords = new short[0];
    this.m_colCoords = new sbyte[0];
    return new Mesh(vertices, submesh, (Appearance) null);
  }

  public static Mesh createMesh(GeomStrip[] subGeomStrips)
  {
    int length1 = subGeomStrips.Length;
    IndexBuffer[] submeshes = new IndexBuffer[length1];
    int vertexCount = 0;
    for (int index = 0; index < length1; ++index)
    {
      GeomStrip subGeomStrip = subGeomStrips[index];
      if (subGeomStrip != null)
      {
        int num = subGeomStrip.m_posCoords.Length / 3;
        vertexCount += num;
      }
    }
    VertexArray arr1 = new VertexArray(vertexCount, 3, 2);
    VertexArray arr2 = new VertexArray(vertexCount, 2, 2);
    VertexArray arr3 = new VertexArray(vertexCount, 4, 1);
    int firstVertex = 0;
    for (int index1 = 0; index1 < length1; ++index1)
    {
      GeomStrip subGeomStrip = subGeomStrips[index1];
      if (subGeomStrip != null)
      {
        int numVertices = subGeomStrip.m_posCoords.Length / 3;
        arr1.set(firstVertex, numVertices, subGeomStrip.m_posCoords);
        arr2.set(firstVertex, numVertices, subGeomStrip.m_texCoords);
        arr3.set(firstVertex, numVertices, subGeomStrip.m_colCoords);
        int length2 = subGeomStrip.m_indices.Length;
        int[] indices = new int[length2];
        for (int index2 = 0; index2 < length2; ++index2)
          indices[index2] = subGeomStrip.m_indices[index2] + firstVertex;
        IndexBuffer indexBuffer = new IndexBuffer(8, length2 / 3, indices);
        submeshes[index1] = indexBuffer;
        firstVertex += numVertices;
      }
    }
    VertexBuffer vertices = new VertexBuffer();
    float[] bias = (float[]) null;
    vertices.setPositions(arr1, 1f, bias);
    vertices.setTexCoords(0, arr2, 0.0001220703f, (float[]) null);
    vertices.setColors(arr3);
    Appearance[] appearances = new Appearance[0];
    return new Mesh(vertices, ref submeshes, ref appearances);
  }

  public static void setAlpha(int alpha, Mesh mesh)
  {
    if (mesh == null)
      return;
    VertexArray colors = mesh.getVertexBuffer().getColors();
    int vertexCount = colors.getVertexCount();
    sbyte[] numArray = new sbyte[vertexCount * 4];
    colors.get(0, vertexCount, numArray);
    for (int index = 0; index < vertexCount; ++index)
      numArray[index * 4 + 3] = (sbyte) alpha;
    colors.set(0, vertexCount, numArray);
  }

  public static void setTint(int color, Mesh mesh)
  {
    if (mesh == null)
      return;
    VertexBuffer vertexBuffer = mesh.getVertexBuffer();
    vertexBuffer.setColors((VertexArray) null);
    int num = -16777216;
    vertexBuffer.setDefaultColor(color | num);
  }

  public static void setTint(int color, Mesh mesh, int submeshIndex)
  {
    if (mesh == null || mesh.getIndexBuffer(submeshIndex) == null)
      return;
    VertexBuffer vertexBuffer = mesh.getVertexBuffer();
    vertexBuffer.setColors((VertexArray) null);
    int num = -16777216;
    vertexBuffer.setDefaultColor(color | num);
  }

  public static void remapTexCoords(Mesh mesh, int[] fromTexCoords, int[] toTexCoords)
  {
    int num1 = fromTexCoords[0] << 3;
    int num2 = 8192 - fromTexCoords[1] << 3;
    int num3 = fromTexCoords[0] + fromTexCoords[2] << 3;
    int num4 = 8192 - fromTexCoords[1] - fromTexCoords[3] << 3;
    int num5 = toTexCoords[0] << 3;
    int num6 = 8192 - toTexCoords[1] << 3;
    int toTexCoord1 = toTexCoords[0];
    int toTexCoord2 = toTexCoords[2];
    int toTexCoord3 = toTexCoords[1];
    int toTexCoord4 = toTexCoords[3];
    float[] scaleBias = new float[10];
    VertexArray texCoords = mesh.getVertexBuffer().getTexCoords(0, ref scaleBias);
    int vertexCount = texCoords.getVertexCount();
    for (int firstVertex = 0; firstVertex < vertexCount; ++firstVertex)
    {
      short[] values = new short[2];
      texCoords.get(firstVertex, 1, ref values);
      int num7 = (int) (ushort) values[0];
      int num8 = (int) (ushort) values[1];
      if (num7 >= num1 && num7 <= num3 && (num8 <= num2 && num8 >= num4))
      {
        values[0] = (short) ((int) values[0] - num1 + num5);
        values[1] = (short) ((int) values[1] - num2 + num6);
      }
      texCoords.set(firstVertex, 1, values);
    }
  }

  public static void remapTexCoords(
    Mesh mesh,
    int[] fromTexCoords,
    int[] toTexCoords,
    int submeshIndex)
  {
    int num1 = fromTexCoords[0] << 3;
    int num2 = 8192 - fromTexCoords[1] << 3;
    int num3 = fromTexCoords[0] + fromTexCoords[2] << 3;
    int num4 = 8192 - fromTexCoords[1] - fromTexCoords[3] << 3;
    int num5 = toTexCoords[0] << 3;
    int num6 = 8192 - toTexCoords[1] << 3;
    int toTexCoord1 = toTexCoords[0];
    int toTexCoord2 = toTexCoords[2];
    int toTexCoord3 = toTexCoords[1];
    int toTexCoord4 = toTexCoords[3];
    float[] scaleBias = new float[10];
    VertexBuffer vertexBuffer = mesh.getVertexBuffer();
    VertexArray texCoords = vertexBuffer.getTexCoords(0, ref scaleBias);
    IndexBuffer indexBuffer = mesh.getIndexBuffer(submeshIndex);
    int indexCount = indexBuffer.getIndexCount();
    int[] indices = new int[indexCount];
    indexBuffer.getIndices(ref indices);
    for (int index = 0; index < indexCount; ++index)
    {
      int firstVertex = indices[index];
      short[] values = new short[2];
      texCoords.get(firstVertex, 1, ref values);
      int num7 = (int) (ushort) values[0];
      int num8 = (int) (ushort) values[1];
      if (num7 >= num1 && num7 <= num3 && (num8 <= num2 && num8 >= num4))
      {
        values[0] = (short) ((int) values[0] - num1 + num5);
        values[1] = (short) ((int) values[1] - num2 + num6);
        texCoords.set(firstVertex, 1, values);
      }
    }
    vertexBuffer.processTextureCoords(0);
  }

  public void addWallTop(
    int p3,
    int panelX,
    int panelZ,
    int panelW,
    GeomStrip.Dir dir,
    int[] texCoords,
    int trimStart,
    int trimEnd)
  {
    int p11 = 0;
    int p12 = 0;
    int p21 = 0;
    int p22 = 0;
    int tileSizeA1 = 0;
    int tileSizeA2 = 0;
    switch (dir)
    {
      case GeomStrip.Dir.DIR_X_POS:
        p11 = panelX + trimStart;
        p12 = panelZ - 2;
        p21 = panelX + panelW - trimEnd;
        p22 = panelZ;
        tileSizeA1 = panelW - trimStart - trimEnd;
        tileSizeA2 = 2;
        break;
      case GeomStrip.Dir.DIR_Z_POS:
        p11 = panelX;
        p12 = panelZ + trimStart;
        p21 = panelX + 2;
        p22 = panelZ + panelW - trimEnd;
        tileSizeA1 = 2;
        tileSizeA2 = panelW - trimStart - trimEnd;
        break;
      case GeomStrip.Dir.DIR_X_NEG:
        p11 = panelX - panelW + trimEnd;
        p12 = panelZ;
        p21 = panelX - trimStart;
        p22 = panelZ + 2;
        tileSizeA1 = panelW - trimStart - trimEnd;
        tileSizeA2 = 2;
        break;
      case GeomStrip.Dir.DIR_Z_NEG:
        p11 = panelX - 2;
        p12 = panelZ - panelW + trimEnd;
        p21 = panelX;
        p22 = panelZ - trimStart;
        tileSizeA1 = 2;
        tileSizeA2 = panelW - trimStart - trimEnd;
        break;
    }
    this.addBasicPanel(p11, p12, p21, p22, p3, GeomStrip.Axis.AXIS_X, GeomStrip.Axis.AXIS_Z, tileSizeA1, tileSizeA2, texCoords);
  }

  public void addWall(
    int p12,
    int p22,
    int tileSizeA2,
    int panelX,
    int panelZ,
    int panelW,
    GeomStrip.Dir dir,
    int[] texCoords,
    int trimStart,
    int trimEnd,
    int flags)
  {
    GeomStrip.Axis a1 = GeomStrip.Axis.AXIS_X;
    int p11 = 0;
    int p21 = 0;
    int p3 = 0;
    switch (dir)
    {
      case GeomStrip.Dir.DIR_X_POS:
        a1 = GeomStrip.Axis.AXIS_X;
        p11 = panelX;
        p21 = panelX + panelW;
        p3 = panelZ;
        break;
      case GeomStrip.Dir.DIR_Z_POS:
        a1 = GeomStrip.Axis.AXIS_Z;
        p11 = panelZ;
        p21 = panelZ + panelW;
        p3 = panelX;
        break;
      case GeomStrip.Dir.DIR_X_NEG:
        a1 = GeomStrip.Axis.AXIS_X;
        p11 = panelX;
        p21 = panelX - panelW;
        p3 = panelZ;
        break;
      case GeomStrip.Dir.DIR_Z_NEG:
        a1 = GeomStrip.Axis.AXIS_Z;
        p11 = panelZ;
        p21 = panelZ - panelW;
        p3 = panelX;
        break;
    }
    this.addTrimmedPanel(p11, p12, p21, p22, p3, a1, GeomStrip.Axis.AXIS_Y, 32, tileSizeA2, texCoords, trimStart, trimEnd, 0, 0, flags);
  }

  public void addTallWall(
    int panelX,
    int panelZ,
    int panelW,
    GeomStrip.Dir dir,
    int[] texCoords,
    int trimStart,
    int trimEnd)
  {
    this.addTallWall(panelX, panelZ, panelW, dir, texCoords, trimStart, trimEnd, 0);
  }

  public void addTallWall(
    int panelX,
    int panelZ,
    int panelW,
    GeomStrip.Dir dir,
    int[] texCoords,
    int trimStart,
    int trimEnd,
    int flags)
  {
    int num = texCoords[3] * 84 / 96;
    int[] texCoords1 = new int[4]
    {
      texCoords[0],
      texCoords[1],
      texCoords[2],
      num
    };
    this.addWall(96, 12, 84, panelX, panelZ, panelW, dir, texCoords1, trimStart, trimEnd, flags);
  }

  public enum Axis
  {
    AXIS_X,
    AXIS_Y,
    AXIS_Z,
  }

  public enum Dir
  {
    DIR_X_POS,
    DIR_Y_POS,
    DIR_Z_POS,
    DIR_X_NEG,
    DIR_Y_NEG,
    DIR_Z_NEG,
  }
}
