using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.Models;

namespace HospitalManagement.Data
{
    public class HospitalManagementContext : DbContext
    {
        public HospitalManagementContext (DbContextOptions<HospitalManagementContext> options)
            : base(options)
        {
        }

        public DbSet<HospitalManagement.Models.User> User { get; set; } = default!;
    }
}
