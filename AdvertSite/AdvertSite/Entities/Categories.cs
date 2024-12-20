namespace AdvertSite.Entities
{
    public class Categories
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public Categories(int categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
        }
    }
}
