using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Tile : ISnake
    {
        private int x;
        private int y;
        private int width;
        private int height;

        public Color TileColor { get; set; }
        public bool isSnake { get; set; }

        public Tile(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public Rectangle getTile()
        {
            return new Rectangle(x, y, width, height);
        }

        public void ChangeColor(ColorSet color)
        {
            switch(color)
            {
                case ColorSet.Snake:
                    TileColor = Color.Green;
                    break;
                case ColorSet.Field:
                    TileColor = Color.Gray;
                    break;
                case ColorSet.Apple:
                    TileColor = Color.Tomato;
                    break;
            }
        }
    }
}
