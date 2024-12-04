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
    /// Логика взаимодействия для MaterialsPage.xaml
    /// </summary>
    public partial class MaterialsPage : Page
    {
        public MaterialsPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var context = EducationalEntities.GetContext();

            var materialsWithLectures = context.Materials
                .Join(
                    context.Lectures,
                    material => material.LectureID,
                    lecture => lecture.LectureID,
                    (material, lecture) => new
                    {
                        material.Title,
                        material.Type,
                        material.FilePath,
                        LectureTitle = lecture.Title
                    }
                )
                .ToList();

            LViewCourses.ItemsSource = materialsWithLectures;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
