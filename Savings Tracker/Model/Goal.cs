using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savings_Tracker.Model
{
    //make it public so you can access it 
    [Table("Goal")]
    public class Goal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SavingGoal { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }
    }
}
