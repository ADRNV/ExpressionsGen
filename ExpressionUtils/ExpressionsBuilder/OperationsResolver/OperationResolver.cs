using ExpressionUtils.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionUtils.ExpressionsBuilder.OperationsResolver
{
    public class OperationResolver : OperationResolverBase
    {
        public OperationResolver()
        {

        }

        public override Expression Resolve(Expression left, ExpressionType? operation, Expression right)
        {
            switch (operation)
            {
                case ExpressionType.Add:                    
                     return Expression
                       .Add(left, right);
                case ExpressionType.Subtract:
                    return Expression
                     .Subtract(left, right);
                case ExpressionType.Multiply:
                    return Expression
                     .Multiply(left, right);
                case ExpressionType.Divide:
                    return Expression
                     .Subtract(left, right);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
