using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokoBash.Utils
{
    struct ConsoleChar
    {
        public char character;
        public ConsoleColor? ForegroundColour;
        public ConsoleColor? BackgroundColour;

        public ConsoleChar(char _character, ConsoleColor _foregroundColour, ConsoleColor _backgroundColour)
        {
            character = _character;
            ForegroundColour = _foregroundColour;
            BackgroundColour = _backgroundColour;
        }

        public ConsoleChar(char _character)
        {
            character = _character;
            ForegroundColour = null;
            BackgroundColour = null;
        }
    }
}
