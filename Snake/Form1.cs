using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Snake
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        List<Tile> tiles;
        int _width;
        int _height;

        public Form1()
            : base()
        {
            this.KeyPreview = true;
            InitializeComponent();
            graphics = gamePanel.CreateGraphics();
            _width = gamePanel.Width;
            _height = gamePanel.Height;
            tiles = generateTiles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Chuj w dupie kurwa 2137

        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush tempB = new SolidBrush(Color.Red);
            // namaluj se
            foreach(var tile in tiles)
            {
                graphics.FillRectangle(tempB, tile.getTile());
            }    

        }
        private List<Tile> generateTiles()
        {
            List<Tile> result = new List<Tile>();
            for(int i = 0; i<_height; i+=32)
            {
                for(int j=0; j<_width; j+=32)
                {
                    // chuj TODO create tiles
                    result.Add(new Tile(i, j, 32, 32));
                }
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                string message = "Button has been pressed";

                MessageConsole.LogMessage(message);
                e.Handled = false;
            }
        }
    }
}
