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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Cours _currentCourse = new Cours();
        public AddEditPage()
        {
            InitializeComponent();
            LoadCombo();

            DataContext = _currentCourse;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentCourse.Title))
                errors.AppendLine("Empty title");
            if (string.IsNullOrEmpty(_currentCourse.Description))
                errors.AppendLine("Empty description");
            if (string.IsNullOrWhiteSpace(_currentCourse.Category))
                errors.AppendLine("Empty category");
            if (_currentCourse.TeacherID == null)
                errors.AppendLine("Empty teacher");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentCourse.CourseID == 0)
                EducationalEntities.GetContext().Courses.Add(_currentCourse);

            try
            {
                EducationalEntities.GetContext().SaveChanges();
                MessageBox.Show("Information saved.");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void LoadCombo()
        {
            ComboTeachers.Items.Add(2);
            ComboTeachers.Items.Add(4);
            ComboTeachers.Items.Add(7);
            ComboTeachers.Items.Add(9);
        }
    }
}
