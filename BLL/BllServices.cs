using System;
using System.Collections.Generic;
using BLL.Interfaces;
using BO;
using BO.Interfaces;
using DAL;
using DAL.Interfaces;

namespace BLL
{
    public class BllServices : IBllServices
    {
        private readonly IDalServices ds = new DalServices();

        public IEnumerable<ICountry> GetCountries()
        {
            return ds.GetCountries();
        }

        public bool AddBook(IBook book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (book.DatePublished > DateTime.Now)
                return false;

            ds.AddBook(book);
            return true;
        }

        public IEnumerable<IBook> GetBooks()
        {
            return ds.GetBooks();
        }

        public IEnumerable<DtoBooks> GetBooksByCountry(int Id)
        {
            return ds.GetBooksByCountry(Id);
        }

        public void AddLog(string message)
        {
            ds.AddLog(message);
        }
    }
}
