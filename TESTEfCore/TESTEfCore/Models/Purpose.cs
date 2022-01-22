using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace TESTEfCore.Models
{
    public enum PurposeStatus { 
        CurrentTask = 0,
        OverdueTask,
        CompletedTask
    }

    [Index("Header", IsUnique = true, Name = "uHeader")]
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
