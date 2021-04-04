using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAppNetTest.Validations;

namespace WpfAppNetTest.Views
{
    /// <summary>
    /// BindingForValidation.xaml 的交互逻辑
    /// </summary>
    public partial class BindingForValidation : Window
    {
        public BindingForValidation()
        {
            InitializeComponent();
            var binding = new Binding("Value") { Source = slider1 };
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.ValidationRules.Add(new RangeValidationRule() { ValidatesOnTargetUpdated = true });
            binding.NotifyOnValidationError = true;
            txtV.SetBinding(TextBox.TextProperty,binding);

            txtV.AddHandler(Validation.ErrorEvent,new RoutedEventHandler(ValidationErrorHandle));
        }

        private void ValidationErrorHandle(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(txtV))
            {
                txtV.ToolTip = Validation.GetErrors(txtV)[0].ErrorContent.ToString();
            }
        }
    }
}
