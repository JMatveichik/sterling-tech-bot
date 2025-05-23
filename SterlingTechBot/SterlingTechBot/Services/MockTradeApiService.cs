using SterlingLib;
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
		public Task<IEnumerable<structSTIOrderUpdate>> GetOrders(string accountId)
		{
			return Task.FromResult(Enumerable.Empty<structSTIOrderUpdate>());
		}

		public Task<bool> CopyOrders(string targetAccountId, IEnumerable<structSTIOrderUpdate> trades)
		{
			return Task.FromResult(true);
		}
	}
}
