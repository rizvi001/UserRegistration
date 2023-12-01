using System;
using Task1.Common;
using Task1.Helper;
using Xamarin.Forms;

namespace Task1.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private Database database;

        public HomePageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            database = new Database();
            Name =Constants.UserLogin.Name ;
            ID = Constants.UserLogin.ID;
        }

        #region properties

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    OnPropertyChanged("Email");
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
                    OnPropertyChanged("Email");
                }
            }

        }
        #endregion
    }
}
