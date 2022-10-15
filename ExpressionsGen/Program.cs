using System.Diagnostics;
using System.Linq.Expressions;
using ExpressionUtils.Core;
using ExpressionUtils.ExpressionsBuilder;

Stopwatch stopwatch = new Stopwatch();

var expressionBuilder = new ExpressionBuilder()
    .Constant(3);

for(int i = 0;i < 100;i++)
{
    expressionBuilder
        .Add(3);
        
}

stopwatch.Start();

var l = expressionBuilder.Build().Compile();

stopwatch.Stop();

Console.WriteLine($"{stopwatch.Elapsed.TotalSeconds} {l.DynamicInvoke()}");

