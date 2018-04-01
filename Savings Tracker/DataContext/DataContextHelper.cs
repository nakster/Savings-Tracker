﻿using Microsoft.EntityFrameworkCore;
using Savings_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savings_Tracker.DataContext
{
    public class DataContextHelper
    {
        public static async Task AddRecord<T>(T newRecord) where T : class
        {
            using (var db = new GoalDataContext())
            {
                db.Add<T>(newRecord);
                await db.SaveChangesAsync();

                if(typeof(T) == typeof(Transaction))
                {
                    var transaction = newRecord as Transaction;
                    await AddBalance(transaction);
                }

            }

        }

        public static async void UpdateGoal(Goal UpdatedGoal)
        {
            using (var db = new GoalDataContext())
            {
                var goal = db.Goals.FirstOrDefault(x => x.GoalId == UpdatedGoal.GoalId);

                if (goal != null)
                {
                    goal.Name = UpdatedGoal.Name;
                    goal.Notes = UpdatedGoal.Notes;
                    goal.SavingGoal = UpdatedGoal.SavingGoal;
                    await db.SaveChangesAsync();
                }

            }

        }
        //gets all the records
        public static List<T> GetTable<T>() where T : class
        {
            using (var db = new GoalDataContext())
                return db.Set<T>().ToList();
        }

        private static async Task AddBalance(Transaction savedTransaction)
        {
            await Task.Factory.StartNew(async () =>
            {
                using(var db = new GoalDataContext())
                {
                    var goals = await db.Goals.ToListAsync();
                    var goal = goals.SingleOrDefault(x => x.GoalId == savedTransaction.GoalId);

                    goal.Balance += savedTransaction.Amount;

                    await db.SaveChangesAsync();
                }

            });
        }

        //delete all goals
        public static void DeleteAllGoals()
        {
            using(var db = new GoalDataContext())
            {
                foreach (var item in db.Goals)
                {
                    db.Goals.Remove(item);

                    db.SaveChanges();
                }

            }
        }
    }
}
