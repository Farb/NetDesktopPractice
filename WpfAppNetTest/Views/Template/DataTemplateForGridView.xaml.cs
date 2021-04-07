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

namespace WpfAppNetTest.Views.Template
{
    /// <summary>
    /// DataTemplateForGridView.xaml 的交互逻辑
    /// </summary>
    public partial class DataTemplateForGridView : Window
    {
        public DataTemplateForGridView()
        {
            InitializeComponent();
        }

        private void tbName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = e.OriginalSource as TextBox;
            //获取模板目标
            ContentPresenter cp= tb.TemplatedParent as ContentPresenter;
            Person person = cp.Content as Person;
            listViewStudent.SelectedItem = person;

            //访问界面元素
            ListViewItem listViewItem = listViewStudent.ItemContainerGenerator.ContainerFromItem(person) as ListViewItem;
            CheckBox cb = FindVisualChild<CheckBox>(listViewItem);
            MessageBox.Show(cb.Name);
        }

        private T FindVisualChild<T>(DependencyObject dependencyObject)
            where T:DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);
                if (child is T t)
                {
                    return t;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
}
