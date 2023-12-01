using System;
using System.Collections.Generic;
using Task1.Common;
using Task1.ViewModels;
using Task1.Views.ForgetPassword;
using Xamarin.Forms;

namespace Task1.Views.EditUser
{	
	public partial class EditUser : ContentPage
	{
        private Database database;
		protected EditUserViewModel EditUserVM; 
		public EditUser (UserModel UserRecord)
        {
            InitializeComponent ();
            EditUserVM = new EditUserViewModel(Navigation, UserRecord);
            database = new Database();
            this.BindingContext = EditUserVM;
            EditUserVM.UserInfo = UserRecord;
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}

