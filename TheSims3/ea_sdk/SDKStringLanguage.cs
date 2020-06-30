// Decompiled with JetBrains decompiler
// Type: ea_sdk.SDKStringLanguage
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace ea_sdk
{
  public class SDKStringLanguage
  {
    public const int NUM_ISOCODE_CHARS = 5;
    public static SDKStringLanguage[] s_languageArray;
    public static SDKStringGroup[] s_groupArray;
    public static SDKStringActualChunk[] s_actualChunkArray;
    public static SDKStringStorageChunk[] s_storageChunkArray;
    public static ushort[] s_wrapOffsets;
    public int encoding;
    public sbyte[] isoCodeArray;
    public sbyte fontDifferentiator;
    public ushort[] chunkSizeArray;

    public SDKStringLanguage()
    {
      this.encoding = 0;
      this.isoCodeArray = new sbyte[5];
      this.fontDifferentiator = (sbyte) 0;
      this.chunkSizeArray = (ushort[]) null;
    }
  }
}
