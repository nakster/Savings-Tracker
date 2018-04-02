using Microsoft.EntityFrameworkCore;
using Savings_Tracker.Interfaces;
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

        public static async Task UpdateGoal(Goal UpdatedGoal)
        {
            using (var db = new GoalDataContext())
            {
                var goals = await db.Goals.ToListAsync();
                var goal = goals.FirstOrDefault(x => x.GoalId == UpdatedGoal.GoalId);

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

        public static List<Transaction> GetTransactionByGoalId(int goalId)
        {
            using(var db = new GoalDataContext())
            {
                return db.Set<Transaction>().Where(x => x.GoalId == goalId).ToList();
            }
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

        public static T GetItem<T>(int id) where T : class
        {
            var item = default(T);
            using (var db = new GoalDataContext())
            {
               item = db.Set<T>().ToList().FirstOrDefault(x => ((ITableItem)x).GetId() == id);
            }

            return item;
        }

        public async static Task DeleteItem<T>(T itemToDelete) where T : class
        {
            using (var db = new GoalDataContext())
            {
                db.Set<T>().Remove(itemToDelete);
                await db.SaveChangesAsync();

            }
        }
    }
}
