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
        public int Length;

        public SnakeItself(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.Length = 0;
        }

        public Rectangle GetCurrentPos()
        {
            return new Rectangle(x, y, 32, 32);
        }
        
        public int SnakeLength()
        {
            Length += 1;
            return Length;
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
