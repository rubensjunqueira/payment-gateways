using Domain;
using Microsoft.Extensions.DependencyInjection;
using Solution.Facotries;
using Solution.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Wrappers
{
    public abstract class ModelFactoryWrapper
    {
        public abstract TModel Create<TModel>(IServiceProvider provider) where TModel : class;
    }

    public class ModelFactoryWrapperImpl<T> : ModelFactoryWrapper
        where T : class
    {
        public override TModel Create<TModel>(IServiceProvider provider)
        {
            var factory = provider.GetRequiredService<IModelFactory<TModel>>();

            return factory == null ?
                throw new Exception("Factory not registred") :
                factory.Create();
        }
    }
}
