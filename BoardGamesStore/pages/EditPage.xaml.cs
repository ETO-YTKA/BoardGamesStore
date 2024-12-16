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
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private string imageName;
        private Games game;

        public EditPage(Games game)
        {
            InitializeComponent();
            LoadComboBoxData();
            LoadGameData(game);
            this.game = game;
        }

        private void LoadGameData(Games game)
        {
            titleField.Text = game.Title;
            genreField.SelectedValue = AppConnect.model.GenreGame.First(x => x.Game == game.Id).Genre;
            publisherField.SelectedValue = AppConnect.model.PublisherGame.First(x => x.Game == game.Id).Publisher;
            artistField.SelectedValue = AppConnect.model.ArtistGame.First(x => x.Game == game.Id).Artist;
            designerField.SelectedValue = AppConnect.model.DesignerGame.First(x => x.Game == game.Id).Designer;
            minPlayersField.Text = game.MinPlayers.ToString();
            maxPlayersField.Text = game.MaxPlayers.ToString();
            priceField.Text = game.Price.ToString();
            playTimeField.Text = game.PlayTime.ToString();
            ageRestrictionField.SelectedValue = game.AgeRestriction;
            if (game.Image == "placeholder.jpg")
            {
                selectPhoto.Content = "placeholder.jpg";
            }
            else
            {
                selectPhoto.Content = game.Image.Remove(0, 18);
            }
        }

        private void LoadComboBoxData()
        {
            foreach (var item in AppConnect.model.Publishers)
            {
                publisherField.Items.Add(item);
            }
            publisherField.SelectedValuePath = "Id";
            publisherField.DisplayMemberPath = "Name";

            foreach (var item in AppConnect.model.Genres)
            {
                genreField.Items.Add(item);
            }
            genreField.SelectedValuePath = "Id";
            genreField.DisplayMemberPath = "Name";

            foreach (var item in AppConnect.model.Artists)
            {
                artistField.Items.Add(item);
            }
            artistField.SelectedValuePath = "Id";
            artistField.DisplayMemberPath = "NameWithInitials";

            foreach (var item in AppConnect.model.Designers)
            {
                designerField.Items.Add(item);
            }
            designerField.SelectedValuePath = "Id";
            designerField.DisplayMemberPath = "NameWithInitials";
        }

        private void OnSaveItemClick(object sender, RoutedEventArgs e)
        {
            if (!IsFieldValid()) return;

            game.Title = titleField.Text;
            game.MinPlayers = Convert.ToInt32(minPlayersField.Text);
            game.MaxPlayers = Convert.ToInt32(maxPlayersField.Text);
            game.Price = Convert.ToDecimal(priceField.Text);
            game.PlayTime = Convert.ToInt32(playTimeField.Text);
            game.AgeRestriction = Convert.ToInt32(ageRestrictionField.Text.Remove(ageRestrictionField.Text.Length - 1));
            if (imageName != null)
            {
                game.Image = imageName;
            }
            game.ArtistGame.First().Artist = (int)artistField.SelectedValue;
            game.DesignerGame.First().Designer = (int)designerField.SelectedValue;
            game.GenreGame.First().Genre = (int)genreField.SelectedValue;
            game.PublisherGame.First().Publisher = (int)publisherField.SelectedValue;

            AppConnect.model.SaveChanges();
            AppFrame.frame.GoBack();
        }

        private void OnSelectPhotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                string imageNameToDisplay = openFileDialog.FileName.Split('\\').Last();
                string imageName = DateTime.Now.Ticks + openFileDialog.FileName.Split('\\').Last();
                if (imageName.Length > 100)
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

        private void OnReturnClick(object sender, RoutedEventArgs e)
        {
            AppFrame.frame.GoBack();
        }

        private bool IsFieldValid()
        {
            if (titleField.Text == ""
                || genreField.SelectedIndex == -1
                || publisherField.SelectedIndex == -1
                || artistField.SelectedIndex == -1
                || designerField.SelectedIndex == -1
                || maxPlayersField.Text == ""
                || minPlayersField.Text == ""
                || priceField.Text == ""
                || playTimeField.Text == ""
                || ageRestrictionField.Text == ""
            ) {
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

            if (titleField.Text.Trim().Length >= 50) {
                MessageBox.Show("Слишком длинное название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
