using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionUtils.Visitors
{
    public class ConstantVisitor : VisitorBase<ConstantExpression>
    {
        public ConstantExpression ConstantNode { get; }
        public ConstantVisitor(ConstantExpression constantExpression) : base(constantExpression)
        {
            this.ConstantNode = constantExpression;
        }
        public override void Visit()
        {
            throw new NotImplementedException();
        }
    }
}
