using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acyclic_graph;

namespace Acyclic_graph.Tests
{
    [TestCategory("Checking DFS for correct resolve")]
    [TestClass]
    public class DfsFinderTests
    {
        [TestMethod]
        public void OneVertexGraph()
        {
            List<string> input = new List<string>()
            {
                "1",
                "0"
            };
            List<int> vertexesInCycle = DfsFinder.FindCycle(GraphConverter.CreateGraph(input));
            string result = "";
            if (vertexesInCycle == null)
                result = "A";
            else
            {
                result = "N\r\n";
                vertexesInCycle.ForEach(vertex => result += vertex);
            }
            Assert.AreEqual("A", result);
        }

        [TestMethod]
        public void TwoVertexGraph()
        {
            List<string> input = new List<string>()
            {
                "2",
                "0 1",
                "1 0"
            };
            List<int> vertexesInCycle = DfsFinder.FindCycle(GraphConverter.CreateGraph(input));
            string result = "";
            if (vertexesInCycle == null)
                result = "A";
            else
            {
                result = "N\r\n";
                vertexesInCycle.ForEach(vertex => result += vertex);
            }
            Assert.AreEqual("A", result);
        }

        [TestMethod]
        public void ThreeVertexGraphWithNoCycle()
        {
            List<string> input = new List<string>()
            {
                "3",
                "0 1 0",
                "1 0 1",
                "0 1 0"
            };
            List<int> vertexesInCycle = DfsFinder.FindCycle(GraphConverter.CreateGraph(input));
            string result = "";
            if (vertexesInCycle == null)
                result = "A";
            else
            {
                result = "N\r\n";
                vertexesInCycle.ForEach(vertex => result += vertex);
            }
            Assert.AreEqual("A", result);
        }

        [TestMethod]
        public void ThreeVertexGraphWithCycle()
        {
            List<string> input = new List<string>()
            {
                "3",
                "0 1 1",
                "1 0 1",
                "1 1 0"
            };
            List<int> vertexesInCycle = DfsFinder.FindCycle(GraphConverter.CreateGraph(input));
            string result = "";
            if (vertexesInCycle == null)
                result = "A";
            else
            {
                result = "N\r\n";
                vertexesInCycle.ForEach(vertex => result += vertex);
            }
            Assert.AreEqual("N\r\n123", result);
        }

        [TestMethod]
        public void TaskExampleGraph()
        {
            List<string> input = new List<string>()
            {
                "4",
                "0 1 1 0",
                "1 0 1 0",
                "1 1 0 1",
                "0 0 1 0"
            };
            List<int> vertexesInCycle = DfsFinder.FindCycle(GraphConverter.CreateGraph(input));
            string result = "";
            if (vertexesInCycle == null)
                result = "A";
            else
            {
                result = "N\r\n";
                vertexesInCycle.ForEach(vertex => result += vertex);
            }
            Assert.AreEqual("N\r\n123", result);
        }

        [TestMethod]
        public void BigGraphWithNoCycle()
        {
            List<string> input = new List<string>()
            {
                "10",
                "0 1 0 0 0 0 0 0 0 0",
                "1 0 1 0 0 0 0 0 0 0",
                "0 1 0 1 1 1 0 0 0 0",
                "0 0 1 0 0 0 1 1 0 0",
                "0 0 1 0 0 0 0 0 1 0",
                "0 0 1 0 0 0 0 0 0 1",
                "0 0 0 1 0 0 0 0 0 0",
                "0 0 0 1 0 0 0 0 0 0",
                "0 0 0 0 1 0 0 0 0 0",
                "0 0 0 0 0 1 0 0 0 0"
            };
            List<int> vertexesInCycle = DfsFinder.FindCycle(GraphConverter.CreateGraph(input));
            string result = "";
            if (vertexesInCycle == null)
                result = "A";
            else
            {
                result = "N\r\n";
                vertexesInCycle.ForEach(vertex => result += vertex);
            }
            Assert.AreEqual("A", result);
        }

        [TestMethod]
        public void BigGraphWithManyCycles()
        {
            List<string> input = new List<string>()
            {
                "10",
                "0 1 0 1 0 0 0 1 0 0",
                "1 0 1 0 0 0 0 0 0 0",
                "0 1 0 1 1 1 0 0 0 0",
                "1 0 1 0 0 0 1 1 0 0",
                "0 0 1 0 0 0 0 0 1 1",
                "0 0 1 0 0 0 0 0 0 1",
                "0 0 0 1 0 0 0 1 0 0",
                "1 0 0 1 0 0 1 0 0 0",
                "0 0 0 0 1 0 0 0 0 0",
                "0 0 0 0 1 1 0 0 0 0"
            };
            List<int> vertexesInCycle = DfsFinder.FindCycle(GraphConverter.CreateGraph(input));
            string result = "";
            if (vertexesInCycle == null)
                result = "A";
            else
            {
                result = "N\r\n";
                vertexesInCycle.ForEach(vertex => result += vertex);
            }
            Assert.IsTrue(result.CompareTo("N\r\n1234") == 0
                           || result.CompareTo("N\r\n048") == 0
                           || result.CompareTo("N\r\n0478") == 0
                           || result.CompareTo("N\r\n35610") == 0
                           || result.CompareTo("N\r\n478") == 0
                           || result.CompareTo("N\r\n123478") == 0
                           || result.CompareTo("N\r\n12348") == 0);
        }
    }
}
