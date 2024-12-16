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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frame.GoBack();
        }

        public void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.model.Users.FirstOrDefault(x => x.Login == loginField.Text.Trim()) != null)
            {
                MessageBox.Show(
                    messageBoxText: "Логин занят",
                    caption: "Ошибка регистрации",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error
                );
                return;
            }

            if (!IsFieldsValid(
                loginField.Text.Trim(),
                firstNameField.Text.Trim(),
                LastNameField.Text.Trim(),
                passwordField.Password.Trim(),
                repPasswordField.Password.Trim(),
                PatronymicField.Text.Trim()
            )) {

            }

            string pastronymic = (PatronymicField.Text.Trim().Length == 0) ? null : PatronymicField.Text;
            Users newUser = new Users()
            {
                Login = loginField.Text,
                Password = passwordField.Password,
                FirstName = firstNameField.Text,
                LastName = LastNameField.Text,
                Patronymic = pastronymic,
                Role = 1
            };
            AppConnect.model.Users.Add(newUser);
            AppConnect.model.SaveChanges();
            MessageBox.Show(
                messageBoxText: "Успешная регистрация",
                caption: "Состояние регистрации",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Information
            );

            AppFrame.frame.Navigate(new LoginPage());
        }

        public bool IsFieldsValid(
            string login,
            string firstName,
            string lastName,
            string password,
            string repPassword,
            string patronymic
        ) {
            if (string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    messageBoxText: "Заполните все обязательные поля",
                    caption: "Ошибка регистрации",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error
                );
                return false;
            }

            if (password != repPassword)
            {
                MessageBox.Show(
                    messageBoxText: "Пароли не совпадают",
                    caption: "Ошибка регистрации",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error
                );
                return false;
            }

            if (password.Trim().Length < 8)
            {
                MessageBox.Show(
                    messageBoxText: "Минимальная длина пароля 8 символов",
                    caption: "Ошибка регистрации",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error
                );
                return false;
            }

            if (login.Trim().Length >= 50 ||
                firstName.Trim().Length >= 50 ||
                lastName.Trim().Length >= 50 ||
                password.Trim().Length >= 50 ||
                (!string.IsNullOrEmpty(patronymic) && patronymic.Trim().Length >= 50))
            {
                MessageBox.Show(
                    messageBoxText: "Превышена длина одного из полей",
                    caption: "Ошибка регистрации",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error
                );
                return false;
            }

            return true;
        }
    }
}
