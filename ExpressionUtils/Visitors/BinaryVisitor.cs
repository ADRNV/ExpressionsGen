using ExpressionUtils.Core;
using ExpressionUtils.ExpressionsDescriptors;
using System.Linq.Expressions;

namespace ExpressionUtils.Visitors
{
    internal class BinaryVisitor : VisitorBase<BinaryExpression>
    {
        public BinaryVisitor(BinaryExpression binaryExpression): base(binaryExpression)
        {

        }

        public override void Visit()
        {
            CreateFromExpression(_node.Left);

            CreateFromExpression(_node.Right);

            CreateFromExpression(_node);
        }
    }
}