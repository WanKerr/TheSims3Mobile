// Decompiled with JetBrains decompiler
// Type: midp.Math
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace midp
{
  public sealed class JMath
  {
    public const float E = 2.718282f;
    public const float PI = 3.141593f;

    public static int abs(int a)
    {
      return a <= -a ? -a : a;
    }

    public static float abs(float a)
    {
      return (double) a <= -(double) a ? -a : a;
    }

    public static float max(float a, float b)
    {
      return (double) a <= (double) b ? b : a;
    }

    public static double max(double a, double b)
    {
      return a <= b ? b : a;
    }

    public static int max(int a, int b)
    {
      return a <= b ? b : a;
    }

    public static float min(float a, float b)
    {
      return (double) a >= (double) b ? b : a;
    }

    public static double min(double a, double b)
    {
      return a >= b ? b : a;
    }

    public static int min(int a, int b)
    {
      return a >= b ? b : a;
    }

    public static float sqrt(float a)
    {
      if ((double) a == 0.0 || (double) a == 1.0)
        return a;
      float n = 1f;
      for (int index = 0; index < 10; ++index)
        n = GlobalMembersJMath.Math_sqrtPolish(a, n);
      return n;
    }

    public static int sqrt(int a)
    {
      return (int) System.Math.Sqrt((double) a);
    }

    public static float Sqrt(float a)
    {
      return JMath.sqrt(a);
    }

    public static float tan(float a)
    {
      float num1 = a;
      float num2 = a * a;
      float num3 = a * num2;
      float num4 = num1 + 0.3333333f * num3;
      float num5 = num3 * num2;
      float num6 = num4 + 0.1333333f * num5;
      float num7 = num5 * num2;
      return num6 + 0.05396825f * num7 + 0.02186949f * (num7 * num2);
    }

    public static double tan(double a)
    {
      double num1 = a;
      double num2 = a * a;
      double num3 = a * num2;
      double num4 = num1 + 1.0 / 3.0 * num3;
      double num5 = num3 * num2;
      double num6 = num4 + 2.0 / 15.0 * num5;
      double num7 = num5 * num2;
      return num6 + 17.0 / 315.0 * num7 + 0.0218694885361552 * (num7 * num2);
    }

    public static float cos(float a)
    {
      int num = 65536;
      return (float) MathExt.Fcos((int) ((double) num * (double) a)) / (float) num;
    }

    public static double cos(double a)
    {
      if (a == 0.0)
        return 1.0;
      double num1 = a / (2.0 * System.Math.PI);
      double num2 = a - 2.0 * System.Math.PI * num1;
      double num3 = 1.0;
      double num4 = num2 * num2;
      double num5 = num4 * 0.5;
      double num6 = num3 - num5;
      double num7 = num5 * (num4 * (1.0 / 12.0));
      double num8 = num6 + num7;
      double num9 = num7 * (num4 * (1.0 / 32.0));
      double num10 = num8 - num9;
      double num11 = num9 * (num4 * (1.0 / 56.0));
      double num12 = num10 + num11;
      double num13 = num11 * (num4 * (1.0 / 90.0));
      double num14 = num12 - num13;
      double num15 = num13 * (num4 * (1.0 / 132.0));
      return num14 + num15 - num15 * (num4 * (1.0 / 182.0));
    }

    public static float sin(float a)
    {
      int num = 65536;
      return (float) MathExt.Fsin((int) ((double) num * (double) a)) / (float) num;
    }

    public static double sin(double a)
    {
      if (a > -0.2 && a < 0.2)
        return a;
      double num1 = a / (2.0 * System.Math.PI);
      double num2 = a - 2.0 * System.Math.PI * num1;
      double num3 = num2;
      double num4 = num2 * num2;
      double num5 = num2 * num4 * (1.0 / 6.0);
      double num6 = num3 - num5;
      double num7 = num5 * (num4 * 0.05);
      double num8 = num6 + num7;
      double num9 = num7 * (num4 * (1.0 / 42.0));
      double num10 = num8 - num9;
      double num11 = num9 * (num4 * (1.0 / 72.0));
      double num12 = num10 + num11;
      double num13 = num11 * (num4 * (1.0 / 110.0));
      return num12 - num13 + num13 * (num4 * (1.0 / 156.0));
    }

    public static float Sin(float a)
    {
      return JMath.sin(a);
    }

    public static float Cos(float a)
    {
      return JMath.cos(a);
    }

    internal static int Atan2(int p, int p_2)
    {
      return (int) (System.Math.Atan2((double) p / 65563.0, (double) p_2 / 65536.0) * 65536.0);
    }

    internal static int Atan2(float p, float p_2)
    {
      return (int) (System.Math.Atan2((double) p / 65563.0, (double) p_2 / 65536.0) * 65536.0);
    }

    internal static float acos(float y)
    {
      return (float) System.Math.Acos((double) y);
    }
  }
}
