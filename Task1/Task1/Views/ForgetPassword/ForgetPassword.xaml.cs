using System;
using System.Collections.Generic;
using Task1.ViewModels;
using Xamarin.Forms;

namespace Task1.Views.ForgetPassword
{	
	public partial class ForgetPassword : ContentPage
	{
		protected ForgetPasswordViewModel ForgetPasswordVM;
		public ForgetPassword ()
		{
			InitializeComponent ();
            ForgetPasswordVM = new ForgetPasswordViewModel(Navigation);
            this.BindingContext = ForgetPasswordVM;
            NavigationPage.SetBackButtonTitle(this, "");

        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
			await Navigation.PopModalAsync();
        }
    }
}

