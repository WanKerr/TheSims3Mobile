// Decompiled with JetBrains decompiler
// Type: ModelManager
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using midp;
using sims3;
using System;

public class ModelManager : GlobalConstants
{
    public static readonly short[] CACHED_MODELS = new short[1]
    {
    (short) 7
    };
    private static ModelManager instance = new ModelManager();
    private static Transform tempReflection = new Transform();
    public const int STATUS_NONE = 0;
    public const int STATUS_SCENEMENU = 1;
    public const int STATUS_HOUSEMODE = 2;
    public const int STATUS_HOUSEMODE_HOME = 3;
    public const int STATUS_MAPMODE = 4;
    public const int STATUS_ZOOMMAPMODE = 5;
    private Appearance[] m_appearances;
    private Appearance[][] m_simAppearances;
    private string[][] m_simTextureFilenames;
    private Appearance[][] m_extAppearances;
    private int[] m_extAppearanceTimers;
    private Fog m_fog;
    private bool m_nightTextures;
    private Image2D m_hemisphereMapImage;
    private Image2D m_hemisphereMapImageDay;
    private Image2D m_hemisphereMapImageNight;
    private Node[] m_modelCache;
    private Node m_simMaleNode;
    private Group m_simMaleSkeleton;
    private Node m_simFemaleNode;
    private Group m_simFemaleSkeleton;
    private int m_status;
    private int m_townmapTimer;
    private int m_townmapCloudsTimer;
    private int m_scrollingTimer;
    private int m_lakesideTimerLayer2;
    private int m_lakesideTimerLayer3;
    private int m_lakesideTimerLayer4;
    private bool m_tvUpdatedAction;
    private bool m_tvUpdatedComedy;

    public static void collectBones(Node bone, ref Vector boneList)
    {
        boneList.addElement((object)bone);
        Group group = Group.m3g_cast((Object3D)bone);
        if (group == null)
            return;
        int childCount = group.getChildCount();
        for (int index = 0; index < childCount; ++index)
            ModelManager.collectBones(group.getChild(index), ref boneList);
    }

    private ModelManager()
    {
        this.m_appearances = (Appearance[])null;
        this.m_simAppearances = (Appearance[][])null;
        this.m_simTextureFilenames = (string[][])null;
        this.m_extAppearances = new Appearance[0][];
        this.m_extAppearanceTimers = (int[])null;
        this.m_fog = (Fog)null;
        this.m_nightTextures = false;
        this.m_hemisphereMapImage = (Image2D)null;
        this.m_hemisphereMapImageDay = (Image2D)null;
        this.m_hemisphereMapImageNight = (Image2D)null;
        this.m_modelCache = new Node[ModelManager.CACHED_MODELS.Length];
        this.m_simMaleNode = (Node)null;
        this.m_simMaleSkeleton = (Group)null;
        this.m_simFemaleNode = (Node)null;
        this.m_simFemaleSkeleton = (Group)null;
        this.m_status = 0;
        this.m_townmapTimer = 0;
        this.m_townmapCloudsTimer = 0;
        this.m_scrollingTimer = 0;
        this.m_lakesideTimerLayer2 = 0;
        this.m_lakesideTimerLayer3 = 0;
        this.m_lakesideTimerLayer4 = 0;
        this.m_tvUpdatedAction = false;
        this.m_tvUpdatedComedy = false;
    }

    public new void Dispose()
    {
        this.unload();
    }

    public void unload()
    {
        for (int index = 0; index < this.m_appearances.Length; ++index)
            this.m_appearances[index] = (Appearance)null;
        this.m_hemisphereMapImageDay = (Image2D)null;
        this.m_hemisphereMapImageNight = (Image2D)null;
        this.m_fog = (Fog)null;
        this.m_simMaleSkeleton = (Group)null;
        this.m_simMaleNode = (Node)null;
        this.m_simFemaleSkeleton = (Group)null;
        this.m_simFemaleNode = (Node)null;
        for (int index = 0; index < this.m_modelCache.Length; ++index)
            this.m_modelCache[index] = (Node)null;
        for (int index1 = 0; index1 < this.m_simTextureFilenames.Length; ++index1)
        {
            for (int index2 = 0; index2 < this.m_simTextureFilenames[index1].Length; ++index2)
                this.m_simTextureFilenames[index1][index2] = (string)null;
        }
    }

    public static ModelManager getInstance()
    {
        return ModelManager.instance;
    }

    public static void getBoundingBox(int[] result, Node node)
    {
        ModelManager.getBoundingBox(result, node, (Node)null);
    }

    public static void getBoundingBox(int[] result, Node node, Node parent)
    {
        if (parent == null)
        {
            AppEngine.fillArray(result, 0);
            ModelManager.getBoundingBox(result, node, node);
        }
        else
        {
            Group group = Group.m3g_cast((Object3D)node);
            if (group != null)
            {
                int childCount = group.getChildCount();
                for (int index = 0; index < childCount; ++index)
                {
                    Node child = group.getChild(index);
                    ModelManager.getBoundingBox(result, child, parent);
                }
            }
            Mesh mesh = Mesh.m3g_cast((Object3D)node);
            if (mesh == null)
                return;
            int[] result1 = new int[6];
            ModelManager.getBoundingBox(result1, mesh);
            int[] vector = new int[8];
            Transform transform = new Transform();
            transform.setIdentity();
            mesh.getTransformTo(parent, ref transform);
            vector[0] = result1[0];
            vector[1] = result1[1];
            vector[2] = result1[2];
            vector[3] = 65536;
            vector[4] = result1[3];
            vector[5] = result1[4];
            vector[6] = result1[5];
            vector[7] = 65536;
            transform.transformx(ref vector);
            result[0] = midp.JMath.min(result[0], vector[0]);
            result[1] = midp.JMath.min(result[1], vector[1]);
            result[2] = midp.JMath.min(result[2], vector[2]);
            result[3] = midp.JMath.max(result[3], vector[4]);
            result[4] = midp.JMath.max(result[4], vector[5]);
            result[5] = midp.JMath.max(result[5], vector[6]);
        }
    }

    public static void getBoundingBox(int[] result, Mesh mesh)
    {
        m3g.VertexBuffer vertexBuffer = mesh.getVertexBuffer();
        int vertexCount = vertexBuffer.getVertexCount();
        float[] scaleBias = new float[4];
        VertexArray positions = vertexBuffer.getPositions(ref scaleBias);
        int componentCount = positions.getComponentCount();
        float a1 = 0.0f;
        float a2 = 0.0f;
        float a3 = 0.0f;
        float a4 = 0.0f;
        float a5 = 0.0f;
        float a6 = 0.0f;
        float[] values = new float[vertexCount * componentCount];
        positions.get(0, vertexCount, ref values);
        float num1 = scaleBias[0];
        float num2 = scaleBias[1];
        float num3 = scaleBias[2];
        float num4 = scaleBias[3];
        for (int index = 0; index < vertexCount; ++index)
        {
            float b1 = num1 * values[index * componentCount] + num2;
            float b2 = num1 * values[index * componentCount + 1] + num3;
            float b3 = num1 * values[index * componentCount + 2] + num4;
            if (index == 0)
            {
                a1 = a2 = b1;
                a3 = a4 = b2;
                a5 = a6 = b3;
            }
            else
            {
                a1 = midp.JMath.min(a1, b1);
                a3 = midp.JMath.min(a3, b2);
                a5 = midp.JMath.min(a5, b3);
                a2 = midp.JMath.max(a2, b1);
                a4 = midp.JMath.max(a4, b2);
                a6 = midp.JMath.max(a6, b3);
            }
        }
        result[0] = (int)((double)a1 * 65536.0);
        result[1] = (int)((double)a3 * 65536.0);
        result[2] = (int)((double)a5 * 65536.0);
        result[3] = (int)((double)a2 * 65536.0);
        result[4] = (int)((double)a4 * 65536.0);
        result[5] = (int)((double)a6 * 65536.0);
    }

    public static void coordWorldToScreen(
      float[] result,
      Camera camera,
      Transform cameraTransform,
      int viewportWidth,
      int viewportHeight,
      float worldX,
      float worldY,
      float worldZ)
    {
        Transform transform = new Transform();
        Transform trans = new Transform(cameraTransform);
        trans.invert();
        camera.getProjection(transform);
        transform.postMultiply(ref trans);
        float[] vector = new float[4]
        {
      worldX,
      worldY,
      worldZ,
      1f
        };
        transform.transform(ref vector);
        float num1 = 1f / vector[3];
        float num2 = vector[0] * num1;
        float num3 = vector[1] * num1;
        float num4 = vector[2] * num1;
        float num5 = -num3;
        float num6 = -num2;
        float num7 = (float)(0.0 + (double)(viewportWidth >> 1) + (double)num5 * (double)viewportWidth * 0.5);
        float num8 = (float)(0.0 + (double)(viewportHeight >> 1) + (double)num6 * (double)viewportHeight * 0.5);
        result[0] = num7;
        result[1] = num8;
        result[2] = num4;
    }

    public static void createReflectionTransform(
      Transform transform,
      float normalX,
      float normalY,
      float normalZ,
      float pointInPlaneX,
      float pointInPlaneY,
      float pointInPlaneZ)
    {
        float num1 = 1E-07f;
        float num2 = (float)((double)normalX * (double)normalX + (double)normalY * (double)normalY + (double)normalZ * (double)normalZ);
        if ((double)midp.JMath.abs(num2 - 1f) > (double)num1)
        {
            float num3 = 1f / (float)System.Math.Sqrt((double)num2);
            normalX *= num3;
            normalY *= num3;
            normalZ *= num3;
        }
        float num4 = (float)((double)normalX * (double)pointInPlaneX + (double)normalY * (double)pointInPlaneY + (double)normalZ * (double)pointInPlaneZ);
        float[] matrix = new float[16]
        {
      (float) (1.0 - 2.0 * (double) normalX * (double) normalX),
      -2f * normalX * normalY,
      -2f * normalX * normalZ,
      2f * num4 * normalX,
      -2f * normalY * normalX,
      (float) (1.0 - 2.0 * (double) normalY * (double) normalY),
      -2f * normalY * normalZ,
      2f * num4 * normalY,
      -2f * normalZ * normalX,
      -2f * normalZ * normalY,
      (float) (1.0 - 2.0 * (double) normalZ * (double) normalZ),
      2f * num4 * normalZ,
      0.0f,
      0.0f,
      0.0f,
      1f
        };
        transform.set(matrix);
    }

    public static void createLookAtTransform(
      Transform cameraTransform,
      float fromX,
      float fromY,
      float fromZ,
      float atX,
      float atY,
      float atZ,
      float upX,
      float upY,
      float upZ)
    {
        float num1 = 1E-07f;
        float num2 = fromX;
        float num3 = fromY;
        float num4 = fromZ;
        float num5 = num2 - atX;
        float num6 = num3 - atY;
        float num7 = num4 - atZ;
        float num8 = 1f / midp.JMath.sqrt((float)((double)num5 * (double)num5 + (double)num6 * (double)num6 + (double)num7 * (double)num7));
        float num9 = num5 * num8;
        float num10 = num6 * num8;
        float num11 = num7 * num8;
        bool flag = (double)midp.JMath.abs((float)((double)upX * (double)upX + (double)upY * (double)upY + (double)upZ * (double)upZ) - 1f) < (double)num1;
        float num12 = (float)((double)upY * (double)num11 - (double)upZ * (double)num10);
        float num13 = (float)((double)upZ * (double)num9 - (double)upX * (double)num11);
        float num14 = (float)((double)upX * (double)num10 - (double)upY * (double)num9);
        if (!flag)
        {
            int num15 = (int)(1.0 / (double)midp.JMath.sqrt((float)((double)num12 * (double)num12 + (double)num13 * (double)num13 + (double)num14 * (double)num14)));
            num12 *= (float)num15;
            num13 *= (float)num15;
            num14 *= (float)num15;
        }
        float num16 = (float)((double)num10 * (double)num14 - (double)num11 * (double)num13);
        float num17 = (float)((double)num11 * (double)num12 - (double)num9 * (double)num14);
        float num18 = (float)((double)num9 * (double)num13 - (double)num10 * (double)num12);
        float[] matrix = new float[16]
        {
      num12,
      num13,
      num14,
      0.0f,
      num16,
      num17,
      num18,
      0.0f,
      num9,
      num10,
      num11,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      1f
        };
        cameraTransform.set(matrix);
        cameraTransform.postTranslate(-num2, -num3, -num4);
        cameraTransform.invert();
    }

    public static void createLookAtTransformx(
      Transform cameraTransform,
      int fromXF,
      int fromYF,
      int fromZF,
      int atXF,
      int atYF,
      int atZF)
    {
        float num1 = (float)fromXF * 1.525879E-05f;
        float num2 = (float)fromYF * 1.525879E-05f;
        float num3 = (float)fromZF * 1.525879E-05f;
        float num4 = (float)(atXF - fromXF) * 1.525879E-05f;
        float num5 = (float)(atYF - fromYF) * 1.525879E-05f;
        float num6 = (float)(atZF - fromZF) * 1.525879E-05f;
        float num7 = 1f / midp.JMath.sqrt((float)((double)num4 * (double)num4 + (double)num5 * (double)num5 + (double)num6 * (double)num6));
        float num8 = num4 * num7;
        float num9 = num5 * num7;
        float num10 = num6 * num7;
        float num11 = -num10;
        float num12 = num8;
        float num13 = 1f / midp.JMath.sqrt((float)((double)num11 * (double)num11 + (double)num12 * (double)num12));
        float num14 = num11 * num13;
        float num15 = num12 * num13;
        float num16 = (float)-((double)num15 * (double)num9);
        float num17 = (float)((double)num15 * (double)num8 - (double)num14 * (double)num10);
        float num18 = num14 * num9;
        float[] matrix = new float[16]
        {
      num14,
      0.0f,
      num15,
      0.0f,
      num16,
      num17,
      num18,
      0.0f,
      -num8,
      -num9,
      -num10,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      1f
        };
        cameraTransform.set(matrix);
        cameraTransform.postTranslate(-num1, -num2, -num3);
        cameraTransform.invert();
    }

    public static void createLookAtTransformPYD(
      Transform cameraTransform,
      float x,
      float y,
      float z,
      float pitch,
      float yaw,
      float dolly)
    {
        cameraTransform.setIdentity();
        cameraTransform.postTranslate(x, y, z);
        cameraTransform.postRotate(yaw, 0.0f, 1f, 0.0f);
        cameraTransform.postRotate(-pitch, 1f, 0.0f, 0.0f);
        cameraTransform.postTranslate(0.0f, 0.0f, dolly);
    }

    public void preloadAppearances()
    {
        if (this.m_appearances != null && this.m_appearances.Length != 0)
            return;
        ResourceManager resourceManager = AppEngine.getResourceManager();
        this.m_appearances = new Appearance[57];
        int simCount = AppEngine.getCanvas().getSimData().getSimCount();
        this.m_simAppearances = new Appearance[simCount][];
        this.m_simTextureFilenames = new string[simCount][];
        for (int index1 = 0; index1 < simCount; ++index1)
        {
            this.m_simTextureFilenames[index1] = new string[11];
            for (int index2 = 0; index2 < 11; ++index2)
                this.m_simTextureFilenames[index1][index2] = (string)null;
        }
        CompositingMode compositingMode1 = new CompositingMode();
        compositingMode1.setDepthTestEnable(true);
        compositingMode1.setDepthWriteEnable(true);
        compositingMode1.setAlphaWriteEnable(true);
        compositingMode1.setColorWriteEnable(true);
        compositingMode1.setAlphaThreshold(0.0f);
        compositingMode1.setBlending(68);
        CompositingMode compositingMode2 = new CompositingMode();
        compositingMode2.setDepthTestEnable(true);
        compositingMode2.setDepthWriteEnable(true);
        compositingMode2.setAlphaWriteEnable(true);
        compositingMode2.setColorWriteEnable(true);
        compositingMode2.setAlphaThreshold(0.0f);
        compositingMode2.setBlending(64);
        CompositingMode compositingMode3 = new CompositingMode();
        compositingMode3.setDepthTestEnable(true);
        compositingMode3.setDepthWriteEnable(false);
        compositingMode3.setAlphaWriteEnable(true);
        compositingMode3.setColorWriteEnable(true);
        compositingMode3.setAlphaThreshold(0.0f);
        compositingMode3.setBlending(64);
        CompositingMode compositingMode4 = new CompositingMode();
        compositingMode4.setDepthTestEnable(true);
        compositingMode4.setDepthWriteEnable(true);
        compositingMode4.setAlphaWriteEnable(true);
        compositingMode4.setColorWriteEnable(true);
        compositingMode4.setAlphaThreshold(0.75f);
        compositingMode4.setBlending(64);
        CompositingMode compositingMode5 = new CompositingMode();
        compositingMode5.setDepthTestEnable(true);
        compositingMode5.setDepthWriteEnable(false);
        compositingMode5.setAlphaWriteEnable(true);
        compositingMode5.setColorWriteEnable(true);
        compositingMode5.setAlphaThreshold(0.0f);
        compositingMode5.setBlending(65);
        CompositingMode compositingMode6 = new CompositingMode();
        compositingMode6.setDepthTestEnable(true);
        compositingMode6.setDepthWriteEnable(false);
        compositingMode6.setAlphaWriteEnable(false);
        compositingMode6.setColorWriteEnable(true);
        compositingMode6.setAlphaThreshold(0.0f);
        compositingMode6.setBlending(66);
        CompositingMode compositingMode7 = new CompositingMode();
        compositingMode7.setDepthTestEnable(true);
        compositingMode7.setDepthWriteEnable(true);
        compositingMode7.setAlphaWriteEnable(false);
        compositingMode7.setColorWriteEnable(false);
        compositingMode7.setAlphaThreshold(0.0f);
        compositingMode7.setBlending(68);
        CompositingMode compositingMode8 = new CompositingMode();
        compositingMode8.setDepthTestEnable(false);
        compositingMode8.setDepthWriteEnable(false);
        compositingMode8.setAlphaWriteEnable(true);
        compositingMode8.setColorWriteEnable(true);
        compositingMode8.setAlphaThreshold(0.0f);
        compositingMode8.setBlending(68);
        CompositingMode compositingMode9 = new CompositingMode();
        compositingMode9.setDepthTestEnable(false);
        compositingMode9.setDepthWriteEnable(false);
        compositingMode9.setAlphaWriteEnable(false);
        compositingMode9.setColorWriteEnable(true);
        compositingMode9.setAlphaThreshold(0.0f);
        compositingMode9.setBlending(64);
        PolygonMode polygonMode1 = new PolygonMode();
        polygonMode1.setCulling(161);
        PolygonMode polygonMode2 = new PolygonMode();
        polygonMode2.setCulling(162);
        Appearance appearance1 = new Appearance();
        appearance1.setCompositingMode(compositingMode1);
        appearance1.setLayer(0);
        this.m_appearances[3] = appearance1;
        this.m_appearances[4] = (Appearance)appearance1.duplicate();
        Appearance appearance2 = new Appearance();
        appearance2.setCompositingMode(compositingMode2);
        appearance2.setPolygonMode(polygonMode2);
        appearance2.setLayer(7);
        this.m_appearances[5] = appearance2;
        Appearance appearance3 = new Appearance();
        appearance3.setCompositingMode(compositingMode4);
        appearance3.setPolygonMode(polygonMode2);
        appearance3.setLayer(7);
        this.m_appearances[6] = appearance3;
        Appearance appearance4 = new Appearance();
        appearance4.setCompositingMode(compositingMode5);
        appearance4.setPolygonMode(polygonMode2);
        appearance4.setLayer(9);
        this.m_appearances[7] = appearance4;
        Appearance appearance5 = new Appearance();
        appearance5.setCompositingMode(compositingMode6);
        appearance5.setPolygonMode(polygonMode2);
        appearance5.setLayer(2);
        this.m_appearances[8] = appearance5;
        m3g.Texture2D texture1 = resourceManager.loadM3GTexture2D(282);
        texture1.setFiltering(210, 209);
        Appearance appearance6 = new Appearance();
        appearance6.setTexture(0, texture1);
        appearance6.setCompositingMode(compositingMode3);
        appearance6.setLayer(2);
        this.m_appearances[25] = appearance6;
        Appearance appearance7 = (Appearance)appearance6.duplicate();
        appearance7.setPolygonMode(polygonMode2);
        appearance7.setLayer(3);
        this.m_appearances[26] = appearance7;
        Appearance appearance8 = new Appearance();
        appearance8.setCompositingMode(compositingMode1);
        appearance8.setLayer(0);
        this.m_appearances[56] = appearance8;
        this.m_appearances[55] = (Appearance)appearance8.duplicate();
        Fog fog = new Fog();
        fog.setColor(9222898);
        fog.setLinear(800f, 1500f);
        this.m_fog = fog;
        Appearance appearance9 = new Appearance();
        appearance9.setCompositingMode(compositingMode1);
        appearance9.setFog(fog);
        this.m_appearances[0] = appearance9;
        Appearance appearance10 = (Appearance)appearance9.duplicate();
        this.m_appearances[1] = appearance10;
        Appearance appearance11 = (Appearance)appearance10.duplicate();
        this.m_appearances[45] = appearance11;
        Appearance appearance12 = (Appearance)appearance11.duplicate();
        appearance12.setCompositingMode(compositingMode2);
        appearance12.setLayer(4);
        this.m_appearances[2] = appearance12;
        Appearance appearance13 = (Appearance)appearance12.duplicate();
        this.m_appearances[43] = appearance13;
        Appearance appearance14 = (Appearance)appearance13.duplicate();
        appearance14.setLayer(1);
        this.m_appearances[44] = appearance14;
        Appearance appearance15 = new Appearance();
        appearance15.setCompositingMode(compositingMode5);
        appearance15.setPolygonMode(polygonMode2);
        appearance15.setLayer(9);
        this.m_appearances[46] = appearance15;
        Appearance appearance16 = new Appearance();
        appearance16.setCompositingMode(compositingMode4);
        appearance16.setPolygonMode(polygonMode2);
        appearance16.setLayer(9);
        this.m_appearances[47] = appearance16;
        Appearance appearance17 = new Appearance();
        appearance17.setFog(fog);
        appearance17.setCompositingMode(compositingMode1);
        appearance17.setLayer(0);
        this.m_appearances[11] = appearance17;
        Appearance appearance18 = new Appearance();
        appearance18.setFog(fog);
        appearance18.setCompositingMode(compositingMode2);
        appearance18.setPolygonMode(polygonMode2);
        appearance18.setLayer(7);
        this.m_appearances[12] = appearance18;
        Appearance appearance19 = new Appearance();
        appearance19.setCompositingMode(compositingMode5);
        appearance19.setPolygonMode(polygonMode2);
        appearance19.setLayer(9);
        this.m_appearances[13] = appearance19;
        Appearance appearance20 = new Appearance();
        appearance20.setFog(fog);
        appearance20.setCompositingMode(compositingMode4);
        appearance20.setPolygonMode(polygonMode2);
        appearance20.setLayer(7);
        this.m_appearances[14] = appearance20;
        Appearance appearance21 = new Appearance();
        appearance21.setFog(fog);
        appearance21.setCompositingMode(compositingMode2);
        appearance21.setPolygonMode(polygonMode2);
        appearance21.setLayer(7);
        this.m_appearances[15] = appearance21;
        Appearance appearance22 = new Appearance();
        appearance22.setCompositingMode(compositingMode5);
        appearance22.setPolygonMode(polygonMode2);
        appearance22.setLayer(9);
        this.m_appearances[42] = appearance22;
        Appearance appearance23 = new Appearance();
        appearance23.setCompositingMode(compositingMode5);
        appearance23.setPolygonMode(polygonMode2);
        appearance23.setLayer(9);
        this.m_appearances[52] = appearance23;
        Appearance appearance24 = new Appearance();
        appearance24.setFog(fog);
        appearance24.setCompositingMode(compositingMode1);
        appearance24.setLayer(0);
        this.m_appearances[53] = appearance24;
        Appearance appearance25 = new Appearance();
        appearance25.setFog(fog);
        appearance25.setCompositingMode(compositingMode2);
        appearance25.setPolygonMode(polygonMode2);
        appearance25.setLayer(8);
        this.m_appearances[54] = appearance25;
        Appearance appearance26 = new Appearance();
        appearance26.setFog(fog);
        appearance26.setCompositingMode(compositingMode1);
        appearance26.setLayer(0);
        this.m_appearances[16] = appearance26;
        Appearance appearance27 = new Appearance();
        appearance27.setFog(fog);
        appearance27.setCompositingMode(compositingMode2);
        appearance27.setPolygonMode(polygonMode2);
        appearance27.setLayer(7);
        this.m_appearances[17] = appearance27;
        Appearance appearance28 = new Appearance();
        appearance28.setFog(fog);
        appearance28.setCompositingMode(compositingMode4);
        appearance28.setPolygonMode(polygonMode2);
        appearance28.setLayer(7);
        this.m_appearances[18] = appearance28;
        Appearance appearance29 = new Appearance();
        appearance29.setFog(fog);
        appearance29.setCompositingMode(compositingMode5);
        appearance29.setPolygonMode(polygonMode2);
        appearance29.setLayer(9);
        this.m_appearances[19] = appearance29;
        Appearance appearance30 = new Appearance();
        appearance30.setFog(fog);
        appearance30.setCompositingMode(compositingMode1);
        appearance30.setLayer(-4);
        this.m_appearances[20] = appearance30;
        Appearance appearance31 = new Appearance();
        appearance31.setFog(fog);
        appearance31.setCompositingMode(compositingMode9);
        appearance31.setPolygonMode(polygonMode2);
        appearance31.setLayer(-3);
        this.m_appearances[21] = appearance31;
        Appearance appearance32 = new Appearance();
        appearance32.setFog(fog);
        appearance32.setCompositingMode(compositingMode9);
        appearance32.setPolygonMode(polygonMode2);
        appearance32.setLayer(-2);
        this.m_appearances[22] = appearance32;
        Appearance appearance33 = new Appearance();
        appearance33.setFog(fog);
        appearance33.setCompositingMode(compositingMode9);
        appearance33.setPolygonMode(polygonMode2);
        appearance33.setLayer(-1);
        this.m_appearances[23] = appearance33;
        for (int index = 0; index < simCount; ++index)
        {
            Appearance[] appearanceArray = new Appearance[20];
            this.m_simAppearances[index] = appearanceArray;
            Appearance appearance34 = new Appearance();
            appearance34.setCompositingMode(compositingMode1);
            appearance34.setLayer(0);
            appearanceArray[0] = appearance34;
            Appearance appearance35 = (Appearance)appearance34.duplicate();
            appearance35.setPolygonMode(polygonMode1);
            appearanceArray[10] = appearance35;
            Appearance appearance36 = new Appearance();
            appearance36.setCompositingMode(compositingMode4);
            appearance36.setLayer(7);
            appearanceArray[1] = appearance36;
            Appearance appearance37 = (Appearance)appearance36.duplicate();
            appearance37.setPolygonMode(polygonMode1);
            appearanceArray[11] = appearance37;
            Appearance appearance38 = new Appearance();
            appearance38.setCompositingMode(compositingMode1);
            appearance38.setLayer(0);
            appearanceArray[2] = appearance38;
            Appearance appearance39 = (Appearance)appearance38.duplicate();
            appearance39.setPolygonMode(polygonMode1);
            appearanceArray[12] = appearance39;
            appearanceArray[3] = (Appearance)appearanceArray[2].duplicate();
            appearanceArray[3].setUserID(49);
            appearanceArray[13] = (Appearance)appearanceArray[12].duplicate();
            Appearance appearance40 = new Appearance();
            appearance40.setCompositingMode(compositingMode2);
            appearance40.setPolygonMode(polygonMode2);
            appearance40.setLayer(5);
            appearanceArray[4] = appearance40;
            Appearance appearance41 = (Appearance)appearance40.duplicate();
            appearance41.setLayer(3);
            appearanceArray[14] = appearance41;
            Appearance appearance42 = new Appearance();
            appearance42.setCompositingMode(compositingMode4);
            appearance42.setLayer(5);
            appearance42.setPolygonMode(polygonMode2);
            appearanceArray[5] = appearance42;
            Appearance appearance43 = (Appearance)appearance42.duplicate();
            appearance43.setPolygonMode(polygonMode2);
            appearance43.setLayer(3);
            appearanceArray[15] = appearance43;
            Appearance appearance44 = new Appearance();
            appearance44.setCompositingMode(compositingMode1);
            appearance44.setLayer(0);
            appearanceArray[6] = appearance44;
            Appearance appearance45 = (Appearance)appearance44.duplicate();
            appearance45.setPolygonMode(polygonMode1);
            appearanceArray[16] = appearance45;
            Appearance appearance46 = new Appearance();
            appearance46.setCompositingMode(compositingMode1);
            appearance46.setLayer(0);
            appearanceArray[7] = appearance46;
            Appearance appearance47 = Appearance.m3g_cast(appearance46.duplicate());
            appearance47.setPolygonMode(polygonMode1);
            appearanceArray[17] = appearance47;
            Appearance appearance48 = new Appearance();
            appearance48.setCompositingMode(compositingMode1);
            appearance48.setLayer(0);
            appearanceArray[8] = appearance48;
            Appearance appearance49 = Appearance.m3g_cast(appearance48.duplicate());
            appearance49.setPolygonMode(polygonMode1);
            appearanceArray[18] = appearance49;
            Appearance appearance50 = new Appearance();
            appearance50.setCompositingMode(compositingMode4);
            appearance50.setLayer(5);
            appearance50.setPolygonMode(polygonMode2);
            appearanceArray[9] = appearance50;
            Appearance appearance51 = (Appearance)appearance50.duplicate();
            appearance51.setPolygonMode(polygonMode2);
            appearance51.setLayer(3);
            appearanceArray[19] = appearance51;
        }
        m3g.Texture2D texture2 = resourceManager.loadM3GTexture2D((int)byte.MaxValue);
        texture2.setFiltering(210, 209);
        Appearance appearance52 = new Appearance();
        appearance52.setTexture(0, texture2);
        appearance52.setCompositingMode(compositingMode1);
        appearance52.setLayer(0);
        this.m_appearances[40] = appearance52;
        m3g.Texture2D texture3 = (m3g.Texture2D)texture2.duplicate();
        texture3.setFiltering(210, 209);
        Appearance appearance53 = new Appearance();
        appearance53.setTexture(0, texture3);
        appearance53.setCompositingMode(compositingMode5);
        appearance53.setLayer(9);
        this.m_appearances[41] = appearance53;
        Appearance appearance54 = new Appearance();
        appearance54.setCompositingMode(compositingMode5);
        appearance54.setLayer(9);
        this.m_appearances[48] = appearance54;
        m3g.Texture2D texture4 = resourceManager.loadTexture2D(248);
        texture4.setFiltering(210, 209);
        this.m_appearances[48].setTexture(0, texture4);
        Appearance appearance55 = new Appearance();
        appearance55.setCompositingMode(compositingMode1);
        appearance55.setLayer(0);
        this.m_appearances[49] = appearance55;
        Appearance appearance56 = new Appearance();
        appearance56.setCompositingMode(compositingMode1);
        appearance56.setLayer(0);
        this.m_appearances[50] = appearance56;
        Appearance appearance57 = new Appearance();
        appearance57.setCompositingMode(compositingMode1);
        appearance57.setLayer(0);
        this.m_appearances[27] = appearance57;
        Appearance appearance58 = new Appearance();
        appearance58.setCompositingMode(compositingMode5);
        appearance58.setPolygonMode(polygonMode2);
        appearance58.setLayer(9);
        this.m_appearances[28] = appearance58;
        Appearance appearance59 = new Appearance();
        appearance59.setCompositingMode(compositingMode4);
        appearance59.setLayer(7);
        this.m_appearances[29] = appearance59;
        Appearance appearance60 = new Appearance();
        appearance60.setCompositingMode(compositingMode2);
        appearance60.setLayer(7);
        this.m_appearances[30] = appearance60;
        Appearance appearance61 = new Appearance();
        appearance61.setCompositingMode(compositingMode2);
        appearance61.setLayer(7);
        this.m_appearances[31] = appearance61;
        Appearance appearance62 = new Appearance();
        appearance62.setCompositingMode(compositingMode2);
        appearance62.setPolygonMode(polygonMode1);
        appearance62.setLayer(3);
        this.m_appearances[32] = appearance62;
        Appearance appearance63 = new Appearance();
        appearance63.setCompositingMode(compositingMode2);
        appearance63.setLayer(7);
        this.m_appearances[33] = appearance63;
        Appearance appearance64 = new Appearance();
        appearance64.setCompositingMode(compositingMode2);
        appearance64.setPolygonMode(polygonMode1);
        appearance64.setLayer(3);
        this.m_appearances[34] = appearance64;
        Appearance appearance65 = new Appearance();
        appearance65.setCompositingMode(compositingMode1);
        appearance65.setLayer(0);
        this.m_appearances[35] = appearance65;
        Appearance appearance66 = new Appearance();
        appearance66.setCompositingMode(compositingMode1);
        appearance66.setPolygonMode(polygonMode1);
        appearance66.setLayer(0);
        this.m_appearances[36] = appearance66;
        Appearance appearance67 = new Appearance();
        appearance67.setCompositingMode(compositingMode8);
        appearance67.setLayer(-1);
        this.m_appearances[37] = appearance67;
        Appearance appearance68 = new Appearance();
        appearance68.setCompositingMode(compositingMode2);
        appearance68.setLayer(10);
        this.m_appearances[38] = appearance68;
        Appearance appearance69 = new Appearance();
        appearance69.setCompositingMode(compositingMode7);
        appearance69.setLayer(-2);
        this.m_appearances[39] = appearance69;
        Appearance appearance70 = new Appearance();
        appearance70.setCompositingMode(compositingMode1);
        appearance70.setLayer(0);
        this.m_appearances[51] = appearance70;
    }

    public void initExtAppearances()
    {
        if (this.m_appearances == null || this.m_appearances.Length <= 0)
            return;
        int packCount = DLCManager.getInstance().getPackCount();
        if (this.m_extAppearances.Length == packCount)
            return;
        this.m_extAppearances = new Appearance[packCount][];
        this.m_extAppearanceTimers = new int[packCount];
        for (int index = 0; index < packCount; ++index)
        {
            this.m_extAppearanceTimers[index] = 0;
            this.m_extAppearances[index] = new Appearance[11];
            this.m_extAppearances[index][0] = (Appearance)this.m_appearances[3].duplicate();
            this.m_extAppearances[index][2] = (Appearance)this.m_appearances[5].duplicate();
            this.m_extAppearances[index][4] = (Appearance)this.m_appearances[7].duplicate();
            this.m_extAppearances[index][5] = (Appearance)this.m_appearances[8].duplicate();
            this.m_extAppearances[index][3] = (Appearance)this.m_appearances[6].duplicate();
            this.m_extAppearances[index][1] = (Appearance)this.m_appearances[4].duplicate();
            this.m_extAppearances[index][6] = (Appearance)this.m_appearances[3].duplicate();
            this.m_extAppearances[index][7] = (Appearance)this.m_appearances[6].duplicate();
            this.m_extAppearances[index][7].setLayer(6);
            this.m_extAppearances[index][8] = (Appearance)this.m_appearances[7].duplicate();
            this.m_extAppearances[index][9] = (Appearance)this.m_appearances[3].duplicate();
            this.m_extAppearances[index][10] = (Appearance)this.m_appearances[5].duplicate();
        }
    }

    public void setFogColor(int color)
    {
        this.m_fog.setColor(color);
    }

    public void setFogRange(float start, float end)
    {
        this.m_fog.setLinear(start, end);
    }

    private Image2D getHemisphereMapImage()
    {
        if (this.m_hemisphereMapImage == null)
        {
            ResourceManager resourceManager = AppEngine.getResourceManager();
            this.m_hemisphereMapImageDay = resourceManager.loadM3GImage2D(245);
            this.m_hemisphereMapImageNight = resourceManager.loadM3GImage2D(246);
            this.m_hemisphereMapImage = this.m_nightTextures ? this.m_hemisphereMapImageNight : this.m_hemisphereMapImageDay;
        }
        return this.m_hemisphereMapImage;
    }

    public void setNightTextures(bool nightTextures)
    {
        if (this.m_nightTextures == nightTextures)
            return;
        this.m_nightTextures = nightTextures;
        Image2D hemisphereMapImage = this.getHemisphereMapImage();
        int packCount = DLCManager.getInstance().getPackCount();
        for (int index = 0; index < packCount; ++index)
            this.m_extAppearances[index][9].getTexture(1)?.setImage(hemisphereMapImage);
        this.m_appearances[55].getTexture(1)?.setImage(hemisphereMapImage);
    }

    public Appearance getAppearance(int appId)
    {
        if (this.m_appearances == null)
            this.preloadAppearances();
        return this.m_appearances[appId];
    }

    public Appearance getSimAppearance(int appId, int simId)
    {
        if (this.m_appearances == null)
            this.preloadAppearances();
        return this.m_simAppearances[simId][appId];
    }

    public Appearance getExtAppearance(int appId, int packId)
    {
        if (this.m_appearances == null)
            this.preloadAppearances();
        return this.m_extAppearances[packId][appId];
    }

    private static void applyAppearance(Node node, Appearance app)
    {
        if (node == null)
            return;
        Group group = Group.m3g_cast((Object3D)node);
        if (group != null)
        {
            int childCount = group.getChildCount();
            for (int index = 0; index < childCount; ++index)
                ModelManager.applyAppearance(group.getChild(index), app);
        }
        Mesh mesh = Mesh.m3g_cast((Object3D)node);
        if (mesh == null)
            return;
        for (int index = 0; index < mesh.getSubmeshCount(); ++index)
            mesh.setAppearance(index, app);
        SkinnedMesh skinnedMesh = SkinnedMesh.m3g_cast((Object3D)node);
        if (skinnedMesh == null)
            return;
        ModelManager.applyAppearance((Node)skinnedMesh.getSkeleton(), app);
    }

    public void overrideAppearance(Node node, int appFrom, int appTo)
    {
        Appearance appearance = this.getAppearance(appTo);
        int userId = this.getAppearance(appFrom).getUserID();
        this.overrideAppearance(node, userId, appearance);
    }

    public void overrideSimAppearance(Node node, int appFrom, int appTo, int simId)
    {
        Appearance simAppearance = this.getSimAppearance(appTo, simId);
        int userId = this.getSimAppearance(appFrom, simId).getUserID();
        if (userId == 0)
            return;
        this.overrideAppearance(node, userId, simAppearance);
    }

    public void applyAppearances(Node node)
    {
        this.applyAppearances(node, -1);
    }

    public void applyAppearances(Node node, int extraId)
    {
        if (node == null)
            return;
        Group group = Group.m3g_cast((Object3D)node);
        if (group != null)
        {
            int childCount = group.getChildCount();
            for (int index = 0; index < childCount; ++index)
                this.applyAppearances(group.getChild(index), extraId);
        }
        Mesh mesh = Mesh.m3g_cast((Object3D)node);
        if (mesh == null)
            return;
        for (int index = 0; index < mesh.getSubmeshCount(); ++index)
        {
            Appearance appearance1 = mesh.getAppearance(index);
            bool flag1 = false;
            bool flag2 = false;
            int appId;
            if (appearance1 == null)
            {
                appId = 3;
            }
            else
            {
                switch (appearance1.getUserID())
                {
                    case 29:
                        appId = 4;
                        break;
                    case 30:
                        appId = 3;
                        break;
                    case 31:
                        appId = 5;
                        break;
                    case 32:
                        appId = 7;
                        break;
                    case 33:
                        appId = 6;
                        break;
                    case 34:
                        appId = 8;
                        break;
                    case 35:
                        appId = 25;
                        break;
                    case 36:
                        appId = 27;
                        break;
                    case 37:
                        appId = 28;
                        break;
                    case 38:
                        appId = 29;
                        break;
                    case 39:
                        appId = 30;
                        break;
                    case 40:
                        appId = 0;
                        flag1 = true;
                        break;
                    case 41:
                        appId = 2;
                        flag1 = true;
                        break;
                    case 42:
                        appId = 4;
                        flag1 = true;
                        break;
                    case 43:
                        appId = 5;
                        flag1 = true;
                        break;
                    case 44:
                        appId = 6;
                        flag1 = true;
                        break;
                    case 45:
                        appId = 7;
                        flag1 = true;
                        break;
                    case 46:
                        appId = 8;
                        flag1 = true;
                        break;
                    case 47:
                        appId = 1;
                        flag1 = true;
                        break;
                    case 48:
                        appId = 9;
                        flag1 = true;
                        break;
                    case 49:
                        appId = 3;
                        flag1 = true;
                        break;
                    case 51:
                        appId = 43;
                        break;
                    case 52:
                        appId = 45;
                        break;
                    case 53:
                        appId = 48;
                        break;
                    case 54:
                        appId = 49;
                        break;
                    case 55:
                        appId = 46;
                        break;
                    case 56:
                        appId = 47;
                        break;
                    case 57:
                        appId = 44;
                        break;
                    case 58:
                        appId = 50;
                        break;
                    case 60:
                        appId = 11;
                        break;
                    case 61:
                        appId = 12;
                        break;
                    case 62:
                        appId = 13;
                        break;
                    case 63:
                        appId = 14;
                        break;
                    case 64:
                        appId = 15;
                        break;
                    case 65:
                        appId = 42;
                        break;
                    case 66:
                        appId = 52;
                        break;
                    case 67:
                        appId = 53;
                        break;
                    case 68:
                        appId = 54;
                        break;
                    case 71:
                        appId = 16;
                        break;
                    case 72:
                        appId = 18;
                        break;
                    case 73:
                        appId = 19;
                        break;
                    case 74:
                        appId = 17;
                        break;
                    case 75:
                        appId = 20;
                        break;
                    case 76:
                        appId = 21;
                        break;
                    case 77:
                        appId = 22;
                        break;
                    case 78:
                        appId = 23;
                        break;
                    case 80:
                        appId = 35;
                        break;
                    case 81:
                        appId = 31;
                        break;
                    case 82:
                        appId = 33;
                        break;
                    case 83:
                        appId = 39;
                        break;
                    case 84:
                        appId = 37;
                        break;
                    case 85:
                        appId = 38;
                        break;
                    case 86:
                        appId = 51;
                        break;
                    case 90:
                        appId = 40;
                        break;
                    case 91:
                        appId = 41;
                        break;
                    case 92:
                        appId = 55;
                        break;
                    case 93:
                        appId = 56;
                        break;
                    case 100:
                        appId = 0;
                        flag2 = true;
                        break;
                    case 101:
                        appId = 1;
                        flag2 = true;
                        break;
                    case 102:
                        appId = 2;
                        flag2 = true;
                        break;
                    case 103:
                        appId = 4;
                        flag2 = true;
                        break;
                    case 104:
                        appId = 3;
                        flag2 = true;
                        break;
                    case 105:
                        appId = 5;
                        flag2 = true;
                        break;
                    case 106:
                        appId = 6;
                        flag2 = true;
                        break;
                    case 107:
                        appId = 7;
                        flag2 = true;
                        break;
                    case 108:
                        appId = 8;
                        flag2 = true;
                        break;
                    case 109:
                        appId = 9;
                        flag2 = true;
                        break;
                    case 110:
                        appId = 10;
                        flag2 = true;
                        break;
                    default:
                        appId = 3;
                        break;
                }
            }
            Appearance appearance2 = !flag1 ? (!flag2 ? this.getAppearance(appId) : this.getExtAppearance(appId, extraId)) : this.getSimAppearance(appId, extraId);
            if (appearance1 != null && appearance2 != null)
                appearance2.setUserID(appearance1.getUserID());
            mesh.setAppearance(index, appearance2);
        }
        SkinnedMesh skinnedMesh = SkinnedMesh.m3g_cast((Object3D)mesh);
        if (skinnedMesh == null)
            return;
        this.applyAppearances((Node)skinnedMesh.getSkeleton(), extraId);
    }

    public static void applyCommit(Node node)
    {
        if (node == null)
            return;
        Group group = Group.m3g_cast((Object3D)node);
        if (group != null)
        {
            int childCount = group.getChildCount();
            for (int index = 0; index < childCount; ++index)
                ModelManager.applyCommit(group.getChild(index));
        }
        Mesh mesh = Mesh.m3g_cast((Object3D)node);
        if (mesh == null)
            return;
        mesh.commit();
        SkinnedMesh skinnedMesh = SkinnedMesh.m3g_cast((Object3D)node);
        if (skinnedMesh == null)
            return;
        ModelManager.applyCommit((Node)skinnedMesh.getSkeleton());
    }

    public static void applyAlphaFactor(Node node, int alphaFactorF)
    {
        if (node == null)
            return;
        Group group = Group.m3g_cast((Object3D)node);
        if (group != null)
        {
            int childCount = group.getChildCount();
            for (int index = 0; index < childCount; ++index)
                ModelManager.applyAlphaFactor(group.getChild(index), alphaFactorF);
        }
        Mesh mesh = Mesh.m3g_cast((Object3D)node);
        if (mesh == null)
            return;
        mesh.setAlphaFactorx(alphaFactorF);
        SkinnedMesh skinnedMesh = SkinnedMesh.m3g_cast((Object3D)node);
        if (skinnedMesh == null)
            return;
        ModelManager.applyAlphaFactor((Node)skinnedMesh.getSkeleton(), alphaFactorF);
    }

    public static void applyDefaultColor(Node node, int defaultColor)
    {
        if (node == null)
            return;
        Group group = Group.m3g_cast((Object3D)node);
        if (group != null)
        {
            int childCount = group.getChildCount();
            for (int index = 0; index < childCount; ++index)
                ModelManager.applyDefaultColor(group.getChild(index), defaultColor);
        }
        Mesh mesh = Mesh.m3g_cast((Object3D)node);
        if (mesh == null)
            return;
        mesh.getVertexBuffer().setDefaultColor(defaultColor);
        SkinnedMesh skinnedMesh = SkinnedMesh.m3g_cast((Object3D)node);
        if (skinnedMesh == null)
            return;
        ModelManager.applyDefaultColor((Node)skinnedMesh.getSkeleton(), defaultColor);
    }

    public static void applyTintColor(Node node, int tintColor)
    {
        if (node == null)
            return;
        Group group = Group.m3g_cast((Object3D)node);
        if (group != null)
        {
            int childCount = group.getChildCount();
            for (int index = 0; index < childCount; ++index)
                ModelManager.applyTintColor(group.getChild(index), tintColor);
        }
        Mesh mesh = Mesh.m3g_cast((Object3D)node);
        if (mesh == null)
            return;
        Appearance appearance = mesh.getAppearance(0);
        int num1 = AppEngine.indexOf(appearance, ModelManager.getInstance().m_appearances);
        if (appearance.getUserID() != 110 && num1 != 41 && (num1 != 48 && num1 != 49) && (num1 != 50 && num1 != 40 && (num1 != 25 && num1 != 4)) && (num1 != 8 && num1 != 7 && (num1 != 28 && num1 != 13) && (num1 != 19 && num1 != 42)))
        {
            m3g.VertexBuffer vertexBuffer = mesh.getVertexBuffer();
            int num2 = (int)((long)vertexBuffer.getDefaultColor() & 4278190080L);
            vertexBuffer.setDefaultColor(tintColor | num2);
        }
        SkinnedMesh skinnedMesh = SkinnedMesh.m3g_cast((Object3D)node);
        if (skinnedMesh == null)
            return;
        ModelManager.applyTintColor((Node)skinnedMesh.getSkeleton(), tintColor);
    }

    public static void applyHemisphereMappedTexture(Node node, m3g.Texture2D refmap)
    {
        if (node == null)
            return;
        Mesh mesh = Mesh.m3g_cast((Object3D)node);
        Group group = Group.m3g_cast((Object3D)node);
        if (mesh != null)
        {
            bool flag = false;
            int submeshCount = mesh.getSubmeshCount();
            for (int index = 0; index < submeshCount; ++index)
            {
                Appearance appearance = mesh.getAppearance(index);
                if (appearance.getUserID() == 109 || appearance.getUserID() == 92)
                {
                    appearance.setTexture(1, refmap);
                    flag = true;
                }
            }
            if (!flag)
                return;
            m3g.VertexBuffer vertexBuffer = mesh.getVertexBuffer();
            VertexArray normals = vertexBuffer.getNormals();
            if (normals.getComponentType() != 1)
                return;
            float[] bias = new float[3]
            {
        0.003921569f,
        0.003921569f,
        0.003921569f
            };
            vertexBuffer.setTexCoords(1, normals, 0.007843138f, bias);
        }
        else
        {
            if (group == null)
                return;
            int childCount = group.getChildCount();
            for (int index = 0; index < childCount; ++index)
                ModelManager.applyHemisphereMappedTexture(group.getChild(index), refmap);
        }
    }

    public static void orphanNode(Node node)
    {
        Node parent = node.getParent();
        if (parent == null)
            return;
        Group.m3g_cast((Object3D)parent).removeChild(node);
    }

    public static void removeNode(Node rootNode, int userId)
    {
        Object3D object3D = rootNode.find(userId);
        if (object3D == null)
            return;
        ModelManager.orphanNode(Node.m3g_cast(object3D));
    }

    public static Node mergeSkinnedMeshes(SkinnedMesh[] skinnedMeshes)
    {
        return ModelManager.mergeSkinnedMeshes(skinnedMeshes, (Group)null);
    }

    public static Node mergeSkinnedMeshes(SkinnedMesh[] skinnedMeshes, Group skeleton)
    {
        AppEngine.timerBegin();
        int length1 = skinnedMeshes.Length;
        m3g.IndexBuffer[] submeshes = new m3g.IndexBuffer[length1];
        Appearance[] appearances = new Appearance[length1];
        int[] numArray1 = new int[length1];
        int vertexCount1 = 0;
        int componentCount1 = 0;
        int componentCount2 = 0;
        float[] scaleBias = new float[4];
        for (int index = 0; index < length1; ++index)
        {
            numArray1[index] = vertexCount1;
            m3g.VertexBuffer vertexBuffer = skinnedMeshes[index].getVertexBuffer();
            vertexCount1 += vertexBuffer.getVertexCount();
            VertexArray positions = vertexBuffer.getPositions(ref scaleBias);
            if (positions.getComponentCount() > componentCount1)
                componentCount1 = positions.getComponentCount();
            VertexArray texCoords = vertexBuffer.getTexCoords(0, ref scaleBias);
            if (texCoords.getComponentCount() > componentCount2)
                componentCount2 = texCoords.getComponentCount();
        }
        m3g.VertexBuffer vertices = new m3g.VertexBuffer();
        VertexArray arr1 = new VertexArray(vertexCount1, componentCount1, 4);
        VertexArray arr2 = new VertexArray(vertexCount1, componentCount2, 4);
        vertices.setPositions(arr1, 1f, (float[])null);
        vertices.setTexCoords(0, arr2, 1f, (float[])null);
        float[] src1 = new float[componentCount1];
        float[] src2 = new float[componentCount2];
        for (int index1 = 0; index1 < length1; ++index1)
        {
            SkinnedMesh skinnedMesh = skinnedMeshes[index1];
            m3g.VertexBuffer vertexBuffer = skinnedMesh.getVertexBuffer();
            int vertexCount2 = vertexBuffer.getVertexCount();
            int num1 = numArray1[index1];
            VertexArray positions = vertexBuffer.getPositions(ref scaleBias);
            float num2 = scaleBias[0];
            float[] numArray2 = new float[scaleBias.Length - 1];
            midp.JSystem.arraycopy((Array)scaleBias, 1, (Array)numArray2, 0, scaleBias.Length - 1);
            int componentCount3 = positions.getComponentCount();
            if (positions.getComponentType() == 2)
            {
                float[] values = new float[componentCount3];
                for (int firstVertex = 0; firstVertex < vertexCount2; ++firstVertex)
                {
                    positions.get(firstVertex, 1, ref values);
                    for (int index2 = 0; index2 < componentCount3; ++index2)
                        src1[index2] = values[index2] * num2 + numArray2[index2];
                    arr1.set(firstVertex + num1, 1, src1);
                }
            }
            VertexArray texCoords = vertexBuffer.getTexCoords(0, ref scaleBias);
            float num3 = scaleBias[0];
            float[] numArray3 = new float[scaleBias.Length - 1];
            midp.JSystem.arraycopy((Array)scaleBias, 1, (Array)numArray3, 0, scaleBias.Length - 1);
            int componentCount4 = texCoords.getComponentCount();
            if (texCoords.getComponentType() == 2)
            {
                float[] values = new float[componentCount4];
                for (int firstVertex = 0; firstVertex < vertexCount2; ++firstVertex)
                {
                    texCoords.get(firstVertex, 1, ref values);
                    for (int index2 = 0; index2 < componentCount4; ++index2)
                        src2[index2] = values[index2] * num3 + numArray3[index2];
                    arr2.set(firstVertex + num1, 1, src2);
                }
            }
            m3g.IndexBuffer indexBuffer = skinnedMesh.getIndexBuffer(0);
            if (indexBuffer.isImplicit())
            {
                if (indexBuffer.isStripped())
                {
                    ushort[] stripLengths1 = indexBuffer.getStripLengths();
                    int length2 = stripLengths1.Length;
                    int[] stripLengths2 = new int[length2];
                    for (int index2 = 0; index2 < length2; ++index2)
                        stripLengths2[index2] = (int)stripLengths1[index2];
                    submeshes[index1] = new m3g.IndexBuffer(8, stripLengths2, indexBuffer.getFirstIndex() + num1);
                }
            }
            else
            {
                short[] explicitIndices = indexBuffer.getExplicitIndices();
                int length2 = explicitIndices.Length;
                int[] indices = new int[length2];
                for (int index2 = 0; index2 < length2; ++index2)
                    indices[index2] = (int)explicitIndices[index2] + num1;
                if (indexBuffer.isStripped())
                {
                    ushort[] stripLengths1 = indexBuffer.getStripLengths();
                    int length3 = stripLengths1.Length;
                    int[] stripLengths2 = new int[length3];
                    for (int index2 = 0; index2 < length3; ++index2)
                        stripLengths2[index2] = (int)stripLengths1[index2];
                    submeshes[index1] = new m3g.IndexBuffer(8, stripLengths2, indices);
                }
            }
            appearances[index1] = skinnedMesh.getAppearance(0);
        }
        Group skeleton1 = skeleton ?? (Group)skinnedMeshes[0].getSkeleton().duplicate();
        SkinnedMesh skinnedMesh1 = new SkinnedMesh(vertices, ref submeshes, ref appearances, skeleton1);
        Vector boneList1 = new Vector();
        ModelManager.collectBones((Node)skeleton1, ref boneList1);
        int initialCapacity = boneList1.size();
        for (int index1 = 0; index1 < length1; ++index1)
        {
            SkinnedMesh skinnedMesh2 = skinnedMeshes[index1];
            int num = numArray1[index1];
            int vertexCount2 = skinnedMesh2.getVertexBuffer().getVertexCount();
            int[] indices = new int[vertexCount2];
            float[] weights = new float[vertexCount2];
            Vector boneList2 = new Vector(initialCapacity);
            ModelManager.collectBones((Node)skinnedMesh2.getSkeleton(), ref boneList2);
            for (int index2 = 0; index2 < initialCapacity; ++index2)
            {
                Node bone1 = (Node)boneList2.elementAt(index2);
                Node bone2 = (Node)boneList1.elementAt(index2);
                int boneVertices = skinnedMesh2.getBoneVertices(bone1, ref indices, ref weights);
                if (boneVertices > 0)
                {
                    for (int index3 = 0; index3 < boneVertices; ++index3)
                    {
                        int weight = (int)((double)weights[index3] * 512.0);
                        if (weight != 0)
                        {
                            int firstVertex = indices[index3] + num;
                            skinnedMesh1.addTransform(bone2, weight, firstVertex, 1);
                        }
                    }
                }
            }
        }
        AppEngine.timerEnd(nameof(mergeSkinnedMeshes));
        return (Node)skinnedMesh1;
    }

    public static m3g.Texture2D mergeTextures(
      Image imageUnder,
      Image imageOver,
      bool compress)
    {
        AppEngine.timerBegin();
        int width = imageUnder.getWidth();
        int height = imageUnder.getHeight();
        Image image = Image.createImage(width, height);
        GraphicsDevice graphicsDevice = JavaLib.GraphicsDevice;
        RenderTarget2D renderTarget = new RenderTarget2D(graphicsDevice, width, height);
        SpriteBatch spriteBatch = Display.getDisplay(JavaLib.MIDlet).getSpriteBatch();
        lock (spriteBatch)
        {
            graphicsDevice.SetRenderTarget(renderTarget);
            spriteBatch.Begin();
            spriteBatch.Draw(imageUnder.texture2D, new Rectangle(0, 0, width, height), Color.White);
            spriteBatch.Draw(imageOver.texture2D, new Rectangle(0, 0, width, height), Color.White);
            spriteBatch.End();
            graphicsDevice.SetRenderTarget(TheSims3.currentTarget);
            image.texture2D = (Microsoft.Xna.Framework.Graphics.Texture2D)renderTarget;
        }
        m3g.Texture2D texture2D = new m3g.Texture2D(new Image2D(100, image));
        texture2D.setFiltering(210, 209);
        AppEngine.timerEnd(nameof(mergeTextures));
        return texture2D;
    }

    public static void doubleTextureUnits(Node node, int simId)
    {
        if (node == null)
            return;
        Group group = Group.m3g_cast((Object3D)node);
        if (group != null)
        {
            int childCount = group.getChildCount();
            for (int index = 0; index < childCount; ++index)
                ModelManager.doubleTextureUnits(group.getChild(index), simId);
        }
        float[] scaleBias = new float[10];
        Mesh mesh = Mesh.m3g_cast((Object3D)node);
        if (mesh == null)
            return;
        int submeshCount = mesh.getSubmeshCount();
        for (int index = 0; index < submeshCount; ++index)
        {
            switch (AppEngine.indexOf(mesh.getAppearance(index), ModelManager.getInstance().m_simAppearances[simId]))
            {
                case 6:
                case 7:
                case 8:
                    m3g.VertexBuffer vertexBuffer = mesh.getVertexBuffer();
                    VertexArray texCoords = vertexBuffer.getTexCoords(0, ref scaleBias);
                    if (vertexBuffer.getTexCoords(1, ref scaleBias) == null)
                    {
                        float scale = scaleBias[0];
                        scaleBias[0] = scaleBias[1];
                        scaleBias[1] = scaleBias[2];
                        scaleBias[2] = scaleBias[3];
                        vertexBuffer.setTexCoords(1, texCoords, scale, scaleBias);
                        break;
                    }
                    break;
            }
        }
        SkinnedMesh skinnedMesh = SkinnedMesh.m3g_cast((Object3D)node);
        if (skinnedMesh == null)
            return;
        ModelManager.doubleTextureUnits((Node)skinnedMesh.getSkeleton(), simId);
    }

    public static void dumpTree(Node node, string prefix)
    {
    }

    public void preloadSimAssets()
    {
        if (this.m_simMaleNode != null)
            return;
        ResourceManager resourceManager = AppEngine.getResourceManager();
        AppEngine.timerBegin();
        this.m_simMaleNode = resourceManager.loadM3GNode(179);
        AppEngine.timerEnd("preloadSimAssets-male");
        AppEngine.timerBegin();
        this.m_simFemaleNode = resourceManager.loadM3GNode(178);
        AppEngine.timerEnd("preloadSimAssets-female");
        this.m_simMaleSkeleton = (Group)((SkinnedMesh)this.m_simMaleNode.find(200)).getSkeleton().duplicate();
        this.cleanSimHair(this.m_simMaleSkeleton);
        this.m_simFemaleSkeleton = (Group)((SkinnedMesh)this.m_simFemaleNode.find(250)).getSkeleton().duplicate();
        this.cleanSimHair(this.m_simFemaleSkeleton);
    }

    private void cleanSimHair(Group meshSkeleton)
    {
        Vector vector = new Vector();
        Group group1 = (Group)meshSkeleton.find(702);
        int childCount = group1.getChildCount();
        for (int index = 0; index < childCount; ++index)
        {
            Node child = group1.getChild(index);
            Group group2 = Group.m3g_cast((Object3D)child);
            if (child.getUserID() == 0 && group2 != null && (group2.getChildCount() == 1 && group2.getChild(0).getUserID() != 0))
                vector.addElement((object)child);
        }
        for (int index = 0; index < vector.size(); ++index)
            ModelManager.orphanNode((Node)vector.elementAt(index));
    }

    public Node getSimModel(int simId, bool forCAS, bool naked)
    {
        ResourceManager resourceManager = AppEngine.getResourceManager();
        SimData simData = AppEngine.getCanvas().getSimData();
        SimWorld simWorld = AppEngine.getCanvas().getSimWorld();
        this.preloadSimAssets();
        AppEngine.timerBegin();
        int simAttributeUnique1 = simData.getSimAttributeUnique(simId, 2);
        int simAttributeUnique2 = simData.getSimAttributeUnique(simId, 11);
        int simAttributeUnique3 = simData.getSimAttributeUnique(simId, 5);
        int simAttributeUnique4 = simData.getSimAttributeUnique(simId, 7);
        int simAttributeUnique5 = simData.getSimAttributeUnique(simId, 9);
        int meshAttrib1 = simData.mapAttributeToMeshAttrib(simId, 2);
        int meshAttrib2 = simData.mapAttributeToMeshAttrib(simId, 11);
        int meshAttrib3 = simData.mapAttributeToMeshAttrib(simId, 14);
        int meshAttrib4 = simData.mapAttributeToMeshAttrib(simId, 5);
        int meshAttrib5 = simData.mapAttributeToMeshAttrib(simId, 7);
        int meshAttrib6 = simData.mapAttributeToMeshAttrib(simId, 9);
        int simMeshUserId1 = simWorld.getSimMeshUserId(meshAttrib1, simAttributeUnique1);
        string simMeshFilename1 = simWorld.getSimMeshFilename(meshAttrib1, simAttributeUnique1);
        int simMeshFlags = simWorld.getSimMeshFlags(meshAttrib2, simAttributeUnique2);
        int simMeshUserId2 = simWorld.getSimMeshUserId(meshAttrib2, simAttributeUnique2);
        string simMeshFilename2 = simWorld.getSimMeshFilename(meshAttrib2, simAttributeUnique2);
        int simMeshUserId3 = simWorld.getSimMeshUserId(meshAttrib4, simAttributeUnique3);
        string filename1 = simWorld.getSimMeshFilename(meshAttrib4, simAttributeUnique3);
        int simMeshUserId4 = simWorld.getSimMeshUserId(meshAttrib5, simAttributeUnique4);
        string filename2 = simWorld.getSimMeshFilename(meshAttrib5, simAttributeUnique4);
        int simMeshUserId5 = simWorld.getSimMeshUserId(meshAttrib6, simAttributeUnique5);
        string filename3 = simWorld.getSimMeshFilename(meshAttrib6, simAttributeUnique5);
        if (naked)
        {
            int meshAttrib7 = simData.mapAttributeToMeshAttrib(simId, 1);
            simMeshUserId3 = simWorld.getSimMeshUserId(meshAttrib7, 1);
            filename1 = (string)null;
            simMeshUserId4 = simWorld.getSimMeshUserId(meshAttrib7, 2);
            filename2 = (string)null;
            simMeshUserId5 = simWorld.getSimMeshUserId(meshAttrib7, 3);
            filename3 = (string)null;
        }
        bool flag = simData.isSimMale(simId);
        Node node1 = flag ? this.m_simMaleNode : this.m_simFemaleNode;
        Group skeleton = (Group)(flag ? (Object3D)this.m_simMaleSkeleton : (Object3D)this.m_simFemaleSkeleton).duplicate();
        Node node2 = (Node)null;
        Node node3 = simMeshFilename2 == null ? node1 : resourceManager.loadM3GNode(simMeshFilename2);
        Node node4 = (Node)null;
        Node node5 = filename1 == null ? node1 : (!filename1.Equals(simMeshFilename2) ? resourceManager.loadM3GNode(filename1) : node3);
        Node node6 = (Node)null;
        Node node7 = filename2 == null ? node1 : (!filename2.Equals(simMeshFilename2) ? (!filename2.Equals(filename1) ? resourceManager.loadM3GNode(filename2) : node5) : node3);
        Node node8 = (Node)null;
        Node node9 = filename3 == null ? node1 : (!filename3.Equals(simMeshFilename2) ? (!filename3.Equals(filename1) ? (!filename3.Equals(filename2) ? resourceManager.loadM3GNode(filename3) : node7) : node5) : node3);
        Node child1 = (Node)null;
        if ((simMeshFlags & 2) != 0)
        {
            int simMeshUserId6 = simWorld.getSimMeshUserId(meshAttrib3, simAttributeUnique2);
            child1 = (Node)((Node)node3.find(simMeshUserId6)).getParent().duplicate();
        }
        Node child2 = (Node)null;
        if ((simMeshFlags & 1) == 0)
        {
            if (simMeshFilename1 != null)
                child2 = ((Node)(!simMeshFilename1.Equals(simMeshFilename2) ? (!simMeshFilename1.Equals(filename1) ? (!simMeshFilename1.Equals(filename2) ? (!simMeshFilename1.Equals(filename3) ? (Object3D)resourceManager.loadM3GNode(simMeshFilename1) : (Object3D)node9) : (Object3D)node7) : (Object3D)node5) : (Object3D)node3).find(simMeshUserId1)).getParent();
            else
                child2 = (Node)((Node)node1.find(simMeshUserId1)).getParent().duplicate();
        }
        AppEngine.timerBegin();
        SkinnedMesh skinnedMesh1 = SkinnedMesh.m3g_cast(node3.find(simMeshUserId2));
        SkinnedMesh skinnedMesh2 = SkinnedMesh.m3g_cast(node5.find(simMeshUserId3));
        SkinnedMesh skinnedMesh3 = SkinnedMesh.m3g_cast(node7.find(simMeshUserId4));
        SkinnedMesh skinnedMesh4 = SkinnedMesh.m3g_cast(node9.find(simMeshUserId5));
        AppEngine.timerEnd("getSimModel-gather");
        SkinnedMesh[] skinnedMeshes = new SkinnedMesh[4]
        {
      (SkinnedMesh) skinnedMesh1.duplicate(),
      (SkinnedMesh) skinnedMesh2.duplicate(),
      (SkinnedMesh) skinnedMesh3.duplicate(),
      (SkinnedMesh) skinnedMesh4.duplicate()
        };
        AppEngine.timerBegin();
        for (int index = 0; index < skinnedMeshes.Length; ++index)
            this.cleanSimHair(skinnedMeshes[index].getSkeleton());
        AppEngine.timerEnd("getSimModel-cull hair");
        Node node10 = ModelManager.mergeSkinnedMeshes(skinnedMeshes, skeleton);
        node2 = (Node)null;
        node4 = (Node)null;
        node6 = (Node)null;
        node8 = (Node)null;
        AppEngine.timerBegin();
        if (child2 != null || child1 != null)
        {
            Group group = (Group)node10.find(702);
            if (child2 != null)
                group.addChild(child2);
            if (child1 != null)
                group.addChild(child1);
        }
        AppEngine.timerEnd("getSimModel-add hair");
        AppEngine.timerBegin();
        this.applyAppearances(node10, simId);
        AppEngine.timerEnd("getSimModel-apps");
        Node node11 = (Node)node10.find(700);
        if (node11 != null)
            ModelManager.applyAppearance(node11, this.m_simAppearances[simId][3]);
        AppEngine.timerEnd(nameof(getSimModel));
        return node10;
    }

    private void loadSimTexture(
      int simId,
      int textureId,
      string textureFilename,
      int appId,
      int reflectedAppId)
    {
        ResourceManager resourceManager = AppEngine.getResourceManager();
        string str = this.m_simTextureFilenames[simId][textureId];
        if (str != null && str.Equals(textureFilename))
            return;
        m3g.Texture2D texture;
        if (textureFilename.EndsWith(".png"))
        {
            AppEngine.timerBegin();
            texture = new m3g.Texture2D(new Image2D(100, ResourceManager.loadImage(textureFilename)));
            AppEngine.timerEnd("loading PNG texture");
        }
        else
        {
            AppEngine.timerBegin();
            texture = resourceManager.loadM3GTexture2D(textureFilename);
            AppEngine.timerEnd("loading M3G texture");
        }
        texture.setFiltering(210, 209);
        this.getSimAppearance(appId, simId).setTexture(0, texture);
        this.getSimAppearance(reflectedAppId, simId).setTexture(0, texture);
        switch (appId)
        {
            case 0:
                this.getSimAppearance(1, simId).setTexture(0, texture);
                this.getSimAppearance(11, simId).setTexture(0, texture);
                break;
            case 4:
                this.getSimAppearance(5, simId).setTexture(0, texture);
                this.getSimAppearance(15, simId).setTexture(0, texture);
                break;
        }
        this.m_simTextureFilenames[simId][textureId] = textureFilename;
    }

    private void loadSimTexture(
      int simId,
      int textureId,
      string textureFilename,
      int textureIdOver,
      string textureFilenameOver,
      int appId,
      int reflectedAppId,
      bool compressTextures)
    {
        string[] simTextureFilename = this.m_simTextureFilenames[simId];
        if (simTextureFilename[textureId] != null && simTextureFilename[textureId].Equals(textureFilename) && (simTextureFilename[textureIdOver] != null && simTextureFilename[textureIdOver].Equals(textureFilenameOver)))
            return;
        m3g.Texture2D simTexture = TextureManager.getInstance().getSimTexture(simId, textureId, textureFilename, textureIdOver, textureFilenameOver, compressTextures);
        simTexture.setFiltering(210, 209);
        this.getSimAppearance(appId, simId).setTexture(0, simTexture);
        this.getSimAppearance(reflectedAppId, simId).setTexture(0, simTexture);
        simTextureFilename[textureId] = textureFilename;
        if (textureFilenameOver != null)
            simTextureFilename[textureIdOver] = textureFilenameOver;
        else
            simTextureFilename[textureIdOver] = (string)null;
    }

    public void loadSimTextures(int simId, bool forCAS, bool naked)
    {
        AppEngine.timerBegin();
        SimData simData = AppEngine.getCanvas().getSimData();
        SimWorld simWorld = AppEngine.getCanvas().getSimWorld();
        int simAttributeUnique1 = simData.getSimAttributeUnique(simId, 1);
        int simAttributeUnique2 = simData.getSimAttributeUnique(simId, 2);
        int simAttributeUnique3 = simData.getSimAttributeUnique(simId, 3);
        int simAttributeUnique4 = simData.getSimAttributeUnique(simId, 11);
        int simAttributeUnique5 = simData.getSimAttributeUnique(simId, 12);
        int simAttributeUnique6 = simData.getSimAttributeUnique(simId, 4);
        int simAttributeUnique7 = simData.getSimAttributeUnique(simId, 5);
        int simAttributeUnique8 = simData.getSimAttributeUnique(simId, 6);
        int simAttributeUnique9 = simData.getSimAttributeUnique(simId, 7);
        int simAttributeUnique10 = simData.getSimAttributeUnique(simId, 8);
        int simAttributeUnique11 = simData.getSimAttributeUnique(simId, 9);
        int simAttributeUnique12 = simData.getSimAttributeUnique(simId, 10);
        bool flag = simData.isSimMale(simId);
        int meshAttrib1 = simData.mapAttributeToMeshAttrib(simId, 1);
        int optIndex1 = flag ? 0 : 0;
        int optIndex2 = flag ? 1 : 1;
        int optIndex3 = flag ? 2 : 2;
        int optIndex4 = flag ? 3 : 3;
        int meshAttrib2 = simData.mapAttributeToMeshAttrib(simId, 2);
        int meshAttrib3 = simData.mapAttributeToMeshAttrib(simId, 11);
        int meshAttrib4 = simData.mapAttributeToMeshAttrib(simId, 14);
        int num = 0;
        int meshAttrib5 = simData.mapAttributeToMeshAttrib(simId, 5);
        int meshAttrib6 = simData.mapAttributeToMeshAttrib(simId, 7);
        int meshAttrib7 = simData.mapAttributeToMeshAttrib(simId, 9);
        string simTextureFilename1 = simWorld.getSimTextureFilename(meshAttrib2, simAttributeUnique2, simAttributeUnique3);
        string simTextureFilename2 = simWorld.getSimTextureFilename(num, 0, simAttributeUnique6);
        string simTextureFilename3 = simWorld.getSimTextureFilename(meshAttrib1, optIndex1, simAttributeUnique1);
        string simTextureFilename4 = simWorld.getSimTextureFilename(meshAttrib3, simAttributeUnique4, simAttributeUnique5);
        string simTextureFilename5 = simWorld.getSimTextureFilename(meshAttrib1, optIndex2, simAttributeUnique1);
        string simTextureFilename6 = simWorld.getSimTextureFilename(meshAttrib5, simAttributeUnique7, simAttributeUnique8);
        string simTextureFilename7 = simWorld.getSimTextureFilename(meshAttrib1, optIndex3, simAttributeUnique1);
        string simTextureFilename8 = simWorld.getSimTextureFilename(meshAttrib6, simAttributeUnique9, simAttributeUnique10);
        string simTextureFilename9 = simWorld.getSimTextureFilename(meshAttrib1, optIndex4, simAttributeUnique1);
        string simTextureFilename10 = simWorld.getSimTextureFilename(meshAttrib7, simAttributeUnique11, simAttributeUnique12);
        string textureFilename = (string)null;
        if ((simWorld.getSimMeshFlags(meshAttrib3, simAttributeUnique4) & 2) != 0)
            textureFilename = simWorld.getSimTextureFilename(meshAttrib4, simAttributeUnique4, simAttributeUnique5);
        int simOverrideType1 = simWorld.getSimOverrideType(meshAttrib3, simAttributeUnique4, meshAttrib1);
        if (simOverrideType1 != -1)
        {
            simTextureFilename3 = simWorld.getSimTextureFilename(meshAttrib1, optIndex1, simOverrideType1);
            simTextureFilename5 = simWorld.getSimTextureFilename(meshAttrib1, optIndex2, simOverrideType1);
            simTextureFilename7 = simWorld.getSimTextureFilename(meshAttrib1, optIndex3, simOverrideType1);
            simTextureFilename9 = simWorld.getSimTextureFilename(meshAttrib1, optIndex4, simOverrideType1);
        }
        string filename = (string)null;
        int simOverrideType2 = simWorld.getSimOverrideType(num, simAttributeUnique6, num);
        if (simOverrideType2 != -1)
            filename = simWorld.getSimTextureFilename(num, 0, simOverrideType2);
        this.loadSimTexture(simId, 1, simTextureFilename1, 4, 14);
        this.loadSimTexture(simId, 0, simTextureFilename2, 2, 12);
        if (textureFilename != null)
            this.loadSimTexture(simId, 10, textureFilename, 9, 19);
        if (filename != null)
        {
            m3g.Texture2D texture = AppEngine.getResourceManager().loadM3GTexture2D(filename);
            this.m_simAppearances[simId][3].setTexture(0, texture);
            this.m_simAppearances[simId][13].setTexture(0, texture);
        }
        else
        {
            m3g.Texture2D texture = this.m_simAppearances[simId][2].getTexture(0);
            this.m_simAppearances[simId][3].setTexture(0, texture);
            this.m_simAppearances[simId][13].setTexture(0, texture);
        }
        bool compressTextures = !forCAS && !naked;
        this.loadSimTexture(simId, 2, simTextureFilename3, 3, simTextureFilename4, 0, 10, compressTextures);
        this.loadSimTexture(simId, 4, simTextureFilename5, 5, naked ? (string)null : simTextureFilename6, 6, 16, compressTextures);
        this.loadSimTexture(simId, 6, simTextureFilename7, 7, naked ? (string)null : simTextureFilename8, 8, 18, compressTextures);
        this.loadSimTexture(simId, 8, simTextureFilename9, 9, naked ? (string)null : simTextureFilename10, 7, 17, compressTextures);
        AppEngine.timerEnd(nameof(loadSimTextures));
    }

    public void unloadSimTextures(int simId)
    {
        this.getSimAppearance(4, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(14, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(5, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(15, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(9, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(19, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(2, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(12, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(3, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(13, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(0, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(10, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(1, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(11, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(6, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(16, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(6, simId).setTexture(1, (m3g.Texture2D)null);
        this.getSimAppearance(16, simId).setTexture(1, (m3g.Texture2D)null);
        this.getSimAppearance(8, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(18, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(8, simId).setTexture(1, (m3g.Texture2D)null);
        this.getSimAppearance(18, simId).setTexture(1, (m3g.Texture2D)null);
        this.getSimAppearance(7, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(17, simId).setTexture(0, (m3g.Texture2D)null);
        this.getSimAppearance(7, simId).setTexture(1, (m3g.Texture2D)null);
        this.getSimAppearance(17, simId).setTexture(1, (m3g.Texture2D)null);
        for (int index = 0; index < this.m_simTextureFilenames[simId].Length; ++index)
            this.m_simTextureFilenames[simId][index] = (string)null;
    }

    private Node loadModel(string filename, bool commit, int extId)
    {
        Node node = AppEngine.getResourceManager().loadM3GNode(filename);
        this.applyAppearances(node, extId);
        if (commit)
            ModelManager.applyCommit(node);
        return node;
    }

    private Node loadModel(int modelId, bool commit)
    {
        ResourceManager resourceManager = AppEngine.getResourceManager();
        int extId = -1;
        string filename;
        if ((modelId & 16384) != 0)
        {
            DLCManager instance = DLCManager.getInstance();
            filename = instance.getModelFilename(modelId);
            extId = instance.getModelPackId(modelId);
        }
        else
            filename = resourceManager.idToFilename(modelId);
        return this.loadModel(filename, commit, extId);
    }

    public Node getModel(int modelId)
    {
        return this.getModel(modelId, true);
    }

    public Node getModel(int modelId, bool commit)
    {
        int index1 = -1;
        for (int index2 = 0; index2 < ModelManager.CACHED_MODELS.Length; ++index2)
        {
            if (modelId == (int)ModelManager.CACHED_MODELS[index2])
            {
                index1 = index2;
                break;
            }
        }
        if (index1 == -1)
            return this.loadModel(modelId, commit);
        if (this.m_modelCache[index1] == null)
            this.m_modelCache[index1] = this.loadModel(modelId, commit);
        return (Node)this.m_modelCache[index1].duplicate();
    }

    public Node getModel(string filename)
    {
        return this.getModel(filename, true);
    }

    public Node getModel(string filename, bool commit)
    {
        int extId = -1;
        DLCManager instance = DLCManager.getInstance();
        int packCount = instance.getPackCount();
        for (int packId = 0; packId < packCount; ++packId)
        {
            string carModelFilename = instance.getMiniCarModelFilename(packId);
            if (carModelFilename != null && carModelFilename.Equals(filename))
            {
                extId = packId;
                break;
            }
        }
        return this.loadModel(filename, commit, extId);
    }

    public m3g.Texture2D addHemisphereMap(Node node)
    {
        m3g.Texture2D refmap = new m3g.Texture2D(this.getHemisphereMapImage());
        refmap.setFiltering(210, 209);
        refmap.setBlending(224);
        ModelManager.applyHemisphereMappedTexture(node, refmap);
        return refmap ?? (m3g.Texture2D)null;
    }

    public static void transformHemisphereMap(m3g.Texture2D hemisphereTexture, Transform cameraTrans)
    {
        ModelManager.tempReflection.set(cameraTrans);
        ModelManager.tempReflection.postScale(0.5f, 0.5f, 0.5f);
        Matrix matrix = ModelManager.tempReflection.getMatrix();
        matrix.M12 = matrix.M13;
        matrix.M22 = matrix.M23;
        matrix.M32 = matrix.M33;
        matrix.M13 = matrix.M23 = matrix.M33 = 0.0f;
        matrix.M41 = 0.5f;
        matrix.M42 = 0.5f;
        matrix.M43 = 0.0f;
        ModelManager.tempReflection.set(ref matrix);
        hemisphereTexture.setTransform(ModelManager.tempReflection);
    }

    public void setLoadStatus(int status)
    {
        ResourceManager resourceManager = AppEngine.getResourceManager();
        DLCManager instance = DLCManager.getInstance();
        if (status != 2 && status != 3 && status != 5)
        {
            this.m_appearances[0].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[1].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[2].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[45].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[43].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[44].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[46].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[47].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[3].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[4].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[5].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[6].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[7].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[8].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[27].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[28].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[29].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[30].setTexture(0, (m3g.Texture2D)null);
            for (int index = 0; index < this.m_modelCache.Length; ++index)
                this.m_modelCache[index] = (Node)null;
        }
        if (status != 3 && this.m_status == 3)
        {
            for (int index = 0; index < this.m_extAppearances.Length; ++index)
            {
                this.m_extAppearances[index][0].setTexture(0, (m3g.Texture2D)null);
                this.m_extAppearances[index][2].setTexture(0, (m3g.Texture2D)null);
                this.m_extAppearances[index][4].setTexture(0, (m3g.Texture2D)null);
                this.m_extAppearances[index][5].setTexture(0, (m3g.Texture2D)null);
                this.m_extAppearances[index][3].setTexture(0, (m3g.Texture2D)null);
                this.m_extAppearances[index][1].setTexture(0, (m3g.Texture2D)null);
                this.m_extAppearances[index][9].setTexture(0, (m3g.Texture2D)null);
                this.m_extAppearances[index][10].setTexture(0, (m3g.Texture2D)null);
            }
            this.m_appearances[56].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[55].setTexture(0, (m3g.Texture2D)null);
        }
        if (status != 2 && status != 3)
        {
            this.m_appearances[49].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[50].setTexture(0, (m3g.Texture2D)null);
        }
        if (status != 5)
        {
            this.m_appearances[16].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[17].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[18].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[19].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[20].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[21].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[22].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[23].setTexture(0, (m3g.Texture2D)null);
        }
        if (status != 4)
        {
            this.m_appearances[11].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[12].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[13].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[14].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[15].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[42].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[52].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[53].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[54].setTexture(0, (m3g.Texture2D)null);
            for (int index = 0; index < this.m_extAppearances.Length; ++index)
                this.m_extAppearances[index][6].setTexture(0, (m3g.Texture2D)null);
        }
        if (status != 1)
        {
            this.m_appearances[35].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[31].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[33].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[36].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[32].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[34].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[39].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[37].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[38].setTexture(0, (m3g.Texture2D)null);
            this.m_appearances[51].setTexture(0, (m3g.Texture2D)null);
        }
        if ((status == 2 || status == 3 || status == 5) && (this.m_status != 2 && this.m_status != 3 && this.m_status != 5))
        {
            m3g.Texture2D texture1 = resourceManager.loadTexture2D(288);
            texture1.setFiltering(210, 209);
            this.m_appearances[0].setTexture(0, texture1);
            this.m_appearances[1].setTexture(0, texture1);
            this.m_appearances[2].setTexture(0, texture1);
            this.m_appearances[45].setTexture(0, texture1);
            this.m_appearances[43].setTexture(0, texture1);
            this.m_appearances[44].setTexture(0, texture1);
            this.m_appearances[46].setTexture(0, texture1);
            this.m_appearances[47].setTexture(0, texture1);
            m3g.Texture2D texture2 = resourceManager.loadTexture2D(254);
            texture2.setFiltering(210, 209);
            this.m_appearances[3].setTexture(0, texture2);
            this.m_appearances[4].setTexture(0, texture2);
            this.m_appearances[5].setTexture(0, texture2);
            this.m_appearances[6].setTexture(0, texture2);
            this.m_appearances[7].setTexture(0, texture2);
            this.m_appearances[8].setTexture(0, texture2);
            m3g.Texture2D texture3 = resourceManager.loadTexture2D(249);
            texture3.setFiltering(210, 209);
            this.m_appearances[27].setTexture(0, texture3);
            this.m_appearances[28].setTexture(0, texture3);
            this.m_appearances[29].setTexture(0, texture3);
            this.m_appearances[30].setTexture(0, texture3);
        }
        if (status == 3 && this.m_status != 3)
        {
            for (int packId = 0; packId < this.m_extAppearances.Length; ++packId)
            {
                string objectTextureFilename = instance.getObjectTextureFilename(packId);
                if (objectTextureFilename != null)
                {
                    m3g.Texture2D texture = resourceManager.loadM3GTexture2D(objectTextureFilename);
                    texture.setFiltering(210, 209);
                    this.m_extAppearances[packId][0].setTexture(0, texture);
                    this.m_extAppearances[packId][2].setTexture(0, texture);
                    this.m_extAppearances[packId][4].setTexture(0, texture);
                    this.m_extAppearances[packId][5].setTexture(0, texture);
                    this.m_extAppearances[packId][3].setTexture(0, texture);
                    this.m_extAppearances[packId][1].setTexture(0, texture);
                    this.m_extAppearances[packId][9].setTexture(0, texture);
                    this.m_extAppearances[packId][10].setTexture(0, texture);
                }
                string scrollingTextureFilename = instance.getObjectScrollingTextureFilename(packId);
                if (scrollingTextureFilename != null)
                {
                    m3g.Texture2D texture = resourceManager.loadM3GTexture2D(scrollingTextureFilename);
                    texture.setFiltering(210, 209);
                    this.m_extAppearances[packId][7].setTexture(0, texture);
                    this.m_extAppearances[packId][8].setTexture(0, texture);
                }
            }
            string simCarTexture = AppEngine.getCanvas().getSimData().getSimCarTexture();
            if (simCarTexture != null)
            {
                m3g.Texture2D texture = resourceManager.loadTexture2D(simCarTexture);
                texture.setFiltering(210, 209);
                this.m_appearances[56].setTexture(0, texture);
                this.m_appearances[55].setTexture(0, texture);
            }
        }
        if ((status == 2 || status == 3) && (this.m_status != 2 && this.m_status != 3))
        {
            m3g.Texture2D texture = resourceManager.loadTexture2D(247);
            texture.setFiltering(210, 209);
            this.m_appearances[49].setTexture(0, texture);
            this.m_appearances[50].setTexture(0, (m3g.Texture2D)texture.duplicate());
        }
        if (status == 5 && this.m_status != 5)
        {
            m3g.Texture2D texture1 = resourceManager.loadTexture2D(240);
            texture1.setFiltering(210, 209);
            m3g.Texture2D texture2 = resourceManager.loadTexture2D(241);
            texture2.setFiltering(210, 209);
            m3g.Texture2D texture3 = resourceManager.loadTexture2D(242);
            texture2.setFiltering(210, 209);
            m3g.Texture2D texture4 = resourceManager.loadTexture2D(243);
            texture4.setFiltering(210, 209);
            this.m_appearances[16].setTexture(0, texture1);
            this.m_appearances[17].setTexture(0, texture1);
            this.m_appearances[18].setTexture(0, texture1);
            this.m_appearances[19].setTexture(0, texture1);
            this.m_appearances[20].setTexture(0, texture1);
            this.m_appearances[21].setTexture(0, texture2);
            this.m_appearances[22].setTexture(0, texture3);
            this.m_appearances[23].setTexture(0, texture4);
        }
        if (status == 4)
        {
            SimWorld simWorld = AppEngine.getCanvas().getSimWorld();
            int townmapTextureId = simWorld.getLocationTownmapTextureId();
            int scrollingTextureId = simWorld.getLocationTownmapScrollingTextureId();
            int townmapCloudTextureId = simWorld.getLocationTownmapCloudTextureId();
            m3g.Texture2D texture1 = resourceManager.loadTexture2D(townmapTextureId);
            texture1.setFiltering(210, 209);
            m3g.Texture2D texture2 = resourceManager.loadTexture2D(291);
            texture2.setFiltering(210, 209);
            m3g.Texture2D texture3 = (m3g.Texture2D)null;
            if (scrollingTextureId != -1)
            {
                texture3 = resourceManager.loadM3GTexture2D(scrollingTextureId);
                texture3.setFiltering(210, 209);
            }
            m3g.Texture2D texture4 = (m3g.Texture2D)null;
            if (townmapCloudTextureId != -1)
                texture4 = resourceManager.loadM3GTexture2D(townmapCloudTextureId);
            this.m_appearances[11].setTexture(0, texture1);
            this.m_appearances[12].setTexture(0, texture1);
            this.m_appearances[13].setTexture(0, texture1);
            this.m_appearances[14].setTexture(0, texture1);
            this.m_appearances[52].setTexture(0, texture3);
            this.m_appearances[53].setTexture(0, texture3);
            this.m_appearances[54].setTexture(0, texture4);
            this.m_appearances[15].setTexture(0, texture2);
            this.m_appearances[42].setTexture(0, texture2);
            for (int packId = 0; packId < this.m_extAppearances.Length; ++packId)
            {
                string carTextureFilename = instance.getMiniCarTextureFilename(packId);
                if (carTextureFilename != null)
                {
                    m3g.Texture2D texture5 = resourceManager.loadM3GTexture2D(carTextureFilename);
                    this.m_extAppearances[packId][6].setTexture(0, texture5);
                }
            }
        }
        if (status == 1 && this.m_status != 1)
        {
            m3g.Texture2D texture1 = resourceManager.loadTexture2D(244);
            texture1.setFiltering(210, 209);
            texture1.setBlending(227);
            this.m_appearances[31].setTexture(0, texture1);
            this.m_appearances[35].setTexture(0, texture1);
            this.m_appearances[33].setTexture(0, texture1);
            this.m_appearances[32].setTexture(0, texture1);
            this.m_appearances[36].setTexture(0, texture1);
            this.m_appearances[34].setTexture(0, texture1);
            this.m_appearances[39].setTexture(0, texture1);
            this.m_appearances[37].setTexture(0, texture1);
            this.m_appearances[38].setTexture(0, texture1);
            m3g.Texture2D texture2 = resourceManager.loadTexture2D(289);
            texture2.setFiltering(210, 209);
            this.m_appearances[51].setTexture(0, texture2);
        }
        this.m_status = status;
    }

    public void updateScrollingTextures(int timeStep)
    {
        DLCManager instance = DLCManager.getInstance();
        int packCount = instance.getPackCount();
        for (int packId = 0; packId < packCount; ++packId)
        {
            int scrollingTextureTiming = instance.getObjectScrollingTextureTiming(packId);
            if (scrollingTextureTiming != 0)
            {
                int num1 = midp.JMath.abs(scrollingTextureTiming);
                this.m_extAppearanceTimers[packId] = (this.m_extAppearanceTimers[packId] + timeStep) % num1;
                float num2 = (float)this.m_extAppearanceTimers[packId] * 2f / (float)num1;
                m3g.Texture2D texture = this.m_extAppearances[packId][7].getTexture(0);
                if (texture != null)
                {
                    if (scrollingTextureTiming < 0)
                        texture.setTranslation(0.0f, num2, 0.0f);
                    else
                        texture.setTranslation(num2, 0.0f, 0.0f);
                }
            }
        }
        this.m_townmapTimer = (this.m_townmapTimer + timeStep) % 4000;
        m3g.Texture2D texture1 = this.m_appearances[52].getTexture(0);
        if (texture1 != null)
        {
            float num = (float)((double)this.m_townmapTimer * 2.0 / 4000.0);
            texture1.setTranslation(-num, 0.0f, 0.0f);
        }
        this.m_townmapCloudsTimer = (this.m_townmapCloudsTimer + timeStep) % 60000;
        m3g.Texture2D texture2 = this.m_appearances[54].getTexture(0);
        if (texture2 == null)
            return;
        float y = (float)((double)this.m_townmapCloudsTimer * 2.0 / 60000.0);
        texture2.setTranslation(0.0f, y, 0.0f);
    }

    public void updateLakesideTextures(int timeStep)
    {
        this.m_lakesideTimerLayer2 = (this.m_lakesideTimerLayer2 + timeStep) % 90000;
        this.m_lakesideTimerLayer3 = (this.m_lakesideTimerLayer3 + timeStep) % 24000;
        this.m_lakesideTimerLayer4 = (this.m_lakesideTimerLayer4 + timeStep) % 32000;
        m3g.Texture2D texture1 = this.m_appearances[21].getTexture(0);
        if (texture1 != null)
        {
            float y = (float)((double)this.m_lakesideTimerLayer2 * 2.0 / 90000.0);
            texture1.setTranslation(0.0f, y, 0.0f);
        }
        m3g.Texture2D texture2 = this.m_appearances[22].getTexture(0);
        if (texture2 != null)
        {
            float x = (float)((double)this.m_lakesideTimerLayer3 * 2.0 / 24000.0);
            texture2.setTranslation(x, 0.0f, 0.0f);
        }
        m3g.Texture2D texture3 = this.m_appearances[23].getTexture(0);
        if (texture3 == null)
            return;
        float x1 = (float)((double)this.m_lakesideTimerLayer4 * 2.0 / 32000.0);
        texture3.setTranslation(x1, 0.0f, 0.0f);
    }

    public void clearTVFrame()
    {
        this.m_tvUpdatedAction = this.m_tvUpdatedComedy = false;
    }

    public void setTVFrame(int index, bool action)
    {
        if (action && this.m_tvUpdatedAction || !action && this.m_tvUpdatedComedy)
            return;
        m3g.Texture2D texture = this.getAppearance(action ? 49 : 50).getTexture(0);
        if (texture == null)
            return;
        if (action)
            this.m_tvUpdatedAction = true;
        else
            this.m_tvUpdatedComedy = true;
        float x = (float)(index % 4) * 0.25f;
        float num = (float)(index / 4) * 0.125f;
        texture.setTranslation(x, 1f - num, 0.0f);
    }

    public void overrideAppearance(Node node, int appFromUserID, Appearance appTo)
    {
        if (node == null)
            return;
        Group group = Group.m3g_cast((Object3D)node);
        if (group != null)
        {
            int childCount = group.getChildCount();
            for (int index = 0; index < childCount; ++index)
                this.overrideAppearance(group.getChild(index), appFromUserID, appTo);
        }
        Mesh mesh = Mesh.m3g_cast((Object3D)node);
        if (mesh == null)
            return;
        int submeshCount = mesh.getSubmeshCount();
        for (int index = 0; index < submeshCount; ++index)
        {
            if (mesh.getAppearance(index).getUserID() == appFromUserID)
                mesh.setAppearance(index, appTo);
        }
        SkinnedMesh skinnedMesh = SkinnedMesh.m3g_cast((Object3D)node);
        if (skinnedMesh == null)
            return;
        this.overrideAppearance((Node)skinnedMesh.getSkeleton(), appFromUserID, appTo);
    }
}
