using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Rectangle : Shape , IPersist, IComparable
    {
        public override double Area { get; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height, ConsoleColor color) : base(color)
        {
            Width = width;
            Height = height;
            Area = Width * Height;
        }

        public Rectangle(int width, int height) : base()
        {
                Width = width;
                Height = height;
                Area = Width * Height;
        }

        public override void Display()
        {
            Console.BackgroundColor = _Color;

            Console.WriteLine("Width="+Width+" Height="+Height);
            
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine("Rectangle: Width " + Width + " Height " + Height);
        }

        public int CompareTo(object obj)
        {   
            Rectangle rectangle = (Rectangle)obj;
            if (this.Area > rectangle.Area)
                return 1;
            if (this.Area < rectangle.Area)
                return -1;
            return 0;
        }

    }
}
