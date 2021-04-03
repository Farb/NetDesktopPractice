using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppNetTest.Interfaces;

namespace WpfAppNetTest.Commands
{
    public class ClearCommand : ICommand
    {
        //当命令可执行状态发生改变时 应当被激发
        public event EventHandler CanExecuteChanged;

        //命令是否可以执行
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        //执行命令，带有与业务相关的Clear逻辑
        public void Execute(object parameter)
        {
            IView view = parameter as IView;
            view?.Clear();
        }
    }
}
