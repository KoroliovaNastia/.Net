using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvsPL.Models
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int? UserId { get; set; }

        public virtual UserViewModel User { get; set; }
        //public virtual ICollection<Test> MyPassedTest { get; set; }
    }
}