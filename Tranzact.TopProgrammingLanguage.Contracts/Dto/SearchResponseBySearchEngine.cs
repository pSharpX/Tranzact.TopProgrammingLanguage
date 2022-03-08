namespace Tranzact.TopProgrammingLanguage.Contracts.Dto
{
    public class SearchResponseBySearchEngine
    {
        public string SearchTermWinner{ get; set; }

        public long Total { get; set; }

        public string SearchEngine{ get; set; }
    }
}
