using System;
using Microsoft.EntityFrameworkCore;

namespace SevenHabitsTodoApp.Models
{
    public class TaskEntryContext : DbContext
    {
        public TaskEntryContext(DbContextOptions<TaskEntryContext> options) : base (options)
        {

        }

        public DbSet<TaskEntry> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(

                new Category { CategoryID = 1, CategoryName = "Home"},
                new Category { CategoryID = 2, CategoryName = "School"},
                new Category { CategoryID = 3, CategoryName = "Work"},
                new Category { CategoryID = 4, CategoryName = "Church"}
            );

            mb.Entity<TaskEntry>().HasData(
                new TaskEntry
                {
                    TaskID = 1,
                    Task = "Finish 455 MLR Project",
                    DueDate = "2022-02-09",
                    Quadrant = 1,
                    CategoryID = 2,
                    Completed = false
                },
                new TaskEntry
                {
                    TaskID = 2,
                    Task = "Wash Dishes",
                    DueDate = "2022-02-11",
                    Quadrant = 2,
                    CategoryID = 2,
                    Completed = false
                },
                new TaskEntry
                {
                    TaskID = 3,
                    Task = "Play Fortnite",
                    DueDate = "2022-02-11",
                    Quadrant = 4,
                    CategoryID = 1,
                    Completed = false
                },
                new TaskEntry
                {
                    TaskID = 4,
                    Task = "Do Ministering",
                    DueDate = "2022-02-06",
                    Quadrant = 2,
                    CategoryID = 4,
                    Completed = true
                },
                new TaskEntry
                {
                    TaskID = 5,
                    Task = "Call Mom back",
                    DueDate = "2022-02-09",
                    Quadrant = 3,
                    CategoryID = 1,
                    Completed = false
                },
                new TaskEntry
                {
                    TaskID = 6,
                    Task = "Deliver new report to manager",
                    DueDate = "2022-02-12",
                    Quadrant = 1,
                    CategoryID = 3,
                    Completed = false
                },
                new TaskEntry
                {
                    TaskID = 7,
                    Task = "Apply for graduation",
                    DueDate = "2022-02-16",
                    Quadrant = 2,
                    CategoryID = 2,
                    Completed = false
                },
                new TaskEntry
                {
                    TaskID = 8,
                    Task = "Go to church",
                    DueDate = "2022-02-13",
                    Quadrant = 2,
                    CategoryID = 4,
                    Completed = false
                },
                new TaskEntry
                {
                    TaskID = 9,
                    Task = "Finish Project 1",
                    DueDate = "2022-02-09",
                    Quadrant = 1,
                    CategoryID = 2,
                    Completed = false
                },
                new TaskEntry
                {
                    TaskID = 10,
                    Task = "Go grocery shopping",
                    DueDate = "2022-02-11",
                    Quadrant = 3,
                    CategoryID = 1,
                    Completed = false
                }
            );
        }
    }
}
