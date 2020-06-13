using System;
using System.Collections.Generic;
using System.Linq;

using static ApplicationLayer.Money;

namespace ApplicationLayer
{
    public sealed class SnackMachine : Entity
    {
        public Money SnackMachinedMoney { get; private set; } = None;
        public Money TransactionMoney { get; private set; } = None; // Attention c'est immutable
        public Dictionary<string, int> SnackCategories { get; private set; }



        //Methods--------------------------------------------------------------
        public void InsertMoney(Money pieceOfMoney)
        {
            Money[] acceptedPieces = { /*None, */Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar };
            if (!acceptedPieces.Contains(pieceOfMoney))
            {
                throw new InvalidOperationException();
            }

            TransactionMoney += pieceOfMoney;
        }

        public Money ReturnMoneyBack()
        {
            var returnedMoney = TransactionMoney;

            TransactionMoney = None;

            return returnedMoney;
        }

        public /*PurchaseResult*/ void GetSnack(/*string snackLabel*/)
        {
            //Money snackPrice = Dollar; // changer implementation
            //Money change = TransactionMoney - snackPrice;

            SnackMachinedMoney += TransactionMoney;
            TransactionMoney = None;
        }


    }
}



