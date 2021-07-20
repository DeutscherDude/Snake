using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class Collision
    {
        public static bool CheckAppleCollision(Tile tile, Rectangle rect)
        {
            if(tile.isApple)
            {
                if (tile.getTile() == rect)
                {
                    MessageConsole.LogMessage("XD");
                    tile.isApple = false;
                    return true;
                }
            }
            return false;
        }
        public static bool CheckSnakeCollision(Tile tile)
        {
          
            if(tile.isHead && tile.isSnake)
            {
                return true;
            }
            return false;
        }
    }
}
