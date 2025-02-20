using Domain.Repositories;
using Domain.Repositories.User;
using Moq;

namespace CommonTestUtilities.Repositories
{
    public class UserReadOnlyRepositoryBuilder
    {
        public static IUserReadOnlyRepository Build()
        {
            //only work with interface
            var mock = new Mock<IUserReadOnlyRepository>();

            return mock.Object;
        }
    }
}
