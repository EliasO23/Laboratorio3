using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio3
{
    public class Context: DbContext
    {
        public DbSet<facultades> facultades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-GKE3OSON\\SQLEXPRESS;Database=lab3;Trusted_Connection=SSPI;MultipleActiveResultSets=True;TrustServerCertificate=True;");
        }
    }
}
