using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Task1.Views.HomeTapped
{	
	public partial class HomeTapped : TabbedPage
	{	
		public HomeTapped ()
		{
			InitializeComponent ();
		}
        public HomeTapped(string current_page)
        {
            InitializeComponent();
			if (current_page=="Home")
			{
				CurrentPage = this.Children[0];
			}
			if(current_page=="AllUser")
			{
				CurrentPage = this.Children[1];
			}
			if(current_page=="Profile")
			{
				CurrentPage = this.Children[2];
			}
        }
    }
}

