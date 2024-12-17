using BoardGamesStore.Data;
using BoardGamesStore.db;
using System;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frame.Navigate(new RegistrationPage());
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            Users user = AppConnect.model.Users.FirstOrDefault(x => x.Login == loginField.Text);

            if (user != null)
            {
                if (user.Password == passwordField.Password)
                {
                    MessageBox.Show(
                        messageBoxText: $"Добро пожаловать {user.LastName} {user.FirstName}",
                        caption: "Успешная авторизация",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.None
                    );
                    AppFrame.frame.Navigate(new CatalogPage(user));
                }
                else
                {
                    MessageBox.Show(
                        messageBoxText: "Неверный пароль",
                        caption: "Ошибка авторизации",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error
                    );
                }
            }
            else
            {
                MessageBox.Show(
                    messageBoxText: "Такого пользователя не существует",
                    caption: "Ошибка авторизации",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error
                );
            }
        }

        private void Field_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length > 48 && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }

        private void passwordField_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox.Password.Length > 48 && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }
    }
}
