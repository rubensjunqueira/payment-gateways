using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Requests.GatewayOne
{
    internal class CreditCardOneRequest : IGatewayRequest
    {
        public string NameCustomer { get; set; }
        public string CardBrand { get; set; }
        public string CardNumber { get; set; }
        public string CardExpirationMonth { get; set; }
        public string CardExpirationYear { get; set; }
        public string CardCVV { get; set; }
    }
}
