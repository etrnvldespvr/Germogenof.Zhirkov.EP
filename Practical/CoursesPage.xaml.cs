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
    public partial class CoursesPage : Page
    {
        private string _userRole;
        public CoursesPage(string userRole)
        {
            InitializeComponent();
            _userRole = userRole;
            LoadData();
            
            if (userRole == "Teacher")
            {
                BtnAdd.Visibility = Visibility.Visible;
            }
        }

        private void LoadData()
        {
            var context = EducationalEntities.GetContext();

            var coursesWithTeachers = context.Courses
                .Join(
                    context.Users,
                    course => course.TeacherID,
                    user => user.UserID,
                    (course, user) => new
                    {
                        course.Title,
                        course.Category,
                        course.Description,
                        TeacherFirstName = user.FirstName,
                        TeacherLastName = user.LastName
                    }
                )
                .ToList();

            LViewCourses.ItemsSource = coursesWithTeachers;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

