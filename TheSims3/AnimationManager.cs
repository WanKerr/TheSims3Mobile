// Decompiled with JetBrains decompiler
// Type: AnimationManager
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class AnimationManager
{
  public const int ANIM_DATA_FILE = 3;
  public const int IMAGE_DATA_FILE = 24;
  public const int COLOR_DATA_FILE = 5;
  public const int SUB_IMAGE_ID = 0;
  public const int SUB_IMAGE_X = 1;
  public const int SUB_IMAGE_Y = 2;
  public const int SUB_IMAGE_WIDTH = 3;
  public const int SUB_IMAGE_HEIGHT = 4;
  public const int NUM_SUB_IMAGE_FIELDS = 5;
  public const int MAX_FILE_SIZE = 4096;
  public const int PRIMITIVE_SPRITE_ENUM = 0;
  public const int PRIMITIVE_CLIP_ENUM = 1;
  public const int PRIMITIVE_COLL_BOX_ENUM = 2;
  public const int PRIMITIVE_HOLLOW_RECTANGLE_ENUM = 3;
  public const int PRIMITIVE_FILLED_RECTANGLE_ENUM = 4;
  public const int PRIMITIVE_HOLLOW_ELLIPSE_ENUM = 5;
  public const int PRIMITIVE_FILLED_ELLIPSE_ENUM = 6;
  public const int PRIMITIVE_FIRE_POINT_ENUM = 7;
  public const int PRIMITIVE_LINE_ENUM = 8;
  public const int PRIMITIVE_TEXT_ENUM = 9;
  public const int PRIMITIVE_COLOR_ENUM = 10;
  public const int PRIMITIVE_XFLIPPED_SPRITE_ENUM = 11;
  public const int PRIMITIVE_RIGHT_TRIANGLE_ENUM = 12;
  public const int PRIMITIVE_ATTRIB_TYPE = 0;
  public const int PRIMITIVE_ATTRIB_X = 1;
  public const int PRIMITIVE_ATTRIB_Y = 2;
  public const int PRIMITIVE_ATTRIB_X2 = 3;
  public const int PRIMITIVE_ATTRIB_Y2 = 4;
  public const int PRIMITIVE_ATTRIB_SUBIMAGE = 3;
  public const int PRIMITIVE_ATTRIB_WIDTH = 3;
  public const int PRIMITIVE_ATTRIB_HEIGHT = 4;
  public const int PRIMITIVE_ATTRIB_COLOUR_INDEX = 1;
  public const int ANIMFLAG_XFLIPPED = 16384;
  public const int NUM_BANKS = 1;
  public const int ANIMPLAYER_POOLSIZE = 48;
  public const int M3G_TRANSFORM_FIXED = 0;
  public const int M3G_TRANSFORMABLE_FIXED = 0;
  private const int CEIL_ONE_F = 65535;

  public static void constructAnimationManager(ref AnimationManagerData thisData)
  {
    for (int index = 0; index < 48; ++index)
      thisData.m_animPlayerPool[index] = new AnimPlayer();
    thisData.colourData = (sbyte[]) null;
    thisData.animNumFrames = new sbyte[18];
    thisData.animFrameOffset = new short[18];
    thisData.frameDuration = new short[201];
    thisData.frameNumPrimitives = new sbyte[201];
    thisData.framePrimitiveOffset = new int[201];
    thisData.primitiveData = new short[538];
    thisData.m_animImageArray = new Image[1][];
    for (int index = 0; index < 1; ++index)
      thisData.m_animImageArray[index] = new Image[0];
  }

  public static bool loadColorsFile(ref AnimationManagerData thisData, ref ResourceManager resMgr)
  {
    InputStream inputStream = ResourceManager.loadBinaryFile(5);
    thisData.colourData = new sbyte[ResourceManager.RESOURCE_FILESIZE_LIST[5]];
    inputStream.read(thisData.colourData);
    inputStream.close();
    return true;
  }

  public static void setColor(Graphics g, int index)
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    int index1 = index * 3;
    int R = (int) (byte) animManData.colourData[index1];
    int G = (int) (byte) animManData.colourData[index1 + 1];
    int B = (int) (byte) animManData.colourData[index1 + 2];
    g.setColor(R, G, B);
  }

  public static bool loadSubimageFile(ref AnimationManagerData thisData, ref ResourceManager resMgr)
  {
    DataInputStream dataInputStream = new DataInputStream(ResourceManager.loadBinaryFile(24));
    for (int index = 0; index < 0; ++index)
    {
      thisData.m_subImages[index][0] = (short) dataInputStream.readUnsignedShort();
      thisData.m_subImages[index][1] = dataInputStream.readShort();
      thisData.m_subImages[index][2] = dataInputStream.readShort();
      thisData.m_subImages[index][3] = (short) dataInputStream.readUnsignedShort();
      thisData.m_subImages[index][4] = (short) dataInputStream.readUnsignedShort();
    }
    return true;
  }

  public static bool loadAnimFile(ref AnimationManagerData thisData, ref ResourceManager resMgr)
  {
    DataInputStream dataInputStream = new DataInputStream(ResourceManager.loadBinaryFile(3));
    int index1 = 0;
    int num1 = 0;
    for (int index2 = 0; index2 != 18; ++index2)
    {
      int num2 = dataInputStream.readUnsignedByte();
      thisData.animNumFrames[index2] = (sbyte) num2;
      thisData.animFrameOffset[index2] = (short) index1;
      int num3 = 0;
      while (num3 != num2)
      {
        thisData.frameDuration[index1] = dataInputStream.readShort();
        int num4 = dataInputStream.readUnsignedByte();
        thisData.frameNumPrimitives[index1] = (sbyte) num4;
        thisData.framePrimitiveOffset[index1] = num1;
        for (int index3 = 0; index3 != num4; ++index3)
        {
          int num5 = dataInputStream.readUnsignedByte();
          thisData.primitiveData[num1++] = (short) num5;
          switch (num5)
          {
            case 0:
            case 11:
              int num6 = num1 - 1;
              thisData.primitiveData[num6 + 3] = dataInputStream.readShort();
              thisData.primitiveData[num6 + 1] = dataInputStream.readShort();
              thisData.primitiveData[num6 + 2] = dataInputStream.readShort();
              num1 = num6 + 4;
              break;
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 8:
              short[] primitiveData1 = thisData.primitiveData;
              int index4 = num1;
              int num7 = index4 + 1;
              int num8 = (int) dataInputStream.readShort();
              primitiveData1[index4] = (short) num8;
              short[] primitiveData2 = thisData.primitiveData;
              int index5 = num7;
              int num9 = index5 + 1;
              int num10 = (int) dataInputStream.readShort();
              primitiveData2[index5] = (short) num10;
              short[] primitiveData3 = thisData.primitiveData;
              int index6 = num9;
              int num11 = index6 + 1;
              int num12 = (int) dataInputStream.readShort();
              primitiveData3[index6] = (short) num12;
              short[] primitiveData4 = thisData.primitiveData;
              int index7 = num11;
              num1 = index7 + 1;
              int num13 = (int) dataInputStream.readShort();
              primitiveData4[index7] = (short) num13;
              break;
            case 7:
              short[] primitiveData5 = thisData.primitiveData;
              int index8 = num1;
              int num14 = index8 + 1;
              int num15 = (int) dataInputStream.readShort();
              primitiveData5[index8] = (short) num15;
              short[] primitiveData6 = thisData.primitiveData;
              int index9 = num14;
              num1 = index9 + 1;
              int num16 = (int) dataInputStream.readShort();
              primitiveData6[index9] = (short) num16;
              break;
            case 10:
              thisData.primitiveData[num1++] = (short) dataInputStream.readUnsignedByte();
              break;
            case 12:
              short[] primitiveData7 = thisData.primitiveData;
              int index10 = num1;
              int num17 = index10 + 1;
              int num18 = (int) dataInputStream.readShort();
              primitiveData7[index10] = (short) num18;
              short[] primitiveData8 = thisData.primitiveData;
              int index11 = num17;
              int num19 = index11 + 1;
              int num20 = (int) dataInputStream.readShort();
              primitiveData8[index11] = (short) num20;
              short[] primitiveData9 = thisData.primitiveData;
              int index12 = num19;
              int num21 = index12 + 1;
              int num22 = (int) dataInputStream.readShort();
              primitiveData9[index12] = (short) num22;
              short[] primitiveData10 = thisData.primitiveData;
              int index13 = num21;
              num1 = index13 + 1;
              int num23 = (int) dataInputStream.readShort();
              primitiveData10[index13] = (short) num23;
              break;
          }
        }
        ++num3;
        ++index1;
      }
    }
    return true;
  }

  public static bool loadImage(ref ResourceManager resourceManager, int resID)
  {
    return AnimationManager.loadImage(AppEngine.getCanvas().getAnimManData(), resourceManager, resID);
  }

  public static bool unloadImage(int resID, int bank)
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    int index = 0;
    while (index < 0 && resID != (int) GlobalConstants.IMAGE_RES_IDS[index])
      ++index;
    if (index == 0)
      return false;
    Image image = animManData.m_animImageArray[bank][index];
    animManData.m_animImageArray[bank][index] = (Image) null;
    return true;
  }

  public static AnimPlayer createAnimPlayer()
  {
    return new AnimPlayer();
  }

  private static int getNumAttributes(int primitiveType)
  {
    switch (primitiveType)
    {
      case 0:
      case 11:
        return 4;
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 8:
      case 12:
        return 5;
      case 7:
        return 3;
      case 10:
        return 2;
      default:
        return 0;
    }
  }

  public static void drawAnimFrame(Graphics g, int animID, int frameID, int x, int y)
  {
    if (animID < 0)
      return;
    AnimationManager.drawNormalAnimFrame(g, animID, frameID, x, y);
  }

  private static void drawNormalAnimFrame(Graphics g, int animID, int frameID, int x, int y)
  {
    int clipX = g.getClipX();
    int clipY = g.getClipY();
    int clipWidth = g.getClipWidth();
    int clipHeight = g.getClipHeight();
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    int index1 = (int) animManData.animFrameOffset[animID] + frameID;
    int primitiveIndex = animManData.framePrimitiveOffset[index1];
    int frameNumPrimitive = (int) animManData.frameNumPrimitives[index1];
    for (int index2 = 0; index2 != frameNumPrimitive; ++index2)
    {
      short num = animManData.primitiveData[primitiveIndex];
      switch (num)
      {
        case 0:
        case 11:
          int x1 = x + (int) animManData.primitiveData[primitiveIndex + 1];
          int y1 = y + (int) animManData.primitiveData[primitiveIndex + 2];
          short[] subImage = animManData.m_subImages[(int) animManData.primitiveData[primitiveIndex + 3]];
          int index3 = (int) subImage[0];
          g.clipRect(x1, y1, (int) subImage[3], (int) subImage[4]);
          g.drawImage(animManData.m_animImageArray[animManData.m_curBank][index3], (float) (x1 - (int) subImage[1]), (float) (y1 - (int) subImage[2]), 9);
          g.setClip(clipX, clipY, clipWidth, clipHeight);
          goto case 2;
        case 2:
        case 7:
          primitiveIndex += AnimationManager.getNumAttributes((int) num);
          continue;
        default:
          AnimationManager.drawPrimitive(g, x, y, primitiveIndex, (int) num);
          goto case 2;
      }
    }
    g.setClip(clipX, clipY, clipWidth, clipHeight);
  }

  private static bool drawNormalAnimFrameExt(
    Graphics g,
    int animID,
    int frameID,
    int x,
    int y,
    int extraAnimId,
    int extraIndex,
    int[] firepoint)
  {
    int clipX = g.getClipX();
    int clipY = g.getClipY();
    int clipWidth = g.getClipWidth();
    int clipHeight = g.getClipHeight();
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    bool flag = false;
    int num1 = extraAnimId >= 0 ? (int) animManData.animFrameOffset[extraAnimId] : -1;
    int index1 = (int) animManData.animFrameOffset[animID] + frameID;
    int primitiveIndex = animManData.framePrimitiveOffset[index1];
    int frameNumPrimitive1 = (int) animManData.frameNumPrimitives[index1];
    for (int index2 = 0; index2 != frameNumPrimitive1; ++index2)
    {
      short num2 = animManData.primitiveData[primitiveIndex];
      switch (num2)
      {
        case 0:
        case 11:
          int x1 = x + (int) animManData.primitiveData[primitiveIndex + 1];
          int y1 = y + (int) animManData.primitiveData[primitiveIndex + 2];
          int index3 = (int) animManData.primitiveData[primitiveIndex + 3];
          short[] subImage1 = animManData.m_subImages[index3];
          int index4 = (int) subImage1[0];
          Image image1 = animManData.m_animImageArray[animManData.m_curBank][index4];
          g.clipRect(x1, y1, (int) subImage1[3], (int) subImage1[4]);
          g.drawImage(image1, (float) (x1 - (int) subImage1[1]), (float) (y1 - (int) subImage1[2]), 9);
          g.setClip(clipX, clipY, clipWidth, clipHeight);
          if (num1 >= 0)
          {
            int animNumFrame = (int) animManData.animNumFrames[extraAnimId];
            short[] primitiveData = animManData.primitiveData;
            for (int index5 = 0; index5 < animNumFrame; ++index5)
            {
              int index6 = animManData.framePrimitiveOffset[num1 + index5];
              AppEngine.ASSERT(primitiveData[index6] == (short) 0, "non-sprite in extras anim");
              int num3 = (int) primitiveData[index6 + 3] & (int) ushort.MaxValue;
              if (index3 == num3)
              {
                int num4 = (int) primitiveData[index6 + 1];
                int num5 = (int) primitiveData[index6 + 2];
                int frameNumPrimitive2 = (int) animManData.frameNumPrimitives[num1 + index5];
                if (firepoint != null)
                {
                  flag = true;
                  int index7 = index6;
                  int num6 = frameNumPrimitive2 - 1;
                  for (int index8 = 0; index8 < num6; ++index8)
                  {
                    int primitiveType = (int) primitiveData[index7];
                    index7 += AnimationManager.getNumAttributes(primitiveType);
                  }
                  AppEngine.ASSERT(primitiveData[index7] == (short) 7, "non-firepoint at end of extras anim");
                  firepoint[0] = x1 + (int) primitiveData[index7 + 1] - num4;
                  firepoint[1] = y1 + (int) primitiveData[index7 + 2] - num5;
                }
                if (extraIndex < frameNumPrimitive2 - 1)
                {
                  for (int index7 = 0; index7 < extraIndex; ++index7)
                  {
                    int primitiveType = (int) primitiveData[index6];
                    index6 += AnimationManager.getNumAttributes(primitiveType);
                  }
                  int x2 = (int) primitiveData[index6 + 1] - num4;
                  int y2 = (int) primitiveData[index6 + 2] - num5;
                  short[] subImage2 = animManData.m_subImages[(int) primitiveData[index6 + 3]];
                  int index8 = (int) subImage2[0] & (int) ushort.MaxValue;
                  Image image2 = animManData.m_animImageArray[animManData.m_curBank][index8];
                  if (image1 != null)
                  {
                    g.clipRect(x2, y2, (int) subImage2[3], (int) subImage2[4]);
                    g.drawImage(image2, (float) (x2 - (int) subImage2[1]), (float) (y2 - (int) subImage2[2]), 9);
                    g.setClip(clipX, clipY, clipWidth, clipHeight);
                    break;
                  }
                  break;
                }
                break;
              }
            }
            goto case 2;
          }
          else
            goto case 2;
        case 2:
        case 7:
          primitiveIndex += AnimationManager.getNumAttributes((int) num2);
          continue;
        default:
          AnimationManager.drawPrimitive(g, x, y, primitiveIndex, (int) num2);
          goto case 2;
      }
    }
    g.setClip(clipX, clipY, clipWidth, clipHeight);
    return flag;
  }

  private static bool drawPrimitive(
    Graphics g,
    int x,
    int y,
    int primitiveIndex,
    int primitiveType)
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    switch (primitiveType)
    {
      case 1:
        int x1 = x + (int) animManData.primitiveData[primitiveIndex + 1];
        int y1 = y + (int) animManData.primitiveData[primitiveIndex + 2];
        int w = (int) animManData.primitiveData[primitiveIndex + 3];
        int h = (int) animManData.primitiveData[primitiveIndex + 4];
        g.clipRect(x1, y1, w, h);
        break;
      case 3:
      case 4:
      case 5:
      case 6:
        int num1 = x + (int) animManData.primitiveData[primitiveIndex + 1];
        int num2 = y + (int) animManData.primitiveData[primitiveIndex + 2];
        int num3 = (int) animManData.primitiveData[primitiveIndex + 3];
        int num4 = (int) animManData.primitiveData[primitiveIndex + 4];
        switch (primitiveType - 3)
        {
          case 0:
            g.drawRect((float) num1, (float) num2, (float) (num3 - 1), (float) (num4 - 1));
            break;
          case 1:
            g.fillRect(num1, num2, num3, num4);
            break;
          case 2:
            g.drawArc(num1, num2, num3, num4, 0, 360);
            break;
          case 3:
            g.fillArc(num1, num2, num3, num4, 0, 360);
            break;
        }
        break;
      case 8:
        int num5 = x + (int) animManData.primitiveData[primitiveIndex + 1];
        int num6 = y + (int) animManData.primitiveData[primitiveIndex + 2];
        int num7 = x + (int) animManData.primitiveData[primitiveIndex + 3];
        int num8 = y + (int) animManData.primitiveData[primitiveIndex + 4];
        g.drawLine((float) num5, (float) num6, (float) num7, (float) num8);
        break;
      case 10:
        AnimationManager.setColor(g, (int) animManData.primitiveData[primitiveIndex + 1]);
        break;
      case 12:
        int num9 = x + (int) animManData.primitiveData[1];
        int posY1 = y + (int) animManData.primitiveData[2];
        int posX2 = x + (int) animManData.primitiveData[3];
        int num10 = y + (int) animManData.primitiveData[4];
        g.fillTriangle(num9, posY1, posX2, num10, num9, num10);
        break;
    }
    return false;
  }

  private static bool drawXFlippedPrimitive(
    Graphics g,
    int x,
    int y,
    int primitiveIndex,
    int primitiveType)
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    switch (primitiveType)
    {
      case 3:
      case 4:
      case 5:
      case 6:
        int num1 = (int) animManData.primitiveData[primitiveIndex + 3];
        int num2 = (int) animManData.primitiveData[primitiveIndex + 4];
        int num3 = x - ((int) animManData.primitiveData[primitiveIndex + 1] + num1);
        int num4 = y + (int) animManData.primitiveData[primitiveIndex + 2];
        switch (primitiveType - 3)
        {
          case 0:
            g.drawRect((float) num3, (float) num4, (float) (num1 - 1), (float) (num2 - 1));
            break;
          case 1:
            g.fillRect(num3, num4, num1, num2);
            break;
          case 2:
            g.drawArc(num3, num4, num1, num2, 0, 360);
            break;
          case 3:
            g.fillArc(num3, num4, num1, num2, 0, 360);
            break;
        }
        break;
      case 8:
        int num5 = x - (int) animManData.primitiveData[primitiveIndex + 1];
        int num6 = y + (int) animManData.primitiveData[primitiveIndex + 2];
        int num7 = x - (int) animManData.primitiveData[primitiveIndex + 3];
        int num8 = y + (int) animManData.primitiveData[primitiveIndex + 4];
        g.drawLine((float) num5, (float) num6, (float) num7, (float) num8);
        break;
      case 10:
        AnimationManager.setColor(g, (int) animManData.primitiveData[primitiveIndex + 1]);
        break;
      case 12:
        int num9 = x + (int) animManData.primitiveData[1];
        int posY1 = y + (int) animManData.primitiveData[2];
        int posX2 = x + (int) animManData.primitiveData[3];
        int num10 = y + (int) animManData.primitiveData[4];
        g.fillTriangle(num9, posY1, posX2, num10, num9, num10);
        break;
    }
    return false;
  }

  public static void drawScaledPrimitives(
    Graphics g,
    int animID,
    int frameID,
    int x,
    int y,
    int scaleXF,
    int scaleYF,
    bool flipX)
  {
    if (animID < 0)
      return;
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    int clipX = g.getClipX();
    int clipY = g.getClipY();
    int clipWidth = g.getClipWidth();
    int clipHeight = g.getClipHeight();
    int index1 = (int) animManData.animFrameOffset[animID] + frameID;
    int index2 = animManData.framePrimitiveOffset[index1];
    int frameNumPrimitive = (int) animManData.frameNumPrimitives[index1];
    int num1 = 0;
    for (int index3 = 0; index3 != frameNumPrimitive; ++index3)
    {
      index2 += num1;
      short num2 = animManData.primitiveData[index2];
      switch (num2)
      {
        case 0:
        case 2:
        case 7:
        case 11:
label_16:
          num1 = AnimationManager.getNumAttributes((int) num2);
          continue;
        case 10:
          AnimationManager.setColor(g, (int) animManData.primitiveData[index2 + 1]);
          goto case 0;
        default:
          int num3 = MathExt.Fmul((int) animManData.primitiveData[index2 + 1] << 16, scaleXF) + (int) ushort.MaxValue >> 16;
          int num4 = MathExt.Fmul((int) animManData.primitiveData[index2 + 2] << 16, scaleYF) + (int) ushort.MaxValue >> 16;
          int num5 = MathExt.Fmul((int) animManData.primitiveData[index2 + 3] << 16, scaleXF) + (int) ushort.MaxValue >> 16;
          int num6 = MathExt.Fmul((int) animManData.primitiveData[index2 + 4] << 16, scaleYF) + (int) ushort.MaxValue >> 16;
          if (flipX)
          {
            if (num2 == (short) 8 || num2 == (short) 12)
            {
              num3 = -num3;
              num5 = -num5;
            }
            else
              num3 = -num3 - num5;
          }
          switch (num2)
          {
            case 3:
              g.drawRect((float) (x + num3), (float) (y + num4), (float) num5, (float) num6);
              goto label_16;
            case 4:
              g.fillRect(x + num3, y + num4, num5, num6);
              goto label_16;
            case 5:
              g.drawArc(x + num3, y + num4, num5, num6, 0, 360);
              goto label_16;
            case 6:
              g.fillArc(x + num3, y + num4, num5, num6, 0, 360);
              goto label_16;
            case 8:
              g.drawLine((float) (x + num3), (float) (y + num4), (float) (x + num3 + num5), (float) (y + num4 + num6));
              goto label_16;
            case 12:
              g.fillTriangle(x + num3, y + num4, x + num5, y + num6, x + num3, y + num6);
              goto label_16;
            default:
              goto label_16;
          }
      }
    }
    g.setClip(clipX, clipY, clipWidth, clipHeight);
  }

  public static short getNumAnims()
  {
    return 18;
  }

  public static int getAnimFrameCount(int animID)
  {
    animID &= -16385;
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    return animID < 0 || animID >= 18 ? -1 : (int) animManData.animNumFrames[animID];
  }

  public static short getAnimFrameDuration(int animID, int frameID)
  {
    animID &= -16385;
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    return animManData.frameDuration[(int) animManData.animFrameOffset[animID] + frameID];
  }

  private static int getPrimitiveX(int primitiveShortIndex)
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    switch (animManData.primitiveData[primitiveShortIndex])
    {
      case 0:
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
      case 9:
      case 11:
      case 12:
        return (int) animManData.primitiveData[primitiveShortIndex + 1];
      case 8:
        int num1 = (int) animManData.primitiveData[primitiveShortIndex + 1];
        int num2 = (int) animManData.primitiveData[primitiveShortIndex + 3];
        return num1 >= num2 ? num2 : num1;
      default:
        return 0;
    }
  }

  private static int getPrimitiveY(int primitiveShortIndex)
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    switch (animManData.primitiveData[primitiveShortIndex])
    {
      case 0:
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
      case 9:
      case 11:
      case 12:
        return (int) animManData.primitiveData[primitiveShortIndex + 2];
      case 8:
        int num1 = (int) animManData.primitiveData[primitiveShortIndex + 2];
        int num2 = (int) animManData.primitiveData[primitiveShortIndex + 4];
        return num1 >= num2 ? num2 : num1;
      default:
        return 0;
    }
  }

  private static int getPrimitiveWidth(int primitiveShortIndex)
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    switch (animManData.primitiveData[primitiveShortIndex])
    {
      case 0:
      case 11:
        int index = (int) animManData.primitiveData[primitiveShortIndex + 3] & (int) ushort.MaxValue;
        return (int) animManData.m_subImages[index][3];
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
        return (int) animManData.primitiveData[primitiveShortIndex + 3];
      case 8:
        int num = (int) animManData.primitiveData[primitiveShortIndex + 1] - (int) animManData.primitiveData[primitiveShortIndex + 3];
        return num >= 0 ? num : -num;
      case 9:
        return 0;
      case 12:
        return (int) animManData.primitiveData[3] - (int) animManData.primitiveData[1];
      default:
        return 0;
    }
  }

  private static int getPrimitiveHeight(int primitiveShortIndex)
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    switch (animManData.primitiveData[primitiveShortIndex])
    {
      case 0:
      case 11:
        int index = (int) animManData.primitiveData[primitiveShortIndex + 3] & (int) ushort.MaxValue;
        return (int) animManData.m_subImages[index][4];
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
        return (int) animManData.primitiveData[primitiveShortIndex + 4];
      case 8:
        int num = (int) animManData.primitiveData[primitiveShortIndex + 2] - (int) animManData.primitiveData[primitiveShortIndex + 4];
        return num >= 0 ? num : -num;
      case 9:
        return 0;
      case 12:
        return (int) animManData.primitiveData[4] - (int) animManData.primitiveData[2];
      default:
        return 0;
    }
  }

  public static int getAnimFrameX(int animID, int frameID)
  {
    animID &= -16385;
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    int index1 = (int) animManData.animFrameOffset[animID] + frameID;
    int primitiveShortIndex = animManData.framePrimitiveOffset[index1];
    int frameNumPrimitive = (int) animManData.frameNumPrimitives[index1];
    if (frameNumPrimitive == 0)
      return 0;
    int num = int.MaxValue;
    for (int index2 = 0; index2 != frameNumPrimitive; ++index2)
    {
      int primitiveType = (int) animManData.primitiveData[primitiveShortIndex];
      if (primitiveType != 10)
      {
        int primitiveX = AnimationManager.getPrimitiveX(primitiveShortIndex);
        if (primitiveX < num)
          num = primitiveX;
      }
      primitiveShortIndex += AnimationManager.getNumAttributes(primitiveType);
    }
    return num;
  }

  public static int getAnimFrameY(int animID, int frameID)
  {
    animID &= -16385;
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    int index1 = (int) animManData.animFrameOffset[animID] + frameID;
    int primitiveShortIndex = animManData.framePrimitiveOffset[index1];
    int frameNumPrimitive = (int) animManData.frameNumPrimitives[index1];
    if (frameNumPrimitive == 0)
      return 0;
    int num = int.MaxValue;
    for (int index2 = 0; index2 != frameNumPrimitive; ++index2)
    {
      int primitiveType = (int) animManData.primitiveData[primitiveShortIndex];
      if (primitiveType != 10)
      {
        int primitiveY = AnimationManager.getPrimitiveY(primitiveShortIndex);
        if (primitiveY < num)
          num = primitiveY;
      }
      primitiveShortIndex += AnimationManager.getNumAttributes(primitiveType);
    }
    return num;
  }

  public static int getAnimFrameWidth(int animID, int frameID)
  {
    animID &= -16385;
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    int index1 = (int) animManData.animFrameOffset[animID] + frameID;
    int primitiveShortIndex = animManData.framePrimitiveOffset[index1];
    int frameNumPrimitive = (int) animManData.frameNumPrimitives[index1];
    if (frameNumPrimitive == 0)
      return 0;
    int num1 = int.MaxValue;
    int num2 = int.MinValue;
    for (int index2 = 0; index2 != frameNumPrimitive; ++index2)
    {
      int primitiveType = (int) animManData.primitiveData[primitiveShortIndex];
      if (primitiveType != 10)
      {
        int primitiveX = AnimationManager.getPrimitiveX(primitiveShortIndex);
        int num3 = primitiveX + AnimationManager.getPrimitiveWidth(primitiveShortIndex);
        if (primitiveX < num1)
          num1 = primitiveX;
        if (num3 > num2)
          num2 = num3;
      }
      primitiveShortIndex += AnimationManager.getNumAttributes(primitiveType);
    }
    return num2 - num1;
  }

  public static int getAnimFrameHeight(int animID, int frameID)
  {
    animID &= -16385;
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    int index1 = (int) animManData.animFrameOffset[animID] + frameID;
    int primitiveShortIndex = animManData.framePrimitiveOffset[index1];
    int frameNumPrimitive = (int) animManData.frameNumPrimitives[index1];
    if (frameNumPrimitive == 0)
      return 0;
    int num1 = int.MaxValue;
    int num2 = int.MinValue;
    for (int index2 = 0; index2 != frameNumPrimitive; ++index2)
    {
      int primitiveType = (int) animManData.primitiveData[primitiveShortIndex];
      if (primitiveType != 10)
      {
        int primitiveY = AnimationManager.getPrimitiveY(primitiveShortIndex);
        int num3 = primitiveY + AnimationManager.getPrimitiveHeight(primitiveShortIndex);
        if (primitiveY < num1)
          num1 = primitiveY;
        if (num3 > num2)
          num2 = num3;
      }
      primitiveShortIndex += AnimationManager.getNumAttributes(primitiveType);
    }
    return num2 - num1;
  }

  public static int getAnimFrameFirePointCount(int animID, int frameID)
  {
    animID &= -16385;
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    int index1 = (int) animManData.animFrameOffset[animID] + frameID;
    int index2 = animManData.framePrimitiveOffset[index1];
    int frameNumPrimitive = (int) animManData.frameNumPrimitives[index1];
    int num = 0;
    for (int index3 = 0; index3 != frameNumPrimitive; ++index3)
    {
      int primitiveType = (int) animManData.primitiveData[index2];
      if (primitiveType == 7)
        ++num;
      index2 += AnimationManager.getNumAttributes(primitiveType);
    }
    return num;
  }

  public static bool getAnimFrameFirePoint(
    ref int[] result,
    int animID,
    int frameID,
    int firePointIDConst)
  {
    bool flag = false;
    if ((animID & 16384) != 0)
    {
      animID &= -16385;
      flag = true;
    }
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    int num = firePointIDConst;
    int index1 = (int) animManData.animFrameOffset[animID] + frameID;
    int index2 = animManData.framePrimitiveOffset[index1];
    int frameNumPrimitive = (int) animManData.frameNumPrimitives[index1];
    for (int index3 = 0; index3 != frameNumPrimitive; ++index3)
    {
      int primitiveType = (int) animManData.primitiveData[index2];
      if (primitiveType == 7)
      {
        if (num == 0)
        {
          result[0] = (int) animManData.primitiveData[index2 + 1];
          result[1] = (int) animManData.primitiveData[index2 + 2];
          if (flag)
            result[0] = -result[0];
          return true;
        }
        --num;
      }
      index2 += AnimationManager.getNumAttributes(primitiveType);
    }
    result[0] = 0;
    result[1] = 0;
    return false;
  }

  public static bool getAnimFrameFirePoint(
    int[] result,
    int animID,
    int frameID,
    int firePointIDConst)
  {
    bool flag = false;
    if ((animID & 16384) != 0)
    {
      animID &= -16385;
      flag = true;
    }
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    int num = firePointIDConst;
    int index1 = (int) animManData.animFrameOffset[animID] + frameID;
    int index2 = animManData.framePrimitiveOffset[index1];
    int frameNumPrimitive = (int) animManData.frameNumPrimitives[index1];
    for (int index3 = 0; index3 != frameNumPrimitive; ++index3)
    {
      int primitiveType = (int) animManData.primitiveData[index2];
      if (primitiveType == 7)
      {
        if (num == 0)
        {
          result[0] = (int) animManData.primitiveData[index2 + 1];
          result[1] = (int) animManData.primitiveData[index2 + 2];
          if (flag)
            result[0] = -result[0];
          return true;
        }
        --num;
      }
      index2 += AnimationManager.getNumAttributes(primitiveType);
    }
    result[0] = 0;
    result[1] = 0;
    return false;
  }

  public static bool getAnimFrameCollisionBox(
    ref int[] result,
    int animID,
    int frameID,
    int boxID)
  {
    bool flag = false;
    if ((animID & 16384) != 0)
    {
      animID &= -16385;
      flag = true;
    }
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    if (animID != -1)
    {
      int index1 = (int) animManData.animFrameOffset[animID] + frameID;
      int index2 = animManData.framePrimitiveOffset[index1];
      int frameNumPrimitive = (int) animManData.frameNumPrimitives[index1];
      int num1 = 0;
      for (int index3 = 0; index3 != frameNumPrimitive; ++index3)
      {
        int primitiveType = (int) animManData.primitiveData[index2];
        if (primitiveType == 2)
        {
          if (num1 == boxID)
          {
            result[0] = (int) animManData.primitiveData[index2 + 1];
            result[1] = (int) animManData.primitiveData[index2 + 2];
            result[2] = (int) animManData.primitiveData[index2 + 3];
            result[3] = (int) animManData.primitiveData[index2 + 4];
            int num2 = flag ? 1 : 0;
            return true;
          }
          ++num1;
        }
        index2 += AnimationManager.getNumAttributes(primitiveType);
      }
    }
    result[0] = 0;
    result[1] = 0;
    result[2] = 0;
    result[3] = 0;
    return false;
  }

  public static bool getAnimFrameCollisionBox(int[] result, int animID, int frameID, int boxID)
  {
    bool flag = false;
    if ((animID & 16384) != 0)
    {
      animID &= -16385;
      flag = true;
    }
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    if (animID != -1)
    {
      int index1 = (int) animManData.animFrameOffset[animID] + frameID;
      int index2 = animManData.framePrimitiveOffset[index1];
      int frameNumPrimitive = (int) animManData.frameNumPrimitives[index1];
      int num1 = 0;
      for (int index3 = 0; index3 != frameNumPrimitive; ++index3)
      {
        int primitiveType = (int) animManData.primitiveData[index2];
        if (primitiveType == 2)
        {
          if (num1 == boxID)
          {
            result[0] = (int) animManData.primitiveData[index2 + 1];
            result[1] = (int) animManData.primitiveData[index2 + 2];
            result[2] = (int) animManData.primitiveData[index2 + 3];
            result[3] = (int) animManData.primitiveData[index2 + 4];
            int num2 = flag ? 1 : 0;
            return true;
          }
          ++num1;
        }
        index2 += AnimationManager.getNumAttributes(primitiveType);
      }
    }
    result[0] = 0;
    result[1] = 0;
    result[2] = 0;
    result[3] = 0;
    return false;
  }

  public static int getImageIndex(int resID)
  {
    int index = 0;
    while (index < 0 && resID != (int) GlobalConstants.IMAGE_RES_IDS[index])
      ++index;
    return index;
  }

  public static Image getImage(int imageIndex)
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    if (imageIndex < 0 || imageIndex >= 0)
      return (Image) null;
    Image image = animManData.m_animImageArray[animManData.m_curBank][imageIndex];
    return animManData.m_animImageArray[animManData.m_curBank][imageIndex];
  }

  public static void drawAnim(Graphics g, AnimPlayer p, int x, int y)
  {
    AnimationManager.drawAnimFrame(g, p.getAnimID(), p.getCurrAnimFrame(), x, y);
  }

  public static bool startAnimReverse(int animID, int bitFlag)
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    int index1 = -1;
    for (int index2 = 0; index2 < 48; ++index2)
    {
      if (animManData.m_animPlayerPool[index2].isAnimating())
      {
        if (animManData.m_animPlayerPool[index2].getAnimID() == animID)
          return true;
      }
      else if (index1 < 0)
        index1 = index2;
    }
    if (index1 < 0)
      return false;
    animManData.m_animPlayerPool[index1].startAnim(animID, bitFlag);
    animManData.m_animPlayerPool[index1].setReverse(true);
    return true;
  }

  public static bool startAnim(int animID, int bitFlag)
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    int index1 = -1;
    for (int index2 = 0; index2 < 48; ++index2)
    {
      if (animManData.m_animPlayerPool[index2].isAnimating())
      {
        if (animManData.m_animPlayerPool[index2].getAnimID() == animID)
          return true;
      }
      else if (index1 < 0)
        index1 = index2;
    }
    if (index1 < 0)
      return false;
    animManData.m_animPlayerPool[index1].startAnim(animID, bitFlag);
    animManData.m_animPlayerPool[index1].setReverse(false);
    return true;
  }

  public static void updateAnims(int timeStep)
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    for (int index = 0; index < 48; ++index)
      animManData.m_animPlayerPool[index].updateAnim(timeStep);
  }

  public static bool drawAnim(Graphics g, int animID, int x, int y)
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    for (int index = 0; index < 48; ++index)
    {
      AnimPlayer animPlayer = animManData.m_animPlayerPool[index];
      if (animPlayer.getAnimID() == animID)
      {
        AnimationManager.drawAnimFrame(g, animID, animPlayer.getCurrAnimFrame(), x, y);
        return true;
      }
    }
    return false;
  }

  public static bool drawAnim(Graphics g, ref AnimPlayer p, int x, int y)
  {
    if (p.getAnimID() < 0)
      return false;
    AnimationManager.drawAnimFrame(g, p.getAnimID(), p.getCurrAnimFrame(), x, y);
    return true;
  }

  public static void stopAnim(int animID)
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    for (int index = 0; index < 48; ++index)
    {
      if (animManData.m_animPlayerPool[index].getAnimID() == animID)
        animManData.m_animPlayerPool[index].setAnimating(false);
    }
  }

  public static void stopAllAnims()
  {
    AnimationManagerData animManData = AppEngine.getCanvas().getAnimManData();
    for (int index = 0; index < 48; ++index)
      animManData.m_animPlayerPool[index].setAnimating(false);
  }

  public static bool loadImage(
    AnimationManagerData thisData,
    ResourceManager resourceManager,
    int resID)
  {
    int imageIndex = AnimationManager.getImageIndex(resID);
    if (imageIndex == 0)
      return false;
    int index = 0;
    if (thisData.m_animImageArray[index][imageIndex] == null)
    {
      Image image = ResourceManager.loadImage(resID);
      thisData.m_animImageArray[index][imageIndex] = image;
    }
    return true;
  }

  public static void setBank(int bank)
  {
    AppEngine.ASSERT(bank >= 0 && bank < 1, "invalid bank");
    AppEngine.getCanvas().getAnimManData().m_curBank = bank;
  }

  public bool drawAnimFrameExt(
    Graphics g,
    int animID,
    int frameID,
    int x,
    int y,
    int extraAnimId,
    int extraIndex,
    ref int[] firepoint)
  {
    return animID >= 0 && AnimationManager.drawNormalAnimFrameExt(g, animID, frameID, x, y, extraAnimId, extraIndex, firepoint);
  }
}
