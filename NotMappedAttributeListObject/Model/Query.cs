using Microsoft.Extensions.Configuration;
using System;

namespace NotMappedAttributeListObject.Model
{
    public class Query
    {
        // https://chillicream.com/docs/hotchocolate/v12/fetching-data/pagination/#offset-pagination
        [UseOffsetPaging(MaxPageSize = 100, IncludeTotalCount = true, DefaultPageSize = 20)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<FArticle> GetFArticles([Service] AppDbContext context) =>
            context.FArticles;
    }

}
