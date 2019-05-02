using NUnit.Framework;
using PointOfSale;


namespace PointOfSaleTerminalTest
{
	public class Tests
	{
		PointOfSaleTerminal terminal;

		[SetUp]
		public void Setup()
		{
			terminal = new PointOfSaleTerminal();
			terminal.SetPricing();
		}

		[Test]
		public void Test_ABCDABA_Should_Result_13_25()
		{
			terminal.SetPricing();
			terminal.Scan('A');
			terminal.Scan('B');
			terminal.Scan('C');
			terminal.Scan('D');
			terminal.Scan('A');
			terminal.Scan('B');
			terminal.Scan('A');
			var result = terminal.CalculateTotal();
			Assert.AreEqual(result, 13.25);
		}

		[Test]
		public void Test_7C_Should_Result_6()
		{
			terminal.SetPricing();
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			var result = terminal.CalculateTotal();
			Assert.AreEqual(result, 6.00);
		}

		[Test]
		public void Test_13C_Should_Result_11()
		{
			terminal.SetPricing();
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			terminal.Scan('C');
			var result = terminal.CalculateTotal();
			Assert.AreEqual(result, 11.00);
		}

		[Test]
		public void Test_ABCD_Should_Result_7_25()
		{
			terminal.SetPricing();
			terminal.Scan('A');
			terminal.Scan('B');
			terminal.Scan('C');
			terminal.Scan('D');
			var result = terminal.CalculateTotal();
			Assert.AreEqual(result, 7.25);
		}

		[Test]
		public void Test_14E_Should_Result_13_75()
		{
			terminal.SetPricing();
			terminal.Scan('E');
			terminal.Scan('E');
			terminal.Scan('E');
			terminal.Scan('E');
			terminal.Scan('E');
			terminal.Scan('E');
			terminal.Scan('E');
			terminal.Scan('E');
			terminal.Scan('E');
			terminal.Scan('E');
			terminal.Scan('E');
			terminal.Scan('E');
			terminal.Scan('E');
			terminal.Scan('E');
			var result = terminal.CalculateTotal();
			Assert.AreEqual(result, 13.75);
		}

		[Test]
		public void Test_Invalid_Code_Not_Added_To_Cart()
		{
			terminal.SetPricing();
			terminal.Scan('R');
			var result = terminal.CalculateTotal();
			Assert.AreEqual(result, 0);
		}
	}
}