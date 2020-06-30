// Decompiled with JetBrains decompiler
// Type: ea_sdk.SDKFontIM
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace ea_sdk
{
  public class SDKFontIM
  {
    private SDKFont m_sdkFont;

    public SDKFontIM(object sdkFont)
    {
      this.m_sdkFont = (SDKFont) sdkFont;
    }

    public void Dispose()
    {
      if (this.m_sdkFont == null)
        return;
      this.m_sdkFont.Dispose();
      this.m_sdkFont = (SDKFont) null;
    }
  }
}
