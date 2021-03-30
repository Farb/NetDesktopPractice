using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppNetTest.Model
{
    class StudentForAttachedEvent
    {
        //声明并定义路由事件
        public static readonly RoutedEvent NameChangedEvent = EventManager
            .RegisterRoutedEvent("NameChanged",RoutingStrategy.Bubble,typeof(RoutedEventHandler),typeof(StudentForAttachedEvent));
        public string Name { get; set; }

        //以下方法命名为微软规定这样添加附加事件  Add[EventName]Handler
        public static void AddNameChangedEventHandler(DependencyObject dp,RoutedEventHandler h)
        {
            if (dp is UIElement element)
            {
                element.AddHandler(NameChangedEvent, h);
            }
        }

        public static void RemoveNameChangedEventHandler(DependencyObject dp,RoutedEventHandler h)
        {
            if (dp is UIElement element)
            {
                element.RemoveHandler(NameChangedEvent,h);
            }
        }
    }
}
