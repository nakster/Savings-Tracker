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
        public static async void AddRecord<T>(T newRecord) where T : class
        {
            using (var db = new GoalDataContext())
            {
                db.Add<T>(newRecord);
                await db.SaveChangesAsync();

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
    }
}
