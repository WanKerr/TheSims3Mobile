// Decompiled with JetBrains decompiler
// Type: house.Window
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;
using System;

namespace house
{
  public class Window : PlaceableWallObject
  {
    public static Window house_cast(PlaceableObject obj)
    {
      throw new NotImplementedException();
    }

    public Window(int x, int y, int width, int type)
      : base(x, y, width, type)
    {
    }

    public new void Dispose()
    {
    }

    public override void writexml(OutputStream @out)
    {
      string str1 = GlobalConstants.LOOKUP_OBJECT[this.getType()];
      StringBuffer stringBuffer = new StringBuffer();
      stringBuffer.append("    <window ").append("x=\"").append(this.getX()).append("\" ").append("y=\"").append(this.getY()).append("\" ").append("width=\"").append(this.getWidth()).append("\" ").append("type=\"OBJECT_").append(str1).append("\" ").append("/>\n");
      string str2 = stringBuffer.toString();
      sbyte[] b = new sbyte[str2.Length];
      for (int index = 0; index < str2.Length; ++index)
        b[index] = (sbyte) str2[index];
      @out.write(b, 0, b.Length);
    }

    public static Window fromXMLString(string str)
    {
      int x = HouseEditorObject.readXMLAttribInt(str, "x");
      int y = HouseEditorObject.readXMLAttribInt(str, "y");
      int width = HouseEditorObject.readXMLAttribInt(str, "width");
      string idStr = HouseEditorObject.readXMLAttribStr(str, "type").Substring("OBJECT_".Length);
      int type = HouseEditorObject.idLookup(GlobalConstants.LOOKUP_OBJECT, GlobalConstants.LOOKUP_OBJECT.Length, idStr);
      return new Window(x, y, width, type);
    }
  }
}
