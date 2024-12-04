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
        public MainPage()
        {
            InitializeComponent();
        }

        private void Courses_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CoursesPage());
        }

        private void Lectures_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new LecturesPage());
        }

        private void Materials_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MaterialsPage());
        }

        private void Tests_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new TestsPage());
        }

        private void Results_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ResultsPage());
        }

        private void PFP_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AccountPage());
        }
    }
}
