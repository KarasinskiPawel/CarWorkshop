using Xunit;
using CarWorkshop.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using CarWorkshop.Application.CarWorkshop;
using Moq;
using MediatR;
using CarWorkshop.Application.CarWorkshop.Commands.Querrys.GetAllCarWorkshops;
using Microsoft.AspNetCore.TestHost;
using FluentAssertions;
using System.Net;

namespace CarWorkshop.MVC.Controllers.Tests
{
    public class CarWorkshopControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CarWorkshopControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact()]
        public async Task Index_ReturnViewWithExpectedData_ForExistingWorkshop()
        {
            //arrange
            var CarWorkshops = new List<CarWorkshopDto>()
            {
                new CarWorkshopDto()
                {
                    Name = "Workshop 1",
                },

                new CarWorkshopDto()
                {
                    Name = "Workshop 2",
                },

                new CarWorkshopDto()
                {
                    Name = "Workshop 3",
                },

            };

            var mediatorMock = new Mock<IMediator>();

            mediatorMock.Setup(a => a.Send(It.IsAny<GetAllCarWorkshopsQuerry>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(CarWorkshops);

            var client = _factory
                .WithWebHostBuilder(builder => builder.ConfigureTestServices(services => services.AddScoped(_ => mediatorMock.Object)))
                .CreateClient();

            //act
            var response = await client.GetAsync("/CarWorkshop/Index");

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var contetnt = await response.Content.ReadAsStringAsync();

            contetnt.Should().Contain("<h1>Car Workshop</h1>")
                .And.Contain("Workshop 1")
                .And.Contain("Workshop 2")
                .And.Contain("Workshop 3");
        }

        [Fact()]
        public async Task Index_ReturnEmptyView_WhenNoCarWorkshopsExist()
        {
            //arrange
            var CarWorkshops = new List<CarWorkshopDto>()
            {

            };

            var mediatorMock = new Mock<IMediator>();

            mediatorMock.Setup(a => a.Send(It.IsAny<GetAllCarWorkshopsQuerry>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(CarWorkshops);

            var client = _factory
                .WithWebHostBuilder(builder => builder.ConfigureTestServices(services => services.AddScoped(_ => mediatorMock.Object)))
                .CreateClient();

            //act
            var response = await client.GetAsync("/CarWorkshop/Index");

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var contetnt = await response.Content.ReadAsStringAsync();

            contetnt.Should().NotContain("div class=\"card-m3\"");
        }
    }
}