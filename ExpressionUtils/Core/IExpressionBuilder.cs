using System.Linq.Expressions;

namespace ExpressionUtils.Core
{
    /// <summary>
    /// Represents base expression builder logic
    /// </summary>
    public interface IExpressionBuilder
    {
        public Dictionary<Type, IOperationResolver> Resolvers { get; }

        internal Expression Expression { get; set; }

        public ExpressionType? LastOperation { get; internal set; }

        public List<ParameterExpression> ParametersContext { get; }

        LambdaExpression Build();

        ParameterExpression AddInContext(ParameterExpression parameter);
    }
}
