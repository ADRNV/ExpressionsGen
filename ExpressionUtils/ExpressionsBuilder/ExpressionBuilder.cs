using ExpressionUtils.Core;
using System.Linq.Expressions;

namespace ExpressionUtils.ExpressionsBuilder
{
    /// <summary>
    /// Represents builder for expressions
    /// </summary>
    public class ExpressionBuilder : IExpressionBuilder
    {
        public Dictionary<Type, IOperationResolver> Resolvers { get; private set; } = new();

        internal Expression Expression { get; set; }

        internal ExpressionType? LastOperation = null;
        public List<ParameterExpression> ParametersContext { get; private set; } = new();

        /// <summary>
        /// Builds ready lambda expression
        /// </summary>
        /// <returns></returns>
        public LambdaExpression Build()
        {
            return Expression.Lambda(Expression, ParametersContext);
        }

        /// <summary>
        /// Add parameters in "Expression scope"
        /// </summary>
        /// <param name="parameter">Requre parameter</param>
        /// <returns></returns>
        public ParameterExpression AddInContext(ParameterExpression parameter)
        {
            ParametersContext.Add(parameter);

            return parameter;
        }
    }
}
