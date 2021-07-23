using System.Drawing;
using System.Windows.Controls;

namespace Snake
{
    public static class ButtonsDrawing
    {
        private static Pen background = new Pen(Color.Black, 1);
        private static SolidBrush sbPause = new SolidBrush(Color.LightBlue);
        private static Rectangle buttonPause = new Rectangle(0, 0, 100, 30);


        public static void DrawPauseButton(Graphics g, Point mousePos)
        {

            ClearButtons(g);
            g.FillRectangle(sbPause, buttonPause);
            g.DrawRectangle(background, buttonPause);
            if (checkHover(buttonPause, mousePos))
            {
                sbPause.Color = Color.FromArgb(100,100,255);
            }
            else
            {
                sbPause.Color = Color.FromArgb(80, 80, 255);
            }
        }

        private static bool checkHover(Rectangle rect, Point mousePos)
        {
            int x1 = rect.X;
            int x2 = rect.X+rect.Width;
            int y1 = rect.Y;
            int y2 = rect.Y+rect.Height;

            if(mousePos.X>x1 && mousePos.X<x2
                &&mousePos.Y>y1&&mousePos.Y<y2)
            {
                return true;
            }
            return false;
        }

        private static void ClearButtons(Graphics g)
        {
            g.Clear(Color.FromKnownColor(KnownColor.ControlDark));
        }
    }
}
