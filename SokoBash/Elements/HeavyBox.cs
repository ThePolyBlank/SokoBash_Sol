using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SokoBash.Utils;

namespace SokoBash.Elements
{
    internal class HeavyBox : Box
    {
        // test class for a custom element

        public override bool TryPush(Level levelState, Vector selfLocation, Vector direction)
        {
            Element selfElement = levelState.GetTileContent(selfLocation);
            Vector destination = selfLocation + direction;
            Element destinationElement = levelState.GetTileContent(destination);

            if (destinationElement is Air)
            {
                levelState.SetTileContent(destination, selfElement);
                levelState.SetTileContent(selfLocation, new Air());
                return true;
            }
            return false;
        }

        public override char ToChar()
        {
            return 'X';
        }
    }
}
