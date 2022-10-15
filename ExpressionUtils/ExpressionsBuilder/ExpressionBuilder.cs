using ExpressionUtils.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionUtils.ExpressionsBuilder
{
    /// <summary>
    /// Represents builder for expressions
    /// </summary>
    public class ExpressionBuilder : IExpressionBuilder
    {
        internal Expression Expression { get; set; }

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
        internal ParameterExpression AddInContext(ParameterExpression parameter)
        {
            ParametersContext.Add(parameter);

            return parameter;
        }
    }
}
