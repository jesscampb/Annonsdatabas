using AdvertSite.Entities;
using System.Data;
using System.Data.SqlClient;

namespace AdvertSite.Repository
{
    public class AdvertsRepo
    {
        /// 
        /// INSERT
        /// 

        //Skapar en ny annons med värden som anges i applikationen.
        public void CreateAdvert(Adverts adverts)
        {
            string sql = "insert into Adverts (Title, AdvertDescription, Price, UploadDate, CategoryId, UserId)" +
                " values (@Title, @AdvertDescription, @Price, @UploadDate, @CategoryId, @UserId)";
            
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Title", adverts.Title));
            parameters.Add(new SqlParameter("@AdvertDescription", adverts.AdvertDescription));
            parameters.Add(new SqlParameter("@Price", adverts.Price));
            parameters.Add(new SqlParameter("@UploadDate", adverts.UploadDate));
            parameters.Add(new SqlParameter("@CategoryId", adverts.Categories.CategoryID));
            parameters.Add(new SqlParameter("@UserId", adverts.Users.UserID));

            DataContext.ExecuteNonQuery(sql, parameters);
        }

        ///
        /// UPDATE
        ///

        //Uppdaterar en befintlig annons i databasen baserat på AdvertId.
        public void UpdateAdvert(Adverts adverts)
        {
            string sql = "update Adverts" +
                " set Title = @Title, AdvertDescription = @AdvertDescription, Price = @Price, CategoryID = @CategoryID" +
                " where AdvertID = @AdvertID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Title", adverts.Title));
            parameters.Add(new SqlParameter("@AdvertDescription", adverts.AdvertDescription));
            parameters.Add(new SqlParameter("@Price", adverts.Price));
            parameters.Add(new SqlParameter("@CategoryId", adverts.Categories.CategoryID));
            parameters.Add(new SqlParameter("@AdvertID", adverts.AdvertID));

            DataContext.ExecuteNonQuery(sql, parameters);
        }
        
        ///
        /// DELETE
        /// 
        
        //Tar bort en annons från databasen baserat på AdvertId.
        public void DeleteAdvert(Adverts adverts)
        {
            string sql = "delete from Adverts where AdvertId = @AdvertId";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AdvertId", adverts.AdvertID));

            DataContext.ExecuteNonQuery(sql, parameters);
        }

        /// 
        ///SELECT
        ///

        //Hämtar alla annonser från databasen.
        //Används för att jämföra med värdena man skrivit in i applikationen.
        public List<Adverts> AllAdverts()
        {
            string sql = "select *" +
                " from adverts a" +
                " inner join categories c on c.categoryid = a.categoryid" +
                " inner join users u on u.userid = a.userid";

            DataTable data = DataContext.ExecuteQueryReturnTable(sql, new List<SqlParameter>());

            List<Adverts> adverts = new List<Adverts>();

            foreach (DataRow row in data.Rows)
            {
                Categories category = new Categories((int)row.ItemArray[5], row.ItemArray[6].ToString());
                Users user = new Users((int)row.ItemArray[7], row.ItemArray[8].ToString(), row.ItemArray[9].ToString());
                Adverts advert = new Adverts((int)row.ItemArray[0], row.ItemArray[1].ToString(), row.ItemArray[2].ToString(),
                    (decimal)row.ItemArray[3], (DateTime)row.ItemArray[4], category, user);

                adverts.Add(advert);
            }
            return adverts;
        }

        //Hämtar annonser som matchar sökvillkoret och/eller kategorin man valt.
        //Sorterar resultatet efter val. Default-sortering är annonsId fallande.
        public List<Adverts> SearchAdverts(string condition, int selectedCategoryId, string selectedSorting)
        {
            string sql = "select AdvertId, Title, AdvertDescription, Price, UploadDate, c.CategoryId, CategoryName, u.UserId, UserName, UserPassword" +
                " from Adverts a" +
                " inner join Categories c on c.CategoryId = a.CategoryId" +
                " inner join Users u on u.UserId = a.UserId" +
                " where 1=1";

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(condition))
            {
                sql += " and Title like @condition";
                parameters.Add(new SqlParameter("@condition", $"%{condition}%"));
            }            
            
            if (selectedCategoryId != -1)
            {
                sql += " and a.CategoryId = @selectedCategoryId";
                parameters.Add(new SqlParameter("@selectedCategoryId", selectedCategoryId));
            }

            switch (selectedSorting)
            {
                case "Billigast":
                    sql += " order by Price asc";
                    break;
                case "Dyrast":
                    sql += " order by Price desc";
                    break;
                case "Äldst":
                    sql += " order by UploadDate asc";
                    break;
                case "Nyast":
                    sql += " order by UploadDate desc";
                    break;
                default:
                    sql += " order by AdvertId desc";
                    break;
            }

            DataTable data = DataContext.ExecuteQueryReturnTable(sql, parameters);

            List<Adverts> adverts = new List<Adverts>();

            foreach (DataRow row in data.Rows)
            {
                Categories category = new Categories((int)row.ItemArray[5], row.ItemArray[6].ToString());
                Users user = new Users((int)row.ItemArray[7], row.ItemArray[8].ToString(), row.ItemArray[9].ToString());
                Adverts advert = new Adverts((int)row.ItemArray[0], row.ItemArray[1].ToString(), row.ItemArray[2].ToString(),
                    (decimal)row.ItemArray[3], (DateTime)row.ItemArray[4], category, user);

                adverts.Add(advert);
            }
            return adverts;
        }

        //Den lista som visas i listboxen när applikationen startar eller när man väljer Alla annonser.
        //Sorterar resultatet efter val. Default-sortering är annonsId fallande.
        public List<Adverts> GetAllAdsList(string selectedSorting)
        {
            string sql = "select *" +
                " from adverts a" +
                " inner join categories c on c.categoryid = a.categoryid" +
                " inner join users u on u.userid = a.userid";

            switch (selectedSorting)
            {
                case "Billigast":
                    sql += " order by Price asc";
                    break;
                case "Dyrast":
                    sql += " order by Price desc";
                    break;
                case "Äldst":
                    sql += " order by UploadDate asc";
                    break;
                case "Nyast":
                    sql += " order by UploadDate desc";
                    break;
                default:
                    sql += " order by AdvertId desc";
                    break;
            }

            DataTable data = DataContext.ExecuteQueryReturnTable(sql, new List<SqlParameter>());

            List<Adverts> adverts = new List<Adverts>();

            foreach (DataRow row in data.Rows)
            {
                Categories category = new Categories((int)row.ItemArray[5], row.ItemArray[6].ToString());
                Users user = new Users((int)row.ItemArray[7], row.ItemArray[8].ToString(), row.ItemArray[9].ToString());
                Adverts advert = new Adverts((int)row.ItemArray[0], row.ItemArray[1].ToString(), row.ItemArray[2].ToString(),
                    (decimal)row.ItemArray[3], (DateTime)row.ItemArray[4], category, user);

                adverts.Add(advert);
            }
            return adverts;
        }

        //Hämtar alla annonser skapade av den användare som är inloggad i applikationen.
        //Använder UserId som villkor för att hämta annonserna.
        //Sorterar resultatet efter val. Default är annonsId fallande.
        public List<Adverts> GetUserAdsList(string selectedSorting, int loggedInUserId)
        {
            string sql = "select advertid, title, advertdescription, price, uploaddate, c.categoryid, categoryname, u.userid, username, userpassword" +
                " from adverts a" +
                " inner join categories c on c.categoryid = a.categoryid" +
                " inner join users u on u.userid = a.userid" +
                " where a.userid = @loggedInUserId";

            switch (selectedSorting)
            {
                case "Billigast":
                    sql += " order by Price asc";
                    break;
                case "Dyrast":
                    sql += " order by Price desc";
                    break;
                case "Äldst":
                    sql += " order by UploadDate asc";
                    break;
                case "Nyast":
                    sql += " order by UploadDate desc";
                    break;
                default:
                    sql += " order by AdvertId desc";
                    break;
            }

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@loggedInUserId", loggedInUserId));

            DataTable data = DataContext.ExecuteQueryReturnTable(sql, parameters);

            List<Adverts> adverts = new List<Adverts>();

            foreach (DataRow row in data.Rows)
            {
                Categories category = new Categories((int)row.ItemArray[5], row.ItemArray[6].ToString());
                Users user = new Users((int)row.ItemArray[7], row.ItemArray[8].ToString(), row.ItemArray[9].ToString());
                Adverts advert = new Adverts((int)row.ItemArray[0], row.ItemArray[1].ToString(), row.ItemArray[2].ToString(),
                    (decimal)row.ItemArray[3], (DateTime)row.ItemArray[4], category, user);

                adverts.Add(advert);
            }
            return adverts;
        }

        //Hämtar all information i en annons baserat på AdvertId på den annons man har valt i listboxen.
        public Adverts GetAdvertDetails(int selectedAdvertId)
        {
            string sql = "select AdvertId, Title, AdvertDescription, Price, UploadDate, c.CategoryId, CategoryName, u.UserId, UserName, UserPassword" +
                " from adverts a" +
                " inner join categories c on c.categoryid = a.categoryid" +
                " inner join users u on u.userid = a.userid" +
                " where advertid = @selectedAdvertId";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@selectedAdvertId", selectedAdvertId));

            DataTable data = DataContext.ExecuteQueryReturnTable(sql, parameters);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];

                Categories category = new Categories((int)row.ItemArray[5], row.ItemArray[6].ToString());
                Users user = new Users((int)row.ItemArray[7], row.ItemArray[8].ToString(), row.ItemArray[9].ToString());
                Adverts advert = new Adverts((int)row.ItemArray[0], row.ItemArray[1].ToString(), row.ItemArray[2].ToString(),
                    (decimal)row.ItemArray[3], (DateTime)row.ItemArray[4], category, user);

                return advert;
            }
            return null;
        }
    }
}
