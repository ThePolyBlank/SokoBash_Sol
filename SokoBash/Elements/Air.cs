using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SokoBash.Utils;

namespace SokoBash.Elements
{
    internal class Air : Element
    {
        public override bool TryPush(Level levelState, Vector selfLocation, Vector direction)
        {
            return true;
        }
    }
}
