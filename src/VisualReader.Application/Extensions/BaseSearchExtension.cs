using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace VisualReader
{
    public static class BaseSearchExtension
    {
        public static async Task<SearchResponse<T>> SearchAsync<T>(this IQueryable<T> query, SearchRequest request)
        {
            var data = await query.ToListAsync();
            var dataFilter = data;
            var filters = JsonConvert.DeserializeObject<IEnumerable<Filter>>(request.Filter);
            if (filters != null && filters.Any())
            {
                foreach (var filter in filters)
                {
                    switch (filter.DataType)
                    {
                        case DataTypeConstant.NUMBER:
                            switch (filter.Condition)
                            {
                                case CondictionConstant.BETTER_THAN:
                                    dataFilter = dataFilter.Where(x => double.Parse(x.GetType().GetProperty(filter.Field).GetValue(x).ToString()) > double.Parse(filter.Value.ToString())).ToList();
                                    break;

                                case CondictionConstant.LESS_THAN:
                                    dataFilter = dataFilter.Where(x => double.Parse(x.GetType().GetProperty(filter.Field).GetValue(x).ToString()) < double.Parse(filter.Value.ToString())).ToList();
                                    break;

                                default:
                                    dataFilter = dataFilter.Where(x => double.Parse(x.GetType().GetProperty(filter.Field).GetValue(x).ToString()) == double.Parse(filter.Value.ToString())).ToList();
                                    break;
                            }
                            break;

                        case DataTypeConstant.BOOL:
                            dataFilter = dataFilter.Where(x => bool.Parse(x.GetType().GetProperty(filter.Field).GetValue(x).ToString()) == bool.Parse(filter.Value.ToString())).ToList();
                            break;

                        default:
                            switch (filter.Condition)
                            {
                                case CondictionConstant.EQUAL:
                                    dataFilter = dataFilter.Where(x => filter.Value.ToString().Equals(x.GetType().GetProperty(filter.Field).GetValue(x).ToString())).ToList();
                                    break;

                                default:
                                    dataFilter = dataFilter.Where(x => filter.Value.ToString().Contains(x.GetType().GetProperty(filter.Field).GetValue(x).ToString())).ToList();
                                    break;
                            }
                            break;
                    }
                }
            }
            var dataOnPage = dataFilter.Skip(request.PageSize * request.PageIndex).Take(request.PageSize).ToList();
            return new SearchResponse<T>(request.PageIndex, request.PageSize, dataFilter.Count, dataOnPage);
        }
    }
}