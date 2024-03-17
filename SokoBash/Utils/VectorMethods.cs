using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokoBash.Utils
{
    enum Direction
    {
        Up, Down, Left, Right, Neutral
    }

    static class VectorMethods
    {
        public static Vector GetVector(this Direction dir)
        {
            switch (dir)
            {
                case Direction.Up: return new Vector(0, -1);
                case Direction.Down: return new Vector(0, 1);
                case Direction.Left: return new Vector(-1, 0);
                case Direction.Right: return new Vector(1, 0);
            }
            return new Vector(0, 0);
        }

        public static Vector ConsoleKeyToVector(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    return GetVector(Direction.Up);

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    return GetVector(Direction.Down);

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    return GetVector(Direction.Left);

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    return GetVector(Direction.Right);

                default:
                    return GetVector(Direction.Neutral);
            }
        }
    }
}
