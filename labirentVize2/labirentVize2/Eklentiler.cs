using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;

namespace labirentVize2
{
    public static class Extensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            var e = source.ToArray();
            for (var i = e.Length - 1; i >= 0; i--)
            {
                var swapIndex = rng.Next(i + 1);
                yield return e[swapIndex];
                e[swapIndex] = e[i];
            }
        }

        public static HucreDurumu ZitDuvar(this HucreDurumu orig)
        {
            return (HucreDurumu)(((int)orig >> 2) | ((int)orig << 2)) & HucreDurumu.Baslangic;
        }
    }

    [Flags]
    public enum HucreDurumu
    {
        Ust = 1,
        Sag = 2,
        Alt = 4,
        Sol = 8,
        Gidildi = 128,
        Baslangic = Ust | Sag | Alt | Sol,
    }

    public struct DuvarKaldirici
    {
        public Point Komsu;
        public HucreDurumu Duvar;
    }
}
