using System;
using Acr.UserDialogs;
using Task1.Common;
using Task1.Helper;
using Xamarin.Forms;


namespace Task1.ViewModels
{
    public class UpdatePasswordViewModel : BaseViewModel
	{
        private Database database;

        
        #region Constructor
        public UpdatePasswordViewModel(INavigation nav)
		{
            Navigation = nav;
            database = new Database();
            //Password = Constants.UserLogin.Password;
            UpdateCommand = new Command(UpdatePassword);
        }
        #endregion

        #region Properties

        public Command UpdateCommand { get; set; }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        private string _New_Password;
        public string New_Password
        {
            get { return _New_Password; }
            set
            {
                if (_New_Password != value)
                {
                    _New_Password = value;
                    OnPropertyChanged("New_Password");
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
                    OnPropertyChanged("Confirm_Password");
                }
            }
        }
        #endregion

        #region Method

        public async void UpdatePassword()
        {
            try
            {
                if(Validate())
                {

                    
                    Constants.UserLogin.Password = New_Password;
                    database.UpdateManager(Constants.UserLogin);
                    UserDialogs.Instance.HideLoading();
                    await Navigation.PushModalAsync(new Views.HomeTapped.HomeTapped());
                    UserDialogs.Instance.AlertAsync("Password update successfully!", "Successfull", "OK");

                    Password = "";
                    New_Password = "";
                    Confirm_Password = "";
                }

            
                
            }
            catch(Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Error", "Password update failed", "OK");

            }
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(New_Password) || string.IsNullOrWhiteSpace(Confirm_Password))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Error", "All fields are required.", "OK");
                return false;
            }

            if (Password != Constants.UserLogin.Password)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Password is not valid ");
                return false;
            }
            if (New_Password != Confirm_Password)
            {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.AlertAsync("New Password & Confirm Password not matches ");
                    return false;
            }
            return true;
        }
        #endregion
    }
}

