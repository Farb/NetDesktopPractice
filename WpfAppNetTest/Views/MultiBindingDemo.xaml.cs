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
using WpfAppNetTest.Converter;

namespace WpfAppNetTest.Views
{
    /// <summary>
    /// MultiBindingDemo.xaml 的交互逻辑
    /// </summary>
    public partial class MultiBindingDemo : Window
    {
        public MultiBindingDemo()
        {
            InitializeComponent();
            SetMultiBinding();
        }

        private void SetMultiBinding()
        {
            //准备基础Binding
            var b1 = new Binding("Text") { Source = txt1 };
            var b2 = new Binding("Text") { Source = txt2 };
            var b3 = new Binding("Text") { Source = txt3 };
            var b4 = new Binding("Text") { Source = txt4 };

            //准备MultiBinding
            var mb = new MultiBinding { Mode =BindingMode.OneWay};
            mb.Bindings.Add(b1);//Add子Binding的顺序是敏感的
            mb.Bindings.Add(b2);
            mb.Bindings.Add(b3);
            mb.Bindings.Add(b4);

            mb.Converter = new LoginMultiBindingConverter();

                //将Button和MultiBinding关联
                btnLogin.SetBinding(Button.IsEnabledProperty, mb);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
