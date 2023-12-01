using System;
using System.Collections.Generic;
using Task1.ViewModels;
using Task1.Views.ProfilePage;
using Xamarin.Forms;

namespace Task1.Views.UpdatePassword
{	
	public partial class UpdatePassword : ContentPage
	{
		protected UpdatePasswordViewModel UpdatePasswordVM;

		public UpdatePassword ()
        {
			InitializeComponent ();
            UpdatePasswordVM = new UpdatePasswordViewModel(Navigation);
            this.BindingContext = UpdatePasswordVM;
            NavigationPage.SetBackButtonTitle(this, "");
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
			await Navigation.PopModalAsync();
        }
    }
}

