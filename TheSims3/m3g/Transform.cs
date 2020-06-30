// Decompiled with JetBrains decompiler
// Type: m3g.Transform
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;

namespace m3g
{
  public class Transform
  {
    public Matrix mat = new Matrix();

    public Transform(Transform rhs)
    {
      this.set(rhs);
    }

    public Transform()
    {
      this.setIdentity();
    }

    public Transform(Matrix m)
    {
      this.set(ref m);
    }

    public void setIdentity()
    {
      this.mat = Matrix.Identity;
    }

    public void set(ref Matrix m)
    {
      this.mat = m;
    }

    public void set(Transform t)
    {
      this.mat = t.mat;
    }

    public void set(float[] matrix)
    {
      this.mat.M11 = matrix[0];
      this.mat.M12 = matrix[4];
      this.mat.M13 = matrix[8];
      this.mat.M14 = matrix[12];
      this.mat.M21 = matrix[1];
      this.mat.M22 = matrix[5];
      this.mat.M23 = matrix[9];
      this.mat.M24 = matrix[13];
      this.mat.M31 = matrix[2];
      this.mat.M32 = matrix[6];
      this.mat.M33 = matrix[10];
      this.mat.M34 = matrix[14];
      this.mat.M41 = matrix[3];
      this.mat.M42 = matrix[7];
      this.mat.M43 = matrix[11];
      this.mat.M44 = matrix[15];
    }

    public void setx(int[] matrix)
    {
      float num = 1f / 65536f;
      float[] matrix1 = new float[16];
      for (int index = 0; index < 16; ++index)
        matrix1[index] = (float) matrix[index] * num;
      this.set(matrix1);
    }

    public Matrix getMatrix()
    {
      return this.mat;
    }

    public void get(ref Matrix mat_in)
    {
      mat_in = this.mat;
    }

    public void get(ref float[] matrix)
    {
      matrix[0] = this.mat.M11;
      matrix[4] = this.mat.M12;
      matrix[8] = this.mat.M13;
      matrix[12] = this.mat.M14;
      matrix[1] = this.mat.M21;
      matrix[5] = this.mat.M22;
      matrix[9] = this.mat.M23;
      matrix[13] = this.mat.M24;
      matrix[2] = this.mat.M31;
      matrix[6] = this.mat.M32;
      matrix[10] = this.mat.M33;
      matrix[14] = this.mat.M34;
      matrix[3] = this.mat.M41;
      matrix[7] = this.mat.M42;
      matrix[11] = this.mat.M43;
      matrix[15] = this.mat.M44;
    }

    public void getx(ref int[] matrix)
    {
      float[] matrix1 = new float[16];
      this.get(ref matrix1);
      for (int index = 0; index < 16; ++index)
        matrix[index] = (int) ((double) matrix1[index] * 65536.0 + 0.5);
    }

    public void postTranslate(float tx, float ty, float tz)
    {
      this.mat.M41 += (float) ((double) tx * (double) this.mat.M11 + (double) ty * (double) this.mat.M21 + (double) tz * (double) this.mat.M31);
      this.mat.M42 += (float) ((double) tx * (double) this.mat.M12 + (double) ty * (double) this.mat.M22 + (double) tz * (double) this.mat.M32);
      this.mat.M43 += (float) ((double) tx * (double) this.mat.M13 + (double) ty * (double) this.mat.M23 + (double) tz * (double) this.mat.M33);
    }

    public void postTranslatex(int tx, int ty, int tz)
    {
      this.postTranslate((float) tx * 1.525879E-05f, (float) ty * 1.525879E-05f, (float) tz * 1.525879E-05f);
    }

    public void postScale(float sx, float sy, float sz)
    {
      this.mat.M11 *= sx;
      this.mat.M12 *= sx;
      this.mat.M13 *= sx;
      this.mat.M14 *= sx;
      this.mat.M21 *= sy;
      this.mat.M22 *= sy;
      this.mat.M23 *= sy;
      this.mat.M24 *= sy;
      this.mat.M31 *= sz;
      this.mat.M32 *= sz;
      this.mat.M33 *= sz;
      this.mat.M34 *= sz;
    }

    public void postScalex(int sx, int sy, int sz)
    {
      this.postScale((float) sx * 1.525879E-05f, (float) sy * 1.525879E-05f, (float) sz * 1.525879E-05f);
    }

    public void postRotate(float degrees, float ax, float ay, float az)
    {
      Quaternion quat;
      Transform.angleAxisToQuat(degrees, ax, ay, az, out quat);
      this.postRotateQuat(quat.X, quat.Y, quat.Z, quat.W);
    }

    public void postRotatex(int degrees, int ax, int ay, int az)
    {
      Quaternion quat;
      Transform.angleAxisToQuat((float) degrees * 1.525879E-05f, (float) ax * 1.525879E-05f, (float) ay * 1.525879E-05f, (float) az * 1.525879E-05f, out quat);
      this.postRotateQuat(quat.X, quat.Y, quat.Z, quat.W);
    }

    public void postRotateQuat(float qx, float qy, float qz, float qw)
    {
      float num1 = 1f / midp.JMath.sqrt((float) ((double) qx * (double) qx + (double) qy * (double) qy + (double) qz * (double) qz + (double) qw * (double) qw));
      float num2 = num1 * qx;
      float num3 = num1 * qy;
      float num4 = num1 * qz;
      float num5 = num1 * qw;
      float num6 = (float) ((double) num2 * (double) num2 * 2.0);
      float num7 = (float) ((double) num2 * (double) num3 * 2.0);
      float num8 = (float) ((double) num2 * (double) num4 * 2.0);
      float num9 = (float) ((double) num2 * (double) num5 * 2.0);
      float num10 = (float) ((double) num3 * (double) num3 * 2.0);
      float num11 = (float) ((double) num3 * (double) num4 * 2.0);
      float num12 = (float) ((double) num3 * (double) num5 * 2.0);
      float num13 = (float) ((double) num4 * (double) num4 * 2.0);
      float num14 = (float) ((double) num4 * (double) num5 * 2.0);
      Matrix b = new Matrix()
      {
        M11 = (float) (1.0 - ((double) num10 + (double) num13)),
        M21 = num7 - num14,
        M31 = num8 + num12,
        M12 = num7 + num14,
        M22 = (float) (1.0 - ((double) num6 + (double) num13)),
        M32 = num11 - num9,
        M13 = num8 - num12,
        M23 = num11 + num9,
        M33 = (float) (1.0 - ((double) num6 + (double) num10))
      };
      this.postMultiply_34(ref b);
    }

    private void postMultiply_34(ref Matrix b)
    {
      float num1 = (float) ((double) this.mat.M11 * (double) b.M11 + (double) this.mat.M21 * (double) b.M12 + (double) this.mat.M31 * (double) b.M13);
      float num2 = (float) ((double) this.mat.M11 * (double) b.M21 + (double) this.mat.M21 * (double) b.M22 + (double) this.mat.M31 * (double) b.M23);
      float num3 = (float) ((double) this.mat.M11 * (double) b.M31 + (double) this.mat.M21 * (double) b.M32 + (double) this.mat.M31 * (double) b.M33);
      float num4 = (float) ((double) this.mat.M11 * (double) b.M41 + (double) this.mat.M21 * (double) b.M42 + (double) this.mat.M31 * (double) b.M43) + this.mat.M41;
      this.mat.M11 = num1;
      this.mat.M21 = num2;
      this.mat.M31 = num3;
      this.mat.M41 = num4;
      float num5 = (float) ((double) this.mat.M12 * (double) b.M11 + (double) this.mat.M22 * (double) b.M12 + (double) this.mat.M32 * (double) b.M13);
      float num6 = (float) ((double) this.mat.M12 * (double) b.M21 + (double) this.mat.M22 * (double) b.M22 + (double) this.mat.M32 * (double) b.M23);
      float num7 = (float) ((double) this.mat.M12 * (double) b.M31 + (double) this.mat.M22 * (double) b.M32 + (double) this.mat.M32 * (double) b.M33);
      float num8 = (float) ((double) this.mat.M12 * (double) b.M41 + (double) this.mat.M22 * (double) b.M42 + (double) this.mat.M32 * (double) b.M43) + this.mat.M42;
      this.mat.M12 = num5;
      this.mat.M22 = num6;
      this.mat.M32 = num7;
      this.mat.M42 = num8;
      float num9 = (float) ((double) this.mat.M13 * (double) b.M11 + (double) this.mat.M23 * (double) b.M12 + (double) this.mat.M33 * (double) b.M13);
      float num10 = (float) ((double) this.mat.M13 * (double) b.M21 + (double) this.mat.M23 * (double) b.M22 + (double) this.mat.M33 * (double) b.M23);
      float num11 = (float) ((double) this.mat.M13 * (double) b.M31 + (double) this.mat.M23 * (double) b.M32 + (double) this.mat.M33 * (double) b.M33);
      float num12 = (float) ((double) this.mat.M13 * (double) b.M41 + (double) this.mat.M23 * (double) b.M42 + (double) this.mat.M33 * (double) b.M43) + this.mat.M43;
      this.mat.M13 = num9;
      this.mat.M23 = num10;
      this.mat.M33 = num11;
      this.mat.M43 = num12;
    }

    public void postRotateQuatx(int qx, int qy, int qz, int qw)
    {
      this.postRotateQuat((float) qx * 1.525879E-05f, (float) qy * 1.525879E-05f, (float) qz * 1.525879E-05f, (float) qw * 1.525879E-05f);
    }

    public void transformx(ref int[] vector)
    {
      for (int index = 0; index < vector.Length; index += 4)
      {
        Vector4 result = new Vector4()
        {
          X = (float) vector[index] * 1.525879E-05f,
          Y = (float) vector[index + 1] * 1.525879E-05f,
          Z = (float) vector[index + 2] * 1.525879E-05f,
          W = (float) vector[index + 3] * 1.525879E-05f
        };
        Vector4.Transform(ref result, ref this.mat, out result);
        vector[index] = (int) ((double) result.X * 65536.0 + 0.5);
        vector[index + 1] = (int) ((double) result.Y * 65536.0 + 0.5);
        vector[index + 2] = (int) ((double) result.Z * 65536.0 + 0.5);
        vector[index + 3] = (int) ((double) result.W * 65536.0 + 0.5);
      }
    }

    public void transform(ref float[] vector)
    {
      this.transform(vector, vector.Length);
    }

    public void transform(float[] vector, int length)
    {
      for (int index = 0; index < length; index += 4)
      {
        Vector4 result = new Vector4()
        {
          X = vector[index],
          Y = vector[index + 1],
          Z = vector[index + 2],
          W = vector[index + 3]
        };
        Vector4.Transform(ref result, ref this.mat, out result);
        vector[index] = result.X;
        vector[index + 1] = result.Y;
        vector[index + 2] = result.Z;
        vector[index + 3] = result.W;
      }
    }

    public void postMultiply(ref Transform trans)
    {
      Matrix.Multiply(ref trans.mat, ref this.mat, out this.mat);
    }

    public void invert()
    {
      Matrix.Invert(ref this.mat, out this.mat);
    }

    public static void angleAxisToQuatx(
      int degrees,
      int x,
      int y,
      int z,
      out int qX,
      out int qY,
      out int qZ,
      out int qW)
    {
      if (degrees == 0 || x == 0 && y == 0 && z == 0)
      {
        qX = 0;
        qY = 0;
        qZ = 0;
        qW = 65536;
      }
      else
      {
        float num1 = (float) ((double) degrees * System.Math.PI / 23592960.0);
        float num2 = (float) System.Math.Sin((double) num1);
        float num3 = (float) System.Math.Cos((double) num1);
        float num4 = (float) x * 1.525879E-05f;
        float num5 = (float) y * 1.525879E-05f;
        float num6 = (float) z * 1.525879E-05f;
        float num7 = 1f / (float) System.Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5 + (double) num6 * (double) num6);
        qX = (int) ((double) num2 * (double) x * (double) num7 + 0.5);
        qY = (int) ((double) num2 * (double) y * (double) num7 + 0.5);
        qZ = (int) ((double) num2 * (double) z * (double) num7 + 0.5);
        qW = (int) ((double) num3 * 65536.0 + 0.5);
      }
    }

    public static void angleAxisToQuat(
      float degrees,
      float x,
      float y,
      float z,
      out Quaternion quat)
    {
      if ((double) degrees != 0.0 && (double) x == 0.0 && ((double) y == 0.0 && (double) z == 0.0))
      {
        quat = new Quaternion();
      }
      else
      {
        float num1 = (float) ((double) degrees * System.Math.PI / 360.0);
        float num2 = (float) System.Math.Sin((double) num1);
        float num3 = (float) System.Math.Cos((double) num1);
        float num4 = 1f / (float) System.Math.Sqrt((double) x * (double) x + (double) y * (double) y + (double) z * (double) z);
        quat = new Quaternion()
        {
          X = num2 * x * num4,
          Y = num2 * y * num4,
          Z = num2 * z * num4,
          W = num3
        };
      }
    }

    public void getTranslate(ref float tx, ref float ty, ref float tz)
    {
      tx = this.mat.M41;
      ty = this.mat.M42;
      tz = this.mat.M43;
    }

    public void getTranslatex(ref int tx, ref int ty, ref int tz)
    {
      tx = (int) ((double) this.mat.M41 * 65536.0);
      ty = (int) ((double) this.mat.M42 * 65536.0);
      tz = (int) ((double) this.mat.M43 * 65536.0);
    }

    public void transform(ref Vector4 vector)
    {
      vector = Vector4.Transform(vector, this.mat);
    }
  }
}
