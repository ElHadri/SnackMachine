using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Snack : ValueObject
    {
        public readonly string Label;
        public readonly Money Price;

        public Snack(string label, Money price)
        {
            Label = label;
            Price = price;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Label;
            yield return Price;
        }
    }
}
