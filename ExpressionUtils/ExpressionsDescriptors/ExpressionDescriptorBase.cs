using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ExpressionUtils.Core;
using ExpressionUtils.Visitors;

namespace ExpressionUtils.ExpressionsDescriptors
{
    /// <summary>
    /// Discribe expression in user-friendly format 
    /// </summary>
    /// <typeparam name="T">Expression type</typeparam>
    public class ExpressionDescriptorBase<T> : IDescriptor where T: Expression
    {
        protected readonly T _expression;

        public ExpressionDescriptorBase(T expression)
        {
            _expression = expression;
        }

        public ExpressionType NodeType { get => _expression.NodeType; }

        public Type Type { get => _expression.Type; }
    }
}
