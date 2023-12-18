using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AdminInfo
    {
        [Key]
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
