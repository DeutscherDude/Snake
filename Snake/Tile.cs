﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Tile : ISnake, IApple
    {
        private int x;
        private int y;
        private int width;
        private int height;

        public Color TileColor { get; set; }
        public bool isSnake { get; set; }
        public bool isApple { get; set; }
        public bool isHead { get; set; }
        public bool hasEyes { get; set; }

        public Tile(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public void CheckState()
        {
            if (isHead)
                ChangeColor(ColorSet.SnakeH);
            else if (isApple)
                ChangeColor(ColorSet.Apple);
            else if (isSnake)
                ChangeColor(ColorSet.Snake);
            else
                ChangeColor(ColorSet.Field);
        }

        public Rectangle getTile()
        {
            return new Rectangle(x, y, width, height);
        }

        //public Elipse GetElipse()
        //{
        //    return new Elipse(x, y, width, height);
        //}

        public void ChangeColor(ColorSet color)
        {
            switch(color)
            {
                case ColorSet.Snake:
                    TileColor = Color.Green;
                    break;
                case ColorSet.Field:
                    TileColor = Color.Gray;
                    break;
                case ColorSet.Apple:
                    TileColor = Color.Tomato;
                    break;
                case ColorSet.SnakeH:
                    TileColor = Color.DarkGreen;
                    break;
            }
        }
    }
}
