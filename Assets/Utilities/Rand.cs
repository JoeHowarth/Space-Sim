using UnityEngine;
using System;

public class Rand {
    public static System.Random r;
    double nextNextGaussian;
    bool haveNextNextGaussian = false;

    public Rand ()
    {
        r = new System.Random ();
    }

    public static bool Bool (double p = 0.5)
    {
        if (r.NextDouble () > p) return true;
        else return false;
    }

    public static float PowerRange (float minExp, float maxExp, float b = 10)
    {
        float exp = Range (minExp, maxExp);
        return (float)Math.Pow (b, exp);

    }

    public static float Range (float min, float max)
    {
        return UnityEngine.Random.Range (min, max);
    }

    public double NormalD (float mu, float std)
    {

        if (haveNextNextGaussian) {
            haveNextNextGaussian = false;
            return nextNextGaussian;
        } else {
            double v1, v2, s;
            do {
                v1 = 2 * r.NextDouble () - 1;   // between -1.0 and 1.0
                v2 = 2 * r.NextDouble () - 1;   // between -1.0 and 1.0
                s = v1 * v1 + v2 * v2;
            } while (s >= 1 || s == 0);
            double multiplier = Math.Sqrt (-2 * Math.Log (s) / s);
            nextNextGaussian = v2 * multiplier;
            haveNextNextGaussian = true;
            return v1 * multiplier;
        }
    }


    public float Normal (float mu, float std)
    {
        return (float)NormalD (mu, std);
    }


}


