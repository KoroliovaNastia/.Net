using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using System.Web.Security;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;

namespace MvsPL.Providers
{
    public class CustomRoleProvider:RoleProvider
    {
         public IUserService UserService
         {
             get { return (IUserService) DependencyResolver.Current.GetService(typeof (IUserService)); }
         }

        public IRoleService RoleService
        {
            get { return (IRoleService) DependencyResolver.Current.GetService(typeof (IRoleService)); }
        }

        public override bool IsUserInRole(string nickname, string roleName)
        {

            UserDTO user = UserService.GetUsers().FirstOrDefault(u => u.NickName == nickname);

            if (user == null) return false;

            RoleDTO userRole = RoleService.GetRole(user.RoleId);

            if (userRole != null && userRole.Name == roleName)
            {
                return true;
            }

            return false;
        }

        public override string[] GetRolesForUser(string nickname)
        {
            //using (var usRep = new User())
            //{
            //    var roles = new string[] {};
            //    //var user = context.Users.FirstOrDefault(u => u.Email == email);

               

                var roles = new string[] {};
                var user=UserService.GetUserByNick(nickname);
                 if (user == null) return roles;
                var userRole = user.Role;
                if (userRole != null)
                {
                    roles = new string[] {userRole.Name};
                }
                return roles;
            //}
        }

        public override void CreateRole(string roleName)
        {
            var newRole = new RoleDTO() {Name = roleName};
            RoleService.CreateNewRole(newRole);
            //using (var context = new UserService())
            //{
            //    context.Roles.Add(newRole);
            //    context.SaveChanges();
            //}
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }

    }
}