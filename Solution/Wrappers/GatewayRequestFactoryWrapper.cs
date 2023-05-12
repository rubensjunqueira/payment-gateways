using Domain;
using Microsoft.Extensions.DependencyInjection;
using Solution.Facotries;
using Solution.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Wrappers
{
    public abstract class GatewayRequestFactoryWrapper
    {
        public abstract IGatewayRequest Create<TModel>(
            Payment parcel,
            TModel model,
            IServiceProvider container)
            where TModel : class;
    }

    public class GatewayRequestFactoryWrapperImpl<T> : GatewayRequestFactoryWrapper
        where T : IGatewayRequest
    {
        public override IGatewayRequest Create<TModel>(
            Payment parcel, 
            TModel model, 
            IServiceProvider container)
        {
            var factory = container.GetRequiredService<IGatewayRequestFactory<T, TModel>>();

            return factory == null ? 
                throw new Exception("Factory not registred") : 
                (IGatewayRequest)factory.Create(parcel, model);
        }
    }
}
