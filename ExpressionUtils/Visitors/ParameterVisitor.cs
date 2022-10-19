using System.Linq.Expressions;

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
