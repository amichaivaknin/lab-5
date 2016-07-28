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
        
        public Shape this[int index] => (Shape) Shapes[index];

        public int Count => Shapes.Count;

        public ShapeManager()
        {
            Shapes = new ArrayList();
        }

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
