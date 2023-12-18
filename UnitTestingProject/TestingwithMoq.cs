using DataAccessLayer;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingProject
{
    [TestFixture]
    public class TestingwithMoq
    {
        [Test]
        public void checkEmployeeExistWithMoq()
        {
            EmpInfo emp = new EmpInfo
            {
                Name = "Abhay",
                EmailId = "abhay@gmail.com",
                PassCode = 12345,
                DateOfJoining = DateTime.Now,
            };
            var fakeObject = new Mock<EmpInfoRepository>();
            fakeObject.Setup(x => x.GetEmpInfo(It.IsAny<string>())).Returns(emp);
            var res = fakeObject.Object.GetEmpInfo("abhay@gmail.com");
            Assert.That(res, Is.EqualTo(emp));
        }
    }
}
