using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvsPL.Models
{
    public class UserViewModel
    {
       public int Id { get; set; }

        [Display(Name = "User's e-mail")]
        public string Email { get; set; }
        public string Password { get; set; }

        [Display(Name = "Date of user's registration")]
        public DateTime CreationDate { get; set; }

        [Display(Name="User's NickName")]
        public string NickName { get; set; }
        public int? RoleId { get; set; }

        [Display(Name = "User's role in the system")]
        public string Role { get; set; }

        //public virtual RoleViewModel Role { get; set; }
        public IEnumerable<int> MyAnswersId { get; set; }
    }
}