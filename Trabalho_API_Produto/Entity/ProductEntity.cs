namespace Trabalho_API_Produto.Entity
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double OriginalPrice { get; set; }
        public double CurrentPrice { get; set; }
        public double Discount { get; set; }
        public int Buyers { get; set; }
    }
}
