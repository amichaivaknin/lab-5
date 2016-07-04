using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Ellipse : Shape , IPersist, IComparable
    {
        public override double Area { get; }
        protected double R1;
        protected double R2;

        public Ellipse(int k1, int k2, ConsoleColor color) : base(color)
        {
            R1 = (double)k1/2;
            R2 = (double)k2/2;
            Area = 3.14*((double)k1/2)*((double)k2 /2);
        }

        public Ellipse(int k1, int k2) : base()
        {
            R1 = (double)k1 / 2;
            R2 = (double)k2 / 2;
            Area = 3.14 * ((double)k1 / 2) * ((double)k2 / 2);
        }

        public override void Display()
        {
            Console.BackgroundColor = _Color;

            Console.WriteLine("Radius1=" + R1 + " Radius2=" + R2);

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine("Ellipse : Width " + R1*2 + " Height " + R2*2);
        }

        public int CompareTo(object obj)
        {
            Ellipse ellipse = (Ellipse) obj;
            if (Area > ellipse.Area)
                return 1;
            if (Area < ellipse.Area)
                return -1;
            return 0;
        }    
    }
}
