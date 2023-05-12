using Domain;
using Microsoft.Extensions.DependencyInjection;
using Solution.Facotries;
using Solution.Gateways;
using Solution.Gateways.GatewayOne;
using Solution.Gateways.GatewayTwo;
using Solution.Mediator;
using Solution.Models.GatewayOne;
using Solution.Requests.GatewayOne;
using System.Diagnostics;

namespace Tests
{
    public class GeralTest
    {
        [Fact]
        public void Should_pass()
        {
            try
            {
                var services = new ServiceCollection();

                // request factory
                services.AddTransient<IGatewayRequestFactory<PixOneRequest, PixOneModel>, GatewayRequestFactory>();
                services.AddTransient<IGatewayRequestFactory<PixTwoRequest, PixTwoModel>, GatewayRequestFactory>();

                // model factory
                services.AddTransient<IModelFactory<PixOneModel>, ModelFactory>();
                services.AddTransient<IModelFactory<PixTwoModel>, ModelFactory>();

                // gateway
                services.AddTransient<IGateway<PixOneRequest>, GatewayOne>();
                services.AddTransient<IGateway<PixTwoRequest>, GatewayTwo>();

                // payment mediator
                services.AddScoped<IPaymentMediator, PaymentMediator>();


                var provider = services.BuildServiceProvider();
                var mediator = provider.GetRequiredService<IPaymentMediator>();

                Payment parcel = new()
                {
                    PaymentMethod = EPaymentMethod.PixOne
                };


                mediator.Pay(parcel);
            }
            catch
            {
                Assert.Fail("Should pass but got an error");
            }
        }
    }
}