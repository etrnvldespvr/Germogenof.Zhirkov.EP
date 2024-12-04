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
    public partial class MainPage : Page
    {
        private int _userIdAuth;
        private string _userRole;
        public MainPage(int userIdAuth, string userRole)
        {
            InitializeComponent();
            _userIdAuth = userIdAuth;
            _userRole = userRole;
        }

        private void Courses_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CoursesPage(_userRole));
        }

        private void Lectures_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new LecturesPage(_userRole));
        }

        private void Materials_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MaterialsPage(_userRole));
        }

        private void Tests_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new TestsPage(_userRole));
        }

        private void Results_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ResultsPage(_userRole));
        }

        private void PFP_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AccountPage(_userIdAuth));
        }
    }
}
