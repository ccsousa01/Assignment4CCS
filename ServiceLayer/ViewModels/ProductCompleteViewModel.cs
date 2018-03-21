


namespace ServiceLayer.ViewModels
{
    public class ProductCompleteViewModel
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public CategoryViewModel Category { get; set; }
    }

}
