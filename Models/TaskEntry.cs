using System;
using System.ComponentModel.DataAnnotations;

namespace SevenHabitsTodoApp.Models
{
    public class TaskEntry
    {
        [Key]
        [Required]
        public int TaskID { get; set; }

        [Required]
        public string Task { get; set; }

        public string DueDate { get; set; }

        [Required]
        [Range(1,4)]
        public int Quadrant { get; set; }

        public bool Completed { get; set; }

        //Build foreign key relationship
        [Required]
        public int CategoryID { get; set; }
        public Category CategoryName { get; set; }
    }
}
