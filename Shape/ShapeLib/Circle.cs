using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Circle : Ellipse
    {

        public Circle(int k1, ConsoleColor color) : base(k1, k1, color)
        {
        }

        public Circle(int k1) : base(k1, k1)
        {
        }

        //Same note as in all Shape derived classes
        public override void Display()
        {
            Console.BackgroundColor = _Color;
            Console.WriteLine("Radius=" + R1);
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
