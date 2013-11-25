using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstutiteOfFineArt.Models
{
    public class Painting
    {
        public int Id { get; set; }
        public string PaintingDescription { get; set; }
        public string PaintingURL { get; set; }
        public int Mark { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime LastModify { get; set; }
        public int CompetitionId { get; set; }
        public int StudentId { get; set; }
        public int ExhibitionId { get; set; }
        public int CustomerId { get; set; }
        public string Comment { get; set; }
        public bool IsExhibited { get; set; }
        public int Price { get; set; }
        public bool IsPaid { get; set; }
    }
}