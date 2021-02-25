using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmDemo.Commands;

namespace WpfMvvmDemo.ViewModels
{
    class MainWindowViewModel : NotificationObject
    {
        public MainWindowViewModel()
        {
            AddCommand.ExecuteAction = Add;
            SaveCommand.ExecuteAction = Save;
        }
        private double input1;

        public double Input1
        {
            get { return input1; }
            set
            {
                input1 = value;
                RaisePropertyChanged(nameof(Input1));
            }
        }

        private double input2;

        public double Input2
        {
            get { return input2; }
            set { input2 = value; RaisePropertyChanged(nameof(Input2)); }
        }

        private double result;

        public double Result
        {
            get { return result; }
            set { result = value; RaisePropertyChanged(nameof(Result)); }
        }

        public void Add(object parameter)
        {
            Result = Input1 + Input2;
        }

        public void Save(object o)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
        }
        public DelegateCommand AddCommand { get; set; } = new DelegateCommand();
        public DelegateCommand SaveCommand { get; set; } = new DelegateCommand();


    }
}
