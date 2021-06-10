using System;

namespace EmployeeManager.Common.DataProvider
{
    public static class Helper
    {
        public static string CnnVal()
        {
            string serverName = "DESKTOP-FQ236RN";
            String connectionString = $"Data Source={serverName};Initial Catalog=MySnippets;Integrated Security=True";
            return connectionString;
        }
    }
}
