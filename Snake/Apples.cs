using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Apples
    {
        public bool isApple { get; set; }
        public Color TileColor { get; set; }
        private int x, y, width = 32, height = 32;

        public Apples()
        {
            isApple = true;
            var rand = new Random();
            this.x = rand.Next(1, 16) * 32;
            this.y = rand.Next(1, 16) * 32;
        }
    }
}
