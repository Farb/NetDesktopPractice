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
using WpfAppNetTest.Model;

namespace WpfAppNetTest.Views
{
    /// <summary>
    /// ObjectDataProviderDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ObjectDataProviderDemo : Window
    {
        public ObjectDataProviderDemo()
        {
            InitializeComponent();
            SetBinding();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var odp = new ObjectDataProvider
            {
                ObjectInstance = new Calculator(),
                MethodName = "Add",
            };
            odp.MethodParameters.Add("1");
            odp.MethodParameters.Add("2");
            MessageBox.Show(odp.Data.ToString());
        }

        private void SetBinding()
        {
            //创建并配置ObjectDataProvider对象
            var odp = new ObjectDataProvider();
            odp.ObjectInstance = new Calculator();
            odp.MethodName = "Add";
            odp.MethodParameters.Add("0");
            odp.MethodParameters.Add("0");

            //以ObjectDataProvider对象为Source创建Binding
            var bindingArg1 = new Binding("MethodParameters[0]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            var bindingArg2 = new Binding("MethodParameters[1]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            var bindingToResult = new Binding(".") { Source = odp };

            txtArg1.SetBinding(TextBox.TextProperty, bindingArg1);
            txtArg2.SetBinding(TextBox.TextProperty, bindingArg2);
            txtResult.SetBinding(TextBox.TextProperty, bindingToResult);
        }
    }
}
