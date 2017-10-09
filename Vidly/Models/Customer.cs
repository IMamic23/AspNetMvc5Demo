using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Min18YearsIfAMember]
        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public DateTime LastUpdateDate { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }


        [ForeignKey("MembershipTypeId")]
        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}