using System;
using DomainModel;
using FluentAssertions;
using Xunit;
using static DomainModel.Money;

namespace DomainModelTest
{
    public class SnackMachineSpecs
    {
        // ReturnMoneyBack()
        [Fact]
        public void Return_money_empties_money_in_transaction()
        {
            // Arrange
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollar);

            // Act
            snackMachine.ReturnMoneyBack();

            // Assert
            Assert.Equal(None, snackMachine.TransactionMoney);
        }


        // InsertMoney()
        [Fact]
        public void Inserted_money_goes_to_money_in_transaction()
        {
            // Arrange
            var snackMachine = new SnackMachine(); // le problème c'est le fait de vider money_in_transaction

            // Act
            snackMachine.InsertMoney(Cent);
            snackMachine.InsertMoney(Dollar);

            // Assert
            Assert.Equal(Cent + Dollar, snackMachine.TransactionMoney);
        }
        [Fact]
        public void Cannot_insert_more_than_one_coin_or_note_at_a_time()
        {
            var snackMachine = new SnackMachine();
            var twoCent = Cent + Cent;

            Action action = () => snackMachine.InsertMoney(twoCent);

            action.Should().Throw<InvalidOperationException>();
        }
        [Fact]
        public void Cannot_accept_coin_or_note_not_allowed_by_the_machine()
        {
            var snackMachine = new SnackMachine();

            Money imaginedPiece = new Money(0, 1, 1, 1, 0, 0);

            Action action = () => snackMachine.InsertMoney(imaginedPiece);

            action.Should().Throw<InvalidOperationException>();

        }


        // GetSnack()
        [Fact]
        public void Money_in_transaction_goes_to_money_inside_after_purchase()  // To Do: il faut le change ect...
        {
            // Arrange
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollar);
            snackMachine.InsertMoney(Dollar);

            // Act
            snackMachine.GetSnack();

            // Assert
            Assert.Equal(Dollar + Dollar, snackMachine.SnackMachineMoney);
            Assert.Equal(None, snackMachine.TransactionMoney);
        }

    }
}
