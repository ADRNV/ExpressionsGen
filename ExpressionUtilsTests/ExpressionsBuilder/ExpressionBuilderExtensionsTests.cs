using NUnit.Framework;
using ExpressionUtils.ExpressionsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework.Constraints;
using ExpressionUtils.Core;
using ExpressionUtilsTests.Helpers.Di;
using Ninject;

namespace ExpressionUtils.ExpressionsBuilder.Tests
{
    [TestFixture()]
    public class ExpressionBuilderExtensionsTests
    {
        private static IExpressionBuilder _expressionBuilder;

        private readonly static IoCKernel _ioCKernel;

        static ExpressionBuilderExtensionsTests()
        {
            _ioCKernel = new IoCKernel(new ExpressionBuilderModule());
        }

        [Test()]
        public void ConstantTest()
        {
            //arrange
            var constantExpression = Expression.Constant(1);

            //act
            var expressionBuilder = _ioCKernel.Kernel.Get<IExpressionBuilder>()
                .Constant(1)
                .Build();

            //assert
            bool equalNodeTypes = expressionBuilder.Body.NodeType == constantExpression.NodeType;
            
            Assert.True(equalNodeTypes);
        }

        [Test()]
        public void ParameterTest()
        {
            //arrange
            var parameterExpression = Expression.Parameter(typeof(int), "x");

            //act
            var expressionBuilder = _ioCKernel.Kernel.Get<IExpressionBuilder>()
                .Parameter<int>("x")
                .Build();

            //assert

            bool equalsNames = parameterExpression.Name == expressionBuilder.Parameters[0].Name;
           
            bool equalsTypes = parameterExpression.Type == expressionBuilder.Parameters[0].Type;

            Assert.True(equalsNames);

            Assert.True(equalsTypes);
        }

        [Test()]
        public void LambdaTest()
        {
            //arrange
            var labmdaExpression = Expression.Lambda((int x) => x);

            //act
            var expressionBuilder = _ioCKernel.Kernel.Get<IExpressionBuilder>()
                .Lambda<Func<int, int>>((int x) => x)
                .Build();

            //assert
            bool equalsBodyes = labmdaExpression.Body.Type == expressionBuilder.Body.Type;

            Assert.True(equalsBodyes);
        }

        [Test()]
        public void NestedExpressionTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void AddTest()
        {
            //arrange
            var expressionBuilder = _ioCKernel.Kernel.Get<IExpressionBuilder>()
                .Constant(42)
                .Add<int>()
                .Constant(42)
                .Build();

            var addExpression = Expression.Add(Expression.Constant(42), Expression.Constant(42));

            //act
            var executionExpected = (int)Expression
                .Lambda(addExpression)
                .Compile()
                .DynamicInvoke()!;

            var executionActual = (int)expressionBuilder
                .Compile()
                .DynamicInvoke()!;

            //assert
            bool equalNodeTypes = expressionBuilder.Body.NodeType == addExpression.NodeType;

            bool equalsResults = executionActual == executionExpected;

            Assert.True(equalNodeTypes);
        }

        [Test()]
        public void SubstractTest()
        {
            //arrange
            var expressionBuilder = _ioCKernel.Kernel.Get<IExpressionBuilder>()
                .Constant(42)
                .Multiply<int>()
                .Constant(42)
                .Build();

            var substractExpression = Expression.Multiply(Expression.Constant(42), Expression.Constant(42));

            //act
            var executionExpected = (int)Expression
                .Lambda(substractExpression)
                .Compile()
                .DynamicInvoke()!;

            var executionActual = (int)expressionBuilder
                .Compile()
                .DynamicInvoke()!;

            //assert
            bool equalNodeTypes = expressionBuilder.Body.NodeType == substractExpression.NodeType;

            bool equalsResults = executionActual == executionExpected;

            Assert.True(equalNodeTypes);

            Assert.True(equalsResults);
        }

        [Test()]
        public void MultiplyTest()
        {
            //arrange
            var expressionBuilder = _ioCKernel.Kernel.Get<IExpressionBuilder>()
                .Constant(42)
                .Divide<int>()
                .Constant(42)
                .Build();

            var multiplyExpression = Expression.Divide(Expression.Constant(42), Expression.Constant(42));

            //act
            var executionExpected = (int)Expression
                .Lambda(multiplyExpression)
                .Compile()
                .DynamicInvoke()!;

            var executionActual = (int)expressionBuilder
                .Compile()
                .DynamicInvoke()!;

            //assert
            bool equalNodeTypes = expressionBuilder.Body.NodeType == multiplyExpression.NodeType;

            bool equalsResults = executionActual == executionExpected;

            Assert.True(equalNodeTypes);

            Assert.True(equalsResults);
        }

        [Test()]
        public void DivideTest()
        {
            //arrange
            var expressionBuilder = _ioCKernel.Kernel.Get<IExpressionBuilder>()
                .Constant(42)
                .Divide<int>()
                .Constant(42)
                .Build();

            var devideExpression = Expression.Divide(Expression.Constant(42), Expression.Constant(42));

            //act
            var executionExpected = (int)Expression
                .Lambda(devideExpression)
                .Compile()
                .DynamicInvoke()!;

            var executionActual = (int)expressionBuilder
                .Compile()
                .DynamicInvoke()!;

            //assert
            bool equalNodeTypes = expressionBuilder.Body.NodeType == devideExpression.NodeType;

            bool equalsResults = executionActual == executionExpected;

            Assert.True(equalNodeTypes);

            Assert.True(equalsResults);
        }
    }
}