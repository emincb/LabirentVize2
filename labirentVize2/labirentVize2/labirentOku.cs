using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace labirentVize2
{
    class labirentOku
    {

        public string labirentOkuyucu()
        {
            String input1 = File.ReadAllText("C:\\Users\\eminb\\Desktop\\labirent.txt");


            string output = input1.Replace("{", "");
            string output1 = output.Replace("}", "");
            
            diziCevir(output1);
            

            return output1;
        }

        public int[,] diziCevir(string output1)
        {
            string original = output1;
            original = output1.Trim();
            string[] sarr;
            sarr = original.Split(',');

            int[,] element = new int[30, 30];
            int i, j;
            for (i = 0; i < 30; i++)
            {
                for (j = 0; j < 30; j++)
                {   
                    element[i, j] = Convert.ToInt32(sarr[i *30+ j]);
                    //Console.Write(element[i,j]);

                 }  // Console.Write(Environment.NewLine);   
            }bombaGoster(element);
            return element;

        }
        public void bombaGoster(int[,]element)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (element[i, j] == 8)
                    {
                        
                        Console.Write('B');
                    }
                    else { Console.Write('0'); }
                }   Console.Write(Environment.NewLine);   
            }

        }
    }
}
