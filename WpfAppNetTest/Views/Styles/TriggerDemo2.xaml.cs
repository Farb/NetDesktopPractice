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
using WpfAppNetTest.Model;

namespace WpfAppNetTest.Views.Styles
{
    /// <summary>
    /// TriggerDemo2.xaml 的交互逻辑
    /// </summary>
    public partial class TriggerDemo2 : Window
    {
        public TriggerDemo2()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            var stuList = new List<StudentVm>
            {
                new StudentVm{Id=1,Name="Alice",Age=18},
                new StudentVm{Id=3,Name="Bob",Age=19},
                new StudentVm{Id=2,Name="Jack",Age=20},
                new StudentVm{Id=4,Name="Jenny",Age=17},
            };

            listBoxStudent.ItemsSource = stuList;
        }
    }
}
