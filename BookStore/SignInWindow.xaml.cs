using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookStoreDB;

namespace BookStoreApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        BookStore context = new BookStore();
        Main main = new Main();
        public SignInWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Button(object sender, RoutedEventArgs e)
        {
            bool isLoggedIn = false;
            string login = UserLogin.Text;
            string password = UserPassword.Text;
            var accounts = context.accounts;

            foreach(var account in accounts)
            {
                if(login == account.Login && password == account.Password)
                {
                    MessageBox.Show("Successfully logged in");
                    isLoggedIn = true;
                    this.Close();
                    main.IsEnabled = true;
                    main.Show();
                    
                }
                
            }
            if(!isLoggedIn)
            {
                MessageBox.Show("Account not found!");
            }
            
            

            
            
            
        }

        private void SignUp_Button(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            this.Close();
            signUpWindow.Show();
        }
    }
}