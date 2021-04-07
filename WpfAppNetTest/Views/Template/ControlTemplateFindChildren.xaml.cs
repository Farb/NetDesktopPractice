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

namespace WpfAppNetTest.Views.Template
{
    /// <summary>
    /// ControlTemplateFindChildren.xaml 的交互逻辑
    /// </summary>
    public partial class ControlTemplateFindChildren : Window
    {
        public ControlTemplateFindChildren()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            var txt1= uc.Template.FindName("txt1", uc) as TextBox;
            txt1.Text = "Hello,WPF";
            var sp= txt1.Parent as StackPanel;
            (sp.Children[1] as TextBox).Text = "Hello,ControlTemplate";
            (sp.Children[2] as TextBox).Text = "I can find u!";
        }
    }
}
