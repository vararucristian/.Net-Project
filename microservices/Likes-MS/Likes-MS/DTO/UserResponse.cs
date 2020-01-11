using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Likes_MS.DTO
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public object ImagePath { get; set; }
    }

    public class UserResponse
    {
        public string Token { get; set; }
        public bool succes { get; set; }
        public User user { get; set; }
    }
}
