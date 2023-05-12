using Solution.Models.GatewayOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Facotries
{
    public interface IModelFactory<TModel>
    {
        TModel Create();
    }

    public class ModelFactory :
        IModelFactory<PixOneModel>,
        IModelFactory<PixTwoModel>
    {
        PixOneModel IModelFactory<PixOneModel>.Create()
        {
            return new PixOneModel();
        }

        PixTwoModel IModelFactory<PixTwoModel>.Create()
        {
            return new PixTwoModel();
        }
    }
}
