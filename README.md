This repo is a minimal reproductibale example for https://stackoverflow.com/questions/78623076/notmapped-attribute-is-ignored-when-used-on-list-of-object

### Prerequires
- A microsoft SQL server with a database named `not_mapped` (if you want another name for the database change the `NotMappedAttributeListObject/appsettings.json` file)

### Installation

- `git clone https://github.com/Lenny4/NotMappedAttributeListObject.git`
- `cd .\NotMappedAttributeListObject\`
- `dotnet ef database update -c AppDbContext`
- launch the project by clicking the Run button ![Screenshot 2024-06-18 222206](https://github.com/Lenny4/NotMappedAttributeListObject/assets/25544892/a1ef140e-7491-47a8-9115-ecb0c12edabb)
 
or with command `dotnet run`

Open Postman and add a new GraphQl request:
![image](https://github.com/Lenny4/NotMappedAttributeListObject/assets/25544892/6e3aed97-15b5-4534-b3f6-1048c7ff1f72)

With url `http://localhost:5066/graphql` and data 
```
query FArticles {
    fArticles(take: 1, skip: 0) {
        totalCount
        items {
            cbMarq
            arRef
            prices {
                someValue
            }
        }
    }
}
```
Then launch it, you should have the result:
```
{
    "errors": [
        {
            "message": "Unexpected Execution Error",
            "locations": [
                {
                    "line": 2,
                    "column": 5
                }
            ],
            "path": [
                "fArticles"
            ],
            "extensions": {
                "message": "The LINQ expression 'p1 => new PriceDto{ SomeValue = p1.SomeValue }\r\n' could not be translated. Either rewrite the query in a form that can be translated, or switch to client evaluation explicitly by inserting a call to 'AsEnumerable', 'AsAsyncEnumerable', 'ToList', or 'ToListAsync'. See https://go.microsoft.com/fwlink/?linkid=2101038 for more information.",
                "stackTrace": "   at Microsoft.EntityFrameworkCore.Query.RelationalSqlTranslatingExpressionVisitor.VisitLambda[T](Expression`1 lambdaExpression)\r\n   at Microsoft.EntityFrameworkCore.Query.RelationalSqlTranslatingExpressionVisitor.TranslateInternal(Expression expression, Boolean applyDefaultTypeMapping)\r\n   at Microsoft.EntityFrameworkCore.Query.RelationalSqlTranslatingExpressionVisitor.TranslateProjection(Expression expression, Boolean applyDefaultTypeMapping)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.RelationalProjectionBindingExpressionVisitor.Visit(Expression expression)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.RelationalProjectionBindingExpressionVisitor.VisitMethodCall(MethodCallExpression methodCallExpression)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.RelationalProjectionBindingExpressionVisitor.Visit(Expression expression)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.RelationalProjectionBindingExpressionVisitor.VisitMethodCall(MethodCallExpression methodCallExpression)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.RelationalProjectionBindingExpressionVisitor.Visit(Expression expression)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.RelationalProjectionBindingExpressionVisitor.VisitMemberAssignment(MemberAssignment memberAssignment)\r\n   at System.Linq.Expressions.ExpressionVisitor.VisitMemberBinding(MemberBinding node)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.RelationalProjectionBindingExpressionVisitor.VisitMemberInit(MemberInitExpression memberInitExpression)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.RelationalProjectionBindingExpressionVisitor.Visit(Expression expression)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.RelationalProjectionBindingExpressionVisitor.Translate(SelectExpression selectExpression, Expression expression)\r\n   at Microsoft.EntityFrameworkCore.Query.RelationalQueryableMethodTranslatingExpressionVisitor.TranslateSelect(ShapedQueryExpression source, LambdaExpression selector)\r\n   at Microsoft.EntityFrameworkCore.Query.QueryableMethodTranslatingExpressionVisitor.VisitMethodCall(MethodCallExpression methodCallExpression)\r\n   at Microsoft.EntityFrameworkCore.Query.RelationalQueryableMethodTranslatingExpressionVisitor.VisitMethodCall(MethodCallExpression methodCallExpression)\r\n   at Microsoft.EntityFrameworkCore.Query.QueryableMethodTranslatingExpressionVisitor.Translate(Expression expression)\r\n   at Microsoft.EntityFrameworkCore.Query.RelationalQueryableMethodTranslatingExpressionVisitor.Translate(Expression expression)\r\n   at Microsoft.EntityFrameworkCore.Query.QueryCompilationContext.CreateQueryExecutor[TResult](Expression query)\r\n   at Microsoft.EntityFrameworkCore.Storage.Database.CompileQuery[TResult](Expression query, Boolean async)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.CompileQueryCore[TResult](IDatabase database, Expression query, IModel model, Boolean async)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.<>c__DisplayClass12_0`1.<ExecuteAsync>b__0()\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.CompiledQueryCache.GetOrAddQuery[TResult](Object cacheKey, Func`1 compiler)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.ExecuteAsync[TResult](Expression query, CancellationToken cancellationToken)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.EntityQueryProvider.ExecuteAsync[TResult](Expression expression, CancellationToken cancellationToken)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.EntityQueryable`1.GetAsyncEnumerator(CancellationToken cancellationToken)\r\n   at System.Runtime.CompilerServices.ConfiguredCancelableAsyncEnumerable`1.GetAsyncEnumerator()\r\n   at HotChocolate.Types.Pagination.QueryableOffsetPagination`1.ExecuteAsync(IQueryable`1 query, CancellationToken cancellationToken)\r\n   at HotChocolate.Types.Pagination.OffsetPaginationAlgorithm`2.ApplyPaginationAsync(TQuery query, OffsetPagingArguments arguments, Nullable`1 totalCount, CancellationToken cancellationToken)\r\n   at HotChocolate.Types.Pagination.QueryableOffsetPagingHandler`1.ResolveAsync(IResolverContext context, IQueryable`1 source, OffsetPagingArguments arguments, CancellationToken cancellationToken)\r\n   at HotChocolate.Types.Pagination.OffsetPagingHandler.HotChocolate.Types.Pagination.IPagingHandler.SliceAsync(IResolverContext context, Object source)\r\n   at HotChocolate.Types.Pagination.PagingMiddleware.InvokeAsync(IMiddlewareContext context)\r\n   at HotChocolate.Utilities.MiddlewareCompiler`1.ExpressionHelper.AwaitTaskHelper(Task task)\r\n   at HotChocolate.Execution.Processing.Tasks.ResolverTask.ExecuteResolverPipelineAsync(CancellationToken cancellationToken)\r\n   at HotChocolate.Execution.Processing.Tasks.ResolverTask.TryExecuteAsync(CancellationToken cancellationToken)"
            }
        }
    ],
    "data": {
        "fArticles": null
    }
}
```
