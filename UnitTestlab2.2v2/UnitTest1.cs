using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestlab2._2v2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] arr = new int[5] { 7, -1, 8, 9, -4 };
            int n = 5;
            int res = lab2._2v2.Program.negCount(arr, n);
            Assert.AreEqual(2, res);
        }
    }
}
