using BoardGamesStore.Data;
using BoardGamesStore.db;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        private string imagePath;

        public AddItem()
        {
            InitializeComponent();
            LoadComboBoxData();
        }

        private void OnSelectPhotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                string imageName = openFileDialog.FileName.Split('\\').Last();
                string pathToSave = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + $"\\image\\{DateTime.Now.Ticks + imageName}";
                File.Copy(openFileDialog.FileName, pathToSave);
                imagePath = imageName;
                selectPhoto.Content = imageName;
            }
        }
        private void LoadComboBoxData()
        {
            foreach (var item in AppConnect.model.Publishers)
            {
                publisherField.Items.Add(item.Name);
            }
            foreach (var item in AppConnect.model.Genres)
            {
                genreField.Items.Add(item.Name);
            }
            foreach (var item in AppConnect.model.Artists)
            {
                artistField.Items.Add(item.NameWithInitials);
            }
            foreach (var item in AppConnect.model.Designers)
            {
                designerField.Items.Add(item.NameWithInitials);
            }
        }

        private void OnReturnClick(object sender, RoutedEventArgs e)
        {
            AppFrame.frame.GoBack();
        }

        private void OnAddItemClick(object sender, RoutedEventArgs e)
        {
            Games game = new Games
            {
                Title = titleField.Text,
                MinPlayers = Convert.ToInt32(minPlayersField.Text),
                MaxPlayers = Convert.ToInt32(maxPlayersField.Text),
                Price = Convert.ToDecimal(priceField.Text),
                PlayTime = Convert.ToInt32(playTimeField.Text),
                AgeRestriction = Convert.ToInt32(ageRestrictionField.Text.Remove(ageRestrictionField.Text.Length - 1)),
                Image = imagePath
            };

            AppConnect.model.Games.Add(game);
            AppConnect.model.SaveChanges();

            game = AppConnect.model.Games.First(x => x.Title == game.Title);
            int publisherId = AppConnect.model.Publishers.First(x => x.Name == publisherField.Text).Id;
            int genreId = AppConnect.model.Genres.First(x => x.Name == genreField.Text).Id;
            string artistLastName = artistField.Text.Split(' ')[0];
            int artistId = AppConnect.model.Artists.First(x => x.LastName == artistLastName).Id;
            string designerLastName = designerField.Text.Split(' ')[0];
            int designerId = AppConnect.model.Designers.First(x => x.LastName == designerLastName).Id;

            PublisherGame publisherGame = new PublisherGame
            {
                Game = game.Id,
                Publisher = publisherId
            };
            GenreGame genreGame = new GenreGame
            {
                Game = game.Id,
                Genre = genreId
            };
            ArtistGame artistGame = new ArtistGame
            {
                Game = game.Id,
                Artist = artistId
            };
            DesignerGame designerGame = new DesignerGame
            {
                Game = game.Id,
                Designer = designerId
            };

            AppConnect.model.PublisherGame.Add(publisherGame);
            AppConnect.model.GenreGame.Add(genreGame);
            AppConnect.model.ArtistGame.Add(artistGame);
            AppConnect.model.DesignerGame.Add(designerGame);

            AppConnect.model.SaveChanges();
            MessageBox.Show("Игра успешно добавлена");
        }
    }
}
