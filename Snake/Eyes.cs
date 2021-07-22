using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Snake
{
    public static class Eyes
    {
        private static bool eyesUtil(Tile tile)
        {
            if(tile.isHead)
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

       
    }
}
