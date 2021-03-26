using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using WpfAppNetTest.Model;

namespace WpfAppNetTest.Views
{
    /// <summary>
    /// BindingForConverter.xaml 的交互逻辑
    /// </summary>
    public partial class BindingForConverter : Window
    {
        public BindingForConverter()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            var planeList = new List<Plane>
            {
                new Plane{Name="B-1",Category=Category.Bomber,State=State.Unknown},
                new Plane{Name="B-2",Category=Category.Bomber,State=State.Unknown},
                new Plane{Name="F-22",Category=Category.Fighter,State=State.Unknown},
                new Plane{Name="Su-47",Category=Category.Fighter,State=State.Unknown},
                new Plane{Name="B-52",Category=Category.Bomber,State=State.Unknown},
                new Plane{Name="J-10",Category=Category.Fighter,State=State.Unknown},
            };
            listBoxPlane.ItemsSource = planeList;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            foreach (Plane p in listBoxPlane.Items)
            {
                sb.AppendLine($"Name={p.Name},Category={p.Category},State={p.State}");
            }
            File.WriteAllText("PlaneList.txt",sb.ToString());
        }
    }
}
