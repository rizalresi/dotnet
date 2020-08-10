using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coba.model
{
    public class KelasContext : DbContext
    {
        public KelasContext(DbContextOptions<KelasContext> options)
            : base(options)
        {

        }

        public DbSet<KelasItem> KelasItems { get; set; }
    }
}
