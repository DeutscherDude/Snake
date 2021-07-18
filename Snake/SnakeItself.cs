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
        private int _width;
        private int _height;

        public SnakeItself(int x, int y)
        {
            this.x = (x / 2) - 32;
            this.y = (y / 2) - 32;
            this.Length = 0;
            _width = x;
            _height = y;
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
                    if (y == -32)
                        Teleport(Direction.Up);
                    break;    
                case Direction.Down:
                    y += 32;
                    if (y == _height)
                        Teleport(Direction.Down);
                    break;
                case Direction.Left:
                    x -= 32;
                    if (x == -32)
                        Teleport(Direction.Left);
                    break;
                case Direction.Right:
                    x += 32;
                    if (x == _width)
                        Teleport(Direction.Right);
                    break;
            }
        }
        private void Teleport(Direction wall)
        {
            switch(wall)
            {
                case Direction.Up:
                    y = _height - 32;
                    break;
                case Direction.Down:
                    y = 0;
                    break;
                case Direction.Left:
                    x = _width - 32;
                    break;
                case Direction.Right:
                    x = 0;
                    break;
            }
        }

    }
}
