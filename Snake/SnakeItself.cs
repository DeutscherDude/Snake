using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class SnakeItself
    {
        private int x;
        private int y;
        public int Length { get; set; }

        public SnakeItself(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Rectangle GetCurrentPos()
        {
            return new Rectangle(x, y, 32, 32);
        }

        public void Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    y -= 32;
                    break;    
                case Direction.Down:
                    y += 32;
                    break;
                case Direction.Left:
                    x -= 32;
                    break;
                case Direction.Right:
                    x += 32;
                    break;

            }
        }
    }
}
