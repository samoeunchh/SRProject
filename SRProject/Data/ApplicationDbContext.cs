using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SRProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<Brand> Brand { get; set; }
    }
}
