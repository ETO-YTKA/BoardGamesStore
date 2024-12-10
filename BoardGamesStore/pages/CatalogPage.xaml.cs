using BoardGamesStore.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoardGamesStore.pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        public CatalogPage()
        {
            InitializeComponent();

            UpdateData();
            LoadComboBoxData();
        }

        private void UpdateData()
        {
            listView.ItemsSource = AppConnect.model.Games.ToList();
        }

        private void LoadComboBoxData()
        {
            var artists = AppConnect.model.Artists.ToList();
            var publishers = AppConnect.model.Publishers.ToList();
            var genres = AppConnect.model.Genres.ToList();
            var designers = AppConnect.model.Designers.ToList();

            foreach (var artist in artists)
            {
                artistFilter.Items.Add(artist.NameWithInitials);
            }
            foreach (var publisher in publishers)
            {
                publisherFilter.Items.Add(publisher.Name);
            }
            foreach (var genre in genres)
            {
                genreFilter.Items.Add(genre.Name);
            }
            foreach (var designer in designers)
            {
                designerFilter.Items.Add(designer.NameWithInitials);
            }
        }
    }
}
