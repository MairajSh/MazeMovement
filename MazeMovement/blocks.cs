using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeMovement
{
    internal class block
    {
        public int PositionX { get; set; } = 0;
        public int PositionY { get; set; } = 0;
        public int SizeWidth { get; set; } = 32;

        public int SizeHeight { get; set; } = 32;
        public Image BlockImage { get; set; }
        public string type { get; set; }   
    }
}
