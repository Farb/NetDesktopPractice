using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Linq;
using WpfAppNetTest.Model;

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
            //v1
            //var doc = new XmlDocument();
            //var dataPath = Path.Combine(Directory.GetCurrentDirectory(),"Data/Students.xml");
            //doc.Load(dataPath);

            //var xdp = new XmlDataProvider();
            //xdp.Document = doc;
            //xdp.XPath = "/Students/Student";
            //listViewStudents.DataContext = xdp;
            //listViewStudents.SetBinding(ListView.ItemsSourceProperty, new Binding());

            //v2
            //var dataPath = Path.Combine(Directory.GetCurrentDirectory(),"Data/Students.xml");
            //var xdp = new XmlDataProvider();
            //xdp.Source = new Uri(dataPath);
            //使用XPath选择需要暴露的数据
            //xdp.XPath = "/Students/Student";
            //listViewStudents.DataContext = xdp;
            //listViewStudents.SetBinding(ListView.ItemsSourceProperty, new Binding());

            //v3 使用Linq

            var dataPath = Path.Combine(Directory.GetCurrentDirectory(),"Data/Students.xml");
            var xDoc = XDocument.Load(dataPath);
            listViewStudents.ItemsSource = xDoc.Descendants("Student")
                .Where(ele => Convert.ToInt32(ele.Attribute("Id").Value)>1)
                .Select(x => new StudentVm
                {
                    Id = int.Parse(x.Attribute("Id").Value),
                    Name=x.Element("Name").Value,
                });
        }
    }
}
