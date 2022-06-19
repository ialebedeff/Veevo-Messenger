using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.BusinessModels;
using Veevo.BLL.Contexts;
using Veevo.BLL.Exceptions;
using Veevo.BLL.Interfaces;
using Veevo.BLL.Models.Database;
using Veevo.BLL.Models.Requests;
using Veevo.BLL.Tools;

namespace Veevo.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;
        public UserService(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }
        public bool VerifyUser(string verificationCode)
        {
            var account = _context.Users.FirstOrDefault(x => x.ConfirmationCode == verificationCode);

            if (account == null)
                return false;

            return account.IsActivated = true;
        }
        public bool IsUserVerified(VerificationRequestModel verificationRequestModel)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == verificationRequestModel.Email);

            return user != null && user.IsActivated;
        }
        public UserDatabaseModel CreateUser(RegistrationRequestModel registrationRequestModel, string role)
        {
            if (GetUserByEmail(registrationRequestModel.Email) != null)
                throw new EmailExistException("Такой Email уже используется.");

            var entry = _context.Users.Add(new UserDatabaseModel()
            {
                CreatedDate = DateTime.UtcNow,
                Role = role,
                Email = registrationRequestModel.Email,
                IsActivated = false,
                Password = registrationRequestModel.Password,
                Username = new UsernameGenerator().GenerateUsername(),
                ConfirmationCode = ConfirmationCodeGenerator.Create(registrationRequestModel.Email)
            });

            return entry.Entity;
        }

        public UserDatabaseModel? GetUserByEmail(string? email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public UserDatabaseModel? GetUserById(int? id)
        {
            return _context.Users.Find(id);
        }

        public UserDatabaseModel? GetUserByUsername(string? username)
        {
            if (string.IsNullOrEmpty(username))
                return null;

            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public bool IsUserExist(string email, string password)
        {
            return _context.Users.Any(x => x.Email == email && x.Password == password);
        }

        public void MakeOnline(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);

            if (user != null)
            {
                user.LastOnline = DateTime.UtcNow;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public UserDatabaseModel UpdateUser(UserDatabaseModel userDatabaseModel)
        {
            throw new NotImplementedException();
        }
    }
}
