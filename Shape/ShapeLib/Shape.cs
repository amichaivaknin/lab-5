using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public abstract class Shape
    {
        protected ConsoleColor _Color { get; set; }
        public abstract double Area { get; }


        protected Shape(ConsoleColor color)
        {
            _Color = color;
        }

        protected Shape()
        {
            _Color=ConsoleColor.White;
        }

        public virtual void Display()
        {
            Console.BackgroundColor = _Color;
        }

    }
}
