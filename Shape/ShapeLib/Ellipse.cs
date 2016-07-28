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
        
        //Never expose fields- fields are meant to be private.
        //Naming convention note: '_r1' and '_r2'
        
        protected double R1;
        protected double R2;

        /*
        * No input validation
        * Refer to my notes regarding a DRY constructor in the Shape and Rectangle clases
        */
        public Ellipse(int k1, int k2, ConsoleColor color) : base(color)
        {
            R1 = (double)k1/2;
            R2 = (double)k2/2;
            /*
            Why not user the already computed R1 and R2?
            Also, consider using the constant Math.PI, which is more accurate than yours : 
            https://msdn.microsoft.com/en-us/library/system.math.pi(v=vs.110).aspx
            */
            
            Area = 3.14*((double)k1/2)*((double)k2 /2);
        }

        
        public Ellipse(int k1, int k2) : base()
        {
            R1 = (double)k1 / 2;
            R2 = (double)k2 / 2;
            Area = 3.14 * ((double)k1 / 2) * ((double)k2 / 2);
        }

        //Refer to my notes regarding this method's implementation in the Rectangle class
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
