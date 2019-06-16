using Microsoft.AspNetCore.Mvc;
using Moq;
using odd.web.Controllers;
using odd.web.DTOs;
using odd.web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace odd.web.test
{
    public class AdminControllerTest
    {
        [Fact]
        public void IndexView_All_Admin_Odds_Entry_Test()
        {
            // Arrange
            var mockRepo = new Mock<IOddServices>();
            mockRepo.Setup(repo => repo.AdminQueryOdds(null))
                .Returns(GetAdminTestOdds());
            var controller = new AdminController(mockRepo.Object,null,null);
    

            // Act
            var result = controller.index(null);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<AdminQuery>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void IndexView_All_Client_Odds_Entry_Test()
        {
            // Arrange
            var mockRepo = new Mock<IOddServices>();
            mockRepo.Setup(repo => repo.ClientQueryOdds())
                .Returns(GetClientTestOdds());
            var controller = new HomeController(mockRepo.Object);


            // Act
            var result = controller.index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ClientQuery>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Odd_Entry_Post_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<IOddServices>();
            mockRepo.Setup(repo => repo.AdminQueryOdds(null))
                .Returns(GetAdminTestOdds());
            var controller = new AdminController(mockRepo.Object, null, null);
            controller.ModelState.AddModelError("HomeOdd", "Required");
            var newOdd = new CreateOdd();

            // Act
            var result = await controller.odd_entry(newOdd);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }


        public IQueryable<AdminQuery> GetAdminTestOdds()
        {
            var odds = new List<AdminQuery>();
            odds.Add(new AdminQuery()
            {
                HomeTeam = "Arsenal",
                AwayTeam = "Man U",
                HomeOdd = 2,
                AwayOdd = 6,
                DrawOdd = 3,
                LastUpdated = DateTime.UtcNow.ToString()
            });
            odds.Add(new AdminQuery()
            {
                HomeTeam = "Chelsea",
                AwayTeam = "Man City",
                HomeOdd = 2,
                AwayOdd = 6,
                DrawOdd = 3,
                LastUpdated = DateTime.UtcNow.ToString()
            });
            return odds.AsQueryable();
        }

        public IQueryable<ClientQuery> GetClientTestOdds()
        {
            var odds = new List<ClientQuery>();
            odds.Add(new ClientQuery()
            {
                HomeTeam = "Arsenal",
                AwayTeam = "Man U",
                HomeOdd = 2,
                AwayOdd = 6,
                DrawOdd = 3,
                LastUpdated = DateTime.UtcNow.ToString()
            });
            odds.Add(new ClientQuery()
            {
                HomeTeam = "Chelsea",
                AwayTeam = "Man City",
                HomeOdd = 2,
                AwayOdd = 6,
                DrawOdd = 3,
                LastUpdated = DateTime.UtcNow.ToString()
            });
            return odds.AsQueryable();
        }
    }

}
