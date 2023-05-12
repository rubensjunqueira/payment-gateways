using Domain;
using Solution.Gateways;
using Solution.Requests;
using Solution.Wrappers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Strategies
{
    public interface IPaymentStrategy
    {
        void Pay(Payment parcel);
    }

    public abstract class PaymentStrategyBase : IPaymentStrategy
    {
        private readonly IServiceProvider _provider;

        private ConcurrentDictionary<Type, GatewayRequestFactoryWrapper> _requestGatewayFactories = new();
        private ConcurrentDictionary<Type, ModelFactoryWrapper> _modelFactories = new();
        private ConcurrentDictionary<Type, GatewayWrapper> _gateways = new();

        public PaymentStrategyBase(IServiceProvider serviceProvider)
        {
            _provider = serviceProvider;
        }

        public abstract void Pay(Payment parcel);

        protected TRequest GetRequest<TRequest, TModel>(Payment parcel, TModel model)
            where TRequest : IGatewayRequest
            where TModel : class
        {
            var requestWrapper = _requestGatewayFactories.GetOrAdd(typeof(TRequest), static type =>
            {
                var wrapperType = typeof(GatewayRequestFactoryWrapperImpl<>).MakeGenericType(type);
                var wrapper = Activator.CreateInstance(wrapperType);
                return (GatewayRequestFactoryWrapper)wrapper;
            });

            return (TRequest)requestWrapper.Create(parcel, model, _provider);
        }

        protected TModel GetModel<TModel>()
            where TModel : class
        {
            var modelWrapper = _modelFactories.GetOrAdd(typeof(TModel), static type =>
            {
                var wrapperType = typeof(ModelFactoryWrapperImpl<>).MakeGenericType(type);
                var wrapper = Activator.CreateInstance(wrapperType);
                return (ModelFactoryWrapper)wrapper;
            });

            return modelWrapper.Create<TModel>(_provider);
        }

        protected IGateway<TRequest> GetGateway<TRequest>()
            where TRequest : IGatewayRequest
        {
            var gatewayWrapper = _gateways.GetOrAdd(typeof(TRequest), static type =>
            {
                var wrapperType = typeof(GatewayWrapperImpl<>).MakeGenericType(type);
                var wrapper = Activator.CreateInstance(wrapperType);
                return (GatewayWrapper)wrapper;
            });

            return gatewayWrapper.Create<TRequest>(_provider);
        }
    }
}
