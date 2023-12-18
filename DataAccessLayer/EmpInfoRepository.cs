using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DataAccessLayer
{
    public class EmpInfoRepository : IEmpInfo
    {

        private readonly BlogDbContext _Db;
        public EmpInfoRepository()
        {
            _Db = new BlogDbContext();
        }
        
        public EmpInfoRepository(BlogDbContext context)
        {
            _Db = context;
        }
        public IEnumerable<EmpInfo> GetAllEmpInfo()
        {
            return _Db.EmpInfo.ToList();
        }

        public void Insert(EmpInfo empInfo)
        {
            _Db.EmpInfo.Add(empInfo);
        }

        public void Save()
        {
           _Db.SaveChanges();
        }
        public void Update(EmpInfo empInfo)
        {
            _Db.Entry(empInfo).State = EntityState.Modified;
        }
        public void Delete(string id)
        {
            EmpInfo found = _Db.EmpInfo.Find(id);
            if (found != null)
            {
                _Db.EmpInfo.Remove(found);
            }
        }
        public bool ValidateEmployeeLogin(string email, int pass)
        {
            return _Db.EmpInfo.Any(e=> e.EmailId==email && e.PassCode==pass);
        }

        public EmpInfo GetEmpInfo(string EmailId)
        {
            return _Db.EmpInfo.Find(EmailId);
        }

        public object GetEmpInfo()
        {
            throw new NotImplementedException();
        }
    }
}
