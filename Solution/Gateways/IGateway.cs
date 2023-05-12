using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.Requests;

namespace Solution.Gateways
{

    public interface IGateway<TRequest>
        where TRequest : IGatewayRequest
    {
        void Execute(TRequest request);
    }
}
