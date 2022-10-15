using ExpressionUtils.ExpressionsDescriptors;
using System.Linq.Expressions;

namespace ExpressionUtils.Core
{
    /// <summary>
    /// Represents base visitor logic
    /// </summary>
    public interface IVisitor
    {
        void Visit();
    }
}
