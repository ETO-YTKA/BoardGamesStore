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

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsFieldsEmpty())
            {
                MessageBox.Show(
                    messageBoxText: "Заполните все поля",
                    caption: "Ошибка регистрации",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error
                );
                return;
            }
            if (!IsLoginFree())
            {
                MessageBox.Show(
                    messageBoxText: "Логин занят",
                    caption: "Ошибка регистрации",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error
                );
                return;
            }
            if (!IsPasswordRepCorrect())
            {
                MessageBox.Show(
                    messageBoxText: "Пароли не совпадают",
                    caption: "Ошибка регистрации",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Error
                );
                return;
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
                    messageBoxText: "Успешная регистрация\nIP. 92.28.211.234 N: 43.7462 W: 12.4893 SS Number: 6979191519182016 IPv6: fe80::5dcd::ef69::fb22::d9888%12 UPNP: Enabled DMZ: 10.112.42.15 MAC: 5A:78:3E:7E:00 ISP: Ucom Universal DNS: 8.8.8.8 ALT DNS: 1.1.1.8.1 DNS SUFFIX: Dlink WAN: 100.23.10.15 GATEWAY: 192.168.0.1 SUBNET MASK: 255.255.0.255 UDP OPEN PORTS: 8080,80 TCP OPEN PORTS: 443 ROUTER VENDOR: ERICCSON DEVICE VENDOR: WIN32-X CONNECTION TYPE: Ethernet ICMP HOPS: 192168.0.1 192168.1.1 100.73.43.4 host-132.12.32.167.ucom.com host-66.120.12.111.ucom.com 36.134.67.189 216.239.78.111 sof02s32-in-f14.1e100.net TOTAL HOPS: 8 ACTIVE SERVICES: [HTTP] 192.168.3.1:80=>92.28.211.234:80 [HTTP] 192.168.3.1:443=>92.28.211.234:443 [UDP] 192.168.0.1:788=>192.168.1:6557 [TCP] 192.168.1.1:67891=>92.28.211.234:345 [TCP] 192.168.52.43:7777=>192.168.1.1:7778 [TCP] 192.168.78.12:898=>192.168.89.9:667 EXTERNAL MAC: 6U:78:89:ER:O4 MODEM JUMPS: 64",
                    caption: "Состояние регистрации",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information
                );
        }

        private bool IsPasswordRepCorrect()
        {
            return passwordField.Password == repPasswordField.Password;
        }

        private bool IsLoginFree()
        {
            return AppConnect.model.Users.FirstOrDefault(x => x.Login == loginField.Text.Trim()) == null;
        }

        private bool IsFieldsEmpty()
        {
            return loginField.Text.Trim() == ""
                    || firstNameField.Text.Trim() == ""
                    || LastNameField.Text.Trim() == ""
                    || passwordField.Password.Trim() == "";
        }
    }
}
