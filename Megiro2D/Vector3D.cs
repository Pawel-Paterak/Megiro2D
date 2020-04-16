using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megiro2D
{
    public class Vector3D
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3D()
        {

        }

        public Vector3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3D operator *(Vector3D l, Vector3D r)
            => new Vector3D(l.X * r.X, l.Y * r.Y, l.Z * r.Z);

        public static Vector3D operator *(Vector3D l, int r)
            => new Vector3D(l.X * r, l.Y * r, l.Z * r);

        public static Vector3D operator *(Vector3D l, double r)
            => new Vector3D(l.X * (float)r, l.Y * (float)r, l.Z * (float)r);

        public static Vector3D operator *(Vector3D l, float r)
            => new Vector3D(l.X * r, l.Y * r, l.Z * r);

        public static Vector3D operator /(Vector3D l, Vector3D r)
            => new Vector3D(l.X / r.X, l.Y / r.Y, l.Z / r.Z);

        public static Vector3D operator /(Vector3D l, int r)
            => new Vector3D(l.X / r, l.Y / r, l.Z / r);

        public static Vector3D operator /(Vector3D l, double r)
            => new Vector3D(l.X / (float)r, l.Y / (float)r, l.Z / (float)r);

        public static Vector3D operator /(Vector3D l, float r)
            => new Vector3D(l.X / r, l.Y / r, l.Z / r);

        public static Vector3D operator +(Vector3D l, Vector3D r)
            => new Vector3D(l.X+r.X, l.Y+r.Y, l.Z+r.Z);

        public static Vector3D operator -(Vector3D l, Vector3D r)
            => new Vector3D(l.X + r.X, l.Y + r.Y, l.Z + r.Z);
    }
}
