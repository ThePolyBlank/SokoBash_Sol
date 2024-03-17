using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SokoBash.Utils;

namespace SokoBash.Elements
{
    internal abstract class Element
    {
        public virtual ConsoleColor switchColor => ConsoleColor.Black;

        public abstract bool TryPush(Level levelState, Vector selfLocation, Vector direction);

        public virtual char ToChar()
        {
            return ' ';
        }
    }
}
