using Domain;
using Solution.Models.GatewayOne;
using Solution.Requests;
using Solution.Requests.GatewayOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Facotries
{
    public interface IGatewayRequestFactory<TGatewayRequest, TModel>
        where TGatewayRequest : IGatewayRequest
        where TModel : class
    {
        TGatewayRequest Create(Payment parcel, TModel model);
    }

    public class GatewayRequestFactory :
        IGatewayRequestFactory<PixOneRequest, PixOneModel>,
        IGatewayRequestFactory<PixTwoRequest, PixTwoModel>
    {
        public PixOneRequest Create(Payment parcel, PixOneModel model)
        {
            return new PixOneRequest();
        }

        public PixTwoRequest Create(Payment parcel, PixTwoModel model)
        {
            return new PixTwoRequest();
        }
    }
}
