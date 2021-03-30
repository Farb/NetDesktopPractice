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
    /// EventSourceDemo.xaml 的交互逻辑
    /// </summary>
    public partial class EventSourceDemo : Window
    {
        public EventSourceDemo()
        {
            InitializeComponent();
            //为主窗体添加ButtonClick的监听
            AddHandler(Button.ClickEvent, new RoutedEventHandler(btnClick));
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            string originalSource=$"Visual tree start point is:{(e.OriginalSource as FrameworkElement).Name},type is:{e.OriginalSource.GetType().Name}";

            string source = $"Logical tree start point:{(e.Source as FrameworkElement).Name},type is:{e.Source.GetType().Name}";

            MessageBox.Show(source+"\n"+originalSource);
        }
    }
}
