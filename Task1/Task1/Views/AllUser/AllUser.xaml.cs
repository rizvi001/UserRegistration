using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Task1.Common;
using Task1.ViewModels;
using Task1.Views.ProfilePage;
using Xamarin.Forms;

namespace Task1.Views.AllUser
{	
	public partial class AllUser : ContentPage
	{
        private Database database;

        protected AllUserViewModel AllUserVM;
        private ObservableCollection<UserModel> users;
        public ObservableCollection<UserModel> Users
        {
            get { return users; }
            set
            {
                if (users != value)
                {
                    users = value;
                    //database.UserDisplay();
                    OnPropertyChanged();
                }
            }
        }

        public AllUser ()
        {
            try
            {

                InitializeComponent();
                database = new Database();
                AllUserVM = new AllUserViewModel(this.Navigation);
                this.BindingContext = AllUserVM;
                NavigationPage.SetBackButtonTitle(this, "");
            }
            catch (Exception ex)
            {

            }
        }

        void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage = new MasterDetail.MasterDetail();
            if (App.Current.MainPage is MasterDetail.MasterDetail mdp)
            {
                mdp.IsPresented = true;
            }
        }

        async void ImageButton_Clicked_1(System.Object sender, System.EventArgs e)
        {
            UserModel user = (sender as ImageButton).BindingContext as UserModel;
            await Navigation.PushModalAsync(new Views.EditUser.EditUser(user));
        }

        async void ImageButton_Clicked_2(System.Object sender, System.EventArgs e)
        {
            UserModel user = (sender as ImageButton).BindingContext as UserModel;
           
            
                database.DeleteManager(user.ID);
            AllUserVM.Users.Remove(user);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AllUserVM.PopulateUserList();
        }
    }
}

