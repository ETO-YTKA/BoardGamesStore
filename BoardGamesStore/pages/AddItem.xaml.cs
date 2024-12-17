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
        private string imageName;
        private CatalogPage parent;

        public AddItem(CatalogPage parent)
        {
            InitializeComponent();
            LoadComboBoxData();
            this.parent = parent;
        }

        private void OnSelectPhotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                string imageNameToDisplay = openFileDialog.FileName.Split('\\').Last();
                string imageName = DateTime.Now.Ticks + openFileDialog.FileName.Split('\\').Last();
                if (imageName.Length >= 100)
                {
                    MessageBox.Show("Слишком длинное название файла", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                string pathToSave = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + $"\\image\\{imageName}";
                File.Copy(openFileDialog.FileName, pathToSave);
                this.imageName = imageName;
                selectPhoto.Content = imageNameToDisplay;
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
            parent.Search();
        }

        private void OnAddItemClick(object sender, RoutedEventArgs e)
        {
            if (!IsAddItemFieldsValid()) return;
            Games game = new Games
            {
                Title = titleField.Text,
                MinPlayers = Convert.ToInt32(minPlayersField.Text),
                MaxPlayers = Convert.ToInt32(maxPlayersField.Text),
                Price = Convert.ToDecimal(priceField.Text),
                PlayTime = Convert.ToInt32(playTimeField.Text),
                AgeRestriction = Convert.ToInt32(ageRestrictionField.Text.Remove(ageRestrictionField.Text.Length - 1)),
                Image = imageName
            };

            AppConnect.model.Games.Add(game);
            AppConnect.model.SaveChanges();

            Games insertedGame = AppConnect.model.Games.ToList().Last();
            int publisherId = AppConnect.model.Publishers.First(x => x.Name == publisherField.Text).Id;
            int genreId = AppConnect.model.Genres.First(x => x.Name == genreField.Text).Id;
            string artistLastName = artistField.Text.Split(' ')[0];
            int artistId = AppConnect.model.Artists.First(x => x.LastName == artistLastName).Id;
            string designerLastName = designerField.Text.Split(' ')[0];
            int designerId = AppConnect.model.Designers.First(x => x.LastName == designerLastName).Id;

            PublisherGame publisherGame = new PublisherGame
            {
                Game = insertedGame.Id,
                Publisher = publisherId
            };
            GenreGame genreGame = new GenreGame
            {
                Game = insertedGame.Id,
                Genre = genreId
            };
            ArtistGame artistGame = new ArtistGame
            {
                Game = insertedGame.Id,
                Artist = artistId
            };
            DesignerGame designerGame = new DesignerGame
            {
                Game = insertedGame.Id,
                Designer = designerId
            };

            AppConnect.model.PublisherGame.Add(publisherGame);
            AppConnect.model.GenreGame.Add(genreGame);
            AppConnect.model.ArtistGame.Add(artistGame);
            AppConnect.model.DesignerGame.Add(designerGame);

            AppConnect.model.SaveChanges();
            MessageBox.Show("Игра успешно добавлена");
            AppFrame.frame.GoBack();
            parent.Search();
        }

        private bool IsAddItemFieldsValid()
        {
            if (titleField.Text == "" || 
                genreField.SelectedIndex == -1 || 
                publisherField.SelectedIndex == -1 || 
                artistField.SelectedIndex == -1 || 
                designerField.SelectedIndex == -1 || 
                maxPlayersField.Text == "" || 
                minPlayersField.Text == "" || 
                priceField.Text == "" || 
                playTimeField.Text == "" || 
                ageRestrictionField.Text == "" || 
                imageName == null
            )
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(minPlayersField.Text, out int minPlayers) || minPlayers <= 0)
            {
                MessageBox.Show("Введите корректное минимальное количество игроков.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(maxPlayersField.Text, out int maxPlayers) || maxPlayers < minPlayers)
            {
                MessageBox.Show("Введите корректное максимальное количество игроков (не меньше минимального).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!decimal.TryParse(priceField.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Введите корректную цену.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(playTimeField.Text, out int playTime) || playTime <= 0)
            {
                MessageBox.Show("Введите корректное время игры.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (titleField.Text.Trim().Length >= 50)
            {
                MessageBox.Show("Слишком длинное название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void Field_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length > 48 && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }
    }
}
