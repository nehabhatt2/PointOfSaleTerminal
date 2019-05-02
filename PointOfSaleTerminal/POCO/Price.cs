namespace PointOfSale.POCO
{
	public class Price
	{
		public Price(int volumn, double price)
		{
			this.Amount = price;
			this.Volumn = volumn;
		}

		public double Amount { get; set; }
		public int Volumn { get; set; }
	}
}