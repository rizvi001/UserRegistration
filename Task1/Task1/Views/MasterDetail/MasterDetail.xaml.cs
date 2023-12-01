using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task1.Common;
using Task1.ViewModels;
using Xamarin.Forms;

namespace Task1.Views.MasterDetail
{
    public partial class MasterDetail : MasterDetailPage
	{
        

        protected MasterDetailViewModel MasterDetailVM;
		public MasterDetail ()
		{
            try
            {

                InitializeComponent();
                MasterDetailVM = new MasterDetailViewModel(this.Navigation);
                this.BindingContext = MasterDetailVM;

                MessagingCenter.Subscribe<string>("MenuOpen", "MenuOpen", (sender) =>
                {

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        MenuOpen();
                    });
                });
            }
            catch (Exception ex)
            {

            }
		}

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            //await Navigation.PushModalAsync(new Views.HomePage.HomePage());
            Detail = new HomeTapped.HomeTapped("Home");
            IsPresented = false;
        }

        async void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        {
            //await Navigation.PushModalAsync(new Views.AllUser.AllUser());
            Detail = new HomeTapped.HomeTapped("AllUser");
            IsPresented = false;
        }

        async void TapGestureRecognizer_Tapped_2(System.Object sender, System.EventArgs e)
        {
            //await Navigation.PushModalAsync(new Views.ProfilePage.ProfilePage());
            Detail = new HomeTapped.HomeTapped("Profile");
            IsPresented = false;
        }
        async void MenuOpen()
        {
            IsPresented = true;
        }
    }
}

