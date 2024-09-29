using System.Text;

namespace MVCTestEFCore.Data
{
    public static class LocalConnectionString
    {
        public static string ConnectionString => CreateLocalConnectionString();

        private static string CreateLocalConnectionString()
        {
            var sb = new StringBuilder();
            sb.Append(@"Server=(localdb)\mssqllocaldb;");
            sb.Append("Database=mvcefcoreDb;");
            sb.Append("Trusted_Connection=true;");
            sb.Append("MultipleActiveResultSets=true");
            return sb.ToString();
        }
    }
}
