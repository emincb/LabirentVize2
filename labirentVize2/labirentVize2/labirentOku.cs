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

           
            Console.WriteLine(input1);
            return input1;
        }
        
        /*public Array diziCevir(string input2)
        {
            string original = input2;
            original = input2.Trim();
            string[] sarr;
            sarr = original.Split(',');
             
            int[,] element = new int[30,30];
            int i, j;
            for (i = 0; i < 30; i++)
            {
                for(j = 0; j < 30; j++)
                {
                    element[i, j] = Convert.ToInt32(sarr[i*j]);
                    
                }
            }
            return element; 
        
        } */
    }
}
