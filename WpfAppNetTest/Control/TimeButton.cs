using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfAppNetTest.Model;

namespace WpfAppNetTest.Control
{
    class TimeButton:Button
    {
        //声明和注册路由事件
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent
            ("ReportTime",RoutingStrategy.Bubble,typeof(EventHandler<ReportTimeEventArgs>),typeof(TimeButton));

        //CLR 事件包装器
        public event EventHandler<ReportTimeEventArgs> ReportTime
        {
            add { this.AddHandler(ReportTimeEvent, value); }
            remove { this.RemoveHandler(ReportTimeEvent, value); }
        }

        //激发路由事件，借助Click事件的激发方法
        protected override void OnClick()
        {
            base.OnClick();//保证Button原有功能正常，Click事件能被激发

            var args = new ReportTimeEventArgs(ReportTimeEvent,this);
            args.ClickTime = DateTime.Now;
            this.RaiseEvent(args);
        }
    }
}
