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
    public partial class RegistrationPage : Page
    {
        private User _currentUser = new User();
        public RegistrationPage()
        {
            InitializeComponent();
            LoadCombo();

            DataContext = _currentUser;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentUser.Login))
                errors.AppendLine("Empty login");
            if (string.IsNullOrEmpty(_currentUser.Password))
                errors.AppendLine("Empty password");
            if (string.IsNullOrWhiteSpace(_currentUser.Email))
                errors.AppendLine("Empty email");
            if (_currentUser.Role == null)
                errors.AppendLine("Empty role");
            if (string.IsNullOrWhiteSpace(_currentUser.FirstName))
                errors.AppendLine("Empty first name");
            if (string.IsNullOrWhiteSpace(_currentUser.LastName))
                errors.AppendLine("Empty last name");
            if (string.IsNullOrWhiteSpace(_currentUser.ContactInfo))
                errors.AppendLine("Empty phone");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentUser.UserID == 0)
                EducationalEntities.GetContext().Users.Add(_currentUser);

            try
            {
                EducationalEntities.GetContext().SaveChanges();
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void LoadCombo()
        {
            ComboRole.Items.Add("Student");
            ComboRole.Items.Add("Teacher");
        }
    }
}
