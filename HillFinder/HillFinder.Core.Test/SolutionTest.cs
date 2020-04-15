using HillFinder.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HillFinder.Core.Test
{
    [TestClass]
    public class SolutionTest
    {
        private Solution solution = new Solution();

        [TestMethod]
        public void TestExample()
        {
            int[] a = new int[] { 1, 6, 4, 5, 4, 5, 1, 2, 3, 4, 7, 2 };
            Assert.AreEqual(3, solution.GetSolution(a));
        }

        [TestMethod]
        public void TestWithoutValues()
        {
            int[] a = new int[0];
            Assert.AreEqual(0, solution.GetSolution(a));
        }
    }
}
