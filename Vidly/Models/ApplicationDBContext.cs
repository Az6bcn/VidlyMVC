﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MemberShipType> MembershipTypes {get; set;}
        public DbSet<MovieGenre> Genres { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}