using Domain;
using NSubstitute;
using System;
using Xunit;

namespace Tests
{
    public class CocktailServiceTests
    {
        private const int cocktailId = 42;

        [Fact]
        public void Mix_Mojito_ReturnsMojito1(){
            // arrange
            var barsProvider = Substitute.For<IBarsProvider>();
            barsProvider.FindCocktailId("mojito").Returns(cocktailId);
            barsProvider.FindPrices(cocktailId).Returns(new[] { 100m, 200m });
            var service = new CocktailService(barsProvider);
            // act
            Cocktail result = service.Mix("mojito", out decimal? bestPrice);
            // assert
            Assert.Equal("mojito", result.Name);
            Assert.Equal(0.5, result.Size);
            Assert.Equal(5, result.PreparationTime.TotalMinutes);
            Assert.Equal(5, result.TotalTime.TotalMinutes);
            Assert.NotNull(result.Instructions);
            Assert.Equal(100m, bestPrice);
        }


        [Fact]
        public void Mix_Mojito_ReturnsMojito()
        {
            // arrange
            var service = new CocktailService(Substitute.For<IBarsProvider>());
            // act
            Cocktail result = service.Mix("mojito", out _);
            // assert
            Assert.Equal("mojito", result.Name);
            Assert.Equal(0.5, result.Size);
            Assert.Equal(5, result.PreparationTime.TotalMinutes);
            Assert.Equal(5, result.TotalTime.TotalMinutes);
            Assert.NotNull(result.Instructions);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        public void Test(int first, int second)
        {
            Assert.Equal(1, first);
            Assert.Equal(2, second);
        }
    }
}
