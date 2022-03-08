using Tranzact.TopProgrammingLanguage.Domain.Enums;

namespace Tranzact.TopProgrammingLanguage.Domain.Common
{
    public interface ISearchResult
    {
        long GetTotal();

        string GetSearchTerm();

        string GetSearchTime();

        SearchEngineTypes GetSearchEngine();
    }
}
