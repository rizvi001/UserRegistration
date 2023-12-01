using System;
using System.Text.RegularExpressions;
using Acr.UserDialogs;
using Task1.Common;
using Task1.Helper;
using Xamarin.Forms;

namespace Task1.ViewModels
{
	public class ForgetPasswordViewModel : BaseViewModel
	{
        private const string _emailRegex = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        private Database database;

        
        #region Constructor
        public ForgetPasswordViewModel(INavigation nav)
		{
            Navigation = nav;
            database = new Database();
            Set_New_Password = new Command(SetPassword);
        }
        #endregion

        #region Properties
        public Command Set_New_Password { get; set; }

        private string _Email;
        public string Email
        { 
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    OnPropertyChanged("Email");
                }
            }

        }
        #endregion

        #region Method

        public async void SetPassword()
        {
            if (!Validate())
            {
                return;
            }

            if (Validate())
            {
                UserModel user = database.GetUserByEmail(Email);

                if(user==null)
                {
                    UserDialogs.Instance.Alert("User email doesn't exeist .");
                }

                if (user != null)
                {
                    Constants.UserLogin = user;
                    await Navigation.PushModalAsync(new Views.SetNewPassword.SetNewPassword());
                    UserDialogs.Instance.Alert("Password reset instructions have been sent to your email.");
                }
            }
            else
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Error", "This is no a registered Email", "OK");
            }
        }

        private bool Validate()
        {
            if(string.IsNullOrEmpty(Email))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Please enter email.", "Error", "OK");
                return false;
            }
            bool isValid2 = (Regex.IsMatch(Email, _emailRegex, RegexOptions.IgnoreCase));
            if (!isValid2)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Email is not valid");
                return false;
            }

            return true;
        }


        #endregion
    }
}

