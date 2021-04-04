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
    /// BindingDemo6RelativeSource.xaml 的交互逻辑
    /// </summary>
    public partial class BindingDemo6RelativeSource : Window
    {
        public BindingDemo6RelativeSource()
        {
            InitializeComponent();
            var rs = new RelativeSource(RelativeSourceMode.FindAncestor);
            rs.AncestorLevel = 1;
            rs.AncestorType = typeof(Grid);

            var binding = new Binding("Name") { RelativeSource = rs };
            txt1.SetBinding(TextBox.TextProperty, binding);
        }
    }
}
