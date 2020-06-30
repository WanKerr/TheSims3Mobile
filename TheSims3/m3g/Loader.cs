// Decompiled with JetBrains decompiler
// Type: m3g.Loader
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace m3g
{
  public class Loader
  {
    private static byte[] M3G_FILE_IDENTIFIER = new byte[12]
    {
      (byte) 171,
      (byte) 74,
      (byte) 83,
      (byte) 82,
      (byte) 49,
      (byte) 56,
      (byte) 52,
      (byte) 187,
      (byte) 13,
      (byte) 10,
      (byte) 26,
      (byte) 10
    };
    private const int M3G_FILE_IDENTIFIER_LENGTH = 12;

    public static int reverseBytes(int value)
    {
      return (int) (((long) value & 4278190080L) >> 24 & (long) byte.MaxValue) | (value & 16711680) >> 8 | (value & 65280) << 8 | (value & (int) byte.MaxValue) << 24;
    }

    public static short reverseBytes(short value)
    {
      return (short) (((int) value & 65280) >> 8 & (int) byte.MaxValue | ((int) value & (int) byte.MaxValue) << 8);
    }

    public static short readShortLE(ref DataInputStream @in)
    {
      return Loader.reverseBytes(@in.readShort());
    }

    public static int readUShortLE(ref DataInputStream @in)
    {
      return (int) Loader.readShortLE(ref @in) & (int) ushort.MaxValue;
    }

    public static int readIntLE(ref DataInputStream @in)
    {
      return Loader.reverseBytes(@in.readInt());
    }

    public static float readFloatLE(ref DataInputStream @in)
    {
      return BitConverter.ToSingle(BitConverter.GetBytes(Loader.readIntLE(ref @in)), 0);
    }

    private static bool loadSection(
      DataInputStream @in,
      List<Object3D> objectList,
      List<Object3D> rootObjectList)
    {
      if (@in.read() == -1)
        return false;
      int num = Loader.readIntLE(ref @in);
      Loader.readIntLE(ref @in);
      int length = num - 13;
      sbyte[] numArray = new sbyte[length];
      @in.readFully(numArray, length);
      @in.skip(4L);
      DataInputStream in1 = new DataInputStream((InputStream) new ByteArrayInputStream(numArray, length));
      do
        ;
      while (Loader.loadObject(ref in1, ref objectList, ref rootObjectList));
      return true;
    }

    public static Object3D[] load(sbyte[] data, int offset)
    {
      return Loader.load((InputStream) new ByteArrayInputStream(data, offset, data.Length - offset));
    }

    public static Object3D[] load(string filename)
    {
      return (Object3D[]) null;
    }

    public static Object3D[] load(InputStream stream)
    {
      DataInputStream @in = new DataInputStream(stream);
      sbyte[] b = new sbyte[12];
      @in.readFully(b, 12);
      for (int index = 0; index < 12; ++index)
      {
        int num1 = (int) b[index] & (int) byte.MaxValue;
        int num2 = (int) Loader.M3G_FILE_IDENTIFIER[index] & (int) byte.MaxValue;
      }
      List<Object3D> rootObjectList = new List<Object3D>(30);
      List<Object3D> objectList = new List<Object3D>(30);
      objectList.Add((Object3D) null);
      int num = 0;
      while (Loader.loadSection(ref @in, ref objectList, ref rootObjectList))
        ++num;
      @in.close();
      return rootObjectList.ToArray();
    }

    private static bool loadSection(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      if (@in.read() == -1)
        return false;
      int num = Loader.readIntLE(ref @in);
      Loader.readIntLE(ref @in);
      int length = num - 13;
      sbyte[] numArray = new sbyte[length];
      @in.readFully(numArray, length);
      @in.skip(4L);
      DataInputStream in1 = new DataInputStream((InputStream) new ByteArrayInputStream(numArray, length));
      do
        ;
      while (Loader.loadObject(ref in1, ref objectList, ref rootObjectList));
      return true;
    }

    private static bool loadObject(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      int num = @in.read();
      if (num == -1)
        return false;
      int length = Loader.readIntLE(ref @in);
      sbyte[] numArray = new sbyte[length];
      @in.readFully(numArray, length);
      DataInputStream in1 = new DataInputStream((InputStream) new ByteArrayInputStream(numArray, length));
      object obj = (object) null;
      switch (num)
      {
        case 0:
          in1.readUnsignedByte();
          in1.readUnsignedByte();
          in1.readBoolean();
          Loader.readIntLE(ref in1);
          Loader.readIntLE(ref in1);
          break;
        case 1:
          obj = Loader.loadAnimationController(ref in1, ref objectList, ref rootObjectList);
          break;
        case 2:
          obj = Loader.loadAnimationTrack(ref in1, ref objectList, ref rootObjectList);
          break;
        case 3:
          obj = Loader.loadAppearance(ref in1, ref objectList, ref rootObjectList);
          break;
        case 5:
          obj = Loader.loadCamera(ref in1, ref objectList, ref rootObjectList);
          break;
        case 6:
          obj = Loader.loadCompositingMode(ref in1, ref objectList, ref rootObjectList);
          break;
        case 8:
          obj = Loader.loadPolygonMode(ref in1, ref objectList, ref rootObjectList);
          break;
        case 9:
          obj = (object) new Group();
          Loader.loadGroup((Group) obj, ref in1, ref objectList, ref rootObjectList);
          break;
        case 10:
          obj = Loader.loadImage2D(ref in1, ref objectList, ref rootObjectList);
          break;
        case 11:
          obj = Loader.loadTriangleStripArray(ref in1, ref objectList, ref rootObjectList);
          break;
        case 14:
          obj = (object) new Mesh();
          Loader.loadMesh((Mesh) obj, ref in1, ref objectList, ref rootObjectList);
          break;
        case 16:
          obj = Loader.loadSkinnedMesh(ref in1, ref objectList, ref rootObjectList);
          break;
        case 17:
          obj = Loader.loadTexture2D(ref in1, ref objectList, ref rootObjectList);
          break;
        case 19:
          obj = Loader.loadKeyframeSequence(ref in1, ref objectList, ref rootObjectList);
          break;
        case 20:
          obj = Loader.loadVertexArray(ref in1, ref objectList, ref rootObjectList);
          break;
        case 21:
          obj = Loader.loadVertexBuffer(ref in1, ref objectList, ref rootObjectList);
          break;
        case 22:
          obj = Loader.loadWorld(ref in1, ref objectList, ref rootObjectList);
          break;
      }
      objectList.Add((Object3D) obj);
      if (obj != null)
        rootObjectList.Add((Object3D) obj);
      return true;
    }

    private static void loadObject3D(
      Object3D @object,
      ref DataInputStream @in,
      ref List<Object3D> objects,
      ref List<Object3D> rootObjects)
    {
      int userID = Loader.readIntLE(ref @in);
      @object.setUserID(userID);
      int num1 = Loader.readIntLE(ref @in);
      for (int index = 0; index < num1; ++index)
      {
        AnimationTrack reference = (AnimationTrack) Loader.getReference(ref @in, ref objects, ref rootObjects);
        @object.addAnimationTrack(reference);
      }
      int num2 = Loader.readIntLE(ref @in);
      for (int index = 0; index < num2; ++index)
      {
        Loader.readIntLE(ref @in);
        sbyte[] b = new sbyte[Loader.readIntLE(ref @in)];
        @in.readFully(b);
      }
    }

    private static void loadIndexBuffer(
      IndexBuffer @object,
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      Loader.loadObject3D((Object3D) @object, ref @in, ref objectList, ref rootObjectList);
      switch (@in.readUnsignedByte())
      {
        case 0:
          int index1 = Loader.readIntLE(ref @in);
          @object.setFirstIndex(index1);
          break;
        case 1:
          int index2 = @in.readUnsignedByte();
          @object.setFirstIndex(index2);
          break;
        case 2:
          int index3 = (int) Loader.readShortLE(ref @in);
          @object.setFirstIndex(index3);
          break;
        case 128:
          int length1 = Loader.readIntLE(ref @in);
          int[] indices1 = new int[length1];
          for (int index4 = 0; index4 < length1; ++index4)
            indices1[index4] = Loader.readIntLE(ref @in);
          @object.setIndices(indices1);
          break;
        case 129:
          int length2 = Loader.readIntLE(ref @in);
          int[] indices2 = new int[length2];
          for (int index4 = 0; index4 < length2; ++index4)
            indices2[index4] = @in.readUnsignedByte();
          @object.setIndices(indices2);
          break;
        case 130:
          int length3 = Loader.readIntLE(ref @in);
          int[] indices3 = new int[length3];
          for (int index4 = 0; index4 < length3; ++index4)
            indices3[index4] = (int) Loader.readShortLE(ref @in);
          @object.setIndices(indices3);
          break;
      }
    }

    private static void loadTransformable(
      Transformable @object,
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      Loader.loadObject3D((Object3D) @object, ref @in, ref objectList, ref rootObjectList);
      if (@in.readBoolean())
      {
        float x1 = Loader.readFloatLE(ref @in);
        float y1 = Loader.readFloatLE(ref @in);
        float z1 = Loader.readFloatLE(ref @in);
        @object.setTranslation(x1, y1, z1);
        float sx = Loader.readFloatLE(ref @in);
        float sy = Loader.readFloatLE(ref @in);
        float sz = Loader.readFloatLE(ref @in);
        @object.setScale(sx, sy, sz);
        float degrees = Loader.readFloatLE(ref @in);
        float x2 = Loader.readFloatLE(ref @in);
        float y2 = Loader.readFloatLE(ref @in);
        float z2 = Loader.readFloatLE(ref @in);
        @object.setOrientation(degrees, x2, y2, z2);
      }
      if (!@in.readBoolean())
        return;
      float[] matrix = new float[16];
      for (int index = 0; index < 16; ++index)
        matrix[index] = Loader.readFloatLE(ref @in);
      Transform transform = new Transform();
      transform.set(matrix);
      @object.setTransform(transform);
    }

    private static void loadNode(
      Node @object,
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      Loader.loadTransformable((Transformable) @object, ref @in, ref objectList, ref rootObjectList);
      bool enable1 = @in.readBoolean();
      bool enable2 = @in.readBoolean();
      int num = @in.readUnsignedByte();
      int scope = @in.readInt();
      if (@in.readBoolean())
      {
        @in.readUnsignedByte();
        @in.readUnsignedByte();
        List<Object3D> rootObjectList1 = (List<Object3D>) null;
        Loader.getReference(ref @in, ref objectList, ref rootObjectList1);
        rootObjectList1 = (List<Object3D>) null;
        Loader.getReference(ref @in, ref objectList, ref rootObjectList1);
      }
      @object.setRenderingEnable(enable1);
      @object.setPickingEnable(enable2);
      @object.setAlphaFactor((float) num / (float) byte.MaxValue);
      @object.setScope(scope);
    }

    private static void loadGroup(
      Group @object,
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      Loader.loadNode((Node) @object, ref @in, ref objectList, ref rootObjectList);
      int num = Loader.readIntLE(ref @in);
      for (int index = 0; index < num; ++index)
      {
        Node reference = (Node) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
        @object.addChild(reference);
      }
    }

    private static void loadMesh(
      Mesh @object,
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      Loader.loadNode((Node) @object, ref @in, ref objectList, ref rootObjectList);
      VertexBuffer reference1 = (VertexBuffer) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
      @object.setVertexBuffer(reference1);
      int count = Loader.readIntLE(ref @in);
      @object.setSubmeshCount(count);
      for (int index = 0; index < count; ++index)
      {
        IndexBuffer reference2 = (IndexBuffer) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
        @object.setIndexBuffer(index, reference2);
        Appearance reference3 = (Appearance) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
        @object.setAppearance(index, reference3);
      }
    }

    private static object loadAnimationController(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      AnimationController animationController = new AnimationController();
      Loader.loadObject3D((Object3D) animationController, ref @in, ref objectList, ref rootObjectList);
      float speed = Loader.readFloatLE(ref @in);
      float weight = Loader.readFloatLE(ref @in);
      int start = Loader.readIntLE(ref @in);
      int end = Loader.readIntLE(ref @in);
      float sequenceTime = Loader.readFloatLE(ref @in);
      int worldTime = Loader.readIntLE(ref @in);
      animationController.setActiveInterval(start, end);
      animationController.setPosition(sequenceTime, worldTime);
      animationController.setSpeed(speed, worldTime);
      animationController.setWeight(weight);
      return (object) animationController;
    }

    private static object loadAnimationTrack(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      AnimationTrack animationTrack = new AnimationTrack();
      Loader.loadObject3D((Object3D) animationTrack, ref @in, ref objectList, ref rootObjectList);
      KeyframeSequence reference1 = (KeyframeSequence) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
      AnimationController reference2 = (AnimationController) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
      int property = Loader.readIntLE(ref @in);
      animationTrack.setKeyframeSequence(reference1);
      animationTrack.setProperty(property);
      animationTrack.setController(reference2);
      return (object) animationTrack;
    }

    private static object loadAppearance(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      Appearance appearance = new Appearance();
      Loader.loadObject3D((Object3D) appearance, ref @in, ref objectList, ref rootObjectList);
      sbyte num1 = (sbyte) @in.readUnsignedByte();
      appearance.setLayer((int) num1);
      CompositingMode reference1 = (CompositingMode) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
      appearance.setCompositingMode(reference1);
      Fog reference2 = (Fog) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
      appearance.setFog(reference2);
      PolygonMode reference3 = (PolygonMode) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
      appearance.setPolygonMode(reference3);
      Material reference4 = (Material) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
      appearance.setMaterial(reference4);
      int num2 = Loader.readIntLE(ref @in);
      for (int index = 0; index < num2; ++index)
      {
        Texture2D reference5 = (Texture2D) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
        appearance.setTexture(index, reference5);
      }
      return (object) appearance;
    }

    private static object loadCamera(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      Camera camera = new Camera();
      Loader.loadNode((Node) camera, ref @in, ref objectList, ref rootObjectList);
      int num = @in.readUnsignedByte();
      if (num == 48)
      {
        Transform transform = new Transform();
        float[] matrix = new float[16];
        for (int index = 0; index != 16; ++index)
          matrix[index] = Loader.readFloatLE(ref @in);
        transform.set(matrix);
        camera.setGeneric(transform);
      }
      else
      {
        float fovy = Loader.readFloatLE(ref @in);
        float aspectRatio = Loader.readFloatLE(ref @in);
        float nearClip = Loader.readFloatLE(ref @in);
        float farClip = Loader.readFloatLE(ref @in);
        if (num == 49)
          camera.setParallel(fovy, aspectRatio, nearClip, farClip);
        else
          camera.setPerspective(fovy, aspectRatio, nearClip, farClip);
      }
      return (object) camera;
    }

    private static object loadCompositingMode(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      CompositingMode compositingMode = new CompositingMode();
      Loader.loadObject3D((Object3D) compositingMode, ref @in, ref objectList, ref rootObjectList);
      bool enable1 = @in.readBoolean();
      bool enable2 = @in.readBoolean();
      bool enable3 = @in.readBoolean();
      bool enable4 = @in.readBoolean();
      int mode = @in.readUnsignedByte();
      float threshold = (float) @in.readUnsignedByte() / (float) byte.MaxValue;
      float factor = Loader.readFloatLE(ref @in);
      float units = Loader.readFloatLE(ref @in);
      compositingMode.setDepthTestEnable(enable1);
      compositingMode.setDepthWriteEnable(enable2);
      compositingMode.setColorWriteEnable(enable3);
      compositingMode.setAlphaWriteEnable(enable4);
      compositingMode.setBlending(mode);
      compositingMode.setAlphaThreshold(threshold);
      compositingMode.setDepthOffset(factor, units);
      return (object) compositingMode;
    }

    private static object loadImage2D(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      Image2D image2D = new Image2D();
      Loader.loadObject3D((Object3D) image2D, ref @in, ref objectList, ref rootObjectList);
      int format = @in.readUnsignedByte();
      bool flag = @in.readBoolean();
      int width = Loader.readIntLE(ref @in);
      int height = Loader.readIntLE(ref @in);
      image2D.set(format, width, height);
      if (!flag)
      {
        sbyte[] numArray1 = (sbyte[]) null;
        int length = Loader.readIntLE(ref @in);
        if (length > 0)
        {
          numArray1 = new sbyte[length];
          @in.readFully(numArray1);
        }
        int len = Loader.readIntLE(ref @in);
        sbyte[] numArray2 = new sbyte[len];
        @in.readFully(numArray2, len);
        if (numArray1 != null)
        {
          image2D.commit(numArray1, numArray2);
        }
        else
        {
          byte[] pixels = new byte[numArray2.Length];
          Buffer.BlockCopy((Array) numArray2, 0, (Array) pixels, 0, numArray2.Length);
          image2D.commit(pixels);
        }
      }
      return (object) image2D;
    }

    private static object loadKeyframeSequence(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      KeyframeSequence keyframeSequence = new KeyframeSequence();
      Loader.loadObject3D((Object3D) keyframeSequence, ref @in, ref objectList, ref rootObjectList);
      int interpolation = @in.readUnsignedByte();
      int mode = @in.readUnsignedByte();
      int num1 = @in.readUnsignedByte();
      int duration = Loader.readIntLE(ref @in);
      int first = Loader.readIntLE(ref @in);
      int last = Loader.readIntLE(ref @in);
      int numComponents = Loader.readIntLE(ref @in);
      int numKeyframes = Loader.readIntLE(ref @in);
      keyframeSequence.setInterpolation(interpolation);
      keyframeSequence.setRepeatMode(mode);
      keyframeSequence.setDuration(duration);
      keyframeSequence.setKeyframeSize(numKeyframes, numComponents);
      keyframeSequence.setValidRange(first, last);
      switch (num1)
      {
        case 0:
          float[] numArray1 = new float[numComponents];
          for (int index1 = 0; index1 < numKeyframes; ++index1)
          {
            int time = Loader.readIntLE(ref @in);
            for (int index2 = 0; index2 < numComponents; ++index2)
              numArray1[index2] = Loader.readFloatLE(ref @in);
            keyframeSequence.setKeyframe(index1, time, numArray1);
          }
          break;
        case 2:
          float num2 = 1.525902E-05f;
          float[] numArray2 = new float[4];
          float[] numArray3 = new float[4];
          for (int index = 0; index < numComponents; ++index)
            numArray2[index] = Loader.readFloatLE(ref @in);
          for (int index = 0; index < numComponents; ++index)
            numArray3[index] = Loader.readFloatLE(ref @in);
          float[] numArray4 = new float[numComponents];
          for (int index1 = 0; index1 < numKeyframes; ++index1)
          {
            int time = Loader.readIntLE(ref @in);
            for (int index2 = 0; index2 < numComponents; ++index2)
            {
              float num3 = (float) Loader.readUShortLE(ref @in) * num2 * numArray3[index2] + numArray2[index2];
              numArray4[index2] = num3;
            }
            keyframeSequence.setKeyframe(index1, time, numArray4);
          }
          break;
      }
      return (object) keyframeSequence;
    }

    private static object loadSkinnedMesh(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      SkinnedMesh skinnedMesh = new SkinnedMesh();
      Loader.loadMesh((Mesh) skinnedMesh, ref @in, ref objectList, ref rootObjectList);
      Group reference1 = (Group) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
      skinnedMesh.setSkeleton(reference1);
      bool flag = true;
      if (flag)
        skinnedMesh.setLegacy(true);
      int length = Loader.readIntLE(ref @in);
      if (flag)
      {
        for (int index = 0; index < length; ++index)
        {
          Node reference2 = (Node) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
          int firstVertex = Loader.readIntLE(ref @in);
          int numVertices = Loader.readIntLE(ref @in);
          int weight = Loader.readIntLE(ref @in);
          skinnedMesh.addTransform(reference2, weight, firstVertex, numVertices);
        }
      }
      else
      {
        Node[] bones = new Node[length];
        for (int index = 0; index < length; ++index)
          bones[index] = (Node) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
        skinnedMesh.setBones(bones);
      }
      return (object) skinnedMesh;
    }

    private static object loadPolygonMode(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      PolygonMode polygonMode = new PolygonMode();
      Loader.loadObject3D((Object3D) polygonMode, ref @in, ref objectList, ref rootObjectList);
      int mode1 = @in.readUnsignedByte();
      int mode2 = @in.readUnsignedByte();
      int mode3 = @in.readUnsignedByte();
      bool enable1 = @in.readBoolean();
      bool enable2 = @in.readBoolean();
      bool enable3 = @in.readBoolean();
      polygonMode.setCulling(mode1);
      polygonMode.setShading(mode2);
      polygonMode.setWinding(mode3);
      polygonMode.setTwoSidedLightingEnable(enable1);
      polygonMode.setLocalCameraLightingEnable(enable2);
      polygonMode.setPerspectiveCorrectionEnable(enable3);
      return (object) polygonMode;
    }

    private static object loadTexture2D(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      Texture2D texture2D = new Texture2D();
      Loader.loadTransformable((Transformable) texture2D, ref @in, ref objectList, ref rootObjectList);
      Image2D reference = (Image2D) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
      texture2D.setImage(reference);
      uint num1 = (uint) @in.readUnsignedByte();
      uint num2 = (uint) @in.readUnsignedByte();
      uint num3 = (uint) @in.readUnsignedByte();
      int blending = @in.readUnsignedByte();
      int wrapS = @in.readUnsignedByte();
      int wrapT = @in.readUnsignedByte();
      int levelFilter = @in.readUnsignedByte();
      int imageFilter = @in.readUnsignedByte();
      texture2D.setBlendColor((int) num1 << 16 | (int) num2 << 8 | (int) num3);
      texture2D.setBlending(blending);
      texture2D.setWrapping(wrapS, wrapT);
      texture2D.setFiltering(levelFilter, imageFilter);
      return (object) texture2D;
    }

    private static object loadTriangleStripArray(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      TriangleStripArray triangleStripArray = new TriangleStripArray();
      Loader.loadIndexBuffer((IndexBuffer) triangleStripArray, ref @in, ref objectList, ref rootObjectList);
      int length = Loader.readIntLE(ref @in);
      int[] stripLengths = new int[length];
      for (int index = 0; index < length; ++index)
        stripLengths[index] = Loader.readIntLE(ref @in);
      triangleStripArray.setStripLengths(stripLengths);
      return (object) triangleStripArray;
    }

    private static object loadVertexArray(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      VertexArray vertexArray = new VertexArray();
      Loader.loadObject3D((Object3D) vertexArray, ref @in, ref objectList, ref rootObjectList);
      int componentType = @in.readUnsignedByte();
      int componentCount = @in.readUnsignedByte();
      int num1 = @in.readUnsignedByte();
      int num2 = (int) Loader.readShortLE(ref @in);
      vertexArray.setFormat(num2, componentCount, componentType);
      if (num1 == 0)
      {
        switch (componentType)
        {
          case 1:
            sbyte[] src1 = new sbyte[num2 * componentCount];
            for (int index = 0; index < num2 * componentCount; ++index)
              src1[index] = @in.readByte();
            vertexArray.set(0, num2, src1);
            break;
          case 2:
          case 5:
            short[] src2 = new short[num2 * componentCount];
            for (int index = 0; index < num2 * componentCount; ++index)
              src2[index] = Loader.readShortLE(ref @in);
            vertexArray.set(0, num2, src2);
            break;
          case 3:
            int[] src3 = new int[num2 * componentCount];
            for (int index = 0; index < num2 * componentCount; ++index)
              src3[index] = Loader.readIntLE(ref @in);
            vertexArray.set(0, num2, src3);
            break;
          case 4:
            float[] src4 = new float[num2 * componentCount];
            for (int index = 0; index < num2 * componentCount; ++index)
              src4[index] = Loader.readFloatLE(ref @in);
            vertexArray.set(0, num2, src4);
            break;
        }
      }
      return (object) vertexArray;
    }

    private static object loadVertexBuffer(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      VertexBuffer vertexBuffer = new VertexBuffer();
      Loader.loadObject3D((Object3D) vertexBuffer, ref @in, ref objectList, ref rootObjectList);
      uint num1 = (uint) @in.readUnsignedByte();
      uint num2 = (uint) @in.readUnsignedByte();
      uint num3 = (uint) @in.readUnsignedByte();
      uint num4 = (uint) @in.readUnsignedByte();
      vertexBuffer.setDefaultColor((int) num1 << 16 | (int) num2 << 8 | (int) num3 | (int) num4 << 24);
      VertexArray reference1 = (VertexArray) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
      float[] bias1 = new float[3]
      {
        Loader.readFloatLE(ref @in),
        Loader.readFloatLE(ref @in),
        Loader.readFloatLE(ref @in)
      };
      float scale1 = Loader.readFloatLE(ref @in);
      vertexBuffer.setPositions(reference1, scale1, bias1);
      VertexArray reference2 = (VertexArray) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
      vertexBuffer.setNormals(reference2);
      VertexArray reference3 = (VertexArray) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
      vertexBuffer.setColors(reference3);
      int num5 = Loader.readIntLE(ref @in);
      for (int index = 0; index < num5; ++index)
      {
        VertexArray reference4 = (VertexArray) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
        float[] bias2 = new float[3]
        {
          Loader.readFloatLE(ref @in),
          Loader.readFloatLE(ref @in),
          Loader.readFloatLE(ref @in)
        };
        float scale2 = Loader.readFloatLE(ref @in);
        vertexBuffer.setTexCoords(index, reference4, scale2, bias2);
      }
      return (object) vertexBuffer;
    }

    private static object loadWorld(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      World world = new World();
      Loader.loadGroup((Group) world, ref @in, ref objectList, ref rootObjectList);
      Camera reference1 = (Camera) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
      Background reference2 = (Background) Loader.getReference(ref @in, ref objectList, ref rootObjectList);
      world.setActiveCamera(reference1);
      world.setBackground(reference2);
      return (object) world;
    }

    private static object getReference(
      ref DataInputStream @in,
      ref List<Object3D> objectList,
      ref List<Object3D> rootObjectList)
    {
      int index = Loader.readIntLE(ref @in);
      Object3D object3D = objectList.ElementAt<Object3D>(index);
      if (rootObjectList != null && rootObjectList.Contains(object3D))
        rootObjectList.Remove(object3D);
      return (object) object3D;
    }
  }
}
