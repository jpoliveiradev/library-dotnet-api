using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Library.API.Helpers {
    public static class Extensions {
        public static void AddPagination(this HttpResponse response,
                int currentPage, int itemsPerPages,
                int totalItems, int totalCount) {

            var paginationHeader = new PaginationHeader(currentPage, itemsPerPages, totalItems, totalCount);

            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));

            response.Headers.Add("Access-Control-Expose-Header", "Pagination");

        }
    }
}
