using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace labirentVize2
{
    public class Maze
    {
        
        private readonly HucreDurumu[,] hucreler;
        private readonly int genislik;
        private readonly int yukseklik;
        private readonly Random rastgele;

        public Maze(int width, int height)
        {
            genislik = width;
            yukseklik = height;
            hucreler = new HucreDurumu[width, height];
            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                    hucreler[x, y] = HucreDurumu.Baslangic;
            rastgele = new Random();
            HucreyeGit(rastgele.Next(width), rastgele.Next(height));
        }

        public HucreDurumu this[int x, int y]
        {
            get { return hucreler[x, y]; }
            set { hucreler[x, y] = value; }
        }

        public IEnumerable<DuvarKaldirici> KomsuAl(Point p)
        {
            if (p.X > 0) yield return new DuvarKaldirici { Komsu = new Point(p.X - 1, p.Y), Duvar = HucreDurumu.Sol };
            if (p.Y > 0) yield return new DuvarKaldirici { Komsu = new Point(p.X, p.Y - 1), Duvar = HucreDurumu.Ust };
            if (p.X < genislik - 1) yield return new DuvarKaldirici { Komsu = new Point(p.X + 1, p.Y), Duvar = HucreDurumu.Sag };
            if (p.Y < yukseklik - 1) yield return new DuvarKaldirici { Komsu = new Point(p.X, p.Y + 1), Duvar = HucreDurumu.Alt };
        }

        public void HucreyeGit(int x, int y)
        {
            this[x, y] |= HucreDurumu.Gidildi;
            foreach (var p in KomsuAl(new Point(x, y)).Shuffle(rastgele).Where(z => !(this[z.Komsu.X, z.Komsu.Y].HasFlag(HucreDurumu.Gidildi))))
            {
                this[x, y] -= p.Duvar;
                this[p.Komsu.X, p.Komsu.Y] -= p.Duvar.ZitDuvar();
                HucreyeGit(p.Komsu.X, p.Komsu.Y);
            }
        }

        public void Display(string a)
        {
            int[,] uret = new int[30, 30];
            var firstLine = string.Empty;
            for (var y = 0; y < yukseklik; y++)
            {
                var sbTop = new StringBuilder();
                var sbMid = new StringBuilder();
                for (var x = 0; x < genislik; x++)
                {
                    if (x == 6 )
                    {
                        sbTop.Append(this[x, y].HasFlag(HucreDurumu.Ust) ? "00" : "11");
                        sbMid.Append(this[x, y].HasFlag(HucreDurumu.Sol) ? "01" : "11");
                    }

                    else
                    {
                        sbTop.Append(this[x, y].HasFlag(HucreDurumu.Ust) ? "010" : "011");
                        
                        sbMid.Append(this[x, y].HasFlag(HucreDurumu.Sol) ? "011" : "111");
                    }
                   
                }
                if (firstLine == string.Empty)
                    firstLine = sbTop.ToString();
               // Console.WriteLine(sbTop + "0");
               // Console.WriteLine(sbMid + "0");
                //Console.WriteLine(sbMid + "0");
                 
                a += (sbTop + "0" +  sbMid + "0"+  sbMid + "0").ToString();
                
                
                

            }
                
                //Console.WriteLine(a);
                char[] karakterDizisi = a.ToCharArray();
            //Console.Write(karakterDizisi);                         
            var twoDArray = Make2DArray(karakterDizisi, 30, 30);
            Random rand = new Random();
            int g = rand.Next(1, 30);
            int h = rand.Next(1, 30);
            int g1 = rand.Next(1, 30);
            int h1 = rand.Next(1, 30);
            int g2 = rand.Next(1, 30);
            int h2 = rand.Next(1, 30);
            twoDArray[g, h] = '8';
            twoDArray[g1, h1] = '8';
            twoDArray[g2, h2] = '8';
            string e = "{";
               
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 30; j++)
                    {
                    if (j == 0) { e+='{';}
                    e +=   twoDArray[i, j].ToString() + ',';
                    
                    }
                 e += '}'+Environment.NewLine;
                
                    
                }e += '}';

            string fileName = @"C:\\Users\\eminb\\Desktop\\labirent.txt";
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write)) {
                fs.Close();
                File.AppendAllText(fileName, e);

                
            }
            

        }
        private static T[,] Make2DArray<T>(T[] input, int height, int width)
        {
            T[,] output = new T[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    output[i, j] = input[i * width + j];
                    
                    
                    //Console.Write(output[i, j]);
                    
                }
               // Console.Write(System.Environment.NewLine);
            }
            return output;
        }
            
    }

}





