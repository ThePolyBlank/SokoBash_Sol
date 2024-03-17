using SokoBash.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokoBash.Tiles
{
    internal class Tile
    {
        protected Element content;

        public virtual Element Content
        {
            get { return content; }
            set { content = value; }
        }

        public virtual bool IsSatisfied { get { return true; } }

        public Tile(Element _content)
        {
            this.content = _content;
        }

        // Constructor for empty Tiles
        public Tile() :this(new Air()) { }

    }
}
