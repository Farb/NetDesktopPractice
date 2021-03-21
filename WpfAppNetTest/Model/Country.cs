using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppNetTest.Model
{
    public class Country
    {
        public string Name { get; set; }
        public List<Province> ProvinceList { get; set; }
    }

    public class Province
    {
        public string Name { get; set; }
        public List<City> CityList { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
    }
}
