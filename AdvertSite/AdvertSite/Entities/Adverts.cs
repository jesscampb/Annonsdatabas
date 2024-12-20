namespace AdvertSite.Entities
{
    public class Adverts
    {
        public int AdvertID { get; set; }
        public string Title { get; set; }
        public string AdvertDescription { get; set; }
        public decimal Price { get; set; }
        public DateTime UploadDate { get; set; }
        public Categories Categories { get; set; }
        public Users Users { get; set; }

        public Adverts(int advertID, string title, string advertDescription, decimal price, 
            DateTime uploadDate, Categories categories, Users users)
        {
            AdvertID = advertID;
            Title = title;
            AdvertDescription = advertDescription;
            Price = price;
            UploadDate = uploadDate;
            Categories = categories;
            Users = users;
        }
    }
}
