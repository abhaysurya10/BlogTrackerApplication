using DataAccessLayer;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingProject
{
    [TestFixture]
    public class CheckEmployeeTest
    {
        [Test]
        public void checkEmployeeExist()
        {
            var obj=new EmpInfoRepository(new BlogDbContext());
            var res = obj.GetEmpInfo("abhay@gmail.com");
            Assert.That(res, Is.Not.Null);
        }
        [Test]
        public void checkEmployeeCreate()
        {
            EmpInfo emp = new EmpInfo
            {
                Name = "Surya",
                EmailId = "surya@gmail.com",
                PassCode = 123456,
                DateOfJoining = DateTime.Now,
            };
            var obj = new BlogDbContext();
            EmpInfo res = obj.EmpInfo.Add(emp);
            obj.SaveChanges();
            ClassicAssert.AreEqual(emp.Name, res.Name);
            ClassicAssert.AreEqual(emp.EmailId, res.EmailId);
        }
    }
}
