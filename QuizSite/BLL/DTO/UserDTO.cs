﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public DateTime CreationDate { get; set; }
        public int? RoleId { get; set; }
        public virtual RoleDTO Role { get; set; }
        public IEnumerable<int> MyAnswersId { get; set; }
    }
}
