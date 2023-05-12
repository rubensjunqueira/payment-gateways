using Domain;
using Solution.Gateways;
using Solution.Models.GatewayOne;
using Solution.Requests;
using Solution.Requests.GatewayOne;
using Solution.Strategies;
using Solution.Strategies.GatewayOne;
using Solution.Wrappers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Mediator
{
    public class PaymentMediator : IPaymentMediator
    {
        private Dictionary<EPaymentMethod, IPaymentStrategy> _strategies;

        public PaymentMediator(IServiceProvider provider)
        {
            _strategies = new Dictionary<EPaymentMethod, IPaymentStrategy>();
            _strategies.Add(EPaymentMethod.PixOne, new PixOnePaymentStrategy(provider));
            _strategies.Add(EPaymentMethod.PixTwo, new PixOnePaymentStrategy(provider));
        }

        public void Pay(Payment parcel)
        {
            if (_strategies.TryGetValue(parcel.PaymentMethod, out var paymentStrategy))
            {
                paymentStrategy.Pay(parcel);
            }
            else
            {
                throw new Exception("Invalid Payment method, please add the method in this constructor");
            }
        }
    }
}
