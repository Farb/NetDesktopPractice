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
using WpfAppNetTest.Model;

namespace WpfAppNetTest.Views
{
    /// <summary>
    /// BindingDemo1.xaml 的交互逻辑
    /// </summary>
    public partial class BindingDemo1 : Window
    {
        private Student student;
        public BindingDemo1()
        {
            InitializeComponent();

            #region v1
            /*
            //准备数据源
            student = new Student();
            //准备Binding
            var binding = new Binding();
            binding.Source = student;
            binding.Path = new PropertyPath("Name");

            //使用Binding连接数据源和Binding目标
            BindingOperations.SetBinding(this.txtName, TextBox.TextProperty, binding);
            */
            #endregion

            #region v2 简化版本
            txtName.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = student = new Student() });
            #endregion

            #region 绑定集合 的默认元素
            List<string> stringList = new List<string> { "Tim", "Tom", "Blog" };
            txtDefaultElement1.SetBinding(TextBox.TextProperty, new Binding("/") { Source = stringList });
            txtDefaultElement2.SetBinding(TextBox.TextProperty, new Binding("/Length") { Source = stringList, Mode = BindingMode.OneWay });
            txtDefaultElement3.SetBinding(TextBox.TextProperty, new Binding("/[2]") { Source = stringList, Mode = BindingMode.OneWay });
            #endregion

            #region 绑定泛型元素
            List<Country> countries = new List<Country>
            {
                new Country
                {
                    Name="中国",
                    ProvinceList=new List<Province>
                    {
                       new Province
                       {
                            Name="陕西",
                        CityList=new List<City>
                        {
                            new City
                            {
                                Name="西安"
                            }
                        }
                       }
                    }
                }
            };

            txtGenericElement1.SetBinding(TextBox.TextProperty, new Binding("/Name") { Source=countries});
            txtGenericElement2.SetBinding(TextBox.TextProperty,new Binding("/ProvinceList/Name") { Source=countries});
            txtGenericElement3.SetBinding(TextBox.TextProperty, new Binding("/ProvinceList/CityList/Name") { Source = countries });
            #endregion
        }

        private void btnAddName_Click(object sender, RoutedEventArgs e)
        {
            student.Name += "Name";
        }
    }
}
