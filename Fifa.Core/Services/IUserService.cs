﻿using System.Collections.Generic;

using Fifa.Core.Models;

namespace Fifa.Core.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();

        User CreateUser();

        User GetUser(int id);

        void SaveTeam(User user);

        void DeleteUser(User user);

        void CalculateStats(int userId);
    }
}