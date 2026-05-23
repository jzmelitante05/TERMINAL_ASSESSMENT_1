using System.Configuration;

namespace CRUDApplication
{
    public class DatabaseHelper
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager
                    .ConnectionStrings["MyConnection"]
                    .ConnectionString;
            }
        }
    }
}
