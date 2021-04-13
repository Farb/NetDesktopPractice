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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppNetTest.Views.Animations
{
    /// <summary>
    /// SimpleAnimationDemo.xaml 的交互逻辑
    /// </summary>
    public partial class SimpleAnimationDemo : Window
    {
        public SimpleAnimationDemo()
        {
            InitializeComponent();
        }

        private readonly Random _random = new Random();
        private void btnShowAnimation_Click(object sender, RoutedEventArgs e)
        {
            var doubleX = new DoubleAnimation();
            var doubleY = new DoubleAnimation();
            var doubleW = new DoubleAnimation();
            var doubleH = new DoubleAnimation();

            //指定起点,如果不指定起点，则起点就是当前位置
            //doubleX.From = 0d;
            //doubleY.From = 0;

            //指定终点
            doubleX.To = _random.NextDouble() * 300;
            doubleY.To = _random.NextDouble() * 300;
            doubleW.To = _random.NextDouble() * 300;
            doubleH.To = _random.NextDouble() * 300;

            //指定持续时间
            var duration = new Duration(TimeSpan.FromMilliseconds(300));
            doubleX.Duration = duration;
            doubleY.Duration = duration;
            doubleW.Duration = duration;
            doubleH.Duration = duration;

            //动画的主体是TranslateTransform而不是Button
            tt.BeginAnimation(TranslateTransform.XProperty, doubleX);
            tt.BeginAnimation(TranslateTransform.YProperty, doubleY);
            btnShowAnimation.BeginAnimation(Button.WidthProperty, doubleW);
            btnShowAnimation.BeginAnimation(HeightProperty, doubleH);
        }
    }
}
