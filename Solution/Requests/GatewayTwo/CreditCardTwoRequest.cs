using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Requests.GatewayOne
{
    internal class CreditCardTwoRequest : IGatewayRequest
    {
        public string Brand { get; set; }
        public string Number { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
    }
}
