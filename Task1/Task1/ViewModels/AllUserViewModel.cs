using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task1.Common;
using Xamarin.Forms;

namespace Task1.ViewModels
{
    public class AllUserViewModel : BaseViewModel
    {
        private ObservableCollection<UserModel> users;
        private Database database;
      
        #region Constructor
        public AllUserViewModel(INavigation navigation)
        {
            Navigation = navigation;
            database = new Database();
            Users = database.UserDisplay();
            
        }
        #endregion

        #region Properties
        public ObservableCollection<UserModel> Users
        {
            get { return users; }
            set
            {
                if (users != value)
                {
                    users = value;
                    OnPropertyChanged("Users");
                }
            }
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
        #endregion

        #region Method
        public void PopulateUserList()
        {
            Users = null;
            Users =database.UserDisplay();
        }
        #endregion
    }
}

