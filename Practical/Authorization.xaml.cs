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

namespace Practical
{
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrEmpty(LoginBox.Text) || string.IsNullOrEmpty(PasswordBox.Password)))
            {
                ErrorData.Visibility = Visibility.Visible;
                return;
            }
            using (var db = new EducationalEntities())
            {
                var user = db.Users
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == LoginBox.Text && u.Password == PasswordBox.Password);

                if (user == null)
                {
                    ErrorText.Visibility = Visibility.Visible;
                    return;
                }

                switch (user.Role)
                {
                    case "Teacher":
                        Manager.MainFrame.Navigate(new MainPage(user.UserID, user.Role));
                        break;
                    case "Student":
                        Manager.MainFrame.Navigate(new MainPage(user.UserID, user.Role));
                        break;
                }
            }
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RegistrationPage());
        }
    }
}
