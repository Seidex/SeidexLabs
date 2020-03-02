using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab1test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int a = 654;
            int result = lab1.Program.Example(a);
            Assert.AreEqual(456, result);
        }
    }
}