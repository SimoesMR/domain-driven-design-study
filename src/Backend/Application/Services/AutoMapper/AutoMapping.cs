using AutoMapper;
using Comunication.Request;
using Domain.Entities;

namespace Application.Services.AutoMapper
{
    //classa de configuração do automapper
    //Perfil do automapper
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            //cria o mapeamente de onde esta vindo(fonte), Segundo parametro qual a classe que vai receber os dados
            //vai ignora a propriedade password porque ela precisa ser criptografada
            CreateMap<RequestRegisterUserJson, Domain.Entities.User>()
                .ForMember(destination => destination.Password, option => option.Ignore());
        }
    }
}

