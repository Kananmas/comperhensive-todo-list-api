using System.ComponentModel.DataAnnotations.Schema;

namespace comperhensive_todo_list_api.DTO
{
    public class TodoStepDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid TodoId { get; set; }
        public int StepIndex { get; set; }
        public string StepTitle { get; set; }
        public string StepDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
