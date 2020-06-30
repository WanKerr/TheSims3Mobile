// Decompiled with JetBrains decompiler
// Type: house.HouseObject
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;
using System;

namespace house
{
  public class HouseObject : PlaceableObject
  {
    private int m_type;
    private int m_facing;

    public static HouseObject house_cast(PlaceableObject obj)
    {
      throw new NotImplementedException();
    }

    public static void requireVaildType(int type)
    {
    }

    public static void requireValidFacing(int facing)
    {
    }

    public static string getFacingCStr(int facing)
    {
      switch (facing)
      {
        case 0:
          return "FACING_SE";
        case 1:
          return "FACING_SW";
        case 2:
          return "FACING_NW";
        case 3:
          return "FACING_NE";
        default:
          return (string) null;
      }
    }

    public static int getFacingInt(string facingStr)
    {
      if (facingStr.Equals("FACING_SE"))
        return 0;
      if (facingStr.Equals("FACING_SW"))
        return 1;
      if (facingStr.Equals("FACING_NE"))
        return 3;
      return facingStr.Equals("FACING_NW") ? 2 : -1;
    }

    public HouseObject(int x, int y, int type, int facing)
      : base(x, y)
    {
      this.m_type = 0;
      this.m_facing = 0;
      this.setTypeAndFacing(type, facing);
    }

    public new void Dispose()
    {
      base.Dispose();
    }

    public int getType()
    {
      return this.m_type;
    }

    public int getFacing()
    {
      return this.m_facing;
    }

    public void setType(int type)
    {
      this.setTypeAndFacing(type, this.getFacing());
    }

    public void setFacing(int facing)
    {
      this.setTypeAndFacing(this.getType(), facing);
    }

    public void setTypeAndFacing(int type, int facing)
    {
      HouseObject.requireVaildType(type);
      HouseObject.requireValidFacing(facing);
      SimWorld simWorld = AppEngine.getCanvas().getSimWorld();
      this.setSize(simWorld.getObjectFootprintWidth(type), simWorld.getObjectFootprintHeight(type));
      this.m_type = type;
      this.m_facing = facing;
    }

    public override void writexml(OutputStream @out)
    {
      string str1 = GlobalConstants.LOOKUP_OBJECT[this.getType()];
      string facingCstr = HouseObject.getFacingCStr(this.getFacing());
      StringBuffer stringBuffer = new StringBuffer();
      stringBuffer.append("    <object ").append("x=\"").append(this.getX()).append("\" ").append("y=\"").append(this.getY()).append("\" ").append("type=\"OBJECT_").append(str1).append("\" ").append("facingDir=\"").append(facingCstr).append("\" ").append("/>\n");
      string str2 = stringBuffer.toString();
      sbyte[] b = new sbyte[str2.Length];
      for (int index = 0; index < str2.Length; ++index)
        b[index] = (sbyte) str2[index];
      @out.write(b, 0, b.Length);
    }

    public static HouseObject fromXMLString(string str)
    {
      int x = HouseEditorObject.readXMLAttribInt(str, "x");
      int y = HouseEditorObject.readXMLAttribInt(str, "y");
      string idStr = HouseEditorObject.readXMLAttribStr(str, "type").Substring("OBJECT_".Length);
      int type = HouseEditorObject.idLookup(GlobalConstants.LOOKUP_OBJECT, GlobalConstants.LOOKUP_OBJECT.Length, idStr);
      int facingInt = HouseObject.getFacingInt(HouseEditorObject.readXMLAttribStr(str, "facingDir"));
      return new HouseObject(x, y, type, facingInt);
    }
  }
}
