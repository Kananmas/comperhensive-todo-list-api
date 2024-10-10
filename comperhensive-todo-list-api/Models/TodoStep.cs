using System.ComponentModel.DataAnnotations.Schema;

namespace comperhensive_todo_list_api.Models
{
    public class TodoStep
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey("TodoId")]
        public Guid TodoId { get; set; }
        public int StepIndex { get; set; }
        public string StepTitle { get; set; }
        public string StepDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Todo Todo { get; set; }
    }
}
