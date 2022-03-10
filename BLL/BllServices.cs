using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using BO;
using BO.Interfaces;
using DAL;
using DAL.Interfaces;

namespace BLL
{
    public class BllServices : IBllServices
    {
        readonly IDalServices ds = new DalServices();
        public IEnumerable<ICountry> GetCountries()
        {
            var countries = ds.GetCountries();
            return countries;
        }
        public bool AddBook(IBook book)
        {
            bool ok = false;
            try
            {
                if (book.DatePublished < DateTime.Now)
                {
                    ds.AddBook(book);
                    ok = true;
                    return ok;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return ok;
        }
        public IEnumerable<IBook> GetBooks()
        {
            var books = ds.GetBooks();
            return books;
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
