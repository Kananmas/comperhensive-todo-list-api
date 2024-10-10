using System.ComponentModel.DataAnnotations.Schema;

namespace comperhensive_todo_list_api.Models
{
    public class Todo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public string Priority { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public DateTime? EndDate { get; set; } 

        public bool IsDone { get; set; } = false;

        public virtual ICollection<TodoStep>? Steps { get; set; }
        public virtual User User { get; set; }
    }
}
