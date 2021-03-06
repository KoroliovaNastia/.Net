﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvsPL.Models
{
    public class LogOnViewModel
    {
        [Required]
        [Display(Name = "Yuor NickName if you have")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your e-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [DataType(DataType.Password)]
        [Display(Name = "Enter your password")]
        public string Password { get; set; }

        [Display(Name = "Remember password?")]
        public bool RememberMe { get; set; }
    }
}