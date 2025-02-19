using Comunication.Request;
using Comunication.Response;
using FluentValidation;
using Exceptions;

namespace Application.UseCases.User.Register
{
    public class RegisterUserValidator: AbstractValidator<RequestRegisterUserJson>
    {
        //Constructor
        public RegisterUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(MessagesException.NAME_EMPTY);
            RuleFor(user => user.Email).NotEmpty().WithMessage(MessagesException.EMAIL_EMPTY);
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(MessagesException.PASSWORD_INVALID);
            When(user => string.IsNullOrEmpty(user.Email) == false, () =>
            {
                RuleFor(user => user.Email).EmailAddress().WithMessage(MessagesException.EMAIL_INVALID);
            });
        }
    }
}
