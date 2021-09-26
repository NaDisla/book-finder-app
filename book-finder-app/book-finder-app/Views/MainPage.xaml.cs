using book_finder_app.Models;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace book_finder_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        HttpClient client = new HttpClient();
        public MainPage()
        {
            InitializeComponent();
        }

        [Obsolete]
        private async void btnSearchBook_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtBookTitle.Text))
            {
                txtBookTitle.Placeholder = "Debe proporcionar un título";
                txtBookTitle.PlaceholderColor = Color.Red;
            }
            else
            {
                LoadingSearchPage loading = new LoadingSearchPage();
                await PopupNavigation.PushAsync(loading);
                await Task.Delay(2000);
                string urlApi = "https://www.googleapis.com/books/v1/volumes?q="+txtBookTitle.Text;
                var json = await client.GetStringAsync(urlApi);
                var getBooks = JsonConvert.DeserializeObject<Books>(json);
                ObservableCollection<Items> listBooksItems = new ObservableCollection<Items>(getBooks.Items);
                ObservableCollection<VolumeInfo> volumeInfos = new ObservableCollection<VolumeInfo>();
                foreach (var item in listBooksItems)
                {
                    if (item.VolumeInfo.ImageLinks == null || string.IsNullOrEmpty(item.VolumeInfo.ImageLinks.Thumbnail))
                    {
                        item.VolumeInfo.SourceImage = "error.jpg";
                    }
                    else
                    {
                        item.VolumeInfo.SourceImage = item.VolumeInfo.ImageLinks.Thumbnail;
                    }
                    if (item.VolumeInfo.Authors == null)
                    {
                        item.VolumeInfo.FinalAuthors = "Desconocido";
                    }
                    else
                    {
                        string[] authors = item.VolumeInfo.Authors;
                        if (authors.Length > 1)
                        {
                            for (int i = 0; i < authors.Length; i++)
                            {
                                if (i == authors.Length - 1) item.VolumeInfo.FinalAuthors += $"{authors[i]}.";
                                else item.VolumeInfo.FinalAuthors += $"{authors[i]}, ";
                            }
                        }
                        else
                        {
                            item.VolumeInfo.FinalAuthors = authors[0];
                        }
                    }
                    if(string.IsNullOrEmpty(item.VolumeInfo.Description))
                    {
                        item.VolumeInfo.Description = "No hay descripción de este libro.";
                    }
                    volumeInfos.Add(item.VolumeInfo);
                }
                lvwBooks.ItemsSource = volumeInfos;
                lblResults.IsVisible = true;
                resultsFrame.IsVisible = true;
                await PopupNavigation.RemovePageAsync(loading);
                txtBookTitle.Text = "";
                txtBookTitle.Placeholder = "Título del libro";
                txtBookTitle.PlaceholderColor = Color.Default;
            }
        }

        [Obsolete]
        private async void btnBookDescription_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var volumeInfo = button.BindingContext as VolumeInfo;
            await PopupNavigation.PushAsync(new BookDescriptionPage(volumeInfo.Description));
        }
    }
}