using EasyCaptcha.Wpf;
using OOO_Gentlmen;
using OOO_Gentlmen.Classes;
using OOO_Gentlmen.Model;
using OOO_Gentlmen.View;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using System.Windows.Threading;

namespace OOO_Gentlmen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool captchaReqired = false;
        DispatcherTimer timerLogin = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            Helper.DB = new dbGentlmen();

            timerLogin.Tick += AllowInput;
            timerLogin.Interval = new TimeSpan(0, 0, 10);
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Password;
            StringBuilder sb = new StringBuilder();
            if (String.IsNullOrEmpty(login))
            {
                sb.AppendLine("Вы не ввели логин");
            }
            if (String.IsNullOrEmpty(password))
            {
                sb.AppendLine("Вы не ввели пароль");
            }
            if (!CheckCaptcha())
            {
                sb.AppendLine("Неверная каптча");
                UpdateCaptcha();
            }
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }
            bool result = Login(login, password);
            if (!result)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                if (captchaReqired)
                {
                    BlockInput();
                    UpdateCaptcha();
                }
                else
                {
                    EnableCaptcha();
                }
                return;
            }
            OpenCatalogWindow();
        }

        public bool Login(string login, string password)
        {
            Helper.User = Helper.DB.User.Where<User>(u => u.UserLogin == login && u.UserPassword == password).FirstOrDefault<User>();
            return Helper.User != null;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void ButtonGuest_Click(object sender, RoutedEventArgs e)
        {
            Helper.User = null;
            OpenCatalogWindow();
        }

        private void EnableCaptcha()
        {
            captchaReqired = true;
            labelCaptcha.IsEnabled = true;
            textBoxCaptcha.IsEnabled = true;
            captcha.IsEnabled = true;
            UpdateCaptcha();
        }

        private void UpdateCaptcha()
        {
            captcha.CreateCaptcha(Captcha.LetterOption.Alphanumeric, 5);
            textBoxCaptcha.Text = "";
        }

        private bool CheckCaptcha()
        {
            if (captchaReqired)
            {
                return captcha.CaptchaText == textBoxCaptcha.Text.ToUpper();
            }
            else
            {
                return true;
            }
        }

        private void captcha_Click(object sender, RoutedEventArgs e)
        {
            UpdateCaptcha();
        }

        private void OpenCatalogWindow()
        {
            CatalogWindow catalogWindow = new CatalogWindow();
            catalogWindow.Owner = this;
            this.Hide();
            catalogWindow.Show();
        }

        private void BlockInput()
        {
            timerLogin.Start();
            textBoxLogin.IsEnabled = false;
            captcha.IsEnabled = false;
            textBoxCaptcha.IsEnabled = false;
            textBoxPassword.IsEnabled = false;
        }

        private void AllowInput(object sender, EventArgs e)
        {
            timerLogin.Stop();
            textBoxLogin.IsEnabled = true;
            captcha.IsEnabled = true;
            textBoxCaptcha.IsEnabled = true;
            textBoxPassword.IsEnabled = true;
        }
    }
}
