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
using WpfAppNetTest.Control;
using WpfAppNetTest.Model;

namespace WpfAppNetTest.Views.Template
{
    /// <summary>
    /// PreDataTemplate.xaml 的交互逻辑
    /// </summary>
    public partial class PreDataTemplate : Window
    {
        public PreDataTemplate()
        {
            InitializeComponent();
            InitializeCarList();
        }

        private void InitializeCarList()
        {
            var carList = new List<Car>
            {
                new Car{Automaker="Audi",Name="AudiCar",Year="1890",TopSpeed="260"},
                new Car{Automaker="Bentley",Name="BentleyCar",Year="1891",TopSpeed="270"},
                new Car{Automaker="Benz",Name="BenzCar",Year="1892",TopSpeed="250"},
                new Car{Automaker="BMW",Name="BMWCar",Year="1893",TopSpeed="280"},
                new Car{Automaker="ChuanQi",Name="ChuanQiCar",Year="1990",TopSpeed="220"},
                new Car{Automaker="Ferrari",Name="FerrariCar",Year="1870",TopSpeed="360"},
                new Car{Automaker="Martin",Name="MartinCar",Year="1820",TopSpeed="560"},
            };

            foreach (Car car in carList)
            {
                var carListView = new CarListView();
                carListView.Car = car;
                listBoxCars.Items.Add(carListView);
            }
        }

        private void listBoxCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var carListView= e.AddedItems[0] as CarListView;
            if (carListView != null)
            {
                carDetailView.Car = carListView.Car;
            }
        }
    }
}
