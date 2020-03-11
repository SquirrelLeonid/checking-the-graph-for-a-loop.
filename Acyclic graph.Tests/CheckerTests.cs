using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acyclic_graph.Tests
{
    [TestCategory("Is checking for correct data works correct?")]
    [TestClass]
    public class CheckerTests
    {
        [TestMethod]
        public void NullMatrix()
        {
            List<string> input = null;
            Assert.AreEqual(false, Checker.CheckInputData(input));
        }

        [TestMethod]
        public void NotEnoughStrings()
        {
            List<string> input = new List<string>();
            Assert.AreEqual(false, Checker.CheckInputData(input));
        }

        [TestMethod]
        public void VertexCountIsNotNumber()
        {
            string[] input = new string[3]
            {
                "two",
                "0 1",
                "1 0"
            };
            Assert.AreEqual(false, Checker.CheckInputData(input.ToList()));
        }

        [TestMethod]
        public void IncorrectStringLength()
        {
            string[] input = new string[]
            {
                "3",
                "0 1 1",
                "1 0",
                "1 1 1"
            };
            Assert.AreEqual(false, Checker.CheckInputData(input.ToList()));
        }

        [TestMethod]
        public void IncorrectMatrixSize()
        {
            string[] input = new string[]
            {
                "3",
                "0 1",
                "1 0"
            };
            Assert.AreEqual(false, Checker.CheckInputData(input.ToList()));
        }

        [TestMethod]
        public void CorrectData()
        {
            string[] input = new string[]
            {
                "4",
                "0 1 1 0",
                "1 0 1 0",
                "1 1 0 1",
                "0 0 1 0"
            };
            Assert.AreEqual(true, Checker.CheckInputData(input.ToList()));
        }
    }
}
