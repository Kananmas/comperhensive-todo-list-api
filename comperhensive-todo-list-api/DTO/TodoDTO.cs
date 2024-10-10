using System.ComponentModel.DataAnnotations.Schema;

namespace comperhensive_todo_list_api.DTO
{
    public class TodoDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public string Priority { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsDone { get; set; } = false;

    }
}
