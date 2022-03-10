using BO.Interfaces;
using System;

namespace BO
{
    public class Book : IBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CountryId { get; set; }
        public DateTime DatePublished { get; set; }

        public override string ToString()
        {
            return $"{ Id} { Title} { Author} { Price} { Description} {CountryId} {DatePublished }";
        }
    }
}
