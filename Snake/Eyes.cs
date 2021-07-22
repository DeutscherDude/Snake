using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Snake
{
    public static class Eyes
    {
        private static bool eyesUtil(Tile tile)
        {
            if(tile.isHead)
            {
                tile.hasEyes = false;
                return true;
            }
            else
            {
                tile.hasEyes = false;
                return false;
            }
        }

        public static void getEyesPos(Graphics g, Tile tile, Direction direction)
        {
            SolidBrush white = new SolidBrush(Color.White);
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            if (eyesUtil(tile))
            {
                var tileRect = tile.getTile();

                switch (direction)
                {
                    case Direction.Up:
                        x1 = 5;
                        x2 = 18;
                        y1 = y2 = 9;
                        break;
                    case Direction.Down:
                        x1 = 5;
                        x2 = 18;
                        y1 = y2 = 13;
                        break;
                    case Direction.Left:
                        x1 = x2 = 9;
                        y1 = 5;
                        y2 = 18;
                        break;
                    case Direction.Right:
                        x1 = x2 = 13;
                        y1 = 5;
                        y2 = 18;
                        break;
                }

                g.FillEllipse(white, tileRect.X + x1, tileRect.Y + y1, 9, 9);
                g.FillEllipse(white, tileRect.X + x2, tileRect.Y + y2, 9, 9);
            }
        }
    }
}
