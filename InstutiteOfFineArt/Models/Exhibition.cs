using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstutiteOfFineArt.Models
{
    public class Exhibition
    {
        public Exhibition()
        {
            StartDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public string ExhibitionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ExhibitionDescription { get; set; }
    }
}