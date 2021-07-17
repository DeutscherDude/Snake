using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        List<Tile> tiles;

        public Form1()
        {
            InitializeComponent();
            graphics = gamePanel.CreateGraphics();
            generateTiles();
        }
        int _width = 16;
        int _height = 16;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Chuj w dupie kurwa 2137
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            // namaluj se
        }
        private void generateTiles()
        {
            
            for(int i = 0; i<_height; i++)
            {
                for(int j=0; j<_width; j++)
                {
                    // chuj TODO create tiles
                }
            }
        }
    }
}
