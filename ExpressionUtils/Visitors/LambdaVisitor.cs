using System.Linq.Expressions;

namespace ExpressionUtils.Visitors
{
    internal class LambdaVisitor : VisitorBase<LambdaExpression>
    {
        public LambdaVisitor(LambdaExpression lambdaExpression) : base(lambdaExpression)
        {

        }

        public override void Visit()
        {
            foreach (var parameter in _node.Parameters)
            {
                CreateFromExpression(parameter);
            }

        }
    }
}
