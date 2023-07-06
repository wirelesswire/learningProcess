using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using test2;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
             MathOperations.add(12,21);
             Assert.AreEqual(10,MathOperations.add(8,2));
        }
        [TestMethod]
        public void sumatest()
        {
            Assert.AreEqual(15, MathOperations.suma(0, 5));
        }
        [TestMethod]
        public void pierwiastkitest()
        {
            Assert.AreEqual("0 , -1",MathOperations.pierwiastki(2,2,0));
        }
        [TestMethod]
        public void ilosclitertest()
        {
            Assert.AreEqual(5, MathOperations.iloscliter("asdas"));
        }
        [TestMethod]
        public void najdluzszystringtest()
        {
            string[] str = new string[4] { "1", "123", "1233", "123333" };
            Assert.AreEqual("123333", MathOperations.najdluzszystring(str));
        }
        [TestMethod]
        public void isvalidhextest()
        {
            Assert.AreEqual(true, MathOperations.isvalidinhexadecimal("#FFF"));
        }
        [TestMethod]
        public void isphonetest()
        {
            Assert.AreEqual(true,MathOperations.isphonenumber("qweqwewq123123121"));
        }
        [TestMethod]
        public void palindromtest()
        {
            Assert.AreEqual(true, MathOperations.ispalindrom(123321));
        }
        [TestMethod]
        public void narcistictest()
        {
            Assert.AreEqual(true ,MathOperations.isnarcistic(2));
        }
        [TestMethod]
        public void eventest()
        {
            Assert.AreEqual(false,MathOperations.iseven(1001));
        }
        [TestMethod]
        public void cointainstest()
        {
            int[] r = new int[4] { 1, 2, 3, 4 };
            Assert.AreEqual(true,MathOperations.contains(r,1));
        }
        [TestMethod]
        public void vectormovetest()
        {
            //Assert.AreEqual(new int[] { 4, 4 }, MathOperations.movevector(new Point(1, 2), new Vector(3, 2)));
            CollectionAssert.AreEqual(new int[] { 4, 4 }, MathOperations.movevector(new Point(1, 2), new Vector(3, 2)));
        }
        [TestMethod]
        public void sameqtest()
        {
            Assert.AreEqual(true, MathOperations.sameq(new Point(-1, 1), new Point(-2, 2)));
        }
        [TestMethod]
        public void samepositiontest()
        {
            Assert.AreEqual(true ,MathOperations.sameposition(new Point(1,1),new Point(1,1)));
        }
        [TestMethod]
        public void isdivisiblebybtest()
        {
            Assert.AreEqual(false, MathOperations.isadivisiblebyb(10, 3));
        }
        [TestMethod]
        public void nwdtest()
        {
            Assert.AreEqual(10, MathOperations.nwd(90,100));
        }
        [TestMethod]
        public void isprimetest()
        {
            Assert.AreEqual(true, MathOperations.isprime(11));
        }
        
        [TestMethod]
        public void skalartest()
        {
            CollectionAssert.AreEqual(new int[] { 4, 6, 8 }, MathOperations.skalar(new int[] { 2, 3, 4 }, 2));
        }
      
      
        [TestMethod]
        public void arraddtest()
        {
            // CollectionAssert.AreEqual(
            //    new int[2][] { new int[] { 0, 0 }, new int[] { 0, 0 } },
            //MathOperations.arradd(
            //    new int[2][] { new int[] { 0, 0 }, new int[] { 0, 0 } },
            //    new int[2][] { new int[] { 0, 0 }, new int[] { 0, 0 } })
            //);


         //   CollectionAssert.AreEqual(
         //    new int[] { 0, 0 },
         //MathOperations.arradd(
         //    new int[2][] { new int[] { 0, 0 }, new int[] { 0, 0 } },
         //    new int[2][] { new int[] { 0, 0 }, new int[] { 0, 0 } })[0]
         //);
            CollectionAssert.AreEqual(
             new int[]{ 0, 0 },
         MathOperations.arradd(
             new int[][] { new int[] { 0, 0 }, new int[] { 0, 0 } },
             new int[][] { new int[] { 0, 0 }, new int[] { 0, 0 } })[0]
         );
            

        }
        [TestMethod]
        public void ispliktest()
        {
            Assert.AreEqual(true, MathOperations.isplik("xd.txt"));
        }
        [TestMethod]
        public void stopienzagniezdzeniatest()
        {
            Assert.AreEqual(2,MathOperations.stopienzagniezdzenia("/sa/cascsa"));
        }

    }


}
