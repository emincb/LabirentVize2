using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;

namespace labirentVize2
{
    public static class Eklentiler
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> kaynak, Random rastgele)
        {
            var e = kaynak.ToArray();
            for (var i = e.Length - 1; i >= 0; i--)
            {
                var degistirIndex = rastgele.Next(i + 1);
                yield return e[degistirIndex];
                e[degistirIndex] = e[i];
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
