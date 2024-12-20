using AdvertSite.Entities;
using AdvertSite.Repository;

namespace AdvertSite
{
    public partial class FormHomepage : Form
    {
        private Users loggedInUser;

        public FormHomepage()
        {
            InitializeComponent();
        }

        private void FormHomepage_Load(object sender, EventArgs e)
        {
            LoadAdverts();
            LoadCategories();
            LoadSortingOptions();
            ShowOrHideControls();
        }

        private void buttonNewAccount_Click(object sender, EventArgs e)
        {
            CreateAccount();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginUser();
            //ShowOrHideControls();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            LogOutUser();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchResult();
        }

        private void buttonShowAd_Click(object sender, EventArgs e)
        {
            LoadAdvertDetails();
        }

        private void buttonAllAdverts_Click(object sender, EventArgs e)
        {
            LoadAdverts();
        }

        private void buttonUserAdverts_Click(object sender, EventArgs e)
        {
            LoadUserAdverts();
        }

        private void buttonNewAd_Click(object sender, EventArgs e)
        {
            ClearFields();
            buttonUpdateAd.Visible = false;
            buttonDeleteAd.Visible = false;
            buttonInsertAd.Visible = true;
            NewAdCategorylist();
        }

        private void buttonDeleteAd_Click(object sender, EventArgs e)
        {
            DeleteSelectedAdvert();
        }

        private void buttonUpdateAd_Click(object sender, EventArgs e)
        {
            SaveAdvertChanges();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            CreateNewAdvert();
        }


        ///
        /// SELECT
        /// 

        private void LoadCategories()
        {
            CategoriesRepo repo = new CategoriesRepo();
            var result = repo.GetCategoryList();

            comboBoxSearchCategory.DisplayMember = "CategoryName";
            comboBoxSearchCategory.ValueMember = "CategoryId";
            comboBoxSearchCategory.DataSource = result;
            comboBoxSearchCategory.SelectedIndex = -1;
        }

        private void LoadAdverts()
        {
            string selectedSorting = comboBoxSortBy.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedSorting))
            {
                selectedSorting = default;
            }

            AdvertsRepo repo = new AdvertsRepo();
            var result = repo.GetAllAdsList(selectedSorting);

            listBoxSearchResult.DisplayMember = "Title";
            listBoxSearchResult.ValueMember = "AdvertID";
            listBoxSearchResult.DataSource = result;
            listBoxSearchResult.SelectedIndex = -1;

            HideButtons();
            ClearFields();
        }

        private void LoadUserAdverts()
        {
            string selectedSorting = comboBoxSortBy.SelectedItem?.ToString();
            int loggedInUserId = loggedInUser.UserID;

            if (string.IsNullOrEmpty(selectedSorting))
            {
                selectedSorting = default;
            }

            AdvertsRepo repo = new AdvertsRepo();
            var result = repo.GetUserAdsList(selectedSorting, loggedInUserId);

            listBoxSearchResult.DisplayMember = "Title";
            listBoxSearchResult.ValueMember = "AdvertID";
            listBoxSearchResult.DataSource = result;
            listBoxSearchResult.SelectedIndex = -1;

            HideButtons();
            ClearFields();
        }

        private void LoginUser()
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            UsersRepo repo = new UsersRepo();
            List<Users> userAccounts = repo.GetUserList();

            bool loginSuccess = false;

            foreach (var user in userAccounts)
            {
                if (user.UserName == username && user.UserPassword == password)
                {
                    loggedInUser = user;
                    loginSuccess = true;
                    break;
                }
            }

            if (loginSuccess)
            {
                Users.IsLoggedIn = true;
                MessageBox.Show("Du är nu inloggad!");
                ShowOrHideControls();
                ClearFields();
                HideButtons();
                listBoxSearchResult.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Fel användarnamn eller lösenord. Försök igen.");
            }
        }

        private void LoadAdvertDetails()
        {
            if (listBoxSearchResult.SelectedItem == null)
            {
                MessageBox.Show("Du måste välja en annons.");
                return;
            }

            int selectedAdvertId = (int)listBoxSearchResult.SelectedValue;

            AdvertsRepo repo = new AdvertsRepo();
            Adverts selectedAdvert = repo.GetAdvertDetails(selectedAdvertId);

            if (selectedAdvert != null)
            {
                textBoxTitle.Text = selectedAdvert.Title;
                comboBoxCategoryName.Text = selectedAdvert.Categories.CategoryName;
                textBoxPrice.Text = selectedAdvert.Price.ToString("C");
                labelUploadDate.Text = selectedAdvert.UploadDate.ToString("yyyy-MM-dd");
                labelUploadDate.Visible = true;
                textBoxAdvertDescription.Text = selectedAdvert.AdvertDescription;
                labelAdvertiser.Text = selectedAdvert.Users.UserName;
                labelAdvertiser.Visible = true;
                buttonInsertAd.Visible = false;

                if (Users.IsLoggedIn == true && selectedAdvert.Users.UserID == loggedInUser.UserID)
                {
                    NewAdCategorylist();
                    comboBoxCategoryName.SelectedValue = selectedAdvert.Categories.CategoryID;
                    buttonUpdateAd.Visible = true;
                    buttonDeleteAd.Visible = true;
                }
                else
                {
                    HideButtons();
                }
            }
            else
            {
                MessageBox.Show("Ingen annons hittades.");
            }
        }

        private void NewAdCategorylist()
        {
            CategoriesRepo repo = new CategoriesRepo();
            var result = repo.GetCategoryList();

            comboBoxCategoryName.DisplayMember = "CategoryName";
            comboBoxCategoryName.ValueMember = "CategoryId";
            comboBoxCategoryName.DataSource = result;
            comboBoxCategoryName.SelectedIndex = -1;
        }

        private void SearchResult()
        {
            string condition = textBoxSearchCondition.Text.Trim();
            int selectedCategoryId;
            string selectedSorting = comboBoxSortBy.SelectedItem?.ToString();

            //Kontrollerar om man valt en kategori att söka på eller ej
            if (comboBoxSearchCategory.SelectedIndex >= 0)
            {
                selectedCategoryId = (int)comboBoxSearchCategory.SelectedValue;
            }
            else
            {
                selectedCategoryId = -1;
            }

            //Kontrollerar om man valt att sortera
            if (string.IsNullOrEmpty(selectedSorting))
            {
                selectedSorting = default;
            }

            AdvertsRepo repo = new AdvertsRepo();
            var result = repo.SearchAdverts(condition, selectedCategoryId, selectedSorting);

            listBoxSearchResult.DisplayMember = "Title";
            listBoxSearchResult.ValueMember = "AdvertId";
            listBoxSearchResult.DataSource = result;
            listBoxSearchResult.SelectedIndex = -1;
            comboBoxSearchCategory.SelectedIndex = -1;

            HideButtons();
            ClearFields();
        }


        ///
        /// INSERT
        /// 

        private void CreateAccount()
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Alla fält måste vara ifyllda.");
                return;
            }
            string newUsername = textBoxUsername.Text;

            UsersRepo repo = new UsersRepo();
            List<Users> existingUsers = repo.GetUserList();

            bool usernameTaken = false;

            foreach (var user in existingUsers)
            {
                if (user.UserName == newUsername)
                {
                    usernameTaken = true;
                    break;
                }
            }

            if (usernameTaken)
            {
                MessageBox.Show("Användarnamn upptaget. Välj ett annat.");
                textBoxUsername.Text = string.Empty;
                textBoxPassword.Text = string.Empty;
            }
            else
            {
                repo.CreateUser(new Users(0, textBoxUsername.Text, textBoxPassword.Text));

                MessageBox.Show("Konto skapat!");
            }
        }

        private void CreateNewAdvert()
        {
            if (textBoxTitle.Text == string.Empty ||
                textBoxPrice.Text == string.Empty ||
                comboBoxCategoryName.Text == string.Empty ||
                textBoxAdvertDescription.Text == string.Empty)
            {
                MessageBox.Show("Du måste fylla i alla fält.");
                return;
            }

            string newAdTitle = textBoxTitle.Text;
            string newAdDescription = textBoxAdvertDescription.Text;
            decimal newAdPrice;

            if (!decimal.TryParse(textBoxPrice.Text, out newAdPrice))
            {
                MessageBox.Show("Du måste ange priset i siffror.");
                return;
            }

            DateTime newAdUploadDate = DateTime.Today;
            int newAdCategoryId = (int)comboBoxCategoryName.SelectedValue;
            int newAdUserId = loggedInUser.UserID;

            Categories category = new Categories(newAdCategoryId, comboBoxCategoryName.Text);
            Users user = new Users(newAdUserId, loggedInUser.UserName, loggedInUser.UserPassword);

            AdvertsRepo repo = new AdvertsRepo();
            List<Adverts> existingAds = repo.AllAdverts();

            bool advertIsIdentical = false;

            foreach (var advert in existingAds)
            {
                if (advert.Title == newAdTitle &&
                    advert.AdvertDescription == newAdDescription &&
                    advert.Price == newAdPrice &&
                    advert.Categories.CategoryID == newAdCategoryId &&
                    advert.Users.UserID == newAdUserId)
                {
                    advertIsIdentical = true;
                    break;
                }
            }

            if (advertIsIdentical)
            {
                MessageBox.Show("Du kan inte skapa en identisk annons.");
            }
            else
            {
                Adverts newAdvert = new Adverts(0, newAdTitle, newAdDescription, newAdPrice, newAdUploadDate, category, user);
                repo.CreateAdvert(newAdvert);

                MessageBox.Show("Annons skapad!");
                LoadAdverts();
                ClearFields();
                HideButtons();
            }
        }


        ///
        /// UPDATE
        ///

        private void SaveAdvertChanges()
        {
            if (listBoxSearchResult.SelectedItem == null)
            {
                MessageBox.Show("Ingen annons vald.");
            }

            int editedAdvertId = (int)listBoxSearchResult.SelectedValue;
            string editedTitle = textBoxTitle.Text;
            string editedDescription = textBoxAdvertDescription.Text;
            int editedCategoryId = (int)comboBoxCategoryName.SelectedValue;
            decimal editedPrice;

            if (!decimal.TryParse(textBoxPrice.Text, out editedPrice))
            {
                MessageBox.Show("Du måste ange priset i siffror.");
                return;
            }

            AdvertsRepo repo = new AdvertsRepo();
            Adverts originalAdvert = repo.GetAdvertDetails(editedAdvertId);

            if (originalAdvert == null)
            {
                MessageBox.Show("Kunde inte hitta annons.");
                return;
            }

            if (originalAdvert.Title == editedTitle &&
                originalAdvert.AdvertDescription == editedDescription &&
                originalAdvert.Price == editedPrice &&
                originalAdvert.Categories.CategoryID == editedCategoryId)
            {
                MessageBox.Show("Du måste göra en ändring för att spara.");
                return;
            }

            Categories category = new Categories(editedCategoryId, comboBoxCategoryName.Text);
            Users user = new Users(loggedInUser.UserID, loggedInUser.UserName, loggedInUser.UserPassword);
            Adverts editedAdvert = new Adverts(editedAdvertId, editedTitle, editedDescription, editedPrice,
                originalAdvert.UploadDate, category, user);

            repo.UpdateAdvert(editedAdvert);
            MessageBox.Show("Annonsen har uppdaterats!");
            LoadAdverts();
            ClearFields();
            HideButtons();
        }


        ///
        /// DELETE
        /// 

        private void DeleteSelectedAdvert()
        {
            if (listBoxSearchResult.SelectedItem == null)
            {
                MessageBox.Show("Du måste välja en annons.");
                return;
            }

            int selectedAdvertId = (int)listBoxSearchResult.SelectedValue;
            AdvertsRepo repo = new AdvertsRepo();
            Adverts selectedAdvert = repo.GetAdvertDetails(selectedAdvertId);
            repo.DeleteAdvert(selectedAdvert);

            LoadAdverts();
            ClearFields();
            buttonUpdateAd.Visible = false;
            buttonDeleteAd.Visible = false;
        }


        ///
        /// ÖVRIGT
        ///

        private void ClearFields()
        {
            textBoxTitle.Text = string.Empty;
            textBoxPrice.Text = string.Empty;
            textBoxAdvertDescription.Text = string.Empty;
            labelUploadDate.Text = string.Empty;
            labelAdvertiser.Text = string.Empty;
            comboBoxCategoryName.Text = string.Empty;
            textBoxSearchCondition.Text = string.Empty;
        }

        private void LogOutUser()
        {
            Users.IsLoggedIn = false;
            textBoxUsername.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            listBoxSearchResult.SelectedIndex = -1;
            ShowOrHideControls();
            HideButtons();
            ClearFields();
        }

        private void LoadSortingOptions()
        {
            comboBoxSortBy.Items.Add("Nyast");
            comboBoxSortBy.Items.Add("Äldst");
            comboBoxSortBy.Items.Add("Billigast");
            comboBoxSortBy.Items.Add("Dyrast");
            comboBoxSortBy.SelectedIndex = 0;
        }

        private void ShowOrHideControls()
        {
            if (Users.IsLoggedIn)
            {
                buttonLogout.Visible = true;
                buttonUserAds.Visible = true;
                buttonNewAd.Visible = true;
                labelWelcomeUser.Text = $"Välkommen, {loggedInUser.UserName}!";

                buttonLogin.Visible = false;
                buttonNewAccount.Visible = false;
                labelLogin.Visible = false;
                labelUsername.Visible = false;
                labelPassword.Visible = false;
                textBoxUsername.Visible = false;
                textBoxPassword.Visible = false;
            }
            else if (!Users.IsLoggedIn)
            {
                buttonLogout.Visible = false;
                buttonUserAds.Visible = false;
                buttonNewAd.Visible = false;
                buttonDeleteAd.Visible = false;
                buttonUpdateAd.Visible = false;
                buttonInsertAd.Visible = false;;

                buttonLogin.Visible = true;
                buttonNewAccount.Visible = true;
                labelLogin.Visible = true;
                labelUsername.Visible = true;
                labelPassword.Visible = true;
                textBoxUsername.Visible = true;
                textBoxPassword.Visible = true;
                labelWelcomeUser.Text = "Välkommen!";
            }
        }

        private void HideButtons()
        {
            buttonDeleteAd.Visible = false;
            buttonUpdateAd.Visible = false;
            buttonInsertAd.Visible = false;
        }
    }
}
