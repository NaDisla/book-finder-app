using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms.Xaml;

namespace book_finder_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDescriptionPage : PopupPage
    {
        public BookDescriptionPage(string description)
        {
            InitializeComponent();
            lblBookDescription.Text = description;
        }

        [Obsolete]
        private async void btnCloseDescription_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
        }
    }
}