using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class PurchaseResult
    {
        public Snack Snack { get; set; }
        public Money Change { get; set; }
    }
}
