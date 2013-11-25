using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstutiteOfFineArt.Models
{
    public class Award
    {
        public int Id { get; set; }
        public string AdwardName { get; set; }
        public string AdwardRank { get; set; }
        public string AwardDescription { get; set; }
        public int PaintingId { get; set; }
        public int CompetitionId { get; set; }
    }
}