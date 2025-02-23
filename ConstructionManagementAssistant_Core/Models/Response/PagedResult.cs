namespace ConstructionManagementAssistant_Core.Models.Response
{
    public class PagedResult<T>
    {
        public required List<T> Items { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
        public bool HasNextPage => PageSize * CurrentPage < TotalItems;
        public bool HasPreveiosPage => CurrentPage > 1;
    }
}
