using Domain;
using Solution.Models.GatewayOne;
using Solution.Requests.GatewayOne;

namespace Solution.Strategies.GatewayTwo
{
    public class PixTwoPaymentStrategy : PaymentStrategyBase
    {
        public PixTwoPaymentStrategy(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override void Pay(Payment parcel)
        {
            var model = GetModel<PixTwoModel>();
            var request = GetRequest<PixTwoRequest, PixTwoModel>(parcel, model);
            var gateway = GetGateway<PixTwoRequest>();

            gateway.Execute(request);
        }
    }
}
