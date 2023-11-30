using ApiFilesIT.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiFilesIT.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
    }
}
