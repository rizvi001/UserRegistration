using System;
using SQLite;
using System.Collections.Generic;
using Task1.Interface;
using Xamarin.Forms;
using Task1.ViewModels;
using System.Linq;
using System.Collections.ObjectModel;

namespace Task1.Common
{
    public class Database
    {
        //TODO : To Declare Class Level Variable
        private SQLiteConnection _sqlconnection;
        //TODO : To Define Constructor
        public Database()
        {
            //Getting conection and Creating table  
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();

            #region Create Table
            try
            {
                _sqlconnection.CreateTable<UserModel>();

            }
            catch (Exception ex)
            {

            }
            #endregion
        }

        #region UserRegistration
        //Add new UserRegistration to DB  
        public void AddManager(UserModel userModel)
        {
            _sqlconnection.Insert(userModel);
        }

        //Update UserRegistration to DB  
        public void UpdateManager(UserModel userModel)
        {
            _sqlconnection.Update(userModel);
        }

        //Delete specific USerRegistration  
        public void DeleteManager(int id)
        {
            _sqlconnection.Delete<UserModel>(id);
        }

        //Get all UserRegistration  
        public IEnumerable<UserModel> GetManagerRegistration()
        {

            return (from t in _sqlconnection.Table<UserModel>() select t).ToList();
        }

        //To Display all user
        public ObservableCollection<UserModel> UserDisplay()
        {
            return new ObservableCollection<UserModel>( _sqlconnection.Table<UserModel>().ToList());
        }
        // To get user by Email
        public UserModel GetUserByEmail(string email)
        {
            return _sqlconnection.Table<UserModel>().FirstOrDefault(t => t.Email == email);
        }

        #endregion
    }
}

