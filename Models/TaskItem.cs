// backend/TaskManagementApi/Models/TaskItem.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementApi.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        // EF maps bool → bit in SQL Server
        public bool Completed { get; set; }

        // Ensure SQL type = date (no time)
        [Column(TypeName = "date")]
        public DateOnly FromDate { get; set; }

        [Column(TypeName = "date")]
        public DateOnly ToDate { get; set; }
    }
}
