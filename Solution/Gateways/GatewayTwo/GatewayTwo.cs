using Solution.Requests.GatewayOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Gateways.GatewayTwo
{
    public class GatewayTwo :
        IGateway<PixTwoRequest>
    {
        public void Execute(PixTwoRequest request)
        {
            Console.WriteLine("Executando pagamento via pix pelo gateway: {0}", nameof(GatewayTwo));
        }
    }
}
