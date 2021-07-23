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
        Graphics graphicsPoints;
        Graphics graphicsButtons;
        List<Tile> tiles;
        SnakeItself head;
        Buttons button;

        List<int> snakeIndexes;

        int _width;
        int _height;
        private int length = 4;
        public bool AppleExists = false;
        public bool AppleEaten = false;

        Direction currentDirection = Direction.Up;

        private Point mousePos;
        private bool isPressed = false;
        public Form1()
            : base()
        {
            this.KeyPreview = true;
            InitializeComponent();
            graphics = gamePanel.CreateGraphics();
            graphicsPoints = Counter.CreateGraphics();
            graphicsButtons = buttons.CreateGraphics();
            _width = gamePanel.Width;
            _height = gamePanel.Height;
            tiles = generateTiles();
            snakeIndexes = new List<int>();
            generateHead();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageConsole.LogMessage("Starting");
        }

        private void showButtons()
        {
            ButtonsDrawing.DrawPauseButton(buttons, graphicsButtons, mousePos);
            Buttons? but = ButtonsDrawing.GetButton();
            if (but != null)
            {
                button = but.Value;
            }
            else
                button = Buttons.None;
        }

        private void generateHead()
        {
            head = new SnakeItself(_width, _height);

        }

        private List<Tile> generateTiles()
        {
            List<Tile> result = new List<Tile>();
            for (int i = 0; i < _height; i += 32)
            {
                for (int j = 0; j < _width; j += 32)
                {
                    // chuj TODO create tiles
                    result.Add(new Tile(i, j, 32, 32));
                }
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageConsole.LogMessage("Clicked Exit button");
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (isPressed == false)
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
            showButtons();

            foreach (var tile in tiles)
            {
                if (isHeadTile(tile))
                {
                    tile.isHead = true;
                    snakeIndexes.Insert(0, tiles.IndexOf(tile));
                }
                if (Collision.CheckAppleCollision(tile, head.GetCurrentPos()))
                {
                    Eating();
                }
                if(Collision.CheckSnakeCollision(tile))
                {
                    Death();
                }

                removeTail();
                tile.CheckState();
                if (tile.isApple)
                {
                    graphics.FillEllipse(new SolidBrush(tile.TileColor), tile.getTile());
                }

                else
                {
                    graphics.FillRectangle(new SolidBrush(tile.TileColor), tile.getTile());
                }

                Eyes.drawEyes(graphics, tile, currentDirection);

                if (tile.isHead)
                {
                    tile.isHead = false;
                    tile.isSnake = true;
                }
            }


            if (AppleExists == false)
            {
                AppleGenerator.Generate(tiles);
                AppleExists = true;
            }
            head.Move(currentDirection);
            isPressed = false; // HAS TO BE LAST!
        }

        private void Death()
        {
            MessageConsole.LogMessage("Ending");
            gameLoop.Stop();
            // To-Do:
            //          Play some wacky sound
            //          Kill myself
            MessageBox.Show("GAME OVER! / TODO: coś na koniec gry");
            System.Threading.Thread.Sleep(2000);
            gameLoop.Dispose();
            length = 4;
        }

        private void Eating()
        {
            MessageConsole.LogMessage("Eating");
            bool eaten = true;
            AppleExists = false;
            length++;
            drawPoints(eaten);
        }

        private bool isHeadTile(Tile tile)
        {
            if (head.GetCurrentPos() == tile.getTile())
            {
                return true;
            }
            else
                return false;
        }

        private void removeTail()
        {
            int lastIndex = snakeIndexes.Count();
            if (lastIndex > length)
            {
                tiles[snakeIndexes[lastIndex - 1]].isSnake = false;
                snakeIndexes.RemoveAt(lastIndex - 1);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageConsole.LogMessage("Clicked Start Button");
            gamePanel.Visible = true;
            gameLoop.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageConsole.LogMessage("Clicked Pause Button");
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

        // counter variables
        private Font f = new Font("Verdana", 20, FontStyle.Bold);
        private SolidBrush sb = new SolidBrush(Color.White);
        private void drawPoints(bool eaten)
        {
            if (eaten)
            {
                graphicsPoints.Clear(Color.Black); ;
                graphicsPoints.DrawString((length * 100).ToString(), f, sb, 7, 7);
            }

        }

        private void Counter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttons_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = e.Location;
        }

        private void buttons_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if(button == Buttons.Pause)
                {
                    MessageConsole.LogMessage("Clicked Pause Button");
                    pause();
                }
            }
        }

        private void pause()
        {
            if (gameLoop.Enabled == true)
            {
                gameLoop.Enabled = false;
            }
            else if (gameLoop.Enabled == false)
            {
                gameLoop.Enabled = true;
            }
        }
    }
}
