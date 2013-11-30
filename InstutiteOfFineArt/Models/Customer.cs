using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstutiteOfFineArt.Models
{
    public class Customer
    {
        public Customer()
        {
            CustomerGender = false;
        }
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime CustomerBirthday { get; set; }
        public string CustomerPhone { get; set; }
        public bool CustomerGender { get; set; }
    }
}