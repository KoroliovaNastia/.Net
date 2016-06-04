using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Infrastructure
{
    public static class BLLMappers
    {
        public static TestDTO ToTestDto(this Test test)
        {
            return new TestDTO()
            {
                Category = test.Category,
                DateOfPublication = test.DateOfPublication,
                Id=test.Id,
                ShortDescription = test.ShortDescription,
                TimeToComplete = test.TimeToComplete,
                Title = test.Title
            };
        }

        public static Test ToTest(this TestDTO test)
        {
            return new Test()
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
