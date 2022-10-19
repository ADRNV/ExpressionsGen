using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace ExpressionUtils.ExpressionsDescriptors
{
    /// <summary>
    /// Describe <see cref="LambdaExpression"/> in user-friendly format
    /// </summary>
    public class LambdaExpressionDescriptor : ExpressionDescriptorBase<LambdaExpression>
    {
        /// <summary>
        /// Contains all lambda parameters 
        /// </summary>
        public ReadOnlyCollection<ParameterExpression> Parameters { get => _expression.Parameters; }

        /// <summary>
        /// Return type of lambda
        /// </summary>
        public Type ReturnType { get => _expression.ReturnType; }

        /// <summary>
        /// Body of lambda
        /// </summary>
        public Expression Body { get => _expression.Body; }

        /// <summary>
        /// Creates new <see cref="LambdaExpressionDescriptor"/>
        /// </summary>
        /// <param name="expression">Lamda expression</param>
        public LambdaExpressionDescriptor(LambdaExpression expression) : base(expression)
        {

        }
    }
}
