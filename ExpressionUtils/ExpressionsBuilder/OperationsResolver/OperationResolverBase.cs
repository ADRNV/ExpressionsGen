using ExpressionUtils.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionUtils.ExpressionsBuilder.OperationsResolver
{
    public abstract class OperationResolverBase : IOperationResolver
    {
        public OperationResolverBase()
        {

        }

        public abstract Expression Resolve(Expression left, ExpressionType operation, Expression right);
    }
}
