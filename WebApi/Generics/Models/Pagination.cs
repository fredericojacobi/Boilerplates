namespace Generics.Models;

public class Pagination<T> where T : class
{
    public IEnumerable<T> Records { get; }

    public int PageSize { get; }

    public int CurrentPage { get; }

    public int NextPage => TotalPages > CurrentPage ? CurrentPage + 1 : CurrentPage;

    public int PreviousPage => CurrentPage > 1 ? CurrentPage - 1 : CurrentPage;

    public int LastPage => TotalPages;

    public int TotalRecords { get; }

    public int TotalPages => (int)Math.Ceiling((double)Records.Count() / PageSize);

    public bool HasNextPage => NextPage > CurrentPage;

    public bool HasPreviousPage => PreviousPage < CurrentPage;

    public Pagination(IEnumerable<T> records, int totalRecords, int currentPage = 1, int pageSize = 10)
    {
        Records = records;
        CurrentPage = currentPage;
        TotalRecords = totalRecords;
        PageSize = pageSize;
    }
}