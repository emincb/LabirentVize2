using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace labirentVize2
{
    class labirentCoz
    {// Labirentin boyutu
        static int N = 30;
        
        static int w = 1;
        
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
        bool sinirdaMi(int[,] maze, int x, int y, string p)
        {

            // Eğer x,y labirentin dışındaysa false
            return (x >= 0 && x < N && y >= 0 &&
                    y < N && maze[x, y] == 1);
        }

        // Bu fonksiyon backtracking yöntemi yardımıyla 
        // matrisi çözer. 

        public bool labCoz(int[,] maze, string p)
        {
            int[,] coz = new int[N, N];
            int z = 0;
            while ((maze[28, w] == 0 || (maze[29, w - 1] == 0 && maze[29, w + 1] == 0 && w < 29))||maze[29,w]==0)
            {
                w++;//manuel çıkış belirleme yapmak için bu döngüyü comment'e alıp w yi [29,w] şeklinde istediğiniz çıkışı seçebilirsiniz.
            }
            

            if (labCozucu(maze, 0, z, coz, w, z,p) == false)
            {
                if (z < 30)
                {
                     z++;
                   // z = 14; //manuel giriş belirleme
                    labCozucu(maze, 0, z, coz, w, z,p);//recursive maze solving function

                }
            }
            
            cozumGoster(coz);//
            

            return true;

         }

        // İç içe kendini çağıran (recursive)
        // yöntem ile matrisi çözme
        bool labCozucu(int[,] maze, int x, int y,
                           int[,] coz, int w,int z,string p)
        {

            if (maze[x, y] == 8)
            {
                Console.WriteLine("Bombanin uzerinden gecilmeye calisildi.");
                Thread.Sleep(1000);
                Console.Beep();

                cozumGoster(coz);
                Thread.Sleep(1000);
            }
            if (x == 29 )
            {
                coz[x, y] = 1;
                 Console.WriteLine("{0} , {1} Bu satıra kadar olan x,y koordinatları çıkmaz yolları , sonrası ise çözüm yolunu gösterir.",x,y) ;
                
                return true;
            }



            // Labirent sınırlarını kontrol et
            if (sinirdaMi(maze, x, y, p) == true)
                {
                    // Şuanki nokta çözüme dahil mi değil mi kontrol et  
                    if (coz[x, y] == 1)  {
                    Console.WriteLine("{0} , {1}", x, y);

                    return false;

                    }


                    //x,y yi çözüm adımı olarak işaretle
                    coz[x, y] = 1;

                // eğer x yönünde gitmek çözümü vermezse
                // y yönünde ileri git
                if (labCozucu(maze, x, y + 1, coz, w, z,p))
                {
                    Console.WriteLine("{0} , {1} ", x, y+1);
                    return true;
                }

                // x yönünde hareket et
                if (labCozucu(maze, x + 1, y, coz, w,z,p))
                    {if(x==29)
                    {
                        return false;
                    }
                    else {
                        Console.WriteLine("{0} , {1}", x+1, y);
                        return true;
                    }
                    
                    }
                    
                    // y yönünde gitmek çözümü vermezse
                    // x yönünde geri git
                    if (labCozucu(maze, x - 1, y, coz, w,z,p))
                    {
                    Console.WriteLine("{0} , {1}", x-1, y);
                    return true;
                    }

                    // eğer x yönünde geri gitmek çözüm vermezse
                    // y yönünde yukarı git 
                    if (labCozucu(maze, x, y - 1, coz, w,z,p)) 
                    {
                    Console.WriteLine("{0} , {1}", x, y-1);
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

