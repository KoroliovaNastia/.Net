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
    class ProfileService:IProfileService
    {
        IUnitOfWork Database { get; set; }

        public ProfileService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public ProfileDTO GetProfile(int? id)
        {
            return Database.Profiles.Get(id).ToProfileDto();
        }

        public IEnumerable<ProfileDTO> GetProfiles()
        {
            return Database.Profiles.GetAll().Select(user => user.ToProfileDto());
        }

        public void Dispose()
        {
            Database.Dispose();
        }


        public void CreateNewProfile(ProfileDTO newProfile)
        {
            Database.Profiles.Create(newProfile.ToProfile());
            Database.Save();
        }

        public void Update(ProfileDTO profile)
        {
            Database.Profiles.Update(profile.ToProfile());
        }
    }
}
