using System;
using System.Collections.Generic;
using System.Linq;
using DotNet5MvcJwtAuth.Models;

namespace DotNet5MvcJwtAuth.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>
            {
                new () {Id = 1, UserName = "batman", Password = "batman", Role = "manager"},
                new () {Id = 2, UserName = "robin", Password = "robin", Role = "employee"}
            };
            return users.FirstOrDefault(x => x.UserName == username && x.Password == password);
        }
    }
}