// Decompiled with JetBrains decompiler
// Type: DLCManager
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;
using sims3;
using System.Collections.Generic;

internal class DLCManager : DLCHandler
{
  private static readonly string DLCDATA_FILENAME = "dlcdata.bin";
  private static readonly string PACKDATA_FILENAME = "packdata.bin";
  private static readonly string STRINGS_DLC_FILENAME = "strings_dlc.bin";
  private static readonly string PACKINFO_FILENAME = "pack.info";
  private static readonly string TAGPNG_FILENAME = "tag";
  public static readonly string pathSeparatorChar = "/";
  private readonly string[] DLC_PACK_FILENAMES = new string[16]
  {
    "dlc_decorative.zip",
    "dlc_deviant.zip",
    "dlc_goth_cas.zip",
    "dlc_goth_lifestyle.zip",
    "dlc_medieval_cas.zip",
    "dlc_medieval_lifestyle.zip",
    "dlc_nightlife_cas.zip",
    "dlc_nightlife_lifestyle.zip",
    "dlc_scifi_cas.zip",
    "dlc_scifi_lifestyle.zip",
    "dlc_university_cas.zip",
    "dlc_university_lifestyle.zip",
    "dlc_vampwere_cas.zip",
    "dlc_vampwere_lifestyle.zip",
    "dlc_holidaypack.zip",
    "dlc_wa_cas.zip"
  };
  private bool m_bakedDLC;
  private string m_rootFolder;
  private List<DLCPack> m_packs;
  private int m_packCount;
  private int[] m_packSellIds;
  private int m_totalObjects;
  private RecObject[] m_objectRecordIndex;
  private int m_totalItems;
  private RecItem[] m_itemRecordIndex;
  private static DLCManager instance;
  private static DLCManager instanceBaked;

  public int getPackCount()
  {
    return this.m_packCount;
  }

  private DLCManager(bool bakedDLC)
  {
    this.m_bakedDLC = bakedDLC;
    this.m_rootFolder = (string) null;
    this.m_packs = new List<DLCPack>();
    this.m_packCount = 0;
    this.m_packSellIds = new int[0];
    this.m_totalObjects = 0;
    this.m_objectRecordIndex = new RecObject[0];
    this.m_totalItems = 0;
    this.m_itemRecordIndex = new RecItem[0];
    this.m_rootFolder = "baked_dlc";
  }

  public static DLCManager getInstance()
  {
    if (DLCManager.instance == null)
      DLCManager.instance = new DLCManager(true);
    return DLCManager.instance;
  }

  private static DLCManager getInstanceBaked()
  {
    if (DLCManager.instanceBaked == null)
      DLCManager.instanceBaked = new DLCManager(true);
    return DLCManager.instanceBaked;
  }

  private void saveDLCData()
  {
    if (this.m_bakedDLC)
      return;
    StringBuffer stringBuffer = new StringBuffer();
    stringBuffer.append(this.m_rootFolder);
    stringBuffer.append(DLCManager.pathSeparatorChar);
    stringBuffer.append(DLCManager.DLCDATA_FILENAME);
    FileOutputStream fileOutputStream = new FileOutputStream(stringBuffer.toString());
    fileOutputStream.clear();
    DataOutputStream dataOutputStream = new DataOutputStream((OutputStream) fileOutputStream);
    dataOutputStream.writeInt(this.m_packCount);
    for (int index = 0; index < this.m_packCount; ++index)
      dataOutputStream.writeInt(this.m_packSellIds[index]);
    dataOutputStream.close();
  }

  private void loadDLCData()
  {
    StringBuffer stringBuffer = new StringBuffer();
    stringBuffer.append(this.m_rootFolder);
    stringBuffer.append(DLCManager.pathSeparatorChar);
    stringBuffer.append(DLCManager.DLCDATA_FILENAME);
    DataInputStream dataInputStream1 = new DataInputStream(JavaLib.getResourceAsStream(stringBuffer.toString(), false));
    if (dataInputStream1 == null)
    {
      this.m_packCount = 0;
      this.m_packSellIds = new int[0];
    }
    else
    {
      DataInputStream dataInputStream2 = dataInputStream1;
      this.m_packCount = dataInputStream2.readInt();
      this.m_packSellIds = new int[this.m_packCount];
      for (int index = 0; index < this.m_packCount; ++index)
        this.m_packSellIds[index] = dataInputStream2.readInt();
      dataInputStream2.close();
    }
  }

  public void initPacks()
  {
    TextManager textManager = AppEngine.getCanvas().getTextManager();
    this.loadDLCData();
    this.m_totalObjects = 0;
    this.m_totalItems = 0;
    for (int packId = 0; packId < this.m_packCount; ++packId)
    {
      DLCPack dlcPack = this.loadPack(packId, this.m_packSellIds[packId]);
      if (dlcPack != null)
      {
        this.m_totalObjects += dlcPack.d_objectRecords.Length;
        this.m_totalItems += dlcPack.d_itemRecords.Length;
        this.m_packs.Add(dlcPack);
      }
    }
    this.initObjectIndex();
    textManager.setCurrentLocale(textManager.getCurrentLocale());
  }

  private string readXMLtoBinFilename(DataInputStream dis, string prefix)
  {
    string str = RecObject.readXMLtoBinString(dis);
    if (str == null || str.Length <= 0)
      return (string) null;
    if (prefix == null)
      return str;
    StringBuffer stringBuffer = new StringBuffer();
    stringBuffer.append(prefix);
    stringBuffer.append(DLCManager.pathSeparatorChar);
    stringBuffer.append(str);
    return stringBuffer.toString();
  }

  private DLCPack loadPack(int packId, int sellId)
  {
    AppEngine canvas = AppEngine.getCanvas();
    SimWorld simWorld = canvas.getSimWorld();
    SimData simData = canvas.getSimData();
    TextManager textManager = canvas.getTextManager();
    DLCPack dlcPack = new DLCPack();
    StringBuffer stringBuffer = new StringBuffer();
    stringBuffer.setLength(0);
    stringBuffer.append(this.m_rootFolder);
    stringBuffer.append(DLCManager.pathSeparatorChar);
    stringBuffer.append(sellId);
    string str1 = stringBuffer.toString();
    stringBuffer.setLength(0);
    stringBuffer.append(str1);
    stringBuffer.append(DLCManager.pathSeparatorChar);
    stringBuffer.append(DLCManager.PACKDATA_FILENAME);
    DataInputStream dis = new DataInputStream(JavaLib.getResourceAsStream(stringBuffer.toString(), false));
    stringBuffer.setLength(0);
    stringBuffer.append(str1);
    stringBuffer.append(DLCManager.pathSeparatorChar);
    stringBuffer.append(DLCManager.STRINGS_DLC_FILENAME);
    string filename = stringBuffer.toString();
    int stringPooldId = textManager.addStringsFile(filename);
    dis.readInt();
    dlcPack.d_packId = dis.readInt();
    dlcPack.d_packName = RecObject.readXMLtoBinString(dis);
    string str2 = this.readXMLtoBinFilename(dis, str1);
    dlcPack.d_objectTextureFilename = str2;
    string str3 = this.readXMLtoBinFilename(dis, str1);
    dlcPack.d_objectScrollingTextureFilename = str3;
    dlcPack.d_objectScrollingTextureTiming = dis.readInt();
    string str4 = this.readXMLtoBinFilename(dis, str1);
    dlcPack.d_simMaleFilename = str4;
    string str5 = this.readXMLtoBinFilename(dis, str1);
    dlcPack.d_simFemaleFilename = str5;
    string str6 = this.readXMLtoBinFilename(dis, str1);
    dlcPack.d_miniCarModelFilename = str6;
    string str7 = this.readXMLtoBinFilename(dis, str1);
    dlcPack.d_miniCarTextureFilename = str7;
    int length1 = (int) dis.readByte();
    short[] numArray1 = new short[length1];
    for (int index = 0; index < length1; ++index)
    {
      int action = (int) dis.readShort();
      numArray1[index] = (short) action;
      simData.unlockAction(action, packId);
    }
    int length2 = (int) dis.readShort();
    RecObject[] recObjectArray = new RecObject[length2];
    for (int index = 0; index < length2; ++index)
    {
      recObjectArray[index] = new RecObject();
      recObjectArray[index].readDLC(dis, packId, index, stringPooldId, str1);
    }
    int length3 = (int) dis.readByte();
    RecItem[] recItemArray = new RecItem[length3];
    for (int index = 0; index < length3; ++index)
    {
      recItemArray[index] = new RecItem();
      recItemArray[index].readDLC(dis, packId, index, stringPooldId, str1);
    }
    int length4 = (int) dis.readByte();
    short[] numArray2 = new short[length4];
    for (int index = 0; index < length4; ++index)
    {
      int wallId = (int) dis.readShort();
      numArray2[index] = (short) wallId;
      simWorld.unlockWall(wallId, packId);
    }
    int length5 = (int) dis.readByte();
    short[] numArray3 = new short[length5];
    for (int index = 0; index < length5; ++index)
    {
      int floorId = (int) dis.readShort();
      numArray3[index] = (short) floorId;
      simWorld.unlockFloor(floorId, packId);
    }
    int num = (int) dis.readByte();
    int length6 = 15;
    short[][] numArray4 = new short[length6][];
    int[][] numArray5 = new int[length6][];
    string[][][] strArray1 = new string[length6][][];
    for (int index1 = 0; index1 < length6; ++index1)
    {
      int length7 = (int) dis.readByte();
      short[] numArray6 = new short[length7];
      int[] numArray7 = new int[length7];
      string[][] strArray2 = new string[length7][];
      for (int index2 = 0; index2 < length7; ++index2)
      {
        numArray6[index2] = (short) dis.readInt();
        numArray7[index2] = dis.readInt();
        int length8 = (int) dis.readByte();
        string[] strArray3 = new string[length8];
        for (int index3 = 0; index3 < length8; ++index3)
        {
          string str8 = this.readXMLtoBinFilename(dis, str1);
          strArray3[index3] = str8;
        }
        strArray2[index2] = strArray3;
      }
      numArray4[index1] = numArray6;
      numArray5[index1] = numArray7;
      strArray1[index1] = strArray2;
    }
    dlcPack.d_objectRecords = recObjectArray;
    dlcPack.d_itemRecords = recItemArray;
    dlcPack.d_simAttribUserIds = numArray4;
    dlcPack.d_simAttribFlags = numArray5;
    dlcPack.d_simAttribTextureFilenames = strArray1;
    return dlcPack;
  }

  private void initObjectIndex()
  {
    int index1 = 0;
    this.m_objectRecordIndex = new RecObject[this.m_totalObjects];
    for (int packId = 0; packId < this.m_packCount; ++packId)
    {
      RecObject[] dObjectRecords = this.getDLCPack(packId).d_objectRecords;
      int length = dObjectRecords.Length;
      for (int index2 = 0; index2 < length; ++index2)
      {
        this.m_objectRecordIndex[index1] = dObjectRecords[index2];
        dObjectRecords[index2].m_modelId = (short) (index1 | 16384);
        ++index1;
      }
    }
    int index3 = 0;
    this.m_itemRecordIndex = new RecItem[this.m_totalItems];
    for (int packId = 0; packId < this.m_packCount; ++packId)
    {
      RecItem[] dItemRecords = this.getDLCPack(packId).d_itemRecords;
      int length = dItemRecords.Length;
      for (int index2 = 0; index2 < length; ++index2)
      {
        this.m_itemRecordIndex[index3] = dItemRecords[index2];
        ++index3;
      }
    }
    ModelManager.getInstance().initExtAppearances();
  }

  public DLCPack getDLCPack(int packId)
  {
    return this.m_packs[packId];
  }

  public DLCPack getDLCPackByUniqueId(int uniquePackId)
  {
    int packIdByUniqueId = this.getPackIdByUniqueId(uniquePackId);
    if (packIdByUniqueId != -1)
      return this.m_packs[packIdByUniqueId];
    return !this.m_bakedDLC ? DLCManager.getInstanceBaked().getDLCPackByUniqueId(uniquePackId) : (DLCPack) null;
  }

  public int getDLCPackUniqudId(int packId)
  {
    return this.getDLCPack(packId).d_packId;
  }

  public int getPackIdByUniqueId(int uniquePackId)
  {
    int packCount = this.getPackCount();
    for (int packId = 0; packId < packCount; ++packId)
    {
      if (this.getDLCPack(packId).d_packId == uniquePackId)
        return packId;
    }
    return -1;
  }

  public string getObjectTextureFilename(int packId)
  {
    return this.getDLCPack(packId).d_objectTextureFilename;
  }

  public string getObjectScrollingTextureFilename(int packId)
  {
    return this.getDLCPack(packId).d_objectScrollingTextureFilename;
  }

  public int getObjectScrollingTextureTiming(int packId)
  {
    return this.getDLCPack(packId).d_objectScrollingTextureTiming;
  }

  public string getMiniCarTextureFilename(int packId)
  {
    return this.getDLCPack(packId).d_miniCarTextureFilename;
  }

  public string getMiniCarModelFilename(int packId)
  {
    return this.getDLCPack(packId).d_miniCarModelFilename;
  }

  public bool isPackAllowedBySellId(int sellId)
  {
    return true;
  }

  public bool isPackAllowed(int packId)
  {
    return true;
  }

  public Image getPackTagByUniquePackId(int uniquePackId)
  {
    int packIdByUniqueId = this.getPackIdByUniqueId(uniquePackId);
    if (packIdByUniqueId != -1)
      return this.getPackTag(packIdByUniqueId);
    return !this.m_bakedDLC ? DLCManager.getInstanceBaked().getPackTagByUniquePackId(uniquePackId) : (Image) null;
  }

  public Image getPackTag(int packId)
  {
    DLCPack dlcPack = this.getDLCPack(packId);
    if (dlcPack.m_tagImage == null)
    {
      string str = this.m_packSellIds[packId].ToString();
      string name = this.m_rootFolder + DLCManager.pathSeparatorChar + str + DLCManager.pathSeparatorChar + DLCManager.TAGPNG_FILENAME;
      if (name != null)
      {
        Image image = Image.createImage(name);
        dlcPack.m_tagImage = image;
      }
    }
    return dlcPack.m_tagImage;
  }

  public string getPackName(int packId)
  {
    return this.getDLCPack(packId).d_packName;
  }

  public int getDLCObjectCount()
  {
    return this.m_objectRecordIndex.Length;
  }

  public RecObject getDLCObjectRecord(int extObjectId)
  {
    return this.m_objectRecordIndex[extObjectId];
  }

  public string getModelFilename(int modelId)
  {
    return this.m_objectRecordIndex[modelId & -16385].m_modelFilename;
  }

  public int getModelPackId(int modelId)
  {
    return (int) this.m_objectRecordIndex[modelId & -16385].m_packId;
  }

  public int getDLCItemCount()
  {
    return this.m_itemRecordIndex.Length;
  }

  public RecItem getDLCItemRecord(int extItemId)
  {
    return this.m_itemRecordIndex[extItemId];
  }

  public int getDLCItemCarObject(int extItemId)
  {
    int packId = (int) this.getDLCItemRecord(extItemId).m_packId;
    for (int index = 0; index < this.m_objectRecordIndex.Length; ++index)
    {
      if ((int) this.m_objectRecordIndex[index].m_packId == packId && this.m_objectRecordIndex[index].m_parent == (sbyte) 9)
        return index;
    }
    return -1;
  }

  public int getSimMeshUserIdCount(int attribId)
  {
    int num = 0;
    for (int packId = 0; packId < this.m_packCount; ++packId)
    {
      DLCPack dlcPack = this.getDLCPack(packId);
      num += dlcPack.d_simAttribUserIds[attribId].Length;
    }
    return num;
  }

  public int getSimTextureIdCount(int attribId, int optIndex)
  {
    if (attribId == 0 || attribId == 1 || attribId == 8)
    {
      int num = 0;
      for (int packId = 0; packId < this.m_packCount; ++packId)
      {
        DLCPack dlcPack = this.getDLCPack(packId);
        num += dlcPack.d_simAttribTextureFilenames[attribId][optIndex].Length;
      }
      return num;
    }
    int num1 = 0;
    for (int packId = 0; packId < this.m_packCount; ++packId)
    {
      DLCPack dlcPack = this.getDLCPack(packId);
      int index = optIndex - num1;
      int length = dlcPack.d_simAttribUserIds[attribId].Length;
      if (index < length)
        return dlcPack.d_simAttribTextureFilenames[attribId][index].Length;
      num1 += length;
    }
    return 0;
  }

  public int getSimMeshPackId(int attribId, int optIndex, bool getOffset)
  {
    if (attribId == 0 || attribId == 1 || attribId == 8)
    {
      int num1 = 0;
      for (int packId = 0; packId < this.m_packCount; ++packId)
      {
        DLCPack dlcPack = this.getDLCPack(packId);
        int num2 = optIndex - num1;
        int length = dlcPack.d_simAttribTextureFilenames[attribId][0].Length;
        if (num2 < length)
          return getOffset ? num2 : packId;
        num1 += length;
      }
    }
    int num3 = 0;
    for (int packId = 0; packId < this.m_packCount; ++packId)
    {
      DLCPack dlcPack = this.getDLCPack(packId);
      int num1 = optIndex - num3;
      int length = dlcPack.d_simAttribUserIds[attribId].Length;
      if (num1 < length)
        return getOffset ? num1 : packId;
      num3 += length;
    }
    return -1;
  }

  public int getSimAttribIdLocal(int attribId, int packId, int index)
  {
    int num = 0;
    for (int packId1 = 0; packId1 < packId; ++packId1)
    {
      DLCPack dlcPack = this.getDLCPack(packId1);
      switch (attribId)
      {
        case 0:
        case 1:
        case 8:
          int length1 = dlcPack.d_simAttribTextureFilenames[attribId][0].Length;
          num += length1;
          break;
        default:
          int length2 = dlcPack.d_simAttribUserIds[attribId].Length;
          num += length2;
          break;
      }
    }
    return num + index;
  }

  public bool isPackInstalledBySellId(int sellId)
  {
    for (int index = 0; index < this.m_packCount; ++index)
    {
      if (this.m_packSellIds[index] == sellId)
        return true;
    }
    return false;
  }

  public bool installDLC(string contentFilename, int sellId)
  {
    return false;
  }
}
