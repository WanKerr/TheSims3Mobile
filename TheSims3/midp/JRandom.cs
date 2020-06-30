// Decompiled with JetBrains decompiler
// Type: midp.JRandom
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace midp
{
  public class JRandom
  {
    private long mSeed;

    public JRandom()
    {
      this.mSeed = 0L;
      this.setSeed(JSystem.currentTimeMillis());
    }

    public JRandom(long seed)
    {
      this.mSeed = 0L;
      this.setSeed(seed);
    }

    public void Dispose()
    {
    }

    protected int next(int bits)
    {
      this.mSeed = this.mSeed * 25214903917L + 11L & 281474976710655L;
      return (int) ((ulong) this.mSeed >> 48 - bits);
    }

    public float nextFloat()
    {
      return (float) this.next(24) / 1.677722E+07f;
    }

    public int nextInt()
    {
      return this.next(32);
    }

    public int nextInt(int n)
    {
      if ((n & -n) == n)
        return (int) ((long) n * (long) this.next(31) >> 31);
      int num1;
      int num2;
      do
      {
        num1 = this.next(31);
        num2 = num1 % n;
      }
      while (num1 - num2 + (n - 1) < 0);
      return num2;
    }

    public void setSeed(long seed)
    {
      this.mSeed = (seed ^ 25214903917L) & 281474976710655L;
    }
  }
}
