using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfAppNetTest.Model;

namespace WpfAppNetTest.Control
{
    /// <summary>
    /// CarListView.xaml 的交互逻辑
    /// </summary>
    public partial class CarListView : UserControl
    {
        public CarListView()
        {
            InitializeComponent();
        }
        private Car car;
        public Car Car
        {
            get { return car; }
            set
            {
                car = value;
                textBlockName.Text = car.Name;
                textBlockYear.Text = car.Year;
                string url = $"/Images/Cars/logo/{car.Automaker}.jpg";
                imageLogo.Source = new BitmapImage(new Uri(url, UriKind.RelativeOrAbsolute));
            }
        }
    }
}
