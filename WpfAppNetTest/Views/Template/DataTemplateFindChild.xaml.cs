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
using WpfAppNetTest.Model;

namespace WpfAppNetTest.Views.Template
{
    /// <summary>
    /// DataTemplateFindChild.xaml 的交互逻辑
    /// </summary>
    public partial class DataTemplateFindChild : Window
    {
        public DataTemplateFindChild()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            var tb= cp.ContentTemplate.FindName("tbName", cp) as TextBlock;
            MessageBox.Show(tb.Text);

            var per= cp.Content as Person;
            MessageBox.Show(per.Name);
        }
    }
}
