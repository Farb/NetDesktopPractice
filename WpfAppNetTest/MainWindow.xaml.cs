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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppNetTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindow : Window
    {
        public static string WindowTitle = "山高越小";
        public static string TextTitle = "水落实处";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Human human=FindResource("human") as Human;
            MessageBox.Show(human.Child.Name);
        }

        private void btnShowResource_Click(object sender, RoutedEventArgs e)
        {
            string str = FindResource("myString") as string;
            lblShowResource.Content = str;
        }
    }
}
