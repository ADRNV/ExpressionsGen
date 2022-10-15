using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionUtils.Core
{
    /// <summary>
    /// Represents base expression builder logic
    /// </summary>
   public interface IExpressionBuilder
   {
        LambdaExpression Build();

        ParameterExpression AddInContext(ParameterExpression parameter);
   }
}
