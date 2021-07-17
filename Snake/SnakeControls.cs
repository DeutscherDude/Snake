using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Snake
{
    class SnakeControls
    {
        //    26, -down
        //    24, -up
        //    23, -left
        //    25  -right

        protected enum MovementButtons
        {
            down,
            up,
            left,
            right
        };

        private Key button = Key.Down;

        protected Key Button { get => button; set => button = value; }

        private void OnMovementKeyStrokeHandler(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Down)
            {
                Console.WriteLine("Code to go X will be here");
            }

        }
    }
}
