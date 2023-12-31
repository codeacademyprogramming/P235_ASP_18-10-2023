﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P235AllupDb.Models
{
    public class AppUser : IdentityUser
    {
        [NotMapped]
        public IList<string> Roles { get; set; }
        public bool IsActive { get; set; }
        [StringLength(255)]
        public string? Name { get; set; }
        [StringLength(255)]
        public string? SurName { get; set; }

        public IEnumerable<Address>? Addresses { get; set; }
        public IEnumerable<Basket>? Baskets { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
    }
}
