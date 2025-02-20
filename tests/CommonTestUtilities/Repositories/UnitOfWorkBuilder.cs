using Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories
{
    public class UnitOfWorkBuilder
    {
        public static IUnitOfWork Build()
        {
            //only work with interface
            var mock = new Mock<IUnitOfWork>();

            return mock.Object;
        }
    }
}
