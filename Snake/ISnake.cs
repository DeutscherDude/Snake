﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    interface ISnake
    {
        bool isSnake { get; set; }
        bool isHead { get; set; }

        void ChangeColor(ColorSet color);
        Color TileColor { get; set; }
    }
}
