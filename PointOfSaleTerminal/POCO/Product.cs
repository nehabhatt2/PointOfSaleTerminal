using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.POCO
{
	public class Product
	{
		public Product(char code, double singlePrice)
		{
			this.Code = code;
			this.PriceList = new HashSet<Price>
			{
				new Price(1, singlePrice)
			};
		}

		public void AddDiscountedPrice(int volumn, double discountedPrice)
		{
			this.PriceList.Add(new Price(volumn, discountedPrice));
		}

		public char Code { get; set; }
		public ICollection<Price> PriceList { get; set; }

		public double BestPriceForGivenVolumn(int volumn, double price)
		{
			if (volumn != 0)
			{
				var highestDiscount = this.PriceList.Where(x => x.Volumn <= volumn).OrderByDescending(x => x.Volumn).FirstOrDefault();
				if (highestDiscount == null)
					throw new Exception("Volumn less than expected");

				// no discounted price available for product, return straight forward the amount * volumn
				if (highestDiscount.Volumn == 1)
					return highestDiscount.Amount * volumn;

				var quot = Math.Abs(volumn / highestDiscount.Volumn);
				price = (quot * highestDiscount.Amount) + (BestPriceForGivenVolumn(volumn - (highestDiscount.Volumn * quot), price));
			}

			return price;
		}
	}
}
