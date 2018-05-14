using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;
using VkNet;
using VkNet.Enums.Filters;
using MessageBox = System.Windows.MessageBox;

namespace VK
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        private readonly VkApi _api = new VkApi();

        public SignInWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            var appId = ConfigurationManager.AppSettings["appId"];

            GlobalSettings.AppId = appId;

            var login = accountBox.Text;
            var password = passwordBox.Password;

            _api.Authorize(new ApiAuthParams
            {
                ApplicationId = ulong.Parse(appId),
                Login = login,
                Password = password,
                Settings = Settings.All
            });

            //TODO: make the incorrect scenario with the red highlight
            if (string.IsNullOrEmpty(_api.Token))
            {
                accountBox.Text = string.Empty;
                passwordBox.Password = string.Empty;

                return;
            }

            GlobalSettings.Token = _api.Token;

            var mainWindow = new MainWindow();

            this.Close();
            mainWindow.ShowDialog();
        }
    }
}