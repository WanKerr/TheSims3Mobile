// Decompiled with JetBrains decompiler
// Type: ea_sdk.SDKUtils
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

namespace ea_sdk
{
  public class SDKUtils
  {
    private const int MAX_VIRTUAL_RECORDS = 1024;
    public const int TRANS_MIRROR = 2;
    public const int TRANS_MIRROR_ROT180 = 1;
    public const int TRANS_MIRROR_ROT270 = 4;
    public const int TRANS_MIRROR_ROT90 = 7;
    public const int TRANS_NONE = 0;
    public const int TRANS_ROT180 = 3;
    public const int TRANS_ROT270 = 6;
    public const int TRANS_ROT90 = 5;
    private static Graphics s_graphics;

    public static Graphics getGraphics()
    {
      return SDKUtils.s_graphics;
    }

    public static int chooseLanguage(int langChosen)
    {
      return langChosen == -1 ? 0 : langChosen;
    }

    public static void drawRegion(
      Image img,
      int xsrc,
      int ysrc,
      int w,
      int h,
      int transform,
      int x,
      int y,
      int anchor)
    {
      SDKUtils.getGraphics().drawRegion(img, xsrc, ysrc, w, h, transform, x, y, anchor);
    }

    public static void drawRegion(
      short[] pixels,
      int scanLength,
      int xsrc,
      int ysrc,
      int w,
      int h,
      int transform,
      int x,
      int y,
      int anchor)
    {
    }

    public static void drawString(SDKStringIM _string, int x, int y, int anchor)
    {
      SDKTextUtils.drawString(_string.getEAString(), x, y, anchor, new SDKTextUtils.DrawRegionRoutineDelegate(GlobalMembersSDKUtils.renderFunc));
    }

    public static void drawSubString(
      SDKStringIM _string,
      int offset,
      int len,
      int x,
      int y,
      int anchor)
    {
      SDKTextUtils.drawSubString(_string.getEAString(), offset, len, x, y, anchor, new SDKTextUtils.DrawRegionRoutineDelegate(GlobalMembersSDKUtils.renderFunc));
    }

    public static void drawWrappedString(
      SDKStringIM _string,
      short[] offsets,
      int startLine,
      int lineCount,
      int x,
      int y,
      int anchor)
    {
      SDKTextUtils.drawWrappedString(_string.getEAString(), offsets, startLine, lineCount, x, y, anchor, new SDKTextUtils.DrawRegionRoutineDelegate(GlobalMembersSDKUtils.renderFunc));
    }

    public static void fillTriangle(int x0, int y0, int x1, int y1, int x2, int y2, int color)
    {
      SDKUtils.getGraphics().fillTriangle(x0, y0, x1, y1, x2, y2);
    }

    public static void freeStringsChunk(int chunkID)
    {
      SDKTextUtils.freeStringsChunk(chunkID);
    }

    public static int getBaselinePosition()
    {
      return SDKTextUtils.getBaselinePosition();
    }

    public static int getCharSpacing()
    {
      return SDKTextUtils.getCharSpacing();
    }

    public static int getCurrentLanguage()
    {
      return SDKTextUtils.getCurrentLanguage();
    }

    public static object getFont()
    {
      return (object) SDKTextUtils.getFont();
    }

    public static int getFontDifferentiator(int langIndex)
    {
      return 0;
    }

    public static SDKStringIM getHeaderString(
      int langIndex,
      int stringID,
      ref SDKStringIM _string)
    {
      bool flag = _string.getEAString() == null;
      SDKString headerString = SDKTextUtils.getHeaderString(langIndex, stringID, _string.getEAString());
      if (flag)
        _string.setEAString(headerString);
      return _string;
    }

    public static SDKStringIM getHeaderString(
      int langIndex,
      int stringID,
      SDKStringIM _string)
    {
      return _string == null ? new SDKStringIM(SDKTextUtils.getHeaderString(langIndex, stringID, (SDKString) null)) : SDKUtils.getHeaderString(langIndex, stringID, ref _string);
    }

    public static int getLeadingSpacing()
    {
      return SDKTextUtils.getLeadingSpacing();
    }

    public static int getLineSize()
    {
      return SDKTextUtils.getLineSize();
    }

    public static long getRecordSizeAvailable()
    {
      return 0;
    }

    public static int getSpaceSpacing()
    {
      return SDKTextUtils.getSpaceSpacing();
    }

    public static SDKStringIM getString(int stringID, ref SDKStringIM _string)
    {
      if (_string == null)
        _string = new SDKStringIM();
      bool flag = _string.getEAString() == null;
      SDKString eaString = SDKTextUtils.getString(stringID, _string.getEAString());
      if (flag)
        _string.setEAString(eaString);
      return _string;
    }

    public static int getStringSize(ref SDKStringIM _string)
    {
      return SDKTextUtils.getStringSize(_string.getEAString());
    }

    public static int getSubStringSize(ref SDKStringIM _string, int offset, int len)
    {
      return SDKTextUtils.getSubStringSize(_string.getEAString(), offset, len);
    }

    public static bool isLoadedStringsChunk(int chunkID)
    {
      return true;
    }

    public static bool isRecordEmpty(int virtualId)
    {
      return true;
    }

    public static object loadFont(Image fontImage, ref sbyte[] fontChunk)
    {
      return (object) SDKTextUtils.loadFont((object) fontImage, fontChunk);
    }

    public static sbyte[] loadRecord(int virtualId)
    {
      return new sbyte[0];
    }

    public static int loadStringsChunk(int chunkID)
    {
      SDKTextUtils.loadStringsChunk(chunkID);
      return 10;
    }

    public static int loadTextHeader(ref sbyte[] textHeader)
    {
      return SDKTextUtils.loadTextHeader(textHeader);
    }

    public static int readBytesNative(InputStream @is, ref sbyte[] data, int offset, int length)
    {
      return @is.read(data, offset, length);
    }

    public static void removeRecord(int virtualId)
    {
    }

    public static void saveRecord(int virtualId, ref sbyte[] data)
    {
    }

    public static void setCharSpacing(int val)
    {
      SDKTextUtils.setCharSpacing(val);
    }

    public static void setClip(Graphics g, int x, int y, int w, int h)
    {
      g.setClip(x, y, w, h);
    }

    public static bool setCurrentLanguage(int index)
    {
      return SDKTextUtils.setCurrentLanguage(index);
    }

    public static void setFont(object font)
    {
      SDKTextUtils.setFont((SDKFont) font);
    }

    public static object setFontChunk(ref sbyte[] newChunk)
    {
      return (object) SDKTextUtils.setFontChunk(newChunk);
    }

    public static object setFontImage(Image image)
    {
      return (object) SDKTextUtils.setFontImage((object) image);
    }

    public static void setGraphics(Graphics graphics)
    {
      SDKUtils.s_graphics = graphics;
    }

    public static void setLeadingSpacing(int val)
    {
      SDKTextUtils.setLeadingSpacing(val);
    }

    public static void setMidlet(MIDlet mid)
    {
    }

    public static void setSpaceSpacing(int val)
    {
      SDKTextUtils.setSpaceSpacing(val);
    }

    public static void setTransform(int transform)
    {
      SDKUtils.setTransform(transform);
    }

    public static long skipNative(InputStream @is, long howmuch)
    {
      return @is.skip(howmuch);
    }

    public static short[] wrapString(
      ref SDKStringIM _string,
      ref short[] offsets,
      int wrapLimit,
      short newline)
    {
      if (offsets == null)
        return SDKUtils.convertWrapData(SDKTextUtils.wrapString(_string.getEAString(), (short[]) null, wrapLimit, newline));
      SDKTextUtils.wrapString(_string.getEAString(), offsets, wrapLimit, newline);
      return offsets;
    }

    public static short[] wrapSubString(
      ref SDKStringIM _string,
      int offset,
      int len,
      ref short[] offsets,
      int wrapLimit,
      short newline)
    {
      if (offsets == null)
        return SDKUtils.convertWrapData(SDKTextUtils.wrapSubString(_string.getEAString(), offset, len, (short[]) null, wrapLimit, newline));
      SDKTextUtils.wrapSubString(_string.getEAString(), offset, len, offsets, wrapLimit, newline);
      return offsets;
    }

    private static short[] convertWrapData(short[] data)
    {
      int length = (int) data[0] + 3;
      short[] numArray = new short[length];
      for (int index = 0; index != length; ++index)
        numArray[index] = data[index];
      return numArray;
    }
  }
}
