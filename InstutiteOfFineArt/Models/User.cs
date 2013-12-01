using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstutiteOfFineArt.Models
{
    public class User
    {
        public const int ROLE_ADMIN = 0;
        public const int ROLE_STAFF = 1;
        public const int ROLE_MANEGE = 2;
        public const int ROLE_STUDENT = 3;

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public int Permission { get; set; }
        public bool Gender { get; set; }
    }
}