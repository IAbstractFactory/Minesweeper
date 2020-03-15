using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper
{
    class Cell : System.Windows.Forms.Button
    {
        public bool Flag { get; set; } = false;
        Color color;
        public int Value { get; set; } = 0;
        public bool IsBomb { get; set; }
        //public bool Pressed { get; set; } = false;
        public int X { get; }
        public int Y { get; }
        public Cell(bool bomb, int x, int y)
        {

            IsBomb = bomb;
            X = x;
            Y = y;
        }
        public void ToFlag()
        {
            if (Flag == false)
            {
                color = this.BackColor;
                Flag = true;
                this.BackColor = Color.Aqua;

            }
            else
            {
                Flag = false;
                this.BackColor = color;
            }
        }
        public Cell(int x, int y)
        {
            IsBomb = false;
            X = x;
            Y = y;
        }
    }
}
