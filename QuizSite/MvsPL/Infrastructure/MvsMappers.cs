using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DTO;
using MvsPL.Models;

namespace MvsPL.Infrastructure
{
    public static class MvsMappers
    {
        public static TestViewModel ToMvcTest(this TestDTO test)
        {
            return new TestViewModel()
            {
                Category = test.Category,
                DateOfPublication = test.DateOfPublication,
                Id = test.Id,
                ShortDescription = test.ShortDescription,
                TimeToComplete = test.TimeToComplete,
                Title = test.Title

            };
        }
        public static TestDTO ToBllTest(this TestViewModel test)
        {
            return new TestDTO()
            {
                Category = test.Category,
                DateOfPublication = test.DateOfPublication,
                Id = test.Id,
                ShortDescription = test.ShortDescription,
                TimeToComplete = test.TimeToComplete,
                Title = test.Title

            };
        }
    }
}