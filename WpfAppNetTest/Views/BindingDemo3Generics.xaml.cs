using System;
using System.Collections.Generic;
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
    /// BindingDemo3Generics.xaml 的交互逻辑
    /// </summary>
    public partial class BindingDemo3Generics : Window
    {
        public BindingDemo3Generics()
        {
            InitializeComponent();

            //准备数据
            var students = new List<StudentVm>
            {
                new StudentVm{Id=1,Name="aaa",Age=30},
                new StudentVm{Id=2,Name="eee",Age=29},
                new StudentVm{Id=3,Name="bbb",Age=28},
                new StudentVm{Id=4,Name="ddd",Age=27},
                new StudentVm{Id=5,Name="ccc",Age=26},
            };

            //设置Binding
            listBoxStudents.ItemsSource = students;
            //listBoxStudents.DisplayMemberPath = "Name";

            //为Textbox设置binding
            var binding = new Binding("SelectedItem.Id") { Source = listBoxStudents };
            txtSelected.SetBinding(TextBox.TextProperty,binding);

        }
    }
}
