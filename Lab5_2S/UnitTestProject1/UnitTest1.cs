using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Lab5_2S.Visiting> Test = new List<Lab5_2S.Visiting>();
            for(int i = 0; i < 10; i++)
            {
                Lab5_2S.Visiting Tst = new Lab5_2S.Visiting()
                {
                    Name = "Name" + i,
                    CountOfDownload = i,
                    UnicalHosts = 10 - i,
                    Date = "29.03.202" + i,
                    URL = "www.sameSite" + i + "html",
                  
                };
                Test.Add(Tst);
            }
            float res = Test[0].MaxCountOfDownload(Test);
            Assert.AreEqual(9, res);
        }
        
    }
}
