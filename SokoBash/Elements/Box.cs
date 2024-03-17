using SokoBash.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokoBash.Elements
{
    internal class Box : Element
    {

        public override char ToChar()
        {
            return 'X';
        }

        public override bool TryPush(Level levelState, Vector selfLocation, Vector direction)
        {
            Element selfElement = levelState.GetTileContent(selfLocation);
            Vector destination = selfLocation + direction;
            Element destinationElement = levelState.GetTileContent(destination);

            if (destinationElement.TryPush(levelState, destination, direction))
            {

                levelState.SetTileContent(destination, selfElement);
                levelState.SetTileContent(selfLocation, new Air());
                return true;
            }
            return false;
        }
    }
}
