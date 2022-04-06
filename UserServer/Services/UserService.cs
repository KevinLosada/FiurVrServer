using System;
using System.Collections.Generic;
using UserServer.Data;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
using SharedLibrary;

namespace UserServer.Services
{
    public class UserService
    {
        public void CreateUser(string username)
        {
            Database._database.Add(username, new User());
            Database._database[username].username = username;
        }

        public List<User> GetAll()
        {
            List<User> users = Database._database.Values.ToList();
            return users;
        }

        public User GetUser(string username)
        {
            return Database._database[username];
        }

        public User UpdateInventory(string username, int item, int quantity)
        {
            Database._database[username].inventory[item] = quantity;
            return Database._database[username];
        }

        public void DeleteUser(string username)
        {
            Database._database.Remove(username);
            Console.WriteLine("User deleted");
        }

        public User UpdatePreferences(string username, int head, int skin, int face, int hair, int color)
        {
            Database._database[username].headPref = head;
            Database._database[username].skinPref = skin;
            Database._database[username].facePref = face;
            Database._database[username].hairPref = hair;
            Database._database[username].hairColorPref = color;

            return Database._database[username];
        }
    }
}