using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Models.Database;
using Veevo.BLL.Models.Requests;

namespace Veevo.BLL.Interfaces
{
    public interface IUserService
    {
        public UserDatabaseModel CreateUser(RegistrationRequestModel registrationRequestModel, string role);
        public UserDatabaseModel UpdateUser(UserDatabaseModel userDatabaseModel);
        public UserDatabaseModel? GetUserById(int? id);
        public UserDatabaseModel? GetUserByUsername(string? username);
        public bool VerifyUser(string verificationCode);
        public bool IsUserVerified(VerificationRequestModel verificationRequestModel);
        public UserDatabaseModel? GetUserByEmail(string? email);
        public void MakeOnline(string email);
        public bool IsUserExist(string email, string password);
        public void SaveChanges();
    }
}
