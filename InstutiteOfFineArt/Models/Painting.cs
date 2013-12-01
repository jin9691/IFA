using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstutiteOfFineArt.Models
{
    public class Painting
    {
        public const string MARK_BAD = "Bad";
        public const string MARK_Normal = "Normal";
        public const string MARK_GOOD = "Good";
        public const string MARK_BEST = "Best";
        public Painting()
        {
            Mark = 0;
            UploadDate = DateTime.Now;
            IsExhibited = false;
            Price = 0;
            IsPaid = false;
        }
        public int Id { get; set; }
        public string PaintingDescription { get; set; }
        public string PaintingURL { get; set; }
        public int Mark { get; set; }
        public DateTime UploadDate { get; set; }
        public int CompetitionId { get; set; }
        public int StudentId { get; set; }
        public int ExhibitionId { get; set; }
        public int CustomerId { get; set; }
        public string Comment { get; set; }
        public bool IsExhibited { get; set; }
        public int Price { get; set; }
        public bool IsPaid { get; set; }
        public DateTime LastModify { get; set; }
    }
}