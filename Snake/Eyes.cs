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
                        x1 = 8;
                        y1 = 10;
                        x2 = 19;
                        y2 = 10;
                        break;
                    case Direction.Down:
                        x1 = 8;
                        y1 = 17;
                        x2 = 19;
                        y2 = 17;
                        break;
                    case Direction.Left:
                        x1 = 10;
                        y1 = 8;
                        x2 = 10;
                        y2 = 19;
                        break;
                    case Direction.Right:
                        x1 = 17;
                        y1 = 8;
                        x2 = 17;
                        y2 = 19;
                        break;
                }

                g.FillEllipse(white, tileRect.X + x1, tileRect.Y + y1, 5, 5);
                g.FillEllipse(white, tileRect.X + x2, tileRect.Y + y2, 5, 5);
            }
        }
    }
}
