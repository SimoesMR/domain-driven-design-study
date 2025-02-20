using Application.UseCases.User.Register;
using CommonTestUtilities.Cryptografy;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;

namespace UseCases.Test.User.Register
{
    public class RegisterUserUseCaseTest
    {
        public async Task Success()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var mapper = MapperBuilder.Build();
            var passwordEncripter = PasswordEncrypterBuilder.Build();
            var unitOfWork = UnitOfWorkBuilder.Build();
            var userReadOnlyRepository = UserReadOnlyRepositoryBuilder.Build();
            var userWriteOnlyRepository = UserWriteOnlyRepositoryBuilder.Build();

            var useCase = new RegisterUserUseCase(userWriteOnlyRepository, userReadOnlyRepository, unitOfWork, mapper, passwordEncripter);

            var result = await useCase.Execute(request);

            Assert.NotNull(result);
            Assert.Equal(request.Name, result.Name);
        }
    }
}
