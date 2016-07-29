using ShapesApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;


namespace ShapesApp
{
    class ShapeManager
    {
        /*
        Really Great work! (as far as Lab 5.1 goes)
        note the naming convention for fields: '_shapes'.
        It is common to specify the access for each field method and property:
        
        End result:
        'private ArrayList _shapes;''
        */
        ArrayList Shapes;
        
        /**
            Very good!
        */
        public Shape this[int index] => (Shape) Shapes[index];

        public int Count => Shapes.Count;

        public ShapeManager()
        {
            Shapes = new ArrayList();
        }

        /**
            Input validation!
        
        */
        public void Add(Shape shape)
        {
            Shapes.Add(shape);
        }

        public void DisplyAll()
        {
            foreach (Shape shape in Shapes)
            {
                shape.Display();
                Console.WriteLine(shape.Area);
            }
        }

        /**
        
        What happens when you add more shapes?
        Do you add more cases to the switch?
        What happens if you want to use this method for any shape out there, even those which are not in your code?
        Polymorphism is the answer

        Consider this implementation:

            foreach (var persistable in Shapes.OfType<IPersist>())
            {
               persistable.Write(st);
            }

        OfType will select only members which are assignable to an IPersist reference and return such a collection
        https://msdn.microsoft.com/en-us/library/bb360913(v=vs.110).aspx

        */
        public StringBuilder Save(StringBuilder st)
        {
            foreach (var shape in Shapes)
            {
                switch (shape.GetType().ToString())
                {
                    case "ShapeLib.Rectangle":
                        ((Rectangle)shape).Write(st);
                        break;
                    case "ShapeLib.Ellipse":
                        ((Ellipse)shape).Write(st);
                        break;
                }
            }
            return st;
        }
    }
}
