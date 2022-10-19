using ExpressionUtils.Core;
using ExpressionUtils.ExpressionsBuilder.OperationsResolver;
using System.Linq.Expressions;

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
            try
            {
                var resolver = ManageResolver<OperationResolver>(expressionBuilder, typeof(OperationResolver));

                var expression = resolver.Resolve(expressionBuilder.Expression, expressionBuilder.LastOperation, Expression.Constant(value, typeof(T)));

                expressionBuilder.Expression = expression;

                return expressionBuilder;
            }
            catch
            {
                expressionBuilder.Expression = Expression.Constant(value);

                return expressionBuilder;
            }

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

            expressionBuilder.ParametersContext.Add(parameter);

            var resolver = ManageResolver<OperationResolver>(expressionBuilder, typeof(OperationResolver));

            var expression = resolver.Resolve(expressionBuilder.Expression, expressionBuilder.LastOperation, parameter);

            expressionBuilder.Expression = expression;

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

        public static ExpressionBuilder NestedExpression(this ExpressionBuilder root, ExpressionBuilder nestedExpressionBuilder)
        {
            root.Expression = nestedExpressionBuilder.Expression;

            return root;
        }
        #endregion

        #region Operations
        public static ExpressionBuilder Add<T>(this ExpressionBuilder expressionBuilder)
        {
            expressionBuilder.LastOperation = ExpressionType.Add;

            return expressionBuilder;
        }

        public static ExpressionBuilder Substract<T>(this ExpressionBuilder expressionBuilder)
        {
            expressionBuilder.LastOperation = ExpressionType.Subtract;

            return expressionBuilder;
        }

        public static ExpressionBuilder Multiply<T>(this ExpressionBuilder expressionBuilder)
        {
            expressionBuilder.LastOperation = ExpressionType.Multiply;

            return expressionBuilder;
        }

        public static ExpressionBuilder Divide<T>(this ExpressionBuilder expressionBuilder)
        {
            expressionBuilder.LastOperation = ExpressionType.Divide;

            return expressionBuilder;
        }
        #endregion

        internal static IOperationResolver ManageResolver<TResolver>(ExpressionBuilder expressionBuilder, Type resolverType) where TResolver : class, IOperationResolver
        {
            if (expressionBuilder?.LastOperation is not null)
            {
                if (!expressionBuilder.Resolvers.TryGetValue(resolverType, out var resolver))
                {
                    resolver = Activator.CreateInstance(resolverType) as
                        IOperationResolver;

                    expressionBuilder.Resolvers.Add(resolverType, resolver);
                }

                return resolver;
            }
            else
            {
                return expressionBuilder.Resolvers[resolverType];
            }
        }
    }
}
