using System;
using System.IO;
namespace labirentVize2
{
    class Program
    {
        public static int N = 30;

         static void Main(string[] args)
        {   
            int[,] uret = new int[N, N];
            labirentCoz oyuncu = new labirentCoz();
            labirentOku labirent = new labirentOku();

            var maze = new Maze(10, 10);
            string a = "";
            string p = "";
            maze.Display(a);
            labirentOku aa = new labirentOku();
            string x = aa.labirentOkuyucu();
            uret = aa.diziCevir(x);
            Console.Clear();
            Console.WriteLine("Bir seçenek seçin :");
            Console.WriteLine("L) Orijinal labirenti göster");
            Console.WriteLine("X) Labirent üret ve çöz.");
            Console.WriteLine("B) Bombaları göster.");
            Console.Write("\r\nBir seçenek seçin: ");
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu(x,uret,p,oyuncu,aa);
            }
        }
        private static bool MainMenu(string x,int[,]uret,string p,labirentCoz oyuncu,labirentOku aa)
        {
            switch (Console.ReadLine())
            {
                case "L":
                    Console.Write(x);
                    return true;
                case "X":
                    oyuncu.labCoz(uret, p);
                    return true;
                case "B":
                   aa.labirentOkuyucu();


                    return true;
                default:
                    return true;
            }
        }

        }
    }

