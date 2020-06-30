// Decompiled with JetBrains decompiler
// Type: AnimationManager3D
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class AnimationManager3D
{
  public const int HERMITE_SHIFT = 6;
  public const int NUM_HERMITES = 1025;
  private short[] m_animStartFrame;
  private short[] m_animEndFrame;
  private short[][] m_animWindowStartFrame;
  private short[][] m_animWindowEndFrame;
  private sbyte[][] m_animWindowFlags;
  private int[] m_cubicHermites;

  public AnimationManager3D()
  {
    this.m_animStartFrame = (short[]) null;
    this.m_animEndFrame = (short[]) null;
    this.m_animWindowStartFrame = (short[][]) null;
    this.m_animWindowEndFrame = (short[][]) null;
    this.m_animWindowFlags = (sbyte[][]) null;
    this.m_cubicHermites = (int[]) null;
    this.m_cubicHermites = new int[4100];
    int num1 = -1;
    for (int index = 0; index < 1025; ++index)
    {
      int num2 = index << 6;
      int a = MathExt.Fmul(num2, num2);
      int num3 = MathExt.Fmul(a, num2);
      int num4;
      this.m_cubicHermites[num4 = num1 + 1] = 2 * num3 - 3 * a + 65536;
      int num5;
      this.m_cubicHermites[num5 = num4 + 1] = -2 * num3 + 3 * a;
      int num6;
      this.m_cubicHermites[num6 = num5 + 1] = num3 - 2 * a + num2;
      this.m_cubicHermites[num1 = num6 + 1] = num3 - a;
    }
  }

  public void Dispose()
  {
    if (this.m_cubicHermites == null)
      return;
    this.m_cubicHermites = (int[]) null;
    this.m_cubicHermites = (int[]) null;
  }

  public bool loadAnimFile(ref ResourceManager resMgr)
  {
    DataInputStream dataInputStream = new DataInputStream(ResourceManager.loadBinaryFile(2));
    int length1 = (int) dataInputStream.readShort();
    this.m_animStartFrame = new short[length1];
    this.m_animEndFrame = new short[length1];
    this.m_animWindowStartFrame = new short[length1][];
    this.m_animWindowEndFrame = new short[length1][];
    this.m_animWindowFlags = new sbyte[length1][];
    for (int index1 = 0; index1 < length1; ++index1)
    {
      this.m_animStartFrame[index1] = dataInputStream.readShort();
      this.m_animEndFrame[index1] = dataInputStream.readShort();
      int length2 = (int) dataInputStream.readShort();
      if (length2 > 0)
      {
        this.m_animWindowStartFrame[index1] = new short[length2];
        this.m_animWindowEndFrame[index1] = new short[length2];
        this.m_animWindowFlags[index1] = new sbyte[length2];
        for (int index2 = 0; index2 < length2; ++index2)
        {
          this.m_animWindowStartFrame[index1][index2] = dataInputStream.readShort();
          this.m_animWindowEndFrame[index1][index2] = dataInputStream.readShort();
          this.m_animWindowFlags[index1][index2] = dataInputStream.readByte();
        }
      }
    }
    return true;
  }

  public AnimPlayer3D createAnimPlayer3D()
  {
    return new AnimPlayer3D(this);
  }

  public int getNumAnimations()
  {
    return this.m_animStartFrame.Length;
  }

  public int getAnimStartFrame(int animIndex)
  {
    return (int) this.m_animStartFrame[animIndex];
  }

  public int getAnimEndFrame(int animIndex)
  {
    return (int) this.m_animEndFrame[animIndex];
  }

  public int getAnimationDuration(int animIndex)
  {
    int animStartFrame = this.getAnimStartFrame(animIndex);
    int animEndFrame = this.getAnimEndFrame(animIndex);
    int num = animEndFrame - animStartFrame;
    return num <= 0 || animStartFrame == 0 || animEndFrame == 0 ? 0 : num * 40;
  }

  public int getAnimNumWindows(int animIndex)
  {
    return this.m_animWindowStartFrame[animIndex].Length;
  }

  public int getAnimWindowStartFrame(int animIndex, int windowIndex)
  {
    return (int) this.m_animWindowStartFrame[animIndex][windowIndex];
  }

  public int getAnimWindowEndFrame(int animIndex, int windowIndex)
  {
    return (int) this.m_animWindowEndFrame[animIndex][windowIndex];
  }

  public int getAnimWindowFlags(int animIndex, int windowIndex)
  {
    return (int) this.m_animWindowFlags[animIndex][windowIndex];
  }

  public int getCubicHermites(int interp)
  {
    return this.m_cubicHermites[(interp >> 6) * 4];
  }
}
