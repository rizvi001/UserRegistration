using System;
using Task1.Common;
using Task1.ViewModels;
using Task1.Views.MasterDetail;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Task1
{
    public partial class App : Application
    {
        //public static MasterDetail masterDetailPage = new MasterDetail();
        public App ()
        {
            InitializeComponent();
            MainPage = new  NavigationPage(new Views.LogIn());
        }

        

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

