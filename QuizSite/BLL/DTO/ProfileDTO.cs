using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int? UserId { get; set; }

        public virtual UserDTO User { get; set; }
        //public virtual ICollection<Test> MyPassedTest { get; set; }
    }
}
