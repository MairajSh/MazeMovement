using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace MazeMovement
{
    class Node
    {
        public Point Position { get; }

        // Constructor for initializing a node with a position
        public Node(int x, int y)
        {
            Position = new Point(x, y);
        }
    }
}
