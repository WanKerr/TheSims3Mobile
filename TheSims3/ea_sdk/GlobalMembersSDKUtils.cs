// Decompiled with JetBrains decompiler
// Type: ea_sdk.GlobalMembersSDKUtils
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

namespace ea_sdk
{
  public static class GlobalMembersSDKUtils
  {
    public static void renderFunc(
      object img,
      short xdst,
      short ydst,
      short w,
      short h,
      short xsrc,
      short ysrc)
    {
      SDKUtils.getGraphics().drawRegion((Image) img, (int) xsrc, (int) ysrc, (int) w, (int) h, 0, (int) xdst, (int) ydst, 9);
    }
  }
}
