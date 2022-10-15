using ExpressionUtils.ExpressionsDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionUtils.Visitors
{
    public class ParameterVisitor : VisitorBase<ParameterExpression>
    {
        public ParameterVisitor(ParameterExpression parameterExpression) : base(parameterExpression)
        {

        }

        public override void Visit()
        {
            throw new NotImplementedException();
        }
    }
}
