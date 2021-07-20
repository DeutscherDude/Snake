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
        public static CollisonType CheckCollision(Tile tile, Rectangle rect)
        {
            if (tile.getTile() == rect)
            {
                if (tile.isSnake)
                    return CollisonType.Eat;
                else if (tile.isApple)
                    return CollisonType.Death;
            }
            return CollisonType.Field;
        }
    }

    public enum CollisonType
    {
        Eat,
        Death,
        Field,
    }
}
