namespace Website.Models
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }

        public Product(int id, string name, 
            string qtyPerUnit = default(string),
            decimal? unitPrice = default(decimal?),
            short? unitsInStock = default(short?))
        {
            this.Id = id;
            this.Name = name;
            //
            this.QuantityPerUnit = qtyPerUnit;
            this.UnitPrice = unitPrice;
            this.UnitsInStock = unitsInStock;
        }
    }
}