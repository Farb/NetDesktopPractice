using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppNetTest
{
    public class MyButton:Button
    {
        public Type UserWindowType { get; set; }

        protected override void OnClick()
        {
            base.OnClick();
            object oWin = Activator.CreateInstance(UserWindowType);
            if (oWin is Window win)
            {
                win.ShowDialog();
            }

        }
    }
}
