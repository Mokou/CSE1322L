using System;

namespace Lab4 {
    class Program {
        static void Main(string[] args) {
            var octagon1 = new Octagon();
            var octagon2 = octagon1.Clone() as Octagon;

            Console.WriteLine($"{octagon1}");
            Console.WriteLine($"{octagon2}");
            int comp = octagon1.CompareTo(octagon2);
            if (comp == 0) {
                Console.WriteLine("The two geometric objects are the same.");
            } else {
                Console.WriteLine($"The compared object is {(comp == 1 ? "smaller" : "bigger")}");
            }
        }
    }

    abstract class GeometricObject : IComparable, ICloneable {
        protected double SideLength {get; set;}
        protected double Area {get; set;}

        public override string ToString() {
            return $"{this.GetType().Name}: Side length = {SideLength}, Area = {Area:N2}";
        }

        public int CompareTo(object obj) {
            if (obj == null) return 1;

            GeometricObject geo = obj as GeometricObject;
            if (SideLength.CompareTo(geo.SideLength) == 0 && Area.CompareTo(geo.Area) == 0) {
                return 0;
            } else if (SideLength.CompareTo(geo.SideLength) == -1 && Area.CompareTo(geo.Area) == -1) {
                return -1;
            } else {
                return 1;
            }
        }

        public object Clone() {
            return this.MemberwiseClone();
        }
    }

    class Octagon : GeometricObject {
        public Octagon() : this(8.0) { }

        public Octagon(double sideLength) {
            SideLength = sideLength;
            Area = 2 * (1 + Math.Sqrt(2)) * Math.Pow(SideLength, 2);
        }
    }
}
