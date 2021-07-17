using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class SnakeItself : ISnake
    {
        private int initX;
        private int initY;

        public SnakeItself()
        {
            this.initX = 2;
            this.initY = 3;
        }

        public bool isSnake { get; set; }

        public Color TileColor { get; set; }

        public void ChangeColor(ColorSet color)
        {
            TileColor = Color.Green;
        }
    }
}
