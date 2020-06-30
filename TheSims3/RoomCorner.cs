// Decompiled with JetBrains decompiler
// Type: RoomCorner
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g;
using System;

public class RoomCorner
{
  public const int MAX_ATTACHED = 8;
  private const int SUBMESH_CORNER_SHORT = 0;
  private const int SUBMESH_CORNER_SHORT_OUTSIDE = 1;
  private const int SUBMESH_CORNER_SHORT_TOP = 2;
  private const int SUBMESH_CORNER_TALL = 3;
  private const int SUBMESH_CORNER_TALL_OUTSIDE = 4;
  private const int SUBMESH_CORNER_TALL_TOP = 5;
  private const int SUBMESH_COUNT = 6;
  private int m_posX;
  private int m_posZ;
  private Group m_group;
  private Mesh m_compositeMesh;
  private Room[] m_attachedWallRooms;
  private int[] m_attachedWallIds;
  private int m_level;
  private bool m_subDownWall;
  private Appearance m_appWallAlpha;
  private Appearance m_appWallReplace;

  public void createGeometry()
  {
    ModelManager instance = ModelManager.getInstance();
    Appearance appearance = instance.getAppearance(1);
    this.m_appWallAlpha = instance.getAppearance(2);
    this.m_appWallReplace = appearance;
    Group group = new Group();
    this.m_group = group;
    SimWorld simWorld = AppEngine.getCanvas().getSimWorld();
    int[] numArray1 = new int[4];
    for (int index = 0; index < 4; ++index)
    {
      int tileX = this.m_posX + Room.ROOM_OFFSETS[index << 1];
      int tileZ = this.m_posZ + Room.ROOM_OFFSETS[(index << 1) + 1];
      numArray1[index] = simWorld.getRoomAt(tileX, tileZ);
    }
    int num1 = -1;
    for (int index1 = 0; index1 < Room.CONFIGURATIONS_COUNT && num1 == -1; ++index1)
    {
      int num2 = index1 * 13;
      int[] numArray2 = new int[4]{ -1, -1, -1, -1 };
      bool flag = true;
      for (int index2 = 0; index2 < 4 && flag; ++index2)
      {
        int num3 = Room.CONFIGURATIONS[num2 + index2];
        int num4 = numArray1[index2];
        if (num3 != 0 || num4 != -1)
        {
          if (num3 != 0 && num4 != -1)
          {
            int index3 = num3 - 1;
            if (index3 != 9)
            {
              int num5 = numArray2[index3];
              if (num5 == -1)
              {
                numArray2[index3] = num4;
                continue;
              }
              if (num4 == num5)
                continue;
            }
            else
              continue;
          }
          flag = false;
        }
      }
      if (flag)
      {
        num1 = index1;
        break;
      }
    }
    if (num1 == -1)
      return;
    this.m_level = -1;
    this.m_subDownWall = Room.CONFIGURATIONS[num1 * 13 + 12] == 1;
    int[] numArray3 = new int[Room.CONFIGURATIONS.Length - (num1 * 13 + 8)];
    midp.JSystem.arraycopy((Array) Room.CONFIGURATIONS, num1 * 13 + 8, (Array) numArray3, 0, Room.CONFIGURATIONS.Length - (num1 * 13 + 8));
    int[] numArray4 = new int[Room.CONFIGURATIONS.Length - (num1 * 13 + 4)];
    midp.JSystem.arraycopy((Array) Room.CONFIGURATIONS, num1 * 13 + 4, (Array) numArray4, 0, Room.CONFIGURATIONS.Length - (num1 * 13 + 4));
    int[] wallTexCoords1 = simWorld.getWallTexCoords(46);
    int[] wallTexCoords2 = simWorld.getWallTexCoords(46);
    int[] wallTexCoords3 = simWorld.getWallTexCoords(27);
    GeomStrip[] geomStripArray = new GeomStrip[6];
    for (int index = 0; index < geomStripArray.Length; ++index)
      geomStripArray[index] = new GeomStrip();
    GeomStrip geomStrip1 = geomStripArray[3];
    GeomStrip geomStrip2 = geomStripArray[4];
    GeomStrip geomStrip3 = geomStripArray[5];
    GeomStrip geomStrip4 = geomStripArray[0];
    GeomStrip geomStrip5 = geomStripArray[1];
    GeomStrip geomStrip6 = geomStripArray[2];
    int panelX1 = this.m_posX * 32;
    int panelZ1 = this.m_posZ * 32;
    int panelX2 = panelX1 - 2;
    int panelZ2 = panelZ1 - 2;
    int panelX3 = panelX1 + 2;
    int panelZ3 = panelZ1 + 2;
    int num6 = 30;
    if (numArray4[0] != 0 || numArray4[3] != 0)
    {
      int trimStart = numArray4[0] != 0 ? 0 : 2;
      int trimEnd = numArray4[3] != 0 ? 0 : 2;
      geomStrip3.addTallWallTop(panelX2, panelZ2, 4, GeomStrip.Dir.DIR_Z_POS, wallTexCoords1, trimStart, trimEnd);
      geomStrip6.addShortWallTop(panelX2, panelZ2, 4, GeomStrip.Dir.DIR_Z_POS, wallTexCoords1, trimStart, trimEnd);
    }
    if (numArray4[1] != 0 || numArray4[2] != 0)
    {
      int trimStart = numArray4[1] != 0 ? 0 : 2;
      int trimEnd = numArray4[2] != 0 ? 0 : 2;
      geomStrip3.addTallWallTop(panelX1, panelZ2, 4, GeomStrip.Dir.DIR_Z_POS, wallTexCoords1, trimStart, trimEnd);
      geomStrip6.addShortWallTop(panelX1, panelZ2, 4, GeomStrip.Dir.DIR_Z_POS, wallTexCoords1, trimStart, trimEnd);
    }
    if (numArray3[0] != 2)
    {
      if (numArray3[0] == 1)
      {
        geomStrip1.addTallWall(panelX1 + 32, panelZ2, 32, GeomStrip.Dir.DIR_X_NEG, wallTexCoords2, num6, 0);
        geomStrip4.addShortWall(panelX1 + 32, panelZ2, 32, GeomStrip.Dir.DIR_X_NEG, wallTexCoords2, num6, 0);
        geomStrip1.addTallWall(panelX1, panelZ2, 32, GeomStrip.Dir.DIR_X_NEG, wallTexCoords2, 0, num6);
        geomStrip4.addShortWall(panelX1, panelZ2, 32, GeomStrip.Dir.DIR_X_NEG, wallTexCoords2, 0, num6);
      }
      else
      {
        geomStrip2.addTallWall(panelX1 + 32, panelZ2, 32, GeomStrip.Dir.DIR_X_NEG, wallTexCoords3, num6, 0);
        geomStrip5.addShortWall(panelX1 + 32, panelZ2, 32, GeomStrip.Dir.DIR_X_NEG, wallTexCoords3, num6, 0);
        geomStrip2.addTallWall(panelX1, panelZ2, 32, GeomStrip.Dir.DIR_X_NEG, wallTexCoords3, 0, num6);
        geomStrip5.addShortWall(panelX1, panelZ2, 32, GeomStrip.Dir.DIR_X_NEG, wallTexCoords3, 0, num6);
      }
    }
    if (numArray3[3] != 2)
    {
      if (numArray3[3] == 1)
      {
        geomStrip1.addTallWall(panelX2, panelZ1, 32, GeomStrip.Dir.DIR_Z_POS, wallTexCoords2, 0, num6);
        geomStrip4.addShortWall(panelX2, panelZ1, 32, GeomStrip.Dir.DIR_Z_POS, wallTexCoords2, 0, num6);
        geomStrip1.addTallWall(panelX2, panelZ1 - 32, 32, GeomStrip.Dir.DIR_Z_POS, wallTexCoords2, num6, 0);
        geomStrip4.addShortWall(panelX2, panelZ1 - 32, 32, GeomStrip.Dir.DIR_Z_POS, wallTexCoords2, num6, 0);
      }
      else
      {
        geomStrip2.addTallWall(panelX2, panelZ1, 32, GeomStrip.Dir.DIR_Z_POS, wallTexCoords3, 0, num6);
        geomStrip5.addShortWall(panelX2, panelZ1, 32, GeomStrip.Dir.DIR_Z_POS, wallTexCoords3, 0, num6);
        geomStrip2.addTallWall(panelX2, panelZ1 - 32, 32, GeomStrip.Dir.DIR_Z_POS, wallTexCoords3, num6, 0);
        geomStrip5.addShortWall(panelX2, panelZ1 - 32, 32, GeomStrip.Dir.DIR_Z_POS, wallTexCoords3, num6, 0);
      }
    }
    if (numArray3[1] != 2)
    {
      if (numArray3[1] == 1)
      {
        geomStrip1.addTallWall(panelX3, panelZ1 + 32, 32, GeomStrip.Dir.DIR_Z_NEG, wallTexCoords2, num6, 0);
        geomStrip4.addShortWall(panelX3, panelZ1 + 32, 32, GeomStrip.Dir.DIR_Z_NEG, wallTexCoords2, num6, 0);
        geomStrip1.addTallWall(panelX3, panelZ1, 32, GeomStrip.Dir.DIR_Z_NEG, wallTexCoords2, 0, num6);
        geomStrip4.addShortWall(panelX3, panelZ1, 32, GeomStrip.Dir.DIR_Z_NEG, wallTexCoords2, 0, num6);
      }
      else
      {
        geomStrip2.addTallWall(panelX3, panelZ1 + 32, 32, GeomStrip.Dir.DIR_Z_NEG, wallTexCoords3, num6, 0);
        geomStrip5.addShortWall(panelX3, panelZ1 + 32, 32, GeomStrip.Dir.DIR_Z_NEG, wallTexCoords3, num6, 0);
        geomStrip2.addTallWall(panelX3, panelZ1, 32, GeomStrip.Dir.DIR_Z_NEG, wallTexCoords3, 0, num6);
        geomStrip5.addShortWall(panelX3, panelZ1, 32, GeomStrip.Dir.DIR_Z_NEG, wallTexCoords3, 0, num6);
      }
    }
    if (numArray3[2] != 2)
    {
      if (numArray3[2] == 1)
      {
        geomStrip1.addTallWall(panelX1 - 32, panelZ3, 32, GeomStrip.Dir.DIR_X_POS, wallTexCoords2, num6, 0);
        geomStrip4.addShortWall(panelX1 - 32, panelZ3, 32, GeomStrip.Dir.DIR_X_POS, wallTexCoords2, num6, 0);
        geomStrip1.addTallWall(panelX1, panelZ3, 32, GeomStrip.Dir.DIR_X_POS, wallTexCoords2, 0, num6);
        geomStrip4.addShortWall(panelX1, panelZ3, 32, GeomStrip.Dir.DIR_X_POS, wallTexCoords2, 0, num6);
      }
      else
      {
        geomStrip2.addTallWall(panelX1 - 32, panelZ3, 32, GeomStrip.Dir.DIR_X_POS, wallTexCoords3, num6, 0);
        geomStrip5.addShortWall(panelX1 - 32, panelZ3, 32, GeomStrip.Dir.DIR_X_POS, wallTexCoords3, num6, 0);
        geomStrip2.addTallWall(panelX1, panelZ3, 32, GeomStrip.Dir.DIR_X_POS, wallTexCoords3, 0, num6);
        geomStrip5.addShortWall(panelX1, panelZ3, 32, GeomStrip.Dir.DIR_X_POS, wallTexCoords3, 0, num6);
      }
    }
    GeomStrip[] subGeomStrips = new GeomStrip[6];
    for (int index = 0; index < 6; ++index)
    {
      subGeomStrips[index] = (GeomStrip) null;
      if (geomStripArray[index].getQuadCount() > 0)
        subGeomStrips[index] = geomStripArray[index];
    }
    this.m_compositeMesh = GeomStrip.createMesh(subGeomStrips);
    group.addChild((Node) this.m_compositeMesh);
  }

  public int getPosX()
  {
    return this.m_posX;
  }

  public int getPosZ()
  {
    return this.m_posZ;
  }

  public Group getGroup()
  {
    return this.m_group;
  }

  public void updateCameraPos()
  {
    int num1 = 0;
    int num2 = 0;
    for (int index = 0; index < 8; ++index)
    {
      if (this.m_attachedWallIds[index] != -1)
      {
        ++num1;
        if (this.m_attachedWallRooms[index].getWallAlpha(this.m_attachedWallIds[index]) != 0)
          ++num2;
      }
    }
    int level = 0;
    if (num2 == num1)
      level = 2;
    else if (num2 != 0)
      level = !this.m_subDownWall || num2 > num1 >> 1 ? 1 : 0;
    this.setCornerLevel(level);
  }

  public void setCornerLevel(int level)
  {
    if (level == this.m_level)
      return;
    this.m_level = level;
    switch (level)
    {
      case 0:
        this.m_compositeMesh.setAppearance(0, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(2, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(1, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(3, (Appearance) null);
        this.m_compositeMesh.setAppearance(5, (Appearance) null);
        this.m_compositeMesh.setAppearance(4, (Appearance) null);
        break;
      case 1:
        this.m_compositeMesh.setAppearance(0, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(2, (Appearance) null);
        this.m_compositeMesh.setAppearance(1, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(3, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(5, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(4, this.m_appWallReplace);
        break;
      case 2:
        this.m_compositeMesh.setAppearance(0, (Appearance) null);
        this.m_compositeMesh.setAppearance(2, (Appearance) null);
        this.m_compositeMesh.setAppearance(1, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(3, (Appearance) null);
        this.m_compositeMesh.setAppearance(5, this.m_appWallReplace);
        this.m_compositeMesh.setAppearance(4, this.m_appWallReplace);
        break;
    }
  }

  public void setTintOutside(int tint)
  {
    GeomStrip.setTint(tint, this.m_compositeMesh);
  }

  public RoomCorner(int x, int z)
  {
    this.m_posX = x;
    this.m_posZ = z;
    this.m_group = (Group) null;
    this.m_compositeMesh = (Mesh) null;
    this.m_attachedWallRooms = new Room[8];
    this.m_attachedWallIds = new int[8];
    this.m_level = -1;
    this.m_subDownWall = false;
    this.m_appWallAlpha = (Appearance) null;
    this.m_appWallReplace = (Appearance) null;
    AppEngine.fillArray(this.m_attachedWallIds, -1);
  }

  public void Dispose()
  {
  }

  public void attachWall(Room room, int wall)
  {
    for (int index = 0; index < 8; ++index)
    {
      if (this.m_attachedWallIds[index] == -1)
      {
        this.m_attachedWallRooms[index] = room;
        this.m_attachedWallIds[index] = wall;
        break;
      }
    }
  }
}
