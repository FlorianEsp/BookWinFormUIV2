using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class DtoBooks
    {
        public int ID { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }  
        public decimal Price { get; set; }  
        public DateTime Country { get; set; }
    }
}
