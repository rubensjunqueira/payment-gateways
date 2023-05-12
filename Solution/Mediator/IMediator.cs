using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Mediator
{
    public interface IPaymentMediator
    {
        void Pay(Payment parcel);
    }
}
