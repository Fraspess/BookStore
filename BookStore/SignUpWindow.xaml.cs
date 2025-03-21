using BookStoreDB;
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
using System.Windows.Shapes;

namespace BookStoreApp
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        BookStore context = new BookStore();
        SignInWindow signInWindow = new SignInWindow();
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void SignUp_Button(object sender, RoutedEventArgs e)
        {
            string login = UserLogin.Text;
            string password = UserPassword.Text;
            string password2 = UserPassword2.Text;
            if (password != password2)
            {
                MessageBox.Show("You need to enter exactly the same password 2 times");
                return;
            }

            foreach (var account in context.accounts)
            {
                if (login == account.Login)
                {
                    MessageBox.Show("Login is already used");
                    return;
                }

            }

            context.accounts.Add(new BookStoreDB.Entities.Account(){Login = login, Password = password });
            context.SaveChanges();
            MessageBox.Show("Successfully created account");
            this.Close();
            signInWindow.Show();

        }

        private void SignIn_Button(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow();
            this.Close();
            signInWindow.Show();
        }
    }
}
