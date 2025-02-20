using Domain.Repositories.User;
using Moq;

namespace CommonTestUtilities.Repositories
{
    public class UserWriteOnlyRepositoryBuilder
    {
        public static IUserWriteOnlyRepository Build()
        {
            //only work with interface
            var mock = new Mock<IUserWriteOnlyRepository>();

            return mock.Object;
        }
    }
}
