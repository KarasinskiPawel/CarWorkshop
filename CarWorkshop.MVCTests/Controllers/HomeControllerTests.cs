using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarWorkshop.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using AspNetCore;
using FluentAssertions;
using System.Net;

namespace CarWorkshop.MVC.Controllers.Tests
{
    public class HomeControllerTests :IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public HomeControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact()]
        public async void About_ReturnsViewWithRenderModel()
        {
            //arrange
            var client = _factory.CreateClient();

            //act
            var response = await client.GetAsync("Home/About");

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain("<h1>CarWorkshop application</h1>");
        }
    }
}