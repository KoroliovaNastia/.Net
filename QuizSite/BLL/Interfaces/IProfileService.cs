using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IProfileService
    {
        ProfileDTO GetProfile(int? id);
        void CreateNewProfile(ProfileDTO profile);
        IEnumerable<ProfileDTO> GetProfiles();
        void Dispose();
        void Update(ProfileDTO profile);
        IEnumerable<ProfileDTO> GetProfilesByNickName(string nickname);
    }
}
