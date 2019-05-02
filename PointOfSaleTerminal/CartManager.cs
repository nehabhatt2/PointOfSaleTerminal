using System.Collections.Generic;

namespace PointOfSale
{
	public class CartManager
	{
		/// Cart is collection of Product Code and their volumn
		readonly Dictionary<char, int> cart;

		public CartManager()
		{
			this.cart = new Dictionary<char, int>();
		}

		public void Add(char productCode)
		{
			if (this.cart.ContainsKey(productCode))
			{
				this.cart[productCode] += 1;
			}
			else
			{
				this.cart.Add(productCode, 1);
			}
		}

		public Dictionary<char, int> GetCart()
		{
			return this.cart;
		}

		public bool Remove(char key)
		{
			if (this.cart[key] > 1)
			{
				this.cart[key] -= 1;
			}
			else
			{
				this.cart.Remove(key);
			}

			return true;
		}
	}
}
