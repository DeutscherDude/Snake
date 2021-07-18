using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public static class MovingHandler
    {
        static Direction currentDirection;

        public static Direction GetDirection(Keys pressedKey, Direction lastDirection)
        {
            if ((pressedKey == Keys.Up || pressedKey == Keys.W) && (lastDirection != Direction.Up && lastDirection != Direction.Down))
            {
                currentDirection = Direction.Up;
                MessageConsole.LogMessage($"Changed Direction to {currentDirection}");
            }
            else if ((pressedKey == Keys.Down || pressedKey == Keys.S) && (lastDirection != Direction.Down && lastDirection != Direction.Up))
            {
                currentDirection = Direction.Down;
                MessageConsole.LogMessage($"Changed Direction to {currentDirection}");
            }
            else if ((pressedKey == Keys.Left || pressedKey == Keys.A) && (lastDirection != Direction.Left && lastDirection != Direction.Right))
            {
                currentDirection = Direction.Left;
                MessageConsole.LogMessage($"Changed Direction to {currentDirection}");
            }
            else if ((pressedKey == Keys.Right || pressedKey == Keys.D) && (lastDirection != Direction.Right && lastDirection != Direction.Left))
            {
                currentDirection = Direction.Right;
                MessageConsole.LogMessage($"Changed Direction to {currentDirection}");
            }
            else
            {
                currentDirection = lastDirection;
            }
            return currentDirection;
        }
    }
}
