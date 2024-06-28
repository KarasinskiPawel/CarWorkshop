using Xunit;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CarWorkshop.Domain.Entities.Tests
{
    public class CarWorkshopTests
    {
        [Fact()]
        public void SetEncodeName_ShouldSetEncodedName()
        {
            //arrange
            var carWorkshop = new CarWorkshop();
            carWorkshop.Name = "Test Workshop";

            //act
            carWorkshop.SetEncodeName();

            //assert
            carWorkshop.EncodeName.Should().Be("test-workshop");
        }

        //[Fact()]
        //public void SetEncodeName_ShouldThrowException_WhenNameIsNull()
        //{
        //    //arrange
        //    var carWorkshop = new CarWorkshop();

        //    //act
        //    Action action =() => carWorkshop.SetEncodeName();

        //    //assert
        //    action.Invoking(a => a.Invoke())
        //        .Should().Throw<ArgumentNullException>();
        //}
    }
}