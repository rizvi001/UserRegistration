using System;
using System.Collections.Generic;
using System.Drawing;
using Task1.ViewModels;
using Xamarin.Forms;

namespace Task1.Views.Registration
{	
	public partial class Registration : ContentPage
	{
		protected RegistrationViewModel RegistrationVM;
        public int count=0;

        public Registration ()
		{
			InitializeComponent ();
            RegistrationVM = new RegistrationViewModel(Navigation);
            this.BindingContext = RegistrationVM;
            NavigationPage.SetBackButtonTitle(this, "");
        }

        private void DOBPicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (count != 0)
            {
                DateTime selectedDate = e.NewDate;
                RegistrationVM.DOB = selectedDate.ToString("MMM, dd yyyy");
                 DOBEntry.Text =$"{selectedDate.ToShortDateString()}";
            }
            count++;
        }

        private void DOBEntry_Focused(object sender, FocusEventArgs e)
        {
            DOBPicker.Focus();
        }

        void DOBEntry_Tabbed(System.Object sender, System.EventArgs e)
        {
            DOBPicker.Focus();
        }

    }
}

