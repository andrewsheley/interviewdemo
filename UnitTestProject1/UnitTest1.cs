using InterviewDemo.Core.Models;
//using InterviewDemo.Mobile.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //}


        [TestMethod]
        public void FullName()
        {
            var emp = new Employee() {
                LastName = "sheley",
                FirstName = "andy",
            };

            Assert.AreEqual(emp.Fullname(), "sheley, andy", "Values don't match");

        }
    }
}
