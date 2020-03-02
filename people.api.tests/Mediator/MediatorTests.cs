using MediatR;
using Moq;
using people.api.MediatR.People;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace people.api.tests.Mediator
{
    /// <summary>
    /// Few basic Meditor Tests
    /// </summary>
    public class MediatorTests
    {
        [Fact]
        public async Task Verfy_GetPeopleSkillsQuery()
        {
            //Arrange
            var mediator = new Mock<IMediator>();
            mediator.Setup(m => m.Send(It.IsAny<GetPeopleSkillsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(It.IsAny<List<Models.People>>());

            //Act
            await mediator.Object.Send(new GetPeopleSkillsQuery());

            //Assert
            mediator.Verify(x => x.Send(It.IsAny<GetPeopleSkillsQuery>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task Verfy_UpdatePersonCommand()
        {
            //Arrange
            var mediator = new Mock<IMediator>();
            mediator.Setup(m => m.Send(It.IsAny<UpdatePersonCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(It.IsAny<bool>());

            //Act
            await mediator.Object.Send(new UpdatePersonCommand());

            //Assert
            mediator.Verify(x => x.Send(It.IsAny<UpdatePersonCommand>(), It.IsAny<CancellationToken>()));
        }
    }
}
