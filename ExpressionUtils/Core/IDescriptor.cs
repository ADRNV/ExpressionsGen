using System.Linq.Expressions;

namespace ExpressionUtils.Core
{
    public interface IDescriptor
    {
        public ExpressionType NodeType { get; }

        public Type Type { get; }
    }
}
