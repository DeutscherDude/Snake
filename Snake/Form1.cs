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
        SnakeItself head;
        
        List<int> snakeIndexes;

        int _width;
        int _height;
        private int length = 4;
        public bool AppleExists = false;

        Direction currentDirection = Direction.Up;

		private bool isPressed = false;
        public Form1()
            : base()
        {
            this.KeyPreview = true;
            InitializeComponent();
            graphics = gamePanel.CreateGraphics();
            _width = gamePanel.Width;
            _height = gamePanel.Height;
            tiles = generateTiles();
            snakeIndexes = new List<int>();
            generateHead();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Chuj w dupie kurwa 2137

        }

        private void generateHead()
        {
             head = new SnakeItself(_width, _height);

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
            if(isPressed == false)
            {
                isPressed = true;
                var button = keyData;
                currentDirection = MovingHandler.GetDirection(keyData, currentDirection);
                return base.ProcessCmdKey(ref msg, keyData);
            }
            else
            {
                return false;
            }        
         }


        private void gameLoop_Tick(object sender, EventArgs e)
        {
            foreach (var tile in tiles)
            {
                // adding tail
                if(isHeadTile(tile))
                {
                    snakeIndexes.Insert(0, tiles.IndexOf(tile));
                }

                removeTail();
                tile.CheckState();
                graphics.FillRectangle(new SolidBrush(tile.TileColor), tile.getTile());
            }
            if (AppleExists == false)
            {
                AppleGenerator.Generate(tiles);
                AppleExists = true;
            }
            head.Move(currentDirection);
			isPressed = false; // HAVE TO BE LAST!
        }

        private bool isHeadTile(Tile tile)
        {
            if (head.GetCurrentPos() == tile.getTile())
            {
                tile.isSnake = true;
                return true;
            }
            else
                return false;
        }

        private void removeTail()
        {
            int lastIndex = snakeIndexes.Count();
            if(lastIndex > length)
            {
                tiles[snakeIndexes[lastIndex-1]].isSnake = false;
                snakeIndexes.RemoveAt(lastIndex-1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameLoop.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (gameLoop.Enabled == true)
            {
                gameLoop.Enabled = false;   
                Pause.Text = "Unpause"; 
            }
            else if (gameLoop.Enabled == false)
            {
                Pause.Text = "Pause";
                gameLoop.Enabled = true;
            }
        }
    }
}
