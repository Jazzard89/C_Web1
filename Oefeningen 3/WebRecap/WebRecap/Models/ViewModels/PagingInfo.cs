namespace WebRecap.Models.ViewModels
{
    public class PagingInfo
    {
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public string TopicName { get; set; } = "Home";

        public int NextPage => CurrentPage < TotalPages ? CurrentPage + 1 : CurrentPage;
        public int PreviousPage => CurrentPage > 1 ? CurrentPage - 1 : CurrentPage;

        public bool NextVisible => CurrentPage < TotalPages;
        public bool PrevVisible => CurrentPage > 1;
    }
}
