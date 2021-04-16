using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Collections_Generics
{
    [Serializable]
    public class Circle : IComparable<Circle>, ISerializable
    {
       
        public Circle()
        {

        }
        public Circle(SerializationInfo info, StreamingContext context)
        {
            Radius = (double)info.GetValue("Radius", typeof(Double));
        }
        public double Radius { get; }
        public Circle(double r)
        {
            if (r <= 0)
            {
                throw new ArgumentException("Radius can't be 0 or less than 0");
            }
            Radius = r;
        }
        // S = π*r^2
        public double Square()
        {
            return Math.PI * Radius * Radius;
        }
        // P = π*2r
        public double Perimeter()
        {
            return Math.PI * 2 * Radius;
        }
        public int CompareTo([AllowNull] Circle cir)
        {
            if (cir is null)
                return 1;
            return Radius.CompareTo(cir.Radius);
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Radius", Radius);
        }
        public override string ToString()
        {
            return $"Radius of circle: {Radius}";
        }
    }
}
