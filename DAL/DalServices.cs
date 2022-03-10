using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using BO.Interfaces;
using DAL.Interfaces;

namespace DAL
{
    public class DalServices : IDalServices
    {
        public IEnumerable<ICountry> GetCountries()
        {
            using (IDbConnection connection = new SqlConnection(Connection.GetConnection("Books")))
            {
                var countries = connection.Query<Country>("spGetAllCountries", commandType: CommandType.StoredProcedure).ToList();
                return countries;
            }
        }
        public void AddBook(IBook book)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Title", book.Title);
            param.Add("@Author", book.Author);
            param.Add("@Description", book.Description);
            param.Add("@Price", book.Price);
            param.Add("@CountryId", book.CountryId);
            param.Add("@DatePublished", book.DatePublished);

            using (IDbConnection connection = new SqlConnection(Connection.GetConnection("Books")))
            {
                try
                {
                    connection.Execute("spAddNewBook", param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public IEnumerable<IBook> GetBooks()
        {
            using (IDbConnection connection = new SqlConnection(Connection.GetConnection("Books")))
            {
                var books = connection.Query<Book>("spGetAllBooks", commandType: CommandType.StoredProcedure).ToList();
               
                return books;
            }
        }
        public IEnumerable<DtoBooks> GetBooksByCountry(int Id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", Id);
            using (IDbConnection connection = new SqlConnection(Connection.GetConnection("Books")))
            {
                var books = connection.Query<DtoBooks, Country, DtoBooks>("spGetPerCountry",
                    (dtobooks, country) =>
                    {
                        dtobooks.Country = country;
                        return dtobooks;
                    },
                param, commandType: CommandType.StoredProcedure).ToList();
                return books;
            }
        }
        public void AddLog(string message)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@LogMessage", message);


            using (IDbConnection connection = new SqlConnection(Connection.GetConnection("Books")))
            {
                try
                {
                    connection.Execute("spLog", param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
