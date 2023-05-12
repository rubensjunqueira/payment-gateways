using Domain;
using Solution.Models.GatewayOne;
using Solution.Requests.GatewayOne;

namespace Solution.Strategies.GatewayOne
{
    public class PixOnePaymentStrategy : PaymentStrategyBase
    {
        public PixOnePaymentStrategy(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override void Pay(Payment parcel)
        {
            var model = GetModel<PixOneModel>();
            var request = GetRequest<PixOneRequest, PixOneModel>(parcel, model);
            var gateway = GetGateway<PixOneRequest>();

            gateway.Execute(request);
        }
    }
}
