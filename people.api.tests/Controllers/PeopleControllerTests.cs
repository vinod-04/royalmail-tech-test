using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using people.api.Controllers;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace people.api.tests.Controllers
{
    /// <summary>
    /// Few basic PeopleController Tests
    /// </summary>
    public class PeopleControllerTests
    {
        [Fact]
        public async Task GetAllPeople_Returns_Status_Ok()
        {
            //Arrange
            var logger = new Mock<ILogger<PeopleController>>();
            var mediator = new Mock<IMediator>();
            var controller = new PeopleController(mediator.Object, logger.Object);

            //Act
            var actionResult = await controller.GetAllPeople(new CancellationToken());
            var result = actionResult.Result as OkObjectResult;

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>()
            .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetPersonById_Returns_Status_Ok()
        {
            //Arrange
            var logger = new Mock<ILogger<PeopleController>>();
            var mediator = new Mock<IMediator>();
            var controller = new PeopleController(mediator.Object, logger.Object);

            //Act
            var actionResult = await controller.GetPersonById(1, new CancellationToken());
            var result = actionResult.Result as OkObjectResult;

            //Act
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>()
            .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}
