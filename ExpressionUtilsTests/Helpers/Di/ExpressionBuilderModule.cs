using ExpressionUtils.Core;
using ExpressionUtils.ExpressionsBuilder;
using Ninject.Modules;

namespace ExpressionUtilsTests.Helpers.Di
{
    public class ExpressionBuilderModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IExpressionBuilder>()
                .To<ExpressionBuilder>();
        }
    }
}
