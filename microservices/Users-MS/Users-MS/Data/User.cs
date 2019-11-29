﻿using System;

namespace Users_Ms.Data
{
    public class User
    {
        public Guid Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string UserName { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        private User()
        {

        }

        public static User Create(string firstName, string lastName, string userName, string email, string password)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Email = email,
                Password = password

            };
        }

    }
}