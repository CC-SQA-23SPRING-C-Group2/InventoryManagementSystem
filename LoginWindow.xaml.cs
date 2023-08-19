using InventoryManagementSystem.Models;
using Realms;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace InventoryManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Realm context;

        public LoginWindow()
        {
            InitializeComponent();
            context = ((App)Application.Current).context;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string id = IDTextBox.Text.Trim();
            string password = PasswordTextBox.Password.Trim();

            
            var user = context.All<User>().Where(u=> u.ID == id && u.Password == password).ToArray();
            

            if (user.Length == 1 )
            {
                LoginErrorTextBlock.Height = 0;
                Window window = new ControlWindow();
                window.Show();
                this.Close();
            }
            else
            {
                LoginErrorTextBlock.Height = double.NaN;
                LoginErrorTextBlock.Text = "Sorry! Wrong id or password.";
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginButton_Click(this, new RoutedEventArgs());
            }
        }
    }
}
