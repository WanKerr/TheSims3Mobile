// Decompiled with JetBrains decompiler
// Type: RandomNumbers
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

internal static class RandomNumbers
{
    private static Random r;

    internal static int NextNumber()
    {
        if (r == null)
            Seed();

        return r.Next();
    }

    internal static int NextNumber(int ceiling)
    {
        if (r == null)
            Seed();

        return r.Next(ceiling);
    }

    internal static void Seed()
    {
        r = new Random();
    }

    internal static void Seed(int seed)
    {
        r = new Random(seed);
    }
}
