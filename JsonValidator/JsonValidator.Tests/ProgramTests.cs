using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void CorrectJSONStringShouldReturnCorrect()
        {
            string test = "\"Test\"";
            Assert.Equal("Valid", Program.GetJSONValidity(test));
        }

        [Fact]
        public void ValidJSONStringWithLineBreakShouldReturnValid()
        {
            string test = "\"Test\\u0097\nAnother line\"";
            Assert.Equal("Valid", Program.GetJSONValidity(test));
        }

        [Fact]
        public void InValidJSONStringWithQuotationMissingAtStartShouldReturnInvalid()
        {
            string test = "Test\"";
            Assert.Equal("Invalid", Program.GetJSONValidity(test));
        }

        [Fact]
        public void InValidJSONStringWithQuotationMissingAtEndShouldReturnInvalid()
        {
            string test = "\"Test";
            Assert.Equal("Invalid", Program.GetJSONValidity(test));
        }

        [Fact]
        public void InValidJSONStringContainingBackslashShouldReturnInvalid()
        {
            string test = "\"\\Test\"";
            Assert.Equal("Invalid", Program.GetJSONValidity(test));
        }

        [Fact]
        public void InValidJSONStringContainingQuotationInsidehShouldReturnInvalid()
        {
            string test = "\"Te\"st\"";
            Assert.Equal("Invalid", Program.GetJSONValidity(test));
        }
    }
}
