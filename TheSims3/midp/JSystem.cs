// Decompiled with JetBrains decompiler
// Type: midp.System
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;
using System.Diagnostics;

namespace midp
{
    public sealed class JSystem
    {
        public static long currentTimeMillis()
        {
            return DateTime.Now.Ticks / 10000L;
        }

        public static void arraycopy(
          Array src,
          int src_position,
          Array dst,
          int dst_position,
          int length)
        {
            Array.Copy(src, src_position, dst, dst_position, length);
        }

        public static void arraycopy(
          Array src,
          int src_position,
          Array dst,
          int dst_position,
          int length,
          int sizeOfItem)
        {
            Array.Copy(src, src_position, dst, dst_position, length);
        }

        public static void println(string str)
        {
            Debug.WriteLine(str);
        }
    }
}
