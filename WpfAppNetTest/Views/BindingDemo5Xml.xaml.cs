using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace WpfAppNetTest.Views
{
    /// <summary>
    /// BindingDemo5Xml.xaml 的交互逻辑
    /// </summary>
    public partial class BindingDemo5Xml : Window
    {
        public BindingDemo5Xml()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var doc = new XmlDocument();
            var dataPath = Path.Combine(Directory.GetCurrentDirectory(),"Data/Students.xml");
            doc.Load(dataPath);

            var xdp = new XmlDataProvider();
            xdp.Document = doc;

            //v2
            //var xdp = new XmlDataProvider();
            //xdp.Source = new Uri(dataPath);
            //使用XPath选择需要暴露的数据
            xdp.XPath = "/Students/Student";
            listViewStudents.DataContext = xdp;
            listViewStudents.SetBinding(ListView.ItemsSourceProperty, new Binding());
        }
    }
}
