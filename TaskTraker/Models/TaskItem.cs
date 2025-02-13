using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTraker.Models
{
    public class TaskItem
    {
        
        public int Id { get; set; }
        public string Description { get; set; }
        public Status TaskStatus { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public enum Status
        {
            Todo,
            InProgress,
            Done
        }
    }
}
