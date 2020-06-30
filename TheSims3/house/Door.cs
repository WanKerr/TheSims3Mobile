// Decompiled with JetBrains decompiler
// Type: house.Door
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

namespace house
{
  public class Door : PlaceableWallObject
  {
    public Door(int x, int y, int width, int type)
      : base(x, y, width, type)
    {
    }

    public new void Dispose()
    {
      base.Dispose();
    }

    public static Door house_cast(PlaceableObject obj)
    {
      return (object) obj.GetType() == (object) typeof (Door) ? (Door) obj : (Door) null;
    }

    public override void writexml(OutputStream @out)
    {
      string str1 = GlobalConstants.LOOKUP_OBJECT[this.getType()];
      StringBuffer stringBuffer = new StringBuffer();
      stringBuffer.append("    <door ").append("x=\"").append(this.getX()).append("\" ").append("y=\"").append(this.getY()).append("\" ").append("width=\"").append(this.getWidth()).append("\" ").append("type=\"OBJECT_").append(str1).append("\" ").append("/>\n");
      string str2 = stringBuffer.toString();
      sbyte[] b = new sbyte[str2.Length];
      for (int index = 0; index < str2.Length; ++index)
        b[index] = (sbyte) str2[index];
      @out.write(b, 0, b.Length);
    }

    public static Door fromXMLString(string str)
    {
      int x = HouseEditorObject.readXMLAttribInt(str, "x");
      int y = HouseEditorObject.readXMLAttribInt(str, "y");
      int width = HouseEditorObject.readXMLAttribInt(str, "width");
      string idStr = HouseEditorObject.readXMLAttribStr(str, "type").Substring("OBJECT_".Length);
      int type = HouseEditorObject.idLookup(GlobalConstants.LOOKUP_OBJECT, GlobalConstants.LOOKUP_OBJECT.Length, idStr);
      return new Door(x, y, width, type);
    }
  }
}
