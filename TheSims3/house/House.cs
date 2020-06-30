// Decompiled with JetBrains decompiler
// Type: house.House
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

namespace house
{
  public class House : GlobalConstants
  {
    private Vector m_rooms = new Vector();
    private Vector m_doors = new Vector();
    private Vector m_windows = new Vector();
    private Vector m_objects = new Vector();
    private string m_name;
    private int m_id;

    public House(string name)
    {
      this.m_rooms = new Vector();
      this.m_doors = new Vector();
      this.m_windows = new Vector();
      this.m_objects = new Vector();
      this.m_name = (string) null;
      this.m_id = -1;
      this.setName(name);
    }

    public House(string name, int houseId)
    {
      this.m_rooms = new Vector();
      this.m_doors = new Vector();
      this.m_windows = new Vector();
      this.m_objects = new Vector();
      this.m_name = (string) null;
      this.m_id = -1;
      this.setName(name);
      this.setId(houseId);
    }

    public new void Dispose()
    {
    }

    public string getName()
    {
      return this.m_name;
    }

    public int getId()
    {
      return this.m_id;
    }

    public void setName(string name)
    {
      this.m_name = name;
    }

    public void setId(int houseId)
    {
      this.m_id = houseId;
    }

    public void addRoom(Room room)
    {
      this.m_rooms.addElement((object) room);
    }

    public void deleteRoom(Room room)
    {
      this.m_rooms.removeElement((object) room);
    }

    public void addDoor(Door door)
    {
      this.m_doors.addElement((object) door);
    }

    public void deleteDoor(Door door)
    {
      this.m_doors.removeElement((object) door);
    }

    public void addWindow(Window window)
    {
      this.m_windows.addElement((object) window);
    }

    public void deleteWindow(Window window)
    {
      this.m_windows.removeElement((object) window);
    }

    public void addHouseObject(HouseObject @object)
    {
      this.m_objects.addElement((object) @object);
    }

    public void deleteHouseObject(HouseObject houseObject)
    {
      this.m_objects.removeElement((object) houseObject);
    }

    public Vector getRooms()
    {
      return this.m_rooms;
    }

    public Vector getDoors()
    {
      return this.m_doors;
    }

    public Vector getWindows()
    {
      return this.m_windows;
    }

    public Vector getHouseObjects()
    {
      return this.m_objects;
    }

    public Room getRoomAt(int x, int y)
    {
      int num = this.m_rooms.size();
      for (int index = 0; index < num; ++index)
      {
        Room room = (Room) this.m_rooms.elementAt(index);
        if (room.getX() == x && room.getY() == y)
          return room;
      }
      return (Room) null;
    }

    public Door getDoorAt(int x, int y)
    {
      int num = this.m_doors.size();
      for (int index = 0; index < num; ++index)
      {
        Door door = (Door) this.m_doors.elementAt(index);
        if (door.getX() == x && door.getY() == y)
          return door;
      }
      return (Door) null;
    }

    public Window getWindowAt(int x, int y)
    {
      int num = this.m_windows.size();
      for (int index = 0; index < num; ++index)
      {
        Window window = (Window) this.m_windows.elementAt(index);
        if (window.getX() == x && window.getY() == y)
          return window;
      }
      return (Window) null;
    }

    public HouseObject getHouseObjectAt(int x, int y)
    {
      int num = this.m_objects.size();
      for (int index = 0; index < num; ++index)
      {
        HouseObject houseObject = (HouseObject) this.m_objects.elementAt(index);
        if (houseObject.getX() == x && houseObject.getY() == y)
          return houseObject;
      }
      return (HouseObject) null;
    }

    public void writexml(DataOutputStream @out)
    {
      StringBuffer stringBuffer = new StringBuffer();
      stringBuffer.append("<house ").append("id=\"").append(this.getName()).append("\"").append(" macroObject=\"OBJECT_MM_").append(this.getName()).append("\"").append(" >\n");
      string str1 = stringBuffer.toString();
      sbyte[] b1 = new sbyte[str1.Length];
      for (int index = 0; index < str1.Length; ++index)
        b1[index] = (sbyte) str1[index];
      @out.write(b1, 0, b1.Length);
      int num1 = this.m_rooms.size();
      for (int index = 0; index < num1; ++index)
        ((PlaceableObject) this.m_rooms.elementAt(index)).writexml((OutputStream) @out);
      int num2 = this.m_doors.size();
      for (int index = 0; index < num2; ++index)
        ((PlaceableObject) this.m_doors.elementAt(index)).writexml((OutputStream) @out);
      int num3 = this.m_windows.size();
      for (int index = 0; index < num3; ++index)
        ((PlaceableObject) this.m_windows.elementAt(index)).writexml((OutputStream) @out);
      int num4 = this.m_objects.size();
      for (int index = 0; index < num4; ++index)
        ((PlaceableObject) this.m_objects.elementAt(index)).writexml((OutputStream) @out);
      string str2 = "</house>\n";
      sbyte[] b2 = new sbyte[str2.Length];
      for (int index = 0; index < str2.Length; ++index)
        b2[index] = (sbyte) str2[index];
      @out.write(b2, 0, b2.Length);
    }

    public static House fromXMLStream(DataInputStream @is, string houseName, int houseId)
    {
      int length1 = @is.available();
      sbyte[] b = new sbyte[length1];
      char[] chArray = new char[length1];
      @is.readFully(b);
      for (int index = 0; index < length1; ++index)
        chArray[index] = (char) b[index];
      string str1 = new string(chArray);
      string str2 = "<room ";
      string str3 = "<door ";
      string str4 = "<window ";
      string str5 = "<object ";
      House house = new House(houseName, houseId);
      int startIndex = 0;
      do
      {
        int length2 = str1.IndexOf('\n', startIndex);
        string str6 = str1.Substring(startIndex, length2);
        if (str6.IndexOf(str2) != -1)
          house.addRoom(Room.fromXMLString(str6));
        else if (str6.IndexOf(str3) != -1)
          house.addDoor(Door.fromXMLString(str6));
        else if (str6.IndexOf(str4) != -1)
          house.addWindow(Window.fromXMLString(str6));
        else if (str6.IndexOf(str5) != -1)
          house.addHouseObject(HouseObject.fromXMLString(str6));
        startIndex = length2 + 1;
      }
      while (startIndex < str1.Length);
      return house;
    }
  }
}
