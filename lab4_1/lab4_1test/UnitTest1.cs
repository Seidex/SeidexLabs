using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab4_1test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int R = 90;
            int result = lab4_1.Program.StudentRating(R);
            Assert.AreEqual(3, result);
        }
    }
}
