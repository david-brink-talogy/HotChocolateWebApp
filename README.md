The first query uses HotChocolate sorting and generates a "must be reducible node" error. The error occurs even if a connection cannot be made to the OData endpoint.

```GraphQL
{
  airports(order: [{ name: ASC }]) {
    name
    location {
      address
      city {
        name
      }
    }
  }
  airportsSelfSort(order: [{ name: ASC }]) {
    name
    location {
      address
      city {
        name
      }
    }
  }
}
```

Stack Trace

```
   at System.Linq.Expressions.Expression.VisitChildren(ExpressionVisitor visitor)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortVisitorContextExtensions.OrderingMethodFinder.Visit(Expression node)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortVisitorContextExtensions.OrderingMethodFinder.OrderMethodExists(Expression expression)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortVisitorContextExtensions.Compile(QueryableSortContext context, Expression source)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortVisitorContextExtensions.Sort[TSource](QueryableSortContext context, IQueryable`1 source)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortProvider.<>c__DisplayClass14_1`1.<CreateApplicatorAsync>b__1(IQueryable`1 q)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortProvider.ApplyToResult[TEntityType](Object input, Func`2 sort)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortProvider.<>c__DisplayClass14_0`1.<CreateApplicatorAsync>b__0(IResolverContext context, Object input)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortProvider.<>c__DisplayClass9_0`1.<<CreateExecutor>g__ExecuteAsync|1>d.MoveNext()
--- End of stack trace from previous location ---
   at HotChocolate.Execution.Processing.Tasks.ResolverTask.ExecuteResolverPipelineAsync(CancellationToken cancellationToken)
   at HotChocolate.Execution.Processing.Tasks.ResolverTask.TryExecuteAsync(CancellationToken cancellationToken)
```
