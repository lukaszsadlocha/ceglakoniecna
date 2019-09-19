using System;
using CeglaKoniecNa;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CeglaKoniecNa.Test
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void SumIntsInStringTests()
        {
            Assert.AreEqual(Program.SumIntsInString("5 62 ar 11"), 78);
            Assert.AreEqual(Program.SumIntsInString("5"), 5);
            Assert.AreEqual(Program.SumIntsInString("siała baba mak 5 nie wiedziała jak 11"), 16);
            Assert.AreEqual(Program.SumIntsInString("-2 ostatnia spacja "), -2);
            Assert.AreEqual(Program.SumIntsInString("     "), 0);
            Assert.AreEqual(Program.SumIntsInString("-2 -3"), -5);
            Assert.AreEqual(Program.SumIntsInString("50000000 hello 11"), 50000011);
        }

        [TestMethod]
        public void FactorialTests()
        {
            Assert.AreEqual(Program.Factorial(6), 720);
            Assert.AreEqual(Program.Factorial(0), 1);
            Assert.AreEqual(Program.Factorial(1), 1);
            Assert.AreEqual(Program.Factorial(2), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Factorial argument cannot be negative")]
        public void FactorialExeceptionTests()
        {
            Program.Factorial(-1);
        }

        [TestMethod]
        public void ClosestToZeroTests()
        {
            Assert.AreEqual(Program.ClosestToZero(new int[] { 5, 62, 11, 6, -2, 3, 6, 7, 8 }), -2);
            Assert.AreEqual(Program.ClosestToZero(new int[] { 5, 62, 11, 6, -2, 6, 2, 8 }), 2);
            Assert.AreEqual(Program.ClosestToZero(new int[] { 5, 0, 11, 6, -2, 3, 6, 7, 8 }), 0);
            Assert.AreEqual(Program.ClosestToZero(new int[] { 5, 62, 11, 6, -2, 3, 6, 7, -1 }), -1);
            Assert.AreEqual(Program.ClosestToZero(new int[] { 5 }), 5);
        }

        [TestMethod]
        public void FindOddElementTests()
        {
            Assert.AreEqual(Program.FindOddElement(new int[] { 5 }), 5);
            Assert.AreEqual(Program.FindOddElement(new int[] { 5, 5, 2}), 2);
            Assert.AreEqual(Program.FindOddElement(new int[] { -2, 2, -2, 2, 1}), 1);
            Assert.AreEqual(Program.FindOddElement(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5 }), 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "There is no odd element in the table")]
        public void FindOddElementExceptionTests()
        {
            Program.FindOddElement(new int[] { 2, 2, 3, 3, 4, 4, 5, 5, 7, 7, 6, 6 });
        }

        [TestMethod]
        public void FindOddElementVersion2Tests()
        {
            Assert.AreEqual(Program.FindOddElementVersion2(new int[] { 5 }), 5);
            Assert.AreEqual(Program.FindOddElementVersion2(new int[] { 5, 5, 2 }), 2);
            Assert.AreEqual(Program.FindOddElementVersion2(new int[] { -2, 2, -2, 2, 1 }), 1);
            Assert.AreEqual(Program.FindOddElementVersion2(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5 }), 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "There is no odd element in the table")]
        public void FindOddElementVersion2ExceptionTests()
        {
            Program.FindOddElementVersion2(new int[] { 2, 2, 3, 3, 4, 4, 5, 5, 7, 7, 6, 6 });
        }





    }
}
