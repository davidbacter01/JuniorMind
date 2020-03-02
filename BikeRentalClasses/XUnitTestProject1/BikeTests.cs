using System;
using BikeRentalClasses;
using Xunit;

namespace BikeRentelClasses.Tests
{
    public class BikeTests
    {
        [Fact]
        public void CheckingPriceForSportBikeForAWeekShouldReturnExpectedValue()
        {
            Bike sportBike = new Bike();
            Assert.Equal(17.00, sportBike.GetPriceForDays(1));
        }
    }
}
