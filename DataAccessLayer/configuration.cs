using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BlogStart
    {
        public BlogStart()
        {
            BlogDbContext context = new BlogDbContext();
            DALContextInit contextInit = new DALContextInit();
            contextInit.InitializeDatabase(context);
        }
    }
}
