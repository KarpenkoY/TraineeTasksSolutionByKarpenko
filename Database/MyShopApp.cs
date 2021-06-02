using System.Linq;

namespace MyShop
{
    class MyShopApp
    {
        static void Main(string[] args)
        {
            AppContext db = new AppContext();
            PopulateDatabase(db);


        }

        // Select product with product name that begins with ‘C’
        static IQueryable ProductNameQuery (AppContext db)
        {
            return from      p in db.Products
                   where     p.ProductName.First() == 'C'
                   select    p;

            
        }

        // Select product with the smallest price
        static double ProductSmallestPriceQuery (AppContext db)
        {
            return db.Products.Min(p => p.Price);
        }

        // Select cost of all products from the USA
        static IQueryable CostQuery (AppContext db)
        {
            return from     p in db.Products
                   from     s in db.Suppliers
                   where    p.SupplierID == s.SupplierID 
                         && s.Country == "USA"

                   select   p.Price;
        }

        // Select suppliers that supply Condiments
        static IQueryable SuppliersQuery (AppContext db)
        {
            return from      s in db.Suppliers
                   from      p in db.Products
                   from      c in db.Categories
                   where     s.SupplierID == p.SupplierID
                          && p.CategoryID == c.CategoryID
                          && c.CategoryName == "Condiments"
                   
                   select    s;
        }

        // Add to database new supplier
        static void AddEntitiesQuery (AppContext db)
        {
            var sNew = new Supplier()
            {
                SupplierName    = "Norske Meierier",
                City            = "Lviv",
                Country         = "Ukraine"
            };

            var cNew = new Category()
            {
                CategoryName = "Beverages"
            };

            db.Suppliers.Add(sNew);
            db.Categories.Add(cNew);
            db.SaveChanges();

            var pNew = new Product()
            {
                ProductName     = "Green tea",
                SupplierID      = sNew.SupplierID,
                CategoryID      = cNew.CategoryID,
                Price           = 10D
            };

            db.Products.Add(pNew);
            db.SaveChanges();
        }

        // Populate database
        static void PopulateDatabase (AppContext db)
        {
            var p1 = new Product(1, "Chais", 1, 1, 18.00);
            var p2 = new Product(2, "Chang", 1, 1, 19.00);
            var p3 = new Product(3, "Aniseed Syrup", 1, 2, 10.00);
            var p4 = new Product(4, "Chef Anton’s Cajun Seasoning", 2, 2, 22.00);
            var p5 = new Product(5, "Chef Anton’s Gumbo Mix", 2, 2, 21.35);
            db.Products.AddRange(p1, p2, p3, p4, p5);

            var s1 = new Supplier(1, "Exotic Liquid", "London", "UK");
            var s2 = new Supplier(2, "New Orleans Cajun Delights", "New Orleans", "USA");
            var s3 = new Supplier(3, "Grandma Kelly’s Homestead", "Ann Arbor", "USA");
            var s4 = new Supplier(4, "Tokyo Traders", "Tokyo", "Japan");
            var s5 = new Supplier(5, "Cooperativa de Quesos ‘Las Cabras’", "Oviedo", "Spain");
            db.Suppliers.AddRange(s1, s2, s3, s4, s5);

            var c1 = new Category(1, "Beverages", "Soft drinks, coffees, teas, beers, and ales");
            var c2 = new Category(2, "Condiments", "Sweet and savory sauces, relishes, spreads, and seasonings");
            var c3 = new Category(3, "Confections", "Desserts, candies, and sweet breads");
            var c4 = new Category(4, "Dairy Products", "Cheeses");
            var c5 = new Category(5, "Grains / Cereals", "Breads, crackers, pasta, and cereal");
            db.Categories.AddRange(c1, c2, c3, c4, c5);

            db.SaveChanges();
        }
    }
}
