﻿using book_finder_app.Models;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
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

        [Obsolete]
        private async void btnSearchBook_Clicked(object sender, EventArgs e)
        {
            LoadingSearchPage loading = new LoadingSearchPage();
            await PopupNavigation.PushAsync(loading);
            await Task.Delay(2000);
            urlApi += txtBookTitle.Text;
            var json = await client.GetStringAsync(urlApi);
            var getBooks = JsonConvert.DeserializeObject<Books>(json);
            ObservableCollection<Items> listBooksItems = new ObservableCollection<Items>(getBooks.Items);
            ObservableCollection<VolumeInfo> volumeInfos = new ObservableCollection<VolumeInfo>();
            foreach (var item in listBooksItems)
            {
                item.VolumeInfo.SourceImage = item.VolumeInfo.ImageLinks.Thumbnail;
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
                volumeInfos.Add(item.VolumeInfo);
            }
            lvwBooks.ItemsSource = volumeInfos;
            await PopupNavigation.RemovePageAsync(loading);
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