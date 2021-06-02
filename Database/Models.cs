
namespace MyShop
{
    public class Product
    {
        public int      ProductID { get; set; }
        public string   ProductName { get; set; }
        public int      SupplierID { get; set; }
        public int      CategoryID { get; set; }
        public double   Price { get; set; }

        public Product() { }
        public Product(int pID, string pName, int sID, int cID, double price)
        {
            ProductID       = pID;
            ProductName     = pName;
            SupplierID      = sID;
            CategoryID      = cID;
            Price           = price;
        }
    }

    public class Supplier
    {
        public int      SupplierID { get; set; }
        public string   SupplierName { get; set; }
        public string   City { get; set; }
        public string   Country { get; set; }

        public Supplier() { }
        public Supplier(int sID, string sName, string city, string country)
        {
            SupplierID      = sID;
            SupplierName    = sName;
            City            = city;
            Country         = country;
        }
    }

    public class Category
    {
        public int      CategoryID { get; set; }
        public string   CategoryName { get; set; }
        public string   Description { get; set; }

        public Category() { }
        public Category(int cID, string cName, string d)
        {
            CategoryID      = cID;
            CategoryName    = cName;
            Description     = d;
        }
    }
}
