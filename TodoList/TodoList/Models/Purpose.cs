using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public enum PurposeStatus {
        CurrentTask = 0,
        OverdueTask,
        CompletedTask
    }

    [Index(new string[]{"Header", "TaskId"}, IsUnique = true, Name = "uPurpose")]
    public class Purpose
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Header { get; set; }
        public string? Text { get; set; }
        [Required]
        public PurposeStatus Status { get; set; }
        public DateTime CreateTime  { get; set; }
        public DateTime EndTime { get; set; }
        public int TaskId { get; set; }
        public Task? Task { get; set; }
    }
}
