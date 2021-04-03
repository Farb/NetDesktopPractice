using System.Windows;
using WpfAppNetTest.Commands;

namespace WpfAppNetTest.Views.Commands
{
    /// <summary>
    /// CustomCommands.xaml 的交互逻辑
    /// </summary>
    public partial class CustomCommands : Window
    {
        public CustomCommands()
        {
            InitializeComponent();

            //声明命令 并使命令源和目标与之关联
            var clearCmd = new ClearCommand();
            ctrlClear.Command = clearCmd;
            ctrlClear.CommandTarget = miniView;
        }
    }
}
