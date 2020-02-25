using System;
using Xunit;

namespace JsonNumberValidator.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void PositiveIntegerNumberShouldReturnValid()
        {
            string test = "234";
            Assert.Equal("Valid", Program.GetJSONNumberValidity(test));
        }
    }
}