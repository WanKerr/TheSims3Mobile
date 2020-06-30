// Decompiled with JetBrains decompiler
// Type: sims3.MTXStoreManager
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;
using System;

namespace sims3
{
  public class MTXStoreManager
  {
    private static MTXStoreManager g_mtxStoreManager;

    public static MTXStoreManager getInstance()
    {
      if (MTXStoreManager.g_mtxStoreManager == null)
        MTXStoreManager.g_mtxStoreManager = new MTXStoreManager();
      return MTXStoreManager.g_mtxStoreManager;
    }

    public Image getBannerImage()
    {
      throw new NotImplementedException();
    }

    public string getTickerString(int index)
    {
      throw new NotImplementedException();
    }

    public string getTickerURL(int index)
    {
      throw new NotImplementedException();
    }

    public string getBannerURL()
    {
      throw new NotImplementedException();
    }

    public int getTickerCount()
    {
      throw new NotImplementedException();
    }
  }
}
