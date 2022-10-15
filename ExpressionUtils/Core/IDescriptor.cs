using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionUtils.Core
{
    public interface IDescriptor
    {
        public ExpressionType NodeType { get; }

        public Type Type { get; }
    }
}
