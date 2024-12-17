using BoardGamesStore.Data;
using BoardGamesStore.db;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
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
        private bool isInit = false;

        public CatalogPage(Users user)
        {
            InitializeComponent();
            UserRoleCheck(user);
            isInit = true;

            LoadCatalogData();
        }

        private void LoadCatalogData()
        {
            listView.ItemsSource = AppConnect.model.Games.ToList();
        }

        private void searchCond_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void listViewFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sortListView();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sortListView();
        }

        private void sortListView()
        {
            if (!isInit) return;
            ComboBoxItem filter = listViewSort.SelectedItem as ComboBoxItem;
            string propertyName = filter.Tag.ToString();

            Button button = sortDirectionButton as Button;
            string directionTag = button.Tag.ToString();
            ListSortDirection sortDirection;

            if (directionTag == "asc")
            {
                sortDirection = ListSortDirection.Ascending;
                button.Tag = "desc";
                button.Content = "↓";
            }
            else
            {
                sortDirection = ListSortDirection.Descending;
                button.Tag = "asc";
                button.Content = "↑";
            }

            listView.Items.SortDescriptions.Clear();
            listView.Items.SortDescriptions.Add(new SortDescription(propertyName, sortDirection));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        public void Search()
        {
            if (!isInit) return;
            string search = searchField.Text.Trim().ToLower();
            ComboBoxItem selectedSearchFilter = this.searchFilter.SelectedItem as ComboBoxItem;
            string searchFilterTag = selectedSearchFilter.Tag.ToString();
            ComboBoxItem selectedGenre = listViewFilter.SelectedItem as ComboBoxItem;
            string genreTag = selectedGenre.Tag.ToString();
            IQueryable<Games> filteredGames = AppConnect.model.Games;

            if (genreTag != "All")
            {
                filteredGames = AppConnect.model.Games.Where(x => AppConnect.model.GenreGame
                    .Any(gg => gg.Game == x.Id && AppConnect.model.Genres
                        .Any(g => g.Id == gg.Genre && g.Name.Equals(genreTag, StringComparison.OrdinalIgnoreCase))));
            }

            switch (searchFilterTag)
            {
                case "name":
                    filteredGames = filteredGames
                        .Where(x => x.Title.ToLower().Contains(search));
                    break;
                case "artist":
                    filteredGames = filteredGames
                        .Where(x => AppConnect.model.ArtistGame
                            .Any(ag => ag.Game == x.Id && AppConnect.model.Artists
                                .Any(a => a.Id == ag.Artist && a.FullName.ToLower().Contains(search))));
                    break;
                case "publisher":
                    filteredGames = filteredGames
                        .Where(x => AppConnect.model.PublisherGame
                            .Any(pg => pg.Game == x.Id && AppConnect.model.Publishers
                                .Any(p => p.Id == pg.Publisher && p.Name.ToLower().Contains(search))));
                    break;
                case "genre":
                    filteredGames = filteredGames
                        .Where(x => AppConnect.model.GenreGame
                            .Any(gg => gg.Game == x.Id && AppConnect.model.Genres
                                .Any(g => g.Id == gg.Genre && g.Name.ToLower().Contains(search))));
                    break;
                case "designer":
                    filteredGames = filteredGames
                        .Where(x => AppConnect.model.DesignerGame
                            .Any(dg => dg.Game == x.Id && AppConnect.model.Designers
                                .Any(d => d.Id == dg.Designer && d.FullName.ToLower().Contains(search))));
                    break;
            }

            listView.ItemsSource = filteredGames.ToList();
        }

        private void UserRoleCheck(Users user)
        {
            int role = user.Role;

            switch (role)
            {
                case 2:
                    editItemContextOption.Visibility = Visibility.Visible;
                    deleteItemContextOption.Visibility = Visibility.Visible;
                    addItem.Visibility = Visibility.Visible;
                    break;
                case 1:
                    editItemContextOption.Visibility = Visibility.Collapsed;
                    deleteItemContextOption.Visibility = Visibility.Collapsed;
                    addItem.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    editItemContextOption.Visibility = Visibility.Visible;
                    deleteItemContextOption.Visibility = Visibility.Collapsed;
                    addItem.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void OnEditItemClick(object sender, RoutedEventArgs e)
        {
            Games game = listView.SelectedItem as Games;
            AppFrame.frame.Navigate(new EditPage(this, game));
            Search();
        }

        private void OnDeleteItemClick(object sender, RoutedEventArgs e)
        {
            Games game = listView.SelectedItem as Games;
            if (game == null)
            {
                MessageBox.Show("Выберите игру для удаления");
                return;
            }

            try
            {
                AppConnect.model.Games.Remove(game);
                AppConnect.model.SaveChanges();
                MessageBox.Show("Игра успешно удалена");
                Search();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Невозможно удалить игру, так как она используется в других таблицах");
            }
        }

        private void OnAddItemClick(object sender, RoutedEventArgs e)
        {
            AppFrame.frame.Navigate(new AddItem(this));
            Search();
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
