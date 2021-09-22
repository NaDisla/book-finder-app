using book_finder_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace book_finder_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        string urlApi = "https://www.googleapis.com/books/v1/volumes?q=";
        HttpClient client = new HttpClient();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSearchBook_Clicked(object sender, EventArgs e)
        {
            urlApi += txtBookTitle.Text;
            var json = await client.GetStringAsync(urlApi);
            var getBooks = JsonConvert.DeserializeObject<Books>(json);
            ObservableCollection<Items> listBooksItems = new ObservableCollection<Items>(getBooks.Items);
            var scrollBooks = new ScrollView();
            var layoutBooks = new StackLayout();

            foreach (var item in listBooksItems)
            {
                var frameBook = new Frame()
                {
                    Content = new Label { Text = $"Título: {item.VolumeInfo.Title}" },
                    BackgroundColor = Color.FromHex("#e3cf9f"),
                    CornerRadius = 15,
                    BorderColor = Color.Gray,
                    HeightRequest = 20
                };
                
                layoutBooks.Children.Add(frameBook);
                scrollBooks.Content = layoutBooks;
                resultsFrame.Content = scrollBooks;
                
            }
        }
    }
}