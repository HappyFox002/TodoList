using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TESTEfCore.Models
{
    [Index("Name", IsUnique = true, Name = "uName")]
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Purpose> Purposes { get; set; } = new();
    }
}
