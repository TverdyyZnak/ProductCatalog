using Domain.Enums;
using Domain.Interfaces;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
namespace Domain.Models
{
    public class User: IEntity
    {
        public Guid Id { get; }
        public string Login {  get; }
        public string Password { get; }
        public bool IsBlocked { get; } = false;
        public Role UserRole { get; }

        private User(Guid id, string login, string password, Role role)
        {
            Id = id;
            Login = login;
            Password = password;
            UserRole = role;
        }

        public static Result<User> Create(Guid id, string login, string password, Role role)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(login)) 
            {
                errors.Add("Логин не может быть пустым");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                errors.Add("Пароль не может быть пустым");
            }

            if (errors.Any())
            {
                return Result<User>.Fail(errors);
            }

            return Result<User>.Success(new User(id, login, password, role));
        }
    }
}
