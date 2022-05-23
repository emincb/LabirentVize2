using System;
using System.Collections.Generic;
using System.Text;

namespace labirentVize2
{
    class labirentCoz
    {// Labirentin boyutu
        static int N = 30;

        // Çözüm matrixini yazdırmak için 
        // bir fonksiyon
        void cozumGoster(int[,] coz)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(" " + coz[i, j] + " ");

                Console.WriteLine();
            }
        }

        // x ve y nin matrix içindeki 
        // N*N matrisin içindeki sınırlarında tutmak için test
        bool sinirdaMi(int[,] maze, int x, int y)
        {

            // Eğer x,y labirentin dışındaysa false döndür
            return (x >= 0 && x < N && y >= 0 &&
                    y < N && maze[x, y] == 1);
        }

        // Bu fonksiyon backtracking yöntemi yardımıyla 
        // matrisi çözer. 
       
        public bool labCoz(int[,] maze)
        {
            int[,] coz = new int[N, N];
            int z = 0;
            if (labCozucu(maze, 0, z, coz) == false)
            {
                for (z = 0; z < 30; z++)
                {
                    labCozucu(maze, 0, z, coz);
                    
                }
               

            }

            cozumGoster(coz);
            return true;
        }

        // İç içe kendini çağıran (recursive)
        // yöntem ile matrisi çözme
        bool labCozucu(int[,] maze, int x, int y,
                           int[,] coz)
        {

            // Eğer x,y hedef
           /* if (x == N - 1 && y == N - 1)
            {
                coz[x, y] = 1;
                return true;
            }*/

            // Labirent sınırlarını kontrol et
            if (sinirdaMi(maze, x, y) == true)
            {
                // Şuanki nokta çözüme dahil mi değil mi kontrol et  
                if (coz[x, y] == 1)
                                         
                    return false;
                
                //x,y yi çözüm adımı olarak işaretle
                coz[x, y] = 1;

                // x yönünde hareket et
                if (labCozucu(maze, x + 1, y, coz))
                {
                    Console.WriteLine(x + 1 + ',' + y);
                    return true;
                }

                // eğer x yönünde gitmek çözümü vermezse
                // y yönünde ileri git
                if (labCozucu(maze, x, y + 1, coz))
                {
                    Console.WriteLine(x + ',' + y + 1);
                    return true;
                }

                // y yönünde gitmek çözümü vermezse
                // x yönünde geri git
                if (labCozucu(maze, x - 1, y, coz))
                {
                    Console.WriteLine(x - 1 + ',' + y);
                    return true;
                }

                // eğer x yönünde geri gitmek çözüm vermezse
                // y yönünde yukarı git 
                if (labCozucu(maze, x, y - 1, coz))
                {
                    Console.WriteLine(x + ',' + y - 1);
                    return true;
                }

                // eğer bu yukarıdakilerin hiçbiri çözüm vermezse
                // x,y yi çözüm yolu işaretini kaldır
                // 
                coz[x, y] = 0;
                return false;
            }
            return false;
        }

       
        
        
            
        
    }
}
