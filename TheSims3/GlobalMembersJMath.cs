// Decompiled with JetBrains decompiler
// Type: GlobalMembersJMath
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

public static class GlobalMembersJMath
{
  public const float E = 2.718282f;
  public const float PI = 3.141593f;

  public static float Math_sqrtPolish(float a, float n)
  {
    return (float) (((double) n + (double) a / (double) n) * 0.5);
  }

  public static double Math_sqrtPolish(double a, double n)
  {
    return (n + a / n) * 0.5;
  }
}
