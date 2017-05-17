using System;
using System.Collections.Generic;
using garbage_calendar.ViewModels;
using Xamarin.Forms;

namespace garbage_calendar
{
    public partial class EditCalendarDataPage : ContentPage
    {
        public EditCalendarDataPage()
        {
            InitializeComponent();
            var viewModel = (EditCalendarDataPageViewModel) BindingContext;

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
