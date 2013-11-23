using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstutiteOfFineArt.Models
{
    public class Exhibition
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}