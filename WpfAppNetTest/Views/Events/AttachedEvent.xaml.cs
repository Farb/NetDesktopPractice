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

namespace WpfAppNetTest.Views.Events
{
    /// <summary>
    /// AttachedEvent.xaml 的交互逻辑
    /// </summary>
    public partial class AttachedEvent : Window
    {
        public AttachedEvent()
        {
            InitializeComponent();
            //为外层Grid添加路由事件监听器

            //v1
            //gridMain.AddHandler(StudentForAttachedEvent.NameChangedEvent,new RoutedEventHandler(NameChangedEventHandler));
            
            //v2
            StudentForAttachedEvent.AddNameChangedEventHandler(gridMain, NameChangedEventHandler);
        }

        private void NameChangedEventHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as StudentForAttachedEvent).Name);
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var stu = new StudentForAttachedEvent { Name = "test" };
            //准备事件消息并发送路由事件
            var routedEventArgs = new RoutedEventArgs(StudentForAttachedEvent.NameChangedEvent, stu);
            btnOk.RaiseEvent(routedEventArgs);
        }
    }
}
