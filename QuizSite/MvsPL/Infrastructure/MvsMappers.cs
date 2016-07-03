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

        public static QuestionDTO ToBllQuestion(this QuestionViewModel question)
        {
            return new QuestionDTO()
            {
                TestDtoId = question.TestViewModelId,
                Id = question.Id,
                Formulation = question.Formulation,
                SelectedAnswer = question.SelectedAnswer,
                TrueAnswer = question.TrueAnswer
            };
        }

        public static QuestionViewModel ToMvcQuestion(this QuestionDTO question)
        {
            return new QuestionViewModel()
            {
                TestViewModelId = question.TestDtoId,
                Id = question.Id,
                Formulation = question.Formulation,
                SelectedAnswer = question.SelectedAnswer,
                TrueAnswer = question.TrueAnswer
                
            };
        }

        public static AnswersDTO ToBllAnswers(this AnswerViewModel answers)
        {
            return new AnswersDTO()
            {
                Id = answers.Id,
                //Question = ToBllQuestion(answers.Question),
                QuestionId = answers.QuestionId,
                Text = answers.Text
            };
        }

        public static AnswerViewModel ToMvcAnswers(this AnswersDTO answers)
        {
            return new AnswerViewModel()
            {
                Id = answers.Id,
                //Question = ToMvcQuestion(answers.Question),
                QuestionId = answers.QuestionId,
                Text = answers.Text
            };
        }

        public static UserDTO ToBllUser(this UserViewModel user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Email = user.Email,
                CreationDate = user.CreationDate,
                Password = user.Password,
                //Role = new RoleDTO{Name=user.Role},
                RoleId = user.RoleId

            };
        }

        public static UserViewModel ToMvcUser(this UserDTO user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                CreationDate = user.CreationDate,
                Password = user.Password,
                Role = user.Role.Name,
                RoleId = user.RoleId

            };
        }

        public static RoleDTO ToBllRole(this RoleViewModel role)
        {
            return new RoleDTO()
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static RoleViewModel ToMvcRole(this RoleDTO role)
        {
            return new RoleViewModel()
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static ProfileDTO ToBllProfile(this ProfileViewModel profile)
        {
            return new ProfileDTO()
            {
                Age = profile.Age,
                FirstName = profile.FirstName,
                Id = profile.Id,
                LastName = profile.LastName,
                LastUpdateDate = profile.LastUpdateDate,
                UserId = profile.UserId,
                User = ToBllUser(profile.User)
            };
        }

        public static ProfileViewModel ToMvcProfile(this ProfileDTO profile)
        {
            return new ProfileViewModel()
            {
                Age = profile.Age,
                FirstName = profile.FirstName,
                Id = profile.Id,
                LastName = profile.LastName,
                LastUpdateDate = profile.LastUpdateDate,
                UserId = profile.UserId,
                User = ToMvcUser(profile.User)
            };
        }
    }
}