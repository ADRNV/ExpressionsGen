using System.Linq.Expressions;

namespace ExpressionUtils.Core
{
    /// <summary>
    /// Represents base expression builder logic
    /// </summary>
    public interface IExpressionBuilder
    {
        LambdaExpression Build();

        ParameterExpression AddInContext(ParameterExpression parameter);
    }
}
