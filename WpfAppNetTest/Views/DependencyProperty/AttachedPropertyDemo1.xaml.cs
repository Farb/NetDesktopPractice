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

namespace WpfAppNetTest.Views.DependencyProperty
{
    /// <summary>
    /// AttachedPropertyDemo1.xaml 的交互逻辑
    /// </summary>
    public partial class AttachedPropertyDemo1 : Window
    {
        public AttachedPropertyDemo1()
        {
            InitializeComponent();
            InitilizeLayout();
        }

        private void InitilizeLayout()
        {
            var grid = new Grid { ShowGridLines = true };

            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width=new GridLength(100)});
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition(){Width = new GridLength(100)});

            grid.RowDefinitions.Add(new RowDefinition(){ Height = new GridLength(100)});
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100) });

            var button = new Button { Content = "ok" };
            Grid.SetRow(button, 1);
            Grid.SetColumn(button, 1);

            grid.Children.Add(button);
            sp.Children.Add(grid);
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var h = new HumanAttach();
            School.SetGrade(h, 6);
            int grade = School.GetGrade(h);
            MessageBox.Show(grade.ToString());
        }
    }
}
