// Decompiled with JetBrains decompiler
// Type: DLCPack
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class DLCPack
{
  public int d_packId;
  public string d_packName;
  public string d_objectTextureFilename;
  public string d_objectScrollingTextureFilename;
  public int d_objectScrollingTextureTiming;
  public string d_simMaleFilename;
  public string d_simFemaleFilename;
  public string d_miniCarModelFilename;
  public string d_miniCarTextureFilename;
  public RecObject[] d_objectRecords;
  public RecItem[] d_itemRecords;
  public short[][] d_simAttribUserIds;
  public int[][] d_simAttribFlags;
  public string[][][] d_simAttribTextureFilenames;
  public Image m_tagImage;

  public DLCPack()
  {
    this.d_packId = -1;
    this.d_packName = (string) null;
    this.d_objectTextureFilename = (string) null;
    this.d_objectScrollingTextureFilename = (string) null;
    this.d_objectScrollingTextureTiming = 0;
    this.d_simMaleFilename = (string) null;
    this.d_simFemaleFilename = (string) null;
    this.d_miniCarModelFilename = (string) null;
    this.d_miniCarTextureFilename = (string) null;
    this.d_objectRecords = new RecObject[0];
    this.d_itemRecords = new RecItem[0];
    this.d_simAttribUserIds = new short[0][];
    this.d_simAttribFlags = new int[0][];
    this.d_simAttribTextureFilenames = new string[0][][];
    this.m_tagImage = (Image) null;
  }
}
