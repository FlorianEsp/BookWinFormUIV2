using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BLL
{
    public class BllServices
    {
        DalServices ds = new DalServices();
        
        public List<Country> GetCountries()
        {
            var countries = ds.GetCountries();
            return countries;
        }

        public bool AddBook(Book book)
        {
            bool ok = false;
            try
            {
              
                if (book.DatePublished < DateTime.Now)
                {
                    ds.AddBook(book);
                    ok = true;  
                    return ok ;
                }
            }
            catch (Exception)
            {
                ok = false;
                throw; 
            }
            return ok;  
           
        }
        public List<Book> GetBooks()
        {
            var books = ds.GetBooks();
            return books;
           
        }
        public List<DtoBooks> GetBooksByCountry(int Id)
        {
            return ds.GetBooksByCountry(Id);

        }
        public void AddLog(string message)
        {
            ds.AddLog(message); 
        }
    }
}
