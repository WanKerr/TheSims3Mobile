// Decompiled with JetBrains decompiler
// Type: sims3.StringRenderer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

namespace sims3
{
  public abstract class StringRenderer
  {
    public abstract void drawString(Graphics g, string str, int x, int y, int anchor);

    public abstract void drawString(Graphics g, StringBuffer str, int x, int y, int anchor);

    public abstract void drawSubstring(
      Graphics g,
      string str,
      int offset,
      int len,
      int x,
      int y,
      int anchor);

    public abstract int charsWidth(ushort[] ch, int offset, int length);

    public abstract int charWidth(ushort chr);

    public abstract int getBaselinePosition();

    public abstract int getHeight();

    public abstract int stringWidth(string str);

    public abstract int substringWidth(string str, int offset, int length);

    public virtual void getStringTexturePadding(ref int x0, ref int x1, ref int y0, ref int y1)
    {
    }
  }
}
