using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapper
{
    class Cell : System.Windows.Forms.Button
    {
        public bool IsBomb { get; }
        public Cell(bool bomb)
        {
            IsBomb = bomb;
        }
        public Cell()
        {
            IsBomb = false;
        }
    }
}
