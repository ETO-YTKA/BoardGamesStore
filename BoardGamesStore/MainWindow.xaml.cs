using BoardGamesStore.Data;
using BoardGamesStore.pages;
using System.Windows;

namespace BoardGamesStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AppConnect.model = new db.BGSEntities();
            AppFrame.frame = mainFrame;

            mainFrame.Navigate(new LoginPage());
        }
    }
}
