using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfAppNetTest.Model;

namespace WpfAppNetTest.Control
{
    /// <summary>
    /// CarDetailView.xaml 的交互逻辑
    /// </summary>
    public partial class CarDetailView : UserControl
    {
        public CarDetailView()
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
                textBlockTopSpeed.Text = car.TopSpeed;
                textBlockAutomaker.Text = car.Automaker;
                
                imagePhoto.Source = new BitmapImage(new System.Uri($"/Images/Cars/{car.Name}.jpg",System.UriKind.Relative));
            }
        }
    }
}
