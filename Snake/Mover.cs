using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public static class Mover
    {
        private readonly Keys currentMovement;

        public static void GetDirection (Keys pressedKey)
        {
            Direction currentDirection = Direction.Up;

            switch (pressedKey)
            {
                case Keys.Up:
                    currentDirection = Direction.Up;
                    break;
                case Keys.W:
                    currentDirection = Direction.Up;
                    break;
                case Keys.Right:
                    currentDirection = Direction.Right;
                    break;
                case Keys.D:
                    currentDirection = Direction.Right;
                    break;
                case Keys.Down:
                    currentDirection = Direction.Down;
                    break;
                case Keys.S:
                    currentDirection = Direction.Down;
                    break;
                case Keys.A:
                    currentDirection = Direction.Left;
                    break;
                case Keys.Left:
                    currentDirection = Direction.Left;
                    break;
            }
        }
    }
}
