using System.Drawing;

namespace Snake
{
    public static class Eyes
    {
        static SolidBrush white = new SolidBrush(Color.White);
        static SolidBrush black = new SolidBrush(Color.Black);

        public static void drawEyes(Graphics g, Tile tile, Direction direction)
        {
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
                Rectangle firstEye = new Rectangle(tileRect.X + x1, tileRect.Y + y1, 9, 9);
                Rectangle secondEye = new Rectangle(tileRect.X + x2, tileRect.Y + y2, 9, 9);
                g.FillEllipse(white, firstEye);
                g.FillEllipse(white, secondEye);
                DrawBlackCircles(g, direction, firstEye, secondEye);
            }
        }

        private static bool eyesUtil(Tile tile)
        {
            if (tile.isHead)
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

        private static void DrawBlackCircles(Graphics g, Direction direction, Rectangle rect, Rectangle rect2)
        {
            switch (direction)
            {
                case Direction.Up:
                    rect.Height -= 2;
                    rect2.Height -= 2;
                    break;
                case Direction.Down:
                    rect.Height -= 2;
                    rect2.Height -= 2;
                    rect.Y += 2;
                    rect2.Y += 2;
                    break;
                case Direction.Left:
                    rect.Width -= 2;
                    rect2.Width -= 2;
                    break;
                case Direction.Right:
                    rect.Width -= 2;
                    rect2.Width -= 2;
                    rect.X += 2;
                    rect2.X += 2;
                    break;
            }
            g.FillEllipse(black, rect);
            g.FillEllipse(black, rect2);
        }
    }
}
