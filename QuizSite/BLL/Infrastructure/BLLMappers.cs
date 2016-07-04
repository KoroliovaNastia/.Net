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
            if (test == null)
                return null;
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

        public static QuestionDTO ToQuestionDto(this Question question)
        {
            if (question == null)
                return null;
            return new QuestionDTO()
            {
                TestDtoId=question.TestId,
                Id = question.Id,
                Formulation = question.Formulation,
                SelectedAnswer = question.SelectedAnswer,
                TrueAnswer =question.TrueAnswer
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
                TrueAnswer = question.TrueAnswer
            };
        }

        public static AnswersDTO ToAnswersDto(this Answers answers)
        {
            if (answers == null)
                return null;
            return new AnswersDTO()
            {
                Id = answers.Id,
                //Question = ToQuestionDto(answers.Question),
                QuestionId = answers.QuestionId,
                Text = answers.Text
            };
        }

        public static Answers ToAnswers(this AnswersDTO answers)
        {
            return new Answers()
            {
                Id = answers.Id,
                //Question = ToQuestion(answers.Question),
                QuestionId = answers.QuestionId,
                Text = answers.Text
            };
        }

        public static UserDTO ToUserDto(this User user)
        {
            if (user == null)
                return null;
            return new UserDTO()
            {
                Id = user.Id,
                Email=user.Email,
                CreationDate=user.CreationDate,
                Password = user.Password,
                Role = ToRoleDto(user.Role),
                RoleId=user.RoleId,
                MyAnswersId = user.MyAnswersId
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
                RoleId = user.RoleId,
                MyAnswersId = user.MyAnswersId
            };
        }

        public static RoleDTO ToRoleDto(this Role role)
        {
            if (role == null)
                return null;
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
            if (profile == null)
                return null;
            return new ProfileDTO()
            {
                Age = profile.Age,
                FirstName = profile.FirstName,
                Id = profile.Id,
                LastName = profile.LastName,
                LastUpdateDate = profile.LastUpdateDate,
                UserId = profile.UserId,
               // User = ToUserDto(profile.User)
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
               // User = ToUser(profile.User)
            };
        }
    }
}
