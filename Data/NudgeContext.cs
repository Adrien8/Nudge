using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nudge.Models;

    public class NudgeContext : DbContext
    {
        public NudgeContext (DbContextOptions<NudgeContext> options)
            : base(options)
        {
        }

        public DbSet<Nudge.Models.Personne> Personne { get; set; }

        public DbSet<Nudge.Models.Trophee> Trophee { get; set; }

        public DbSet<Nudge.Models.Defi> Defi { get; set; }
    }
