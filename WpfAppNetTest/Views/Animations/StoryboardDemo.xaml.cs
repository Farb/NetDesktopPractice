using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfAppNetTest.Views.Animations
{
    /// <summary>
    /// StoryboardDemo.xaml 的交互逻辑
    /// </summary>
    public partial class StoryboardDemo : Window
    {
        public StoryboardDemo()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            var duration = new Duration(TimeSpan.FromSeconds(2));

            //红色小球匀速运动
            var daRed = new DoubleAnimation(400,duration);

            //绿色小球变速运动
            var daukfGreen = new DoubleAnimationUsingKeyFrames();
            daukfGreen.Duration = duration;
            SplineDoubleKeyFrame sdkf = new SplineDoubleKeyFrame(400, KeyTime.FromPercent(1));
            sdkf.KeySpline = new KeySpline(1, 0, 0, 1);
            daukfGreen.KeyFrames.Add(sdkf);

            //蓝色小球变速运动
            var daukfBlue = new DoubleAnimationUsingKeyFrames();
            daukfBlue.Duration = duration;
            SplineDoubleKeyFrame sdkf2 = new SplineDoubleKeyFrame(400, KeyTime.FromPercent(1));
            sdkf2.KeySpline = new KeySpline(0, 1, 1, 1);
            daukfBlue.KeyFrames.Add(sdkf2);

            //创建场景
            var sb = new Storyboard();
            Storyboard.SetTargetName(daRed,"ttRed");
            Storyboard.SetTargetProperty(daRed,new PropertyPath(TranslateTransform.XProperty));

            Storyboard.SetTargetName(daukfGreen, "ttGreen");
            Storyboard.SetTargetProperty(daukfGreen, new PropertyPath(TranslateTransform.XProperty));
           
            Storyboard.SetTargetName(daukfBlue, "ttBlue");
            Storyboard.SetTargetProperty(daukfBlue, new PropertyPath(TranslateTransform.XProperty));


            sb.Duration = duration;
            sb.Children.Add(daRed);
            sb.Children.Add(daukfGreen);
            sb.Children.Add(daukfBlue);
            sb.Begin(this);

            sb.Completed += Sb_Completed;
        }

        private void Sb_Completed(object sender, EventArgs e)
        {
            MessageBox.Show(ttRed.X.ToString());
        }
    }
}
