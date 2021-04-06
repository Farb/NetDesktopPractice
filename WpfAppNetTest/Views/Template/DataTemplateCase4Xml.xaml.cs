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
using System.Windows.Shapes;
using System.Xml;

namespace WpfAppNetTest.Views.Template
{
    /// <summary>
    /// DataTemplateCase4Xml.xaml 的交互逻辑
    /// </summary>
    public partial class DataTemplateCase4Xml : Window
    {
        public DataTemplateCase4Xml()
        {
            InitializeComponent();
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = e.OriginalSource as MenuItem;
            XmlElement xe = mi.Header as XmlElement;
            MessageBox.Show(xe.GetAttribute("Name"));
        }
    }
}
