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
            var viewModel = (EditMasterDataPageViewModel) BindingContext;

            ToolbarItems.Add(new ToolbarItem
            {
                Text = "menu1",
                Priority = 1,
                Command = viewModel.Menu1Clicked
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}
