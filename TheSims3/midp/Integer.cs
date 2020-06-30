// Decompiled with JetBrains decompiler
// Type: midp.Integer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

namespace midp
{
  public sealed class Integer
  {
    public const int MAX_VALUE = 2147483647;
    public const int MIN_VALUE = -2147483648;
    private int integer;

    public Integer(int value)
    {
      this.integer = value;
    }

    public sbyte byteValue()
    {
      return (sbyte) this.integer;
    }

    public int intValue()
    {
      return this.integer;
    }

    public static string toBinaryString(int i)
    {
      return Convert.ToString(i, 2);
    }

    public static string toHexString(int i)
    {
      return Convert.ToString(i, 16);
    }

    public static string toOctalString(int i)
    {
      return Convert.ToString(i, 8);
    }

    public static string toString(int i)
    {
      return i.ToString();
    }

    public static int parseInt(string s)
    {
      return Integer.parseInt(s, 10);
    }

    public static int parseInt(string s, int radix)
    {
      return Convert.ToInt32(s, radix);
    }

    public static Integer valueOf(string s)
    {
      return Integer.valueOf(s, 10);
    }

    public static Integer valueOf(string s, int radix)
    {
      return new Integer(Integer.parseInt(s, radix));
    }

    public override bool Equals(object obj)
    {
      return obj is Integer integer && integer.intValue() == this.intValue();
    }

    public override int GetHashCode()
    {
      return this.integer;
    }
  }
}
