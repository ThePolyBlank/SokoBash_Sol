using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokoBash.Utils
{
    struct Vector
    {
        public int x;
        public int y;

        public Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector() : this(0, 0) { }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y);
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            return v1.x == v2.x && v1.y == v2.y;
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return v1.x != v2.x || v1.y != v2.y;
        }

        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1.x * v2.x, v1.y * v2.y);
        }

        public static Vector operator *(Vector v, int s)
        {
            return new Vector(v.x * s, v.y * s);
        }

        public static Vector operator *(int s, Vector v)
        {
            return v * s;
        }

        public override string ToString()
        {
            return $"({x}|{y})";
        }
    }


}
