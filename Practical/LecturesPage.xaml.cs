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
    /// <summary>
    /// Логика взаимодействия для LecturesPage.xaml
    /// </summary>
    public partial class LecturesPage : Page
    {
        private string _userRole;
        public LecturesPage(string userRole)
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var context = EducationalEntities.GetContext();

            var lecturesWithCourses = context.Lectures
                .Join(
                    context.Courses,
                    lectures => lectures.CourseID,
                    course => course.CourseID,
                    (lectures, course) => new
                    {
                        lectures.Title,
                        lectures.Description,
                        CourseTitle = course.Title
                    }
                )
                .ToList();

            LViewCourses.ItemsSource = lecturesWithCourses;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
