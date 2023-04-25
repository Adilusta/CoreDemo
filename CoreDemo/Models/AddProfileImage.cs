using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class AddProfileImage
    {
        [Key]
        public int WriterID { get; set; }
        [MaxLength(30)]
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public string WriterMail { get; set; }
        [DataType(DataType.Password)]
        public string WriterPassword { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public bool WriterStatus { get; set; }
    }
}
