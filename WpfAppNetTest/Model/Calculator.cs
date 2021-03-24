namespace WpfAppNetTest.Model
{
    class Calculator
    {
        public string Add(string arg1,string arg2)
        {
            if (double.TryParse(arg1,out double x)&&double.TryParse(arg2,out double y))
            {
                return (x + y).ToString();
            }
            return "Input error!";
        }
    }
}
