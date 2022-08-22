namespace Library.API.Helpers {
    public class PaginationHeader {
        public PaginationHeader(int currentPage, int itemsPerPages, int totalItems, int totalCount) {
            CurrentPage = currentPage;
            ItemsPerPages = itemsPerPages;
            TotalItems = totalItems;
            TotalCount = totalCount;
        }

        public int CurrentPage { get; set; }
        public int ItemsPerPages { get; set; }
        public int TotalItems { get; set; }
        public int TotalCount { get; set; }
    }
}
