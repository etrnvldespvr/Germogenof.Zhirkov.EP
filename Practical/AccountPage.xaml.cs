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
    public partial class AccountPage : Page
    {
        private int _userId;

        public AccountPage(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadUserData();
            LoadResultsData();
        }
        private void LoadUserData()
        {
            LViewUsers.ItemsSource = EducationalEntities.GetContext().Users
                .Where(u => u.UserID == _userId)
                .ToList();
        }
        private void LoadResultsData()
        {
            var userId = _userId;

            var resultsData = EducationalEntities.GetContext().Results
                .Where(r => r.UserID == userId)
                .Select(r => new
                {
                    UserFullName = r.User.FirstName + " " + r.User.LastName,
                    CourseTitle = r.Cours.Title,
                    Grade = r.Grade
                })
                .ToList();

            LViewResults.ItemsSource = resultsData;
        }
    }
}
