﻿using System;
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

        private void generateHead()
        {
            head = new SnakeItself((_width / 2) - 32, (_height / 2) - 32);

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
 
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var button = keyData;
            if (keyData == Keys.Down || keyData == Keys.S)
            {
                currentDirection = Direction.Down;
                MessageConsole.LogMessage($"Changed Direction to {currentDirection}");
                return true;
            }
            if (keyData == Keys.Up || keyData == Keys.W)
            {
                currentDirection = Direction.Up;
                MessageConsole.LogMessage($"Changed Direction to {currentDirection}");
                return true;
            }
            if (keyData == Keys.Left || keyData == Keys.A)
            {
                currentDirection = Direction.Left;
                MessageConsole.LogMessage($"Changed Direction to {currentDirection}");
                return true;
            }
            if (keyData == Keys.Right || keyData == Keys.D)
            {
                currentDirection = Direction.Right;
                MessageConsole.LogMessage($"Changed Direction to {currentDirection}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            foreach (var tile in tiles)
            {
                if (head.GetCurrentPos() == tile.getTile())
                {
                    tile.isSnake = true;
                }
                tile.CheckState();
                graphics.FillRectangle(new SolidBrush(tile.TileColor), tile.getTile());
            }
            head.Move(currentDirection);
        }
    }
}
