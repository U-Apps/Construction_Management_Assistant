namespace ConstructionManagementAssistant_Core.Models.Response
{
    public class PagedResult<T>
    {
        public required List<T> Items { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
    }
}
