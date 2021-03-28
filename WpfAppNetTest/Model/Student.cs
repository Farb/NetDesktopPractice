using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace WpfAppNetTest.Model
{
    public class Student:DependencyObject,INotifyPropertyChanged
    {
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id",typeof(string),typeof(Student));
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(nameof(Name)); }
        }

        public string Id { get=>GetValue(IdProperty).ToString(); set=>SetValue(IdProperty,value); }


        public int No
        {
            get { return (int)GetValue(NoProperty); }
            set { SetValue(NoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for No.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NoProperty =
            DependencyProperty.Register("No", typeof(int), typeof(Student), new PropertyMetadata(0));


        public BindingExpressionBase SetBinding(DependencyProperty dp,BindingBase binding)
        {
            return BindingOperations.SetBinding(this, IdProperty, binding);
        }
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
