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

namespace WpfAppNetTest.Views.Events
{
    /// <summary>
    /// BuiltInRoutedEvent.xaml 的交互逻辑
    /// </summary>
    public partial class BuiltInRoutedEvent01 : Window
    {
        public BuiltInRoutedEvent01()
        {
            InitializeComponent();
            gridRoot.AddHandler(Button.ClickEvent,new RoutedEventHandler(btnClick));
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            //获取最近的触发元素
            MessageBox.Show((sender as FrameworkElement).Name);
            //获取原始的触发元素
            MessageBox.Show((e.OriginalSource as FrameworkElement).Name);
        }
    }
}
