using Application.UseCases.User.Register;
using CommonTestUtilities.Requests;
using Exceptions;

namespace Validators.Test.User.Register
{
    public class RegisterUserUseCaseTest
    {
        [Fact]
        public void Success()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();

            var result = validator.Validate(request);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void Error_Name_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = string.Empty;

            var result = validator.Validate(request);

            Assert.False(result.IsValid);

            //need recive only one error
            Assert.Single(result.Errors);
            Assert.Contains(MessagesException.NAME_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_Email_empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Email = string.Empty;

            var result = validator.Validate(request);

            Assert.False(result.IsValid);

            //need recive only one error
            Assert.Single(result.Errors);
            Assert.Contains(MessagesException.EMAIL_EMPTY, result.Errors[0].ErrorMessage);
        }
    }
}
