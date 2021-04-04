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

namespace WpfAppNetTest.Views
{
    /// <summary>
    /// BindingDemo2.xaml 的交互逻辑
    /// </summary>
    public partial class BindingDemo2 : Window
    {
        public BindingDemo2()
        {
            InitializeComponent();
        }

        private void btnShowDataContext_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(btnShowDataContext.DataContext.ToString());
        }
    }
}
