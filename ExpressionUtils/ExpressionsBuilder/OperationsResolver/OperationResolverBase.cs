using ExpressionUtils.Core;
using System.Linq.Expressions;

namespace ExpressionUtils.ExpressionsBuilder.OperationsResolver
{
    public abstract class OperationResolverBase : IOperationResolver
    {
        public OperationResolverBase()
        {

        }

        public abstract Expression Resolve(Expression left, ExpressionType? operation, Expression right);
    }
}
