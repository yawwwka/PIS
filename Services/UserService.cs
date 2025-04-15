using PIS.Models;
using PIS.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using System;
using PIS.Forms;
using System.Diagnostics;

namespace PIS.Services
{
    public class UserService
    {
        private readonly DatabaseService _databaseService;
        private readonly PasswordHasher _passwordHasher;

        public UserService(DatabaseService databaseService, PasswordHasher passwordHasher)
        {
            _databaseService = databaseService;
            _passwordHasher = passwordHasher;
        }

        public User Authenticate(string email, string password)
        {
            User user = GetUserByEmail(email);
            if (_passwordHasher.VerifyPassword(password, user.Password)) 
            {
                SetUserOnlineStatus(user, true);
                return user;
            }

            return null;
        }

        public bool RegisterUser(User user, out string message)
        {
            if (user == null ||
                string.IsNullOrEmpty(user.Name) ||
                string.IsNullOrEmpty(user.Password) ||
                string.IsNullOrEmpty(user.Email))
            {
                message = "Регистрация не завершена. Не все поля заполнены.";
                return false;
            }
            else if (GetUserByEmail(user.Email) != null)
            {
                message = "Регистрация не завершена. Пользователь с таким Email уже существует.";
                return false;
            }
            else if (user.Password.Length < 8)
            {
                message = "Регистрация не завершена. Пароль слишком короткий.";
                return false;
            }
            _databaseService.AddUser(user); 
            message = "Регистрация завершена успешно!";
            return true;
        }

        public void DeleteUser(User user)
        {
            try
            {
                _databaseService.DeleteUser(user);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to delete user", ex);
            }
        }

        public void ChangeUserRole(User user, UserRole role, ChangeRoleForm form)
        {
            user.Role = role;
            _databaseService.ChangeUserRole(user);
            form.Close();
        }

        public List<User> GetAllUsers() => _databaseService.GetAllUsers();

        public User GetUserByEmail(string email) => GetAllUsers().FirstOrDefault(u => u.Email == email);

        public void SetUserOnlineStatus(User user, bool online)
        {
            user.Online = online;
            _databaseService.SetUserOnlineStatus(user);
        }

        public void UpdateLastActivity(User user) => _databaseService.UpdateLastActivity(user);
    }
}
