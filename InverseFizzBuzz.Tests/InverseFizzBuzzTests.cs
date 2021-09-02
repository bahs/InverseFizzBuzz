using Xunit;

namespace InverseFizzBuzz.Tests
{
    public class InverseFizzBuzzTests
    {
        [Theory]
        [InlineData("fizz", "3")]
        [InlineData("buzz", "5")]
        [InlineData("fizzbuzz", "15")]
        [InlineData("buzz,fizz", "5,6")]
        [InlineData("fizz, fizz", "6,7,8,9")]
        [InlineData("fizz,buzz", "9,10")]
        [InlineData("FizzBuzz, fizz", "15,16,17,18")]
        [InlineData("fizz, buzz , fizz ", "3,4,5,6")]
        [InlineData("test,test", "Sequence not found.")]
        [InlineData("fizz,fizz,fizz", "Sequence not found.")]
        [InlineData("fizz,buzz,fizz,fizz,buzz", "3,4,5,6,7,8,9,10")]
        public void FindShortSequence_ShouldFindSequence(string inputFizzBuzzString, string expectedValues)
        {
            var finder = new InverseFizzBuzzGame.InverseFizzBuzz();
            var actualValues = finder.FindShortSequence(inputFizzBuzzString);

            Assert.Equal(expectedValues, actualValues);
        }

        [Theory]
        [InlineData("test,test")]
        [InlineData("fizz,fizz,fizz")]
        public void FindShortSequence_ShouldNotFindSequence(string inputFizzBuzzString)
        {
            var finder = new InverseFizzBuzzGame.InverseFizzBuzz();
            var actualValues = finder.FindShortSequence(inputFizzBuzzString);

            Assert.Equal("Sequence not found.", actualValues);
        }

    }
}
