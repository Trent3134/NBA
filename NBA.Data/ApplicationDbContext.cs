using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {}

        public DbSet<PlayersEntity> Players { get; set; }
        // public DbSet<TeamEntity> Teams { get; set; }
        // public DbSet<StadiumEntity> Stadium { get; set; }
    }
