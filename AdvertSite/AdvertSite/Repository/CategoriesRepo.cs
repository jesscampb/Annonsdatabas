using AdvertSite.Entities;
using System.Data;
using System.Data.SqlClient;

namespace AdvertSite.Repository
{
    public class CategoriesRepo
    {
        //Hämtar alla kategorier från databasen
        public List<Categories> GetCategoryList()
        {
            string sql = "select CategoryId, CategoryName from Categories";

            DataTable data = DataContext.ExecuteQueryReturnTable(sql, new List<SqlParameter>());

            List<Categories> categories = new List<Categories>();

            foreach (DataRow row in data.Rows)
            {
                Categories category = new Categories((int)row.ItemArray[0], row.ItemArray[1].ToString());
                categories.Add(category);
            }
            return categories;
        }
    }
}
