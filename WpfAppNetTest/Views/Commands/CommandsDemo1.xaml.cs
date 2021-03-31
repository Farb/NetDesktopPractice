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
    /// CommandsDemo1.xaml 的交互逻辑
    /// </summary>
    public partial class CommandsDemo1 : Window
    {
        public CommandsDemo1()
        {
            InitializeComponent();
            InitCommand();
        }

        //声明并定义命令
        private RoutedCommand clearCmd = new RoutedCommand("Clear",typeof(CommandsDemo1));
    
        private void InitCommand()
        {
            //把命令赋值给命令源（发送者），并指定快捷键
            btnSend.Command = clearCmd;
            clearCmd.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));

            //指定命令目标
            btnSend.CommandTarget = txtMsg;

            //设置命令关联
            var cmdBinding = new CommandBinding(clearCmd);
            cmdBinding.CanExecute += CmdBinding_CanExecute;
            cmdBinding.Executed += CmdBinding_Executed;

            //把命令关联安置在外围控件上
            stackPanel.CommandBindings.Add(cmdBinding);
        }

        //当探测命令是否可执行时调用
        private void CmdBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMsg.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }

            //避免继续向上传影响性能
            e.Handled = true;
        }


        //当命令送到目标后调用
        private void CmdBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtMsg.Clear();
            //避免继续向上传影响性能
            e.Handled = true;
        }
    }
}
