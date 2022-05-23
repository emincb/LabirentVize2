using System;
using System.Collections.Generic;
using System.Text;

namespace labirentVize2
{
    public class MazeCell
    {
        public int x;
        public int y;
        public bool passage = false;
        MazeCell parent;

        public MazeCell(int x, int y, MazeCell parent)
        {
            this.x = x;
            this.y = y;
            this.parent = parent;
        }

        public MazeCell opposite()
        {
            if (x.CompareTo(parent.x) != 0)
                return new MazeCell(x + x.CompareTo(parent.x), y, this);
            if (y.CompareTo(parent.y) != 0)
                return new MazeCell(x, y + y.CompareTo(parent.y), this);
            return null;
        }
    }
}
