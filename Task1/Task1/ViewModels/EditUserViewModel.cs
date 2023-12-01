using System;
using Acr.UserDialogs;
using System.Reflection;
using Task1.Common;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1.ViewModels
{
	public class EditUserViewModel : BaseViewModel
	{
        private const string _password = @"^(?!0+$)\d{4,}$";

        private Database database;

        public Command UpdateCommand { get; set; }

        public EditUserViewModel(INavigation nav,UserModel UserRecord)
		{
            Navigation = nav;
            database = new Database();
            UpdateCommand = new Command(UpdateUser);
        }

        private UserModel _UserInfo;
        public UserModel UserInfo
        {
            get { return _UserInfo; }
            set
            {
                if (_UserInfo != value)
                {
                    _UserInfo = value;
                    OnPropertyChanged("UserInfo");
                }
            }
        }

        public async void UpdateUser()
        {
            try
            {
              if(UserInfo!=null)
              {
                    database.UpdateManager(UserInfo);
                    await Navigation.PopModalAsync();
              }
            }
            catch (Exception ex)
            {
            }
        }
    }
}

