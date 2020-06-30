// Decompiled with JetBrains decompiler
// Type: MathExt
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

public sealed class MathExt
{
    public static readonly int[] Facos_neg_percalc = new int[5]
    {
    205525,
    205375,
    205260,
    205163,
    205077
    };
    public static readonly int[] Facos_pos_percalc = new int[5]
    {
    270,
    512,
    627,
    724,
    809
    };
    public static readonly int[] Fsqrt_smallest_precalced = new int[48]
    {
    0,
    256,
    362,
    443,
    512,
    572,
    627,
    677,
    724,
    768,
    810,
    849,
    887,
    923,
    958,
    991,
    1024,
    1056,
    1086,
    1116,
    1145,
    1173,
    1201,
    1227,
    1254,
    1280,
    1305,
    1330,
    1355,
    1378,
    1402,
    1425,
    1448,
    1471,
    1493,
    1515,
    1536,
    1557,
    1578,
    1599,
    1619,
    1639,
    1659,
    1679,
    1698,
    1717,
    1736,
    1755
    };
    private const int PI_Q16_INV = 20861;
    private const int PI_Q16_180 = 1144;
    private const int PI_Q16_180_INV = 3754936;
    public const int ONE_FIXED = 65536;
    public const int HALF_FIXED = 32768;
    public const int PI = 205887;
    public const int PI_2 = 102944;
    public const int PI_3 = 68629;
    public const int PI_4 = 51472;
    public const int PI_6 = 34315;
    public const int PI_8 = 25736;
    public const int PI_16 = 12868;
    public const int DEG_180_FIXED = 11796480;
    public const int DEG_360_FIXED = 23592960;
    public const short ONE_FIXED_2_14 = 16384;
    public const float FIXED_TO_FLOAT = 1.525879E-05f;
    public const sbyte CLASSIFY_NEGATIVE_SIDE = -1;
    public const sbyte CLASSIFY_INTERSECTION = 0;
    public const sbyte CLASSIFY_POSITIVE_SIDE = 1;
    private const int FSQRT_NUM_PRECALCED = 48;
    private const int FSQRT_LOWER_SCALE_LIMIT = 1755;
    private const int FSQRT_UPPER_SCALE_LIMIT = 4194304;

    public static int sign(int n)
    {
        if (n > 0)
            return 1;
        return n >= 0 ? 0 : -1;
    }

    public static int power(int @base, int n)
    {
        int num = 1;
        for (int index = 1; index <= n; ++index)
            num *= @base;
        return num;
    }

    public static int Fpow(int fixedBase, int intExp)
    {
        int a = 65536;
        for (int index = 1; index <= intExp; ++index)
            a = MathExt.Fmul(a, fixedBase);
        return a;
    }

    public static int clip(int value, int lower, int higher)
    {
        return midp.JMath.max(lower, midp.JMath.min(higher, value));
    }

    public static float clip(float value, float lower, float higher)
    {
        return midp.JMath.max(lower, midp.JMath.min(higher, value));
    }

    public static int floatToFixed16(float f)
    {
        return (int)((double)f * 65536.0);
    }

    public static float fixed16ToFloat(int f)
    {
        return (float)f * 1.525879E-05f;
    }

    public static short int16_16ToShort2_14(int x)
    {
        return (short)(x >> 2);
    }

    public static int short2_14ToInt16_16(short x)
    {
        if (x == (short)16383)
            return 65536;
        return x <= (short)-16383 ? -65536 : (int)x << 2;
    }

    public static int Fmul(int a, int b)
    {
        return (int)((long)a * (long)b >> 16);
    }

    public static int FmulLSL1(int a, int b)
    {
        return (int)((long)a * (long)b >> 15);
    }

    public static int FmulASR8(int a, int b)
    {
        return (int)((long)a * (long)b >> 24);
    }

    public static int FmulASR10(int a, int b)
    {
        return (int)((long)a * (long)b >> 26);
    }

    public static int FmulASR14(int a, int b)
    {
        return (int)((long)a * (long)b >> 30);
    }

    public static float radiansToDegrees(float radians)
    {
        return 57.29578f * radians;
    }

    public static int Fdiv(int a, int b)
    {
        return (int)(((long)a << 16) / (long)b);
    }

    public static int Fdot2(int[] a, int[] b)
    {
        return (int)((long)a[0] * (long)b[0] + (long)a[1] * (long)b[1] >> 16);
    }

    public static int Fdot3(int[] a, int[] b)
    {
        return (int)((long)a[0] * (long)b[0] + (long)a[1] * (long)b[1] + (long)a[2] * (long)b[2] >> 16);
    }

    public static int Fdot4(int[] a, int[] b)
    {
        return (int)((long)a[0] * (long)b[0] + (long)a[1] * (long)b[1] + (long)a[2] * (long)b[2] + (long)a[3] * (long)b[3] >> 16);
    }

    public static int Fdot4(int[] a, int aoffs, int[] b)
    {
        return (int)((long)a[aoffs] * (long)b[0] + (long)a[1 + aoffs] * (long)b[1] + (long)a[2 + aoffs] * (long)b[2] + (long)a[3 + aoffs] * (long)b[3] >> 16);
    }

    public static int Fdot4(int[] a, int[] b, int boffs)
    {
        return (int)((long)a[0] * (long)b[boffs] + (long)a[1] * (long)b[4 + boffs] + (long)a[2] * (long)b[8 + boffs] + (long)a[3] * (long)b[12 + boffs] >> 16);
    }

    public static int Fdot4(int[] a, int[] b, int boffs, int bstride)
    {
        return (int)((long)a[0] * (long)b[boffs] + (long)a[1] * (long)b[bstride + boffs] + (long)a[2] * (long)b[2 * bstride + boffs] + (long)a[3] * (long)b[3 * bstride + boffs] >> 16);
    }

    public static int Fdot4(int[] a, int aoffs, int[] b, int boffs, int bstride)
    {
        return (int)((long)a[aoffs] * (long)b[boffs] + (long)a[1 + aoffs] * (long)b[bstride + boffs] + (long)a[2 + aoffs] * (long)b[2 * bstride + boffs] + (long)a[3 + aoffs] * (long)b[3 * bstride + boffs] >> 16);
    }

    public static void Fcross3(int[] a, int[] b, int[] vout)
    {
        vout[0] = MathExt.Fmul(a[1], b[2]) - MathExt.Fmul(a[2], b[1]);
        vout[1] = -MathExt.Fmul(a[0], b[2]) + MathExt.Fmul(a[2], b[0]);
        vout[2] = MathExt.Fmul(a[0], b[1]) - MathExt.Fmul(a[1], b[0]);
    }

    public static int Fmag2(int[] a)
    {
        return MathExt.Fsqrt(MathExt.Fmag2Sqr(a));
    }

    public static int Fmag2Sqr(int[] a)
    {
        return MathExt.Fmag2Sqr(a[0], a[1]);
    }

    public static int Fmag2Sqr(int x, int y)
    {
        return (int)((long)x * (long)x + (long)y * (long)y >> 16);
    }

    public static int Fmag2(int x, int y)
    {
        return MathExt.Fsqrt(MathExt.Fmag2Sqr(x, y));
    }

    public static int Fmag3(int x, int y, int z)
    {
        return MathExt.Fsqrt(MathExt.Fmag3Sqr(x, y, z));
    }

    public static int Fmag3(int[] a)
    {
        return MathExt.Fsqrt(MathExt.Fmag3Sqr(a));
    }

    public static int Fmag3Sqr(int[] a)
    {
        return MathExt.Fmag3Sqr(a[0], a[1], a[2]);
    }

    public static int Fmag3Sqr(int x, int y, int z)
    {
        long num1 = (long)x;
        long num2 = (long)y;
        long num3 = (long)z;
        return (int)(num1 * num1 + num2 * num2 + num3 * num3 >> 16);
    }

    public static int Fmag4Sqr(int[] a)
    {
        throw new MissingMethodException();
    }

    public static int mag2Sqr(int x, int y)
    {
        return x * x + y * y;
    }

    public static float mag2(float x, float y)
    {
        return (float)System.Math.Sqrt((double)x * (double)x + (double)y * (double)y);
    }

    public static float degreesToRadians(float degrees)
    {
        return 0.0174533f * degrees;
    }

    public static int degreesToRadiansF(int degreesF)
    {
        return MathExt.Fmul(degreesF, 1144);
    }

    public static int radiansToDegreesF(int radiansF)
    {
        return MathExt.Fmul(radiansF, 3754936);
    }

    public static int normaliseAngleRadiansF(int radiansF)
    {
        if ((double)radiansF > 3.14159274101257)
            radiansF -= midp.JMath.max(1, radiansF / 6) * 6;
        else if ((double)radiansF < -3.14159274101257)
            radiansF += midp.JMath.max(1, -radiansF / 6) * 6;
        return radiansF;
    }

    public static int normaliseAngleDegreesF(int degreesF)
    {
        if (degreesF > 11796480)
            degreesF -= midp.JMath.max(1, degreesF / 23592960) * 23592960;
        else if (degreesF < -11796480)
            degreesF += midp.JMath.max(1, -degreesF / 23592960) * 23592960;
        return degreesF;
    }

    public static int getDiffBetweenAnglesF(int angle1, int angle2)
    {
        return MathExt.normaliseAngleRadiansF(angle2 - angle1);
    }

    public static int getDiffBetweenAnglesDegF(int angle1, int angle2)
    {
        return MathExt.normaliseAngleDegreesF(angle2 - angle1);
    }

    public static int Fcos(int radiansF)
    {
        int num1 = MathExt.Fmul((radiansF >= 0 ? 1 : -1) * radiansF << 1, 20861) & 262143;
        int num2 = num1 >> 16 & 3;
        int a1 = num1 & (int)ushort.MaxValue;
        int num3 = 1;
        if ((num2 & 1) != 0)
        {
            num3 = -num3;
            a1 = 65536 - a1;
        }
        if ((num2 & 2) != 0)
            num3 = -num3;
        int num4 = MathExt.Fmul(a1, 205887) >> 1;
        int num5 = 262144;
        int a2 = MathExt.Fmul(num4, num4);
        int b1 = a2 << 1;
        int num6 = num5 - b1;
        int b2 = MathExt.Fmul(MathExt.Fmul(a2, b1), 5461);
        int num7 = num6 + b2;
        int b3 = MathExt.Fmul(MathExt.Fmul(a2, b2), 2185);
        return (num7 - b3 + MathExt.Fmul(MathExt.Fmul(a2, b3), 1170)) * num3 >> 2;
    }

    public static int Facos(int lengthF)
    {
        if (lengthF <= -65536)
            return 205887;
        if ((int)ushort.MaxValue + lengthF < 5)
            return MathExt.Facos_neg_percalc[(int)ushort.MaxValue + lengthF];
        if (lengthF >= 65536)
            return 0;
        if ((int)ushort.MaxValue - lengthF < 5)
            return MathExt.Facos_pos_percalc[(int)ushort.MaxValue - lengthF];
        long num1 = (long)lengthF * (long)lengthF;
        if (lengthF > 46661)
            return 102944 - MathExt.Facos(MathExt.Fsqrt((int)(4294967296L - num1 + 32768L >> 16)));
        if (lengthF < -46661)
            return 102944 + MathExt.Facos(MathExt.Fsqrt((int)(4294967296L - num1 + 32768L >> 16)));
        int b = (int)(num1 + 32768L >> 16);
        int a = lengthF;
        int num2 = -a;
        int num3 = MathExt.Fmul(a, b);
        int num4 = num2 - MathExt.Fmul(10923, num3);
        int num5 = MathExt.Fmul(num3, b);
        return 102944 + (num4 - MathExt.Fmul(4915, num5) - MathExt.Fmul(2926, MathExt.Fmul(num5, b)));
    }

    public static int Fsin(int radiansF)
    {
        return MathExt.Fcos(radiansF - 102944);
    }

    public static int Fasin(int lengthF)
    {
        if (lengthF <= -65536)
            return -102944;
        if (lengthF >= 65536)
            return 102944;
        long num1 = (long)lengthF * (long)lengthF;
        if (lengthF > 46720)
            return MathExt.Facos(MathExt.Fsqrt((int)(4294967296L - num1 >> 16)));
        if (lengthF < -46720)
            return -MathExt.Facos(MathExt.Fsqrt((int)(4294967296L - num1 >> 16)));
        int b = (int)(num1 >> 16);
        int num2 = 0;
        int a = lengthF;
        int num3 = num2 + a;
        int num4 = MathExt.Fmul(a, b);
        int num5 = num3 + MathExt.Fmul(10923, num4);
        int num6 = MathExt.Fmul(num4, b);
        return num5 + MathExt.Fmul(4915, num6) + MathExt.Fmul(2926, MathExt.Fmul(num6, b));
    }

    public static int Ftan(int radiansF)
    {
        return MathExt.Fdiv(MathExt.Fsin(radiansF), MathExt.Fcos(radiansF));
    }

    public static int Fatan2(int lengthY, int lengthX)
    {
        if (lengthY == 0)
            return lengthX < 0 ? 205887 : 0;
        if (lengthX == 0)
            return lengthY < 0 ? -102944 : 102944;
        int b = MathExt.Fmag2(lengthY, lengthX);
        int a = lengthX < 0 ? -lengthX : lengthX;
        int num = MathExt.Facos(b > 0 ? MathExt.Fdiv(a, b) : a);
        if (lengthY < 0 && lengthX < 0)
            num -= 205887;
        else if (lengthY < 0 && lengthX > 0)
            num = -num;
        else if (lengthY > 0 && lengthX < 0)
            num = 205887 - num;
        return num;
    }



    public static int Fsqrt(int _x)
    {
        if (_x < 0)
            return 0;
        if (_x < 48)
            return MathExt.Fsqrt_smallest_precalced[_x];
        int num1 = _x;
        if (_x < 1755)
            num1 <<= 2;
        else if (_x > 4194304)
            num1 >>= 2;
        int num2;
        if (num1 > 65200 && num1 < 65800)
        {
            num2 = num1 + 65536 >> 1;
        }
        else
        {
            int num3 = (num1 >> 3) + 131072;
            if (num3 > 8388608)
                num3 = 8388608;
            int num4 = 1755;
            num2 = num3 + num4 >> 1;
            for (int index = 0; index < 13; ++index)
            {
                if (MathExt.Fmul(num2, num2) > num1)
                    num3 = num2;
                else
                    num4 = num2;
                num2 = num3 + num4 >> 1;
            }
        }
        if (_x < 1755)
            num2 >>= 1;
        else if (_x > 4194304)
            num2 <<= 1;
        return num2;
    }

    public static void normalise2(int[] vec)
    {
        int b1 = MathExt.Fmag2(vec);
        int b2 = 0;
        if (b1 > 0)
            b2 = MathExt.Fdiv(65536, b1);
        vec[0] = MathExt.Fmul(vec[0], b2);
        vec[1] = MathExt.Fmul(vec[1], b2);
        if (vec[0] == 0 && midp.JMath.abs(vec[1]) != 65536)
        {
            vec[1] = vec[1] < 0 ? -65536 : 65536;
        }
        else
        {
            if (vec[1] != 0 || midp.JMath.abs(vec[0]) == 65536)
                return;
            vec[0] = vec[0] < 0 ? -65536 : 65536;
        }
    }

    public static void normalise3(int[] vec)
    {
        int b1 = MathExt.Fmag3(vec);
        int b2 = 0;
        if (b1 > 0)
            b2 = MathExt.Fdiv(65536, b1);
        vec[0] = MathExt.Fmul(vec[0], b2);
        vec[1] = MathExt.Fmul(vec[1], b2);
        vec[2] = MathExt.Fmul(vec[2], b2);
        if (vec[0] == 0 && vec[1] == 0 && midp.JMath.abs(vec[2]) != 65536)
            vec[2] = vec[2] < 0 ? -65536 : 65536;
        else if (vec[0] == 0 && vec[2] == 0 && midp.JMath.abs(vec[1]) != 65536)
        {
            vec[1] = vec[1] < 0 ? -65536 : 65536;
        }
        else
        {
            if (vec[1] != 0 || vec[2] != 0 || midp.JMath.abs(vec[0]) == 65536)
                return;
            vec[0] = vec[0] < 0 ? -65536 : 65536;
        }
    }

    public static void getUnitVec2DFixed(int[] inVec, int[] outVec)
    {
        int b1 = MathExt.Fmag2(inVec);
        int b2 = 0;
        if (b1 > 0)
            b2 = MathExt.Fdiv(65536, b1);
        outVec[0] = MathExt.Fmul(inVec[0], b2);
        outVec[1] = MathExt.Fmul(inVec[1], b2);
    }

    public static void getUnitVec2DFixed(int[] inVec, int[] outVec, int mag)
    {
        int b = MathExt.Fdiv(65536, mag);
        outVec[0] = MathExt.Fmul(inVec[0], b);
        outVec[1] = MathExt.Fmul(inVec[1], b);
    }

    public static void getUnitVec3DFixed(int[] inVec, int[] outVec)
    {
        int b1 = MathExt.Fmag3(inVec);
        int b2 = 0;
        if (b1 > 0)
            b2 = MathExt.Fdiv(65536, b1);
        outVec[0] = MathExt.Fmul(inVec[0], b2);
        outVec[1] = MathExt.Fmul(inVec[1], b2);
        outVec[2] = MathExt.Fmul(inVec[2], b2);
    }

    public static void getUnitVec3DFixed(int[] inVec, int[] outVec, int mag)
    {
        int b = MathExt.Fdiv(65536, mag);
        outVec[0] = MathExt.Fmul(inVec[0], b);
        outVec[1] = MathExt.Fmul(inVec[1], b);
        outVec[2] = MathExt.Fmul(inVec[2], b);
    }

    public static int interp(int from, int to, int step)
    {
        if (from > to)
            return midp.JMath.max(to, from - step);
        return from < to ? midp.JMath.min(to, from + step) : from;
    }

    public static int interpFilter(int from, int to, int timeStep, int factorF)
    {
        if (from != to)
        {
            int n = to - from;
            int num = MathExt.Fmul(n * timeStep, factorF);
            if (num == 0)
                num = MathExt.sign(n);
            else if (n > 0 && from + num > to || n < 0 && from + num < to)
                num = n;
            from += num;
        }
        return from;
    }

    public static int interpFilter(float from, float to, int timeStep, float factor)
    {
        if ((double)from != (double)to)
        {
            float num1 = to - from;
            float num2 = num1 * (float)timeStep * factor;
            if ((double)num2 > -1.0 && (double)num2 < 1.0)
                num2 = (float)MathExt.sign((int)num1);
            else if ((double)num1 > 0.0 && (double)from + (double)num2 > (double)to || (double)num1 < 0.0 && (double)from + (double)num2 < (double)to)
                num2 = num1;
            from += num2;
        }
        return (int)from;
    }

    public static int filter(int from, int to, int factorF)
    {
        return MathExt.Fmul(from, factorF) + MathExt.Fmul(to, 65536 - factorF);
    }

    public static int smoothstepF(int min, int max, int t)
    {
        if (t < min)
            return 0;
        if (t >= max)
            return 65536;
        int num = MathExt.Fdiv(t - min, max - min);
        int a = MathExt.Fmul(num, num);
        return -2 * MathExt.Fmul(a, num) + 3 * a;
    }

    public static int parabolicstepF(int min, int max, int t)
    {
        int b = max - min >> 1;
        int num = MathExt.Fdiv(t, b) - 65536;
        return 65536 - MathExt.Fmul(num, num);
    }

    public static int linearstepF(int min, int max, int t)
    {
        if (t < min)
            return 0;
        return t >= max ? 65536 : MathExt.Fdiv(t - min, max - min);
    }

    public static void lerpi(int[] from, int[] to, int[] @out, int interp, int count)
    {
        for (int index = 0; index < count; ++index)
            @out[index] = MathExt.Fmul(from[index], 65536 - interp) + MathExt.Fmul(to[index], interp);
    }

    public static void intToRGB(int[] rgb, int color)
    {
        rgb[0] = (int)(byte)((color & 16711680) >> 16);
        rgb[1] = (int)(byte)((color & 65280) >> 8);
        rgb[2] = (int)(byte)(color & (int)byte.MaxValue);
    }

    public static int RGBtoInt(int[] rgb)
    {
        return (rgb[0] << 16) + (rgb[1] << 8) + rgb[2];
    }

    public static int interpARGB(int from, int to, int factorFromF)
    {
        int b1 = (int)(((long)from & 4278190080L) >> 24) & (int)byte.MaxValue;
        int b2 = (from & 16711680) >> 16;
        int b3 = (from & 65280) >> 8;
        int b4 = from & (int)byte.MaxValue;
        int b5 = (int)(((long)to & 4278190080L) >> 24) & (int)byte.MaxValue;
        int b6 = (to & 16711680) >> 16;
        int b7 = (to & 65280) >> 8;
        int b8 = to & (int)byte.MaxValue;
        int a = 65536 - factorFromF;
        return MathExt.Fmul(factorFromF, b1) + MathExt.Fmul(a, b5) << 24 | MathExt.Fmul(factorFromF, b2) + MathExt.Fmul(a, b6) << 16 | MathExt.Fmul(factorFromF, b3) + MathExt.Fmul(a, b7) << 8 | MathExt.Fmul(factorFromF, b4) + MathExt.Fmul(a, b8);
    }

    private static void intToHSV(int[] hsv, int color)
    {
        hsv[0] = (int)(((long)color & 4294901760L) >> 16);
        hsv[1] = (color & 65280) >> 8;
        hsv[2] = color & (int)byte.MaxValue;
    }

    public static int interpRGB(int from, int to, int factorFromF)
    {
        int a = 65536 - factorFromF;
        int[] rgb1 = new int[3];
        int[] rgb2 = new int[3];
        MathExt.intToRGB(rgb1, from);
        MathExt.intToRGB(rgb2, to);
        for (int index = 0; index < 3; ++index)
            rgb2[index] = MathExt.Fmul(factorFromF, rgb1[index]) + MathExt.Fmul(a, rgb2[index]);
        return MathExt.RGBtoInt(rgb2);
    }

    private static int convertHSVtoRGB(int[] hsvArray)
    {
        int[] rgb = new int[3];
        int num1 = hsvArray[0];
        int hsv1 = hsvArray[1];
        int hsv2 = hsvArray[2];
        if (hsv1 == 0)
        {
            int num2 = hsv2 * (int)byte.MaxValue / 100;
            rgb[0] = num2;
            rgb[1] = num2;
            rgb[2] = num2;
        }
        else
        {
            if (num1 >= 360)
                num1 = 0;
            int num2 = num1 / 60;
            int num3 = num1 - 60 * num2;
            int num4 = hsv2 * (100 - hsv1) * (int)byte.MaxValue / 10000;
            int num5 = hsv2 * (6000 - num3 * hsv1) * (int)byte.MaxValue / 600000;
            int num6 = hsv2 * (6000 - (60 - num3) * hsv1) * (int)byte.MaxValue / 600000;
            int num7 = hsv2 * (int)byte.MaxValue / 100;
            switch (num2)
            {
                case 0:
                    rgb[0] = num7;
                    rgb[1] = num6;
                    rgb[2] = num4;
                    break;
                case 1:
                    rgb[0] = num5;
                    rgb[1] = num7;
                    rgb[2] = num4;
                    break;
                case 2:
                    rgb[0] = num4;
                    rgb[1] = num7;
                    rgb[2] = num6;
                    break;
                case 3:
                    rgb[0] = num4;
                    rgb[1] = num5;
                    rgb[2] = num7;
                    break;
                case 4:
                    rgb[0] = num6;
                    rgb[1] = num4;
                    rgb[2] = num7;
                    break;
                case 5:
                    rgb[0] = num7;
                    rgb[1] = num4;
                    rgb[2] = num5;
                    break;
            }
        }
        return MathExt.RGBtoInt(rgb);
    }

    private static void convertRGBtoHSV(int[] hsvArray, int rgb)
    {
        MathExt.intToRGB(hsvArray, rgb);
        int hsv1 = hsvArray[0];
        int hsv2 = hsvArray[1];
        int hsv3 = hsvArray[2];
        int num1 = midp.JMath.max(midp.JMath.max(hsv1, hsv2), hsv3);
        int num2 = midp.JMath.min(midp.JMath.min(hsv1, hsv2), hsv3);
        if (num1 == num2)
        {
            hsvArray[0] = 0;
            hsvArray[1] = 0;
            hsvArray[2] = num1 * 100 / (int)byte.MaxValue;
        }
        else
        {
            int num3 = num1 - num2;
            int num4;
            if (hsv1 == num1)
            {
                num4 = 60 * (hsv2 - hsv3);
                if (hsv3 > hsv2)
                    num4 += 92160 * num3;
            }
            else
                num4 = hsv2 != num1 ? 60 * (hsv1 - hsv2) + 61440 * num3 : 60 * (hsv3 - hsv1) + 30720 * num3;
            hsvArray[0] = num4 / num3 % 360;
            hsvArray[1] = 100 - 100 * num2 / num1;
            hsvArray[2] = num1 * 100 / (int)byte.MaxValue;
        }
    }

    public static int getVectorYawRad(int x, int y, int z)
    {
        return MathExt.Fatan2(x, z);
    }

    public static int getVectorYawDeg(int x, int y, int z)
    {
        return MathExt.radiansToDegreesF(MathExt.Fatan2(x, z));
    }

    public static int getVectorPitchRad(int x, int y, int z)
    {
        return MathExt.Fatan2(y, MathExt.Fsqrt(MathExt.Fmul(x, x) + MathExt.Fmul(z, z)));
    }

    public static int getVectorPitchDeg(int x, int y, int z)
    {
        return MathExt.radiansToDegreesF(MathExt.Fatan2(y, MathExt.Fsqrt(MathExt.Fmul(x, x) + MathExt.Fmul(z, z))));
    }

    public static void rotate2DVecF(int[] in2DVec, int[] out2DVec, int angleF)
    {
        out2DVec[0] = MathExt.Fmul(MathExt.Fcos(angleF), in2DVec[0]) - MathExt.Fmul(MathExt.Fsin(angleF), in2DVec[1]);
        out2DVec[1] = MathExt.Fmul(MathExt.Fsin(angleF), in2DVec[0]) + MathExt.Fmul(MathExt.Fcos(angleF), in2DVec[1]);
    }

    public static void rotate2DVecF(int inX, int inY, int[] out2DVec, int angleF)
    {
        out2DVec[0] = MathExt.Fmul(MathExt.Fcos(angleF), inX) - MathExt.Fmul(MathExt.Fsin(angleF), inY);
        out2DVec[1] = MathExt.Fmul(MathExt.Fsin(angleF), inX) + MathExt.Fmul(MathExt.Fcos(angleF), inY);
    }

    public static int angleBetweenVectors2D(int[] vecA, int[] vecB)
    {
        return MathExt.Fatan2(vecB[1], vecB[0]) - MathExt.Fatan2(vecA[1], vecA[0]);
    }

    public static int angleBetweenVectors3D(int[] vecA, int[] vecB)
    {
        int a = MathExt.Fdot3(vecA, vecB);
        int b = MathExt.Fsqrt(MathExt.Fmul(MathExt.Fmag3Sqr(vecA), MathExt.Fmag3Sqr(vecB)));
        if (b == 0)
            b = 65536;
        int lengthF = MathExt.Fdiv(a, b);
        return lengthF < 0 ? MathExt.Facos(lengthF) : 205887 - MathExt.Facos(lengthF);
    }

    public static void getLineNormal2DCW(int[] lineDirectionVector, int[] output2DVec)
    {
        output2DVec[0] = -lineDirectionVector[1];
        output2DVec[1] = lineDirectionVector[0];
    }

    public static void getLineNormal2DCCW(int[] lineDirectionVector, int[] output2DVec)
    {
        output2DVec[0] = lineDirectionVector[1];
        output2DVec[1] = -lineDirectionVector[0];
    }

    public static int pointLineDistance2D(int[] point, int[] lineEndpoints)
    {
        int[] vecB = new int[2]
        {
      lineEndpoints[2] - lineEndpoints[0],
      lineEndpoints[3] - lineEndpoints[1]
        };
        int[] numArray = new int[2]
        {
      point[0] - lineEndpoints[0],
      point[1] - lineEndpoints[1]
        };
        int radiansF = MathExt.angleBetweenVectors2D(numArray, vecB);
        return MathExt.Fmul(MathExt.Fmag2(numArray), MathExt.Fsin(radiansF));
    }

    public static sbyte classifyPointsWRTLine(int[][] points, int[] lineNormal, int[] pointOnLine)
    {
        int num1 = 0;
        int num2 = 0;
        for (int index = 0; index < points.Length; ++index)
        {
            int num3 = MathExt.classifyPointWRTLine(points[index][0], points[index][2], lineNormal, pointOnLine);
            if (num3 > 0)
                ++num1;
            else if (num3 < 0)
                ++num2;
            if (num1 > 0 && num2 > 0)
                return 0;
        }
        return num1 <= 0 ? (sbyte)-1 : (sbyte)1;
    }

    public static int classifyPointWRTLine(int x, int z, int[] lineNormal, int[] pointOnLine)
    {
        int[] b = new int[2]
        {
      x - pointOnLine[0],
      z - pointOnLine[1]
        };
        return MathExt.Fdot2(lineNormal, b);
    }

    public static int minMaxFactorF(int minF, int maxF, int factorF)
    {
        return minF + MathExt.Fmul(maxF - minF, factorF);
    }

    public static float normaliseAngleDegrees(float degrees)
    {
        if ((double)degrees > 180.0)
            degrees -= (float)midp.JMath.max(1, (int)((double)degrees / 360.0)) * 360f;
        else if ((double)degrees < -180.0)
            degrees += (float)midp.JMath.max(1, (int)(-(double)degrees / 360.0)) * 360f;
        return degrees;
    }

    public static float normaliseAngleRadians(float radians)
    {
        float num = 6.283185f;
        if ((double)radians > 3.14159274101257)
            radians -= (float)midp.JMath.max(1, (int)((double)radians / (double)num)) * num;
        else if ((double)radians < -3.14159274101257)
            radians += (float)midp.JMath.max(1, (int)(-(double)radians / (double)num)) * num;
        return radians;
    }

    public static float smoothstep(float min, float max, float t)
    {
        if ((double)t < (double)min)
            return 0.0f;
        if ((double)t >= (double)max)
            return 1f;
        float num1 = (t - min) / (max - min);
        float num2 = num1 * num1;
        return (float)(-2.0 * (double)num2 * (double)num1 + 3.0 * (double)num2);
    }

    public static float parabolicstep(float t)
    {
        float num = (float)(((double)t - 1.0) * 0.5);
        return 1f - num * num;
    }

    public static float parabolicstep(float min, float max, float t)
    {
        float num1 = max - min;
        float num2 = (float)((double)t / (double)num1 - 1.0);
        return 1f - num2 * num2;
    }
}
