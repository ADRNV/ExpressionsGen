using System.Linq.Expressions;

namespace ExpressionUtils.Core
{
    public interface IOperationResolver
    {
        Expression Resolve(Expression left, ExpressionType? operation, Expression right);
    }
}
