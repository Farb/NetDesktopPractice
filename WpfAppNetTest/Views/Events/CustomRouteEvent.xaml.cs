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
    /// CustomRouteEvent.xaml 的交互逻辑
    /// </summary>
    public partial class CustomRouteEvent : Window
    {
        public CustomRouteEvent()
        {
            InitializeComponent();
        }


        private void ReportTimeHandler(object sender, Model.ReportTimeEventArgs e)
        {
            var element = sender as FrameworkElement;
            string timeString = e.ClickTime.ToLongTimeString();
            listBox.Items.Add($"{timeString}到达{element.Name}");

            //Bucket stop here
            if (element==grid2)
            {
                e.Handled = true;
            }
        }
    }
}
