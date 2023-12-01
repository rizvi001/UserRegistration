using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using SQLite;
using Task1.Common;
using Task1.Helper;
using Task1.Interface;
using Task1.Views.HomeTapped;
using Task1.Views.MasterDetail;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Task1.ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        private const string _emailRegex = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        private Database database;

        public Command LoginCommand { get; set; }

        #region Constructor

        public LogInViewModel(INavigation Nav)
        {
            Navigation = Nav;
            database = new Database();
            LoginCommand = new Command(OnLoginCommand);
        }
        #endregion

        #region Properties
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
        public bool _IsButtonVisible = false;

        public bool IsButtonVisible
        {
            get { return _IsButtonVisible; }

            set
            {
                if (_IsButtonVisible != value)
                {
                    _IsButtonVisible = value;
                    OnPropertyChanged("IsButtonVisible");
                }
            }


        }
        #endregion

        public async void OnLoginCommand()
        {
            try
            {
                if (!Validate())
                {
                    return;
                }
                var user = database.GetManagerRegistration().ToList();
                if (user != null)
                {
                    var loginUser = user.Where(a => a.Email == Email && a.Password == Password).FirstOrDefault();

                    if (loginUser != null)
                    {
                        Constants.UserLogin = loginUser;

                        //App.Current.MainPage = new MasterDetail();

                        await Navigation.PushModalAsync(new MasterDetail());
                    }
                    else
                    {
                        await UserDialogs.Instance.AlertAsync("User does not exist!");
                        return;
                    }
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync("Not able to get users");
                }
            }
            catch(Exception ex)
            {

            }  
        }

        public bool Validate()
        {
            
            if (string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Email))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Please enter Email.");
                return false;
            }

            if (string.IsNullOrEmpty(Password) || string.IsNullOrWhiteSpace(Password))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Please enter your Password.");
                return false;
            }
            if (string.IsNullOrEmpty(Email))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Please enter Email.");
                return false;
            }
            bool isValid2 = (Regex.IsMatch(Email, _emailRegex, RegexOptions.IgnoreCase));
            if (!isValid2)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Email is not valid");
                return false;
            }
            if (string.IsNullOrEmpty(Password) || Password.Length < 6)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Please enter a valid 6 character password.");
                return false;
            }
            return true;
        }
    }
}
	


