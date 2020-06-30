// Decompiled with JetBrains decompiler
// Type: SimWorld
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using house;
using m3g;
using midp;
using System;

public class SimWorld : GlobalConstants
{
  public static readonly int[] PLAYER_HOUSE_LIST = new int[3]
  {
    0,
    1,
    2
  };
  public static readonly int[] ROTATION_FLAGS = new int[4]
  {
    1,
    2,
    4,
    8
  };
  internal static readonly string[] LEGACY_LOOKUP_ITEM = new string[52]
  {
    "REPAIRING_KIT",
    "FISHING_KIT",
    "GARDENING_WATERINGCAN",
    "GARDENING_FERTILIZER",
    "SEED_BELLPEPPER",
    "SEED_CARROT",
    "SEED_CORN",
    "SEED_LETTUCE",
    "SEED_TOMATO",
    "BEANS",
    "CAPSICUM",
    "CARROT",
    "CORN",
    "EGGPLANT",
    "LETTUCE",
    "ONION",
    "POTATO",
    "SPINACH",
    "TOMATO",
    "ZUCCHINI",
    "CHEESE",
    "BREAD",
    "PASTA",
    "EGGS",
    "STEAK",
    "PORK",
    "HAM",
    "CHICKEN",
    "LOBSTER",
    "FISH_CATFISH",
    "FISH_SNAPPER",
    "FISH_TROUT",
    "FISH_SALMON",
    "FISH_TUNA",
    "CAR",
    "RECIPE_CHEESETOAST",
    "RECIPE_BACONEGGS",
    "RECIPE_CHEESEBURGERS",
    "RECIPE_SPAGHETTI",
    "RECIPE_RATATOUILLE",
    "RECIPE_QUICHE",
    "RECIPE_STEAK",
    "RECIPE_CHICKENSALAD",
    "RECIPE_PORKCHOPS",
    "RECIPE_MINISTRONE",
    "RECIPE_PIZZA",
    "RECIPE_SURFNTURF",
    "RECIPE_SALMON",
    "RECIPE_SNAPPER",
    "RECIPE_TUNA",
    "RECIPE_TROUT",
    "RECIPE_GUMBO"
  };
  internal readonly int[] CREATE_FLOOR_OFFSETS = new int[24]
  {
    -1,
    -1,
    16,
    -1,
    0,
    1,
    -1,
    1,
    32,
    0,
    -1,
    4,
    0,
    1,
    8,
    1,
    -1,
    64,
    1,
    0,
    2,
    1,
    1,
    128
  };
  private Transform tempTransform = new Transform();
  private Vector m_houseRoomCorners = new Vector();
  private float[] m_camRangeSlowdownVec = new float[2];
  private int[] PATH_FIND_OFFSETS = new int[32]
  {
    -1,
    0,
    512,
    4352,
    1,
    0,
    256,
    4608,
    0,
    -1,
    2048,
    5120,
    0,
    1,
    1024,
    6144,
    -1,
    -1,
    2560,
    5376,
    1,
    -1,
    2304,
    5632,
    1,
    1,
    1280,
    6656,
    -1,
    1,
    1536,
    6400
  };
  private const int MAX_HOUSE_OBJECTS = 150;
  public const int WALL_NORTH = 0;
  public const int WALL_EAST = 1;
  public const int WALL_SOUTH = 2;
  public const int WALL_WEST = 3;
  public const int WORLD_TILE_SHIFT = 5;
  public const int WORLD_TILE_SIZE = 2097152;
  private const int FLOOR_NUM_DIVS_X = 8;
  private const int FLOOR_NUM_DIVS_Z = 8;
  private const int DAYNIGHT_INTERVAL = 750;
  public const int FLOOR_GRASS2 = 10;
  public const int FLOOR_GRASS3 = 11;
  public const int WALL_OUTSIDE = 27;
  private const int PATH_MAX_AVOID_TILES = 10;
  private const int PATH_WIDTH = 80;
  private const int PATH_HEIGHT = 80;
  private const int PATH_HCOST = 200;
  private const int PATH_GCOST_DEFAULT = 200;
  private const int PATH_GCOST_DIAG = 300;
  private const int PATH_GCOST_DIAG_CAR_GOOD = 300;
  private const int PATH_GCOST_DIAG_CAR_BAD = 500;
  private const int PATH_GCOST_TURN = 30;
  private const int PATH_GCOST_AVOID = 500;
  private const int PATH_GCOST_ROAD_GOOD = -150;
  private const int PATH_GCOST_ROAD_BAD = 150;
  private const int PATH_GCOST_SIDEWALK_GOOD = -50;
  private const int PATH_GCOST_SIDEWALK_BAD = 150;
  public const int PATHFLAG_AVOID = 1;
  public const int PATHFLAG_ATTRIB_CAR = 2;
  public const int PATHFLAG_ATTRIB_INCAR = 4;
  public const int PATHFLAG_ATTRIB_WALK = 8;
  public const int PATHFLAG_STRAIGHTEN = 16;
  private AppEngine m_engine;
  private float[] m_tempFloat4;
  private int[] m_tempInt4;
  private RecObject[] d_objectRecordsBuiltIn;
  private short[] d_categoryStrings;
  private short[] d_categoryIcons;
  private short[][] d_appearanceAnim3Ds;
  private short[][] d_simAttribUserIds;
  private int[][] d_simAttribFlags;
  private short[][][] d_simAttribTextureIds;
  private short[] d_floorStringIds;
  private short[] d_floorGroupStringIds;
  private int[][] d_floorTexCoords;
  private short[] d_wallStringIds;
  private short[] d_wallGroupStringIds;
  private int[][] d_wallTexCoords;
  private RecItem[] d_itemRecordsBuiltIn;
  private sbyte[] d_recipeItems;
  private sbyte[] d_recipeReplenishes;
  private short[][] d_recipeIngredients;
  private short[] d_houseMacroObjects;
  private sbyte[][] d_houseRoomXs;
  private sbyte[][] d_houseRoomYs;
  private sbyte[][] d_houseRoomWidths;
  private sbyte[][] d_houseRoomHeights;
  private sbyte[][] d_houseRoomFloors;
  private sbyte[][] d_houseRoomWalls;
  private sbyte[][] d_houseDoorXs;
  private sbyte[][] d_houseDoorYs;
  private sbyte[][] d_houseDoorWidths;
  private short[][] d_houseDoorTypes;
  private sbyte[][] d_houseWindowXs;
  private sbyte[][] d_houseWindowYs;
  private sbyte[][] d_houseWindowWidths;
  private short[][] d_houseWindowTypes;
  private sbyte[][] d_houseObjectXs;
  private sbyte[][] d_houseObjectZs;
  private short[][] d_houseObjectTypes;
  private sbyte[][] d_houseObjectFacingDirs;
  private int m_houseIndex;
  private sbyte m_playerHouseLevel;
  private sbyte[] m_playerHouseObjectXs;
  private sbyte[] m_playerHouseObjectZs;
  private short[] m_playerHouseObjectTypes;
  private sbyte[] m_playerHouseObjectFacingDirs;
  private sbyte[] m_playerHouseWallTypes;
  private sbyte[] m_playerHouseFloorTypes;
  private int m_viewportX;
  private int m_viewportY;
  private int m_viewportWidth;
  private int m_viewportHeight;
  private int m_attribWidth;
  private int m_attribHeight;
  private int m_attribOffsetX;
  private int m_attribOffsetZ;
  private short[] m_attributesLayer;
  private Room[] m_houseRooms;
  private Mesh[] m_floorMeshes;
  private Background m_background;
  private World m_world;
  private Group m_worldObjects;
  private Node m_visuals;
  private Node m_additiveVisuals;
  private AnimPlayer3D m_visualsAnimPlayer;
  private int m_dayNightTimer;
  private bool m_dayNightForce;
  private int m_dayNightTint;
  private int m_dayNightSky;
  private bool m_dayNightLighting;
  private Camera m_camera;
  private Transform m_cameraTransform;
  private Transform m_cameraTransformPreRotate;
  private Transform m_cameraTransformInv;
  private float m_cameraPosX;
  private float m_cameraPosY;
  private float m_cameraPosZ;
  private float m_cameraCenterX;
  private float m_cameraCenterZ;
  private float m_cameraPitch;
  private float m_cameraYaw;
  private float m_cameraDolly;
  private short[] m_unlockedFloorIds;
  private short[] m_unlockedFloorPackIds;
  private short[] m_unlockedWallIds;
  private short[] m_unlockedWallPackIds;
  private int m_pathStartX;
  private int m_pathStartY;
  private int m_pathDestX;
  private int m_pathDestY;
  private int[] m_pathAvoidTiles;
  private int m_pathNumAvoidTiles;
  private int m_pathOffsetX;
  private int m_pathOffsetY;
  private short[] m_pathOpenList;
  private int m_pathOpenCount;
  private short[] m_pathClosedList;
  private int m_pathClosedCount;
  private short[][] m_pathParentArray;
  private int[][] m_pathFCost;
  private int[][] m_pathGCost;
  private int[][] m_pathHCost;
  private short[] m_pathList;
  private int m_pathFlags;

  public SimWorld(AppEngine ae)
  {
    this.m_engine = ae;
    this.m_tempFloat4 = new float[4];
    this.m_tempInt4 = new int[4];
    this.d_objectRecordsBuiltIn = (RecObject[]) null;
    this.d_categoryStrings = (short[]) null;
    this.d_categoryIcons = (short[]) null;
    this.d_appearanceAnim3Ds = new short[0][];
    this.d_simAttribUserIds = new short[0][];
    this.d_simAttribFlags = new int[0][];
    this.d_simAttribTextureIds = new short[0][][];
    this.d_floorStringIds = new short[0];
    this.d_floorGroupStringIds = new short[0];
    this.d_floorTexCoords = new int[0][];
    this.d_wallStringIds = new short[0];
    this.d_wallGroupStringIds = new short[0];
    this.d_wallTexCoords = new int[0][];
    this.d_itemRecordsBuiltIn = (RecItem[]) null;
    this.d_recipeItems = new sbyte[0];
    this.d_recipeReplenishes = new sbyte[0];
    this.d_recipeIngredients = new short[0][];
    this.d_houseMacroObjects = new short[0];
    this.d_houseRoomXs = new sbyte[0][];
    this.d_houseRoomYs = new sbyte[0][];
    this.d_houseRoomWidths = new sbyte[0][];
    this.d_houseRoomHeights = new sbyte[0][];
    this.d_houseRoomFloors = new sbyte[0][];
    this.d_houseRoomWalls = new sbyte[0][];
    this.d_houseDoorXs = new sbyte[0][];
    this.d_houseDoorYs = new sbyte[0][];
    this.d_houseDoorWidths = new sbyte[0][];
    this.d_houseDoorTypes = new short[0][];
    this.d_houseWindowXs = new sbyte[0][];
    this.d_houseWindowYs = new sbyte[0][];
    this.d_houseWindowWidths = new sbyte[0][];
    this.d_houseWindowTypes = new short[0][];
    this.d_houseObjectXs = new sbyte[0][];
    this.d_houseObjectZs = new sbyte[0][];
    this.d_houseObjectTypes = new short[0][];
    this.d_houseObjectFacingDirs = new sbyte[0][];
    this.m_houseIndex = 0;
    this.m_playerHouseLevel = (sbyte) 0;
    this.m_playerHouseObjectXs = (sbyte[]) null;
    this.m_playerHouseObjectZs = (sbyte[]) null;
    this.m_playerHouseObjectTypes = (short[]) null;
    this.m_playerHouseObjectFacingDirs = (sbyte[]) null;
    this.m_playerHouseWallTypes = (sbyte[]) null;
    this.m_playerHouseFloorTypes = (sbyte[]) null;
    this.m_viewportX = 0;
    this.m_viewportY = 0;
    this.m_viewportWidth = 0;
    this.m_viewportHeight = 0;
    this.m_attribWidth = 0;
    this.m_attribHeight = 0;
    this.m_attribOffsetX = 0;
    this.m_attribOffsetZ = 0;
    this.m_attributesLayer = new short[0];
    this.m_houseRooms = new Room[0];
    this.m_houseRoomCorners = new Vector();
    this.m_floorMeshes = new Mesh[0];
    this.m_background = (Background) null;
    this.m_world = (World) null;
    this.m_worldObjects = (Group) null;
    this.m_visuals = (Node) null;
    this.m_additiveVisuals = (Node) null;
    this.m_visualsAnimPlayer = new AnimPlayer3D(ae.getAnimationManager3D());
    this.m_dayNightTimer = 0;
    this.m_dayNightForce = false;
    this.m_dayNightTint = 0;
    this.m_dayNightSky = 0;
    this.m_dayNightLighting = false;
    this.m_camera = (Camera) null;
    this.m_cameraTransform = (Transform) null;
    this.m_cameraTransformPreRotate = (Transform) null;
    this.m_cameraTransformInv = (Transform) null;
    this.m_cameraPosX = 0.0f;
    this.m_cameraPosY = 0.0f;
    this.m_cameraPosZ = 0.0f;
    this.m_cameraCenterX = 0.0f;
    this.m_cameraCenterZ = 0.0f;
    this.m_cameraPitch = 0.0f;
    this.m_cameraYaw = 0.0f;
    this.m_cameraDolly = 0.0f;
    this.m_unlockedFloorIds = new short[0];
    this.m_unlockedFloorPackIds = (short[]) null;
    this.m_unlockedWallIds = new short[0];
    this.m_unlockedWallPackIds = (short[]) null;
    this.m_pathStartX = 0;
    this.m_pathStartY = 0;
    this.m_pathDestX = 0;
    this.m_pathDestY = 0;
    this.m_pathAvoidTiles = new int[0];
    this.m_pathNumAvoidTiles = 0;
    this.m_pathOffsetX = 0;
    this.m_pathOffsetY = 0;
    this.m_pathOpenList = (short[]) null;
    this.m_pathOpenCount = 0;
    this.m_pathClosedList = new short[0];
    this.m_pathClosedCount = 0;
    this.m_pathParentArray = new short[0][];
    this.m_pathFCost = new int[0][];
    this.m_pathGCost = new int[0][];
    this.m_pathHCost = new int[0][];
    this.m_pathList = new short[0];
    this.m_pathFlags = 0;
    this.pathInit();
  }

  public new void Dispose()
  {
    this.unload();
    this.m_camera = (Camera) null;
    this.m_cameraTransform = (Transform) null;
    this.m_cameraTransformPreRotate = (Transform) null;
    this.m_cameraTransformInv = (Transform) null;
  }

  private SceneGame getSceneGame()
  {
    return this.m_engine.getSceneGame();
  }

  public SimData getSimData()
  {
    return this.m_engine.getSimData();
  }

  public bool isLoaded()
  {
    return this.m_world != null;
  }

  public static short lookupSimsWorld(DataInputStream dis)
  {
    return GlobalConstants.SIMSDATA_SYMBOL_LOOKUPS[(int) dis.readShort()];
  }

  public void initWorld(DataInputStream dis)
  {
    int length1 = (int) dis.readShort();
    RecObject[] recObjectArray = new RecObject[length1];
    for (int index = 0; index < length1; ++index)
    {
      recObjectArray[index] = new RecObject();
      recObjectArray[index].readBuiltIn(dis, index);
    }
    int length2 = (int) dis.readByte();
    short[] numArray1 = new short[length2];
    short[] numArray2 = new short[length2];
    for (int index = 0; index < length2; ++index)
    {
      numArray1[index] = SimWorld.lookupSimsWorld(dis);
      numArray2[index] = SimWorld.lookupSimsWorld(dis);
    }
    int length3 = (int) dis.readByte();
    short[][] numArray3 = new short[length3][];
    for (int index1 = 0; index1 < length3; ++index1)
    {
      int length4 = (int) dis.readByte();
      short[] numArray4 = new short[length4];
      for (int index2 = 0; index2 < length4; ++index2)
        numArray4[index2] = SimWorld.lookupSimsWorld(dis);
      numArray3[index1] = numArray4;
    }
    int length5 = (int) dis.readByte();
    short[][] numArray5 = new short[length5][];
    int[][] numArray6 = new int[length5][];
    short[][][] numArray7 = new short[length5][][];
    for (int index1 = 0; index1 < length5; ++index1)
    {
      int length4 = (int) dis.readByte();
      short[] numArray4 = new short[length4];
      int[] numArray8 = new int[length4];
      short[][] numArray9 = new short[length4][];
      for (int index2 = 0; index2 < length4; ++index2)
      {
        numArray4[index2] = SimWorld.lookupSimsWorld(dis);
        numArray8[index2] = dis.readInt();
        int length6 = (int) dis.readByte();
        short[] numArray10 = new short[length6];
        for (int index3 = 0; index3 < length6; ++index3)
          numArray10[index3] = SimWorld.lookupSimsWorld(dis);
        numArray9[index2] = numArray10;
      }
      numArray5[index1] = numArray4;
      numArray6[index1] = numArray8;
      numArray7[index1] = numArray9;
    }
    int length7 = (int) dis.readByte();
    short[] numArray11 = new short[length7];
    short[] numArray12 = new short[length7];
    int[][] numArray13 = new int[length7][];
    for (int index1 = 0; index1 < length7; ++index1)
    {
      numArray11[index1] = SimWorld.lookupSimsWorld(dis);
      numArray12[index1] = SimWorld.lookupSimsWorld(dis);
      int[] numArray4 = new int[4];
      for (int index2 = 0; index2 < 4; ++index2)
        numArray4[index2] = (int) dis.readShort();
      numArray13[index1] = numArray4;
    }
    int length8 = (int) dis.readByte();
    short[] numArray14 = new short[length8];
    short[] numArray15 = new short[length8];
    int[][] numArray16 = new int[length8][];
    for (int index1 = 0; index1 < length8; ++index1)
    {
      numArray14[index1] = SimWorld.lookupSimsWorld(dis);
      numArray15[index1] = SimWorld.lookupSimsWorld(dis);
      int[] numArray4 = new int[4];
      for (int index2 = 0; index2 < 4; ++index2)
        numArray4[index2] = (int) dis.readShort();
      numArray16[index1] = numArray4;
    }
    int length9 = (int) dis.readByte();
    RecItem[] recItemArray = new RecItem[length9];
    for (int index = 0; index < length9; ++index)
    {
      recItemArray[index] = new RecItem();
      recItemArray[index].readBuiltIn(dis, index);
    }
    int length10 = (int) dis.readByte();
    sbyte[] numArray17 = new sbyte[length10];
    sbyte[] numArray18 = new sbyte[length10];
    short[][] numArray19 = new short[length10][];
    for (int index1 = 0; index1 < length10; ++index1)
    {
      numArray17[index1] = dis.readByte();
      numArray18[index1] = dis.readByte();
      int length4 = (int) dis.readByte();
      short[] numArray4 = new short[length4];
      for (int index2 = 0; index2 < length4; ++index2)
        numArray4[index2] = (short) dis.readByte();
      numArray19[index1] = numArray4;
    }
    this.d_objectRecordsBuiltIn = recObjectArray;
    this.d_categoryStrings = numArray1;
    this.d_categoryIcons = numArray2;
    this.d_appearanceAnim3Ds = numArray3;
    this.d_simAttribUserIds = numArray5;
    this.d_simAttribFlags = numArray6;
    this.d_simAttribTextureIds = numArray7;
    this.d_floorStringIds = numArray11;
    this.d_floorGroupStringIds = numArray12;
    this.d_floorTexCoords = numArray13;
    this.d_wallStringIds = numArray14;
    this.d_wallGroupStringIds = numArray15;
    this.d_wallTexCoords = numArray16;
    this.d_itemRecordsBuiltIn = recItemArray;
    this.d_recipeItems = numArray17;
    this.d_recipeReplenishes = numArray18;
    this.d_recipeIngredients = numArray19;
  }

  private static short lookupSimsHouses(DataInputStream dis)
  {
    return GlobalConstants.SIMSDATA_SYMBOL_LOOKUPS[(int) dis.readShort()];
  }

  public void initHouses(DataInputStream dis)
  {
    int length1 = (int) dis.readByte();
    short[] numArray1 = new short[length1];
    sbyte[][] numArray2 = new sbyte[length1][];
    sbyte[][] numArray3 = new sbyte[length1][];
    sbyte[][] numArray4 = new sbyte[length1][];
    sbyte[][] numArray5 = new sbyte[length1][];
    sbyte[][] numArray6 = new sbyte[length1][];
    sbyte[][] numArray7 = new sbyte[length1][];
    sbyte[][] numArray8 = new sbyte[length1][];
    sbyte[][] numArray9 = new sbyte[length1][];
    sbyte[][] numArray10 = new sbyte[length1][];
    short[][] numArray11 = new short[length1][];
    sbyte[][] numArray12 = new sbyte[length1][];
    sbyte[][] numArray13 = new sbyte[length1][];
    sbyte[][] numArray14 = new sbyte[length1][];
    short[][] numArray15 = new short[length1][];
    sbyte[][] numArray16 = new sbyte[length1][];
    sbyte[][] numArray17 = new sbyte[length1][];
    short[][] numArray18 = new short[length1][];
    sbyte[][] numArray19 = new sbyte[length1][];
    for (int index1 = 0; index1 < length1; ++index1)
    {
      numArray1[index1] = SimWorld.lookupSimsHouses(dis);
      int length2 = (int) dis.readByte();
      sbyte[] numArray20 = new sbyte[length2];
      sbyte[] numArray21 = new sbyte[length2];
      sbyte[] numArray22 = new sbyte[length2];
      sbyte[] numArray23 = new sbyte[length2];
      sbyte[] numArray24 = new sbyte[length2];
      sbyte[] numArray25 = new sbyte[length2];
      for (int index2 = 0; index2 < length2; ++index2)
      {
        numArray20[index2] = dis.readByte();
        numArray21[index2] = dis.readByte();
        numArray22[index2] = dis.readByte();
        numArray23[index2] = dis.readByte();
        numArray24[index2] = (sbyte) SimWorld.lookupSimsHouses(dis);
        numArray25[index2] = (sbyte) SimWorld.lookupSimsHouses(dis);
        ++numArray22[index2];
        ++numArray23[index2];
      }
      int length3 = (int) dis.readByte();
      sbyte[] numArray26 = new sbyte[length3];
      sbyte[] numArray27 = new sbyte[length3];
      sbyte[] numArray28 = new sbyte[length3];
      short[] numArray29 = new short[length3];
      for (int index2 = 0; index2 < length3; ++index2)
      {
        numArray26[index2] = dis.readByte();
        numArray27[index2] = dis.readByte();
        numArray28[index2] = dis.readByte();
        numArray29[index2] = SimWorld.lookupSimsHouses(dis);
      }
      int length4 = (int) dis.readByte();
      sbyte[] numArray30 = new sbyte[length4];
      sbyte[] numArray31 = new sbyte[length4];
      sbyte[] numArray32 = new sbyte[length4];
      short[] numArray33 = new short[length4];
      for (int index2 = 0; index2 < length4; ++index2)
      {
        numArray30[index2] = dis.readByte();
        numArray31[index2] = dis.readByte();
        numArray32[index2] = dis.readByte();
        numArray33[index2] = SimWorld.lookupSimsHouses(dis);
      }
      int length5 = (int) dis.readByte();
      sbyte[] numArray34 = new sbyte[length5];
      sbyte[] numArray35 = new sbyte[length5];
      short[] numArray36 = new short[length5];
      sbyte[] numArray37 = new sbyte[length5];
      for (int index2 = 0; index2 < length5; ++index2)
      {
        numArray34[index2] = dis.readByte();
        numArray35[index2] = dis.readByte();
        numArray36[index2] = SimWorld.lookupSimsHouses(dis);
        numArray37[index2] = (sbyte) SimWorld.lookupSimsHouses(dis);
      }
      numArray2[index1] = numArray20;
      numArray3[index1] = numArray21;
      numArray4[index1] = numArray22;
      numArray5[index1] = numArray23;
      numArray6[index1] = numArray24;
      numArray7[index1] = numArray25;
      numArray8[index1] = numArray26;
      numArray9[index1] = numArray27;
      numArray10[index1] = numArray28;
      numArray11[index1] = numArray29;
      numArray12[index1] = numArray30;
      numArray13[index1] = numArray31;
      numArray14[index1] = numArray32;
      numArray15[index1] = numArray33;
      numArray16[index1] = numArray34;
      numArray17[index1] = numArray35;
      numArray18[index1] = numArray36;
      numArray19[index1] = numArray37;
    }
    this.d_houseMacroObjects = numArray1;
    this.d_houseRoomXs = numArray2;
    this.d_houseRoomYs = numArray3;
    this.d_houseRoomWidths = numArray4;
    this.d_houseRoomHeights = numArray5;
    this.d_houseRoomFloors = numArray6;
    this.d_houseRoomWalls = numArray7;
    this.d_houseDoorXs = numArray8;
    this.d_houseDoorYs = numArray9;
    this.d_houseDoorWidths = numArray10;
    this.d_houseDoorTypes = numArray11;
    this.d_houseWindowXs = numArray12;
    this.d_houseWindowYs = numArray13;
    this.d_houseWindowWidths = numArray14;
    this.d_houseWindowTypes = numArray15;
    this.d_houseObjectXs = numArray16;
    this.d_houseObjectZs = numArray17;
    this.d_houseObjectTypes = numArray18;
    this.d_houseObjectFacingDirs = numArray19;
    for (int index1 = 0; index1 < SimWorld.PLAYER_HOUSE_LIST.Length; ++index1)
    {
      int playerHouse = SimWorld.PLAYER_HOUSE_LIST[index1];
      int length2 = this.d_houseRoomWalls[playerHouse].Length;
      for (int index2 = 0; index2 < length2; ++index2)
      {
        this.unlockFloor((int) this.d_houseRoomFloors[playerHouse][index2]);
        this.unlockWall((int) this.d_houseRoomWalls[playerHouse][index2]);
      }
    }
  }

  public int getHouseId()
  {
    return SimWorld.isHousePlayers(this.m_houseIndex) ? 0 : this.m_houseIndex;
  }

  private static bool isHousePlayers(int houseId)
  {
    return AppEngine.indexOf(houseId, SimWorld.PLAYER_HOUSE_LIST) != -1;
  }

  public int getHouseMacroObject(int houseIndex)
  {
    return (int) this.d_houseMacroObjects[houseIndex];
  }

  public int getHouseForObject(int @object)
  {
    return AppEngine.indexOf((short) @object, this.d_houseMacroObjects);
  }

  public int getLocationTownmapSceneId()
  {
    return 177;
  }

  public int getLocationTownmapTextureId()
  {
    return 290;
  }

  public int getLocationTownmapScrollingTextureId()
  {
    return -1;
  }

  public int getLocationTownmapCloudTextureId()
  {
    return -1;
  }

  public void initPlayerHouse()
  {
    this.m_playerHouseLevel = (sbyte) 0;
    if (this.m_playerHouseObjectXs == null)
    {
      this.m_playerHouseObjectXs = new sbyte[150];
      this.m_playerHouseObjectZs = new sbyte[150];
      this.m_playerHouseObjectTypes = new short[150];
      this.m_playerHouseObjectFacingDirs = new sbyte[150];
    }
    AppEngine.fillArray(this.m_playerHouseObjectTypes, (short) -1);
    sbyte[] dHouseObjectX = this.d_houseObjectXs[0];
    sbyte[] dHouseObjectZ = this.d_houseObjectZs[0];
    short[] dHouseObjectType = this.d_houseObjectTypes[0];
    sbyte[] houseObjectFacingDir = this.d_houseObjectFacingDirs[0];
    midp.JSystem.arraycopy((Array) dHouseObjectX, 0, (Array) this.m_playerHouseObjectXs, 0, dHouseObjectX.Length);
    midp.JSystem.arraycopy((Array) dHouseObjectZ, 0, (Array) this.m_playerHouseObjectZs, 0, dHouseObjectZ.Length);
    midp.JSystem.arraycopy((Array) dHouseObjectType, 0, (Array) this.m_playerHouseObjectTypes, 0, dHouseObjectType.Length);
    midp.JSystem.arraycopy((Array) houseObjectFacingDir, 0, (Array) this.m_playerHouseObjectFacingDirs, 0, houseObjectFacingDir.Length);
    sbyte[] dHouseRoomWall = this.d_houseRoomWalls[0];
    sbyte[] dHouseRoomFloor = this.d_houseRoomFloors[0];
    this.m_playerHouseWallTypes = new sbyte[dHouseRoomWall.Length];
    this.m_playerHouseFloorTypes = new sbyte[dHouseRoomFloor.Length];
    midp.JSystem.arraycopy((Array) dHouseRoomWall, 0, (Array) this.m_playerHouseWallTypes, 0, dHouseRoomWall.Length);
    midp.JSystem.arraycopy((Array) dHouseRoomFloor, 0, (Array) this.m_playerHouseFloorTypes, 0, dHouseRoomFloor.Length);
  }

  public int getHouseUpgradeCost()
  {
    if ((int) this.m_playerHouseLevel == SimWorld.PLAYER_HOUSE_LIST.Length - 1)
      return -1;
    return this.m_playerHouseLevel == (sbyte) 0 ? (!this.getSimData().getAchievements(16) ? 0 : 1000) : (!this.getSimData().getAchievements(32) ? 0 : 2500);
  }

  public bool isBestHouse()
  {
    return (int) this.m_playerHouseLevel == SimWorld.PLAYER_HOUSE_LIST.Length - 1;
  }

  public int getHouseUpgradeLevel()
  {
    return (int) this.m_playerHouseLevel;
  }

  public bool gotBetterTV()
  {
    short[] houseObjectTypes = this.m_playerHouseObjectTypes;
    for (int index = houseObjectTypes.Length - 1; index >= 0; --index)
    {
      switch (houseObjectTypes[index])
      {
        case 130:
        case 131:
          return true;
        default:
          continue;
      }
    }
    return false;
  }

  public bool gotBetterCouch()
  {
    short[] houseObjectTypes = this.m_playerHouseObjectTypes;
    for (int index = houseObjectTypes.Length - 1; index >= 0; --index)
    {
      switch (houseObjectTypes[index])
      {
        case 109:
        case 110:
        case 111:
        case 112:
          return true;
        default:
          continue;
      }
    }
    return false;
  }

  public bool gotBestFurniture()
  {
    int num1 = 0;
    short[] houseObjectTypes = this.m_playerHouseObjectTypes;
    for (int index = houseObjectTypes.Length - 1; index >= 0; --index)
    {
      int type = (int) houseObjectTypes[index];
      if (type != -1 && (this.getObjectFlags(type) & 262144) != 0 && AppEngine.indexOf((short) type, houseObjectTypes, index + 1) == -1)
        ++num1;
    }
    int objectCountBuiltIn = this.getObjectCountBuiltIn();
    int num2 = 0;
    for (int type = 0; type < objectCountBuiltIn; ++type)
    {
      if ((this.getObjectFlags(type) & 262144) != 0)
        ++num2;
    }
    return num1 == num2;
  }

  public void upgradePlayerHouse()
  {
    AppEngine.ASSERT((int) this.m_playerHouseLevel < SimWorld.PLAYER_HOUSE_LIST.Length - 1, "invalid house upgrade");
    ++this.m_playerHouseLevel;
    int playerHouse1 = SimWorld.PLAYER_HOUSE_LIST[(int) this.m_playerHouseLevel];
    sbyte[] dHouseObjectX = this.d_houseObjectXs[playerHouse1];
    sbyte[] dHouseObjectZ = this.d_houseObjectZs[playerHouse1];
    short[] dHouseObjectType = this.d_houseObjectTypes[playerHouse1];
    sbyte[] houseObjectFacingDir = this.d_houseObjectFacingDirs[playerHouse1];
    short[] houseObjectTypes = this.m_playerHouseObjectTypes;
    sbyte[] playerHouseObjectXs = this.m_playerHouseObjectXs;
    sbyte[] playerHouseObjectZs = this.m_playerHouseObjectZs;
    sbyte[] objectFacingDirs = this.m_playerHouseObjectFacingDirs;
    for (int index = 0; index < houseObjectTypes.Length; ++index)
    {
      int type = (int) houseObjectTypes[index];
      if (type != -1)
      {
        int num = this.getObjectFlags(type) & 2097152;
      }
    }
    for (int oldIdx = 0; oldIdx < dHouseObjectType.Length; ++oldIdx)
    {
      short num1 = dHouseObjectType[oldIdx];
      sbyte num2 = dHouseObjectX[oldIdx];
      sbyte num3 = dHouseObjectZ[oldIdx];
      if (num1 == (short) 24 && houseObjectTypes[oldIdx] != (short) -1 && this.getObjectParent((int) houseObjectTypes[oldIdx]) == 23)
        num1 = houseObjectTypes[oldIdx];
      if ((int) num1 == (int) houseObjectTypes[oldIdx])
      {
        if ((this.getObjectFlags((int) num1) & 8) == 0)
          ;
      }
      else if (houseObjectTypes[oldIdx] != (short) -1)
      {
        int newIdx = AppEngine.indexOf((short) -1, houseObjectTypes);
        AppEngine.ASSERT(newIdx != -1, "no slots left in house records");
        houseObjectTypes[newIdx] = houseObjectTypes[oldIdx];
        playerHouseObjectXs[newIdx] = playerHouseObjectXs[oldIdx];
        playerHouseObjectZs[newIdx] = playerHouseObjectZs[oldIdx];
        objectFacingDirs[newIdx] = objectFacingDirs[oldIdx];
        this.getSimData().moveObject(oldIdx, newIdx);
      }
      houseObjectTypes[oldIdx] = num1;
      playerHouseObjectXs[oldIdx] = num2;
      playerHouseObjectZs[oldIdx] = num3;
      objectFacingDirs[oldIdx] = houseObjectFacingDir[oldIdx];
    }
    int playerHouse2 = SimWorld.PLAYER_HOUSE_LIST[(int) this.m_playerHouseLevel];
    sbyte[] dHouseRoomWall = this.d_houseRoomWalls[playerHouse2];
    sbyte[] dHouseRoomFloor = this.d_houseRoomFloors[playerHouse2];
    sbyte[] numArray1 = new sbyte[dHouseRoomWall.Length];
    sbyte[] numArray2 = new sbyte[dHouseRoomFloor.Length];
    midp.JSystem.arraycopy((Array) dHouseRoomWall, 0, (Array) numArray1, 0, dHouseRoomWall.Length);
    midp.JSystem.arraycopy((Array) dHouseRoomFloor, 0, (Array) numArray2, 0, dHouseRoomFloor.Length);
    midp.JSystem.arraycopy((Array) this.m_playerHouseWallTypes, 0, (Array) numArray1, 0, this.m_playerHouseWallTypes.Length);
    midp.JSystem.arraycopy((Array) this.m_playerHouseFloorTypes, 0, (Array) numArray2, 0, this.m_playerHouseFloorTypes.Length);
    this.m_playerHouseWallTypes = numArray1;
    this.m_playerHouseFloorTypes = numArray2;
    this.getSimData().upgradePlayerHouse();
  }

  public void changeFloor(int roomId, int floorType, bool save)
  {
    if (save)
    {
      this.m_playerHouseFloorTypes[roomId] = (sbyte) floorType;
      SpywareManager.getInstance().trackBuyFloor(floorType);
    }
    this.getRoom(roomId).setFloorType(floorType);
  }

  public void changeWall(int roomId, int wallType, bool save)
  {
    if (save)
    {
      this.m_playerHouseWallTypes[roomId] = (sbyte) wallType;
      SpywareManager.getInstance().trackBuyWall(wallType);
    }
    this.getRoom(roomId).setWallType(wallType);
  }

  public int objectBuy(int type, int x, int z, int facingDir)
  {
    AppEngine.ASSERT(this.getHouseId() == 0, "buying at non-home house");
    int index = AppEngine.indexOf((short) -1, this.m_playerHouseObjectTypes);
    AppEngine.ASSERT(index != -1, "out of house object slots");
    this.m_playerHouseObjectTypes[index] = (short) type;
    this.m_playerHouseObjectXs[index] = (sbyte) this.coordWorldToWorldTileX(x);
    this.m_playerHouseObjectZs[index] = (sbyte) this.coordWorldToWorldTileZ(z);
    this.m_playerHouseObjectFacingDirs[index] = (sbyte) facingDir;
    SpywareManager.getInstance().trackBuyObject(type);
    return index;
  }

  public void objectSell(int id)
  {
    AppEngine.ASSERT(this.getHouseId() == 0, "selling at non-home house");
    this.m_playerHouseObjectTypes[id] = (short) -1;
    this.getSimData().removeObjectValue(0, id);
  }

  public void objectRotate(int id, int facingDir)
  {
    AppEngine.ASSERT(this.getHouseId() == 0, "rotating at non-home house");
    this.m_playerHouseObjectFacingDirs[id] = (sbyte) facingDir;
  }

  public void objectChange(int id, int newType)
  {
    AppEngine.ASSERT(this.getHouseId() == 0, "changing at non-home house");
    this.m_playerHouseObjectTypes[id] = (short) newType;
  }

  public void objectChange(int id, int newX, int newZ, int newFacingDir)
  {
    AppEngine.ASSERT(this.getHouseId() == 0, "changing at non-home house");
    this.m_playerHouseObjectXs[id] = (sbyte) this.coordWorldToWorldTileX(newX);
    this.m_playerHouseObjectZs[id] = (sbyte) this.coordWorldToWorldTileZ(newZ);
    this.m_playerHouseObjectFacingDirs[id] = (sbyte) newFacingDir;
  }

  public bool playerOwnsParentType(int parentType)
  {
    foreach (int playerHouseObjectType in this.m_playerHouseObjectTypes)
    {
      if (playerHouseObjectType != -1 && this.getObjectParent(playerHouseObjectType) == parentType)
        return true;
    }
    return false;
  }

  public bool playerOwnsObject(int type)
  {
    return AppEngine.indexOf((short) type, this.m_playerHouseObjectTypes) != -1;
  }

  public int getWindowNthTypeCount(int size)
  {
    int num = 0;
    int objectCount = this.getObjectCount();
    for (int type = 0; type < objectCount; ++type)
    {
      if (this.getObjectParent(type) == 32 && this.getObjectFootprintHeight(type) == size)
        ++num;
    }
    return num;
  }

  public int getWindowNthType(int index, int size)
  {
    int num = 0;
    int objectCount = this.getObjectCount();
    for (int type = 0; type < objectCount; ++type)
    {
      if (this.getObjectParent(type) == 32 && this.getObjectFootprintHeight(type) == size)
      {
        if (num == index)
          return type;
        ++num;
      }
    }
    return -1;
  }

  public int getDoorNthTypeCount()
  {
    int num = 0;
    int objectCount = this.getObjectCount();
    for (int type = 0; type < objectCount; ++type)
    {
      if (this.getObjectParent(type) == 15)
        ++num;
    }
    return num;
  }

  public int getDoorNthType(int index)
  {
    int num = 0;
    int objectCount = this.getObjectCount();
    for (int type = 0; type < objectCount; ++type)
    {
      if (this.getObjectParent(type) == 15)
      {
        if (num == index)
          return type;
        ++num;
      }
    }
    return -1;
  }

  public void resetRMSGameData()
  {
    this.m_playerHouseLevel = (sbyte) 0;
    this.initPlayerHouse();
  }

  public void loadRMSGameDataLegacy(DataInputStream @in)
  {
    this.m_playerHouseLevel = @in.readByte();
    for (int index = 0; index < this.m_playerHouseObjectTypes.Length; ++index)
    {
      this.m_playerHouseObjectTypes[index] = @in.readShort();
      this.m_playerHouseObjectXs[index] = @in.readByte();
      this.m_playerHouseObjectZs[index] = @in.readByte();
      this.m_playerHouseObjectFacingDirs[index] = @in.readByte();
    }
    int playerHouse = SimWorld.PLAYER_HOUSE_LIST[(int) this.m_playerHouseLevel];
    sbyte[] dHouseRoomWall = this.d_houseRoomWalls[playerHouse];
    sbyte[] dHouseRoomFloor = this.d_houseRoomFloors[playerHouse];
    this.m_playerHouseWallTypes = new sbyte[dHouseRoomWall.Length];
    this.m_playerHouseFloorTypes = new sbyte[dHouseRoomFloor.Length];
    midp.JSystem.arraycopy((Array) dHouseRoomWall, 0, (Array) this.m_playerHouseWallTypes, 0, dHouseRoomWall.Length);
    midp.JSystem.arraycopy((Array) dHouseRoomFloor, 0, (Array) this.m_playerHouseFloorTypes, 0, dHouseRoomFloor.Length);
  }

  public void loadRMSGameData(DataInputStream @in)
  {
    this.m_playerHouseLevel = @in.readByte();
    for (int index = 0; index < this.m_playerHouseObjectTypes.Length; ++index)
    {
      this.m_playerHouseObjectTypes[index] = @in.readShort();
      this.m_playerHouseObjectXs[index] = @in.readByte();
      this.m_playerHouseObjectZs[index] = @in.readByte();
      this.m_playerHouseObjectFacingDirs[index] = @in.readByte();
    }
    int length = @in.readInt();
    this.m_playerHouseFloorTypes = new sbyte[length];
    this.m_playerHouseWallTypes = new sbyte[length];
    for (int index = 0; index < length; ++index)
    {
      this.m_playerHouseFloorTypes[index] = @in.readByte();
      this.m_playerHouseWallTypes[index] = @in.readByte();
    }
  }

  public void saveRMSGameData(DataOutputStream @out)
  {
    @out.writeByte((int) this.m_playerHouseLevel);
    for (int index = 0; index < this.m_playerHouseObjectTypes.Length; ++index)
    {
      @out.writeShort((int) this.m_playerHouseObjectTypes[index]);
      @out.writeByte((int) this.m_playerHouseObjectXs[index]);
      @out.writeByte((int) this.m_playerHouseObjectZs[index]);
      @out.writeByte((int) this.m_playerHouseObjectFacingDirs[index]);
    }
    int length = this.m_playerHouseFloorTypes.Length;
    @out.writeInt(length);
    for (int index = 0; index < length; ++index)
    {
      @out.writeByte((int) this.m_playerHouseFloorTypes[index]);
      @out.writeByte((int) this.m_playerHouseWallTypes[index]);
    }
  }

  public void setViewport(int x, int y, int width, int height)
  {
    this.m_viewportX = x;
    this.m_viewportY = y;
    this.m_viewportWidth = width;
    this.m_viewportHeight = height;
  }

  public int getViewportX()
  {
    return this.m_viewportX;
  }

  public int getViewportY()
  {
    return this.m_viewportY;
  }

  public int getViewportWidth()
  {
    return this.m_viewportWidth;
  }

  public int getViewportHeight()
  {
    return this.m_viewportHeight;
  }

  private void prepareWorld()
  {
    this.m_attribOffsetX = this.m_attribWidth >> 1;
    this.m_attribOffsetZ = this.m_attribHeight >> 1;
    if (this.m_attributesLayer == null || this.m_attribWidth * this.m_attribHeight != this.m_attributesLayer.Length)
      this.m_attributesLayer = new short[this.m_attribWidth * this.m_attribHeight];
    AppEngine.fillArray(this.m_attributesLayer, (short) 0);
    if (this.m_camera == null)
    {
      Camera camera = new Camera();
      float aspectRatio = (float) this.m_viewportHeight / (float) this.m_viewportWidth;
      camera.setPerspective(38f, aspectRatio, 32f, 2600f);
      this.m_camera = camera;
      this.m_cameraTransform = new Transform();
      this.m_cameraTransformPreRotate = new Transform();
      this.m_cameraTransformInv = new Transform();
    }
    Background background = new Background();
    background.setColor(9222898);
    background.setColorClearEnable(true);
    background.setDepthClearEnable(true);
    this.m_background = background;
    World world = new World();
    world.setBackground(background);
    world.addChild((Node) this.m_camera);
    world.setActiveCamera(this.m_camera);
    this.m_world = world;
    this.m_worldObjects = new Group();
    this.m_world.addChild((Node) this.m_worldObjects);
  }

  private void createObjectsHouse(int houseId)
  {
    AppEngine.timerBegin();
    SceneGame sceneGame = this.getSceneGame();
    sbyte[] numArray1 = this.d_houseObjectXs[houseId];
    sbyte[] numArray2 = this.d_houseObjectZs[houseId];
    short[] anArray = this.d_houseObjectTypes[houseId];
    sbyte[] numArray3 = this.d_houseObjectFacingDirs[houseId];
    if (this.getHouseId() == 0)
    {
      numArray1 = this.m_playerHouseObjectXs;
      numArray2 = this.m_playerHouseObjectZs;
      anArray = this.m_playerHouseObjectTypes;
      numArray3 = this.m_playerHouseObjectFacingDirs;
    }
    bool flag = false;
    int num1 = 0;
    int num2 = 0;
    int length = anArray.Length;
    for (int id = 0; id < length; ++id)
    {
      int type = (int) anArray[id];
      if (type != -1 && (this.getObjectFlags(type) & 1048576) == 0)
      {
        int roomTileX = (int) numArray1[id];
        int yF = 0;
        int roomTileZ = (int) numArray2[id];
        int facingDir = (int) numArray3[id];
        if (this.getHouseId() == 0 && type == 103 && (roomTileX == 8 && roomTileZ == 8))
          roomTileZ = 2;
        sceneGame.createObjectOnWorldTile(type, roomTileX, yF, roomTileZ, facingDir, id);
        if (!flag && this.getObjectParent(type) == 23)
        {
          flag = true;
          num1 = roomTileX;
          num2 = roomTileZ;
        }
      }
    }
    for (int id = 0; id < length; ++id)
    {
      int type = (int) anArray[id];
      if (type != -1 && (this.getObjectFlags(type) & 1048576) != 0)
      {
        int num3 = (int) numArray1[id];
        int num4 = (int) numArray2[id];
        int facingDir = (int) numArray3[id];
        int benchtopHeightAt = this.getBenchtopHeightAt(num3, num4);
        sceneGame.createObjectOnWorldTile(type, num3, benchtopHeightAt, num4, facingDir, id);
      }
    }
    if (flag)
    {
      int num3 = this.m_playerHouseLevel == (sbyte) 1 ? 1 : 0;
      int x = num1 + 1;
      int z = num2 + num3;
      int worldCenterX = this.coordWorldTileToWorldCenterX(x);
      int worldCenterZ = this.coordWorldTileToWorldCenterZ(z);
      int type = this.m_playerHouseLevel == (sbyte) 1 ? 30 : 31;
      sceneGame.createObject(type, worldCenterX, 65536, worldCenterZ, 1, -1);
    }
    int num5 = 3;
    if (this.getHouseId() == 0)
      num5 = 2;
    int index1 = AppEngine.indexOf((short) num5, anArray);
    AppEngine.ASSERT(index1 >= 0, "no player start");
    int roomTileX1 = (int) numArray1[index1];
    int roomTileZ1 = (int) numArray2[index1];
    int facingDir1 = (int) numArray3[index1];
    sceneGame.createObjectOnWorldTile(0, roomTileX1, 0, roomTileZ1, facingDir1, 0);
    int index2 = num5 == 2 ? index1 : -1;
    SimData simData = this.getSimData();
    int simCount = simData.getSimCount();
    for (int index3 = 1; index3 < simCount; ++index3)
    {
      if (simData.getSimHome(index3) == houseId)
      {
        int timeFlags = simData.getTimeFlags(index3);
        if ((timeFlags & 8) != 0)
        {
          index2 = AppEngine.indexOf((short) 2, anArray, index2 + 1);
          AppEngine.ASSERT(index2 >= 0, "no NPC start");
          int roomTileX2 = (int) numArray1[index2];
          int yF = 0;
          int roomTileZ2 = (int) numArray2[index2];
          int type = 1;
          int facingDir2 = (int) numArray3[index2];
          MapObjectSim objectOnWorldTile = (MapObjectSim) sceneGame.createObjectOnWorldTile(type, roomTileX2, yF, roomTileZ2, facingDir2, index3);
          if ((timeFlags & 16) != 0 && this.m_engine.randPercent() < 60)
            sceneGame.putSimInBed(objectOnWorldTile);
        }
      }
    }
    AppEngine.timerEnd(nameof (createObjectsHouse));
  }

  public bool isBenchTopObjectAt(int tileX, int tileZ)
  {
    int houseId = this.getHouseId();
    sbyte[] numArray1 = this.d_houseObjectXs[houseId];
    sbyte[] numArray2 = this.d_houseObjectZs[houseId];
    short[] numArray3 = this.d_houseObjectTypes[houseId];
    if (houseId == 0)
    {
      numArray1 = this.m_playerHouseObjectXs;
      numArray2 = this.m_playerHouseObjectZs;
      numArray3 = this.m_playerHouseObjectTypes;
    }
    for (int index = 0; index < numArray3.Length; ++index)
    {
      int type = (int) numArray3[index];
      if (type != -1 && (this.getObjectFlags(type) & 1048576) != 0 && (tileX == (int) numArray1[index] && tileZ == (int) numArray2[index]))
        return true;
    }
    return false;
  }

  public int getBenchtopHeightAt(int tileX, int tileZ)
  {
    SceneGame sceneGame = this.getSceneGame();
    int[] tempInt4 = this.m_tempInt4;
    MapObject benchtopSupplyObjectAt = sceneGame.findBenchtopSupplyObjectAt(tileX, tileZ);
    if (benchtopSupplyObjectAt != null)
    {
      int benchtopCount = benchtopSupplyObjectAt.getBenchtopCount();
      for (int index = 0; index < benchtopCount; ++index)
      {
        benchtopSupplyObjectAt.getBenchtop(tempInt4, index);
        int worldTileX = this.coordWorldToWorldTileX(tempInt4[0]);
        int worldTileZ = this.coordWorldToWorldTileZ(tempInt4[2]);
        if (worldTileX == tileX && worldTileZ == tileZ)
          return tempInt4[1];
      }
    }
    return 0;
  }

  public int getFirstFacing(int rotFlags)
  {
    for (int index = 0; index < 4; ++index)
    {
      if ((rotFlags & SimWorld.ROTATION_FLAGS[index]) != 0)
        return index;
    }
    return -1;
  }

  public bool isAgainstWall(
    int tileX,
    int tileZ,
    int objectWidth,
    int objectHeight,
    int facingDir)
  {
    bool flag = true;
    switch (facingDir)
    {
      case 0:
      case 2:
        int num1 = 1;
        int num2 = 256;
        if (facingDir == 2)
        {
          num1 = -1;
          num2 = 512;
        }
        int tileX1 = tileX - objectWidth * num1;
        int num3 = tileZ;
        for (int index = 0; index < objectHeight && flag; ++index)
          flag = (this.getAttribute(tileX1, num3 - index * num1) & num2) != 0;
        break;
      case 1:
      case 3:
        int num4 = 1;
        int num5 = 1024;
        if (facingDir == 3)
        {
          num4 = -1;
          num5 = 2048;
        }
        int num6 = tileX;
        int tileZ1 = tileZ - objectWidth * num4;
        for (int index = 0; index < objectHeight && flag; ++index)
          flag = (this.getAttribute(num6 - index * num4, tileZ1) & num5) != 0;
        break;
    }
    return flag;
  }

  private bool checkWallOnSide(int tileX, int tileZ, int sizeX, int sizeZ, int wallDir)
  {
    bool flag = false;
    switch (wallDir)
    {
      case 0:
        flag = (this.getAttribute(tileX - sizeX + 1, tileZ) & 512) != 0;
        break;
      case 1:
        flag = (this.getAttribute(tileX, tileZ - sizeZ + 1) & 2048) != 0;
        break;
      case 2:
        flag = (this.getAttribute(tileX, tileZ) & 256) != 0;
        break;
      case 3:
        flag = (this.getAttribute(tileX, tileZ) & 1024) != 0;
        break;
    }
    return flag;
  }

  public void getWallStatus(
    int tileX,
    int tileZ,
    int objectWidth,
    int objectHeight,
    int facingDir,
    ref bool[] outResult)
  {
    for (int index = 0; index < 4; ++index)
      outResult[index] = this.checkWallOnSide(tileX, tileZ, objectWidth, objectHeight, (facingDir + index) % 4);
  }

  public int getObjectValidRotations(int type, int tileX, int tileZ)
  {
    int objectFlags = this.getObjectFlags(type);
    int objectFootprintWidth = this.getObjectFootprintWidth(type);
    int objectFootprintHeight = this.getObjectFootprintHeight(type);
    int num1 = 0;
    MapObjectSim[] simObjects = this.getSceneGame().getSimObjects();
    for (int facingDir = 0; facingDir < SimWorld.ROTATION_FLAGS.Length; ++facingDir)
    {
      int num2 = SimWorld.ROTATION_FLAGS[facingDir];
      int width = objectFootprintWidth;
      int height = objectFootprintHeight;
      if (facingDir == 1 || facingDir == 3)
      {
        width = objectFootprintHeight;
        height = objectFootprintWidth;
      }
      if (((objectFlags & 1048576) != 0 || this.checkFootprintOK(tileX, tileZ, width, height)) && ((objectFlags & 2097152) == 0 || this.isAgainstWall(tileX, tileZ, objectFootprintWidth, objectFootprintHeight, facingDir)))
      {
        if ((objectFlags & 4194304) != 0 && this.isAgainstWall(tileX, tileZ, objectFootprintWidth, objectFootprintHeight, facingDir))
          return 0;
        bool flag = true;
        for (int index = 0; index < simObjects.Length && flag; ++index)
        {
          if (simObjects[index].isWithinTiles(tileX, tileZ, width, height))
            flag = false;
        }
        if (flag)
          num1 |= num2;
      }
    }
    return num1;
  }

  public int createBuildPoints(int newType)
  {
    SceneGame sceneGame = this.getSceneGame();
    int objectFlags = this.getObjectFlags(newType);
    int objectFootprintWidth = this.getObjectFootprintWidth(newType);
    int objectFootprintHeight = this.getObjectFootprintHeight(newType);
    int num1 = 0;
    if ((objectFlags & 1048576) != 0)
    {
      foreach (MapObject mapObject in sceneGame.getObjects())
      {
        if (mapObject.getFlag(524288))
        {
          int[] tempInt4 = this.m_tempInt4;
          int benchtopCount = mapObject.getBenchtopCount();
          for (int index = 0; index < benchtopCount; ++index)
          {
            mapObject.getBenchtop(tempInt4, index);
            int worldTileX1 = this.coordWorldToWorldTileX(tempInt4[0]);
            int yF = tempInt4[1];
            int worldTileX2 = this.coordWorldToWorldTileX(tempInt4[2]);
            if (!this.isBenchTopObjectAt(worldTileX1, worldTileX2))
            {
              int firstFacing = this.getFirstFacing(this.getObjectValidRotations(newType, worldTileX1, worldTileX2));
              if (firstFacing != -1)
              {
                sceneGame.createObjectOnWorldTile(14, worldTileX1, yF, worldTileX2, firstFacing, -1);
                ++num1;
              }
            }
          }
        }
      }
    }
    else
    {
      int playerHouse = SimWorld.PLAYER_HOUSE_LIST[(int) this.m_playerHouseLevel];
      sbyte[] dHouseRoomX = this.d_houseRoomXs[playerHouse];
      sbyte[] dHouseRoomY = this.d_houseRoomYs[playerHouse];
      sbyte[] dHouseRoomWidth = this.d_houseRoomWidths[playerHouse];
      sbyte[] dHouseRoomHeight = this.d_houseRoomHeights[playerHouse];
      int length = dHouseRoomX.Length;
      if ((objectFootprintWidth != 1 || objectFootprintHeight != 1) && (objectFootprintWidth != 1 || objectFootprintHeight != 2) && ((objectFootprintWidth != 1 || objectFootprintHeight != 3) && (objectFootprintWidth != 2 || objectFootprintHeight != 1)) && ((objectFootprintWidth != 2 || objectFootprintHeight != 2) && (objectFootprintWidth != 3 || objectFootprintHeight != 1) && objectFootprintWidth == 3))
        ;
      for (int index1 = 0; index1 < length; ++index1)
      {
        int num2 = (int) dHouseRoomX[index1];
        int num3 = num2 + (int) dHouseRoomWidth[index1];
        int num4 = (int) dHouseRoomY[index1];
        int num5 = num4 + (int) dHouseRoomHeight[index1];
        int yF = 0;
        for (int index2 = num4; index2 < num5; ++index2)
        {
          for (int index3 = num2; index3 < num3; ++index3)
          {
            int firstFacing = this.getFirstFacing(this.getObjectValidRotations(newType, index3, index2));
            if (firstFacing != -1)
            {
              sceneGame.createObjectOnWorldTile(14, index3, yF, index2, firstFacing, -1);
              ++num1;
            }
          }
        }
      }
    }
    if (num1 > 0)
    {
      foreach (MapObject mapObject in sceneGame.getObjects())
      {
        if (mapObject.getType() == 14)
        {
          int worldTileX = this.coordWorldToWorldTileX(mapObject.getPosX());
          int worldTileZ = this.coordWorldToWorldTileZ(mapObject.getPosZ());
          int objectValidRotations = this.getObjectValidRotations(newType, worldTileX, worldTileZ);
          mapObject.createDummies(objectFootprintWidth, objectFootprintHeight, objectValidRotations);
        }
      }
    }
    return num1;
  }

  public void prepareWorldMacromap(bool atWork, bool atAirport)
  {
    this.m_attribWidth = 192;
    this.m_attribHeight = 192;
    this.prepareWorld();
    AppEngine engine = this.m_engine;
    SceneGame sceneGame = this.getSceneGame();
    Node target = AppEngine.getResourceManager().loadM3GNode(this.getLocationTownmapSceneId());
    this.m_visuals = (Node) target.find(5002);
    this.m_additiveVisuals = (Node) this.m_visuals.find(5003);
    ModelManager.getInstance().applyAppearances(this.m_visuals);
    ModelManager.applyCommit(this.m_visuals);
    this.m_world.addChild(this.m_visuals);
    if ((Node) this.m_visuals.find(5004) != null)
    {
      this.m_visualsAnimPlayer.setNode(this.m_visuals);
      this.m_visualsAnimPlayer.startAnim(216, 20);
    }
    int[] vector = new int[4];
    Transform transform = new Transform();
    int objectCountBuiltIn = this.getObjectCountBuiltIn();
    for (int type = 0; type < objectCountBuiltIn; ++type)
    {
      if ((this.getObjectFlags(type) & 64) != 0)
      {
        int objectModelId = this.getObjectModelId(type);
        Node node = (Node) target.find(objectModelId);
        if (node != null)
        {
          node.getTransformTo(target, ref transform);
          vector[0] = vector[1] = vector[2] = 0;
          vector[3] = 65536;
          transform.transformx(ref vector);
          sceneGame.createObject(type, vector[0], vector[1], vector[2], 1, -1).initMacromapObject(node);
        }
      }
    }
    AppEngine.fillArray(this.m_attributesLayer, (short) 3840);
    this.paintAttributes((Node) target.find(5000), -3841, 0);
    this.paintAttributes((Node) target.find(5001), 0, 64);
    this.calculateSidewalk();
    if (atWork)
    {
      SimData simData = this.getSimData();
      int careerRabbitHole = simData.getCareerRabbitHole(simData.getSimCareer(0));
      MapObject randomObjectByType = sceneGame.findRandomObjectByType(careerRabbitHole);
      AppEngine.ASSERT(randomObjectByType != null, "couldn't find workplace");
      sceneGame.createObjectOnObjectInterestPoint(0, randomObjectByType, 0);
      sceneGame.startPlayerAction(170, randomObjectByType, 0, 0);
    }
    else
    {
      int nextHouseId = engine.getNextHouseId();
      if (nextHouseId != -1)
      {
        this.m_houseIndex = 13;
        int houseMacroObject = this.getHouseMacroObject(nextHouseId);
        MapObject randomObjectByType = sceneGame.findRandomObjectByType(houseMacroObject);
        sceneGame.createObjectOnObjectInterestPoint(0, randomObjectByType, 0);
      }
      else
      {
        sceneGame.createObject(0, engine.getEncounterPlayerX(), 0, engine.getEncounterPlayerZ(), 0, 0);
        int encounterNpcId = engine.getEncounterNPCId();
        if (encounterNpcId != -1)
          sceneGame.createObject(1, engine.getEncounterNPCX(), 0, engine.getEncounterNPCZ(), 0, encounterNpcId);
        engine.setupEncounter((MapObjectSim) null);
      }
    }
    ModelManager.getInstance().setFogRange(1500f, 2500f);
    this.calcDayNightTint();
    this.applyDayNightTint();
  }

  public void prepareWorldZoomMap(int tileMapId)
  {
    this.m_attribWidth = 256;
    this.m_attribHeight = 256;
    this.prepareWorld();
    AppEngine engine = this.m_engine;
    SceneGame sceneGame = this.getSceneGame();
    Node target = AppEngine.getResourceManager().loadM3GNode(engine.getNextZoomMapId());
    this.m_visuals = (Node) target.find(5002);
    this.m_additiveVisuals = (Node) this.m_visuals.find(5003);
    ModelManager.getInstance().applyAppearances(this.m_visuals);
    ModelManager.applyCommit(this.m_visuals);
    this.m_world.addChild(this.m_visuals);
    int[] numArray = new int[24]
    {
      6200,
      9,
      6201,
      9,
      6202,
      7,
      6203,
      7,
      6211,
      2,
      6221,
      3,
      6222,
      3,
      6223,
      3,
      6231,
      4,
      6232,
      4,
      6233,
      4,
      6234,
      4
    };
    int[] vector1 = new int[4];
    int[] vector2 = new int[4];
    Transform transform = new Transform();
    for (int index = 0; index < numArray.Length; index += 2)
    {
      int userID = numArray[index];
      int type = numArray[index + 1];
      Node node = (Node) target.find(userID);
      if (node != null)
      {
        node.getTransformTo(target, ref transform);
        vector1[0] = vector1[1] = vector1[2] = 0;
        vector1[3] = 65536;
        transform.transformx(ref vector1);
        int facing = 1;
        if (type == 4)
        {
          vector2[1] = vector2[2] = 0;
          vector2[0] = vector2[3] = 65536;
          transform.transformx(ref vector2);
          facing = MapObject.getFacingDir(vector2[0] - vector1[0], vector2[2] - vector1[2]);
        }
        sceneGame.createObject(type, vector1[0], vector1[1], vector1[2], facing, -1);
      }
    }
    AppEngine.fillArray(this.m_attributesLayer, (short) 3840);
    this.paintAttributes((Node) target.find(5000), -3841, 0);
    MapObject randomObjectByType = sceneGame.findRandomObjectByType(2);
    AppEngine.ASSERT(randomObjectByType != null, "no start point!");
    int worldTileX = this.coordWorldToWorldTileX(randomObjectByType.getPosX());
    int worldTileZ = this.coordWorldToWorldTileZ(randomObjectByType.getPosZ());
    sceneGame.createObjectOnWorldTile(0, worldTileX, 0, worldTileZ, 0, 0);
    int encounterNpcId = engine.getEncounterNPCId();
    if (encounterNpcId != -1)
    {
      MapObject objectOnWorldTile = sceneGame.createObjectOnWorldTile(1, worldTileX + 1, 0, worldTileZ, 2, encounterNpcId);
      sceneGame.setCursorObject(objectOnWorldTile);
      sceneGame.showContextMenu(objectOnWorldTile);
    }
    ModelManager.getInstance().setFogRange(800f, 1500f);
    this.calcDayNightTint();
    this.applyDayNightTint();
  }

  public void unload()
  {
    this.m_world = (World) null;
    this.m_worldObjects = (Group) null;
    this.m_background = (Background) null;
    this.m_visuals = (Node) null;
    this.m_additiveVisuals = (Node) null;
    this.m_visualsAnimPlayer.setNode((Node) null);
    this.m_floorMeshes = new Mesh[0];
    this.m_houseRooms = new Room[0];
    this.m_houseRoomCorners.removeAllElements();
  }

  public void renderWorld(Graphics g)
  {
    SceneGame sceneGame = this.getSceneGame();
    this.renderWorld3D(g);
    foreach (MapObject mapObject in sceneGame.getObjects())
    {
      if (mapObject.getFlag(32768))
        mapObject.render2D(g);
    }
  }

  public int coordWorldTileToWorldCenterX(int x)
  {
    return (x << 21) + 1048576;
  }

  public int coordWorldTileToWorldCenterZ(int z)
  {
    return (z << 21) + 1048576;
  }

  public int coordWorldToWorldTileX(int x)
  {
    return x >> 21;
  }

  public int coordWorldToWorldTileZ(int z)
  {
    return z >> 21;
  }

  public void coordWorldToScreen(int[] result, int worldX, int worldY, int worldZ)
  {
    this.m_camera.getProjection(this.tempTransform);
    this.tempTransform.postMultiply(ref this.m_cameraTransformInv);
    this.m_camera.getProjection(ref this.m_tempFloat4);
    float num1 = this.m_tempFloat4[2] + 27.01689f;
    float[] tempFloat4 = this.m_tempFloat4;
    tempFloat4[0] = (float) worldX * 1.525879E-05f;
    tempFloat4[1] = (float) worldY * 1.525879E-05f;
    tempFloat4[2] = (float) worldZ * 1.525879E-05f;
    tempFloat4[3] = 1f;
    this.tempTransform.transform(ref tempFloat4);
    float num2 = 1f / tempFloat4[3];
    float num3 = tempFloat4[0] * num2;
    float num4 = tempFloat4[1] * num2;
    float num5 = tempFloat4[2] + num1;
    float num6 = -num4;
    float num7 = -num3;
    float num8 = (float) (this.m_viewportX + (this.m_viewportWidth >> 1)) + (float) ((double) num6 * (double) this.m_viewportWidth * 0.5);
    float num9 = (float) (this.m_viewportY + (this.m_viewportHeight >> 1)) + (float) ((double) num7 * (double) this.m_viewportHeight * 0.5);
    result[0] = (int) num8;
    result[1] = (int) num9;
    result[2] = (int) ((double) num5 * 65536.0);
  }

  public bool coordScreenToWorldPlane(int[] resultF, int[] p0F, int[] pnF, int x, int y)
  {
    float[] vector1 = new float[4];
    float[] vector2 = new float[4];
    float[] numArray1 = new float[4];
    float[] numArray2 = new float[4];
    numArray1[0] = (float) p0F[0] / 65536f;
    numArray1[1] = (float) p0F[1] / 65536f;
    numArray1[2] = (float) p0F[2] / 65536f;
    numArray1[3] = 1f;
    numArray2[0] = (float) pnF[0] / 65536f;
    numArray2[1] = (float) pnF[1] / 65536f;
    numArray2[2] = (float) pnF[2] / 65536f;
    numArray2[3] = 1f;
    vector1[0] = 0.0f;
    vector1[1] = 0.0f;
    vector1[2] = 0.0f;
    vector1[3] = 1f;
    this.m_cameraTransformPreRotate.transform(ref vector1);
    float num1 = (float) (((double) x - 266.5) * (2.0 / 533.0));
    float num2 = (float) (((double) y - 160.0) * (1.0 / 160.0));
    if ((double) num1 < -1.0 && (double) num1 > 1.0 || (double) num2 < -1.0 && (double) num2 > 1.0)
      return false;
    float num3 = (float) (63.2937507629395 * (double) num1 * 0.5);
    float num4 = (float) (38.0 * (double) num2 * 0.5);
    float cameraYaw = this.m_cameraYaw;
    float cameraPitch = this.m_cameraPitch;
    Transform transform = new Transform();
    transform.setIdentity();
    transform.postRotate(cameraYaw, 0.0f, 1f, 0.0f);
    transform.postRotate(-cameraPitch, 1f, 0.0f, 0.0f);
    float[] vector3 = new float[4]{ 0.0f, 1f, 0.0f, 1f };
    transform.transform(ref vector3);
    float[] vector4 = new float[4]{ -1f, 0.0f, 0.0f, 1f };
    transform.transform(ref vector4);
    transform.setIdentity();
    transform.postRotate((float) (-(double) num3 * 0.649999976158142), vector3[0], vector3[1], vector3[2]);
    transform.postRotate(num4 * 0.65f, vector4[0], vector4[1], vector4[2]);
    transform.postRotate(cameraYaw, 0.0f, 1f, 0.0f);
    transform.postRotate(-cameraPitch, 1f, 0.0f, 0.0f);
    vector2[0] = 0.0f;
    vector2[1] = 0.0f;
    vector2[2] = -1f;
    vector2[3] = 1f;
    transform.transform(ref vector2);
    float num5 = numArray1[0] - vector1[0];
    float num6 = numArray1[1] - vector1[1];
    float num7 = numArray1[2] - vector1[2];
    float a = (float) ((double) numArray2[0] * (double) vector2[0] + (double) numArray2[1] * (double) vector2[1] + (double) numArray2[2] * (double) vector2[2]);
    if ((double) midp.JMath.abs(a) < 9.99999997475243E-07)
      return false;
    float num8 = (float) ((double) numArray2[0] * (double) num5 + (double) numArray2[1] * (double) num6 + (double) numArray2[2] * (double) num7) / a;
    float num9 = vector1[0] + vector2[0] * num8;
    float num10 = vector1[1] + vector2[1] * num8;
    float num11 = vector1[2] + vector2[2] * num8;
    resultF[0] = (int) ((double) num9 * 65536.0);
    resultF[1] = (int) ((double) num10 * 65536.0);
    resultF[2] = (int) ((double) num11 * 65536.0);
    resultF[3] = (int) ((double) num8 * 65536.0);
    return true;
  }

  public void coordScreenToWorldY0(int[] result, int x, int y)
  {
    float[] vector1 = new float[4]{ 0.0f, 0.0f, 0.0f, 1f };
    this.m_cameraTransformPreRotate.transform(ref vector1);
    float num1 = (float) (((double) x - 266.5) * (2.0 / 533.0));
    float num2 = (float) (((double) y - 160.0) * (1.0 / 160.0));
    if ((double) num1 < -1.0 || (double) num1 > 1.0 || ((double) num2 < -1.0 || (double) num2 > 1.0))
      return;
    float num3 = (float) (63.2937507629395 * (double) num1 * 0.5);
    float num4 = (float) (38.0 * (double) num2 * 0.5);
    float cameraYaw = this.m_cameraYaw;
    float cameraPitch = this.m_cameraPitch;
    Transform transform = new Transform();
    transform.setIdentity();
    transform.postRotate(cameraYaw, 0.0f, 1f, 0.0f);
    transform.postRotate(-cameraPitch, 1f, 0.0f, 0.0f);
    float[] vector2 = new float[4]{ 0.0f, 1f, 0.0f, 1f };
    transform.transform(ref vector2);
    float[] vector3 = new float[4]{ -1f, 0.0f, 0.0f, 1f };
    transform.transform(ref vector3);
    transform.setIdentity();
    transform.postRotate((float) (-(double) num3 * 0.649999976158142), vector2[0], vector2[1], vector2[2]);
    transform.postRotate(num4 * 0.65f, vector3[0], vector3[1], vector3[2]);
    transform.postRotate(cameraYaw, 0.0f, 1f, 0.0f);
    transform.postRotate(-cameraPitch, 1f, 0.0f, 0.0f);
    float[] vector4 = new float[4]{ 0.0f, 0.0f, -1f, 1f };
    transform.transform(ref vector4);
    float num5 = -vector1[1] / vector4[1];
    float num6 = vector1[0] + vector4[0] * num5;
    float num7 = vector1[2] + vector4[2] * num5;
    result[0] = (int) ((double) num6 * 65536.0);
    result[1] = 0;
    result[2] = (int) ((double) num7 * 65536.0);
    result[3] = (int) ((double) num5 * 65536.0);
  }

  public int getWallDepthAt(int screenX, int screenY)
  {
    int num = 0;
    for (int index = 0; index < this.m_houseRooms.Length; ++index)
    {
      int wallDepthAt = this.m_houseRooms[index].getWallDepthAt(screenX, screenY);
      if (wallDepthAt > 0 && (num == 0 || wallDepthAt < num))
        num = wallDepthAt;
    }
    return num;
  }

  public int getWallDepthRoomIdAt(int screenX, int screenY)
  {
    int num1 = 0;
    int num2 = -1;
    for (int index = 0; index < this.m_houseRooms.Length; ++index)
    {
      int wallDepthAt = this.m_houseRooms[index].getWallDepthAt(screenX, screenY);
      if (wallDepthAt > 0 && (num1 == 0 || wallDepthAt < num1))
      {
        num1 = wallDepthAt;
        num2 = index;
      }
    }
    return num2;
  }

  public bool isWorldPointWalkable(int xF, int zF)
  {
    return this.isWorldTileWalkable(this.coordWorldToWorldTileX(xF), this.coordWorldToWorldTileZ(zF));
  }

  public bool isWorldPointWalkableFrom(int xF, int zF, int srcXF, int srcZF)
  {
    int worldTileX1 = this.coordWorldToWorldTileX(xF);
    int worldTileZ1 = this.coordWorldToWorldTileZ(zF);
    int worldTileX2 = this.coordWorldToWorldTileX(srcXF);
    int worldTileZ2 = this.coordWorldToWorldTileZ(srcZF);
    if (worldTileX1 == worldTileX2 && worldTileZ1 == worldTileZ2)
      return this.isWorldTileWalkable(this.coordWorldToWorldTileX(xF), this.coordWorldToWorldTileZ(zF));
    int num1 = worldTileX1 - worldTileX2;
    int num2 = worldTileZ1 - worldTileZ2;
    int attribute = this.getAttribute(worldTileX1, worldTileZ1);
    if (num1 != 0)
    {
      int num3 = num1 < 0 ? 256 : 512;
      if ((attribute & num3) != 0)
        return false;
    }
    if (num2 != 0)
    {
      int num3 = num2 < 0 ? 1024 : 2048;
      if ((attribute & num3) != 0)
        return false;
    }
    return (attribute & 4096) == 0;
  }

  public bool isWorldTileWalkable(int tileX, int tileZ)
  {
    int attribute = this.getAttribute(tileX, tileZ);
    return (attribute & 3840) != 3840 && (attribute & 4096) == 0;
  }

  public Room getRoom(int roomId)
  {
    return roomId >= 0 && roomId < this.m_houseRooms.Length ? this.m_houseRooms[roomId] : (Room) null;
  }

  public int getAttribute(int tileX, int tileZ)
  {
    tileX += this.m_attribOffsetX;
    tileZ += this.m_attribOffsetZ;
    return tileX >= 0 && tileX < this.m_attribWidth && (tileZ >= 0 && tileZ < this.m_attribHeight) ? (int) this.m_attributesLayer[tileX + tileZ * this.m_attribWidth] : 3840;
  }

  private void setAttribute(int tileX, int tileY, int attribAnd, int attribOr)
  {
    tileX += this.m_attribOffsetX;
    tileY += this.m_attribOffsetZ;
    if (tileX < 0 || tileX >= this.m_attribWidth || (tileY < 0 || tileY >= this.m_attribHeight))
      return;
    short[] attributesLayer = this.m_attributesLayer;
    int index = tileX + tileY * this.m_attribWidth;
    int num = (int) attributesLayer[index] & attribAnd;
    attributesLayer[index] = (short) (num | attribOr);
  }

  public void paintAttributes(int x, int z, int width, int height, int attribAnd, int attribOr)
  {
    short[] attributesLayer = this.m_attributesLayer;
    int attribWidth = this.m_attribWidth;
    int num1 = this.m_attribOffsetX + x;
    int num2 = this.m_attribOffsetX + x + width;
    int num3 = this.m_attribOffsetZ + z;
    int num4 = this.m_attribOffsetZ + z + height;
    for (int index1 = num1; index1 < num2; ++index1)
    {
      for (int index2 = num3; index2 < num4; ++index2)
      {
        int index3 = index1 + index2 * attribWidth;
        int num5 = (int) attributesLayer[index3] & attribAnd;
        attributesLayer[index3] = (short) (num5 | attribOr);
      }
    }
  }

  public void paintAttributes(Node node, int attribAnd, int attribOr)
  {
    if (node == null)
      return;
    Group group = Group.m3g_cast((Object3D) node);
    if (group != null)
    {
      int childCount = group.getChildCount();
      for (int index = 0; index < childCount; ++index)
        this.paintAttributes(group.getChild(index), attribAnd, attribOr);
    }
    Mesh mesh = Mesh.m3g_cast((Object3D) node);
    if (mesh == null)
      return;
    int[] result = new int[6];
    ModelManager.getBoundingBox(result, mesh);
    int x1 = (int) (System.Math.Floor((double) (result[0] + 1048576) / 2097152.0) * 2097152.0);
    int z1 = (int) (System.Math.Floor((double) (result[2] + 1048576) / 2097152.0) * 2097152.0);
    int x2 = (int) (System.Math.Floor((double) (result[3] + 1048576) / 2097152.0) * 2097152.0);
    int z2 = (int) (System.Math.Floor((double) (result[5] + 1048576) / 2097152.0) * 2097152.0);
    int worldTileX1 = this.coordWorldToWorldTileX(x1);
    int worldTileZ1 = this.coordWorldToWorldTileZ(z1);
    int worldTileX2 = this.coordWorldToWorldTileX(x2);
    int worldTileZ2 = this.coordWorldToWorldTileZ(z2);
    int width = worldTileX2 - worldTileX1;
    int height = worldTileZ2 - worldTileZ1;
    this.paintAttributes(worldTileX1, worldTileZ1, width, height, attribAnd, attribOr);
  }

  private void calculateSidewalk()
  {
    short[] attributesLayer = this.m_attributesLayer;
    int attribWidth = this.m_attribWidth;
    int length = attributesLayer.Length;
    for (int index1 = 0; index1 < length; ++index1)
    {
      if (((int) attributesLayer[index1] & 64) != 0)
      {
        int index2 = index1 - 1;
        int index3 = index1 + 1;
        int index4 = index1 - attribWidth;
        int index5 = index1 + attribWidth;
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        bool flag4 = false;
        if (index2 >= 0 && ((int) attributesLayer[index2] & 64) == 0)
        {
          attributesLayer[index2] |= (short) 32;
          flag3 = true;
        }
        if (index3 < length && ((int) attributesLayer[index3] & 64) == 0)
        {
          attributesLayer[index3] |= (short) 32;
          flag4 = true;
        }
        if (index4 >= 0 && ((int) attributesLayer[index4] & 64) == 0)
        {
          attributesLayer[index4] |= (short) 32;
          flag1 = true;
        }
        if (index5 < length && ((int) attributesLayer[index5] & 64) == 0)
        {
          attributesLayer[index5] |= (short) 32;
          flag2 = true;
        }
        if (flag1)
        {
          if (flag3 && ((int) attributesLayer[index4 - 1] & 64) == 0)
            attributesLayer[index4 - 1] |= (short) 32;
          if (flag4 && ((int) attributesLayer[index4 + 1] & 64) == 0)
            attributesLayer[index4 + 1] |= (short) 32;
        }
        if (flag2)
        {
          if (flag3 && ((int) attributesLayer[index5 - 1] & 64) == 0)
            attributesLayer[index5 - 1] |= (short) 32;
          if (flag4 && ((int) attributesLayer[index5 + 1] & 64) == 0)
            attributesLayer[index5 + 1] |= (short) 32;
        }
        if (((int) attributesLayer[index1] & 8192) == 0 && !flag1 && (!flag2 && !flag3) && !flag4)
        {
          int num1 = 0;
          if (((int) attributesLayer[index5 - 1] & 64) == 0)
            num1 = -attribWidth;
          else if (((int) attributesLayer[index5 + 1] & 64) == 0)
            num1 = -attribWidth - 1;
          else if (((int) attributesLayer[index4 + 1] & 64) == 0)
            num1 = -1;
          int index6 = index1 + num1;
          int num2 = (int) attributesLayer[index6];
          attributesLayer[index6] = (short) (num2 & -129 | 8192);
          int index7 = index1 + num1 + 1;
          int num3 = (int) attributesLayer[index7];
          attributesLayer[index7] = (short) (num3 & -129 | 8192);
          int index8 = index1 + num1 + attribWidth;
          int num4 = (int) attributesLayer[index8];
          attributesLayer[index8] = (short) (num4 & -129 | 8192);
          int index9 = index1 + num1 + attribWidth + 1;
          int num5 = (int) attributesLayer[index9];
          attributesLayer[index9] = (short) (num5 & -129 | 8192);
        }
        else if ((flag1 && !flag3 || flag4 && !flag2) && ((int) attributesLayer[index1] & 8192) == 0)
          attributesLayer[index1] |= (short) 128;
      }
    }
  }

  public bool checkFootprintOK(int tileX, int tileZ, int width, int height)
  {
    for (int index1 = 0; index1 < width; ++index1)
    {
      int num1 = 40704;
      if (index1 == 0)
        num1 &= -257;
      if (index1 == width - 1)
        num1 &= -513;
      for (int index2 = 0; index2 < height; ++index2)
      {
        int num2 = num1;
        if (index2 == 0)
          num2 &= -1025;
        if (index2 == height - 1)
          num2 &= -2049;
        if ((this.getAttribute(tileX - index1, tileZ - index2) & num2) != 0)
          return false;
      }
    }
    return true;
  }

  public int getBackgroundColor()
  {
    return this.m_background.getColor();
  }

  public void setBackgroundColor(int color)
  {
    this.m_background.setColor(color);
  }

  public World getWorldNode()
  {
    return this.m_world;
  }

  private void prepareWorldHouse3D(int houseId)
  {
    this.paintHouseAttributes(houseId);
    this.createRooms(houseId);
    this.createFloors3D(houseId);
  }

  private void paintHouseAttributes(int houseId)
  {
    AppEngine.timerBegin();
    sbyte[] dHouseRoomX = this.d_houseRoomXs[houseId];
    sbyte[] dHouseRoomY = this.d_houseRoomYs[houseId];
    sbyte[] dHouseRoomWidth = this.d_houseRoomWidths[houseId];
    sbyte[] dHouseRoomHeight = this.d_houseRoomHeights[houseId];
    sbyte[] dHouseDoorX = this.d_houseDoorXs[houseId];
    sbyte[] dHouseDoorY = this.d_houseDoorYs[houseId];
    sbyte[] dHouseDoorWidth = this.d_houseDoorWidths[houseId];
    short[] dHouseDoorType = this.d_houseDoorTypes[houseId];
    sbyte[] dHouseWindowX = this.d_houseWindowXs[houseId];
    sbyte[] dHouseWindowY = this.d_houseWindowYs[houseId];
    sbyte[] houseWindowWidth = this.d_houseWindowWidths[houseId];
    short[] dHouseWindowType = this.d_houseWindowTypes[houseId];
    int length1 = dHouseRoomX.Length;
    int length2 = dHouseDoorX.Length;
    int length3 = dHouseWindowX.Length;
    for (int index = 0; index < length1; ++index)
    {
      int x = (int) dHouseRoomX[index];
      int z = (int) dHouseRoomY[index];
      int width = (int) dHouseRoomWidth[index];
      int height = (int) dHouseRoomHeight[index];
      this.paintAttributes(x, z, width, height, (int) ushort.MaxValue, index + 1 | 16);
      this.paintAttributes(x, z, width, 1, (int) ushort.MaxValue, 2048);
      this.paintAttributes(x, z - 1, width, 1, (int) ushort.MaxValue, 1024);
      this.paintAttributes(x, z + height - 1, width, 1, (int) ushort.MaxValue, 1024);
      this.paintAttributes(x, z + height, width, 1, (int) ushort.MaxValue, 2048);
      this.paintAttributes(x, z, 1, height, (int) ushort.MaxValue, 512);
      this.paintAttributes(x - 1, z, 1, height, (int) ushort.MaxValue, 256);
      this.paintAttributes(x + width - 1, z, 1, height, (int) ushort.MaxValue, 256);
      this.paintAttributes(x + width, z, 1, height, (int) ushort.MaxValue, 512);
    }
    SceneGame sceneGame = this.getSceneGame();
    bool flag1 = false;
    for (int id = 0; id < length2; ++id)
    {
      int tileX = (int) dHouseDoorX[id];
      int tileZ = (int) dHouseDoorY[id];
      int x = tileX;
      int z = tileZ;
      int num1 = midp.JMath.abs((int) dHouseDoorWidth[id]);
      int type = (int) dHouseDoorType[id];
      int num2;
      int num3;
      int width;
      int height;
      int num4;
      if ((this.getAttribute(tileX, tileZ) & 3840 & this.getAttribute(tileX - 1, tileZ)) != 0)
      {
        num2 = tileX + (num1 - 1);
        num3 = tileZ + 1;
        width = num1;
        height = 2;
        num4 = 1;
      }
      else
      {
        num2 = tileX + 1;
        num3 = tileZ + (num1 - 1);
        width = 2;
        height = num1;
        num4 = 0;
        dHouseDoorWidth[id] = (sbyte) -num1;
      }
      this.paintAttributes(x, z, width, height, -3841, 32);
      if (type != -1)
      {
        bool flag2 = false;
        int doorX = num2;
        int doorZ = num3;
        if (num4 == 0)
        {
          if (this.getRoomAt(num2, num3) == -1)
            flag2 = true;
          else if (this.getRoomAt(num2 - 1, num3) == -1)
          {
            flag2 = true;
            num4 = 2;
            --doorX;
          }
        }
        else if (this.getRoomAt(num2, num3) == -1)
          flag2 = true;
        else if (this.getRoomAt(num2, num3 - 1) == -1)
        {
          flag2 = true;
          num4 = 3;
          --doorZ;
        }
        MapObject objectOnWorldTile = sceneGame.createObjectOnWorldTile(type, num2, 0, num3, num4, id);
        if (flag2)
        {
          objectOnWorldTile.setRuntimeFlag(1048576, flag2);
          if (!flag1)
          {
            flag1 = true;
            this.createRoad(doorX, doorZ, num4);
          }
        }
      }
    }
    for (int id = 0; id < length3; ++id)
    {
      int tileX = (int) dHouseWindowX[id];
      int tileZ = (int) dHouseWindowY[id];
      int x = tileX;
      int z = tileZ;
      int num = midp.JMath.abs((int) houseWindowWidth[id]);
      int type = (int) dHouseWindowType[id];
      int roomTileX;
      int roomTileZ;
      int width;
      int height;
      int facingDir;
      if ((this.getAttribute(tileX, tileZ) & 3840 & this.getAttribute(tileX - 1, tileZ)) != 0)
      {
        roomTileX = tileX + (num - 1);
        roomTileZ = tileZ + 1;
        width = num;
        height = 2;
        facingDir = 1;
      }
      else
      {
        roomTileX = tileX + 1;
        roomTileZ = tileZ + (num - 1);
        width = 2;
        height = num;
        facingDir = 0;
        houseWindowWidth[id] = (sbyte) -num;
      }
      this.paintAttributes(x, z, width, height, (int) ushort.MaxValue, 128);
      sceneGame.createObjectOnWorldTile(type, roomTileX, 0, roomTileZ, facingDir, id);
    }
    AppEngine.timerEnd("paintAttributesHouse");
  }

  private void createRoad(int doorX, int doorZ, int doorFacing)
  {
    SceneGame sceneGame = this.getSceneGame();
    sceneGame.createObjectOnWorldTile(32, doorX, 13107, doorZ, doorFacing, -1);
    if (this.getHouseId() != 0)
      return;
    int simCarObject = this.getSimData().getSimCarObject(0);
    if (simCarObject == -1)
      return;
    int worldCenterX = this.coordWorldTileToWorldCenterX(doorX + 6);
    int worldCenterZ = this.coordWorldTileToWorldCenterZ(doorZ + 4);
    sceneGame.createObject(simCarObject, worldCenterX, 0, worldCenterZ, doorFacing, -1);
  }

  private void createRooms(int houseId)
  {
    AppEngine.timerBegin();
    sbyte[] dHouseRoomX = this.d_houseRoomXs[houseId];
    sbyte[] dHouseRoomY = this.d_houseRoomYs[houseId];
    sbyte[] dHouseRoomWidth = this.d_houseRoomWidths[houseId];
    sbyte[] dHouseRoomHeight = this.d_houseRoomHeights[houseId];
    sbyte[] numArray1 = this.d_houseRoomFloors[houseId];
    sbyte[] numArray2 = this.d_houseRoomWalls[houseId];
    if (SimWorld.isHousePlayers(houseId))
    {
      numArray1 = this.m_playerHouseFloorTypes;
      numArray2 = this.m_playerHouseWallTypes;
    }
    int length = dHouseRoomX.Length;
    this.m_houseRooms = new Room[length];
    for (int index = 0; index < length; ++index)
    {
      int x = (int) dHouseRoomX[index];
      int z = (int) dHouseRoomY[index];
      int w = (int) dHouseRoomWidth[index];
      int h = (int) dHouseRoomHeight[index];
      int floorType = (int) numArray1[index];
      int wallType = (int) numArray2[index];
      Room room = new Room();
      this.m_houseRooms[index] = room;
      room.init(x, z, w, h, floorType, wallType);
    }
    for (int index = 0; index < length; ++index)
    {
      Room houseRoom = this.m_houseRooms[index];
      houseRoom.createGeometry();
      this.m_world.addChild((Node) houseRoom.getGroup());
    }
    int num = this.m_houseRoomCorners.size();
    for (int index = 0; index < num; ++index)
    {
      RoomCorner roomCorner = (RoomCorner) this.m_houseRoomCorners.elementAt(index);
      roomCorner.createGeometry();
      this.m_world.addChild((Node) roomCorner.getGroup());
    }
    AppEngine.timerEnd(nameof (createRooms));
  }

  public RoomCorner createCorner(int tileX, int tileZ)
  {
    RoomCorner roomCorner1 = (RoomCorner) null;
    int num = this.m_houseRoomCorners.size();
    for (int index = 0; index < num; ++index)
    {
      RoomCorner roomCorner2 = (RoomCorner) this.m_houseRoomCorners.elementAt(index);
      if (roomCorner2.getPosX() == tileX && roomCorner2.getPosZ() == tileZ)
        roomCorner1 = roomCorner2;
    }
    if (roomCorner1 == null)
    {
      roomCorner1 = new RoomCorner(tileX, tileZ);
      this.m_houseRoomCorners.addElement((object) roomCorner1);
    }
    return roomCorner1;
  }

  public MapObject registerWall(Room room, int wall, int tileX, int tileZ)
  {
    int num = this.m_houseRoomCorners.size();
    for (int index = 0; index < num; ++index)
    {
      RoomCorner roomCorner = (RoomCorner) this.m_houseRoomCorners.elementAt(index);
      if (roomCorner.getPosX() == tileX && roomCorner.getPosZ() == tileZ)
        roomCorner.attachWall(room, wall);
    }
    return this.getSceneGame().findWallFadableObjectAt(this.coordWorldTileToWorldCenterX(tileX) - 1048576, this.coordWorldTileToWorldCenterZ(tileZ) - 1048576);
  }

  private void createFloors3D(int houseId)
  {
    AppEngine.timerBegin();
    int[][] dFloorTexCoords = this.d_floorTexCoords;
    Appearance appearance = ModelManager.getInstance().getAppearance(0);
    int num1 = this.m_attribWidth / 8;
    int num2 = this.m_attribHeight / 8;
    int num3 = -(this.m_attribWidth >> 1);
    int num4 = -(this.m_attribHeight >> 1);
    Mesh[] meshArray = new Mesh[64];
    this.m_floorMeshes = meshArray;
    for (int index1 = 0; index1 < 8; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        GeomStrip geomStrip = new GeomStrip();
        int num5 = num3 + index1 * num1;
        int num6 = num4 + index2 * num2;
        int num7 = num5;
        int num8 = midp.JMath.min(num5 + num1, this.m_attribWidth);
        int num9 = num6;
        int num10 = midp.JMath.min(num6 + num2, this.m_attribHeight);
        for (int tileX = num7; tileX < num8; ++tileX)
        {
          for (int tileZ = num9; tileZ < num10; ++tileZ)
          {
            int num11 = this.getRoomAt(tileX, tileZ);
            if ((this.getAttribute(tileX, tileZ) & 16384) != 0)
              num11 = 0;
            if (num11 == -1)
            {
              int flags = 0;
              for (int index3 = 0; index3 < this.CREATE_FLOOR_OFFSETS.Length; index3 += 3)
              {
                int num12 = this.CREATE_FLOOR_OFFSETS[index3];
                int num13 = this.CREATE_FLOOR_OFFSETS[index3 + 1];
                if (this.getRoomAt(tileX + num12, tileZ + num13) != -1)
                  flags |= this.CREATE_FLOOR_OFFSETS[index3 + 2];
              }
              int index4 = (tileX & 1) == 0 ? 11 : 10;
              geomStrip.addFloor(32 * tileX, 32 * tileZ, 32, 32, dFloorTexCoords[index4], 0, 0, 0, 0, flags);
            }
          }
        }
        if (geomStrip.getQuadCount() > 0)
        {
          Mesh mesh = geomStrip.createMesh();
          mesh.setAppearance(0, appearance);
          mesh.commit();
          this.m_world.addChild((Node) mesh);
          meshArray[index1 + index2 * 8] = mesh;
        }
      }
    }
    AppEngine.timerEnd(nameof (createFloors3D));
  }

  private void renderWorld3D(Graphics g)
  {
    float radians1 = MathExt.degreesToRadians(this.m_cameraYaw);
    float radians2 = MathExt.degreesToRadians(this.m_cameraPitch);
    float cameraDolly = this.m_cameraDolly;
    float a1 = radians1 + 1.570796f + MathExt.degreesToRadians(19f);
    float num1 = midp.JMath.Sin(a1);
    float num2 = midp.JMath.Cos(a1);
    float num3 = (float) (-(double) this.m_cameraPosX * (double) num1 + -(double) this.m_cameraPosZ * (double) num2);
    float num4 = midp.JMath.min((float) (-(double) cameraDolly * 0.5), -200f);
    float a2 = radians1 + 1.570796f - MathExt.degreesToRadians(19f);
    float num5 = -midp.JMath.Sin(a2);
    float num6 = -midp.JMath.Cos(a2);
    float num7 = (float) (-(double) this.m_cameraPosX * (double) num5 + -(double) this.m_cameraPosZ * (double) num6);
    float num8 = midp.JMath.min((float) (-(double) cameraDolly * 0.5), -200f);
    float num9 = midp.JMath.Sin(radians1);
    float num10 = midp.JMath.Cos(radians1);
    float num11 = (float) (-(double) this.m_cameraPosX * (double) num9 + -(double) this.m_cameraPosZ * (double) num10);
    float num12 = (float) (1.0 + (double) midp.JMath.Cos(radians2) * 2.0);
    float num13 = (float) MathExt.clip((int) (-(double) cameraDolly * (double) num12), -800, -200);
    float num14 = -midp.JMath.Sin(radians1);
    float num15 = -midp.JMath.Cos(radians1);
    float num16 = (float) (-(double) this.m_cameraPosX * (double) num14 + -(double) this.m_cameraPosZ * (double) num15);
    float num17 = num13 * 0.5f;
    foreach (MapObject mapObject in this.getSceneGame().getObjects())
    {
      float num18 = (float) mapObject.getPosX() * 1.525879E-05f;
      float num19 = (float) mapObject.getPosZ() * 1.525879E-05f;
      float num20 = (float) ((double) num18 * (double) num1 + (double) num19 * (double) num2) + num3;
      float num21 = (float) ((double) num18 * (double) num5 + (double) num19 * (double) num6) + num7;
      float num22 = (float) ((double) num18 * (double) num9 + (double) num19 * (double) num10) + num11;
      float num23 = (float) ((double) num18 * (double) num14 + (double) num19 * (double) num15) + num16;
      mapObject.setInView((double) num20 > (double) num4 && (double) num21 > (double) num8 && (double) num22 > (double) num13 && (double) num23 > (double) num17);
      mapObject.updateModel();
    }
    int num24 = this.m_attribWidth / 8;
    int num25 = this.m_attribHeight / 8;
    int num26 = -(this.m_attribWidth >> 1);
    int num27 = -(this.m_attribHeight >> 1);
    for (int index1 = 0; index1 < this.m_floorMeshes.Length; ++index1)
    {
      if (this.m_floorMeshes[index1] != null)
      {
        int num18 = index1 % 8;
        int num19 = index1 / 8;
        int num20 = num26 + num18 * num24;
        int num21 = num27 + num19 * num25;
        float num22 = (float) (num20 * 32);
        float num23 = (float) (num21 * 32);
        float num28 = num22 + (float) (num24 * 32);
        float num29 = num23 + (float) (num25 * 32);
        bool enable = false;
        for (int index2 = 0; index2 < 4 && !enable; ++index2)
        {
          float num30 = (index2 & 1) == 0 ? num22 : num28;
          float num31 = (index2 & 2) == 0 ? num23 : num29;
          float num32 = (float) ((double) num30 * (double) num1 + (double) num31 * (double) num2) + num3;
          float num33 = (float) ((double) num30 * (double) num5 + (double) num31 * (double) num6) + num7;
          float num34 = (float) ((double) num30 * (double) num9 + (double) num31 * (double) num10) + num11;
          float num35 = (float) ((double) num30 * (double) num14 + (double) num31 * (double) num15) + num16;
          enable = (double) num32 > (double) num4 && (double) num33 > (double) num8 && (double) num34 > (double) num13 && (double) num35 > (double) num17;
        }
        this.m_floorMeshes[index1].setRenderingEnable(enable);
      }
    }
    Graphics3D graphics3D = this.m_engine.getGraphics3D();
    this.setupCameraTransform();
    this.m_camera.setTransform(this.m_cameraTransform);
    graphics3D.bindTarget((object) g, JavaLib.GraphicsDevice);
    graphics3D.setViewport(this.m_viewportX, this.m_viewportY, this.m_viewportWidth, this.m_viewportHeight);
    graphics3D.render(this.m_world);
    graphics3D.releaseTarget();
  }

  public void initCamera()
  {
    bool flag1 = this.getSceneGame().isMapMode();
    bool flag2 = this.getSceneGame().isZoomMapMode() && this.m_engine.getNextZoomMapId() == 4;
    bool flag3 = this.getSceneGame().isZoomMapMode() && this.m_engine.getNextZoomMapId() == 183;
    if (!flag1 && !flag2 && !flag3)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      for (int index = 0; index < this.m_houseRooms.Length; ++index)
      {
        Room houseRoom = this.m_houseRooms[index];
        int posX = houseRoom.getPosX();
        int posZ = houseRoom.getPosZ();
        int sizeX = houseRoom.getSizeX();
        int sizeZ = houseRoom.getSizeZ();
        if (index == 0 || posX < num1)
          num1 = posX;
        if (index == 0 || posZ < num3)
          num3 = posZ;
        if (index == 0 || posX + sizeX > num2)
          num2 = posX + sizeX;
        if (index == 0 || posZ + sizeZ > num4)
          num4 = posZ + sizeZ;
      }
      MapObject randomObjectByType = this.getSceneGame().findRandomObjectByType(4);
      if (randomObjectByType != null)
      {
        int num5 = randomObjectByType.getPosX() / 2097152;
        int num6 = randomObjectByType.getPosZ() / 2097152;
        if (num5 < num1)
          num1 = num5;
        else if (num5 > num2)
          num2 = num5;
        if (num6 < num3)
          num3 = num6;
        else if (num6 > num4)
          num4 = num6;
      }
      float num7 = (float) (num2 - num1) / 2f;
      float num8 = (float) (num4 - num3) / 2f;
      float num9 = (float) num1 + num7;
      float num10 = (float) num3 + num8;
      this.m_cameraCenterX = num9 * 32f;
      this.m_cameraCenterZ = num10 * 32f;
    }
    else if (flag1)
    {
      this.m_cameraCenterX = 106f;
      this.m_cameraCenterZ = 276f;
    }
    else if (flag2)
    {
      this.m_cameraCenterX = 896f;
      this.m_cameraCenterZ = 384f;
    }
    else
    {
      if (!flag3)
        return;
      this.m_cameraCenterX = 0.0f;
      this.m_cameraCenterZ = 0.0f;
    }
  }

  public float[] getCamRangeSlowdownFactor(float vecX, float vecZ)
  {
    bool flag1 = this.getSceneGame().isMapMode();
    bool flag2 = this.getSceneGame().isZoomMapMode() && this.m_engine.getNextZoomMapId() == 4;
    bool flag3 = this.getSceneGame().isZoomMapMode() && this.m_engine.getNextZoomMapId() == 183;
    if (flag3)
    {
      float num1;
      float num2;
      float num3;
      float num4;
      if (flag1)
      {
        num1 = 1100f;
        num2 = 1000f;
        num3 = 1008f;
        num4 = 900f;
      }
      else if (flag2)
      {
        num1 = 400f;
        num2 = 400f;
        num3 = 300f;
        num4 = 300f;
      }
      else if (flag3)
      {
        num1 = 400f;
        num2 = 132f;
        num3 = 200f;
        num4 = 32f;
      }
      else
      {
        num1 = 400f;
        num2 = 400f;
        num3 = 300f;
        num4 = 300f;
      }
      float num5 = this.m_cameraPosX + vecX;
      float num6 = this.m_cameraPosZ + vecZ;
      float a1 = num5 - this.m_cameraCenterX;
      float a2 = num6 - this.m_cameraCenterZ;
      float a3 = this.m_cameraPosX - this.m_cameraCenterX;
      float a4 = this.m_cameraPosZ - this.m_cameraCenterZ;
      if ((double) midp.JMath.abs(a1) > (double) num3 && (double) midp.JMath.abs(a1) > (double) midp.JMath.abs(a3))
      {
        float num7 = midp.JMath.max(0.0f, midp.JMath.min(1f, (midp.JMath.abs(a1) - num3) / (num1 - num3)));
        vecX *= 1f - num7;
        float num8 = this.m_cameraPosX + vecX - this.m_cameraCenterX;
      }
      if ((double) midp.JMath.abs(a2) > (double) num4 && (double) midp.JMath.abs(a2) > (double) midp.JMath.abs(a4))
      {
        float num7 = midp.JMath.max(0.0f, midp.JMath.min(1f, (midp.JMath.abs(a2) - num4) / (num2 - num4)));
        vecZ *= 1f - num7;
        float num8 = this.m_cameraPosZ + vecZ - this.m_cameraCenterZ;
      }
      this.m_camRangeSlowdownVec[0] = vecX;
      this.m_camRangeSlowdownVec[1] = vecZ;
      return this.m_camRangeSlowdownVec;
    }
    float num9;
    float num10;
    if (flag1)
    {
      num9 = 1000f;
      num10 = 1400f;
    }
    else if (flag2)
    {
      num9 = 600f;
      num10 = 800f;
    }
    else if (flag3)
    {
      num9 = 600f;
      num10 = 800f;
    }
    else
    {
      num9 = 400f;
      num10 = 570f;
    }
    float cameraCenterX = this.m_cameraCenterX;
    float cameraCenterZ = this.m_cameraCenterZ;
    float num11 = this.m_cameraPosX + vecX - cameraCenterX;
    float num12 = this.m_cameraPosZ + vecZ - cameraCenterZ;
    float num13 = midp.JMath.Sqrt((float) ((double) num11 * (double) num11 + (double) num12 * (double) num12));
    float num14 = num11 / num13;
    float num15 = num12 / num13;
    float num16 = (float) ((double) num14 * (double) vecX + (double) num15 * (double) vecZ);
    float num17 = num14 * num16;
    float num18 = num15 * num16;
    float num19 = vecX - num17;
    float num20 = vecZ - num18;
    float num21 = this.m_cameraPosX - cameraCenterX;
    float num22 = this.m_cameraPosZ - cameraCenterZ;
    float num23 = midp.JMath.sqrt((float) (((double) num17 + (double) num21) * ((double) num17 + (double) num21)) + (float) (((double) num18 + (double) num22) * ((double) num18 + (double) num22)));
    float num24 = midp.JMath.sqrt((float) (((double) num19 + (double) num21) * ((double) num19 + (double) num21)) + (float) (((double) num20 + (double) num22) * ((double) num20 + (double) num22)));
    float num25 = midp.JMath.Sqrt((float) ((double) num21 * (double) num21 + (double) num22 * (double) num22));
    float num26 = num10 - num9;
    if ((double) num23 > (double) num9)
    {
      float num1 = num23 - num9;
      float num2 = midp.JMath.min(midp.JMath.max((double) num26 <= 0.0 ? 0.0f : (float) (1.0 - (double) num1 / (double) num26), 0.0f), 1f);
      if ((double) num23 > (double) num25)
      {
        num17 *= num2;
        num18 *= num2;
      }
    }
    if ((double) num24 > (double) num9)
    {
      float num1 = num24 - num9;
      float num2 = midp.JMath.min(midp.JMath.max((double) num26 <= 0.0 ? 0.0f : (float) (1.0 - (double) num1 / (double) num26), 0.0f), 1f);
      num19 *= num2;
      num20 *= num2;
    }
    this.m_camRangeSlowdownVec[0] = num17 + num19;
    this.m_camRangeSlowdownVec[1] = num18 + num20;
    return this.m_camRangeSlowdownVec;
  }

  public void setupCameraTransform()
  {
    float cameraPosX = this.m_cameraPosX;
    float cameraPosY = this.m_cameraPosY;
    float cameraPosZ = this.m_cameraPosZ;
    float cameraPitch = this.m_cameraPitch;
    float cameraYaw = this.m_cameraYaw;
    float cameraDolly = this.m_cameraDolly;
    Transform cameraTransform = this.m_cameraTransform;
    cameraTransform.setIdentity();
    cameraTransform.postTranslate(cameraPosX, cameraPosY, cameraPosZ);
    cameraTransform.postRotate(cameraYaw, 0.0f, 1f, 0.0f);
    cameraTransform.postRotate(-cameraPitch, 1f, 0.0f, 0.0f);
    cameraTransform.postTranslate(0.0f, 0.0f, cameraDolly);
    this.m_cameraTransformPreRotate.set(cameraTransform);
    cameraTransform.postRotate(90f, 0.0f, 0.0f, 1f);
    Transform cameraTransformInv = this.m_cameraTransformInv;
    cameraTransformInv.setIdentity();
    cameraTransformInv.postRotate(-90f, 0.0f, 0.0f, 1f);
    cameraTransformInv.postTranslate(0.0f, 0.0f, -cameraDolly);
    cameraTransformInv.postRotate(cameraPitch, 1f, 0.0f, 0.0f);
    cameraTransformInv.postRotate(-cameraYaw, 0.0f, 1f, 0.0f);
    cameraTransformInv.postTranslate(-cameraPosX, -cameraPosY, -cameraPosZ);
  }

  public void updateCameraPos(int timeStep)
  {
    float yawDeg = MathExt.normaliseAngleDegrees(this.m_cameraYaw);
    for (int index = 0; index < this.m_houseRooms.Length; ++index)
      this.m_houseRooms[index].updateCameraPos(this.m_cameraPosX, this.m_cameraPosZ, yawDeg, timeStep);
    int num1 = this.m_houseRoomCorners.size();
    for (int index = 0; index < num1; ++index)
      ((RoomCorner) this.m_houseRoomCorners.elementAt(index)).updateCameraPos();
    float[] tempFloat4 = this.m_tempFloat4;
    Transform cameraTransform = this.m_cameraTransform;
    tempFloat4[0] = 0.0f;
    tempFloat4[1] = 0.0f;
    tempFloat4[2] = 0.0f;
    tempFloat4[3] = 1f;
    cameraTransform.transform(ref tempFloat4);
    float num2 = tempFloat4[0];
    float num3 = tempFloat4[1];
    float num4 = tempFloat4[2];
    tempFloat4[0] = 0.0f;
    tempFloat4[1] = 0.0f;
    tempFloat4[2] = -1f;
    tempFloat4[3] = 1f;
    cameraTransform.transform(ref tempFloat4);
    float atX = tempFloat4[0] - num2;
    float atY = tempFloat4[1] - num3;
    float atZ = tempFloat4[2] - num4;
    tempFloat4[0] = 1f;
    tempFloat4[1] = 0.0f;
    tempFloat4[2] = 0.0f;
    tempFloat4[3] = 1f;
    cameraTransform.transform(ref tempFloat4);
    float upX = tempFloat4[0] - num2;
    float upY = tempFloat4[1] - num3;
    float upZ = tempFloat4[2] - num4;
    this.m_engine.getSoundManager().setListenerPosition(this.m_cameraPosX, this.m_cameraPosY, this.m_cameraPosZ, 0.0f, 0.0f, 0.0f, atX, atY, atZ, upX, upY, upZ);
    if (!this.getSceneGame().isRepairing() && !this.getSceneGame().isCooking())
    {
      this.m_dayNightTimer -= timeStep;
      if (this.m_dayNightTimer < 0 || this.m_dayNightForce)
      {
        this.m_dayNightTimer = 750;
        if (this.calcDayNightTint() || this.m_dayNightForce)
          this.applyDayNightTint();
        this.m_dayNightForce = false;
      }
    }
    ModelManager.getInstance().updateScrollingTextures(timeStep);
    this.m_visualsAnimPlayer.updateAnim(timeStep);
    if (!this.getSceneGame().isZoomMapMode() || this.m_engine.getNextZoomMapId() != 4)
      return;
    ModelManager.getInstance().updateLakesideTextures(timeStep);
  }

  public void addObjectNode(Node node)
  {
    this.m_worldObjects.addChild(node);
    this.forceTint();
  }

  public void removeObjectNode(Node node)
  {
    this.m_worldObjects.removeChild(node);
  }

  private bool calcDayNightTint()
  {
    int gameTime = this.getSimData().getGameTime();
    int num1;
    int num2;
    bool flag;
    if (gameTime < 360)
    {
      num1 = 5197695;
      num2 = 32;
      flag = true;
    }
    else if (gameTime < 480)
    {
      int factorFromF = MathExt.Fdiv(gameTime - 360, 120);
      num1 = MathExt.interpRGB(16777215, 5197695, factorFromF);
      num2 = MathExt.interpRGB(9222898, 32, factorFromF);
      flag = gameTime < 420;
    }
    else if (gameTime < 1080)
    {
      num1 = 16777215;
      num2 = 9222898;
      flag = false;
    }
    else if (gameTime < 1200)
    {
      int factorFromF = MathExt.Fdiv(gameTime - 1080, 120);
      num1 = MathExt.interpRGB(5197695, 16777215, factorFromF);
      num2 = MathExt.interpRGB(32, 9222898, factorFromF);
      flag = gameTime > 1140;
    }
    else
    {
      num1 = 5197695;
      num2 = 32;
      flag = true;
    }
    int dayNightTint = this.m_dayNightTint;
    int dayNightSky = this.m_dayNightSky;
    bool dayNightLighting = this.m_dayNightLighting;
    this.m_dayNightTint = num1;
    this.m_dayNightSky = num2;
    this.m_dayNightLighting = flag;
    return dayNightTint != num1 || dayNightSky != num2 || dayNightLighting != this.m_dayNightLighting;
  }

  private void applyDayNightTint()
  {
    for (int index = 0; index < this.m_floorMeshes.Length; ++index)
      GeomStrip.setTint(this.m_dayNightTint, this.m_floorMeshes[index]);
    for (int index = 0; index < this.m_houseRooms.Length; ++index)
      this.m_houseRooms[index].setTintOutside(this.m_dayNightTint);
    foreach (MapObject mapObject in this.getSceneGame().getObjects())
      mapObject.updateTint();
    ModelManager.applyTintColor(this.m_visuals, this.m_dayNightTint);
    this.m_background.setColor(this.m_dayNightSky);
    ModelManager.getInstance().setFogColor(this.m_dayNightSky);
    ModelManager.getInstance().setNightTextures(this.m_dayNightLighting);
    if (this.m_additiveVisuals == null)
      return;
    this.m_additiveVisuals.setRenderingEnable(this.m_dayNightLighting);
  }

  public void forceTint()
  {
    this.m_dayNightForce = true;
  }

  public int getDayNightTint()
  {
    return this.m_dayNightTint;
  }

  public bool getDayNightLighting()
  {
    return this.m_dayNightLighting;
  }

  public void setCameraPosX(float x)
  {
    this.m_cameraPosX = x;
  }

  public void setCameraPosY(float y)
  {
    this.m_cameraPosY = y;
  }

  public void setCameraPosZ(float z)
  {
    this.m_cameraPosZ = z;
  }

  public void setCameraPitch(float pitch)
  {
    this.m_cameraPitch = pitch;
  }

  public void setCameraYaw(float yaw)
  {
    this.m_cameraYaw = yaw;
  }

  public void setCameraDolly(float dolly)
  {
    this.m_cameraDolly = dolly;
  }

  public float getCameraPosX()
  {
    return this.m_cameraPosX;
  }

  public float getCameraPosY()
  {
    return this.m_cameraPosY;
  }

  public float getCameraPosZ()
  {
    return this.m_cameraPosZ;
  }

  public float getCameraPitch()
  {
    return this.m_cameraPitch;
  }

  public float getCameraYaw()
  {
    return this.m_cameraYaw;
  }

  public float getCameraDolly()
  {
    return this.m_cameraDolly;
  }

  public Transform getCameraTransform()
  {
    return this.m_cameraTransformPreRotate;
  }

  public int getObjectCount()
  {
    return this.d_objectRecordsBuiltIn.Length + DLCManager.getInstance().getDLCObjectCount();
  }

  public int getObjectCountBuiltIn()
  {
    return this.d_objectRecordsBuiltIn.Length;
  }

  private RecObject getObjectRecord(int objectId)
  {
    return objectId < this.d_objectRecordsBuiltIn.Length ? this.d_objectRecordsBuiltIn[objectId] : DLCManager.getInstance().getDLCObjectRecord(objectId - this.d_objectRecordsBuiltIn.Length);
  }

  public int getObjectParent(int type)
  {
    return (int) this.getObjectRecord(type).m_parent;
  }

  public int getObjectCategory(int type)
  {
    return (int) this.getObjectRecord(type).m_category;
  }

  public int getObjectStringId(int type)
  {
    return this.getObjectRecord(type).m_stringId;
  }

  public int getObjectActionIcon(int type)
  {
    return (int) this.getObjectRecord(type).m_actionIcon;
  }

  public int getObjectFlags(int type)
  {
    return this.getObjectRecord(type).m_flags;
  }

  public int getObjectNeed(int type)
  {
    return (int) this.getObjectRecord(type).m_need;
  }

  public int getObjectBuyPrice(int type)
  {
    return (int) this.getObjectRecord(type).m_buyPrice;
  }

  public int getObjectSellPrice(int type)
  {
    return (int) this.getObjectRecord(type).m_sellPrice;
  }

  public int getObjectFootprintWidth(int type)
  {
    return (int) this.getObjectRecord(type).m_footprintWidth;
  }

  public int getObjectFootprintHeight(int type)
  {
    return (int) this.getObjectRecord(type).m_footprintHeight;
  }

  public int getObjectModelId(int type)
  {
    return (int) this.getObjectRecord(type).m_modelId;
  }

  public int getObjectPackId(int type)
  {
    return (int) this.getObjectRecord(type).m_packId;
  }

  public int getObjectInterestPointCount(int type)
  {
    return this.getObjectRecord(type).m_interestPointXs.Length;
  }

  public void getObjectInterestPoint(ref int[] result, int type, int index, int facingDir)
  {
    RecObject objectRecord = this.getObjectRecord(type);
    int num1 = (int) objectRecord.m_interestPointXs[index];
    int num2 = (int) objectRecord.m_interestPointYs[index];
    int num3 = midp.JMath.max((int) objectRecord.m_footprintWidth, 1);
    int num4 = midp.JMath.max((int) objectRecord.m_footprintHeight, 1);
    switch (facingDir)
    {
      case 1:
        int num5 = num1;
        num1 = -num2 - (num4 - 1);
        num2 = num5;
        break;
      case 2:
      case 5:
      case 6:
        num1 = -num1 - (num3 - 1);
        num2 = -num2 - (num4 - 1);
        break;
      case 3:
        int num6 = num1;
        num1 = num2;
        num2 = -num6 - (num3 - 1);
        break;
    }
    result[0] = num1;
    result[1] = num2;
  }

  public short[] getObjectActions(int type)
  {
    return this.getObjectRecord(type).m_actions;
  }

  public int getObjectQuickLinkIndex(int type)
  {
    if ((this.getObjectFlags(type) & 128) == 0)
      return -1;
    int objectCountBuiltIn = this.getObjectCountBuiltIn();
    int num = 0;
    for (int type1 = 0; type1 < objectCountBuiltIn; ++type1)
    {
      if ((this.getObjectFlags(type1) & 128) != 0)
      {
        if (type1 == type)
          return num;
        ++num;
      }
    }
    AppEngine.ASSERT(false, "invalid object type");
    return -1;
  }

  public string getObjectSpywareId(int objectId)
  {
    if (objectId < this.getObjectCountBuiltIn())
      return GlobalConstants.LOOKUP_OBJECT[objectId];
    DLCManager instance = DLCManager.getInstance();
    RecObject objectRecord = this.getObjectRecord(objectId);
    string packName = instance.getPackName((int) objectRecord.m_packId);
    string str = string.Concat((object) objectRecord.m_index);
    StringBuffer stringBuffer = new StringBuffer();
    stringBuffer.append(packName).append("/").append(str);
    return stringBuffer.toString();
  }

  public int getCategoryString(int category)
  {
    return (int) this.d_categoryStrings[category];
  }

  public int getCategoryIcon(int category)
  {
    return (int) this.d_categoryIcons[category];
  }

  public int getSimAttributeMax(int sim, int attribute)
  {
    return this.getSimAttributeMax(sim, attribute, false);
  }

  public int getSimAttributeMax(int sim, int attribute, bool builtInOnly)
  {
    DLCManager instance = DLCManager.getInstance();
    SimData simData = this.getSimData();
    switch (attribute)
    {
      case 0:
        return 2;
      case 1:
        int meshAttrib1 = simData.mapAttributeToMeshAttrib(sim, attribute);
        int simTextureIdCount1 = this.getSimTextureIdCount(meshAttrib1, 0);
        if (!builtInOnly)
        {
          int simTextureIdCount2 = instance.getSimTextureIdCount(meshAttrib1, 0);
          simTextureIdCount1 += simTextureIdCount2;
        }
        return simTextureIdCount1;
      case 2:
      case 5:
      case 7:
      case 9:
      case 11:
        int meshAttrib2 = simData.mapAttributeToMeshAttrib(sim, attribute);
        return this.getSimMeshUserIdCount(meshAttrib2) + (builtInOnly ? 0 : instance.getSimMeshUserIdCount(meshAttrib2));
      case 3:
      case 6:
      case 8:
      case 10:
      case 12:
        int attributeTypeForColor = SimData.getAttributeTypeForColor(attribute);
        int meshAttrib3 = simData.mapAttributeToMeshAttrib(sim, attributeTypeForColor);
        int attributeByIndex = simData.getSimAttributeByIndex(sim, attributeTypeForColor);
        return attributeByIndex != -1 ? this.getSimTextureIdCount(meshAttrib3, attributeByIndex) : 1;
      case 4:
        return this.getSimTextureIdCount(0, 0) + (builtInOnly ? 0 : instance.getSimTextureIdCount(0, 0));
      default:
        return 0;
    }
  }

  public int getSimMeshUserIdCount(int attribId)
  {
    return attribId == 0 || attribId == 1 || attribId == 8 ? this.d_simAttribTextureIds[attribId][0].Length : this.d_simAttribUserIds[attribId].Length;
  }

  public int getSimMeshUserId(int attribId, int optIndex)
  {
    int uniquePackId = SimWorld.getUniquePackId(optIndex);
    int uniqueOffset = SimWorld.getUniqueOffset(optIndex);
    if (uniquePackId == 0)
      return (int) this.d_simAttribUserIds[attribId][uniqueOffset];
    DLCPack dlcPackByUniqueId = DLCManager.getInstance().getDLCPackByUniqueId(uniquePackId);
    return dlcPackByUniqueId != null ? (int) dlcPackByUniqueId.d_simAttribUserIds[attribId][uniqueOffset] : -1;
  }

  public string getSimMeshFilename(int attribId, int optIndex)
  {
    int uniquePackId = SimWorld.getUniquePackId(optIndex);
    if (uniquePackId == 0)
      return (string) null;
    bool flag = attribId == 4 || attribId == 3 || (attribId == 2 || attribId == 5) || attribId == 6 || attribId == 7;
    DLCPack dlcPackByUniqueId = DLCManager.getInstance().getDLCPackByUniqueId(uniquePackId);
    if (dlcPackByUniqueId == null)
      return (string) null;
    return !flag ? dlcPackByUniqueId.d_simFemaleFilename : dlcPackByUniqueId.d_simMaleFilename;
  }

  public int getSimMeshFlags(int attribId, int optIndex)
  {
    int uniquePackId = SimWorld.getUniquePackId(optIndex);
    int index = SimWorld.getUniqueOffset(optIndex);
    if (attribId == 0 || attribId == 1 || attribId == 8)
    {
      index = 0;
      if (uniquePackId == 16)
        uniquePackId = 0;
    }
    if (uniquePackId == 0)
      return this.d_simAttribFlags[attribId][index];
    DLCPack dlcPackByUniqueId = DLCManager.getInstance().getDLCPackByUniqueId(uniquePackId);
    return dlcPackByUniqueId != null ? dlcPackByUniqueId.d_simAttribFlags[attribId][index] : 0;
  }

  private int getSimTextureIdCount(int attribId, int optIndex)
  {
    int length = this.d_simAttribTextureIds[attribId].Length;
    return optIndex < length ? this.d_simAttribTextureIds[attribId][optIndex].Length : DLCManager.getInstance().getSimTextureIdCount(attribId, optIndex - length);
  }

  public string getSimTextureFilename(int attribId, int optIndex, int subOptIndex)
  {
    int uniquePackId = SimWorld.getUniquePackId(optIndex);
    int index1 = SimWorld.getUniqueOffset(optIndex);
    int index2 = subOptIndex;
    if (attribId == 0 || attribId == 1 || attribId == 8)
    {
      uniquePackId = SimWorld.getUniquePackId(subOptIndex);
      index1 = optIndex;
      index2 = SimWorld.getUniqueOffset(subOptIndex);
    }
    if (uniquePackId == 0)
    {
      int res_id = (int) this.d_simAttribTextureIds[attribId][index1][index2];
      return res_id == -1 ? (string) null : ResourceManager.ID_TO_FILENAME(res_id);
    }
    DLCPack dlcPackByUniqueId = DLCManager.getInstance().getDLCPackByUniqueId(uniquePackId);
    if (dlcPackByUniqueId == null)
      return (string) null;
    string str = dlcPackByUniqueId.d_simAttribTextureFilenames[attribId][index1][index2];
    return str == null || str.Length == 0 ? (string) null : str;
  }

  public int getSimOverrideType(int attribId, int optIndex, int overrideAttribId)
  {
    switch (attribId)
    {
      case 0:
        if ((this.getSimMeshFlags(attribId, optIndex) & 32) != 0)
        {
          switch (SimWorld.getUniqueOffset(optIndex))
          {
            case 0:
              return 1;
            case 1:
              return 3;
            case 2:
              return 0;
            default:
              return 0;
          }
        }
        else
          break;
      case 3:
      case 10:
        int simMeshFlags = this.getSimMeshFlags(attribId, optIndex);
        if ((simMeshFlags & 8) == 0 && (simMeshFlags & 16) == 0)
          return -1;
        int packOffsetId = (simMeshFlags & 8) != 0 ? 0 : 1;
        int uniquePackId = SimWorld.getUniquePackId(optIndex);
        return uniquePackId == 0 ? 0 : SimWorld.getUniqueId(uniquePackId, packOffsetId);
    }
    return -1;
  }

  public static int getUniqueId(int uniquePackId, int packOffsetId)
  {
    return uniquePackId << 8 | packOffsetId;
  }

  public static int getUniquePackId(int uniqueOptIndex)
  {
    return uniqueOptIndex >> 8;
  }

  public static int getUniqueOffset(int uniqueOptIndex)
  {
    return uniqueOptIndex & (int) byte.MaxValue;
  }

  public int getSimMeshUniqueId(int attribId, int optIndex)
  {
    DLCManager instance = DLCManager.getInstance();
    switch (attribId)
    {
      case 0:
      case 1:
      case 8:
        int length1 = this.d_simAttribTextureIds[attribId][0].Length;
        if (optIndex < length1)
          return optIndex;
        int simMeshPackId1 = instance.getSimMeshPackId(attribId, optIndex - length1, false);
        return SimWorld.getUniqueId(instance.getDLCPackUniqudId(simMeshPackId1), instance.getSimMeshPackId(attribId, optIndex - length1, true));
      case 2:
      case 3:
      case 5:
      case 6:
      case 7:
      case 9:
      case 10:
      case 12:
      case 13:
      case 14:
        int length2 = this.d_simAttribUserIds[attribId].Length;
        if (optIndex < length2)
          return optIndex;
        int simMeshPackId2 = instance.getSimMeshPackId(attribId, optIndex - length2, false);
        return SimWorld.getUniqueId(instance.getDLCPackUniqudId(simMeshPackId2), instance.getSimMeshPackId(attribId, optIndex - length2, true));
      default:
        return 0;
    }
  }

  public int getSimMeshLocalId(int attribId, int meshUniqueId)
  {
    DLCManager instance = DLCManager.getInstance();
    int uniquePackId = SimWorld.getUniquePackId(meshUniqueId);
    int uniqueOffset = SimWorld.getUniqueOffset(meshUniqueId);
    if (uniquePackId == 0)
      return uniqueOffset;
    int packIdByUniqueId = instance.getPackIdByUniqueId(uniquePackId);
    if (packIdByUniqueId == -1)
      return -1;
    int simAttribIdLocal = instance.getSimAttribIdLocal(attribId, packIdByUniqueId, uniqueOffset);
    return this.getSimMeshUserIdCount(attribId) + simAttribIdLocal;
  }

  public int mapSubAppearance(int sub)
  {
    if (sub < 0)
    {
      int num = this.m_engine.randPercent();
      switch (sub)
      {
        case -5:
          sub = num < 33 ? 72 : (num < 66 ? 73 : 74);
          break;
        case -4:
          sub = num < 50 ? 12 : 13;
          break;
        case -3:
          sub = num < 50 ? 9 : 10;
          break;
        case -2:
          sub = num >= 25 ? (num >= 50 ? (num >= 75 ? 8 : 7) : 6) : 5;
          break;
      }
    }
    return sub;
  }

  public int getSubAppearanceAnim3D(int appearance, int sub)
  {
    short[] appearanceAnim3D = this.d_appearanceAnim3Ds[appearance];
    return sub >= appearanceAnim3D.Length ? (int) appearanceAnim3D[0] : (int) appearanceAnim3D[sub];
  }

  private int getFurnitureExcludeFlags()
  {
    switch (this.getSimData().getFurnitureStage())
    {
      case 0:
        return 201326592;
      case 1:
        return 134217728;
      case 2:
        return 0;
      default:
        AppEngine.ASSERT(false, "invalid furniture stage");
        return -1;
    }
  }

  public int getFurnitureCountOfCategory(int category)
  {
    int objectCount = this.getObjectCount();
    int num = 0;
    for (int type = 0; type < objectCount; ++type)
    {
      if (this.getObjectCategory(type) == category)
        ++num;
    }
    return num;
  }

  public int getFurnitureNthItemOfCategory(int index, int category)
  {
    int objectCountBuiltIn = this.getObjectCountBuiltIn();
    int objectCount = this.getObjectCount();
    int num1 = objectCount - objectCountBuiltIn;
    int num2 = index;
    for (int index1 = 0; index1 < objectCount; ++index1)
    {
      int type = index1 < num1 ? objectCountBuiltIn + index1 : index1 - num1;
      if (this.getObjectCategory(type) == category)
      {
        if (num2 == 0)
          return type;
        --num2;
      }
    }
    return -1;
  }

  public int getFloorCount()
  {
    return this.d_floorTexCoords.Length;
  }

  public int getFloorStringId(int floorType)
  {
    return (int) this.d_floorStringIds[floorType];
  }

  public int[] getFloorTexCoords(int floorType)
  {
    return this.d_floorTexCoords[floorType];
  }

  public int getWallCount()
  {
    return this.d_wallTexCoords.Length - 1;
  }

  public int getWallStringId(int wallType)
  {
    return (int) this.d_wallStringIds[wallType];
  }

  public int[] getWallTexCoords(int wallType)
  {
    return this.d_wallTexCoords[wallType];
  }

  public void unlockFloor(int floorId)
  {
    this.unlockFloor(floorId, -1);
  }

  public void unlockFloor(int floorId, int packId)
  {
    if (this.m_unlockedFloorIds.Length == 0)
    {
      this.m_unlockedFloorIds = new short[this.d_floorStringIds.Length];
      AppEngine.fillArray(this.m_unlockedFloorIds, (short) -1);
      this.m_unlockedFloorPackIds = new short[this.d_floorStringIds.Length];
      AppEngine.fillArray(this.m_unlockedFloorPackIds, (short) -1);
    }
    if (AppEngine.indexOf((short) floorId, this.m_unlockedFloorIds) != -1)
      return;
    int index = AppEngine.indexOf((short) -1, this.m_unlockedFloorIds);
    this.m_unlockedFloorIds[index] = (short) floorId;
    this.m_unlockedFloorPackIds[index] = (short) packId;
  }

  public int getUnlockedFloorIndex(int floorId)
  {
    return AppEngine.indexOf((short) floorId, this.m_unlockedFloorIds);
  }

  public int getUnlockedFloorNthCount()
  {
    return this.m_unlockedFloorIds.Length - AppEngine.countOf(-1, this.m_unlockedFloorIds);
  }

  public int getUnlockedFloorNthId(int index)
  {
    return (int) this.m_unlockedFloorIds[index];
  }

  public int getFloorPackId(int floorId)
  {
    int index = AppEngine.indexOf((short) floorId, this.m_unlockedFloorIds);
    return index != -1 ? (int) this.m_unlockedFloorPackIds[index] : -1;
  }

  public void unlockWall(int wallId)
  {
    this.unlockWall(wallId, -1);
  }

  public void unlockWall(int wallId, int packId)
  {
    if (this.m_unlockedWallIds.Length == 0)
    {
      this.m_unlockedWallIds = new short[this.d_wallStringIds.Length];
      AppEngine.fillArray(this.m_unlockedWallIds, (short) -1);
      this.m_unlockedWallPackIds = new short[this.d_wallStringIds.Length];
      AppEngine.fillArray(this.m_unlockedWallPackIds, (short) -1);
    }
    if (AppEngine.indexOf((short) wallId, this.m_unlockedWallIds) != -1)
      return;
    int index = AppEngine.indexOf((short) -1, this.m_unlockedWallIds);
    this.m_unlockedWallIds[index] = (short) wallId;
    this.m_unlockedWallPackIds[index] = (short) packId;
  }

  public int getUnlockedWallIndex(int wallId)
  {
    return AppEngine.indexOf((short) wallId, this.m_unlockedWallIds);
  }

  public int getUnlockedWallNthCount()
  {
    return this.m_unlockedWallIds.Length - AppEngine.countOf(-1, this.m_unlockedWallIds);
  }

  public int getUnlockedWallNthId(int index)
  {
    return (int) this.m_unlockedWallIds[index];
  }

  public int getWallPackId(int wallId)
  {
    int index = AppEngine.indexOf((short) wallId, this.m_unlockedWallIds);
    return index != -1 ? (int) this.m_unlockedWallPackIds[index] : -1;
  }

  public int getItemCountLegacy()
  {
    return SimWorld.LEGACY_LOOKUP_ITEM.Length;
  }

  public int getItemIdLegacy(int itemId)
  {
    string strA = SimWorld.LEGACY_LOOKUP_ITEM[itemId];
    int itemCountBuiltIn = this.getItemCountBuiltIn();
    for (int index = 0; index < itemCountBuiltIn; ++index)
    {
      string strB = GlobalConstants.LOOKUP_ITEM[index];
      if (string.Compare(strA, strB) == 0)
        return index;
    }
    return string.Compare(strA, "CAR") == 0 ? 34 : -1;
  }

  public int getItemCount()
  {
    return this.d_itemRecordsBuiltIn.Length + DLCManager.getInstance().getDLCItemCount();
  }

  public int getItemCountBuiltIn()
  {
    return this.d_itemRecordsBuiltIn.Length;
  }

  public RecItem getItemRecord(int itemId)
  {
    return itemId < this.d_itemRecordsBuiltIn.Length ? this.d_itemRecordsBuiltIn[itemId] : DLCManager.getInstance().getDLCItemRecord(itemId - this.d_itemRecordsBuiltIn.Length);
  }

  public int getItemDescString(int item)
  {
    return this.getItemRecord(item).m_descStringId;
  }

  public int getItemIcon(int item)
  {
    return (int) this.getItemRecord(item).m_icon;
  }

  public int getItemFlags(int item)
  {
    return this.getItemRecord(item).m_flags;
  }

  public int getItemMaxInventory(int item)
  {
    return (int) this.getItemRecord(item).m_maxInventory;
  }

  public int getItemBuyPrice(int item)
  {
    return (int) this.getItemRecord(item).m_buyPrice;
  }

  public int getItemSellPrice(int item)
  {
    return (int) this.getItemRecord(item).m_sellPrice;
  }

  public int getItemPackId(int item)
  {
    return (int) this.getItemRecord(item).m_packId;
  }

  public string getItemCarModel(int itemId)
  {
    int packId = (int) this.getItemRecord(itemId).m_packId;
    if (packId != -1)
      return DLCManager.getInstance().getMiniCarModelFilename(packId);
    switch (itemId)
    {
      case 34:
        return ResourceManager.ID_TO_FILENAME(295);
      case 35:
        return ResourceManager.ID_TO_FILENAME(293);
      case 36:
        return ResourceManager.ID_TO_FILENAME(294);
      case 37:
        return ResourceManager.ID_TO_FILENAME(296);
      default:
        return (string) null;
    }
  }

  public string getItemCarTexture(int itemId)
  {
    if (this.getItemRecord(itemId).m_packId != (short) -1)
      return (string) null;
    switch (itemId)
    {
      case 34:
        return ResourceManager.ID_TO_FILENAME(253);
      case 35:
        return ResourceManager.ID_TO_FILENAME(250);
      case 36:
        return ResourceManager.ID_TO_FILENAME(252);
      case 37:
        return ResourceManager.ID_TO_FILENAME(251);
      default:
        return (string) null;
    }
  }

  public int getItemCarObject(int itemId)
  {
    switch (itemId)
    {
      case 34:
        return 159;
      case 35:
        return 160;
      case 36:
        return 161;
      case 37:
        return 162;
      default:
        return itemId >= this.getItemCountBuiltIn() ? this.getObjectCountBuiltIn() + DLCManager.getInstance().getDLCItemCarObject(itemId - this.getItemCountBuiltIn()) : 159;
    }
  }

  public int getItemByName(int name)
  {
    int itemCount = this.getItemCount();
    for (int index = 0; index < itemCount; ++index)
    {
      if (this.getItemDescString(index) == name)
        return index;
    }
    return -1;
  }

  private int getShopFlags(int objectType)
  {
    int num = 0;
    switch (objectType)
    {
      case 152:
        num = 64;
        break;
      case 153:
        num = 8;
        break;
      case 155:
        num = 16;
        break;
      case 156:
        num = 32;
        break;
      case 158:
        num = 128;
        break;
      default:
        AppEngine.ASSERT(false, "unknown shop item");
        break;
    }
    return num;
  }

  public int getItemNthCount(int store)
  {
    int shopFlags = this.getShopFlags(store);
    int itemCount = this.getItemCount();
    int num = 0;
    for (int index = 0; index < itemCount; ++index)
    {
      if ((this.getItemFlags(index) & shopFlags) != 0)
        ++num;
    }
    return num;
  }

  public int getItemNthItem(int store, int index)
  {
    int shopFlags = this.getShopFlags(store);
    int itemCount = this.getItemCount();
    int num = 0;
    for (int index1 = 0; index1 < itemCount; ++index1)
    {
      if ((this.getItemFlags(index1) & shopFlags) != 0)
      {
        if (index == num)
          return index1;
        ++num;
      }
    }
    return num;
  }

  public string getItemSpywareId(int itemId)
  {
    if (itemId < this.getItemCountBuiltIn())
      return GlobalConstants.LOOKUP_ITEM[itemId];
    DLCManager instance = DLCManager.getInstance();
    RecItem itemRecord = this.getItemRecord(itemId);
    string packName = instance.getPackName((int) itemRecord.m_packId);
    string str = string.Concat((object) itemRecord.m_index);
    StringBuffer stringBuffer = new StringBuffer();
    stringBuffer.append(packName).append("/").append(str);
    return stringBuffer.toString();
  }

  public int getRecipeCount()
  {
    return this.d_recipeItems.Length;
  }

  public int getRecipeReplenishes(int recipe)
  {
    return MathExt.Fmul((int) this.d_recipeReplenishes[recipe] << 16, 22937);
  }

  public int getRecipeItem(int recipe)
  {
    return (int) this.d_recipeItems[recipe];
  }

  public int getRecipeIngredientCount(int recipe)
  {
    return this.d_recipeIngredients[recipe].Length;
  }

  public int getRecipeIngredient(int recipe, int index)
  {
    return (int) this.d_recipeIngredients[recipe][index];
  }

  public int getRecipeForItem(int item)
  {
    return AppEngine.indexOf((sbyte) item, this.d_recipeItems);
  }

  public int getRecipeDesc(int recipe)
  {
    return this.getItemDescString((int) this.d_recipeItems[recipe]);
  }

  public int getRecipeByName(int stringId)
  {
    for (int recipe = 0; recipe < this.d_recipeItems.Length; ++recipe)
    {
      if (this.getRecipeDesc(recipe) == stringId)
        return recipe;
    }
    return -1;
  }

  public void pathClearAvoidTiles()
  {
    this.m_pathNumAvoidTiles = 0;
  }

  public void pathAddAvoidTile(int x, int y)
  {
    AppEngine.ASSERT(this.m_pathNumAvoidTiles < 10, "not enough avoid tile slots");
    int index = this.m_pathNumAvoidTiles << 1;
    this.m_pathAvoidTiles[index] = x;
    this.m_pathAvoidTiles[index + 1] = y;
    ++this.m_pathNumAvoidTiles;
  }

  public int[] pathFind(int sx, int sy, int dx, int dy, int flags)
  {
    AppEngine.timerBegin();
    this.pathReset();
    this.m_pathFlags = flags;
    this.m_pathStartX = this.coordWorldToWorldTileX(sx);
    this.m_pathStartY = this.coordWorldToWorldTileZ(sy);
    this.m_pathDestX = this.coordWorldToWorldTileX(dx);
    this.m_pathDestY = this.coordWorldToWorldTileZ(dy);
    if (!this.isWorldTileWalkable(this.m_pathStartX, this.m_pathStartY) || !this.isWorldTileWalkable(this.m_pathDestX, this.m_pathDestY))
    {
      AppEngine.timerEnd("pathfind");
      return new int[0];
    }
    this.m_pathOffsetX = this.m_pathStartX + this.m_pathDestX - 80 >> 1;
    this.m_pathOffsetY = this.m_pathStartY + this.m_pathDestY - 80 >> 1;
    int num1 = this.m_pathStartX - this.m_pathOffsetX;
    int num2 = this.m_pathStartY - this.m_pathOffsetY;
    if (num1 < 0 || num2 < 0 || (num1 >= 80 || num2 >= 80))
    {
      AppEngine.timerEnd("pathfind");
      return new int[0];
    }
    int num3 = this.m_pathDestX - this.m_pathOffsetX;
    int num4 = this.m_pathDestY - this.m_pathOffsetY;
    if (num3 < 0 || num4 < 0 || (num3 >= 80 || num4 >= 80))
    {
      AppEngine.timerEnd("pathfind");
      return new int[0];
    }
    this.pathAddToOpenList(this.m_pathStartX - this.m_pathOffsetX, this.m_pathStartY - this.m_pathOffsetY);
    bool flag = false;
    while (!flag)
    {
      int lowestF = this.pathFindLowestF();
      if (lowestF == -1)
      {
        AppEngine.timerEnd("pathfind");
        return new int[0];
      }
      int num5 = (int) this.m_pathOpenList[lowestF] & (int) byte.MaxValue;
      int num6 = ((int) this.m_pathOpenList[lowestF] & 65280) >> 8;
      int num7 = this.PATH_FIND_OFFSETS.Length >> 2;
      for (int index1 = 0; index1 < num7; ++index1)
      {
        int index2 = index1 << 2;
        int num8 = this.PATH_FIND_OFFSETS[index2];
        int num9 = this.PATH_FIND_OFFSETS[index2 + 1];
        int num10 = this.PATH_FIND_OFFSETS[index2 + 2];
        int num11 = this.PATH_FIND_OFFSETS[index2 + 3];
        int rx = num5 + num8;
        int ry = num6 + num9;
        int attribute = this.getAttribute(this.m_pathOffsetX + num5, this.m_pathOffsetY + num6);
        if ((this.getAttribute(this.m_pathOffsetX + rx, this.m_pathOffsetY + ry) & num11) == 0 && (attribute & num10) == 0 && !this.pathIsClosed(rx, ry))
        {
          if (this.pathAddToOpenList(rx, ry))
          {
            this.pathSetParent(rx, ry, num5, num6);
            this.pathCalculateGCost(rx, ry);
            this.pathCalculateHCost(rx, ry);
            this.pathCalculateFCost(rx, ry);
          }
          else if (this.pathBetterGCost(rx, ry, num5, num6))
          {
            this.pathSetParent(rx, ry, num5, num6);
            this.pathCalculateGCost(rx, ry);
            this.pathCalculateFCost(rx, ry);
          }
        }
      }
      this.pathSwitchToClosedList(lowestF);
      if (num5 == this.m_pathDestX - this.m_pathOffsetX && num6 == this.m_pathDestY - this.m_pathOffsetY)
        flag = true;
    }
    int num12 = int.MaxValue;
    int num13 = int.MaxValue;
    int index3 = this.m_pathDestX - this.m_pathOffsetX;
    int index4 = this.m_pathDestY - this.m_pathOffsetY;
    int num14 = this.m_pathStartX - this.m_pathOffsetX;
    int num15 = this.m_pathStartY - this.m_pathOffsetY;
    int index5 = 0;
    int num16;
    for (; index3 >= 0 && index4 >= 0 && (index3 < 80 && index4 < 80) && ((index3 != num14 || index4 != num15) && (num12 != index3 || num13 != index4)); index4 = (num16 & 65280) >> 8)
    {
      num16 = (int) this.m_pathParentArray[index3][index4];
      if (num16 != -1)
      {
        this.m_pathList[index5] = (short) (index3 | index4 << 8);
        ++index5;
        num12 = index3;
        num13 = index4;
        index3 = num16 & (int) byte.MaxValue;
      }
      else
        break;
    }
    int[] numArray = new int[index5 << 1];
    for (int index1 = 0; index1 < index5; ++index1)
    {
      int index2 = index5 - index1 - 1;
      int x = ((int) this.m_pathList[index2] & (int) byte.MaxValue) + this.m_pathOffsetX;
      int z = (((int) this.m_pathList[index2] & 65280) >> 8) + this.m_pathOffsetY;
      numArray[index1 << 1] = this.coordWorldTileToWorldCenterX(x);
      numArray[(index1 << 1) + 1] = this.coordWorldTileToWorldCenterZ(z);
    }
    AppEngine.timerEnd("pathfind");
    return numArray;
  }

  private void pathInit()
  {
    if (this.m_pathOpenList != null)
      return;
    this.m_pathOpenList = new short[6400];
    this.m_pathOpenCount = 0;
    this.m_pathClosedList = new short[6400];
    this.m_pathClosedCount = 0;
    this.m_pathParentArray = new short[80][];
    for (int index = 0; index < this.m_pathParentArray.Length; ++index)
      this.m_pathParentArray[index] = new short[80];
    this.m_pathGCost = new int[80][];
    for (int index = 0; index < this.m_pathGCost.Length; ++index)
      this.m_pathGCost[index] = new int[80];
    this.m_pathFCost = new int[80][];
    for (int index = 0; index < this.m_pathFCost.Length; ++index)
      this.m_pathFCost[index] = new int[80];
    this.m_pathHCost = new int[80][];
    for (int index = 0; index < this.m_pathHCost.Length; ++index)
      this.m_pathHCost[index] = new int[80];
    this.m_pathList = new short[1600];
    this.m_pathNumAvoidTiles = 0;
    this.m_pathAvoidTiles = new int[20];
  }

  private bool pathAddToOpenList(int rx, int ry)
  {
    short num = (short) (rx | ry << 8);
    for (int index = 0; index < this.m_pathOpenCount; ++index)
    {
      if ((int) this.m_pathOpenList[index] == (int) num)
        return false;
    }
    this.m_pathOpenList[this.m_pathOpenCount] = num;
    ++this.m_pathOpenCount;
    return true;
  }

  private void pathSwitchToClosedList(int index)
  {
    this.m_pathClosedList[this.m_pathClosedCount] = this.m_pathOpenList[index];
    ++this.m_pathClosedCount;
    for (int index1 = index; index1 < this.m_pathOpenCount - 1; ++index1)
      this.m_pathOpenList[index1] = this.m_pathOpenList[index1 + 1];
    --this.m_pathOpenCount;
  }

  private void pathSetParent(int rx, int ry, int parentx, int parenty)
  {
    AppEngine.ASSERT(rx >= 0 && ry >= 0 && rx < 80 && ry < 80, "pathSetParent: rx, ry off pathfind");
    this.m_pathParentArray[rx][ry] = (short) (parentx | parenty << 8);
  }

  private int pathTileGCost(int rx, int ry, int px, int py)
  {
    AppEngine.ASSERT(rx >= 0 && ry >= 0 && rx < 80 && ry < 80, "pathTileGCost: rx, ry off pathfind");
    int num1 = 200;
    int num2 = 0;
    int attribute1 = this.getAttribute(rx + this.m_pathOffsetX, ry + this.m_pathOffsetY);
    int num3 = px - rx;
    int num4 = py - ry;
    if (num3 != 0 && num4 != 0)
    {
      if ((this.m_pathFlags & 4) != 0)
      {
        int attribute2 = this.getAttribute(px + this.m_pathOffsetX, py + this.m_pathOffsetY);
        num1 = (attribute1 & 8192) != 0 || (attribute2 & 8192) != 0 ? 300 : 500;
      }
      else
        num1 = 300;
    }
    if ((attribute1 & 64) != 0)
    {
      if ((this.m_pathFlags & 6) != 0)
      {
        int num5 = -150;
        if ((attribute1 & 8192) == 0)
        {
          if (num3 > 0 || num4 > 0)
            num5 = (attribute1 & 128) != 0 ? -150 : 150;
          else if (num3 < 0 || num4 < 0)
            num5 = (attribute1 & 128) != 0 ? 150 : -150;
        }
        num2 += num5;
      }
      else if ((this.m_pathFlags & 8) != 0)
        num2 += 150;
    }
    else if ((attribute1 & 32) != 0)
    {
      if ((this.m_pathFlags & 6) != 0)
        num2 += 150;
      else if ((this.m_pathFlags & 8) != 0)
        num2 += -50;
    }
    if ((this.m_pathFlags & 1) != 0)
    {
      for (int index1 = 0; index1 < this.m_pathNumAvoidTiles; ++index1)
      {
        int index2 = index1 << 1;
        if (rx + this.m_pathOffsetX == this.m_pathAvoidTiles[index2] && ry + this.m_pathOffsetY == this.m_pathAvoidTiles[index2 + 1])
        {
          num2 += 500;
          break;
        }
      }
    }
    return num1 + num2;
  }

  private void pathCalculateGCost(int rx, int ry)
  {
    AppEngine.ASSERT(rx >= 0 && ry >= 0 && rx < 80 && ry < 80, "pathCalculateGCost: rx, ry off pathfind");
    int px = (int) this.m_pathParentArray[rx][ry] & (int) byte.MaxValue;
    int py = ((int) this.m_pathParentArray[rx][ry] & 65280) >> 8;
    AppEngine.ASSERT(px >= 0 && py >= 0 && px < 80 && py < 80, "pathCalculateGCost: parent off pathfind");
    int num = this.m_pathGCost[px][py];
    this.m_pathGCost[rx][ry] = num + this.pathTileGCost(rx, ry, px, py);
  }

  private bool pathBetterGCost(int rx, int ry, int cx, int cy)
  {
    AppEngine.ASSERT(rx >= 0 && ry >= 0 && (rx < 80 && ry < 80) && (cx >= 0 && cy >= 0 && cx < 80) && cy < 80, "pathBetterGCost: (rx, ry) or (cx, cy) off pathfind");
    int num = this.m_pathGCost[rx][ry];
    return this.m_pathGCost[cx][cy] + this.pathTileGCost(rx, ry, cx, cy) < num;
  }

  private void pathCalculateHCost(int rx, int ry)
  {
    AppEngine.ASSERT(rx >= 0 && ry >= 0 && rx < 80 && ry < 80, "pathCalculateHCost: rx, ry off pathfind");
    AppEngine.ASSERT(this.pathIsWalkable(rx, ry), "pathCalculateHCost: rx, ry non-walkable");
    int num1 = this.m_pathDestX - this.m_pathOffsetX - rx;
    int num2 = this.m_pathDestY - this.m_pathOffsetY - ry;
    this.m_pathHCost[rx][ry] = midp.JMath.sqrt(num1 * num1 + num2 * num2) * 200;
  }

  private void pathCalculateFCost(int rx, int ry)
  {
    AppEngine.ASSERT(rx >= 0 && ry >= 0 && rx < 80 && ry < 80, "pathCalculateFCost: rx, ry off pathfind");
    this.m_pathFCost[rx][ry] = this.m_pathHCost[rx][ry] + this.m_pathGCost[rx][ry];
  }

  private int pathFindLowestF()
  {
    int num1 = -1;
    int num2 = int.MaxValue;
    for (int index1 = 0; index1 < this.m_pathOpenCount; ++index1)
    {
      int index2 = (int) this.m_pathOpenList[index1] & (int) byte.MaxValue;
      int index3 = ((int) this.m_pathOpenList[index1] & 65280) >> 8;
      AppEngine.ASSERT(index2 >= 0 && index3 >= 0 && index2 < 80 && index3 < 80, "pathFindLowestF: open tile rx, ry off pathfind");
      int num3 = this.m_pathFCost[index2][index3];
      if (num2 > num3)
      {
        num2 = num3;
        num1 = index1;
      }
    }
    return num1;
  }

  private bool pathIsWalkable(int rx, int ry)
  {
    return this.isWorldTileWalkable(rx + this.m_pathOffsetX, ry + this.m_pathOffsetY);
  }

  private bool pathIsClosed(int rx, int ry)
  {
    if (rx < 0 || ry < 0 || (rx >= 80 || ry >= 80) || !this.pathIsWalkable(rx, ry))
      return true;
    int num = rx | ry << 8;
    for (int index = 0; index < this.m_pathClosedCount; ++index)
    {
      if (num == (int) this.m_pathClosedList[index])
        return true;
    }
    return false;
  }

  private void pathReset()
  {
    this.m_pathClosedCount = 0;
    this.m_pathOpenCount = 0;
    AppEngine.fillArray(this.m_pathParentArray, (short) 0);
    AppEngine.fillArray(this.m_pathGCost, 0);
    AppEngine.fillArray(this.m_pathFCost, 0);
    AppEngine.fillArray(this.m_pathHCost, 0);
  }

  public int getBuildableNthCount()
  {
    int num = 0;
    for (int index = 0; index < this.d_objectRecordsBuiltIn.Length; ++index)
    {
      if ((this.d_objectRecordsBuiltIn[index].m_flags & 1) == 0)
        ++num;
    }
    return num;
  }

  public int getBuildableNthObject(int index)
  {
    int num = 0;
    for (int index1 = 0; index1 < this.d_objectRecordsBuiltIn.Length; ++index1)
    {
      if ((this.d_objectRecordsBuiltIn[index1].m_flags & 1) == 0)
      {
        if (num == index)
          return index1;
        ++num;
      }
    }
    return -1;
  }

  public int getWindowTypeNthCount()
  {
    int num = 0;
    for (int index = 0; index < this.d_objectRecordsBuiltIn.Length; ++index)
    {
      if (this.d_objectRecordsBuiltIn[index].m_parent == (sbyte) 32)
        ++num;
    }
    return num;
  }

  public int getWindowTypeNthObject(int index)
  {
    int num = 0;
    for (int index1 = 0; index1 < this.d_objectRecordsBuiltIn.Length; ++index1)
    {
      if (this.d_objectRecordsBuiltIn[index1].m_parent == (sbyte) 32)
      {
        if (num == index)
          return index1;
        ++num;
      }
    }
    return -1;
  }

  public int getDoorTypeNthCount()
  {
    int num = 0;
    for (int index = 0; index < this.d_objectRecordsBuiltIn.Length; ++index)
    {
      if (this.d_objectRecordsBuiltIn[index].m_parent == (sbyte) 15)
        ++num;
    }
    return num;
  }

  public int getDoorTypeNthObject(int index)
  {
    int num = 0;
    for (int index1 = 0; index1 < this.d_objectRecordsBuiltIn.Length; ++index1)
    {
      if (this.d_objectRecordsBuiltIn[index1].m_parent == (sbyte) 15)
      {
        if (num == index)
          return index1;
        ++num;
      }
    }
    return -1;
  }

  public int getHouseCount()
  {
    return this.d_houseObjectXs.Length;
  }

  public int getObjectOfTypeIndexFromObjectArrayIndex(int objectClass, int objectArrayIndex)
  {
    int num = -1;
    for (int type = 0; type <= objectArrayIndex; ++type)
    {
      if (this.getObjectParent(type) == objectClass)
        ++num;
    }
    return num;
  }

  public int getBuildableObjectIndexFromObjectArrayIndex(int objectArrayIndex)
  {
    int num = -1;
    for (int type = 0; type <= objectArrayIndex; ++type)
    {
      if ((this.getObjectFlags(type) & 1) == 0)
        ++num;
    }
    return num;
  }

  public void editHouse(int houseId, House newHouse)
  {
    Vector rooms = newHouse.getRooms();
    int length1 = rooms.size();
    this.d_houseRoomXs[houseId] = new sbyte[length1];
    this.d_houseRoomYs[houseId] = new sbyte[length1];
    this.d_houseRoomWidths[houseId] = new sbyte[length1];
    this.d_houseRoomHeights[houseId] = new sbyte[length1];
    this.d_houseRoomFloors[houseId] = new sbyte[length1];
    this.d_houseRoomWalls[houseId] = new sbyte[length1];
    for (int index = 0; index < length1; ++index)
    {
      house.Room room = (house.Room) rooms.elementAt(index);
      this.d_houseRoomXs[houseId][index] = (sbyte) room.getX();
      this.d_houseRoomYs[houseId][index] = (sbyte) room.getY();
      this.d_houseRoomWidths[houseId][index] = (sbyte) room.getWidth();
      this.d_houseRoomHeights[houseId][index] = (sbyte) room.getHeight();
      this.d_houseRoomFloors[houseId][index] = (sbyte) room.getFloor();
      this.d_houseRoomWalls[houseId][index] = (sbyte) room.getWall();
    }
    Vector doors = newHouse.getDoors();
    int length2 = doors.size();
    this.d_houseDoorXs[houseId] = new sbyte[length2];
    this.d_houseDoorYs[houseId] = new sbyte[length2];
    this.d_houseDoorWidths[houseId] = new sbyte[length2];
    this.d_houseDoorTypes[houseId] = new short[length2];
    for (int index = 0; index < length2; ++index)
    {
      Door door = (Door) doors.elementAt(index);
      this.d_houseDoorXs[houseId][index] = (sbyte) door.getX();
      this.d_houseDoorYs[houseId][index] = (sbyte) door.getY();
      this.d_houseDoorWidths[houseId][index] = (sbyte) door.getWidth();
      this.d_houseDoorTypes[houseId][index] = (short) (sbyte) door.getType();
    }
    Vector windows = newHouse.getWindows();
    int length3 = windows.size();
    this.d_houseWindowXs[houseId] = new sbyte[length3];
    this.d_houseWindowYs[houseId] = new sbyte[length3];
    this.d_houseWindowWidths[houseId] = new sbyte[length3];
    this.d_houseWindowTypes[houseId] = new short[length3];
    for (int index = 0; index < length3; ++index)
    {
      Window window = (Window) windows.elementAt(index);
      this.d_houseWindowXs[houseId][index] = (sbyte) window.getX();
      this.d_houseWindowYs[houseId][index] = (sbyte) window.getY();
      this.d_houseWindowWidths[houseId][index] = (sbyte) window.getWidth();
      this.d_houseWindowTypes[houseId][index] = (short) (sbyte) window.getType();
    }
    Vector houseObjects = newHouse.getHouseObjects();
    int length4 = houseObjects.size();
    this.d_houseObjectXs[houseId] = new sbyte[length4];
    this.d_houseObjectZs[houseId] = new sbyte[length4];
    this.d_houseObjectTypes[houseId] = new short[length4];
    this.d_houseObjectFacingDirs[houseId] = new sbyte[length4];
    for (int index = 0; index < length4; ++index)
    {
      HouseObject houseObject = (HouseObject) houseObjects.elementAt(index);
      this.d_houseObjectXs[houseId][index] = (sbyte) houseObject.getX();
      this.d_houseObjectZs[houseId][index] = (sbyte) houseObject.getY();
      this.d_houseObjectTypes[houseId][index] = (short) (sbyte) houseObject.getType();
      this.d_houseObjectFacingDirs[houseId][index] = (sbyte) houseObject.getFacing();
    }
  }

  public House getHouse(int houseId)
  {
    House house = new House(GlobalConstants.LOOKUP_HOUSE[houseId], houseId);
    int length1 = this.d_houseRoomXs[houseId].Length;
    for (int index = 0; index < length1; ++index)
    {
      house.Room room = new house.Room((int) this.d_houseRoomXs[houseId][index], (int) this.d_houseRoomYs[houseId][index], (int) this.d_houseRoomWidths[houseId][index], (int) this.d_houseRoomHeights[houseId][index], (int) this.d_houseRoomFloors[houseId][index], (int) this.d_houseRoomWalls[houseId][index]);
      house.addRoom(room);
    }
    int length2 = this.d_houseDoorXs[houseId].Length;
    for (int index = 0; index < length2; ++index)
    {
      Door door = new Door((int) this.d_houseDoorXs[houseId][index], (int) this.d_houseDoorYs[houseId][index], midp.JMath.abs((int) this.d_houseDoorWidths[houseId][index]), (int) this.d_houseDoorTypes[houseId][index]);
      house.addDoor(door);
    }
    int length3 = this.d_houseWindowXs[houseId].Length;
    for (int index = 0; index < length3; ++index)
    {
      Window window = new Window((int) this.d_houseWindowXs[houseId][index], (int) this.d_houseWindowYs[houseId][index], midp.JMath.abs((int) this.d_houseWindowWidths[houseId][index]), (int) this.d_houseWindowTypes[houseId][index]);
      house.addWindow(window);
    }
    int length4 = this.d_houseObjectXs[houseId].Length;
    for (int index = 0; index < length4; ++index)
    {
      HouseObject @object = new HouseObject((int) this.d_houseObjectXs[houseId][index], (int) this.d_houseObjectZs[houseId][index], (int) this.d_houseObjectTypes[houseId][index], (int) this.d_houseObjectFacingDirs[houseId][index]);
      house.addHouseObject(@object);
    }
    return house;
  }

  public void prepareWorldHouse(int houseId)
  {
    AppEngine.timerBegin();
    if (houseId == 0)
      houseId = SimWorld.PLAYER_HOUSE_LIST[(int) this.m_playerHouseLevel];
    this.m_houseIndex = houseId;
    this.m_attribWidth = 64;
    this.m_attribHeight = 64;
    this.prepareWorld();
    this.prepareWorldHouse3D(houseId);
    this.createObjectsHouse(houseId);
    ModelManager.getInstance().setFogRange(800f, 1500f);
    this.calcDayNightTint();
    this.applyDayNightTint();
    AppEngine.timerEnd(nameof (prepareWorldHouse));
  }

  public int getRoomAt(int tileX, int tileZ)
  {
    return (this.getAttribute(tileX, tileZ) & 15) - 1;
  }

  public bool isFurnitureAvailable(int type)
  {
    int furnitureExcludeFlags = this.getFurnitureExcludeFlags();
    return (this.getObjectFlags(type) & furnitureExcludeFlags) == 0;
  }
}
