using AdvertSite.Entities;
using System.Data;
using System.Data.SqlClient;

namespace AdvertSite.Repository
{
    public class UsersRepo
    {

        //Hämtar alla användare i databasen
        public List<Users> GetUserList()
        {
            string sql = "select UserId, UserName, UserPassword from Users";

            DataTable data = DataContext.ExecuteQueryReturnTable(sql, new List<SqlParameter>());

            List<Users> users = new List<Users>();

            foreach (DataRow row in data.Rows)
            {
                users.Add(new Users((int)row.ItemArray[0], row.ItemArray[1].ToString(), row.ItemArray[2].ToString()));
            }
            return users;
        }

        //Lägger till en ny användare i databasen
        public void CreateUser(Users users)
        {
            string sql = "insert into Users (UserName, UserPassword) values (@UserName, @UserPassword)";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserName", users.UserName));
            parameters.Add(new SqlParameter("@UserPassword", users.UserPassword));

            DataContext.ExecuteNonQuery(sql, parameters);
        }
    }
}
