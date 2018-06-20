using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace calcul
{
    public class Class1

    {
        public void Calcul(double a, double b, double c, ref string x1, ref string x2)
        {
            double rezult1, rezult2, d;
            d = b * b - 4 * a * c;
            if (d < 0)
            {
                d *= -1;
                rezult1 = (-b / 2 * a);
                rezult2 = (Math.Sqrt(d) / 2 * a);
                x1 = String.Format("{0:G3}", rezult1) + '+' + String.Format("{0:G3}", rezult2) + 'i';
                x2 = String.Format("{0:G3}", rezult1) + '-' + String.Format("{0:G3}", rezult2) + 'i';
                return;
            }
            else if (d == 0)
            {
                rezult1 = (-b / (2 * a));
                x1 = String.Format("{0:G3}", rezult1);
                x2 = x1;
            }
            if (d > 0)
            {
                {
                    rezult1 = ((-b - Math.Sqrt(d)) / (2 * a));
                    rezult2 = ((-b + Math.Sqrt(d)) / (2 * a));
                    x1 = String.Format("{0:G3}", rezult1);
                    x2 = String.Format("{0:G3}", rezult2);
                }
            }

        }
    }
}

