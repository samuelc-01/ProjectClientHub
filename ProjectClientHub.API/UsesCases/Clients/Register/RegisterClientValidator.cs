using FluentValidation;
using ProjectClientHub.Communication.Requests;
namespace ProjectClientHub.API.UsesCases.Clients.Register
{
    public class RegisterClientValidator :  AbstractValidator<RequestClientJson>
    {
        public RegisterClientValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .Length(2, 50)
                .WithMessage("Name must be between 2 and 50 characters.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");
        }
    } 
}
