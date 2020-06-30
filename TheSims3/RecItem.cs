// Decompiled with JetBrains decompiler
// Type: RecItem
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class RecItem
{
  public const int MODELID_EXT_FLAG = 16384;
  public short m_packId;
  public short m_index;
  public int m_descStringId;
  public short m_icon;
  public int m_flags;
  public short m_buyPrice;
  public short m_sellPrice;
  public sbyte m_maxInventory;
  public short m_associatedObj;
  public short m_inventoryCount;

  public RecItem()
  {
    this.m_packId = (short) -1;
    this.m_index = (short) -1;
    this.m_descStringId = -1;
    this.m_icon = (short) 0;
    this.m_flags = -1;
    this.m_buyPrice = (short) -1;
    this.m_sellPrice = (short) -1;
    this.m_maxInventory = (sbyte) -1;
    this.m_inventoryCount = (short) 0;
    this.m_associatedObj = (short) 0;
  }

  public RecItem(RecItem rhs)
  {
    this.m_packId = rhs.m_packId;
    this.m_index = rhs.m_index;
    this.m_descStringId = rhs.m_descStringId;
    this.m_icon = rhs.m_icon;
    this.m_flags = rhs.m_flags;
    this.m_buyPrice = rhs.m_buyPrice;
    this.m_sellPrice = rhs.m_sellPrice;
    this.m_maxInventory = rhs.m_maxInventory;
    this.m_inventoryCount = rhs.m_inventoryCount;
  }

  public RecItem CopyFrom(RecItem rhs)
  {
    if (this != rhs)
    {
      this.m_packId = rhs.m_packId;
      this.m_index = rhs.m_index;
      this.m_descStringId = rhs.m_descStringId;
      this.m_icon = rhs.m_icon;
      this.m_flags = rhs.m_flags;
      this.m_buyPrice = rhs.m_buyPrice;
      this.m_sellPrice = rhs.m_sellPrice;
      this.m_maxInventory = rhs.m_maxInventory;
      this.m_inventoryCount = rhs.m_inventoryCount;
    }
    return this;
  }

  public void readBuiltIn(DataInputStream dis, int index)
  {
    this.m_packId = (short) -1;
    this.m_index = (short) index;
    this.m_descStringId = (int) SimWorld.lookupSimsWorld(dis);
    this.m_icon = SimWorld.lookupSimsWorld(dis);
    this.m_flags = dis.readInt();
    this.m_buyPrice = dis.readShort();
    this.m_sellPrice = dis.readShort();
    this.m_maxInventory = dis.readByte();
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
    this.m_descStringId = (int) (ushort) dis.readShort() | stringPooldId << 11;
    this.m_icon = (short) ((int) dis.readShort() + 11);
    this.m_flags = dis.readInt();
    this.m_buyPrice = dis.readShort();
    this.m_sellPrice = dis.readShort();
    this.m_maxInventory = dis.readByte();
  }
}
