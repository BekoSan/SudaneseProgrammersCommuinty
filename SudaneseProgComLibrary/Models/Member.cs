using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SudaneseProgComLibrary.Models
{
    public class Member
    {
        public int Id { get; set; }

        [BsonId]
        public Guid _id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Job")]
        public string Job { get; set; }
    }
}