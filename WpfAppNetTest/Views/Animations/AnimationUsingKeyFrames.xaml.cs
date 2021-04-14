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
    /// AnimationUsingKeyFrames.xaml 的交互逻辑
    /// </summary>
    public partial class AnimationUsingKeyFrames : Window
    {
        public AnimationUsingKeyFrames()
        {
            InitializeComponent();
        }

        private void btnShowAnimation_Click(object sender, RoutedEventArgs e)
        {
            var keyFrameAnimationX = new DoubleAnimationUsingKeyFrames();
            var keyFrameAnimationY = new DoubleAnimationUsingKeyFrames();

            //设置动画总时长
            keyFrameAnimationX.Duration = TimeSpan.FromSeconds(2);
            keyFrameAnimationY.Duration = TimeSpan.FromSeconds(2);

            //新增关键帧
            var lx01 = new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromPercent(0.3),
                Value = 400
            };
            var lx02 = new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromPercent(0.66),
                Value = 0
            };
            var lx03 = new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromPercent(1),
                Value = 400
            };

            keyFrameAnimationX.KeyFrames.Add(lx01);
            keyFrameAnimationX.KeyFrames.Add(lx02);
            keyFrameAnimationX.KeyFrames.Add(lx03);


            var ly01 = new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromPercent(0.3),
                Value = 00
            };
            var ly02 = new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromPercent(0.66),
                Value = 350
            };
            var ly03 = new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromPercent(1),
                Value = 350
            };
            keyFrameAnimationY.KeyFrames.Add(ly01);
            keyFrameAnimationY.KeyFrames.Add(ly02);
            keyFrameAnimationY.KeyFrames.Add(ly03);

            //执行动画
            tt.BeginAnimation(TranslateTransform.XProperty, keyFrameAnimationX);
            tt.BeginAnimation(TranslateTransform.YProperty, keyFrameAnimationY);
        }

        private void btnBrShow_Click(object sender, RoutedEventArgs e)
        {
            //创建动画
            var dkf = new DoubleAnimationUsingKeyFrames();
            dkf.Duration = new Duration(TimeSpan.FromSeconds(1));

            //创建 添加关键帧
            var splineKf = new SplineDoubleKeyFrame();
            splineKf.KeyTime = KeyTime.FromPercent(1);
            splineKf.Value = 400;
            KeySpline ks = new KeySpline();
            ks.ControlPoint1 = new Point(0, 1);
            ks.ControlPoint2= new Point(1, 0);
            splineKf.KeySpline = ks;

            dkf.KeyFrames.Add(splineKf);

            //执行动画
            tt2.BeginAnimation(TranslateTransform.XProperty,dkf);
        }
    }
}
