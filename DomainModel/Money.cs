using System;
using System.Collections.Generic;

namespace DomainModel
{
    public class Money : ValueObject
    {
        public readonly string _currency = "$";

        /* fields: composition of money */
        public readonly int NbOfCent;  // or  public int NbOfCent {get;}   ==> immutability
        public readonly int NbOfTenCent;
        public readonly int NbOfQuarter;
        public readonly int NbOfDollar;
        public readonly int NbOfFiveDollar;
        public readonly int NbOfTwentyDollar;
        public decimal Amount =>   /*read-only*/
            NbOfCent * 0.01m +
            NbOfTenCent * 0.10m +
            NbOfQuarter * 0.25m +
            NbOfDollar +
            NbOfFiveDollar * 5m +
            NbOfTwentyDollar * 20m;

        // OR
        //public decimal Amount  /*read-only*/
        //{
        //    get
        //    {
        //        return _nbOfCent * 0.01m +
        //                _nbOfTenCent * 0.10m +
        //                _nbOfQuarter * 0.25m +
        //                _nbOfDollar +
        //                _nbOfFiveDollar * 5 +
        //                _nbOfTwentyDollar * 20;
        //    }
        //}

        /* Constructor*/ /*me permet de contruire autres pieces acceptables par la machine*/
        public Money(
            int nbOfCent,
            int nbOfTenCent,
            int nbOfQuarter,
            int nbOfDollar,
            int nbOfFiveDollar,
            int nbOfTwentyDollar
            )
        {
            if (nbOfCent < 0)
                throw new InvalidOperationException();
            if (nbOfTenCent < 0)
                throw new InvalidOperationException();
            if (nbOfQuarter < 0)
                throw new InvalidOperationException();
            if (nbOfDollar < 0)
                throw new InvalidOperationException();
            if (nbOfFiveDollar < 0)
                throw new InvalidOperationException();
            if (nbOfTwentyDollar < 0)
                throw new InvalidOperationException();

            NbOfCent = nbOfCent;
            NbOfTenCent = nbOfTenCent;
            NbOfQuarter = nbOfQuarter;
            NbOfDollar = nbOfDollar;
            NbOfFiveDollar = nbOfFiveDollar;
            NbOfTwentyDollar = nbOfTwentyDollar;
        }

        // predefined peices of money
        public static readonly Money None = new Money(0, 0, 0, 0, 0, 0); // juste pour des raisons techniques
        public static readonly Money Cent = new Money(1, 0, 0, 0, 0, 0);
        public static readonly Money TenCent = new Money(0, 1, 0, 0, 0, 0);
        public static readonly Money Quarter = new Money(0, 0, 1, 0, 0, 0);
        public static readonly Money Dollar = new Money(0, 0, 0, 1, 0, 0);
        public static readonly Money FiveDollar = new Money(0, 0, 0, 0, 1, 0);
        public static readonly Money TwentyDollar = new Money(0, 0, 0, 0, 0, 1);



        //-----------------------------------------------------------------------------------------------------------
        /*Methods*/
        public static Money operator -(Money operand1, Money operand2)  // la soustraction ici ne concerne pas le monatant
        {
            return new Money(
                    operand1.NbOfCent - operand2.NbOfCent,
                    operand1.NbOfTenCent - operand2.NbOfTenCent,
                    operand1.NbOfQuarter - operand2.NbOfQuarter,
                    operand1.NbOfDollar - operand2.NbOfDollar,
                    operand1.NbOfFiveDollar - operand2.NbOfFiveDollar,
                    operand1.NbOfTwentyDollar - operand2.NbOfTwentyDollar);

            //var difference = operand1.Amount - operand2.Amount;
            //if (difference < 0)
            //    throw new InvalidOperationException();
            //return mapAmountToPieces(difference);
        }

        public static Money operator +(Money operand1, Money operand2) // l'addition ici ne concerne pas le monatant
        {
            return new Money(
                operand1.NbOfCent + operand2.NbOfCent,
                operand1.NbOfTenCent + operand2.NbOfTenCent,
                operand1.NbOfQuarter + operand2.NbOfQuarter,
                operand1.NbOfDollar + operand2.NbOfDollar,
                operand1.NbOfFiveDollar + operand2.NbOfFiveDollar,
                operand1.NbOfTwentyDollar + operand2.NbOfTwentyDollar);
        }

        private static Money mapAmountToPieces(decimal amount)
        {
            Money mapResult = None;

            while (amount % 20m == 0)
            {
                mapResult += TwentyDollar;
                amount -= TwentyDollar.Amount;
            }
            while (amount % 5m == 0)
            {
                mapResult += FiveDollar;
                amount -= FiveDollar.Amount;
            }
            while (amount % 1m == 0)
            {
                mapResult += Dollar;
                amount -= Dollar.Amount;
            }
            while (amount % 0.25m == 0)
            {
                mapResult += Quarter;
                amount -= Quarter.Amount;
            }
            while (amount % 0.10m == 0)
            {
                mapResult += TenCent;
                amount -= TenCent.Amount;
            }
            while (amount % 0.01m == 0)
            {
                mapResult += TenCent;
                amount -= TenCent.Amount;
            }

            return mapResult;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _currency;

            yield return NbOfCent;
            yield return NbOfTenCent;
            yield return NbOfQuarter;
            yield return NbOfDollar;
            yield return NbOfFiveDollar;
            yield return NbOfTwentyDollar;
        }

    }
}
