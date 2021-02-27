using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfAppNetTest
{
    [TypeConverter(typeof(StringToHumanTypeConverter))]
    public class Human
    {
        public string Name { get; set; }

        public Human Child { get; set; }
    }
}
