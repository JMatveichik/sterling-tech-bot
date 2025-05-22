using SterlingTechBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SterlingTechBot.Services
{

	/// <summary>
	/// Пустой сервис для дизайнера
	/// </summary>
	public class MockTradeApiService : ITradeApiService
	{
		public Task<IEnumerable<Trade>> GetTrades(string accountId)
		{
			return Task.FromResult(Enumerable.Empty<Trade>());
		}
		public Task<string> CopyTrades(IEnumerable<Trade> trades, string targetAccountId)
		{
			return Task.FromResult("true");
		}
	}
}
