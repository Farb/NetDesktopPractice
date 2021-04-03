using System.Windows;
using System.Windows.Controls;

namespace WpfAppNetTest.Views.ResourcesDict
{
    /// <summary>
    /// ResourceDictDemo1.xaml 的交互逻辑
    /// </summary>
    public partial class ResourceDictDemo1 : Window
    {
        public ResourceDictDemo1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var value = TryFindResource("str")?.ToString();
            tb3.Text = value;

            txtFromResource.Text = Resource1.testResourceFile;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Resources["txt1"] = new TextBlock { Text = "天涯共此时" };
            Resources["txt2"] = new TextBlock { Text = "天涯共此时" };
        }

    }
}
