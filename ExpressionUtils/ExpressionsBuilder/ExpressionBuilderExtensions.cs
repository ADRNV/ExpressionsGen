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
        public static IExpressionBuilder Constant<T>(this IExpressionBuilder expressionBuilder, T value)
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
        public static IExpressionBuilder Parameter<TParam>(this IExpressionBuilder expressionBuilder)
        {
            return Parameter<TParam>(expressionBuilder, $"Param{Guid.NewGuid()}");
        }

        /// <summary>
        /// Add parameter in expression
        /// </summary>
        /// <typeparam name="TParam">Parameter type</typeparam>
        /// <param name="name">Name of parameter</param>
        /// <param name="expressionBuilder">Builder</param>
        /// <returns> <see cref="ExpressionBuilder"/> - builder for next operation</returns>
        public static IExpressionBuilder Parameter<TParam>(this IExpressionBuilder expressionBuilder, string name)
        {
            var parameter = Expression.Parameter(typeof(TParam), name);

            expressionBuilder.ParametersContext.Add(parameter);

            try
            {
                var resolver = ManageResolver<OperationResolver>(expressionBuilder, typeof(OperationResolver));

                var expression = resolver.Resolve(expressionBuilder.Expression, expressionBuilder.LastOperation, parameter);
            }
            catch
            {
                expressionBuilder.Expression = Expression.Parameter(typeof(TParam), name);
            }

            return expressionBuilder;
        }

        /// <summary>
        /// Experemental API !
        /// </summary>
        /// <typeparam name="TLambda"></typeparam>
        /// <param name="expressionBuilder"></param>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public static IExpressionBuilder Lambda<TLambda>(this IExpressionBuilder expressionBuilder, LambdaExpression lambda)
        {
            //Adds parameter on top
            //foreach (var parameter in lambda.Parameters)
            //{
            //    expressionBuilder.AddInContext(parameter);
            //}

            expressionBuilder.Expression = Expression.Lambda(lambda, lambda.Parameters).Body;

            return expressionBuilder;
        }

        public static IExpressionBuilder NestedExpression(this IExpressionBuilder root, ExpressionBuilder nestedExpressionBuilder)
        {
            root.Expression = nestedExpressionBuilder.Expression;

            return root;
        }
        #endregion

        #region Operations
        public static IExpressionBuilder Add<T>(this IExpressionBuilder expressionBuilder)
        {
            expressionBuilder.LastOperation = ExpressionType.Add;

            return expressionBuilder;
        }

        public static IExpressionBuilder Substract<T>(this IExpressionBuilder expressionBuilder)
        {
            expressionBuilder.LastOperation = ExpressionType.Subtract;

            return expressionBuilder;
        }

        public static IExpressionBuilder Multiply<T>(this IExpressionBuilder expressionBuilder)
        {
            expressionBuilder.LastOperation = ExpressionType.Multiply;

            return expressionBuilder;
        }

        public static IExpressionBuilder Divide<T>(this IExpressionBuilder expressionBuilder)
        {
            expressionBuilder.LastOperation = ExpressionType.Divide;

            return expressionBuilder;
        }
        #endregion

        internal static IOperationResolver ManageResolver<TResolver>(IExpressionBuilder expressionBuilder, Type resolverType) where TResolver : class, IOperationResolver
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
