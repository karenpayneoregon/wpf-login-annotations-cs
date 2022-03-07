using System.Data;
using System.Data.SqlClient;

namespace ValidateLogin.Classes
{
    public class DataOperations
    {
        private static string ConnectionString =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=UserLoginExample;" +
            "Integrated Security=True";

        public static bool UserExists(string userName)
        {
            using (var cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                var selectStatement = "SELECT UserName FROM dbo.Users WHERE UserName = @UserName;";
                using (var cmd = new SqlCommand() { Connection = cn, CommandText = selectStatement })
                {
                    cmd.Parameters.Add("@UserName", SqlDbType.NChar).Value = userName;
                    cn.Open();
                    return cmd.ExecuteScalar() != null;
                    
                }
            }
        }

        /// <summary>
        /// Add user to Users table
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        public static void AddUser(string UserName, string Password)
        {
            // TODO - insert user into table
        }
    }
}
