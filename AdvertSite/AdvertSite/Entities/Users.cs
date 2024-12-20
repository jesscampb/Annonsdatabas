namespace AdvertSite.Entities
{
    public class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public static bool IsLoggedIn { get; set; }

        public Users(int userID, string userName, string userPassword)
        {
            UserID = userID;
            UserName = userName;
            UserPassword = userPassword;
        }
    }
}
