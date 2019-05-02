using PointOfSale.POCO;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale
{
	public class PointOfSaleTerminal
	{
		ProductCatalogManager productCatalogManager;
		CartManager cartmanager;

		public PointOfSaleTerminal()
		{
			productCatalogManager = ProductCatalogManager.Instance;
			cartmanager = new CartManager();
		}

		public void SetPricing()
		{
			var a = new Product('A', 1.25);
			a.AddDiscountedPrice(3, 3.00);

			var b = new Product('B', 4.25);

			var c = new Product('C', 1.00);
			c.AddDiscountedPrice(6, 5.00);

			var d = new Product('D', 0.75);

			var e = new Product('E', 1.25);
			e.AddDiscountedPrice(3, 3.00);
			e.AddDiscountedPrice(5, 4.75);

			productCatalogManager.Add(a);
			productCatalogManager.Add(b);
			productCatalogManager.Add(c);
			productCatalogManager.Add(d);
			productCatalogManager.Add(e);
		}

		public List<char> GetAvailableProducts()
		{
			return productCatalogManager.Get().Select(x => x.Code).ToList();
		}

		public void Scan(char code)
		{
			var prod = productCatalogManager.Get(code);
			if (prod != null)
			{
				cartmanager.Add(code);
			}
		}

		public double CalculateTotal()
		{
			double price = 0;
			var cartItems = cartmanager.GetCart();
			foreach (var item in cartItems)
			{
				var prod = productCatalogManager.Get(item.Key);
				price += prod.BestPriceForGivenVolumn(item.Value, 0);
			}
			return price;
		}
	}
}
