using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using calcul;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Class1 l = new Class1 ();

        [TestMethod]
        public void TestMethod1()
        {  // Дискрименант больше  0
            double
                a = 1,
                b = 8,
                c = 2;
            string x1 = null, x2 = null;

            l.Calcul(a, b, c, ref x1, ref x2);
            Assert.AreEqual(x1, "-7,74");
            Assert.AreEqual(x2, "-0,258");
        }


        [TestMethod]
        public void TestMethod2()
        {  // Дискрименант равен  0
            double
                a = 3,
                b = 6,
                c = 3;
            string x1 = null, x2 = null;

            l.Calcul(a, b, c, ref x1, ref x2);
            Assert.AreEqual(x1, "-1");
            Assert.AreEqual(x2, "-1");

        }

        [TestMethod]
        public void TestMethod3()
        {  // Дискрименант равен  0
            double
                 a = -1,
                 b = -4,
                 c = -4;
            string x1 = null, x2 = null;

            l.Calcul(a, b, c, ref x1, ref x2);
            Assert.AreEqual(x1, "-2");
            Assert.AreEqual(x2, "-2");

        }

        [TestMethod]
        public void TestMethod4()
        {  // Дискрименант меньше  0
            double
                a = 1,
                b = 2,
                c = 48;
            string x1 = null, x2 = null;

            l.Calcul(a, b, c, ref x1, ref x2);
            Assert.AreEqual(x1, "-1+6,86i");
            Assert.AreEqual(x2, "-1-6,86i");
        }

        [TestMethod]
        public void TestMethod()
        {  // Дискрименант меньше  0
            double
                a = 1.6,
                b = 0.3,
                c = 2.3;
            string x1 = null, x2 = null;

            l.Calcul(a, b, c, ref x1, ref x2);
            Assert.AreEqual(x1, "-0,24+3,06i");
            Assert.AreEqual(x2, "-0,24-3,06i");
        }
    }

}
