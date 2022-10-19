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
            return Expression.MakeBinary((ExpressionType)operation, left, right);
        }
    }
}
