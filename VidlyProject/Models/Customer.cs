using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
    public class Customer
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribeToNewsModel { get; set; }
      
        public MembershipType MembershipType { get; set; }

        [Display(Name ="Birth Date")]
        [Min18YearsOldIfAMember]
        public DateTime? BirthDay { get; set; }


        [Display(Name = "MemberShip Type")]
        public int MembershipTypeId { get; set; }
    }
}