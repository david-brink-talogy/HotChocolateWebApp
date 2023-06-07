using HotChocolate.Types.Pagination;
using Trippin;

namespace HotChocolateWebApp
{
    public enum SortDirection
    {
        Asc,
        Desc
    }

    public class AirportCustomSortInput
    {
        public SortDirection? IcaoCode { get; set; }
        public SortDirection? Name { get; set; }
    }

    public class Query
    {
        private readonly Container _container;

        public Query([Service] Container container)
        {
            _container = container;
        }

        public IQueryable<Airport> GetAirports() => _container.Airports;
        public IQueryable<Airport> GetAirportsSelfSort(IEnumerable<AirportCustomSortInput>? order)
        {
            IQueryable<Airport> airports = _container.Airports;

            if (order is not null)
            {
                bool first = true;
                foreach (var singleOrder in order)
                {
                    airports = airports
                        .AddSort(a => a.IcaoCode, singleOrder.IcaoCode, ref first)
                        .AddSort(a => a.Name, singleOrder.Name, ref first)
                        ;
                }
            }

            return airports;
        }
    }

    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor
                .Field(q => q.GetAirports())
                .UseOffsetPaging(options: new PagingOptions { DefaultPageSize = 25, MaxPageSize = 100, IncludeTotalCount = true })
                .UseFiltering()
                .UseSorting()
            ;

            descriptor
                .Field(q => q.GetAirportsSelfSort(default!))
                .UseOffsetPaging(options: new PagingOptions { DefaultPageSize = 25, MaxPageSize = 100, IncludeTotalCount = true })
                .UseFiltering()
            ;
        }
    }


    public static class QueryableExtensions
    {
        public static IQueryable<TSource> AddSort<TSource, TKey>(this IQueryable<TSource> queryable, System.Linq.Expressions.Expression<Func<TSource, TKey>> keySelector, SortDirection? sortDirection, ref bool first)
        {
            if (sortDirection is null)
            {
                return queryable;
            }

            first = false;
            var ordered = queryable as IOrderedQueryable<TSource>;

            if (sortDirection == SortDirection.Asc)
            {
                return !first || ordered is null ? queryable.OrderBy(keySelector) : ordered.ThenBy(keySelector);
            }

            return !first || ordered is null ? queryable.OrderByDescending(keySelector) : ordered.ThenByDescending(keySelector);
        }
    }
}
