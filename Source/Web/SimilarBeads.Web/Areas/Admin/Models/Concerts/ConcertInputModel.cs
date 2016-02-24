namespace SimilarBeads.Web.Areas.Admin.Models.Concerts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ConcertInputModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime Date { get; set; }
    }
}
