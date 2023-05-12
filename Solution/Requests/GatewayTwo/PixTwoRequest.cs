using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Requests.GatewayOne
{
    public class PixTwoRequest : IGatewayRequest
    {
        public string Key { get; set; }
        public double Value { get; set; }
        public string Message { get; set; }
    }
}
