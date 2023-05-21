# ExpressionsGen
User-friendly API-Interface for writing expression

 1. ~~Fast~~
 2. Simple
 3. Understandable code
 
 **For example**
 What is more understadable from this two things ?
 
 this ?
 
```csharp
    var lambda = new ExpressionBuilder()
    .Constant(40)
    .Add<int>()
    .Constant(2);
```
    
or this ?

```csharp
    var c1 = Expression.Constant(40);
    var c2 = Expression.Constant(2);
    
    var expression = Expression.MakeBinary(ExpressionType.Add, c1, c2);
    
    var lambda = Expression.Lambda<Func<int>>(expression, c1, c2)
    .Compile();
```
