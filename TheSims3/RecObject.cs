// Decompiled with JetBrains decompiler
// Type: RecObject
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class RecObject
{
  public string m_modelFilename = "";
  public const int MODELID_EXT_FLAG = 16384;
  public short m_packId;
  public short m_index;
  public sbyte m_parent;
  public sbyte m_category;
  public int m_stringId;
  public short m_actionIcon;
  public int m_flags;
  public short m_need;
  public short m_buyPrice;
  public short m_sellPrice;
  public sbyte m_footprintWidth;
  public sbyte m_footprintHeight;
  public short m_modelId;
  public sbyte[] m_interestPointXs;
  public sbyte[] m_interestPointYs;
  public short[] m_actions;

  public RecObject()
  {
    this.m_packId = (short) -1;
    this.m_index = (short) -1;
    this.m_parent = (sbyte) -1;
    this.m_category = (sbyte) -1;
    this.m_stringId = -1;
    this.m_actionIcon = (short) -1;
    this.m_flags = 0;
    this.m_need = (short) -1;
    this.m_buyPrice = (short) -1;
    this.m_sellPrice = (short) -1;
    this.m_footprintWidth = (sbyte) -1;
    this.m_footprintHeight = (sbyte) -1;
    this.m_modelId = (short) -1;
    this.m_modelFilename = (string) null;
    this.m_interestPointXs = new sbyte[0];
    this.m_interestPointYs = new sbyte[0];
    this.m_actions = new short[0];
  }

  public RecObject(RecObject rhs)
  {
    this.m_packId = rhs.m_packId;
    this.m_index = rhs.m_index;
    this.m_parent = rhs.m_parent;
    this.m_category = rhs.m_category;
    this.m_stringId = rhs.m_stringId;
    this.m_actionIcon = rhs.m_actionIcon;
    this.m_flags = rhs.m_flags;
    this.m_need = rhs.m_need;
    this.m_buyPrice = rhs.m_buyPrice;
    this.m_sellPrice = rhs.m_sellPrice;
    this.m_footprintWidth = rhs.m_footprintWidth;
    this.m_footprintHeight = rhs.m_footprintHeight;
    this.m_modelId = rhs.m_modelId;
    this.m_modelFilename = rhs.m_modelFilename;
    this.m_interestPointXs = rhs.m_interestPointXs;
    this.m_interestPointYs = rhs.m_interestPointYs;
    this.m_actions = rhs.m_actions;
  }

  public RecObject CopyFrom(RecObject rhs)
  {
    if (this != rhs)
    {
      this.m_packId = rhs.m_packId;
      this.m_index = rhs.m_index;
      this.m_parent = rhs.m_parent;
      this.m_category = rhs.m_category;
      this.m_stringId = rhs.m_stringId;
      this.m_actionIcon = rhs.m_actionIcon;
      this.m_flags = rhs.m_flags;
      this.m_need = rhs.m_need;
      this.m_buyPrice = rhs.m_buyPrice;
      this.m_sellPrice = rhs.m_sellPrice;
      this.m_footprintWidth = rhs.m_footprintWidth;
      this.m_footprintHeight = rhs.m_footprintHeight;
      this.m_modelId = rhs.m_modelId;
      this.m_modelFilename = rhs.m_modelFilename.ToString();
      this.m_interestPointXs = rhs.m_interestPointXs;
      this.m_interestPointYs = rhs.m_interestPointYs;
      this.m_actions = rhs.m_actions;
    }
    return this;
  }

  public virtual void Dispose()
  {
  }

  public void readBuiltIn(DataInputStream dis, int index)
  {
    this.m_packId = (short) -1;
    this.m_index = (short) index;
    this.m_parent = dis.readByte();
    this.m_category = dis.readByte();
    this.m_stringId = (int) SimWorld.lookupSimsWorld(dis);
    this.m_actionIcon = SimWorld.lookupSimsWorld(dis);
    this.m_flags = dis.readInt();
    this.m_need = dis.readShort();
    this.m_buyPrice = dis.readShort();
    this.m_sellPrice = dis.readShort();
    this.m_footprintWidth = dis.readByte();
    this.m_footprintHeight = dis.readByte();
    this.m_modelId = SimWorld.lookupSimsWorld(dis);
    this.m_modelFilename = (string) null;
    int length1 = (int) dis.readByte();
    sbyte[] numArray1 = new sbyte[length1];
    sbyte[] numArray2 = new sbyte[length1];
    for (int index1 = 0; index1 < length1; ++index1)
    {
      numArray1[index1] = dis.readByte();
      numArray2[index1] = dis.readByte();
    }
    int length2 = (int) dis.readByte();
    short[] numArray3 = new short[length2];
    for (int index1 = 0; index1 < length2; ++index1)
      numArray3[index1] = dis.readShort();
    this.m_interestPointXs = numArray1;
    this.m_interestPointYs = numArray2;
    this.m_actions = numArray3;
  }

  public void readDLC(
    DataInputStream dis,
    int packId,
    int index,
    int stringPooldId,
    string resPrefix)
  {
    this.m_packId = (short) packId;
    this.m_index = (short) index;
    this.m_parent = dis.readByte();
    this.m_category = dis.readByte();
    this.m_stringId = (int) dis.readShort();
    this.m_actionIcon = (short) ((int) dis.readShort() + 11);
    this.m_flags = dis.readInt();
    this.m_need = dis.readShort();
    this.m_buyPrice = dis.readShort();
    this.m_sellPrice = dis.readShort();
    this.m_footprintWidth = dis.readByte();
    this.m_footprintHeight = dis.readByte();
    this.m_modelId = (short) -1;
    string str = RecObject.readXMLtoBinString(dis);
    StringBuffer stringBuffer = new StringBuffer(resPrefix);
    stringBuffer.append(DLCManager.pathSeparatorChar);
    stringBuffer.append(str);
    this.m_modelFilename = stringBuffer.toString();
    int length1 = (int) dis.readByte();
    sbyte[] numArray1 = new sbyte[length1];
    sbyte[] numArray2 = new sbyte[length1];
    for (int index1 = 0; index1 < length1; ++index1)
    {
      numArray1[index1] = dis.readByte();
      numArray2[index1] = dis.readByte();
    }
    int length2 = (int) dis.readByte();
    short[] numArray3 = new short[length2];
    for (int index1 = 0; index1 < length2; ++index1)
      numArray3[index1] = dis.readShort();
    this.m_interestPointXs = numArray1;
    this.m_interestPointYs = numArray2;
    this.m_actions = numArray3;
  }

  public static string readXMLtoBinString(DataInputStream dis)
  {
    int length = (int) dis.readByte();
    if (length < 0)
      return "";
    char[] chArray = new char[length];
    for (int index = 0; index < length; ++index)
      chArray[index] = (char) dis.readByte();
    return new string(chArray);
  }
}
