using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
   public class ProfileService:IProfileService
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

       public IEnumerable<ProfileDTO> GetProfilesByNickName(string nickname)
       {
           var users = Database.Users.GetAll().FirstOrDefault(t => t.NickName == nickname);
           var profiles = Database.Profiles.GetAll().Where(u => u.UserId == users.Id);
           var enumerable = profiles as Profile[] ?? profiles.ToArray();
           if (!enumerable.Any())
               return null;
           return enumerable.Select(p=>p.ToProfileDto());
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
