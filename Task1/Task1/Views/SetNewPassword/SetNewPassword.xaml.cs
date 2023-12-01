using System;
using System.Collections.Generic;
using Task1.ViewModels;
using Xamarin.Forms;

namespace Task1.Views.SetNewPassword
{	
	public partial class SetNewPassword : ContentPage
	{
		protected SetNewPasswordViewModel SetNewPasswordVM;
		public SetNewPassword ()
		{
			InitializeComponent ();
			SetNewPasswordVM = new SetNewPasswordViewModel(Navigation);
			this.BindingContext = SetNewPasswordVM;
            NavigationPage.SetBackButtonTitle(this, "");


        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
			await Navigation.PopModalAsync();
        }
    }
}

