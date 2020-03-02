using Moq;
using people.api.Domain;
using people.api.Repository;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace people.api.tests.Repository
{
    /// <summary>
    /// Few basic PeopleRepository Tests
    /// </summary>
    public class PeopleRepositoyTests
    {
        [Fact]
        public void GetById_Returns_Person()
        {
            //Arrange  
            var person = new People { PersonId = 1, FirstName = "David", LastName = "Hirst", IsAdmin = false, IsEnabled = true, IsValid = true };
            var repo = new Mock<IPeopleRepository>();
            repo.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(person);

            var result = repo.Object.GetById(1);

            Assert.NotNull(result);
            Assert.True(result.Result.IsValid);
        }

        [Fact]
        public void GetAll_Returns_People()
        {
            //Arrange  
            var people = new List<Models.People> { new Models.People { PersonId = 1, FirstName = "David", LastName = "Hirst", IsAdmin = false, IsEnabled = true, IsValid = true } };
            var repo = new Mock<IPeopleRepository>();
            repo.Setup(x => x.GetAllPagedAsync()).ReturnsAsync(people);
            
            //Act
            var result = repo.Object.GetAllPagedAsync();

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Result.Any());
        }
    }
}
