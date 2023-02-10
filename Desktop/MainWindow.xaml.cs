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
using System.Text.RegularExpressions;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Voiti(object sender, RoutedEventArgs e)
        {
            if (check.IsChecked.Value)
            {
                PasswordBox.Password = passv.Text;

            }
            var cureentuser = UserBase.AppData.db.users.FirstOrDefault(u => u.login == Login.Text && u.password == PasswordBox.Password);
            string log = Login.Text;
            if (Validator.EmailValid(Login) == false)
            {
                MessageBox.Show("Неккоректный ввод почты");
            }
            else
            {
                if (Validator.PasswordValid(PasswordBox) == false)
                {
                    MessageBox.Show("Неккоректный ввод пароля");
                }
                else
                {
                    if (cureentuser != null)
                    {
                       Window2 vhod = new Window2();
                       vhod.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("нет такого пользователя или логин/пароль неверные");
                    }
                }
            }
        }
        private void Registracia(object sender, RoutedEventArgs e)
        {
            Window1 reg = new Window1();
            reg.Show();
            Close();
        }
        private void vid(object sender, RoutedEventArgs e)
        {
            passv.Text = PasswordBox.Password;
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                passv.Text = PasswordBox.Password;
                passv.Visibility = Visibility.Visible;
                PasswordBox.Visibility = Visibility.Hidden;
                PasswordBox.Password = passv.Text;

            }
            else
            {
                passv.Visibility = Visibility.Hidden;
                PasswordBox.Visibility = Visibility.Visible;
                passv.Text = PasswordBox.Password;
                PasswordBox.Password = passv.Text;

            }

        }
    }
    public static class Validator
    {
        public static bool EmailValid(TextBox Login)
        {
            Regex regex = new Regex(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$");
            Match match = regex.Match(Login.Text);

            if (match.Success)
                return true;
            else
                return false;
        }
        public static bool PasswordValid(PasswordBox PasswordBox)
        {
            if (PasswordBox.Password.Length >= 6)
                return true;
            else
                return false;
        }
        public static bool Name(TextBox name)
        {
            if (name.Text.Length >= 3)
                return true;
            else
                return false;
        }
        public static bool PochtaValid(TextBox pochta)
        {
            Regex regex = new Regex(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$");
            Match match = regex.Match(pochta.Text);

            if (match.Success)
                return true;
            else
                return false;
        }
        public static bool PassregValid(TextBox passreg)
        {
            if (passreg.Text.Length >= 6)
                return true;
            else
                return false;
        }
        public static bool PassregandpovtValid(TextBox passregpovt, TextBox passreg)
        {
            if (passregpovt.Text == passreg.Text)
                return true;
            else
                return false;
        }
    }
}