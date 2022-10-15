using ExpressionUtils.Core;
using ExpressionUtils.ExpressionsDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionUtils.Visitors
{
    public abstract class VisitorBase<E> : IVisitor where E: Expression
    {
        protected readonly E _node;

        public VisitorBase(E node)
        {
            this._node = node;
        }

        public abstract void Visit();

        public ExpressionType NodeType => this._node.NodeType;

        public static IVisitor CreateFromExpression(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                    return new ConstantVisitor((ConstantExpression)node);
                case ExpressionType.Lambda:
                    return new LambdaVisitor((LambdaExpression)node);
                case ExpressionType.Parameter:
                    return new ParameterVisitor((ParameterExpression)node);
                case ExpressionType.Add:
                case ExpressionType.Multiply:
                case ExpressionType.Subtract:
                    return new BinaryVisitor((BinaryExpression)node);
                default:
                    throw new InvalidOperationException("Cant find node type");
            }
        }
    }
}
