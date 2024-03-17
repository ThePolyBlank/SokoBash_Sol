using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokoBash.Elements
{
    internal class Player : Box
    {
        public override ConsoleColor switchColor => ConsoleColor.DarkGreen;
        public override char ToChar()
        {
            return '@';
        }
    }
}
