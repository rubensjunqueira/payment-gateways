using Microsoft.Extensions.DependencyInjection;
using Solution.Facotries;
using Solution.Gateways;
using Solution.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Wrappers
{
    public abstract class GatewayWrapper
    {
        public abstract IGateway<TRequest> Create<TRequest>(IServiceProvider provider)
            where TRequest : IGatewayRequest;
    }

    public class GatewayWrapperImpl<T> : GatewayWrapper
        where T : IGatewayRequest
    {
        public override IGateway<TRequest> Create<TRequest>(IServiceProvider provider)
        {
            return provider.GetRequiredService<IGateway<TRequest>>();
        }
    }
}
