// Decompiled with JetBrains decompiler
// Type: m3g.SkinnedMesh
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace m3g
{
  public class SkinnedMesh : Mesh
  {
    public const int MAX_WEIGHTS_PER_VERTEX = 4;
    public new const int M3G_UNIQUE_CLASS_ID = 16;
    private Group m_skeleton;
    private bool m_legacy;
    private List<Node> m_bones;
    private Dictionary<Node, Transform> m_atRestTransformByBone;
    private Dictionary<Node, int[]> m_weightsByBone;
    private int[] m_summedWeights;
    private List<Transform> m_transformsCached;
    private Transform[] m_transformArrayCached;
    private Node[] m_boneArrayCached;
    private VertexArray m_skinIndices;
    private VertexArray m_skinWeights;
    private Matrix[] returnArray;

    internal static void requireBoneNotNull(Node bone)
    {
    }

    internal static void requireValidVertexRange(int firstVertex, int numVertices, int vertexCount)
    {
      int num = firstVertex + numVertices;
    }

    internal static void requireWeightNotZero(int weight)
    {
    }

    internal static void ensureBoneWeightsNotNull(int[] weights)
    {
    }

    public SkinnedMesh(
      VertexBuffer vertices,
      ref IndexBuffer[] submeshes,
      ref Appearance[] appearances,
      Group skeleton)
      : base(vertices, ref submeshes, ref appearances)
    {
      this.m_skeleton = (Group) null;
      this.m_legacy = true;
      this.m_bones = (List<Node>) null;
      this.m_atRestTransformByBone = (Dictionary<Node, Transform>) null;
      this.m_weightsByBone = (Dictionary<Node, int[]>) null;
      this.m_summedWeights = new int[0];
      this.m_transformsCached = (List<Transform>) null;
      this.m_transformArrayCached = (Transform[]) null;
      this.m_boneArrayCached = (Node[]) null;
      this.m_skinIndices = (VertexArray) null;
      this.m_skinWeights = (VertexArray) null;
      this.setSkeleton(skeleton);
    }

    public SkinnedMesh(
      VertexBuffer vertices,
      IndexBuffer submesh,
      Appearance appearance,
      Group skeleton)
      : base(vertices, submesh, appearance)
    {
      this.m_skeleton = (Group) null;
      this.m_legacy = true;
      this.m_bones = (List<Node>) null;
      this.m_atRestTransformByBone = (Dictionary<Node, Transform>) null;
      this.m_weightsByBone = (Dictionary<Node, int[]>) null;
      this.m_summedWeights = new int[0];
      this.m_transformsCached = (List<Transform>) null;
      this.m_transformArrayCached = (Transform[]) null;
      this.m_boneArrayCached = (Node[]) null;
      this.m_skinIndices = (VertexArray) null;
      this.m_skinWeights = (VertexArray) null;
      this.setSkeleton(skeleton);
    }

    public SkinnedMesh()
    {
      this.m_skeleton = (Group) null;
      this.m_legacy = true;
      this.m_bones = (List<Node>) null;
      this.m_atRestTransformByBone = (Dictionary<Node, Transform>) null;
      this.m_weightsByBone = (Dictionary<Node, int[]>) null;
      this.m_summedWeights = new int[0];
      this.m_transformsCached = (List<Transform>) null;
      this.m_transformArrayCached = (Transform[]) null;
      this.m_boneArrayCached = (Node[]) null;
      this.m_skinIndices = (VertexArray) null;
      this.m_skinWeights = (VertexArray) null;
    }

    protected override void duplicateTo(ref Object3D ret)
    {
      base.duplicateTo(ref ret);
      SkinnedMesh that = (SkinnedMesh) ret;
      Group skeleton1 = this.getSkeleton();
      Group skeleton2 = (Group) skeleton1.duplicate();
      that.setSkeleton(skeleton2);
      this.duplicateToAddWeight(that, (Node) skeleton1, (Node) skeleton2);
    }

    protected virtual void duplicateToAddWeight(SkinnedMesh that, Node thisBone, Node thatBone)
    {
      if (this.m_weightsByBone.ContainsKey(thisBone))
      {
        int[] numArray = this.m_weightsByBone[thisBone];
        if (numArray != null)
        {
          int length = numArray.Length;
          for (int firstVertex = 0; firstVertex < length; ++firstVertex)
          {
            int weight = numArray[firstVertex];
            if (weight != 0)
              that.addTransform(thatBone, weight, firstVertex, 1);
          }
        }
      }
      if ((object) thisBone.GetType() != (object) typeof (Group) && !thisBone.GetType().IsSubclassOf(typeof (Group)))
        return;
      Group group1 = (Group) thisBone;
      if (group1 == null)
        return;
      Group group2 = (Group) thatBone;
      int childCount = group1.getChildCount();
      for (int index = 0; index < childCount; ++index)
        this.duplicateToAddWeight(that, group1.getChild(index), group2.getChild(index));
    }

    public override int getReferences(ref Object3D[] references)
    {
      int references1 = base.getReferences(ref references);
      int num1 = references1;
      if (this.getSkeleton() != null)
        ++references1;
      if (references != null)
      {
        int length = references.Length;
        if (this.getSkeleton() != null)
        {
          Object3D[] object3DArray = references;
          int index = num1;
          int num2 = index + 1;
          Group skeleton = this.getSkeleton();
          object3DArray[index] = (Object3D) skeleton;
        }
      }
      return references1;
    }

    protected override void findReferences(ref Object3DFinder finder)
    {
      base.findReferences(ref finder);
      finder.find((Object3D) this.getSkeleton());
    }

    public override int animateReferences(int time)
    {
      int val2 = base.animateReferences(time);
      return Math.Min(this.getSkeleton().animate(time), val2);
    }

    public void setSkeleton(Group skeleton)
    {
      SkinnedMesh.requireBoneNotNull((Node) skeleton);
      this.requireVertexBufferNotNull();
      this.m_skeleton = skeleton;
      this.m_skeleton.setParent((Node) this);
      if (!this.isLegacy())
        return;
      this.addTransformWithoutWeightCheck((Node) this.m_skeleton, 0, 0, this.getVertexBuffer().getVertexCount());
    }

    public void setLegacy(bool enable)
    {
      this.m_legacy = enable;
    }

    protected bool isLegacy()
    {
      return this.m_legacy;
    }

    public Matrix[] getBoneTransforms()
    {
      Node[] boneArray = this.getBoneArray();
      int length = boneArray.Length;
      List<Transform> source = this.m_transformsCached;
      if (source == null)
      {
        source = new List<Transform>(length);
        for (int index = 0; index < length; ++index)
          source.Add(new Transform());
        this.m_transformsCached = source;
      }
      source.Capacity = length;
      while (source.Capacity < length)
        source.Add(new Transform());
      Transform[] transformArray = this.m_transformArrayCached;
      if (transformArray == null || transformArray.Length != length)
      {
        transformArray = new Transform[length];
        this.m_transformArrayCached = transformArray;
        this.returnArray = new Matrix[this.m_transformArrayCached.Length];
      }
      for (int index = 0; index < length; ++index)
      {
        Node bone = boneArray[index];
        Transform transform = source.ElementAt<Transform>(index);
        bone.getTransformTo((Node) this, ref transform);
        Transform boneTransform = this.getBoneTransform(bone);
        transform.postMultiply(ref boneTransform);
        transformArray[index] = transform;
        this.returnArray[index] = transform.getMatrix();
      }
      return this.returnArray;
    }

    public int[] getWeights(Node bone)
    {
      return this.m_weightsByBone[bone];
    }

    public VertexArray getSkinIndices()
    {
      this.requireVertexBufferNotNull();
      VertexBuffer vertexBuffer = this.getVertexBuffer();
      VertexArray skinIndices = vertexBuffer.getSkinIndices();
      if (skinIndices == null)
      {
        if (this.m_skinIndices == null)
        {
          int vertexCount = vertexBuffer.getVertexCount();
          this.m_skinIndices = new VertexArray(vertexCount, 4, 1);
          Node[] boneArray = this.getBoneArray();
          int[] numArray1 = new int[4];
          int[] numArray2 = new int[4];
          sbyte[] src = new sbyte[4];
          for (int firstVertex = 0; firstVertex < vertexCount; ++firstVertex)
          {
            for (int index = 0; index < 4; ++index)
            {
              numArray1[index] = 0;
              numArray2[index] = 0;
            }
            for (int index1 = 0; index1 < boneArray.Length; ++index1)
            {
              int num = Math.Abs(this.getWeights(boneArray[index1])[firstVertex]);
              if (num != 0)
              {
                for (int index2 = 0; index2 < 4; ++index2)
                {
                  if (num > numArray2[index2])
                  {
                    for (int index3 = 3; index3 > index2; --index3)
                    {
                      numArray1[index3] = numArray1[index3 - 1];
                      numArray2[index3] = numArray2[index3 - 1];
                    }
                    numArray1[index2] = index1;
                    numArray2[index2] = num;
                    break;
                  }
                }
              }
            }
            for (int index = 0; index < 4; ++index)
            {
              int num = numArray1[index];
              if (num > (int) sbyte.MaxValue)
                num -= 256;
              src[index] = (sbyte) num;
            }
            this.m_skinIndices.set(firstVertex, 1, src);
            this.m_vertexBuffer.finalVertexData[firstVertex].skinIndex.X = (float) src[0];
            this.m_vertexBuffer.finalVertexData[firstVertex].skinIndex.Y = (float) src[1];
            this.m_vertexBuffer.finalVertexData[firstVertex].skinIndex.Z = (float) src[2];
            this.m_vertexBuffer.finalVertexData[firstVertex].skinIndex.W = 0.0f;
          }
        }
        skinIndices = this.m_skinIndices;
      }
      return skinIndices;
    }

    public VertexArray getSkinWeights()
    {
      this.requireVertexBufferNotNull();
      VertexBuffer vertexBuffer = this.getVertexBuffer();
      VertexArray skinWeights = vertexBuffer.getSkinWeights();
      if (skinWeights == null)
      {
        if (this.m_skinWeights == null)
        {
          VertexArray skinIndices = this.getSkinIndices();
          int componentCount = skinIndices.getComponentCount();
          int vertexCount = vertexBuffer.getVertexCount();
          this.m_skinWeights = new VertexArray(vertexCount, componentCount, 4);
          Node[] boneArray = this.getBoneArray();
          float[] values = new float[4];
          int[] numArray = new int[4];
          float[] src = new float[4];
          for (int firstVertex = 0; firstVertex < vertexCount; ++firstVertex)
          {
            for (int index = 0; index < componentCount; ++index)
              numArray[index] = 0;
            skinIndices.get(firstVertex, 1, ref values);
            int val1 = 0;
            int num1 = 0;
            for (int index1 = 0; index1 < 4; ++index1)
            {
              int index2 = (int) (sbyte) values[index1] & (int) byte.MaxValue;
              int weight = this.getWeights(boneArray[index2])[firstVertex];
              val1 = Math.Min(val1, weight);
              num1 += Math.Abs(weight);
              numArray[index1] = weight;
            }
            float num2 = 1f;
            if (num1 > 0)
              num2 /= (float) num1;
            for (int index = 0; index < componentCount; ++index)
              src[index] = num1 <= 0 ? (index != 0 ? 0.0f : 1f) : (float) (numArray[index] - val1) * num2;
            this.m_skinWeights.set(firstVertex, 1, src);
            this.m_vertexBuffer.finalVertexData[firstVertex].skinWeight.X = src[0];
            this.m_vertexBuffer.finalVertexData[firstVertex].skinWeight.Y = src[1];
            this.m_vertexBuffer.finalVertexData[firstVertex].skinWeight.Z = src[2];
            this.m_vertexBuffer.finalVertexData[firstVertex].skinWeight.W = src[3];
          }
        }
        skinWeights = this.m_skinWeights;
      }
      return skinWeights;
    }

    protected void addBone(Node bone)
    {
      SkinnedMesh.requireBoneNotNull(bone);
      this.getSkeleton();
      if (this.m_atRestTransformByBone == null)
        this.m_atRestTransformByBone = new Dictionary<Node, Transform>();
      if (this.m_bones == null)
        this.m_bones = new List<Node>();
      if (this.m_atRestTransformByBone.ContainsKey(bone))
        return;
      Transform transform = new Transform();
      this.getTransformTo(bone, ref transform);
      this.m_atRestTransformByBone.Add(bone, transform);
      this.m_bones.Add(bone);
    }

    protected void addWeight(Node bone, int weight, int firstVertex, int numVertices)
    {
      SkinnedMesh.requireBoneNotNull(bone);
      this.requireVertexBufferNotNull();
      int vertexCount = this.getVertexBuffer().getVertexCount();
      SkinnedMesh.requireValidVertexRange(firstVertex, numVertices, vertexCount);
      if (this.m_weightsByBone == null)
        this.m_weightsByBone = new Dictionary<Node, int[]>();
      int[] numArray1 = this.m_weightsByBone.ContainsKey(bone) ? this.m_weightsByBone[bone] : new int[vertexCount];
      if (this.m_summedWeights.Length == 0)
        this.m_summedWeights = new int[vertexCount];
      int[] numArray2 = numArray1;
      int num1 = firstVertex + numVertices;
      for (int index = firstVertex; index < num1; ++index)
      {
        int num2 = numArray2[index];
        this.m_summedWeights[index] -= Math.Abs(num2);
        int num3 = num2 + weight;
        this.m_summedWeights[index] += Math.Abs(num3);
        numArray2[index] = num3;
      }
      if (this.m_weightsByBone.ContainsKey(bone))
        this.m_weightsByBone[bone] = numArray1;
      else
        this.m_weightsByBone.Add(bone, numArray1);
    }

    public void addTransform(Node bone, int weight, int firstVertex, int numVertices)
    {
      SkinnedMesh.requireWeightNotZero(weight);
      this.addTransformWithoutWeightCheck(bone, weight, firstVertex, numVertices);
    }

    private void addTransformWithoutWeightCheck(
      Node bone,
      int weight,
      int firstVertex,
      int numVertices)
    {
      this.requireIsLegacy();
      SkinnedMesh.requireValidVertexRange(firstVertex, numVertices, (int) ushort.MaxValue);
      this.addBone(bone);
      this.addWeight(bone, weight, firstVertex, numVertices);
    }

    public Node[] getBoneArray()
    {
      if (this.m_boneArrayCached == null)
        this.m_boneArrayCached = this.m_bones.ToArray();
      return this.m_boneArrayCached;
    }

    public Node[] getBones()
    {
      this.requireIsNotLegacy();
      return this.getBoneArray();
    }

    public Transform getBoneTransform(Node bone)
    {
      SkinnedMesh.requireBoneNotNull(bone);
      Dictionary<Node, Transform> restTransformByBone = this.m_atRestTransformByBone;
      return this.m_atRestTransformByBone[bone];
    }

    public void getBoneTransform(Node bone, ref Transform transform)
    {
      Transform transform1 = transform;
      transform.set(this.getBoneTransform(bone));
    }

    public int getBoneVertices(Node bone, ref int[] indices, ref float[] weights)
    {
      this.requireIsLegacy();
      SkinnedMesh.requireBoneNotNull(bone);
      this.requireVertexBufferNotNull();
      if (!this.m_weightsByBone.ContainsKey(bone))
        return 0;
      int[] numArray1 = this.m_weightsByBone[bone];
      if (numArray1 == null)
        return 0;
      bool flag = indices.Length == 0;
      int vertexCount = this.getVertexBuffer().getVertexCount();
      int[] numArray2 = numArray1;
      int[] summedWeights = this.m_summedWeights;
      int index1 = 0;
      for (int index2 = 0; index2 < vertexCount; ++index2)
      {
        int num1 = numArray2[index2];
        if (num1 != 0)
        {
          if (!flag)
          {
            indices[index1] = index2;
            int num2 = summedWeights[index2];
            weights[index1] = (float) num1 / (float) num2;
          }
          ++index1;
        }
      }
      return index1;
    }

    public Group getSkeleton()
    {
      return this.m_skeleton;
    }

    public void setBones(Node[] bones)
    {
      this.requireIsNotLegacy();
      this.getSkeleton();
      for (int index = 0; index < bones.Length; ++index)
        this.addBone(bones[index]);
    }

    private void requireIsNotLegacy()
    {
      this.isLegacy();
    }

    private void requireIsLegacy()
    {
      this.isLegacy();
    }

    private void requireVertexBufferNotNull()
    {
      this.getVertexBuffer();
    }

    public override int getM3GUniqueClassID()
    {
      return 16;
    }

    public static SkinnedMesh m3g_cast(Object3D obj)
    {
      return obj.getM3GUniqueClassID() == 16 ? (SkinnedMesh) obj : (SkinnedMesh) null;
    }
  }
}
