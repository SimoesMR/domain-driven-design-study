using Comunication.Request;
using Comunication.Response;

namespace Application.UseCases.User.Register
{
    public interface IRegisterUserUseCase
    {
       public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
    }
}
