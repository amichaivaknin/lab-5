using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ShapeLib;


namespace ShapesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder st = new StringBuilder();
            ShapeManager shapeManager = new ShapeManager();
            Rectangle rec = new Rectangle(5,4,ConsoleColor.Blue);
            Ellipse ellipse = new Ellipse(2,1);
            Circle  circle  = new Circle(3, ConsoleColor.Cyan);
            Circle circle2 = new Circle(2, ConsoleColor.DarkRed);
            shapeManager.Add(rec);
            shapeManager.Add(ellipse);
            shapeManager.Add(circle);
            shapeManager.Add(circle2);
            shapeManager.DisplyAll();
            Console.WriteLine(shapeManager.Count);
            st=shapeManager.Save(st);
            Console.WriteLine(st.ToString());
            Console.WriteLine(circle.CompareTo(circle2));
        }
    }
}
