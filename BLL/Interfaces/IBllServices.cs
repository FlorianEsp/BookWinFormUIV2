using BO;
using BO.Interfaces;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IBllServices
    {
        bool AddBook(IBook book);
        void AddLog(string message);
        IEnumerable<IBook> GetBooks();
        IEnumerable<DtoBooks> GetBooksByCountry(int Id);
        IEnumerable<ICountry> GetCountries();
    }
}