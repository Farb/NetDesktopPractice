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

namespace WpfAppNetTest.Views.Commands
{
    /// <summary>
    /// CommandParameterDemo.xaml 的交互逻辑
    /// </summary>
    public partial class CommandParameterDemo : Window
    {
        public CommandParameterDemo()
        {
            InitializeComponent();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(txtName.Text);
        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string name = txtName.Text;
            if (e.Parameter.ToString()=="Teacher")
            {
                listBox.Items.Add($"New Teacher:{name}");
            }else if (e.Parameter.ToString() == "Student")
            {
                listBox.Items.Add($"New Student:{name}");
            }
        }
    }
}
