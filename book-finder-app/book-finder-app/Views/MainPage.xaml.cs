using book_finder_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        }
    }
}