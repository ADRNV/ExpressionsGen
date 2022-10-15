# ExpressionsGen
User-friendly API-Interface for writing expression

 1. ~~Fast~~
 2. ~~Reliable~~(Test incoming)
 3. Simple
 4. Understandable code
 
 **For example**
 What is more understadable from this two things ?
 
 this ?

    var lambda = new ExpressionBuilder()
    .Constant(2)
    .Multiply<int>()
    .Add<int>();
    
or this ?

    var p1 = Expression.Parameter(typeof(int));
    var p2 = Expression.Parameter(typeof(int));
    var expression = Expression.Add(p2, Expression.Multiply(c1, p1));
    var expression = Expression.Add(p2, Expression.Multiply(c1, p1));
    var lambda = Expression.Lambda<Func<int, int, int>>(expression, p1, p2).Compile();
