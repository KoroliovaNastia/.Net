using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUser(int? id);
        UserDTO GetUserByEmail(string email);
        void CreateNewUser(UserDTO user);
        IEnumerable<UserDTO> GetUsers();
        void Dispose();
        UserDTO GetUserByNick(string nickname);
    }
}
