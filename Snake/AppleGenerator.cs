using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class AppleGenerator
    {
        public static void Generate(List<Tile> tiles)
        {
            Tile randTile;
            var rand = new Random();
            do
            {
                randTile = tiles[rand.Next(0, 16)];
                
            } while (randTile.isSnake);
            randTile.isApple = true;
        }
    }
}
