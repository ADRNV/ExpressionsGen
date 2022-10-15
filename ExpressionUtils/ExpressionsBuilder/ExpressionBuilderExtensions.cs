using ExpressionUtils.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionUtils.ExpressionsBuilder
{
    public static class ExpressionBuilderExtensions
    {
        #region Definition 

        /// <summary>
        /// Add constant value in expression
        /// </summary>
        /// <typeparam name="T">Constant type</typeparam>
        /// <param name="expressionBuilder">Builder</param>
        /// <param name="value">Your constant</param>
        /// <returns>Builder for next operation</returns>
        public static ExpressionBuilder Constant<T>(this ExpressionBuilder expressionBuilder, T value)
        {
            expressionBuilder.Expression = Expression.Constant(value);

            return expressionBuilder;
        }

        /// <summary>
        /// Add parameter in expression
        /// </summary>
        /// <typeparam name="TParam">Parameter type</typeparam>
        /// <param name="expressionBuilder">Builder</param>
        /// <returns> <see cref="ExpressionBuilder"/> - builder for next operation</returns>
        public static ExpressionBuilder Parameter<TParam>(this ExpressionBuilder expressionBuilder)
        {
            var parameter = Expression.Parameter(typeof(TParam));

            expressionBuilder.AddInContext(parameter);

            expressionBuilder.Expression = parameter;

            return expressionBuilder;
        }

        /// <summary>
        /// Experemental API !
        /// </summary>
        /// <typeparam name="TLambda"></typeparam>
        /// <param name="expressionBuilder"></param>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public static ExpressionBuilder Lambda<TLambda>(this ExpressionBuilder expressionBuilder, TLambda lambda)
        {
            var metadata = lambda.GetType().GetMethods()[0];

            var lambdaParameters = new List<ParameterExpression>();

            foreach (var methodParameter in metadata.GetParameters())
            {

                var parameter = Expression.Parameter(methodParameter.GetType()); 

                expressionBuilder.AddInContext(parameter);

                lambdaParameters.Add(parameter);
            }

            var l = Expression.Call(metadata, lambdaParameters);

            expressionBuilder.Expression = l;

            return expressionBuilder;
        }

        #endregion

        #region Operations

        /// <summary>
        /// Add expression and constant value
        /// </summary>
        /// <typeparam name="T">Constant type</typeparam>
        /// <param name="expressionBuilder">Builder</param>
        /// <param name="right">your value</param>
        /// <returns> <see cref="ExpressionBuilder"/> - builder for next operation</returns>
        public static ExpressionBuilder Add<T>(this ExpressionBuilder expressionBuilder, T right)
        {
            expressionBuilder.Expression = Expression.Add(expressionBuilder.Expression, Expression.Constant(right));
       
            return expressionBuilder;
        }

        /// <summary>
        /// Add expression and parameter
        /// </summary>
        /// <typeparam name="TParam">Parameter type</typeparam>
        /// <param name="expressionBuilder">Builder</param>
        /// <returns> <see cref="ExpressionBuilder"/> - builder for next operation</returns>
        public static ExpressionBuilder Add<TParam>(this ExpressionBuilder expressionBuilder)
        {
            var parameter = Expression.Parameter(typeof(TParam));

            expressionBuilder.AddInContext(parameter);

            expressionBuilder.Expression = Expression.Add(expressionBuilder.Expression, parameter);

            return expressionBuilder;
        }

        /// <summary>
        /// Multiplies exprission and constant value
        /// </summary>
        /// <typeparam name="T">Type of constant</typeparam>
        /// <param name="expressionBuilder">Builder</param>
        /// <param name="right">Value</param>
        /// <returns> <see cref="ExpressionBuilder"/> - builder for next operation</returns>
        public static ExpressionBuilder Multiply<T>(this ExpressionBuilder expressionBuilder, T right)
        {
            expressionBuilder.Expression = Expression.Multiply(expressionBuilder.Expression, Expression.Constant(right));

            return expressionBuilder;
        }

        /// <summary>
        /// Multiplies exprission and parameter
        /// </summary>
        /// <typeparam name="TParam">Type of parameter</typeparam>
        /// <param name="expressionBuilder">Builder</param>
        /// <param name="right">Value</param>
        /// <returns> <see cref="ExpressionBuilder"/> - builder for next operation</returns>
        public static ExpressionBuilder Multiply<TParam>(this ExpressionBuilder expressionBuilder)
        {
            var parameter = Expression.Parameter(typeof(TParam));

            expressionBuilder.AddInContext(parameter);

            expressionBuilder.Expression = Expression.Add(expressionBuilder.Expression, parameter);

            return expressionBuilder;
        }

        #endregion
    }
}
