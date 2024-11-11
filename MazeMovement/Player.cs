using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeMovement
{
    internal class Player
    {
        // Public properties for the player's position and size with default values
        public int PositionX { get; set; } = 32;
            public int PositionY { get; set; } = 32;
            public int SizeWidth { get; set; } = 20;

            public int SizeHeight { get; set; } = 20;
            public Image PlayerImage { get; set; }
        
    }
}
