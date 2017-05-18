using System;
using System.Collections.Generic;
using garbage_calendar.ViewModels;
using Xamarin.Forms;

namespace garbage_calendar
{
    public partial class EditMasterDataPage : ContentPage
    {
        public EditMasterDataPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}
