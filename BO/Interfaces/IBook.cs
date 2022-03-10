using System;

namespace BO.Interfaces
{
    public interface IBook
    {
        string Author { get; set; }
        int CountryId { get; set; }
        DateTime DatePublished { get; set; }
        string Description { get; set; }
        int Id { get; set; }
        decimal Price { get; set; }
        string Title { get; set; }
    }
}