using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BlogInfo
    {
        [Key]
        public string BlogId { get; set; }
       
        public string Title { get; set; }
        public string Subject { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateOfCreation { get; set; }
        public string BlogUrl { get; set; }
        public string EmpEmailId { get; set; }

    }
}
