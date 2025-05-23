
using System;

namespace SterlingTechBot.Models
{
	// Сделка -  поля из XML определяются после изучения API
	public class Order
	{
		public string? Id { get; set; }
		public string? Symbol { get; set; }
		public string? Side { get; set; }
		public int? Quantity { get; set; }
		public string Timestamp { get; set; }

	}
}
