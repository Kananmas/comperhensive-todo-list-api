using comperhensive_todo_list_api.Models;
using FluentValidation;
using System.Net.Mail;

namespace comperhensive_todo_list_api.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator() {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("username is required for creating account");
            RuleFor(x => x.Password).NotEmpty()
                .Matches("\\w")
                .WithMessage("password must contain lowercase letters")
                .Matches(".*")
                .WithMessage("password must contain symboles lie @ # '.' ...")
                .Matches("[A-Z]*")
                .WithMessage("please must contain uppercase letters");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("please enter your email")
                .Must(isValidAddress)
                .WithMessage("please enter a valid email");
        }


        private bool isValidAddress(string address)
        {
            try
            {
                MailAddress m = new MailAddress(address);

                return true;
            }
            catch { return false; }
        }
    }
}
