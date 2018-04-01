using Microsoft.EntityFrameworkCore;
using Savings_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savings_Tracker.DataContext
{
    public class GoalDataContext : DbContext
    {
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=GoalTracker.db");
          
        }
    }
}
