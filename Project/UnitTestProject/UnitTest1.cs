using System;
using System.Diagnostics;
using Lab_1.Model.Calculators.SimulationTask;
using Lab_1.Model.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FactTest6()
        {
            double result = MathUtils.Fact(3);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void FactTest1()
        {
            double result = MathUtils.Fact(0);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FactTest2()
        {
            double result = MathUtils.Fact(2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void FactTest5()
        {
            double result = MathUtils.Fact(5);
            Assert.AreEqual(120, result);
        }

        [TestMethod]
        public void RandomTest()
        {
            for (int i = 0; i < 100; i++)
            {
                Debug.Write(RandomEvent.Instance.Occured(0.01) ? "1": "0");
            }
            
        }
    }
}
