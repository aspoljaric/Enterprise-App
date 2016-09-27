using MyApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext() : base("name=MyAppConnectionString")
        {
        }

        public System.Data.Entity.DbSet<Student> Students { get; set; }
    }
}
