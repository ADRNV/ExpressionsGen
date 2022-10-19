using System.Linq.Expressions;

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
