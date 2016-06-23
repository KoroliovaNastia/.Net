using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Services
{
    public class RoleService:IRoleService
    {
        IUnitOfWork Database { get; set; }

        public RoleService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public RoleDTO GetRole(int? id)
        {
            return Database.Roles.Get(id).ToRoleDto();
        }

        public IEnumerable<RoleDTO> GetRoles()
        {
            return Database.Roles.GetAll().Select(user => user.ToRoleDto());
        }

        public void Dispose()
        {
            Database.Dispose();
        }


        public void CreateNewRole(RoleDTO newRole)
        {
            Database.Roles.Create(newRole.ToRole());
            Database.Save();
        }
    }
}
