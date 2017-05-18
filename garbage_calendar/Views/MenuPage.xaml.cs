using System;
using System.Collections.Generic;
using garbage_calendar.ViewModels;
using Xamarin.Forms;

namespace garbage_calendar.Views
{
    public partial class MenuPage : ContentPage
    {
        private RootPageViewModel ViewModel => this.BindingContext as RootPageViewModel;

        public MenuPage()
        {
            InitializeComponent();
        }

        private async void ListViewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await this.ViewModel.PageChangeAsync(e.SelectedItem as ViewModels.MenuItem);
        }
    }
}
