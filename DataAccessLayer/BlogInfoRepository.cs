using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{
    public class BlogInfoRepository : IBlogInfo
    {
        private readonly BlogDbContext _Db;

        public BlogInfoRepository()
        {
            _Db = new BlogDbContext();
        }

        public BlogInfoRepository(BlogDbContext context) 
        {
            _Db = context;
        }
        public IEnumerable<BlogInfo> GetAllBlogInfo()
        {
            return _Db.BlogInfo.ToList();
        }
        public void Save()
        {
            _Db.SaveChanges();
        }
        public BlogInfo GetBlogId(string id)
        {
           return  _Db.BlogInfo.Find(id);
        }
        public IEnumerable<BlogInfo> GetUserBlog(string email) 
        {
            return _Db.BlogInfo.Where(u => u.EmpEmailId.Contains(email)).ToList();
        }

     
        public void Insert(BlogInfo blogInfo)
        {
            _Db.BlogInfo.Add(blogInfo);
        }

        public void Update(BlogInfo blogInfo)
        {
            _Db.Entry(blogInfo).State = EntityState.Modified;
        }
        public void Delete(string id)
        {
            BlogInfo found = _Db.BlogInfo.Find(id);
            if (found != null)
            {
                _Db.BlogInfo.Remove(found);
            }
        }
    }
}
