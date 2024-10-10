using comperhensive_todo_list_api.Models;
using FluentValidation;

namespace comperhensive_todo_list_api.Validators
{
    public class TodoValidator:AbstractValidator<Todo>
    {
        public TodoValidator() {

            RuleFor((item) => item.PlannedEndDate)
                .NotEmpty()
                .WithMessage("planned end date is not set for this task")
                .GreaterThanOrEqualTo(item => item.StartDate)
                .WithMessage("planned end date must be set after the start date");

            RuleFor((item) => item)
             .Must(isValidEndDate)
             .WithMessage("end date must be set after the start date");
        }


        private bool isValidEndDate(Todo item)
        {
           if (item.EndDate == null) return true;
           if(item.EndDate < item.StartDate) { return false; }
           return true;
        }
    }
}
