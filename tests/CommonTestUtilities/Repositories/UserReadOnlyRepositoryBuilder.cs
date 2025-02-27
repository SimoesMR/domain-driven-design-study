﻿using Domain.Repositories;
using Domain.Repositories.User;
using Moq;

namespace CommonTestUtilities.Repositories
{
    public class UserReadOnlyRepositoryBuilder
    {
        private readonly Mock<IUserReadOnlyRepository> _repository;

        public UserReadOnlyRepositoryBuilder() => _repository = new Mock<IUserReadOnlyRepository>();

        public void ExisteActiveUserWithEmail(string email)
        {
            _repository.Setup(repository => repository.ExisteActiveUserWithEmail(email)).ReturnsAsync(true);
        }

        public IUserReadOnlyRepository Build() => _repository.Object;
    }
}
