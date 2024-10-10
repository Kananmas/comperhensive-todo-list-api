using comperhensive_todo_list_api.Models;
using FluentValidation;

namespace comperhensive_todo_list_api.Validators
{
    public class TodoStepValidator:AbstractValidator<TodoStep>
    {

        public TodoStepValidator()
        {
            RuleFor((item) => item.EndDate)
                .GreaterThanOrEqualTo(item => item.StartDate)
                .WithMessage("end date must be set after the start date");
        }
    }
}
