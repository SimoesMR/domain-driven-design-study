using Application.UseCases.User.Register;
using CommonTestUtilities.Requests;
using Exceptions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

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
        public void Error_Email_Empty()
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

        [Fact]
        public void Error_Email_Invalid()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Email = "email.com";

            var result = validator.Validate(request);

            Assert.False(result.IsValid);

            //need recive only one error
            Assert.Single(result.Errors);
            Assert.Contains(MessagesException.EMAIL_INVALID, result.Errors[0].ErrorMessage);
        }

        //because the password is a string, the validation is done by the length of the string
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Error_Password_Invalid(int passwordLenght)
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build(passwordLenght);
            var result = validator.Validate(request);

            Assert.False(result.IsValid);

            //need recive only one error
            Assert.Single(result.Errors);
            Assert.Contains(MessagesException.PASSWORD_INVALID, result.Errors[0].ErrorMessage);
        }
    }
}
