using System;
using System.Collections.Generic;
using System.Data;
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

namespace pr_9_teselko_01._01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Student[] _students = new Student[10];
        private int _indexOfStudent;

        struct Student
        {
            public Student(string sureanme, bool hostelneed, int background, bool didwork, string degree, string language)
            {
                Surname = sureanme;
                HostelNeed = hostelneed;
                Background = background;
                DidWork = didwork;
                Degree = degree;
                Language = language;
            }

            public string Surname { get; set; }

            public bool HostelNeed { get; set; }

            public int Background { get; set; }

            public bool DidWork { get; set; }

            public string Degree { get; set; }

            public string Language { get; set; }
        }

        private static DataTable ToDataTable(Student[] students)
        {
            var table = new DataTable();

            table.Columns.Add("Фамилия", typeof(string));
            table.Columns.Add("Общежитие", typeof(bool));
            table.Columns.Add("Опыт", typeof(string));
            table.Columns.Add("Работал ли", typeof(bool));
            table.Columns.Add("Образование", typeof(string));
            table.Columns.Add("Язык", typeof(string));

            for (int i = 0; i < students.Length; i++)
            {
                var row = table.NewRow();
                row.ItemArray = new object[] { students[i].Surname, students[i].HostelNeed, students[i].Background, students[i].DidWork, students[i].Degree, students[i].Language };
                table.Rows.Add(row);
            }
            return table;
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            _students[_indexOfStudent] = new Student(surenameInput.Text, (bool)hostelCheck.IsChecked, int.Parse(backgroundInput.Text), (bool)workCheck.IsChecked, degreeInput.Text, languageInput.Text);
            dataGridMain.ItemsSource = ToDataTable(_students).DefaultView;
            _indexOfStudent++;
        }

        private void Calcualtion_Click(object sender, RoutedEventArgs e)
        {
            var reuslt = 0;
            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].HostelNeed)
                {
                    reuslt++;
                }
            }
            MessageBox.Show($"Кол-во студентов нуждающихся в общежитии - {reuslt}");
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №9\n" +
                "Теселько Максим ИСП-34\n" +
                "После поступления в ВУЗ о студентах собрана информация: фамилия, нуждается ли в общежитии, стаж, работал ли, что окончил," +
                " какой язык изучал. Вывести результат на экран. Вывести информацию, сколько человек нуждаются в общежитии.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
