using System.Configuration;

namespace DAL
{
    public static class Connection
    {
        public static string GetConnection(string name)
        {
           return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
