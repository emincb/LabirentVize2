using System;
using System.IO;
namespace labirentVize2
{
    class Program
    {
        public static int N = 30;

        static void Main(String[] args)
        {   
            int[,] uret = new int[N, N];
            labirentCoz oyuncu = new labirentCoz();
            labirentOku labirent = new labirentOku();

            // labirentOlustur olustur = new labirentOlustur();
          
            //olustur.generateMaze();
            // labirent.labirentOkuyucu();
            //oyuncu.labCoz(maze);
            var maze = new Maze(10, 10);
            string a = "";
            maze.Display(a);
            

        }
    }
}
