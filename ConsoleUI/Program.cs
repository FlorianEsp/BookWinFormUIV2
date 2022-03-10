using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using BLL;


namespace ConsoleUI
{
    public class Program
    {
        static IBllServices bllServices = new BllServices();
        static void Main(string[] args)
        {

            var allCountries = bllServices.GetCountries();
            foreach (var country in allCountries)
            {
                Console.WriteLine(country);
            }
            ShowAllBooks();


        }
        private static void ShowAllBooks()
        {
            Console.WriteLine("***List of all books***");


            var allBooks = bllServices.GetBooks();
            foreach (var book in allBooks)
            {
                Console.WriteLine(book);
            }

        }
    }
}
