using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfAppNetTest.Commands
{
    class MyCommandSource : UserControl, ICommandSource
    {
        //继承自ICommandSource的属性
        public ICommand Command { get; set; }
        public object CommandParameter { get; set; }
        public IInputElement CommandTarget { get; set; }

        //左键单机时连带执行命令
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            //在命令目标上执行命令
            if (this.CommandTarget!=null)
            {
                Command.Execute(CommandTarget);
            }
        }
    }
}
