using Application.UseCases.User.Register;
using CommonTestUtilities.Cryptografy;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using Exceptions;
using Exceptions.ExceptionBase;

namespace UseCases.Test.User.Register
{
    public class RegisterUserUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = CreateUseCase();

            var result = await useCase.Execute(request);

            Assert.NotNull(result);
            Assert.Equal(request.Name, result.Name);
        }

        [Fact]
        public async Task Error_Email_Already_Registered()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = CreateUseCase(request.Email);

            Func<Task> act = async () => await useCase.Execute(request);

            var exception = await Assert.ThrowsAsync<ErroOnValidationException>(act);

            Assert.Single(exception.ErroMensages, MessagesException.EMAIL_ALREADY_REGISTERED);

            Assert.True(exception.ErroMensages.Count == 1, "Deveria ter 1 mensagem de erro");
        }

        [Fact]
        public async Task Error_Name_Empty()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = string.Empty;

            var useCase = CreateUseCase();

            Func<Task> act = async () => await useCase.Execute(request);

            var exception = await Assert.ThrowsAsync<ErroOnValidationException>(act);

            Assert.Single(exception.ErroMensages, MessagesException.NAME_EMPTY);

            Assert.True(exception.ErroMensages.Count == 1, "Deveria ter 1 mensagem de erro");
        }

        private RegisterUserUseCase CreateUseCase(string? email = null)
        {
            var mapper = MapperBuilder.Build();
            var passwordEncripter = PasswordEncrypterBuilder.Build();
            var unitOfWork = UnitOfWorkBuilder.Build();
            var userWriteOnlyRepository = UserWriteOnlyRepositoryBuilder.Build();

            var userReadOnlyRepositoryBuilder = new UserReadOnlyRepositoryBuilder();

            if(!string.IsNullOrEmpty(email))
            {
                userReadOnlyRepositoryBuilder.ExisteActiveUserWithEmail(email);
            }

            return new RegisterUserUseCase(userWriteOnlyRepository, userReadOnlyRepositoryBuilder.Build(), unitOfWork, mapper, passwordEncripter);
        }
    }
}
