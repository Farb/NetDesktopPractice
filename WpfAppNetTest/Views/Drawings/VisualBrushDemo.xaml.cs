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

namespace WpfAppNetTest.Views.Drawings
{
    /// <summary>
    /// VisualBrushDemo.xaml 的交互逻辑
    /// </summary>
    public partial class VisualBrushDemo : Window
    {
        public VisualBrushDemo()
        {
            InitializeComponent();
        }

        double opacity = 1;//不透明度计数器
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vb = new VisualBrush(realBtn);
            var rect = new Rectangle
            {
                Width = realBtn.ActualWidth,
                Height = realBtn.ActualHeight
            };

            rect.Fill = vb;
            rect.Opacity = opacity;
            opacity -= 0.2;
            rightStack.Children.Add(rect);
        }
    }
}
