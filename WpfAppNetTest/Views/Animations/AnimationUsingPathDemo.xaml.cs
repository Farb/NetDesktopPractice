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
    /// AnimationUsingPathDemo.xaml 的交互逻辑
    /// </summary>
    public partial class AnimationUsingPathDemo : Window
    {
        public AnimationUsingPathDemo()
        {
            InitializeComponent();
        }

        private void btnPathDemo_Click(object sender, RoutedEventArgs e)
        {
            //从XAML代码中获取移动路径数据
            var path = layoutRoot.FindResource("movingPath") as PathGeometry;

            Duration duration = new Duration(TimeSpan.FromSeconds(1));

            //创建动画
            var dx = new DoubleAnimationUsingPath
            {
                Duration=duration,
                PathGeometry=path,
                Source=PathAnimationSource.X,
                AutoReverse=true,
                RepeatBehavior=RepeatBehavior.Forever
            };
            var dy = new DoubleAnimationUsingPath
            {
                Duration = duration,
                PathGeometry = path,
                Source = PathAnimationSource.Y,
                AutoReverse=true,//自动返回
                RepeatBehavior=RepeatBehavior.Forever//永远循环
            };

            //执行动画
            tt.BeginAnimation(TranslateTransform.XProperty,dx);
            tt.BeginAnimation(TranslateTransform.YProperty,dy);
        }
    }
}
