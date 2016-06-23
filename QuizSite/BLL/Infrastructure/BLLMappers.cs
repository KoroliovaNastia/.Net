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
                Title = test.Title,
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

        public static QuestionDTO ToQuestionDto(this Question question)
        {
            return new QuestionDTO()
            {
                TestDtoId=question.TestId,
                Id = question.Id,
                Formulation = question.Formulation,
                SelectedAnswer = question.SelectedAnswer,
                TrueAnswer =ToAnswersDto( question.TrueAnswer)
            };
        }

        public static Question ToQuestion(this QuestionDTO question)
        {
            return new Question()
            {
                TestId = question.TestDtoId,
                Id = question.Id,
                Formulation = question.Formulation,
                SelectedAnswer = question.SelectedAnswer,
                TrueAnswer = ToAnswers(question.TrueAnswer)
            };
        }

        public static AnswersDTO ToAnswersDto(this Answers answers)
        {
            return new AnswersDTO()
            {
                Id = answers.Id,
                Question = ToQuestionDto(answers.Question),
                QuestionId = answers.QuestionId,
                Text = answers.Text
            };
        }

        public static Answers ToAnswers(this AnswersDTO answers)
        {
            return new Answers()
            {
                Id = answers.Id,
                Question = ToQuestion(answers.Question),
                QuestionId = answers.QuestionId,
                Text = answers.Text
            };
        }

        public static UserDTO ToUserDto(this User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Email=user.Email,
                CreationDate=user.CreationDate,
                Password = user.Password,
                Role = ToRoleDto(user.Role),
                RoleId=user.RoleId
                
            };
        }

        public static User ToUser(this UserDTO user)
        {
            return new User()
            {
                Id = user.Id,
                Email = user.Email,
                CreationDate = user.CreationDate,
                Password = user.Password,
                Role = ToRole(user.Role),
                RoleId = user.RoleId
            };
        }

        public static RoleDTO ToRoleDto(this Role role)
        {
            return new RoleDTO()
            {
                Id = role.Id,
                Name=role.Name
            };
        }

        public static Role ToRole(this RoleDTO role)
        {
            return new Role()
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static ProfileDTO ToProfileDto(this Profile profile)
        {
            return new ProfileDTO()
            {
                Age = profile.Age,
                FirstName = profile.FirstName,
                Id = profile.Id,
                LastName = profile.LastName,
                LastUpdateDate = profile.LastUpdateDate,
                UserId = profile.UserId,
                User = ToUserDto(profile.User)
            };
        }

        public static Profile ToProfile(this ProfileDTO profile)
        {
            return new Profile()
            {
                Age = profile.Age,
                FirstName = profile.FirstName,
                Id = profile.Id,
                LastName = profile.LastName,
                LastUpdateDate = profile.LastUpdateDate,
                UserId = profile.UserId,
                User = ToUser(profile.User)
            };
        }
    }
}
