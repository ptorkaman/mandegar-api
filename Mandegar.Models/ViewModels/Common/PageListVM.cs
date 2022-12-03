namespace Mandegar.Models.ViewModels.Common
{
    public class PageListVM
    {
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public string OrderBy { get; set; }
        public bool OrderAsc { get; set; }
        public bool IsCount { get; set; }
    }
}
