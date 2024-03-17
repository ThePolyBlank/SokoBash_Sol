using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SokoBash.Elements;

namespace SokoBash.Tiles
{
    internal class TileSwitch : Tile
    {

        public Element satisfactoryElement;
        public override bool IsSatisfied { get { return content.GetType() == satisfactoryElement.GetType(); } }

        public TileSwitch(Element _content, Element _watchedElement) :base(_content)
        {
            satisfactoryElement = _watchedElement;
        }

    }
}
