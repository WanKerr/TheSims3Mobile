// Decompiled with JetBrains decompiler
// Type: Room
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g;
using midp;

public class Room
{
  internal static readonly int[] ROOM_OFFSETS = new int[8]
  {
    -1,
    -1,
    0,
    -1,
    0,
    0,
    -1,
    0
  };
  internal static readonly int[] CONFIGURATIONS = new int[377]
  {
    1,
    0,
    0,
    0,
    1,
    1,
    1,
    1,
    1,
    0,
    0,
    1,
    0,
    0,
    1,
    0,
    0,
    1,
    1,
    1,
    1,
    1,
    1,
    0,
    0,
    0,
    0,
    0,
    1,
    0,
    1,
    1,
    1,
    1,
    0,
    1,
    1,
    0,
    0,
    0,
    0,
    0,
    1,
    1,
    1,
    1,
    1,
    0,
    0,
    1,
    1,
    0,
    1,
    2,
    0,
    0,
    1,
    1,
    1,
    1,
    1,
    1,
    0,
    1,
    0,
    0,
    1,
    2,
    0,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    0,
    0,
    0,
    0,
    1,
    2,
    1,
    1,
    1,
    1,
    0,
    1,
    1,
    1,
    0,
    1,
    0,
    0,
    2,
    1,
    1,
    1,
    1,
    1,
    0,
    1,
    1,
    0,
    1,
    1,
    2,
    0,
    0,
    0,
    1,
    1,
    2,
    2,
    1,
    2,
    1,
    1,
    1,
    0,
    2,
    0,
    0,
    1,
    1,
    2,
    2,
    1,
    2,
    1,
    0,
    1,
    1,
    2,
    1,
    0,
    0,
    1,
    2,
    2,
    2,
    1,
    1,
    1,
    2,
    2,
    0,
    1,
    0,
    0,
    1,
    2,
    2,
    2,
    1,
    1,
    1,
    0,
    2,
    2,
    1,
    1,
    0,
    0,
    1,
    2,
    2,
    2,
    1,
    0,
    1,
    2,
    2,
    1,
    1,
    0,
    0,
    1,
    2,
    2,
    2,
    1,
    1,
    2,
    0,
    1,
    0,
    1,
    1,
    0,
    2,
    1,
    2,
    2,
    1,
    1,
    0,
    2,
    1,
    0,
    1,
    1,
    0,
    2,
    1,
    2,
    2,
    1,
    1,
    1,
    2,
    3,
    0,
    0,
    1,
    1,
    2,
    2,
    1,
    2,
    0,
    1,
    1,
    3,
    2,
    0,
    0,
    1,
    1,
    2,
    2,
    1,
    2,
    0,
    3,
    1,
    1,
    2,
    1,
    0,
    0,
    1,
    2,
    2,
    2,
    1,
    0,
    1,
    2,
    2,
    3,
    1,
    0,
    0,
    1,
    2,
    2,
    2,
    1,
    0,
    1,
    3,
    2,
    2,
    1,
    1,
    0,
    0,
    1,
    2,
    2,
    2,
    0,
    3,
    1,
    2,
    2,
    1,
    1,
    0,
    0,
    1,
    2,
    2,
    2,
    0,
    1,
    2,
    3,
    1,
    0,
    1,
    1,
    0,
    2,
    1,
    2,
    2,
    0,
    1,
    3,
    2,
    1,
    0,
    1,
    1,
    0,
    2,
    1,
    2,
    2,
    0,
    0,
    1,
    2,
    3,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    0,
    2,
    3,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    2,
    0,
    3,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    2,
    3,
    0,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    2,
    3,
    4,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    0
  };
  internal static int CONFIGURATIONS_COUNT = Room.CONFIGURATIONS.Length / 13;
  internal readonly int[] WALL_ANGLES = new int[4]
  {
    -90,
    180,
    90,
    0
  };
  public const int TILE_TO_WORLD = 32;
  public const int WALL_WIDTH = 4;
  public const int BORDER_WIDTH = 16;
  public const int WALL_HEIGHT = 96;
  public const int WINDOW_HEIGHT_LOWER = 38;
  public const int WINDOW_HEIGHT_UPPPER = 80;
  public const int SHORT_WALL_HEIGHT = 12;
  internal const int CONFIGURATIONS_TOPOFFSET = 4;
  internal const int CONFIGURATIONS_WALLOFFSET = 8;
  internal const int CONFIGURATIONS_SUBDOWN = 12;
  internal const int CONFIGURATIONS_RECSIZE = 13;
  public const int WALL_X_POS = 0;
  public const int WALL_Z_POS = 1;
  public const int WALL_X_NEG = 2;
  public const int WALL_Z_NEG = 3;
  public const int NUM_WALLS = 4;
  public const int MAX_WALL_WINDOWS = 6;
  private const int SUBMESH_WALL_SHORT = 0;
  private const int SUBMESH_WALL_SHORT_TOP = 1;
  private const int SUBMESH_WALL_TALL = 2;
  private const int SUBMESH_WALL_OUTSIDE_SHORT = 3;
  private const int SUBMESH_WALL_OUTSIDE_SHORT_TOP = 4;
  private const int SUBMESH_WALL_OUTSIDE_TALL = 5;
  private const int SUBMESH_WALL_COUNT = 6;
  private const int SUBMESH_FLOOR = 24;
  private const int SUBMESH_COUNT = 25;
  private int m_posX;
  private int m_posZ;
  private int m_sizeX;
  private int m_sizeZ;
  private int m_floorType;
  private int m_wallType;
  private RoomCorner[] m_corners;
  private Group m_group;
  private Mesh m_compositeMesh;
  private int[] m_wallAlphasF8;
  private MapObject[][] m_wallWindows;
  private Appearance m_appWallAlpha;
  private Appearance m_appWallReplace;
  private int m_dayNightTint;
  private int m_lightCount;
  private int m_simCount;

  public Room()
  {
    this.m_posX = 0;
    this.m_posZ = 0;
    this.m_sizeX = 0;
    this.m_sizeZ = 0;
    this.m_floorType = -1;
    this.m_wallType = -1;
    this.m_corners = new RoomCorner[4];
    this.m_group = (Group) null;
    this.m_compositeMesh = (Mesh) null;
    this.m_wallAlphasF8 = new int[4];
    this.m_wallWindows = new MapObject[4][];
    this.m_appWallAlpha = (Appearance) null;
    this.m_appWallReplace = (Appearance) null;
    this.m_dayNightTint = 16777215;
    this.m_lightCount = 0;
    this.m_simCount = 0;
  }

  public void Dispose()
  {
  }

  public void init(int x, int z, int w, int h, int floorType, int wallType)
  {
    this.m_posX = x;
    this.m_posZ = z;
    this.m_sizeX = w;
    this.m_sizeZ = h;
    this.m_floorType = floorType;
    this.m_wallType = wallType;
    SimWorld simWorld = AppEngine.getCanvas().getSimWorld();
    this.m_corners[0] = simWorld.createCorner(x, z);
    this.m_corners[1] = simWorld.createCorner(x + w, z);
    this.m_corners[2] = simWorld.createCorner(x + w, z + h);
    this.m_corners[3] = simWorld.createCorner(x, z + h);
  }

  public void createGeometry()
  {
    ModelManager instance = ModelManager.getInstance();
    Appearance appearance1 = instance.getAppearance(0);
    Appearance appearance2 = instance.getAppearance(1);
    this.m_appWallAlpha = instance.getAppearance(2);
    this.m_appWallReplace = appearance2;
    SimWorld simWorld = AppEngine.getCanvas().getSimWorld();
    int length1 = JMath.min(6, this.m_sizeX >> 1);
    int length2 = JMath.min(6, this.m_sizeZ >> 1);
    this.m_wallWindows[0] = new MapObject[length1];
    this.m_wallWindows[2] = new MapObject[length1];
    this.m_wallWindows[1] = new MapObject[length2];
    this.m_wallWindows[3] = new MapObject[length2];
    for (int index = 0; index <= this.m_sizeX; ++index)
    {
      int tileX = this.m_posX + index;
      int posZ = this.m_posZ;
      AppEngine.appendUnique(simWorld.registerWall(this, 0, tileX, posZ), this.m_wallWindows[0], (MapObject) null);
      int tileZ = this.m_posZ + this.m_sizeZ;
      AppEngine.appendUnique(simWorld.registerWall(this, 2, tileX, tileZ), this.m_wallWindows[2], (MapObject) null);
    }
    for (int index = 0; index <= this.m_sizeZ; ++index)
    {
      int tileZ = this.m_posZ + index;
      int posX = this.m_posX;
      AppEngine.appendUnique(simWorld.registerWall(this, 3, posX, tileZ), this.m_wallWindows[3], (MapObject) null);
      int tileX = this.m_posX + this.m_sizeX;
      AppEngine.appendUnique(simWorld.registerWall(this, 1, tileX, tileZ), this.m_wallWindows[1], (MapObject) null);
    }
    GeomStrip[] geomStripArray = new GeomStrip[25];
    for (int index = 0; index < geomStripArray.Length; ++index)
      geomStripArray[index] = new GeomStrip();
    GeomStrip geomStrip1 = geomStripArray[24];
    this.m_group = new Group();
    int[] floorTexCoords = simWorld.getFloorTexCoords(this.m_floorType);
    int[] wallTexCoords1 = simWorld.getWallTexCoords(this.m_wallType);
    int[] wallTexCoords2 = simWorld.getWallTexCoords(46);
    int[] wallTexCoords3 = simWorld.getWallTexCoords(27);
    int panelX1 = this.m_posX * 32;
    int panelZ1 = this.m_posZ * 32;
    int panelW1 = this.m_sizeX * 32;
    int panelH1 = this.m_sizeZ * 32;
    int num1 = 18;
    geomStrip1.addFloor(panelX1, panelZ1, panelW1, panelH1, floorTexCoords, num1, num1, num1, num1);
    geomStrip1.addFloor(panelX1, panelZ1, 32, 32, floorTexCoords, 2, 14, 2, 14, 5);
    geomStrip1.addFloor(panelX1, panelZ1, panelW1, 32, floorTexCoords, 18, 18, 2, 14, 4);
    geomStrip1.addFloor(panelX1 + panelW1 - 32, panelZ1, 32, 32, floorTexCoords, 14, 2, 2, 14, 6);
    geomStrip1.addFloor(panelX1 + panelW1 - 32, panelZ1, 32, panelH1, floorTexCoords, 14, 2, 18, 18, 2);
    geomStrip1.addFloor(panelX1 + panelW1 - 32, panelZ1 + panelH1 - 32, 32, 32, floorTexCoords, 14, 2, 14, 2, 10);
    geomStrip1.addFloor(panelX1, panelZ1 + panelH1 - 32, panelW1, 32, floorTexCoords, 18, 18, 14, 2, 8);
    geomStrip1.addFloor(panelX1, panelZ1 + panelH1 - 32, 32, 32, floorTexCoords, 2, 14, 14, 2, 9);
    geomStrip1.addFloor(panelX1, panelZ1, 32, panelH1, floorTexCoords, 2, 14, 18, 18, 1);
    for (int index1 = 0; index1 < 4; ++index1)
    {
      int index2 = index1 * 6;
      GeomStrip geomStrip2 = geomStripArray[index2 + 2];
      GeomStrip geomStrip3 = geomStripArray[index2];
      GeomStrip geomStrip4 = geomStripArray[index2 + 1];
      GeomStrip geomStrip5 = geomStripArray[index2 + 5];
      GeomStrip geomStrip6 = geomStripArray[index2 + 3];
      GeomStrip geomStrip7 = geomStripArray[index2 + 4];
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      int num6 = 0;
      GeomStrip.Dir dir1 = GeomStrip.Dir.DIR_X_POS;
      int num7 = 0;
      int num8 = 0;
      GeomStrip.Dir dir2 = GeomStrip.Dir.DIR_X_POS;
      switch (index1)
      {
        case 0:
          num2 = this.m_posX;
          num3 = this.m_posZ;
          num6 = this.m_sizeX;
          dir1 = GeomStrip.Dir.DIR_X_POS;
          num7 = 1;
          num4 = this.m_posX * 32;
          num5 = this.m_posZ * 32 + 2;
          dir2 = GeomStrip.Dir.DIR_X_NEG;
          break;
        case 1:
          num2 = this.m_posX + this.m_sizeX;
          num3 = this.m_posZ;
          num6 = this.m_sizeZ;
          dir1 = GeomStrip.Dir.DIR_Z_POS;
          num8 = 1;
          num4 = this.m_posX * 32 + this.m_sizeX * 32 - 2;
          num5 = this.m_posZ * 32;
          dir2 = GeomStrip.Dir.DIR_Z_NEG;
          break;
        case 2:
          num2 = this.m_posX + this.m_sizeX - 1;
          num3 = this.m_posZ + this.m_sizeZ;
          num6 = this.m_sizeX;
          dir1 = GeomStrip.Dir.DIR_X_NEG;
          num7 = -1;
          num4 = this.m_posX * 32 + this.m_sizeX * 32;
          num5 = this.m_posZ * 32 + this.m_sizeZ * 32 - 2;
          dir2 = GeomStrip.Dir.DIR_X_POS;
          break;
        case 3:
          num2 = this.m_posX;
          num3 = this.m_posZ + this.m_sizeZ - 1;
          num6 = this.m_sizeZ;
          dir1 = GeomStrip.Dir.DIR_Z_NEG;
          num8 = -1;
          num4 = this.m_posX * 32 + 2;
          num5 = this.m_posZ * 32 + this.m_sizeZ * 32;
          dir2 = GeomStrip.Dir.DIR_Z_POS;
          break;
      }
      int num9 = -num8;
      int num10 = num7;
      int tileX = num2;
      int tileZ = num3;
      int panelX2 = num4;
      int panelZ2 = num5;
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      bool flag5 = false;
      bool flag6 = false;
      bool flag7 = false;
      bool flag8 = false;
      int num11 = 0;
      int num12 = 0;
      int panelW2 = 0;
      int num13 = 0;
      int num14 = 0;
      int num15 = 0;
      int num16 = 0;
      int num17 = 0;
      int panelW3 = 0;
      for (int index3 = 0; index3 < num6; ++index3)
      {
        int attribute = simWorld.getAttribute(tileX, tileZ);
        bool flag9 = (attribute & 3840) != 0;
        bool flag10 = (attribute & 64) != 0;
        bool flag11 = !flag10 && (attribute & 32) != 0;
        bool flag12 = (attribute & 128) != 0;
        bool flag13 = (simWorld.getAttribute(tileX - num9, tileZ - num10) & 16) == 0;
        bool flag14 = flag9 && flag13;
        if (flag9 && !flag1 || (flag5 || flag4))
        {
          num11 = panelX2;
          num12 = panelZ2;
          panelW2 = 0;
        }
        if (!flag9 && flag1)
        {
          num13 = panelX2;
          num14 = panelZ2;
          num15 = 0;
        }
        if (flag14 && !flag2 || (flag5 || flag4))
        {
          num16 = panelX2;
          num17 = panelZ2;
          panelW3 = 0;
          flag6 = flag3;
          flag7 = flag4;
          flag8 = flag5;
        }
        if (flag9)
          panelW2 += 32;
        else
          num15 += 32;
        if (flag14)
          panelW3 += 32;
        if (flag10)
        {
          geomStrip2.addDoorWall(panelX2, panelZ2, 32, dir1, wallTexCoords1, 0, 0);
          geomStrip2.addTallWallTop(panelX2, panelZ2, 32, dir1, wallTexCoords2, 0, 0);
          if (flag13)
          {
            int num18 = num16 + num7 * panelW3 - num9 * 4;
            int num19 = num17 + num8 * panelW3 - num10 * 4;
            int panelX3 = num18 + num7 * 32;
            int panelZ3 = num19 + num8 * 32;
            geomStrip5.addDoorWall(panelX3, panelZ3, 32, dir2, wallTexCoords3, 0, 0);
            geomStrip5.addTallWallTop(panelX3, panelZ3, 32, dir2, wallTexCoords2, 0, 0);
          }
        }
        if (panelW2 > 0 && (flag12 && flag9 || !flag9 && flag1 || index3 == num6 - 1))
        {
          int panelX3 = num11;
          int panelZ3 = num12;
          int flags = 0;
          int trimStart = 0;
          int trimEnd = 0;
          if (num11 == num4 && num12 == num5)
          {
            trimStart = 2;
            flags |= 1;
          }
          if (index3 == num6 - 1)
          {
            trimEnd = 2;
            flags |= 2;
          }
          if (flag12)
          {
            geomStrip2.addWindowWall(panelX2, panelZ2, 32, dir1, wallTexCoords1, 0, 0);
            geomStrip2.addTallWallTop(panelX2, panelZ2, 32, dir1, wallTexCoords2, 0, 0);
            geomStrip3.addShortWall(panelX2, panelZ2, 32, dir1, wallTexCoords1, 0, 0);
            geomStrip4.addShortWallTop(panelX2, panelZ2, 32, dir1, wallTexCoords2, 0, 0);
            panelW2 -= 32;
          }
          if (panelW2 > 0)
          {
            geomStrip2.addTallWall(panelX3, panelZ3, panelW2, dir1, wallTexCoords1, trimStart, trimEnd, flags);
            geomStrip2.addTallWallTop(panelX3, panelZ3, panelW2, dir1, wallTexCoords2, trimStart, trimEnd);
            geomStrip3.addShortWall(panelX3, panelZ3, panelW2, dir1, wallTexCoords1, trimStart, trimEnd, flags);
            geomStrip4.addShortWallTop(panelX3, panelZ3, panelW2, dir1, wallTexCoords2, trimStart, trimEnd);
            if (!flag8 && !flag7)
            {
              int panelX4 = panelX3 + num7 * trimStart;
              int panelZ4 = panelZ3 + num8 * trimStart;
              geomStrip2.addTallCap(panelX4, panelZ4, dir1, wallTexCoords2);
              geomStrip4.addShortCap(panelX4, panelZ4, dir1, wallTexCoords2);
            }
            if (!flag12 && !flag10)
            {
              int panelX4 = panelX3 + -num9 * 2 + num7 * (panelW2 - trimEnd);
              int panelZ4 = panelZ3 + -num10 * 2 + num8 * (panelW2 - trimEnd);
              geomStrip2.addTallCap(panelX4, panelZ4, dir2, wallTexCoords2);
              geomStrip4.addShortCap(panelX4, panelZ4, dir2, wallTexCoords2);
            }
          }
        }
        if (num15 > 0 && flag9 && !flag1)
        {
          int panelX3 = 0;
          int panelZ3 = 0;
          int panelW4 = 0;
          int panelH2 = 0;
          int trimStartX = 0;
          int trimEndX = 0;
          int trimStartZ = 0;
          int trimEndZ = 0;
          switch (dir1)
          {
            case GeomStrip.Dir.DIR_X_POS:
              panelX3 = num13;
              panelZ3 = num14 - 2;
              panelW4 = num15;
              panelH2 = 32;
              trimStartZ = 0;
              trimEndZ = 30;
              break;
            case GeomStrip.Dir.DIR_Z_POS:
              panelX3 = num13 - 32 + 2;
              panelZ3 = num14;
              panelW4 = 32;
              panelH2 = num15;
              trimStartX = 30;
              trimEndX = 0;
              break;
            case GeomStrip.Dir.DIR_X_NEG:
              panelX3 = num13 - num15;
              panelZ3 = num14 - 32 + 2;
              panelW4 = num15;
              panelH2 = 32;
              trimStartZ = 30;
              trimEndZ = 0;
              break;
            case GeomStrip.Dir.DIR_Z_NEG:
              panelX3 = num13 - 2;
              panelZ3 = num14 - num15;
              panelW4 = 32;
              panelH2 = num15;
              trimStartX = 0;
              trimEndX = 30;
              break;
          }
          geomStrip1.addFloor(panelX3, panelZ3, panelW4, panelH2, floorTexCoords, trimStartX, trimEndX, trimStartZ, trimEndZ, 15);
        }
        if (panelW3 > 0 && ((flag12 || flag10) && flag14 || (!flag14 && flag2 || flag14 && index3 == num6 - 1)))
        {
          int panelX3 = num16 + num7 * panelW3 - num9 * 4;
          int panelZ3 = num17 + num8 * panelW3 - num10 * 4;
          int trimEnd = flag6 || flag8 || flag7 ? 0 : 2;
          int trimStart = flag11 || flag12 || flag10 ? 0 : 2;
          if (flag12)
          {
            geomStrip5.addWindowWall(panelX3, panelZ3, 32, dir2, wallTexCoords3, 0, 0);
            geomStrip5.addTallWallTop(panelX3, panelZ3, 32, dir2, wallTexCoords2, 0, 0);
            geomStrip6.addShortWall(panelX3, panelZ3, 32, dir2, wallTexCoords3, 0, 0);
            geomStrip7.addShortWallTop(panelX3, panelZ3, 32, dir2, wallTexCoords2, 0, 0);
            panelW3 -= 32;
            panelX3 += -num7 * 32;
            panelZ3 += -num8 * 32;
          }
          if (panelW3 > 0)
          {
            geomStrip5.addTallWall(panelX3, panelZ3, panelW3, dir2, wallTexCoords3, trimStart, trimEnd);
            geomStrip5.addTallWallTop(panelX3, panelZ3, panelW3, dir2, wallTexCoords2, trimStart, trimEnd);
            geomStrip6.addShortWall(panelX3, panelZ3, panelW3, dir2, wallTexCoords3, trimStart, trimEnd);
            geomStrip7.addShortWallTop(panelX3, panelZ3, panelW3, dir2, wallTexCoords2, trimStart, trimEnd);
            if (!flag12 && !flag10)
            {
              int panelX4 = panelX3 - num7 * trimStart;
              int panelZ4 = panelZ3 - num8 * trimStart;
              geomStrip5.addTallCap(panelX4, panelZ4, dir2, wallTexCoords2);
              geomStrip6.addShortCap(panelX4, panelZ4, dir2, wallTexCoords2);
            }
            if (!flag8 && !flag7)
            {
              int panelX4 = panelX3 + num9 * 2 + -num7 * (panelW3 - trimEnd);
              int panelZ4 = panelZ3 + num10 * 2 + -num8 * (panelW3 - trimEnd);
              geomStrip5.addTallCap(panelX4, panelZ4, dir1, wallTexCoords2);
              geomStrip6.addShortCap(panelX4, panelZ4, dir1, wallTexCoords2);
            }
          }
        }
        flag1 = flag9;
        flag2 = flag14;
        flag3 = flag11;
        flag4 = flag10;
        flag5 = flag12;
        tileX += num7;
        tileZ += num8;
        panelX2 += num7 * 32;
        panelZ2 += num8 * 32;
      }
    }
    GeomStrip[] subGeomStrips = new GeomStrip[25];
    for (int index = 0; index < 25; ++index)
    {
      subGeomStrips[index] = (GeomStrip) null;
      if (geomStripArray[index].getQuadCount() > 0)
        subGeomStrips[index] = geomStripArray[index];
    }
    this.m_compositeMesh = GeomStrip.createMesh(subGeomStrips);
    this.m_compositeMesh.setAppearance(24, appearance1);
    this.m_group.addChild((Node) this.m_compositeMesh);
    for (int wall = 0; wall < 4; ++wall)
    {
      this.m_wallAlphasF8[wall] = 0;
      this.updateWallAlpha(wall, (int) byte.MaxValue, 0);
    }
  }

  public Group getGroup()
  {
    return this.m_group;
  }

  public void updateCameraPos(float posX, float posZ, float yawDeg, int timeStep)
  {
    float num1 = -JMath.Sin(MathExt.degreesToRadians(yawDeg));
    float num2 = -JMath.Cos(MathExt.degreesToRadians(yawDeg));
    int num3 = this.m_posX * 32;
    int num4 = this.m_posZ * 32;
    int num5 = num3 + this.m_sizeX * 32;
    int num6 = num4 + this.m_sizeZ * 32;
    bool flag = (double) posX > (double) num3 && (double) posX < (double) num5 && (double) posZ > (double) num4 && (double) posZ < (double) num6;
    for (int wall = 0; wall < 4; ++wall)
    {
      int alpha;
      if (flag)
      {
        int num7 = this.WALL_ANGLES[wall];
        float num8 = MathExt.normaliseAngleDegrees(yawDeg - (float) num7);
        alpha = (double) num8 <= 0.0 ? ((double) num8 <= -45.0 ? ((double) num8 >= -135.0 ? 0 : (int) ((double) byte.MaxValue - ((double) num8 + 180.0) * (double) byte.MaxValue / 45.0)) : (int) ((double) byte.MaxValue - -(double) num8 * (double) byte.MaxValue / 45.0)) : (int) byte.MaxValue;
      }
      else
      {
        int num7 = 0;
        int num8 = 0;
        int num9 = 0;
        int num10 = 0;
        switch (wall)
        {
          case 0:
            num7 = num3;
            num8 = num5;
            num9 = num10 = num4;
            break;
          case 1:
            num7 = num8 = num5;
            num9 = num4;
            num10 = num6;
            break;
          case 2:
            num7 = num3;
            num8 = num5;
            num9 = num10 = num6;
            break;
          case 3:
            num7 = num8 = num3;
            num9 = num4;
            num10 = num6;
            break;
        }
        float num11 = (double) posX < (double) num7 ? -1f : ((double) posX > (double) num8 ? 1f : 0.0f);
        float num12 = (double) posZ < (double) num9 ? -1f : ((double) posZ > (double) num10 ? 1f : 0.0f);
        alpha = (double) num1 * (double) num11 + (double) num2 * (double) num12 >= 0.0 ? 0 : (int) byte.MaxValue;
      }
      this.updateWallAlpha(wall, alpha, timeStep);
    }
  }

  public int getWallAlpha(int wall)
  {
    return this.m_wallAlphasF8[wall] >> 8;
  }

  public void updateWallAlpha(int wall, int alpha, int timeStep)
  {
    int num1 = this.m_wallAlphasF8[wall];
    int num2 = alpha == (int) byte.MaxValue ? 65280 : 0;
    if (num1 == num2)
      return;
    int index1 = wall * 6;
    int num3 = num2 >> 8;
    this.m_wallAlphasF8[wall] = num2;
    switch (num3)
    {
      case 0:
        this.m_compositeMesh.setAppearance(index1 + 2, (Appearance) null);
        this.m_compositeMesh.setAppearance(index1, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(index1 + 1, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(index1 + 5, (Appearance) null);
        this.m_compositeMesh.setAppearance(index1 + 3, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(index1 + 4, this.m_appWallReplace);
        break;
      case (int) byte.MaxValue:
        this.m_compositeMesh.setAppearance(index1 + 2, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(index1, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(index1 + 1, (Appearance) null);
        this.m_compositeMesh.setAppearance(index1 + 5, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(index1 + 3, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(index1 + 4, (Appearance) null);
        break;
    }
    for (int index2 = 0; index2 < this.m_wallWindows[wall].Length; ++index2)
    {
      MapObject mapObject = this.m_wallWindows[wall][index2];
      if (mapObject == null)
        break;
      mapObject.wallFadableSetAlpha(num3 * 65536 / (int) byte.MaxValue);
    }
  }

  public void setTintOutside(int tint)
  {
    this.m_dayNightTint = tint;
    int tintInside = this.getTintInside();
    for (int index = 0; index < this.m_corners.Length; ++index)
      this.m_corners[index].setTintOutside(tint);
    for (int index = 0; index < 4; ++index)
    {
      int submeshIndex = index * 6;
      GeomStrip.setTint(tintInside, this.m_compositeMesh, submeshIndex);
      GeomStrip.setTint(tintInside, this.m_compositeMesh, submeshIndex + 1);
      GeomStrip.setTint(tintInside, this.m_compositeMesh, submeshIndex + 2);
      GeomStrip.setTint(tint, this.m_compositeMesh, submeshIndex + 3);
      GeomStrip.setTint(tint, this.m_compositeMesh, submeshIndex + 4);
      GeomStrip.setTint(tint, this.m_compositeMesh, submeshIndex + 5);
    }
    GeomStrip.setTint(tintInside, this.m_compositeMesh, 24);
  }

  public int getTintInside()
  {
    return this.m_lightCount != 0 ? 16777215 : this.m_dayNightTint;
  }

  public void addLight()
  {
    ++this.m_lightCount;
    if (this.m_lightCount != 1)
      return;
    AppEngine.getCanvas().getSimWorld().forceTint();
  }

  public void removeLight()
  {
    --this.m_lightCount;
    if (this.m_lightCount != 0)
      return;
    AppEngine.getCanvas().getSimWorld().forceTint();
  }

  public void addSim()
  {
    ++this.m_simCount;
    if (this.m_simCount != 1)
      return;
    this.updateLights();
  }

  public void removeSim()
  {
    --this.m_simCount;
    if (this.m_simCount != 0)
      return;
    this.updateLights();
  }

  public void updateLights()
  {
    foreach (MapObject mapObject in AppEngine.getCanvas().getSceneGame().getObjects())
    {
      if ((mapObject.getParentType() == 20 || mapObject.getParentType() == 21) && mapObject.getRoom() == this)
        mapObject.updateLightStatus();
    }
  }

  public int getPosX()
  {
    return this.m_posX;
  }

  public int getPosZ()
  {
    return this.m_posZ;
  }

  public int getSizeX()
  {
    return this.m_sizeX;
  }

  public int getSizeZ()
  {
    return this.m_sizeZ;
  }

  public int getFloorType()
  {
    return this.m_floorType;
  }

  public int getWallType()
  {
    return this.m_wallType;
  }

  public bool getLightStatus()
  {
    return this.m_simCount > 0;
  }

  public int getWallDepthAt(int screenX, int screenY)
  {
    SimWorld simWorld = AppEngine.getCanvas().getSimWorld();
    int[] p0F = new int[3];
    int[] pnF = new int[3];
    int[] resultF = new int[4];
    int num1 = 0;
    for (int index = 0; index < 4; ++index)
    {
      if (this.m_wallAlphasF8[index] >= 32512)
      {
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        int num6 = 0;
        switch (index)
        {
          case 0:
            num4 = this.m_sizeX;
            num5 = 1;
            num2 = this.m_posX * 32;
            num3 = this.m_posZ * 32 + 2;
            break;
          case 1:
            num4 = this.m_sizeZ;
            num6 = 1;
            num2 = this.m_posX * 32 + this.m_sizeX * 32 - 2;
            num3 = this.m_posZ * 32;
            break;
          case 2:
            num4 = this.m_sizeX;
            num5 = -1;
            num2 = this.m_posX * 32 + this.m_sizeX * 32;
            num3 = this.m_posZ * 32 + this.m_sizeZ * 32 - 2;
            break;
          case 3:
            num4 = this.m_sizeZ;
            num6 = -1;
            num2 = this.m_posX * 32 + 2;
            num3 = this.m_posZ * 32 + this.m_sizeZ * 32;
            break;
        }
        int num7 = -num6;
        int num8 = num5;
        p0F[0] = num2 << 16;
        p0F[1] = 0;
        p0F[2] = num3 << 16;
        pnF[0] = num7;
        pnF[1] = 0;
        pnF[2] = num8;
        if (simWorld.coordScreenToWorldPlane(resultF, p0F, pnF, screenX, screenY))
        {
          int num9 = resultF[0];
          int num10 = resultF[1];
          int num11 = resultF[2];
          int num12 = resultF[3];
          if (num12 >= 0 && num10 > 0 && num10 < 6291456)
          {
            if (num5 != 0)
            {
              int a = num2 << 16;
              int b = num2 + num4 * num5 * 32 << 16;
              int num13 = JMath.min(a, b);
              int num14 = JMath.max(a, b);
              if (num9 < num13 || num9 > num14)
                continue;
            }
            else
            {
              int a = num3 << 16;
              int b = num3 + num4 * num6 * 32 << 16;
              int num13 = JMath.min(a, b);
              int num14 = JMath.max(a, b);
              if (num11 < num13 || num11 > num14)
                continue;
            }
            if (num1 == 0 || num12 < num1)
              num1 = num12;
          }
        }
      }
    }
    return num1;
  }

  public void setFloorType(int newType)
  {
    if (newType == this.m_floorType)
      return;
    SimWorld simWorld = AppEngine.getCanvas().getSimWorld();
    GeomStrip.remapTexCoords(this.m_compositeMesh, simWorld.getFloorTexCoords(this.m_floorType), simWorld.getFloorTexCoords(newType), 24);
    this.m_floorType = newType;
  }

  public void setWallType(int newType)
  {
    if (newType == this.m_wallType)
      return;
    SimWorld simWorld = AppEngine.getCanvas().getSimWorld();
    int[] wallTexCoords1 = simWorld.getWallTexCoords(this.m_wallType);
    int[] wallTexCoords2 = simWorld.getWallTexCoords(newType);
    for (int index = 0; index < 4; ++index)
    {
      int submeshIndex = index * 6;
      GeomStrip.remapTexCoords(this.m_compositeMesh, wallTexCoords1, wallTexCoords2, submeshIndex);
      GeomStrip.remapTexCoords(this.m_compositeMesh, wallTexCoords1, wallTexCoords2, submeshIndex + 2);
    }
    this.m_wallType = newType;
  }
}
