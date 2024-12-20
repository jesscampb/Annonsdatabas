namespace AdvertSite
{
    partial class FormHomepage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            labelUsername = new Label();
            labelPassword = new Label();
            buttonNewAccount = new Button();
            buttonLogin = new Button();
            listBoxSearchResult = new ListBox();
            textBoxSearchCondition = new TextBox();
            labelSearch = new Label();
            labelWelcomeUser = new Label();
            buttonSearch = new Button();
            buttonLogout = new Button();
            labelLogin = new Label();
            comboBoxSearchCategory = new ComboBox();
            labelAdvertiser = new Label();
            labelUploadDate = new Label();
            comboBoxSortBy = new ComboBox();
            labelResultOrder = new Label();
            buttonShowAd = new Button();
            buttonAllAdverts = new Button();
            buttonNewAd = new Button();
            buttonUserAds = new Button();
            buttonDeleteAd = new Button();
            buttonUpdateAd = new Button();
            textBoxTitle = new TextBox();
            comboBoxCategoryName = new ComboBox();
            textBoxPrice = new TextBox();
            textBoxAdvertDescription = new TextBox();
            labelTitle = new Label();
            labelCategoryName = new Label();
            labelPrice = new Label();
            labelAdvertDescription = new Label();
            buttonInsertAd = new Button();
            SuspendLayout();
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(732, 88);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(295, 31);
            textBoxUsername.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(732, 125);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(295, 31);
            textBoxPassword.TabIndex = 1;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(589, 91);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(137, 25);
            labelUsername.TabIndex = 2;
            labelUsername.Text = "Användarnamn:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(636, 128);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(90, 25);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Lösenord:";
            // 
            // buttonNewAccount
            // 
            buttonNewAccount.Location = new Point(732, 162);
            buttonNewAccount.Name = "buttonNewAccount";
            buttonNewAccount.Size = new Size(137, 34);
            buttonNewAccount.TabIndex = 4;
            buttonNewAccount.Text = "Nytt konto";
            buttonNewAccount.UseVisualStyleBackColor = true;
            buttonNewAccount.Click += buttonNewAccount_Click;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(890, 162);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(137, 34);
            buttonLogin.TabIndex = 5;
            buttonLogin.Text = "Logga in";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // listBoxSearchResult
            // 
            listBoxSearchResult.FormattingEnabled = true;
            listBoxSearchResult.ItemHeight = 25;
            listBoxSearchResult.Location = new Point(22, 345);
            listBoxSearchResult.Name = "listBoxSearchResult";
            listBoxSearchResult.Size = new Size(403, 229);
            listBoxSearchResult.TabIndex = 6;
            // 
            // textBoxSearchCondition
            // 
            textBoxSearchCondition.Location = new Point(22, 263);
            textBoxSearchCondition.Name = "textBoxSearchCondition";
            textBoxSearchCondition.Size = new Size(329, 31);
            textBoxSearchCondition.TabIndex = 7;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(22, 196);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(170, 25);
            labelSearch.TabIndex = 9;
            labelSearch.Text = "Sök efter en annons";
            // 
            // labelWelcomeUser
            // 
            labelWelcomeUser.AutoSize = true;
            labelWelcomeUser.Font = new Font("Segoe UI", 18F);
            labelWelcomeUser.Location = new Point(22, 30);
            labelWelcomeUser.Name = "labelWelcomeUser";
            labelWelcomeUser.Size = new Size(403, 48);
            labelWelcomeUser.TabIndex = 12;
            labelWelcomeUser.Text = "Välkommen, Användare!";
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(357, 257);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(68, 43);
            buttonSearch.TabIndex = 14;
            buttonSearch.Text = "Sök";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonLogout
            // 
            buttonLogout.Location = new Point(890, 30);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(137, 34);
            buttonLogout.TabIndex = 15;
            buttonLogout.Text = "Logga ut";
            buttonLogout.UseVisualStyleBackColor = true;
            buttonLogout.Visible = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 18F);
            labelLogin.Location = new Point(732, 30);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(157, 48);
            labelLogin.TabIndex = 18;
            labelLogin.Text = "Logga in";
            // 
            // comboBoxSearchCategory
            // 
            comboBoxSearchCategory.FormattingEnabled = true;
            comboBoxSearchCategory.Location = new Point(22, 224);
            comboBoxSearchCategory.Name = "comboBoxSearchCategory";
            comboBoxSearchCategory.Size = new Size(223, 33);
            comboBoxSearchCategory.TabIndex = 19;
            // 
            // labelAdvertiser
            // 
            labelAdvertiser.AutoSize = true;
            labelAdvertiser.Location = new Point(572, 523);
            labelAdvertiser.Name = "labelAdvertiser";
            labelAdvertiser.Size = new Size(90, 25);
            labelAdvertiser.TabIndex = 35;
            labelAdvertiser.Text = "Annonsör";
            labelAdvertiser.Visible = false;
            // 
            // labelUploadDate
            // 
            labelUploadDate.AutoSize = true;
            labelUploadDate.Location = new Point(903, 317);
            labelUploadDate.Name = "labelUploadDate";
            labelUploadDate.Size = new Size(124, 25);
            labelUploadDate.TabIndex = 34;
            labelUploadDate.Text = "YYYY-MM-DD";
            labelUploadDate.Visible = false;
            // 
            // comboBoxSortBy
            // 
            comboBoxSortBy.FormattingEnabled = true;
            comboBoxSortBy.Location = new Point(278, 306);
            comboBoxSortBy.Name = "comboBoxSortBy";
            comboBoxSortBy.Size = new Size(147, 33);
            comboBoxSortBy.TabIndex = 36;
            // 
            // labelResultOrder
            // 
            labelResultOrder.AutoSize = true;
            labelResultOrder.Location = new Point(183, 309);
            labelResultOrder.Name = "labelResultOrder";
            labelResultOrder.Size = new Size(89, 25);
            labelResultOrder.TabIndex = 20;
            labelResultOrder.Text = "Sortering:";
            // 
            // buttonShowAd
            // 
            buttonShowAd.Location = new Point(165, 580);
            buttonShowAd.Name = "buttonShowAd";
            buttonShowAd.Size = new Size(127, 34);
            buttonShowAd.TabIndex = 37;
            buttonShowAd.Text = "Visa annons";
            buttonShowAd.UseVisualStyleBackColor = true;
            buttonShowAd.Click += buttonShowAd_Click;
            // 
            // buttonAllAdverts
            // 
            buttonAllAdverts.Location = new Point(298, 580);
            buttonAllAdverts.Name = "buttonAllAdverts";
            buttonAllAdverts.Size = new Size(127, 34);
            buttonAllAdverts.TabIndex = 38;
            buttonAllAdverts.Text = "Alla annonser";
            buttonAllAdverts.UseVisualStyleBackColor = true;
            buttonAllAdverts.Click += buttonAllAdverts_Click;
            // 
            // buttonNewAd
            // 
            buttonNewAd.Location = new Point(162, 81);
            buttonNewAd.Name = "buttonNewAd";
            buttonNewAd.Size = new Size(134, 34);
            buttonNewAd.TabIndex = 39;
            buttonNewAd.Text = "Ny annons";
            buttonNewAd.UseVisualStyleBackColor = true;
            buttonNewAd.Visible = false;
            buttonNewAd.Click += buttonNewAd_Click;
            // 
            // buttonUserAds
            // 
            buttonUserAds.Location = new Point(22, 81);
            buttonUserAds.Name = "buttonUserAds";
            buttonUserAds.Size = new Size(134, 34);
            buttonUserAds.TabIndex = 40;
            buttonUserAds.Text = "Dina annonser";
            buttonUserAds.UseVisualStyleBackColor = true;
            buttonUserAds.Visible = false;
            buttonUserAds.Click += buttonUserAdverts_Click;
            // 
            // buttonDeleteAd
            // 
            buttonDeleteAd.Location = new Point(613, 580);
            buttonDeleteAd.Name = "buttonDeleteAd";
            buttonDeleteAd.Size = new Size(134, 34);
            buttonDeleteAd.TabIndex = 41;
            buttonDeleteAd.Text = "Radera";
            buttonDeleteAd.UseVisualStyleBackColor = true;
            buttonDeleteAd.Visible = false;
            buttonDeleteAd.Click += buttonDeleteAd_Click;
            // 
            // buttonUpdateAd
            // 
            buttonUpdateAd.Location = new Point(753, 580);
            buttonUpdateAd.Name = "buttonUpdateAd";
            buttonUpdateAd.Size = new Size(134, 34);
            buttonUpdateAd.TabIndex = 42;
            buttonUpdateAd.Text = "Uppdatera";
            buttonUpdateAd.UseVisualStyleBackColor = true;
            buttonUpdateAd.Visible = false;
            buttonUpdateAd.Click += buttonUpdateAd_Click;
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(572, 232);
            textBoxTitle.MaxLength = 50;
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(295, 31);
            textBoxTitle.TabIndex = 43;
            // 
            // comboBoxCategoryName
            // 
            comboBoxCategoryName.FormattingEnabled = true;
            comboBoxCategoryName.Location = new Point(572, 269);
            comboBoxCategoryName.Name = "comboBoxCategoryName";
            comboBoxCategoryName.Size = new Size(223, 33);
            comboBoxCategoryName.TabIndex = 44;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(572, 308);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(150, 31);
            textBoxPrice.TabIndex = 45;
            // 
            // textBoxAdvertDescription
            // 
            textBoxAdvertDescription.Location = new Point(572, 345);
            textBoxAdvertDescription.MaxLength = 250;
            textBoxAdvertDescription.Multiline = true;
            textBoxAdvertDescription.Name = "textBoxAdvertDescription";
            textBoxAdvertDescription.Size = new Size(455, 175);
            textBoxAdvertDescription.TabIndex = 46;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(518, 235);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(48, 25);
            labelTitle.TabIndex = 47;
            labelTitle.Text = "Titel:";
            // 
            // labelCategoryName
            // 
            labelCategoryName.AutoSize = true;
            labelCategoryName.Location = new Point(484, 272);
            labelCategoryName.Name = "labelCategoryName";
            labelCategoryName.Size = new Size(82, 25);
            labelCategoryName.TabIndex = 48;
            labelCategoryName.Text = "Kategori:";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(522, 311);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(44, 25);
            labelPrice.TabIndex = 49;
            labelPrice.Text = "Pris:";
            // 
            // labelAdvertDescription
            // 
            labelAdvertDescription.AutoSize = true;
            labelAdvertDescription.Location = new Point(460, 348);
            labelAdvertDescription.Name = "labelAdvertDescription";
            labelAdvertDescription.Size = new Size(106, 25);
            labelAdvertDescription.TabIndex = 50;
            labelAdvertDescription.Text = "Beskrivning:";
            // 
            // buttonInsertAd
            // 
            buttonInsertAd.Location = new Point(893, 580);
            buttonInsertAd.Name = "buttonInsertAd";
            buttonInsertAd.Size = new Size(134, 34);
            buttonInsertAd.TabIndex = 51;
            buttonInsertAd.Text = "Skapa annons";
            buttonInsertAd.UseVisualStyleBackColor = true;
            buttonInsertAd.Visible = false;
            buttonInsertAd.Click += buttonInsert_Click;
            // 
            // FormHomepage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 633);
            Controls.Add(buttonInsertAd);
            Controls.Add(labelAdvertDescription);
            Controls.Add(labelPrice);
            Controls.Add(labelCategoryName);
            Controls.Add(labelTitle);
            Controls.Add(textBoxAdvertDescription);
            Controls.Add(textBoxPrice);
            Controls.Add(comboBoxCategoryName);
            Controls.Add(textBoxTitle);
            Controls.Add(buttonUpdateAd);
            Controls.Add(buttonDeleteAd);
            Controls.Add(buttonUserAds);
            Controls.Add(buttonNewAd);
            Controls.Add(buttonAllAdverts);
            Controls.Add(buttonShowAd);
            Controls.Add(comboBoxSortBy);
            Controls.Add(labelAdvertiser);
            Controls.Add(labelUploadDate);
            Controls.Add(labelResultOrder);
            Controls.Add(comboBoxSearchCategory);
            Controls.Add(labelLogin);
            Controls.Add(buttonLogout);
            Controls.Add(buttonSearch);
            Controls.Add(labelWelcomeUser);
            Controls.Add(labelSearch);
            Controls.Add(textBoxSearchCondition);
            Controls.Add(listBoxSearchResult);
            Controls.Add(buttonLogin);
            Controls.Add(buttonNewAccount);
            Controls.Add(labelPassword);
            Controls.Add(labelUsername);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Name = "FormHomepage";
            Text = "Sök efter annonser eller ladda upp en egen!";
            Load += FormHomepage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Label labelUsername;
        private Label labelPassword;
        private Button buttonNewAccount;
        private Button buttonLogin;
        private ListBox listBoxSearchResult;
        private TextBox textBoxSearchCondition;
        private Label labelSearch;
        private Label labelWelcomeUser;
        private Button buttonSearch;
        private Button buttonLogout;
        private Label labelLogin;
        private ComboBox comboBoxSearchCategory;
        private Label labelAdvertiser;
        private Label labelUploadDate;
        private ComboBox comboBoxSortBy;
        private Label labelResultOrder;
        private Button buttonShowAd;
        private Button buttonAllAdverts;
        private Button buttonNewAd;
        private Button buttonUserAds;
        private Button buttonDeleteAd;
        private Button buttonUpdateAd;
        private TextBox textBoxTitle;
        private ComboBox comboBoxCategoryName;
        private TextBox textBoxPrice;
        private TextBox textBoxAdvertDescription;
        private Label labelTitle;
        private Label labelCategoryName;
        private Label labelPrice;
        private Label labelAdvertDescription;
        private Button buttonInsertAd;
    }
}
