using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapper
{
    class Cell : System.Windows.Forms.Button
    {
        public int Value { get; set; } = 0;
        public bool IsBomb { get; set; }
        public int X { get; }
        public int Y { get; }
        public Cell(bool bomb, int x, int y)
        {
            IsBomb = bomb;
            X = x;
            Y = y;
        }
        public Cell(int x, int y)
        {
            IsBomb = false;
            X = x;
            Y = y;
        }
    }
}
