using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppNetTest.Model
{
    public enum Category
    {
        Bomber,
        Fighter
    }

    enum State
    {
        Unknown,
        Available,
        Locked
    }

    class Plane
    {
        public string Name { get; set; }

        public Category Category { get; set; }
        public State State { get; set; }
    }
}
