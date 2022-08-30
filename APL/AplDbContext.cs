using APL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APL
{
    public class AplDbContext : DbContext
    {
        public DbSet<Club> clubs { get; set; }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Player> Players { get; set; }


        public AplDbContext(DbContextOptions<AplDbContext> options) : base(options)
        {
            //DbContextOptions<AplDbContext> - конфігуратор, типізований типом даного класу - AplDbContext

            Database.EnsureCreated(); // метод створює БД у разі ії відсутності // рядок до БД підключається у файлі appsettings.json
        }

    }
}
