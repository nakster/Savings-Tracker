using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Savings_Tracker.DataContext;

namespace Savings_Tracker.Migrations
{
    [DbContext(typeof(GoalDataContext))]
    partial class GoalDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5");

            modelBuilder.Entity("Savings_Tracker.Model.Goal", b =>
                {
                    b.Property<int>("GoalId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<decimal>("SavingGoal");

                    b.HasKey("GoalId");

                    b.ToTable("Goal");
                });

            modelBuilder.Entity("Savings_Tracker.Model.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int>("GoalId");

                    b.HasKey("Id");

                    b.HasIndex("GoalId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Savings_Tracker.Model.Transaction", b =>
                {
                    b.HasOne("Savings_Tracker.Model.Goal", "Goal")
                        .WithMany("Transactions")
                        .HasForeignKey("GoalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
