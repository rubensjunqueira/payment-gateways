using Solution.Requests.GatewayOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Gateways.GatewayOne
{
    public class GatewayOne :
        IGateway<PixOneRequest>
    {
        public void Execute(PixOneRequest request)
        {
            Console.WriteLine("Executando pagamento via pix pelo gateway: {0}", nameof(GatewayOne));
        }
    }
}
