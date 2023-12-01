using System;
using Task1.Common;
using Task1.Helper;
using Xamarin.Forms;

namespace Task1.ViewModels
{
	public class MasterDetailViewModel : BaseViewModel
	{
        private Database database;

        #region Constructor
        public MasterDetailViewModel(INavigation navigation)
        {
            Navigation = navigation;
            database = new Database();
            Name = Constants.UserLogin.Name;
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
        #endregion
    }
}

