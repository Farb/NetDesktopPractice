using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAppNetTest.Model;

namespace WpfAppNetTest.Views
{
    /// <summary>
    /// BindingDemo04DataTable.xaml 的交互逻辑
    /// </summary>
    public partial class BindingDemo4DataTable : Window
    {
        public BindingDemo4DataTable()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //获取DataTable实例
            DataTable dataTable = Load();
            //v1
            //listBoxStudents.DisplayMemberPath = "Name";
            //listBoxStudents.ItemsSource = dataTable.DefaultView;

            //v2
            //listViewStudents.ItemsSource = dataTable.DefaultView;

            //v3
            listViewStudents.DataContext = dataTable;
            listViewStudents.SetBinding(ListView.ItemsSourceProperty, new Binding());
        }

        private DataTable Load()
        {
            var students = new List<StudentVm>
            {
                new StudentVm{Id=1,Name="aaa",Age=30},
                new StudentVm{Id=2,Name="eee",Age=29},
                new StudentVm{Id=3,Name="bbb",Age=28},
                new StudentVm{Id=4,Name="ddd",Age=27},
                new StudentVm{Id=5,Name="ccc",Age=26},
            };
            var dataTable = new DataTable("studentsTable");
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Age", typeof(int));
            foreach (var student in students)
            {
                DataRow row = dataTable.NewRow();
                row.SetField("Id",student.Id);
                row.SetField("Name",student.Name);
                row.SetField("Age",student.Age);
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
    }
}
