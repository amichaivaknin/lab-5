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
        
        /*
        This class is a good example of my comments regarding your Shape implementation
        
        Note that the value returned by 'Area' is computed at construct time
        After which any code referencing the instance can set your width and / or height properties,
        To values different than the construct time ones.
        This will make the instance inconsistent since 'Width*Height' will no longer be equal to 'Area'
        
        Consider this:
        public int Width { get; private set; }
        public int Height { get; private set; }
        */
        public int Width { get; set; }
        public int Height { get; set; }

/*
        * No Input validation!
        
        *It is a good practice to delegate initialization logic to a single constructor.
         Although, it is not always possible- in which case all constructors delegate the initialization to a common method
         This is in accordance to the DRY (Dont Repeat Yourself) principle
         
        A DRY instantiation implementation for this class would be:
            
        public Rectangle(ConsoleColor color,int width, int height):base(color)
        {
          Initialize(width,height);
        }
        
        public Rectangle(int width, int height):base(color)
        {
           Initialize(width,height);
        }
        
        private void Initialize(int width, int height)
        {
             _width = width;
            _height = height;
            _area = _width*_height;
        }
        
        */
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

        /*
            Your implementation violates the following principles:
            1) DRY - the first line of code actually does exactly what the base class implementation does
            Replace the first line with 'base.Display();'
            
            2) Encapsulation - the derived class accesses the state of the base class
            In fact, there is no valid reason for the '_Color' property to be accessible outside of 'Shape'
            
        */
        public override void Display()
        {
            Console.BackgroundColor = _Color;

            Console.WriteLine("Width="+Width+" Height="+Height);
            
            //Why are you doing this? each Display call of any Shape derived class will set its own background color anyway
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
