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
    /// Логика взаимодействия для TestsPage.xaml
    /// </summary>
    public partial class TestsPage : Page
    {
        public TestsPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var context = EducationalEntities.GetContext();

            var testsWithLectures = context.Tests
                .Join(
                    context.Lectures,
                    test => test.LectureID,
                    lecture => lecture.LectureID,
                    (test, lecture) => new
                    {
                        test.Title,
                        test.Description,
                        LectureTitle = lecture.Title
                    }
                )
                .ToList();

            LViewCourses.ItemsSource = testsWithLectures;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
