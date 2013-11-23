using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstutiteOfFineArt.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
    }
}