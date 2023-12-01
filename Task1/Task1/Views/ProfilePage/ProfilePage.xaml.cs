using System;
using System.Collections.Generic;
using Task1.ViewModels;
using Task1.Views.HomePage;
using Xamarin.Forms;

namespace Task1.Views.ProfilePage
{	
	public partial class ProfilePage : ContentPage
	{
        protected ProfilePageViewModel ProfilePageVM;

        public ProfilePage ()
		{
            try
            {

                InitializeComponent();
                ProfilePageVM = new ProfilePageViewModel(this.Navigation);
                this.BindingContext = ProfilePageVM;
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

    }
}

