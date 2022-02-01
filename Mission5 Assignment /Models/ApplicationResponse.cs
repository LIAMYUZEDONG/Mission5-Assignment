using System;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class ApplicationResponse
    {

        [Key]

        [Required]

        public int ApplicationId { get; set; }


        // Build Foregin Key Relationship
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Year filed is required")]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public string Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25, ErrorMessage = "25 characters limited")]
        public string Notes { get; set; }



}
}
