using Ninject;
using Ninject.Modules;

namespace ExpressionUtilsTests.Helpers.Di
{
    public class IoCKernel
    {
        public IKernel Kernel { get; }

        public IoCKernel(params NinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);
        }
    }
}
