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

namespace WpfAppNetTest.Views.DependencyProperty
{
    /// <summary>
    /// DpDemo1.xaml 的交互逻辑
    /// </summary>
    public partial class DpDemo1 : Window
    {
        Student stu;
        public DpDemo1()
        {
            InitializeComponent();
            stu = new Student();
            //v1
            //var binding = new Binding("Text") { Source = txt1 };
            //BindingOperations.SetBinding(stu, Student.IdProperty, binding);
            //txt2.SetBinding(TextBox.TextProperty, binding);

            //v2
            stu.SetBinding(Student.IdProperty, new Binding("Text") { Source = txt1 });
            txt2.SetBinding(TextBox.TextProperty, new Binding("Id") { Source = stu });
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var student = new Student();
            //v1
            //student.SetValue(Student.IdProperty, txt1.Text);
            //txt2.Text = (string)student.GetValue(Student.IdProperty);

            //v2
            student.Id = txt1.Text;
            txt2.Text = student.Id;
        }

        private void btnO2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(stu.GetValue(Student.IdProperty).ToString());
        }
    }
}
