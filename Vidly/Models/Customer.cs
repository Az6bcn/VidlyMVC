using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewLetter { get; set; }


        public MemberShipType MembershipType { get; set; } // Navigation Property
        /* I specify my FK: prevents EF from createing FK property for me automatically (which will be MembershipType_Id), Also will be able to add the MembershipTypeID when creating a new customer. With the navigation property only was in possible. */
        [Display(Name="Membership Type")]
        public int MembershipTypeId { get; set; }

        [Min18YearsIfAMember]
        public DateTime? Birthdate { get;  set; }
    }
}