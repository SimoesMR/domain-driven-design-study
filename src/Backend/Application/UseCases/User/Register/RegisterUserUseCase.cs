using Application.Services.Cryptography;
using AutoMapper;
using Comunication.Request;
using Comunication.Response;
using Domain.Repositories;
using Domain.Repositories.User;
using Exceptions;
using Exceptions.ExceptionBase;

namespace Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserWriteOnlyRepository _writeOnlyRepository;
        private readonly IUserReadOnlyRepository _readOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PasswordEncripter _passwordEncripter;

        public RegisterUserUseCase(
            IUserWriteOnlyRepository writeOnlyRepository, 
            IUserReadOnlyRepository readOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            PasswordEncripter passwordEncripter)
        {
            _writeOnlyRepository = writeOnlyRepository;
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            //1 - validar dados request
            await Valitadion(request);

           //2 - mapear request em uma entidade/dominio
            var user = _mapper.Map<Domain.Entities.User>(request);

            //3 - encriptografar password
            user.Password = _passwordEncripter.Encrypt(request.Password);

            //4 - salvar no banco de dados
            await _writeOnlyRepository.Add(user);

            //Commit no banco
            await _unitOfWork.Commit();

            return new ResponseRegisteredUserJson {
                Name = user.Name
            };
        }

        public async Task Valitadion(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            var emailExist = await _readOnlyRepository.ExisteActiveUserWithEmail(request.Email);
            if(emailExist)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, MessagesException.EMAIL_ALREADY_REGISTERED));
            }

            if (result.IsValid == false)
            {
                var errorMessage = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErroOnValidationException(errorMessage);
            }
        }
    }
}
