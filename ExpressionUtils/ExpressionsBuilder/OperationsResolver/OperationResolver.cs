using System.Linq.Expressions;

namespace ExpressionUtils.ExpressionsBuilder.OperationsResolver
{
    public class OperationResolver : OperationResolverBase
    {
        public OperationResolver()
        {

        }

        public override Expression Resolve(Expression left, ExpressionType? operation, Expression right)
        {
            return Expression.MakeBinary((ExpressionType)operation, left, right);
        }
    }
}
