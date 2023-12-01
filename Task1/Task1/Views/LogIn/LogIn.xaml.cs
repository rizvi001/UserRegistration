using System;
using System.Collections.Generic;
using Task1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Task1.ViewModels.LogInViewModel;

namespace Task1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
	{
		protected LogInViewModel LogInVM;
		public LogIn ()
		{
			InitializeComponent ();
			LogInVM = new LogInViewModel(this.Navigation);
			this.BindingContext = LogInVM;
            NavigationPage.SetBackButtonTitle(this, "");
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
			await Navigation.PushModalAsync(new Views.Registration.Registration());
        }

        async void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.ForgetPassword.ForgetPassword());
        }

    }
}

