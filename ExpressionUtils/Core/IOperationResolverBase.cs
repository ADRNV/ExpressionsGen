using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionUtils.Core
{
    public interface IOperationResolver
    {
        Expression Resolve(Expression left, ExpressionType operation, Expression right);
    }
}
