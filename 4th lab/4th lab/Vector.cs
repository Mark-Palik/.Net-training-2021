namespace _4th_lab
{
    class Vector
    {
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}";
        }
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector operator -(Vector a, Vector b)
        { 
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static double operator *(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
        public static Vector operator *(Vector a, int number)
        {
            return new Vector(a.X * number, a.Y * number, a.Z * number);
        }
        // Скалярное произведение
    }
}
