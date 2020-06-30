// Decompiled with JetBrains decompiler
// Type: SevenZip.Compression.LZ.IMatchFinder
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace SevenZip.Compression.LZ
{
  internal interface IMatchFinder : IInWindowStream
  {
    void Create(
      uint historySize,
      uint keepAddBufferBefore,
      uint matchMaxLen,
      uint keepAddBufferAfter);

    uint GetMatches(uint[] distances);

    void Skip(uint num);
  }
}
