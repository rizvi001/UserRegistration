using System;
using System.Collections.Generic;
using Task1.ViewModels;
using Xamarin.Forms;

namespace Task1.Views.HomePage
{	
	public partial class HomePage : ContentPage
	{
       
        protected HomePageViewModel HomePageVM;

		public HomePage ()
		{
            try
            {

                InitializeComponent();
                HomePageVM = new HomePageViewModel(this.Navigation);
                this.BindingContext = HomePageVM;
                NavigationPage.SetBackButtonTitle(this, "");
            }
            catch (Exception ex)
            {

            }

        }

        void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            //App.Current.MainPage = new MasterDetail.MasterDetail();
            //if (App.Current.MainPage is MasterDetail.MasterDetail mdp)
            //{
            //    mdp.IsPresented = true;
            //}
            MessagingCenter.Send<string>("MenuOpen", "MenuOpen");
        }
    }
}

