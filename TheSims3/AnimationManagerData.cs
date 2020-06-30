// Decompiled with JetBrains decompiler
// Type: AnimationManagerData
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class AnimationManagerData
{
  public AnimPlayer[] m_animPlayerPool;
  public sbyte[] colourData;
  public sbyte[] animNumFrames;
  public short[] animFrameOffset;
  public short[] frameDuration;
  public sbyte[] frameNumPrimitives;
  public int[] framePrimitiveOffset;
  public short[] primitiveData;
  public short[][] m_subImages;
  public Image[][] m_animImageArray;
  public int m_curBank;

  public AnimationManagerData()
  {
    this.m_subImages = new short[0][];
    for (int index = 0; index < 0; ++index)
      this.m_subImages[index] = new short[5];
    this.m_animPlayerPool = new AnimPlayer[48];
    this.colourData = (sbyte[]) null;
    this.animNumFrames = (sbyte[]) null;
    this.animFrameOffset = (short[]) null;
    this.frameDuration = (short[]) null;
    this.frameNumPrimitives = (sbyte[]) null;
    this.framePrimitiveOffset = (int[]) null;
    this.primitiveData = (short[]) null;
    this.m_animImageArray = (Image[][]) null;
    this.m_curBank = 0;
  }

  public void Dispose()
  {
    for (int index = 0; index < 48; ++index)
      this.m_animPlayerPool[index] = (AnimPlayer) null;
    for (int index1 = 0; index1 < 1; ++index1)
    {
      for (int index2 = 0; index2 < this.m_animImageArray[index1].Length; ++index2)
      {
        Image image = this.m_animImageArray[index1][index2];
        this.m_animImageArray[index1][index2] = (Image) null;
      }
    }
  }
}
