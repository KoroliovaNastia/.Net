using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IRoleService
    {
        RoleDTO GetRole(int? id);
        void CreateNewRole(RoleDTO role);
        IEnumerable<RoleDTO> GetRoles();
        void Dispose();
    }
}
