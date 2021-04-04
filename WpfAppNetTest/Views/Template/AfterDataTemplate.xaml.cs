using System.Collections.Generic;
using System.Windows;
using WpfAppNetTest.Model;

namespace WpfAppNetTest.Views.Template
{
    /// <summary>
    /// AfterDataTemplate.xaml 的交互逻辑
    /// </summary>
    public partial class AfterDataTemplate : Window
    {
        public AfterDataTemplate()
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

            listBoxCars.ItemsSource = carList;
        }
    }
}
