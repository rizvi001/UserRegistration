using System;
using Acr.UserDialogs;
using Task1.Common;
using Task1.Helper;
using Xamarin.Forms;

namespace Task1.ViewModels
{
	public class SetNewPasswordViewModel : BaseViewModel
	{
        private Database database;

        
        #region Constructor
        public SetNewPasswordViewModel(INavigation nav)
		{
            Navigation = nav;
            database = new Database();
            ResetPasswordCommand = new Command(ResetPassword);
        }
        #endregion

        #region Properties
        public Command ResetPasswordCommand { get; set; }

        private string _New_Password;
        public string New_Password
        {
            get { return _New_Password; }
            set
            {
                if (_New_Password != value)
                {
                    _New_Password = value;
                    OnPropertyChanged("Email");
                }
            }

        }

        private string _Confirm_Password;
        public string Confirm_Password
        {
            get { return _Confirm_Password; }
            set
            {
                if (_Confirm_Password != value)
                {
                    _Confirm_Password = value;
                    OnPropertyChanged("Email");
                }
            }

        }
        #endregion

        #region Method
        public async void ResetPassword()
        { 
            try
            {
                if (Validate())
                {
                    Constants.UserLogin.Password = New_Password;
                    database.UpdateManager(Constants.UserLogin);
                    await Navigation.PushModalAsync(new Views.LogIn());
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.AlertAsync("Password update successfully!", "Successful", "OK");

                }
            }
            catch (Exception ex)
            {
                    
            }

        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(New_Password) || string.IsNullOrWhiteSpace(New_Password) || string.IsNullOrWhiteSpace(Confirm_Password))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Error", "All fields are required.", "OK");
                return false;
            }

            
            if (New_Password != Confirm_Password)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("New Password & Confirm Password not matches ");
                return false;
            }
            if (string.IsNullOrEmpty(New_Password) || New_Password.Length < 6)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Please enter a valid 6 character password.");
                return false;
            }
            if (string.IsNullOrEmpty(Confirm_Password) || Confirm_Password.Length < 6)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Please enter a valid 6 character password.");
                return false;
            }
            return true;
        }

        #endregion
    }
}

