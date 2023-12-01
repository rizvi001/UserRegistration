using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1.Common;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace Task1.ViewModels
{
	public class RegistrationViewModel : BaseViewModel
	{
        //TODO : Regex Property
        private const string _emailRegex = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        private const string _name = "^[a-zA-Z][a-zA-Z\\s]+$";
        private const string _phone = @"^(?!0+$)\d{10,}$";

        private Database database;
        #region Costructor
        public RegistrationViewModel(INavigation nav)
        {
            Navigation = nav;
            database = new Database();
            LoginCommand = new Command(OnLoginCommand);
        }
        #endregion 
        #region Properties
        public Command LoginCommand
        {
            get; set;
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    OnPropertyChanged("WorkEmail");
                }
            }

        }
        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set
            {
                if (_Phone != value)
                {
                    _Phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set
            {
                if (_Gender != value)
                {
                    _Gender = value;
                    OnPropertyChanged("Gender");
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

        private string _Age;
        public string Age
        {
            get { return _Age; }
            set
            {
                if (_Age != value)
                {
                    _Age = value;
                    OnPropertyChanged("Age");
                }
            }
        }

        private string _DOB;
        public string DOB
        {
            get { return _DOB; }
            set
            {
                if (_DOB != value)
                {
                    _DOB = value;
                    OnPropertyChanged("DOB");
                }
            }
        }

        #endregion
        #region Method
        public async void OnLoginCommand(object obj)
        {
            //Apply Validations.. 
            try
            {
                if (!Validate()) return;

                //To Save User Details In DB...
                    UserModel user = new UserModel();

                    user.Name = Name;
                    user.Email = Email;
                    user.Phone = Phone;
                    user.Gender = Gender;
                    user.Password = Password;
                    user.Age = Age;
                    user.DOB = DOB;
                    database.AddManager(user);

                Device.BeginInvokeOnMainThread(async () =>
                {
                    UserDialogs.Instance.HideLoading();
                    
                    await Navigation.PopModalAsync();
                    UserDialogs.Instance.AlertAsync("User regisiter successfully.");

                });
            }
            catch (Exception ex)
            {

            }
        }
       

        private bool Validate()
        {
            if (string.IsNullOrEmpty(Name) && (string.IsNullOrEmpty(Email))  && (string.IsNullOrEmpty(Phone))  && (string.IsNullOrEmpty(Gender)) && (string.IsNullOrEmpty(Password)))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("All fields are Mandatory.");
                return false;
                
            }
            if (string.IsNullOrEmpty(Name))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Please enter your Name.");
                return false;
            }
            bool isValid1 = (Regex.IsMatch(Name, _name, RegexOptions.IgnoreCase));
            if (!isValid1)
            {

                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Name is not valid");
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

            if (string.IsNullOrEmpty(Phone))
            {

                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Please enter your Phone No.");
                return false;
            }
            bool isValid3 = (Regex.IsMatch(Phone, _phone, RegexOptions.IgnoreCase));
            if(!isValid3)
            {

                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Phone No is not valid");
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {

                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Please enter your Password.");
                return false;
            }

            if (string.IsNullOrEmpty(Password) || Password.Length < 6)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Please enter a valid 6 character password.");
                return false;
            }
            //Check if email already exists
            UserModel existingUser = database.GetUserByEmail(Email);
            if (existingUser != null)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Email already exists. Please use another email.");
                return false;
            }
            return true;
            
            
        }
        #endregion
    }
}

