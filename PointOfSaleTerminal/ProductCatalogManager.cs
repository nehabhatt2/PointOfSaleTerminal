using PointOfSale.POCO;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale
{
	public sealed class ProductCatalogManager
	{
		static ProductCatalogManager instance = null;
		static List<Product> productCatalog;

		private ProductCatalogManager()
		{
			productCatalog = new List<Product>();
		}

		public static ProductCatalogManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ProductCatalogManager();
				}
				return instance;
			}
		}

		public void Add(Product product)
		{
			if (!productCatalog.Any(x => x.Code == product.Code))
			{
				productCatalog.Add(product);
			}
		}

		public Product Get(char code)
		{
			return productCatalog.FirstOrDefault(x => x.Code == code);
		}

		public List<Product> Get()
		{
			return productCatalog;
		}

		public bool Remove(char code)
		{
			return productCatalog.Remove(this.Get(code));
		}
	}
}
