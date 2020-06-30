// Decompiled with JetBrains decompiler
// Type: house.Room
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

namespace house
{
  public class Room : PlaceableObject
  {
    private int m_floor;
    private int m_wall;

    public Room(int x, int y, int width, int height, int floor, int wall)
      : base(x, y, width, height)
    {
      this.m_floor = 0;
      this.m_wall = 0;
      this.setFloor(floor);
      this.setWall(wall);
    }

    public new void Dispose()
    {
      base.Dispose();
    }

    public static Room house_cast(PlaceableObject obj)
    {
      return (object) obj.GetType() == (object) typeof (Room) ? (Room) obj : (Room) null;
    }

    public static void requireValidFloor(int floor)
    {
    }

    public static void requireValidWall(int wall)
    {
    }

    public int getFloor()
    {
      return this.m_floor;
    }

    public int getWall()
    {
      return this.m_wall;
    }

    public void setFloor(int floor)
    {
      Room.requireValidFloor(floor);
      this.m_floor = floor;
    }

    public void setWall(int wall)
    {
      Room.requireValidWall(wall);
      this.m_wall = wall;
    }

    public override void writexml(OutputStream @out)
    {
      string str1 = GlobalConstants.LOOKUP_FLOOR[this.getFloor()];
      string str2 = GlobalConstants.LOOKUP_WALL[this.getWall()];
      StringBuffer stringBuffer = new StringBuffer();
      stringBuffer.append("    <room ").append("x=\"").append(this.getX()).append("\" ").append("y=\"").append(this.getY()).append("\" ").append("width=\"").append(this.getWidth() - 1).append("\" ").append("height=\"").append(this.getHeight() - 1).append("\" ").append("floor=\"FLOOR_").append(str1).append("\" ").append("wall=\"WALL_").append(str2).append("\" ").append("/>\n");
      string str3 = stringBuffer.toString();
      sbyte[] b = new sbyte[str3.Length];
      for (int index = 0; index < str3.Length; ++index)
        b[index] = (sbyte) str3[index];
      @out.write(b, 0, b.Length);
    }

    public static Room fromXMLString(string str)
    {
      int x = HouseEditorObject.readXMLAttribInt(str, "x");
      int y = HouseEditorObject.readXMLAttribInt(str, "y");
      int width = HouseEditorObject.readXMLAttribInt(str, "width") + 1;
      int height = HouseEditorObject.readXMLAttribInt(str, "height") + 1;
      string idStr1 = HouseEditorObject.readXMLAttribStr(str, "floor").Substring("FLOOR_".Length);
      int floor = HouseEditorObject.idLookup(GlobalConstants.LOOKUP_FLOOR, GlobalConstants.LOOKUP_FLOOR.Length, idStr1);
      string idStr2 = HouseEditorObject.readXMLAttribStr(str, "wall").Substring("WALL_".Length);
      int wall = HouseEditorObject.idLookup(GlobalConstants.LOOKUP_WALL, GlobalConstants.LOOKUP_WALL.Length, idStr2);
      return new Room(x, y, width, height, floor, wall);
    }
  }
}
