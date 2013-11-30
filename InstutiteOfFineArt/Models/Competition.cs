using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstutiteOfFineArt.Models
{
    public class Competition
    {
        public Competition()
        {
            StartDate = DateTime.Now;
        }

        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Topic { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string CompetitionDescription { get; set; }
        public string Condition { get; set; }
        public string Remark { get; set; }
    }
}