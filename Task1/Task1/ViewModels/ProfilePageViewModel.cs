using System;
using Task1.Common;
using Task1.Helper;
using Xamarin.Forms;

namespace Task1.ViewModels
{
	public class ProfilePageViewModel : BaseViewModel
	{
        private Database database;
        public  Command ChangeCommand { get; set; }

        #region Constructor
        public ProfilePageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            database = new Database();
            Name = Constants.UserLogin.Name;
            Email = Constants.UserLogin.Email;
            Phone = Constants.UserLogin.Phone;
            Gender = Constants.UserLogin.Gender;
            Age = Constants.UserLogin.Age;
            DOB = Constants.UserLogin.DOB;

            ChangeCommand = new Command(ChangePassword);
        }
        #endregion

        #region Properties
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

        public async void ChangePassword()
        {
            await Navigation.PushModalAsync(new Views.UpdatePassword.UpdatePassword());

        }

        #endregion

    }
}

