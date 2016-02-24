namespace SimilarBeads.Web.ViewModels.Concert
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ConcertInputModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }
    }
}
