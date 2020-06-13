using System;
using ApplicationLayer;
using FluentAssertions;
using Xunit;

namespace ApplicationLayerTest
{
    public class MoneySpecs
    {
        [Fact]
        public void Sum_of_two_moneys_produces_correct_result()
        {
            // Arrange
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            // Act
            var actualSum = money1 + money2;

            // Assert
            Assert.Equal(2, actualSum.NbOfCent);
            Assert.Equal(4, actualSum.NbOfTenCent);
            Assert.Equal(6, actualSum.NbOfQuarter);
            Assert.Equal(8, actualSum.NbOfDollar);
            Assert.Equal(10, actualSum.NbOfFiveDollar);
            Assert.Equal(12, actualSum.NbOfTwentyDollar);
        }


        // It's a good practice to always check that two value object instances with the same data of the same 
        // type are considered to be equal (structural equality + haschcode), because as we know,. NET employs the reference equality for all classes by default.
        [Fact]
        public void Two_money_instances_equal_if_contain_the_same_number_of_predefined_pieces()
        {
            // Arrange
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            // Act

            // Assert
            Assert.Equal(money1, money2);
            Assert.Equal(money1.GetHashCode(), money2.GetHashCode());
        }

        [Fact]
        public void Two_money_instances_do_not_equal_if_contain_different_number_of_predefined_pieces()
        {
            // Arrange
            Money hundredCents = new Money(100, 0, 0, 0, 0, 0);
            Money oneDollar = new Money(0, 0, 0, 1, 0, 0);

            // Act

            // Assert
            Assert.NotEqual(hundredCents, oneDollar);
            Assert.NotEqual(hundredCents.GetHashCode(), oneDollar.GetHashCode());
            //Assert.Equal(hundredCents.GetAmount, oneDollar.GetAmount, 2);  // même si ils ont la même valeur

        }

        [Theory]
        [InlineData(-1, 0, 0, 0, 0, 0)]
        [InlineData(0, -2, 0, 0, 0, 0)]
        [InlineData(0, 0, -3, 0, 0, 0)]
        [InlineData(0, 0, 0, -4, 0, 0)]
        [InlineData(0, 0, 0, 0, -5, 0)]
        [InlineData(0, 0, 0, 0, 0, -6)]
        public void Cannot_create_money_with_negative_value(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            Action action = () => new Money(
                oneCentCount,
                tenCentCount,
                quarterCount,
                oneDollarCount,
                fiveDollarCount,
                twentyDollarCount);

            action.Should().Throw<InvalidOperationException>();
        }


        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0, 0)]
        [InlineData(1, 0, 0, 0, 0, 0, 0.01)]
        [InlineData(1, 2, 0, 0, 0, 0, 0.21)]
        [InlineData(1, 2, 3, 0, 0, 0, 0.96)]
        [InlineData(1, 2, 3, 4, 0, 0, 4.96)]
        [InlineData(1, 2, 3, 4, 5, 0, 29.96)]
        [InlineData(1, 2, 3, 4, 5, 6, 149.96)]
        [InlineData(11, 0, 0, 0, 0, 0, 0.11)]
        [InlineData(110, 0, 0, 0, 100, 0, 501.1)]
        public void Amount_is_calculated_correctly(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount,
            decimal expectedAmount)
        {
            // Arrange

            // Act
            var money = new Money(
                oneCentCount,
                tenCentCount,
                quarterCount,
                oneDollarCount,
                fiveDollarCount,
                twentyDollarCount);

            // Assert
            Assert.Equal(expectedAmount, money.Amount, 2);
        }


        [Fact]
        public void Subtraction_of_two_moneys_produces_correct_result()
        {
            // Arrange
            var money1 = new Money(10, 10, 10, 10, 10, 10);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            // Act
            var actualSum = money1 - money2;

            // Assert
            Assert.Equal(9, actualSum.NbOfCent);
            Assert.Equal(8, actualSum.NbOfTenCent);
            Assert.Equal(7, actualSum.NbOfQuarter);
            Assert.Equal(6, actualSum.NbOfDollar);
            Assert.Equal(5, actualSum.NbOfFiveDollar);
            Assert.Equal(4, actualSum.NbOfTwentyDollar);
        }

        [Fact]
        public void Cannot_subtract_more_than_exists_considering_predefined_pieces()
        {
            // Arrange
            var money1 = new Money(
                nbOfCent: 0, 
                nbOfTenCent: 0, 
                nbOfQuarter: 0, 
                nbOfDollar: 1, 
                nbOfFiveDollar: 0, 
                nbOfTwentyDollar: 0
                );
            var money2 = new Money(
                nbOfCent: 1, 
                nbOfTenCent: 0, 
                nbOfQuarter: 0, 
                nbOfDollar: 0, 
                nbOfFiveDollar: 0, 
                nbOfTwentyDollar: 0
                );

            // Act
            Action action = () =>
            {
                var money = money1 - money2;
            };

            // Assert
            action.Should().Throw<InvalidOperationException>();
        }
    }
}
