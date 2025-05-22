
using System;

namespace SterlingTechBot.Models
{
	// Сделка -  поля из XML определяются после изучения API
	public class Trade
	{
		public string? Id { get; set; }
		public string? AccountId { get; set; }
		public decimal Amount { get; set; }
		public DateTime Timestamp { get; set; }

	}
}
