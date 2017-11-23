using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User :IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsAdmin { get; set; }
    }
}
