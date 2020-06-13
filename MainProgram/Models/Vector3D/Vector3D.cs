using System;

namespace Vector
{
    public class Vector3D
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        /// <summary>
        /// Calculates the length of the vector 'X ^ 2 + Y ^ 2 + Z ^ 2'
        /// </summary>
        public double Length { get => Math.Sqrt(X * X + Y * Y + Z * Z); }
        /// <summary>
        /// Creates a vector with coordinates X, Y, Z from the origin (0, 0, 0)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        /// <summary>
        /// This method forms a string representation of a vector in the format (X, Y, Z)
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"({X}, {Y}, {Z})";

        public override bool Equals(object obj)
        {
            return (obj is Vector3D) && Equals((Vector3D)obj);
        }

        public bool Equals(Vector3D vector)
        {
            return X == vector.X && Y == vector.Y && Z == vector.Z;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Vector3D v1, Vector3D v2)
        {
            return v1.Equals(v2);
        }

        public static bool operator !=(Vector3D v1, Vector3D v2)
        {
            return !v1.Equals(v2);
        }

        public static Vector3D operator +(Vector3D v)
        {
            return v;
        }

        public static Vector3D operator -(Vector3D v)
        {
            return new Vector3D(-v.X, -v.Y, -v.Z);
        }

        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return v1 - v2;
        }

        public static Vector3D operator *(Vector3D v, double d)
        {
            return new Vector3D(v.X * d, v.Y * d, v.Z * d);
        }

        public static Vector3D operator *(double d, Vector3D v)
        {
            return v * d;
        }

        public static Vector3D operator /(Vector3D v, double d)
        {
            return new Vector3D(v.X / d, v.Y / d, v.Z / d);
        }

        public static Vector3D operator /(double d, Vector3D v)
        {
            return new Vector3D(d / v.X, d / v.Y, d / v.Z);
        }
        /// <summary>
        /// This method calculates the scalar product of two vectors
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns></returns>
        public static double ScalarProduct(Vector3D v1, Vector3D v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }
        /// <summary>
        /// This method calculates the angle between two vectors
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns></returns>
        public static double Angle(Vector3D v1, Vector3D v2)
        {
            double scalarProduct = ScalarProduct(v1, v2);
            double v1Length = v1.Length;
            double v2Length = v2.Length;
            return Math.Acos(scalarProduct / v1Length / v2Length);
        }

    }
}
