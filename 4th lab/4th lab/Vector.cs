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
        public static Vector Addition(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector Subtraction(Vector a, Vector b)
        { 
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vector VectorMultiplication(Vector a, Vector b)
        {
            return new Vector(a.Y * b.Z - a.Z * b.Y, a.X * b.Z - a.Z * b.X, a.X * b.Y - a.Y * b.X);
        }
        public static double ScalarMultiplication(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
        public static Vector MultiplyByNumber(Vector a, int number)
        {
            return new Vector(a.X * number, a.Y * number, a.Z * number);
        }
        // Скалярное произведение
    }
}
