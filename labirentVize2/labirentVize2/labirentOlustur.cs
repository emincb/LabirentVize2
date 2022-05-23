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
        
        private readonly CellState[,] _cells;
        private readonly int _width;
        private readonly int _height;
        private readonly Random _rng;

        public Maze(int width, int height)
        {
            _width = width;
            _height = height;
            _cells = new CellState[width, height];
            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                    _cells[x, y] = CellState.Initial;
            _rng = new Random();
            VisitCell(_rng.Next(width), _rng.Next(height));
        }

        public CellState this[int x, int y]
        {
            get { return _cells[x, y]; }
            set { _cells[x, y] = value; }
        }

        public IEnumerable<RemoveWallAction> GetNeighbours(Point p)
        {
            if (p.X > 0) yield return new RemoveWallAction { Neighbour = new Point(p.X - 1, p.Y), Wall = CellState.Left };
            if (p.Y > 0) yield return new RemoveWallAction { Neighbour = new Point(p.X, p.Y - 1), Wall = CellState.Top };
            if (p.X < _width - 1) yield return new RemoveWallAction { Neighbour = new Point(p.X + 1, p.Y), Wall = CellState.Right };
            if (p.Y < _height - 1) yield return new RemoveWallAction { Neighbour = new Point(p.X, p.Y + 1), Wall = CellState.Bottom };
        }

        public void VisitCell(int x, int y)
        {
            this[x, y] |= CellState.Visited;
            foreach (var p in GetNeighbours(new Point(x, y)).Shuffle(_rng).Where(z => !(this[z.Neighbour.X, z.Neighbour.Y].HasFlag(CellState.Visited))))
            {
                this[x, y] -= p.Wall;
                this[p.Neighbour.X, p.Neighbour.Y] -= p.Wall.OppositeWall();
                VisitCell(p.Neighbour.X, p.Neighbour.Y);
            }
        }

        public void Display(string a)
        {
            int[,] uret = new int[30, 30];
            var firstLine = string.Empty;
            for (var y = 0; y < _height; y++)
            {
                var sbTop = new StringBuilder();
                var sbMid = new StringBuilder();
                for (var x = 0; x < _width; x++)
                {
                    if (x == 6 )
                    {
                        sbTop.Append(this[x, y].HasFlag(CellState.Top) ? "00" : "11");
                        sbMid.Append(this[x, y].HasFlag(CellState.Left) ? "01" : "11");
                    }

                    else
                    {
                        sbTop.Append(this[x, y].HasFlag(CellState.Top) ? "010" : "011");
                        
                        sbMid.Append(this[x, y].HasFlag(CellState.Left) ? "011" : "111");
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
                    Console.Write(output[i, j]);
                    
                }
                Console.Write(System.Environment.NewLine);
            }
            return output;
        }
            
    }

}





