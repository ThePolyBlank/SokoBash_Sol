using SokoBash.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokoBash.Elements
{
    internal class Wall : Element
    {
        public override char ToChar()
        {
            return '#';
        }

        public override bool TryPush(Level levelState, Vector selfLocation, Vector direction)
        {
            // Walls can never be pushed
            return false;
        }
    }
}
