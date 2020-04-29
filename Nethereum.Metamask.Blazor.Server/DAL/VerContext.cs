using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nethereum.Metamask.Blazor.Server.DB_Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.EntityFrameworkCore;

namespace Nethereum.Metamask.Blazor.Server.DAL
{
    public class VerContext : DbContext
    {

        public VerContext(DbContextOptions<VerContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<PdfInfo>().HasOne(e => e.diploma);
        }
        public DbSet<Diploma_model> Diploma { get; set; }
        public DbSet<PdfInfo> pdfInfos { get; set; }


    }
}
