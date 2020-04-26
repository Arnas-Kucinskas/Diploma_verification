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

        public DbSet<Diploma_model> Diploma { get; set; }



    }
}
