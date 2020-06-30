// Decompiled with JetBrains decompiler
// Type: XLSLoader.DataReader
// Assembly: XLSContentLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E48F643-5EE4-457D-A2FE-ED503ACE2B61
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\XLSContentLibrary.dll

using Microsoft.Xna.Framework.Content;

namespace XLSLoader
{
  public class DataReader : ContentTypeReader<Data>
  {
    protected override Data Read(ContentReader input, Data existingInstance)
    {
      return new Data()
      {
        Grid = input.ReadObject<string[][]>()
      };
    }
  }
}
