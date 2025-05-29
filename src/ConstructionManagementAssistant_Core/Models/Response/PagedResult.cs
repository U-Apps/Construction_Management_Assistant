namespace ConstructionManagementAssistant.Core.Models.Response
{
    public class PagedResult<T>
    {
        public required List<T> Items { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
        public bool HasNextPage => PageSize * PageNumber < TotalItems;
        public bool HasPreveiosPage => PageNumber > 1;
    }
}
