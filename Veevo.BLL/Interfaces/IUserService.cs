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
        /// <summary>
        /// Создать пользователя/аккаунт
        /// </summary>
        /// <param name="registrationRequestModel"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public UserDatabaseModel CreateUser(RegistrationRequestModel registrationRequestModel, string role);
        /// <summary>
        /// Обновить данные об аккаунте
        /// </summary>
        /// <param name="userDatabaseModel"></param>
        /// <returns></returns>
        public UserDatabaseModel UpdateUser(UserDatabaseModel userDatabaseModel);
        /// <summary>
        /// Получение аккаунта по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserDatabaseModel? GetUserById(int? id);
        /// <summary>
        /// Получение пользователя по Username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserDatabaseModel? GetUserByUsername(string? username);
        /// <summary>
        /// Подтверждение аккаунта
        /// </summary>
        /// <param name="verificationCode"></param>
        /// <returns></returns>
        public bool VerifyUser(string verificationCode);
        /// <summary>
        /// Проверка на подтверждение аккаунта
        /// </summary>
        /// <param name="verificationRequestModel"></param>
        /// <returns></returns>
        public bool IsUserVerified(VerificationRequestModel verificationRequestModel);
        /// <summary>
        /// Получить пользователя по Email адресу
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public UserDatabaseModel? GetUserByEmail(string? email);
        /// <summary>
        /// Изменить дату последнего онлайна
        /// </summary>
        /// <param name="email"></param>
        public void MakeOnline(string email);
        /// <summary>
        /// Проверка на существование пользователя по логину и паролю
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsUserExist(string email, string password);
        /// <summary>
        /// Сохранить данные
        /// </summary>
        public void SaveChanges();
    }
}
