using Savings_Tracker.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savings_Tracker.Model
{
    public class Transaction : ITableItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int GoalId { get; set; }

        [ForeignKey("GoalId")]
        public Goal Goal { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}
