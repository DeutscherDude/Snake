using System.Drawing;
using System.Windows.Controls;

namespace Snake
{
    public static class ButtonsDrawing
    {
        private static Pen background = new Pen(Color.Black, 1);


        public static void DrawPauseButton(Graphics g)
        {
            ClearButtons(g);
            SolidBrush sol = new SolidBrush(Color.LightBlue);
            g.FillRectangle(sol, 0, 0, 100, 30);
            g.DrawRectangle(background, 0, 0, 100, 30);
        }



        private static void ClearButtons(Graphics g)
        {
            g.Clear(Color.FromKnownColor(KnownColor.ControlDark));
        }
    }
}
