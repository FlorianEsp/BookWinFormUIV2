using BO;
using BO.Interfaces;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IDalServices
    {
        void AddBook(IBook book);
        void AddLog(string message);
        IEnumerable<IBook> GetBooks();
        IEnumerable<DtoBooks> GetBooksByCountry(int Id);
        IEnumerable<ICountry> GetCountries();
    }
}