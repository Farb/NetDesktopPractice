namespace WpfAppNetTest.Interfaces
{
    public interface IView
    {
        public bool IsChanged { get; set; }

        void SetBinding();

        void Clear();

        void Refresh();

        void Save();
    }
}
