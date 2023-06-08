The first query uses HotChocolate sorting and generates a "must be reducible node" error.

```GraphQL
{
  airports(order: [{ name: ASC }]) {
    items {
      name
      location {
        address
        city {
          name
        }
      }
    }
  }
  airportsSelfSort(order: [{ name: ASC }]) {
    items {
      name
      location {
        address
        city {
          name
        }
      }
    }
  }
}
```

Stack Trace

```
at System.Linq.Expressions.Expression.VisitChildren(ExpressionVisitor visitor)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortVisitorContextExtensions.OrderingMethodFinder.Visit(Expression node)
   at System.Dynamic.Utils.ExpressionVisitorUtils.VisitArguments(ExpressionVisitor visitor, IArgumentProvider nodes)
   at System.Linq.Expressions.ExpressionVisitor.VisitMethodCall(MethodCallExpression node)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortVisitorContextExtensions.OrderingMethodFinder.VisitMethodCall(MethodCallExpression node)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortVisitorContextExtensions.OrderingMethodFinder.Visit(Expression node)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortVisitorContextExtensions.OrderingMethodFinder.OrderMethodExists(Expression expression)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortVisitorContextExtensions.Compile(QueryableSortContext context, Expression source)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortVisitorContextExtensions.Sort[TSource](QueryableSortContext context, IQueryable`1 source)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortProvider.<>c__DisplayClass14_1`1.<CreateApplicatorAsync>b__1(IQueryable`1 q)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortProvider.ApplyToResult[TEntityType](Object input, Func`2 sort)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortProvider.<>c__DisplayClass14_0`1.<CreateApplicatorAsync>b__0(IResolverContext context, Object input)
   at HotChocolate.Data.Sorting.Expressions.QueryableSortProvider.<>c__DisplayClass9_0`1.<<CreateExecutor>g__ExecuteAsync|1>d.MoveNext()
--- End of stack trace from previous location ---
   at HotChocolate.Data.Filters.Expressions.QueryableFilterProvider.<>c__DisplayClass10_0`1.<<CreateExecutor>g__ExecuteAsync|1>d.MoveNext()
--- End of stack trace from previous location ---
   at HotChocolate.Types.Pagination.PagingMiddleware.InvokeAsync(IMiddlewareContext context)
   at HotChocolate.Utilities.MiddlewareCompiler`1.ExpressionHelper.AwaitTaskHelper(Task task)
   at PsiTm.Scoring.Results.Service.Queries.ConnectedEvaluationResultMiddleware.InvokeAsync(IMiddlewareContext context) in C:\\Repos\\NexusScoringResult\\src\\PsiTm.Scoring.Results.Service\\Queries\\Query.cs:line 94
   at HotChocolate.Utilities.MiddlewareCompiler`1.ExpressionHelper.AwaitTaskHelper(Task task)
   at HotChocolate.Authorization.AuthorizeMiddleware.InvokeAsync(IMiddlewareContext context)
   at HotChocolate.Authorization.AuthorizationTypeInterceptor.<>c__DisplayClass26_1.<<CreateAuthMiddleware>b__1>d.MoveNext()
--- End of stack trace from previous location ---
   at HotChocolate.Authorization.AuthorizeMiddleware.InvokeAsync(IMiddlewareContext context)
   at HotChocolate.Authorization.AuthorizeDirectiveType.<>c__DisplayClass3_0.<<CreateMiddleware>b__1>d.MoveNext()
--- End of stack trace from previous location ---
   at HotChocolate.Execution.Processing.Tasks.ResolverTask.ExecuteResolverPipelineAsync(CancellationToken cancellationToken)
   at HotChocolate.Execution.Processing.Tasks.ResolverTask.TryExecuteAsync(CancellationToken cancellationToken)
```
