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
      /*
         * It is a good practice, to disallow instance mutation - unless mutation is necessary.
         (mutation refers to changing the instance's state).
         
         In this case, for example - it was specified that the constructor initializes the shape's color.
         Meaning that the creator of the instance would expect that state to be persistent.
         Your implementation's protected setter allows the mutation of the initialized color, and does not meet this expectation.
         
         So, to sum it up, the best approach for the color property in this case would be:
         'public ConsoleColor Color{get; private set;}'
         (Do note the private keyword on the property setter.)
         
         * Consider avoiding protected properties, since it encourages better encapsulation between the base class and derived class.
         
         *In your case, you are allowing derived classes to mutate the instance,
         despite the fact that the code which created the instance probably specified the color he wishes to see in the constructor.
         
         * Note that the naming convention for the private field would be '_color', with a lower-case 'c'.
      */
        protected ConsoleColor _Color { get; set; }
        public abstract double Area { get; }


       /*
        
         No input validation:
         
         Syntactically, this is correct:
         
         var color = (ConsoleColor)9999;
         var shape = new MyShape(color);
         
         This will not throw a runtime exception, despite the fact that there is no such a memeber in the enumeration.
         Consider using Enum.IsDefined
         https://msdn.microsoft.com/en-us/library/system.enum.isdefined(v=vs.110).aspx
         
         This will enable you to detect invalid instances
         And destroy them before they are used by throwing an exception from within the constructor
         
       */
        protected Shape(ConsoleColor color)
        {
            _Color = color;
        }

         /*
         It is a good practice to delegate initialization logic to a single constructor.
         This is in accordance to the DRY (Dont Repeat Yourself) principle
         
         A DRY implementation of the default constructor would be:
         
          public Shape():this(ConsoleColor.White)
          {
          }
         */
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
